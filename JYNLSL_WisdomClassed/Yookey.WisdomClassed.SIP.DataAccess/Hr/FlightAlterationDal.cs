//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightAlterationDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/12/20 14:32:38
//  功能描述：FlightAlteration数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using DBHelper;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Hr;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// 调班管理 数据访问操作
    /// </summary>
    public class FlightAlterationDal : DalImp.BaseDal<FlightAlterationEntity>
    {
        public FlightAlterationDal()
        {
            Model = new FlightAlterationEntity();
        }

        /// <summary>
        /// 根据中队编号获取中队的调班信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">请求单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchResult(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageIndex,
            int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT Id,DeptName,BeforeUserName,AfterUserName,BeforeDate,AfterDate,Reason,
(CASE WHEN [Status] = -2 THEN '已作废' 
WHEN [Status] = -1 THEN '审批不通过' WHEN [Status] = 0 THEN '登记'
WHEN [Status] > 0 AND [Status] < 10 THEN '审批中'
WHEN [Status] = 10 THEN '审批通过' ELSE '审批不通过' END ) AS Status
FROM FlightAlteration
WHERE RowStatus = 1");

            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(" AND DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeforeDate>='{0}' AND BeforeDate<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeforeDate>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeforeDate<='{0} 23:59:59.999'", endTime);
            }
            if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND (BeforeUserName LIKE '%{0}%' OR AfterUserName LIKE '%{0}%' OR Reason LIKE '%{0}%')", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeforeDate", "DESC", pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 查询排班信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <param name="totalRecords">查询结果总条数</param>
        /// <returns></returns>
        public DataTable GetSearchResult(FlightAlterationEntity search, out int totalRecords)
        {
            var strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT Id,DeptName,BeforeUserName,AfterUserName,BeforeDate,BeforeClassesName,AfterDate,AfterClassesName,Reason,
(CASE WHEN [Status] = -2 THEN '已作废' 
WHEN [Status] = -1 THEN '审批不通过' WHEN [Status] = 0 THEN '登记'
WHEN [Status] > 0 AND [Status] < 10 THEN '审批中'
WHEN [Status] = 10 THEN '审批通过' ELSE '审批不通过' END ) AS Status
FROM FlightAlteration
WHERE RowStatus = 1");

            if (!string.IsNullOrEmpty(search.CompanyId) && !search.CompanyId.Equals("all"))
            {
                strSql.AppendFormat(" AND CompanyId='{0}'", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DeptId) && !search.DeptId.Equals("all"))
            {
                strSql.AppendFormat(" AND DeptId='{0}'", search.DeptId);
            }
            if (!string.IsNullOrEmpty(search.AferUserId))
            {
                strSql.AppendFormat(" AND (BeforeUserId='{0}' OR AferUserId='{0}') ", search.AferUserId);
            }

            if (!string.IsNullOrEmpty(search.Keywords))
            {
                strSql.AppendFormat(" AND (BeforeUserName LIKE '%{0}%' OR AfterUserName LIKE '%{0}%' OR Reason LIKE '%{0}%')", search.Keywords);
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeforeDate", "DESC", search.PageIndex, search.PageSize, out totalRecords);

        }

        /// <summary>
        /// 更改状态，在当前状态上面加1
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            //var model= Get(id);
            //var result = false;
            //if (model != null)
            //{
            //    model.Status+=1;
            //    result=UpdataChangeShift(model);
            //}
            var strSql = string.Format("UPDATE FlightAlteration SET [Status]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            //return result;
        }

        /// <summary>
        /// 更改可用状态
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {


            //var model = Get(id);
            //var result = false;
            //if (model != null)
            //{
            //    model.Status=state;
            //    result = UpdataChangeShift(model);
            //}
            //return result;
            try
            {
                var strSql = string.Format("UPDATE FlightAlteration SET [Status]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 插入调班和调班消息事务
        /// </summary>
        /// <param name="model">调班实体</param>
        /// <returns>是否成功</returns>
        public bool AddChangeShift(FlightAlterationEntity model)
        {
            var transaction = new TransactionLoader().BeginTransaction("FlightAlteration");
            try
            {
                Add(model, transaction);//新增调班
                // 待办
                var crmModel = new CrmMessageWorkEntity();
                crmModel.Id = Guid.NewGuid().ToString();
                crmModel.Titles = model.BeforeUserName + "的调班申请";
                crmModel.StartDate = DateTime.Now;
                crmModel.SenderID = model.BeforeUserId;
                crmModel.ActionerID = model.AferUserId;
                crmModel.FormID = model.Id;
                crmModel.FormData = "同意";
                crmModel.FormAddress = "/Alteration/Detail?Id=" + model.Id;
                crmModel.ContentTypeID = "00050005";
                crmModel.IsReply = 0;
                crmModel.State = 0;
                crmModel.RowStatus = 1;
                crmModel.CreatorId = model.BeforeUserId;
                crmModel.CreateBy = model.BeforeUserName;
                crmModel.CreateOn = DateTime.Now;
                new CrmMessageWorkDal().Add(crmModel, transaction);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }

            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 更新调班和调班消息事务
        /// </summary>
        /// <param name="model">调班实体</param>
        /// <returns>是否成功</returns>
        public bool UpdataChangeShift(FlightAlterationEntity model)
        {
            var transaction = new TransactionLoader().BeginTransaction("FlightAlteration");
            try
            {
                Update(model, transaction);//更行调班
                string whereStr = @"and ContentTypeID='00050005' and FormID='" + model.Id + "'";
                string setValue = string.Format(@"State=2,UpdateId='{0}',UpdateBy='{1}',UpdateOn='{2}',RowStatus={3}", model.UpdateId, model.UpdateBy, model.UpdateOn, model.RowStatus);

                string sqlStr = string.Format("update CrmMessageWork set {0} where 1=1 {1}", setValue, whereStr);
                SqlHelper.ExecuteScalar(transaction, CommandType.Text, sqlStr);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }
    }
}

