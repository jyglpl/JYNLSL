using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Assessment;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Assessment;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Assessment
{
    /// <summary>
    /// 路面考核
    /// </summary>
    public class AssessmentController : BaseController
    {
        readonly AssessmentAttachBll _assessmentAttachBll = new AssessmentAttachBll();
        readonly AssessmentBll _assessmentBll = new AssessmentBll();
        readonly CrmUserBll _crmUserBll = new CrmUserBll();
        readonly AssessmentProcessBll _assessmentProcessBll = new AssessmentProcessBll();

        #region 列表页面
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取暂扣数据
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetAssessmentPageJqDatagrid(string companyId, string deptId, string startTime, string endTime, string keywords, int state, int rows = 30, int page = 1)
        {
            if (string.IsNullOrEmpty(companyId) && string.IsNullOrEmpty(deptId))
            {
                return JsonConvert.SerializeObject(new PageJqDatagrid<AssessmentEntity>());
            }

            if (companyId == "all")
            {
                companyId = "";
            }
            if (deptId == "all")
            {
                deptId = "";
            }

            var data = _assessmentBll.GetAssessmentPageJqDatagrid(new AssessmentEntity()
            {
                Remark = keywords,
                Status = state,
                CompanyId = companyId,
                DepartmentId = deptId,
                STime = startTime,
                ETime = endTime,
                PageIndex = page,
                PageSize = rows
            });

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        #endregion

        #region  报表
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AssessmentReportGroupByDeptIndex()
        {
            return View();
        }

        /// <summary>
        /// 获取暂扣数据
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetAssessmentReportGroupByDeptJqDatagrid(string companyId, string startTime, string endTime)
        {
            if (companyId == "all")
            {
                companyId = "";
            }


            DataTable data = _assessmentBll.GetAssessmentReportGroupByDept(companyId, startTime, endTime);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        #endregion

        /// <summary>
        /// 详细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(string id)
        {

            AssessmentEntity model = _assessmentBll.Get(id);
            List<AssessmentAttachEntity> assessmentAttachList = new List<AssessmentAttachEntity>();
            if (model != null)
            {
                assessmentAttachList = _assessmentAttachBll.GetAssessmentAttachListByAssessmentId(id);
            }

            List<AssessmentProcessEntity> assessmentProcessList = _assessmentProcessBll.GetAssessmentProcessListByAssessmentId(id, (int)AssessmentSate.Processed);
            AssessmentProcessEntity assessmentProcessModel = new AssessmentProcessEntity();
            if (assessmentProcessList.Any())
            {
                assessmentProcessModel = assessmentProcessList.FirstOrDefault();
            }

            ViewBag.AssessmentAttachList = assessmentAttachList;
            ViewBag.AssessmentProcessModel = assessmentProcessModel;
            ViewData.Model = model;

            return View();
        }

    }
}
