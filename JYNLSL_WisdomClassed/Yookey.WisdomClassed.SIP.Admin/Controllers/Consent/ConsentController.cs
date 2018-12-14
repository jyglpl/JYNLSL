using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Consent;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Consent;
using Yookey.WisdomClassed.SIP.Common;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Consent
{
    public class ConsentController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly AdvertisingBll _advertisingBll = new AdvertisingBll();
        readonly ActivityBll _activityBll = new ActivityBll();
        readonly TemporaryBll _temporaryBll = new TemporaryBll();
        readonly ExcavationBll _excavationBll = new ExcavationBll();
        readonly ComNumberBll _comNumberBll = new ComNumberBll();          //编号

        #region 视图
        /// <summary>
        /// 户外广告
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <returns></returns>
        public ActionResult Advertising()
        {
            //类型
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0046" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ConsentType"] = new SelectList(classNos, "Id", "Rskey");
            return View();    
        }

        /// <summary>
        /// 户外广告详情
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <returns></returns>
        public ActionResult AdvertisDetails(string id)
        {
            var user = CurrentUser.CrmUser;
            var entity = new AdvertisingEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _advertisingBll.Get(id);
                var files = new Consent_AttachBll().GetSearchResult(new Consent_AttachEntity() { ResourceId = id });
                ViewData["Files"] = files;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            BindDrp();
            return View(entity);

        }

        /// <summary>
        /// 临时占道
        /// </summary>
        /// <returns></returns>
        public ActionResult Temporary()
        {
            return View();
        }

        /// <summary>
        /// 临时占道详情
        /// </summary>
        /// <returns></returns>
        public ActionResult TemporaryDetails(string id)
        {
            var entity = new TemporaryEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _temporaryBll.Get(id);
                var files = new Consent_AttachBll().GetSearchResult(new Consent_AttachEntity() { ResourceId = id });
                ViewData["Files"] = files;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            return View(entity);
        }

        /// <summary>
        /// 举办活动
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <returns></returns>
        public ActionResult Activity()
        {
            return View();
        }

        /// <summary>
        /// 举办活动详细
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ActivityDetails(string id)
        {
            var entity = new ActivityEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _activityBll.Get(id);
                var files = new Consent_AttachBll().GetSearchResult(new Consent_AttachEntity() { ResourceId = id });
                ViewData["Files"] = files;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            return View(entity);
        }

        /// <summary>
        /// 开挖
        /// </summary>
        /// <returns></returns>
        public ActionResult Excavation()
        {
            return View();
        }

        /// <summary>
        /// 开挖详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcavationDetails(string id)
        {
            var entity = new ExcavationEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _excavationBll.Get(id);
                var files = new Consent_AttachBll().GetSearchResult(new Consent_AttachEntity() { ResourceId = id });
                ViewData["Files"] = files;
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            return View(entity);
        }


        private void BindDrp()
        {
            //类型
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0046" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ConsentType"] = new SelectList(classNos, "Id", "Rskey");
        }


        #endregion

        /// <summary>
        /// 户外广告数据查询
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="typeId"></param>
        /// <param name="keyword"></param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryAdvertingList(string startTime, string endTime, string typeId, string keyword, string companyId, int rows, int page)
        {
            var data = new AdvertisingBll().QueryAdvertingList(startTime, endTime, typeId, keyword, companyId, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 保存户外广告
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveAdvertis(AdvertisingEntity entity)
        {
            var rtMsrg = "";
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;

                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                //自动生成编号
                if (string.IsNullOrEmpty(entity.BatchNum))
                {
                    entity.BatchNum = _comNumberBll.GetNumber(AppConst.XkGg, "", null);
                }
                isOk = _advertisingBll.SaveAdvertis(entity);
                rtMsrg = isOk == false ? "编号重复，保存失败" : "成功";
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<AdvertisingEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsrg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存举办活动
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveActivity(ActivityEntity entity)
        {
            var rtMsrg = "";
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = _activityBll.SaveActivity(entity);

                rtMsrg = isOk == false ? "编号重复，保存失败" : "成功";
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<AdvertisingEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsrg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除户外广告
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _advertisingBll.BatchDeleteConsent("'" + id + "'") ? 1 : 0;
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
        /// 查询举办活动
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryActivityList(string startTime, string endTime, string keyword, string companyId, int rows, int page)
        {
            var data = new ActivityBll().QueryActivityList(startTime, endTime, keyword, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 删除举办活动
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public JsonResult DeleteActivity(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _activityBll.BatchDeleteConsent("'" + id + "'") ? 1 : 0;
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
        /// 临时占道
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="keyword"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string QueryTemporaryList(string startTime, string endTime, string keyword, int rows, int page, string companyId = "")
        {
            var data = new TemporaryBll().QueryTemporaryList(startTime, endTime, keyword, companyId, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// 保存占道经营
        /// 添加人：叶念
        /// 添加时间：2015-07-30
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveTemporary(TemporaryEntity entity)
        {
            var rtMsrg = "";
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                //自动生成编号
                if (string.IsNullOrEmpty(entity.BatchNum))
                {
                    entity.BatchNum = _comNumberBll.GetNumber(AppConst.XkZd, "", null);
                }
                isOk = _temporaryBll.SaveTemporary(entity);

                rtMsrg = isOk == false ? "编号重复，保存失败" : "成功";
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<TemporaryEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsrg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 删除占道经营
        /// 添加人：叶念
        /// 添加时间：2015-07-28
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteTemporary(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _temporaryBll.BatchDeleteTemporary("'" + id + "'") ? 1 : 0;
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
        /// 挖掘数据列表
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryExcavationList(string startTime, string endTime, string keyword, string companyId, int rows, int page)
        {
            var data = _excavationBll.QueryExcavationList(startTime, endTime, keyword,companyId, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// 保存挖掘
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveExcavation(ExcavationEntity entity)
        {
            var rtMsrg = "";
            var isOk = false;
            try
            {
                var user = CurrentUser.CrmUser;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                //自动生成编号
                if (string.IsNullOrEmpty(entity.BatchNum))
                {
                    entity.BatchNum = _comNumberBll.GetNumber(AppConst.XkKw, "", null);
                }
                isOk = _excavationBll.Save(entity);

                rtMsrg = isOk == false ? "编号重复，保存失败" : "成功";
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<TemporaryEntity>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsrg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 删除挖掘
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public JsonResult DeleteExcavation(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _excavationBll.BatchDeleteExcavation("'" + id + "'") ? 1 : 0;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
    }
}
