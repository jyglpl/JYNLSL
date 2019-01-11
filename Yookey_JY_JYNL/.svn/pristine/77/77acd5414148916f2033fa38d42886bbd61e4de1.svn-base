//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_ATTACHBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/20 18:22:52
//  功能描述：INF_PUNISH_ATTACH业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 案件附件业务逻辑
    /// </summary>
    public class InfPunishAttachBll : BaseBll<InfPunishAttachEntity>
    {
        public InfPunishAttachBll()
        {
            BaseDal = new InfPunishAttachDal();
        }

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<InfPunishAttachEntity> GetSearchResult(InfPunishAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_CreateOn, true);
            return Query(queryCondition) as List<InfPunishAttachEntity>;
        }

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <param name="types">附件的类型</param>
        /// <returns></returns>
        public List<InfPunishAttachEntity> GetSearchResult(InfPunishAttachEntity search, List<string> types)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_ResourceId, search.ResourceId);
            }
            if (types != null && types.Count > 0)
            {
                queryCondition.AddIn(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_FileType, string.Join(",", types.ToArray()));
            }
            queryCondition.AddOrderBy(InfPunishAttachEntity.Parm_INF_PUNISH_ATTACH_CreateOn, true);
            return Query(queryCondition) as List<InfPunishAttachEntity>;
        }

        /// <summary>
        /// 批量删除照片
        /// 添加人：周 鹏
        /// 添加时间：2015-03-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">照片数据集,使用逗号分隔开</param>
        /// <returns></returns>
        public bool DeleteAttach(string ids)
        {
            return new InfPunishAttachDal().DeleteAttach(ids);
        }
    }
}
