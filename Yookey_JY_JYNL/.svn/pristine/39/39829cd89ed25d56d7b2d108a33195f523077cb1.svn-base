using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.SealUp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.Business.SealUp
{
    /// <summary>
    /// SealUpAttach业务逻辑
    /// </summary>
    public class SealUpAttachBll : BaseBll<SealUpAttachEntity>
    {
        public SealUpAttachBll()
        {
            BaseDal = new SealUpAttachDal();
        }
        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <param name="types">附件的类型</param>
        /// <returns></returns>
        public List<SealUpAttachEntity> GetSearchResult(SealUpAttachEntity search, List<string> types)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(SealUpAttachEntity.Parm_SealUpAttach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(SealUpAttachEntity.Parm_SealUpAttach_ResourceId, search.ResourceId);
            }
            if (types != null && types.Count > 0)
            {
                queryCondition.AddIn(SealUpAttachEntity.Parm_SealUpAttach_FileType, string.Join(",", types.ToArray()));
            }
            queryCondition.AddOrderBy(SealUpAttachEntity.Parm_SealUpAttach_CreateOn, true);
            return Query(queryCondition) as List<SealUpAttachEntity>;
        }


        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<SealUpAttachEntity> GetSearchResult(SealUpAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(SealUpAttachEntity.Parm_SealUpAttach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(SealUpAttachEntity.Parm_SealUpAttach_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(SealUpAttachEntity.Parm_SealUpAttach_CreateOn, true);
            return Query(queryCondition) as List<SealUpAttachEntity>;
        }
    }
}
