using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Report;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel.Contrib;
using NPOI.SS.UserModel;
using Yookey.WisdomClassed.SIP.Common;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Case;
using Newtonsoft.Json.Converters;


namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    public class PenaltyStatisticalController : BaseController
    {
        private readonly CaseReportBll _caseReportBll = new CaseReportBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        private readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        private readonly InfCaseCollectBll _infCaseCollectBll = new InfCaseCollectBll();

        #region 视图


        /// <summary>
        /// 现场纠处、违章建筑、户外广告
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <param name="caseType">1:现场纠处、2:违章建筑、3:户外广告</param>
        /// <returns></returns>
        public ActionResult CaseCollectIndex(int caseType)
        {
            //类型标示
            ViewBag.CaseType = caseType;
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);

            //类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 添加案件
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCaseCollect(int caseType)
        {
            ViewBag.CaseType = caseType;
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);

            //类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            BindDate(DateTime.Now.Year, DateTime.Now.Month);

            return View();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditCaseCollect(string Id, int caseType)
        {
            ViewBag.CaseType = caseType;
            InfCaseCollectEntity model = _infCaseCollectBll.Get(Id);
            if (model == null)//不存在跳转到新增
                return RedirectToAction("AddCaseCollect", new { caseType = ViewBag.CaseType });

            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", model.DeptId);

            //类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey", model.ClassesNo);

            BindDate(model.ReportingPeriod.Year, model.ReportingPeriod.Month);
            return View(model);
        }

        /// <summary>
        /// 案件分类汇总报表
        /// 创建人：周庆
        /// 创建日期：2015年5月19日
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseCatalogSumaryReport()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 年度汇总报表
        /// 创建人：周庆
        /// 创建日期：2015年5月19日
        /// </summary>
        /// <returns></returns>
        public ActionResult AnnualSummaryReport()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 案件月报表
        /// 创建人：周庆
        /// 创建日期：2015年5月18日
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseMonthReport()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 处理情况统计表
        /// 添加人：周 鹏
        /// 添加时间：2015-05-18
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult HandlingInformation()
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 案件明细统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseDetailsReport()
        {
            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            //部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            var processType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0028" }).Where(x => x.Id != "00280003").ToList();
            processType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ProcessType"] = new SelectList(processType, "Id", "RsKey");

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 违法停车统计表
        /// </summary>
        /// <returns></returns>
        public ActionResult CarReport()
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
        #endregion

        #region Ajax 数据请求

        /// <summary>
        /// 删除案件信息
        /// 创建人：周庆
        /// 创建日期：2015年5月26日
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeleteCaseCollect(string Id)
        {
            int res = _infCaseCollectBll.DeleteCaseCollect(Id, CurrentUser.CrmUser);
            return res.ToString();
        }
        /// <summary>
        /// 获取案件信息
        /// 创建人：周庆
        /// 创建日期：2015年5月26日
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="classNo"></param>
        /// <param name="period"></param>
        /// <param name="caseType"></param>
        /// <returns></returns>
        public JsonResult GetCaseCollent(string deptId, string classNo, string period, int caseType)
        {
            InfCaseCollectEntity entity = _infCaseCollectBll.GetCaseCollent(deptId, period, classNo, (InfCaseCollectEntity.CaseType)caseType);
            return Json(new { rtState = 1, Data = entity });
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

        /// <summary>
        /// 处理情况统计
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2017-03-16 周 鹏 增加单位编号
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string AjaxReportHandling(string companyId, string caseType, string startTime, string endTime)
        {
            var data = _caseReportBll.QueryHandlingInformation(companyId, caseType, startTime, endTime);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 案件明细统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="targetType">当事人类型</param>
        /// <returns></returns>
        public string AjaxReportCaseDetails(string startTime, string endTime, string deptid, string ProcessTypeId, string State, string ClassNo, string targetType, string keyword, string sidx, string sord)
        {
            var data = _caseReportBll.QueryCaseDetailsInformation(startTime, endTime, deptid, ProcessTypeId, State, ClassNo, targetType, keyword, sidx, sord);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        /// <summary>
        /// 年度各中队统计汇总
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年份</param>
        /// <returns>System.String.</returns>
        public string AjaxReportAnnualSummary(int? year)
        {
            var data = _caseReportBll.QueryAnnualSummary(year ?? DateTime.Now.Year);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 案件汇总统计
        /// 添加人：周 鹏
        /// 添加时间：2015-05-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string AjaxCaseCatalogSumary(string companyId, string caseType, string startTime, string endTime)
        {
            var data = _caseReportBll.CaseCatalogSumary(companyId, caseType, startTime, endTime);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }
               
        /// <summary>
        /// Ajaxes the case month.
        /// 添加人：周 鹏
        /// 添加时间：2015-05-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="total"></param>
        /// <param name="deptId">部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string AjaxCaseMonth(string companyId, string total, string deptId, string startTime, string endTime)
        {
            var data = _caseReportBll.CaseMonth(companyId, total, startTime, endTime);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }


        /// <summary>
        /// 执法月报表
        /// 添加人：周 鹏
        /// 添加时间：2017-03-17
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId"></param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public string AjaxCarReport(string companyId, string deptId, string startTime, string endTime)
        {
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = endTime + " 23:59:59";
            }
            var data = _caseReportBll.CarReport(companyId, deptId, startTime, endTime);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        #endregion

        #region Ajax提交数据

        /// <summary>
        /// 创建
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JsonResult CreateCaseCollect(InfCaseCollectEntity entity)
        {
            var user = CurrentUser.CrmUser;
            var isOk = false;
            var msg = "";
            try
            {
                UpdateModel(entity);
                if (_infCaseCollectBll.AddOrUpdateCaseCollect(entity, user) != null)
                    isOk = true;
            }
            catch (Exception e)
            {
                isOk = false;
                msg = e.Message;
            }
            return Json(new { Status = isOk, Msg = msg });

        }


        /// <summary>
        /// 获取现场纠处的全部数据
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="period">时间（月）</param>
        /// <param name="classNo">分类</param>
        /// <param name="caseType"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string GetCaseCollectData(string deptId, string period, string classNo, int caseType, int page = 1, int rows = 30)
        {

            var data = _infCaseCollectBll.SearchCaseCollect(deptId, period, classNo, (InfCaseCollectEntity.CaseType)caseType, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;

        }
        #endregion

        #region 导出Excel

        /// <summary>
        /// 导出案件月报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <param name="total"></param>
        /// <param name="deptId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        ///  <param name="title"></param>
        public void ExportCaseMonthReport(string companyId, string total, string deptId, string startTime, string endTime, string title)
        {
            var fileName = "案件月报表.xls";
            var reportTitle = "姑苏区综合行政执法月报表";
            if (!string.IsNullOrEmpty(total) && total.Equals("checked"))
            {
                fileName = "累计月报表.xls";
                reportTitle = "姑苏区综合行政执法月报表";
            }

            var data = _caseReportBll.CaseMonth(companyId, total, startTime, endTime);
            MemoryStream ms = CreateCaseMonthReport(data, reportTitle, title);
            TurnFileStreamForDownload(fileName, ms);
        }

        /// <summary>
        /// 导出年度汇总报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <returns></returns>
        public void ExportAnnualSummaryReport(int? year)
        {
            const string fileName = "年度汇总报表.xls";
            var data = _caseReportBll.QueryAnnualSummary(year ?? DateTime.Now.Year);
            var columnCnName = new string[] { "中队", "类型", "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月", "合计" };
            for (int i = 0, j = data.Columns.Count; i < j; i++)
            {
                data.Columns[i].ColumnName = columnCnName[i];
            }
            MemoryStream ms = CreateAnnualSummaryReport(data, year ?? DateTime.Now.Year);
            TurnFileStreamForDownload(fileName, ms);
        }

        /// <summary>
        /// 导出处理信息报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="title"></param>
        public void ExportHandlingInformationReport(string companyId, string caseType, string startTime, string endTime, string title)
        {
            string fileName = "处理情况统计报表.xls";
            var data = _caseReportBll.QueryHandlingInformation(companyId, caseType, startTime, endTime);
            MemoryStream ms = CreateHandlingInformationReport(data, title);
            TurnFileStreamForDownload(fileName, ms);
        }
        /// <summary>
        /// 导出案件明细报表
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptid">部门</param>
        /// <param name="title"></param>
        public void ExportCaseDetailsReport(string startTime, string endTime, string deptid, string title, string ProcessTypeId, string State, string ClassNo, string targetType, string keyword, string sidx, string sord)
        {
            string fileName = "案件明细统计报表.xls";
            var data = _caseReportBll.QueryCaseDetailsInformation(startTime, endTime, deptid, ProcessTypeId, State, ClassNo, targetType, keyword, sidx, sord);
            if (data != null)
            {
                data.Columns.RemoveAt(0);
                data.Columns.RemoveAt(0);
            }
            MemoryStream ms = CreateCaseDetailsReport(data, title);
            TurnFileStreamForDownload(fileName, ms);
        }


        /// <summary>
        /// 导出案件分类汇总报表
        /// 创建人：周庆
        /// 创建日期：2015年5月22日
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public void ExportCaseCatalogSumaryReport(string deptId, string caseType, string startTime, string endTime)
        {
            const string fileName = "案件汇总统计报表.xls";
            var data = _caseReportBll.CaseCatalogSumary(deptId, caseType, startTime, endTime);


            var date = Convert.ToDateTime(endTime);
            var title = string.Format("{0}案件分类汇总", date.ToString("yyyy年MM月"));

            MemoryStream ms = CreateCaseCatalogSumaryReport(data, title);
            TurnFileStreamForDownload(fileName, ms);
        }

        /// <summary>
        /// 创建案件分类汇总报表
        /// 创建人:周庆
        /// 创建日期:2015年5月22日
        /// </summary>
        /// <param name="table">数据集</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        private MemoryStream CreateCaseCatalogSumaryReport(DataTable table, string title)
        {
            MemoryStream stream = new MemoryStream();
            //Excel工作本
            using (HSSFWorkbook workbook = new HSSFWorkbook())
            {
                int RowHeight = 18;//行高
                //细边框
                NPOI.SS.UserModel.CellStyle styleThinBorder = workbook.CreateCellStyle();
                styleThinBorder.Alignment = HorizontalAlignment.CENTER;
                styleThinBorder.VerticalAlignment = VerticalAlignment.CENTER;
                styleThinBorder.BorderTop = CellBorderType.THIN;
                styleThinBorder.BorderBottom = CellBorderType.THIN;
                styleThinBorder.BorderLeft = CellBorderType.THIN;
                styleThinBorder.BorderRight = CellBorderType.THIN;
                styleThinBorder.TopBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.BottomBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.LeftBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.RightBorderColor = IndexedColors.BLACK.Index;

                CellStyle styleLeft = workbook.CreateCellStyle();
                styleLeft.CloneStyleFrom(styleThinBorder);
                styleLeft.Alignment = HorizontalAlignment.CENTER;

                //无边框
                NPOI.SS.UserModel.CellStyle styleNoBorder = workbook.CreateCellStyle();
                styleNoBorder.Alignment = HorizontalAlignment.CENTER;
                styleNoBorder.VerticalAlignment = VerticalAlignment.CENTER;

                //加粗22*22
                Font font1 = workbook.CreateFont();
                font1.FontHeight = 22 * 15;
                font1.Boldweight = short.MaxValue;

                //加粗16*16
                Font font2 = workbook.CreateFont();
                font2.FontHeight = 18 * 18;
                font2.Boldweight = short.MaxValue;
                styleNoBorder.SetFont(font2);



                using (Sheet sheet = workbook.CreateSheet())
                {
                    #region 标题
                    //大标题
                    //设置样式
                    CellStyle styleBigTitle = workbook.CreateCellStyle();
                    styleBigTitle.CloneStyleFrom(styleNoBorder);
                    styleBigTitle.SetFont(font1);
                    var values = new string[] {"姑苏区综合行政执法局"};
                    Row rowBigTitle = CreateMergedRegionRow(sheet, 0, 1, 5, 5, values, styleBigTitle);
                    rowBigTitle.HeightInPoints = 150;//行高


                    //副标题
                    //设置样式
                    CellStyle styleSecondTitle = workbook.CreateCellStyle();
                    styleSecondTitle.CloneStyleFrom(styleNoBorder);
                    styleSecondTitle.SetFont(font2);
                    values = new string[] { title };
                    Row rowSecondTitle = CreateMergedRegionRow(sheet, 1, 1, 5, 5, values, styleSecondTitle);
                    rowSecondTitle.HeightInPoints = 50;

                    #endregion

                    #region 表头
                    //创建2行
                    Row row3 = sheet.CreateRow(2);
                    Row row4 = sheet.CreateRow(3);
                    sheet.AddMergedRegion(new CellRangeAddress(2, 3, 0, 0));
                    row3.CreateCell(0).SetCellValue("案由名称");
                    sheet.AddMergedRegion(new CellRangeAddress(2, 2, 1, 2));
                    row3.CreateCell(1).SetCellValue("案件数");
                    sheet.AddMergedRegion(new CellRangeAddress(2, 2, 3, 4));
                    row3.CreateCell(3).SetCellValue("罚款额");
                    row4.CreateCell(1).SetCellValue("本月");
                    row4.CreateCell(2).SetCellValue("累计");
                    row4.CreateCell(3).SetCellValue("本月");
                    row4.CreateCell(4).SetCellValue("累计");
                    //样式
                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        HSSFCellUtil.GetCell(row3, i).CellStyle = styleThinBorder;
                        HSSFCellUtil.GetCell(row4, i).CellStyle = styleThinBorder;
                    }
                    #endregion

                    DataTableToExcel(sheet, table, styleThinBorder, false, 4);

                    #region 设置列宽宽度 行高
                    Row row = null;
                    for (int m = 0, n = sheet.LastRowNum; m <= n; m++)
                    {
                        row = sheet.GetRow(m);
                        row.HeightInPoints = RowHeight;
                        //第一列左对齐
                        if (m > 0 && m < n)
                            HSSFCellUtil.GetCell(row, 0).CellStyle = styleLeft;
                    }

                    sheet.SetColumnWidth(0, 10 * 1000);//第一列宽一点
                    for (int i = 1, j = table.Columns.Count; i < j; i++)
                    {
                        sheet.SetColumnWidth(i, 10 * 300);
                    }
                    #endregion
                    workbook.Write(stream);
                }
            }
            stream.Flush();
            stream.Position = 0;
            return stream;

        }

        /// <summary>
        /// 创建处理情况统计报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="table"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private MemoryStream CreateHandlingInformationReport(DataTable table, string title)
        {
            MemoryStream stream = new MemoryStream();
            //Excel工作本
            using (HSSFWorkbook workbook = new HSSFWorkbook())
            {
                int RowHeight = 18;//行高
                //细边框
                NPOI.SS.UserModel.CellStyle styleThinBorder = workbook.CreateCellStyle();
                styleThinBorder.Alignment = HorizontalAlignment.CENTER;
                styleThinBorder.VerticalAlignment = VerticalAlignment.CENTER;
                styleThinBorder.BorderTop = CellBorderType.THIN;
                styleThinBorder.BorderBottom = CellBorderType.THIN;
                styleThinBorder.BorderLeft = CellBorderType.THIN;
                styleThinBorder.BorderRight = CellBorderType.THIN;
                styleThinBorder.TopBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.BottomBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.LeftBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.RightBorderColor = IndexedColors.BLACK.Index;

                //无边框
                NPOI.SS.UserModel.CellStyle styleNoBorder = workbook.CreateCellStyle();
                styleNoBorder.Alignment = HorizontalAlignment.CENTER;
                styleNoBorder.VerticalAlignment = VerticalAlignment.CENTER;
                //加粗16*16
                Font font2 = workbook.CreateFont();
                font2.FontHeight = 16 * 16;
                font2.Boldweight = short.MaxValue;
                styleNoBorder.SetFont(font2);
                using (Sheet sheet = workbook.CreateSheet())
                {
                    Row rowTitle = sheet.CreateRow(0);
                    rowTitle.HeightInPoints = 40;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));
                    rowTitle.CreateCell(0).SetCellValue(string.Format("{0}案件处理情况统计表", title));
                    for (int i = 0; i < 6; i++)
                        HSSFCellUtil.GetCell(rowTitle, i).CellStyle = styleNoBorder;

                    #region 表头
                    //创建2行
                    Row row1 = sheet.CreateRow(1);
                    Row row2 = sheet.CreateRow(2);
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 0, 0));
                    row1.CreateCell(0).SetCellValue("部门");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, 2));
                    row1.CreateCell(1).SetCellValue("全部案件");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 3, 4));
                    row1.CreateCell(3).SetCellValue("停车类型案件");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 5, 6));
                    row1.CreateCell(5).SetCellValue("非停车类型案件");
                    row2.CreateCell(1).SetCellValue("已开停违单");
                    row2.CreateCell(2).SetCellValue("未处理单");
                    row2.CreateCell(3).SetCellValue("已开停违单");
                    row2.CreateCell(4).SetCellValue("未处理单");
                    row2.CreateCell(5).SetCellValue("已开停违单");
                    row2.CreateCell(6).SetCellValue("未处理单");
                    //样式
                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        HSSFCellUtil.GetCell(row1, i).CellStyle = styleThinBorder;
                        HSSFCellUtil.GetCell(row2, i).CellStyle = styleThinBorder;
                    }
                    #endregion

                    DataTableToExcel(sheet, table, styleThinBorder, false, 3);

                    #region 设置列宽宽度 行高
                    for (int m = 0, n = sheet.LastRowNum; m <= n; m++)
                        sheet.GetRow(m).HeightInPoints = RowHeight;

                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        sheet.SetColumnWidth(i, 10 * 350);
                    }
                    #endregion
                    workbook.Write(stream);
                }
            }
            stream.Flush();
            stream.Position = 0;
            return stream;
        }

        private MemoryStream CreateCaseDetailsReport(DataTable table, string title)
        {
            MemoryStream stream = new MemoryStream();
            //Excel工作本
            using (HSSFWorkbook workbook = new HSSFWorkbook())
            {
                int RowHeight = 18;//行高
                //细边框
                NPOI.SS.UserModel.CellStyle styleThinBorder = workbook.CreateCellStyle();
                styleThinBorder.Alignment = HorizontalAlignment.CENTER;
                styleThinBorder.VerticalAlignment = VerticalAlignment.CENTER;
                styleThinBorder.BorderTop = CellBorderType.THIN;
                styleThinBorder.BorderBottom = CellBorderType.THIN;
                styleThinBorder.BorderLeft = CellBorderType.THIN;
                styleThinBorder.BorderRight = CellBorderType.THIN;
                styleThinBorder.TopBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.BottomBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.LeftBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.RightBorderColor = IndexedColors.BLACK.Index;

                //无边框
                NPOI.SS.UserModel.CellStyle styleNoBorder = workbook.CreateCellStyle();
                styleNoBorder.Alignment = HorizontalAlignment.CENTER;
                styleNoBorder.VerticalAlignment = VerticalAlignment.CENTER;
                //加粗16*16
                Font font2 = workbook.CreateFont();
                font2.FontHeight = 16 * 16;
                font2.Boldweight = short.MaxValue;
                styleNoBorder.SetFont(font2);
                using (Sheet sheet = workbook.CreateSheet())
                {
                    Row rowTitle = sheet.CreateRow(0);
                    rowTitle.HeightInPoints = 40;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 9));
                    rowTitle.CreateCell(0).SetCellValue(string.Format("{0}案件明细统计表", title));
                    for (int i = 0; i < 9; i++)
                        HSSFCellUtil.GetCell(rowTitle, i).CellStyle = styleNoBorder;

                    #region 表头
                    //创建2行
                    Row row1 = sheet.CreateRow(1);
                    Row row2 = sheet.CreateRow(2);
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 0, 0));
                    row1.CreateCell(0).SetCellValue("通知书编号");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 1, 1));
                    row1.CreateCell(1).SetCellValue("案件编号");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 2, 2));
                    row1.CreateCell(2).SetCellValue("登记时间");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 3, 3));
                    row1.CreateCell(3).SetCellValue("处理时间");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 4, 4));
                    row1.CreateCell(4).SetCellValue("当事人姓名");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 5, 5));
                    row1.CreateCell(5).SetCellValue("案由名称");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 6, 6));
                    row1.CreateCell(6).SetCellValue("部门");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 7, 8));
                    row1.CreateCell(7).SetCellValue("办案人员");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 9, 9));
                    row1.CreateCell(9).SetCellValue("处罚金额");

                    row2.CreateCell(7).SetCellValue("办案人员");
                    row2.CreateCell(8).SetCellValue("办案人员");

                    //样式
                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        HSSFCellUtil.GetCell(row1, i).CellStyle = styleThinBorder;
                        HSSFCellUtil.GetCell(row2, i).CellStyle = styleThinBorder;
                    }
                    #endregion

                    DataTableToExcelCaseDetail(sheet, table, styleThinBorder, false, 3);

                    #region 设置列宽宽度 行高
                    for (int m = 0, n = sheet.LastRowNum; m <= n; m++)
                        sheet.GetRow(m).HeightInPoints = RowHeight;

                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        sheet.SetColumnWidth(i, 10 * 350);
                    }
                    #endregion
                    workbook.Write(stream);
                }
            }
            stream.Flush();
            stream.Position = 0;
            return stream;
        }
        /// <summary>
        /// 文件流下载
        /// 创建人：周庆
        /// 创建日期:2015年5月21日
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ms"></param>
        private void TurnFileStreamForDownload(string fileName, MemoryStream ms)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "GB2312";
            //中文文件名处理
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("Content-Length", ms.Length.ToString());
            Response.BinaryWrite(ms.ToArray());
            Response.Flush();
            Response.End();
            Response.Clear();
        }

        /// <summary>
        /// 创建年度汇总报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="table"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private MemoryStream CreateAnnualSummaryReport(DataTable table, int year)
        {
            var stream = new MemoryStream();
            //Excel工作本
            using (var workbook = new HSSFWorkbook())
            {
                const int rowHeight = 18; //行高
                //细边框
                var styleThinBorder = workbook.CreateCellStyle();
                styleThinBorder.Alignment = HorizontalAlignment.CENTER;
                styleThinBorder.VerticalAlignment = VerticalAlignment.CENTER;
                styleThinBorder.BorderTop = CellBorderType.THIN;
                styleThinBorder.BorderBottom = CellBorderType.THIN;
                styleThinBorder.BorderLeft = CellBorderType.THIN;
                styleThinBorder.BorderRight = CellBorderType.THIN;
                styleThinBorder.TopBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.BottomBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.LeftBorderColor = IndexedColors.BLACK.Index;
                styleThinBorder.RightBorderColor = IndexedColors.BLACK.Index;

                //无边框
                var styleNoBorder = workbook.CreateCellStyle();
                styleNoBorder.Alignment = HorizontalAlignment.CENTER;
                styleNoBorder.VerticalAlignment = VerticalAlignment.CENTER;
                //加粗16*16
                Font font2 = workbook.CreateFont();
                font2.FontHeight = 20 * 20;
                font2.Boldweight = short.MaxValue;
                styleNoBorder.SetFont(font2);

                using (Sheet sheet = workbook.CreateSheet())
                {
                    //设置标题
                    Row rowTitle = sheet.CreateRow(0);
                    rowTitle.HeightInPoints = 40;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, table.Columns.Count - 1));
                    rowTitle.CreateCell(0).SetCellValue(string.Format("姑苏区综合行政执法局{0}年度各中队汇总统计表", year));
                    for (int i = 0, j = table.Columns.Count; i < j; i++)
                    {
                        HSSFCellUtil.GetCell(rowTitle, i).CellStyle = styleNoBorder;
                    }

                    DataTableToExcel(sheet, table, styleThinBorder, true, 1);
                    MergedClomun(sheet, 0, 1);//合并单元格

                    #region 设置列宽宽度 行高
                    for (int m = 1, n = sheet.LastRowNum; m <= n; m++)
                        sheet.GetRow(m).HeightInPoints = rowHeight;

                    sheet.SetColumnWidth(0, 3700);
                    for (int i = 1, j = table.Columns.Count; i < j; i++)
                    {
                        sheet.SetColumnWidth(i, 2126);
                    }
                    #endregion

                    workbook.Write(stream);
                }
            }
            stream.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// 合并列
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columnIndex">需要合并的列</param>
        /// <param name="rowIndexBegin">开始合并的行</param>
        /// <param name="rowIndexEnd">最后合并的行（999）</param>
        private void MergedClomun(Sheet sheet, int columnIndex, int rowIndexBegin = 0, int rowIndexEnd = 999)
        {
            int beginIndex = 0;
            int endIndex = 0;
            string beginText = "";
            string endText = "";
            Row row = null;
            int LastRow = Math.Min(sheet.LastRowNum, rowIndexEnd);
            //LastRowNum 索引
            for (int i = rowIndexBegin, j = LastRow; i <= j; i++)
            {
                endIndex = i;
                row = sheet.GetRow(i);
                endText = row.GetCell(columnIndex).StringCellValue;
                if (i == 0)
                {
                    beginText = endText;
                    beginIndex = endIndex = 0;
                }
                if (!endText.Equals(beginText))
                {
                    //需要合并
                    if (endIndex - beginIndex > 1)
                        sheet.AddMergedRegion(new CellRangeAddress(beginIndex, endIndex - 1, columnIndex, columnIndex));
                    beginIndex = endIndex;
                    beginText = endText;
                }
                //如果是最后一行
                if ((i == j) && (endIndex - beginIndex > 0))
                {
                    sheet.AddMergedRegion(new CellRangeAddress(beginIndex, endIndex, columnIndex, columnIndex));
                }
            }
        }

        /// <summary>
        /// DataTable=>Excel
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="table"></param>
        /// <param name="style"></param>
        /// <param name="needColumnName">是否需要DataTable的表头</param>
        /// <param name="startRow">从第几行开始创建</param>
        private void DataTableToExcel(Sheet sheet, DataTable table, CellStyle style, bool needColumnName = true, int startRow = 0)
        {
            int ColmunCount = table.Columns.Count;
            Row excelRow = null;
            //数据行
            int i = startRow;
            if (needColumnName)
            {
                //标题头
                excelRow = sheet.CreateRow(i);
                for (int c = 0; c < ColmunCount; c++)
                {
                    excelRow.CreateCell(c).SetCellValue(table.Columns[c].ColumnName);
                    HSSFCellUtil.GetCell(excelRow, c).CellStyle = style;
                }
                i++;
            }

            foreach (DataRow dataRow in table.Rows)
            {
                excelRow = sheet.CreateRow(i);
                for (int j = 0; j < ColmunCount; j++)
                {
                    excelRow.CreateCell(j).SetCellValue(dataRow[j].ToString());
                    HSSFCellUtil.GetCell(excelRow, j).CellStyle = style;
                }
                i++;
            }

        }
        /// <summary>
        /// 案件明细
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="table"></param>
        /// <param name="style"></param>
        /// <param name="needColumnName"></param>
        /// <param name="startRow"></param>
        private void DataTableToExcelCaseDetail(Sheet sheet, DataTable table, CellStyle style, bool needColumnName = true, int startRow = 0)
        {
            int ColmunCount = table.Columns.Count;
            Row excelRow = null;
            //数据行
            int i = startRow;
            if (needColumnName)
            {
                //标题头
                excelRow = sheet.CreateRow(i);
                for (int c = 0; c < ColmunCount; c++)
                {
                    excelRow.CreateCell(c).SetCellValue(table.Columns[c].ColumnName);
                    HSSFCellUtil.GetCell(excelRow, c).CellStyle = style;
                }
                i++;
            }

            foreach (DataRow dataRow in table.Rows)
            {
                excelRow = sheet.CreateRow(i);
                for (int j = 0; j < ColmunCount; j++)
                {
                    if (j == 2 || j == 3)
                    {
                        excelRow.CreateCell(j).SetCellValue(dataRow[j].ToString() == "1900/1/1 0:00:00" ? "" : Convert.ToDateTime(dataRow[j].ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        excelRow.CreateCell(j).SetCellValue(dataRow[j].ToString() == "0" ? "" : dataRow[j].ToString());
                    }
                    HSSFCellUtil.GetCell(excelRow, j).CellStyle = style;
                }
                i++;
            }

        }


        /// <summary>
        /// 创建案件月报表
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="table">数据源</param>
        /// <param name="reportTitle">报表标题</param>
        /// <param name="title">当年/月份</param>
        /// <returns></returns>
        private MemoryStream CreateCaseMonthReport(DataTable table, string reportTitle, string title)
        {
            const int cellTotal = 81;       //单元格个数
            const int columnSpace8 = 10;    //跨度7*10+1*11
            const int columnSpace9 = 9;     //跨度9*9
            const int columnSpace10 = 8;    //跨度1*9+9*8
            const int columnSpace11 = 7;    //跨度9*7+2*9


            int ColumnWidth = 320;//单元格宽度
            int j = 0;
            MemoryStream stream = new MemoryStream();
            try
            {
                DataRow dataRow = table.Rows[0];
                //Excel工作本
                using (HSSFWorkbook workbook = new HSSFWorkbook())
                {
                    //加粗22*22
                    Font font1 = workbook.CreateFont();
                    font1.FontHeight = 20 * 20;
                    font1.Boldweight = short.MaxValue;
                    //加粗16*16
                    Font font2 = workbook.CreateFont();
                    font2.FontHeight = 16 * 16;
                    font2.Boldweight = short.MaxValue;

                    //无边框
                    CellStyle styleNoBorder = workbook.CreateCellStyle();
                    styleNoBorder.Alignment = HorizontalAlignment.CENTER;
                    styleNoBorder.VerticalAlignment = VerticalAlignment.CENTER;

                    //细边框
                    CellStyle styleThinBorder = workbook.CreateCellStyle();
                    styleThinBorder.Alignment = HorizontalAlignment.CENTER;
                    styleThinBorder.VerticalAlignment = VerticalAlignment.CENTER;
                    styleThinBorder.BorderTop = CellBorderType.THIN;
                    styleThinBorder.BorderBottom = CellBorderType.THIN;
                    styleThinBorder.BorderLeft = CellBorderType.THIN;
                    styleThinBorder.BorderRight = CellBorderType.THIN;
                    styleThinBorder.TopBorderColor = IndexedColors.BLACK.Index;
                    styleThinBorder.BottomBorderColor = IndexedColors.BLACK.Index;
                    styleThinBorder.LeftBorderColor = IndexedColors.BLACK.Index;
                    styleThinBorder.RightBorderColor = IndexedColors.BLACK.Index;

                    using (Sheet sheet = workbook.CreateSheet())
                    {
                        string[] values = null;
                        Row row = null;
                        int i = 0;

                        #region 标题
                        //大标题
                        //设置样式
                        CellStyle styleBigTitle = workbook.CreateCellStyle();
                        styleBigTitle.CloneStyleFrom(styleNoBorder);
                        styleBigTitle.SetFont(font1);
                        values = new string[] { reportTitle };
                        Row rowBigTitle = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleBigTitle);
                        rowBigTitle.HeightInPoints = 50;//行高
                        i++;


                        //副标题
                        //设置样式
                        CellStyle styleSecondTitle = workbook.CreateCellStyle();
                        styleSecondTitle.CloneStyleFrom(styleNoBorder);
                        styleSecondTitle.SetFont(font2);
                        values = new string[] { title + "各项执法数据统计表" };
                        Row rowSecondTitle = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleSecondTitle);
                        rowSecondTitle.HeightInPoints = 20;
                        i++;
                        #endregion

                        #region 现场纠处（起）
                        values = new string[] { "现场纠处（起）" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;

                        values = new string[] { "市容", "规划", "绿化", "工商", "市政", "水务", "公安", "环保", "小计" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        //todo: value
                        values = new string[] { 
                            dataRow["Ed_00090001"].ToString(),
                            dataRow["Ed_00090002"].ToString(),
                            dataRow["Ed_00090003"].ToString(),
                            dataRow["Ed_00090006"].ToString(),
                            dataRow["Ed_00090004"].ToString(),
                            dataRow["Ed_00090008"].ToString(),
                            dataRow["Ed_00090005"].ToString(),
                            dataRow["Ed_00090007"].ToString(),
                            dataRow["Ed_TotalCount"].ToString()};
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;

                        #endregion

                        #region 违章查处（起）
                        values = new string[] { "违章查处（起）" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;

                        values = new string[] { "市容", "规划", "绿化", "工商", "市政", "水务", "公安", "环保", "小计" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        //todo: value
                        values = new string[] {
                            dataRow["Case_00090001"].ToString(), 
                            dataRow["Case_00090002"].ToString(),
                            dataRow["Case_00090003"].ToString(),
                            dataRow["Case_00090006"].ToString(),
                            dataRow["Case_00090004"].ToString(), 
                            dataRow["Case_00090008"].ToString(), 
                            dataRow["Case_00090005"].ToString(),
                            dataRow["Case_00090007"].ToString(), 
                            dataRow["Case_TotalCount"].ToString() };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        #endregion

                        #region 结案数（起）/罚款金额（元）
                        values = new string[] { "结案数（起）/罚款金额（元）" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;

                        values = new string[] { "市容", "规划", "绿化", "工商", "市政", "水务", "公安", "环保", "小计" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace11, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        //todo：
                        //处理前9个
                        values = new string[] {
                            dataRow["Case_00090001"].ToString(), 
                            dataRow["Case_00090002"].ToString(),
                            dataRow["Case_00090003"].ToString(),
                            dataRow["Case_00090006"].ToString(),
                            dataRow["Case_00090004"].ToString(), 
                            dataRow["Case_00090008"].ToString(), 
                            dataRow["Case_00090005"].ToString(),
                            dataRow["Case_00090007"].ToString(), 
                            dataRow["Case_TotalCount"].ToString() };

                        Row row1 = sheet.CreateRow(i);
                        Row row2 = sheet.CreateRow(i + 1);
                        for (int p = 0; p < 9; p++)
                        {
                            //合并单元格
                            sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, p * columnSpace11, (p + 1) * columnSpace11 - 1));
                            row1.CreateCell(p * columnSpace11).SetCellValue(values[p]);
                            row2.CreateCell(p * columnSpace11).SetCellValue(values[p]);
                        }
                        row1.HeightInPoints = 15;
                        row2.HeightInPoints = 15;

                        //处理后面2个
                        //合并单元格
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace11 * 9, columnSpace11 * 9 + 8));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace11 * 9 + 9, cellTotal - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace11 * 9, columnSpace11 * 9 + 8));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace11 * 9 + 9, cellTotal - 1));

                        row1.CreateCell(columnSpace11 * 9).SetCellValue("一般");
                        row1.CreateCell(columnSpace11 * 9 + 9).SetCellValue(dataRow["Case_Punish"].ToString());
                        row2.CreateCell(columnSpace11 * 9).SetCellValue("简易");
                        row2.CreateCell(columnSpace11 * 9 + 9).SetCellValue(dataRow["Case_Simple"].ToString());

                        for (int m = 0; m < cellTotal; m++)//设置样式
                        {
                            HSSFCellUtil.GetCell(row1, m).CellStyle = styleThinBorder;
                            HSSFCellUtil.GetCell(row2, m).CellStyle = styleThinBorder;
                        }
                        i += 2;

                        values = new string[] {
                            dataRow["Case_00090001_Money"].ToString(), 
                            dataRow["Case_00090002_Money"].ToString(),
                            dataRow["Case_00090003_Money"].ToString(),
                            dataRow["Case_00090006_Money"].ToString(),
                            dataRow["Case_00090004_Money"].ToString(), 
                            dataRow["Case_00090008_Money"].ToString(), 
                            dataRow["Case_00090005_Money"].ToString(),
                            dataRow["Case_00090007_Money"].ToString(), 
                            dataRow["Case_TotalMoney"].ToString() };
                        row1 = sheet.CreateRow(i);
                        row2 = sheet.CreateRow(i + 1);
                        for (int p = 0; p < 9; p++)
                        {
                            //合并单元格
                            sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, p * columnSpace11, (p + 1) * columnSpace11 - 1));
                            row1.CreateCell(p * columnSpace11).SetCellValue(values[p]);
                            row2.CreateCell(p * columnSpace11).SetCellValue(values[p]);
                        }
                        row1.HeightInPoints = 15;
                        row2.HeightInPoints = 15;

                        //处理后面2个
                        //合并单元格
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace11 * 9, columnSpace11 * 9 + 8));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace11 * 9 + 9, cellTotal - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace11 * 9, columnSpace11 * 9 + 8));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace11 * 9 + 9, cellTotal - 1));

                        row1.CreateCell(columnSpace11 * 9).SetCellValue("一般");
                        row1.CreateCell(columnSpace11 * 9 + 9).SetCellValue(dataRow["Case_PunishMoney"].ToString());
                        row2.CreateCell(columnSpace11 * 9).SetCellValue("简易");
                        row2.CreateCell(columnSpace11 * 9 + 9).SetCellValue(dataRow["Case_SimpleMoney"].ToString());

                        for (int m = 0; m < cellTotal; m++)//设置样式
                        {
                            HSSFCellUtil.GetCell(row1, m).CellStyle = styleThinBorder;
                            HSSFCellUtil.GetCell(row2, m).CellStyle = styleThinBorder;
                        }
                        i += 2;


                        #endregion

                        #region 未结案（起）
                        values = new string[] { "未结案（起）" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;

                        values = new string[] { "市容", "规划", "绿化", "工商", "市政", "水务", "公安", "环保", "小计" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        //todo: value
                        values = new string[] { "", "", "", "", "", "", "", "", "" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace9, cellTotal, values, styleThinBorder);
                        row.HeightInPoints = 18;
                        i++;
                        #endregion

                        #region 一月份各项案件结案数与罚款金额所占当月总数的比例统计表
                        CellStyle stytleTitle = workbook.CreateCellStyle();
                        stytleTitle.CloneStyleFrom(styleThinBorder);
                        stytleTitle.SetFont(font2);
                        values = new string[] { title + "各项案件结案数与罚款金额所占当月总数的比例统计表" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, stytleTitle);
                        row.HeightInPoints = 18;
                        i++;

                        values = new string[] { "市容", "规划", "绿化", "工商", "市政", "水务", "公安", "环保", "小计" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace10, cellTotal - 9, values, styleThinBorder, 9);
                        row.HeightInPoints = 18;
                        //处理第一个
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, 0, 8));
                        row.CreateCell(0).SetCellValue("");
                        for (int m = 0; m < 9; m++)
                            HSSFCellUtil.GetCell(row, m).CellStyle = styleThinBorder;
                        i++;
                        //todo:
                        values = new string[] { 
                            dataRow["CaseCloseProportion_00090001"].ToString(),
                            dataRow["CaseCloseProportion_00090002"].ToString(),
                            dataRow["CaseCloseProportion_00090003"].ToString(),
                            dataRow["CaseCloseProportion_00090006"].ToString(),
                            dataRow["CaseCloseProportion_00090004"].ToString(),
                            dataRow["CaseCloseProportion_00090008"].ToString(),
                            dataRow["CaseCloseProportion_00090005"].ToString(),
                            dataRow["CaseCloseProportion_00090007"].ToString(), "100%" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace10, cellTotal - 9, values, styleThinBorder, 9);
                        row.HeightInPoints = 18;
                        //处理第一个
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, 0, 8));
                        row.CreateCell(0).SetCellValue("结案数比例");
                        for (int m = 0; m < 9; m++)
                            HSSFCellUtil.GetCell(row, m).CellStyle = styleThinBorder;
                        i++;
                        //todo:
                        values = new string[] { 
                            dataRow["PunishMoneyProportion_00090001"].ToString(),
                            dataRow["PunishMoneyProportion_00090002"].ToString(),
                            dataRow["PunishMoneyProportion_00090003"].ToString(),
                            dataRow["PunishMoneyProportion_00090006"].ToString(),
                            dataRow["PunishMoneyProportion_00090004"].ToString(),
                            dataRow["PunishMoneyProportion_00090008"].ToString(),
                            dataRow["PunishMoneyProportion_00090005"].ToString(),
                            dataRow["PunishMoneyProportion_00090007"].ToString(), 
                            "100%" };
                        row = CreateMergedRegionRow(sheet, i, 9, columnSpace10, cellTotal - 9, values, styleThinBorder, 9);
                        row.HeightInPoints = 18;
                        //处理第一个
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, 0, 8));
                        row.CreateCell(0).SetCellValue("罚款金额比例");
                        for (int m = 0; m < 9; m++)
                            HSSFCellUtil.GetCell(row, m).CellStyle = styleThinBorder;
                        i++;
                        #endregion

                        #region 一月份违章建筑、违章广告、先进事例及暴力抗法事件统计表
                        values = new string[] { title + "违章建筑、违章广告、先进事例及暴力抗法事件统计表" };
                        row = CreateMergedRegionRow(sheet, i, 1, cellTotal, cellTotal, values, stytleTitle);
                        row.HeightInPoints = 18;
                        i++;

                        //创建2行
                        row1 = sheet.CreateRow(i);
                        row1.HeightInPoints = 18;
                        row2 = sheet.CreateRow(i + 1);
                        row2.HeightInPoints = 18;
                        //合并4个
                        sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, 0, columnSpace8 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, columnSpace8 * 2, columnSpace8 * 3 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, columnSpace8 * 4, columnSpace8 * 5 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i + 1, columnSpace8 * 6, columnSpace8 * 7 - 1));
                        row1.CreateCell(0).SetCellValue("拆除违章建筑数");
                        row1.CreateCell(columnSpace8 * 2).SetCellValue("拆除户外广告");
                        row1.CreateCell(columnSpace8 * 4).SetCellValue("先进事例");
                        row1.CreateCell(columnSpace8 * 6).SetCellValue("暴力抗法事件");

                        //不合并的4个
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace8, columnSpace8 * 2 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace8, columnSpace8 * 2 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace8 * 3, columnSpace8 * 4 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace8 * 3, columnSpace8 * 4 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace8 * 5, columnSpace8 * 6 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace8 * 5, columnSpace8 * 6 - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i, i, columnSpace8 * 7, cellTotal - 1));
                        sheet.AddMergedRegion(new CellRangeAddress(i + 1, i + 1, columnSpace8 * 7, cellTotal - 1));
                        //todo:
                        row1.CreateCell(columnSpace8).SetCellValue(dataRow["DismantleBdCount"].ToString());
                        row1.CreateCell(columnSpace8 * 3).SetCellValue(dataRow["DismantleAdCount"].ToString());
                        row1.CreateCell(columnSpace8 * 5).SetCellValue("");
                        row1.CreateCell(columnSpace8 * 7).SetCellValue("");
                        row2.CreateCell(columnSpace8).SetCellValue(dataRow["DismantleBdArea"].ToString());
                        row2.CreateCell(columnSpace8 * 3).SetCellValue(dataRow["DismantleAdArea"].ToString());
                        row2.CreateCell(columnSpace8 * 5).SetCellValue("");
                        row2.CreateCell(columnSpace8 * 7).SetCellValue("");
                        //设置样式
                        for (int m = 0; m < cellTotal; m++)
                        {
                            HSSFCellUtil.GetCell(row1, m).CellStyle = styleThinBorder;
                            HSSFCellUtil.GetCell(row2, m).CellStyle = styleThinBorder;
                        }
                        #endregion

                        #region 设置列宽宽度
                        for (j = 0; j < cellTotal; j++)
                        {
                            sheet.SetColumnWidth(j, ColumnWidth);
                        }
                        #endregion

                        workbook.Write(stream);
                    }
                }
            }
            catch (Exception e)
            {
                UnicodeEncoding uniEncoding = new UnicodeEncoding();
                byte[] error = uniEncoding.GetBytes(e.Message);
                stream.Write(error, 0, error.Length);
            }
            stream.Flush();
            stream.Position = 0;
            return stream;
        }


        /// <summary>
        /// 创建一行
        /// 创建人：周庆
        /// 创建日期：2015年5月20日
        /// 关键字：列 单元格
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowIndex">行号Index</param>
        /// <param name="columCout">一共多少列</param>
        /// <param name="columnSpace">每列跨度（单元格）</param>
        /// <param name="cellTotal">总共多少单元格</param>
        /// <param name="columnValues">列名</param>
        /// <param name="style">样式</param>
        /// <param name="startIndex">起始单元格位置(偏移量)</param>
        /// <returns></returns>
        private Row CreateMergedRegionRow(Sheet sheet, int rowIndex, int columCout, int columnSpace, int cellTotal, string[] columnValues, CellStyle style, int startIndex = 0)
        {
            Row row = sheet.CreateRow(rowIndex);
            for (int i = 0; i < columCout; i++)
            {
                //合并单元格
                if (i < columCout - 1)
                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, startIndex + columnSpace * i, startIndex + columnSpace * (i + 1) - 1));
                else
                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, startIndex + columnSpace * i, startIndex + cellTotal - 1));
                //设置值
                row.CreateCell(startIndex + columnSpace * i).SetCellValue(columnValues[i]);
            }
            for (int j = startIndex, k = cellTotal + startIndex; j < k; j++)//设置样式
                HSSFCellUtil.GetCell(row, j).CellStyle = style;
            return row;
        }

        #endregion
    }
}
