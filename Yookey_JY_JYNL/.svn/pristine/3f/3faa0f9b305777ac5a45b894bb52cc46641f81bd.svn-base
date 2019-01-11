//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WF_ProcessBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 11:25:32
//  功能描述：WF_Process业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.WorkFlow;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;

namespace Yookey.WisdomClassed.SIP.Business.WorkFlow
{
    /// <summary>
    /// WF_Process业务逻辑
    /// </summary>
    public class WfProcessBll : BaseBll<WfProcessEntity>
    {
        public WfProcessBll()
        {
            BaseDal = new WfProcessDal();
        }

        /// <summary>
        /// 获取消息过程
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<WfProcessEntity> GetSearchResult(WfProcessEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(WfProcessEntity.Parm_WF_Process_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(WfProcessEntity.Parm_WF_Process_Id, search.Id);
            }
            return Query(queryCondition) as List<WfProcessEntity>;
        }
    }
}
