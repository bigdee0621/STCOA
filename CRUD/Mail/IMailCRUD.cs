using STCOA.EnityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCOA.CRUD.Mail
{
    interface IMailCRUD : IBaseAppServices<MailType>
    {
        List<MailType> GetTypeList();
        

    }
}
