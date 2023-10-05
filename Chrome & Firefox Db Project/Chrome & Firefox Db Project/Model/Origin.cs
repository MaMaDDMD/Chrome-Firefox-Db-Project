using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class Origin
    {
        public Origin()
        {
            MediaImages = new HashSet<MediaImage>();
            PlaybackSessions = new HashSet<PlaybackSession>();
            Playbacks = new HashSet<Playback>();
        }

        public long Id { get; set; }
        public string Origin1 { get; set; } = null!;
        public long? LastUpdatedTimeS { get; set; }
        public long? HasMediaEngagement { get; set; }
        public long? MediaEngagementVisits { get; set; }
        public long? MediaEngagementPlaybacks { get; set; }
        public double? MediaEngagementLastPlaybackTime { get; set; }
        public long? MediaEngagementHasHighScore { get; set; }
        public long? AggregateWatchtimeAudioVideoS { get; set; }

        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual ICollection<PlaybackSession> PlaybackSessions { get; set; }
        public virtual ICollection<Playback> Playbacks { get; set; }
    }
}
