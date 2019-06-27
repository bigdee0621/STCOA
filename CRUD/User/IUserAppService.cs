using STCOA.EnityModel;
using STCOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCOA.CRUD.User
{
    interface IUserAppService : IBaseAppServices<SysUserinfo>
    {
        UserModel Login(string userName, string passWord);
    }
}
