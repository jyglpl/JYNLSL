using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule
{
    public class CommonModuleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CommonModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CommonModule_default",
                "CommonModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
