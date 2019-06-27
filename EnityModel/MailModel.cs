using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class MailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Type { get; set; }
        public string Context { get; set; }
    }
}
