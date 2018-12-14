using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Report;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    /// <summary>
    /// 案件分析
    /// </summary>
    public class PenaltyAnalysisController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly CaseAnalysisBll _caseAnalysisBll = new CaseAnalysisBll();

        #region 视图

        /// <summary>
        /// 案件分析-按类型
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            //LoadDefaultDate();
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 按案件分类
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByClassify()
        {
            //LoadDefaultDate();
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 按时间趋势
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByDate()
        {
            ViewBag.StartTime = DateTime.Now.AddYears(-1).ToString("yyyy") + "-12-26";
            ViewBag.EndTime = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        /// <summary>
        /// 按处理情况
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByHandle()
        {
            //LoadDefaultDate();
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 按部门
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByDept()
        {
            //LoadDefaultDate();
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 按阶段分析
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByStage()
        {
            LoadDefaultDate();
            return View();
        }

        /// <summary>
        /// 按城市顽疾
        /// 添加人：周 鹏
        /// 添加时间：2015-05-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult StatisitcsByCityIlls()
        {
            ViewBag.StartTime = DateTime.Now.ToString("yyyy") + "-01-01";
            ViewBag.EndTime = DateTime.Now.ToString("yyyy") + "-12-31";
            return View();
        }


        public void LoadDefaultDate()
        {
            var date = DateTime.Now;
            var startTime = date.AddDays(1 - date.Day);
            var endTime = startTime.AddMonths(1).AddDays(-1);

            ViewBag.StartTime = startTime.ToString(AppConst.DateFormat);
            ViewBag.EndTime = endTime.ToString(AppConst.DateFormat);
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

        #endregion

        #region Ajax 数据请求

        #region 首页-按案件类别柱状图、按八大类饼图


        /// <summary>
        /// 按八大类统计出案件量（饼图）
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-05 周 鹏 增加按时间区间
        /// </history>
        /// <returns>System.String.</returns>
        public string IndexReportByClass(string type)
        {
            try
            {
                return _caseAnalysisBll.ReportChartByClass("pie", type);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }


        /// <summary>
        /// 按案件类型统计出案件量（柱状图）
        /// 添加人：周 鹏
        /// 添加时间：2017-03-14
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>System.String.</returns>
        public string IndexReportCharByClassify(string type)
        {
            try
            {
                return _caseAnalysisBll.ReportCharByClassify("bar", type);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按类型统计

        /// <summary>
        /// 按八大类统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="classNo">八大类类型</param>
        /// <returns>System.String.</returns>
        public string ReportChartByClass(string chartType, string type, string sTime, string eTime, string classNo, string caseType)
        {
            try
            {
                return _caseAnalysisBll.ReportChartByClass(chartType, type, sTime, eTime, classNo, caseType);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按案件分类

        /// <summary>
        /// 按案件分类
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByClassify(string chartType, string type, string sTime, string eTime)
        {
            try
            {
                return _caseAnalysisBll.ReportCharByClassify(chartType, type, sTime, eTime);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按中队分析

        /// <summary>
        /// 按执法中队统计出案件量（柱状图）
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>System.String.</returns>
        public string ReportCharByReportByDept(string chartType, string type, string companyId, string deptId, string sTime, string eTime, string reportType = "Total")
        {
            try
            {
                return _caseAnalysisBll.ReportByDept("bar", type, companyId, deptId, sTime, eTime, reportType);
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按阶段分析

        /// <summary>
        /// 按阶段分析
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByStage(string chartType, string type, string sTime, string eTime)
        {
            try
            {
                return _caseAnalysisBll.ReportCharByStage(chartType, type, sTime, eTime);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按处理情况

        /// <summary>
        /// 按处理情况
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByHandle(string chartType, string type, string caseType, string sTime, string eTime)
        {
            try
            {
                return _caseAnalysisBll.ReportByHandle(chartType, type, caseType, sTime, eTime);
            }
            catch (Exception)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按时间趋势
        /// <summary>
        /// 按时间趋势统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>System.String.</returns>
        public string ReportCharByReportByDate(string type, string sTime, string eTime, string reportType = "Total")
        {
            try
            {
                return _caseAnalysisBll.GetCaseTotalByDate(type, sTime, eTime, reportType);
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }
        #endregion

        #region 按城市顽疾
        /// <summary>
        /// 按时间趋势统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByReportByCityIlls(string chartType, string type, string sTime, string eTime)
        {
            try
            {
                return _caseAnalysisBll.ReportCharByCityIlls(chartType, type, sTime, eTime);
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }
        #endregion

        #region 违法停车-案件趋势图

        /// <summary>
        /// 按日期统计每月的案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string GetCarTotalByDate()
        {
            try
            {
                return _caseAnalysisBll.GetCarTotalByDate();
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        #endregion

        #endregion
    }
}
