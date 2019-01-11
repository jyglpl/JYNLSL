using System;
using System.Web.Mvc;
using System.Web.Routing;
using Yookey.WisdomClassed.SIP.Admin.Attribute;
using Yookey.WisdomClassed.SIP.Membership;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    [AuthorizeFilter]
    public class BaseController : Controller
    {
        public DateTime NowDate = DateTime.Now;
        public DateTime MinDate = Convert.ToDateTime("1900-01-01");
        /// <summary>
        /// 其他Controller (多个时用，号隔开),例如:“home,user”
        /// </summary>
        public string OtherControllers = "";

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public AccountInfo CurrentUser { get; private set; }

        /// <summary>
        /// 列表页之每页记录数
        /// </summary>
        public int PageSize = 10;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = new MembershipManager().GetCurrentAccount(User.Identity.Name);
                ViewBag.CurrentUser = CurrentUser;
                if (CurrentUser == null || CurrentUser.CrmUser == null)
                {
                    Response.Redirect("~/Account/Login?returnurl=" + Request.RawUrl);
                    return;
                }
                if (requestContext.HttpContext.Request.HttpMethod == "GET")
                {
                    var controllername = requestContext.RouteData.Values["controller"].ToString().ToLower();
                    var currentController = controllername;
                    if (Session["CurrentController"] == null || Session["CurrentController"].ToString() != currentController)
                    {
                        controllername = string.Format("'{0}'", controllername);
                        var currentUrl = string.Format("/{0}", controllername);
                        if (!string.IsNullOrEmpty(OtherControllers))
                        {
                            controllername += "," + OtherControllers;
                        }
                        var myAllActions = new MembershipManager().GetUserMenus(CurrentUser.CrmUser.Id, controllername);
                        Session["CurrentUrl"] = currentUrl;
                        Session["MyAllActions"] = myAllActions.ToLower();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login?returnurl=" + Request.RawUrl);
            }
        }
    }
}
