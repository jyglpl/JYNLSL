using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Approval;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Approval;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Approval 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Approval : System.Web.Services.WebService
    {
        /// <summary>
        /// 审批事项信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetApproval(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var keywords = Regex.Match(context, @"(?<=""KeyWords""\:"").*?(?="",)").Value;   //事项名称

                    var major = new TmMatterApplyMajorBll().GetSearchResult(new TmMatterApplyMajorEntity() { });
                    var list = new List<TmMatterApplyMajorEntity>();
                    if (major.Any())
                    {
                        foreach (var item in major)
                        {
                            var matter = new TmMatterBll().GetSearchResult(new TmMatterEntity() { ID = item.MATTER_ID });
                            if (matter.Any())
                            {
                                item.APPLY_TIME = Convert.ToDateTime(item.APPLY_TIME).AddDays(Convert.ToDouble(matter[0].TIME_LIMIT)).ToString("yyyy-MM-dd");
                                item.MATTER_TYPE = matter[0].MATTER_SIMPLE_NAME;
                                //户外广告
                                if (matter[0].POWER_NO == "0100215000")
                                {
                                    var hwgg = new TmMatterApplyHWGGBll().GetSearchResult(new TmMatterApplyHWGGEntity() { MAJOR_ID = item.ID });
                                    if (hwgg.Any())
                                    {
                                        var hwggdetail = new TmMatterApplyHWGGDetailBll().GetSearchResult(new TmMatterApplyHWGGDetailEntity() { MATTER_APPLY_HWGG_ID = hwgg[0].ID });
                                        //附件
                                        if (hwggdetail.Any())
                                        {
                                            foreach (var hwggitem in hwggdetail)
                                            {
                                                var attachref = new TcAttachMentRefBll().GetSearchResult(new TcAttachMentRefEntity() { REF_RECORD_ID = hwggitem.ID });
                                                if (attachref.Any())
                                                {
                                                    var attach = new TcAttachMentBll().GetSearchResult(new TcAttachMentEntity() { ID = attachref[0].ATTACHMENT_ID });
                                                    if (attach.Any())
                                                    {
                                                        if (attach[0].SUFFIXATION.Contains("jpg") || attach[0].SUFFIXATION.Contains("png") || attach[0].SUFFIXATION.Contains("jpeg"))
                                                        {
                                                            item.FileAddress = AppConfig.FileViewLink + attach[0].PATH + attach[0].REAL_NAME + attach[0].SUFFIXATION;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //渣土运输
                                if (matter[0].POWER_NO == "0100214000")
                                {
                                    var ztys = new TmMatterApplyZTYSBll().GetSearchResult(new TmMatterApplyZTYSEntity() { MAJOR_ID = item.ID });
                                    if (ztys.Any())
                                    {
                                        var ztysVehicle = new TmMatterApplyZTYSVehicleBll().GetSearchResult(new TmMatterApplyZTYSVehicleEntity() { MATTER_APPLY_ZTYS_ID = ztys[0].ID });
                                        if (ztysVehicle.Any())
                                        {
                                            //附件
                                            foreach (var ztysitem in ztysVehicle)
                                            {
                                                var attachref = new TcAttachMentRefBll().GetSearchResult(new TcAttachMentRefEntity() { REF_RECORD_ID = ztysitem.ID });
                                                if (attachref.Any())
                                                {
                                                    var att = new TcAttachMentBll().GetSearchResult(new TcAttachMentEntity() { ID = attachref[0].ATTACHMENT_ID });
                                                    if (att.Any())
                                                    {
                                                        if (att[0].SUFFIXATION.Contains("jpg") || att[0].SUFFIXATION.Contains("png") || att[0].SUFFIXATION.Contains("jpeg"))
                                                        {
                                                            item.FileAddress = AppConfig.FileViewLink + att[0].PATH + att[0].REAL_NAME + att[0].SUFFIXATION;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(keywords) && matter[0].MATTER_SIMPLE_NAME.Contains(keywords))
                                {
                                    list.Add(item);
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(keywords))
                    {
                        obj = list;
                    }
                    else
                    {
                        obj = major;
                    }
                    Status = true;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 审批事项详情
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApprovalDetail(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var Id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;   //事项Id
                    var entity = new TmMatterApplyMajorEntity();
                    var matterentity = new TmMatterEntity();
                    var enterentity = new TmEnterpriseEntity();
                    string appro = "";
                    string approlist = "";
                    var attach = new List<TcAttachMentEntity>();
                    if (!string.IsNullOrEmpty(Id))
                    {
                        var major = new TmMatterApplyMajorBll().GetSearchResult(new TmMatterApplyMajorEntity() { ID = Id });
                        if (major.Any())
                        {
                            entity = major[0];//1
                            var dictionary = new TcDictionaryDataBll().GetSearchResult(new TcDictionaryDataEntity() { CODE = entity.APPLY_STATUS });
                            if (dictionary.Any())
                            {
                                entity.APPLY_STATUS = dictionary[0].VALUE;
                            }
                            var matter = new TmMatterBll().GetSearchResult(new TmMatterEntity() { ID = major[0].MATTER_ID });
                            if (matter.Any())
                            {
                                matterentity = matter[0];//2
                                entity.APPLY_TIME = Convert.ToDateTime(entity.APPLY_TIME).ToString("yyyy-MM-dd");
                            }
                            var enterprise = new TmEnterpriseBll().GetSearchResult(new TmEnterpriseEntity() { ID = major[0].APPLY_DEPT_ID });
                            if (enterprise.Any())
                            {
                                enterentity = enterprise[0];//3
                            }
                            if (matter.Any())
                            {

                                //户外广告
                                if (matter[0].POWER_NO == "0100215000")
                                {
                                    var hwgg = new TmMatterApplyHWGGBll().GetSearchResult(new TmMatterApplyHWGGEntity() { MAJOR_ID = Id });
                                    if (hwgg.Any())
                                    {
                                        appro = JsonConvert.SerializeObject(hwgg[0]);
                                        var hwggdetail = new TmMatterApplyHWGGDetailBll().GetSearchResult(new TmMatterApplyHWGGDetailEntity() { MATTER_APPLY_HWGG_ID = hwgg[0].ID });
                                        if (hwggdetail.Any())
                                        {
                                            approlist = JsonConvert.SerializeObject(hwggdetail);
                                            //附件
                                            foreach (var item in hwggdetail)
                                            {
                                                var attachref = new TcAttachMentRefBll().GetSearchResult(new TcAttachMentRefEntity() { REF_RECORD_ID = item.ID });
                                                if (attachref.Any())
                                                {
                                                    var att = new TcAttachMentBll().GetSearchResult(new TcAttachMentEntity() { ID = attachref[0].ATTACHMENT_ID });
                                                    if (att.Any())
                                                    {
                                                        attach.AddRange(att);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //渣土运输
                                if (matter[0].POWER_NO == "0100214000")
                                {
                                    var ztys = new TmMatterApplyZTYSBll().GetSearchResult(new TmMatterApplyZTYSEntity() { MAJOR_ID = Id });
                                    if (ztys.Any())
                                    {
                                        appro = JsonConvert.SerializeObject(ztys[0]);
                                        var ztysVehicle = new TmMatterApplyZTYSVehicleBll().GetSearchResult(new TmMatterApplyZTYSVehicleEntity() { MATTER_APPLY_ZTYS_ID = ztys[0].ID });
                                        if (ztysVehicle.Any())
                                        {
                                            approlist = JsonConvert.SerializeObject(ztysVehicle);
                                            //附件
                                            foreach (var item in ztysVehicle)
                                            {
                                                var attachref = new TcAttachMentRefBll().GetSearchResult(new TcAttachMentRefEntity() { REF_RECORD_ID = item.ID });
                                                if (attachref.Any())
                                                {
                                                    var att = new TcAttachMentBll().GetSearchResult(new TcAttachMentEntity() { ID = attachref[0].ATTACHMENT_ID });
                                                    if (att.Any())
                                                    {
                                                        attach.AddRange(att);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                //占用挖掘
                                if (matter[0].POWER_NO == "0100209003")
                                {
                                    var zywj = new TmMatteApplyZYWJBll().GetSearchResult(new TmMatteApplyZYWJEntity() { MAJOR_ID = Id });
                                    if (zywj.Any())
                                    {
                                        appro = JsonConvert.SerializeObject(zywj[0]);
                                    }
                                }
                            }
                        }
                    }
                    obj = new ApprovalEntity()
                    {
                        TmMatterApplyMajor = entity,
                        TmMatterEntity = matterentity,
                        TmEnterpriseEntity = enterentity,
                        Attach = attach,
                        ApprovalName = appro,
                        ApprovalDetail = approlist
                    };
                    Status = true;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        public class ApprovalEntity
        {
            /// <summary>
            /// 审批事项信息
            /// </summary>
            public object TmMatterApplyMajor { get; set; }

            /// <summary>
            /// 审批事项类别
            /// </summary>
            public object TmMatterEntity { get; set; }

            /// <summary>
            /// 企业信息
            /// </summary>
            public object TmEnterpriseEntity { get; set; }

            /// <summary>
            /// 附件
            /// </summary>
            public List<TcAttachMentEntity> Attach { get; set; }

            /// <summary>
            /// 事项类型
            /// </summary>
            public string ApprovalName { get; set; }

            /// <summary>
            /// 事项类型详情
            /// </summary>
            public string ApprovalDetail { get; set; }
        }
    }
}
