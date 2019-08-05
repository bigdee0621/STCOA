using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using STCOA.CRUD.User;
using STCOA.EnityModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STCOA.Controllers.api
{
    [Route("api/mail")]
    public class MailAPI : Controller
    {
        MailController obj = new MailController();

        // POST api/<controller>
        [HttpPost]
        public bool Post(UserMail value)
        {
            return obj.AddData(value);

        }

    }

    [Route("api/getVocation")]
    public class GetVocation : Controller
    {
        MailController obj = new MailController();

        // POST api/<controller>
        [HttpPost]
        public float Post(int UserId)
        {
            return obj.GetVocation(UserId);

        }

    }
    [Route("api/UserList")]
    public class getUserList : Controller
    {
        UserAppService obj = new UserAppService();

        // POST api/<controller>
        [HttpPost]
        public List<SysUserinfo> getData()
        {
            return obj.getUserList();

        }


    }
}
