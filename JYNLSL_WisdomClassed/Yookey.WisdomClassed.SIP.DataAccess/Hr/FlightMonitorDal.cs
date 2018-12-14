//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightMonitorDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightMonitor数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// FlightMonitor数据访问操作
    /// </summary>
    public class FlightMonitorDal : DalImp.BaseDal<FlightMonitorEntity>
    {
        public FlightMonitorDal()
        {
            Model = new FlightMonitorEntity();
        }

        /// <summary>
        /// 根据值班时间获取数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="day">值班日期</param>
        /// <returns>FlightMonitorEntity.</returns>
        public FlightMonitorEntity GetEntityByDay(string day)
        {
            var strSql = string.Format("SELECT * FROM dbo.FlightMonitor WHERE DATEDIFF(DAY,OndutyDate,'{0}')=0", day);

            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt != null && dt.Rows.Count > 0 ? DataTableToList(dt)[0] : null;
        }

        /// <summary>
        /// 查询出一个月内所有值班信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="day">日期</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDataSource(string day)
        {
            var strSql = string.Format("SELECT * FROM dbo.FlightMonitor WHERE DATEDIFF(MONTH,OndutyDate,'{0}')=0", day);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }
    }
}

