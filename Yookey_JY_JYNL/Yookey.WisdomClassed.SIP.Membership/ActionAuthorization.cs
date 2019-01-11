//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ActionAuthorization.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03
//  功能描述：权限验证
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Web;
using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Membership
{
    /// <summary>
    /// 功能权限判断
    /// </summary>
    public static class ActionAuthorization
    {
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="html"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool IsAllowed(this HtmlHelper html, string action)
        {
            return IsAllowed(html, "", action);
        }
        
        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="html"></param>
        /// <param name="controller">Controller</param>
        /// <param name="action">Action</param>
        /// <returns></returns>
        public static bool IsAllowed(this HtmlHelper html, string controller, string action)
        {
            if (html.ViewContext.HttpContext.Session != null)
            {
                var myAllActions = html.ViewContext.HttpContext.Session["MyAllActions"];
                if (myAllActions != null && !string.IsNullOrEmpty(myAllActions.ToString()))
                {
                    if (string.IsNullOrEmpty(controller))
                    {
                        controller = html.ViewContext.RouteData.Values["controller"].ToString().ToLower();
                    }
                    //var conAct = "," + controller.ToLower() + "_" + action.ToLower() + "_0" + ",";
                    var conAct2 = "," + controller.ToLower() + "_" + action.ToLower() + "_1" + ",";
                    //var chk = !myAllActions.ToString().Contains(conAct);
                    var chk2 = myAllActions.ToString().Contains(conAct2);
                    //return chk || chk2;
                    return chk2;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断是否有权限
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="controller">Controller</param>
        /// <param name="action">Action</param>
        /// <returns></returns>
        public static bool IsAllowed(HttpContextBase httpContext, string controller, string action)
        {
            if (httpContext.Session != null)
            {
                var myAllActions = httpContext.Session["MyAllActions"];
                if (myAllActions != null && !string.IsNullOrEmpty(myAllActions.ToString()))
                {
                    var conAct = "," + controller.ToLower() + "_" + action.ToLower() + "_0" + ",";
                    return !myAllActions.ToString().Contains(conAct);
                }
            }
            return true;
        }
    }
}
