using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    public class PenaltyCaseSeaController : Controller
    {
        //
        // GET: /PenaltyCaseSea/

        /// <summary>
        /// 查询界面
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseSeaIndex()
        {
            return View();
        }

        /// <summary>
        /// 详情界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            var defaultPage = "CaseSeaEntity";

            ViewBag.DefaultPage = defaultPage;

            return View();
        }

        /// <summary>
        /// 案件详情
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseSeaEntity()
        {
            return View();
        }

    }
}
