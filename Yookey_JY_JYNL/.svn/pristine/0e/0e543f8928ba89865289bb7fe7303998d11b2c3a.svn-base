using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.TeamManagement;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.WebService.TeamManagement
{
    /// <summary>
    /// 队伍管理 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TeamManagementService : System.Web.Services.WebService
    {
        readonly TeamManagementAttachBll _teamManagementAttachBll = new TeamManagementAttachBll();
        readonly TeamManagementProcessBll _teamManagementProcessBll = new TeamManagementProcessBll();
        readonly TeamManagementBll _teamManagementBll = new TeamManagementBll();
        readonly CrmUserBll _crmUserBll = new CrmUserBll();
        readonly CrmRoleBll _crmRoleBll = new CrmRoleBll();
        readonly TeamManagementStandardBll _teamManagementStandardBll = new TeamManagementStandardBll();

        /// <summary>
        /// 上报队伍考核
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string UploadTeamManagement(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "上报用户不存在！" });
                    Status = false;
                    msg = "上报用户不存在！";
                }

                var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value; //Id
                var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value; //大队Id
                var companyName = Regex.Match(context, @"(?<=""CompanyName""\:"").*?(?="",)").Value; //单位名称
                var departmentId = Regex.Match(context, @"(?<=""DepartmentId""\:"").*?(?="",)").Value; //部门ID
                var departmentName = Regex.Match(context, @"(?<=""DepartmentName""\:"").*?(?="",)").Value; //部门名称
                var classNo = Regex.Match(context, @"(?<=""ClassNo""\:"").*?(?="",)").Value; //大类ID
                var className = Regex.Match(context, @"(?<=""ClassName""\:"").*?(?="",)").Value; //大类名称

                var standardId = Regex.Match(context, @"(?<=""StandardId""\:"").*?(?="",)").Value; //考核标准Id  小类
                var standardName = Regex.Match(context, @"(?<=""StandardName""\:"").*?(?="",)").Value; //考核标准 小类

                var assessmentTime = Regex.Match(context, @"(?<=""AssessmentTime""\:"").*?(?="",)").Value; //考核时间
                var assessmentAddress = Regex.Match(context, @"(?<=""AssessmentAddress""\:"").*?(?="",)").Value; //考核地点
                var remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value; //信息描述

                //中队长指派
                var handleIdea = Regex.Match(context, @"(?<=""HandleIdea""\:"").*?(?="",)").Value; // 意见
                var assignUserId = Regex.Match(context, @"(?<=""AssignUserId""\:"").*?(?="",)").Value; // 指派人员Id
                string status = Regex.Match(context, @"(?<=""Status""\:"").*?(?="",)").Value; // 状态 0:待处理,1:处理中

                // 审核过程
                TeamManagementProcessEntity teamManagementProcess = null;
                ComNoteEntity noteEntity = null;
                CrmUserEntity assignUserModel = null;
                if (int.Parse(status) == 1)
                {
                    assignUserModel = _crmUserBll.Get(assignUserId);
                    if (assignUserModel == null)
                    {
                        //return JsonConvert.SerializeObject(new { result = false, msg = "指派队员不存在！" });
                        Status = false;
                        msg = "指派队员不存在！";
                    }

                    teamManagementProcess = new TeamManagementProcessEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        TeamManagementId = "",
                        Idea = handleIdea,
                        UserId = userId,
                        UserName = crmUserModel.RealName,
                        Status = 1,

                        RowStatus = 1,
                        CreateBy = crmUserModel.RealName,
                        CreatorId = userId,
                        CreateOn = DateTime.Now,
                        UpdateBy = crmUserModel.RealName,
                        UpdateId = userId,
                        UpdateOn = DateTime.Now,

                    };

                    if (!string.IsNullOrEmpty(assignUserModel.Mobile) && !assignUserModel.Mobile.Equals("&nbsp;"))
                    {
                        noteEntity = new ComNoteEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourcesId = "",
                            ReceivePhone = assignUserModel.Mobile,
                            MistakeInfo = "您有一条待处理的队伍管理考核任务，请及时处理！",
                            ReceiveTime = DateTime.Now,
                            Status = 0,
                            RowStatus = 1
                        };

                    }
                }

                //状态：0:待处理,1:处理中,2:已处理,3:已核查
                TeamManagementEntity model = new TeamManagementEntity()
                {
                    Id = id,
                    AssessmentAddress = assessmentAddress,
                    AssessmentTime = DateTime.Parse(assessmentTime),
                    ClassName = className,
                    ClassNo = classNo,
                    CompanyId = companyId,
                    CompanyName = companyName,
                    DepartmentId = departmentId,
                    DepartmentName = departmentName,
                    StandardId = standardId,
                    StandardName = standardName,
                    Remark = remark,
                    Status = int.Parse(status),
                    RowStatus = 1,
                    AssignUserId = assignUserId,
                    AssignUserName = assignUserModel != null ? assignUserModel.RealName : "",

                    CreateBy = crmUserModel.RealName,
                    CreatorId = userId,
                    CreateOn = DateTime.Now,
                    UpdateBy = crmUserModel.RealName,
                    UpdateId = userId,
                    UpdateOn = DateTime.Now,
                };


                _teamManagementBll.TransactionAddTeamManagement(model, teamManagementProcess);

                #region 发短信
                if (model.Status == 0)
                {
                    List<CrmUserEntity> crmUserList = _crmUserBll.GetUserListBySquadronLeader(companyId, departmentId, "中队长");
                    if (crmUserList.Any())
                    {
                        foreach (CrmUserEntity item in crmUserList)
                        {
                            if (string.IsNullOrEmpty(item.Mobile) || item.Mobile.Equals("&nbsp;")) continue;

                            noteEntity = new ComNoteEntity()
                            {
                                Id = Guid.NewGuid().ToString(),
                                ResourcesId = "",
                                ReceivePhone = item.Mobile,
                                MistakeInfo = "您有一条待处理的队伍管理考核，请及时处理！",
                                ReceiveTime = DateTime.Now,
                                Status = 0,
                                RowStatus = 1
                            };

                            new ComNoteBll().Add(noteEntity);
                        }
                    }
                    else
                    {
                        crmUserList = _crmUserBll.GetUserListBySquadronLeader(companyId, departmentId, "副中队长");
                        if (crmUserList.Any())
                        {
                            foreach (CrmUserEntity item in crmUserList)
                            {
                                if (string.IsNullOrEmpty(item.Mobile) || item.Mobile.Equals("&nbsp;")) continue;

                                noteEntity = new ComNoteEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    ResourcesId = "",
                                    ReceivePhone = item.Mobile,
                                    MistakeInfo = "您有一条待处理的队伍管理考核，请及时处理！",
                                    ReceiveTime = DateTime.Now,
                                    Status = 0,
                                    RowStatus = 1
                                };

                                new ComNoteBll().Add(noteEntity);
                            }
                        }
                    }
                }
                else if (model.Status == 1 && noteEntity != null)
                {
                    new ComNoteBll().Add(noteEntity);
                }

                #endregion

                //return JsonConvert.SerializeObject(new { result = true, msg = "上报成功！" });
                Status = true;
                obj = "true";
                msg = "上报成功！";
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
                Status = false;
            }

            //return JsonConvert.SerializeObject(new { });
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取队伍考核分页列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTeamManagementList(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                //var d = JsonConvert.DeserializeObject<dynamic>(context);

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value; //大队Id
                var departmentId = Regex.Match(context, @"(?<=""DepartmentId""\:"").*?(?="",)").Value; //部门ID
                var classNo = Regex.Match(context, @"(?<=""ClassNo""\:"").*?(?="",)").Value; //八大类ID
                var pageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value; //起始页
                var pageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value; //页大小
                var sTime = Regex.Match(context, @"(?<=""STime""\:"").*?(?="",)").Value; //考核时间起
                var eTime = Regex.Match(context, @"(?<=""ETime""\:"").*?(?="",)").Value; //考核时间止
                var status = Regex.Match(context, @"(?<=""Status""\:"").*?(?="",)").Value; //状态 1:处理中,2:已处理 

                if (!string.IsNullOrEmpty(companyId) && string.IsNullOrEmpty(departmentId))
                {
                    //return JsonConvert.SerializeObject(new { result = true, data = new { } });
                    Status = true;
                }

                if (companyId == "all")
                {
                    companyId = "";
                }
                if (departmentId == "all")
                {
                    departmentId = "";
                }

                int totalRecords = 0;

                List<TeamManagementEntity> teamManagementList = _teamManagementBll.GetTeamManagementPage(new TeamManagementEntity()
                {
                    CompanyId = companyId,
                    DepartmentId = departmentId,
                    ClassNo = classNo,
                    STime = sTime,
                    ETime = eTime,
                    Status = int.Parse(status),
                    PageIndex = int.Parse(pageIndex),
                    PageSize = int.Parse(pageSize)
                }, out totalRecords);

                var result = (from aeamManagementEntity in teamManagementList
                              select new
                              {
                                  Id = aeamManagementEntity.Id,
                                  AssessmentAddress = aeamManagementEntity.AssessmentAddress,
                                  Remark = aeamManagementEntity.Remark,
                                  ClassName = aeamManagementEntity.ClassName,
                                  AssessmentTime = aeamManagementEntity.AssessmentTime.ToString("yyyy-MM-dd HH:ss:mm"),
                                  Status = aeamManagementEntity.Status

                              }).ToList();

                //return JsonConvert.SerializeObject(new { result = true, data = result });
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
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
        /// 通过登录用户查询待办的队伍考核分布列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTeamManagementListByUserId(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                int totalRecords = 0;

                List<TeamManagementEntity> assessmentList = _teamManagementBll.GetTeamManagementPage(new TeamManagementEntity()
                {
                    Status = 1,
                    AssignUserId = userId,
                }, out totalRecords);

                var result = (from assessmentEntity in assessmentList
                              select new
                              {
                                  Id = assessmentEntity.Id,
                                  AssessmentAddress = assessmentEntity.AssessmentAddress,
                                  Remark = assessmentEntity.Remark,
                                  ClassName = assessmentEntity.ClassName,
                                  AssessmentTime = assessmentEntity.AssessmentTime.ToString("yyyy-MM-dd HH:ss:mm"),
                                  Status = assessmentEntity.Status

                              }).ToList();

                //return JsonConvert.SerializeObject(new { result = true, data = result });
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
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
        /// 通过案件Id查询案件信息和附件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTeamManagementById(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                var id = Regex.Match(context, @"(?<=""id""\:"").*?(?="",)").Value; //案件Id

                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                TeamManagementEntity assessment = _teamManagementBll.Get(id);
                if (assessment == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核不存在！" });
                    Status = false;
                    msg = "队伍管理考核不存在！";
                }

                List<TeamManagementProcessEntity> assessmentProcessList = _teamManagementProcessBll.GetTeamManagementProcessListByTeamManagementId(id, (int)TeamManagementSate.Processed);
                if (assessmentProcessList.Any())
                {
                    assessment.HandlingIdea = assessmentProcessList.FirstOrDefault().Idea;
                }

                List<TeamManagementAttachEntity> assessmentAttachList = _teamManagementAttachBll.GetTeamManagementAttachListByTeamManagementId(id);
                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
                var fileViewLink = AppConfig.FileViewLink;
                switch (netWork)
                {
                    case CommonMethod.NetWorkEnum.Intranet:   //内网
                        fileViewLink = AppConfig.FileViewLink;
                        break;
                    case CommonMethod.NetWorkEnum.OutNet:     //外网
                        fileViewLink = AppConfig.FileViewOutNetLink;
                        break;
                }

                var result = (from assessmentAttach in assessmentAttachList
                              select new
                              {
                                  Id = assessmentAttach.Id,
                                  FileName = assessmentAttach.FileName,
                                  FileReName = assessmentAttach.FileReName,
                                  FileAddress = fileViewLink + assessmentAttach.FileAddress,
                                  FileType = assessmentAttach.FileType,
                                  FileTypeName = assessmentAttach.FileTypeName

                              }).ToList();

                //return JsonConvert.SerializeObject(new { result = true, data = assessment, attach = result });
                Status = true;
                obj = result;
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
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
        /// 获取队伍管理考核待办数量
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTeamManagementToDoNumber(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                // 是否是中队长（副中队长）
                bool isSquadronLeader = _crmRoleBll.IsSquadronLeader(userId);
                string assignUserId = "";
                int state = -1;
                if (isSquadronLeader)
                {
                    state = 0;
                }
                else
                {
                    assignUserId = userId;
                    state = 1;
                }


                int totalRecords = _teamManagementBll.GetTeamManagementToDoNumber(crmUserModel.CompanyId, crmUserModel.DepartmentId, assignUserId, state);

                //return JsonConvert.SerializeObject(new { result = true, data = totalRecords });
                Status = true;
                obj = totalRecords;
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
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
        /// 处理队伍管理考核（核实）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string HandleTeamManagement(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value; // 案件Id
                var handleIdea = Regex.Match(context, @"(?<=""HandleIdea""\:"").*?(?="",)").Value; // 案件Id

                string status = Regex.Match(context, @"(?<=""Status""\:"").*?(?="",)").Value; // 状态 2:已处理,3:已核查
                if (string.IsNullOrEmpty(status))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "处理状态不正确！" });
                    Status = false;
                    msg = "处理状态不正确！";

                }
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                // 获取考核
                TeamManagementEntity entity = _teamManagementBll.Get(id);
                if (entity == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核不存在！" });
                    Status = false;
                    msg = "队伍管理考核不存在！";
                }

                if (int.Parse(status) == 2)
                {
                    if (entity.Status == (int)TeamManagementSate.Processed)
                    {
                        //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核已处理！" });
                        Status = false;
                        msg = "队伍管理考核已处理！";
                    }

                    entity.HandlingTime = DateTime.Now;
                }
                //0:待处理,1:处理中,2:已处理,3:已核查
                if (entity.Status == (int)TeamManagementSate.Check)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核已核查！" });
                    Status = false;
                    msg = "队伍管理考核已核查！";
                }

                if (entity.Status == (int)TeamManagementSate.Pending && int.Parse(status) == 2)
                {
                    entity.AssignUserId = userId;
                    entity.AssignUserName = crmUserModel.RealName;
                }
                entity.Status = int.Parse(status);
                entity.UpdateBy = crmUserModel.RealName;
                entity.UpdateId = userId;
                entity.UpdateOn = DateTime.Now;

                TeamManagementProcessEntity assessmentProcess = new TeamManagementProcessEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    TeamManagementId = entity.Id,
                    Idea = handleIdea,
                    UserId = userId,
                    UserName = crmUserModel.RealName,
                    Status = int.Parse(status),

                    RowStatus = 1,
                    CreateBy = crmUserModel.RealName,
                    CreatorId = userId,
                    CreateOn = DateTime.Now,
                    UpdateBy = crmUserModel.RealName,
                    UpdateId = userId,
                    UpdateOn = DateTime.Now,

                };

                _teamManagementBll.TransactionHandleTeamManagement(entity, assessmentProcess);

                //return JsonConvert.SerializeObject(new { result = true, msg = "处理成功！" });
                Status = true;
                obj = "true";
                msg = "处理成功！";
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
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
        /// 指派队伍管理考核
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string AssignTeamManagement(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(context))
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "参数不能为空！" });
                    Status = false;
                    msg = "参数不能为空！";
                }

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value; //上报用户Id
                var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value; // 案件Id
                var handleIdea = Regex.Match(context, @"(?<=""HandleIdea""\:"").*?(?="",)").Value; // 意见
                var assignUserId = Regex.Match(context, @"(?<=""AssignUserId""\:"").*?(?="",)").Value; // 指派人员Id
                CrmUserEntity crmUserModel = _crmUserBll.Get(userId);
                if (crmUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "用户不存在！" });
                    Status = false;
                    msg = "用户不存在！";
                }

                CrmUserEntity assignUserModel = _crmUserBll.Get(assignUserId);
                if (assignUserModel == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "指派人员不存在！" });
                    Status = false;
                    msg = "指派人员不存在！";
                }

                // 获取考核
                TeamManagementEntity entity = _teamManagementBll.Get(id);
                if (entity == null)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核不存在！" });
                    Status = false;
                    msg = "队伍管理考核不存在！";
                }

                if (entity.Status == (int)TeamManagementSate.Processing)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核已指派！" });
                    Status = false;
                    msg = "队伍管理考核已指派！";
                }

                if (entity.Status == (int)TeamManagementSate.Processed)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核已处理！" });
                    Status = false;
                    msg = "队伍管理考核已处理！";
                }

                if (entity.Status == (int)TeamManagementSate.Check)
                {
                    //return JsonConvert.SerializeObject(new { result = false, msg = "队伍管理考核已核查！" });
                    Status = false;
                    msg = "队伍管理考核已核查！";
                }

                entity.Status = (int)TeamManagementSate.Processing;
                entity.AssignUserId = assignUserId;
                entity.AssignUserName = assignUserModel.RealName;

                entity.UpdateBy = crmUserModel.RealName;
                entity.UpdateId = userId;
                entity.UpdateOn = DateTime.Now;

                TeamManagementProcessEntity assessmentProcess = new TeamManagementProcessEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    TeamManagementId = entity.Id,
                    Idea = handleIdea,
                    UserId = userId,
                    UserName = crmUserModel.RealName,
                    Status = (int)TeamManagementSate.Pending,

                    RowStatus = 1,
                    CreateBy = crmUserModel.RealName,
                    CreatorId = userId,
                    CreateOn = DateTime.Now,
                    UpdateBy = crmUserModel.RealName,
                    UpdateId = userId,
                    UpdateOn = DateTime.Now,

                };

                _teamManagementBll.TransactionHandleTeamManagement(entity, assessmentProcess);

                if (!string.IsNullOrEmpty(assignUserModel.Mobile) && !assignUserModel.Mobile.Equals("&nbsp;"))
                {
                    var noteEntity = new ComNoteEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ResourcesId = "",
                        ReceivePhone = assignUserModel.Mobile,
                        MistakeInfo = "您有一条待处理的队伍管理考核任务，请及时处理！",
                        ReceiveTime = DateTime.Now,
                        Status = 0,
                        RowStatus = 1
                    };

                    new ComNoteBll().Add(noteEntity);
                }

                //return JsonConvert.SerializeObject(new { result = true, msg = "处理成功！" });
                Status = true;
                obj = "true";
                msg = "处理成功！";
            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
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
        /// 通过考核大类获取考核明细（小类）
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTeamManagementStandardByClassId(string context)
        {
            string msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var classId = Regex.Match(context, @"(?<=""classId""\:"").*?(?="",)").Value;
                IList<TeamManagementStandardEntity> list = _teamManagementStandardBll.GetSearchResult(new TeamManagementStandardEntity() { ClassTypeId = classId });

                var result = (from entity in list
                              select new
                              {
                                  entity.Id,
                                  entity.ClassTypeId,
                                  entity.ClassTypeIdName,
                                  entity.StandardContent

                              }).ToList();

                //return JsonConvert.SerializeObject(new { result = true, data = result });
                Status = true;
                obj = result;

            }
            catch (Exception ex)
            {
                //msg = "错误：" + ex.Message;
                //msg = "";
                //return JsonConvert.SerializeObject(new { result = false, msg = msg });
                Status = false;
                msg = ex.Message;
            }
            var results = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(results);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="imageDate"></param>
        /// <param name="imageName"></param>
        /// <param name="fileType"></param>
        /// <param name="userID"></param>
        /// <param name="imageType"></param>
        /// <param name="worklistId"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveImage(string resourceId, byte[] imageDate, string imageName, string userID, string fileType)
        {
            try
            {
                //return _teamManagementAttachBll.SaveImage(resourceId, imageDate, imageName, userID, fileType) ? "true" : "false";

                #region 写入到本地硬盘（不用）

                //var urlpath = string.Format(@"/{0}/{1}/{2}/", "Assessment", DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
                //var dirpath = AppConfig.FileSaveAddr + urlpath;
                //if (!Directory.Exists(dirpath))
                //{
                //    Directory.CreateDirectory(dirpath);
                //}

                //var filename = GetFileName(imageName.ToLower());   //重新生成命称
                ////将图片写到硬盘
                //var fs = new FileStream(dirpath + filename, FileMode.CreateNew, FileAccess.Write, FileShare.None, imageDate.Length, false);
                //fs.Write(imageDate, 0, imageDate.Length);
                //fs.Close();
                //fs.Dispose();

                #endregion

                #region 调用服务存储照片

                var filename = GetFileName(imageName.ToLower());   //重新生成命称

                //调用WebService进行文件存储.FileExt(postedFile.FileName)
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("TeamManagement",
                    CommonMethod.FileExt(imageName), filename, imageDate);

                #endregion

                #region 实体赋值

                var fileTypeName = "";
                if (fileType == "1")
                {
                    fileTypeName = "问题照片";
                }
                else if (fileType == "2")
                {
                    fileTypeName = "处理照片";
                }
                //fileTypeName = _comResourceBll.GetSearchResult(new ComResourceEntity() { Id = fileType })[0].RsKey;
                //执行数据库保存
                var result = Guid.NewGuid().ToString();
                var entity = new TeamManagementAttachEntity()
                {
                    Id = result,
                    ResourceId = resourceId,
                    FileType = fileType,
                    FileTypeName = fileTypeName,
                    FileAddress = filePath,
                    FileName = imageName,
                    FileReName = filename,
                    FileRemark = "注释",
                    RowStatus = 1,
                    IsCompleted = 1,
                    CreatorId = userID,
                    CreateOn = DateTime.Now,
                    UpdateId = userID,
                    UpdateOn = DateTime.Now
                };
                _teamManagementAttachBll.Add(entity);

                #endregion

                return "true";
            }
            catch (Exception)
            {
                return "error";
            }
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
                var random = new Random();
                var extension = ".jpg";
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var filename = Regex.Match(context, @"(?<=""filename""\:"").*?(?="",)").Value;
                if (filename.Contains("."))
                {
                    extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                    ? filename.Substring(filename.IndexOf('.'))
                                    : ".jpg";
                }
                //return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
                Status = true;
                obj = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
            }
            catch (Exception)
            {
                //return JsonConvert.SerializeObject(new { result = false });
                Status = false;
            }
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}
