using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.OA;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.JYNLSL
{
    public class OAController : Controller
    {
        //
        // GET: /OA/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult DocAdd()
        {
            return View();
        }

        /// <summary>
        /// 获取公告通知表数据
        /// add by lpl
        /// 2018-12-14
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetAllDoc(string limit,string page)
        {
            var entity = new DocumentNotificationEntity();


            var data = new DocumentNotificationBll().GetAllResult(entity);

            var pagecount = data.Count;

            //分页重写，linq实现的数据量过大效率会出现瓶颈
            data = data.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(limit)).Take(Convert.ToInt32(limit)).ToList();

            var result = new LayTableModel<DocumentNotificationEntity>
            {
                code = 0,
                msg = "成功",
                count = pagecount,
                data = data
            };
            string temp = JsonConvert.SerializeObject(result);
            return JsonConvert.SerializeObject(result);

        }


   
        public string AddDoc(string title,string content)
        {
            return "1";
        }

    }
}
