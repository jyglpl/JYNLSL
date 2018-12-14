//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="EmployeeWageBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/16 11:16:42
//  功能描述：EmployeeWage业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Hr;
using System.Linq;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// EmployeeWage业务逻辑
    /// </summary>
    public class EmployeeWageBll : BaseBll<EmployeeWageEntity>
    {
        private EmployeeWageDal _dal = new EmployeeWageDal();

        public EmployeeWageBll()
        {
            BaseDal = new EmployeeWageDal();
        }

        /// <summary>
        /// 查询工资信息
        /// </summary>
        /// <param name="person"></param>
        /// <param name="date"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        public PageJqDatagrid<EmployeeWageDetailEntity> GetCommonQuryGetCommonQury(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart,string wageTimeEnd
         ,string userId,int status, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = _dal.GetCommonQury(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd,userId,status, pageSize, pageIndex, out totalRecords);
            var list = ConvertListHelper<EmployeeWageDetailEntity>.ConvertToList(data);
            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<EmployeeWageDetailEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteWage(string id)
        {     
            return _dal.DeleteWage(id);
        }

        /// <summary>
        /// 导出EXCEL方法
        /// </summary>
        /// <param name="person"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable ExportExcel(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart, string wageTimeEnd)
        {
            var data = _dal.ExportExcel(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd);
            return data;
        }

        /// <summary>
        /// 导入Excel到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool ImportWage(DataTable dt, string sendWageTime, string wageTime,ref List<string> lstName)
        {
            var dtUser = _dal.GetAllUser();        
            foreach (DataRow row in dt.Rows)
            {
               EmployeeWageEntity wage=new EmployeeWageEntity();
               wage.Id = Guid.NewGuid().ToString();
               if (dtUser.Select(string.Format("RealName='{0}'", row["UserName"])).Length == 0)
               {
                   lstName.Add(row["UserName"].ToString().Trim());
                   continue;
               }
               else
               {
                   wage.UserId = dtUser.Select(string.Format("RealName='{0}'", row["UserName"]))[0]["UserId"].ToString();
               }
               wage.DutyWage = double.Parse(row["DutyWage"].ToString());
               wage.LevelWage = double.Parse(row["LevelWage"].ToString());
               wage.ColligateBT = double.Parse(row["ColligateBT"].ToString());
               wage.PostJT = double.Parse(row["PostJT"].ToString());
               wage.BaseJT = double.Parse(row["BaseJT"].ToString());
               wage.AddressBT = double.Parse(row["AddressBT"].ToString());
               wage.SpecialJT = double.Parse(row["SpecialJT"].ToString());
               wage.TelephoneBT = double.Parse(row["TelephoneBT"].ToString());
               wage.OvertimeToll = double.Parse(row["OvertimeToll"].ToString());
               wage.MissEatToll = double.Parse(row["MissEatToll"].ToString());
               wage.ReissueWage = double.Parse(row["ReissueWage"].ToString());
               wage.PersonTax = double.Parse(row["PersonTax"].ToString());
               wage.HouseWage = double.Parse(row["HouseWage"].ToString());
               wage.MedicalInsurance = double.Parse(row["MedicalInsurance"].ToString());
               wage.EndowmentInsurance = double.Parse(row["EndowmentInsurance"].ToString());
               wage.BuckleUp = double.Parse(row["BuckleUp"].ToString());
               wage.WageTime =DateTime.Parse(wageTime);
               wage.SendWageTime =DateTime.Parse(sendWageTime);
               Add(wage);
            }
            if (lstName.Count > 0)
                return false;
            return true;

        }

        /// <summary>
        /// 返回table 数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public PageJqDatagrid<EmployeeWageDetailEntity> ImprotData(DataTable dt,int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords=dt.Rows.Count;
            var list = ConvertListHelper<EmployeeWageDetailEntity>.ConvertToList(dt);
            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<EmployeeWageDetailEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }
    } 
}
