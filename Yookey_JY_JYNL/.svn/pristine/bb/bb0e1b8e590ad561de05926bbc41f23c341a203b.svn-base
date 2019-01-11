//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagement数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.TeamManagement
{
    /// <summary>
    /// TeamManagement数据访问操作
    /// </summary>
    public class TeamManagementDal : DalImp.BaseDal<TeamManagementEntity>
    {
        public TeamManagementDal()
        {
            Model = new TeamManagementEntity();
        }

        /// <summary>
        /// 查询路面考核分页列表(手机端使用)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<TeamManagementEntity> GetTeamManagementPage(TeamManagementEntity entity, out int totalRecords)
        {
            var strSql = new StringBuilder(@" SELECT * FROM TeamManagement AMT WITH(NOLOCK) WHERE 1=1 ");

            if (!string.IsNullOrEmpty(entity.CompanyId))
            {
                strSql.AppendFormat(" AND CompanyId='{0}' ", entity.CompanyId);
            }
            if (!string.IsNullOrEmpty(entity.DepartmentId))
            {
                strSql.AppendFormat(" AND DepartmentId='{0}' ", entity.DepartmentId);
            }
            if (!string.IsNullOrEmpty(entity.ClassNo))
            {
                strSql.AppendFormat(" AND ClassNo='{0}' ", entity.ClassNo);
            }
            if (!string.IsNullOrEmpty(entity.AssignUserId))
            {
                strSql.AppendFormat(" AND AssignUserId='{0}' ", entity.AssignUserId);
            }
            // 0:待处理,1:处理中,2:已处理,3:已核查
            if (entity.Status == 1)
            {
                strSql.Append(" AND Status in (0,1) ");
            }
            else if (entity.Status == 2)
            {
                strSql.Append(" AND Status in (2,3) ");
            }

            if (!string.IsNullOrEmpty(entity.STime))
            {
                strSql.AppendFormat(" AND CONVERT(varchar(100), AssessmentTime, 23) >= '{0}' ", entity.STime);
            }
            if (!string.IsNullOrEmpty(entity.ETime))
            {
                strSql.AppendFormat(" AND CONVERT(varchar(100), AssessmentTime, 23) <= '{0}' ", entity.ETime);
            }


            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "AssessmentTime", "Desc", entity.PageIndex, entity.PageSize, out totalRecords);
            return data != null && data.Rows.Count > 0 ? DataTableToList(data) : new List<TeamManagementEntity>();
        }

        /// <summary>
        /// 查询路面考核分页列表
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<TeamManagementEntity> GetTeamManagementPageJqDatagrid(TeamManagementEntity entity, out int totalRecords)
        {
            var strSql = new StringBuilder(@" SELECT * FROM TeamManagement AMT WITH(NOLOCK) WHERE 1=1 ");

            if (!string.IsNullOrEmpty(entity.CompanyId))
            {
                strSql.AppendFormat(" AND CompanyId='{0}' ", entity.CompanyId);
            }
            if (!string.IsNullOrEmpty(entity.DepartmentId))
            {
                strSql.AppendFormat(" AND DepartmentId='{0}' ", entity.DepartmentId);
            }
            if (!string.IsNullOrEmpty(entity.ClassNo))
            {
                strSql.AppendFormat(" AND ClassNo='{0}' ", entity.ClassNo);
            }
            // 0:待处理,1:处理中,2:已处理,3:已核查
            if (entity.Status == 0)
            {
                strSql.Append(" AND Status =0 ");
            }
            else if (entity.Status == 1)
            {
                strSql.Append(" AND Status =1 ");
            }
            else if (entity.Status == 2)
            {
                strSql.Append(" AND Status =2 ");
            }
            else if (entity.Status == 3)
            {
                strSql.Append(" AND Status =3 ");
            }

            if (!string.IsNullOrEmpty(entity.Remark))
            {
                strSql.AppendFormat(" AND  (AssessmentAddress like '%{0}%' OR Remark like '%{0}%') ", entity.Remark);
            }

            if (!string.IsNullOrEmpty(entity.STime))
            {
                strSql.AppendFormat(" AND CONVERT(varchar(100), AssessmentTime, 23) >= '{0}' ", entity.STime);
            }
            if (!string.IsNullOrEmpty(entity.ETime))
            {
                strSql.AppendFormat(" AND CONVERT(varchar(100), AssessmentTime, 23) <= '{0}' ", entity.ETime);
            }


            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "AssessmentTime", "Desc", entity.PageIndex, entity.PageSize, out totalRecords);
            return data != null && data.Rows.Count > 0 ? DataTableToList(data) : new List<TeamManagementEntity>();
        }

        /// <summary>
        /// 事务新增路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionAddTeamManagement(TeamManagementEntity teamManagement, TeamManagementProcessEntity teamManagementProcess)
        {
            var transaction = new TransactionLoader().BeginTransaction("TransactionAddTeamManagement");
            try
            {
                Add(teamManagement, transaction);

                if (teamManagementProcess != null)
                {
                    teamManagementProcess.TeamManagementId = teamManagement.Id;
                    new TeamManagementProcessDal().Add(teamManagementProcess, transaction);
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 事务处理路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionHandleTeamManagement(TeamManagementEntity teamManagement, TeamManagementProcessEntity teamManagementProcess)
        {
            var transaction = new TransactionLoader().BeginTransaction("TransactionHandleTeamManagement");
            try
            {
                Update(teamManagement, transaction);

                if (teamManagementProcess != null)
                {
                    teamManagementProcess.TeamManagementId = teamManagement.Id;
                    new TeamManagementProcessDal().Add(teamManagementProcess, transaction);
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 查询部门分组的统计报表
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public DataTable GetTeamManagementReportGroupByDept(string companyId, string stime, string etime)
        {
            StringBuilder selSql = new StringBuilder();
            selSql.Append(@"  select CCOMP.FullName CompanyName,CDEPT.FullName DepartmentName,
SUM(case when TM.Status in (0,1) then 1 else 0 end ) SumUntreated,
SUM(case when TM.Status in (2,3) then 1 else 0 end ) SumProcessed,
SUM(case when TM.ClassNo='00500001' then 1 else 0 end ) SumClassNo1,
SUM(case when TM.ClassNo='00500002' then 1 else 0 end ) SumClassNo2,
SUM(case when TM.ClassNo='00500003' then 1 else 0 end ) SumClassNo3,
SUM(case when TM.ClassNo='00500004' then 1 else 0 end ) SumClassNo4


 FROM  CrmDepartment   CDEPT with(nolock)
 inner join CrmCompany CCOMP with(nolock)
 ON CDEPT.CompanyId=CCOMP.Id
 left join TeamManagement  TM with(nolock)  
 ON CDEPT.Id=TM.DepartmentId ");

            if (!string.IsNullOrEmpty(stime))
            {
                selSql.AppendFormat(" AND CONVERT(varchar(100), TM.AssessmentTime, 23) >= '{0}' ", stime);
            }
            if (!string.IsNullOrEmpty(etime))
            {
                selSql.AppendFormat(" AND CONVERT(varchar(100), TM.AssessmentTime, 23) <= '{0}' ", etime);
            }

            selSql.Append(" where 1=1  and CCOMP.Enforcement=1 ");

            if (!string.IsNullOrEmpty(companyId))
            {
                selSql.AppendFormat(" and CDEPT.CompanyId='{0}'  ", companyId);
            }



            selSql.Append(" GROUP BY CCOMP.Id ,CCOMP.FullName ,CDEPT.Id ,CDEPT.FullName    order by CDEPT.FullName ");

            DataSet data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, System.Data.CommandType.Text, selSql.ToString());

            return data != null && data.Tables[0] != null ? data.Tables[0] : new DataTable();
        }

        /// <summary>
        /// 查询路面考核待办数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="assignUserId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetTeamManagementToDoNumber(string companyId, string deptId, string assignUserId, int state)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"SELECT COUNT(1) Number FROM TeamManagement AMT WITH(NOLOCK) WHERE 1=1");
            if (!string.IsNullOrEmpty(companyId))
            {
                sbSql.AppendFormat(" AND CompanyId='{0}' ", companyId);
            }

            if (!string.IsNullOrEmpty(deptId))
            {
                sbSql.AppendFormat(" AND DepartmentId='{0}' ", deptId);
            }

            if (!string.IsNullOrEmpty(assignUserId))
            {
                sbSql.AppendFormat(" AND AssignUserId='{0}' ", assignUserId);
            }

            if (state != -1)
            {
                sbSql.AppendFormat(" AND Status={0} ", state);
            }

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            if (list != null && list.Tables.Count > 0)
            {
                return int.Parse(list.Tables[0].Rows[0][0].ToString());

            }

            return 0;
        }

    }
}

