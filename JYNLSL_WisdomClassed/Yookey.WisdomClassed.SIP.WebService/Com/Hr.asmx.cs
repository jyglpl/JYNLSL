using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using System.Threading.Tasks;
using System.Data;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Hr 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Hr : System.Web.Services.WebService
    {
        private readonly FlightParticularBll _flightParticularBll = new FlightParticularBll();
        private readonly AttendanceLeaveBll _attendanceLeaveBll = new AttendanceLeaveBll();
        readonly FlightOfEmpBll _flightOfEmpBll = new FlightOfEmpBll();
        private readonly WorkOvertimeBll _workOvertimeBll = new WorkOvertimeBll();
        private readonly AttendanceReportBll _attendanceReportBll = new AttendanceReportBll();

        /// <summary>
        /// 请求个人排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string GetAppearByMonth(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            string time = "";
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    time = Regex.Match(context, @"(?<=""Time""\:"").*?(?="",)").Value;      //请求月份（格式：yyyy-MM）
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;  //类型
                    time = time + "-01";
                    var dt = _flightParticularBll.GetAppearByUser(time, userId);
                    //return JsonConvert.SerializeObject(dt);
                    Status = true;
                    obj = dt;
                }
                //return "[]";
            }
            catch (Exception ex)
            {
                //return "[]";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        #region 请假相关接口

        /// <summary>
        /// 请假审批
        /// 添加人：周 鹏
        /// 添加时间：2015-04-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string LeaveApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var erMsg = "";
                var isOk = _attendanceLeaveBll.LeaveApprove(context, out erMsg);
                // return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";

                //return erMsg;
                if (isOk)
                {
                    Status = true; 
                }
                obj = isOk;
            }
            catch (Exception ex)
            {
                // return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 获取请假类型 Value/Text
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetAttendanceLeaveType(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
                var leaveType = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0006" });
                var lstLeaveType = leaveType.Select(m => new { Value = m.Id, Text = m.RsKey }).ToList();
                var timeInfor = _attendanceLeaveBll.GetCompTime(userId);
                var typeAndTime = new { lstLeaveType = lstLeaveType, timeInfor = timeInfor };
                //return JsonConvert.SerializeObject(typeAndTime);
                Status = true;
                obj = typeAndTime;
            }
            catch (Exception e)
            {
                //return "[]";
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 通过用户Id获取请假记录
        /// 创建人：周庆
        /// 创建日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAllAttendanceLeaveByUserDeptId(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    string userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;
                    string deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;
                    string startTime = Regex.Match(context, @"(?<=""StartTime""\:"").*?(?="",)").Value;
                    string endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;
                    string keyWords = Regex.Match(context, @"(?<=""KeyWords""\:"").*?(?="",)").Value;
                    string strPageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;
                    string strPageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value;

                    int pageSize = 30;
                    int pageIndex = 1;
                    if (!string.IsNullOrEmpty(strPageIndex))
                        int.TryParse(strPageIndex, out pageIndex);
                    if (!string.IsNullOrEmpty(strPageSize))
                        int.TryParse(strPageSize, out pageSize);

                    if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(deptId))
                    {
                        var lstAttendanceData = new AttendanceLeaveBll().GetAllAttendanceLeaveByUserDeptId(userId, deptId, startTime, endTime, keyWords, pageSize, pageIndex);
                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(lstAttendanceData.rows, timeConverter);
                        Status = true;
                        obj = lstAttendanceData.rows;
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception e)
            {
                //return "[]";
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }


        /// <summary>
        /// 新增或保存请假申请
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CreateOrUpdateApply(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                DateTime BeginTime;
                DateTime EndTime;
                float LeaveTime;
                if (!string.IsNullOrEmpty(context))
                {
                    //string msg = "";
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    string id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    string userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;
                    string leaveType = Regex.Match(context, @"(?<=""LeaveType""\:"").*?(?="",)").Value;
                    string leaveReason = Regex.Match(context, @"(?<=""LeaveReason""\:"").*?(?="",)").Value;
                    string deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;
                    string beginTime = Regex.Match(context, @"(?<=""BeginTime""\:"").*?(?="",)").Value;
                    string endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;
                    string leaveTime = Regex.Match(context, @"(?<=""LeaveTime""\:"").*?(?="",)").Value;
                    string remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;
                    string currentUserId = Regex.Match(context, @"(?<=""CurrentUserId""\:"").*?(?="",)").Value;

                    //非空验证
                    if (string.IsNullOrEmpty(userId))
                        msg += "请假人Id不能为空；";
                    if (string.IsNullOrEmpty(deptId))
                        msg += "请假人部门Id不能为空；";
                    if (string.IsNullOrEmpty(beginTime))
                        msg += "请假开始时间不能为空；";
                    if (string.IsNullOrEmpty(endTime))
                        msg += "请假截止时间不能为空；";
                    if (string.IsNullOrEmpty(leaveTime))
                        msg += "请假天数不能为空；";
                    if (string.IsNullOrEmpty(currentUserId))
                        msg += "当前用户Id不能为空；";
                    if (!string.IsNullOrEmpty(msg))
                    {
                        // return JsonConvert.SerializeObject(new { Status = false, Id = "", msg = msg });
                        Status = false;
                        obj = "";
                    }
                    //有效性验证
                    var entity = new AttendanceLeaveEntity
                        {
                            Id = id,
                            LeaveReason = leaveReason
                        };

                    var userBll = new CrmUserBll();
                    //验证请假用户
                    //var user = baseUserBll.Get(userId);
                    var user = userBll.GetUserEntity(userId);

                    if (user == null || string.IsNullOrEmpty(user.Id))
                    {
                        msg += "请假人不存在；";
                    }
                    else
                    {
                        entity.UserId = user.Id;
                        entity.UserName = user.RealName;
                    }

                    if (user != null)
                    {

                        entity.CompanyId = user.CompanyId;
                        entity.CompanyName = user.CompanyName;
                        entity.DeptId = user.DepartmentId;
                        entity.DeptName = user.DepartmentName;
                        entity.CreatorId = user.Id;
                        entity.CreateBy = user.RealName;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateId = user.Id;
                        entity.UpdateBy = user.RealName;
                        entity.UpdateOn = entity.CreateOn;
                    }

                    var leave = new ComResourceBll().Get(leaveType);
                    if (leave == null)
                    {
                        msg += "请假类型不正确；";
                    }
                    else
                    {
                        entity.LeaveType = leave.Id;
                        entity.LeaveTypeName = leave.RsKey;
                    }
                    if (!DateTime.TryParse(beginTime, out BeginTime))
                    {
                        msg += "请假开始时间格式不正确；";
                    }
                    if (!DateTime.TryParse(endTime, out EndTime))
                    {
                        msg += "请假截止时间格式不正确；";
                    }
                    if (EndTime < BeginTime)
                    {
                        msg += "请假截止时间不能小于开始时间；";
                    }
                    if (!float.TryParse(leaveTime, out LeaveTime))
                    {
                        msg += "请假天数格式不正确；";
                    }
                    if ((entity.LeaveType.Equals("00060010") && _attendanceLeaveBll.GetCompTime(entity.UserId).HasTime < LeaveTime * 8.0f))
                    {
                        msg += "您当前没有加班时间可以排休！";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new { Status = false, Id = "", msg });
                        Status = false;
                        obj = "";
                    }
                    entity.BeginTime = BeginTime;
                    entity.EndTime = EndTime;
                    entity.LeaveTime = LeaveTime;
                    //执行新增或保存
                    var res = new AttendanceLeaveBll().CreateOrUpdateApply(entity);
                    //return JsonConvert.SerializeObject(new
                    //    {
                    //        Status = true,
                    //        res.Id,
                    //        msg
                    //    });
                    Status = true;
                    obj = id;
                }
                //return JsonConvert.SerializeObject(new
                //    {
                //        Status = false,
                //        Id = "",
                //        msg = "空请求"
                //    });
                else
                {
                    Status = false;
                    obj = "";
                }
                
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //    {
                //        Status = false,
                //        Id = "",
                //        msg = e.Message
                //    });
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 请假明细
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetApplyById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;

                    var entity = new AttendanceLeaveBll().Get(id);
                    if (entity != null && entity.RowStatus == 1)
                    {
                        var strStatus = "";
                        if (entity.Status == -2)
                            strStatus = "已作废";
                        else if (entity.Status == -1)
                            strStatus = "审批不通过";
                        else if (entity.Status == 0)
                            strStatus = "登记";
                        else if (entity.Status > 0 && entity.Status < 10)
                            strStatus = "审批中";
                        else if (entity.Status == 10)
                            strStatus = "审批通过";

                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Id = entity.Id,
                        //    UserId = entity.UserId,
                        //    UserName = entity.UserName,
                        //    DeptId = entity.DeptId,
                        //    DeptName = entity.DeptName,
                        //    LeaveType = entity.LeaveType,
                        //    LeaveTypeName = entity.LeaveTypeName,
                        //    LeaveReason = entity.LeaveReason,
                        //    BeginTime = entity.BeginTime,
                        //    EndTime = entity.EndTime,
                        //    LeaveTime = Convert.ToString(entity.LeaveTime),
                        //    Remark = entity.Remark,
                        //    Status = strStatus
                        //}, timeConverter);
                        Status = true;
                        obj = new
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            UserName = entity.UserName,
                            DeptId = entity.DeptId,
                            DeptName = entity.DeptName,
                            LeaveType = entity.LeaveType,
                            LeaveTypeName = entity.LeaveTypeName,
                            LeaveReason = entity.LeaveReason,
                            BeginTime = entity.BeginTime,
                            EndTime = entity.EndTime,
                            LeaveTime = Convert.ToString(entity.LeaveTime),
                            Remark = entity.Remark,
                            Status = strStatus
                        };
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 删除请假记录
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteApplyById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    var currentUserId = Regex.Match(context, @"(?<=""CurrentUserId""\:"").*?(?="",)").Value;

                    //var msg = "";
                    if (string.IsNullOrEmpty(id))
                        msg += "Id不能为空；";
                    if (string.IsNullOrEmpty(currentUserId))
                        msg += "当前用户Id不能为空；";
                    if (!string.IsNullOrEmpty(msg))
                    {
                        // return JsonConvert.SerializeObject(new { Status = false, msg });
                        Status = false;
                    }
                    var attendanceLeaveBll = new AttendanceLeaveBll();
                    var entity = attendanceLeaveBll.Get(id);
                    if (entity == null)
                    {
                        msg += "当前记录不存在或已删除；";
                    }
                    else
                    {
                        var currentUser = new BaseUserBll().Get(currentUserId);
                        if (currentUser == null)
                        {
                            msg += "当前用户不存在；";
                        }
                        else
                        {
                            entity.UpdateId = currentUser.Id;
                            entity.UpdateBy = currentUser.UserName;
                            entity.UpdateOn = DateTime.Now;
                        }
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new { Status = false, msg = msg });
                        Status = false;
                    }
                    else
                    {
                        attendanceLeaveBll.DeleteApply(entity);
                        //return JsonConvert.SerializeObject(new { Status = true, msg = msg });
                        Status = true;
                        obj = attendanceLeaveBll.DeleteApply(entity);
                    }
                }
                else
                {
                    //return JsonConvert.SerializeObject(new { Status = false, msg = "" });
                    Status = false;
                    msg = "";
                }
            }
            catch (Exception ex)
            {
                // return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 通讯录接口

        [WebMethod]
        public string GetMailList(string context)
        {
            bool Status = false;
            string msg = "";
            object obj = null;
            try
            {
                //获取所有单位
                var companys = new CrmCompanyBll().GetAllCompany(new CrmCompanyEntity());
                //获取所有部门
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity());
                //获取所有人员
                var users = new CrmUserBll().GetUserList(new CrmUserEntity());


                //企业
                var topCompany = companys.Where(x => x.ParentId == "0").ToList();
                var result = (from companyEntity in topCompany
                              let childs = ChildCompany(companys, departments, users, companyEntity.Id)
                              select new MailList()
                              {
                                  Department = companyEntity.FullName,
                                  UserList = new List<MailUser>(),
                                  ChildList = childs
                              }).ToList();

                //return CommonMethod.SerializeObject(result);
                Status = true;
                obj = result;
                //var queryResult = (from companyEntity in topCompany
                //                   let childs = ChildCompany(companys, departments, users, companyEntity.Id)
                //                   select new MailList()
                //                   {
                //                       Department = companyEntity.FullName,
                //                       UserList = new List<MailUser>(),
                //                       ChildList = childs
                //                   }).ToList();
                //Status = true;
                //obj = CommonMethod.SerializeObject(queryResult);
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
                Status = false;
                msg = ex.Message;
            }
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = CommonMethod.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(results);
            
        }


        /// <summary>
        /// 加载子公司信息
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companys">公司集</param>
        /// <param name="departments">部门集</param>
        /// <param name="users">用户集</param>
        /// <param name="parentId">公司父编号</param>
        /// <returns></returns>
        public List<MailList> ChildCompany(IEnumerable<CrmCompanyEntity> companys, IEnumerable<CrmDepartmentEntity> departments, List<CrmUserEntity> users, string parentId)
        {
            try
            {
                var baseCompanyEntities = companys as CrmCompanyEntity[] ?? companys.ToArray();
                var childList = baseCompanyEntities.Where(t => t.ParentId == parentId).ToList();

                var list = new List<MailList>();
                foreach (var companyEntity in childList)
                {
                    var childs = ChildCompany(baseCompanyEntities, departments, users, companyEntity.Id);
                    var departmentList = ChildDepartment(departments, users, companyEntity.Id);
                    if (departmentList.Any())
                    {
                        childs.AddRange(departmentList);
                    }
                    list.Add(new MailList()
                    {
                        Department = companyEntity.FullName,
                        UserList = new List<MailUser>(),
                        ChildList = childs
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="departments">部门集</param>
        /// <param name="users">用户集</param>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public List<MailList> ChildDepartment(IEnumerable<CrmDepartmentEntity> departments, List<CrmUserEntity> users, string companyId)
        {
            try
            {
                var baseDepartmentEntities = departments as CrmDepartmentEntity[] ?? departments.ToArray();
                var childList = baseDepartmentEntities.Where(t => t.CompanyId == companyId).ToList();
                return (from companyEntity in childList
                        select new MailList()
                        {
                            Department = companyEntity.FullName,
                            UserList = GetUsers(users, companyEntity.Id),
                            ChildList = new List<MailList>()
                        }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据部门加载人员
        /// </summary>
        /// <param name="userList">用户数据集</param>
        /// <param name="deptId">部门主键</param>
        /// <returns></returns>
        private List<MailUser> GetUsers(List<CrmUserEntity> userList, string deptId)
        {
            try
            {
                var users = userList.Where(x => x.DepartmentId == deptId);
                return users.Select(entity => new MailUser()
                {
                    UserName = entity.RealName,
                    PhoneNum = entity.Mobile
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region 调班接口

        /// <summary>
        /// 上报调班信息
        /// 添加人：周 鹏
        /// 添加时间：2017-03-14
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveAlterationApply(string context)
        {
            var status = false;
            var msg = "";
            var rid = "";  //保存后返回ID
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    string id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;                       //主键
                    string beforeuserId = Regex.Match(context, @"(?<=""BeforeuserId""\:"").*?(?="",)").Value;   //调班人员（当前用户）
                    string afterUserId = Regex.Match(context, @"(?<=""AfterUserId""\:"").*?(?="",)").Value;     //调班后人员
                    string beforeDate = Regex.Match(context, @"(?<=""BeforeDate""\:"").*?(?="",)").Value;       //调班时间开始
                    string beforeSecondDate = Regex.Match(context, @"(?<=""BeforeSecondDate""\:"").*?(?="",)").Value;   //调班时间截止
                    string afterDate = Regex.Match(context, @"(?<=""AfterDate""\:"").*?(?="",)").Value;         //调班后时间开始
                    string afterSecondDate = Regex.Match(context, @"(?<=""AfterSecondDate""\:"").*?(?="",)").Value;     //调班后时间截止
                    string reason = Regex.Match(context, @"(?<=""Reason""\:"").*?(?="",)").Value;               //调班原因
                    string remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;               //备注情况

                    //当前用户实体
                    var userEntity = new CrmUserBll().GetUserEntity(beforeuserId);
                    var afterUserEntity = new CrmUserBll().GetUserEntity(afterUserId);

                    if (userEntity != null && !string.IsNullOrEmpty(userEntity.Id) &&
                        afterUserEntity != null && !string.IsNullOrEmpty(afterUserEntity.Id))
                    {
                        var entity = new FlightAlterationEntity()
                            {
                                Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id,
                                CompanyId = userEntity.CompanyId,
                                CompanyName = userEntity.CompanyName,
                                DeptId = userEntity.DepartmentId,
                                DeptName = userEntity.DepartmentName,
                                BeforeUserId = userEntity.Id,
                                BeforeUserName = userEntity.RealName,
                                AferUserId = afterUserEntity.Id,
                                AfterUserName = afterUserEntity.RealName,
                                BeforeDate = Convert.ToDateTime(beforeDate),
                                //BeforeDateSecond = Convert.ToDateTime(beforeSecondDate),
                                AfterDate = Convert.ToDateTime(afterDate),
                                //AfterDateSecond = Convert.ToDateTime(afterSecondDate),
                                Reason = reason,
                                Remark = remark,
                                RowStatus = 1,
                                CreatorId = userEntity.Id,
                                CreateBy = userEntity.RealName,
                                CreateOn = DateTime.Now,
                                UpdateId = userEntity.Id,
                                UpdateBy = userEntity.UpdateBy,
                                UpdateOn = DateTime.Now
                            };
                        rid = entity.Id;
                        new FlightAlterationBll().Add(entity);
                        status = true;
                        obj = "true";
                    }
                    else
                    {
                        msg = "未获取到当前用户信息";
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                msg = ex.Message;
                //msg = ex.Message;
                //msg = "";
            }
            //return JsonConvert.SerializeObject(new { Status = status, Id = rid, msg = msg });
            var result = new StatusModel()
            {
                Status = status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 通过用户Id获取调班记录
        /// 添加人：周 鹏
        /// 添加时间：2017-03-14
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAllAlterationByUserId(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;          //当前登录用户
                    var keyWords = Regex.Match(context, @"(?<=""KeyWords""\:"").*?(?="",)").Value;      //查询关键字
                    var strPageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;   //每页请求条数
                    var strPageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value; //当前请求页码

                    var pageSize = 30;
                    var pageIndex = 1;
                    if (!string.IsNullOrEmpty(strPageIndex))
                        int.TryParse(strPageIndex, out pageIndex);
                    if (!string.IsNullOrEmpty(strPageSize))
                        int.TryParse(strPageSize, out pageSize);

                    if (!string.IsNullOrEmpty(userId))
                    {
                        var lstAlterationData = new FlightAlterationBll().GetSearchResult(new FlightAlterationEntity()
                            {
                                AferUserId = userId,
                                Keywords = keyWords,
                                PageIndex = pageIndex,
                                PageSize = pageSize
                            });
                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(lstAlterationData.rows, timeConverter);
                        Status = true;
                        obj = lstAlterationData.rows;
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception e)
            {
                //return "[]";
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 获取调班详情
        /// 添加人：周 鹏
        /// 添加时间：2017-03-14
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAlterationById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;

                    var entity = new FlightAlterationBll().Get(id);
                    if (entity != null && entity.RowStatus == 1)
                    {
                        var strStatus = "";
                        if (entity.Status == -2)
                            strStatus = "已作废";
                        else if (entity.Status == -1)
                            strStatus = "审批不通过";
                        else if (entity.Status == 0)
                            strStatus = "登记";
                        else if (entity.Status > 0 && entity.Status < 10)
                            strStatus = "审批中";
                        else if (entity.Status == 10)
                            strStatus = "审批通过";

                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(
                        //    new
                        //        {
                        //            entity.Id,
                        //            entity.BeforeUserName,
                        //            entity.AfterUserName,
                        //            entity.BeforeDate,
                        //            entity.BeforeClassesName,
                        //            entity.AfterDate,
                        //            entity.AfterClassesName,
                        //            entity.Reason,
                        //            entity.Remark,
                        //            entity.CreateOn,
                        //            Status = strStatus
                        //        }, timeConverter);
                        Status = true;
                        obj = new
                                {
                                    entity.Id,
                                    entity.BeforeUserName,
                                    entity.AfterUserName,
                                    entity.BeforeDate,
                                    entity.BeforeClassesName,
                                    entity.AfterDate,
                                    entity.AfterClassesName,
                                    entity.Reason,
                                    entity.Remark,
                                    entity.CreateOn,
                                    Status = strStatus
                                };
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 调班审批
        /// 添加人：周 鹏
        /// 添加时间：2017-03-14
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string AlterationApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var erMsg = "";
                var isOk = new FlightAlterationBll().AlterationApprove(context, out erMsg);
                //return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 公告通知

        /// <summary>
        /// 请求个人的公告通知信息
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string GetNotice(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;      //当前登录用户ID
                var pageIndex = Regex.Match(context, @"(?<=""pageIndex""\:"").*?(?="",)").Value;    //分页索引
                var pageSize = Regex.Match(context, @"(?<=""pageSize""\:"").*?(?="",)").Value;      //每页条数

                int totalRecords = 0;
                var data = new ComNoticeBll().GetUserNotice(userId, int.Parse(pageIndex), int.Parse(pageSize), out totalRecords);
                timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                //转Json
                //return JsonConvert.SerializeObject(data, timeConverter);
                Status = true;
                obj = data;
            }
            catch (Exception ex)
            {
                //return "[]";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj, timeConverter)
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 请求个人的公告未读的条数
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string GetNoticeNoReadCount(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;      //当前登录用户ID
                var NoticeNoRead = new ComNoticeBll().GetUserNoticeNoRead(userId);
                //return new ComNoticeBll().GetUserNoticeNoRead(userId).ToString();
                Status = true;
                obj = NoticeNoRead;
            }
            catch (Exception ex)
            {
                //return "0";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 请求个人的公告通知的详细信息
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string GetNoticeDetails(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;      //当前登录用户ID
                var noticeId = Regex.Match(context, @"(?<=""NoticeId""\:"").*?(?="",)").Value;      //通知ID

                var entity = new ComNoticeBll().Get(noticeId);
                var files = new ComNoticeAttachBll().GetSearchResult(new ComNoticeAttachEntity() { ResourceId = noticeId });

                //更改为已读
                new ComNoticeBll().SetNoticeIsRead(userId, entity.Id);

                var result = new Notice()
                    {
                        SendUser = entity.CreateBy,
                        SendTime = entity.CreateOn.ToString(AppConst.DateFormatLong),
                        Contents = entity.Contents,
                        Files = new List<NoticeFile>()
                    };
                if (files.Any())
                {
                    foreach (var comNoticeAttachEntity in files)
                    {
                        result.Files.Add(new NoticeFile()
                            {
                                FileName = comNoticeAttachEntity.FileName,
                                FileAddress = AppConfig.FileViewOutNetLink + comNoticeAttachEntity.FileAddress
                            });
                    }
                }
                //return JsonConvert.SerializeObject(result);
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                // return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(results);
        }

        #endregion

        #region JSON转换实体

        /// <summary>
        /// 通讯录集
        /// </summary>
        public class MailList
        {
            /// <summary>
            /// 部门名称
            /// </summary>
            public string Department { get; set; }

            /// <summary>
            /// 人员
            /// </summary>
            public List<MailUser> UserList { get; set; }

            /// <summary>
            /// 子集
            /// </summary>
            public List<MailList> ChildList { get; set; }
        }

        /// <summary>
        /// 通讯录人员
        /// </summary>
        public class MailUser
        {
            /// <summary>
            /// 人员姓名
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 电话号码
            /// </summary>
            public string PhoneNum { get; set; }
        }

        /// <summary>
        /// 公告通知详情
        /// </summary>
        public class Notice
        {
            /// <summary>
            /// 发布人
            /// </summary>
            public string SendUser { get; set; }

            /// <summary>
            /// 发布日期
            /// </summary>
            public string SendTime { get; set; }

            /// <summary>
            /// 公告内容
            /// </summary>
            public string Contents { get; set; }

            /// <summary>
            /// 附件材料
            /// </summary>
            public List<NoticeFile> Files { get; set; }
        }

        /// <summary>
        /// 公告通知附件
        /// </summary>
        public class NoticeFile
        {
            /// <summary>
            /// 附件名称
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// 下载地址
            /// </summary>
            public string FileAddress { get; set; }
        }

        #endregion

        #region   调班接口
        /// <summary>
        /// 新加调班接口
        /// </summary>
        /// <param name="model">调班实体</param>
        /// <returns></returns>
        [WebMethod]
        public string AddChangeShift(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                }

                var model = JsonConvert.DeserializeObject<FlightAlterationEntity>(context);
                if (model == null)
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "参数对象不存在！" });
                }

                if (string.IsNullOrEmpty(model.CompanyId) && string.IsNullOrEmpty(model.CompanyName)
                    || string.IsNullOrEmpty(model.DeptId) && string.IsNullOrEmpty(model.DeptName))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "大队或中队不能为空！" });
                }

                if (string.IsNullOrEmpty(model.AferUserId) || string.IsNullOrEmpty(model.AfterUserName))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班后人员不能为空！" });
                }
                if (model.BeforeDate.Year == 1900)
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班前时间不能为空！" });
                }
                if (model.AfterDate.Year == 1900)
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班后时间不能为空！" });
                }
                if (string.IsNullOrEmpty(model.BeforeUserId) || string.IsNullOrEmpty(model.BeforeUserName))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班后人员不能为空！" });
                }

                if (string.IsNullOrEmpty(model.BeforeClassesId) || string.IsNullOrEmpty(model.AfterClassesName))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班前班别不能为空！" });
                }
                if (string.IsNullOrEmpty(model.AfterClassesId) || string.IsNullOrEmpty(model.AfterClassesName))
                {
                    return JsonConvert.SerializeObject(new { result = false, msg = "调班后班别不能为空！" });
                }
                model.CreateOn = DateTime.Now;
                model.RowStatus = 1;
                model.CreatorId = model.BeforeUserId;
                model.CreateBy = model.BeforeUserName;
                model.CreateOn = DateTime.Now;
                model.UpdateBy = model.BeforeUserName;
                model.UpdateId = model.BeforeUserId;
                model.UpdateOn = DateTime.Now;

                bool result = new FlightAlterationBll().AddTranByCrmMessageWork(model);

                //return JsonConvert.SerializeObject(new { result = result, msg = result ? "调班成功！" : "调班失败！" });
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //string msg = "错误：" + ex.Message;
                //string msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
                Status = false;
                msg = ex.Message;
            }
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 获取人员的调班
        /// </summary>
        /// <param name="Userid">人员编号</param>
        /// <param name="time">时间条件</param>
        /// <returns>排班列表</returns>
        [WebMethod]
        public string ChangeShiftList(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
                var flightDays = Regex.Match(context, @"(?<=""flightDays""\:"").*?(?="",)").Value;
                if (string.IsNullOrEmpty(userId))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "调班人员不能为空！" });
                    Status = false;
                    msg = "调班人员不能为空！";
                }
                if (string.IsNullOrEmpty(flightDays))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "调班时间不能为空！" });
                    Status = false;
                    msg = "调班时间不能为空！";
                }

                //通过日期和人员查询排班信息
                DataTable flightOfEmpList = _flightOfEmpBll.GetFlightOfEmpByUserIdAndFlightDays(userId, flightDays);

                var result = (from flightOfEmp in flightOfEmpList.Select()
                              select new
                              {
                                  ClassesId = flightOfEmp["ClassesId"],
                                  ClassesName = flightOfEmp["FlightDays"] + " (" + flightOfEmp["ClassesName"] + ")"

                              }).ToList();


                //return JsonConvert.SerializeObject(result);
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //return "false";
                Status = false;
                msg = ex.Message;
            }
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 修改调班状态 
        /// </summary>
        /// <param name="formId">调班表单编号</param>
        /// <param name="state">要修改的状态</param>
        /// <param name="flowName"></param>
        /// <param name="eType"></param>
        /// <param name="worklistId"></param>
        /// <param name="ideadate"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod]
        public string ChangeFlightAlterationState(string context)//用于A和B之间确认的状态修改-1是B退回 1是B同意
        {
            //已作废 -2，审批不通过 -1，登记0，大于0小于10审批中，等于10审批通过
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var formId = Regex.Match(context, @"(?<=""formId""\:"").*?(?="",)").Value;
                var state = Regex.Match(context, @"(?<=""state""\:"").*?(?="",)").Value;
                var worklistId = Regex.Match(context, @"(?<=""worklistId""\:"").*?(?="",)").Value;
                var idea = Regex.Match(context, @"(?<=""idea""\:"").*?(?="",)").Value;
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;

                FlightAlterationEntity entity = new FlightAlterationBll().Get(formId);         //调班实体
                string flowName = "调班审批";
                if (entity.Status == -1)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "对方确认不通过！" });
                    Status = false;
                    msg = "对方确认不通过！";
                }
                if (entity.Status == -2)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "调班已作废！" });
                    Status = false;
                    msg = "调班已作废！";
                }
                if (entity.Status == 10)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "调班已审批！" });
                    Status = false;
                    msg = "调班已审批！";
                }
                if (string.IsNullOrEmpty(formId))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "未指定调班！" });
                    Status = false;
                    msg = "未指定调班！";
                }
                if (string.IsNullOrEmpty(state))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "状态不能为空！" });
                    Status = false;
                    msg = "状态不能为空！！";
                }
                if (string.IsNullOrEmpty(userId))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "操作人员不能为空！" });
                    Status = false;
                    msg = "操作人员不能为空！";
                }
                string reMes = string.Empty;
                bool result = false;
                FlightAlterationBll _alterBll = new FlightAlterationBll();
                CrmUserEntity userModel = new CrmUserBll().Get(userId);
                var bUserModel = new Yookey.WisdomClassed.SIP.Model.Base.BaseUserEntity();
                bUserModel.UserName = userModel.RealName;
                bUserModel.Id = userModel.Id;
                if (string.IsNullOrEmpty(worklistId))
                {
                    worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(userModel.Id, formId);
                }

                if (entity.Status == 0)//登记状态才能确认
                {
                    result = _alterBll.UpdataTranByCrmMessageWork(formId, int.Parse(state), flowName, "apply", worklistId, DateTime.Now.ToString(), bUserModel);
                }
                else if (entity.Status > 0 && entity.Status < 10)
                {
                    switch (state)//B确认后启动流程 1.同意 2.不通过 3.作废
                    {
                        case "1":
                            result = _alterBll.AlterationApproveT(formId, flowName, "agree", idea, DateTime.Now.ToString(), worklistId, bUserModel);
                            break;
                        case "-1":
                            result = _alterBll.AlterationApproveT(formId, flowName, "disAgree", idea, DateTime.Now.ToString(), worklistId, bUserModel);
                            break;
                    }
                }

                //return JsonConvert.SerializeObject(new { result = result, msg = reMes });
                Status = true;
                obj = result;
                msg = reMes;
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { result = false, msg = "错误：" + ex });
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var relusts = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(relusts);
        }


        #endregion

        #region 上传图片

        /// <summary>
        /// 上传图片
        /// 添加人：周 鹏
        /// 添加时间：2017-03-24
        /// </summary>
        /// <param name="resourceId">对应外键ID</param>
        /// <param name="imageDate">图片的 Base64String 字符串</param>
        /// <param name="imageName">图片名称</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        public string SaveImage(string context)
        {
            //var isOk = true;
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var resourceId = Regex.Match(context, @"(?<=""resourceId""\:"").*?(?="",)").Value;
                var imageDate = Regex.Match(context, @"(?<=""imageDate""\:"").*?(?="",)").Value;
                var imageName = Regex.Match(context, @"(?<=""imageName""\:"").*?(?="",)").Value;
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
                var time = DateTime.Now;        //照片时间

                #region 调用服务存储照片

                var imageData = Convert.FromBase64String(imageDate);
                var filename = GetFileName(imageName.ToLower());   //重新生成命称

                //调用WebService进行文件存储.FileExt(postedFile.FileName)
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("Car", CommonMethod.FileExt(imageName), filename, imageData);

                #endregion

                #region 数据保存

                var infCar = new ComAttachmentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    FileName = imageName,
                    FileAddress = filePath,
                    RowStatus = 1,
                    ResourceId = resourceId,
                    FileType = "1",
                    CreateBy = userId,
                    CreateOn = time,
                    CreatorId = userId,
                    UpdateBy = userId,
                    UpdateOn = time,
                    Version = 1,
                    UpdateId = userId,
                };
                new ComAttachmentBll().Add(infCar);
                Status = true;
                obj = "true";
                #endregion
            }
            catch (Exception ex)
            {
                //isOk = false;
                Status = false;
                msg = ex.Message;
            }
            //return isOk;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        private static string GetFileName(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var filename = Regex.Match(context, @"(?<=""filename""\:"").*?(?="",)").Value;

                var random = new Random();
                var extension = ".jpg";
                if (filename.Contains("."))
                {
                    extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                    ? filename.Substring(filename.IndexOf('.'))
                                    : ".jpg";
                }
                //return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) +
                //       extension;
                Status = true;
                obj = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;

            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 加班相关接口

        /// <summary>
        /// 加班审批
        /// 添加人：周 鹏
        /// 添加时间：2015-04-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string WorkOvertimeApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var erMsg = "";
                var isOk = _workOvertimeBll.WorkOvertimeApprove(context, out erMsg);
                //return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 通过用户Id获取加班记录
        /// 创建人：周庆
        /// 创建日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAllWorkOvertimeByUserDeptId(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    string userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;
                    string deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;
                    string startTime = Regex.Match(context, @"(?<=""StartTime""\:"").*?(?="",)").Value;
                    string endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;
                    string keyWords = Regex.Match(context, @"(?<=""KeyWords""\:"").*?(?="",)").Value;
                    string strPageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;
                    string strPageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value;

                    int pageSize = 30;
                    int pageIndex = 1;
                    if (!string.IsNullOrEmpty(strPageIndex))
                        int.TryParse(strPageIndex, out pageIndex);
                    if (!string.IsNullOrEmpty(strPageSize))
                        int.TryParse(strPageSize, out pageSize);

                    if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(deptId))
                    {
                        var lstOvertimeData = new WorkOvertimeBll().GetAllWorkOvertimeByUserDeptId(userId, deptId, startTime, endTime, keyWords, pageSize, pageIndex);
                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(lstOvertimeData.rows, timeConverter);
                        Status = true;
                        obj = lstOvertimeData.rows;
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception e)
            {
                //return "[]";
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }


        /// <summary>
        /// 新增或保存加班申请
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CreateOrUpdateOverTimeApply(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                DateTime BeginTime;
                DateTime EndTime;
                double OverTime;
                if (!string.IsNullOrEmpty(context))
                {
                    //string msg = "";
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    string id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    string userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;
                    string overtimeReason = Regex.Match(context, @"(?<=""OvertimeReason""\:"").*?(?="",)").Value;
                    string deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;
                    string beginTime = Regex.Match(context, @"(?<=""BeginTime""\:"").*?(?="",)").Value;
                    string endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;
                    string overtime = Regex.Match(context, @"(?<=""Overtime""\:"").*?(?="",)").Value;
                    string remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;
                    string currentUserId = Regex.Match(context, @"(?<=""CurrentUserId""\:"").*?(?="",)").Value;

                    //非空验证
                    if (string.IsNullOrEmpty(userId))
                        msg += "加班人Id不能为空；";
                    if (string.IsNullOrEmpty(deptId))
                        msg += "加班人部门Id不能为空；";
                    if (string.IsNullOrEmpty(beginTime))
                        msg += "加班开始时间不能为空；";
                    if (string.IsNullOrEmpty(endTime))
                        msg += "加班截止时间不能为空；";
                    if (string.IsNullOrEmpty(overtime))
                        msg += "加班时数不能为空；";
                    if (string.IsNullOrEmpty(currentUserId))
                        msg += "当前用户Id不能为空；";
                    if (!string.IsNullOrEmpty(msg))
                    {
                        // return JsonConvert.SerializeObject(new { Status = false, Id = "", msg = msg });
                        Status = false;

                    }
                    //有效性验证
                    var entity = new WorkOvertimeEntity
                    {
                        Id = id,
                        OvertimeReason = overtimeReason
                    };

                    var userBll = new CrmUserBll();
                    //验证请假用户
                    //var user = baseUserBll.Get(userId);
                    var user = userBll.GetUserEntity(userId);

                    if (user == null || string.IsNullOrEmpty(user.Id))
                    {
                        msg += "加班人不存在；";
                    }
                    else
                    {
                        entity.UserId = user.Id;
                        entity.UserName = user.RealName;
                    }

                    if (user != null)
                    {

                        entity.CompanyId = user.CompanyId;
                        entity.CompanyName = user.CompanyName;
                        entity.DeptId = user.DepartmentId;
                        entity.DeptName = user.DepartmentName;
                        entity.Remark = remark;
                        entity.CreatorId = user.Id;
                        entity.CreateBy = user.RealName;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateId = user.Id;
                        entity.UpdateBy = user.RealName;
                        entity.UpdateOn = entity.CreateOn;
                    }
                    if (!DateTime.TryParse(beginTime, out BeginTime))
                    {
                        msg += "加班开始时间格式不正确；";
                    }
                    if (!DateTime.TryParse(endTime, out EndTime))
                    {
                        msg += "加班截止时间格式不正确；";
                    }
                    if (EndTime < BeginTime)
                    {
                        msg += "加班截止时间不能小于开始时间；";
                    }

                    OverTime = Convert.ToDouble(overtime);
                    //if (!double.TryParse(overtime, out OverTime))
                    //{
                    //    msg += "加班小时数格式不正确；";
                    //}
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //   return JsonConvert.SerializeObject(new { Status = false, Id = "", msg });
                        Status = false;

                    }
                    entity.BeginTime = BeginTime;
                    entity.EndTime = EndTime;
                    entity.Overtime = OverTime;
                    //执行新增或保存
                    var res = new WorkOvertimeBll().CreateOrUpdateApply(entity);
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = true,
                    //    res.Id,
                    //    msg
                    //});
                    Status = true;
                    obj = res;
                }
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = false,
                //    Id = "",
                //    msg = "空请求"
                //});
                else
                {
                    Status = false;
                    msg = "空请求";
                }
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = false,
                //    Id = "",
                //    msg = e.Message
                //});
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = e.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 加班明细
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetOvertimeApplyById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;

                    var entity = new WorkOvertimeBll().Get(id);
                    if (entity != null && entity.RowStatus == 1)
                    {
                        var strStatus = "";
                        if (entity.Status == -2)
                            strStatus = "已作废";
                        else if (entity.Status == -1)
                            strStatus = "审批不通过";
                        else if (entity.Status == 0)
                            strStatus = "登记";
                        else if (entity.Status > 0 && entity.Status < 10)
                            strStatus = "审批中";
                        else if (entity.Status == 10)
                            strStatus = "审批通过";

                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        Status = true;
                        obj = new
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            UserName = entity.UserName,
                            DeptId = entity.DeptId,
                            DeptName = entity.DeptName,
                            OvertimeReason = entity.OvertimeReason,
                            BeginTime = entity.BeginTime,
                            EndTime = entity.EndTime,
                            Overtime = Convert.ToString(entity.Overtime),
                            Remark = entity.Remark,
                            Status = strStatus
                        };

                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Id = entity.Id,
                        //    UserId = entity.UserId,
                        //    UserName = entity.UserName,
                        //    DeptId = entity.DeptId,
                        //    DeptName = entity.DeptName,
                        //    OvertimeReason = entity.OvertimeReason,
                        //    BeginTime = entity.BeginTime,
                        //    EndTime = entity.EndTime,
                        //    Overtime = Convert.ToString(entity.Overtime),
                        //    Remark = entity.Remark,
                        //    Status = strStatus
                        //}, timeConverter);
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 删除加班记录
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteOvertimeApplyById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    var currentUserId = Regex.Match(context, @"(?<=""CurrentUserId""\:"").*?(?="",)").Value;

                    //var msg = "";
                    if (string.IsNullOrEmpty(id))
                        msg += "Id不能为空；";
                    if (string.IsNullOrEmpty(currentUserId))
                        msg += "当前用户Id不能为空；";
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new { Status = false, msg });
                        Status = false;

                    }
                    var workOvertimeBll = new WorkOvertimeBll();
                    var entity = workOvertimeBll.Get(id);
                    if (entity == null)
                    {
                        msg += "当前记录不存在或已删除；";
                    }
                    else
                    {
                        var currentUser = new BaseUserBll().Get(currentUserId);
                        if (currentUser == null)
                        {
                            msg += "当前用户不存在；";
                        }
                        else
                        {
                            entity.UpdateId = currentUser.Id;
                            entity.UpdateBy = currentUser.UserName;
                            entity.UpdateOn = DateTime.Now;
                        }
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new { Status = false, msg = msg });
                        Status = false;
                    }
                    else
                    {
                        workOvertimeBll.DeleteApply(entity);
                        //return JsonConvert.SerializeObject(new { Status = true, msg = msg });
                        Status = true;
                        obj = workOvertimeBll.DeleteApply(entity);
                    }
                }
                else
                {
                    //return JsonConvert.SerializeObject(new { Status = false, msg = "" });
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 考勤申报审批接口

        /// <summary>
        /// 考勤申报审批
        /// 添加人：周 鹏
        /// 添加时间：2017-05-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string AttendanceApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var erMsg = "";
                var isOk = _attendanceReportBll.AttendanceApprove(context, out erMsg);
                //return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 考勤申报明细
        /// 添加人：周 鹏
        /// 添加时间：2017-05-06
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAttendanceById(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    if (string.IsNullOrEmpty(id)) return "[]";

                    var entity = new AttendanceReportBll().Get(id);
                    var details = new AttendanceReportDetailsBll().GetAttendanceDetails(id);

                    if (entity != null && entity.RowStatus == 1)
                    {
                        var strStatus = "";
                        if (entity.State == -2)
                            strStatus = "已作废";
                        else if (entity.State == -1)
                            strStatus = "审批不通过";
                        else if (entity.State == 0)
                            strStatus = "登记";
                        else if (entity.State > 0 && entity.State < 10)
                            strStatus = "审批中";
                        else if (entity.State == 10)
                            strStatus = "审批通过";

                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    CompanyName = entity.CompanyName,
                        //    DepartmentName = entity.DepartmentName,
                        //    SMonth = entity.SMonth.ToString("yyyy-MM"),
                        //    Remark = entity.Remark,
                        //    State = entity.State,
                        //    Status = strStatus,
                        //    Details = details,
                        //}, timeConverter);
                        Status = true;
                        obj = new
                        {
                            CompanyName = entity.CompanyName,
                            DepartmentName = entity.DepartmentName,
                            SMonth = entity.SMonth.ToString("yyyy-MM"),
                            Remark = entity.Remark,
                            State = entity.State,
                            Status = strStatus,
                            Details = details,
                        };
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
                else
                {
                    //return "[]";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }
        #endregion
    }
}
