using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class SessionImage
    {
        public long SessionId { get; set; }
        public long ImageId { get; set; }
        public long? Width { get; set; }
        public long? Height { get; set; }

        public virtual MediaImage Image { get; set; } = null!;
        public virtual PlaybackSession Session { get; set; } = null!;
    }
}
