using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    /// <summary>
    /// 每日一题 控制器
    /// </summary>
    public class DailyOneProblemController : BaseController
    {

        readonly CrmDailyOneProblemBll _CrmDailyOneProblemBll = new CrmDailyOneProblemBll();// 每日一题
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典

        #region 题目管理 列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 请求数据列表
        /// </summary>
        public string GetQuestionList(string question, string starttime, string endtime, int rowStatus, int rows, int page)
        {
            var data = _CrmDailyOneProblemBll.GetSearchResult((new CrmDailyOneProblemEntity()
            {
                Question = question,
                RowStatus = rowStatus,
                PageIndex = page,
                PageSize = rows
            }), starttime, endtime);

            return CommonMethod.PageToJson(data);
        }

        #endregion

        /// <summary>
        /// 编辑/详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            var entity = new CrmDailyOneProblemEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _CrmDailyOneProblemBll.Get(id);
            }
            else
            {
                entity.Time = DateTime.Now;
                entity.RowStatus = 1;
            }

            //试题类型
            var questionsTypeList = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0069" });
            ViewData["TypeList"] = new SelectList(questionsTypeList, "Id", "RsKey", entity.QuestionsTypeId);
            return View(entity);
        }

        /// <summary>
        /// 积分编辑
        /// </summary>
        /// <param name="cgDynamic"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public string SubmitForm(CrmDailyOneProblemEntity entity)
        {
            string rtMsrg;
            int rtState;
            try
            {
                bool flag = true;
                entity.RowStatus = (int)RowStatus.Normal;
                entity.Answer = entity.Answer.Replace(",", "");
                if (string.IsNullOrEmpty(entity.Id))
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CreateBy = CurrentUser.CrmUser.UserName;
                    entity.CreateOn = DateTime.Now;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.UpdateBy = CurrentUser.CrmUser.UserName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;

                    _CrmDailyOneProblemBll.Add(entity);
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.UserName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    _CrmDailyOneProblemBll.Update(entity);
                }
                rtMsrg = flag ? "保存成功" : "保存失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new
            {
                RtMsrg = rtMsrg,
                RtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var rtState = 0;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _CrmDailyOneProblemBll.BatchDelete("'" + id + "'") ? 1 : 0;
            }
            return Json(new
            {
                RtMsrg = "删除成功",
                RtState = rtState
            }, JsonRequestBehavior.AllowGet);
        }


    }
}
