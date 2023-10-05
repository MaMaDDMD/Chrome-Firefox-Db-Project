using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class MediaImage
    {
        public long Id { get; set; }
        public long PlaybackOriginId { get; set; }
        public string Url { get; set; } = null!;
        public string? MimeType { get; set; }

        public virtual Origin PlaybackOrigin { get; set; } = null!;
    }
}
