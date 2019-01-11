using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Evidence;
using Yookey.WisdomClassed.SIP.Business.Evidence;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Win32;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    /// <summary>
    /// 行政处罚->案件办理
    /// </summary>
    public class PenaltyCaseController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        readonly BaseUserBll _crmUserBll = new BaseUserBll();
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();      //审批意见
        readonly InfPunishHearBll _infPunishHearBll = new InfPunishHearBll();//陈述申辩与听证
        readonly LegislationBll _legislationBll = new LegislationBll();              //法律法规-违法行为
        readonly LegislationItemBll _legislationItemBll = new LegislationItemBll();  //法律法规-适用案由
        readonly LegislationGistBll _legislationGistBll = new LegislationGistBll();  //法律法规-法律条文
        readonly LegislationRuleBll _legislationRuleBll = new LegislationRuleBll();  //法律法规-处罚标准

        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();        //案件基本信息
        readonly InfPunishLegislatioinBll _infPunishLegislatioinBll = new InfPunishLegislatioinBll();   //案件法律法规信息
        readonly ComNumberBll _comNumberBll = new ComNumberBll();          //编号
        readonly InfPunishReceiptBll _infPunishReceiptBll = new InfPunishReceiptBll();         //送达回执
        readonly InfPunishFinishBll _infPunishFinishBll = new InfPunishFinishBll();            //结案
        readonly InfPunishSurveyBll _infPunishSurveyBll = new InfPunishSurveyBll();            //调查
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll();            //证据信息


        #region 视图
        /// <summary>
        /// 处罚办案界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Punishmentcase()
        {
            return View();
        }

        public string CheckUserDriver()
        {
            string Driver = "0";

            RegistryKey hkml = Registry.ClassesRoot;
            var subkeyNames = hkml.GetSubKeyNames();

            foreach (var keyName in subkeyNames)
            {
                if (keyName == "HWCAMCTRL.HWCamCtrlCtrl.1")
                {
                    Driver = "1";
                }
            }
            return Driver;
        }

        /// <summary>
        /// GET: /PenaltyCase/Index
        /// 案件办理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string type, string companyId, string deptId)
        {
            var user = CurrentUser.CrmUser;



            ViewData["Driver"] = CheckUserDriver();

            //var casecount = _infPunishCaseinfoBll.GetCaseStateCount(companyId, deptId, user.DeptId);
            //if (casecount != null && casecount.Rows.Count > 0)
            //{
            //    //预审
            //    ViewBag.FirstTrial = casecount.Rows[0]["FirstTrial"];
            //    //待立案
            //    ViewBag.Untreated = casecount.Rows[0]["Untreated"];
            //    //待处理
            //    ViewBag.InHand = casecount.Rows[0]["InHand"];
            //    //待结案
            //    ViewBag.StayClose = casecount.Rows[0]["StayClose"];
            //    //已结案
            //    ViewBag.CloseJugee = casecount.Rows[0]["CloseJugee"];
            //    //已归档
            //    ViewBag.Archived = casecount.Rows[0]["Archived"];
            //    //全部
            //    ViewBag.All = casecount.Rows[0]["All"];
            //}

            //查询条件
            var quTypeList = EnumOperate.ConvertEnumToListItems(typeof(CaseQueryType), "0");
            ViewData["QueryTypeList"] = quTypeList;

            ViewBag.Type = type;

            return View();
        }


        /// <summary>
        /// 查询案件的状态
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="deptId">所属部门ID</param>
        /// <param name="caseType">案件类型</param>
        /// <returns></returns>
        public string GetCaseStateCount(string caseType, string companyId, string deptId)
        {
            var user = CurrentUser.CrmUser;
            var casecount = _infPunishCaseinfoBll.GetCaseStateCount(companyId, deptId, user.DeptId, caseType);
            if (casecount != null && casecount.Rows.Count > 0)
            {
                //预审
                ViewBag.FirstTrial = casecount.Rows[0]["FirstTrial"];
                //待立案
                ViewBag.Untreated = casecount.Rows[0]["Untreated"];
                //待处理
                ViewBag.InHand = casecount.Rows[0]["InHand"];
                //待结案
                ViewBag.StayClose = casecount.Rows[0]["StayClose"];
                //已结案
                ViewBag.CloseJugee = casecount.Rows[0]["CloseJugee"];
                //已归档
                ViewBag.Archived = casecount.Rows[0]["Archived"];
                //全部
                ViewBag.All = casecount.Rows[0]["All"];
            }
            string data = ViewBag.FirstTrial + "|" + ViewBag.Untreated + "|" + ViewBag.InHand + "|" + ViewBag.StayClose + "|" + ViewBag.CloseJugee + "|" + ViewBag.Archived + "|" + ViewBag.All;
            return data;
        }

        /// <summary>
        /// GET: /PenaltyCase/Main
        /// 案件主窗体
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="type">案件类别</param>
        /// <returns></returns>
        public ActionResult Main(string id, string worklistId, string type)
        {
            var caseEntity = new InfPunishCaseinfoEntity();
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id); //案件实体
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;

            //【开始】========左侧的导航和文书及右侧显示页面根据状态的不同进行判断
            //        以下是以园区项目为例
            //        不同的单位可能不同的要求,如有其它要求,在此进行判断


            //案件的状态
            var caseState = caseEntity != null ? caseEntity.State : 0;
            var punishProcess = caseEntity != null ? caseEntity.PunishProcess : "";

            #region 默认右侧界面

            var defaultPage = "CaseEntity";

            if (!punishProcess.Equals("00280001"))   //案件类型不是简易
            {
                if (caseState > 10 && caseState < 30)           //立案
                {
                    defaultPage = "CaseFiled";
                }
                else if (caseState >= 30 && caseState < 40)    //调查
                {
                    defaultPage = "CaseInvestigation";
                }
                else if (caseState >= 40 && caseState <= 50)   //处理审批
                {
                    defaultPage = "CaseDealWith";
                }
                else if (caseState >= 50 && caseState < 70)    //陈述申辩与听证
                {
                    defaultPage = "CaseCT";
                }
                else if (caseState >= 70 && caseState < 80)    //行政处罚决定书
                {
                    defaultPage = "CaseDecision";
                }
                else if (caseState >= 80 && caseState < 90)    //结案审批
                {
                    defaultPage = "CaseEnd";
                }
                else if (caseState >= 90)                      //归档
                {
                    defaultPage = "CaseArchive";
                }
            }
            ViewBag.DefaultPage = defaultPage;

            #endregion

            //【结束】========左侧的导航和文书及右侧显示页面根据状态的不同进行判断
            //        以上是以园区项目为例
            //        不同的单位可能不同的要求,如有其它要求,在此进行判断

            ViewBag.CaseState = caseState;
            ViewBag.Type = type;

            #region 是否显示申述申辩听证文书
            ViewBag.PleadHear = false;
            ViewBag.Plead = false;
            var hearcaseEntity = _infPunishHearBll.GetHearEntity(id);
            if (hearcaseEntity != null)
            {
                if ((hearcaseEntity.ApplyType == 1 || hearcaseEntity.ApplyType == 2))
                {
                    ViewBag.PleadHear = true;
                    if ((hearcaseEntity.ApplyType == 1))
                    {
                        ViewBag.Plead = true;
                    }
                }
            }
            #endregion

            return View(caseEntity);
        }


        /// <summary>
        /// GET: /PenaltyCase/Main
        /// 案件主窗体（小额类案件）
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="type">案件类别</param>
        /// <returns></returns>
        public ActionResult SimpleMain(string id, string worklistId, string type)
        {
            var caseEntity = new InfPunishCaseinfoEntity();
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id); //案件实体
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;

            //【开始】========左侧的导航和文书及右侧显示页面根据状态的不同进行判断
            //        以下是以园区项目为例
            //        不同的单位可能不同的要求,如有其它要求,在此进行判断


            //案件的状态
            var caseState = caseEntity != null ? caseEntity.State : 0;
            var punishProcess = caseEntity != null ? caseEntity.PunishProcess : "";

            #region 默认右侧界面

            var defaultPage = "SimpleCaseEntity";

            if (!punishProcess.Equals("00280001"))   //案件类型不是简易
            {
                if (caseState >= 20 && caseState < 30)           //立案
                {
                    defaultPage = "CaseFiled";
                }
                else if (caseState >= 30 && caseState < 40)    //调查
                {
                    defaultPage = "CaseInvestigation";
                }
                else if (caseState >= 40 && caseState <= 50)   //处理审批
                {
                    defaultPage = "CaseDealWith";
                }
                else if (caseState >= 50 && caseState < 70)    //陈述申辩与听证
                {
                    defaultPage = "CaseCT";
                }
                else if (caseState >= 70 && caseState < 80)    //行政处罚决定书
                {
                    defaultPage = "CaseDecision";
                }
                else if (caseState >= 80 && caseState < 90)    //结案审批
                {
                    defaultPage = "CaseEnd";
                }
                else if (caseState >= 90)                      //归档
                {
                    defaultPage = "CaseArchive";
                }
            }
            ViewBag.DefaultPage = defaultPage;

            #endregion

            //【结束】========左侧的导航和文书及右侧显示页面根据状态的不同进行判断
            //        以上是以园区项目为例
            //        不同的单位可能不同的要求,如有其它要求,在此进行判断

            ViewBag.CaseState = caseState;
            ViewBag.Type = type;

            return View(caseEntity);
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseEntity
        /// 案件基本信息
        /// </summary>
        /// <param name="id">案件ID</param>
        /// <param name="worklistId">worklistId</param>
        /// <param name="type">案件类别</param>
        /// <returns></returns>
        public ActionResult CaseEntity(string id, string worklistId, string type)
        {
            var user = CurrentUser.CrmUser;
            var caseEntity = new InfPunishCaseinfoEntity();
            //var punishItem = new InfPunishItemEntity();
            var punishLegislationEntity = new InfPunishLegislationEntity();
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id); //案件实体
                type = caseEntity.CaseType;
                var punishLegislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    punishLegislationEntity = punishLegislations[0];

                    ViewBag.ClassNo = punishLegislationEntity.ClassNo;
                    ViewBag.LegislationId = punishLegislationEntity.LegislationId;
                    ViewBag.LegislationItemId = punishLegislationEntity.LegislationItemId;
                    ViewBag.LegislationGistId = punishLegislationEntity.LegislationGistId;
                }
            }
            else
            {

                //默认当前部门
                caseEntity.DeptId = (string.IsNullOrEmpty(caseEntity.DeptId) ? user.DeptId : caseEntity.DeptId);
                caseEntity.CaseDate = DateTime.Now;
                caseEntity.Id = Guid.NewGuid().ToString();  //案件主键
            }

            #region 验证按钮权限

            //保存
            bool btnSave = false, btnNext = false, btnApply = false, btnAgree = false;
            var caseState = caseEntity.State;
            var punishProcess = caseEntity.PunishProcess;

            //表示简易类型的案件
            if (punishProcess.Equals("00280001") && caseState == 80)
            {

            }
            else
            {
                //待做：这里需要验证是否有处理的权限
                if (caseState == 0)
                {
                    btnSave = true;
                    btnApply = true;
                }

                if (string.IsNullOrEmpty(worklistId))
                {
                    worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
                }

                if (!string.IsNullOrEmpty(worklistId) && caseState > 0 && caseState < 10)
                {
                    btnAgree = true;     //预审通过
                }
                if (caseState == 10)
                {
                    btnSave = true;
                    btnNext = true;
                }
            }
            ViewBag.BtnSave = btnSave;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnNext = btnNext;
            #endregion

            #region 默认值
            //案件来源
            ViewData["Sources"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0010" });

            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            //两个执法人员
            var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = caseEntity.DeptId }).ToList();
            users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });

            if (!string.IsNullOrEmpty(type))
            {
                #region 过滤

                if (type.Equals("00950001"))  //城市管理
                {
                    classNos = classNos.Where(x => x.Id == "00090001" || x.Id == "00090002" || x.Id == "00090003" || x.Id == "00090004" || x.Id == "00090005" || x.Id == "00090006" || x.Id == "00090007" || x.Id == "00090008").ToList();
                }
                else if (type.Equals("00950002"))  //国土监察
                {
                    classNos = classNos.Where(x => x.Id == "00090013").ToList();
                }
                else if (type.Equals("00950003"))  //安全生产
                {
                    classNos = classNos.Where(x => x.Id == "00090019").ToList();
                }
                else if (type.Equals("00950004"))  //海洋渔政
                {
                    classNos = classNos.Where(x => x.Id == "00090015").ToList();
                }
                else if (type.Equals("00950005"))  //水利
                {
                    classNos = classNos.Where(x => x.Id == "00090014").ToList();
                }
                else if (type.Equals("00950006"))  //规划
                {
                    classNos = classNos.Where(x => x.Id == "00090010").ToList();
                }
                else if (type.Equals("00950007"))  //建设
                {
                    classNos = classNos.Where(x => x.Id == "00090012").ToList();
                }
                else if (type.Equals("00950008"))  //房产
                {
                    classNos = classNos.Where(x => x.Id == "00090018").ToList();
                }
                else if (type.Equals("00950009"))  //物业
                {
                    classNos = classNos.Where(x => x.Id == "00090016").ToList();
                }
                else if (type.Equals("00950010"))  //燃气
                {
                    classNos = classNos.Where(x => x.Id == "00090011").ToList();
                }
                else if (type.Equals("00950011"))  //园林
                {
                    classNos = classNos.Where(x => x.Id == "00090017").ToList();
                }
                else if (type.Equals("00950012"))  //供水排水
                {
                    classNos = classNos.Where(x => x.Id == "00090020").ToList();
                }

                #endregion
            }

            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");
            
            //证据类别
            ViewData["Evidences"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });
            
            //判断案件是简易案件
            if (caseEntity.PunishProcess.Equals("00280001") && caseEntity.State == 90)
            {
                var finishs = _infPunishFinishBll.GetSearchResult(new InfPunishFinishEntity { CaseInfoId = id });  //结案信息
                var finnishEntity = new InfPunishFinishEntity();
                if (finishs.Any())
                {
                    finnishEntity = finishs[0];
                    ViewBag.PaymentType = finnishEntity.PaymentType; //缴纳方式
                    ViewBag.PaymentNum = finnishEntity.PaymentNum; //票据号
                }
                else
                {
                    finnishEntity.PaymentType = "00220002";
                }

                //缴款方式
                var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" }).ToList();
                paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey", finnishEntity.PaymentType);

                ViewBag.PunishType = punishLegislationEntity.PunishType;             //处罚方式
                ViewBag.PunishAmount = punishLegislationEntity.PunishAmount;         //处罚金额
                ViewBag.ForfeitureAmount = punishLegislationEntity.ForfeitureAmount; //没收金额
            }

            #endregion

            ViewBag.Id = id;
            ViewBag.worklistId = worklistId;
            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "案件预审", "reper");
            //if (caseEntity.CreatorId == CurrentUser.CrmUser.Id)
            //{

            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "案件预审", "", 1);

            //}

            //ViewData["FlowIdea"] = _crmIdeaListBll.GetPunishCaseFirstTrialIdea(id);




            return View(caseEntity);
        }


        /// <summary>
        /// GET: /PenaltyCase/CaseEntity
        /// 案件基本信息
        /// </summary>
        /// <param name="id">案件ID</param>
        /// <returns></returns>
        public ActionResult SimpleCaseEntity(string id,string type)
        {
            var user = CurrentUser.CrmUser;
            var caseEntity = new InfPunishCaseinfoEntity();
            //var punishItem = new InfPunishItemEntity();
            var punishLegislationEntity = new InfPunishLegislationEntity();
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id); //案件实体
                type = caseEntity.CaseType;
                var punishLegislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    punishLegislationEntity = punishLegislations[0];

                    ViewBag.ClassNo = punishLegislationEntity.ClassNo;
                    ViewBag.LegislationId = punishLegislationEntity.LegislationId;
                    ViewBag.LegislationItemId = punishLegislationEntity.LegislationItemId;
                    ViewBag.LegislationGistId = punishLegislationEntity.LegislationGistId;
                }
            }
            else
            {

                //默认当前部门
                caseEntity.DeptId = (string.IsNullOrEmpty(caseEntity.DeptId) ? user.DeptId : caseEntity.DeptId);
                caseEntity.CaseDate = DateTime.Now;
                caseEntity.Id = Guid.NewGuid().ToString();  //案件主键
            }

            #region 验证按钮权限
            ViewBag.BtnSave = true;
            #endregion

            #region 默认值
            //案件来源
            ViewData["Sources"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0010" });

            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            //两个执法人员
            var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = caseEntity.DeptId }).ToList();
            users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });

            if (!string.IsNullOrEmpty(type))
            {
                #region 过滤

                if (type.Equals("00950001"))  //城市管理
                {
                    classNos = classNos.Where(x => x.Id == "00090001" || x.Id == "00090002" || x.Id == "00090003" || x.Id == "00090004" || x.Id == "00090005" || x.Id == "00090006" || x.Id == "00090007" || x.Id == "00090008").ToList();
                }
                else if (type.Equals("00950002"))  //国土监察
                {
                    classNos = classNos.Where(x => x.Id == "00090013").ToList();
                }
                else if (type.Equals("00950003"))  //安全生产
                {
                    classNos = classNos.Where(x => x.Id == "00090019").ToList();
                }
                else if (type.Equals("00950004"))  //海洋渔政
                {
                    classNos = classNos.Where(x => x.Id == "00090015").ToList();
                }
                else if (type.Equals("00950005"))  //水利
                {
                    classNos = classNos.Where(x => x.Id == "00090014").ToList();
                }
                else if (type.Equals("00950006"))  //规划
                {
                    classNos = classNos.Where(x => x.Id == "00090010").ToList();
                }
                else if (type.Equals("00950007"))  //建设
                {
                    classNos = classNos.Where(x => x.Id == "00090012").ToList();
                }
                else if (type.Equals("00950008"))  //房产
                {
                    classNos = classNos.Where(x => x.Id == "00090018").ToList();
                }
                else if (type.Equals("00950009"))  //物业
                {
                    classNos = classNos.Where(x => x.Id == "00090016").ToList();
                }
                else if (type.Equals("00950010"))  //燃气
                {
                    classNos = classNos.Where(x => x.Id == "00090011").ToList();
                }
                else if (type.Equals("00950011"))  //园林
                {
                    classNos = classNos.Where(x => x.Id == "00090017").ToList();
                }
                else if (type.Equals("00950012"))  //供水排水
                {
                    classNos = classNos.Where(x => x.Id == "00090020").ToList();
                }

                #endregion
            }

            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            //证据类别
            ViewData["Evidences"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });


            //案件类型
            var processType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0028" }).ToList();

            processType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ProcessType"] = new SelectList(processType, "Id", "RsKey");

            //证据类别
            ViewData["Evidences"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });

            //缴款方式
            var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" }).ToList();
            paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey", "00220002");

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// 案件预审
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseFirstTrial(string id)
        {
            ViewBag.FormId = id;
            return View();
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseHandle
        /// 案件处理
        /// </summary>
        /// <param name="id">案件ID</param>
        /// <returns></returns>
        public ActionResult CaseHandle(string id)
        {
            var caseEntity = new InfPunishCaseinfoEntity();
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Id = id;
                caseEntity = _infPunishCaseinfoBll.Get(id); //案件实体
            }

            ViewData["Driver"] = CheckUserDriver();

            #region 一键审批限定

            ViewBag.FastApprove = true;
            
            ////一键审批限定值
            //var itemList = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0049" }).ToList();
            //var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
            //if (punishItems.Any())
            //{
            //    foreach (var item in itemList)
            //    {
            //        if (item.RsKey == punishItems[0].ItemNo)
            //        {
            //            ViewBag.FastApprove = true;
            //            break;
            //        }
            //    }
            //}

            #endregion

            #region 默认值

            //案件类型
            var processType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0028" }).ToList();

            processType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ProcessType"] = new SelectList(processType, "Id", "RsKey");

            if (string.IsNullOrEmpty(caseEntity.UdPersonelIdFirst))
            {
                caseEntity.UdPersonelIdFirst = _crmUserBll.GetUserByUserName(AppConfig.UdPersonalFirst).Id;
            }

            //两个承办人
            //var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = AppConfig.AcceptCenterId }).ToList();

            var users = new CrmUserBll().GetUserList(new CrmUserEntity() { DepartmentId = caseEntity.DeptId, IsCityManager = "0" }).ToList();
            users.Insert(0, new CrmUserEntity { Id = "", RealName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "RealName");

            if (string.IsNullOrEmpty(caseEntity.UdPersonelNameSecond))
            {
                caseEntity.UdPersonelIdSecond = _crmUserBll.GetUserByUserName(AppConfig.UdPersonalSecond).Id;
            }

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey");

            //证据类别
            ViewData["Evidences"] = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });

            //缴款方式
            var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" }).ToList();
            paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey", "00220002");

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseFiled
        /// 立案审批
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult CaseFiled(string id, string worklistId)
        {
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                }
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "立案审批", "reper");
            //if (caseEntity.CreatorId == CurrentUser.CrmUser.Id)
            //{
            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "立案审批", "", 1);
            //}

            #region 验证按钮权限

            bool btnApply = false, btnFastApply = false;  //审批权限，一键审批权限

            if (!string.IsNullOrEmpty(worklistId))
            {
                var caseState = caseEntity.State;
                if (caseState == 10)
                {
                    btnFastApply = true;
                }
                if (caseState > 10 && caseState < 30)
                {
                    btnApply = true;
                }
            }
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnFastApply = btnFastApply;

            #endregion

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseInvestigation
        /// 调查取证
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseInvestigation(string id, string worklistId)
        {
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                }
                ViewData["Survey"] = _infPunishSurveyBll.GetSearchResult(new InfPunishSurveyEntity { CaseInfoId = id });
            }

            var recordList = new InfPunishRecordBll().GetSearchResult(new InfPunishRecordEntity { CaseInfoId = id });
            if (recordList.Count > 0)
            {
                ViewBag.IsExist = true;
            }
            else
            {
                ViewBag.IsExist = false;
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;

            #region 验证按钮权限

            bool btnNext = false, btnGenerate = false, btnAdd = false;  //下一步，生成调查询问笔录、添加调查

            var caseState = caseEntity.State;
            if (caseState >= 30 && caseState < 40)
            {
                if (!string.IsNullOrEmpty(worklistId))
                {
                    btnNext = true;
                }
                btnGenerate = true;
                btnAdd = true;
            }

            ViewBag.BtnNext = btnNext;
            ViewBag.BtnGenerate = btnGenerate;
            ViewBag.BtnAdd = btnAdd;

            #endregion

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseAddSurvey
        /// 添加调查
        /// </summary>
        /// <param name="caseinfodId">案件编号</param>
        /// <param name="surveyId">调查编号</param>
        /// <returns></returns>
        public ActionResult CaseAddSurvey(string caseinfodId, string surveyId)
        {
            var entity = new InfPunishSurveyEntity();
            if (!string.IsNullOrEmpty(surveyId))
            {
                entity = _infPunishSurveyBll.Get(surveyId);
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.SurveyOjbect = "";
                entity.SurveyDesc = "";
            }

            entity.CaseInfoId = caseinfodId;
            return View(entity);
        }

        /// <summary>
        /// GET: /PenaltyCase/CaseDealWith
        /// 处理审批
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult CaseDealWith(string id, string worklistId)
        {
            var user = CurrentUser.CrmUser;

            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];

                    #region 一键审批限定

                    ViewBag.FastApprove = true;
                    //var itemList = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0049" }).ToList();
                    //foreach (var item in itemList)
                    //{
                    //    if (item.RsKey == punishItem.ItemNo)
                    //    {
                    //        ViewBag.FastApprove = true;
                    //        break;
                    //    }
                    //}
                    #endregion
                }
            }

            ////如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            //if (string.IsNullOrEmpty(worklistId))
            //{
            worklistId = _crmMessageWorkBll.GetUnHandleMessageId(user.Id, id);
            //}

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;
            ViewData["PunishRule"] = _legislationRuleBll.GetSearchResult(new LegislationRuleEntity() { LegislationId = punishItem.LegislationId });
            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "处理审批", "reper");
            //if (caseEntity.CreatorId == CurrentUser.CrmUser.Id)
            //{

            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "处理审批", "", 1);

            //}

            #region 验证按钮权限

            bool btnSave = false,
                 btnApply = false,
                 btnAgree = false,
                 btnDisAgree = false,
                 btnGenGz = false,
                 btnNext = false;

            var caseState = caseEntity.State;

            if (!string.IsNullOrEmpty(worklistId))
            {
                if (caseState == 40)
                {
                    //待做：这里需要结合权限
                    btnSave = true;
                    btnApply = true;
                }
                else if (caseState > 40 && caseState < 50)
                {
                    btnAgree = true;
                    btnDisAgree = true;
                }
                else if (caseState == 50)
                {
                    btnGenGz = true;
                    btnNext = true;
                }
            }

            if (caseState >= 50 && (caseEntity.UdPersonelIdFirst == user.Id || caseEntity.UdPersonelIdSecond == user.Id || caseEntity.RePersonelIdFist == user.Id || caseEntity.RePersonelIdSecond == user.Id))   //承办人随时可以生成“告知书”
            {
                btnGenGz = true;
            }
            else
            {
                var turnHandle = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PenaltyCase", "TurnHandle");

                //有权限的可以随时修改文书
                if (caseState >= 50 && turnHandle)
                {
                    btnSave = true;
                    btnGenGz = true;
                }
                if (caseState == 50 && turnHandle)
                {
                    btnNext = true;
                }
            }

            ViewBag.BtnSave = btnSave;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnDisAgree = btnDisAgree;
            ViewBag.BtnGenGz = btnGenGz;
            ViewBag.BtnNext = btnNext;

            #endregion

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //加载送达回执项
            if (caseEntity.State >= 40)
            {
                var receipts = _infPunishReceiptBll.GetSearchResult(new InfPunishReceiptEntity { CaseInfoId = id, ServiceType = 1 });

                string sendType = "00290001", personIdFirst = caseEntity.RePersonelIdFist, personIdSecond = caseEntity.RePersonelIdSecond;
                if (receipts.Any())
                {
                    sendType = receipts[0].ReceiptType;
                    personIdFirst = receipts[0].ReceiptPersonIdFirst;
                    personIdSecond = receipts[0].ReceiptPersonIdSecond;
                    ViewBag.SigninPerson = receipts[0].SigninPerson;
                    ViewBag.SinginDate = receipts[0].SinginDate;

                }
                else
                {
                    ViewBag.SigninPerson = caseEntity.TargetName;
                    ViewBag.SinginDate = DateTime.Now;
                }
                //两个执法人员
                var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = caseEntity.DeptId }).ToList();
                users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
                ViewData["Users"] = new SelectList(users, "Id", "UserName", personIdFirst);
                ViewData["UsersSecond"] = new SelectList(users, "Id", "UserName", personIdSecond);

                //送达方式
                var sendTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0029" }).ToList();
                sendTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                ViewData["SendTypes"] = new SelectList(sendTypes, "Id", "RsKey", sendType);
            }


            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// 陈述申辨与听证
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult CaseCT(string id, string worklistId)
        {
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                }
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;

            ViewData["PunishRule"] = _legislationRuleBll.GetSearchResult(new LegislationRuleEntity() { LegislationId = punishItem.LegislationId });

            var BtnApply = false;
            var BtnNext = false;

            if (caseEntity.State == 60)
            {
                BtnNext = true;
            }
            var hearcaseEntity = _infPunishHearBll.GetHearEntity(id);

            if (hearcaseEntity != null)
            {
                ViewBag.hearEntity = hearcaseEntity;
                if ((hearcaseEntity.ApplyType == 1 || hearcaseEntity.ApplyType == 2) && caseEntity.State > 60 && caseEntity.State < 70)
                {
                    BtnApply = true;
                }
            }
            ViewBag.BtnApply = BtnApply;
            ViewBag.BtnNext = BtnNext;

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "陈述申辩与听证", "reper");

            //if (caseEntity.CreatorId == CurrentUser.CrmUser.Id)
            //{

            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "陈述申辩与听证", "", 1);

            //}
            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// 行政处罚决定书
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult CaseDecision(string id, string worklistId)
        {
            var user = CurrentUser.CrmUser;    //当前登录用户信息

            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                }
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(user.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;

            ViewData["PunishRule"] = _legislationRuleBll.GetSearchResult(new LegislationRuleEntity() { LegislationId = punishItem.LegislationId });

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //加载送达回执项
            if (caseEntity.State >= 50)
            {
                //两个执法人员
                var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = caseEntity.DeptId }).ToList();
                users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
                ViewData["Users"] = new SelectList(users, "Id", "UserName");

                //送达方式
                var sendType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0029" }).ToList();
                sendType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                ViewData["SendTypes"] = new SelectList(sendType, "Id", "RsKey");
            }

            #endregion

            //加载送达回执项
            if (caseEntity.State >= 50)
            {
                var receipts = _infPunishReceiptBll.GetSearchResult(new InfPunishReceiptEntity { CaseInfoId = id, ServiceType = 2 });

                string sendType = "00290001", personIdFirst = caseEntity.RePersonelIdFist, personIdSecond = caseEntity.RePersonelIdSecond;
                if (receipts.Any())
                {
                    sendType = receipts[0].ReceiptType;
                    personIdFirst = receipts[0].ReceiptPersonIdFirst;
                    personIdSecond = receipts[0].ReceiptPersonIdSecond;
                    ViewBag.SigninPerson = receipts[0].SigninPerson;
                    ViewBag.SinginDate = receipts[0].SinginDate;
                }
                else
                {
                    ViewBag.SigninPerson = caseEntity.TargetName;
                    ViewBag.SinginDate = DateTime.Now;
                }
                //两个执法人员
                var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = caseEntity.DeptId }).ToList();
                users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
                ViewData["Users"] = new SelectList(users, "Id", "UserName", personIdFirst);
                ViewData["UsersSecond"] = new SelectList(users, "Id", "UserName", personIdSecond);

                //送达方式
                var sendTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0029" }).ToList();
                sendTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                ViewData["SendTypes"] = new SelectList(sendTypes, "Id", "RsKey", sendType);
            }



            #region 验证按钮权限

            bool btnGenGz = false,
                 btnNext = false;

            var caseState = caseEntity.State;

            if (!string.IsNullOrEmpty(worklistId))
            {
                if (caseState == 70)
                {
                    btnGenGz = true;
                    btnNext = true;
                }
            }

            if (caseState >= 70 && (caseEntity.UdPersonelIdFirst == user.Id || caseEntity.UdPersonelIdSecond == user.Id || caseEntity.RePersonelIdFist == user.Id || caseEntity.RePersonelIdSecond == user.Id))
            {
                btnGenGz = true;
            }
            else
            {
                var turnHandle = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PenaltyCase", "TurnHandle");

                //有权限的可以随时修改文书
                if (caseState >= 70 && turnHandle)
                {
                    btnGenGz = true;
                }
                if (caseState == 70 && turnHandle)
                {
                    btnNext = true;
                }
            }

            ViewBag.BtnGenGz = btnGenGz;
            ViewBag.BtnNext = btnNext;

            #endregion


            return View(caseEntity);
        }

        /// <summary>
        /// 案件结案
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult CaseEnd(string id, string worklistId)
        {
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规
            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                    #region 一键审批限定

                    ViewBag.FastApprove = false;
                    var itemList = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0049" }).ToList();
                    foreach (var item in itemList)
                    {
                        if (item.RsKey == punishItem.ItemNo)
                        {
                            ViewBag.FastApprove = true;
                            break;
                        }
                    }
                    #endregion
                }
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            ViewBag.PunishItem = punishItem;

            ViewData["PunishRule"] = _legislationRuleBll.GetSearchResult(new LegislationRuleEntity() { LegislationId = punishItem.LegislationId });
            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "结案审批", "reper");

            //if (caseEntity.CreatorId == CurrentUser.CrmUser.Id)
            //{

            ViewData["UNFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "结案审批", "", 1);

            //}

            #region 验证按钮权限

            bool btnSave = false,
                 btnApply = false,
                 btnAgree = false,
                 btnDisAgree = false;

            var caseState = caseEntity.State;
            if (!string.IsNullOrEmpty(worklistId))
            {
                if (caseState == 80)
                {
                    //待做：这里需要验证权限
                    btnSave = true;
                    btnApply = true;
                }
                else if (caseState > 80 && caseState < 90)
                {
                    //待做：这里需要结合消息意见
                    btnAgree = true;
                    btnDisAgree = true;
                }
            }
            else
            {
                if (caseState == 80 && new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PenaltyCase", "TurnHandle"))
                {
                    btnSave = true;
                    //btnApply = true;
                }
            }
            ViewBag.BtnSave = btnSave;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnDisAgree = btnDisAgree;

            #endregion

            #region 默认值

            var finishs = _infPunishFinishBll.GetSearchResult(new InfPunishFinishEntity { CaseInfoId = id });  //结案信息
            string punishContent = "", executeDesc = "", paymentType = "00220002", paymentNum = "", reformDesc = "", remark = "";
            if (finishs.Any())
            {
                InfPunishFinishEntity finishEntity = finishs[0];
                punishContent = finishEntity.PunishContent;
                executeDesc = finishEntity.ExecuteDesc;
                paymentType = finishEntity.PaymentType;
                paymentNum = finishEntity.PaymentNum;
                reformDesc = finishEntity.ReformDesc;
                remark = finishEntity.Remark;
            }
            else
            {
                var punishItemEntity = _legislationGistBll.Get(punishItem.LegislationGistId);
                if (punishItemEntity != null)
                {
                    //处理情况
                    punishContent = punishItemEntity.EndPunishments;
                    //替换当事人名称
                    if (punishContent.Contains("${TargetName}"))
                    {
                        punishContent = punishContent.Replace("${TargetName}", caseEntity.TargetName);
                    }
                    //替换罚款金额
                    if (punishContent.Contains("${Money}"))
                    {
                        punishContent = punishContent.Replace("${Money}", CommonMethod.MoneyToUpper(punishItem.PunishAmount.ToString(CultureInfo.InvariantCulture)));
                    }
                    //执行情况
                    executeDesc = punishItemEntity.EndExecute;
                }
                reformDesc = "已整改";
            }
            ViewBag.PunishContent = punishContent;
            ViewBag.ExecuteDesc = executeDesc;
            ViewBag.PaymentNum = paymentNum;
            ViewBag.ReformDesc = reformDesc;
            ViewBag.Remark = remark;

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //缴款方式
            var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" }).ToList();
            paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey", paymentType);

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// 案件归档
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worklistId"></param>
        /// <returns></returns>
        public ActionResult CaseArchive(string id, string worklistId)
        {
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            var punishItem = new InfPunishLegislationEntity();     //法律法规

            if (!string.IsNullOrEmpty(id))
            {
                caseEntity = _infPunishCaseinfoBll.Get(id);
                var punishItems = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishItems.Any())
                {
                    punishItem = punishItems[0];
                }
            }

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = _crmMessageWorkBll.GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            ViewBag.Id = id;
            ViewBag.WorkListId = worklistId;
            //ViewBag.PunishItem = punishItem;

            ViewBag.Money = punishItem.PunishAmount + "元";

            #region 默认值
            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");
            #endregion

            #region 验证按钮权限

            bool btnArchive = false;


            var caseState = caseEntity.State;
            if (caseState == 90)
            {
                //待做：这里需要验证权限
                btnArchive = true;
            }

            ViewBag.BtnArchive = btnArchive;

            #endregion

            return View(caseEntity);
        }

        /// <summary>
        /// 案件走到哪儿
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CaseFlow(string id)
        {
            var data = _crmMessageWorkBll.GetCaseFlow(id);
            ViewData["Flow"] = data;
            return View();
        }


        /// <summary>
        /// 生成调查询问笔录
        /// </summary>
        /// <returns></returns>
        public ActionResult WritSurvey(string id)
        {
            var entity = new InfPunishRecordEntity();
            var caseEntity = new InfPunishCaseinfoEntity(); //案件实体
            if (!string.IsNullOrEmpty(id))
            {
                entity = new InfPunishRecordBll().GetRecord(id);
                caseEntity = _infPunishCaseinfoBll.Get(entity.CaseInfoId);
            }
            ViewBag.CaseEntity = caseEntity;
            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey");

            return View(entity);
        }

        /// <summary>
        /// 生成决定书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WritDescsion(string id)
        {
            var entity = new InfPunishDecisionEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = new InfPunishDecisionBll().GetDescsion(id);
            }
            return View(entity);
        }

        /// <summary>
        /// 生成告知书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WritNotification(string id)
        {
            var entity = new InfPunishInformEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = new InfPunishInformBll().GetInform(id);
            }
            return View(entity);
        }

        /// <summary>
        /// 打印预览照片
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID</param>
        /// <returns>ActionResult.</returns>
        public ActionResult FilePrintView(string fileId)
        {
            var dt = _infPunishCaseinfoBll.QueryPhotoDetails(fileId);
            var fileView = "";
            var itemName = "";
            var shootAddress = "";
            var shootTime = "";
            var shootPersoneNameFirst = "";
            var shootPersoneNameSecond = "";
            if (dt != null)
            {
                itemName = dt.Rows[0]["ItemName"].ToString();
                shootAddress = dt.Rows[0]["CaseAddress"].ToString();
                shootPersoneNameFirst = dt.Rows[0]["RePersonelNameFist"].ToString();
                shootPersoneNameSecond = dt.Rows[0]["RePersonelNameSecond"].ToString();
                shootTime = Convert.ToDateTime(dt.Rows[0]["ShootTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                fileView = AppConfig.FileViewLink + dt.Rows[0]["ImgAddress"];
            }
            ViewBag.FileView = fileView;
            ViewBag.FileId = fileId;
            ViewBag.ItemName = itemName;
            ViewBag.ShootAddress = shootAddress;
            ViewBag.ShootTime = shootTime;
            ViewBag.ShootPersoneNameFirst = shootPersoneNameFirst;
            ViewBag.ShootPersoneNameSecond = shootPersoneNameSecond;
            return View();
        }

        /// <summary>
        /// 双公示-行政处罚
        /// </summary>
        /// <returns></returns>
        public ActionResult CreditIndex()
        {
            return View();
        }


        #endregion  视图
    }
}