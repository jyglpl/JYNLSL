//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportDetailsBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 13:22:22
//  功能描述：AttendanceReportDetails业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// AttendanceReportDetails业务逻辑
    /// </summary>
    public class AttendanceReportDetailsBll : BaseBll<AttendanceReportDetailsEntity>
    {
        public AttendanceReportDetailsBll()
        {
            BaseDal = new AttendanceReportDetailsDal();
        }


        /// <summary>
        /// 查询考勤记录
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<AttendanceReportDetailsEntity> GetSearchResult(AttendanceReportDetailsEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(AttendanceReportDetailsEntity.Parm_AttendanceReportDetails_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ReportId))
            {
                queryCondition.AddEqual(AttendanceReportDetailsEntity.Parm_AttendanceReportDetails_ReportId, search.ReportId);
            }
            //排序
            queryCondition.AddOrderBy(AttendanceReportDetailsEntity.Parm_AttendanceReportDetails_CreateOn, true);
            return Query(queryCondition) as List<AttendanceReportDetailsEntity>;
        }

        /// <summary>
        /// 获取考勤记录
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public DataTable GetAttendanceDetails(string reportId)
        {
            return new AttendanceReportDetailsDal().GetAttendanceDetails(reportId);
        }
    }
}
