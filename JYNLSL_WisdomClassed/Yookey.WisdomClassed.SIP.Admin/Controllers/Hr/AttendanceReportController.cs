using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class AttendanceReportController : BaseController
    {
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        private readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();
        private readonly ComAttachmentBll _comAttachmentBll = new ComAttachmentBll();

        #region 视图

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增/编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public ActionResult Apply(string id)
        {
            var entity = new AttendanceReportEntity();
            if (!string.IsNullOrEmpty(id))
            {
                //考勤列表详情
                entity = new AttendanceReportBll().Get(id);
                ViewData["AttendanceList"] = new AttendanceReportDetailsBll().GetSearchResult(new AttendanceReportDetailsEntity() { ReportId = id });

                //获取部门下面所有人员
                var users = new CrmUserBll().GetUserList(new CrmUserEntity() { DepartmentId = entity.DepartmentId });
                ViewData["UserList"] = users;

            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.SMonth = DateTime.Now.Day >= 26 ? DateTime.Now.AddMonths(-1) : DateTime.Now;
            }

            //考勤类型
            var attendType = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0051" });
            attendType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AttendType"] = new SelectList(attendType, "Id", "RsKey", "");

            ViewBag.AttendTypeList = attendType;

            return View(entity);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(string id, string worklistId)
        {
            var entity = new AttendanceReportEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                //考勤列表详情
                entity = new AttendanceReportBll().Get(id);
                ViewData["AttendanceList"] = new AttendanceReportDetailsBll().GetSearchResult(new AttendanceReportDetailsEntity() { ReportId = id });

                //获取部门下面所有人员
                var users = new CrmUserBll().GetUserList(new CrmUserEntity() { DepartmentId = entity.DepartmentId });
                ViewData["UserList"] = users;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.SMonth = DateTime.Now.Day >= 26 ? DateTime.Now.AddMonths(-1) : DateTime.Now;
            }


            if (!string.IsNullOrEmpty(worklistId))
            {
                var messageEntity = new CrmMessageWorkBll().Get(worklistId);

                //当前消息接收人是发启人
                if (messageEntity != null && messageEntity.FormAddress.IndexOf("FE_End=true") > 0)
                {
                    messageEntity.State = 2;
                    new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                }
                messagelist.Add(messageEntity); //将消息增加到集合
            }
            else
            {
                worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            switch (entity.State)
            {
                case -2:
                    ViewBag.Status = "已作废";
                    break;
                case -1:
                    ViewBag.Status = "审批不通过";
                    break;
                case 0:
                    ViewBag.Status = "已登记";
                    break;
                default:
                    if (entity.State > 0 && entity.State < 10)
                    {
                        ViewBag.Status = "审批中";
                    }
                    else if (entity.State == 10)
                    {
                        ViewBag.Status = "审批通过";
                    }
                    break;
            }
            
            #region 验证按钮权限

            //保存、申请、审批（同意、不同意）、作废
            bool btnSave = false, btnApply = false, btnAgree = false, btnCancel = false;

            //待做：这里需要验证是否有处理的权限
            if (entity.State == 0)
            {
                btnSave = true;
                btnApply = true;
            }

            if (!string.IsNullOrEmpty(worklistId) && entity.State > 0 && entity.State < 10)
            {
                btnAgree = true;     //预审通过
            }
            if (entity.State == 10)
            {
                btnSave = true;
                btnCancel = true;
            }

            ViewBag.BtnSave = btnSave;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnCancel = btnCancel;

            #endregion


            //考勤类型
            var attendType = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0051" });
            attendType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AttendType"] = new SelectList(attendType, "Id", "RsKey", "");
            ViewBag.AttendTypeList = attendType;

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "考勤申报审批");
            ViewBag.WorkListId = worklistId;
            //附件
            var files = _comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = id });
            ViewData["Files"] = files;
            return View(entity);
        }

        #endregion

        #region  Ajax获取数据

        /// <summary>
        /// 获取考勤申报信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryListJson(string companyId, string deptId, string startTime, string endTime, int rows = 30, int page = 1)
        {
            if (!string.IsNullOrEmpty(companyId) && companyId == "all")
            {
                companyId = "";
            }
            if (!string.IsNullOrEmpty(deptId) && deptId == "all")
            {
                deptId = "";
            }

            var data = new AttendanceReportBll().GetAllAttendanceReport(companyId, deptId, startTime, endTime, "", rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        #endregion

        #region Ajax提交数据

        /// <summary>
        /// 保存考勤申报信息
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveAttendanceReport(AttendanceReportEntity entity)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                var user = CurrentUser.CrmUser;

                #region 考勤列表

                //人员
                List<string> userList = Request["Users"] != null ? Request["Users"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //考勤类型
                List<string> attendTypeList = Request["AttendType"] != null ? Request["AttendType"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //开始时间
                List<string> startTimeList = Request["StartTime"] != null ? Request["StartTime"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //截止时间
                List<string> endTimeList = Request["EndTime"] != null ? Request["EndTime"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //备注
                List<string> remarkList = Request["DetailRemark"] != null ? Request["DetailRemark"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();


                List<AttendanceReportDetailsEntity> detailList = new List<AttendanceReportDetailsEntity>();

                int indexStr = 0;
                foreach (string item in userList)
                {
                    var model = new AttendanceReportDetailsEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ReportId = entity.Id,
                            UserId = item,
                            AttendType = attendTypeList[indexStr],
                            StartTime = Convert.ToDateTime(startTimeList[indexStr]),
                            EndTime = Convert.ToDateTime(endTimeList[indexStr]),
                            Remark = remarkList[indexStr],
                            OrderNo = indexStr,
                            RowStatus = (int)RowStatus.Normal,
                            CreateBy = CurrentUser.CrmUser.UserName,
                            CreatorId = CurrentUser.CrmUser.Id,
                            CreateOn = DateTime.Now,
                            UpdateBy = CurrentUser.CrmUser.UserName,
                            UpdateId = CurrentUser.CrmUser.Id,
                            UpdateOn = DateTime.Now,
                        };
                    indexStr++;
                    detailList.Add(model);
                }

                #endregion

                entity.State = entity.State == -1 ? 0 : entity.State;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.RowStatus = 1;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                isOk = new AttendanceReportBll().TransactionSave(entity, detailList);
            }
            catch (Exception ex)
            {
                isOk = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddAttachmentOfApply(ComAttachmentEntity entity)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //如果多次提交执行覆盖
                var lstAttachment = new ComAttachmentBll().Query(QueryCondition.Instance.AddEqual(ComAttachmentEntity.Parm_ComAttachment_ResourceId, entity.ResourceId).AddEqual(ComAttachmentEntity.Parm_ComAttachment_RowStatus, "1"));
                if (lstAttachment != null && lstAttachment.Count > 0)
                {
                    ComAttachmentEntity one = lstAttachment[0];
                    UpdateModel(one);
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = new ComAttachmentBll().Update(one);
                    isOk = res > 0;
                }
                else
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = 1;
                    entity.CreatorId = user.Id;
                    entity.CreateBy = user.UserName;
                    entity.CreateOn = DateTime.Now;

                    entity.UpdateId = user.Id;
                    entity.UpdateBy = user.UserName;
                    entity.UpdateOn = DateTime.Now;
                    new ComAttachmentBll().Add(entity);
                    isOk = true;
                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<WorkOvertimeEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }

        #endregion
    }
}
