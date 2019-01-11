using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class WhiteListController : BaseController
    {
        //
        // GET: /WhiteList/

        private ComWhiteListBll _whiteListBll = new ComWhiteListBll();//车牌白名单

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string QueryListJson(string keyword)
        {
            var data = _whiteListBll.GetSearchResult(new ComWhiteListEntity { PlateNumber = keyword });
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 编辑详情
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public ActionResult Edit(string whiteListId)
        {
            var entity = new ComWhiteListEntity();
            if (!string.IsNullOrEmpty(whiteListId))
            {
                entity = _whiteListBll.Get(whiteListId);
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();  //主键
            }

            //省份
            var carNoProviences = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0025" });
            carNoProviences.Insert(0, new ComResourceEntity { Id = "", RsKey = "请选择" });
            ViewData["CarCarNoProvience"] = new SelectList(carNoProviences, "RsKey", "RsKey");

            //26个市字母
            var carCarNoWord = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0026" });
            carCarNoWord.Insert(0, new ComResourceEntity { Id = "", RsKey = "请选择" });
            ViewData["CarCarNoWord"] = new SelectList(carCarNoWord, "RsKey", "RsKey");

            return View(entity);
        }

        /// <summary>
        /// 保存违法建设信息
        /// </summary>
        /// <param name="entity">单位实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SubmitForm(ComWhiteListEntity entity)
        {
            var rtState = 0;
            try
            {
                if (true)
                {
                    ComWhiteListEntity whiteList = _whiteListBll.Get(entity.Id);
                    if (whiteList == null)
                    {
                        entity.Id = entity.Id;
                        entity.RowStatus = (int)RowStatus.Normal;
                        entity.CreateBy = CurrentUser.CrmUser.UserName;
                        entity.CreatorId = CurrentUser.CrmUser.Id;
                        entity.CreateOn = DateTime.Now;
                        _whiteListBll.Add(entity);
                    }
                    else
                    {
                        entity.UpdateBy = CurrentUser.CrmUser.UserName;
                        entity.UpdateId = CurrentUser.CrmUser.Id;
                        entity.UpdateOn = DateTime.Now;
                        _whiteListBll.Update(entity);
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
        /// 删除菜单
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">菜单编号</param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _whiteListBll.BatchDelete("'" + id + "'") ? 1 : 0;
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
