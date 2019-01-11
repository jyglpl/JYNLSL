//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WF_ProcessInstanceDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 11:25:32
//  功能描述：WF_ProcessInstance数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;

namespace Yookey.WisdomClassed.SIP.DataAccess.WorkFlow
{
    /// <summary>
    /// WF_ProcessInstance数据访问操作
    /// </summary>
    public class WfProcessInstanceDal : DalImp.BaseDal<WfProcessInstanceEntity>
    {
        public WfProcessInstanceDal()
        {
            Model = new WfProcessInstanceEntity();
        }


        /// <summary>
        /// 通过流程实例名称找到其流程ID
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="fullName">流程实例名称</param>
        /// <returns></returns>
        public string ProcessID(string fullName)
        {
            try
            {
                var strSql =
                    string.Format("SELECT Id FROM WF_Process WHERE FullName='{0}' AND IsCurrentVersion=1 ", fullName);
                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                throw new Exception("该流程实例不存在或以删除");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取实例ID
        /// </summary>
        /// <param name="fullName">流程名称</param>
        /// <param name="formID">表单ID</param>
        /// <returns>流程实例ID-1表示未找到</returns>
        public string ProcessInstanceID(string fullName, string formID)
        {
            try
            {
                var processID = this.ProcessID(fullName);
                if (processID == "")
                {
                    throw new Exception("流程名称不存在，无法查找");
                }

                //var strSql = new StringBuilder("");
                //strSql.Append("SELECT  WF_ProcessInstance.Id FROM WF_ProcessInstance ");
                //strSql.Append(" INNER JOIN WF_Process ON WF_ProcessInstance.ProcessID=WF_Process.Id ");
                //strSql.Append(" WHERE WF_Process.fullname='" + fullName + "' AND FormID='" + formID + "'  ");

                var strSql = new StringBuilder("");
                strSql.Append("SELECT  WF_ProcessInstance.Id FROM WF_ProcessInstance ");
                strSql.Append(" INNER JOIN WF_Process ON WF_ProcessInstance.ProcessID=WF_Process.Id ");
                strSql.Append(" WHERE WF_Process.fullname='" + fullName + "' AND FormID='" + formID + "' AND [Status]=0 ");

                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        /// <summary>
        /// 根据消息编号查询所审批流程
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        ///           2014-12-29 周 鹏 增加按照流程名称进行查询
        /// </hisotry> 
        /// <param name="worklistId">消息编号</param>
        /// <param name="flowName"></param>
        /// <returns></returns>
        public List<WfProcessInstanceEntity> QueryProcessInstance(string worklistId, string flowName)
        {
//            var strSql = string.Format(
//                @"SELECT WPI.* FROM WF_ProcessInstance AS WPI WITH(NOLOCK)
//JOIN WF_Process AS WP WITH(NOLOCK) ON WPI.ProcessID=WP.Id
//JOIN CrmMessageWork AS CMW WITH (NOLOCK) ON CMW.ProcessInstanceID = WPI.Id
//WHERE CMW.Id = '{0}' AND WP.FullName='{1}'", worklistId, flowName);


            var strSql = string.Format(
                @"SELECT WPI.* FROM WF_ProcessInstance AS WPI WITH(NOLOCK)
JOIN WF_Process AS WP WITH(NOLOCK) ON WPI.ProcessID=WP.Id
JOIN CrmMessageWork AS CMW WITH (NOLOCK) ON CMW.ProcessInstanceID = WPI.Id
WHERE CMW.Id = '{0}' AND WP.FullName='{1}' AND WPI.[Status]=0 ", worklistId, flowName);

            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return DataTableToList(dt);
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public bool DelProcessInstance(string fullName, string formID)
        {
            var strSql = string.Format(@"delete from WF_ProcessInstance where id  in(
select WF_ProcessInstance.id  from WF_ProcessInstance inner join WF_Process
on WF_Process.id=WF_ProcessInstance.ProcessID
where WF_Process.fullname='{0}' and formid='{1}')", fullName, formID);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 更改流程的状态为-1
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public bool UpProcessInstance(string fullName, string formID)
        {
            var strSql = string.Format(@"UPDATE WF_ProcessInstance SET Status=-1 where id  in(
select WF_ProcessInstance.id  from WF_ProcessInstance inner join WF_Process
on WF_Process.id=WF_ProcessInstance.ProcessID
where WF_Process.fullname='{0}' and formid='{1}')", fullName, formID);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }
    }
}

