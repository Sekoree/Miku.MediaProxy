using NNDD.Entities.ResultEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miku.MediaProxy.Entities.NND.ResultEntities
{
    public struct TrackInfoExtended
    {
        public string Author { get; set; }
        public Uri AuthorUrl { get; set; }
        public Uri AuthorIconUrl { get; set; }
        public string Title { get; set; }
        public double Length { get; set; }
        public DateTimeOffset UploadDate { get; set; }
        public bool IsLive { get; set; }
        public Uri TrackUrl { get; set; }
        public Uri DirectUrl { get; set; }
        public Uri ThumbnailUrl { get; set; }

        public string Description { get; set; }
        public List<string> VideoQualities { get; set; }
        public List<string> AudioQualities { get; set; }
    }
}
