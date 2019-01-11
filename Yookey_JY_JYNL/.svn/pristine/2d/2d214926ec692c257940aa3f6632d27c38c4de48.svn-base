using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Hr;
using NPOI.POIFS.FileSystem;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;
using System.Threading.Tasks;
namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class LochusFlightController : BaseController
    {
        private readonly FlightLochusAppearBll _flightLochusAppearBll = new FlightLochusAppearBll();
        private readonly FlightMonitorBll _flightMonitorBll = new FlightMonitorBll();
        private readonly ComResourceBll _comResourceBll = new ComResourceBll();
        private readonly CrmDepartmentBll _departmentBll = new CrmDepartmentBll();
        private readonly CrmUserBll _crmUserBll = new CrmUserBll();
        private readonly FlightClassesOfDeptmentBll _flightClassesOfDeptment = new FlightClassesOfDeptmentBll();//部门班别设定
        private readonly FlightParticularBll _FlightParticularBll = new FlightParticularBll();//明细表
        readonly FlightOfEmpBll _flightOfEmpBll = new FlightOfEmpBll();

        #region 视图

        /// <summary>
        /// 排班管理
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">所属部门</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="scroll">滚动条的位置</param>
        /// <returns>ActionResult.</returns>
        public ActionResult FlightList(string companyId, string deptId, int? year, int? month, int? scroll, DateTime? beginTime, DateTime? endTime)
        {
            var user = CurrentUser.CrmUser;
            if (string.IsNullOrEmpty(deptId))
                deptId = user.DeptId;

            if (string.IsNullOrEmpty(companyId))
                companyId = user.CompanyId;

            ViewBag.CompanyId = companyId;
            ViewBag.DeptId = deptId;
            ViewBag.ScrollValue = scroll ?? 0;

            //绑定排班列表
            year = year ?? DateTime.Now.Year;
            month = month ?? DateTime.Now.Month;

            //绑定日期
            BindDate(year, month);
            //绑定排班表
            BindTable(year, month, companyId, deptId, true, beginTime, endTime);

            return View();
        }

        /// <summary>
        /// 选择人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">班次编号</param>
        /// <param name="date">排班日期</param>
        ///  /// <param name="yearMonth">排班月份</param>
        /// <returns>ActionResult.</returns>
        public ActionResult SelectUser(string deptId, string classesId, string date, string yearMonth)
        {
            //执法大队下所有部门
            var dept = _departmentBll.Get(deptId);
            List<CrmDepartmentEntity> depts = new List<CrmDepartmentEntity>();
            depts.Add(dept);
            ViewData["Depts"] = new SelectList(depts, "Id", "FullName", deptId);

            //班次
            var classes = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId);
            //var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0037" });
            classes.Insert(0, new FlightClassesOfDeptmentEntity { Id = "", ClassesId = "==请选择==" });
            ViewData["Classes"] = new SelectList(classes, "Id", "ClassesId", classesId);

            //已选择人员集
            var userIds = _flightLochusAppearBll.GetFlightOfUsersIds(deptId, classesId, date);
            ViewBag.Users = userIds;
            //排班日期
            ViewBag.FlightDay = date;
            // 排班的月份
            ViewBag.YearMonth = yearMonth;
            return View();
        }

        /// <summary>
        /// 拷贝复制排班
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formDate">被复制日期</param>
        /// <param name="deptId">所属中队</param>
        /// <returns>ActionResult.</returns>
        public ActionResult FlightCopy(string formDate, string deptId)
        {
            ViewBag.FormDate = formDate;
            ViewBag.DeptId = deptId;

            var fd = Convert.ToDateTime(formDate).AddMonths(1);

            //绑定日期
            BindDate(fd.Year, fd.Month);
            return View();
        }

        /// <summary>
        /// 排班报表
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="scroll">滚动条高度</param>
        /// <returns>ActionResult.</returns>
        public ActionResult FlightReport(int? year, int? month, int? scroll, string companyId, string deptId)
        {
            ViewBag.ScrollValue = scroll ?? 0;
            ViewBag.CompanyId = companyId;
            ViewBag.DeptId = deptId;

            //绑定排班列表
            year = year ?? DateTime.Now.Year;
            month = month ?? DateTime.Now.Month;

            //绑定日期
            BindDate(year, month);
            if (string.IsNullOrEmpty(companyId))
            {
                ViewData["FlightReports"] = new List<FlightReport>();
                return View();
            }
            if (companyId == "all")
            {
                companyId = "";
            }
            if (string.IsNullOrEmpty(deptId) || deptId == "all")//不能让部门为空
            {
                deptId = CurrentUser.CrmUser.DeptId;//默认当前登入人
            }
            ViewBag.deptId = deptId;
            //查询数据源
            var flightList = JsonConvert.SerializeObject(_flightLochusAppearBll.GetMonthReport(year, month, companyId, deptId));
            ViewData["FlightReports"] = flightList;

            return View();
        }

        /// <summary>
        /// 选择排班值班长
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="data">排班日期</param>
        /// <param name="ctype">值班类型：总值班长、正值班长</param>
        /// <param name="obj"></param>
        /// <returns>ActionResult.</returns>
        public ActionResult FlightChief(string data, string ctype, string obj)
        {
            var deptId = "";
            var userId = "";

            if (!string.IsNullOrEmpty(ctype))
            {
                if (ctype.Equals("watch"))
                {
                    ViewBag.ChiefType = "总值班";
                }
                else if (ctype.Equals("monitor"))
                {
                    ViewBag.ChiefType = "正值班长";
                }
                else if (ctype.Equals("depudy"))
                {
                    ViewBag.ChiefType = "副值班长";
                }
                ViewBag.ctype = ctype;
                var entity = _flightMonitorBll.GetEntityByDay(data);
                if (entity != null)
                {
                    if (ctype.Equals("watch"))
                    {
                        deptId = entity.DeptIdI;
                        userId = entity.ChiefWatch;
                    }
                    else if (ctype.Equals("monitor"))
                    {
                        deptId = entity.DeptIdII;
                        userId = entity.ChiefMonitor;
                    }
                    else if (ctype.Equals("depudy"))
                    {
                        deptId = entity.DeptIdIII;
                        userId = entity.DeputyMonitor;
                    }
                }
            }
            ViewBag.obj = obj;
            ViewBag.FlightDay = data;
            ViewBag.DeptId = deptId;
            ViewBag.UserId = userId;

            //执法大队下所有部门
            //var depts = _departmentBll.GetAllDepartment();
            //ViewData["Depts"] = new SelectList(depts, "Id", "FullName");

            return View();
        }

        /// <summary>
        /// 人员班次统计
        /// 添加人：周 鹏
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>ActionResult.</returns>
        public ActionResult FlightUserReport(string companyId, string deptId)
        {
            //执法大队下所有部门
            //var depts = _departmentBll.GetAllDetachment("all");
            // ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", CurrentUser.CrmUser.DeptId);
            var endTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-25");
            var startTime = DateTime.Parse(endTime.AddMonths(-1).ToString("yyyy-MM") + "-26");
            ViewBag.StartTime = startTime.ToString(AppConst.DateFormat); ;
            ViewBag.EndTime = endTime.ToString(AppConst.DateFormat);
            ViewBag.CompanyId = companyId;
            ViewBag.deptId = deptId;
            return View();
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        public ActionResult UpLoad(string deptId, string flag = "")
        {
            ViewBag.DeptId = deptId;
            ViewBag.Flag = flag;
            return View();
        }

        #endregion

        #region 绑定排班记录

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

            ViewData["Months"] = new SelectList(monthList, defaultMonth);


            if (DateTime.Now.Year == 12 && defaultYear != 12)   //如果当前月份为12月份,则年份则默认为下一年的时间
            {
                ViewData["Years"] = new SelectList(yearList, DateTime.Now.AddYears(1).Year);
            }
            else
            {
                ViewData["Years"] = new SelectList(yearList, defaultYear);
            }
        }

        /// <summary>
        /// 绑定排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="isReport">是否上报</param>
        public void BindTable(int? year, int? month, string companyId, string deptId, bool isReport, DateTime? beginTime, DateTime? finshTime)
        {
            try
            {
                var user = CurrentUser.CrmUser;
                var sdata = string.Empty;
                // 每月的排班从上个月26至 本月的 25号
                if (month - 1 == 0)
                {
                    sdata = year - 1 + "-" + "12" + "-" + "26";//选的是一月份的话是去年的十二月26
                }
                else
                {
                    sdata = year + "-" + (month - 1) + "-" + "26";  //排班日期 开始
                }

                var edata = year + "-" + month + "-" + "25";  //排班日期 结束


                var appearDt = _flightLochusAppearBll.SelectAppear(deptId, edata);    //部门排班信息

                var state = 0;    //排班状态
                if (appearDt != null && appearDt.Rows.Count > 0)
                {
                    state = int.Parse(appearDt.Rows[0]["State"].ToString());
                }
                ViewBag.State = state;

                //排班集合
                var flightList = new List<FlightMaster>();

                var startTime = beginTime ?? DateTime.Parse(sdata);     //开始日期（上个月的26号）   没有选周的时候默认每月26
                var endTime = finshTime ?? DateTime.Parse(edata);     //结束日期（本月的25号）;    没有选周的时候默认下月25

                var classes = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId);  //所有班次
                List<FlightClassesOfDeptmentEntity> flightClassesOfDeptmentList = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId);


                // 当前部门下所有用户
                List<CrmUserEntity> deptUserList = new List<CrmUserEntity>();
                if (!string.IsNullOrEmpty(companyId) && !string.IsNullOrEmpty(deptId))
                {
                    deptUserList = _crmUserBll.GetDeptsUsers(new CrmUserEntity { DepartmentId = deptId }).ToList();
                }

                #region//当月查询  插入休息人员
                //获取部门当月部门的所有排班
                var selectPpople = _flightOfEmpBll.GetFlightOfUsersBydeptIdDate(deptId, startTime.ToString(AppConst.DateFormatLong));
                List<DateTime> daysList = new List<DateTime>();//一个月的时间集合
                for (DateTime dtN = startTime; dtN <= endTime; dtN = dtN.AddDays(1))
                {
                    daysList.Add(dtN);
                }
                foreach (var temp in daysList)
                {
                    var classModel = classes.FirstOrDefault(i => i.ClassesName == "休息");//获取休息的排班部门对应表的ID
                    if (classModel == null)//当前部门没有休息的排班类别
                    {
                        break;//跳出整个插入默认休息的循环
                    }
                    var selectPpople_Month = selectPpople.Where(i => (DateTime.Parse(i.Date) - temp).Days == 0).ToList();//筛选当天的排班
                    var deptUserListNow = deptUserList.Where(i => selectPpople_Month.FirstOrDefault(z => z.UserId == i.Id) == null).ToList();//当前部门当天是否有排班
                    if (deptUserListNow == null || deptUserListNow.Count == 0)//当天没有未排班的人员这里应该删除当天休息的数据保证排班和休息的唯一性
                    {
                        continue;
                    }
                    var userIds = string.Join(",", deptUserListNow.Select(i => i.Id));

                    _flightLochusAppearBll.SaveFlight(deptId, classModel.Id, temp, userIds, null, user.Id, user.UserName, year + "-" + month);
                }
                #endregion


                //循环遍历天
                foreach (var dtN in daysList)
                {
                    var flightEntity = new FlightMaster();    //排班实体

                    var week = CommonMethod.GetWeek(dtN);
                    flightEntity.Date = dtN;    //日期
                    flightEntity.Week = week;       //星期
                    flightEntity.FlightDetailses = new List<FlightDetails>();   //排班明细：班次、人员

                    //循环遍历班次,查询排班人员详情（除休息）
                    foreach (var classEntity in classes)
                    {
                        string strUsers = string.Empty;
                        List<FlightOfUsers> flightOfUserList = _flightLochusAppearBll.GetFlightOfUsers(deptId, classEntity.Id, dtN.ToString(AppConst.DateFormatLong), out strUsers);
                        FlightClassesOfDeptmentEntity classesOfDeptmentEntity = flightClassesOfDeptmentList.FirstOrDefault(r => r.Id == classEntity.Id);//按班次循环的对应班次

                        #region//老数据排班名和时间段显示逻辑
                        //查询明细表 通过时间和排班部门对应表的id
                        var classInfromation = _FlightParticularBll.SelectParticularNoappearId(classEntity.Id, dtN.ToString("yyyy-MM-dd"));//查询这个天的这个类型的这个部门的排班的历史排班名称和时间
                        var className = string.Empty;
                        var classBeginTime = string.Empty;
                        var classEndTime = string.Empty;
                        if (classInfromation != null && classInfromation.Rows.Count > 0)
                        {
                            var oneRow = classInfromation.Select().First();
                            className = oneRow["ClassName"].ToString();
                            classBeginTime = oneRow["ClassBeginTime"].ToString();
                            classEndTime = oneRow["ClassEndTime"].ToString();
                        }
                        #endregion

                        //排班详情实体
                        var flightDetailsEntity = new FlightDetails
                            {
                                ClassesId = classEntity.Id,//部门排班表的ID
                                ClassesName = classEntity.ClassesId,
                                TimeInterval = classesOfDeptmentEntity != null ? classesOfDeptmentEntity.TimePeriodState + "-" + classesOfDeptmentEntity.TimePeriodEnd : "",
                                UserNames = strUsers
                            };

                        #region//老数据排班名和时间段赋值
                        if (!string.IsNullOrEmpty(classBeginTime) && !string.IsNullOrEmpty(classEndTime))
                        {
                            flightDetailsEntity.ClassesName = className;
                            flightDetailsEntity.TimeInterval = classBeginTime + "-" + classEndTime;
                        }
                        #endregion

                        flightEntity.FlightDetailses.Add(flightDetailsEntity);
                    }

                    flightList.Add(flightEntity);

                }

                ViewData["FlightMasters"] = flightList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Ajax 数据请求

        /// <summary>
        /// Ajax加载执法人员
        /// 添加人：周 鹏
        /// 添加时间：2014-12-20
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="selectIds">控件名称集</param>
        /// <returns></returns>
        public string AjaxLoadUsers(string deptId, string selectIds)
        {
            var sbUsers = new StringBuilder();

            var selectIdSp = selectIds.Split(',');
            foreach (var selectId in selectIdSp)
            {
                sbUsers.AppendFormat("document.getElementById('{0}').options.length = 1;", selectId);
            }

            if (!string.IsNullOrEmpty(deptId))
            {
                var users = _crmUserBll.GetDeptsFlightUsers(new CrmUserEntity { DepartmentId = deptId }).ToList();
                if (users.Count > 0)
                {
                    var i = 0;
                    foreach (var t in users.Where(t => !string.IsNullOrEmpty(t.RealName)))
                    {
                        foreach (var selectId in selectIdSp)
                        {
                            sbUsers.Append("document.getElementById('" + selectId + "').options[" + i + "] = new Option('" +
                                      t.RealName + "', '" + t.Id + "', false, false);");
                        }
                        i++;
                    }
                }
            }
            return sbUsers.ToString();
        }

        /// <summary>
        /// Ajax 请求人员班次报表
        /// 添加人：周 鹏
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string AjaxUserReport(string deptId, string startTime, string endTime)
        {

            var data = _flightLochusAppearBll.UserReport(deptId, startTime, endTime);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        #endregion

        #region Ajax 数据提交

        /// <summary>
        /// 排班保存选择人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-30 周 鹏 增加人员标识类型
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">班次ID</param>
        /// <param name="date">排班日期</param>
        /// <param name="users">选择人员</param>
        /// <param name="userType">人员标识类型：userId,userName</param>
        /// <param name="yearMonth">排班月份</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult SaveSelectUsers(string deptId, string classesId, string date, string users, string userType, string yearMonth)
        {
            bool isOk;
            var msg = "成功";
            try
            {
                if (!string.IsNullOrEmpty(deptId) && !string.IsNullOrEmpty(classesId) && !string.IsNullOrEmpty(date))
                {
                    var user = CurrentUser.CrmUser;

                    //保存排班信息
                    isOk = _flightLochusAppearBll.SaveFlight(deptId, classesId, Convert.ToDateTime(date), users, userType, user.Id,
                                                     user.UserName, yearMonth);
                }
                else
                {
                    isOk = false;
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                msg = "保存出现异常，请联系管理员！";
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = msg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证拷贝复制
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formDate">被复制排班日期</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="toDate">复制至日期</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult CheckCopy(string formDate, string deptId, string toDate)
        {
            var fd = Convert.ToDateTime(formDate);
            var td = Convert.ToDateTime(toDate);

            var state = 0;
            var msg = "";
            try
            {
                formDate = fd.ToString(AppConst.DateFormat);
                toDate = td.ToString(AppConst.DateFormat);

                var appearDt = _flightLochusAppearBll.SelectUserByDay(deptId, formDate);    //部门当天排班信息
                var toAppearDt = _flightLochusAppearBll.SelectUserByDay(deptId, toDate);

                //验证是否满足拷贝复制条件
                if (Convert.ToDateTime(formDate) >= Convert.ToDateTime(toDate))
                {
                    msg = "拷贝复制到的年月份不能小于选择的年月份！";
                    state = 1;
                }
                else if (appearDt == null || appearDt.Rows.Count <= 0)
                {
                    //msg = "该月没有排班，无法拷贝复制到其他月！";
                    msg = "该日没有排班，无法拷贝复制到其他日！";
                    state = 2;
                }
                else if (toAppearDt != null && toAppearDt.Rows.Count > 0)
                {
                    msg = "系统检测到" + td.ToString("yyyy年MM月dd") + "号已有排班数据，继续操作将会替换原有排班数据，是否继续？";
                    state = 4;
                }
                else
                {
                    msg = "满足拷贝复制条件！";
                    state = 10;
                }
            }
            catch (Exception ex)
            {
                state = -1;
                msg = "拷贝复制出现异常，请联系管理员！";
            }
            var result = new StatusModel<DBNull>
            {
                rtState = state,
                rtData = null,
                rtObj = null,
                rtMsrg = msg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 验证拷贝复制
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formDate">被复制排班日期</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="toDate">复制至日期</param>
        /// <param name="isDelete">是否删除已排班过的数据</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult CopyFlights(string formDate, string deptId, string toDate, string isDelete)
        {
            var user = CurrentUser.CrmUser;
            var fd = Convert.ToDateTime(formDate);
            var td = Convert.ToDateTime(toDate);
            var state = 0;
            var msg = "";
            try
            {

                formDate = fd.ToString(AppConst.DateFormat);
                toDate = td.ToString(AppConst.DateFormat);

                var appearDt = _flightLochusAppearBll.SelectUserByDay(deptId, formDate);    //部门排班信息（被复制排班）

                if (!string.IsNullOrEmpty(isDelete) && isDelete.Equals("1"))
                {
                    var toAppearDt = _flightLochusAppearBll.SelectUserByDay(deptId, toDate);
                    if (toAppearDt != null && toAppearDt.Rows.Count > 0)
                    {
                        //删除已有排班
                        _flightLochusAppearBll.DeleteAppear(toAppearDt.Rows[0]["AppearId"].ToString(), toDate);
                    }
                }

                state = _flightLochusAppearBll.CopyFlights(appearDt, deptId, formDate, toDate, user.Id, user.UserName) ? 1 : -1;//拷贝月的

            }
            catch (Exception ex)
            {
                state = -1;
                msg = "拷贝复制出现异常，请联系管理员！";
            }
            var result = new StatusModel<DBNull>
                {
                    rtState = state,
                    rtData = null,
                    rtObj = null,
                    rtMsrg = msg
                };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 排班上报
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="flightDate">排班日期</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="types">操作类型：report 上报 back 退回</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult FlightReportAndBack(string flightDate, string deptId, string types)
        {
            int state;
            string msg;
            try
            {
                var appearDt = _flightLochusAppearBll.SelectAppear(deptId, flightDate + "-01");    //部门排班信息
                if (appearDt != null && appearDt.Rows.Count > 0)
                {
                    _flightLochusAppearBll.UpdateFlightState(!string.IsNullOrEmpty(types) && types.Equals("report") ? 1 : 0, appearDt.Rows[0]["AppearId"].ToString());
                    state = 1;
                    msg = "操作成功！";
                }
                else
                {
                    state = -1;
                    msg = "该月没有排班记录,请先保存该月排班！";
                }
            }
            catch (Exception ex)
            {
                state = -1;
                msg = "过程中出现异常，请联系管理员！";
            }
            var result = new StatusModel<DBNull>
            {
                rtState = state,
                rtData = null,
                rtObj = null,
                rtMsrg = msg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存值班信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="flightDate">排班日期</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="ctype">值班人员类型：总值班长、正值班长</param>
        /// <returns>JsonResult.</returns>
        public JsonResult SaveFlightChief(string flightDate, string deptId, string userId, string userName, string ctype)
        {
            int state;

            string msg;
            try
            {
                if (!string.IsNullOrEmpty(flightDate) && !string.IsNullOrEmpty(userId) &&
                    !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(ctype))
                {
                    var user = CurrentUser.CrmUser;
                    _flightMonitorBll.SaveMonitor(flightDate, deptId, userId, userName, ctype, user.Id, user.UserName);
                    state = 1;
                    msg = "保存成功！";
                }
                else
                {
                    state = -1;
                    msg = "参数信息不完整，请联系管理员！";
                }
            }
            catch (Exception ex)
            {
                state = -1;
                msg = "保存过程中出现异常，请联系管理员！";
            }
            var result = new StatusModel<DBNull>
            {
                rtState = state,
                rtData = null,
                rtObj = null,
                rtMsrg = msg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 导出排班统计
        /// <summary>
        /// 生成Excel排班
        /// </summary>
        /// <returns></returns>
        public bool ExportExcel(int? year, int? month, string fileName, string companyId, string deptId)
        {
            if (companyId == "all")
            {
                companyId = "";
            }

            //查询数据源
            var flightList = _flightLochusAppearBll.GetMonthReport(year, month, companyId, deptId);
            if (flightList.Count > 0)
            {
                string url = AppConfig.FileSaveAddr + @"\DownLoad\" + fileName + ".xls";
                CommonMethod.SaveToFile(RenderToExcel(flightList, fileName), url);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 读取流到EXCLE
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private MemoryStream RenderToExcel(List<FlightReport> lst, string fileName)
        {
            FlightReport col = new FlightReport();

            MemoryStream ms = new MemoryStream();


            using (HSSFWorkbook workbook = new HSSFWorkbook())
            {
                using (Sheet sheet = workbook.CreateSheet())
                {

                    //设置Excel头部样式
                    var topStyle = workbook.CreateCellStyle();
                    topStyle.Alignment = HorizontalAlignment.CENTER;
                    topStyle.VerticalAlignment = VerticalAlignment.CENTER;
                    Font font = workbook.CreateFont();
                    font.FontHeight = 22 * 22;
                    font.Boldweight = short.MaxValue;
                    topStyle.SetFont(font);


                    //设置单元格式-居中
                    var stylecenter = workbook.CreateCellStyle();
                    stylecenter.Alignment = HorizontalAlignment.CENTER;
                    stylecenter.VerticalAlignment = VerticalAlignment.CENTER;
                    stylecenter.BorderTop = CellBorderType.THIN;
                    stylecenter.BorderBottom = CellBorderType.THIN;
                    stylecenter.BorderLeft = CellBorderType.THIN;
                    stylecenter.BorderRight = CellBorderType.THIN;
                    stylecenter.TopBorderColor = IndexedColors.BLACK.Index;
                    stylecenter.BottomBorderColor = IndexedColors.BLACK.Index;
                    stylecenter.LeftBorderColor = IndexedColors.BLACK.Index;
                    stylecenter.RightBorderColor = IndexedColors.BLACK.Index;
                    stylecenter.WrapText = true;

                    //行标题
                    Row topRow = sheet.CreateRow(0);
                    topRow.CreateCell(0).SetCellValue("执法大队" + fileName + "表");
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                    topRow.GetCell(0).CellStyle = topStyle;
                    topRow.HeightInPoints = 40;

                    //行列头
                    Row headerRow = sheet.CreateRow(1);
                    for (int i = 0; i < col.ColFileName.Length; i++)
                    {
                        headerRow.CreateCell(i).SetCellValue(col.ColFileName[i]);
                        headerRow.GetCell(i).CellStyle = stylecenter;
                    }
                    headerRow.HeightInPoints = 50;

                    //行数据
                    int rowIndex = 2;
                    foreach (FlightReport row in lst)
                    {
                        var startIndex = rowIndex;
                        //foreach (FlightReportDetails detail in row.FlightReportDetails)
                        //{
                        //    Row dataRow = sheet.CreateRow(rowIndex);
                        //    dataRow.CreateCell(0).SetCellValue(row.Date.Day);
                        //    dataRow.CreateCell(1).SetCellValue(row.Week.Substring(row.Week.Length - 1));

                        //    dataRow.CreateCell(2).SetCellValue(detail.DeptName);
                        //    dataRow.CreateCell(3).SetCellValue(detail.ForeShift);
                        //    dataRow.CreateCell(4).SetCellValue(detail.MiddleShift);
                        //    dataRow.CreateCell(5).SetCellValue(detail.NightShift);
                        //    dataRow.CreateCell(6).SetCellValue(detail.DayShift);
                        //    dataRow.CreateCell(7).SetCellValue(detail.Rest);

                        //    for (int i = 0; i <= 7; i++)
                        //        dataRow.GetCell(i).CellStyle = stylecenter;

                        //    rowIndex++;
                        //}
                        sheet.AddMergedRegion(new CellRangeAddress(startIndex, rowIndex - 1, 0, 0));
                        sheet.AddMergedRegion(new CellRangeAddress(startIndex, rowIndex - 1, 1, 1));
                        //sheet.AddMergedRegion(new CellRangeAddress(startIndex, rowIndex - 1, 2, 2));
                        //sheet.AddMergedRegion(new CellRangeAddress(startIndex, rowIndex - 1, 3, 3));
                        //sheet.AddMergedRegion(new CellRangeAddress(startIndex, rowIndex - 1, 4, 4));
                    }

                    #region 设置列宽
                    sheet.SetColumnWidth(0, 30 * 120);
                    sheet.SetColumnWidth(1, 30 * 60);
                    sheet.SetColumnWidth(2, 30 * 120);

                    sheet.SetColumnWidth(3, 30 * 240);
                    sheet.SetColumnWidth(4, 30 * 240);
                    sheet.SetColumnWidth(5, 30 * 240);
                    sheet.SetColumnWidth(6, 30 * 240);
                    sheet.SetColumnWidth(7, 30 * 240);
                    #endregion

                    #region 自适应高度
                    for (int rowNum = 2; rowNum < rowIndex; rowNum++)
                    {
                        Row currentRow = sheet.GetRow(rowNum);
                        int[] height = new int[11];
                        for (int i = 0; i <= 7; i++)
                        {
                            Cell currentCell = currentRow.GetCell(i);
                            if (currentCell == null)
                                continue;
                            int bytes = Encoding.UTF8.GetBytes(currentCell.ToString()).Length;
                            /*if(i==1||i==2||i==3)
                                height[i] = 20 * (bytes / 5 + 1);*/
                            if (i == 0 || i == 4)
                                height[i] = 20 * (bytes / 60 + 1);
                            if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9)
                                height[i] = 20 * (bytes / 47 + 1);
                        }
                        currentRow.HeightInPoints = height.Max();
                    }
                    #endregion

                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                }

            }

            return ms;

        }

        #endregion

        #region 导入排班统计
        /// <summary>
        /// 导入排班数据
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ImportData(string deptId, string filePath, string flag)
        {
            var user = CurrentUser.CrmUser;
            try
            {
                if (flag.Equals("1")) //导入排班信息
                {
                    var dt = ImprotSchedulExcel(AppConfig.FileSaveAddr + filePath);
                    var date = Convert.ToDateTime(dt.Rows[0][0]);
                    var toDate = date.Year.ToString() + "-" + (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) + "-01";
                    var toAppearDt = _flightLochusAppearBll.SelectAppear(deptId, toDate);
                    var classes = _comResourceBll.GetSearchResult(new ComResourceEntity() { ParentId = "0037" });  //所有班次
                    if (toAppearDt != null && toAppearDt.Rows.Count > 0)
                    {
                        //删除已有排班
                        _flightLochusAppearBll.DeleteAppear(toAppearDt.Rows[0]["AppearId"].ToString());
                    }
                    return _flightLochusAppearBll.LoadFlights(dt, classes, deptId, toDate, user.Id, user.UserName);
                }
                if (flag.Equals("2")) //导入值班信息
                {
                    var dt = ImprotDutyExcel(AppConfig.FileSaveAddr + filePath);
                    if (dt.Rows.Count == 0)
                        return false;
                    var allUser = _crmUserBll.GetAllUsers();
                    var flight = new FlightExcelEntity();
                    foreach (DataRow row in dt.Rows)
                    {
                        string[] dutys = flight.Dutys;
                        for (var i = 0; i < dutys.Length; i++)
                        {
                            if (string.IsNullOrEmpty(row[dutys[i]].ToString())) continue;
                            var userEntity = allUser.Where(p => p.RealName.Equals(row[dutys[i]].ToString())).ToList()[0];
                            _flightMonitorBll.SaveMonitor(row["Date"].ToString(), userEntity.DepartmentId, userEntity.Id, row[dutys[i]].ToString(), dutys[i], user.Id, user.UserName);
                        }
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 导入排班数据到Table
        /// </summary>
        /// <returns></returns>
        private DataTable ImprotSchedulExcel(string filePath)
        {
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            POIFSFileSystem ps = new POIFSFileSystem(file);//需using NPOI.POIFS.FileSystem;
            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
            var workbook = new HSSFWorkbook(ps);

            //获取excel的第一个sheet
            Sheet sheet = workbook.GetSheetAt(0);
            var table = new DataTable();

            //获取sheet的首行
            var headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号 即总的列数
            var cellCount = headerRow.LastCellNum;

            var flight = new FlightExcelEntity();

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                var column = new DataColumn(flight.GetColName(headerRow.GetCell(i).StringCellValue));
                table.Columns.Add(column);
            }

            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                Row row = sheet.GetRow(i);
                if (row == null)//这一句很关键，因为没有数据的行默认是null
                {
                    continue;
                }

                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    var cell = row.GetCell(j);
                    if (cell != null)
                        dataRow[j] = row.GetCell(j).ToString();
                    else
                        dataRow[j] = "";
                }

                table.Rows.Add(dataRow);
            }

            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 导入排班数据到Table
        /// </summary>
        /// <returns></returns>
        private DataTable ImprotDutyExcel(string filePath)
        {
            try
            {
                var file = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
                var workbook = new HSSFWorkbook(file);

                //获取excel的第一个sheet
                Sheet sheet = workbook.GetSheetAt(0);
                var table = new DataTable();

                //获取sheet的首行
                var headerRow = sheet.GetRow(0);

                //一行最后一个方格的编号 即总的列数
                var cellCount = headerRow.LastCellNum;

                var flight = new FlightExcelEntity();

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    if (headerRow.GetCell(i) != null)
                    {
                        var column = new DataColumn(flight.GetColName(headerRow.GetCell(i).StringCellValue));
                        table.Columns.Add(column);
                    }
                }

                //最后一列的标号  即总的行数
                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    Row row = sheet.GetRow(i);
                    if (row == null)//这一句很关键，因为没有数据的行默认是null
                    {
                        continue;
                    }

                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        var cell = row.GetCell(j);
                        if (cell != null && table.Columns.Count > j)
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }

                        //else
                        //    dataRow[j] = "";
                    }

                    table.Rows.Add(dataRow);
                }

                workbook = null;
                sheet = null;
                return table;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        #endregion


        /// <summary>
        /// 通过日期和人员查询排班信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="flightDays"></param>
        /// <returns></returns>
        public string GetFlightDropList(string controlId, string userId, string flightDays)
        {
            var str = new StringBuilder();
            try
            {
                var user = CurrentUser.CrmUser;
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", controlId);
                var companys = new CrmCompanyBll().GetAllEnforcementUnit();

                //通过日期和人员查询排班信息
                DataTable flightOfEmpList = _flightOfEmpBll.GetFlightOfEmpByUserIdAndFlightDays(userId, flightDays);

                var i = 0;

                if (flightOfEmpList != null && flightOfEmpList.Rows.Count > 0)
                {
                    foreach (DataRow row in flightOfEmpList.Rows)
                    {
                        string name = row["FlightDays"] + "(" + row["ClassesName"] + ")";
                        string id = row["ClassesId"].ToString();

                        str.Append("document.getElementById('" + controlId + "').options[" + i + "] = new Option('" + name + "', '" + id + "', false, false);");
                        i++;
                    }
                }
                else
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + 0 + "] = new Option('==请选择==', '', false, false);");
                }
            }
            catch (Exception)
            {
                //ignored
            }
            return str.ToString();
        }
    }
}
