using STCOA.EnityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCOA.CRUD.Mail
{
  
    public class MailCRUD : BaseAppServices<MailType>, IMailCRUD
    {
        stcContext dbcontext = new stcContext();
        public List<MailType> GetTypeList()
        {
         
            List<MailType> TypleList = (from x in dbcontext.MailType  select x).ToList();

            return TypleList;
        }

        public bool AddData(UserMail obj)
        {
            obj.CrateDate = DateTime.Now;
            dbcontext.UserMail.Add(obj);
            if(obj.Type == "年假")
            {
                float day = GetVocation(obj.UserId) - obj.SumDay;  //请年假减去年假
                if (day < 0)
                    return false;
                else
                {
                    var UpdateVocation = (from x in dbcontext.UserVocation where x.UserId == obj.UserId select x).FirstOrDefault();
                    UpdateVocation.Vacation = day;
                }
            }

            if (dbcontext.SaveChanges() > 0)
                return true;
            else
                return false;
        }
        public float GetVocation(int UserId)
        {
            
            var VocationNum = (from x in dbcontext.UserVocation where x.UserId == UserId select x.Vacation).FirstOrDefault();

            return Convert.ToSingle(VocationNum);

        }
    }
}
