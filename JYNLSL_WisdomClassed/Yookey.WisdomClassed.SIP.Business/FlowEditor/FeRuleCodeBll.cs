//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_RuleCodeBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_RuleCode业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.Business.FlowEditor
{
    /// <summary>
    /// FE_RuleCode业务逻辑
    /// </summary>
    public class FeRuleCodeBll : BaseBll<FeRuleCodeEntity>
    {
        public FeRuleCodeBll()
        {
            BaseDal = new FeRuleCodeDal();
        }

        /// <summary>
        /// 得到规则记录
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId">结点ID</param>
        /// <returns></returns>
        public DataTable GetRuleCode(string activityId)
        {
            return new FeRuleCodeDal().GetRuleCode(activityId);
        }

        /// <summary>
        /// 得到规则记录
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId">结点ID</param>
        /// <param name="isUnlock">是否启用；0不启用  1启用</param>
        /// <returns></returns>
        public DataTable GetRuleCode(string activityId, int isUnlock)
        {
            return new FeRuleCodeDal().GetRuleCode(activityId, isUnlock);
        }

        /// <summary>
        /// 得到规则记录
        ///添加人：张西琼
        /// 添加时间：2014-07-29
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public DataTable RuleCodeEntity(string activityId)
        {
            var list = new FeRuleCodeDal().GetRuleCode(activityId);
            return list;
        }

        /// <summary>
        /// 更新成功规则接收对象ID
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="formerProcessId">修改前的流程ID</param>
        /// <param name="processId">修改后的流程ID</param>
        /// <returns>bool</returns>
        public bool UpdateRiolationRuleId(string formerProcessId, string processId)
        {
            return new FeRuleCodeDal().UpdateRiolationRuleId(formerProcessId, processId);
        }

        /// <summary>
        /// 添加规则
        ///  添加人：张西琼
        /// 添加时间：2014-07-31
        /// </summary>
        /// <param name="ruleCode"></param>
        /// <returns></returns>
        public bool AddRuleCode(FeRuleCodeEntity ruleCode)
        {
            DataTable dt = new FeRuleCodeDal().ReadRuleById(ruleCode.RuleCodeID);
            if (dt.Rows.Count > 0)
            {
                return Update(ruleCode) > 0;
            }
            else
                return new FeRuleCodeDal().AddRuleCode(ruleCode);
        }

        /// <summary>
        /// 删除规则
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="id">规则Id</param>
        /// <returns></returns>
        public bool DelRuleCode(string id)
        {
            return new FeRuleCodeDal().DelRuleCode(id);
        }

        /// <summary>
        /// 查询规则
        /// 添加人：张西琼
        /// 时间：2014/8/4
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        public DataTable ReadRuleById(string ruleId)
        {
            return new FeRuleCodeDal().ReadRuleById(ruleId);
        }


        /// <summary>
        /// 保存规则=
        /// 添加人：周 鹏
        /// 时间时间：2014-08-07
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// </summary>
        /// <param name="list">对象集合</param>
        /// <param name="activityId">activityId</param>
        /// <returns></returns>
        public bool SaveRule(List<FeRuleCodeEntity> list, string activityId)
        {
            try
            {
                //先批量删除规则
                new FeRuleCodeDal().DeleteByActivityId(activityId);

                //批量添加
                if (list != null && list.Count > 0)
                {
                    foreach (var entity in list)
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        entity.RuleCodeID = Guid.NewGuid().ToString();
                        entity.ActivityID = activityId;
                        entity.IsUnlock = true;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateOn = DateTime.Now;
                        Add(entity);
                    }
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
