using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Approval;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Approval;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.H5
{
    public class MobileController : Controller
    {
        //
        // GET: /Mobile/
        private readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();         //一般案件基本信息
        private readonly InfPunishLegislatioinBll _infPunishLegislatioinBll = new InfPunishLegislatioinBll();   //案件法律法规
        private readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll(); //附件材料
        private readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();//消息（待办）
        private readonly WfProcessBll _wfProcessBll = new WfProcessBll();
        private readonly WfProcessInstanceBll _wfProcessInstanceBll = new WfProcessInstanceBll();
        private readonly CrmUserBll _crmUserBll = new CrmUserBll();
        //法律法规
        private readonly LegislationItemBll _legislationItem = new LegislationItemBll();
        private readonly LegislationGistBll _legislationGistBll = new LegislationGistBll();
        private readonly LegislationRuleBll _legislationRule = new LegislationRuleBll();
        private readonly LegislationBll _legislationBll = new LegislationBll();
        //审批事项
        private readonly TmEnterpriseBll _tmEnterpriseBll = new TmEnterpriseBll();
        private readonly TmMatterApplyMajorBll _tmMatterApplyMajorBll = new TmMatterApplyMajorBll();
        private readonly TmMatterBll _tmMatterBll = new TmMatterBll();
        //户外广告
        private readonly TmMatterApplyHWGGBll _tmMatterApplyHWGGBll = new TmMatterApplyHWGGBll();
        private readonly TmMatterApplyHWGGDetailBll _tmMatterApplyHWGGDetailBll = new TmMatterApplyHWGGDetailBll();
        //渣土运输
        private readonly TmMatterApplyZTYSBll _tmMatterApplyZTYSBll = new TmMatterApplyZTYSBll();
        private readonly TmMatterApplyZTYSVehicleBll _tmMatterApplyZTYSVehicleBll = new TmMatterApplyZTYSVehicleBll();
        //占用挖掘
        private readonly TmMatteApplyZYWJBll _tmMatteApplyZYWJBll = new TmMatteApplyZYWJBll();
        //证件
        private readonly TmMatterApplyCertificateBll _TmMatterApplyCertificateBll = new TmMatterApplyCertificateBll();
        //附件
        private readonly TcAttachMentBll _tcAttachMentDal = new TcAttachMentBll();
        private readonly TcAttachMentRefBll _tcAttachMentRefBll = new TcAttachMentRefBll();
        //字典
        private readonly TcDictionaryDataBll _tcDictionaryDataBll = new TcDictionaryDataBll();

        /// <summary>
        /// 案件管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseManagementIndex()
        {
            return View();
        }

        /// <summary>
        /// 加载案件
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public string GetCaseManagement(string keywords, int pageIndex, int pageSize)
        {
            var caseList = new List<InfPunishCaseinfoEntity>();
            var list = new List<CaseEntity>();
            var data = _infPunishCaseinfoBll.GetCaseList(keywords, pageIndex, pageSize);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    string FileAddress = "";
                    var attach = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = item["Id"].ToString() }).Where(x => x.FileReName.Contains("jpg") || x.FileReName.Contains("png")).ToList();
                    if (attach.Any())
                    {
                        FileAddress = AppConfig.FileViewLink + attach[0].FileAddress;
                    }
                    list.Add(new CaseEntity()
                    {
                        Id = item["Id"].ToString(),
                        FileAddress = FileAddress,
                        CaseDate = Convert.ToDateTime(item["CaseDate"]).ToString("yyyy-MM-dd"),
                        CaseAddress = item["CaseAddress"].ToString(),
                        TargetName = item["TargetName"].ToString(),
                        RePersonelNameFist = item["RePersonelNameFist"].ToString(),
                        RePersonelNameSecond = item["RePersonelNameSecond"].ToString()
                    });
                }
            }
            var result = JsonConvert.SerializeObject(list);
            return result;
        }

        public class CaseEntity
        {
            /// <summary>
            /// 主键Id
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// 附件地址
            /// </summary>
            public string FileAddress { get; set; }

            /// <summary>
            /// 案发时间
            /// </summary>
            public string CaseDate { get; set; }

            /// <summary>
            /// 案发地点
            /// </summary>
            public string CaseAddress { get; set; }

            /// <summary>
            /// 当事人
            /// </summary>
            public string TargetName { get; set; }

            /// <summary>
            /// 执法人员一
            /// </summary>
            public string RePersonelNameFist { get; set; }

            /// <summary>
            /// 执法人员二
            /// </summary>
            public string RePersonelNameSecond { get; set; }
        }

        /// <summary>
        /// 案件详情
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseManagementDetail(string caseId)
        {
            var entity = new InfPunishCaseinfoEntity();
            if (!string.IsNullOrEmpty(caseId))
            {
                var caseList = _infPunishCaseinfoBll.GetSearchResult(new InfPunishCaseinfoEntity() { Id = caseId });
                if (caseList.Any())
                {
                    entity = caseList[0];
                    var attach = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = caseId });
                    ViewBag.Attach = attach;
                }
            }
            return View(entity);
        }

        /// <summary>
        /// 案件流程
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseProcess(string caseId)
        {
            if (!string.IsNullOrEmpty(caseId))
            {
                var work = _crmMessageWorkBll.GetSearchResult(new CrmMessageWorkEntity() { FormID = caseId, Note = "Asc" });
                if (work.Any())
                {
                    foreach (var item in work)
                    {
                        var userList = _crmUserBll.GetAllUsers(new CrmUserEntity() { Id = item.ActionerID });
                        if (userList.Any())
                        {
                            item.ActionerID = userList[0].RealName; //接收人
                        }
                        var proInstance = _wfProcessInstanceBll.GetSearchResult(new WfProcessInstanceEntity() { Id = item.ProcessInstanceID });
                        if (proInstance.Any())
                        {
                            var wfProcess = _wfProcessBll.GetSearchResult(new WfProcessEntity() { Id = proInstance[0].ProcessID });
                            if (wfProcess.Any())
                            {
                                item.ProcessInstanceID = wfProcess[0].Name; //审批环节
                            }
                        }
                    }
                    ViewBag.Process = work;
                }
            }
            return View();
        }

        /// <summary>
        /// 法律法规库
        /// </summary>
        /// <returns></returns>
        public ActionResult LegislationIndex()
        {
            return View();
        }

        /// <summary>
        /// 获取法律法规
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string GetLegislation(string keywords, int pageIndex, int pageSize)
        {
            var legislation = _legislationBll.GetLegislation(keywords, pageIndex, pageSize);
            var list = new List<LegisEntity>();
            if (legislation.Rows.Count > 0)
            {
                string typeName = "";
                foreach (DataRow item in legislation.Rows)
                {
                    switch (item["ClassNo"].ToString())
                    {
                        case "00090001":
                            typeName = "容";
                            break;
                        case "00090002":
                            typeName = "规";
                            break;
                        case "00090003":
                            typeName = "绿";
                            break;
                        case "00090004":
                            typeName = "设";
                            break;
                        case "00090005":
                            typeName = "交";
                            break;
                        case "00090006":
                            typeName = "工";
                            break;
                        case "00090007":
                            typeName = "环";
                            break;
                        case "00090008":
                            typeName = "水";
                            break;
                        case "00090010":
                            typeName = "人";
                            break;
                        case "00090011":
                            typeName = "教";
                            break;
                        default:
                            typeName = "";
                            break;
                    }
                    list.Add(new LegisEntity()
                    {
                        Id = item["Id"].ToString(),
                        TypeName = typeName,
                        ItemNo = item["ItemNo"].ToString(),
                        ItemAct = item["ItemAct"].ToString()
                    });
                }
            }
            var result = JsonConvert.SerializeObject(list);
            return result;
        }

        public class LegisEntity
        {
            /// <summary>
            /// 主键Id
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// 类别名称
            /// </summary>
            public string TypeName { get; set; }

            /// <summary>
            /// 编号
            /// </summary>
            public string ItemNo { get; set; }

            /// <summary>
            /// 案由
            /// </summary>
            public string ItemAct { get; set; }
        }

        /// <summary>
        /// 法律法规详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult LegislationDetail(string Id)
        {
            var entity = new LegislationEntity();
            var entityItem = new LegislationItemEntity();
            var entityGist = new LegislationGistEntity();
            var list = new List<LegislationRuleEntity>();
            var legislation = _legislationBll.GetSearchResult(new LegislationEntity() { Id = Id });
            if (legislation.Any())
            {
                entity = legislation[0];
                var legitem = _legislationItem.GetSearchResult(new LegislationItemEntity() { LegislationId = legislation[0].Id });
                if (legitem.Any())
                {
                    entityItem = legitem[0];
                    var leggist = _legislationGistBll.GetSearchResult(new LegislationGistEntity() { LegislationItemId = legitem[0].Id });
                    if (leggist.Any())
                    {
                        entityGist = leggist[0];
                    }
                }
                var legrule = _legislationRule.GetSearchResult(new LegislationRuleEntity() { LegislationId = legislation[0].Id });
                if (legrule.Any())
                {
                    list = legrule;
                }
            }
            ViewBag.LegislationItem = entityItem;
            ViewBag.LegislationGist = entityGist;
            ViewBag.LegislationRule = list;
            return View(entity);
        }

        /// <summary>
        /// 审批事项首页
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovalIndex()
        {
            return View();
        }

        /// <summary>
        /// 加载审批事项
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string GetApproval(string keywords, int pageIndex, int pageSize)
        {
            if (!string.IsNullOrEmpty(keywords))
            {
                string type = "";
                var matter = _tmMatterBll.GetSearchResult(new TmMatterEntity() { }).Where(x => x.MATTER_SIMPLE_NAME.Contains(keywords)).ToList();
                if (matter.Any())
                {
                    foreach (var item in matter)
                    {
                        type += "'" + item.ID + "',";
                    }
                    keywords = type.TrimEnd(',');
                }
            }
            var major = _tmMatterApplyMajorBll.GetApplyMajorList(keywords, pageIndex, pageSize);
            string FileAddress = "";
            var list = new List<MajorEntity>();
            if (major.Rows.Count > 0)
            {
                foreach (DataRow item in major.Rows)
                {
                    var matter = _tmMatterBll.GetSearchResult(new TmMatterEntity() { ID = item["MATTER_ID"].ToString() });
                    if (matter.Any() && !string.IsNullOrEmpty(item["APPLY_TIME"].ToString()))
                    {
                        item["APPLY_TIME"] = Convert.ToDateTime(item["APPLY_TIME"]).AddDays(Convert.ToDouble(matter[0].TIME_LIMIT)).ToString("yyyy-MM-dd");//审批到期日期
                        item["MATTER_TYPE"] = matter[0].MATTER_SIMPLE_NAME;
                    }
                    //户外广告
                    if (item["MATTER_ID"] == "3")
                    {
                        //var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "MATTER_APPLY_HWGG_DETAIL" });//所有会外广告的附件说明
                        var hwgg = _tmMatterApplyHWGGBll.GetSearchResult(new TmMatterApplyHWGGEntity() { MAJOR_ID = item["ID"].ToString() });
                        if (hwgg.Any())
                        {
                            var hwggdetail = _tmMatterApplyHWGGDetailBll.GetSearchResult(new TmMatterApplyHWGGDetailEntity() { MATTER_APPLY_HWGG_ID = hwgg[0].ID });
                            if (hwggdetail.Any())
                            {
                                bool flag = false;
                                foreach (var hwggitem in hwggdetail)
                                {
                                    //var attach_ref = attachref.Where(x => x.REF_RECORD_ID == hwggitem.ID).ToList();
                                    var attach_ref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "MATTER_APPLY_HWGG_DETAIL", REF_RECORD_ID = hwggitem.ID });
                                    var attach = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                    if (attach.Any())
                                    {
                                        foreach (var att in attach)
                                        {
                                            if (att.SUFFIXATION.Contains("jpg") || att.SUFFIXATION.Contains("png") || att.SUFFIXATION.Contains("jpeg"))
                                            {
                                                FileAddress = AppConfig.FileViewLink + att.PATH + att.REAL_NAME + "." + att.SUFFIXATION;
                                                flag = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //渣土运输
                    if (item["MATTER_ID"] == "2")
                    {
                        //var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZTYS_VEHICLE_DRIVING_LICENSE" });//所有渣土运输的附件说明
                        var ztys = _tmMatterApplyZTYSBll.GetSearchResult(new TmMatterApplyZTYSEntity() { MAJOR_ID = item["ID"].ToString() });
                        if (ztys.Any())
                        {
                            var ztysVehicle = _tmMatterApplyZTYSVehicleBll.GetSearchResult(new TmMatterApplyZTYSVehicleEntity() { MATTER_APPLY_ZTYS_ID = ztys[0].ID });
                            if (ztysVehicle.Any())
                            {
                                bool flag = false;
                                //附件
                                foreach (var ztysitem in ztysVehicle)
                                {
                                    //var attach_ref = attachref.Where(x => x.REF_RECORD_ID == ztysitem.ID).ToList();
                                    var attach_ref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZTYS_VEHICLE_DRIVING_LICENSE", REF_RECORD_ID = ztysitem.ID });
                                    var attach = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                    if (attach.Any())
                                    {
                                        foreach (var att in attach)
                                        {
                                            if (att.SUFFIXATION.Contains("jpg") || att.SUFFIXATION.Contains("png") || att.SUFFIXATION.Contains("jpeg"))
                                            {
                                                FileAddress = AppConfig.FileViewLink + att.PATH + att.REAL_NAME + "." + att.SUFFIXATION;
                                                flag = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //占用挖掘
                    if (item["MATTER_ID"] == "1")
                    {
                        //var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZYWJ_CERTIFICATE" });//所有占用挖掘的附件说明
                        var zywj = _tmMatteApplyZYWJBll.GetSearchResult(new TmMatteApplyZYWJEntity() { MAJOR_ID = item["ID"].ToString() });
                        if (zywj.Any())
                        {
                            var certificate = _TmMatterApplyCertificateBll.GetSearchResult(new TmMatterApplyCertificate() { ENTERPRISE_ID = item["APPLY_DEPT_ID"].ToString() });
                            if (certificate.Any())
                            {
                                bool flag = false;
                                //附件
                                foreach (var zywjitem in certificate)
                                {
                                    //var attach_ref = attachref.Where(x => x.REF_RECORD_ID == zywjitem.ID).ToList();
                                    var attach_ref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZYWJ_CERTIFICATE", REF_RECORD_ID = zywjitem.ID });
                                    var attach = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                    if (attach.Any())
                                    {
                                        foreach (var att in attach)
                                        {
                                            if (att.SUFFIXATION.Contains("jpg") || att.SUFFIXATION.Contains("png") || att.SUFFIXATION.Contains("jpeg"))
                                            {
                                                FileAddress = AppConfig.FileViewLink + att.PATH + att.REAL_NAME + "." + att.SUFFIXATION;
                                                flag = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (item["MATTER_ID"] == "4" || item["MATTER_ID"] == "5" || item["MATTER_ID"] == "6" || item["MATTER_ID"] == "7" || item["MATTER_ID"] == "8" || item["MATTER_ID"] == "9")
                    {
                        var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "MATTER_DONE_LICENSE", REF_RECORD_ID = item["ID"].ToString() });//其他类型的附件说明
                        var attach = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attachref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                        if (attach.Any())
                        {
                            foreach (var att in attach)
                            {
                                if (att.SUFFIXATION.Contains("jpg") || att.SUFFIXATION.Contains("png") || att.SUFFIXATION.Contains("jpeg"))
                                {
                                    FileAddress = AppConfig.FileViewLink + att.PATH + att.REAL_NAME + "." + att.SUFFIXATION;
                                    break;
                                }
                            }
                        }
                    }
                    list.Add(new MajorEntity()
                    {
                        ID = item["ID"].ToString(),
                        FileAddress = FileAddress,
                        APPLY_TIME = !string.IsNullOrEmpty(item["APPLY_TIME"].ToString()) ? Convert.ToDateTime(item["APPLY_TIME"]).ToString("yyyy-MM-dd") : "",
                        MATTER_TYPE = item["MATTER_TYPE"].ToString(),
                        APPLY_LINKMAN = item["APPLY_LINKMAN"].ToString(),
                        ACCEPT_TIME = item["ACCEPT_TIME"].ToString()
                    });
                }
            }
            var result = JsonConvert.SerializeObject(list);
            return result;
        }

        public class MajorEntity
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 附件地址
            /// </summary>
            public string FileAddress { get; set; }
            /// <summary>
            /// 到期时间
            /// </summary>
            public string APPLY_TIME { get; set; }
            /// <summary>
            /// 类型
            /// </summary>
            public string MATTER_TYPE { get; set; }
            /// <summary>
            /// 联系人
            /// </summary>
            public string APPLY_LINKMAN { get; set; }
            /// <summary>
            /// 审批时间
            /// </summary>
            public string ACCEPT_TIME { get; set; }
        }

        /// <summary>
        /// 审批事项详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ApprovaDetails(string Id)
        {
            var entity = new TmMatterApplyMajorEntity();
            var matterEntity = new TmMatterEntity();
            var enterpriseEntity = new TmEnterpriseEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                var major = _tmMatterApplyMajorBll.GetSearchResult(new TmMatterApplyMajorEntity() { ID = Id });
                if (major.Any())
                {
                    entity = major[0];
                    var dictionary = _tcDictionaryDataBll.GetSearchResult(new TcDictionaryDataEntity() { CODE = entity.APPLY_STATUS });
                    if (dictionary.Any())
                    {
                        entity.APPLY_STATUS = dictionary[0].VALUE;
                    }
                    var matter = _tmMatterBll.GetSearchResult(new TmMatterEntity() { ID = major[0].MATTER_ID });
                    if (matter.Any())
                    {
                        matterEntity = matter[0];
                        entity.APPLY_TIME = Convert.ToDateTime(entity.APPLY_TIME).ToString("yyyy-MM-dd");
                        //ViewBag.APPLY_LIMIT_TIME = Convert.ToDateTime(entity.APPLY_TIME).AddDays(Convert.ToDouble(matter[0].TIME_LIMIT)).ToString("yyyy-MM-dd");
                    }
                    ViewBag.Matter = matterEntity;
                    var enterprise = _tmEnterpriseBll.GetSearchResult(new TmEnterpriseEntity() { ID = major[0].APPLY_DEPT_ID });
                    if (enterprise.Any())
                    {
                        enterpriseEntity = enterprise[0];
                    }
                    ViewBag.Enterprise = enterpriseEntity;
                    if (matter.Any())
                    {
                        var attach = new List<TcAttachMentEntity>();
                        //户外广告
                        if (entity.MATTER_ID == "3")
                        {
                            var hwggEntity = new TmMatterApplyHWGGEntity();
                            var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "MATTER_APPLY_HWGG_DETAIL" });//所有会外广告的附件说明
                            var hwgg = _tmMatterApplyHWGGBll.GetSearchResult(new TmMatterApplyHWGGEntity() { MAJOR_ID = Id });
                            if (hwgg.Any())
                            {
                                hwggEntity = hwgg[0];
                                var hwggdetail = _tmMatterApplyHWGGDetailBll.GetSearchResult(new TmMatterApplyHWGGDetailEntity() { MATTER_APPLY_HWGG_ID = hwgg[0].ID });
                                if (hwggdetail.Any())
                                {
                                    //附件
                                    foreach (var hwggitem in hwggdetail)
                                    {
                                        //广告类别
                                        var data = _tcDictionaryDataBll.GetSearchResult(new TcDictionaryDataEntity() { CODE = hwggitem.ADVERT_TYPE_TWO });
                                        if (data.Any())
                                        {
                                            hwggitem.ADVERT_TYPE_TWO = data[0].VALUE;
                                        }
                                        var attach_ref = attachref.Where(x => x.REF_RECORD_ID == hwggitem.ID).ToList();
                                        var attachs = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                        if (attachs.Any())
                                        {
                                            attach.AddRange(attachs);
                                        }
                                    }
                                }
                                ViewBag.TmMatterApplyHwggDetail = hwggdetail;
                            }
                            ViewBag.TmMatterApplyHwgg = hwggEntity;
                        }
                        //渣土运输
                        if (entity.MATTER_ID == "2")
                        {
                            var ztysEntity = new TmMatterApplyZTYSEntity();
                            var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZTYS_VEHICLE_DRIVING_LICENSE" });//所有渣土运输的附件说明
                            var ztys = _tmMatterApplyZTYSBll.GetSearchResult(new TmMatterApplyZTYSEntity() { MAJOR_ID = Id });
                            if (ztys.Any())
                            {
                                ztysEntity = ztys[0];

                                var ztysVehicle = _tmMatterApplyZTYSVehicleBll.GetSearchResult(new TmMatterApplyZTYSVehicleEntity() { MATTER_APPLY_ZTYS_ID = ztys[0].ID });
                                if (ztysVehicle.Any())
                                {
                                    //附件
                                    foreach (var ztysitem in ztysVehicle)
                                    {
                                        var attach_ref = attachref.Where(x => x.REF_RECORD_ID == ztysitem.ID).ToList();
                                        var attachs = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                        if (attachs.Any())
                                        {
                                            attach.AddRange(attachs);
                                        }
                                    }
                                }
                                ViewBag.TmMatterApplyZTYSVehicle = ztysVehicle;
                            }
                            ViewBag.TmMatterApplyZTYS = ztysEntity;
                        }
                        //占用挖掘
                        if (entity.MATTER_ID == "1")
                        {
                            var zywjEntity = new TmMatteApplyZYWJEntity();
                            var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "ZYWJ_CERTIFICATE" });//所有占用挖掘的附件说明
                            var zywj = _tmMatteApplyZYWJBll.GetSearchResult(new TmMatteApplyZYWJEntity() { MAJOR_ID = Id });
                            if (zywj.Any())
                            {
                                zywjEntity = zywj[0];
                                var certificate = _TmMatterApplyCertificateBll.GetSearchResult(new TmMatterApplyCertificate() { ENTERPRISE_ID = entity.APPLY_DEPT_ID });
                                if (certificate.Any())
                                {
                                    //附件
                                    foreach (var zywjitem in certificate)
                                    {
                                        var attach_ref = attachref.Where(x => x.REF_RECORD_ID == zywjitem.ID).ToList();
                                        var attachs = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attach_ref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                                        if (attachs.Any())
                                        {
                                            attach.AddRange(attachs);
                                        }
                                    }
                                }
                            }
                            ViewBag.TmMatteApplyZYWJ = zywjEntity;
                        }
                        if (entity.MATTER_ID == "4" || entity.MATTER_ID == "5" || entity.MATTER_ID == "6" || entity.MATTER_ID == "7" || entity.MATTER_ID == "8" || entity.MATTER_ID == "9")
                        {
                            var attachref = _tcAttachMentRefBll.GetSearchResult(new TcAttachMentRefEntity() { REF_TYPE = "MATTER_DONE_LICENSE", REF_RECORD_ID = Id });//其他类型的附件说明
                            var attachs = _tcAttachMentDal.GetSearchResult(new TcAttachMentEntity() { }).Where(x => attachref.Any(y => y.ATTACHMENT_ID == x.ID)).ToList();
                            if (attachs.Any())
                            {
                                attach.AddRange(attachs);
                            }
                        }
                        ViewBag.Attach = attach;
                    }
                }
            }
            return View(entity);
        }

        public ActionResult LawSearchIndex()
        {
            return View();
        }
    }
}
