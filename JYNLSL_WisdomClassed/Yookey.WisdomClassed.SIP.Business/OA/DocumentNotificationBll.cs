using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.DataAccess.OA;

using Yookey.WisdomClassed.SIP.Model.OA;


namespace Yookey.WisdomClassed.SIP.Business.OA
{
    public class DocumentNotificationBll
    {
        private static readonly DocumentNotificationDal Dal = new DocumentNotificationDal();
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<DocumentNotificationEntity> GetAllResult(DocumentNotificationEntity search)
        {
            return Dal.GetAllResult(search);
        }
        /// <summary>
        ///// 数据查询
        ///// </summary>
        ///// <param name="search"></param>
        ///// <param name="expressions"></param>
        ///// <returns></returns>
        //public List<DocumentNotificationEntity> GetSearchResult(DocumentNotificationEntity search, List<string> types)
        //{
        //    return Dal.GetSearchResult(search, types);
        //}
        //public List<DocumentNotificationEntity> GetSearchResult(DocumentNotificationEntity search)
        //{
        //    return Dal.GetSearchResult(search);
        //}
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(DocumentNotificationEntity search)
        {
            return Dal.PersistNewItem(search);
        }
        //public virtual bool PersistNewItem(T item, SgDatabase.DatabaseKind databaseKind = SgDatabase.DatabaseKind.Platform)
        //{
        //    return Dal.PersistNewItem(item, databaseKind);
        //}
        ///// <summary>
        ///// 根据主键删除附件
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public int Delete(string id)
        //{
        //    return Dal.Delete(id);
        //}
        ///// <summary>
        ///// 根据主键获取实体
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public DocumentNotificationEntity Get(string Id)
        //{
        //    return Dal.Get(Id);
        //}
        // /// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //public int UpdateRemark(string Id, string Remark)
        //{
        //    return Dal.UpdateRemark(Id, Remark);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public int Update(DocumentNotificationEntity entity)
        //{
        //    return Dal.Update(entity);
        //}
    }
}
