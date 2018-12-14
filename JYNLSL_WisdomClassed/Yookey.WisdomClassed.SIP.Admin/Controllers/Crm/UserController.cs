using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Crm
{
    public class UserController : BaseController
    {
        private readonly BaseUserBll _baseUserBll = new BaseUserBll();
        private readonly BaseCertificateBll _baseCertificateBll = new BaseCertificateBll();
        readonly BaseCertificateUseBll _baseBll = new BaseCertificateUseBll();
        readonly ComResourceBll _comBll = new ComResourceBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询数据Json
        /// </summary>
        /// <param name="keywords">查询关键字</param>
        /// <param name="companyId">企业编号</param>
        /// <param name="departmentId">部门编号</param>
        /// <param name="rows">查询条数</param>
        /// <param name="page">当前页</param>
        /// <returns></returns>
        public string GridPageListJson(string keywords, string companyId, string departmentId, int rows, int page)
        {
            var data = _baseUserBll.GetUsers(HttpUtility.UrlDecode(keywords), companyId, departmentId, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 执法证（监督）管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CertificateIndex(string id)
        {
            return View();
        }
        /// <summary>
        /// 执法证统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CertificateReport()
        {
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==全部==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);
            //证件类型（执法证、监督证）
            var cardTypes = _comBll.GetSearchResult(new ComResourceEntity { ParentId = "0034" }).ToList();
            cardTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==全部==" });
            ViewData["CardType"] = new SelectList(cardTypes, "Id", "RsKey");
            return View();

        }
        /// <summary>
        ///  执法证统计
        /// </summary>
        /// <param name="CardType">证件类型</param>
        /// <param name="Deptid">部门</param>
        /// <param name="LYTimeStart">领用时间（开始）</param>
        /// <param name="LYTimeEnd">领用时间（结束）</param>
        /// <param name="NJTimeStart">年检时间（开始）</param>
        /// <param name="NJTimeEnd">年检时间（结束）</param>
        /// <param name="HZTimeStart">换证时间（开始）</param>
        /// <param name="HZTimeEnd">换证时间（结束）</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetCertificateReportData(string CardType, string Deptid, string LYTimeStart, string LYTimeEnd, string NJTimeStart, string NJTimeEnd, string HZTimeStart, string HZTimeEnd)
        {
            var data = new BaseCertificateBll().GetCertificateReport(CardType, Deptid, LYTimeStart, LYTimeEnd, NJTimeStart, NJTimeEnd, HZTimeStart, HZTimeEnd );
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        /// <summary>
        /// 执法证（监督）管理
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public ActionResult CertificateManage(string id)
        {
            var userEntity = new BaseUserEntity();   //基础数据平台用户信息
            if (!string.IsNullOrEmpty(id))
            {
                userEntity = _baseUserBll.Get(id);
            }
            //用户扩展信息
            var detailsEntity = _baseCertificateBll.GetEntityByUserId(id) ?? new BaseCertificateEntity() { Id = Guid.NewGuid().ToString(), LeaveRoleId = "" };

            //角色
            var roles = _comBll.GetSearchResult(new ComResourceEntity { ParentId = "0038" }).ToList();
            roles.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Roles"] = new SelectList(roles, "Id", "RsKey", detailsEntity.LeaveRoleId);

            //证件类型（执法证、监督证）
            var cardTypes = _comBll.GetSearchResult(new ComResourceEntity { ParentId = "0034" }).ToList();
            cardTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["CardType"] = new SelectList(cardTypes, "Id", "RsKey", detailsEntity.CertificateType);

            ViewBag.UserId = id;
            ViewBag.Account = userEntity.LoginName;
            ViewBag.UserName = userEntity.UserName;

            return View(detailsEntity);
        }

        /// <summary>
        /// 执法证（监督）证使用管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CertificateUseManage()
        {
            var depts = _baseBll.GetCertificateType("0035");
            ViewData["CardType"] = new SelectList(ConvertListHelper<ComResourceEntity>.ConvertToList(depts), "Id", "RsKey");
            ViewData["UserID"] = Request["uid"];
            return View();
        }


        /// <summary>
        /// 查询执法证使用数据Json
        /// </summary>
        public string GridPageListJsonByCertificate()
        {
            string uid = Request["uid"];
            var data = _baseBll.GetAllCertificateUse(uid);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }


        #region Ajax 数据提交

        /// <summary>
        /// 保存信息
        /// 添加人：楚华峰
        /// 添加时间：未知
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-24 周 鹏 优化保存方法
        /// </history>
        /// <param name="certificate">The certificate.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveCertificate(BaseCertificateEntity certificate)
        {
            var rtState = 0;
            try
            {
                var user = CurrentUser.CrmUser;
                var certificateBll = new BaseCertificateBll();
                var entity = certificateBll.Get(certificate.Id);
                if (entity != null && !string.IsNullOrEmpty(entity.Id))
                {
                    certificate.RowStatus = 1;
                    certificate.UpdateId = user.Id;
                    certificate.UpdateBy = user.UserName;
                    certificate.UpdateOn = DateTime.Now;

                    certificateBll.Update(certificate);
                }
                else
                {
                    certificate.RowStatus = 1;
                    certificate.CreatorId = user.Id;
                    certificate.CreateBy = user.UserName;
                    certificate.CreateOn = DateTime.Now;

                    certificateBll.Add(certificate);
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Ajax保存执法证（监督证）使用管理

        /// <summary>
        /// 保存使用管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddCertificateUse(BaseCertificateUseEntity certificate)
        {
            var rtState = 0;
            try
            {
                certificate.Id = Guid.NewGuid().ToString();
                certificate.RowStatus = 1;
                certificate.CreateBy = CurrentUser.CrmUser.UserName;
                certificate.CreateOn = DateTime.Now;
                certificate.CreatorId = CurrentUser.CrmUser.Id;
                certificate.UserId = Request["Uid"];
                certificate.UseType = Request.Form["CardType"];
                certificate.UseOn = DateTime.Parse(Request.Form["Date"]);
                certificate.UseDesc = Request.Form["Describe"];
                new BaseCertificateUseBll().Add(certificate);
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 删除执法（监督）证使用数据

        /// <summary>
        /// 删除执法（监督）证使用数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int CertificateDel(string id)
        {
            try
            {
                return new BaseCertificateUseBll().CertificateDelete(id);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}
