using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Text;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel.Contrib;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class LeaveController : BaseController
    {
        private readonly BaseDepartmentBll _departmentBll = new BaseDepartmentBll();
        private readonly BaseUserBll _crmUserBll = new BaseUserBll();
        private readonly AttendanceLeaveBll _attendanceLeaveBll = new AttendanceLeaveBll();
        private readonly ComAttachmentBll _comAttachmentBll = new ComAttachmentBll();
        private readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();

        //
        // GET: /Leave/

        #region 视图

        /// <summary>
        /// 请假管理
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 请假登记
        /// 添加人：周庆
        /// 添加日期：2015年4月22日
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Apply()
        {
            var deptId = CurrentUser.CrmUser.DeptId;
            //执法大队下所有部门
            var depts = _departmentBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity() { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", deptId);

            //人员
            var lstUser = new List<BaseUserEntity> { new BaseUserEntity() { Id = "", UserName = "==请选择==" } };
            ViewData["Users"] = new SelectList(lstUser, "Id", "UserName", "");

            //请假类型
            var leaveType = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0006" });
            leaveType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["LeaveType"] = new SelectList(leaveType, "Id", "RsKey", "");
            var model = new AttendanceLeaveEntity
                {
                    BeginTime = DateTime.Today.AddHours(8),
                    EndTime = DateTime.Today.AddHours(17),
                    LeaveTime = 1,
                    Id = Guid.NewGuid().ToString()
                };
            return View(model);
        }

        /// <summary>
        /// 请假详情
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <param name="id">请假表单ID</param>
        /// <param name="worklistid">待办事宜ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Detail(string id, string worklistid)
        {
            var entity = new AttendanceLeaveEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _attendanceLeaveBll.Get(id);
                messagelist = new CrmMessageWorkBll().GetSearchResult(new CrmMessageWorkEntity() { FormID = id, State = 2 });

                if (!string.IsNullOrEmpty(worklistid))
                {
                    var messDt = new CrmMessageWorkBll().GetUnHandleMessage(CurrentUser.CrmUser.Id, id);
                    if (messDt != null && messDt.Rows.Count > 0)
                    {
                        worklistid = messDt.Rows[0]["Id"].ToString();
                    }
                }
            }
            if (!string.IsNullOrEmpty(worklistid))
            {
                var messageEntity = new CrmMessageWorkBll().Get(worklistid);

                //当前消息接收人是发启人
                if (messageEntity != null && messageEntity.FormAddress.IndexOf("FE_End=true") > 0)
                {
                    messageEntity.State = 2;
                    new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                }
                messagelist.Add(messageEntity); //将消息增加到集合
                if (!string.IsNullOrEmpty(messageEntity.FormID))
                {
                    entity = new AttendanceLeaveBll().Get(messageEntity.FormID); //请假登记实体
                }
            }
            else
            {
                worklistid = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            var showExamineBtn = false;  //是否显示审批按钮
            var showApplyBtn = false;    //是否显示申请按钮
            var showCancelBtn = false;   //是否显示作废按钮
            var showPrintBtn = false;    //是否显示打印按钮

            messagelist = messagelist.Where(x => x.ActionerID == CurrentUser.CrmUser.Id && x.State != 2 && x.FormAddress.IndexOf("FE_End=true") == -1).ToList();
            if (messagelist.Count > 0)   //有未处理消息
                showExamineBtn = true;
            else
            {
                if (CurrentUser.CrmUser.DeptId == entity.DeptId && entity.Status == 0)  //只能由当前部门下面的人员进行申请
                    showApplyBtn = true;
            }

            switch (entity.Status)
            {
                case -2:
                    ViewBag.Status = "已作废";
                    break;
                case -1:
                    ViewBag.Status = "审批不通过";
                    break;
                case 0:
                    ViewBag.Status = "已登记";
                    break;
                default:
                    if (entity.Status > 0 && entity.Status < 10)
                    {
                        ViewBag.Status = "审批中";
                        showCancelBtn = true; //只有审批中的或者审批通过的才能作废
                    }
                    else if (entity.Status == 10)
                    {
                        ViewBag.Status = "审批通过";
                        showCancelBtn = true; //只有审批中的或者审批通过的才能作废
                        showPrintBtn = true;  //审批通过后显示打印按钮 
                    }
                    break;
            }

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdeaForHr(id, "请假审批");
            ViewBag.ShowApplyBtn = showApplyBtn;
            ViewBag.ShowExaminBtn = showExamineBtn;
            ViewBag.ShowCancelBtn = showCancelBtn;
            ViewBag.ShowPrintBtn = showPrintBtn;
            ViewBag.WorkListId = string.IsNullOrEmpty(worklistid) ? "" : worklistid;

            //附件
            var files = _comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = id });
            ViewData["Files"] = files;
            return View(entity);
        }

        /// <summary>
        /// 审批意见
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApprovalOpinion()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sumary()
        {
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);
            return View();
        }

        #endregion

        #region Ajax数据请求

        /// <summary>
        /// 获取部门下人员
        /// 添加人：周庆
        /// 添加日期：2015年4月22日
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        public JsonResult GetDeptUsers(string DeptId)
        {
            if (!string.IsNullOrEmpty(DeptId))
            {
                var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = DeptId }).ToList();
                users.Insert(0, new BaseUserEntity() { Id = "", UserName = "==请选择==" });
                return Json(users.Select(m => new { m.Id, m.UserName }));
            }
            return Json(null);
        }

        /// <summary>
        /// 获取请假数据
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <returns></returns>
        public string GetApplyData(string companyId, string deptId, string startTime, string endTime, string keyWords, int rows = 30, int page = 1)
        {
            keyWords = HttpUtility.UrlDecode(keyWords);
            var data = _attendanceLeaveBll.GetAllAttendanceLeave(companyId, deptId, startTime, endTime, keyWords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 获取请假汇总数据
        /// 添加人：周庆
        /// 添加日期：2015年4月30日
        /// </summary>
        /// <returns></returns>
        public string GetSumaryApplyData(string companyId, string deptId, string startTime, string endTime, string keyWords, int rows = 30, int page = 1)
        {
            keyWords = HttpUtility.UrlDecode(keyWords);
            var data = _attendanceLeaveBll.GetAllSumaryAttendanceLeave(companyId, deptId, startTime, endTime, keyWords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        #endregion

        #region Ajax数据提交

        /// <summary>
        /// 保存请假
        /// 创建人：周庆
        /// 创建日期：2015年4月22日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateApply(AttendanceLeaveEntity entity)
        {
            var result = new StatusModel<AttendanceLeaveEntity>
            {
                rtState = 1,
                rtData = null,
                rtObj = null,
                rtMsrg = string.Empty
            };      
            try
            {
                if ((entity.LeaveType.Equals("00060010") && _attendanceLeaveBll.GetCompTime(entity.UserId).HasTime < entity.LeaveTime*8.0f))
                {
                    result.rtMsrg = "您当前没有加班时间可以排休！";
                    result.rtState = -1;
                    return Json(result);
                }
                var user = CurrentUser.CrmUser;
                //判断是否存在
                var one = _attendanceLeaveBll.Get(entity.Id);
                entity.RowStatus = 1;
                if (one == null)
                {
                    entity.CreatorId = user.Id;
                    entity.CreateBy = user.UserName;
                    entity.CreateOn = DateTime.Now;
                }
                else
                {
                    entity.UpdateId = user.Id;
                    entity.UpdateBy = user.UserName;
                    entity.UpdateOn = DateTime.Now;
                }
                result.rtState = _attendanceLeaveBll.TransactionSaveLeave(entity)?1:-1;
            }
            catch (Exception)
            {
                result.rtMsrg = "保存过程中出现异常，请联系管理员！";
                result.rtState = -1;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除请假
        /// 创建人：周庆
        /// 创建日期：2015年4月22日
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <returns></returns>
        public JsonResult DeleteApply(string ApplyId)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                AttendanceLeaveEntity one = _attendanceLeaveBll.Get(ApplyId);
                if (one != null)
                {
                    one.RowStatus = 0;//执行假删
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = _attendanceLeaveBll.Update(one);
                    //删除附件（如果有的话）
                    res += _comAttachmentBll.DeleteAttachementByResourceId(ApplyId);
                    isOk = res > 0;

                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<AttendanceLeaveEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }

        /// <summary>
        /// 作废请假（只有审批中或审批通过的才能作废）
        /// 创建人：周庆
        /// 创建日期：2015年4月30日
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <returns></returns>
        public JsonResult CancelApply(string ApplyId)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                AttendanceLeaveEntity one = _attendanceLeaveBll.Get(ApplyId);
                if (one != null && one.Status > 0 && one.Status <= 10)
                {
                    isOk = _attendanceLeaveBll.UpdateState(ApplyId, -2);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<AttendanceLeaveEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }

        /// <summary>
        /// 添加附件
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddAttachmentOfApply(ComAttachmentEntity entity)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //如果多次提交执行覆盖
                var lstAttachment = _comAttachmentBll.Query(QueryCondition.Instance.AddEqual(ComAttachmentEntity.Parm_ComAttachment_ResourceId, entity.ResourceId).AddEqual(ComAttachmentEntity.Parm_ComAttachment_RowStatus, "1"));
                if (lstAttachment != null && lstAttachment.Count > 0)
                {
                    ComAttachmentEntity one = lstAttachment[0];
                    UpdateModel(one);
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = _comAttachmentBll.Update(one);
                    isOk = res > 0;
                }
                else
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = 1;
                    entity.CreatorId = user.Id;
                    entity.CreateBy = user.UserName;
                    entity.CreateOn = DateTime.Now;

                    entity.UpdateId = user.Id;
                    entity.UpdateBy = user.UserName;
                    entity.UpdateOn = DateTime.Now;
                    _comAttachmentBll.Add(entity);
                    isOk = true;
                }

            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<AttendanceLeaveEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);

        }


        #endregion

        #region 导出Excel

        /// <summary>
        /// 导出请假汇总统计表
        /// </summary>
        /// <param name="companyId">请求单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        public void ExportSumary(string companyId, string deptId, string startTime, string endTime, string keyWords, int rows = 30, int page = 1)
        {
            const string fileName = "请假汇总统计表.xls";
            keyWords = HttpUtility.UrlDecode(keyWords);
            var data = _attendanceLeaveBll.GetAllSumaryAttendanceLeave(companyId, deptId, startTime, endTime, keyWords, rows, page);
            if (data != null)
            {

            }
            string title = "";
            MemoryStream ms = CreateCaseDetailsReport(data, title);
            TurnFileStreamForDownload(fileName, ms);
        }
        #endregion

        private MemoryStream CreateCaseDetailsReport(PageJqDatagrid<DataTable> table, string title)
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
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));
                    rowTitle.CreateCell(0).SetCellValue(string.Format("{0}请假汇总表", title));
                    for (int i = 0; i < 6; i++)
                        HSSFCellUtil.GetCell(rowTitle, i).CellStyle = styleNoBorder;

                    #region 表头
                    //创建2行
                    Row row1 = sheet.CreateRow(1);
                    Row row2 = sheet.CreateRow(2);
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 0, 0));
                    row1.CreateCell(0).SetCellValue("部门");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 1, 1));
                    row1.CreateCell(1).SetCellValue("请假人");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 2, 2));
                    row1.CreateCell(2).SetCellValue("类型");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 3, 3));
                    row1.CreateCell(3).SetCellValue("开始时间");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 4, 4));
                    row1.CreateCell(4).SetCellValue("截止时间");
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, 5, 5));
                    row1.CreateCell(5).SetCellValue("请假天数");


                    //样式
                    for (int i = 0, j = ((System.Data.DataTable)(table.rows)).Columns.Count; i < j; i++)
                    {
                        HSSFCellUtil.GetCell(row1, i).CellStyle = styleThinBorder;
                        HSSFCellUtil.GetCell(row2, i).CellStyle = styleThinBorder;
                    }
                    #endregion

                    DataTableToExcelSumary(sheet, (System.Data.DataTable)(table.rows), styleThinBorder, false, 3);

                    #region 设置列宽宽度 行高
                    for (int m = 0, n = sheet.LastRowNum; m <= n; m++)
                        sheet.GetRow(m).HeightInPoints = RowHeight;

                    for (int i = 0, j = ((System.Data.DataTable)(table.rows)).Columns.Count; i < j; i++)
                    {
                        sheet.SetColumnWidth(i, 10 * 400);
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
        /// DataTable=>Excel
        /// 创建人：周庆
        /// 创建日期：2015年5月21日
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="table"></param>
        /// <param name="style"></param>
        /// <param name="needColumnName">是否需要DataTable的表头</param>
        /// <param name="startRow">从第几行开始创建</param>
        private void DataTableToExcelSumary(Sheet sheet, DataTable table, CellStyle style, bool needColumnName = true, int startRow = 0)
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
                excelRow.CreateCell(0).SetCellValue(dataRow["DeptName"].ToString());
                HSSFCellUtil.GetCell(excelRow, 0).CellStyle = style;
                excelRow.CreateCell(1).SetCellValue(dataRow["UserName"].ToString());
                HSSFCellUtil.GetCell(excelRow, 1).CellStyle = style;
                excelRow.CreateCell(2).SetCellValue(dataRow["LeaveTypeName"].ToString());
                HSSFCellUtil.GetCell(excelRow, 2).CellStyle = style;
                excelRow.CreateCell(3).SetCellValue(Convert.ToDateTime(dataRow["BeginTime"]).ToString("yyyy-MM-dd HH:mm"));
                HSSFCellUtil.GetCell(excelRow, 3).CellStyle = style;
                excelRow.CreateCell(4).SetCellValue(Convert.ToDateTime(dataRow["EndTime"]).ToString("yyyy-MM-dd HH:mm"));
                HSSFCellUtil.GetCell(excelRow, 4).CellStyle = style;
                excelRow.CreateCell(5).SetCellValue(dataRow["LeaveTime"].ToString());
                HSSFCellUtil.GetCell(excelRow, 5).CellStyle = style;
                //for (int j = 0; j < ColmunCount; j++)
                //{
                //    excelRow.CreateCell(0).SetCellValue(dataRow[0].ToString());
                //    HSSFCellUtil.GetCell(excelRow, j).CellStyle = style;
                //}
                i++;
            }

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
        /// 获取补休假的一些时间信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLeaveTimeInfor(string userId)
        {
            return Json(new AttendanceLeaveBll().GetCompTime(userId), JsonRequestBehavior.AllowGet);
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
    }
}
