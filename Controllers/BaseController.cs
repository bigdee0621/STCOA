using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STCOA.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 请求过滤处理
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("User", out result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Login/SignIn");
                return;
            }
            base.OnActionExecuting(filterContext);

        }
    }
}
