using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Miku.MP.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var r = Uri.EscapeUriString("Hello Test");
            var c = new HttpClient();
            //c.DefaultRequestHeaders.Add("x-youtube-client-name", "56");
            //c.DefaultRequestHeaders.Add("x-youtube-client-version", "20200911");
            var ret = await c.GetStringAsync("https://youtube.com/get_video_info?style=json&video_id=XSLhsjepelI");
            var hm = WebUtility.UrlDecode(ret);
            var t = hm.IndexOf('{');
            var c1 = hm.Substring(t);
            var l = c1.LastIndexOf('}');
            var c2 = c1.Substring(0, l +1);
            var h = JsonSerializer.Deserialize<YoutubeVideo>(c2);
        }
    }
}
