using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STCOA.Models;
using System.Net.Mail;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace STCOA.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            /// /// <summary>        /// 将byte数组转换成对象        /// </summary>     
            var sss = ByteConvertHelper.Bytes2Object<UserModel>(HttpContext.Session.Get("User"));
            ViewBag.GG = sss.UserName;
            //  sendEmail();
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public void sendEmail()
        {


            SmtpClient smtpClient = new SmtpClient();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式

            smtpClient.Host = "smtp.exmail.qq.com";//指定SMTP服务器

            smtpClient.Credentials = new NetworkCredential("publicmsg@strongtech.net.cn", "Strong123");//用户名和密码

            smtpClient.EnableSsl = true;

            MailAddress fromAddress = new MailAddress("publicmsg@strongtech.net.cn", "施创消息");

            MailAddress toAddress = new MailAddress("liujh@strongtech.net.cn");

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);

            mailMessage.Bcc.Add("370316971@qq.com");

            mailMessage.Subject = "测试";//主题

            mailMessage.Body = "测试邮件";//内容

            mailMessage.BodyEncoding = Encoding.Default;//正文编码

            mailMessage.IsBodyHtml = true;//设置为HTML格式

            mailMessage.Priority = MailPriority.Normal;//优先级

            smtpClient.SendMailAsync(mailMessage);
        }


        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        // public async Task SetCurrentUser(string oid, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)



    }//end class


}
