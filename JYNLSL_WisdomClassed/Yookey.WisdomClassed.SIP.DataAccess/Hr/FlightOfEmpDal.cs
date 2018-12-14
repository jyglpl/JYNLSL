//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightOfEmpDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightOfEmp数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Hr;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// FlightOfEmp数据访问操作
    /// </summary>
    public class FlightOfEmpDal : DalImp.BaseDal<FlightOfEmpEntity>
    {
        public FlightOfEmpDal()
        {
            Model = new FlightOfEmpEntity();
        }

        /// <summary>
        /// 保存人员排班数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="particularId">排班明细ID</param>
        /// <param name="userList">用户集</param>
        /// <returns><c>true</c>保存成功<c>false</c>保存失败</returns>
        public bool SaveFlightUsers(string particularId, string xxParticularId, List<string> userList)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveFlightUsers");
            try
            {
                var listSql = new List<string>();
                var delSql = string.Format("DELETE FlightOfEmp WHERE ParticularId='{0}'", particularId);
                listSql.Add(delSql);

                // 删除休息人员
                if (!string.IsNullOrEmpty(xxParticularId))
                {
                    var sql = string.Format("DELETE FlightOfEmp WHERE ParticularId='{0}'", xxParticularId);
                    listSql.Add(sql);
                }

                var i = 0;
                foreach (var userId in userList)
                {
                    if (string.IsNullOrEmpty(userId)) continue;
                    listSql.Add(string.Format("INSERT INTO dbo.FlightOfEmp(Id,ParticularId,UserId,OrderNo) VALUES(NEWID(),'{0}','{1}',{2})", particularId, userId, i));
                    i++;
                }
                const int size = 20; //每次最多执行Sql条数
                //总页数
                var pagecount = Math.Ceiling(Convert.ToDouble(listSql.Count) / size);
                for (var j = 0; j < pagecount; j++)
                {
                    var list = listSql.Skip(j * size).Take(size);
                    var sql = string.Join("", list.ToArray());
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                    //SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sql);
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
        /// 根据排班明细表编号查询出排班人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="particularId">排班明细表ID</param>
        /// <returns>DataTable.</returns>
        public DataTable GetUsersByParticular(string particularId)
        {
            var strSql = string.Format("SELECT UserId FROM FlightOfEmp WHERE ParticularId='{0}' ORDER BY OrderNo", particularId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 获取整个部门当月的排班人员(排除休息人员)
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetFlightOfUsersBydeptIdDate(string deptId, string date)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT FP.FlightDays,FOE.UserId 
FROM FlightLochusAppear AS FLA WITH(NOLOCK)
JOIN FlightParticular AS FP WITH(NOLOCK) ON FLA.AppearId=FP.AppearId
JOIN FlightOfEmp AS FOE WITH(NOLOCK) ON FP.Id=FOE.ParticularId
JOIN FlightClassesOfDeptment AS FD WITH(NOLOCK) ON FD.Id=FP.ClassesId
WHERE  FD.RowStatus=1 AND FLA.DeptId='{0}' AND  FP.FlightDays BETWEEN  '{1}' AND DATEADD(dd,-1,DATEADD(MM,1,'{1}'))", deptId, date);

                DataTable data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过日期和人员查询排班信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="flightDays"></param>
        /// <returns></returns>
        public DataTable GetFlightOfEmpByUserIdAndFlightDays(string userId, string flightDays)
        {
            string sqlStr = string.Format(@" select  FE.Id FlightOfEmpId,CONVERT(varchar(10), fp.FlightDays, 23)  FlightDays,
        fp.ClassesId,FD.ClassesId ClassesName
from FlightParticular FP with(nolock)
inner join FlightOfEmp FE with(nolock)
on FP.Id=FE.ParticularId  
inner join FlightClassesOfDeptment FD with(nolock)
on fp.ClassesId=FD.Id
where FE.UserId='{0}'  
and   CONVERT(varchar(10), fp.FlightDays, 23)='{1}'

order by fp.FlightDays ", userId, flightDays);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sqlStr).Tables[0];

        }
    }
}

