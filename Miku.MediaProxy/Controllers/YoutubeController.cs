using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Miku.Entities.Youtube;
using NNDD.Entities;
using NNDD.Entities.ResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace NNDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : Controller
    {
        private readonly ILogger<YoutubeController> _logger;
        private readonly HttpClientManager _httpClientManager;
        private readonly YoutubeClient _youtubeClient;

        public YoutubeController(ILogger<YoutubeController> logger, HttpClientManager httpClientManager, YoutubeClient youtubeClient)
        {
            this._logger = logger;
            this._httpClientManager = httpClientManager;
            this._youtubeClient = youtubeClient;
        }

        [Route("{id}/info")]
        public async Task<TrackInfo> GetYTTrackInfoAsync(string id)
        {
            var c = _httpClientManager.GetManagedHttpClient();
            bool usedYE = false;
            try
            {
                var ret = await c.Client.GetStringAsync($"https://youtube.com/get_video_info?video_id={id}&hl=en&el=embedded");
                var hm = WebUtility.UrlDecode(ret);
                var t = hm.IndexOf('{');
                var c1 = hm.Substring(t);
                var l = c1.LastIndexOf('}');
                var c2 = c1.Substring(0, l + 1);
                var h = JsonSerializer.Deserialize<YoutubeVideo>(c2);
                Uri audurl = default;

                if (h.StreamingDataField == null || h.StreamingDataField?.AdaptiveFormats?.Any(x => x.Url == null) == true)
                {
                    var manif = await _youtubeClient.Videos.Streams.GetManifestAsync(new VideoId(id));
                    audurl = new Uri(manif.GetAudioOnly().WithHighestBitrate().Url);
                    usedYE = true;
                    //_logger.LogInformation("YoutubeExplode handled");
                }
                else
                {
                    audurl = h.StreamingDataField
                    .AdaptiveFormats
                    .OrderByDescending(x => x.AudioSampleRate)
                    .First(x => x.MimeType.Contains("opus")).Url;
                    //_logger.LogInformation("Direct handled");
                }
                var info = new TrackInfo
                {
                    Author = h.VideoDetailsField.Author,
                    AuthorIconUrl = null, //no fast endpoint for that
                    AuthorUrl = h.MicroformatField.PlayerMicroformatRenderer.OwnerProfileUrl,
                    IsLive = h.VideoDetailsField.IsLiveContent.GetValueOrDefault(),
                    Length = double.Parse(h.VideoDetailsField.LengthSeconds),
                    DirectUrl = audurl,
                    ThumbnailUrl = h.VideoDetailsField.Thumbnail.Thumbnails.OrderByDescending(x => x.Width).First().Url,
                    Title = h.VideoDetailsField.Title,
                    TrackUrl = new Uri($"https://www.youtube.com/watch?v={h.VideoDetailsField.VideoId}"),
                    UploadDate = h.MicroformatField.PlayerMicroformatRenderer.UploadDate.GetValueOrDefault()
                };
                c.ChangeStatus();
                return info;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            finally
            {
                var manifString = usedYE ? "YoutubeExplode" : "Direct";
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}\n" +
                    $"Manifest got from: {manifString}");
                c.ChangeStatus();
            }
            return default;
        }

        [Route("{id}")]
        public async Task GetYTTrackWiteAsync(string id)
        {

            var c = _httpClientManager.GetManagedHttpClient();
            try
            {
                //var video = await _youtubeClient.Videos.GetAsync($"https://youtube.com/watch?v=" + id);
                var ret = await c.Client.GetStringAsync($"https://youtube.com/get_video_info?style=json&video_id={id}");
                var hm = WebUtility.UrlDecode(ret);
                var t = hm.IndexOf('{');
                var c1 = hm.Substring(t);
                var l = c1.LastIndexOf('}');
                var c2 = c1.Substring(0, l + 1);
                var h = JsonSerializer.Deserialize<YoutubeVideo>(c2);
                var url = h.StreamingDataField
                .AdaptiveFormats
                .OrderByDescending(x => x.AudioSampleRate)
                .First(x => x.MimeType.Contains("opus")).Url;
                var resp = await c.Client.GetAsync(url, System.Net.Http.HttpCompletionOption.ResponseHeadersRead);
                HttpContext.Response.ContentType = resp.Content.Headers.ContentType.MediaType;
                using (var stream = await resp.Content.ReadAsStreamAsync())
                {
                    int read;
                    byte[] buffer = new byte[8192];
                    while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await HttpContext.Response.Body.WriteAsync(buffer, 0, read);
                    }
                }
            }
            finally
            {
                c.ChangeStatus();
                _logger.LogInformation($"Path: {HttpContext.Request.Path}\n" +
                    $"Parameter: {id}\n" +
                    $"Client IP: {HttpContext.Connection.RemoteIpAddress}");
            }
        }
    }
}
