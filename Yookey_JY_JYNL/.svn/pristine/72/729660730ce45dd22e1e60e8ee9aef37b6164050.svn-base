using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Power;
using Yookey.WisdomClassed.SIP.Model.Power;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class PowerController :BaseController
    {

        //
        // GET: /Power/
        /// <summary>
        /// add by lpl
        /// 2019-1-2
        /// 权利事项导航页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-2
        /// 权利事项页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Item()
        {
            return View();
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-3
        /// 加载权利事项
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult LoadItem(string limit, string page,string Item,string LX)
        {
            PowerItemEntity powerItemEntity = new PowerItemEntity()
            {
                LX = LX,
                Item = Item
            };
            var data = new PowerItemBll().QueryList(powerItemEntity);
            var pagecount = data.Count;
            data = data.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(limit)).Take(Convert.ToInt32(limit)).ToList();
            var result = new LayTableModel<PowerItemEntity>
            {
                code = 0,
                msg = "成功",
                count = pagecount,
                data = data
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增和编辑权利事项页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PowerItemEdit(string Id)
        {
            PowerItemEntity powerItemEntity = new PowerItemEntity();
            ViewBag.Edit = "0";
            if (!string.IsNullOrEmpty(Id))
            {
                powerItemEntity = new PowerItemBll().Single(Id);
                ViewBag.Edit = "1";
            }

            return View(powerItemEntity);
        }

        /// <summary>
        /// 查看权利事项详情
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult PowerItemDetial(string Id)
        {
            PowerItemEntity powerItemEntity = new PowerItemEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                powerItemEntity = new PowerItemBll().Single(Id);
                ViewBag.Edit = "1";
            }

            return View(powerItemEntity);
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-3
        /// 绑定权力事项类型
        /// </summary>
        /// <returns></returns>
        public string BindLx()
        {
            var data = new ComResourceBll().GetResourcesByParentId("0058");
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-3
        /// 添加权利事项
        /// </summary>
        /// <param name="Item">违反行为</param>
        /// <param name="CFZL">处罚种类及幅度</param>
        /// <param name="CFYJ">处罚依据</param>
        /// <param name="CFYJYW">处罚依据原文</param>
        /// <param name="WFFG">违反规定</param>
        /// <param name="WFFGYW">违反规定原文</param>
        /// <param name="LX">类型</param>
        /// <returns></returns>
        public string PowerItemAdd(string Item,string CFZL,string CFYJ,string CFYJYW,string WFFG,string WFFGYW,string LX)
        {
            PowerItemEntity powerItemEntity = new PowerItemEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Item = Item,
                CFZL = CFZL,
                CFYJ = CFYJ,
                CFYJYW = CFYJYW,
                WFFG = WFFG,
                WFFGYW = WFFGYW,
                LX = LX,
                RowStatus = 1
            };

            if (new PowerItemBll().Add(powerItemEntity))
                return "1";
            return "0";
        }

        /// <summary>
        /// 更新数据
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="CFZL"></param>
        /// <param name="CFYJ"></param>
        /// <param name="CFYJYW"></param>
        /// <param name="WFFG"></param>
        /// <param name="WFFGYW"></param>
        /// <param name="LX"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string PowerItemChange(string Item, string CFZL, string CFYJ, string CFYJYW, string WFFG, string WFFGYW, string LX,string Id)
        {
            PowerItemEntity powerItemEntity = new PowerItemEntity()
            {
                Id = Id,
                Item = Item,
                CFZL = CFZL,
                CFYJ = CFYJ,
                CFYJYW = CFYJYW,
                WFFG = WFFG,
                WFFGYW = WFFGYW,
                LX = LX,
                RowStatus = 1
            };

            if (new PowerItemBll().Update(powerItemEntity))
                return "1";
            return "0";
        }

        /// <summary>
        /// 删除数据
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeleteItem(string Id)
        {
            if (new PowerItemBll().Delete(new PowerItemEntity()
            {
                Id = Id
            }))
                return "1";
            return "0";
        }
    }
}
