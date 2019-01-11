using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Business.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    /// <summary>
    /// 行政处罚->权力库
    /// </summary>
    public class PenaltyLawController : BaseController
    {

        private readonly LegislationItemBll _legislationItem = new LegislationItemBll();
        private readonly LegislationGistBll _legislationGistBll = new LegislationGistBll();
        private readonly LegislationRuleBll _legislationRule = new LegislationRuleBll();
        private readonly LegislationBll _legislationBll = new LegislationBll();

        //
        // GET: /PenaltyLaw/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /PenaltyLaw/
        public ActionResult New(string id)
        {
            var comPuni = new LegislationEntity();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                comPuni = new LegislationBll().Get(id);
                if (comPuni == null)
                {
                    comPuni = new LegislationEntity();
                }
            }
            else
            {
                comPuni.Id = Guid.NewGuid().ToString();
            }
            var result = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0008" });
            ViewData["ItemType"] = new SelectList(result, "Id", "RsKey", string.IsNullOrEmpty(comPuni.ItemType) ? "1" : comPuni.ItemType);
            var result2 = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0009" });
            ViewData["ClassNo"] = new SelectList(result2, "Id", "RsKey", string.IsNullOrEmpty(comPuni.ClassNo) ? "1" : comPuni.ClassNo);
            ViewBag.LegislationItem = new LegislationItemEntity();
            return View(comPuni);
        }

        /// <summary>
        /// 处罚依据
        /// </summary>
        /// <returns></returns>
        public ActionResult Gist(string gistId)
        {
            // ViewData["LegislationItemId"] = id;
            LegislationGistEntity legislationGistEntity = null;
            var result = _legislationGistBll.Query(QueryCondition.Instance.AddEqual(LegislationGistEntity.Parm_LegislationGist_LegislationItemId, gistId));
            if (result.Count > 0)
            {
                legislationGistEntity = result[0];
            }
            else
            {
                legislationGistEntity = new LegislationGistEntity();
                legislationGistEntity.LegislationItemId = gistId;
            }
            return View(legislationGistEntity);

        }

        /// <summary>
        /// 请求权力Json数据
        /// 添加人：周 鹏
        /// 添加时间：2014-12-16
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="itemno">案由编号</param>
        /// <param name="itemname">案由名称</param>
        /// <param name="rows">每页条数</param>
        /// <param name="page">当前页索引</param>
        /// <returns></returns>
        public JsonResult QueryListJson(string itemno, string itemact, int rows, int page, string itemType = "-999")
        {
            var data = _legislationBll.GetSearchResult(new LegislationEntity() { ItemNo = itemno, ItemAct = itemact, ItemType = itemType }, rows, page);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 处罚依据查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult QueryListJsonRule(string id)
        {
            var data = _legislationRule.QueryToPage(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 案由查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult QueryListJsonAnyou(string id)
        {
            var result = _legislationItem.QueryToPage(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 法律条例Gird显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult QueryListJsonGist(string id)
        {
            var result = _legislationGistBll.QueryToPage(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Add(LegislationEntity punish)
        {
            var rtState = 0;
            try
            {
                if (true)//if (ModelState.IsValid)
                {
                    punish.RowStatus = 1;
                    punish.CreateBy = punish.Id.Equals("") ? CurrentUser.CrmUser.UserName : punish.CreateBy;
                    punish.CreateOn = punish.Id.Equals("") ? DateTime.Now : punish.CreateOn;
                    punish.CreatorId = punish.Id.Equals("") ? CurrentUser.CrmUser.Id : punish.CreatorId;
                    punish.UpdateBy = CurrentUser.CrmUser.UserName;
                    punish.UpdateId = CurrentUser.CrmUser.Id;
                    punish.UpdateOn = DateTime.Now;
                    if (_legislationBll.IsAdd(punish))
                    {
                        _legislationBll.Add(punish);
                    }
                    else
                    {
                        _legislationBll.Update(punish);
                    }
                    rtState = 0;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string Id)
        {
            _legislationGistBll.Delete(Id);
            _legislationItem.Delete(Id);
            _legislationRule.Delete(Id);
            _legislationBll.Delete(Id);
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "",
                rtState = 1
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除案由数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DeleteAnyou(string id)
        {
            int result = _legislationItem.DeleteAnyou(id) ? 1 : 0;
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "",
                rtState = result
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除法律处罚数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteGist(string id)
        {
            int result = _legislationGistBll.DeleteGist(id) ? 1 : 0;
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "",
                rtState = result
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除处罚依据数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DeleteRule(string Id)
        {
            int result = _legislationRule.DeleteRule(Id) ? 1 : 0;
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "",
                rtState = result
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加案由信息
        /// </summary>
        /// <param name="LegislationId"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public JsonResult AddAnyou(string LegislationId, string itemName, string id)
        {
            var rtState = 0;
            try
            {
                if (true)//if (ModelState.IsValid)
                {

                    LegislationItemEntity legislationItem = new LegislationItemEntity();
                    legislationItem.RowStatus = 1;
                    legislationItem.CreateBy = CurrentUser.CrmUser.UserName;
                    legislationItem.CreateOn = DateTime.Now;
                    legislationItem.CreatorId = CurrentUser.CrmUser.Id;
                    legislationItem.UpdateBy = CurrentUser.CrmUser.UserName;
                    legislationItem.UpdateId = CurrentUser.CrmUser.Id;
                    legislationItem.UpdateOn = DateTime.Now;
                    legislationItem.LegislationId = LegislationId;
                    legislationItem.ItemName = itemName;
                    if (id.Equals("") || id.Equals("0"))
                    {
                        legislationItem.Id = Guid.NewGuid().ToString();
                        _legislationItem.Add(legislationItem);
                    }
                    else
                    {
                        legislationItem.Id = id;
                        _legislationItem.Update(legislationItem);
                    }
                    rtState = 0;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 添加法律法规
        /// </summary>
        /// <param name="legislationGist"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddGist(LegislationGistEntity legislationGist)
        {
            var rtState = 0;
            try
            {
                if (true)//if (ModelState.IsValid)
                {
                    legislationGist.RowStatus = 1;
                    legislationGist.CreateBy = legislationGist.Id.Equals("") ? CurrentUser.CrmUser.UserName : legislationGist.CreateBy;
                    legislationGist.CreateOn = legislationGist.Id.Equals("") ? DateTime.Now : legislationGist.CreateOn;
                    legislationGist.CreatorId = legislationGist.Id.Equals("") ? CurrentUser.CrmUser.Id : legislationGist.CreatorId;
                    legislationGist.UpdateBy = CurrentUser.CrmUser.UserName;
                    legislationGist.UpdateId = CurrentUser.CrmUser.Id;
                    legislationGist.UpdateOn = DateTime.Now;
                    if (legislationGist.Id.Equals("") || legislationGist.Id.Equals("0"))
                    {
                        legislationGist.Id = Guid.NewGuid().ToString();
                        _legislationGistBll.Add(legislationGist);
                    }
                    else
                    {
                        _legislationGistBll.Update(legislationGist);
                    }
                    rtState = 0;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddRule(LegislationRuleEntity punishRule)
        {
            var rtState = 0;
            try
            {
                if (true)//if (ModelState.IsValid)
                {

                    punishRule.CreateBy = punishRule.Id.Equals("") ? CurrentUser.CrmUser.UserName : punishRule.CreateBy;
                    punishRule.CreateOn = punishRule.Id.Equals("") ? DateTime.Now : punishRule.CreateOn;
                    punishRule.CreatorId = punishRule.Id.Equals("") ? CurrentUser.CrmUser.Id : punishRule.CreatorId;
                    punishRule.UpdateBy = CurrentUser.CrmUser.UserName;
                    punishRule.UpdateId = CurrentUser.CrmUser.Id;
                    punishRule.UpdateOn = DateTime.Now;
                    if (punishRule.Id.Equals("") || punishRule.Id.Equals("0"))
                    {
                        punishRule.RowStatus = 1;
                        punishRule.Id = Guid.NewGuid().ToString();
                        _legislationRule.Add(punishRule);
                    }
                    else
                    {
                        _legislationRule.Update(punishRule);
                    }
                    rtState = 0;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 绑定下拉菜单
        /// </summary>
        /// <param name="ColName"></param>
        /// <returns></returns>
        public JsonResult ComboxValue(string ColName, string param = "")
        {

            switch (ColName)
            {
                //所属类型（大类）
                case "ItemType":
                    var ItemType = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0009" });
                    var ItemTypeList = new SelectList(ItemType, "Id", "RsKey", 1);
                    return Json(ItemTypeList, JsonRequestBehavior.AllowGet);
                //所属类型（小类）
                case "ItemTypeSmall":
                    //var ItemTypeSmall = new PunishitemBll().Query(QueryCondition.Instance.AddEqual(PunishitemEntity.Parm_PUNISHITEM_ClassNo, param));
                    //var ItemTypeSmallList = new SelectList(ItemTypeSmall, "ItemNo", "ItemName", 1);
                    //return Json(ItemTypeSmallList, JsonRequestBehavior.AllowGet);

                    return null;
                //计量单位
                case "Measurement":
                    var Measurement = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0018" });
                    var MeasurementList = new SelectList(Measurement, "Id", "RsKey", 1);
                    return Json(MeasurementList, JsonRequestBehavior.AllowGet);
                //处罚种类
                case "PunishType":
                    var PunishType = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0017" });
                    var PunishTypeList = new SelectList(PunishType, "Id", "RsKey", 1);
                    return Json(PunishTypeList, JsonRequestBehavior.AllowGet);
                //部门数据
                case "Dept":
                    //var Dept = new CrmDeptBll().GetAllDepts(new Model.Crm.CrmDeptEntity { DeptType = "00110002" }).ToList();
                    //var DeptList = new SelectList(Dept, "Id", "DeptName", 1);
                    //return Json(DeptList, JsonRequestBehavior.AllowGet);
                    return null;
                //违停状态数据
                case "Isaudit":
                    var Isaudit = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0027" });
                    var IsauditList = new SelectList(Isaudit, "RsValue", "RsKey", 1);
                    return Json(IsauditList, JsonRequestBehavior.AllowGet);
                //获取中队数据      
                case "Squadron":
                    //var Squadron = new CrmDeptBll().GetAllDepts(new Model.Crm.CrmDeptEntity() { DeptType = "00110002" });
                    //var SquadronList = new SelectList(Squadron, "Id", "DeptName", 1);
                    //return Json(SquadronList, JsonRequestBehavior.AllowGet);
                    return null;
                //案件状态（违停）
                case "WTState":
                    var WTState = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0021" });
                    var WTStateList = new SelectList(WTState, "RsValue", "RsKey", 1);
                    return Json(WTStateList, JsonRequestBehavior.AllowGet);
                case "ZjType":
                    var ZjType = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0013" }).OrderBy(t => t.RsKey).OrderBy(t => t.OrderNo);
                    var ZjTypeList = new SelectList(ZjType, "Id", "RsKey", 1);
                    return Json(ZjTypeList, JsonRequestBehavior.AllowGet);
                case "Sex":
                    var Sex = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0014" }).OrderBy(t => t.RsKey);
                    var SexList = new SelectList(Sex, "Id", "RsKey", 1);
                    return Json(SexList, JsonRequestBehavior.AllowGet);
                case "Job":
                    var Job = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0022" }).OrderBy(t => t.RsKey);
                    var JobList = new SelectList(Job, "Id", "RsKey", 1);
                    return Json(JobList, JsonRequestBehavior.AllowGet);
                //许可类型
                case "Xuke":
                    var Xuke = new ComResourceBll().GetSearchResult(new Model.Com.ComResourceEntity { ParentId = "0033" }).OrderBy(t => t.RsKey);
                    var XukeList = new SelectList(Xuke, "Id", "RsKey", 1);
                    return Json(XukeList, JsonRequestBehavior.AllowGet);
                default:
                    return Json("", JsonRequestBehavior.AllowGet);

            }
        }
    }
}
