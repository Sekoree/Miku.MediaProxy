using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NNDD.Entities;
using NNDD.Entities.ResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
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
            var video = await _youtubeClient.Videos.GetAsync($"https://youtube.com/watch?v=" + id);
            var user = await _youtubeClient.Channels.GetAsync(video.ChannelId);
            var manif = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
            var info = new TrackInfo
            {
                Author = video.Author,
                AuthorIconUrl = new Uri(user.LogoUrl),
                AuthorUrl = new Uri(user.Url),
                IsLive = false,
                Length = video.Duration.TotalSeconds,
                DirectUrl = new Uri(manif.GetAudioOnly().WithHighestBitrate().Url),
                ThumbnailUrl = new Uri(video.Thumbnails.MaxResUrl),
                Title = video.Title,
                TrackUrl = new Uri(video.Url),
                UploadDate = video.UploadDate
            };
            return info;
        }
        [Route("{id}")]
        public async Task GetYTTrackWiteAsync(string id)
        {

            var c = _httpClientManager.GetManagedHttpClient();
            try
            {
                //var video = await _youtubeClient.Videos.GetAsync($"https://youtube.com/watch?v=" + id);
                var manif = await _youtubeClient.Videos.Streams.GetManifestAsync(id);
                var url = manif.GetMuxed().WithHighestBitrate().Url;
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
            }
        }
    }
}
