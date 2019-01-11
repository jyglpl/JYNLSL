using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.License
{
    public class LicenseOutDoorController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        public string ItemCode = "";

        //
        // GET: /LicenseOutDoor/

        public ActionResult Main()
        {
            return View();
        }

        /// <summary>
        /// 店招标牌详情
        /// </summary>
        /// <param name="id">许可主键</param>
        /// <param name="itemcode">审批事项编号</param>
        /// <param name="worklistId">待办事宜</param>
        /// <returns></returns>
        public ActionResult Entity(string id, string itemcode, string worklistId)
        {
            var entity = new LicenseMainEntity();
            var outdoorEntity = new LicenseOutDoorEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = new LicenseMainBll().Get(id);
                outdoorEntity = new LicenseOutDoorBll().GetEntityByLicenseId(id);
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.ItemCode = itemcode;
                ItemCode = itemcode;
                entity.PromiseStartDate = DateTime.Now;
                entity.PromiseEndDate = new ComHolidaysBll().GetWorkTime(entity.PromiseStartDate, 7);
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;

            #region 字典数据


            //申请人证照类型
            var paperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0055" }).ToList();
            ViewData["PaperTypes"] = new SelectList(paperTypes, "Id", "RsKey");

            //广告类型
            var outdoorType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0056" }).ToList();
            ViewData["OutdoorType"] = outdoorType;


            //设施类型
            var facilityTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0057" }).ToList();
            facilityTypes.Insert(0, new ComResourceEntity() { Id = "", RsKey = "" });
            ViewData["FacilityTypes"] = facilityTypes;

            //广告性质
            var natures = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0058" }).ToList();
            ViewData["Natures"] = natures;

            //设置周期
            var setUpCycles = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0059" }).ToList();
            ViewData["SetUpCycles"] = setUpCycles;

            //短期广告设置时段
            var setUpCycleDetails = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0060" }).ToList();
            ViewData["SetUpCycleDetails"] = setUpCycleDetails;

            //现场检查状态
            var IsState = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0068" }).ToList();
            ViewData["IsState"] = IsState;

            //广告受理类型
            var acceptTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = entity.ItemCode.Equals("JS050800ZJ-XK-0090") ? "0061" : "0065" }).ToList();
            ViewData["AcceptTypes"] = acceptTypes;

            //环保企业分类类别
            var enterpriseTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0062" }).ToList();
            ViewData["EnterpriseTypes"] = enterpriseTypes;

            //片区
            var companys = new CrmCompanyBll().GetAllLicenseUnit();
            companys.Insert(0, new CrmCompanyEntity() { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(companys, "Id", "FullName");

            #endregion

            //申请规格
            var specs = new LicenseSpecBll().GetSearchResult(new LicenseSpecEntity() { LicenseId = entity.Id });
            ViewData["Specs"] = specs;

            //现场勘察的广告尺寸
            var licenseCheckSpecnProspect = new LicenseCheckSpecBll().GetSearchResult(new LicenseCheckSpecEntity() { LicenseId = entity.Id, CheckType = 1 });
            ViewData["LicenseCheckSpecnProspect"] = licenseCheckSpecnProspect;

            //现场检查的广告尺寸
            var licenseCheckSpecnCheck = new LicenseCheckSpecBll().GetSearchResult(new LicenseCheckSpecEntity() { LicenseId = entity.Id, CheckType = 2 });
            ViewData["LicenseCheckSpecnCheck"] = licenseCheckSpecnCheck;

            //店招标牌实体
            ViewData["OutDoorEntity"] = outdoorEntity;
            ViewData["FlowIdea"] = new CrmIdeaListBll().GetFlowIdea(id);
            var licenseInquestSizeList = new LicenseInquestSizeBll().GetSearchResult(new LicenseInquestSizeEntity()
            {
                LicenseId = entity.Id
            });
            ViewBag.LicenseInquestSize = licenseInquestSizeList;

            #region 控制按钮

            var ysIsOpen = new CrmMessageWorkBll().GetIsOpen(id, 2);

            var pwIsOpen = new CrmMessageWorkBll().GetIsOpen(id, 1);
            //保存、受理、申请、同意、退回、提交（街道勘验）、下一步（发起办证申请）、办结
            bool btnSave = false,
                 btnAccept = false,
                 btnApply = false,
                 btnAgree = false,
                 btnDisAgree = false,
                 btnSubmit = false,
                 btnNext = false,
                 btnClosed = false,
                 btnBackWindows = false;//退回窗口

            //是否领导
            bool isDirector = new CrmUserBll().GetIsLicenseDirector(CurrentUser.CrmUser.Id);

            ViewBag.btnAgreeName = isDirector ? "同 意" : "送下一步";






            var state = entity.State;



            //验证当前登录账号是否有受理权限
            var acceptPer = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "LicenseApproval", "Accept");
            //是否有退回窗口的权限
            var licenseBack = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "LicenseBack", "Windowns");

            //if (acceptPer)//窗口有保存按钮
            //{
            //    btnSave = true;
            //    if (state == 20)
            //    {
            //        if (!ysIsOpen)
            //        {
            //            btnNext = true;
            //        }
            //        btnClosed = true;
            //    }
            //    else if (state == 30||state==-1)
            //    {
            //        btnClosed = true;
            //    }
            //}

            //if (state >= 0 && state < 10 && acceptPer)   //受理权限
            //{
            //    btnAccept = true;
            //}
            //if (acceptPer && !ysIsOpen && !fzIsOpen)
            //{
            //    btnApply = true;
            //}
            //if (ysIsOpen && fzIsOpen)
            //{
            //    btnAgree = true;
            //}            


            //if (!string.IsNullOrEmpty(worklistId))
            //{
            //    if (state == 11 || state == 21)
            //    {                    
            //        btnDisAgree = true;
            //    }
            //    else if ((state > 11 && state < 20) || (state > 21 && state < 30))
            //    {
            //        btnAgree = true;
            //        btnDisAgree = true;
            //    }
            //    if (licenseBack)
            //    {
            //        btnBackWindows = true;
            //    }
            //}

            //var handType = entity.State > 20 ? 2 : 1;
            ////已选择人员集
            //var userIds = new LicenseHandUsersBll().GetLicenseHandUserIds(entity.Id, handType);
            //if (userIds.FindIndex(i => i.Equals(CurrentUser.CrmUser.Id)) != -1)
            //{
            //    btnSubmit = true;
            //    btnDisAgree = false;
            //}

            if (acceptPer)//保存权限
            {
                btnSave = true;
            }
            if (acceptPer && state < 10)//受理权限
            {
                btnAccept = true;
            }
            if (acceptPer && state <= 10)//申请权限(发送)
            {
                btnApply = true;
            }
            if (!string.IsNullOrEmpty(worklistId) && ((state >= 10 && state < 20) || (state > 20 && state < 30)))//同意退回
            {
                btnAgree = true;
                if (state != 10 && state != 20)
                {
                    btnDisAgree = true;
                }
            }
            if (state == 20 && ysIsOpen)//当退回窗口验收流程发起的时候显示同意按钮
            {
                btnAgree = true;
            }
            if (!ysIsOpen && state == 20)//下一步发证
            {
                btnNext = true;
            }
            if (state == 20 || state == 30 || state == -1)//办结
            {
                btnClosed = true;
            }
            if (licenseBack)//退回窗口
            {
                btnBackWindows = true;
            }


            ViewBag.BtnSave = btnSave;
            ViewBag.BtnAccept = btnAccept;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnDisAgree = btnDisAgree;
            ViewBag.BtnSubmit = btnSubmit;
            ViewBag.BtnNext = btnNext;
            ViewBag.BtnClosed = btnClosed;
            ViewBag.BtnBackWindows = btnBackWindows;

            #endregion

            bool inquestPanel = false, acceptancePanel = false;

            if (state >= 11)
            {
                inquestPanel = true;
            }
            if (state >= 21)
            {
                acceptancePanel = true;
            }
            ViewBag.InquestPanel = inquestPanel;
            ViewBag.AcceptancePanel = acceptancePanel;

            return View(entity);
        }


        /// <summary>
        /// 文书打印页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DocReportPrint(string id)
        {
            ViewBag.Id = id;
            return View();
        }


        #region AJAX 请求数据



        #endregion

        #region AJAX 提交数据

        /// <summary>
        /// 保存店招标牌信息
        /// </summary>
        /// <param name="mainEntity">许可实体</param>
        /// <param name="collection">表单</param>
        /// <returns></returns>
        public JsonResult AcceptClick(LicenseMainEntity mainEntity, FormCollection collection)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                var user = CurrentUser.CrmUser;

                mainEntity.ApplicationDate = DateTime.Now;
                mainEntity.RowStatus = 1;
                mainEntity.CreatorId = user.Id;
                mainEntity.CreateBy = user.UserName;
                mainEntity.CreateOn = DateTime.Now;
                mainEntity.UpdateId = user.Id;
                mainEntity.UpdateBy = user.UserName;
                mainEntity.UpdateOn = DateTime.Now;
                mainEntity.DataSource = "1";
                #region 获取表单提交内容

                var content = collection["OutDoorContent"];  //广告内容
                var numbers = collection["OutDoorNumbers"];  //广告数量
                var outdoorType = collection["OutdoorType"]; //广告类型

                var txtwidth = collection["txtwidth"];    //规格：宽
                var txtheight = collection["txtheight"];  //规格：高
                var txtLogn = collection["txtLogn"];      //规格：挑高
                var facilityType = collection["FacilityType"];   //规格：设施类型
                var txtothertype = collection["txtothertype"];   //规格：其他设施

                var nature = collection["Nature"];      //广告性质

                var setupcycle = collection["SetUpCycle"];   //广告周期
                var setupcycledetails = collection["SetUpCycleDetails"];   //短期设置区间
                var setUpCycleOther = collection["SetUpCycleOther"];       //其他短期设置

                var installstartdate = collection["InstallStartDate"];  //安装开始日期
                var installenddate = collection["InstallEndDate"];      //安装截止日期
                var laneArea = collection["LaneArea"];  //占道面积

                var acepttype = collection["AcceptType"];   //受理类型  
                var enterprise = collection["Enterprise"];  //环保企业类别

                var checkLeftHeight = collection["CheckLeftHeight"];//左邻高度
                var checkRightLogn = collection["CheckRightLogn"];//左邻外挑
                var checkRightHeight = collection["CheckRightHeight"];//右邻高度
                var checkLeftLogn = collection["CheckLeftLogn"];//右邻外挑


                #endregion

                #region 广告实体

                var outdoorEntity = new LicenseOutDoorEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    LicenseId = mainEntity.Id,
                    Content = content,
                    Numbers = int.Parse(numbers),
                    OutdoorType = outdoorType,
                    Nature = nature,
                    SetUpCycle = setupcycle,
                    SetUpCycleDetails = setupcycledetails,
                    SetUpCycleOther = setUpCycleOther,
                    InstallStartDate = string.IsNullOrEmpty(installstartdate) ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(installstartdate),
                    InstallEndDate = string.IsNullOrEmpty(installenddate) ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(installenddate),
                    LaneArea = laneArea,
                    AcceptType = acepttype,
                    Enterprise = enterprise,
                    CheckLeftHeight = checkLeftHeight,
                    CheckRightLogn = checkRightLogn,
                    CheckRightHeight = checkRightHeight,
                    CheckLeftLogn = checkLeftLogn,
                    RowStatus = 1,
                    CreatorId = user.Id,
                    CreateBy = user.UserName,
                    CreateOn = DateTime.Now,
                    UpdateId = user.Id,
                    UpdateBy = user.UserName,
                    UpdateOn = DateTime.Now
                };

                #endregion

                #region 广告规格

                var specList = new List<LicenseSpecEntity>();

                var splitwidth = txtwidth.Split(',');
                var splitheight = txtheight.Split(',');
                var splitlogn = txtLogn.Split(',');
                var splitfacilityType = facilityType.Split(',');
                var splitothertype = txtothertype.Split(',');

                for (int i = 0; i < splitwidth.Length; i++)
                {
                    specList.Add(new LicenseSpecEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        LicenseId = mainEntity.Id,
                        Width = splitwidth[i],
                        Height = splitheight[i],
                        Long = splitlogn[i],
                        FacilityType = splitfacilityType[i],
                        OtherType = splitothertype[i],
                        SortNo = i,
                        RowStatus = 1,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    });
                }

                #endregion

                //执行调用数据库保存
                isOk = new LicenseOutDoorBll().TransactionSaveOutDoor(mainEntity, outdoorEntity, specList);
            }
            catch (Exception ex)
            {
                isOk = false;
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

        #endregion
    }
}
