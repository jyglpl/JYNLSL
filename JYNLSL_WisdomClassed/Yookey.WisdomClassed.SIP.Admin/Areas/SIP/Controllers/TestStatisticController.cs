using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.TestStatistic;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class TestStatisticController : Controller
    {

        TestStatisticBLL _TestBLL = new TestStatisticBLL();

        //
        // GET: /SIP/TestStatistic/

        public ActionResult TestStatistic()
        {
            return View();
        }

        public string GetCompanyTest(string txtName, int rows = 30, int page = 10)
        {
            var data = _TestBLL.GetSearchResult(txtName, rows, page);
            var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            return result;
        }

    }
}
