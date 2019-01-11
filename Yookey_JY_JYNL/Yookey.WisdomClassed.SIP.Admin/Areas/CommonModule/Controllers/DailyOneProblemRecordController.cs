using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    /// <summary>
    /// 答题记录 控制器
    /// </summary>
    public class DailyOneProblemRecordController : BaseController
    {

        readonly CrmDailyOneProblemBll _CrmDailyOneProblemBll = new CrmDailyOneProblemBll();// 每日一题
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly CrmDailyOneProblemRecordBll _crmDailyOneProblemRecordBll = new CrmDailyOneProblemRecordBll();    //

        #region 题目管理 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 请求数据列表
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="deptId">所属部门ID</param>
        /// <param name="question">查询关键字</param>
        /// <param name="starttime">开始日期</param>
        /// <param name="endtime">截止日期</param>
        /// <param name="rowStatus"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetQuestionList(string companyId, string deptId, string question, string starttime, string endtime, int rowStatus, int rows, int page)
        {
            //var user = CurrentUser.CrmUser;

            var userId = "";

            var data = _crmDailyOneProblemRecordBll.GetSearchResult(companyId, deptId, userId, question, page, rows, starttime, endtime);

            //return CommonMethod.PageToJson(data);

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }

        #endregion


        #region 答题正确率Top10

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CorrectRateTopTenIndex()
        {
            return View();
        }

        /// <summary>
        /// 请求数据列表
        /// </summary>
        public string GetCorrectRateTopTenList(string companyId, string deptId, string keywords, int rows, int page)
        {
            var user = CurrentUser.CrmUser;
            var data = _crmDailyOneProblemRecordBll.GetCorrectRate(companyId, deptId, keywords, page, rows);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }
        #endregion
    }
}
