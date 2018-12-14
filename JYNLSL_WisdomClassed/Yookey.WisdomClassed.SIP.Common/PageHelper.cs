//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="PageHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：请一定在此描述类用途
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Yookey.WisdomClassed.SIP.Common
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public static class PageHelper
    {
        /// <summary>
        /// 获取输入框的值
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static string GetInputStringValue(this HtmlHelper html, string name, string defaultvalue = "")
        {
            return html.ViewContext.HttpContext.Request[name] ?? defaultvalue;
        }

        /// <summary>
        /// 排序标签
        /// </summary>
        /// <param name="html"></param>
        /// <param name="sortParamsData">排序字段及其值</param>
        /// <param name="className">样式(Class Name)</param>
        /// <returns></returns>
        public static MvcHtmlString SortLink(this HtmlHelper html, object sortParamsData, string className)
        {
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            var routeValueDictionary = new RouteValueDictionary(html.ViewContext.RouteData.Values);
            foreach (var key in from string key in queryString.Keys
                                where !string.IsNullOrEmpty(key)
                                where !string.IsNullOrEmpty(queryString[key])
                                select key)
            {
                routeValueDictionary[key] = queryString[key];
            }
            if (sortParamsData != null)
            {
                var pis = sortParamsData.GetType().GetProperties();
                foreach (var pi in pis)
                {
                    var key = pi.Name;
                    if (routeValueDictionary.Count(t => t.Key == key) > 0)
                    {
                        routeValueDictionary.Remove(key);
                    }
                    routeValueDictionary.Add(key, pi.GetValue(sortParamsData, null));
                }
            }
            return html.RouteLink(" ", routeValueDictionary, new Dictionary<string, object> { { "class", className } });
        }

        /// <summary>
        /// 分页(HttpGet)
        /// </summary>
        /// <param name="html">Html Helper</param>
        /// <param name="currentPageString">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns>分页生产后的HTML</returns>
        public static MvcHtmlString Pager(this HtmlHelper html, string currentPageString, long pageSize, long totalRecords)
        {
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            long currentPage;
            if (!long.TryParse(queryString[currentPageString], out currentPage))
            {
                currentPage = 1;
            }
            var pageCount = Math.Max((totalRecords + pageSize - 1) / pageSize, 1);
            var routeValueDictionary = new RouteValueDictionary(html.ViewContext.RouteData.Values);
            var output = new StringBuilder();

            foreach (var key in from string key in queryString.Keys
                                where !string.IsNullOrEmpty(key)
                                where !string.IsNullOrEmpty(queryString[key])
                                select key)
            {
                routeValueDictionary[key] = queryString[key];
            }

            if (pageCount > 1)
            {
                if (currentPage != 1)
                {
                    //首页
                    routeValueDictionary[currentPageString] = 1;
                    output.AppendFormat(html.RouteLink("{0}", routeValueDictionary, new Dictionary<string, object> { { "class", "pagePrev" } }).ToString(), "&nbsp;首页");
                }
                output.Append(" ");

                const long currlong = 5;
                const long showPageMaxSize = 10;
                for (var i = 0; i < showPageMaxSize; i++)
                {
                    //一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currlong) >= 1 && (currentPage + i - currlong) <= pageCount)
                    {
                        if (currlong.Equals(i))
                        {
                            //处理当前页面
                            output.AppendFormat("<a href=\"#\" class=\"at\">{0}</a>", currentPage);
                        }
                        else
                        {
                            //普通页面处理
                            routeValueDictionary[currentPageString] = currentPage + i - currlong;
                            output.AppendFormat("{0}", html.RouteLink((currentPage + i - currlong).ToString(), routeValueDictionary));
                        }
                    }
                    output.Append(" ");
                }
                output.Append(" ");
                if (currentPage != pageCount)
                {
                    routeValueDictionary[currentPageString] = pageCount;
                    output.AppendFormat(html.RouteLink("{0}", routeValueDictionary, new Dictionary<string, object> { { "class", "pageNext" } }).ToString(), "&nbsp;末页");
                }

                output.Append(" ");
            }
            return new MvcHtmlString(output.ToString());
        }

        /// <summary>
        /// 分页(HttpPost)
        /// Controller中通过Request["page"]获取当前页
        /// </summary>
        /// <param name="html">Html Helper</param>
        /// <param name="formName">表单名称</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper html, string formName, long currentPage, long pageSize, long totalRecords)
        {
            var pageCount = Math.Max((totalRecords + pageSize - 1) / pageSize, 1);
            var output = new StringBuilder();
            //增加JS Script
            output.Append(
                "<script type=\"text/javascript\"> function pagea(currentpage) { document.getElementById(\"page\").value=currentpage; document.forms[\"" +
                formName + "\"].submit(); } </script>");
            output.AppendFormat("<input type=\"hidden\" id=\"page\" name=\"page\" />");
            if (pageCount > 1)
            {
                if (currentPage != 1)
                {
                    //首页
                    output.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"javascript:pagea({0})\" class=\"pagePrev\">{0}</a>", "&nbsp;首页");
                }
                output.Append(" ");
                const long currlong = 5;
                const long showPageMaxSize = 10;
                for (var i = 0; i < showPageMaxSize; i++)
                {
                    //一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currlong) >= 1 && (currentPage + i - currlong) <= pageCount)
                    {
                        if (currlong.Equals(i))
                        {
                            //处理当前页面
                            output.AppendFormat("<a href=\"javascript:void(0);\" class=\"at\">{0}</a>", currentPage);
                        }
                        else
                        {
                            //普通页面处理
                            output.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"javascript:pagea({0})\">{0}</a>", currentPage + i - currlong);
                        }
                    }
                    output.Append(" ");
                }
                output.Append(" ");
                if (currentPage != pageCount)
                {
                    output.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"javascript:pagea({0})\" class=\"pageNext\">{0}</a>", "&nbsp;末页");
                }
                output.Append(" ");
            }
            return new MvcHtmlString(output.ToString());
        }
    }
}