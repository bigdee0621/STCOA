using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class UserVocation
    {
        public int UserId { get; set; }
        public float? Vacation { get; set; }
        public string Log { get; set; }
        public DateTime? Update { get; set; }
    }
}
