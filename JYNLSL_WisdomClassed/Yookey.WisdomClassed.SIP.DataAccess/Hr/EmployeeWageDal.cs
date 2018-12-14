//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="EmployeeWageDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/16 11:16:42
//  功能描述：EmployeeWage数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// EmployeeWage数据访问操作
    /// </summary>
    public class EmployeeWageDal : DalImp.BaseDal<EmployeeWageEntity>
    {
        public EmployeeWageDal()
        {
            Model = new EmployeeWageEntity();
        }

        /// <summary>
        /// 查询工资
        /// </summary>
        /// <param name="person"></param>
        /// <param name="date"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCommonQury(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart, string wageTimeEnd,
            string userId, int status, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder();
                if (status == 0)
                    str.AppendFormat(@"SELECT AAA.* FROM VIEW_Wage_Query AAA WHERE AAA.UserId='{0}'", userId);
                if (status == 1)
                    str.AppendFormat(@"SELECT AAA.* FROM VIEW_Wage_Query AAA,JCXXDB.DBO.Base_User AA,JCXXDB.DBO.Base_User BB
                                            WHERE  AAA.UserId=AA.UserId AND AA.CompanyId=BB.CompanyId AND 
                                            AA.DepartmentId=BB.DepartmentId AND BB.UserId='{0}'", userId);
                if (status == 2)
                    str.AppendFormat(@"SELECT* FROM VIEW_Wage_Query AAA WHERE 1=1");
                if (!string.IsNullOrEmpty(person))
                    str.Append(string.Format(@" AND AAA.UserName like '%{0}%'", person));
                if (!string.IsNullOrEmpty(sendWageTimeStart))
                    str.Append(string.Format(@" AND AAA.SendWageTime>='{0}'", sendWageTimeStart));
                if (!string.IsNullOrEmpty(sendWageTimeEnd))
                    str.Append(string.Format(@" AND AAA.SendWageTime<='{0}'", sendWageTimeEnd));
                if (!string.IsNullOrEmpty(wageTimeStart))
                    str.Append(string.Format(@" AND AAA.WageTime >='{0}' ", wageTimeStart + "-01"));
                if (!string.IsNullOrEmpty(wageTimeEnd))
                    str.Append(string.Format(@" AND AAA.WageTime <='{0}' ", wageTimeEnd + "-01"));

                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, str.ToString(), "*", "", "WageTime", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取所以得用户信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2016-02-15  周 鹏 增加按执法大队条件过滤
        /// </history>
        /// <returns></returns>
        public DataTable GetAllUser()
        {
            try
            {
                var str = new StringBuilder(@"SELECT UserId,RealName FROM JCXXDB.dbo.Base_User WHERE CompanyId='c1ef0d6f-4ba6-4acb-8c98-cc5a87f3954f'");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除工资信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteWage(string id)
        {
            try
            {
                var del = new StringBuilder(string.Format("Delete From EmployeeWage Where Id='{0}'",
                    id));
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, del.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询导出Excel数据
        /// </summary>
        /// <param name="person"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable ExportExcel(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart, string wageTimeEnd)
        {
            try
            {
                var str = new StringBuilder(@"SELECT aa.RealName UserName, bb.DutyWage, bb.LevelWage, 
	                bb.ColligateBT,bb.PostJT, bb.BaseJT, bb.AddressBT, 
                    ISNULL(bb.DutyWage, 0) + ISNULL(bb.LevelWage, 0) + ISNULL(bb.ColligateBT, 0)
	                + ISNULL(bb.PostJT, 0) + ISNULL(bb.BaseJT, 0) + ISNULL(bb.AddressBT, 0)
                    AS SmallTotal,
	                bb.SpecialJT, bb.TelephoneBT, bb.OvertimeToll, bb.MissEatToll,  bb.ReissueWage,
                    ISNULL(bb.SpecialJT, 0) + ISNULL(bb.TelephoneBT, 0) 
	                + ISNULL(bb.OvertimeToll, 0) + ISNULL(bb.MissEatToll, 0) + ISNULL(bb.DutyWage, 0) 
                    + ISNULL(bb.LevelWage, 0) + ISNULL(bb.ColligateBT, 0) + ISNULL(bb.PostJT, 0) 
                    + ISNULL(bb.BaseJT, 0) + ISNULL(bb.AddressBT, 0) + ISNULL(bb.ReissueWage, 0)
                    AS Total, 
                    bb.PersonTax, bb.HouseWage,bb.MedicalInsurance,bb.BuckleUp,	                         
	                ISNULL(bb.PersonTax, 0) + ISNULL(bb.HouseWage, 0)
                    + ISNULL(bb.MedicalInsurance, 0)+ ISNULL(bb.BuckleUp, 0)     
                    AS LittleTotal,
                    (ISNULL(bb.SpecialJT, 0)  + ISNULL(bb.TelephoneBT, 0) + ISNULL(bb.OvertimeToll, 0)
                    + ISNULL(bb.MissEatToll, 0) + ISNULL(bb.DutyWage, 0) + ISNULL(bb.LevelWage, 0)
	                + ISNULL(bb.ColligateBT, 0)  + ISNULL(bb.PostJT, 0) + ISNULL(bb.BaseJT, 0) 
                    + ISNULL(bb.AddressBT, 0)   + ISNULL(bb.ReissueWage, 0)) - (ISNULL(bb.PersonTax, 0)
                    + ISNULL(bb.HouseWage, 0)+ISNULL(bb.MedicalInsurance, 0)+ ISNULL(bb.BuckleUp, 0)) 
                    AS ZTotal
                    FROM JCXXDB.dbo.Base_User aa,EmployeeWage bb where aa.UserId=bb.UserId");
                if (!string.IsNullOrEmpty(person))
                    str.Append(string.Format(@" AND aa.RealName like '%{0}%'", person));
                if (!string.IsNullOrEmpty(sendWageTimeStart))
                    str.Append(string.Format(@" AND bb.sendWageTime>='{0}'", sendWageTimeStart));
                if (!string.IsNullOrEmpty(sendWageTimeEnd))
                    str.Append(string.Format(@" AND bb.sendWageTime<='{0}'", sendWageTimeEnd));
                if (!string.IsNullOrEmpty(wageTimeStart))
                    str.Append(string.Format(@" AND bb.wageTime >='{0}' ", wageTimeStart + "-01"));
                if (!string.IsNullOrEmpty(wageTimeEnd))
                    str.Append(string.Format(@" AND bb.wageTime <='{0}'", wageTimeEnd + "-01"));
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

