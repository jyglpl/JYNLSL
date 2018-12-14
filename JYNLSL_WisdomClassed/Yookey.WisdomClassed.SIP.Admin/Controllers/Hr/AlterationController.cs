using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    public class AlterationController : BaseController
    {
        private readonly BaseDepartmentBll _departmentBll = new BaseDepartmentBll();
        private readonly BaseUserBll _crmUserBll = new BaseUserBll();
        private readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        private readonly FlightAlterationBll _alterationBll = new FlightAlterationBll();

        #region View

        // GET: /Alteration/

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

        public ActionResult Apply()
        {
            var deptId = CurrentUser.CrmUser.DeptId;
            //执法大队下所有部门
            var depts = _departmentBll.GetAllDetachment("all");
            depts.Insert(0, new BaseDepartmentEntity() { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", deptId);

            //人员
            var lstUser = new List<BaseUserEntity> { new BaseUserEntity() { Id = "", UserName = "==请选择==" } };
            ViewData["Users"] = new SelectList(lstUser, "Id", "UserName", "");

            var model = new FlightAlterationEntity()
            {
                Id = Guid.NewGuid().ToString()
            };
            return View(model);
        }


        /// <summary>
        /// 调班详情
        /// </summary>
        /// <param name="id">调班表单ID</param>
        /// <param name="worklistid">待办事宜ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Detail(string id, string worklistid)
        {
            var entity = new FlightAlterationEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _alterationBll.Get(id);
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
                    entity = _alterationBll.Get(messageEntity.FormID); //调班实体
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
            bool showBeforeUserIdBtn = CurrentUser.CrmUser.Id == entity.AferUserId ? true : false;

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

            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "调班审批");
            ViewBag.ShowApplyBtn = showApplyBtn;
            ViewBag.ShowExaminBtn = showExamineBtn;
            ViewBag.ShowCancelBtn = showCancelBtn;
            ViewBag.ShowPrintBtn = showPrintBtn;
            ViewBag.ShowBeforeUserIdBtn = showBeforeUserIdBtn;
            ViewBag.WorkListId = string.IsNullOrEmpty(worklistid) ? "" : worklistid;

            //附件
            var files = new ComAttachmentBll().GetSearchResult(new ComAttachmentEntity() {ResourceId = entity.Id});
            ViewData["Files"] = files;

            return View(entity);
        }

        #endregion

        #region AJAX GET

        /// <summary>
        /// 获调班数据
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="keyWords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GridJson(string companyId, string deptId, string startTime, string endTime,string keyWords, int rows = 30, int page = 1)
        {
            keyWords = HttpUtility.UrlDecode(keyWords);
            var data = _alterationBll.GetSearchResult(companyId, deptId, startTime, endTime, keyWords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

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
        public string AjLoadUsers(string deptId, string selectIds)
        {
            var sbUsers = new StringBuilder();
            var selectIdSp = selectIds.Split(',');
            foreach (var selectId in selectIdSp)
            {
                sbUsers.AppendFormat("document.getElementById('{0}').options.length = 1;", selectId);
            }
            if (!string.IsNullOrEmpty(deptId))
            {
                var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = deptId }).ToList();
                if (users.Count > 0)
                {
                    var i = 1;
                    foreach (var t in users.Where(t => !string.IsNullOrEmpty(t.UserName)))
                    {
                        foreach (var selectId in selectIdSp)
                        {
                            sbUsers.Append("document.getElementById('" + selectId + "').options[" + i + "] = new Option('" +
                                      t.UserName + "', '" + t.Id + "', false, false);");
                        }
                        i++;
                    }
                }
            }
            return sbUsers.ToString();
        }

        #endregion

        #region AJAX POST

        /// <summary>
        /// 保存调班
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">The entity.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(FlightAlterationEntity entity)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                var one = _alterationBll.Get(entity.Id);
                if (one != null)
                {
                    UpdateModel(one);
                    one.UpdateId = user.Id;
                    one.UpdateBy = user.UserName;
                    one.UpdateOn = DateTime.Now;
                    int res = _alterationBll.Update(one);
                    isOk = res > 0;
                }
                else
                {
                    entity.RowStatus = 1;
                    entity.CreatorId = user.Id;
                    entity.CreateBy = user.UserName;
                    entity.CreateOn = DateTime.Now;

                    entity.UpdateId = user.Id;
                    entity.UpdateBy = user.UserName;
                    entity.UpdateOn = DateTime.Now;
                    new ComAttachmentBll().SaveAttachment(entity.Id, entity.Attachment);    //保存附件材料
                    _alterationBll.AddTranByCrmMessageWork(entity);//新增并插入消息
                    isOk = true;
                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<FlightAlterationEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }


        /// <summary>
        /// 删除数据 
        /// </summary>
        /// <param name="applyId">主键编号</param>
        /// <returns></returns>
        public JsonResult DeleteApply(string applyId)
        {
            var isOk = false; 
            var one = _alterationBll.Get(applyId);
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                if (one != null)
                {
                    if (CurrentUser.CrmUser.Id == one.BeforeUserId&&one.Status==0)//只能删除自己登记调班
                    {
                        one.RowStatus = 0;//执行假删
                        one.UpdateId = user.Id;
                        one.UpdateBy = user.UserName;
                        one.UpdateOn = DateTime.Now;
                        isOk = _alterationBll.deleTranByCrmMessageWork(one);
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<FlightAlterationEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = string.Empty
            };
            if (isOk)
            {
                result.rtMsrg = "调班单删除成功";
            }
            else if (!isOk && CurrentUser.CrmUser.Id != one.BeforeUserId)
            {
                result.rtMsrg = "不能删除他人的调班单！";
            }
            else if (!isOk)
            {
                result.rtMsrg = "删除调班单失败！";
            }
            return Json(result);
        }

        /// <summary>
        /// 作废 
        /// </summary>
        /// <param name="applyId">主键编号</param>
        /// <returns></returns>
        public JsonResult CancelApply(string applyId)
        {
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                //判断是否存在
                var one = _alterationBll.Get(applyId);
                if (one != null && one.Status > 0 && one.Status < 10)
                {
                    isOk = _alterationBll.UpdateState(applyId, -2);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<AttendanceLeaveEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result);
        }

        #endregion

        /// <summary>
        /// 修改调班状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeFlightAlterationState(string formId, int state, string flowName, string worklistId)
        {
            var isOk = false;
            try
            {
                string ideadate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //判断是否存在
                isOk = _alterationBll.UpdataTranByCrmMessageWork(formId, state, flowName, "apply", worklistId, ideadate, CurrentUser.CrmUser);
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<FlightAlterationEntity>
            {
                rtState = isOk ? 1 : -1,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
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
