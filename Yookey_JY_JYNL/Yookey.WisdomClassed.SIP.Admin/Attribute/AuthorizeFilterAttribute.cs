using System;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Membership;
namespace Yookey.WisdomClassed.SIP.Admin.Attribute
{
    /// <summary>
    /// 权限判断
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var path = filterContext.HttpContext.Request.Path.ToLower();
            if (path == "/" || path == "/Account/Login".ToLower())
                return; //忽略对Login登录页的权限判定
            if (filterContext.HttpContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            //获取当前用户信息
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            if (controllerName.ToLower().Equals("home"))
            {
                return;
            }
            var actionName = filterContext.RouteData.Values["action"].ToString();
            if (new MembershipManager().ValidatePermissions(filterContext.HttpContext.User.Identity.Name, controllerName, actionName)) return;
            filterContext.Result = new RedirectResult("/Error/Index");
        }
    }
}