using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Education;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Education
{
    public class EducationController : BaseController
    {

        private EducationBll _educationBll = new EducationBll();//教育纠处
        private BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();                //部门
        private BaseUserBll _crmUserBll = new BaseUserBll();                            //人员
        private ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        //
        // GET: /Education/

        public ActionResult Index()
        {
            //绑定部门信息
            var companys = new CrmCompanyBll().GetAllCompany(new CrmCompanyEntity() { ParentId = "2721E764-2E69-4385-A3BD-34FF09F0552B" });
            companys.Insert(0, new CrmCompanyEntity { Id = "", ShortName = "==请选择==" });
            ViewData["Companys"] = new SelectList(companys, "Id", "FullName");

            var casetypes = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0009" });
            casetypes.Insert(0, new ComResourceEntity() { Id = "", RsKey = "==请选择==" });
            ViewData["CaseType"] = new SelectList(casetypes, "Id", "RsKey");

            return View();
        }

        /// <summary>
        /// 编辑详情
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public ActionResult Edit(string educationId)
        {

            var entity = new EducationEntity();

            if (!string.IsNullOrEmpty(educationId))
            {
                entity = new EducationBll().Get(educationId);

                var beforeReform = new EducationAttachBll().GetListByResourceId(educationId, "1");  //整改前照片
                var afeterReform = new EducationAttachBll().GetListByResourceId(educationId, "2");  //整改后照片
                var idPhoto = new EducationAttachBll().GetListByResourceId(educationId, "3");       //证据照

                ViewData["BeforeReform"] = beforeReform;
                ViewData["AfterReform"] = afeterReform;
                ViewData["IdPhoto"] = idPhoto;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();  //主键
                entity.EducationTime = DateTime.Now;
            }

            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            //两个执法人员
            var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = "" }).ToList();
            users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            //证件类型
            var numbertype = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0013" }).ToList();
            numbertype.Insert(0, new ComResourceEntity() { Id = "", RsKey = "==请选择==" });
            ViewData["Numbertypes"] = new SelectList(numbertype, "Id", "RsKey");

            //查询当事人特征
            var partyFeatures = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0048" });
            ViewData["PartyFeatures"] = partyFeatures;

            ViewBag.ResourceId = entity.Id;

            return View(entity);
        }

        /// <summary>
        /// 附件放大预览列表
        /// <param name="resourceId">外键编号</param>
        /// <param name="defaultPicId">默认显示图片ID</param>
        /// </summary>
        /// <returns></returns>
        public ActionResult FilesView(string resourceId, string defaultPicId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = new EducationAttachBll().GetSearchResult(new EducationAttachEntity() { ResourceId = resourceId });

                ViewData["Files"] = files;
            }
            ViewBag.DefaultPicId = defaultPicId;
            return View();
        }

        #region AJAX

        /// <summary>
        /// 现场纠处数据查询
        /// </summary>
        /// <param name="companyId">查询单位ID</param>
        /// <param name="departmentId">查询部门ID</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="rows">每页请求条数</param>
        /// <param name="page">当前索引页</param>
        /// <returns></returns>
        public string QueryListJson(string companyId, string departmentId, string caseType, string beginDate, string endDate, string keyword, int rows = 30, int page = 1)
        {
            var data = _educationBll.GetSearchResult(companyId, departmentId, caseType, beginDate, endDate, keyword,
                                                     rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 保存违法建设信息
        /// </summary>
        /// <param name="entity">单位实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SubmitForm(EducationEntity entity)
        {
            var rtState = 0;
            try
            {
                if (true)
                {
                    EducationEntity education = _educationBll.Get(entity.Id);
                    if (education == null)
                    {
                        entity.Id = entity.Id;
                        entity.RowStatus = (int)RowStatus.Normal;
                        entity.CreateBy = CurrentUser.CrmUser.UserName;
                        entity.CreatorId = CurrentUser.CrmUser.Id;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateBy = CurrentUser.CrmUser.UserName;
                        entity.UpdateId = CurrentUser.CrmUser.Id;
                        entity.UpdateOn = DateTime.Now;
                        _educationBll.Add(entity);
                    }
                    else
                    {
                        entity.UpdateBy = CurrentUser.CrmUser.UserName;
                        entity.UpdateId = CurrentUser.CrmUser.Id;
                        entity.UpdateOn = DateTime.Now;
                        _educationBll.Update(entity);
                    }
                    rtState = 0;
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

    }
}
