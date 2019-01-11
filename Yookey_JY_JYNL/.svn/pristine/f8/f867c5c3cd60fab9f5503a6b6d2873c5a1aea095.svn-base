//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightLochusAppearBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightLochusAppear业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;
using Yookey.WisdomClassed.SIP.Business.Hr;
namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// 排班主表 业务逻辑
    /// </summary>
    public class FlightLochusAppearBll : BaseBll<FlightLochusAppearEntity>
    {
        private readonly FlightLochusAppearDal _flightLochusAppearDal = new FlightLochusAppearDal();
        private readonly ComNumberBll _comNumberBll = new ComNumberBll();
        private readonly FlightParticularBll _flightParticularBll = new FlightParticularBll();
        private readonly FlightOfEmpBll _flightOfEmpBll = new FlightOfEmpBll();
        private readonly CrmDepartmentBll _departmentBll = new CrmDepartmentBll();
        private readonly FlightMonitorBll _flightMonitorBll = new FlightMonitorBll();
        private FlightExcelEntity _flightExcelEntity = new FlightExcelEntity();
        private CrmUserBll _baseUserBll = new CrmUserBll();
        private FlightClassesOfDeptmentBll _flightClassesOfDeptment = new FlightClassesOfDeptmentBll();//部门排班类别
        public FlightLochusAppearBll()
        {
            BaseDal = new FlightLochusAppearDal();
        }

        /// <summary>
        /// 查询排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="time">时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable SelectAppear(string deptId, string time)
        {
            try
            {
                return _flightLochusAppearDal.SelectAppear(deptId, time);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询排班对应的人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">班次ID</param>
        /// <param name="date">排班日期</param>
        /// <returns>DataTable.</returns>
        public List<FlightOfUsers> GetFlightOfUsers(string deptId, string classesId, string date, out string strUsers)
        {
            strUsers = "";
            List<FlightOfUsers> userList = new List<FlightOfUsers>();
            try
            {
                var userDt = _flightLochusAppearDal.GetFlightOfUsers(deptId, classesId, date);
                if (userDt != null && userDt.Rows.Count > 0)
                {
                    for (var i = 0; i < userDt.Rows.Count; i++)
                    {
                        if (userDt.Rows[i]["CityManager"].ToString() == "0")//非市容管理队员的颜色                        
                        {
                            strUsers += "<span style=\"color:red\">" + userDt.Rows[i]["UserName"] + " </span>";
                        }
                        else
                        {
                            strUsers += "<span>" + userDt.Rows[i]["UserName"] + " </span>";
                        }
                        userList.Add(new FlightOfUsers()
                        {
                            UserId = userDt.Rows[i]["UserId"].ToString(),
                            UserName = userDt.Rows[i]["UserName"].ToString()
                        });
                    }
                }

                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询排班对应的人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">班次ID</param>
        /// <param name="date">排班日期</param>
        /// <returns>DataTable.</returns>
        public string GetFlightOfUsersIds(string deptId, string classesId, string date)
        {
            var strUsers = "";
            try
            {
                var userDt = _flightLochusAppearDal.GetFlightOfUsers(deptId, classesId, date);
                if (userDt != null && userDt.Rows.Count > 0)
                {
                    for (var i = 0; i < userDt.Rows.Count; i++)
                    {
                        strUsers += userDt.Rows[i]["UserId"] + ",";
                    }
                }
                return strUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 排班保存选择人员信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-30 周 鹏 增加人员标识类型
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="classesId">排班部门对应表的ID</param>
        /// <param name="date">排班日期</param>
        /// <param name="users">选择人员</param>
        /// <param name="userType">人员标识类型：userId,userName</param>
        /// <param name="createId">操作人ID</param>
        /// <param name="createBy">操作人姓名</param>
        /// <returns><c>true</c>保存成功<c>false</c>保存失败</returns>
        public bool SaveFlight(string deptId, string classesId, DateTime date, string users, string userType, string createId, string createBy, string yearMonth)
        {
            try
            {
                //当前排班的月份
                var flightDate = yearMonth + "-01";
                var appearDt = SelectAppear(deptId, flightDate);    //排班信息
                string appearId;

                //首先验证排班主表中是否有记录数据,没有进行新增
                if (appearDt != null && appearDt.Rows.Count > 0)
                {
                    appearId = appearDt.Rows[0]["AppearId"].ToString();
                }
                else
                {
                    //生成流水号
                    appearId = _comNumberBll.GetNumber(AppConst.NumFlight, "", null);
                    //排班主表实体
                    var flightLochusAppearEntity = new FlightLochusAppearEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        AppearId = appearId,
                        DeptId = deptId,
                        FlightDate = flightDate,
                        State = 0,
                        CreatorId = createId,
                        CreateBy = createBy,
                        CreateOn = DateTime.Now
                    };
                    Add(flightLochusAppearEntity);  //保存排班主表
                }

                if (!string.IsNullOrEmpty(appearId))
                {
                    string particularId = "";
                    string xxParticularId = "";
                    //查询排班明细记录
                    var particularDt = _flightParticularBll.SelectParticular(appearId, classesId, date.ToString(AppConst.DateFormat));
                    // 排班休息明细
                    #region //部门排班类别只休息验证
                    var classModel = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId).FirstOrDefault(i => i.ClassesName == "休息");//获取部门休息的排班类别
                    var xxParticularDt = new DataTable();
                    if (classModel == null)//部门没有休息的类别
                    {
                        xxParticularDt = null;//要删除的休息则为NULL
                    }
                    else
                    {
                        xxParticularDt = _flightParticularBll.SelectParticular(appearId, classModel.Id, date.ToString(AppConst.DateFormat));//当第一次插入休息的时候进来这边定为空
                    }
                    #endregion
                    if (xxParticularDt != null && xxParticularDt.Rows.Count > 0)
                    {
                        xxParticularId = xxParticularDt.Rows[0]["Id"].ToString(); //休息排班Id
                    }

                    //验证排班明细表是否存在记录,没有执行新增
                    if (particularDt != null && particularDt.Rows.Count > 0)
                    {
                        particularId = particularDt.Rows[0]["Id"].ToString();
                    }
                    else
                    {
                        var classInfor = _flightClassesOfDeptment.Get(classesId);
                        particularId = Guid.NewGuid().ToString();
                        //排班明细实体
                        var flightParticularEntity = new FlightParticularEntity
                        {
                            Id = particularId,
                            AppearId = appearId,
                            ClassesId = classesId,
                            FlightDays = date,
                            CreatorId = createId,
                            CreateBy = createBy,
                            CreateOn = DateTime.Now
                        };
                        if (classInfor != null)
                        {
                            flightParticularEntity.ClassName = classInfor.ClassesId;
                            flightParticularEntity.ClassBeginTime = classInfor.TimePeriodState;
                            flightParticularEntity.ClassEndTime = classInfor.TimePeriodEnd;
                        }
                        _flightParticularBll.Add(flightParticularEntity);//排班明细新增
                    }
                    //保存排班人员
                    return !string.IsNullOrEmpty(particularId) && _flightOfEmpBll.SaveFlightUsers(particularId, users, userType, "", xxParticularId);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 拷贝复制排班
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearDt">被复制的排班请表</param>
        /// <param name="deptId">所属部门</param>
        /// <param name="formDate">被复制排班日期</param>
        /// <param name="toData">拷贝至排班日期</param>
        /// <param name="createId">创建人ID</param>
        /// <param name="createBy">创建人姓名</param>
        /// <returns><c>true</c>成功<c>false</c>失败</returns>
        public bool CopyFlights(DataTable appearDt, string deptId, string formDate, string toData, string createId, string createBy)
        {
            bool isOk;
            try
            {
                var fd = Convert.ToDateTime(formDate);
                var td = Convert.ToDateTime(toData);

                if (appearDt != null && appearDt.Rows.Count > 0)
                {
                    //当前排班的月份
                    var flightDate = string.Empty;
                    if (td.Month>=12&&td.Day>=26)
                    {
                        flightDate = (td.Year+1) + "-" + "01"+ "-01";
                    }
                    else if (td.Day >= 26)
                    {
                        flightDate = td.Year + "-" + (td.Month + 1) + "-01";
                    }
                    else
                    {
                        flightDate = td.Year + "-" + td.Month + "-01";
                    }
                    var Appear = SelectAppear(deptId, flightDate);    //排班信息

                    var appearId = string.Empty;
                    if (Appear == null || Appear.Rows.Count <= 0)
                    {
                        var flightLochusAppearEntity = new FlightLochusAppearEntity
                            {
                                Id = Guid.NewGuid().ToString(),
                                AppearId = _comNumberBll.GetNumber(AppConst.NumFlight, "", null),
                                DeptId = deptId,
                                FlightDate = flightDate,
                                CreatorId = createId,
                                CreateBy = createBy,
                                CreateOn = DateTime.Now
                            };  //排班主表实体

                        appearId = flightLochusAppearEntity.AppearId;
                        //保存主表
                        _flightLochusAppearDal.Add(flightLochusAppearEntity);
                    }
                    else
                    {
                        appearId = Appear.Rows[0]["AppearId"].ToString();
                    }
                    var formAppearId = appearDt.Rows[0]["AppearId"].ToString();
                    //var formDateDays = DateTime.DaysInMonth(fd.Year, fd.Month);   //被复制月份天数
                    //var toDateDays = DateTime.DaysInMonth(td.Year, td.Month);     //拷贝至的月份天数

                    //排班明细记录   一个整的排班 上个26号到本月25号
                    var formAppearDt = _flightParticularBll.SelectParticular(formAppearId,
                                                                             fd.ToString("yyyy-MM-dd"));
                    // 复制 相差几个月
                    //int month = td.Month - fd.Month;
                    if (formAppearDt != null && formAppearDt.Rows.Count > 0)
                    {
                        foreach (DataRow appearRow in formAppearDt.Rows)
                        {
                            var particularId = Guid.NewGuid().ToString();
                            DateTime toFlightDays = DateTime.Parse(appearRow["FlightDays"].ToString());
                            int toDay = toFlightDays.Day; //复制第几天
                            //DateTime toMonth = toFlightDays.AddMonths(month);//复制到第几个月
                            //int sumDay = DateTime.DaysInMonth(toMonth.Year, toMonth.Month); // 当前月总共多少天
                            //if (sumDay < toDay) //
                            //{
                            //    continue;
                            //}

                            var formParticularId = appearRow["Id"].ToString();
                            var flightParticularEntity = new FlightParticularEntity
                                {
                                    Id = particularId,
                                    AppearId = appearId,
                                    ClassesId = appearRow["ClassesId"].ToString(),
                                    FlightDays = td,
                                    CreatorId = createId,
                                    CreateBy = createBy,
                                    CreateOn = DateTime.Now
                                };

                            //保存排班明细
                            _flightParticularBll.Add(flightParticularEntity);

                            //查询排班人员
                            var usersDt = _flightOfEmpBll.GetUsersByParticular(formParticularId);
                            if (usersDt != null && usersDt.Rows.Count > 0)
                            {
                                var usersStr = usersDt.Rows.Cast<DataRow>().Aggregate("", (current, userRow) => current + (userRow["UserId"] + ","));
                                if (!string.IsNullOrEmpty(usersStr))
                                {
                                    usersStr = usersStr.Remove(usersStr.Length - 1, 1);  //移除最后一个逗号
                                    _flightOfEmpBll.SaveFlightUsers(particularId, usersStr, "");   //保存排班人员
                                }
                            }
                        }
                    }
                    isOk = true;
                }
                else
                {
                    isOk = false;
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }



        /// <summary>
        /// 删除排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班编号</param>
        /// <returns><c>true</c>删除成功<c>false</c>删除失败</returns>
        public bool DeleteAppear(string appearId)
        {
            var particularDt = _flightParticularBll.SelectParticular(appearId);
            return _flightLochusAppearDal.DeleteApperar(appearId, particularDt);
        }

        /// <summary>
        /// 更改排班状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="state">状态</param>
        /// <param name="appearId">排班编号</param>
        /// <exception cref="System.Exception"></exception>
        public bool UpdateFlightState(int state, string appearId)
        {
            try
            {
                return _flightLochusAppearDal.UpdateFlightState(state, appearId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 请求一个月的排班数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="data">日期</param>
        /// <returns>DeptId:部门编号,FlightDays:排班日期,ClassesId:班次编号,UserName:排班人员</returns>
        public DataTable GetMonthData(string flightDays, string ClassesId, string deptId)
        {
            try
            {
                return _flightLochusAppearDal.GetMonthData(flightDays, ClassesId, deptId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门时间范围内所有排班情况
        /// 添加人：周 鹏
        /// 添加时间：2017-05-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        /// <returns></returns>
        public DataTable GetDepartmentSchedule(string deptId, string startDate, string endDate)
        {
            try
            {
                return _flightLochusAppearDal.GetDepartmentSchedule(deptId, startDate, endDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取月份排班报表数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">所属年份</param>
        /// <param name="month">所属月份</param>
        /// <returns>List&lt;FlightReport&gt;.</returns>
        /// <exception cref="System.Exception"></exception>
        public List<FlightReport> GetMonthReport(int? year, int? month, string companyId, string deptId)
        {
            try
            {
                var data = year + "-" + month + "-" + "01";  //排班日期

                //排班集合
                var flightList = new List<FlightReport>();
                var startStr = string.Empty;                     
                if (month == 1)//去年的12月
                { 
                    startStr=year-1+"-"+12+"-26";
                }
                else
                {
                    startStr=year + "-" + (month - 1) + "-26";
                }
                var startTime = DateTime.Parse(startStr);
                var endTime = DateTime.Parse(year + "-" + month + "-25");

                //执法大队下所有部门
                List<CrmDepartmentEntity> depts = _departmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId, Id = deptId }).ToList();
                var classes = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId);  //所有班次
                //该月所有值班信息
                var monthMonitor = _flightMonitorBll.GetDataSource(data);
                //循环遍历天
                for (var dtN = startTime; dtN <= endTime; dtN = dtN.AddDays(1))
                {
                    var flightEntity = new FlightReport();    //排班报表实体

                    //值班信息
                    var monitor = monthMonitor.Select(string.Format("OndutyDate='{0}'", dtN.ToString(AppConst.DateFormat)));

                    var chiefWatch = monitor.Length > 0 ? monitor[0]["ChiefWatchName"].ToString() : "";
                    var chiefMonitor = monitor.Length > 0 ? monitor[0]["ChiefMonitorName"].ToString() : "";
                    var depudyMonotor = monitor.Length > 0 ? monitor[0]["DeputyMonitorName"].ToString() : "";

                    var week = CommonMethod.GetWeek(dtN);
                    flightEntity.Date = dtN;        //日期
                    flightEntity.Week = week;       //星期
                    flightEntity.FlightReportDetails = new List<Dictionary<string, string>>();   //排班明细：班次、人员

                    //循环遍历班次,查询排班人员详情
                    foreach (var deptEntity in depts)
                    {

                        foreach (var deptIdmentId in classes)
                        {
                            var diction = new Dictionary<string, string>();
                            var UserStrs = string.Join(" ", GetMonthData(dtN.ToString(AppConst.DateFormat), deptIdmentId.Id, deptEntity.Id).Select().Select(i => i["UserName"].ToString()));
                            diction.Add(deptIdmentId.ClassesId, UserStrs);//key :"排班类型名称" value:"人员集合"
                            flightEntity.FlightReportDetails.Add(diction);
                        }
                        flightEntity.DeptId = deptEntity.Id;
                        flightEntity.DeptName = deptEntity.FullName;
                    }
                    flightList.Add(flightEntity);
                }

                return flightList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 班次人员统计表
        /// 添加人：周 鹏
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public object UserReport(string deptId, string startTime, string endTime)
        {
            try
            {
                if (string.IsNullOrEmpty(deptId))
                {
                    return null;
                }
                var classes = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId).Select(i => new { ClassesName = i.ClassesId });  //所有班次
                var dataz = _flightLochusAppearDal.UserReport(deptId, startTime, endTime).Select().Select(i => new { ClassesId = i["ClassesId"].ToString(), RealName = i["RealName"].ToString() });
                var users = new CrmUserBll().GetUsersByDepartment(deptId).Select(i => new { Users = i.RealName });
                var data = new { dataList = dataz, className = classes, users = users };//加入班别
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 导入Excel排班数据
        /// </summary>
        /// <param name="excelDt">Excel数据</param>
        /// <param name="deptId">部门编号</param>
        /// <param name="toData">模板时间</param>
        /// <param name="createId">创建人编号</param>
        /// <param name="createBy">创建人名称</param>
        /// <returns></returns>
        public bool LoadFlights(DataTable excelDt, IList<ComResourceEntity> classLst, string deptId, string toData, string createId, string createBy)
        {
            bool isOk;
            string[] shifts = _flightExcelEntity.Shifts;
            try
            {
                var td = Convert.ToDateTime(toData);
                if (excelDt != null && excelDt.Rows.Count > 0)
                {
                    var appearId = _comNumberBll.GetNumber(AppConst.NumFlight, "", null);

                    var flightLochusAppearEntity = new FlightLochusAppearEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        AppearId = appearId,
                        DeptId = deptId,
                        FlightDate = toData,
                        CreatorId = createId,
                        CreateBy = createBy,
                        CreateOn = DateTime.Now
                    };  //排班主表实体

                    //保存主表
                    _flightLochusAppearDal.Add(flightLochusAppearEntity);

                    foreach (DataRow row in excelDt.Rows)
                    {
                        for (int i = 0; i < shifts.Length; i++)
                        {
                            if (excelDt.Columns.Contains(shifts[i]) && !string.IsNullOrEmpty(row[shifts[i]].ToString()))
                            {
                                var particularId = Guid.NewGuid().ToString();

                                var classId = classLst.Where(p => p.RsKey.Contains(_flightExcelEntity.GetName(shifts[i]))).ToList()[0].Id;
                                var flightParticularEntity = new FlightParticularEntity
                                {
                                    Id = particularId,
                                    AppearId = appearId,
                                    ClassesId = classId,
                                    FlightDays = Convert.ToDateTime(row["Date"].ToString()),
                                    CreatorId = createId,
                                    CreateBy = createBy,
                                    CreateOn = DateTime.Now
                                };

                                //保存排班明细
                                _flightParticularBll.Add(flightParticularEntity);

                                //保存排班人员
                                _flightOfEmpBll.SaveFlightUsers(particularId, row[shifts[i]].ToString(), "1", deptId);
                            }
                        }
                    }
                    isOk = true;
                }
                else
                {
                    isOk = false;
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 获取部门的当天的排班信息
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <param name="day">哪一天</param>
        /// <returns></returns>
        public DataTable SelectUserByDay(string deptId, string day)
        {
            return _flightLochusAppearDal.SelectUserByDay(deptId, day);
        }

        /// <summary>
        /// 删除一天排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班编号</param>
        /// <returns><c>true</c>删除成功<c>false</c>删除失败</returns>
        public bool DeleteAppear(string appearId, string day)
        {
            var particularDt = _flightParticularBll.SelectParticular(appearId);
            return _flightLochusAppearDal.DeleteApperar(appearId, particularDt, day);
        }
    }
}
