//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightLochusAppearDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightLochusAppear数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// 排班主表数据访问操作
    /// </summary>
    public class FlightLochusAppearDal : DalImp.BaseDal<FlightLochusAppearEntity>
    {
        public FlightLochusAppearDal()
        {
            Model = new FlightLochusAppearEntity();
        }

        /// <summary>
        /// 查询排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="time">时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable SelectAppear(string deptId, string time)
        {
            try
            {
                //var strSql = string.Format("SELECT * FROM FlightLochusAppear WHERE DATEDIFF(DAY,FlightDate,'{0}')=0 AND DeptId='{1}'", time, deptId);
                var strSql = string.Format("SELECT * FROM FlightLochusAppear WHERE DATEDIFF(DAY,FlightDate,'{0}')=0 AND DeptId='{1}'", time, deptId);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 查询排班对应的人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">班次ID</param>
        /// <param name="date">排班日期</param>
        /// <returns>DataTable.</returns>
        public DataTable GetFlightOfUsers(string deptId, string classesId, string date)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT (CASE WHEN BU.IsBorrow=1 THEN BU.RealName+'（外借）' ELSE BU.RealName END) AS UserName,BU.Id UserId,BU.IsCityManager CityManager
FROM FlightLochusAppear AS FLA WITH(NOLOCK)
JOIN FlightParticular AS FP WITH(NOLOCK) ON FLA.AppearId=FP.AppearId
JOIN FlightOfEmp AS FOE WITH(NOLOCK) ON FP.Id=FOE.ParticularId
JOIN CrmUser AS BU ON BU.Id=FOE.UserId
WHERE BU.RowStatus=1 AND FLA.DeptId='{0}' AND FP.ClassesId='{1}' AND DATEDIFF(DAY,FP.FlightDays,'{2}')=0 ORDER BY BU.FlightSortCode", deptId, classesId, date);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 删除排班记录信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班编号</param>
        /// <param name="particularDt">排班明细集</param>
        /// <returns><c>true</c>删除成功<c>false</c>删除失败</returns>
        public bool DeleteApperar(string appearId, DataTable particularDt)
        {
            var transaction = new TransactionLoader().BeginTransaction("DeleteFlight");
            try
            {
                var listSql = (from DataRow row in particularDt.Rows
                               select string.Format("DELETE FlightOfEmp WHERE ParticularId='{0}'", row["Id"])).ToList();

                var delPar = string.Format("DELETE FlightParticular WHERE AppearId='{0}';DELETE FlightLochusAppear WHERE AppearId='{0}'", appearId);
                listSql.Add(delPar);


                const int size = 20; //每次最多执行Sql条数
                //总页数
                var pagecount = Math.Ceiling(Convert.ToDouble(listSql.Count) / size);
                for (var j = 0; j < pagecount; j++)
                {
                    var list = listSql.Skip(j * size).Take(size);
                    var sql = string.Join("", list.ToArray());
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 删除一天的排班记录信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班编号</param>
        /// <param name="particularDt">排班明细集</param>
        /// <returns><c>true</c>删除成功<c>false</c>删除失败</returns>
        public bool DeleteApperar(string appearId, DataTable particularDt,string day)
        {
            var dayTime=new DateTime();
            if(string.IsNullOrEmpty(appearId)||string.IsNullOrEmpty(day)||particularDt==null||particularDt.Rows.Count<=0||!DateTime.TryParse(day,out dayTime))
            {
                return false;
            }
            var transaction = new TransactionLoader().BeginTransaction("DeleteFlight");
            try
            {
                var listSql = particularDt.Select().Where(z => (DateTime.Parse(z["FlightDays"].ToString()) - dayTime).Days == 0).Select(i => string.Format("DELETE FlightOfEmp WHERE ParticularId='{0}'", i["Id"])).ToList();

                var delPar = string.Format("DELETE FlightParticular WHERE AppearId='{0}' AND FlightDays='{1}';", appearId,day);
                listSql.Add(delPar);
                const int size = 20; //每次最多执行Sql条数
                //总页数
                var pagecount = Math.Ceiling(Convert.ToDouble(listSql.Count) / size);
                for (var j = 0; j < pagecount; j++)
                {
                    var list = listSql.Skip(j * size).Take(size);
                    var sql = string.Join("", list.ToArray());
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 更改排班状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="state">状态</param>
        /// <param name="appearId">排班编号</param>
        /// <exception cref="System.Exception"></exception>
        public bool UpdateFlightState(int state, string appearId)
        {
            try
            {
                var strSql = string.Format("UPDATE FlightLochusAppear SET [State]={0} WHERE AppearId='{1}'", state, appearId);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 请求一个月的排班数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="flightDays"></param>
        /// <param name="classesId"></param>
        /// <param name="deptId"></param>
        /// <returns>DeptId:部门编号,FlightDays:排班日期,ClassesId:班次编号,UserName:排班人员</returns>
        public DataTable GetMonthData(string flightDays, string classesId, string deptId = "")
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT FLA.DeptId,CONVERT(VARCHAR(10),FP.FlightDays,23) AS FlightDays,FP.ClassesId,BU.RealName AS UserName ,bu.Id UserId 
FROM FlightLochusAppear AS FLA WITH(NOLOCK)
JOIN FlightParticular AS FP WITH(NOLOCK) ON FLA.AppearId=FP.AppearId
JOIN FlightOfEmp AS FOE WITH(NOLOCK) ON FOE.ParticularId=FP.Id
JOIN CrmUser AS BU WITH(NOLOCK) ON FOE.UserId=BU.Id
WHERE CONVERT(VARCHAR(10),FP.FlightDays,23)= '{0}'  ", flightDays);
                if (!string.IsNullOrEmpty(deptId))
                {
                    strSql.AppendFormat(" AND FLA.DeptId='{0}' ", deptId);
                }

                if (!string.IsNullOrEmpty(classesId))
                {
                    strSql.AppendFormat(" AND FP.ClassesId ='{0}' ", classesId);
                }

                strSql.Append(" ORDER BY FOE.OrderNo ");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 班次人员统计表
        /// 添加人：周 鹏
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public DataTable UserReport(string deptId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"select  FD.ClassesId,CU.RealName,CU.DepartmentId,FP.FlightDays from FlightOfEmp FE 
JOIN FlightParticular FP ON FP.Id=FE.ParticularId 
JOIN FlightClassesOfDeptment FD ON FD.Id=FP.ClassesId 
JOIN CrmUser CU ON FE.UserId=CU.Id 
WHERE 1=1 AND CU.DepartmentId='{0}' AND FP.FlightDays BETWEEN '{1}' AND '{2}' AND FD.RowStatus=1
", deptId,startTime, endTime);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门时间范围内所有排班情况
        /// 添加人：周 鹏
        /// 添加时间：2017-05-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <returns></returns>
        public DataTable GetDepartmentSchedule(string deptId,string startDate,string endDate)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT FOE.UserId,FP.ClassName,CONVERT(VARCHAR(10),FP.FlightDays,121) AS FlightDays FROM FlightLochusAppear AS FLA WITH(NOLOCK)
JOIN FlightParticular AS FP WITH(NOLOCK) ON FLA.AppearId=FP.AppearId
JOIN FlightOfEmp AS FOE WITH(NOLOCK) ON FP.Id=FOE.ParticularId
WHERE FLA.DeptId='{0}' AND FlightDays>='{1}' AND FlightDays<='{2} 23:59:59'", deptId, startDate, endDate);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }


        /// <summary>
        /// 获取部门的当天的排班信息
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <param name="day">哪一天</param>
        /// <returns></returns>
        public DataTable SelectUserByDay(string deptId,string day)
        {
            var table = new DataTable();
            if (string.IsNullOrEmpty(deptId) || string.IsNullOrEmpty(day))
            {
                return table;
            }
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM FlightParticular FP join FlightLochusAppear FA ON FA.AppearId=FP.AppearId WHERE FP.FlightDays='{0}' AND FA.DeptId='{1}'", day, deptId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

    }
}

