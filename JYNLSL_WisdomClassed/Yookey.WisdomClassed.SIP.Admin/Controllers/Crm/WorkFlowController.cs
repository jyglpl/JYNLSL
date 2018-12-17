using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Business.SealUp;
using Yookey.WisdomClassed.SIP.Business.Petition;
using Yookey.WisdomClassed.SIP.Model.Petition;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Crm
{
    public class WorkFlowController : BaseController
    {
        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();      //一般案件基本信息
        readonly InfPunishDecisionBll _infPunishDecisionBll = new InfPunishDecisionBll();      //一般案件处罚决定
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //待办事宜信息
        readonly BaseUserBll _crmUserBll = new BaseUserBll();                                  //用户基本信息
        //readonly CrmUserBll _crmUserBll = new CrmUserBll();
        readonly FeProcessBll _feProcessBll = new FeProcessBll();
        readonly CrmOpinionsBll _crmOpinionsBll = new CrmOpinionsBll();
        //readonly PunishitemBll _punishitemBll = new PunishitemBll();
        readonly LegislationGistBll _legislationGistBll = new LegislationGistBll();
        //readonly InfPunishItemBll _infpunishItemBll = new InfPunishItemBll();
        readonly InfPunishLegislatioinBll _infPunishLegislatioinBll = new InfPunishLegislatioinBll();
        readonly ComHolidaysBll _comHolidaysBll = new ComHolidaysBll();
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();
        readonly SealUpBll _sealUpBll = new SealUpBll();
        readonly LicenseMainBll _licenseMainBll = new LicenseMainBll();
        readonly IllegalConstructionBll _illegalConstructionBll = new IllegalConstructionBll();
        readonly PetitionBll _petitionBll = new PetitionBll();
        readonly CrmCompanyBll _crmCompanyBll = new CrmCompanyBll();
        readonly IllegalCaseInfoBll _illegalCaseInfoBll = new IllegalCaseInfoBll(); //违法案件



        #region 案件审批

        #region 逐级审批
        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isloadOp">是否加载、保存常用意见</param>
        /// <param name="isFaster">是否一键审批</param>
        /// <returns></returns>
        public ActionResult CaseWorkFlow(string formId, string flowName, string eType, string worklistId, string isloadOp = "1", string isFaster = "0")
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                var infpunishitem = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                if (infpunishitem.Any())
                {
                    ViewBag.DefaultIdea = _legislationGistBll.GetDefaultIdeal(formId, flowName, infpunishitem[0].LegislationGistId);
                }
            }

            if (flowName.Equals("案件预审"))
            {
                if (CurrentUser.CrmUser.UserName == "周永健")
                {
                    ViewBag.DefaultIdea = eType.Equals("apply") ? "同意处罚，补办审批手续。" : "建议拆除。";
                }
            }

            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);
            //结案审批时间自动加上3个月
            if (flowName.Equals("结案审批"))
            {
                var descisionDate = _infPunishDecisionBll.GetDescsion(formId).FileDate.AddMonths(AppConfig.FinishMonth).AddDays(1);
                ViewBag.IdeaDate = descisionDate.ToString(AppConst.DateFormat);
            }
            return View();
        }

        /// <summary>
        /// 案件审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isSaveIdea">是否保存常用意见</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CaseApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId, string isSaveIdea)
        {

            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {
                var user = CurrentUser.CrmUser;
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "案件预审":
                    case "立案审批":
                    case "处理审批":
                    case "陈述申辩与听证":
                    case "结案审批":    //一般案件
                    case "国土违法线索登记审批":
                    case "国土立案审批":
                    case "国土呈批审批":
                    case "国土处罚决定审批":
                    case "国土结案审批":
                        {
                            var entity = _infPunishCaseinfoBll.Get(formId);         //案件实体
                            _feProcessBll.RuleCode.Add("@DeptName", entity.CompanyName);
                            _feProcessBll.Community.Add(entity.DeptId);
                            if (string.IsNullOrEmpty(entity.CaseInfoNo))
                            {
                                if (entity.TargetType.Equals("00120002"))
                                {
                                    ideaTitle = "【" + entity.TargetUnit + "】" + flowName; //待办事事宜标题
                                }
                                else
                                {
                                    ideaTitle = "【" + entity.TargetName + "】" + flowName; //待办事事宜标题
                                }
                            }
                            else
                            {
                                ideaTitle = "【" + entity.CaseInfoNo + "】" + flowName; //待办事事宜标题
                            }

                            //处理审批时，增加当事人类型、处罚金额变量
                            if (flowName.Equals("处理审批"))
                            {
                                var legislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                                if (legislations.Any())
                                {
                                    _feProcessBll.RuleCode.Add("@TargetType", entity.TargetType);                           //设置当事人类型
                                    _feProcessBll.RuleCode.Add("@PunishAmount", legislations[0].PunishAmount.ToString());   //设置处罚金额   
                                }
                            }
                            //案件预审时，增加案由变量
                            if (flowName.Equals("案件预审"))
                            {
                                var legislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                                if (legislations.Any())
                                {
                                    _feProcessBll.RuleCode.Add("@ItemNo", legislations[0].ItemNo);                           //设置当事人类型  
                                }
                            }
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;


                if (!string.IsNullOrEmpty(worklistId))
                {
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (workState == 2 || workState == -1)
                    {
                        flag = false;
                        rtMsg = "该待办事宜已处理请勿点击，关闭当前界面即可！";

                        var rtEntitys = new StatusModel<DBNull>
                        {
                            rtState = flag ? 0 : -1,
                            rtMsrg = rtMsg
                        };
                        return Json(rtEntitys, JsonRequestBehavior.AllowGet);
                    }
                }

                var note = "";      //短信内容
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    var isStartProcess = _feProcessBll.IsStartProcess(flowName, formId);
                    if (!isStartProcess)
                    {
                        rtMsg = "【" + flowName + "】流程发启成功！";
                        note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else
                    {
                        rtMsg = "【" + flowName + "】已发启，请关闭当前界面！";
                    }
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                        }
                        else
                        {
                            note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);

                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
                if (isSaveIdea.Equals("1"))  //是否保存意见
                {
                    _crmOpinionsBll.SaveIdea(idea, CurrentUser.CrmUser);
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "案件预审":
                    case "立案审批":
                    case "处理审批":
                    case "陈述申辩与听证":
                    case "结案审批":
                    case "国土违法线索登记审批":
                    case "国土立案审批":
                    case "国土呈批审批":
                    case "国土处罚决定审批":
                    case "国土结案审批":
                        _infPunishCaseinfoBll.CaseApproveReturn(CurrentUser.CrmUser.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                        break;
                }
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 一键审批

        /// <summary>
        /// 案件一键审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideaDate">审批日期</param>
        /// <param name="workListId">消息编号</param>
        /// <param name="isSaveIdea">是否保存常用意见</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CaseFasterApprove(string formId, string flowName, string eType, string idea, string ideaDate, string workListId, string isSaveIdea)
        {
            var flag = false;            //审批状态
            const string rtMsg = "一键审批处理成功！"; //返回内容
            var crmUser = CurrentUser.CrmUser;
            flag = FasterApprove(formId, flowName, eType, idea, ideaDate, workListId, crmUser);
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 案件一键审批
        /// 添加人：周 鹏
        /// 添加时间：2015-01-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">消息意见内容</param>
        /// <param name="ideaDate">消息处理意见</param>
        /// <param name="workListId">消息编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="crmUser">人员实体</param>
        /// <returns></returns>
        private bool FasterApprove(string formId, string flowName, string eType, string idea, string ideaDate, string workListId, BaseUserEntity crmUser)
        {
            var flag = false;
            var isLastFlow = false;      //当前流程是否为最后一步流程
            try
            {
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "立案审批":
                    case "处理审批":
                    case "结案审批":    //一般案件
                        {
                            var entity = _infPunishCaseinfoBll.Get(formId);         //案件实体
                            if (!_feProcessBll.RuleCode.ContainsKey("@DeptName"))
                            {
                                _feProcessBll.RuleCode.Add("@DeptName", entity.CompanyName);
                            }
                            _feProcessBll.Community.Add(entity.DeptId);
                            ideaTitle = "【" + entity.CaseInfoNo + "】" + flowName; //待办事事宜标题
                        }
                        break;
                }
                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideaDate;
                var note = "";      //短信内容
                if (eType.Equals("apply") || string.IsNullOrEmpty(workListId))
                {
                    //第一次进入

                    //处理审批时，增加当事人类型、处罚金额变量
                    if (flowName.Equals("处理审批"))
                    {
                        var entity = _infPunishCaseinfoBll.Get(formId);         //案件实体
                        var legislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                        if (legislations.Any())
                        {
                            _feProcessBll.RuleCode.Add("@TargetType", entity.TargetType);                           //设置当事人类型
                            _feProcessBll.RuleCode.Add("@PunishAmount", legislations[0].PunishAmount.ToString());   //设置处罚金额   
                        }
                    }

                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, crmUser.Id, formId, idea, false, "");
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(workListId))
                        {
                            isLastFlow = true;
                        }
                        flag = _feProcessBll.SendProcess(workListId, ideaTitle, crmUser.Id, formId, idea, false, "");
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        flag = _feProcessBll.ReturnProcess(workListId, ideaTitle, crmUser.Id, formId, idea, false, "");
                    }
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            if (flag)
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "立案审批":
                    case "处理审批":
                    case "结案审批":
                        _infPunishCaseinfoBll.CaseApproveReturn("", formId, flowName, isLastFlow, workListId, Convert.ToDateTime(ideaDate), eType);
                        break;
                    case "渣土许可证":
                        break;
                }

                //当前不是最后一步流程时，调取出上一步发送的信息
                if (!isLastFlow)
                {
                    var lastHandleId = _crmMessageWorkBll.GetLastWorkListID(formId);   //最后一条消息记录
                    var lastIdea = _crmIdeaListBll.GetLastFlowIdea(formId, flowName);

                    if (!string.IsNullOrEmpty(lastHandleId))
                    {
                        var receiveId = _crmMessageWorkBll.Get(lastHandleId).ActionerID;     //接收人
                        crmUser = _crmUserBll.Get(receiveId);
                        if (lastIdea != null && lastIdea.Rows.Count > 0)
                        {
                            ideaDate = lastIdea.Rows[0]["Adate"].ToString();   //获取最后一条意见的审批时间
                        }
                        //var nIdeaDate = _comHolidaysBll.GetWorkTime(Convert.ToDateTime(ideaDate), 1).ToString(AppConst.DateFormatLong);

                        //时间间隔一分钟
                        ideaDate = Convert.ToDateTime(ideaDate).AddMinutes(1).ToString(AppConst.DateFormatLong);
                        FasterApprove(formId, flowName, "agree", "同意", ideaDate, lastHandleId, crmUser);
                    }
                }
            }
            return flag;
        }

        #endregion

        #endregion

        #region 请假审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult LeaveWorkFlow(string formId, string flowName, string eType, string worklistId)
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }

        /// <summary>
        /// 请假审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult LeaveApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = new AttendanceLeaveBll().Get(formId);         //请假实体
                var roles = new CrmUserBll().GetUserRoleName(entity.UserId);   //人员对应角色信息

                var isArea = 0;  //是否是片区大队
                var userDeparment = new CrmDepartmentBll().Get(entity.DeptId);     //获取人员部门信息
                if (userDeparment != null)
                {
                    var userCompany = new CrmCompanyBll().Get(userDeparment.CompanyId);
                    //if (userCompany != null)
                    //{
                    //    isArea = userCompany.IsArea;
                    //}
                }


                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "请假审批":
                        {
                            _feProcessBll.RuleCode.Add("@CompanyId", entity.CompanyId);   //对应所属单位
                            _feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门
                            //_feProcessBll.RuleCode.Add("@RoleId", !string.IsNullOrEmpty(roleId) ? roleId : "00380001");           //对应的角色
                            _feProcessBll.RuleCode.Add("@Day", Convert.ToString(entity.LeaveTime, CultureInfo.InvariantCulture));   //设置请假天数

                            if (roles != null && roles.Rows.Count > 0)
                            {
                                _feProcessBll.RuleCode.Add("@RoleName", roles.Rows[0]["RoleName"].ToString());
                            }
                            else
                            {
                                var user = new CrmUserBll().Get(entity.UserId);
                                if (user != null)
                                {
                                    _feProcessBll.RuleCode.Add("@RoleName", user.Account.Contains("市容") ? "市容管理员" : "队员");
                                }
                            }

                            _feProcessBll.RuleCode.Add("@IsArea", isArea.ToString());   //是否是片区大队
                            _feProcessBll.Community.Add(entity.DeptId);
                            ideaTitle = "【" + entity.DeptName + "】【" + entity.UserName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的请假审批！", entity.DeptName, entity.UserName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的请假已审批通过！");

                            //针对片区大队中队长的请假审批短信抄送倪俊和高卫东
                            if (isArea == 1)
                            {
                                if (roles != null && roles.Rows.Count > 0)
                                {
                                    if (roles.Rows[0]["RoleName"].ToString().Equals("中队长"))
                                    {
                                        var copyformsg =
                                            string.Format("您有一条来自【{0}】【{1}】【{2}】请假审批抄送，请假时间自{3}至{4}，请假时长为{5}天。",
                                                          entity.CompanyName, entity.DeptName, entity.UserName,
                                                          entity.BeginTime.ToString(AppConst.DateFormatLong),
                                                          entity.EndTime.ToString(AppConst.DateFormatLong),
                                                          entity.LeaveTime);

                                        //new ComNoteBll().SendNote(AppConfig.DeputyDirector, copyformsg);
                                        new ComNoteBll().SendNote(AppConfig.Director, copyformsg);
                                    }
                                }
                            }
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的请假审批！", entity.DeptName, entity.UserName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的请假未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new AttendanceLeaveBll().LeaveApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName, isLastFlow,
                                                            worklistId, DateTime.Now);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 调班审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult AlterationWorkFlow(string formId, string flowName, string eType, string worklistId)
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }


        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AlterationApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = new FlightAlterationBll().Get(formId);         //请假实体
                //var roleId = _crmUserBll.UserRoleId(entity.UserId);
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "调班审批":
                        {
                            _feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门

                            _feProcessBll.Community.Add(entity.DeptId);
                            ideaTitle = "【" + entity.DeptName + "】【" + entity.BeforeUserName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的调班已审批通过！");
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的调班未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new FlightAlterationBll().AlterationApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName, isLastFlow,
                                                            worklistId, DateTime.Now);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 考勤申报审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult AttendanceWorkFlow(string formId, string flowName, string eType, string worklistId)
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }


        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AttendanceApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = new AttendanceReportBll().Get(formId);         //请假实体
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "考勤申报审批":
                        {
                            _feProcessBll.RuleCode.Add("@DeptId", entity.DepartmentId);     //对应的部门
                            _feProcessBll.Community.Add(entity.DepartmentId);
                            ideaTitle = "【" + entity.DepartmentName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】的月度考勤审批！", entity.DepartmentName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您申请的月度考勤已审批通过！");
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】的月度考勤审批！", entity.DepartmentName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您申请的月度考勤未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new AttendanceReportBll().AttendanceApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName,
                                                                         isLastFlow, worklistId, DateTime.Now);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 加班审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult WorkOvertimeWorkFlow(string formId, string flowName, string eType, string worklistId)
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }

        /// <summary>
        /// 加班审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult WorkOvertimeApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = new WorkOvertimeBll().Get(formId);         //加班实体

                //var roleId = _crmUserBll.UserRoleId(entity.UserId);
                var roles = new CrmUserBll().GetUserRoleName(entity.UserId);   //人员对应角色信息

                var isArea = 0;  //是否是片区大队
                var userDeparment = new CrmDepartmentBll().Get(entity.DeptId);     //获取人员部门信息
                if (userDeparment != null)
                {
                    var userCompany = new CrmCompanyBll().Get(userDeparment.CompanyId);  //获取人员所属单位
                    //if (userCompany != null)
                    //{
                    //    isArea = userCompany.IsArea;
                    //}
                }

                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "加班审批":
                        {
                            _feProcessBll.RuleCode.Add("@CompanyId", entity.CompanyId);   //对应所属单位
                            _feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门
                            //_feProcessBll.RuleCode.Add("@RoleId", !string.IsNullOrEmpty(roleId) ? roleId : "00380001");           //对应的角色
                            _feProcessBll.RuleCode.Add("@Day", Convert.ToString(entity.Overtime, CultureInfo.InvariantCulture));   //设置加班天数

                            if (roles != null && roles.Rows.Count > 0)
                            {
                                _feProcessBll.RuleCode.Add("@RoleName", roles.Rows[0]["RoleName"].ToString());
                            }
                            else
                            {
                                var user = new CrmUserBll().Get(entity.UserId);
                                if (user != null)
                                {
                                    _feProcessBll.RuleCode.Add("@RoleName", user.Account.Contains("市容") ? "市容管理员" : "队员");
                                }
                            }
                            _feProcessBll.RuleCode.Add("@IsArea", isArea.ToString());   //是否是片区大队
                            _feProcessBll.Community.Add(entity.DeptId);
                            ideaTitle = "【" + entity.DeptName + "】【" + entity.UserName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的加班审批！", entity.DeptName, entity.UserName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的加班已审批通过！");

                            //针对片区大队中队长的请假审批短信抄送倪俊和高卫东
                            if (isArea == 1)
                            {
                                if (roles != null && roles.Rows.Count > 0)
                                {
                                    if (roles.Rows[0]["RoleName"].ToString().Equals("中队长"))
                                    {
                                        var copyformsg =
                                            string.Format("您有一条来自【{0}】【{1}】【{2}】加班审批抄送，加班时间自{3}至{4}，加班时长为{5}小时。",
                                                          entity.CompanyName, entity.DeptName, entity.UserName,
                                                          entity.BeginTime.ToString(AppConst.DateFormatLong),
                                                          entity.EndTime.ToString(AppConst.DateFormatLong),
                                                          entity.Overtime);

                                        //new ComNoteBll().SendNote(AppConfig.DeputyDirector, copyformsg);
                                        new ComNoteBll().SendNote(AppConfig.Director, copyformsg);
                                    }
                                }
                            }
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的加班审批！", entity.DeptName, entity.UserName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的加班未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new WorkOvertimeBll().WorkOvertimeApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName, isLastFlow,
                                                            worklistId, DateTime.Now);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 查封审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult SealUpWorkFlow(string formId, string flowName, string eType, string worklistId)
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }

        /// <summary>
        /// 案件审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SealUpApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = _sealUpBll.Get(formId);         //加班实体
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "查封审批":
                    case "解封审批":
                        {
                            _feProcessBll.Community.Add(entity.DepartmentId);
                            ideaTitle = "【" + entity.CaseInfoNo + "】" + flowName; //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的{1}！", entity.DepartmentName, entity.TargetName, flowName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您申请的查封已审批通过！");
                            if (flowName == "解封审批")
                            {
                                note = string.Format("您申请的解封已审批通过！");
                            }
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的{1}！", entity.DepartmentName, entity.TargetName, flowName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您申请的查封未审批通过！");
                        if (flowName == "解封审批")
                        {
                            note = string.Format("您申请的解封未审批通过！");
                        }
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = _sealUpBll.SealUpApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName, isLastFlow,
                                                            worklistId, DateTime.Now);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 行政许可审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isloadOp">是否加载、保存常用意见</param>
        /// <param name="isFaster">是否一键审批</param>
        /// <returns></returns>
        public ActionResult LicenseWorkFlow(string formId, string flowName, string eType, string worklistId, string isloadOp = "1", string isFaster = "0")
        {
            //许可主键
            var licenseEntity = new LicenseMainBll().Get(formId);
            var itemCode = licenseEntity.ItemCode;

            if (itemCode.Equals("JS050800ZJ-XK-0090"))
            {
                if (licenseEntity.State == 10)
                {
                    var entity = new LicenseOutDoorBll().GetEntityByLicenseId(formId);
                    var acceptType = entity.AcceptType;
                    if (acceptType.Equals("00610001") || acceptType.Equals("00610002") || acceptType.Equals("00610003"))
                    {
                        flowName = "店招标牌批文";
                    }
                    else if (acceptType.Equals("00610003"))
                    {
                        flowName = "店招标牌发证";
                    }
                }
                else if (licenseEntity.State >= 10 && licenseEntity.State < 20)
                {
                    flowName = "店招标牌批文";
                }
                else if (licenseEntity.State >= 20 && licenseEntity.State < 30)
                {
                    flowName = "店招标牌发证";
                }
            }
            else if (itemCode.Equals("JS050800ZJ-XK-0190"))
            {
                if (licenseEntity.State == 10)
                {
                    var entity = new LicenseOutDoorBll().GetEntityByLicenseId(formId);
                    var acceptType = entity.AcceptType;
                    if (acceptType.Equals("00650001") || acceptType.Equals("00650002") || acceptType.Equals("00650003"))
                    {
                        flowName = "大型户外广告批文";
                    }
                    else if (acceptType.Equals("00650003"))
                    {
                        flowName = "大型户外广告发证";
                    }
                }
                else if (licenseEntity.State >= 10 && licenseEntity.State < 20)
                {
                    flowName = "大型户外广告批文";
                }
                else if (licenseEntity.State >= 20 && licenseEntity.State < 30)
                {
                    flowName = "大型户外广告发证";
                }
            }
            else if (itemCode.Equals("JS050800ZJ-XK-0020"))
            {
                if (licenseEntity.State == 10)
                {
                    flowName = "临时占道批文";
                }
                else if (licenseEntity.State >= 10 && licenseEntity.State < 20)
                {
                    flowName = "临时占道批文";
                }
                else if (licenseEntity.State >= 20 && licenseEntity.State < 30)
                {
                    flowName = "临时占道验收";
                }
            }

            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                var infpunishitem = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                if (infpunishitem.Any())
                {
                    ViewBag.DefaultIdea = _legislationGistBll.GetDefaultIdeal(formId, flowName, infpunishitem[0].LegislationGistId);
                }
            }

            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);
            return View();
        }


        /// <summary>
        /// 许可审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isSaveIdea">是否保存常用意见</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult LicenseApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId, string isSaveIdea)
        {

            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            var user = CurrentUser.CrmUser;
            var entity = _licenseMainBll.Get(formId);         //办件实体
            var ideaTitle = string.Empty;
            ideaTitle = "【" + entity.ApplicantName + "】" + flowName + "审批";     //待办事事宜标题
            var isSenderNote = entity.IsTest == 0;
            try
            {


                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "店招标牌批文":
                    case "店招标牌发证":
                    case "大型户外广告发证":
                    case "大型户外广告批文":
                    case "临时占道验收":
                    case "临时占道批文":
                        {
                            _feProcessBll.Community.Add(entity.Area);         //所属片区
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;


                if (!string.IsNullOrEmpty(worklistId))
                {
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (workState == 2 || workState == -1)
                    {
                        flag = false;
                        rtMsg = "该待办事宜已处理请勿点击，关闭当前界面即可！";

                        var rtEntitys = new StatusModel<DBNull>
                        {
                            rtState = flag ? 0 : -1,
                            rtMsrg = rtMsg
                        };
                        return Json(rtEntitys, JsonRequestBehavior.AllowGet);
                    }
                }

                _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                var note = "";      //短信内容
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    var isStartProcess = _feProcessBll.IsStartProcess(flowName, formId);
                    if (!isStartProcess)
                    {
                        rtMsg = "【" + flowName + "】流程发启成功！";
                        note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSenderNote, note);
                    }
                    else
                    {
                        rtMsg = "【" + flowName + "】已发启，请关闭当前界面！";
                    }
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                        }
                        else
                        {
                            note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSenderNote, note);

                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSenderNote, note);
                    }
                }
                if (isSaveIdea.Equals("1"))  //是否保存意见
                {
                    _crmOpinionsBll.SaveIdea(idea, CurrentUser.CrmUser);
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "店招标牌批文":
                    case "店招标牌发证":
                    case "大型户外广告发证":
                    case "大型户外广告批文":
                    case "临时占道验收":
                    case "临时占道批文":
                        _licenseMainBll.LicenseApproveReturn(CurrentUser.CrmUser.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                        break;
                }
                if (isSenderNote)
                {
                    new ComNoteBll().SendNoteByArea(entity, string.Format("{0}{1},快到三天期限了确认是否处理", user.UserName, ideaTitle));
                }
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 违建拆除审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isloadOp">是否加载、保存常用意见</param>
        /// <param name="isFaster">是否一键审批</param>
        /// <returns></returns>
        public ActionResult IllegalConstructionWorkFlow(string formId, string flowName, string eType, string worklistId, string isloadOp = "1", string isFaster = "0")
        {
            //许可主键
            var entity = _illegalConstructionBll.Get(formId);


            if (entity.State >= 0 && entity.State < 10)
            {
                flowName = "违法建设拆除申请";
            }
            else if (entity.State >= 10 && entity.State < 20)
            {
                flowName = "违法建设拆除结果";
            }


            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                var infpunishitem = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                if (infpunishitem.Any())
                {
                    ViewBag.DefaultIdea = _legislationGistBll.GetDefaultIdeal(formId, flowName, infpunishitem[0].LegislationGistId);
                }
            }

            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);
            return View();
        }

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isloadOp">是否加载、保存常用意见</param>
        /// <param name="isFaster">是否一键审批</param>
        /// <returns></returns>
        public ActionResult IllegalConstructionWorkFlowAndCopyLeader(string formId, string flowName, string eType, string worklistId, string isloadOp = "1", string isFaster = "0")
        {
            //许可主键
            var entity = _illegalConstructionBll.Get(formId);


            if (entity.State >= 0 && entity.State < 10)
            {
                flowName = "违法建设拆除申请";
            }
            else if (entity.State >= 10 && entity.State < 20)
            {
                flowName = "违法建设拆除结果";
            }


            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;

            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                var infpunishitem = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                if (infpunishitem.Any())
                {
                    ViewBag.DefaultIdea = _legislationGistBll.GetDefaultIdeal(formId, flowName, infpunishitem[0].LegislationGistId);
                }
            }

            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);
            return View();
        }


        /// <summary>
        /// 违建拆除审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isSaveIdea">是否保存常用意见</param>
        /// <param name="directorids">抄送局长集（使用逗号分隔）</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult IllegalConstructionApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId, string isSaveIdea, string directorids)
        {

            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            var user = CurrentUser.CrmUser;
            var entity = _illegalConstructionBll.Get(formId);         //办件实体
            var ideaTitle = string.Empty;
            ideaTitle = "【" + entity.CompanyName + "】" + flowName + "审批";     //待办事事宜标题

            try
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "违法建设拆除申请":
                    case "违法建设拆除结果":
                        {
                            _feProcessBll.Community.Add(entity.CompanyId);         //所属片区
                            _feProcessBll.Community.Add(entity.DeptId);         //所属部门
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;


                if (!string.IsNullOrEmpty(worklistId))
                {
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (workState == 2 || workState == -1)
                    {
                        flag = false;
                        rtMsg = "该待办事宜已处理请勿点击，关闭当前界面即可！";

                        var rtEntitys = new StatusModel<DBNull>
                        {
                            rtState = flag ? 0 : -1,
                            rtMsrg = rtMsg
                        };
                        return Json(rtEntitys, JsonRequestBehavior.AllowGet);
                    }
                }

                _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                var note = "";      //短信内容
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    var isStartProcess = _feProcessBll.IsStartProcess(flowName, formId);
                    if (!isStartProcess)
                    {
                        rtMsg = "【" + flowName + "】流程发启成功！";
                        note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                    else
                    {
                        rtMsg = "【" + flowName + "】已发启，请关闭当前界面！";
                    }
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                        }
                        else
                        {
                            note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);

                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
                if (isSaveIdea.Equals("1"))  //是否保存意见
                {
                    _crmOpinionsBll.SaveIdea(idea, CurrentUser.CrmUser);
                }

                #region  抄送局领导

                //抄送局长
                if (!string.IsNullOrEmpty(directorids))
                {
                    var userSplit = directorids.Split(',');
                    if (userSplit.Length > 0)
                    {
                        foreach (var userId in userSplit)
                        {
                            const string formAddress = "/IllegalConstruction/Entity";

                            var messageWorkentity = new CrmMessageWorkEntity
                            {
                                Id = Guid.NewGuid().ToString(),
                                ProcessInstanceID = "",
                                SenderID = user.Id,
                                StartDate = DateTime.Now,
                                FormID = formId,
                                FormData = "",
                                ActionerID = userId,
                                Titles = "【" + entity.CompanyName + "】违法建设审批抄送",
                                State = 0,
                                RowStatus = 1,
                                ContentTypeID = "00050015",
                                SendActivityID = "",
                                ActivityInstanceID = "",
                                CreateOn = DateTime.Now,
                                UpdateOn = DateTime.Now
                            };

                            if (formAddress != "")
                            {
                                if (formAddress.IndexOf("?", System.StringComparison.Ordinal) != -1)
                                {
                                    messageWorkentity.FormAddress = formAddress + "&worklistid=" + messageWorkentity.Id;
                                }
                                else
                                {
                                    messageWorkentity.FormAddress = formAddress + "?worklistid=" + messageWorkentity.Id;
                                }
                            }
                            new CrmMessageWorkBll().Add(messageWorkentity);
                            //执行发送短信
                            if (true)
                            {
                                var msg = string.Format("您有一条来自【" + entity.CompanyName + "】违法建设审批抄送！");
                                new ComNoteBll().SendNote(userId, msg);
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "违法建设拆除申请":
                    case "违法建设拆除结果":
                        _illegalConstructionBll.IllegalConstructionApproveReturn(CurrentUser.CrmUser.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                        break;
                }
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 信访审批

        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult PetitionWorkFlow(string formId, string flowName, string eType, string worklistId, string isloadOp = "1", string isFaster = "0")
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = "信访审批";
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;
            if (eType.Equals("apply"))  //验证,流程为申请时,加载相应的审批意见
            {
                ViewBag.DefaultIdea = "申请";
            }
            else if (eType.Equals("agree"))
            {
                ViewBag.DefaultIdea = "同意！";
            }
            else if (eType.Equals("disAgree"))
            {
                ViewBag.DefaultIdea = "不同意，理由如下：";
            }

            //案件审批时间,这里目前以当前系统时间为默认,后面需要考虑结案上一个人的审批时间等其它因素
            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);

            return View();
        }

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PetitionApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var user = CurrentUser.CrmUser;
            var isLastFlow = false;    //当前流程是否为最后一步流程
            var isSend = true;//是否发送短信
            try
            {

                var entity = new PetitionBll().Get(formId);         //信访实体              
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "信访审批":
                        {
                            _feProcessBll.RuleCode.Add("@IsLastProcess", entity.IsLastProcess.ToString());   //是否走终审
                            _feProcessBll.RuleCode.Add("@IsFZCBack", entity.IsFZCBack.ToString());   //是否走终审
                            _feProcessBll.Community.Add(entity.PetitionCompany);
                            ideaTitle = "【" + entity.PetitionCompanyName + entity.PetitionNo + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的信访审批！", user.UserName, entity.PetitionCompanyName + entity.PetitionNo);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSend, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的信访已审批通过！");
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的信访审批！", user.UserName, entity.PetitionCompanyName + entity.SourceNo);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSend, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的信访未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, isSend, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new PetitionBll().SealUpApproveReturn(eType, CurrentUser.CrmUser.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now);
                _crmOpinionsBll.SaveIdea(idea, CurrentUser.CrmUser);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        #endregion

        /// <summary>
        /// 请求常用意见
        /// </summary>
        /// <returns></returns>
        public string GetOpinions()
        {
            var data = _crmOpinionsBll.GetSearchResult(new CrmOpinionsEntity() { CreatorId = CurrentUser.CrmUser.Id });
            var result = JsonConvert.SerializeObject(data);
            return result;
        }


        #region 违建结案审批
        /// <summary>
        /// GET: /WorkFlow/
        /// </summary>
        /// <param name="formId">审批表单编号</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isloadOp">是否加载、保存常用意见</param>
        /// <param name="isFaster">是否一键审批</param>
        /// <returns></returns>
        public ActionResult IllegalWorkFlow(string formId, string flowName, string eType, string worklistId, string hidden, string VerifyId, string CASE_INFO_NO, string Long, string Width, string High, string BuildTypeId, string BuildType, string StructureId, string Structure, string Covers, string Build, string Describe, string txtVerifyTime, string IllegalState, string IllegalResult, string buildTime = "1900-01-01", string isloadOp = "1", string isFaster = "0")
        {
            ViewBag.FormId = formId;
            ViewBag.FlowName = flowName;
            ViewBag.EType = eType;
            ViewBag.WorklistId = worklistId;
            ViewBag.IsLoadOp = isloadOp;
            ViewBag.IsFaster = isFaster;
            //核实认定参数
            ViewBag.VerifyId = VerifyId;
            ViewBag.CASE_INFO_NO = CASE_INFO_NO;
            ViewBag.Long = Long;
            ViewBag.Width = Width;
            ViewBag.High = High;
            ViewBag.BuildTypeId = BuildTypeId;
            ViewBag.BuildType = BuildType;
            ViewBag.StructureId = StructureId;
            ViewBag.Structure = Structure;
            ViewBag.Covers = Covers;
            ViewBag.Build = Build;
            ViewBag.Describe = Describe;
            ViewBag.txtVerifyTime = txtVerifyTime;
            ViewBag.IllegalState = IllegalState;
            ViewBag.IllegalResult = IllegalResult;
            ViewBag.buildTime = buildTime;
            ViewBag.Hidden = hidden;

            ViewBag.IdeaDate = DateTime.Now.ToString(AppConst.DateFormatLong);
            return View();
        }

        /// <summary>
        /// 案件审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="isSaveIdea">是否保存常用意见</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult IllegalCaseApprove(string formId, string flowName, string eType, string idea, string ideadate, string worklistId, string isSaveIdea)
        {

            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {
                var user = CurrentUser.CrmUser;
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "违建结案审批":
                        {
                            var entity = new IllegalCaseInfoEntity();
                            var list = _illegalCaseInfoBll.GetIllegalCaseResult(new IllegalCaseInfoEntity() { ID = formId });//案件实体
                            if (list.Any())
                            {
                                entity = list[0];
                            }
                            _feProcessBll.Community.Add(entity.DEPT_KEY_ID);
                            if (string.IsNullOrEmpty(entity.CASE_INFO_NO))
                            {
                                ideaTitle = "【违建】" + flowName; //待办事事宜标题
                            }
                            else
                            {
                                ideaTitle = "【违建】" + flowName; //待办事事宜标题
                            }
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;


                if (!string.IsNullOrEmpty(worklistId))
                {
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (workState == 2 || workState == -1)
                    {
                        flag = false;
                        rtMsg = "该待办事宜已处理请勿点击，关闭当前界面即可！";

                        var rtEntitys = new StatusModel<DBNull>
                        {
                            rtState = flag ? 0 : -1,
                            rtMsrg = rtMsg
                        };
                        return Json(rtEntitys, JsonRequestBehavior.AllowGet);
                    }
                }

                var note = "";      //短信内容
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    var isStartProcess = _feProcessBll.IsStartProcess(flowName, formId);
                    if (!isStartProcess)
                    {
                        rtMsg = "【" + flowName + "】流程发启成功！";
                        note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                        //_crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理
                    }
                    else
                    {
                        rtMsg = "【" + flowName + "】已发启，请关闭当前界面！";
                    }
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                        }
                        else
                        {
                            note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);

                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, CurrentUser.CrmUser.Id, formId, idea, true, note);
                    }
                }
                if (isSaveIdea.Equals("1"))  //是否保存意见
                {
                    _crmOpinionsBll.SaveIdea(idea, CurrentUser.CrmUser);
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "违建结案审批":
                        _illegalCaseInfoBll.CaseApproveReturn(CurrentUser.CrmUser.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                        break;
                }
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = flag ? 0 : -1,
                rtMsrg = rtMsg
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
