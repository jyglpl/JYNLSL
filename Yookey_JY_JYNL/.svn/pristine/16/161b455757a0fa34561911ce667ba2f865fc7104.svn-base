//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightParticularDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightParticular数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// FlightParticular数据访问操作
    /// </summary>
    public class FlightParticularDal : DalImp.BaseDal<FlightParticularEntity>
    {
        public FlightParticularDal()
        {
            Model = new FlightParticularEntity();
        }

        /// <summary>
        /// 查询排班明细记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表对应ID</param>
        /// <param name="classesId">排班部门对应表的ID</param>
        /// <param name="flightDays">排班日期</param>
        /// <returns>DataTable.</returns>
        public DataTable SelectParticular(string appearId, string classesId, string flightDays)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM FlightParticular WHERE AppearId='{0}' AND ClassesId='{1}' AND DATEDIFF(DAY,FlightDays,'{2}')=0",
                    appearId, classesId, flightDays);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询出排班排班日期范围内的所有记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表对应ID</param>
        /// <param name="flightDays">排班日期</param>
        /// <returns>DataTable.</returns>
        public DataTable SelectParticular(string appearId, string flightDays)
        {
            try
            {
                var strSql = new StringBuilder("");
                //strSql.AppendFormat("SELECT * FROM FlightParticular WHERE AppearId='{0}' AND DATEDIFF(DAY,FlightDays,'{1}')>0", appearId, flightDays);
                strSql.AppendFormat("SELECT * FROM FlightParticular WHERE AppearId='{0}' AND FlightDays='{1}'", appearId, flightDays);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public DataTable SelectParticularNoappearId(string classesId, string flightDays)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM FlightParticular WHERE 1=1 AND ClassesId='{0}' AND DATEDIFF(DAY,FlightDays,'{1}')=0",
                    classesId, flightDays);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 根据排班主表ID查询所有明细记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表ID</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable SelectParticular(string appearId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM FlightParticular WHERE AppearId='{0}'", appearId);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取个人月份排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="userId">用户编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetAppearByUser(string startDate, string endDate, string userId)
        {
           try
            {
                if(string.IsNullOrEmpty(startDate)||string.IsNullOrEmpty(endDate)||string.IsNullOrEmpty(userId))
                {
                    return new DataTable();
                }
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
@"Declare @beginTime datetime  
Declare @endTime datetime  
Declare @userId VARCHAR(50)
set @beginTime  = '{0}'  
set @endTime  = '{1}'
set @userId='{2}';
with temptab(datez) as  
( select @beginTime  
union all  
select dateadd(d,1,temptab.datez) as datez  
from temptab  
where dateadd(d,1,temptab.datez)<=@endTime  
) 
SELECT CONVERT(VARCHAR(10),FP.FlightDays,23) AS FlightDays,FCD.ClassesId AS ClassesName,(FCD.TimePeriodState+'-'+FCD.TimePeriodEnd) AS TimeBucket FROM FlightParticular AS FP WITH (NOLOCK)
JOIN FlightOfEmp AS FLA WITH(NOLOCK) ON FP.Id=FLA.ParticularId
JOIN FlightClassesOfDeptment AS FCD WITH(NOLOCK) ON FCD.Id=FP.ClassesId
WHERE  FCD.ClassesId<>'休息' AND FlightDays>=@beginTime AND FlightDays<=@endTime AND FLA.UserId=@userId 
union all--请假
select CONVERT(VARCHAR(10),T.datez,23) AS FlightDays,AL.LeaveTypeName AS ClassesName,(SUBSTRING(CONVERT(VARCHAR(30),AL.BeginTime,20),6,11)+' ~ '+SUBSTRING(CONVERT(VARCHAR(30),AL.EndTime,20),6,11)) AS TimeBucket from temptab T inner join AttendanceLeave AL on T.datez between CONVERT(VARCHAR(10),AL.BeginTime,23) and AL.EndTime where AL.UserId=@userId AND AL.RowStatus=1 AND AL.[Status]=10
union all--加班
select convert(VARCHAR(10),BeginTime,23) AS FlightDays,'加班' AS ClassesName,(convert(VARCHAR(5),BeginTime,8)+'-'+convert(VARCHAR(5),EndTime,8)) AS TimeBucket from WorkOvertime WHERE UserId=@userId AND BeginTime BETWEEN @beginTime AND @endTime AND RowStatus=1 AND [Status]=10
union all--考勤
SELECT convert(VARCHAR(10),AD.StartTime,23) AS FlightDays,CR.RsKey AS ClassesName,(convert(VARCHAR(5),AD.StartTime,8)+'-'+convert(VARCHAR(5),AD.EndTime,8)) AS TimeBucket FROM AttendanceReportDetails AD join ComResource CR on AD.AttendType=CR.Id join AttendanceReport AR on AR.Id=AD.ReportId WHERE AR.RowStatus=1 AND AR.[State]=10 AND AD.UserId=@userId AND AR.SMonth BETWEEN @beginTime AND @endTime
union all--调班
select CASE WHEN BeforeUserId=@userId THEN convert(VARCHAR(10),BeforeDate,23) WHEN AferUserId=@userId THEN convert(VARCHAR(10),AfterDate,23) END AS FlightDays,
'调班' AS ClassesName,
(BeforeUserName+BeforeClassesName+'-'+AfterUserName+AfterClassesName) AS TimeBucket
from FlightAlteration 
WHERE RowStatus=1 AND [Status]=10 AND (BeforeUserId=@userId OR AferUserId=@userId) AND (BeforeDate BETWEEN @beginTime AND @endTime OR AfterDate BETWEEN @beginTime AND @endTime)", startDate, endDate, userId);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}

