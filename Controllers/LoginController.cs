using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STCOA.CRUD.User;
using STCOA.EnityModel;
using STCOA.Models;
using Microsoft.AspNetCore.Mvc;

namespace STCOA.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                //检查用户信息
                UserAppService obj = new UserAppService();
                var isLogin = obj.Login(userModel.Username, userModel.Password);
                if (isLogin != null)
                {
                    //记录Session
                    HttpContext.Session.Set("User", ByteConvertHelper.Object2Bytes(isLogin));
                    //跳转到系统首页
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorInfo = "用户名或密码错误";
                return View(userModel);
            }
            ViewBag.ErrorInfo = ModelState.Values.First().Errors[0].ErrorMessage;
            return View(userModel);
        }

        public IActionResult SignOut()
        {
            //清除Session
            HttpContext.Session.Clear();
            //跳转到系统登录界面
            return RedirectToAction("SignIn", "Login");
        }

      




    }// End Class
}