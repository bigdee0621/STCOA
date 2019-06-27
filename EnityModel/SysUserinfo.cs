using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class SysUserinfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? Position { get; set; }
        public string Email { get; set; }
        public int Department { get; set; }
        public int Authority { get; set; }
        public string LastLogin { get; set; }
    }
}
