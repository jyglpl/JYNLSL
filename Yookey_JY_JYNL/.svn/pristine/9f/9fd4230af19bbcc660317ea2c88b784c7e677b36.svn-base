//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActivityBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Activity业务逻辑类
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
    /// FE_Activity业务逻辑
    /// </summary>
    public class FeActivityBll : BaseBll<FeActivityEntity>
    {
        public FeActivityBll()
        {
            BaseDal = new FeActivityDal();
        }

        /// <summary>
        /// 验证是否存在
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="activityId">activity编号</param>
        /// <returns></returns>
        public bool ExitstActivityId(string activityId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActivityEntity.Parm_FE_Activity_RowStatus, "1");
            queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_ActivityID, activityId);
            return QueryCount(queryCondition) > 0;
        }

        /// <summary>
        /// 保存
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool Save(FeActivityEntity entity)
        {
            if (ExitstActivityId(entity.ActivityID))
            {
                entity.UpdateBy = "";
                entity.UpdateOn = DateTime.Now;
                entity.RowStatus = 1;
                return Update(entity) > 0;
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
        /// 获取节点编号
        /// </summary>
        /// <param name="processId">流程编号</param>
        /// <param name="noneName">节点名称</param>
        /// <returns></returns>
        public string GetActivityId(string processId, string noneName)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActivityEntity.Parm_FE_Activity_RowStatus, "1");
            queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_ProcessID, processId)
                          .AddEqual(FeActivityEntity.Parm_FE_Activity_NoneName, noneName);
            var list = Query(queryCondition) as List<FeActivityEntity>;
            if (list != null && list.Count > 0)
            {
                return list[0].ActivityID;
            }
            return null;
        }

        /// <summary>
        /// 根据节点编号查询节点
        /// </summary>
        /// <param name="activityId">节点编号</param>
        /// <returns></returns>
        public List<FeActivityEntity> GetActivity(string activityId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActivityEntity.Parm_FE_Activity_RowStatus, "1");
            queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_ActivityID, activityId);
            var list = Query(queryCondition) as List<FeActivityEntity>;
            return list;
        }


        /// <summary>
        /// 退回接收对象 ID 更新
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="formerProcessId">修改前的流程ID</param>
        /// <param name="processId">修改后的流程ID</param>
        /// <returns></returns>
        public bool UpdateReturnActivityId(string formerProcessId, string processId)
        {
            try
            {
                return new FeActivityDal().UpdateReturnActivityId(formerProcessId, processId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 根据流程编号编号查询节点
        /// 添加人：张西琼
        /// 添加时间：2014-07-28
        /// </summary>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>

        public List<FeActivityEntity> GetActivityByProcessId(string processId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActivityEntity.Parm_FE_Activity_ProcessID, processId);
            // queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_NoneName, noneName);
            var list = Query(queryCondition) as List<FeActivityEntity>;
            return list;
        }
        /// <summary>
        /// 根据流程编号编号及NoneName查询节点
        /// 添加人：张西琼
        /// 添加时间：2014-07-28
        /// </summary>
        /// <param name="processId">流程编号</param>
        /// <param name="noneName"></param>
        /// <returns></returns>
        public List<FeActivityEntity> GetActivityByPIdNone(string processId, string noneName)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActivityEntity.Parm_FE_Activity_ProcessID, processId);
            queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_NoneName, noneName);
            var list = Query(queryCondition) as List<FeActivityEntity>;
            return list;
        }
        /// <summary>
        /// 删除操作
        /// 添加人：张西琼
        /// 时间：2014/8/6
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public bool DeleActivity(string activityId)
        {
            return new FeActivityDal().DeleActivity(activityId);
        }

    }
}
