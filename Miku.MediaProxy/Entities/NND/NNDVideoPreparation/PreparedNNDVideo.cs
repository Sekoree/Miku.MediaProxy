using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Miku.MediaProxy.Entities.NND.NNDVideoPreparation
{
    public class PreparedNNDVideo
    {
        public string Token { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public string ContentType { get; set; }
        public bool IsDone { get; set; } = false;
        public long? FullLength { get; set; }
        public long PacketAmount { get; set; } = -1;
        public List<BytePart> VideoStream { get; set; } = new List<BytePart>();

        public class BytePart
        {
            public byte[] Bytes { get; set; }
            public int Position { get; set; }
        }
    }
}
