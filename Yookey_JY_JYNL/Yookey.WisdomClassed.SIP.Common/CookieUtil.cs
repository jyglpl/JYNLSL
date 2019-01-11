//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CookieUtil.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03
//  功能描述：类型转换
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Web;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class CookieUtil
    {
        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookie(string key)
        {
            string value = "";
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                value = HttpContext.Current.Request.Cookies[key].Value;

            }
            return value;
        }
        /// <summary>
        /// 清除Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void Remove(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                //HttpContext.Current.Request.Cookies[key].Expires = DateTime.Now.AddDays(-1);
                SetCookie(key, "", DateTime.Now.AddDays(-1));
                HttpContext.Current.Request.Cookies.Remove(key);
            }
        }
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string key, string value, DateTime expires)
        {
            //var userCookiesId = new HttpCookie(key) {Expires = expires, Value = value};
            var userCookiesId = new HttpCookie(key) { Expires = expires, Value = value };
            HttpContext.Current.Response.AppendCookie(userCookiesId);
        }
    }
}