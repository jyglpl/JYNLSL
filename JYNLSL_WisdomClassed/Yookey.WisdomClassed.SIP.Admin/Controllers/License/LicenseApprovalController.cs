using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Membership;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.License
{
    public class LicenseApprovalController : BaseController
    {
        //
        // GET: /LicenseApproval/

        public ActionResult Index()
        {

            //验证当前登录账号是否有受理权限
            var isAll = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "LicenseList", "All");

            //许可类型
            var outdoorType = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0054" }).ToList();
            outdoorType.Insert(0, new ComResourceEntity() { RsValue = "", RsKey = "==请选择==" });
            ViewData["LicenseType"] = new SelectList(outdoorType, "RsValue", "RsKey");


            //片区
            var companys = new CrmCompanyBll().GetAllLicenseUnit();
            if (isAll)
            {
                companys.Insert(0, new CrmCompanyEntity() { Id = "", FullName = "==请选择==" });
            }
            else
            {
                companys=companys.Where(i => i.Id == (CurrentUser.CrmUser.CompanyId)).ToList();
            }
            ViewData["Companys"] = new SelectList(companys, "Id", "FullName");


            ViewBag.BtnDelete = false;
            return View();
        }


        public ActionResult HistoryIndex()
        {

            //许可类型
            var outdoorType = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0054" }).ToList();
            outdoorType.Insert(0, new ComResourceEntity() { RsValue = "", RsKey = "==请选择==" });
            ViewData["LicenseType"] = new SelectList(outdoorType, "RsValue", "RsKey");


            ViewBag.BtnDelete = false;
            return View();
        }

        /// <summary>
        /// 请求办件案件列表
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="licenseType">许可类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="rows">每页条数</param>
        /// <param name="page">当前索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>        
        /// <returns></returns>
        public string QueryLicenseList(string caseStateType, string licenseType, string companyId, string keyword, string StartTime, string EndTime, string dataSource, string secpType, int rows, int page, string sidx, string sord)
        {
            var data = new LicenseMainBll().QueryLicenseList(caseStateType, licenseType, companyId, keyword, StartTime, EndTime, dataSource, secpType, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        public ActionResult LicenseAdd()
        {
            return View();
        }


        /// <summary>
        /// 弹出申请人证照搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchPaperCodeList()
        {
            return View();
        }

        #region AJAX 数据提交

        /// <summary>
        /// 行政许可受理
        /// </summary>
        /// <param name="licenseId">许可Id</param>
        /// <param name="acceptType">agree：受理 ,disagree：不受理归档</param>
        /// <returns></returns>
        public JsonResult LicenseAcceptance(string licenseId, string acceptType)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(licenseId))
                {
                    var user = CurrentUser.CrmUser;
                    var comNumberBll = new ComNumberBll();
                    var entity = new LicenseMainBll().Get(licenseId);

                    if (acceptType.Equals("agree"))
                    {
                        entity.State = 10;
                        entity.LicenseNo = comNumberBll.GetNumber("00300011", "", null);  //生成流水号                        
                        entity.AcceptanceId = user.Id;
                        entity.AcceptanceName = user.UserName;
                        entity.AcceptanceDate = DateTime.Now;
                    }
                    else
                    {
                        entity.State = -1;
                    }
                    isOk = new LicenseMainBll().Update(entity) > 0;
                    rtMsg = "受理操作成功";
                }
                else
                {
                    isOk = false;
                    rtMsg = "请传入许可主键值";
                }
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


        /// <summary>
        /// 行政许可办结
        /// </summary>
        /// <param name="licenseId">许可Id</param>        
        /// <returns></returns>
        public JsonResult LicenseClosed(string licenseId)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(licenseId))
                {
                    var user = CurrentUser.CrmUser;
                    var entity = new LicenseMainBll().Get(licenseId);
                    var comNumberBll = new ComNumberBll();
                    if (entity.State != -1)
                    {
                        entity.LicenseSetNo = string.IsNullOrEmpty(entity.LicenseSetNo) ? comNumberBll.GetLicenseSetNo(entity) : entity.LicenseSetNo;//生成设置证号
                    }
                    else
                    {
                        entity.LicenseSetNo = string.Empty;
                    }
                    entity.State = entity.State==-1?-1:40;
                    entity.ClosedDate = DateTime.Now;                    
                    isOk = new LicenseMainBll().Update(entity) > 0;
                    if (isOk)
                    {
                        new CrmMessageWorkBll().UpdateUnHandleMessage(licenseId);
                    }
                    rtMsg = "办结操作成功";
                }
                else
                {
                    isOk = false;
                    rtMsg = "请传入许可主键值";
                }
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


        public JsonResult LicenseSetNo(string licenseId)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(licenseId))
                {
                    var user = CurrentUser.CrmUser;
                    var entity = new LicenseMainBll().Get(licenseId);
                    var comNumberBll = new ComNumberBll();
                    entity.LicenseSetNo = comNumberBll.GetLicenseSetNo(entity);//生成设置证号                    
                    isOk = new LicenseMainBll().Update(entity) > 0;
                    if (isOk)
                    {
                        new CrmMessageWorkBll().UpdateUnHandleMessage(licenseId);
                    }
                    rtMsg = "下一步操作成功";
                }
                else
                {
                    isOk = false;
                    rtMsg = "请传入许可主键值";
                }
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


        /// <summary>
        /// 请求办件案件列表
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="rows">每页条数</param>
        /// <param name="page">当前索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public string SearchApplicantInfoList(string keyword, int rows, int page, string sidx, string sord)
        {
            var data = new LicenseOutDoorBll().QueryApplicantInfoList(keyword, rows, page, sidx, sord);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        #endregion

        #region AJAX 数据请求

        /// <summary>
        /// 查询办件的状态
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public string GetLicenseStateCount(string companyId, string deptId)
        {
            var user = CurrentUser.CrmUser;
            var casecount = new LicenseMainBll().GetLicenseStateCount(companyId, deptId, user.DeptId);
            if (casecount != null && casecount.Rows.Count > 0)
            {

                ViewBag.Admissible = casecount.Rows[0]["Admissible"];
                ViewBag.ToVisit = casecount.Rows[0]["ToVisit"];
                ViewBag.ToBeAudited = casecount.Rows[0]["ToBeAudited"];
                ViewBag.ToBeDone = casecount.Rows[0]["ToBeDone"];
                ViewBag.HaveDone = casecount.Rows[0]["HaveDone"];
                ViewBag.All = casecount.Rows[0]["All"];
            }
            string data = ViewBag.Admissible + "|" + ViewBag.ToVisit + "|" + ViewBag.ToBeAudited + "|" + ViewBag.ToBeDone + "|" + ViewBag.HaveDone + "|" + ViewBag.All;
            return data;
        }

        #endregion
    }
}
