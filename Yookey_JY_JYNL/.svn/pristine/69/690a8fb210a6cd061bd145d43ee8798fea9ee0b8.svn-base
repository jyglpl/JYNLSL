using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Evaluation;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Evaluation
{
    public class EvaluationProcController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                     //数据字典
        readonly EvaluationProcBll _evaluationProcBll = new EvaluationProcBll();            //考核项
        readonly EvaluationBasisBll _evaluationBasisBll = new EvaluationBasisBll();         //考核细则

        public ActionResult Index(string parentId, string keywords)
        {
            //行政执法考核模块
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();
            administrationMod.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AdministrationMod"] = new SelectList(administrationMod, "Id", "RsKey", "parentId");

            return View();
        }
        /// <summary>
        /// 获取考核项目信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetEvaluationProcData(string parentId, string keywords, int rows = 30, int page = 1)
        {
            var data = _evaluationProcBll.GetEvaluationProcInfo(parentId, keywords, rows, page);
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 新增考核项目
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEvaluationProc(string khId)
        {
            var model = new EvaluationProcEntity();
            if (string.IsNullOrEmpty(khId))
            {
                model.Id = Guid.NewGuid().ToString();
            }
            else
            {
                model = _evaluationProcBll.Get(khId);
                //获取考核细则列表
                List<EvaluationBasisEntity> evaluationBasisList =
                    _evaluationBasisBll.GetSearchResult(new EvaluationBasisEntity() { EvaluationProcId = khId });
                ViewData["EvaluationBasisList"] = evaluationBasisList;
            }
            //行政执法考核模块
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();
            administrationMod.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AdministrationMod"] = new SelectList(administrationMod, "Id", "RsKey");

            //奖惩
            //var readList = EnumOperate.ConvertEnumToListItems(typeof(IsReward), "0");
            //ViewData["IsRewards"] = readList;

            return View(model);
        }
        /// <summary>
        /// 保存考核细则
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveEvBas(string evaluationDetail, string procId, int isRewards, string id)
        {
            EvaluationBasisEntity basEntity = new EvaluationBasisEntity();
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var ent = new EvaluationBasisBll().Get(id);
                    if (ent != null)
                    {
                        basEntity.Id = id;
                        basEntity.CreateBy = ent.CreateBy;
                        basEntity.CreatorId = ent.CreatorId;
                        basEntity.CreateOn = ent.CreateOn;
                        basEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                        basEntity.UpdateId = CurrentUser.CrmUser.Id;
                    }
                }
                else
                {
                    basEntity.Id = Guid.NewGuid().ToString();
                    basEntity.CreateBy = CurrentUser.CrmUser.UserName;
                    basEntity.CreatorId = CurrentUser.CrmUser.Id;
                    basEntity.CreateOn = DateTime.Now;
                }
                basEntity.UpdateOn = DateTime.Now;
                basEntity.EvaluationDetail = evaluationDetail;
                basEntity.IsRewards = isRewards;
                basEntity.EvaluationProcId = procId;
                basEntity.RowStatus = (int)RowStatus.Normal;
                isOk = new EvaluationBasisBll().SaveBas(basEntity);
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
        /// 保存考核项目
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveEvaluationProc(EvaluationProcEntity entity)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                var user = CurrentUser.CrmUser;
                //考核项目
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.RowStatus = 1;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                EvaluationBasisEntity bas = new EvaluationBasisEntity()
                {
                    UpdateId = user.Id,
                    UpdateBy = user.UserName,
                    UpdateOn = DateTime.Now,
                };
                isOk = _evaluationProcBll.SaveProc(entity, bas);//baocun
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

        [HttpPost]
        public string Delete(string id)
        {
            var user = CurrentUser.CrmUser;
            EvaluationBasisEntity entity = new EvaluationBasisEntity();
            entity.UpdateId = user.Id;
            entity.UpdateBy = user.UserName;
            entity.UpdateOn = DateTime.Now;
            EvaluationProcEntity proc = new EvaluationProcEntity();
            proc.UpdateId = user.Id;
            proc.UpdateBy = user.UserName;
            proc.UpdateOn = DateTime.Now;
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _evaluationProcBll.TransactionDelete(id, proc, entity);
                rtMsrg = flag ? "删除成功" : "删除失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }
    }
}
