//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_RuleCodeDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_RuleCode数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.DataAccess.FlowEditor
{
    /// <summary>
    /// FE_RuleCode数据访问操作
    /// </summary>
    public class FeRuleCodeDal : DalImp.BaseDal<FeRuleCodeEntity>
    {
        public FeRuleCodeDal()
        {
            Model = new FeRuleCodeEntity();
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
            try
            {
                var strSql = @"SELECT 
FE_RuleCode.Id,dbo.FE_RuleCode.RuleCodeID,FE_RuleCode.ActivityID,FE_RuleCode.RuleClauses,FE_RuleCode.RiolationRuleID,FE_RuleCode.FulfillAssemblyName,FE_RuleCode.FulfillClassFullName,FE_RuleCode.IsUnlock,FE_RuleCode.Remark
,CASE FE_RuleCode.RiolationRuleID 
    WHEN '3' THEN '发送人'
	WHEN '1' THEN '至发启人'
	WHEN '2' THEN '至发启人并结束流程'
	ELSE FE_Activity.NoneName
END AS SendORWithdrawalActivityName
,CASE FE_RuleCode.IsUnlock
	WHEN 1 THEN '是'
	ELSE '否'
END AS IsUnlockName
,'IsEventName' = CASE 
	WHEN ISNULL(FE_RuleCode.FulfillAssemblyName,'') = '' OR ISNULL(FE_RuleCode.FulfillClassFullName,'') = '' THEN '没有'
	ELSE '有'
END
FROM FE_RuleCode
LEFT JOIN FE_Activity ON FE_Activity.ActivityID = FE_RuleCode.RiolationRuleID WHERE FE_RuleCode.ActivityID='@ActivityID' ORDER BY FE_RuleCode.CreateDate";
                strSql = strSql.Replace("@ActivityID", activityId);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
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
            var strSql = "SELECT * FROM FE_RuleCode WHERE ActivityID='" + activityId + "' AND IsUnlock=" + isUnlock + " ORDER BY CreateDate";
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 得到规则记录
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        private DataTable GetRuleCode2(string processId)
        {
            var strSql = string.Format(@"SELECT FE_RuleCode.* FROM FE_RuleCode
INNER JOIN FE_Activity ON FE_Activity.ActivityID = FE_RuleCode.ActivityID  WHERE FE_Activity.ProcessID='{0}'
ORDER BY FE_RuleCode.CreateDate ", processId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
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
            var formerDt = new FeActivityDal().GetActivity(formerProcessId);
            var newDt = new FeActivityDal().GetActivity(processId);
            var dt = GetRuleCode2(processId);
            var strSql = "";
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].IsNull("RiolationRuleID") || dt.Rows[i]["RiolationRuleID"].ToString().Equals(""))
                    continue;
                var strRiolationRuleId = "";
                var strTemp = dt.Rows[i]["RiolationRuleID"].ToString();
                //3:发送人 1:至发启人 2:至发启人并结束流程
                if (strTemp != "1" && strTemp != "2" && strTemp != "3")
                {
                    var rowsFormer = formerDt.Select("ActivityID='" + strTemp + "'");
                    var rows = newDt.Select("NoneID='" + rowsFormer[0]["NoneID"] + "'");
                    strRiolationRuleId = rows[0]["ActivityID"].ToString();
                }
                else
                    strRiolationRuleId = strTemp;
                strSql += "UPDATE FE_RuleCode SET RiolationRuleID='" + strRiolationRuleId + "' WHERE RuleCodeID='" + dt.Rows[i]["RuleCodeID"] + "';";
            }
            if (strSql.Equals(""))
                return false;

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }
        /// <summary>
        /// 添加规则
        ///  添加人：张西琼
        /// 添加时间：2014-07-31
        /// </summary>
        /// <param name="ruleCodeEntity"></param>
        /// <returns></returns>
        public bool AddRuleCode(FeRuleCodeEntity ruleCodeEntity)
        {
            int isUnlock = 0;

            if (ruleCodeEntity.IsUnlock)
            {
                isUnlock = 1;
            }
            string strSql = string.Format(@"insert into FE_RuleCode(ActivityID,CreateBy,CreateDate,CreateOn,CreatorId,FulfillAssemblyName,FulfillClassFullName,IsUnlock,Remark,RiolationRuleID,RowStatus,RuleClauses,RuleCodeID,UpdateBy,UpdateId,UpdateOn)
values('{0}','{1}','{2}','{3}','{4}','{5}',
'{6}',{7},'{8}','{9}','{10}','{11}',
'{12}','{13}','{14}','{15}');
", ruleCodeEntity.ActivityID, ruleCodeEntity.CreateBy, ruleCodeEntity.CreateDate, ruleCodeEntity.CreateOn, ruleCodeEntity.CreatorId, ruleCodeEntity.FulfillAssemblyName, ruleCodeEntity.FulfillClassFullName,
isUnlock, ruleCodeEntity.Remark, ruleCodeEntity.RiolationRuleID, ruleCodeEntity.RowStatus, ruleCodeEntity.RuleClauses,
ruleCodeEntity.RuleCodeID, ruleCodeEntity.UpdateBy, ruleCodeEntity.UpdateId, ruleCodeEntity.UpdateOn);
            if (SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0)
            {
                return true;
            }
            else return false;

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
            if (id == "")
                return false;
            string strSql = "DELETE FROM FE_RuleCode WHERE RuleCodeID IN(" + id + ")";
            if (SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) >= 0)
            {
                return true;
            }
            else return false;
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
            string strSql = string.Format(@"SELECT * FROM FE_RuleCode WHERE RuleCodeID='{0}' ", ruleId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 根据 activityId 删除所有接收对象
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId"></param>
        /// <returns></returns>
        public bool DeleteByActivityId(string activityId)
        {
            var strSql = string.Format("DELETE FROM FE_RuleCode WHERE ActivityID='{0}'", activityId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }
    }
}

