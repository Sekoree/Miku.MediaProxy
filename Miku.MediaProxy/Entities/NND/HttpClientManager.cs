using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NNDD.Entities
{
    public class HttpClientManager
    {
        private List<ManagedHttpClient> _managedHttpClients { get; set; }

        public HttpClientManager()
        {
            _managedHttpClients = new List<ManagedHttpClient>();
        }

        public ManagedHttpClient GetManagedHttpClient()
        {
            if (_managedHttpClients.All(x => x.InUse))
            {
                var mhc = new ManagedHttpClient();
                mhc.ChangeStatus();
                _managedHttpClients.Add(mhc);
                return mhc;
            }
            var hc = _managedHttpClients.First(x => !x.InUse);
            hc.ChangeStatus();
            return hc;
        }
    }
}
