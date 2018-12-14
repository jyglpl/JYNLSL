//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Action业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.FlowEditor;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.Business.FlowEditor
{
    /// <summary>
    /// FE_Action业务逻辑
    /// </summary>
    public class FeActionBll : BaseBll<FeActionEntity>
    {
        public FeActionBll()
        {
            BaseDal = new FeActionDal();
        }


        /// <summary>
        /// 验证是否存在
        /// 添加人：周 鹏
        /// 添加时间：2014-07-21
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="actionId">actionId编号</param>
        /// <returns></returns>
        private bool ExitstActionId(string actionId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActionEntity.Parm_FE_Action_RowStatus, "1");
            queryCondition.AddEqual(FeActionEntity.Parm_FE_Action_ActionID, actionId);
            return QueryCount(queryCondition) > 0;
        }

        /// <summary>
        /// 添加人：周 鹏
        /// 添加时间：2014-07-21
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Save(FeActionEntity entity)
        {
            if (ExitstActionId(entity.ActionID))
            {
                entity.UpdateBy = "";
                entity.UpdateOn = DateTime.Now;
                entity.RowStatus = 1;
                return Update(entity)>0;
            }
            else
            {
                entity.CreateBy = "";
                entity.CreateOn = DateTime.Now;
                entity.RowStatus = 1;
                Add(entity);
                return true;
            }
        }

        /// <summary>
        /// 得到发送记录
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="fromPoint">开始节点</param>
        /// <param name="toPoint">发至结点</param>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        public List<FeActionEntity> GetFeAction(string fromPoint, string toPoint, string processId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActionEntity.Parm_FE_Action_RowStatus, "1");
            queryCondition.AddEqual(FeActionEntity.Parm_FE_Action_ProcessID, processId);
            queryCondition.AddEqual(FeActionEntity.Parm_FE_Action_FromPoint, fromPoint);
            queryCondition.AddEqual(FeActionEntity.Parm_FE_Action_Topoint, toPoint);
            var list = Query(queryCondition) as List<FeActionEntity>;
            return list;
        }
    }
}
