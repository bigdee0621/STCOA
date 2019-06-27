using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace STCOA.CRUD
{
    public interface IBaseAppServices<T>
    {
        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="whereLamba">lamba条件表达式</param>
        /// <returns></returns>
        T GetEntity(Expression<Func<T, bool>> whereLamba);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="whereLamba">lamba条件表达式</param>
        /// <returns></returns>
        int DelEntity(Expression<Func<T, bool>> whereLamba);
        /// <summary>
        /// 保存或修改实体
        /// </summary>
        /// <param name="t"></param>
        /// <param name="type">1保存，2修改</param>
        /// <returns></returns>
        int SaveOrUpdateEntity(T t, int type);
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <typeparam name="S">委托输出的排序实体</typeparam>
        /// <param name="whereLamba">查询条件</param>
        /// <param name="isAsc">是否需要升序排序</param>
        /// <param name="orderLamba">排序条件</param>
        /// <returns></returns>
        IQueryable<T> GetEntitylist<S>(Expression<Func<T, bool>> whereLamba, bool isAsc, Expression<Func<T, S>> orderLamba);

    }


}
