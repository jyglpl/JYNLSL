using System.Collections.Generic;
using PetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Base;

namespace Yookey.WisdomClassed.SIP.Business.BasePetaPoco
{
    /// <summary>
    /// 持久层基类
    /// </summary>
    /// <typeparam name="T">
    /// 实体类型
    /// </typeparam>
    public class BaseBll<T> : IBll<T> where T : new()
    {
        public BaseDal<T> BaseDal;
        /// <summary>
        /// 平台写数据库
        /// </summary>
        public Database WriteDatabase { get; set; }

        public BaseBll()
        {
            BaseDal = new BaseDal<T>();
            //平台写数据库
            WriteDatabase = BaseDal.WriteDatabase;
        }

        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则抛出异常</returns>
        public T Single(object key)
        {
            return BaseDal.Single(key);
        }

        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则返回一个默认值</returns>
        public T SingleOrDefault(object key)
        {
            return BaseDal.SingleOrDefault(key);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        public bool PersistUpdatedItem(T item)
        {
            return BaseDal.PersistUpdatedItem(item);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key">实体</param>
        /// <returns>成功为true,错误为false</returns>
        public virtual bool PersistDeletedItem(object key)
        {
            return BaseDal.PersistDeletedItem(key);
        }

        /// <summary>
        /// 新建实体
        /// </summary>
        /// <param name="item">
        /// 实体
        /// </param>
        /// <returns>
        /// true为成功,false为失败
        /// </returns>
        public virtual bool PersistNewItem(T item)
        {
            return BaseDal.PersistNewItem(item);
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="page">当前页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sql">SQL Script</param>
        /// <param name="isPage">是否分页(false:不分页，查询全部 ，true:分页)</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public PetaPoco.Page<T> Page(long page, long pageSize, string sql = null, List<object> args = null, bool isPage = false)
        {
            return BaseDal.Page(page, pageSize, sql, args, isPage);
        }
    }
}
