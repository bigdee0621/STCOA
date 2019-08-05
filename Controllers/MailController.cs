using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STCOA.CRUD.Mail;
using STCOA.EnityModel;
using STCOA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STCOA.Controllers.api;

namespace STCOA.Controllers
{
    public class MailController : Controller
    {
        MailCRUD con = new MailCRUD();
        public IActionResult Index()
        {

           var typeList = con.GetTypeList();
            ViewBag.typeList = typeList;
            var sss = ByteConvertHelper.Bytes2Object<UserModel>(HttpContext.Session.Get("User"));
            ViewBag.UserId = sss.Id;
            return View();
        }

        public bool AddData(UserMail obj)
        {
            return con.AddData(obj);
        }
        public float GetVocation(int UserId)
        {
            return con.GetVocation(UserId);
        }

        public IActionResult Leave()
        {
            var sss = ByteConvertHelper.Bytes2Object<UserModel>(HttpContext.Session.Get("User"));
            ViewBag.UserId = sss.Id;
            ViewBag.UserName = sss.UserName;
            var userList = new getUserList().getData() ;
            ViewBag.userList = userList;
            return View();
        }
      
    }
}