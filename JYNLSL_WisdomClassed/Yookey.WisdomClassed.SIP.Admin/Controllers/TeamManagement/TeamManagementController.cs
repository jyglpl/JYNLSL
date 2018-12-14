using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.TeamManagement;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Assessment
{
    /// <summary>
    /// 队伍管理
    /// </summary>
    public class TeamManagementController : BaseController
    {
        readonly TeamManagementAttachBll _teamManagementAttachBll = new TeamManagementAttachBll();
        readonly TeamManagementBll _teamManagementBll = new TeamManagementBll();
        readonly CrmUserBll _crmUserBll = new CrmUserBll();
        readonly TeamManagementProcessBll _teamManagementProcessBll = new TeamManagementProcessBll();

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
        public string GetTeamManagementPageJqDatagrid(string companyId, string deptId, string startTime, string endTime, string keywords, int state, int rows = 30, int page = 1)
        {
            if (string.IsNullOrEmpty(companyId) && string.IsNullOrEmpty(deptId))
            {
                return JsonConvert.SerializeObject(new PageJqDatagrid<TeamManagementEntity>());
            }

            if (companyId == "all")
            {
                companyId = "";
            }
            if (deptId == "all")
            {
                deptId = "";
            }

            var data = _teamManagementBll.GetTeamManagementPageJqDatagrid(new TeamManagementEntity()
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
        public ActionResult TeamManagementReport()
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
        public string GetTeamManagementReportJqDatagrid(string companyId, string startTime, string endTime)
        {
            if (companyId == "all")
            {
                companyId = "";
            }


            DataTable data = _teamManagementBll.GetTeamManagementReportGroupByDept(companyId, startTime, endTime);
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

            TeamManagementEntity model = _teamManagementBll.Get(id);
            List<TeamManagementAttachEntity> assessmentAttachList = new List<TeamManagementAttachEntity>();
            if (model != null)
            {
                assessmentAttachList = _teamManagementAttachBll.GetTeamManagementAttachListByTeamManagementId(id);
            }

            List<TeamManagementProcessEntity> assessmentProcessList = _teamManagementProcessBll.GetTeamManagementProcessListByTeamManagementId(id, (int)TeamManagementSate.Processed);
            TeamManagementProcessEntity assessmentProcessModel = new TeamManagementProcessEntity();
            if (assessmentProcessList.Any())
            {
                assessmentProcessModel = assessmentProcessList.FirstOrDefault();
            }

            ViewBag.TeamManagementAttachList = assessmentAttachList;
            ViewBag.TeamManagementProcessModel = assessmentProcessModel;
            ViewData.Model = model;

            return View();
        }

    }
}
