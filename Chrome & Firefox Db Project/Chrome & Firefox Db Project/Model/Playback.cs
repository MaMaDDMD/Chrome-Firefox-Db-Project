using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class Playback
    {
        public long Id { get; set; }
        public long OriginId { get; set; }
        public string? Url { get; set; }
        public long? WatchTimeS { get; set; }
        public long? HasVideo { get; set; }
        public long? HasAudio { get; set; }
        public long LastUpdatedTimeS { get; set; }

        public virtual Origin Origin { get; set; } = null!;
    }
}
