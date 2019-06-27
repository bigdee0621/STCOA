
using Microsoft.EntityFrameworkCore;
using STCOA.EnityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace STCOA.CRUD
{
    public class BaseAppServices<T> : IBaseAppServices<T> where T : class
    {
        public stcContext db = new stcContext();//这个是连接mysql时自动生成的dbcontext
        public int DelEntity(Expression<Func<T, bool>> whereLamba)
        {
            try
            {
                T enilty = db.Set<T>().FirstOrDefault(whereLamba);
                db.Set<T>().Attach(enilty);
                db.Entry<T>(enilty).State = EntityState.Deleted;
                return db.SaveChanges();
            }
            catch (Exception e)
            {
                //Logger.Write.Error(e);
                return 0;
            }
        }

        public T GetEntity(Expression<Func<T, bool>> whereLamba)
        {
            try
            {
                T _enilty = db.Set<T>().FirstOrDefault(whereLamba);
                return _enilty;
            }
            catch (Exception e)
            {
                //Logger.Write.Error(e);
                throw;
            }
        }


        /// <summary>
        /// 返回列表
        /// </summary>
        /// <typeparam name="S">委托输出的排序实体</typeparam>
        /// <param name="whereLamba">查询条件</param>
        /// <param name="isAsc">是否需要升序排序</param>
        /// <param name="orderLamba">排序条件</param>
        /// <returns></returns>
        public IQueryable<T> GetEntitylist<S>(Expression<Func<T, bool>> whereLamba, bool isAsc, Expression<Func<T, S>> orderLamba)
        {
            try
            {
                var list = db.Set<T>().Where(whereLamba);
                if (isAsc) list = list.OrderBy<T, S>(orderLamba);
                else list = list.OrderByDescending<T, S>(orderLamba);
                return list;
            }
            catch (Exception e)
            {
              //  Logger.Write.Error(e);写日记方法可以先去掉
                return null;
            }
        }
        /// <summary>
        /// 保存或修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <param name="type">1保存，2修改</param>
        /// <returns></returns>
        public int SaveOrUpdateEntity(T t, int type)
        {
            try
            {
                db.Set<T>().Attach(t);
                var res = 0;
                if (type == 1)
                {
                    db.Entry<T>(t).State = EntityState.Added;
                    res = db.SaveChanges();
                }
                if (type == 2)
                {
                    db.Entry<T>(t).State = EntityState.Modified;
                    res = db.SaveChanges();
                }
                return res;
            }
            catch (Exception e)
            {
                //Logger.Write.Error(e);
                return 0;

            }

        }
    }
}


