using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Miku.MediaProxy.Entities.NND.ResultEntities;
using NNDD.Entities;
using NNDD.Entities.ResultEntities;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace NNDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NNDController : ControllerBase
    {
        private readonly ILogger<NNDController> _logger;
        private readonly HttpClientManager _httpClientManager;
        private readonly string _email = "EMAIL/TEL";
        private readonly string _password = "PASSWORD";

        //Taken from youtube-dl (and converted vor dotnet regex)
        private readonly Regex _nndRegex =
            new Regex("https?://(?:www\\.|secure\\.|sp\\.)?nicovideo\\.jp/watch/(?<id>(?:[a-z]{2})?[0-9]+)");

        public NNDController(ILogger<NNDController> logger, HttpClientManager httpClientManager)
        {
            this._logger = logger;
            this._httpClientManager = httpClientManager;
        }

        [Route("{id}/info")]
        public async Task<TrackInfo> GetNNDVideoInfoAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("no video ID specified");
            var c = _httpClientManager.GetManagedHttpClient();
            TrackInfo info = default;
            try
            {
                var watchData = await GetWatchDataAsync(c, id);

                info = new TrackInfo
                {
                    Author = watchData.OwnerField.Nickname,
                    AuthorUrl = new Uri($"https://www.nicovideo.jp/user/{watchData.OwnerField.Id}"),
                    AuthorIconUrl = watchData.OwnerField.IconUrl,
                    DirectUrl = new Uri($"https://{this.HttpContext.Request.Host.Value}/nnd/{id}"),
                    IsLive = id.StartsWith("lv"),
                    Length = watchData.Video.Duration.HasValue ? watchData.Video.Duration.Value : 0,
                    ThumbnailUrl = watchData.Video.LargeThumbnailUrl,
                    Title = watchData.Video.Title,
                    TrackUrl = new Uri($"https://www.nicovideo.jp/watch/{id}"),
                    UploadDate = DateTimeOffset.Parse(watchData.Video.PostedDateTime)
                };
            }
            finally
            {
                c.ChangeStatus();
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}");
            }
            return info;
        }

        [Route("{id}/infoex")]
        public async Task<TrackInfoExtended> GetNNDVideoInfoExtendedAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("no video ID specified");
            var c = _httpClientManager.GetManagedHttpClient();
            TrackInfoExtended info = default;
            try
            {
                await DoLoginAsync(c, _email, _password);
                var watchData = await GetWatchDataAsync(c, id);

                info = new TrackInfoExtended
                {
                    Author = watchData.OwnerField.Nickname,
                    AuthorUrl = new Uri($"https://www.nicovideo.jp/user/{watchData.OwnerField.Id}"),
                    AuthorIconUrl = watchData.OwnerField.IconUrl,
                    DirectUrl = new Uri($"https://{this.HttpContext.Request.Host.Value}/nnd/{id}"),
                    IsLive = id.StartsWith("lv"),
                    Length = watchData.Video.Duration.HasValue ? watchData.Video.Duration.Value : 0,
                    ThumbnailUrl = watchData.Video.LargeThumbnailUrl,
                    Title = watchData.Video.Title,
                    TrackUrl = new Uri($"https://www.nicovideo.jp/watch/{id}"),
                    UploadDate = DateTimeOffset.Parse(watchData.Video.PostedDateTime),
                    Description = watchData.Video.Description,
                    AudioQualities = watchData.Video.DmcInfo.SessionApi.Audios,
                    VideoQualities = watchData.Video.DmcInfo.SessionApi.Videos
                };
            }
            finally
            {
                c.ChangeStatus();
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}");
            }
            return info;
        }

        [Route("{id}/a")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task GetNNDVideoAsAudioAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) throw new Exception("no video ID specified");

                HttpContext.Response.ContentType = "audio/mpeg";
                var ffmpeg = Process.Start(new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments =
                        $@"-i ""https://{this.HttpContext.Request.Host.Value}/nnd/{id}"" -f mp3 -ac 2 -b:a 320k pipe:1",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                });
                int read;
                byte[] buffer = new byte[8192];
                while ((read = await ffmpeg.StandardOutput.BaseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await HttpContext.Response.Body.WriteAsync(buffer, 0, read);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            finally
            {
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}");
            }
        }

        [Route("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task GetNNDVideoAsync(string id, string video = null, string audio = null)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("no video ID specified");
            var c = _httpClientManager.GetManagedHttpClient();
            var s = new Stopwatch();
            s.Start();
            await DoLoginAsync(c, _email, _password);

            try
            {
                long? readBytes = 0;
                while (true)
                {
                    var watchData = await GetWatchDataAsync(c, id);
                    var videoSession = await GetVideoSessionAsync(c, watchData, video, audio);

                    if (readBytes != 0)
                        c.Client.DefaultRequestHeaders.Range = new RangeHeaderValue(readBytes, null);

                    var videoStream = await c.Client.GetAsync(videoSession.DataField.Session.ContentUri, HttpCompletionOption.ResponseHeadersRead);

                    if (HttpContext.Response.ContentType != videoStream.Content.Headers.ContentType.MediaType)
                        HttpContext.Response.ContentType = videoStream.Content.Headers.ContentType.MediaType;

                    readBytes = await WriteToOutputAsync(videoStream, HttpContext.Response.Body, readBytes);

                    if (readBytes == null
                        || (videoStream.Content.Headers.ContentRange != null
                            && videoStream.Content.Headers.ContentRange?.Length == readBytes)
                        || videoStream.Content.Headers.ContentLength == readBytes)
                    {
                        _logger.LogInformation("Finished proxy for " + id);
                        c.ChangeStatus();
                        return;
                    }
                }
            }
            finally
            {
                c.ChangeStatus();
                s.Stop();
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}\n" +
                    $"Time taken: {s.Elapsed.TotalSeconds} Seconds");
            }
            
        }

        //HLS is even slower (and kinda just unnecessairy by that?)
        //[Route("{id}/hls")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public async Task GetNNDVideoHLSAsync(string id)
        //{
        //    if (string.IsNullOrWhiteSpace(id)) throw new Exception("no video ID specified");
        //    var c = _httpClientManager.GetManagedHttpClient();
        //
        //    await DoLoginAsync(c, "MAIL/TEL", "PASSWORD");
        //
        //    try
        //    {
        //        var watchData = await GetWatchDataAsync(c, id);
        //        var videoSession = await GetVideoSessionHLSAsync(c, watchData);
        //
        //        var masterPlaylist = await c.Client.GetStringAsync(videoSession.DataField.Session.ContentUri);
        //        var apirUrl = videoSession.DataField.Session.ContentUri.AbsoluteUri.Split("master.m3u8")[0];
        //
        //        M3uContent content = new M3uContent();
        //        M3uPlaylist masterPlaylistObj = content.GetFromString(masterPlaylist);
        //        var playlistPlaylist = await c.Client.GetStringAsync(apirUrl + masterPlaylistObj.PlaylistEntries.First().Path);
        //
        //        HlsMediaContent hlspl = new HlsMediaContent();
        //        HlsMediaPlaylist playlistPlaylistObj = hlspl.GetFromString(playlistPlaylist);
        //
        //        HttpContext.Response.ContentType = "audio/mpeg";
        //        var ffmpeg = Process.Start(new ProcessStartInfo
        //        {
        //            FileName = "ffmpeg",
        //            Arguments =
        //                $@"-protocol_whitelist pipe,https,tcp,tls,file,data,crypto -f concat -safe 0 -i - -f mp3 -ac 2 -b:a 320k pipe:1",
        //            RedirectStandardOutput = true,
        //            RedirectStandardInput = true,
        //            UseShellExecute = false
        //        });
        //
        //        foreach (var item in playlistPlaylistObj.PlaylistEntries)
        //        {
        //            await ffmpeg.StandardInput.WriteLineAsync($"file '{apirUrl}1/ts/{item.Path}'");
        //        }
        //
        //        await ffmpeg.StandardOutput.BaseStream.CopyToAsync(HttpContext.Response.Body);
        //
        //    }
        //    finally
        //    {
        //        c.ChangeStatus();
        //        _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
        //            $"Parameter: {id}\n" +
        //            $"Client IP: {HttpContext.Connection.RemoteIpAddress}");
        //    }
        //
        //}

        private async Task<long?> WriteToOutputAsync(HttpResponseMessage c, Stream outputStream, long? readBytes = 0)
        {
            try
            {
                var s = new Stopwatch();
                s.Start();
                using (var stream = await c.Content.ReadAsStreamAsync())
                {
                    int read;
                    byte[] buffer = new byte[8192];
                    while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await outputStream.WriteAsync(buffer, 0, read);
                        readBytes += Convert.ToInt64(read);
                        if (s.ElapsedMilliseconds > 7500)
                        {
                            s.Stop();
                            break;
                        }
                    }
                }
            }
            catch (IOException ex) 
            {
                _logger.LogInformation("Expected NND I/O Error:\n" + ex);
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Unexpected error:\n" + ex);
                return null; 
            }
            return readBytes;
        }

        private async Task<VideoAPIData> GetVideoSessionAsync(ManagedHttpClient c, WatchData watchData, string video = null, string audio = null)
        {
            if (video == null 
                || !watchData.Video.DmcInfo.SessionApi.Videos.Any(x => x == video)) video = watchData.Video.DmcInfo.SessionApi.Videos.Last();
            if (audio == null
                || !watchData.Video.DmcInfo.SessionApi.Audios.Any(x => x == audio)) audio = watchData.Video.DmcInfo.SessionApi.Audios.First();
            var session = new SessionJson(watchData, audio, video);
            var sessionTxt = JsonSerializer.Serialize(session);
            var url = watchData.Video.DmcInfo.SessionApi.Urls.First().UrlField + "?_format=json";
            var vidData = new StringContent(sessionTxt, Encoding.UTF8, "application/json");

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = vidData;
                var resp = await c.Client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                return await JsonSerializer.DeserializeAsync<VideoAPIData>(await resp.Content.ReadAsStreamAsync());
            }
        }

        private async Task<VideoAPIData> GetVideoSessionHLSAsync(ManagedHttpClient c, WatchData watchData)
        {
            var session = new SessionJsonHLS(watchData, watchData.Video.DmcInfo.SessionApi.Audios.First(), watchData.Video.DmcInfo.SessionApi.Videos.Last());
            var sessionTxt = JsonSerializer.Serialize(session);
            var url = watchData.Video.DmcInfo.SessionApi.Urls.First().UrlField + "?_format=json";
            var vidData = new StringContent(sessionTxt, Encoding.UTF8, "application/json");

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = vidData;
                var resp = await c.Client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                return await JsonSerializer.DeserializeAsync<VideoAPIData>(await resp.Content.ReadAsStreamAsync());
            }
        }

        private async Task<WatchData> GetWatchDataAsync(ManagedHttpClient usedClient, string url)
        {
            var apiData = await usedClient.Client.GetStringAsync($"https://www.nicovideo.jp/watch/{url}");
            var doc = new HtmlDocument();
            doc.LoadHtml(apiData);
            var element = doc.DocumentNode.SelectSingleNode("//*[@id='js-initial-watch-data']");
            var json = element.Attributes.FirstOrDefault(x => x.Name == "data-api-data");
            return JsonSerializer.Deserialize<WatchData>(HttpUtility.HtmlDecode(json.Value));
        }

        private async Task DoLoginAsync(ManagedHttpClient usedClient, string email, string password)
        {
            var sb = new StringContent($"mail={email}&password={password}&site=nicometro");
            sb.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var res = await usedClient.Client.PostAsync("https://account.nicovideo.jp/login/redirector", sb);
            var login = await res.Content.ReadAsStringAsync();
            var reader = new StringReader(login);
            var serializer = new XmlSerializer(typeof(LoginData.Nicovideo_user_response));
            var loginobj = (serializer.Deserialize(reader)) as LoginData.Nicovideo_user_response;
            var cookie = new Cookie("user_session", loginobj.Session_key, "/", "nicovideo.jp");
            usedClient.CookieContainer.Add(new Uri("http://api.ce.nicovideo.jp"), cookie);
        }
    }
}