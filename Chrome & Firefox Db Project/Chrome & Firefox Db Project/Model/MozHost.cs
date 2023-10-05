using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class MozHost
    {
        public long Id { get; set; }
        public string? Host { get; set; }
        public string? Type { get; set; }
        public long? Permission { get; set; }
        public long? ExpireType { get; set; }
        public long? ExpireTime { get; set; }
        public long? ModificationTime { get; set; }
        public long? IsInBrowserElement { get; set; }
    }
}
