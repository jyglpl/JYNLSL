using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.PenaltyCaseSafty;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.PenaltyCaseSafty
{
    public class PenaltyCaseSaftyController : Controller
    {
        //
        // GET: /PenaltyCaseSafty/
        private readonly EnterpriseBll _enterpriseBll = new EnterpriseBll(); //企业信息
        private readonly InspectionBll _inspectionBll = new InspectionBll();//现场检查信息
        private readonly LawpersonnelBll _lawpersonnelBll = new LawpersonnelBll();//执法人员信息
        private readonly PunishCaseBll _punishCaseBll = new PunishCaseBll();//执法案件信息
        private readonly LawbasisBll _lawbasisBll = new LawbasisBll();//执法依据信息
        private readonly RectificationBll _rectificationBll = new RectificationBll();//责令整改信息
        private readonly CorrectiveReviewBll _correctivereviewBll = new CorrectiveReviewBll();//整改复查信息
        private readonly CrmDepartmentBll _crmdeparmentBll = new CrmDepartmentBll();//部门信息

        #region 企业

        /// <summary>
        /// 企业信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterpriseIndex()
        {
            return View();
        }

        /// <summary>
        /// 请求企业信息列表
        /// </summary>
        /// <param name="companyName">企业名称</param>
        /// <param name="rows">每页条数</param>
        /// <param name="page">当前索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public string QueryEnterpriseList(string companyName, int rows, int page, string sidx, string sord)
        {
            var data = _enterpriseBll.QueryEnterpriseList(companyName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 企业详情
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterpriseDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _enterpriseBll.GetEnterpriseDetail(id);
                ViewBag.Details = data;
            }
            return View();
        }
        #endregion

        #region 执法人员
        /// <summary>
        /// 获取执法人员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult LawpersonnelIndex()
        {
            return View();
        }
        /// <summary>
        /// 请求执法人员信息列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryLawpersonnelList(string userName, int rows, int page, string sidx, string sord)
        {
            var data = _lawpersonnelBll.QueryLawpersonnelList(userName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        /// <summary>
        /// 执法人员详情
        /// </summary>
        /// <returns></returns>
        public ActionResult LawpersonnelDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _lawpersonnelBll.GetLawpersonnelDetail(id);
                ViewBag.Details = data;
            }
            return View();
        }
        #endregion

        #region 执法案件
        /// <summary>
        /// 案件信息
        /// </summary>
        /// <returns></returns>
        public ActionResult PunishCaseIndex()
        {
            return View();
        }
        /// <summary>
        /// 请求案件信息列表
        /// </summary>
        /// <param name="caseName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryPunishCaseList(string caseNo, int rows, int page, string sidx, string sord)
        {
            var data = _punishCaseBll.QueryPunishCaseList(caseNo, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 案件详情
        /// </summary>
        /// <param name="caseNo"></param>
        /// <returns></returns>
        public ActionResult PunishCaseDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _punishCaseBll.GetPunishCaseDetail(id);
                ViewBag.Details = data;
                if (data.Rows.Count > 0)
                {
                    var enterprise = _enterpriseBll.GetEnterpriseDetail(data.Rows[0]["拟处罚单位"].ToString());
                    ViewBag.Enterprise = enterprise;
                }
            }
            return View();
        }
        #endregion

        #region 执法依据
        /// <summary>
        /// 请求执法依据信息
        /// </summary>
        /// <returns></returns>
        public ActionResult LawbasisIndex()
        {
            return View();
        }
        /// <summary>
        /// 请求执法依据信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryLawbasisList(string lawName, int rows, int page, string sidx, string sord)
        {
            var data = _lawbasisBll.QueryLawbasisList(lawName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        /// <summary>
        /// 执法依据详情
        /// </summary>
        /// <returns></returns>
        public ActionResult LawbasisDetail(string lawName, string lawterm)
        {
            if (!string.IsNullOrEmpty(lawName))
            {
                var data = _lawbasisBll.GetLawbasisDetail(lawName, lawterm);
                ViewBag.Details = data;
            }
            return View();
        }
        #endregion

        #region 现场检查
        /// <summary>
        /// 现场检查信息
        /// </summary>
        /// <returns></returns>
        public ActionResult InspectionIndex()
        {
            return View();
        }

        /// <summary>
        /// 请求现场检查列表
        /// </summary>
        /// <param name="enterpriseName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryInspectionList(string companyName, int rows, int page, string sidx, string sord)
        {
            var data = _inspectionBll.QueryInspectionList(companyName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 现场检查记录详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult InspectionIndexDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _inspectionBll.GetInspectionDetail(id);
                ViewBag.Details = data;
                if (data.Rows.Count > 0)
                {
                    var enterprise = _enterpriseBll.GetEnterpriseDetail(data.Rows[0]["企业名称"].ToString());
                    ViewBag.Enterprise = enterprise;
                }
            }
            return View();
        }
        #endregion

        #region 责令整改
        /// <summary>
        /// 责令整改信息
        /// </summary>
        /// <returns></returns>
        public ActionResult RectificationIndex()
        {
            return View();
        }

        /// <summary>
        /// 请求责令整改信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryRectificationList(string lawName, int rows, int page, string sidx, string sord)
        {
            var data = _rectificationBll.QueryRectificationList(lawName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 责令整改详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RectificationDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _rectificationBll.GetRectificationDetail(id);
                ViewBag.Details = data;
                //if (data.Rows.Count > 0)
                //{
                //    var enterprise = _enterpriseBll.GetEnterpriseDetail(data.Rows[0]["企业名称"].ToString());
                //    ViewBag.Enterprise = enterprise;
                //}
            }
            return View();
        }
        #endregion

        #region 整改复查
        /// <summary>
        /// 请求整改复查信息
        /// </summary>
        /// <returns></returns>
        public ActionResult CorrectiveReviewIndex()
        {
            return View();
        }

        /// <summary>
        /// 请求整改复查信息列表
        /// </summary>
        /// <param name="lawName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryCorrectiveList(string lawName, int rows, int page, string sidx, string sord)
        {
            var data = _correctivereviewBll.QueryCorrectiveReviewList(lawName, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// 整改复查详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CorrectiveReviewDetail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var data = _correctivereviewBll.GetCorrectiveReviewDetail(id);
                ViewBag.Details = data;
            }
            return View();
        }
        #endregion


        #region 安全生产报表

        /// <summary>
        /// 分析界面
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseSaftyAnalysisIndex()
        {
            //企业总数
            DataTable entDt = _enterpriseBll.QueryEnterpriseList();
            ViewData["entCT"] = entDt.Rows.Count;
            //现检数
            DataTable insDt = _inspectionBll.QueryInspectionList("");
            ViewData["insCT"] = insDt.Rows.Count;
            //责令整改数
            DataTable recDt = _rectificationBll.QueryRectificationList("");
            ViewData["recCT"] = recDt.Rows.Count;
            //整改复查数
            DataTable corDt = _correctivereviewBll.QueryCorrectiveReviewList("");
            ViewData["corCT"] = corDt.Rows.Count;
            //执法案件数
            DataTable casDt = _punishCaseBll.QueryPunishCaseList();
            ViewData["casCT"] = casDt.Rows.Count;
            //执法人员数
            DataTable perDt = _lawpersonnelBll.QueryLawpersonnelList();
            ViewData["perCT"] = perDt.Rows.Count;


            //查询部门
            //List<CrmDepartmentEntity> deptList = _crmdeparmentBll.GetAllDepartment(new CrmDepartmentEntity());
            //deptList = deptList.Where(p => p.FullName.IndexOf("社工委") != -1 || p.FullName.IndexOf("街道") != -1).ToList();
            //ViewData["deptList"] = deptList;


            DataTable entDtSearch = _enterpriseBll.QueryEnterpriseListForAnalysis();
            ViewData["entSearch"] = entDtSearch;
            ViewData["insSearch"] = insDt;
            ViewData["recSearch"] = recDt;
            ViewData["corSearch"] = corDt;

            //网格占比图标
            int yfpWg = entDt.Select("所属网格 is not null").Count();
            int wfpWg = entDt.Rows.Count - yfpWg; ;
            ViewData["yfpWg"] = yfpWg;
            ViewData["wfpWg"] = wfpWg;

            //每月现检数量
            string date = "2018-10-01";
            DataTable insDtSearchList = _inspectionBll.QueryInspectionListForDateTime(date);
            string Date = "";
            string Ct = "";
            for (int i = 0; i < insDtSearchList.Rows.Count; i++)
            {
                Date += insDtSearchList.Rows[i]["date"].ToString() + ",";
                Ct += insDtSearchList.Rows[i]["ct"].ToString() + ",";
            }
            ViewData["date"] = Date.Substring(0, Date.Length - 1);
            ViewData["ct"] = Ct.Substring(0, Ct.Length - 1);


            return View();
        }


        /// <summary>
        /// 统计界面
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseSaftyStatisticsIndex(string year,string month)
        {
            DateTime dt;
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month) )
            {
                BindDate(DateTime.Now.Year, DateTime.Now.Month);
                dt = DateTime.Now;
            }
            else
            {
                BindDate(int.Parse(year), int.Parse(month));
                dt = Convert.ToDateTime(year + "-" + month + "-01");
            }
            //企业
            DataTable entDtSearch = _enterpriseBll.QueryEnterpriseListForAnalysis();
            ViewData["entSearch"] = entDtSearch;
            //现检数
            DataTable insDt = _inspectionBll.QueryInspectionList(dt.ToString("yyyy-MM-dd"));
            ViewData["insSearch"] = insDt;
            //责令整改数
            DataTable recDt = _rectificationBll.QueryRectificationList(dt.ToString("yyyy-MM-dd"));
            ViewData["recSearch"] = recDt;
            //整改复查数
            DataTable corDt = _correctivereviewBll.QueryCorrectiveReviewList(dt.ToString("yyyy-MM-dd"));
            ViewData["corSearch"] = corDt;


            return View();
        }

        #endregion

        #region

        /// <summary>
        /// 绑定年、月
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="defaultYear">The default year.</param>
        /// <param name="defaultMonth">The default month.</param>
        public void BindDate(int? defaultYear, int? defaultMonth)
        {
            //绑定年（当前时间的前后十年）
            var yearList = new List<int>();
            var year = DateTime.Now.Year - 10;
            for (var i = 0; i < 20; i++)
            {
                var years = year + i;
                yearList.Add(years);
            }

            //绑定月份
            var monthList = new List<int>();
            for (var i = 1; i <= 12; i++)
            {
                monthList.Add(i);
            }
            monthList.Add(0);
            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }

        #endregion
    }
}
