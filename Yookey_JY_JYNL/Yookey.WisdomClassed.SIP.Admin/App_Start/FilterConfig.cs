using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers.Com;
namespace Yookey.WisdomClassed.SIP.Admin.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //监控引用
            filters.Add(new StatisticsTrackerAttribute());

        }
    }
}