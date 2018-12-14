using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class WorkOvertimeController : BaseController
    {
        private readonly BaseUserBll _crmUserBll = new BaseUserBll();
        private readonly WorkOvertimeBll _workOvertimeBll = new WorkOvertimeBll();
        private readonly ComAttachmentBll _comAttachmentBll = new ComAttachmentBll();
        private readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        //
        // GET: /WorkOvertime/

        public ActionResult Index()
        {
            var user = CurrentUser.CrmUser;
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            return View();
        }

        /// <summary>
        /// 数据查询列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="keyWords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryListJson(string companyId, string deptId, string startTime, string endTime, string keyWords, int rows = 30, int page = 1)
        {
            keyWords = HttpUtility.UrlDecode(keyWords);
            var data = _workOvertimeBll.GetSearchResult(companyId, deptId, startTime, endTime, keyWords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        public ActionResult Apply()
        {
            var deptId = CurrentUser.CrmUser.DeptId;
            //执法大队下所有部门
            var depts = _crmDeptBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity() { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", deptId);

            //人员
            var lstUser = new List<BaseUserEntity> { new BaseUserEntity() { Id = "", UserName = "==请选择==" } };
            ViewData["Users"] = new SelectList(lstUser, "Id", "UserName", "");

            var model = new WorkOvertimeEntity
            {
                BeginTime = DateTime.Today.AddHours(8),
                EndTime = DateTime.Today.AddHours(17),
                Id = Guid.NewGuid().ToString()
            };
            return View(model);
        }

        /// <summary>
        /// 保存加班
        /// 创建人：陈玲
        /// 创建日期：2017年4月25日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateApply(WorkOvertimeEntity entity)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                var one = _workOvertimeBll.Get(entity.Id);
                entity.RowStatus = 1;
                if (one == null)
                {
                    entity.CreatorId = user.Id;
                    entity.CreateBy = user.UserName;
                    entity.CreateOn = DateTime.Now;
                }
                else
                {
                    entity.UpdateId = user.Id;
                    entity.UpdateBy = user.UserName;
                    entity.UpdateOn = DateTime.Now;
                }
                isOk = _workOvertimeBll.TransactionSaveWorkOvertime(entity);
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

        /// <summary>
        /// 添加附件
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
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
                var lstAttachment = _comAttachmentBll.Query(QueryCondition.Instance.AddEqual(ComAttachmentEntity.Parm_ComAttachment_ResourceId, entity.ResourceId).AddEqual(ComAttachmentEntity.Parm_ComAttachment_RowStatus, "1"));
                if (lstAttachment != null && lstAttachment.Count > 0)
                {
                    ComAttachmentEntity one = lstAttachment[0];
                    UpdateModel(one);
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = _comAttachmentBll.Update(one);
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
                    _comAttachmentBll.Add(entity);
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
        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worklistid"></param>
        /// <returns></returns>
        public ActionResult Detail(string id, string worklistid)
        {
            var entity = new WorkOvertimeEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _workOvertimeBll.Get(id);
                messagelist = new CrmMessageWorkBll().GetSearchResult(new CrmMessageWorkEntity() { FormID = id, State = 2 });

                if (!string.IsNullOrEmpty(worklistid))
                {
                    var messDt = new CrmMessageWorkBll().GetUnHandleMessage(CurrentUser.CrmUser.Id, id);
                    if (messDt != null && messDt.Rows.Count > 0)
                    {
                        worklistid = messDt.Rows[0]["Id"].ToString();
                    }
                }
            }
            if (!string.IsNullOrEmpty(worklistid))
            {
                var messageEntity = new CrmMessageWorkBll().Get(worklistid);

                //当前消息接收人是发启人
                if (messageEntity != null && messageEntity.FormAddress.IndexOf("FE_End=true") > 0)
                {
                    messageEntity.State = 2;
                    new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                }
                messagelist.Add(messageEntity); //将消息增加到集合
                if (!string.IsNullOrEmpty(messageEntity.FormID))
                {
                    entity = _workOvertimeBll.Get(messageEntity.FormID); //请假登记实体
                }
            }
            else
            {
                worklistid = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }

            var showExamineBtn = false;  //是否显示审批按钮
            var showApplyBtn = false;    //是否显示申请按钮
            var showCancelBtn = false;   //是否显示作废按钮
            var showPrintBtn = false;    //是否显示打印按钮

            messagelist = messagelist.Where(x => x.ActionerID == CurrentUser.CrmUser.Id && x.State != 2 && x.FormAddress.IndexOf("FE_End=true") == -1).ToList();
            if (messagelist.Count > 0)   //有未处理消息
                showExamineBtn = true;
            else
            {
                if (CurrentUser.CrmUser.DeptId == entity.DeptId && entity.Status == 0)  //只能由当前部门下面的人员进行申请
                    showApplyBtn = true;
            }

            switch (entity.Status)
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
                    if (entity.Status > 0 && entity.Status < 10)
                    {
                        ViewBag.Status = "审批中";
                        showCancelBtn = true; //只有审批中的或者审批通过的才能作废
                    }
                    else if (entity.Status == 10)
                    {
                        ViewBag.Status = "审批通过";
                        showCancelBtn = true; //只有审批中的或者审批通过的才能作废
                        showPrintBtn = true;  //审批通过后显示打印按钮 
                    }
                    break;
            }

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "加班审批");
            ViewBag.ShowApplyBtn = showApplyBtn;
            ViewBag.ShowExaminBtn = showExamineBtn;
            ViewBag.ShowCancelBtn = showCancelBtn;
            ViewBag.ShowPrintBtn = showPrintBtn;
            ViewBag.WorkListId = string.IsNullOrEmpty(worklistid) ? "" : worklistid;

            //附件
            var files = _comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = id });
            ViewData["Files"] = files;
            return View(entity);
        }

        /// <summary>
        /// 删除加班
        /// 创建人：周庆
        /// 创建日期：2015年4月22日
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <returns></returns>
        public JsonResult Delete(string ApplyId)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                WorkOvertimeEntity one = _workOvertimeBll.Get(ApplyId);
                if (one != null)
                {
                    one.RowStatus = 0;//执行假删
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = _workOvertimeBll.Update(one);
                    //删除附件（如果有的话）
                    res += _comAttachmentBll.DeleteAttachementByResourceId(ApplyId);
                    isOk = res > 0;

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


        /// <summary>
        /// 作废加班（只有审批中或审批通过的才能作废）
        /// 创建人：周庆
        /// 创建日期：2015年4月30日
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <returns></returns>
        public JsonResult CancelApply(string ApplyId)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                WorkOvertimeEntity one = _workOvertimeBll.Get(ApplyId);
                if (one != null && one.Status > 0 && one.Status <= 10)
                {
                    isOk = _workOvertimeBll.UpdateState(ApplyId, -2);
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

            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }

    }
}
