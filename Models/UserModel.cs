using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STCOA.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Phone { get; set; }
        public int? Position { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int Authority { get; set; }
        public string LastLogin { get; set; }

    }


}
