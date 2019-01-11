using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Common.Security;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.FingerPrint;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.ShowVideo;
using Yookey.WisdomClassed.SIP.Business.Attendance;
using Yookey.WisdomClassed.SIP.Model.Attendance;


namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Basis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Basis : System.Web.Services.WebService
    {
        readonly BasisBll _basisBll = new BasisBll();
        readonly BaseUserBll _baseUserBll = new BaseUserBll();
        readonly CrmUserMenuBll _crmUserMenuBll = new CrmUserMenuBll();
        readonly CrmRoleBll _crmRoleBll = new CrmRoleBll();
        readonly CrmCompanyBll _crmCompanyBll = new CrmCompanyBll();
        readonly CrmDepartmentBll _crmDepartmentBll = new CrmDepartmentBll();
        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly ShowVideoBll _showVideoBll = new ShowVideoBll();
        readonly CrmFeedBackBll _crmFeedBackBll = new CrmFeedBackBll();
        readonly CrmDailyOneProblemBll _CrmDailyOneProblemBll = new CrmDailyOneProblemBll();// 每日一题
        readonly CrmDailyOneProblemRecordBll _CrmDailyOneProblemRecordBll = new CrmDailyOneProblemRecordBll();
        readonly AttendanceBll _AttendanceBll = new AttendanceBll();//考勤签到

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string UserLogin(string context)
        {
            var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var loginName = Regex.Match(context, @"(?<=""loginName""\:"").*?(?="",)").Value;   //用户名
                    var passWord = Regex.Match(context, @"(?<=""passWord""\:"").*?(?="",)").Value;     //密码

                    if (!string.IsNullOrEmpty(loginName) && !string.IsNullOrEmpty(passWord))
                    {
                        //使用基础数据平台进行验证
                        var user = new BaseUserBll().GetUserByUserName(loginName);
                        if (user != null && !string.IsNullOrEmpty(user.Id))
                        {
                            var responseWord = DESHelper.ToDESEncrypt(passWord, AppConst.EncryptKey);  //将密码进行加密
                            bool isSquadronLeader = _crmRoleBll.IsSquadronLeader(user.Id);

                            //验证是否有路面考核数据上报权限
                            bool isUpAssessment = new MembershipManager().VerificationPermissions(user.Id, "Assessment", "UpLoad");

                            //TODO 手机端通过执法证号验证判断是否是执法限队员，姑苏系统没有执法证管理，通过角色来判断
                            var certificateNo = "88888888";

                            //人员对应角色信息
                            var roles = new CrmUserBll().GetUserRoleName(user.Id);
                            if (roles.Rows.Cast<DataRow>().Any(role => role["RoleName"].ToString().Equals("市容管理员")))
                            {
                                certificateNo = "";
                            }

                            if (user.PassWord.Equals(responseWord))
                            {
                                var isUnGps = _crmUserMenuBll.GetUserMenu(user.Id, "00030007") ? 1 : 0;
                                bool isUpdatePwd = user.ChangePasswordDate.Year == 1900 ? true : false;

                                result = "{\"UserId\":\"" + user.Id + "\",\"UserName\":\"" + user.UserName + "\",\"Mobile\":\"" + user.Mobile + "\",\"DeptId\":\"" + user.DeptId + "\",\"DeptName\":\"" + user.DeptName + "\",\"DepAddress\":\"\",\"DepTel\":\"\",\"QX\":\"\",\"CertificateNo\":\"" + certificateNo
                                    + "\",\"IsUnGPS\":\"" + isUnGps + "\",\"CompanyId\":\"" + user.CompanyId + "\",\"CompanyName\":\"" + user.CompanyName
                                    + "\",\"IsSquadronLeader\":\"" + isSquadronLeader + "\",\"IsUpdatePwd\":\"" + isUpdatePwd + "\",\"IsUpAssessment\":\"" + isUpAssessment + "\"}";

                                //result = "[{" + result + "}]";
                                Status = true;
                                obj = result;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 考勤签到
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string AttenDance(string context)
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
                    var CompanyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value; //所属单位Id
                    var CompanyName = Regex.Match(context, @"(?<=""CompanyName""\:"").*?(?="",)").Value; //所属单位
                    var DepartmentId = Regex.Match(context, @"(?<=""DepartmentId""\:"").*?(?="",)").Value; //所属部门Id
                    var DepartmentName = Regex.Match(context, @"(?<=""DepartmentName""\:"").*?(?="",)").Value; //所属部门
                    var UserId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //角色Id
                    var UserName = Regex.Match(context, @"(?<=""UserName""\:"").*?(?="",)").Value; //角色
                    var ClockTime = Convert.ToDateTime(Regex.Match(context, @"(?<=""ClockTime""\:"").*?(?="",)").Value); //打卡时间
                    var ClockPlace = Regex.Match(context, @"(?<=""ClockPlace""\:"").*?(?="",)").Value; //打卡地点
                    var Longitude = Regex.Match(context, @"(?<=""Longitude""\:"").*?(?="",)").Value; //经度
                    var Latitude = Regex.Match(context, @"(?<=""Latitude""\:"").*?(?="",)").Value; //纬度

                    _AttendanceBll.InsertAttendance(new AttendanceEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CompanyId = CompanyId,
                        CompanyName = CompanyName,
                        DepartmentId = DepartmentId,
                        DepartmentName = DepartmentName,
                        UserId = UserId,
                        UserName = UserName,
                        ClockTime = ClockTime,
                        ClockPlace = ClockPlace,
                        Longitude = Longitude,
                        Latitude = Latitude
                    });

                    Status = true;
                    obj = "true";
                }
            }
            catch (Exception ex)
            {
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
        /// 更改密码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string UpdatePsw(string context)
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
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;   //用户名
                    var passWord = Regex.Match(context, @"(?<=""PassWord""\:"").*?(?="",)").Value;     //新密码

                    if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(passWord))
                    {
                        //使用基础数据平台进行验证
                        var user = new BaseUserBll().Get(userId);


                        if (user != null && !string.IsNullOrEmpty(user.Id))
                        {
                            var responseWord = DESHelper.ToDESEncrypt(passWord, AppConst.EncryptKey);  //将密码进行加密

                            if (!string.IsNullOrEmpty(responseWord))
                            {
                                var isOk = new BaseUserBll().UpdatePassWord(userId, responseWord);
                                //return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";
                                Status = true;
                                obj = isOk;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //return "[{\"result\":\"false\"}]";
                Status = false;
                msg = ex.Message;
            }
            //return "[{\"result\":\"false\"}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 查找路段
        /// </summary>
        /// <param name="context">{deptId:部门编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetRoad(string context)
        {
            bool Status = false;
            object obj = null;
            var msg = "";
            var data = _basisBll.GetRoad(context);
            //return JsonConvert.SerializeObject(data);
            Status = true;
            obj = data;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取部门详情
        /// </summary>
        /// <param name="context">{deptId:部门编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetDeptDetails(string context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var deptId = Regex.Match(context, @"(?<=""deptId""\:"").*?(?="",)").Value; //部门编号
                    var deptEntity = _crmDepartmentBll.Get(deptId);
                    if (deptEntity != null && !string.IsNullOrEmpty(deptEntity.Id))
                    {
                        return JsonConvert.SerializeObject(new { Address = deptEntity.Address, Phone = deptEntity.Phone });
                    }
                    else
                    {
                        return "[{}]";
                    }
                }
            }
            catch (Exception)
            {
                return "[{}]";
            }
            return "[{}]";
        }

        /// <summary>
        /// 查询部门下，所有人员
        /// </summary>
        /// <param name="context">{"deptId":"xxxx"}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetDeptUsres(string context)
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
                    var deptId = Regex.Match(context, @"(?<=""deptId""\:"").*?(?="",)").Value; //部门编号
                    var userdt = _baseUserBll.GetDeptsUsersDistinctNoCarNo(new BaseUserEntity() { DeptId = deptId });
                    //return JsonConvert.SerializeObject(userdt);
                    Status = true;
                    obj = userdt;
                }
            }
            catch (Exception)
            {
                //return "[{}]";
                Status = false;
            }
            //return "[{}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 查询个人量化汇总查询
        /// </summary>
        /// <param name="context">{"timeType":"","userId":""}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetUserIntegral(string context)
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
                    var timeType = Regex.Match(context, @"(?<=""timeType""\:"").*?(?="",)").Value; //时间类型：day week month
                    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;     //用户ID

                    var dt = DateTime.Now;

                    var startTime = "";
                    var endTime = "";

                    switch (timeType)
                    {
                        case "day":
                            {
                                startTime = dt.ToString("yyyy-MM-dd");
                                endTime = dt.ToString("yyyy-MM-dd") + " 23:59:59";
                            }
                            break;
                        case "week":
                            {
                                var startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
                                var endWeek = startWeek.AddDays(6);
                                startTime = startWeek.ToString("yyyy-MM-dd");
                                endTime = endWeek.ToString("yyyy-MM-dd") + " 23:59:59";
                            }
                            break;
                        case "month":
                            {
                                var startMonth = dt.AddDays(1 - dt.Day);  //本月月初
                                var endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
                                startTime = startMonth.ToString("yyyy-MM-dd");
                                endTime = endMonth.ToString("yyyy-MM-dd") + " 23:59:59";
                            }
                            break;
                    }

                    var data = new InfPunishCaseinfoBll().GetInteralDetailsByUserId(userId, startTime, endTime);
                    //return JsonConvert.SerializeObject(data);
                    Status = true;
                    obj = data;

                }
            }
            catch (Exception ex)
            {
                //return "[{}]";
                Status = false;
                msg = ex.Message;
            }
            //return "[{}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 个人量化汇总 明细
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetUserIntegralDetails(string context)
        {
            int totalRecords = 0;
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var timeType = Regex.Match(context, @"(?<=""timeType""\:"").*?(?="",)").Value; //时间类型：day week month
                    var caseType = Regex.Match(context, @"(?<=""CaseType""\:"").*?(?="",)").Value; //案件类型 A:教育纠处 B:违法停车 C:简易程序 D:一般程序 E:现场考核 F:暂扣物品
                    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;     //用户ID
                    var pageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value; //起始页
                    var pageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value; //页大小

                    var dt = DateTime.Now;

                    var startTime = "";
                    var endTime = "";

                    switch (timeType)
                    {
                        case "day":
                            {
                                startTime = dt.ToString("yyyy-MM-dd");
                                endTime = dt.ToString("yyyy-MM-dd");
                            }
                            break;
                        case "week":
                            {
                                var startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
                                var endWeek = startWeek.AddDays(6);
                                startTime = startWeek.ToString("yyyy-MM-dd");
                                endTime = endWeek.ToString("yyyy-MM-dd");
                            }
                            break;
                        case "month":
                            {
                                var startMonth = dt.AddDays(1 - dt.Day);  //本月月初
                                var endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末
                                startTime = startMonth.ToString("yyyy-MM-dd");
                                endTime = endMonth.ToString("yyyy-MM-dd");
                            }
                            break;
                    }

                    var data = new InfPunishCaseinfoBll().GetInteralDetails(userId, caseType, startTime, endTime,
                                                                            int.Parse(pageSize), int.Parse(pageIndex),
                                                                            out totalRecords);
                    //return JsonConvert.SerializeObject(data);
                    Status = true;
                    obj = data;
                }
            }
            catch (Exception ex)
            {
                //return "[{}]";
                Status = false;
                msg = ex.Message;
            }
            //return "[{}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 获取当前所请求的网段
        /// 添加人：周 鹏
        /// 添加时间：2015-06-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        [WebMethod]
        public string GetNetWork()
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                //return HttpContext.Current.Request.Url.Host;
                Status = true;
                obj = HttpContext.Current.Request.Url.Host;
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
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取法律法规版本号
        /// 添加人：周 鹏
        /// 添加时间：2015-07-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        [WebMethod]
        public string GetLegislationVersion()
        {
            object obj = null;
            bool Status = false;
            string msg = "";
            //return AppConfig.LegislationVersion;
            obj = AppConfig.LegislationVersion;
            Status = true;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取登录用户管理权限的大队列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAuthorizeCompanyList(string context)
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
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //登录用户Id
                    var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value; //登录用户所在大队
                    //询所有的执法单位（支队及各区）
                    List<CrmCompanyEntity> companyLists = _crmCompanyBll.GetAllEnforcementUnit().Where(x => x.FullName != "局机关").ToList();
                    //验证是有获取所有执法单位的权限，如没有只查本单位的权限
                    var isAllEnforcementUnit = new MembershipManager().VerificationPermissions(userId, "Company", "Operation");
                    companyLists = isAllEnforcementUnit
                                   ? companyLists
                                   : companyLists.Where(x => x.Id == companyId).ToList();


                    var result = (from companyEntity in companyLists
                                  select new
                                  {
                                      Id = companyEntity.Id,
                                      ParentId = companyEntity.ParentId,
                                      CompanyName = companyEntity.FullName,
                                      SortCode = companyEntity.SortCode
                                  }).ToList();

                    //return JsonConvert.SerializeObject(result);
                    Status = true;
                    obj = result;
                }
            }
            catch (Exception)
            {
                //return "[{}]";
                Status = false;
            }
            //return "[{}]";
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 获取登录用户管理权限的中队列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAuthorizeDepartmentList(string context)
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
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //登录用户Id
                    var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value; //登录用户所在大队
                    var deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value; //登录用户所在中队
                    // 大队未传则不返回数据
                    if (string.IsNullOrEmpty(companyId))
                    {
                        return "[{}]";
                    }

                    List<CrmDepartmentEntity> departments = _crmDepartmentBll.GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });

                    //验证是有获取所有执法单位的权限，如没有只查本单位的权限
                    var isAllEnforcementUnit = new MembershipManager().VerificationPermissions(userId, "Department", "Operation");
                    departments = isAllEnforcementUnit
                                   ? departments
                                   : departments.Where(x => x.Id == deptId).ToList();


                    var result = (from deptEntity in departments
                                  select new
                                  {
                                      Id = deptEntity.Id,
                                      deptName = deptEntity.FullName,
                                      CompanyId = deptEntity.CompanyId,
                                      SortCode = deptEntity.SortCode
                                  }).ToList();

                    //return JsonConvert.SerializeObject(result);
                    Status = true;
                    obj = result;
                }
            }
            catch (Exception)
            {
                //return "[{}]";
                Status = false;
            }
            //return "[{}]";
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 获取法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <param name="context">{"qType":""}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetLegislation(string context)
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
                    var qType = Regex.Match(context, @"(?<=""qType""\:"").*?(?="",)").Value; //时间类型
                    var data = new LegislationBll().MobileQueryLegislation(qType);
                    //return JsonConvert.SerializeObject(data);
                    Status = true;
                    obj = data;
                }
            }
            catch (Exception)
            {
                //return "[{}]";
                Status = false;
            }
            //return "[{}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj)
            };
            return JsonConvert.SerializeObject(result);
        }

        #region 字典
        /// <summary>
        /// 通过父Id查询字典信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetResourceListByParentId(string parentId)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(parentId);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                List<ComResourceEntity> list = _comResourceBll.GetResourcesByParentId(parentId);

                var result = (from entity in list
                              select new
                              {
                                  entity.Id,
                                  entity.ParentId,
                                  entity.RsKey,
                                  entity.RsValue

                              }).ToList();

                //return JsonConvert.SerializeObject(new { result = true, data = result });
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //var msg = "错误：" + ex.Message;
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
                //return JsonConvert.SerializeObject(new {});
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

        #endregion

        #region 用户指纹

        #region 上报用户数据
        [WebMethod]
        public string ReportFingerPrint(string context)
        {
            var msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //用户Id
                    var serialNumber = Regex.Match(context, @"(?<=""SerialNumber""\:"").*?(?="",)").Value; //手机序列号
                    var creatorId = Regex.Match(context, @"(?<=""CreatorId""\:"").*?(?="",)").Value; //登录用户Id

                    #region 字段校验
                    if (string.IsNullOrEmpty(userId))
                    {
                        msg += "请传入用户编号；";
                    }
                    if (string.IsNullOrEmpty(serialNumber))
                    {
                        msg += "请传入手机序列；";
                    }
                    if (string.IsNullOrEmpty(creatorId))
                    {
                        msg += "创建人Id为空；";
                    }

                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //Status = false,
                        //Id = "",
                        //msg = msg
                        //});
                        Status = false;
                    }
                    #endregion

                    var user = new BaseUserBll().Get(creatorId);
                    if (user == null)
                    {
                        msg += "创建人不存在！";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Status = false,
                        //    Id = "",
                        //    msg = msg
                        //});
                        Status = false;
                    }

                    var fingerprint = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().GetSearchResult(userId, "");  //用USERID检查 防止一个账号绑定多少个手机

                    if (fingerprint.Count > 0)
                    {
                        if (fingerprint[0].SerialNumber != serialNumber)
                        {
                            msg = "当前账号已绑定其它手机，请先解绑！";
                        }
                        else
                        {
                            var fingerprintbyserial = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().GetSearchResult("", serialNumber);  //用SerialNumber检查 防止一个手机绑定多个账号
                            if (fingerprintbyserial.Count > 0)
                            {
                                if (fingerprintbyserial[0].UserId != userId)
                                {
                                    msg = "当前手机已绑定其它账号，请先解绑！";
                                }
                            }
                        }
                    }
                    else
                    {
                        var fingerprintbyserial = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().GetSearchResult("", serialNumber);  //用SerialNumber检查 防止一个手机绑定多个账号
                        if (fingerprintbyserial.Count > 0)
                        {
                            msg = "当前手机已绑定其它账号，请先解绑！";
                        }
                        else
                        {
                            //用户信息不存在，新增
                            var fingerEntity = new FingerPrintEntity
                            {
                                Id = Guid.NewGuid().ToString(),
                                UserId = userId,
                                SerialNumber = serialNumber,
                                RowStatus = 1,
                                CreatorId = user.Id,
                                CreateBy = user.UserName,
                                CreateOn = DateTime.Now,
                                UpdateId = user.Id,
                                UpdateBy = user.UserName,
                                UpdateOn = DateTime.Now
                            };
                            new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().Add(fingerEntity);
                            msg = "用户上传成功！";
                        }
                    }
                }
                //return JsonConvert.SerializeObject(new { Status = true, msg = msg });
                Status = true;
                obj = "true";
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = "",
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
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }
        #endregion

        #region 验证用户是否存在

        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string VerifyFingerPrint(string context)
        {
            var msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //用户Id
                    var serialNumber = Regex.Match(context, @"(?<=""SerialNumber""\:"").*?(?="",)").Value; //手机序列号

                    #region 字段校验
                    if (string.IsNullOrEmpty(userId))
                    {
                        msg += "请传入用户编号；";
                    }
                    if (string.IsNullOrEmpty(serialNumber))
                    {
                        msg += "请传入手机序列；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Status = false,
                        //    Id = "",
                        //    msg = msg
                        //});
                        Status = false;
                    }
                    #endregion

                    var fingerprint = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().GetSearchResult(userId, serialNumber);
                    if (fingerprint.Count > 0)
                    {
                        if (fingerprint[0].UserId.Equals(userId) && fingerprint[0].SerialNumber.Equals(serialNumber))
                        {
                            //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = userId + "," + serialNumber });
                            Status = true;
                            msg = userId + "," + serialNumber;
                        }
                        else
                        {
                            //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = "用户不存在！" });
                            Status = true;
                            msg = "用户不存在！";
                        }
                    }
                    else
                    {
                        //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = "用户不存在！" });
                        Status = true;
                        msg = "用户不存在！";
                    }
                }
                //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = "" });
                Status = true;
                msg = "";
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = "",
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
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }
        #endregion

        #region   解绑手机与指纹

        [WebMethod]
        public string DeleteFingerPrint(string context)
        {
            var msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //用户Id
                    var serialNumber = Regex.Match(context, @"(?<=""SerialNumber""\:"").*?(?="",)").Value; //手机序列号

                    #region 字段校验
                    if (string.IsNullOrEmpty(userId))
                    {
                        msg += "请传入用户编号；";
                    }
                    if (string.IsNullOrEmpty(serialNumber))
                    {
                        msg += "请传入手机序列；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Status = false,
                        //    Id = "",
                        //    msg = msg
                        //});
                        Status = false;
                    }
                    #endregion

                    var fingerprint = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().GetSearchResult(userId, serialNumber);
                    var flag = false;
                    if (fingerprint.Count > 0)
                    {
                        //用户信息已存在，更新
                        flag = new Yookey.WisdomClassed.SIP.Business.FingerPrint.FingerPrintBll().UpdateFnierPrintStatus(0, serialNumber);
                        msg = flag ? "解绑成功 " : "解绑失败";
                        //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = msg });
                        Status = true;
                    }
                    else
                    {
                        //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = "没有查找到用户信息！" });
                        Status = true;
                        msg = "没有查找到用户信息！";
                    }
                }
                //return JsonConvert.SerializeObject(new { Status = true, Id = "", msg = "" });
                Status = true;
                msg = "";
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = "",
                //    Id = "",
                //    msg = e.Message
                //});
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
        #endregion

        #endregion

        #region 手机视频操作演示
        /// <summary>
        /// 查询所有有效的演示视频
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAllVideos()
        {

            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var videolist = _showVideoBll.GetAllVideos();
                foreach (var item in videolist)
                {
                    item.UrL = AppConfig.FileViewLink + item.UrL;
                }
                var result = (from video in videolist
                              select new
                              {
                                  Title = video.Title,
                                  Url = video.UrL,
                                  OrderNo = video.OrderNo
                              }).ToList();
                //return JsonConvert.SerializeObject(result);
                Status = true;
                obj = result;
            }
            catch (Exception)
            {
                //return "[{}]";
                Status = false;
            }
            //return "[{}]";
            var results = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(results);
        }
        #endregion

        /// <summary>
        /// 意见反馈
        /// 添加人：周 鹏
        /// 添加时间：2015-07-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string FeedBack(string context)
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
                    var idea = Regex.Match(context, @"(?<=""Idea""\:"").*?(?="",)").Value;     //反馈意见
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //用户ID
                    var userName = Regex.Match(context, @"(?<=""UserName""\:"").*?(?="",)").Value; //用户姓名

                    _crmFeedBackBll.Add(new CrmFeedBackEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Idea = idea,
                        UserId = userId,
                        CreatorId = userId,
                        CreateBy = userName,
                        CreateOn = DateTime.Now
                    });

                    //return "[{\"result\":\"true\"}]";
                    Status = true;
                    obj = "true";
                }
            }
            catch (Exception ex)
            {
                //return "[{\"result\":\"false\"}]";
                Status = false;
                msg = ex.Message;
            }
            //return "[{\"result\":\"false\"}]";
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #region 每日一题

        /// <summary>
        /// 获取每日一题
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetDailyOneProblem(string context)
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
                    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;   //用户Id


                    if (string.IsNullOrEmpty(userId))
                    {
                        return JsonConvert.SerializeObject(new
                        {
                            Status = 0,
                            msg = "用户Id不能为空！"
                        });
                    }

                    // 判断当前用户是否答过题
                    if (_CrmDailyOneProblemRecordBll.IsExistDailyOneProblemBy(userId, DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        return JsonConvert.SerializeObject(new
                        {
                            Status = 2,
                            Id = "",
                            msg = "用户Id不能为空！"
                        });
                    }


                    // 获取题目
                    CrmDailyOneProblemEntity dailyOneProblem = _CrmDailyOneProblemBll.GetPublicDayQuestionByAppointedDay();
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = 1,
                    //    msg = "数据获取成功！",
                    //    Id = dailyOneProblem.Id,
                    //    QuestionsTypeId = dailyOneProblem.QuestionsTypeId,
                    //    QuestionsTypeName = dailyOneProblem.QuestionsTypeName,
                    //    Question = dailyOneProblem.Question,
                    //    OptionA = dailyOneProblem.OptionA,
                    //    OptionB = dailyOneProblem.OptionB,
                    //    OptionC = dailyOneProblem.OptionC,
                    //    OptionD = dailyOneProblem.OptionD,
                    //    OptionE = dailyOneProblem.OptionE,
                    //    OptionF = dailyOneProblem.OptionF,
                    //    OptionG = dailyOneProblem.OptionG,
                    //    Answer = dailyOneProblem.Answer.Trim()
                    //});
                    Status = true;
                    obj = new
                    {
                        Status = 1,
                        msg = "数据获取成功！",
                        Id = dailyOneProblem.Id,
                        QuestionsTypeId = dailyOneProblem.QuestionsTypeId,
                        QuestionsTypeName = dailyOneProblem.QuestionsTypeName,
                        Question = dailyOneProblem.Question,
                        OptionA = dailyOneProblem.OptionA,
                        OptionB = dailyOneProblem.OptionB,
                        OptionC = dailyOneProblem.OptionC,
                        OptionD = dailyOneProblem.OptionD,
                        OptionE = dailyOneProblem.OptionE,
                        OptionF = dailyOneProblem.OptionF,
                        OptionG = dailyOneProblem.OptionG,
                        Answer = dailyOneProblem.Answer.Trim()
                    };
                }
                else
                {
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = 0,
                    //    msg = "请求无context！"
                    //});
                    Status = false;
                    msg = "请求无context！";
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = 0,
                //    msg = "接口异常！" + ex.Message
                //});
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
        /// 答题结果上报
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string ReportDailyOneProblemRecord(string context)
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
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;   //题目Id
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;   //用户Id
                    var userName = Regex.Match(context, @"(?<=""UserName""\:"").*?(?="",)").Value;   //
                    var answer = Regex.Match(context, @"(?<=""Answer""\:"").*?(?="",)").Value;   //答案
                    var userAnswers = Regex.Match(context, @"(?<=""UserAnswers""\:"").*?(?="",)").Value;   //用户答案
                    var isCorrect = Regex.Match(context, @"(?<=""IsCorrect""\:"").*?(?="",)").Value;   //是否正确

                    if (string.IsNullOrEmpty(id))
                    {
                        return JsonConvert.SerializeObject(new
                        {
                            Status = 0,
                            msg = "题Id不能为空！"
                        });
                    }
                    if (string.IsNullOrEmpty(userId))
                    {
                        return JsonConvert.SerializeObject(new
                        {
                            Status = 0,
                            msg = "用户Id不能为空！"
                        });
                    }
                    // 获取题目
                    CrmDailyOneProblemRecordEntity model = new CrmDailyOneProblemRecordEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsCorrect = int.Parse(isCorrect),
                        ProblemId = id,
                        UserName = userName,
                        UserId = userId,
                        UserAnswers = userAnswers,
                        RightAnswer = answer,
                        RowStatus = 1,
                        CreateBy = userName,
                        CreateOn = DateTime.Now,
                        CreatorId = userId,
                        UpdateBy = userName,
                        UpdateOn = DateTime.Now,
                        UpdateId = userId,

                    };
                    //_CrmDailyOneProblemRecordBll.Add(model);

                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = 1,
                    //    msg = "答题结果上报成功！"
                    //});
                    Status = true;
                    obj = _CrmDailyOneProblemRecordBll.Add(model);
                    msg = "答题结果上报成功！";
                }
                else
                {
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = 0,
                    //    msg = "请求无context！"
                    //});
                    Status = false;
                    msg = "请求无context！";
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = 0,
                //    msg = "接口异常！" + ex.Message
                //});
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
        /// 徐题正确率 Top10
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetCorrectRateTopTen()
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                DataTable dt = _CrmDailyOneProblemRecordBll.GetCorrectRateTopTen();

                var rows = dt.AsEnumerable()
                 .Select(p => new
                {
                    UserId = p.Field<string>("UserId"),
                    UserName = p.Field<string>("UserName"),
                    CorrectRate = p.Field<double>("CorrectRate")
                });

                //return JsonConvert.SerializeObject(rows);
                Status = true;
                obj = rows;

            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = 0,
                //    msg = "接口异常！" + ex.Message
                //});
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
    }
}
