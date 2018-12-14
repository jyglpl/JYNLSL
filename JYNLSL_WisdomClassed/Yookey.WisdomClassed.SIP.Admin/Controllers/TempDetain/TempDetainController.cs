using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.TempDetain;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using System.Text;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Business.Case;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.TempDetain
{
    public class TempDetainController : BaseController
    {
        private BaseUserBll _crmUserBll = new BaseUserBll();                            //人员
        private BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();                //部门
        private ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        private TempDetainInfoBll _tempDetainInfoBll = new TempDetainInfoBll();//暂扣基本信息
        private TempDetainGoodsBll _tempDetainGoodsBll = new TempDetainGoodsBll();//暂扣物品
        private TempDetainAttachBll _tempDetainAttachBll = new TempDetainAttachBll();//暂扣附件
        readonly ComNumberBll _comNumberBll = new ComNumberBll();          //编号
        private TempDetainInfoLegislationBll _tempDetainInfoLegislation = new TempDetainInfoLegislationBll();
        private readonly TempDetainInfoProcessBll _tempDetainInfoProcessBll = new TempDetainInfoProcessBll();
        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();        //案件基本信息
        readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll();      //附件材料

        #region 视图

        /// <summary>
        /// 暂扣管理
        /// 创建人：周庆
        /// 创建日期：2015年5月4日
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 暂扣登记、编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Regist(string id)
        {
            var model = new TempDetainInfoEntity();

            if (string.IsNullOrEmpty(id))
            {
                model.Id = Guid.NewGuid().ToString();
                model.TempDateTime = DateTime.Now;
                model.State = -1;
            }
            else
            {
                model = _tempDetainInfoBll.Get(id);

                //获取暂扣物品信息
                List<TempDetainGoodsEntity> withholdArticleList =
                    _tempDetainGoodsBll.GetSearchResult(new TempDetainGoodsEntity() { TempId = id });
                ViewData["WithholdArticleList"] = withholdArticleList;


                var punishLegislations = _tempDetainInfoLegislation.GetSearchResult(new TempDetainInfoLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    TempDetainInfoLegislationEntity tempLegislationEntity = punishLegislations[0];

                    ViewBag.ClassNo = tempLegislationEntity.ClassNo;
                    ViewBag.LegislationId = tempLegislationEntity.LegislationId;
                    ViewBag.LegislationItemId = tempLegislationEntity.LegislationItemId;
                    ViewBag.LegislationGistId = tempLegislationEntity.LegislationGistId;
                }

            }

            // 审核过程
            List<TempDetainInfoProcessEntity> tempDetainInfoProcessList = _tempDetainInfoProcessBll.GetTempDetainInfoProcessList(id);
            ViewData["TempDetainInfoProcessList"] = tempDetainInfoProcessList;

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            //暂扣物品大类
            var articleTypeI = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0039" });
            articleTypeI.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["ArticleTypeI"] = new SelectList(articleTypeI, "Id", "RsKey", "");

            //暂扣物品单位
            var articleUnit = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0040" });
            articleUnit.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["ArticleUnit"] = new SelectList(articleUnit, "Id", "RsKey", "");

            //物品类型大类
            var tempType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0047" });
            tempType.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["TempTypes"] = new SelectList(tempType, "Id", "RsKey");

            var articleTypeList = _comResourceBll.GetResourceLikeId("0039");
            ViewBag.ArticleTypeList = articleTypeList;

            //ViewBag.ArticleTypeIS = articleTypeI;
            ViewBag.ArticleUnitS = articleUnit;

            #endregion

            return View(model);
        }

        /// <summary>
        /// 暂扣登记、编辑详细
        /// </summary>
        /// <returns></returns>
        public ActionResult TempDetainDetail(string id)
        {
            var model = new TempDetainInfoEntity();

            if (string.IsNullOrEmpty(id))
            {
                model.Id = Guid.NewGuid().ToString();
                model.TempDateTime = DateTime.Now;
                model.State = -1;
            }
            else
            {
                model = _tempDetainInfoBll.Get(id);

                //获取暂扣物品信息
                List<TempDetainGoodsEntity> withholdArticleList =
                    _tempDetainGoodsBll.GetSearchResult(new TempDetainGoodsEntity() { TempId = id });
                ViewData["WithholdArticleList"] = withholdArticleList;


                var punishLegislations = _tempDetainInfoLegislation.GetSearchResult(new TempDetainInfoLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    TempDetainInfoLegislationEntity tempLegislationEntity = punishLegislations[0];

                    ViewBag.ClassNo = tempLegislationEntity.ClassNo;
                    ViewBag.LegislationId = tempLegislationEntity.LegislationId;
                    ViewBag.LegislationItemId = tempLegislationEntity.LegislationItemId;
                    ViewBag.LegislationGistId = tempLegislationEntity.LegislationGistId;
                }

            }

            // 审核过程
            List<TempDetainInfoProcessEntity> tempDetainInfoProcessList = _tempDetainInfoProcessBll.GetTempDetainInfoProcessList(id);
            ViewData["TempDetainInfoProcessList"] = tempDetainInfoProcessList;

            #region 默认值

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            //暂扣物品大类
            var articleTypeI = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0039" });
            articleTypeI.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["ArticleTypeI"] = new SelectList(articleTypeI, "Id", "RsKey", "");

            //暂扣物品单位
            var articleUnit = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0040" });
            articleUnit.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["ArticleUnit"] = new SelectList(articleUnit, "Id", "RsKey", "");

            //物品类型大类
            var tempType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0047" });
            tempType.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["TempTypes"] = new SelectList(tempType, "Id", "RsKey");

            var articleTypeList = _comResourceBll.GetResourceLikeId("0039");
            ViewBag.ArticleTypeList = articleTypeList;

            //ViewBag.ArticleTypeIS = articleTypeI;
            ViewBag.ArticleUnitS = articleUnit;

            #endregion

            return View(model);
        }

        #endregion

        #region Ajax获取数据

        /// <summary>
        /// 获取暂扣数据
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetTempDetainData(string companyId, string deptId, string startTime, string endTime, string keywords, int rows = 30, int page = 1)
        {
            if (string.IsNullOrEmpty(companyId) && string.IsNullOrEmpty(deptId))
            {
                return "";
            }

            if (companyId == "all")
            {
                companyId = "";
            }

            if (deptId == "all")
            {
                deptId = "";
            }

            var data = _tempDetainInfoBll.GetAllTempDetainInfo(companyId, deptId, startTime, endTime, keywords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 获取暂扣附件详情
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetTempDetainAttachDetail(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return "[]";
            var data = _tempDetainAttachBll.Get(Id);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        #endregion

        #region Ajax 数据请求

        /// <summary>
        /// 根据物品大类，请求小类
        /// </summary>
        /// <param name="typeId">大类ID</param>
        /// <param name="defaultSelId">默认选中值</param>
        /// <returns></returns>
        public string AjaxLoadArticleTypeIi(string typeId, string defaultSelId)
        {
            //暂扣物品大类
            var articleTypeIi = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = typeId });
            var sbItemActs = new StringBuilder();
            sbItemActs.AppendFormat("<option value=\"\">==请选择==</option>");
            if (articleTypeIi.Count > 0)
            {
                foreach (var t in articleTypeIi.Where(t => !string.IsNullOrEmpty(t.RsKey)))
                {
                    var selectstr = "";
                    if (t.Id.Equals(defaultSelId))
                    {
                        selectstr = "selected=\"selected\"";
                    }
                    sbItemActs.AppendFormat("<option " + selectstr + " value=\"" + t.Id + "\">" + t.RsKey + "</option>");
                }
            }
            return sbItemActs.ToString();
        }

        #endregion

        #region Ajax提交数据

        /// <summary>
        /// 保存暂扣
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveTempDetain(TempDetainInfoEntity entity)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                var user = CurrentUser.CrmUser;
                //判断关联的一般案件
                InfPunishCaseinfoEntity caseinfoModel = null;
                if (!string.IsNullOrEmpty(entity.NoticeNo))
                {
                    caseinfoModel = _infPunishCaseinfoBll.GetCaseInfoByNoticeNo(entity.NoticeNo);
                    if (caseinfoModel == null)
                    {
                        return Json(new { rtState = -1, rtMsrg = "通知书编号不存在！" }, JsonRequestBehavior.AllowGet);
                    }
                }


                #region 暂扣物品

                //物品大类
                List<string> articleTypeIList = Request["ArticleTypeI"] != null ? Request["ArticleTypeI"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //物品小类
                List<string> articleTypeIiList = Request["ArticleTypeII"] != null ? Request["ArticleTypeII"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 物品名称
                List<string> articleNameList = Request["ArticleName"] != null ? Request["ArticleName"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 型号
                List<string> specificationTypeList = Request["SpecificationType"] != null ? Request["SpecificationType"].Split(",".ToCharArray()).ToList() : new List<string>();
                // 物品数量
                List<string> articleCountList = Request["ArticleCount"] != null ? Request["ArticleCount"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 物品单位
                List<string> articleUnitList = Request["ArticleUnit"] != null ? Request["ArticleUnit"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();

                List<TempDetainGoodsEntity> withholdArticleList = new List<TempDetainGoodsEntity>();

                int indexStr = 0;
                foreach (string item in articleNameList)
                {
                    var model = new TempDetainGoodsEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        TempId = entity.Id,
                        ClassI = articleTypeIList.Count > indexStr ? articleTypeIList[indexStr] : "",
                        ClassII = articleTypeIiList.Count > indexStr ? articleTypeIiList[indexStr] : "",
                        GoodsName = item,
                        GoodsCount = int.Parse(articleCountList[indexStr]),
                        GoodsUnit = articleUnitList[indexStr],
                        Specification = specificationTypeList[indexStr],
                        GoodsUnitName = "",
                        State = 0,
                        RowStatus = (int)RowStatus.Normal,
                        CreateBy = CurrentUser.CrmUser.UserName,
                        CreatorId = CurrentUser.CrmUser.Id,
                        CreateOn = DateTime.Now,
                        UpdateBy = CurrentUser.CrmUser.UserName,
                        UpdateId = CurrentUser.CrmUser.Id,
                        UpdateOn = DateTime.Now,
                    };
                    indexStr++;
                    withholdArticleList.Add(model);
                }

                #endregion

                //法律法规
                var legislationId = Request["LegislationId"];
                var legislationItemId = Request["LegislationItemId"];
                var legislationGistId = Request["LegislationGistId"];

                if (string.IsNullOrEmpty(entity.TempNo))
                {
                    var tempNo = "";
                    if (entity.TempType.Equals("00470001"))
                    {
                        tempNo = _comNumberBll.GetNumber(AppConst.NumTempZq, "", null);
                    }
                    else if (entity.TempType.Equals("00470002"))
                    {
                        tempNo = _comNumberBll.GetNumber(AppConst.NumTempXx, "", null);
                    }
                    entity.TempNo = tempNo;
                }

                entity.State = entity.State == -1 ? 0 : entity.State;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.RowStatus = 1;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                // 关联案件
                if (caseinfoModel != null)
                {
                    entity.CaseId = caseinfoModel.Id;
                    caseinfoModel.TempId = entity.Id;
                    caseinfoModel.TempNo = entity.TempNo;
                }


                isOk = new TempDetainInfoBll().TransactionSave(entity, withholdArticleList, legislationId, legislationItemId,
                                                        legislationGistId, caseinfoModel);
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
        /// 保存暂扣附件信息
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        public JsonResult SaveTempDetainAttachDetail(string Id, string Remark)
        {

            int StatusCode = 0;
            if (!string.IsNullOrEmpty(Id))
            {
                var file = _tempDetainAttachBll.Get(Id);
                if (file != null)
                {
                    file.FileRemark = Remark;
                    StatusCode = _tempDetainAttachBll.Update(file); ;
                }
            }
            return Json(new { rtState = StatusCode }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 物品腐烂无价处理
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DecayTempDetainGoods(string Id)
        {
            int StatusCode = 0;
            if (!string.IsNullOrEmpty(Id))
            {
                var user = CurrentUser.CrmUser;
                StatusCode = _tempDetainGoodsBll.DecayTempDetainGoods(Id, user.Id, user.UserName);
            }
            return Json(new { rtState = StatusCode }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除暂扣
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位主键编号</param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteTempDetain(string id)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _tempDetainInfoBll.BatchDelete(id);
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

        #endregion

        #region 审核意见
        /// <summary>
        /// 处理意见
        /// </summary>
        /// <returns></returns>
        public ActionResult HandleIdea(string id, string state)
        {
            ViewBag.Id = id;
            ViewBag.State = state;

            return View();
        }

        /// <summary>
        /// 暂扣案件状态
        /// </summary>
        /// <param name="id">案件Id</param>
        /// <param name="state">状态</param>
        /// <param name="stateName">状态名称</param>
        /// <param name="withholdIdea">审核意思</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult HandleIdeaState(string id, int state, string withholdIdea, string warehouseCod, string transferDept)
        {
            TempDetainInfoEntity entity = null;
            TempDetainInfoProcessEntity caseApprovalProcess = null;
            BaseUserEntity crmUser = CurrentUser.CrmUser;
            bool isTrue = false;
            string rtMsrg;
            int rtState;
            DateTime date = DateTime.Now;

            if (!string.IsNullOrEmpty(id))
            {
                entity = _tempDetainInfoBll.Get(id);
                if (entity != null)
                {
                    if (entity.State == state)
                    {
                        rtMsrg = "暂扣物品" + EnumOperate.GetEnumDesc((TempDetainSate)state) + "！";
                        rtState = (int)OperationState.Error;
                        return Json(new { rtState = rtState, rtMsrg = rtMsrg }, JsonRequestBehavior.AllowGet);
                    }

                    //日志表withholdflag
                    caseApprovalProcess = new TempDetainInfoProcessEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        After = EnumOperate.GetEnumDesc((TempDetainSate)state),
                        Before = EnumOperate.GetEnumDesc((TempDetainSate)entity.State),
                        TempDetainInfoId = entity.Id,
                        CaseTypeName = "CaseWithhold",
                        Idea = withholdIdea,
                        UserId = CurrentUser.CrmUser.Id,
                        UserName = CurrentUser.CrmUser.UserName,

                        RowStatus = (int)RowStatus.Normal,
                        CreateBy = crmUser.UserName,
                        CreatorId = crmUser.Id,
                        CreateOn = date,
                        UpdateBy = crmUser.UserName,
                        UpdateId = crmUser.Id,
                        UpdateOn = date,

                    };

                    //修改暂扣案件状态
                    entity.State = state;  //待入库-0，已入库-1，教育处理-2，报废处理-3,移交其它部门-4,转入处罚-5, 处罚处理-6，已发还-7    腐烂、无价-88
                    if (state == (int)TempDetainSate.InStorage)
                    {
                        entity.WarehouseCode = warehouseCod;
                    }
                    entity.UpdateId = crmUser.Id;
                    entity.UpdateBy = crmUser.UserName;
                    entity.UpdateOn = date;

                    List<TempDetainGoodsEntity> tempDetainGoodList = _tempDetainGoodsBll.GetSearchResult(new TempDetainGoodsEntity() { TempId = id });
                    foreach (var item in tempDetainGoodList)
                    {
                        if (item.State != (int)TempDetainSate.DecayPriceless)
                        {
                            item.State = state;
                        }
                        // 移交
                        if (item.State == (int)TempDetainSate.TransferDept)
                        {
                            item.TransferDeptName = transferDept;
                        }
                    }

                    isTrue = _tempDetainInfoBll.TransactionUpdateTempDetainInfoSaveProcess(entity, tempDetainGoodList, caseApprovalProcess);
                }
            }

            rtMsrg = isTrue ? EnumOperate.GetEnumDesc((TempDetainSate)state) + "成功" : EnumOperate.GetEnumDesc((TempDetainSate)state) + "失败";
            rtState = isTrue ? (int)OperationState.Success : (int)OperationState.Failure;
            return Json(new { rtState = rtState, rtMsrg = rtMsrg }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  物品腐烂无价处理

        /// <summary>
        /// 腐烂无价处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="withholdIdea"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult HandlePricelessProcessing(string id)
        {
            TempDetainGoodsEntity entity = null;
            BaseUserEntity crmUser = CurrentUser.CrmUser;
            int isTrue = 0;
            string rtMsrg;
            int rtState;
            DateTime date = DateTime.Now;

            if (!string.IsNullOrEmpty(id))
            {
                entity = _tempDetainGoodsBll.Get(id);
                if (entity != null)
                {
                    entity.State = (int)TempDetainSate.DecayPriceless;
                    entity.UpdateId = crmUser.Id;
                    entity.UpdateBy = crmUser.UserName;
                    entity.UpdateOn = date;

                    isTrue = _tempDetainGoodsBll.Update(entity);
                }
            }

            rtMsrg = isTrue == 1 ? "腐烂无价处理成功" : "腐烂无价处理失败";
            rtState = isTrue == 1 ? (int)OperationState.Success : (int)OperationState.Failure;
            return Json(new { rtState = rtState, rtMsrg = rtMsrg }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 附件材料相关


        /// <summary>
        /// 证据材料
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="evtache">证据环节</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult FilesTab(string resourceId, string evtache, string isupload, string isdeleted)
        {
            IList<ComResourceEntity> evidences = new List<ComResourceEntity>();
            if (!string.IsNullOrEmpty(evtache))
            {
                if (evtache.Equals("tempdetain"))    //暂扣物品
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0032" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
            }

            //查询材料对应的材料
            if (!string.IsNullOrEmpty(resourceId) && evidences.Any())
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _tempDetainAttachBll.GetSearchResult(new TempDetainAttachEntity() { ResourceId = resourceId }, filetypelist);
                ViewData["Files"] = files;
            }


            ViewBag.Evtache = evtache;         //证据类型
            ViewBag.ResourceId = resourceId;   //外键编号
            ViewBag.Isupload = isupload;       //是否可上传
            ViewBag.IsDeleted = isdeleted;     //是否可删除

            return View("FilesTab");
        }

        /// <summary>
        /// 附件上传保存附件信息
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="fileAddress">附件保存地址</param>
        /// <param name="fileType">附件类型</param>
        /// <param name="fileTypeName">附件类型名称</param>
        /// <param name="remark">附件描述</param>
        /// <param name="fileName">上传时名称</param>
        /// <param name="fileReName">上传后重命名名称</param>
        /// <returns></returns>
        public string UpSaveImage(string resourceId, string fileAddress, string fileType, string fileTypeName, string remark, string fileName, string fileReName)
        {
            try
            {
                var user = CurrentUser.CrmUser;

                var result = Guid.NewGuid().ToString();
                var entity = new TempDetainAttachEntity()
                {
                    Id = result,
                    ResourceId = resourceId,
                    FileType = fileType,
                    FileTypeName = fileTypeName,
                    FileAddress = fileAddress,
                    FileName = fileName,
                    FileReName = fileReName,
                    FileRemark = remark,
                    RowStatus = 1,
                    IsCompleted = 1,
                    CreatorId = user.Id,
                    CreateBy = user.UserName,
                    CreateOn = DateTime.Now,
                    UpdateId = user.Id,
                    UpdateBy = user.UserName,
                    UpdateOn = DateTime.Now
                };
                _tempDetainAttachBll.Add(entity);
                return result;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// 附件放大预览列表
        /// <param name="resourceId">外键编号</param>
        /// <param name="defaultPicId">默认显示图片ID</param>
        /// </summary>
        /// <returns></returns>
        public ActionResult FilesView(string resourceId, string defaultPicId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = _tempDetainAttachBll.GetSearchResult(new TempDetainAttachEntity() { ResourceId = resourceId });

                ViewData["Files"] = files;
            }
            ViewBag.DefaultPicId = defaultPicId;

            return View();
        }

        /// <summary>
        /// 请求附件详情
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult FileDetails(string fileId)
        {
            var entity = new TempDetainAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = _tempDetainAttachBll.Get(fileId);
            }
            var result = new StatusModel<object>
            {
                rtState = 1,
                rtData = null,
                rtObj = entity,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <param name="remark">附件备注</param>
        /// <returns></returns>
        public JsonResult SaveFileDetails(string fileId, string remark)
        {
            var isOk = 0;
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = _tempDetainAttachBll.Get(fileId);
                entity.FileRemark = remark;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = _tempDetainAttachBll.Update(entity);  //更新
            }

            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult DeleteFile(string fileId)
        {
            var isOk = 0;
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = _tempDetainAttachBll.Get(fileId);
                entity.RowStatus = 0;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                isOk = _tempDetainAttachBll.Update(entity);
            }
            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 附件缩略图预览,用于案件首页右侧
        /// </summary>
        /// <returns></returns>
        public ActionResult FileBreviaryView(string resourceId, string evtache)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = _tempDetainAttachBll.GetSearchResult(new TempDetainAttachEntity() { ResourceId = resourceId });
                ViewData["Files"] = files;
            }
            return View("FileBreviaryView");
        }

        #endregion

        #region 转入处罚

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult ToPenaltyCase(string id)
        {

            try
            {
                TempDetainInfoEntity entity = _tempDetainInfoBll.Get(id);

                if (entity == null)
                {
                    return Json(new { rtState = 0, rtMsrg = "暂扣信息不存在！" }, JsonRequestBehavior.AllowGet);
                }

                BaseUserEntity crmUser = CurrentUser.CrmUser;

                // 一般案件
                InfPunishCaseinfoEntity caseinfoEntity = new InfPunishCaseinfoEntity()
                {
                    CarNo = "",
                    CarType = "",
                    CaseAddress = entity.TempAddress,
                    CaseDate = entity.TempDateTime,
                    CaseFact = "",
                    CaseHurtInfo = "",
                    CaseInfoNo = "",
                    CompanyId = entity.CompanyId,
                    CompanyName = entity.CompanyName,
                    DataSource = 0,
                    DeptId = entity.DepartmentId,
                    DeptName = entity.DepartmentName,
                    FirstTrialPersonelIdFirst = "",
                    FirstTrialPersonelIdSecond = "",
                    FirstTrialPersonelNameFirst = "",
                    FirstTrialPersonelNameSecond = "",
                    ReSource = "00100001",
                    ReSourceName = "巡查",
                    RePersonelIdFist = entity.RePersonelIdFist,
                    RePersonelIdSecond = entity.RePersonelIdSecond,
                    RePersonelNameFist = entity.RePersonelNameFist,
                    RePersonelNameSecond = entity.RePersonelNameSecond,
                    TargetAddress = entity.TargetAddress,
                    TargetAge = entity.TargetAge,
                    TargetDuty = entity.TargetDuty,
                    TargetEmail = entity.TargetEmail,
                    TargetGender = entity.TargetGender,
                    TargetMobile = entity.TargetMobile,
                    TargetName = entity.TargetName,
                    TargetPaperNum = entity.TargetPaperNum,
                    TargetPaperType = entity.TargetPaperType,
                    TargetPhone = entity.TargetPhone,
                    TargetType = entity.TargetType,
                    TargetUnit = entity.TargetUnit,
                    TargetZipCode = entity.TargetZipCode,
                    Id = Guid.NewGuid().ToString(),
                    InternalNo = "",
                    ReProof = "00150001",
                    GDDate = DateTime.Parse("1900-01-01"),
                    HaProof = "",
                    Lat = "",
                    Lng = "",
                    NoticeNo = "",
                    RoadName = entity.RoadName,
                    RoadNo = entity.RoadNo,
                    RowStatus = 1,
                    State = 0,
                    TempId = entity.Id,
                    TempNo = entity.TempNo,


                    CreatorId = crmUser.Id,
                    CreateBy = crmUser.UserName,
                    CreateOn = DateTime.Now,

                    UpdateId = crmUser.Id,
                    UpdateBy = crmUser.UserName,
                    UpdateOn = DateTime.Now,



                };
                // 法律法规
                List<TempDetainInfoLegislationEntity> tempDetainInfoLegislationList = _tempDetainInfoLegislation.GetSearchResult(new TempDetainInfoLegislationEntity() { CaseInfoId = id });
                var legislationId = "";
                var legislationItemId = "";
                var legislationGistId = "";
                if (tempDetainInfoLegislationList.Any())
                {
                    legislationId = tempDetainInfoLegislationList.FirstOrDefault().LegislationId;
                    legislationItemId = tempDetainInfoLegislationList.FirstOrDefault().LegislationItemId;
                    legislationGistId = tempDetainInfoLegislationList.FirstOrDefault().LegislationGistId;
                }
                // 照片
                List<TempDetainAttachEntity> tempDetainAttachList = _tempDetainAttachBll.GetTempDetainAttachsByTempId(id);
                foreach (var item in tempDetainAttachList)
                {
                    var result = Guid.NewGuid().ToString();
                    var infPunishAttachEntity = new InfPunishAttachEntity()
                    {
                        Id = result,
                        ResourceId = caseinfoEntity.Id,
                        FileType = "00150001",
                        FileTypeName = "书证",
                        FileAddress = item.FileAddress,
                        FileName = item.FileName,
                        FileReName = item.FileReName,
                        FileRemark = item.FileRemark,
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = crmUser.Id,
                        CreateBy = crmUser.UserName,
                        CreateOn = DateTime.Now,

                        UpdateId = crmUser.Id,
                        UpdateBy = crmUser.UserName,
                        UpdateOn = DateTime.Now,
                    };
                    _infPunishAttachBll.Add(infPunishAttachEntity);
                }

                // 保存案件信息
                _infPunishCaseinfoBll.SaveCase(caseinfoEntity, legislationId, legislationItemId, legislationGistId);

                #region  转入处罚

                //日志表withholdflag
                TempDetainInfoProcessEntity caseApprovalProcess = new TempDetainInfoProcessEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    After = EnumOperate.GetEnumDesc(TempDetainSate.ToPenaltyCase),
                    Before = EnumOperate.GetEnumDesc((TempDetainSate)entity.State),
                    TempDetainInfoId = entity.Id,
                    CaseTypeName = "CaseWithhold",
                    Idea = "",
                    UserId = CurrentUser.CrmUser.Id,
                    UserName = CurrentUser.CrmUser.UserName,

                    RowStatus = (int)RowStatus.Normal,
                    CreateBy = crmUser.UserName,
                    CreatorId = crmUser.Id,
                    CreateOn = DateTime.Now,
                    UpdateBy = crmUser.UserName,
                    UpdateId = crmUser.Id,
                    UpdateOn = DateTime.Now,

                };

                //修改暂扣案件状态
                entity.State = (int)TempDetainSate.ToPenaltyCase;

                entity.UpdateId = crmUser.Id;
                entity.UpdateBy = crmUser.UserName;
                entity.UpdateOn = DateTime.Now;
                entity.CaseId = caseinfoEntity.Id;

                List<TempDetainGoodsEntity> tempDetainGoodList = _tempDetainGoodsBll.GetSearchResult(new TempDetainGoodsEntity() { TempId = id });
                foreach (var item in tempDetainGoodList)
                {
                    if (item.State != (int)TempDetainSate.DecayPriceless)
                    {
                        item.State = (int)TempDetainSate.ToPenaltyCase;
                    }
                }

                _tempDetainInfoBll.TransactionUpdateTempDetainInfoSaveProcess(entity, tempDetainGoodList, caseApprovalProcess);
                #endregion

                return Json(new { rtState = 1, rtMsrg = "处理成功！", caseinfoId = caseinfoEntity.Id }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rtState = 0, rtMsrg = "错误：" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        /// <summary>
        /// 暂扣统计
        /// </summary>
        /// <returns></returns>
        public ActionResult StatisticsIndex(string lastYear,string lastMonth)
        {
            var companyList = new CrmCompanyBll().GetAllCompany();
            List<CrmCompanyEntity> comList = companyList.Where(t => t.ParentId != "0").ToList();
            List<ComResourceEntity> typeList = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0039" }).ToList();

            string checkTeam = string.Empty;
            string satisticsCount = string.Empty;
            if (string.IsNullOrEmpty(lastYear))
            {
                lastYear =DateTime.Now.Year.ToString();
            }
            if (string.IsNullOrEmpty(lastMonth))
            {
                lastMonth = DateTime.Now.Month.ToString();
            }
            lastMonth = Convert.ToInt32(lastMonth) < 10 ? "0" + lastMonth : lastMonth;
            string startTime = lastYear + "-" + lastMonth + "-" + "01 00:00:00.000";
            string endTime = Convert.ToDateTime(startTime).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
            var tempInfo = new TempDetainInfoBll().GetStatistics(startTime, endTime);
            var tempGoods = new TempDetainGoodsBll().GetGoodsStatistics(startTime, endTime);
            foreach (var item in comList)
            {
                checkTeam += item.FullName + ",";
                var list = tempInfo.Where(t => t.CompanyId == item.Id).ToList();
                satisticsCount += list.Count + ",";
            }
            ViewBag.TeamNames = checkTeam.Trim(',');
            ViewBag.TempCount = satisticsCount.Trim(',');

            string checkType = string.Empty;
            string typeCount = string.Empty;
            foreach (var item in typeList)
            {
                checkType += item.RsKey + ",";
                var list = tempGoods.Where(t => t.ClassI == item.Id).ToList();
                typeCount += list.Count + ",";
            }
            ViewBag.GoodsType = checkType.Trim(',');
            ViewBag.GoodsCount = typeCount.Trim(',');
            //var tempByCompany = new TempDetainInfoBll().GetStatistics(startTime, endTime);
           
            BindDate(Convert.ToInt32(lastYear), Convert.ToInt32(lastMonth));
            return View();
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
            monthList.Add(0);
            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }
    }
}
