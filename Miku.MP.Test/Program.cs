using HtmlAgilityPack;
using NNDD.Entities;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace Miku.MP.Test
{
    class Program
    {
        public static CookieContainer CookieContainer { get; set; } = new CookieContainer();
        static async Task Main(string[] args)
        {
            var r = Uri.EscapeUriString("Hello Test");
            var c = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = CookieContainer,
                UseCookies = true,
                UseDefaultCredentials = false
            });

            await DoLoginAsync(c, "MAIL/TEL", "PASS");
            var watchData = await GetWatchDataAsync(c, "sm37918839");
            var vid = await GetVideoSessionAsync(c, watchData);
            var masterPlaylist = vid.DataField.Session.ContentUri;
            var masterPLString = await c.GetStringAsync(masterPlaylist);
            var apirUrl = masterPlaylist.AbsoluteUri.Split("master.m3u8")[0];
            M3uContent content = new M3uContent();
            M3uPlaylist playlist = content.GetFromString(masterPLString);
            var plpl = playlist.PlaylistEntries.First();
            var playlistPlaylist = await c.GetStringAsync(apirUrl + plpl.Path);
            HlsMediaContent hlspl = new HlsMediaContent();
            HlsMediaPlaylist playlist1 = hlspl.GetFromString(playlistPlaylist);
            //c.DefaultRequestHeaders.Host = "vodedge637.dmc.nico";
            //c.DefaultRequestHeaders.Referrer = new Uri("https://www.nicovideo.jp/watch/sm37918839");
            var firstPl = await c.GetAsync(apirUrl + "1/ts/" + playlist1.PlaylistEntries.First().Path);
            //c.DefaultRequestHeaders.Add("x-youtube-client-name", "56");
            //c.DefaultRequestHeaders.Add("x-youtube-client-version", "20200911");
        }

        private static async Task<VideoAPIData> GetVideoSessionAsync(HttpClient c, WatchData watchData)
        {
            var session = new SessionJsonHLS(watchData, watchData.Video.DmcInfo.SessionApi.Audios.First(), watchData.Video.DmcInfo.SessionApi.Videos.Last());
            var sessionTxt = JsonSerializer.Serialize(session);
            var url = watchData.Video.DmcInfo.SessionApi.Urls.First().UrlField + "?_format=json";
            var vidData = new StringContent(sessionTxt, Encoding.UTF8, "application/json");

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = vidData;
                var resp = await c.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                var asJsonPlain = await resp.Content.ReadAsStringAsync();
                return await JsonSerializer.DeserializeAsync<VideoAPIData>(await resp.Content.ReadAsStreamAsync());
            }
        }

        private static async Task<WatchData> GetWatchDataAsync(HttpClient c, string url)
        {
            var apiData = await c.GetStringAsync($"https://www.nicovideo.jp/watch/{url}");
            var doc = new HtmlDocument();
            doc.LoadHtml(apiData);
            var element = doc.DocumentNode.SelectSingleNode("//*[@id='js-initial-watch-data']");
            var json = element.Attributes.FirstOrDefault(x => x.Name == "data-api-data");
            var correctJson = HttpUtility.HtmlDecode(json.Value);
            return JsonSerializer.Deserialize<WatchData>(correctJson);
        }

        private static async Task DoLoginAsync(HttpClient c, string email, string password)
        {
            var sb = new StringContent($"mail={email}&password={password}&site=nicometro");
            sb.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var res = await c.PostAsync("https://account.nicovideo.jp/login/redirector", sb);
            var login = await res.Content.ReadAsStringAsync();
            var reader = new StringReader(login);
            var serializer = new XmlSerializer(typeof(LoginData.Nicovideo_user_response));
            var loginobj = (serializer.Deserialize(reader)) as LoginData.Nicovideo_user_response;
            var cookie = new Cookie("user_session", loginobj.Session_key, "/", "nicovideo.jp");
            CookieContainer.Add(new Uri("http://api.ce.nicovideo.jp"), cookie);
        }
    }
}
