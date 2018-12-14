//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportDetailsDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 13:22:22
//  功能描述：AttendanceReportDetails数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// AttendanceReportDetails数据访问操作
    /// </summary>
    public class AttendanceReportDetailsDal : DalImp.BaseDal<AttendanceReportDetailsEntity>
    {
        public AttendanceReportDetailsDal()
        {           
            Model = new AttendanceReportDetailsEntity();
        }

        /// <summary>
        /// 获取考勤记录
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public DataTable GetAttendanceDetails(string reportId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(
                @"SELECT CU.RealName,CR.RsKey AS AttendType,ARD.StartTime,ARD.EndTime,ARD.Remark FROM AttendanceReportDetails AS ARD WITH(NOLOCK)
JOIN ComResource AS CR WITH(NOLOCK) ON ARD.AttendType=CR.Id AND CR.ParentId='0051'
JOIN CrmUser AS CU WITH(NOLOCK) ON ARD.UserId=CU.Id
WHERE ARD.ReportId='{0}'
ORDER BY ARD.OrderNo", reportId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
}
                                                                                                                                         
