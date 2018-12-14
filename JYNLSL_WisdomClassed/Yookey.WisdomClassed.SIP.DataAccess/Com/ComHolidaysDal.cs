//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComHolidaysDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/20 9:42:35
//  功能描述：ComHolidays数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using System.Linq;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComHolidays数据访问操作
    /// </summary>
    public class ComHolidaysDal : DalImp.BaseDal<ComHolidaysEntity>
    {
        public ComHolidaysDal()
        {
            Model = new ComHolidaysEntity();
        }


        /// <summary>
        /// 保存一个月的节假日设定
        /// 添加人：周 鹏
        /// 添加时间：2014-03-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="list">节假日集</param>
        /// <param name="sTime">设定月份</param>
        /// <returns></returns>
        public bool SaveHostDate(List<ComHolidaysEntity> list, DateTime sTime)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveHolidays");
            try
            {
                var startTime = Convert.ToDateTime(sTime.ToString("yyyy-MM") + "-01");  //开始时间
                var endTime = startTime.AddMonths(1).AddDays(-1);                       //截止时间
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat("UPDATE ComHolidays SET RowStatus=0 WHERE HostDate BETWEEN '{0}' AND '{1}'", startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"));
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());

                foreach (var comHolidaysEntity in list)
                {
                    Add(comHolidaysEntity, transaction);
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
        /// 查询数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<ComHolidaysEntity> GetSearchResult(ComHolidaysEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ComHolidays WHERE RowStatus=1 ");
            if (search.HostDate.Year != 1900)
            {
                var startTime = Convert.ToDateTime(search.HostDate.ToString("yyyy-MM") + "-01");  //开始时间
                var endTime = startTime.AddMonths(1).AddDays(-1); //截止时间
                strSql.AppendFormat("AND HostDate BETWEEN '{0}' AND '{1}'", startTime, endTime);
            }

            strSql.Append("ORDER BY HostDate");

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ComHolidaysEntity>();
        }

        /// <summary>
        /// 获取工日时间
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="time">时间</param>
        /// <param name="limit">审批时限</param>
        /// <returns></returns>
        public DateTime GetWorkTime(DateTime time, int limit = 3)
        {
             var endTime = time.AddDays(20);
            var strSql = new StringBuilder("");

            strSql.AppendFormat(@"SELECT * FROM ComHolidays WHERE RowStatus=1 ");
            strSql.AppendFormat("AND HostDate BETWEEN '{0}' AND '{1}'", time, endTime);
            var list = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]).Select(i=>i.HostDate).ToList();
            var addDays = 1;
            for (var i = 1; addDays < limit; i++)
            {
                time=time.AddDays(1);
                if (list.FindIndex(z => (z - time).Days == 0) != -1)
                    continue;
                addDays++;//
            }

            //var random = new Random((int)(DateTime.Now.Ticks));
            //var hour = random.Next(9, 17);
            //var minute = random.Next(0, 60);
            //var second = random.Next(0, 60);
            
            return time;
        }        

    }
}

