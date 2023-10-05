using System;
using System.Collections.Generic;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class MozPerm
    {
        public long Id { get; set; }
        public string? Origin { get; set; }
        public string? Type { get; set; }
        public long? Permission { get; set; }
        public long? ExpireType { get; set; }
        public long? ExpireTime { get; set; }
        public long? ModificationTime { get; set; }
    }
}
