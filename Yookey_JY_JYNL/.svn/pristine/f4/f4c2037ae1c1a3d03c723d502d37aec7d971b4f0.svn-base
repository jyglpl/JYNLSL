//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightClassesOfDeptmentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightClassesOfDeptment数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// FlightClassesOfDeptment数据访问操作
    /// </summary>
    public class FlightClassesOfDeptmentDal : DalImp.BaseDal<FlightClassesOfDeptmentEntity>
    {
        public FlightClassesOfDeptmentDal()
        {
            Model = new FlightClassesOfDeptmentEntity();
        }

        /// <summary>
        /// 通过部门Id查询部门班别设定信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<FlightClassesOfDeptmentEntity> GetFlightClassesOfDeptmentListByDeptId(string deptId)
        {
            var sbSql = new StringBuilder("");
            sbSql.AppendFormat(@"SELECT FCD.Id,FCD.DeptId,FCD.ClassesId,FCD.TimePeriodState,FCD.TimePeriodEnd,FCD.RowStatus,
FCD.Version,FCD.CreatorId,FCD.CreateBy,FCD.CreateOn,FCD.UpdateId,FCD.UpdateBy,FCD.UpdateOn,
dept.FullName DepteName,FCD.ClassesId ClassesName
FROM FlightClassesOfDeptment FCD with(nolock)
LEFT JOIN CrmDepartment dept with(nolock)
ON fcd.DeptId=dept.Id
WHERE FCD.deptId='{0}' AND FCD.RowStatus=1 ORDER BY FCD.OrderNo", deptId);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<FlightClassesOfDeptmentEntity>();
        }

        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="particularId"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public bool TransactionSave(List<FlightClassesOfDeptmentEntity> modelList)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveFlightUsers");
            try
            {
                foreach (var item in modelList)
                {
                    Add(item, transaction);
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
        /// 设置默认班别
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public bool SetDefault(string deptId)
        {
            var sqlStr = new StringBuilder("");
            sqlStr.AppendFormat("SELECT * FROM FlightClassesOfDeptment WHERE DeptId='{0}' AND ClassesId='休息'",deptId);
            try
            {
                var result = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, sqlStr.ToString());
                sqlStr = new StringBuilder("");
                if (result != null)
                {
                    sqlStr.AppendFormat("UPDATE FlightClassesOfDeptment SET RowStatus=1 WHERE DeptId='{0}' AND ClassesId='休息'", deptId);
                }
                else
                {
                    sqlStr.AppendFormat(@"INSERT INTO FlightClassesOfDeptment([Id],[DeptId],[ClassesId],[OrderNo],[RowStatus],[CreateOn],[TimePeriodState],[TimePeriodEnd])
                                    VALUES(NEWID(),'{0}','休息',20,1,GETDATE(),'','')", deptId);
                }
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, sqlStr.ToString()) > 0;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}

