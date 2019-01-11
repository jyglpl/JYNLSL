//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceLeaveDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/22 10:50:18
//  功能描述：AttendanceLeave数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Text;
using DBHelper;
using System.Data;
using Yookey.WisdomClassed.SIP.Model.Hr;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// AttendanceLeave数据访问操作
    /// </summary>
    public class AttendanceLeaveDal : DalImp.BaseDal<AttendanceLeaveEntity>
    {
        public AttendanceLeaveDal()
        {
            Model = new AttendanceLeaveEntity();
        }


        /// <summary>
        /// 事务保存请假
        /// 添加人：周 鹏
        /// 添加时间：2017-03-24
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        public bool TransactionSaveLeave(AttendanceLeaveEntity entity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveLeave");
            try
            {
                var noticeId = "";
                if (Get(entity.Id) != null)
                {
                    noticeId = entity.Id;
                    Update(entity, transaction);
                }
                else
                {
                    //noticeId = Guid.NewGuid().ToString();
                    //entity.Id = noticeId;
                    noticeId = entity.Id;
                    Add(entity, transaction);
                }


                //保存附件
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE ComAttachment WHERE ResourceId='{0}'", noticeId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                if (!(string.IsNullOrEmpty(entity.Attachment) || entity.Attachment.Split(',').Length.Equals(0)))
                {
                    var attachDal = new ComAttachmentDal();
                    var splitAttach = entity.Attachment.Split('|');
                    foreach (var attach in splitAttach)
                    {
                        var attachInfo = attach.Split(',');
                        var receiveEntity = new ComAttachmentEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourceId = noticeId,
                            FileName = attachInfo[2],
                            FileReName = attachInfo[3],
                            FileAddress = attachInfo[1],
                            RowStatus = 1,
                            CreateOn = DateTime.Now
                        };
                        attachDal.Add(receiveEntity, transaction);
                    }
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
        /// 获取全部数据
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-24 周 鹏 修改Sql 语句
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetAllData(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT AL.Id ,DeptName,UserName,LeaveTypeName,LeaveReason,BeginTime,EndTime,LeaveTime ,
(CASE WHEN [Status] = -2 THEN '已作废'
WHEN [Status] = -1 THEN '审批不通过'
WHEN [Status] = 0 THEN '登记'
WHEN [Status] > 0 AND [Status] < 10 THEN '审批中'
WHEN [Status] = 10 THEN '审批通过' ELSE '审批不通过' END ) AS Status FROM AttendanceLeave AS AL
WHERE AL.RowStatus=1");

            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND AL.CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(" AND AL.DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND AL.BeginTime>='{0}' AND AL.BeginTime<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND AL.BeginTime>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND AL.BeginTime<='{0} 23:59:59.999'", endTime);
            }
            else if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND AL.UserName LIKE '%{0}%'", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeginTime", "DESC", pageIndex, pageSize, out totalRecords);

        }

        /// <summary>
        /// 获取全部数据（用于汇总）
        /// 创建人：周庆
        /// 创建日期：2015年4月30日
        /// </summary>
        /// <param name="companyId">请求单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetAllSumaryData(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT dept.SortCode AS DeptSort,bu.SortCode AS UserSort,leave.Id,leave.DeptName,leave.UserName,leave.LeaveTypeName,leave.LeaveReason,
leave.BeginTime,leave.EndTime,leave.LeaveTime FROM AttendanceLeave leave WITH(NOLOCK)
LEFT JOIN CrmUser bu WITH(NOLOCK) ON bu.Id = leave.Id
LEFT JOIN CrmDepartment dept WITH(NOLOCK) ON dept.Id = leave.DeptId
WHERE leave.RowStatus=1 AND leave.[Status]=10");

            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND leave.CompanyId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(" AND leave.DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND leave.BeginTime>='{0}' leave.AND BeginTime<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND leave.BeginTime>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND leave.BeginTime<='{0} 23:59:59.999'", endTime);
            }
            else if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND leave.UserName LIKE '%{0}%'", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "DeptSort, UserSort", "Asc", pageIndex, pageSize, out totalRecords);
        }


        /// <summary>
        /// 获取个人的全部请假记录
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">开始时间（不需要则null）</param>
        /// <param name="endTime">机制时间（不需要则null）</param>
        /// <param name="keyWords">关键字（不需要则null）</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总记录条数</param>
        /// <returns></returns>
        public DataTable GetAllDataByUserDeptId(string userId, string deptId, string startTime, string endTime, string keyWords, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT    Id ,
                                            DeptName ,
                                            UserName ,
                                            LeaveTypeName ,
                                            LeaveReason ,
                                            BeginTime ,
                                            EndTime ,
                                            CONVERT(VARCHAR(5), LeaveTime) AS LeaveTime ,
                                            ( CASE WHEN [Status] = -2 THEN '已作废'
                                                   WHEN [Status] = -1 THEN '审批不通过'
                                                   WHEN [Status] = 0 THEN '登记'
                                                   WHEN [Status] > 0
                                                        AND [Status] < 10 THEN '审批中'
                                                   WHEN [Status] = 10 THEN '审批通过'
                                                   ELSE '审批不通过'
                                              END ) AS Status
                                    FROM    AttendanceLeave
                                    WHERE   RowStatus = 1 AND UserId='{0}' AND DeptId='{1}'", userId, deptId);


            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime>='{0}' AND BeginTime<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime<='{0} 23:59:59.999'", endTime);
            }
            else if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%'", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeginTime", "Desc", pageIndex, pageSize, out totalRecords);

        }


        /// <summary>
        /// 更改请假的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            var strSql = string.Format("UPDATE AttendanceLeave SET [Status]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 更改的状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
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
                var strSql = string.Format("UPDATE AttendanceLeave SET [Status]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 更改的状态
        /// 添加人：周 鹏
        /// 添加时间：2017-12-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <param name="upUserId">更新人</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state,string upUserId)
        {
            try
            {
                var strSql = string.Format("UPDATE AttendanceLeave SET [Status]={0},UpdateId='{1}',UpdateOn=GETDATE() WHERE Id='{2}'", state,upUserId, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门所有审核通过的请假记录
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
        public DataTable GetLeaveReportByDepartment(string deptmentId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT * FROM AttendanceLeave WHERE RowStatus=1 AND [Status]=10");

                if (!string.IsNullOrEmpty(deptmentId) && !deptmentId.Equals("all"))
                {
                    strSql.AppendFormat(@" AND DeptId='{0}'", deptmentId);
                }
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat(@" AND ((BeginTime>='{0}' AND BeginTime<='{1} 23:59:59.999') OR (BeginTime<'{0}' AND EndTime>='{1}'))", startTime, endTime);
                }

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取人员的调休
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetCompTime(string userId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"Declare @userId VARCHAR(50)
set @userId='{0}';
WITH WorkTime AS--本年度加班时间
(
SELECT ISNULL(SUM(Overtime),0) AS WorkTimeNumber  FROM WorkOvertime  WHERE UserId=@userId AND RowStatus=1 AND [Status]=10
),
LeavetTime AS--本年度已近补休的时间
(
SELECT ISNULL(SUM(LeaveTime*8),0) AS LeavetTimeNumber FROM AttendanceLeave WHERE UserId=@userId AND RowStatus=1 AND [Status]=10 AND LeaveType='00060010' 
),
OvertimeHistor AS--2017年1到五月的历史加班时长
(
SELECT ISNULL(SUM(Overtime),0) AS HistorsWorkTimeNumber FROM OvertimeHistoryReport WHERE UserId=@userId AND RowStatus=1
)
SELECT (SELECT *FROM WorkTime)+(SELECT *FROM OvertimeHistor)-(SELECT *FROM LeavetTime) AS HasTime,(SELECT *FROM WorkTime)+(SELECT *FROM OvertimeHistor) SumTime", userId);
           return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
           
            catch(Exception ex)
            {
                return new DataTable();
            }
        }
    }
}

