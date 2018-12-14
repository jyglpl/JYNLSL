//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TreeViewHelper.cs">
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

namespace Yookey.WisdomClassed.SIP.Common
{
    /// <summary>
    /// TreeView 控件
    /// </summary>
    public static class TreeViewHtmlHelper
    {
        /// <summary>
        /// 生成TreeView
        /// </summary>
        /// <typeparam name="T">生成TreeView的基本实体类型</typeparam>
        /// <param name="html">当前HtmlHelper</param>
        /// <param name="treeId">生成的TreeView之ID</param>
        /// <param name="rootItems">根节点集合</param>
        /// <param name="childrenProperty">获取子节点集合之方法(泛型委托)</param>
        /// <param name="itemContent">获取子节点文本内容之方法(泛型委托)</param>
        /// <returns></returns>
        public static MvcHtmlString TreeView<T>(this HtmlHelper html, string treeId, IEnumerable<T> rootItems, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemContent)
        {
            return html.TreeView(treeId, rootItems, childrenProperty, itemContent, true, null);
        }

       /// <summary>
        /// 生成TreeView
       /// </summary>
        /// <typeparam name="T">生成TreeView的基本实体类型</typeparam>
        /// <param name="html">当前HtmlHelper</param>
        /// <param name="treeId">生成的TreeView之ID</param>
        /// <param name="rootItems">根节点集合</param>
        /// <param name="childrenProperty">获取子节点集合之方法(泛型委托)</param>
        /// <param name="itemContent">获取子节点文本内容之方法(泛型委托)</param>
       /// <param name="includeJavaScript">是否包含JS脚本</param>
       /// <returns></returns>
        public static MvcHtmlString TreeView<T>(this HtmlHelper html, string treeId, IEnumerable<T> rootItems, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemContent, bool includeJavaScript)
        {
            return html.TreeView(treeId, rootItems, childrenProperty, itemContent, includeJavaScript, null);
        }

        /// <summary>
        /// 生成TreeView
        /// </summary>
        /// <typeparam name="T">生成TreeView的基本实体类型</typeparam>
        /// <param name="html">当前HtmlHelper</param>
        /// <param name="treeId">生成的TreeView之ID</param>
        /// <param name="rootItems">根节点集合</param>
        /// <param name="childrenProperty">获取子节点集合之方法(泛型委托)</param>
        /// <param name="itemContent">获取子节点文本内容之方法(泛型委托)</param>
        /// <param name="includeJavaScript">是否包含JS脚本</param>
        /// <param name="emptyContent">空节点默认文本</param>
        /// <returns></returns>
        public static MvcHtmlString TreeView<T>(this HtmlHelper html, string treeId, IEnumerable<T> rootItems, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemContent, bool includeJavaScript, string emptyContent)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<ul id='{0}'>\r\n", treeId);
            if (rootItems.Count() == 0)
            {
                sb.AppendFormat("<li>{0}</li>", emptyContent);
            } 
            foreach (var item in rootItems)
            {
                RenderLi(sb, item, itemContent);
                AppendChildren(sb, item, childrenProperty, itemContent);
            }
            sb.AppendLine("</ul>");
            if (includeJavaScript)
            {
                sb.AppendFormat(
                    @"<script type='text/javascript'>$(document).ready(function() {{ $('#{0}').treeview({{ animated: 'fast' ,collapsed: true, unique: true,
 persist: 'location'}}); }});</script>",
                    treeId);
            }
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// 加载子树结构
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sb"></param>
        /// <param name="root">父目录树</param>
        /// <param name="childrenProperty">获取子树方法之委托</param>
        /// <param name="itemContent">节点文本</param>
        private static void AppendChildren<T>(StringBuilder sb, T root, Func<T, IEnumerable<T>> childrenProperty, Func<T, string> itemContent)
        {
            var children = childrenProperty(root);
            if (children.Count() == 0)
            {
                sb.AppendLine("</li>");
                return;
            }
            sb.AppendLine("\r\n<ul>");
            foreach (var item in children)
            {
                RenderLi(sb, item, itemContent);
                AppendChildren(sb, item, childrenProperty, itemContent);
            }
            sb.AppendLine("</ul></li>");

        }

        private static void RenderLi<T>(StringBuilder sb, T item, Func<T, string> itemContent)
        {
            sb.AppendFormat("<li>{0}", itemContent(item));
        }

        public static MvcHtmlString TreeView<T>(this HtmlHelper html, string treeId, IEnumerable<T> rootItems, Func<T, IEnumerable<T>> childrenProperty, Func<T, string, string> itemContent, bool includeJavaScript, string emptyContent)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("<ul id='{0}'>\r\n", treeId);
            if (rootItems.Count() == 0)
            {
                sb.AppendFormat("<li>{0}</li>", emptyContent);
            }
            foreach (var item in rootItems)
            {
                RenderLi(sb, item, itemContent, emptyContent);
                AppendChildren(sb, item, childrenProperty, itemContent, emptyContent);
            }
            sb.AppendLine("</ul>");
            if (includeJavaScript)
            {
                sb.AppendFormat(
                    @"<script type='text/javascript'>$(document).ready(function() {{ $('#{0}').treeview({{ animated: 'fast' ,collapsed: true, unique: true,
 persist: 'location'}}); }});</script>",
                    treeId);
            }
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// 加载子树结构
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sb"></param>
        /// <param name="root">父目录树</param>
        /// <param name="childrenProperty">获取子树方法之委托</param>
        /// <param name="itemContent">节点文本</param>
        private static void AppendChildren<T>(StringBuilder sb, T root, Func<T, IEnumerable<T>> childrenProperty, Func<T, string, string> itemContent, string emptyContent)
        {
            var children = childrenProperty(root);
            if (children.Count() == 0)
            {
                sb.AppendLine("</li>");
                return;
            }
            sb.AppendLine("\r\n<ul>");
            foreach (var item in children)
            {
                RenderLi(sb, item, itemContent, emptyContent);
                AppendChildren(sb, item, childrenProperty, itemContent, emptyContent);
            }
            sb.AppendLine("</ul></li>");

        }

        private static void RenderLi<T>(StringBuilder sb, T item, Func<T, string, string> itemContent, string emptyContent)
        {
            sb.AppendFormat("<li>{0}", itemContent(item, emptyContent));
        }
    }
}