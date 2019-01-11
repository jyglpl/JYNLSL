using System.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class AttendanceStatisticsController : Controller
    {
        //
        // GET: /AttendanceStatistics/
        private readonly AttendanceLeaveBll _attendanceLeaveBll = new AttendanceLeaveBll();

        public ActionResult Index()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }


        /// <summary>
        /// 考勤表
        /// </summary>
        /// <returns></returns>
        public ActionResult AttendanceSheet()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }


        /// <summary>
        /// 绑定年、月
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="defaultYear">The default year.</param>
        /// <param name="defaultMonth">The default month.</param>
        public void BindDate(int? defaultYear, int? defaultMonth)
        {
            //绑定年（当前时间的前后十年）
            var yearList = new List<int>();
            var year = DateTime.Now.Year - 10;
            for (var i = 0; i < 20; i++)
            {
                var years = year + i;
                yearList.Add(years);
            }

            //绑定月份
            var monthList = new List<int>();
            for (var i = 1; i <= 12; i++)
            {
                monthList.Add(i);
            }

            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }


        /// <summary>
        /// 动态加载会计月的时间区间
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="firstControlId"></param>
        /// <param name="secondControlId"></param>
        /// <returns>System.String.</returns>
        public string AjaxLoadDateRange(int year, int month, string firstControlId, string secondControlId)
        {
            var sb = new StringBuilder();
            var date = Convert.ToDateTime(year + "-" + month + "-01");
            sb.AppendFormat("$('#" + firstControlId + "').val('" + date.AddMonths(-1).ToString("yyyy-MM") + "-26');");
            sb.AppendFormat("$('#" + secondControlId + "').val('" + date.ToString("yyyy-MM") + "-25');");

            return sb.ToString();
        }

        #region 考勤统计报表

        /// <summary>
        /// 考勤统计报表
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public string AttendanceStatisticsJson(string departmentId, string startTime, string endTime)
        {
            //获取中队下所有人员
            var users = new CrmUserBll().GetAllUsers(new CrmUserEntity() { DepartmentId = departmentId });

            //请假统计
            var leaveReport = new AttendanceLeaveBll().GetLeaveReportByDepartment(departmentId, startTime, endTime);
            //出勤情况统计
            var attendanceReport = new AttendanceReportBll().GetAttendanceReportByDepartment(departmentId, startTime, endTime);
            //加班统计
            var overTimeReport = new WorkOvertimeBll().GetWorkOvertimeByDepartment(departmentId, startTime, endTime);

            var list = new List<StatisticsEntity>();
            foreach (var user in users)
            {
                //年假
                double annualLeave = 0;
                var annualLeaveSplit = leaveReport.Select(string.Format("LeaveType='00060011' AND UserId='{0}'", user.Id));
                if (annualLeaveSplit.Length > 0)
                {
                    annualLeave += annualLeaveSplit.Sum(dataRow => double.Parse(dataRow["LeaveTime"].ToString()));
                }
                //病假
                double stickLeave = 0;
                var stickSplit = leaveReport.Select(string.Format("LeaveType='00060002' AND UserId='{0}'", user.Id));
                if (stickSplit.Length > 0)
                {
                    stickLeave += stickSplit.Sum(dataRow => double.Parse(dataRow["LeaveTime"].ToString()));
                }
                //事假
                double compassLeave = 0;
                var compassSplit = leaveReport.Select(string.Format("LeaveType='00060001' AND UserId='{0}'", user.Id));
                if (compassSplit.Length > 0)
                {
                    compassLeave += compassSplit.Sum(dataRow => double.Parse(dataRow["LeaveTime"].ToString()));
                }
                //其他假
                double otherLeave = 0;
                var otherSplit = leaveReport.Select(string.Format("LeaveType<>'00060001' AND LeaveType<>'00060002' AND LeaveType<>'00060011' AND UserId='{0}'", user.Id));
                if (otherSplit.Length > 0)
                {
                    otherLeave += otherSplit.Sum(dataRow => double.Parse(dataRow["LeaveTime"].ToString()));
                }

                //旷工
                var absenteeism = 0;
                var attendanceSplit = attendanceReport.Select(string.Format("AttendType='{0}' AND UserId='{1}'", "00510003", user.Id));
                absenteeism = attendanceSplit.Length;

                //迟到早退
                var lateLeaveEarly = 0;
                var lateLeaveEarlySplit = attendanceReport.Select(string.Format("(AttendType='00510001' OR AttendType='00510002') AND UserId='{0}'", user.Id));
                lateLeaveEarly = lateLeaveEarlySplit.Length;

                //加班
                var overTimeSplit = overTimeReport.Select(string.Format("UserId='{0}'", user.Id));
                double overTime = overTimeSplit.Sum(dataRow => Math.Round(double.Parse(dataRow["OverTime"].ToString()), 1));

                list.Add(new StatisticsEntity()
                    {
                        UserId = user.Id,
                        UserName = user.RealName,
                        AnnualLeave = annualLeave > 0 ? annualLeave.ToString() : "无",
                        SickLeave = stickLeave > 0 ? stickLeave.ToString() : "无",
                        CompassionateLeave = compassLeave > 0 ? compassLeave.ToString() : "无",
                        OtherLevae = otherLeave > 0 ? otherLeave.ToString() : "无",
                        Absenteeism = absenteeism > 0 ? absenteeism.ToString() : "无",
                        LateLeaveEarly = lateLeaveEarly > 0 ? lateLeaveEarly.ToString() : "无",
                        OverTime = overTime.ToString()
                    });
            }

            return JsonConvert.SerializeObject(list);
        }

        public class StatisticsEntity
        {
            /// <summary>
            /// 用户ID
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// 用户姓名
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 年休假
            /// </summary>
            public string AnnualLeave { get; set; }

            /// <summary>
            /// 病假
            /// </summary>
            public string SickLeave { get; set; }

            /// <summary>
            /// 事假
            /// </summary>
            public string CompassionateLeave { get; set; }

            /// <summary>
            /// 其他假
            /// </summary>
            public string OtherLevae { get; set; }

            /// <summary>
            /// 旷工
            /// </summary>
            public string Absenteeism { get; set; }

            /// <summary>
            /// 迟到早退
            /// </summary>
            public string LateLeaveEarly { get; set; }

            /// <summary>
            /// 加班
            /// </summary>
            public string OverTime { get; set; }
        }

        #endregion


        #region 考勤表

        #region 拼接动态列及合并列

        /// <summary>
        /// 拼接动态列
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public string GetDynamicColumn(string startTime, string endTime)
        {
            var list = new List<JqGridColModel>();
            list.Add(new JqGridColModel() { label = "姓名", name = "UserName", index = "UserName", width = 80, align = "center", cellattr = "function (rowId) {return id=UserName + rowId;}" });
            list.Add(new JqGridColModel() { label = "班别", name = "ClassName", index = "ClassName", width = 80, align = "center" });

            var startDate = Convert.ToDateTime(startTime);
            var endDate = Convert.ToDateTime(endTime);

            for (DateTime dtN = startDate; dtN <= endDate; dtN = dtN.AddDays(1))
            {
                var week = CommonMethod.GetWeekNum(dtN);
                var day = dtN.Day.ToString();
                list.Add(new JqGridColModel() { label = week, name = day, index = day, width = 23, align = "center" });
            }

            list.Add(new JqGridColModel() { label = "加班", name = "OverTime", index = "OverTime", width = 50, align = "center" });
            list.Add(new JqGridColModel() { label = "公休假", name = "Sabbatical", index = "Sabbatical", width = 50, align = "center" });
            list.Add(new JqGridColModel() { label = "病假", name = "SickLeave", index = "SickLeave", width = 50, align = "center" });
            list.Add(new JqGridColModel() { label = "事假", name = "CompassLeave", index = "CompassLeave", width = 50, align = "center" });
            list.Add(new JqGridColModel() { label = "其他假", name = "OtherLevae", index = "OtherLevae", width = 50, align = "center" });
            list.Add(new JqGridColModel() { label = "迟到早退", name = "LateLeaveEarly", index = "LateLeaveEarly", width = 50, align = "center" });

            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 拼接动态合并列
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public string GetDynamicGroupHeaders(string startTime, string endTime)
        {
            var list = new List<JqGridGroupHeaders>();
            var startDate = Convert.ToDateTime(startTime);
            var endDate = Convert.ToDateTime(endTime);

            for (DateTime dtN = startDate; dtN <= endDate; dtN = dtN.AddDays(1))
            {
                var day = dtN.Day.ToString();
                list.Add(new JqGridGroupHeaders() { startColumnName = day, numberOfColumns = 1, titleText = day });
            }

            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 列实体
        /// </summary>
        public class JqGridColModel
        {
            public string label { get; set; }
            public string name { get; set; }
            public string index { get; set; }
            public int width { get; set; }
            public string align { get; set; }
            public string cellattr { get; set; }
        }

        /// <summary>
        /// 合并列实体
        /// </summary>
        public class JqGridGroupHeaders
        {
            public string startColumnName { get; set; }
            public int numberOfColumns { get; set; }
            public string titleText { get; set; }
        }

        #endregion


        #region 请求数据

        /// <summary>
        /// 拼接动态列
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public string AttendanceSheetJson(string departmentId, string startTime, string endTime)
        {
            //获取中队下所有人员
            var users = new CrmUserBll().GetAllUsers(new CrmUserEntity() { DepartmentId = departmentId });

            //排班情况
            var deptSchedule = new FlightLochusAppearBll().GetDepartmentSchedule(departmentId, startTime, endTime);

            //请假统计
            var leaveReport = new AttendanceLeaveBll().GetLeaveReportByDepartment(departmentId, startTime, endTime);
            //出勤情况统计
            var attendanceReport = new AttendanceReportBll().GetAttendanceReportByDepartment(departmentId, startTime, endTime);
            //加班统计
            var overTimeReport = new WorkOvertimeBll().GetWorkOvertimeByDepartment(departmentId, startTime, endTime);


            //创建数据列
            var data = new DataTable();
            data.Columns.Add("UserId");
            data.Columns.Add("UserName");
            data.Columns.Add("ClassName");

            var startDate = Convert.ToDateTime(startTime);
            var endDate = Convert.ToDateTime(endTime);

            for (DateTime dtN = startDate; dtN <= endDate; dtN = dtN.AddDays(1))
            {
                var day = dtN.Day.ToString();
                data.Columns.Add(day);
            }
            data.Columns.Add("OverTime");
            data.Columns.Add("Sabbatical");
            data.Columns.Add("StickLeave");
            data.Columns.Add("CompassLeave");
            data.Columns.Add("OtherLevae");
            data.Columns.Add("LateLeaveEarly");

            foreach (var user in users)
            {
                var nRow = data.NewRow();
                nRow["UserId"] = user.Id;
                nRow["UserName"] = user.RealName;
                nRow["ClassName"] = "上班";

                var nRow2 = data.NewRow();
                nRow2["UserId"] = user.Id;
                nRow2["UserName"] = user.RealName;
                nRow2["ClassName"] = "加班";

                double sumCompassLeave = 0;  //事假（天数）
                double sumStickLeave = 0;    //病假（天数）
                double sumSabbatical = 0;    //公休假（天数）
                double sumOtherLeave = 0;    //其他假（天数）
                double sumOverTimes = 0;     //加班（小时）
                int sumEarlyAndLateCount = 0;  //迟到早退（次数）

                double tempsumCompassLeave =0;
                double tempsumStickLeave = 0;
                double tempsumSabbatical = 0;
                double tempsumOtherLeave = 0;

                for (DateTime dtN = startDate; dtN <= endDate; dtN = dtN.AddDays(1))
                {
                    var day = dtN.Day.ToString();

                    //排班
                    var scheduleSplit = deptSchedule.Select(string.Format("UserId='{0}' AND FlightDays='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //事假
                    var compassLeaveSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060001' AND BeginTime<='{1} 23:59:59' AND EndTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //病假
                    var stickLeaveSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060002' AND BeginTime<='{1} 23:59:59' AND EndTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //婚假
                    var marriageSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060003' AND BeginTime<='{1} 23:59:59' AND EndTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //公休假
                    var sabbaticalSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060005' AND BeginTime<='{1} 23:59:59' AND EndTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //其他假
                    var otherLeaveSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType<>'00060001' AND LeaveType<>'00060002' AND LeaveType<>'00060003' AND LeaveType<>'00060005' AND BeginTime<='{1} 23:59:59' AND EndTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //迟到
                    var lateSplit = attendanceReport.Select(string.Format("UserId='{0}' AND AttendType='00510001' AND StartTime>='{1}'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //早退
                    var leaveSplit = attendanceReport.Select(string.Format("UserId='{0}' AND AttendType='00510002' AND StartTime>='{1}' AND EndTime<='{1} 23:59:59'", user.Id, dtN.ToString(AppConst.DateFormat)));
                    //加班
                    var overTimeSplit = overTimeReport.Select(string.Format("UserId='{0}' AND BeginTime>='{1}' AND BeginTime<='{1} 23:59:59'", user.Id, dtN.ToString(AppConst.DateFormat)));

                    //考勤符号：/ 加班：加 迟到：ф 早退：X 事假：○ 病假：⊕ 其他假：⊙ 婚假：△ 公假：公

                    //第一行  （出勤情况）
                    var attendSymbolI = "";
                    if (scheduleSplit.Length > 0)
                    {
                        for (int i = 0; i < scheduleSplit.Length; i++)
                        {
                            if (!scheduleSplit[i]["ClassName"].Equals("休息"))
                            {
                                attendSymbolI = "/";
                            }
                        }
                    }
                    if (compassLeaveSplit.Length > 0 && scheduleSplit.Length > 0)
                    {
                        attendSymbolI = "○";
                        tempsumCompassLeave += 1;
                    }
                    if (stickLeaveSplit.Length > 0 && scheduleSplit.Length > 0)
                    {
                        attendSymbolI = "⊕";
                        tempsumStickLeave += 1;
                    }
                    if (marriageSplit.Length > 0 && scheduleSplit.Length > 0)
                    {
                        attendSymbolI = "△";
                        tempsumOtherLeave += 1;
                    }
                    if (sabbaticalSplit.Length > 0 && scheduleSplit.Length > 0)
                    {
                        attendSymbolI = "公";
                        tempsumSabbatical += 1;
                    }
                    if (otherLeaveSplit.Length > 0 && scheduleSplit.Length > 0)
                    {
                        attendSymbolI = "⊙";
                        tempsumOtherLeave += 1;
                    }
                    if (lateSplit.Length > 0)
                    {
                        sumEarlyAndLateCount += lateSplit.Count();    //计算迟到次数
                        attendSymbolI = "ф";
                    }
                    if (leaveSplit.Length > 0)
                    {
                        sumEarlyAndLateCount += lateSplit.Count();    //计算早退次数
                        attendSymbolI = "X";
                    }

                    //第二行  （加班情况）
                    var attendSymbolIi = "";
                    if (overTimeSplit.Length > 0)
                    {
                        //计算加班小时
                        sumOverTimes += overTimeSplit.Sum(overtime => double.Parse(overtime["OverTime"].ToString()));
                        attendSymbolIi = "加";
                    }

                    nRow[day] = attendSymbolI;
                    nRow2[day] = attendSymbolIi;
                }

                //计算事假
                var compassLeaveReportSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060001'", user.Id));
                if (compassLeaveReportSplit.Length > 0)
                {
                    foreach (var dataRow in compassLeaveReportSplit)
                    {
                        var sDate = Convert.ToDateTime(dataRow["BeginTime"].ToString());
                        var eDate = Convert.ToDateTime(dataRow["EndTime"].ToString());

                        if (CheckExtNextMonth(sDate, eDate)) //验证是否跨月，不跨月直接累计求和
                        {
                            sumCompassLeave += double.Parse(dataRow["LeaveTime"].ToString());
                        }
                        else
                        {
                            sumCompassLeave += tempsumCompassLeave;
                        }
                    }
                }

                //计算病假
                var stickLeaveReportSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060002'", user.Id));
                if (stickLeaveReportSplit.Length > 0)
                {
                    foreach (var dataRow in stickLeaveReportSplit)
                    {
                        var sDate = Convert.ToDateTime(dataRow["BeginTime"].ToString());
                        var eDate = Convert.ToDateTime(dataRow["EndTime"].ToString());

                        if (CheckExtNextMonth(sDate, eDate)) //验证是否跨月，不跨月直接累计求和
                        {
                            sumStickLeave += double.Parse(dataRow["LeaveTime"].ToString());
                        }
                        else
                        {
                            sumStickLeave += tempsumStickLeave;
                        }
                    }
                }

                //计算公休假
                var sabbaticalReportSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType='00060005'", user.Id));
                if (sabbaticalReportSplit.Length > 0)
                {
                    foreach (var dataRow in sabbaticalReportSplit)
                    {
                        var sDate = Convert.ToDateTime(dataRow["BeginTime"].ToString());
                        var eDate = Convert.ToDateTime(dataRow["EndTime"].ToString());

                        if (CheckExtNextMonth(sDate, eDate)) //验证是否跨月，不跨月直接累计求和
                        {
                            sumSabbatical += double.Parse(dataRow["LeaveTime"].ToString());
                        }
                        else
                        {
                            sumSabbatical += tempsumSabbatical;
                        }
                    }
                }

                //计算其他假
                var otherLeaveReportSplit = leaveReport.Select(string.Format("UserId='{0}' AND LeaveType<>'00060001' AND LeaveType<>'00060002' AND LeaveType<>'00060005'", user.Id));
                if (otherLeaveReportSplit.Length > 0)
                {
                    foreach (var dataRow in otherLeaveReportSplit)
                    {
                        var sDate = Convert.ToDateTime(dataRow["BeginTime"].ToString());
                        var eDate = Convert.ToDateTime(dataRow["EndTime"].ToString());

                        if (CheckExtNextMonth(sDate, eDate)) //验证是否跨月，不跨月直接累计求和
                        {
                            sumOtherLeave += double.Parse(dataRow["LeaveTime"].ToString());
                        }
                        else
                        {
                            sumOtherLeave += tempsumOtherLeave;
                        }
                    }
                }

                nRow["OverTime"] = sumOverTimes > 0 ? sumOverTimes.ToString() : "";
                nRow["Sabbatical"] = sumSabbatical > 0 ? sumSabbatical.ToString() : "";
                nRow["StickLeave"] = sumStickLeave > 0 ? sumStickLeave.ToString() : "";
                nRow["CompassLeave"] = sumCompassLeave > 0 ? sumCompassLeave.ToString() : "";
                nRow["OtherLevae"] = sumOtherLeave > 0 ? sumOtherLeave.ToString() : "";
                nRow["LateLeaveEarly"] = sumEarlyAndLateCount > 0 ? sumEarlyAndLateCount.ToString() : "";

                data.Rows.Add(nRow);
                data.Rows.Add(nRow2);
            }

            return JsonConvert.SerializeObject(data);
        }


        /// <summary>
        /// 验证两段日期是否跨月
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CheckExtNextMonth(DateTime beginDate, DateTime endDate)
        {
            DateTime accountBeginDate = DateTime.Now;
            DateTime accountEndDate = DateTime.Now;

            if (beginDate.Day > 25)
            {
                accountBeginDate = Convert.ToDateTime(beginDate.ToString("yyyy-MM") + "-26");
                accountEndDate = Convert.ToDateTime(accountBeginDate.AddMonths(1).AddDays(-1).ToString(AppConst.DateFormat) + " 23:59:59");
            }
            else
            {
                accountEndDate = Convert.ToDateTime(beginDate.ToString("yyyy-MM") + "-25");
                accountBeginDate = accountEndDate.AddMonths(-1).AddDays(1);

                accountEndDate = Convert.ToDateTime(accountEndDate.ToString(AppConst.DateFormat) + " 23:59:59");
            }
            return (beginDate >= accountBeginDate && endDate <= accountEndDate);
        }

        #endregion

        #endregion
    }
}



