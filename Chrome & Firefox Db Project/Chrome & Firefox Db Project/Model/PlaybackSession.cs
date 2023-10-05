using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class PlaybackSession
    {
        public long Id { get; set; }
        public long OriginId { get; set; }
        public string Url { get; set; } = null!;
        public long? DurationMs { get; set; }
        public long? PositionMs { get; set; }
        public long LastUpdatedTimeS { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public string? SourceTitle { get; set; }

        public virtual Origin Origin { get; set; } = null!;
    }
}
