using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Approval;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.DoubleRandom;
using Yookey.WisdomClassed.SIP.Business.Exam;
using Yookey.WisdomClassed.SIP.Business.OfficeIndex;
using Yookey.WisdomClassed.SIP.Business.OnlineClass;
using Yookey.WisdomClassed.SIP.Business.Report;
using Yookey.WisdomClassed.SIP.Model.Approval;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Exam;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.HomeIndex
{
    public class HomeIndexController : BaseController
    {
        private readonly CrmUserBll _crmUserBll = new CrmUserBll(); //用户
        private readonly OfficeIndexBll _officeIndexBll = new OfficeIndexBll();
        private readonly CaseReportBll _caseReportBll = new CaseReportBll();
        private readonly DoubleRandomSpotChecksBll _doubleBll = new DoubleRandomSpotChecksBll();
        private readonly InfCarChecksignBll _infCarChecksignBll = new InfCarChecksignBll();
        private readonly CrmCompanyBll _crmCompanyBll = new CrmCompanyBll();//机构信息
        private readonly CrmDepartmentBll _crmDepartmentBll = new CrmDepartmentBll(); //部门
        private readonly TmMatterApplyMajorBll _tmMatterApplyMajorBll = new TmMatterApplyMajorBll();//审批事项
        private readonly TmMatterBll _tmMatterBll = new TmMatterBll();
        private readonly ExamInfoBll _examInfoBll = new ExamInfoBll();//考试
        private readonly ExamInfoMationBll _examInfoMationBll = new ExamInfoMationBll();//考试成绩
        private readonly OnlineClassProgressBll _onlineClassProgressBll = new OnlineClassProgressBll();//学习
        private readonly OnlineClassCourseBll _onlineClassCourseBll = new OnlineClassCourseBll();//课程
        //
        // GET: /HomeIndex/

        /// <summary>
        /// 系统主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 框架首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Main(string Source)
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            if (Source == "1" || Source == "2" || Source == "3" || Source == "4")
            {
                Source = "000" + Source;
            }
            ViewBag.Source = Source;
            return View();
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadAccordionMenu(string source, string para)
        {
            try
            {
                if (string.IsNullOrEmpty(source))
                {
                    if (!string.IsNullOrEmpty(para))
                    {
                        source = "0000";
                    }
                    else
                    {
                        source = "0001";
                    }
                }
                var currentUser = CurrentUser.CrmUser;
                var list = new List<ComMenuEntity>();
                var userMenus = new ComMenuBll().GetAllMenu(new ComMenuEntity() { ParentMenuId = source });
                if (userMenus.Any())
                {
                    list.AddRange(userMenus);
                    var secMenuList = new ComMenuBll().GetAllMenu(new ComMenuEntity()).Where(x => userMenus.Any(y => y.Id == x.ParentMenuId)).ToList();
                    if (secMenuList.Any())
                    {
                        list.AddRange(secMenuList);
                    }
                }
                var menuList = list.Select(comMenuEntity => new TreeMenuNode()
                {
                    ModuleId = comMenuEntity.Id,
                    FullName = comMenuEntity.MenuName,
                    Icon = comMenuEntity.Action,
                    Location = comMenuEntity.MenuUrl,
                    ParentId = string.IsNullOrEmpty(comMenuEntity.ParentMenuId) ? "" : comMenuEntity.ParentMenuId,
                    MenuLevel = comMenuEntity.MenuLevel
                }).ToList();
                var json = Json(menuList, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region 日常办公
        /// <summary>
        /// 日常办公页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OfficeIndex()
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            return View();
        }


        /// <summary>
        /// 日常办公页面右侧初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OfficeRight()
        {
            return View();
        }

        /// <summary>
        /// 获取部门平均分
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeptScore()
        {
            var getCompany = _crmCompanyBll.GetAllEnforcementUnit();
            List<ScoreEntity> dic = new List<ScoreEntity>();
            var examList = _examInfoBll.GetExamInfoList(new ExamInfoEntity() { PaperType = "正式考试" });
            var mation = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity() { }).Where(x => examList.Any(y => y.Tid == x.Tid)).ToList();
            foreach (var item in getCompany)
            {
                var deptList = _crmDepartmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = item.Id });
                var userList = _crmUserBll.GetAllUsers(new CrmUserEntity() { }).Where(x => deptList.Any(y => y.Id == x.DepartmentId)).ToList();
                int allScore = 0; double avgScore = 0;
                foreach (var user in userList)
                {
                    int userScore = 0, useravgScore = 0;
                    var Umation = mation.Where(x => x.Uid == user.Id).ToList();
                    Umation.ForEach(x => userScore += Convert.ToInt32(x.Source));
                    if (Umation.Count > 0)
                    {
                        useravgScore = userScore / (Umation.Count);
                    }
                    allScore += useravgScore;
                }
                avgScore = ((double)allScore / (userList.Count));
                dic.Add(new ScoreEntity()
                {
                    deptName = item.FullName.Replace("综合执法大队", " "),
                    score = avgScore
                });
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public class ScoreEntity
        {
            /// <summary>
            /// 部门
            /// </summary>
            public string deptName { get; set; }

            /// <summary>
            /// 平均分
            /// </summary>
            public double score { get; set; }
        }

        /// <summary>
        /// 获取前10学习 时长
        /// </summary>
        /// <returns></returns>
        //public JsonResult GetLongTime()
        //{
        //    List<LongEntity> dic = new List<LongEntity>();
        //    var getCompany = _crmCompanyBll.GetAllEnforcementUnit().Where(x => x.Id == "def6350f-adf1-417c-b7a8-a09c3299d6c9").ToList();

        //    var deptList = _crmDepartmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = getCompany[0].Id });
        //    var userList = _crmUserBll.GetAllUsers(new CrmUserEntity() { }).Where(x => deptList.Any(y => y.Id == x.DepartmentId)).ToList();
        //    foreach (var user in userList)
        //    {
        //        int userLong = 0;
        //        _onlineClassProgressBll.GetSearchResult(new OnlineClassProgressEntity() { UserId = user.Id }).ForEach(x => userLong += Convert.ToInt32(x.TotalTime));
        //        user.timeLong = userLong;
        //    }
        //    var userAny = userList.OrderByDescending(x => x.timeLong).ToList();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        dic.Add(new LongEntity()
        //        {
        //            Name = userAny[i].RealName,
        //            Time = (double)userAny[i].timeLong / 60
        //        });
        //    }
        //    return Json(dic, JsonRequestBehavior.AllowGet);
        //}

        public class LongEntity
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 时长
            /// </summary>
            public double Time { get; set; }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public string GetStatistics()
        {
            int allCourse = (Int32)_onlineClassCourseBll.GetCourseManager("", 1, 10, "").TotalItems;//全部
            int videoCourse = (Int32)_onlineClassCourseBll.GetCourseManager("1", 1, 10, "").TotalItems;//视频
            int audioCourse = (Int32)_onlineClassCourseBll.GetCourseManager("2", 1, 10, "").TotalItems;//音频
            int pictureCourse = (Int32)_onlineClassCourseBll.GetCourseManager("3", 1, 10, "").TotalItems;//图文
            int joinUserCount = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity() { }).GroupBy(t => t.Uid).Select(t => t.First()).ToList().Count;//获取参考人员总数
            int joinCount = _examInfoMationBll.GetSearchResult(new ExamInfoMationEntity() { }).Count;//获取参考次数
            var entity = new Statistics()
            {
                allCourse = allCourse,
                videoCourse = videoCourse,
                audioCourse = audioCourse,
                pictureCourse = pictureCourse,
                joinUserCount = joinUserCount,
                joinCount = joinCount
            };
            //_count.todayct = _officeIndexBll.TodayCount();//获取今日案件投诉量
            //_count.dealct = _officeIndexBll.TodaydealCount();//获取今日投诉处理
            //_count.ratect = _officeIndexBll.Todaydealrate();//获取信访投诉办结率
            //_count.ygxfct = _officeIndexBll.Complaintreporting();//获取阳光信访
            //_count.tzbct = _officeIndexBll.Districtparty();//获取区党政办
            //_count.areact = _officeIndexBll.AreaComplaintreporting();//获取区信访科
            //_count.jdct = _officeIndexBll.AreaPublic();//获取区公众监督
            //_count.bureauct = _officeIndexBll.Citybureau();//获取市局
            return JsonConvert.SerializeObject(entity);
        }

        public class Statistics
        {
            /// <summary>
            /// 获取全部课件总数
            /// </summary>
            public int allCourse { get; set; }

            /// <summary>
            /// 获取视频类课件总数
            /// </summary>
            public int videoCourse { get; set; }

            /// <summary>
            /// 获取音频类课件总数
            /// </summary>
            public int audioCourse { get; set; }

            /// <summary>
            /// 获取图文类课件总数
            /// </summary>
            public int pictureCourse { get; set; }

            /// <summary>
            /// 获取参考人员总数
            /// </summary>
            public int joinUserCount { get; set; }

            /// <summary>
            /// 获取参考次数
            /// </summary>
            public int joinCount { get; set; }
        }
        #endregion

        #region 日常管理
        /// <summary>
        /// 日常管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ManagementIndex()
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            return View();
        }

        /// <summary>
        /// 日常管理页面右侧初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ManagemenRight()
        {
            //获取日案件登记数
            var searchTime = DateTime.Now.ToString("yyyy-MM-dd");
            var startTime = searchTime + " 00:00:00.000";
            var endTime = searchTime + " 23:59:59.997";
            ViewBag.DayCount = _caseReportBll.CaseCatalogDay(startTime, endTime);
            //获取各大队日案件登记数
            //ViewData["DayCountOfCompany"] = new CaseReportBll().GetCaseCatalogOfCompany();

            return View();
        }
        #endregion

        #region 综合执法
        /// <summary>
        /// 综合执法业务处理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessIndex()
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            return View();
        }


        /// <summary>
        ///综合执法业务处理页面右侧初始化页面 
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessRight()
        {

            #region 实时数据

            //行政处罚

            //处罚金额

            //贴单量

            //纠处量

            //双随机抽查情况

            //双随机督查情况


            #endregion


            #region 案件分类

            #endregion


            #region 案件占比情况

            #endregion


            #region 违法行为TOP10

            #endregion


            #region 静态数据

            #endregion

            var searchTime = DateTime.Now.ToString("yyyy-MM-dd");
            var startTime = Convert.ToDateTime(searchTime).Year + "-01-01 00:00:00.000";
            var endTime = Convert.ToDateTime(searchTime).Year + "-12-31 23:59:59.997";
            //获取双随机抽查数据
            ViewBag.DoubleRandomCount = 0;
            ViewBag.DoubleRandomObjCount = 0;
            var drList = _doubleBll.GetRandomCount(startTime, endTime, "1");
            int drCount = 0;
            if (drList != null & drList.Count > 0)
            {
                ViewBag.DoubleRandomCount = drList.Count;
                foreach (var item in drList)
                {
                    drCount += item.ObjNo;
                }
                ViewBag.DoubleRandomObjCount = drCount;
            }
            //获取双随机督查数据
            ViewBag.RandomInspectorCount = 0;
            ViewBag.RandomInspectorObjCount = 0;
            var riList = _doubleBll.GetRandomCount(startTime, endTime, "0");
            int riCount = 0;
            if (riList != null & riList.Count > 0)
            {
                ViewBag.RandomInspectorCount = riList.Count;
                foreach (var item in riList)
                {
                    riCount += item.ObjNo;
                }
                ViewBag.RandomInspectorObjCount = riCount;
            }
            //获取行政处罚数据
            ViewBag.TotalPunishmentCount = _infCarChecksignBll.GetParkingCount(startTime, endTime) + new CaseReportBll().CaseCatalogDay(startTime, endTime);
            //占比分析
            return View();
        }

        /// <summary>
        /// 一张图监管
        /// </summary>
        /// <returns></returns>
        public ActionResult PremapIndex()
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            return View();
        }

        #endregion

        #region 系統框架首頁
        public ActionResult AccordionIndex()
        {
            return View();
        }
        #endregion

        #region 许可审批统计

        /// <summary>
        /// 部门事项统计
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeptMajor(string applyTime)
        {
            var getCompany = _crmCompanyBll.GetAllEnforcementUnit().Where(x => x.FullName.Contains("街道") || x.FullName.Contains("社工委")).ToList();
            var majorList = _tmMatterApplyMajorBll.GetSearchResult(new TmMatterApplyMajorEntity() { ACCEPT_TIME = applyTime });
            List<Entity> dic = new List<Entity>();
            foreach (var item in getCompany)
            {
                var deptList = _crmDepartmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = item.Id });
                var matterList = _tmMatterBll.GetSearchResult(new TmMatterEntity() { }).Where(x => deptList.Any(y => y.FullName == x.DEAL_DEPT)).ToList();
                var list = majorList.Where(x => matterList.Any(y => y.ID == x.MATTER_ID)).ToList();
                dic.Add(new Entity() { Key = item.FullName.Replace("综合执法大队", " "), Value = list.Count });
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 事项办结统计率
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMatterRate(string applyTime)
        {
            var majorList = _tmMatterApplyMajorBll.GetSearchResult(new TmMatterApplyMajorEntity() { ACCEPT_TIME = applyTime });
            List<Entity> dic = new List<Entity>();
            var matterList = _tmMatterBll.GetSearchResult(new TmMatterEntity() { });
            foreach (var item in matterList)
            {
                double lv = 0;
                //办结数
                var complelist = majorList.Where(x => x.MATTER_ID == item.ID).ToList().Where(x => x.DONE_TIME != null).ToList();
                //未逾期办结数
                var duelist = majorList.Where(x => x.MATTER_ID == item.ID).ToList().Where(x => x.OVERDUE == 0).Where(x => x.DONE_TIME != null).ToList();
                //办结率
                if (complelist.Count > 0)
                {
                    lv = (duelist.Count / complelist.Count) * 100;
                }
                dic.Add(new Entity() { Key = item.MATTER_SIMPLE_NAME, dValue = lv, FValue = complelist.Count, SValue = duelist.Count });
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 事项办理统计
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMatter(string applyTime)
        {
            var majorList = _tmMatterApplyMajorBll.GetSearchResult(new TmMatterApplyMajorEntity() { ACCEPT_TIME = applyTime });
            List<Entity> dic = new List<Entity>();
            var matterList = _tmMatterBll.GetSearchResult(new TmMatterEntity() { });
            foreach (var item in matterList)
            {
                //总个数
                var list = majorList.Where(x => x.MATTER_ID == item.ID).ToList();
                //未办结数
                var uncomplelist = majorList.Where(x => x.MATTER_ID == item.ID).ToList().Where(x => x.DONE_TIME == null).ToList();
                //办结数
                var complelist = majorList.Where(x => x.MATTER_ID == item.ID).ToList().Where(x => x.DONE_TIME != null).ToList();
                //逾期数
                var duelist = majorList.Where(x => x.MATTER_ID == item.ID).ToList().Where(x => x.OVERDUE == 1).ToList();
                dic.Add(new Entity() { Key = item.MATTER_SIMPLE_NAME, Value = list.Count, FValue = uncomplelist.Count, SValue = complelist.Count, TValue = duelist.Count });
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 事项上报统计率
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMatterCount(string applyTime)
        {
            var majorList = _tmMatterApplyMajorBll.GetSearchResult(new TmMatterApplyMajorEntity() { ACCEPT_TIME = applyTime });
            List<Entity> dic = new List<Entity>();
            var matterList = _tmMatterBll.GetSearchResult(new TmMatterEntity() { });
            foreach (var item in matterList)
            {
                //总个数
                var list = majorList.Where(x => x.MATTER_ID == item.ID).ToList();
                dic.Add(new Entity() { Key = item.MATTER_SIMPLE_NAME, Value = list.Count });
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public class Entity
        {
            /// <summary>
            /// 键
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// 值
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// 值1
            /// </summary>
            public int FValue { get; set; }

            /// <summary>
            /// 值2
            /// </summary>
            public int SValue { get; set; }

            /// <summary>
            /// 值3
            /// </summary>
            public int TValue { get; set; }

            /// <summary>
            /// double值
            /// </summary>
            public double dValue { get; set; }
        }
        #endregion
    }
}
