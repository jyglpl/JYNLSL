using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using System.Data;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Membership;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class IllegalConstructionController : BaseController
    {
        //
        // GET: /ZFYWCL/IllegalConstruction/
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        readonly IllegalCaseInfoBll _illegalCaseInfoBll = new IllegalCaseInfoBll(); //违法案件
        readonly IllegalCaseVerifyBll _illegalCaseVerifyBll = new IllegalCaseVerifyBll();//核实认定
        readonly IllegalCaseRemoveBll _illegalCaseRemoveBll = new IllegalCaseRemoveBll();//违法拆除
        readonly CrmCompanyBll _crmCompanyBll = new CrmCompanyBll();//机构信息
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();      //审批意见
        readonly CrmDepartmentBll _crmDepartmentBll = new CrmDepartmentBll(); //部门
        readonly ComHolidaysBll _comHolidaysBll = new ComHolidaysBll();//节假日
        /// <summary>
        /// 综合查询首页
        /// </summary>
        /// <returns></returns>
        public ActionResult IllegalIndex()
        {
            //问题来源
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0010", "");
            comResourceEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Source"] = new SelectList(comResourceEntity, "Id", "RSKEY", "");
            return View();
        }

        /// <summary>
        /// 删除案件
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public JsonResult DeleteIllegalCase(string Id)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    isOk = _illegalCaseInfoBll.DeleteIllegalCaseInfo(Id);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取违法案件
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string GetIllegalCase(string companyId, string deptId, string source, string keyword, int rows, int page, string sidx, string sord)
        {
            string UserId = "";
            if (!CurrentUser.CrmUser.LoginName.Equals("admin"))
            {
                UserId = CurrentUser.CrmUser.Id;
            }
            if (companyId == "all") { companyId = ""; }
            if (deptId == "all") { deptId = ""; }
            var data = _illegalCaseInfoBll.QueryIllegalCaseList(companyId, deptId, source, keyword, UserId, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var dtSourse = data.rows as DataTable;
            DateTime nowDate = DateTime.Now;
            foreach (DataRow item in dtSourse.Rows)
            {
                if (Convert.ToInt32(item["CASE_STATUS"]) == 0)
                {
                    item["CASE_STATUS"] = "受理登记";
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) > 0 && Convert.ToInt32(item["CASE_STATUS"]) <= 10)
                {
                    item["CASE_STATUS"] = "核实认定";
                    var varityDate = _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity() { CASE_INFO_NO = item["ID"].ToString() });
                    if (varityDate.Any())
                    {
                        DateTime varity = Convert.ToDateTime(varityDate[0].VERIFYTIME);//核实认定时间
                        DateTime varityEnd = Convert.ToDateTime(varityDate[0].VERIFYTENDIME);//核实认定时间
                        TimeSpan ts = varityEnd - nowDate;
                        int days = ts.Days;
                        if (days > 1)
                        {
                            item["OTHER_REMARK"] = 0;
                        }
                        if (days == 1 || days == 0)
                        {
                            item["OTHER_REMARK"] = 1;
                        }
                        if (days < 0)
                        {
                            item["OTHER_REMARK"] = 2;
                        }
                    }
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) > 10 && Convert.ToInt32(item["CASE_STATUS"]) <= 20)
                {
                    item["CASE_STATUS"] = "规划认定";
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) > 20 && Convert.ToInt32(item["CASE_STATUS"]) < 50 && Convert.ToInt32(item["ISPUNISH"]) == 1)
                {
                    if (Convert.ToInt32(item["CASE_STATUS"]) == 21)
                    {
                        item["CASE_STATUS"] = "立案审批";
                        DateTime plan = Convert.ToDateTime(item["PLAN_CUTOFF_DATE"]);//规划认定时间
                        DateTime planEnd = Convert.ToDateTime(item["PLAN_END_DATE"]);//规划认定截至时间
                        TimeSpan ts = nowDate - planEnd;
                        int days = ts.Days;
                        if (days > 1)
                        {
                            item["OTHER_REMARK"] = 0;
                        }
                        if (days == 1 || days == 0)
                        {
                            item["OTHER_REMARK"] = 1;
                        }
                        if (days < 0)
                        {
                            item["OTHER_REMARK"] = 2;
                        }
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 22)
                    {
                        item["CASE_STATUS"] = "旁证笔录";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 23)
                    {
                        item["CASE_STATUS"] = "测绘";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 24)
                    {
                        item["CASE_STATUS"] = "集体讨论";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 25)
                    {
                        item["CASE_STATUS"] = "法制审核";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 26)
                    {
                        item["CASE_STATUS"] = "处理审批";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 27)
                    {
                        item["CASE_STATUS"] = "行政处罚告知";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 28)
                    {
                        item["CASE_STATUS"] = "行政处罚决定";
                        if (!string.IsNullOrEmpty(item["LASPDATE"].ToString()) && !string.IsNullOrEmpty(item["CFJDDATE"].ToString()))
                        {
                            DateTime LASPDATE = Convert.ToDateTime(item["LASPDATE"]);//立案日期
                            DateTime CFJDDATE = Convert.ToDateTime(item["CFJDDATE"]);//处罚决定日期
                            TimeSpan ts = nowDate - LASPDATE;
                            int days = ts.Days;

                            if (days > 90)
                            {
                                item["OTHER_REMARK"] = 2;
                            }
                            else
                            {
                                item["OTHER_REMARK"] = 0;
                            }
                        }
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 29)
                    {
                        item["CASE_STATUS"] = "申请行政强制";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 30)
                    {
                        item["CASE_STATUS"] = "履行行政处罚催告";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 31)
                    {
                        item["CASE_STATUS"] = "行政处罚强制决定";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 32)
                    {
                        item["CASE_STATUS"] = "履行行政处罚强制催告";
                    }
                    else if (Convert.ToInt32(item["CASE_STATUS"]) == 33)
                    {
                        item["CASE_STATUS"] = "其他";
                    }
                    //item["CASE_STATUS"] = "行政处罚";
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) == 50)
                {
                    item["CASE_STATUS"] = "组织拆除";
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) > 50 && Convert.ToInt32(item["CASE_STATUS"]) < 90)
                {
                    item["CASE_STATUS"] = "待结案";
                }
                else if (Convert.ToInt32(item["CASE_STATUS"]) >= 90)
                {
                    item["CASE_STATUS"] = "已结案";
                }
            }

            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 案件上报
        /// </summary>
        /// <returns></returns>
        public ActionResult IllegalReport(string Id)
        {
            var entity = new IllegalCaseInfoEntity();
            if (string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Guid.NewGuid().ToString();
            }
            else
            {
                ViewBag.Id = Id;
                var IllegalcCase = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity { ID = Id });
                if (IllegalcCase != null && IllegalcCase.Any())
                {
                    entity = IllegalcCase[0];
                }
            }
            //问题来源
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0010", "");
            comResourceEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Source"] = new SelectList(comResourceEntity, "Id", "RSKEY", "");
            //所属区域
            //承办部门
            var company = new CrmCompanyBll().GetAllEnforcementUnit();
            company.Insert(0, new CrmCompanyEntity { Id = "", ShortName = "==请选择==" });
            ViewData["Company"] = new SelectList(company, "Id", "ShortName", "");
            return View(entity);
        }

        /// <summary>
        /// 案件上报
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <param name="txtName"></param>
        /// <param name="txtContact"></param>
        /// <param name="drpSourceId"></param>
        /// <param name="drpSource"></param>
        /// <param name="txtDescription"></param>
        /// <param name="txtAddress"></param>
        /// <param name="txtReportTime"></param>
        /// <returns></returns>
        public ActionResult SubmitCaseData(string Id, string txtName, string txtContact, string drpSourceId, string drpSource, string txtDescription, string txtAddress, string txtReportTime, string txtCompanyId, string txtCompanyName, string txtDeptId, string txtDeptName, string txtUserId, string txtUserName)
        {
            var isOk = false;
            try
            {
                var IllegalcCase = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity { ID = Id });
                if (!IllegalcCase.Any())
                {
                    var CaseInfoEntity = new IllegalCaseInfoEntity
                    {
                        ID = Id,
                        REPORT_NAME = txtName,
                        REPORT_PHONE = txtContact,
                        CASE_SOURCES = drpSourceId,
                        RE_SOURCE_NAME = drpSource == "==请选择==" ? "" : drpSource,
                        CASE_FACT = txtDescription,
                        DETAIL_ADDRESS = txtAddress,
                        REPORT_CASE_DATE = txtReportTime,
                        COMPANY_ID = txtCompanyId == "==请选择==" ? "" : txtCompanyId,
                        COMPANY_NAME = txtCompanyName == "==请选择==" ? "" : txtCompanyName,
                        DEPT_KEY_ID = txtDeptId == "==请选择==" ? "" : txtDeptId,
                        ZF_DEPT_NAME = txtDeptName == "==请选择==" ? "" : txtDeptName,
                        HANDLE_ID = txtUserId == "==请选择==" ? "" : txtUserId,
                        HANDLE_NAME = txtUserName == "==请选择==" ? "" : txtUserName,
                        CASE_REGISTRATION_SOURCE = "1",
                        CASE_STATUS = "0",
                        ROWSTATUS = 1,
                        CREATOR_ID = CurrentUser.CrmUser.Id,
                        CREATE_BY = CurrentUser.CrmUser.UserName,
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = CurrentUser.CrmUser.Id,
                        UPDATE_BY = CurrentUser.CrmUser.UserName,
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _illegalCaseInfoBll.InsertIllegalCaseInfo(CaseInfoEntity);
                }
                else
                {
                    var CaseInfoEntity = new IllegalCaseInfoEntity
                    {
                        ID = Id,
                        REPORT_NAME = txtName,
                        REPORT_PHONE = txtContact,
                        CASE_SOURCES = drpSourceId,
                        RE_SOURCE_NAME = drpSource,
                        CASE_FACT = txtDescription,
                        DETAIL_ADDRESS = txtAddress,
                        REPORT_CASE_DATE = txtReportTime,
                        DEPT_KEY_ID = txtDeptId,
                        ZF_DEPT_NAME = txtDeptName,
                        HANDLE_ID = txtUserId,
                        HANDLE_NAME = txtUserName,
                    };
                    isOk = _illegalCaseInfoBll.UpdateIllegalCase(CaseInfoEntity);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 核实认定
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="Pk_Id">案件Id</param>
        /// <returns></returns>
        public ActionResult IllegalVerify(string Id, string Pk_Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Guid.NewGuid().ToString();
            }
            //违建建筑类型
            List<ComResourceEntity> comBuildTypeEntity = _comResourceBll.GetListBy("0098", "");
            comBuildTypeEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["BuildType"] = new SelectList(comBuildTypeEntity, "Id", "RSKEY", "");
            //房屋结构
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0075", "");
            comResourceEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Structure"] = new SelectList(comResourceEntity, "Id", "RSKEY", "");
            //是违建
            List<ComResourceEntity> comCreateStatusEntity = _comResourceBll.GetListBy("0074", "");
            comCreateStatusEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["CreateStatus"] = new SelectList(comCreateStatusEntity, "Id", "RSKEY", "");
            //非违建
            List<ComResourceEntity> comFactEntity = _comResourceBll.GetListBy("0089", "");
            comFactEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Fact"] = new SelectList(comFactEntity, "Id", "RSKEY", "");
            ViewBag.CaseInfoNo = Pk_Id;
            return View();
        }

        /// <summary>
        /// 上报核实信息
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <param name="Long"></param>
        /// <param name="Width"></param>
        /// <param name="High"></param>
        /// <param name="Structure"></param>
        /// <param name="Covers"></param>
        /// <param name="Build"></param>
        /// <param name="Describe"></param>
        /// <param name="txtVerifyTime"></param>
        /// <param name="IllegalState"></param>
        /// <param name="IllegalResult"></param>
        /// <returns></returns>
        public ActionResult SubmitVerifyData(string Id, string CASE_INFO_NO, string Long, string Width, string High, string BuildTypeId, string BuildType, string StructureId, string Structure, string Covers, string Build, string Describe, string txtVerifyTime, string IllegalState, string IllegalResult, string buildTime = "1900-01-01")
        {
            var isOk = false;
            try
            {
                var IllegalcCase = _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity { CASE_INFO_NO = CASE_INFO_NO });
                if (!IllegalcCase.Any())
                {
                    var datetime = _comHolidaysBll.GetWorkTime(Convert.ToDateTime(txtVerifyTime), 8);//根据节假日获取七个工作日
                    var VerifyEntity = new IllegalCaseVerifyEntity
                    {
                        ID = Id,
                        CASE_INFO_NO = CASE_INFO_NO,
                        LONG = Long,
                        WIDE = Width,
                        HIGH = High,
                        BUILDTYPEID = BuildTypeId,
                        BUILDTYPE = BuildType,
                        STRUCTUREID = StructureId,
                        STRUCTURE = Structure,
                        COVERSAREA = Covers,
                        BUILDAREA = Build,
                        DESCRIBE = Describe,
                        VERIFYTIME = txtVerifyTime,
                        VERIFYTENDIME = datetime.ToString("yyyy-MM-dd HH:mm:ss"),
                        VERIFYSTATE = IllegalState,
                        VERIFYRESULTS = IllegalResult,
                        BUILDTIME = Convert.ToDateTime(buildTime),
                        ROWSTATUS = 1,
                        CREATOR_ID = CurrentUser.CrmUser.Id,
                        CREATE_BY = CurrentUser.CrmUser.UserName,
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = CurrentUser.CrmUser.Id,
                        UPDATE_BY = CurrentUser.CrmUser.UserName,
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _illegalCaseVerifyBll.InsertIllegalVerifyInfo(VerifyEntity);
                    if (isOk && IllegalState == "1")
                    {
                        //核实认定后更新案件状态
                        _illegalCaseInfoBll.UpdateIllegalCaseStatus("10", CASE_INFO_NO);
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 主窗体
        /// </summary>
        /// <returns></returns>
        public ActionResult Main(string Id)
        {
            var entity = new IllegalCaseInfoEntity();
            var IllegalcCase = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity { ID = Id });
            if (IllegalcCase != null && IllegalcCase.Any())
            {
                entity = IllegalcCase[0];
            }
            ViewBag.Id = Id;
            ViewBag.DefaultPage = "IllegalDetail";
            return View(entity);
        }

        /// <summary>
        /// 案件详情
        /// </summary>
        /// <returns></returns>
        public ActionResult IllegalDetail(string Id, string module, string worklistId)
        {
            var entity = new IllegalCaseInfoEntity();
            //问题来源
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0010", "");
            comResourceEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Sources"] = new SelectList(comResourceEntity, "Id", "RsKey", "");
            //违建建筑类型
            List<ComResourceEntity> comBuildTypeEntity = _comResourceBll.GetListBy("0098", "");
            comBuildTypeEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["BuildType"] = new SelectList(comBuildTypeEntity, "Id", "RSKEY", "");
            //房屋结构
            List<ComResourceEntity> comStructureEntity = _comResourceBll.GetListBy("0075", "");
            comStructureEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Structure"] = new SelectList(comStructureEntity, "Id", "RsKey", "");
            //拆除
            List<ComResourceEntity> comRemoveEntity = _comResourceBll.GetListBy("0087", "");
            comRemoveEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Remove"] = new SelectList(comRemoveEntity, "Id", "RsKey", "");
            var verityentity = new IllegalCaseVerifyEntity();
            var removeentity = new IllegalCaseRemoveEntity();
            bool btnApplay = false;
            bool IsPlan = false;
            if (!string.IsNullOrEmpty(Id))
            {
                var IllegalcCase = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity { ID = Id });
                if (IllegalcCase != null && IllegalcCase.Any())
                {
                    entity = IllegalcCase[0];
                    if (entity.HANDLE_ID == CurrentUser.CrmUser.Id)
                    {
                        btnApplay = true;
                    }
                    if (entity.ISPLAN == "0")
                    {
                        IsPlan = true;
                    }
                }
                //核实信息
                var IllegalCaseVerify = _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity { CASE_INFO_NO = Id });
                if (IllegalCaseVerify != null && IllegalCaseVerify.Any())
                {
                    verityentity = IllegalCaseVerify[0];
                }
                //拆除信息
                var IllegalCaseRemove = _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity { CASE_INFO_NO = Id });
                if (IllegalCaseRemove != null && IllegalCaseRemove.Any())
                {
                    removeentity = IllegalCaseRemove[0];
                }
            }


            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, Id);
            }
            ViewBag.WorkListId = worklistId;

            bool btnAgree = false;
            if (!string.IsNullOrEmpty(worklistId))
            {
                if (Convert.ToInt32(entity.CASE_STATUS) > 50 && Convert.ToInt32(entity.CASE_STATUS) < 90)
                    btnAgree = true;
            }
            ViewData["FlowStartIdea"] = _crmIdeaListBll.GetSearchResult(new CrmIdeaListEntity() { ResourceID = Id, Duty = "承办人" });
            ViewData["FlowIdea"] = _crmIdeaListBll.GetSearchResult(new CrmIdeaListEntity() { ResourceID = Id, Duty = "执法中队" });

            ViewBag.IsPlan = IsPlan;//规划认定
            ViewBag.btnApplay = btnApplay;//申请结案
            ViewBag.BtnAgree = btnAgree;//同意

            ViewBag.verityEntity = verityentity;
            ViewBag.removeEntity = removeentity;
            ViewBag.Module = module;
            ViewBag.Id = Id;
            ViewBag.Status = entity.CASE_STATUS;
            return View(entity);
        }

        /// <summary>
        /// 规划认定
        /// </summary>
        /// <returns></returns>
        public ActionResult IllegalPlanning(string Pk_Id)
        {
            ViewBag.CaseInfoNo = Pk_Id;
            return View();
        }

        /// <summary>
        /// 上报规划认定
        /// </summary>
        /// <param name="CaseId"></param>
        /// <param name="txtPlanTime"></param>
        /// <param name="txtPlanNo"></param>
        /// <returns></returns>
        public ActionResult SubmitPlanData(string CaseId, string txtPlanTime, string txtPlanNo, string isPunish)
        {
            var isOk = false;
            try
            {
                string status = "0";
                var datetime = _comHolidaysBll.GetWorkTime(Convert.ToDateTime(txtPlanTime), 8);//根据节假日获取七个工作日
                string planEndTime = datetime.ToString("yyyy-MM-dd HH:mm:ss");
                isOk = _illegalCaseInfoBll.UpdateIllegalCase(new IllegalCaseInfoEntity { ID = CaseId, PLAN_CUTOFF_DATE = txtPlanTime, PLAN_END_DATE = planEndTime, PLAN_FILE_NUMBER = txtPlanNo, ISPUNISH = isPunish });
                if (isOk)
                {
                    if (isPunish == "1")
                    {
                        status = "21";//进入行政处罚流程
                    }
                    else if (isPunish == "0")
                    {
                        status = "50";//进入组织拆除
                    }
                    else if (isPunish == "2")
                    {
                        status = "20";
                    }
                    //规划认定后更新案件状态
                    _illegalCaseInfoBll.UpdateIllegalCaseStatus(status, CaseId);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下一步更新案件状态
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public JsonResult UpdateNextIllegalCase(string Pk_Id, string hidStatus, string status, string updata)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(Pk_Id) && !string.IsNullOrEmpty(hidStatus))
                {
                    isOk = _illegalCaseInfoBll.UpdateIllegalCaseStatus(hidStatus, Pk_Id);
                }
                else
                {
                    isOk = _illegalCaseInfoBll.UpdateIllegalCaseNextStatus(Pk_Id);
                    if (isOk)
                    {
                        if (status == "21" && !string.IsNullOrEmpty(updata))
                        {
                            isOk = _illegalCaseInfoBll.UpdateIllegalCaseDate(status, updata, Pk_Id);
                        }
                        else if (status == "28" && !string.IsNullOrEmpty(updata))
                        {
                            isOk = _illegalCaseInfoBll.UpdateIllegalCaseDate(status, updata, Pk_Id);
                        }
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 组织拆除
        /// </summary>
        /// <returns></returns>
        public ActionResult IllegalRemove(string Id, string Pk_Id, string txtPlanTime, string txtPlanNo, string isPunish)
        {
            if (string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Guid.NewGuid().ToString();
            }
            ViewBag.CaseInfoNo = Pk_Id;

            ViewBag.txtPlanTime = txtPlanTime;
            ViewBag.txtPlanNo = txtPlanNo;
            ViewBag.isPunish = isPunish;
            //拆除
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0087", "");
            comResourceEntity.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Sources"] = new SelectList(comResourceEntity, "Id", "RSKEY", "");
            return View();
        }

        /// <summary>
        /// 上报组织拆除
        /// </summary>
        /// <param name="CaseId"></param>
        /// <param name="txtArea"></param>
        /// <param name="txtGarbage"></param>
        /// <param name="txtNO"></param>
        /// <param name="txtDescription"></param>
        /// <returns></returns>
        public ActionResult SubmitRemoveData(string PK_ID, string CaseId, string drpRemoveId, string drpRemove, string txtRemoveCount, string txtArea, string txtGarbage, string txtNO, string txtDescription, string txtRemoveTime)
        {
            var isOk = false;
            try
            {
                var IllegalcCase = _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity { CASE_INFO_NO = CaseId });
                if (!IllegalcCase.Any())
                {
                    var RemoveEntity = new IllegalCaseRemoveEntity
                    {
                        ID = PK_ID,
                        CASE_INFO_NO = CaseId,
                        REMOVE_FINISH_DATE = txtRemoveTime,
                        KEEP_GARBAGE = txtGarbage,
                        REMOVE_COUNT = txtRemoveCount,
                        REMOVE_AREA = txtArea,
                        REMOVAL_METHOD_ID = drpRemoveId,
                        REMOVAL_METHOD_NAME = drpRemove,
                        REMOVE_NO = txtNO,
                        REMOVE_DESCRIPTION = txtDescription,
                        ROWSTATUS = 1,
                        CREATOR_ID = CurrentUser.CrmUser.Id,
                        CREATE_BY = CurrentUser.CrmUser.UserName,
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = CurrentUser.CrmUser.Id,
                        UPDATE_BY = CurrentUser.CrmUser.UserName,
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _illegalCaseRemoveBll.InsertIllegalRemoveInfo(RemoveEntity);
                    if (isOk)
                    {
                        //组织拆除后更新案件状态
                        _illegalCaseInfoBll.UpdateIllegalCaseStatus("50", CaseId);
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 按责任部门统计
        /// </summary>
        /// <returns></returns>
        public ActionResult DeptStatistics()
        {
            return View();
        }

        /// <summary>
        /// 按责任部门统计
        /// </summary>
        /// <returns></returns>
        public string GetDeptStatistics()
        {
            var data = _illegalCaseInfoBll.GetDeptStatisticsData();
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 按地域统计
        /// </summary>
        /// <returns></returns>
        public ActionResult AreaStatistics()
        {
            return View();
        }

        /// <summary>
        /// 按地域统计
        /// </summary>
        /// <returns></returns>
        public string GetAreaStatistics()
        {
            var data = _illegalCaseInfoBll.GetAreaStatistics();
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 根据机构Id获取所有的部门
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public JsonResult GetDeptment(string companyId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(companyId))
            {
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });
                foreach (CrmDepartmentEntity c in departments)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = c.FullName.ToString(),
                        Value = c.Id.ToString()
                    });
                }
                if (!items.Count.Equals(0))
                {
                    items.Insert(0, new SelectListItem() { Text = "==请选择==", Value = "" });
                }
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据部门Id获取当前部门下所有人员
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public JsonResult GetUsers(string deptId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(deptId))
            {
                var users = new CrmUserBll().GetDeptsUsers(new CrmUserEntity() { DepartmentId = deptId }).ToList();
                foreach (CrmUserEntity c in users)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = c.RealName.ToString(),
                        Value = c.Id.ToString()
                    });
                }
                if (!items.Count.Equals(0))
                {
                    items.Insert(0, new SelectListItem() { Text = "==请选择==", Value = "" });
                }
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存承办人
        /// </summary>
        /// <param name="CaseId"></param>
        /// <param name="deptId"></param>
        /// <param name="deptName"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public JsonResult SavePerson(string CaseId, string deptId, string deptName, string userId, string userName)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(CaseId))
                {
                    var CaseInfoEntity = new IllegalCaseInfoEntity
                    {
                        ID = CaseId,
                        DEPT_KEY_ID = deptId,
                        ZF_DEPT_NAME = deptName,
                        HANDLE_ID = userId,
                        HANDLE_NAME = userName
                    };
                    isOk = _illegalCaseInfoBll.UpdateIllegalCase(CaseInfoEntity);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 考核统计
        /// </summary>
        /// <returns></returns>
        public ActionResult EvaluationIndex(string year, string month)
        {
            if (string.IsNullOrEmpty(year))
            {
                year = DateTime.Now.Year.ToString();
            }
            if (string.IsNullOrEmpty(month))
            {
                month = DateTime.Now.Month.ToString();
            }
            BindDate(Convert.ToInt32(year), Convert.ToInt32(month));

            DateTime lastMonth = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            var startTime = lastMonth.ToString("yyyy-MM-dd") + " 00:00:00.000";
            var endTime = lastMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
            var user = CurrentUser.CrmUser;
            var companys = new CrmCompanyBll().GetAllEnforcementUnit();
            //验证是有获取所有执法单位的权限，如没有只查本单位的权限
            var isAllEnforcementUnit = new MembershipManager().VerificationPermissions(user.Id, "Company", "Operation");
            companys = isAllEnforcementUnit
                           ? companys
                           : companys.Where(x => x.Id == user.CompanyId).ToList();
            List<IllegalEntity> illEntity = new List<IllegalEntity>();
            if (companys.Any() && companys.Count > 1)
            {
                foreach (var item in companys)
                {
                    IllegalEntity entity = new IllegalEntity();
                    //获取部门案件列表
                    var Case = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity() { COMPANY_ID = item.Id }, startTime, endTime);

                    //获取违法案件违法拆除信息
                    int removecount = 0, removearea = 0;
                    var listRemove = _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity() { }).Where(x => Case.Any(y => y.ID == x.CASE_INFO_NO)).ToList();
                    listRemove.ForEach(x => removecount += Convert.ToInt32(x.REMOVE_COUNT));
                    listRemove.ForEach(x => removearea += Convert.ToInt32(x.REMOVE_AREA));
                    entity.UnitId = item.Id;
                    entity.ResponsUnit = item.ShortName;
                    entity.TotalCase = Case.Count();
                    entity.FinishCase = Case.Where(x => Convert.ToInt32(x.CASE_STATUS) >= 90).Count();
                    entity.NotClosed = entity.TotalCase - entity.FinishCase;
                    entity.Dismantle = removecount;
                    entity.DismantleArea = removearea;
                    illEntity.Add(entity);
                }
            }
            ViewData["IllEntity"] = illEntity;
            return View();
        }

        public class IllegalEntity
        {
            //责任单位Id
            public string UnitId { get; set; }
            //责任单位
            public string ResponsUnit { get; set; }
            //案件总数
            public int TotalCase { get; set; }
            //结案数量
            public int FinishCase { get; set; }
            //未结案数量
            public int NotClosed { get; set; }
            //拆除数量
            public int Dismantle { get; set; }
            //拆除面积
            public double DismantleArea { get; set; }
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
            //monthList.Add(0);
            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }

        #region 统计分析
        public ActionResult IllegalStatistic()
        {
            int veritycount = 0, verityarea = 0, removecount = 0, removearea = 0, unremovercount = 0, unremovearea = 0;
            //违法建设总处数
            _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity() { }).ForEach(x => veritycount += Convert.ToInt32(x.COVERSAREA));
            //违法建设总面积
            _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity() { }).ForEach(x => verityarea += Convert.ToInt32(x.BUILDAREA));
            //已拆除处数
            _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity() { }).ForEach(x => removecount += Convert.ToInt32(x.REMOVE_COUNT));
            //已拆除面积
            _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity() { }).ForEach(x => removearea += Convert.ToInt32(x.REMOVE_AREA));
            //未拆除处数
            unremovercount = (veritycount - removecount) >= 0 ? (veritycount - removecount) : 0;
            //未拆除面积
            unremovearea = (verityarea - removearea) > 0 ? (verityarea - removearea) : 0;
            ViewBag.veritycount = veritycount;
            ViewBag.verityarea = verityarea;
            ViewBag.removecount = removecount;
            ViewBag.removearea = removearea;
            ViewBag.unremovercount = unremovercount;
            ViewBag.unremovearea = unremovearea;
            return View();
        }

        /// <summary>
        /// 违建类型占比
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypeData()
        {
            List<ComResourceEntity> comResourceEntity = _comResourceBll.GetListBy("0098", "");
            List<CaseEntity> list = new List<CaseEntity>();
            if (comResourceEntity.Any())
            {
                foreach (var item in comResourceEntity)
                {
                    var lst = _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity() { BUILDTYPEID = item.Id });
                    list.Add(new CaseEntity()
                    {
                        Name = item.RsKey,
                        caseNum = lst.Count
                    });
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 部门违法案件统计
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeptCaseData()
        {
            var getCompany = _crmCompanyBll.GetAllEnforcementUnit();
            //var caseList = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity() { });
            List<CaseEntity> list = new List<CaseEntity>();
            foreach (CrmCompanyEntity item in getCompany)
            {
                int veritycount = 0, removecount = 0;
                //var deptList = _crmDepartmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = item.Id });
                //var getCaseList = caseList.Where<IllegalCaseInfoEntity>(x => deptList.Any(y => y.Id == x.DEPT_KEY_ID)).ToList();
                var getCaseList = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity() { COMPANY_ID = item.Id });
                //违建处数
                _illegalCaseVerifyBll.GetIllegalCaseResult(new IllegalCaseVerifyEntity() { }).Where(x => getCaseList.Any(y => y.ID == x.CASE_INFO_NO)).ToList().ForEach(x => veritycount += Convert.ToInt32(x.COVERSAREA));
                //拆除处数
                _illegalCaseRemoveBll.GetIllegalCaseResult(new IllegalCaseRemoveEntity() { }).Where(x => getCaseList.Any(y => y.ID == x.CASE_INFO_NO)).ToList().ForEach(x => removecount += Convert.ToInt32(x.REMOVE_COUNT));

                list.Add(new CaseEntity()
                {
                    Name = item.ShortName,
                    verityNum = veritycount,
                    removeNum = removecount
                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 实体定义
        /// </summary>
        public class CaseEntity
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 案件总数
            /// </summary>
            public int caseNum { get; set; }

            /// <summary>
            /// 违建处数
            /// </summary>
            public int verityNum { get; set; }

            /// <summary>
            /// 拆除处数
            /// </summary>
            public int removeNum { get; set; }
        }
        #endregion
    }
}
