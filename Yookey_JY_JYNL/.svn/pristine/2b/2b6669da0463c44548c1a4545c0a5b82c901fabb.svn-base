//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_ATTACHBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_ATTACH业务逻辑类
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
    /// INF_CAR_ATTACH业务逻辑
    /// </summary>
    public class InfCarAttachBll : BaseBll<InfCarAttachEntity>
    {
        public InfCarAttachBll()
        {
            BaseDal = new InfCarAttachDal();
        }

        /// <summary>
        /// 查询违停对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<InfCarAttachEntity> GetSearchResult(InfCarAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(InfCarAttachEntity.Parm_INF_CAR_ATTACH_CreateOn, true);
            return Query(queryCondition) as List<InfCarAttachEntity>;
        }
    }
}
