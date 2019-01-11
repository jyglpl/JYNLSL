using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Membership;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.Data;
using System.Collections;
using NPOI.HSSF.Util;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.IllegalConstruction
{
    public class IllegalConstructionController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly IllegalConstructionBll _illegalConstructionBll = new IllegalConstructionBll();
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();      //审批意见
        //
        // GET: /IllegalConstruction/

        public ActionResult Index()
        {
            //违建状态
            var unbuiltState = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0074" }).ToList();
            unbuiltState.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["UnbuiltState"] = new SelectList(unbuiltState, "Id", "RsKey");


            //拆除类型
            var dismantlingType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0082" }).ToList();
            dismantlingType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["DismantlingType"] = new SelectList(dismantlingType, "Id", "RsKey");

            var controlColumn = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "IllegalConstruction", "ControlColumn");
            ViewBag.ControlColumn = controlColumn;//控制显示列
            return View();
        }

        /// <summary>
        /// 违建拆除
        /// </summary>
        /// <param name="id">办件ID</param>
        /// <param name="worklistId">待办事宜ID</param>
        /// <returns></returns>
        public ActionResult Entity(string id, string worklistId)
        {
            var user = CurrentUser.CrmUser;
            var entity = new IllegalConstructionEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _illegalConstructionBll.Get(id); //实体
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.ApplicationUserName = user.UserName;
                entity.ApplicationMobile = user.Mobile;
            }

            var state = entity.State;

            //按钮显示控制
            bool btnSave = false, btnApply = false, btnAgree = false, btnAppointCompany = false, btnCopyLeader = false, btnSaveMessage = false, btnSettlement = false;

            if (state == 0 || state == 10)
            {
                btnSave = true;
            }
            if (state == 20)
            {
                btnSaveMessage = true;
                btnSettlement = true;
            }

            if (!string.IsNullOrEmpty(worklistId))
            {
                var messageEntity = new CrmMessageWorkBll().Get(worklistId);

                //当前消息接收人是发启人
                if ((messageEntity != null && messageEntity.FormAddress.IndexOf("FE_End=true", System.StringComparison.Ordinal) > 0) || state == 20)
                {
                    messageEntity.State = 2;
                    new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                    worklistId = "";
                }
                messagelist.Add(messageEntity); //将消息增加到集合

                if (entity.State == 4)    //当状态为4时（执法处领导），显示“指派公司”按钮
                {
                    btnAppointCompany = true;
                }
            }
            else
            {
                worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            messagelist = messagelist.Where(x => x.ActionerID == CurrentUser.CrmUser.Id && x.State != 2 && x.FormAddress.IndexOf("FE_End=true") == -1).ToList();
            if (messagelist.Count > 0)
            {
                if (entity.State == 13)      //当审批状态为13时（执法处领导），隐藏“同意”按钮，显示“同意并抄送局领导”
                {
                    btnCopyLeader = true;
                    btnAgree = false;
                }
                else if ((state > 0 && state < 10) || (state > 10 && state < 20))
                {
                    //有未处理消息
                    btnAgree = true;
                }
            }
            else
            {
                if (entity.State == 0 || entity.State == 10) //只能由当前部门下面的人员进行申请
                    btnApply = true;
            }

            ViewBag.BtnApply = btnApply;
            ViewBag.BtnSave = btnSave;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnCopyLeader = btnCopyLeader;
            ViewBag.BtnAppointCompany = btnAppointCompany;
            ViewBag.WorkListId = worklistId;
            ViewBag.btnSaveMessage = btnSaveMessage;
            ViewBag.btnSettlement = btnSettlement;
            #region 默认值

            //申请类型
            var applicationType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0072" }).ToList();
            applicationType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ApplicationTypes"] = new SelectList(applicationType, "Id", "RsKey");

            //房屋结构
            var housStructure = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0075" }).ToList();
            housStructure.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["HousStructures"] = new SelectList(housStructure, "Id", "RsKey");

            //违建状态
            var unbuiltState = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0074" }).ToList();
            unbuiltState.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["UnbuiltStates"] = new SelectList(unbuiltState, "Id", "RsKey");

            //申请人证照类型
            var paperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            paperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(paperTypes, "Id", "RsKey");

            //拆除类型
            var dismantlingType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0082" }).ToList();
            dismantlingType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["DismantlingTypes"] = new SelectList(dismantlingType, "Id", "RsKey");


            //广告类型
            var advertisementType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0066" }).ToList();
            advertisementType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AdvertisementTypes"] = new SelectList(advertisementType, "Id", "RsKey");

            #endregion

            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "违法建设拆除申请", "", 1);

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "违法建设拆除申请", "reper");
            ViewData["ReportFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "违法建设拆除结果", "reper");


            //拆除公司
            ViewBag.DismantleCompany = !string.IsNullOrEmpty(entity.DismantleCompanyId)
                                           ? _comResourceBll.Get(entity.DismantleCompanyId).RsKey
                                           : "";

            return View(entity);
        }

        /// <summary>
        /// 指定拆除公司
        /// </summary>
        /// <returns></returns>
        public ActionResult AppointCompany(string id)
        {
            ViewBag.Illegal = id;
            return View();
        }


        /// <summary>
        /// 抄送局领导
        /// </summary>
        /// <returns></returns>
        public ActionResult CopyLeader(string id)
        {
            ViewBag.Illegal = id;
            return View();
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="companyId">所属部门</param>
        /// <param name="dismantlingType">拆除类型</param>
        /// <param name="unbuiltState">违建状态</param>
        /// <param name="unbuiltStartDate">违建日期（开始）</param>
        /// <param name="unbuiltEndDate">违建日期（截止）</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="rows">每页面请求条数</param>
        /// <param name="page">当前索引页</param>
        /// <param name="sidx">排序列</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public string QueryIllegalConstructionList(string caseStateType, string companyId, string dismantlingType, string unbuiltState, string unbuiltStartDate,
                                                   string unbuiltEndDate, string keyword, int rows, int page, string sidx, string sord)
        {
            var data = _illegalConstructionBll.QueryIllegalConstructionList(caseStateType, companyId, dismantlingType, unbuiltState, unbuiltStartDate,
                                                                            unbuiltEndDate, keyword, sidx, sord, rows,
                                                                            page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 获取结算统计数据
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="dismantleCompanyId"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <param name="drpCompany"></param>
        /// <returns></returns>
        public string GetIllegalConstructionStatisticList(int rows, int page, string sidx, string sord, string dismantleCompanyId, string sDate,string eDate, string drpCompany)
        {
            var data = _illegalConstructionBll.GetIllegalConstructionStatisticList(rows, page, sidx, sord, dismantleCompanyId, sDate, eDate, drpCompany);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 保存违法建设拆除
        /// </summary>
        /// <param name="mainEntity">实体</param>
        /// <param name="collection">表单</param>
        /// <returns></returns>
        public JsonResult AcceptClick(IllegalConstructionEntity mainEntity, FormCollection collection)
        {
            var isOk = false;
            var rtMsg = "保存成功";
            try
            {
                var user = CurrentUser.CrmUser;
                mainEntity.CreatorId = user.Id;
                mainEntity.CreateBy = user.UserName;
                mainEntity.CreateOn = DateTime.Now;
                mainEntity.UpdateId = user.Id;
                mainEntity.UpdateBy = user.UserName;
                mainEntity.UpdateOn = DateTime.Now;

                isOk = _illegalConstructionBll.SaveIllegalConstruction(mainEntity);
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存修改信息，不改变案件状态
        /// </summary>
        /// <param name="mainEntity">实体</param>
        /// <returns></returns>
        public JsonResult SaveMessage(IllegalConstructionEntity mainEntity)
        {
            var isOk = false;
            var rtMsg = "保存成功";
            try
            {
                var user = CurrentUser.CrmUser;

                var oldEntity = new IllegalConstructionBll().Get(mainEntity.Id);   //查询未修改的实体信息

                oldEntity.FloorSpace = mainEntity.FloorSpace;
                oldEntity.AreaOfStructure = mainEntity.AreaOfStructure;
                oldEntity.SettlementType = mainEntity.SettlementType;
                oldEntity.Manpower = mainEntity.Manpower;
                oldEntity.SecurityWindow = mainEntity.SecurityWindow;
                oldEntity.Factor = mainEntity.Factor;
                oldEntity.WholeReason = mainEntity.WholeReason;
                oldEntity.Wall = mainEntity.Wall;
                oldEntity.DismantlingDate = mainEntity.DismantlingDate;
                oldEntity.DismantleArea = mainEntity.DismantleArea;
                oldEntity.GarbageTon = mainEntity.GarbageTon;
                oldEntity.GarbageCar = mainEntity.GarbageCar;
                oldEntity.DismantleLetterOfPresentation = mainEntity.DismantleLetterOfPresentation;
                oldEntity.BrigadeSatisfaction = mainEntity.BrigadeSatisfaction;
                oldEntity.LeaderSatisfaction = mainEntity.LeaderSatisfaction;

                oldEntity.UpdateId = user.Id;
                oldEntity.UpdateBy = user.UserName;
                oldEntity.UpdateOn = DateTime.Now;
                oldEntity.RowStatus = 1;
                //计算实际拆除面积
                if (mainEntity.SettlementType == "00830003")
                {
                    oldEntity.DismantleArea = (decimal.Parse(string.IsNullOrEmpty(mainEntity.FloorSpace) ? "0" : mainEntity.FloorSpace) *
                                               decimal.Parse(string.IsNullOrEmpty(mainEntity.Factor) ? "0" : mainEntity.Factor)).ToString();
                }


                if (_illegalConstructionBll.Update(oldEntity) > 0)
                {
                    isOk = true;
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 已结算,改变案件状态
        /// </summary>
        /// <returns></returns>
        public JsonResult Settlement(IllegalConstructionEntity mainEntity)
        {
            var isOk = false;
            var rtMsg = "保存成功";
            try
            {
                var user = CurrentUser.CrmUser;
                var oldEntity = new IllegalConstructionBll().Get(mainEntity.Id);   //查询未修改的实体信息

                //案件状态 30为已结算
                oldEntity.State = 30;
                oldEntity.RowStatus = 1;
                oldEntity.UpdateId = user.Id;
                oldEntity.UpdateBy = user.UserName;
                oldEntity.UpdateOn = DateTime.Now;

                //结算单价
                oldEntity.WailOnPrice = AppConst.WailOnPrice;
                oldEntity.ManpowerOnPrice = AppConst.ManpowerOnPrice;
                oldEntity.DismantleOnPrice = AppConst.DismantleOnPrice;
                oldEntity.SecurityWindowOnPrice = AppConst.SecurityWindowOnPrice;
                oldEntity.GarbageCarOnPrice = AppConst.GarbageCarOnPrice;


                ////计算实际拆除面积
                //if (mainEntity.SettlementType == "00830003")
                //{
                //    mainEntity.DismantleArea = (decimal.Parse(string.IsNullOrEmpty(mainEntity.FloorSpace) ? "0" : mainEntity.FloorSpace) *
                //                               decimal.Parse(string.IsNullOrEmpty(mainEntity.Factor.ToString(CultureInfo.InvariantCulture)) ? "0" : mainEntity.Factor)).ToString();
                //}

                if (_illegalConstructionBll.Update(oldEntity) > 0)
                {
                    isOk = true;
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取拆除公司
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string GetDismantleCompanys()
        {
            try
            {
                var str = new StringBuilder();
                //拆除公司
                var companys = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0077" }).ToList();

                foreach (var entity in companys)
                {
                    //显示的图标
                    var icon = "user_green.png";
                    str.AppendFormat("<li class='{0} {1}'>", entity.Id, "");
                    str.AppendFormat("<a {0} id='{1}' title='{2}'><img src='/Content/Images/Icon16/{3}'>{4}</a><i></i>", "", entity.Id, "公司：" + entity.RsKey, icon, entity.RsKey);
                    str.Append("</li>");
                }

                return str.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 获取局领导
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string GetLeaders()
        {
            try
            {
                var str = new StringBuilder();
                //局领导
                var users = new CrmUserBll().GetDeptsUsers(new CrmUserEntity() { DepartmentId = AppConst.DirectorDeptId }).ToList();

                var deputyDirectorEntity = new CrmUserBll().Get(AppConfig.DeputyDirector);
                users.Add(deputyDirectorEntity);

                foreach (var entity in users)
                {
                    //显示的图标
                    var icon = "user_green.png";
                    str.AppendFormat("<li class='{0} {1}'>", entity.Id, "");
                    str.AppendFormat("<a {0} id='{1}' title='{2}'><img src='/Content/Images/Icon16/{3}'>{4}</a><i></i>", "", entity.Id, "局领导：" + entity.RealName, icon, entity.RealName);
                    str.Append("</li>");
                }

                return str.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// 保存指定拆除公司
        /// </summary>
        /// <param name="illegalId"></param>
        /// <param name="companys">使用逗号分隔</param>
        /// <returns></returns>
        public string DismantleCompanys(string illegalId, string companys)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _illegalConstructionBll.SaveDismantleCompany(illegalId, companys);
                rtMsrg = flag ? "操作成功" : "操作失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }

        /// <summary>
        /// 删除照片
        /// </summary>
        /// <param name="imgName">照片名称</param>
        /// <returns></returns>
        public JsonResult DeleteAttach(string imgName)
        {
            var state = new IllegalConstructionAttachBll().DeleteAttachByImgName(imgName);
            return Json(state, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <returns></returns>
        public string GetIllegalConstructionCount(string companyId, string dismantlingType, string unbuiltState, string unbuiltStartDate,
                                                   string unbuiltEndDate, string keyword)
        {
            var data = new IllegalConstructionBll().GetIllegalConstructionCount(companyId, dismantlingType, unbuiltState, unbuiltStartDate,
                                                   unbuiltEndDate, keyword);
            return CommonMethod.ToJson(data);
        }

        //片区统计视图
        public ActionResult IllegalConstructionStatistics()
        {
            return View();
        }

        /// <summary>
        /// 结算统计
        /// </summary>
        /// <returns></returns>
        public ActionResult SettlementCount()
        {
            //作业公司
            var DismantleCompany = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0077" }).ToList();
            DismantleCompany.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["DismantleCompany"] = new SelectList(DismantleCompany, "Id", "RsKey");
            return View();
        }


        //导出（未完成）
        public ActionResult Export(string DismantleCompanyId, string SetTime, string drpCompany, string footer)
        {
            try
            {
                var data = _illegalConstructionBll.Export(DismantleCompanyId, SetTime, drpCompany);
                MemoryStream stream = new MemoryStream();
                using (HSSFWorkbook workbook = new HSSFWorkbook())
                {
                    //int RowHeight = 18;//行高
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
                    using (Sheet sheet = workbook.CreateSheet("违建结算统计表"))
                    {

                        var titleRow = sheet.CreateRow(0);//标题行
                        titleRow.CreateCell(0).SetCellValue("违建结算统计表");
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 19));
                        titleRow.Height = 500;

                        var row2 = sheet.CreateRow(1);//第一行
                        row2.CreateCell(0).SetCellValue("作业时间");
                        row2.CreateCell(1).SetCellValue("作业公司");
                        row2.CreateCell(2).SetCellValue("片区");
                        row2.CreateCell(3).SetCellValue("结算方式");
                        row2.CreateCell(4).SetCellValue("占地面积(㎡)");
                        row2.CreateCell(5).SetCellValue("系数");
                        row2.CreateCell(6).SetCellValue("拆除面积(㎡)");
                        row2.CreateCell(7).SetCellValue("拆除价");
                        row2.CreateCell(8).SetCellValue("人工数");
                        row2.CreateCell(9).SetCellValue("人工价");
                        row2.CreateCell(10).SetCellValue("拆窗数");
                        row2.CreateCell(11).SetCellValue("拆窗价");
                        row2.CreateCell(12).SetCellValue("整体拆除价");
                        row2.CreateCell(13).SetCellValue("封墙面积(㎡)");
                        row2.CreateCell(14).SetCellValue("封墙价");
                        row2.CreateCell(15).SetCellValue("清运垃圾车数");
                        row2.CreateCell(16).SetCellValue("清运垃圾价");
                        row2.CreateCell(17).SetCellValue("其他说明");
                        row2.CreateCell(18).SetCellValue("其他价");
                        row2.CreateCell(19).SetCellValue("总价");

                        int index = 2;
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var rowItem = sheet.CreateRow(index++);
                            rowItem.CreateCell(0).SetCellValue(data.Rows[i]["LetterOfPresentationSetTime"].ToString());
                            rowItem.CreateCell(1).SetCellValue(data.Rows[i]["DismantleCompany"].ToString());
                            rowItem.CreateCell(2).SetCellValue(string.IsNullOrEmpty(data.Rows[i]["CompanyName"].ToString()) ? "" : data.Rows[i]["CompanyName"].ToString());
                            rowItem.CreateCell(3).SetCellValue(data.Rows[i]["SettlementType"].ToString());
                            rowItem.CreateCell(4).SetCellValue(data.Rows[i]["FloorSpace"].ToString());
                            rowItem.CreateCell(5).SetCellValue(data.Rows[i]["Factor"].ToString());
                            rowItem.CreateCell(6).SetCellValue(data.Rows[i]["DismantleArea"].ToString());
                            rowItem.CreateCell(7).SetCellValue(data.Rows[i]["DismantlePrice"].ToString());
                            rowItem.CreateCell(8).SetCellValue(data.Rows[i]["Manpower"].ToString());
                            rowItem.CreateCell(9).SetCellValue(data.Rows[i]["ManpowerPrice"].ToString());
                            rowItem.CreateCell(10).SetCellValue(data.Rows[i]["SecurityWindow"].ToString());
                            rowItem.CreateCell(11).SetCellValue(data.Rows[i]["SecurityWindowPrice"].ToString());
                            rowItem.CreateCell(12).SetCellValue(data.Rows[i]["WholeReason"].ToString());
                            rowItem.CreateCell(13).SetCellValue(data.Rows[i]["FqArea"].ToString());
                            rowItem.CreateCell(14).SetCellValue(data.Rows[i]["FqPrice"].ToString());
                            rowItem.CreateCell(15).SetCellValue(data.Rows[i]["GarbageCar"].ToString());
                            rowItem.CreateCell(16).SetCellValue(data.Rows[i]["GarbagePrice"].ToString());
                            rowItem.CreateCell(17).SetCellValue(data.Rows[i]["Other"].ToString());
                            rowItem.CreateCell(18).SetCellValue(data.Rows[i]["OtherPrice"].ToString());
                            rowItem.CreateCell(19).SetCellValue(data.Rows[i]["CountPrice"].ToString());
                        }
                        //单元格样式
                        CellStyle style = workbook.CreateCellStyle();
                        style.BorderBottom = CellBorderType.THIN;
                        style.BorderLeft = CellBorderType.THIN;
                        style.BorderRight = CellBorderType.THIN;
                        style.BorderTop = CellBorderType.THIN;
                        style.VerticalAlignment = VerticalAlignment.CENTER;//垂直居中
                        style.Alignment = HorizontalAlignment.CENTER;//水平居中

                        SetBorder(sheet, style);//设置边框
                        workbook.Write(stream);
                    }
                }
                stream.Flush();
                stream.Position = 0;
                return File(stream, "application/ms-excel", "违建片区统计表.xls");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取统计报表数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public string IllegalConstructionStatisticData(string startTime, string endTime)
        {
            var data = new IllegalConstructionBll().IllegalConstructionStatistics(startTime, endTime);
            return CommonMethod.ToJson(data);
        }

        /// <summary>
        /// 窗口统计导出
        /// </summary>
        /// <param name="startTime">申请开始时间</param>
        /// <param name="endTime">申请结束时间</param>
        /// <returns></returns>
        public ActionResult ExportIllegalConstructionStatistics(string startTime, string endTime)
        {
            var data = new IllegalConstructionBll().IllegalConstructionStatistics(startTime, endTime);
            MemoryStream stream = new MemoryStream();
            //Excel工作本
            using (HSSFWorkbook workbook = new HSSFWorkbook())
            {
                //int RowHeight = 18;//行高
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

                    var titleRow = sheet.CreateRow(0);//标题行
                    titleRow.CreateCell(0).SetCellValue("违建片区拆违公司统计表");
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 4));
                    titleRow.Height = 500;

                    var row2 = sheet.CreateRow(1);//第一行
                    row2.CreateCell(0).SetCellValue("片区名称");
                    row2.CreateCell(1).SetCellValue("卫明公司");
                    row2.CreateCell(2).SetCellValue("环秀物业公司");
                    row2.CreateCell(3).SetCellValue("苏州庙港");
                    row2.CreateCell(4).SetCellValue("江苏长建");

                    int index = 2;
                    foreach (DataRow row in data.Rows)
                    {
                        var rowItem = sheet.CreateRow(index++);
                        rowItem.CreateCell(0).SetCellValue(row["FULLNAME"].ToString());
                        rowItem.CreateCell(1).SetCellValue(row["COMPANY1"].ToString());
                        rowItem.CreateCell(2).SetCellValue(row["COMPANY2"].ToString());
                        rowItem.CreateCell(3).SetCellValue(row["COMPANY3"].ToString());
                        rowItem.CreateCell(4).SetCellValue(row["COMPANY4"].ToString());
                    }
                    //单元格样式
                    CellStyle style = workbook.CreateCellStyle();
                    style.BorderBottom = CellBorderType.THIN;
                    style.BorderLeft = CellBorderType.THIN;
                    style.BorderRight = CellBorderType.THIN;
                    style.BorderTop = CellBorderType.THIN;
                    style.VerticalAlignment = VerticalAlignment.CENTER;//垂直居中
                    style.Alignment = HorizontalAlignment.CENTER;//水平居中

                    SetBorder(sheet, style);//设置边框
                    workbook.Write(stream);
                }
                stream.Flush();
                stream.Position = 0;
                return File(stream, "application/vnd.ms-excel", "违建片区拆违公司统计表.xls");
            }


        }

        //设置单元格线
        private void SetBorder(Sheet shet, CellStyle style)
        {
            for (var i = shet.FirstRowNum; i <= shet.LastRowNum; i++)
            {
                var row = shet.GetRow(i);
                for (var z = row.FirstCellNum; z <= row.LastCellNum; z++)
                {
                    if (row.GetCell(z) != null)
                    {
                        row.GetCell(z).CellStyle = style;
                    }
                }
            }
        }

       

    }
}
