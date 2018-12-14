//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 13:22:22
//  功能描述：AttendanceReport数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// 考勤申报 数据访问操作
    /// </summary>
    public class AttendanceReportDal : DalImp.BaseDal<AttendanceReportEntity>
    {
        public AttendanceReportDal()
        {
            Model = new AttendanceReportEntity();
        }

        /// <summary>
        /// 获取考勤申报信息
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询截止时间</param>
        /// <param name="keywords"></param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns></returns>
        public DataTable GetAllAttendanceReport(string companyId, string deptId, string startTime, string endTime, string keywords, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT AP.Id,AP.DepartmentName,CONVERT(VARCHAR(7),AP.SMonth,121) AS SMonth,AP.State,AP.CreateBy,AP.CreateOn,
(CASE WHEN AP.State = -2 THEN '已作废'
WHEN AP.State = -1 THEN '审批不通过'
WHEN AP.State = 0 THEN '登记'
WHEN AP.State > 0 AND AP.State < 10 THEN '审批中'
WHEN AP.State = 10 THEN '审批通过' ELSE '审批不通过' END ) AS StateDsc
FROM AttendanceReport AS AP WITH (NOLOCK)
WHERE AP.RowStatus = 1");
            if (!string.IsNullOrEmpty(companyId))
            {
                strSql.AppendFormat(" AND AP.CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId))
            {
                strSql.AppendFormat(" AND AP.DepartmentId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strSql.AppendFormat(" AND AP.SMonth>='{0}'", startTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND AP.SMonth<='{0} 23:59:59.999'", endTime);
            }
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "SMonth", "DESC", pageIndex, pageSize, out totalRecords);
            return data;
        }


        /// <summary>
        /// 事务保存考勤申报
        /// </summary>
        /// <param name="entity">考勤申报主要信息</param>
        /// <param name="detailList">考勤详细列表</param>
        /// <returns></returns>
        public bool TransactionSave(AttendanceReportEntity entity, List<AttendanceReportDetailsEntity> detailList)
        {
            var transaction = new TransactionLoader().BeginTransaction("AttendanceReport");
            try
            {
                var checkEntity = Get(entity.Id);
                var reportId = entity.Id;

                if (checkEntity != null && !string.IsNullOrEmpty(checkEntity.Id))
                {
                    Update(entity, transaction); //修改
                }
                else
                {
                    Add(entity, transaction); //新增
                }
                if (detailList.Any())
                {
                    var sql = string.Format("DELETE AttendanceReportDetails WHERE ReportId='{0}' ", reportId);
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                }
                foreach (var item in detailList)
                {
                    new AttendanceReportDetailsDal().Add(item, transaction);
                }
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
        /// 批量删除申报信息
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"
UPDATE AttendanceReport SET RowStatus=0 WHERE [Id] IN ('{0}');
UPDATE AttendanceReportDetails SET RowStatus=0 WHERE [ReportId] IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
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
            var strSql = string.Format("UPDATE AttendanceReport SET [State]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
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
            try
            {
                var strSql = string.Format("UPDATE AttendanceReport SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门所有审核通过的考勤异常记录
        /// 添加人：周 鹏
        /// 添加时间：2017-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptmentId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetAttendanceReportByDepartment(string deptmentId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT ARD.UserId, ARD.AttendType, ARD.StartTime,ARD.EndTime FROM AttendanceReportDetails AS ARD WITH(NOLOCK)
JOIN AttendanceReport AS AR WITH(NOLOCK) ON ARD.ReportId=AR.Id
WHERE AR.RowStatus=1 AND AR.[State]=10 ");

                if (!string.IsNullOrEmpty(deptmentId) && !deptmentId.Equals("all"))
                {
                    strSql.AppendFormat("AND AR.DepartmentId='{0}'",deptmentId);
                }
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat("AND ARD.StartTime>='{0}' AND ARD.EndTime<='{1} 23:59:59.999'", startTime, endTime);
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

