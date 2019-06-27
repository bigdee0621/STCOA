using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class SysDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Leader { get; set; }
    }
}
