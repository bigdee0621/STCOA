using System;
using System.Collections.Generic;

namespace STCOA.EnityModel
{
    public partial class UserMail
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public DateTime CrateDate { get; set; }
        public string Reason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Location { get; set; }
        public int? PeopleNum { get; set; }
        public float SumDay { get; set; }
        public int Status { get; set; }
    }
}
