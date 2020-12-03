using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NNDD.Entities
{
    public class ManagedHttpClient
    {
        public HttpClient Client { get; private set; }
        public CookieContainer CookieContainer { get; private set; }
        public bool InUse { get; private set; }

        public ManagedHttpClient()
        {
            CookieContainer = new CookieContainer();
            Client = new HttpClient(new HttpClientHandler 
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = CookieContainer,
                UseCookies = true,
                UseDefaultCredentials = false
            });
        }

        public void ChangeStatus()
        {
            InUse = !InUse;
        }
    }
}
