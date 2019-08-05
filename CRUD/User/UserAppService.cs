using STCOA.EnityModel;
using STCOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCOA.CRUD.User
{
    public class UserAppService : BaseAppServices<SysUserinfo>, IUserAppService
    {
        stcContext dbcontext = new stcContext();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">des加密密码</param>
        /// <returns></returns>
        public UserModel Login(string userName, string passWord)
        {
            try
            {
                //这里是一个des的加密处理string pass = DesMethod.DESEncrypt(passWord, Constant.DesKey);
                string pass = passWord;

                SysUserinfo user = (from c in dbcontext.SysUserinfo where c.UserName == userName && c.Password == pass select c).FirstOrDefault();

            if (user != null)
                {
                    string department = (from x in dbcontext.SysDepartment where x.Id == user.Department select x.Name).FirstOrDefault();
                    
                    var UserInfo = new UserModel();
                    UserInfo.Id = user.Id;
                    UserInfo.UserName = user.UserName;
                    UserInfo.Department = department;
                    UserInfo.Phone = user.Phone;
                    UserInfo.Email = user.Email;
                    UserInfo.Authority = user.Authority;
                    var s = DateTime.Now.ToString();
                user.LastLogin = s;
                dbcontext.SaveChanges();
                return UserInfo;
          

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                //Logger.Write.Info("登录出错:" + e);
                return null;
            }
        }


        public List<SysUserinfo> getUserList()
        {
            var List = dbcontext.SysUserinfo.ToList();
            List<SysUserinfo> userList = new List<SysUserinfo>();
            foreach(var s in List)
            {
                userList.Add(new SysUserinfo { Id = s.Id, UserName=s.UserName });
            }
            return userList;
        }

    }
}
