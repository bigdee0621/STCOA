using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class MailType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string SonType { get; set; }
    }
}
