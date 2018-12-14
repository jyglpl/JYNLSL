using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP
{
    public class SIPAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SIP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SIP_default",
                "SIP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
