using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers.Com;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Hr;


namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    /// <summary>
    /// 人事工资管理
    /// </summary>
    public class WageController : BaseController
    {
        private readonly EmployeeWageBll _bll = new EmployeeWageBll();
        private SystemLogController _log = new SystemLogController();
        private readonly BaseDepartmentBll _baseDepartmentBll = new BaseDepartmentBll();
        private readonly BaseUserBll _baseUserBll = new BaseUserBll();
        //
        // GET: /Wage/

        public ActionResult Index(string moduleName)
        {   
           
            try
            {
                var result = View();
                return result;
            }
            catch(Exception ex) {
                return null;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public ActionResult UpLoad(string id)
        {
            try
            {
                BindDate();
                ViewBag.sendWageTime = DateTime.Now.ToString("yyy-MM-dd");
                var result = View();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //绑定Grid视图
        public string GridJson(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart, string wageTimeEnd, int rows, int page)
        {
            try
            {
                var data=new  Model.PageJqDatagrid<EmployeeWageDetailEntity>();
                if (ActionAuthorization.IsAllowed(HttpContext, "Wage", "WageSearchDept"))             
                    data = _bll.GetCommonQuryGetCommonQury(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd, CurrentUser.CrmUser.Id,1, rows, page);
                else if (ActionAuthorization.IsAllowed(HttpContext, "Wage", "WageSearchAllDept"))
                    data = _bll.GetCommonQuryGetCommonQury(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd, CurrentUser.CrmUser.Id,2, rows, page);
                else
                    data = _bll.GetCommonQuryGetCommonQury(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd, CurrentUser.CrmUser.Id,0, rows, page);
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
                return JsonConvert.SerializeObject(data, timeConverter);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 导入文件数据显示
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string ImportGridJson(string filePath, string fileName, int rows, int page)
        {
            try
            {
                var path = AppConfig.FileSaveAddr + filePath;
                var data = _bll.ImprotData(ImprotExcel(path, fileName), rows, page);
                var result = JsonConvert.SerializeObject(data);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// EXCEL数据存数据库
        /// </summary>
        /// <param name="sendWageTime"></param>
        /// <param name="wageTime"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)] 
        public JsonResult ImportData(string sendWageTime, string wageTime)
        {
            var isOk = false;
            List<string> lstName = new List<string>();
            try
            {
                DataTable tb = Session["Table"] as DataTable;
                Session["Table"] = null;             
                if (tb != null)
                {
                    isOk = _bll.ImportWage(tb, sendWageTime, wageTime, ref lstName);   
                }
            }
            catch (Exception ex)
            {
                isOk=false;
            }
            var result = new StatusModel<string>
            {
                rtState = isOk ? 1 : -1,
                rtData = lstName,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }

        /// <summary>
        /// 删除工资信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteWage(string id)
        {
            try
            {
                var result = _bll.DeleteWage(id);
                return result.ToString();
            }
            catch (Exception ex)
            {
                return false.ToString();
            }
        }


        /// <summary>
        /// 导出Excel数据
        /// </summary>
        /// <returns></returns>
        public bool ExportExcel(string person, string sendWageTimeStart, string sendWageTimeEnd, string wageTimeStart, string wageTimeEnd, string fileName)
        {
            try
            {
                HttpContextBase context = this.HttpContext;
                DataTable dt = _bll.ExportExcel(person, sendWageTimeStart, sendWageTimeEnd, wageTimeStart, wageTimeEnd);
                if (dt == null || dt.Rows.Count == 0) return false;
                string url = AppConfig.FileSaveAddr + @"\DownLoad\" + fileName + ".xls";
                CommonMethod.SaveToFile(RenderToExcel(dt), url);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="fileName"></param>
        private void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="context"></param>
        /// <param name="fileName"></param>
        private void RenderToBrowser(MemoryStream ms, HttpContextBase context, string fileName)
        {
            if (context.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());

        }


        /// <summary>
        /// 读取流到EXCLE
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private MemoryStream RenderToExcel(DataTable table)
        {
            WageExcelColumName col = new WageExcelColumName();
            MemoryStream ms = new MemoryStream();
            using (table)
            {
                using (HSSFWorkbook workbook = new HSSFWorkbook())
                {
                    using (Sheet sheet = workbook.CreateSheet())
                    {

                        //设置单元格式-居中
                        var stylecenter = workbook.CreateCellStyle();
                        stylecenter.Alignment = HorizontalAlignment.CENTER;
                        stylecenter.VerticalAlignment = VerticalAlignment.CENTER;
                        stylecenter.BorderTop = CellBorderType.THIN;
                        stylecenter.BorderBottom = CellBorderType.THIN;
                        stylecenter.BorderLeft = CellBorderType.THIN;
                        stylecenter.BorderRight = CellBorderType.THIN;
                        stylecenter.TopBorderColor = IndexedColors.BLACK.Index;
                        stylecenter.BottomBorderColor = IndexedColors.BLACK.Index;
                        stylecenter.LeftBorderColor = IndexedColors.BLACK.Index;
                        stylecenter.RightBorderColor = IndexedColors.BLACK.Index;

                        Row headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 20;
                        // handling header.

                        foreach (DataColumn column in table.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(col.GetName(column.Caption));
                            //If Caption not set, returns the ColumnName value
                        }
                        int rowIndex = 1;
                        foreach (DataRow row in table.Rows)
                        {
                            Row dataRow = sheet.CreateRow(rowIndex);
                            foreach (DataColumn column in table.Columns)
                            {
                                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                                dataRow.HeightInPoints = 20;
                            }
                            rowIndex++;
                        }
                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }

        /// <summary>
        /// 导入数据到Table
        /// </summary>
        /// <returns></returns>
        private DataTable ImprotExcel(string filePath, string fileName)
        {
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
            var workbook = new HSSFWorkbook(file);
            var lst = new List<string>();

            //获取excel的第一个sheet
            Sheet sheet = null;
            if (string.IsNullOrEmpty(fileName))
            {
                sheet = workbook.GetSheetAt(0);
                lst.Add("0");
            }
            else
            {
                lst = fileName.Split(new char[] { ';' }).ToList<string>();
            }

            var table = new DataTable();
            for (int k = 0; k < lst.Count; k++)
            {
                sheet = lst[0].Contains("0") ? workbook.GetSheetAt(0) : workbook.GetSheet(lst[k]);
                //获取sheet的首行
                var headerRow = sheet.GetRow(0);

                //一行最后一个方格的编号 即总的列数
                var cellCount = headerRow.LastCellNum;
                if (k == 0)
                {
                    var wageDetail = new WageExcelColumName();

                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        if (headerRow.GetCell(i) != null)
                        {
                            var column = new DataColumn(wageDetail.GetColName(headerRow.GetCell(i).StringCellValue));
                            table.Columns.Add(column);
                        }
                    }
                }
                //最后一列的标号  即总的行数
                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum+1; i++)
                {
                    Row row = sheet.GetRow(i);
                    if (row == null)//这一句很关键，因为没有数据的行默认是null
                    {
                        continue;
                    }

                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < table.Columns.Count; j++)
                    {
                        if (row.GetCell(j) != null && j == row.FirstCellNum)//同理，没有数据的单元格都默认是null
                            dataRow[j] = row.GetCell(j).ToString();
                        else
                            dataRow[j] = double.Parse((row.GetCell(j) == null || row.GetCell(j).ToString()==string.Empty)? "0" : row.GetCell(j).ToString().Replace("_",""));
                    }

                    table.Rows.Add(dataRow);
                }
            }
            workbook = null;
            sheet = null;
            if (Session["Table"] == null)
                Session["Table"] = table;
            return table;
        }

        #region 绑定时间

        public void BindDate()
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

            ViewData["Months"] = new SelectList(monthList, DateTime.Now.Month);
            if (DateTime.Now.Year == 12)   //如果当前月份为12月份,则年份则默认为下一年的时间
            {
                ViewData["Years"] = new SelectList(yearList, DateTime.Now.AddYears(1).Year);
            }
            else
            {
                ViewData["Years"] = new SelectList(yearList, DateTime.Now.Year);
            }
        }
        #endregion
    }
}
