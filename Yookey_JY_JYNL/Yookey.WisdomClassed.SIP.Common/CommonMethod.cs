//------------------------------------------------------------------------
// <copyright  company="友科软件" file="CommonMethod.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：公用方法
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using NPOI.SS.UserModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Model;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Yookey.WisdomClassed.SIP.Common
{
    /// <summary>
    /// 通用类
    /// </summary>
    public class CommonMethod
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param> 
        /// <param name="num">截取位数</param>
        /// <param name="ellipsis">省略号</param>
        /// <returns></returns>
        public static string GetSubString(string str, int num, bool ellipsis = true)
        {
            var substr = str;
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length > num)
                {
                    substr = ellipsis ? str.Substring(0, num) + "..." : str.Substring(0, num);
                }
            }
            return substr;
        }

        /// <summary>
        /// 获取最终字符串（排除DBNull，null，string.Empty 或空值后的真实值）
        /// </summary>
        /// <param name="objSource">object字符串</param>
        /// <returns></returns>
        public static string FinalString(object objSource)
        {
            if ((objSource == DBNull.Value) || (objSource == null))
                return string.Empty;
            return objSource.ToString().Trim();
        }

        /// <summary>
        /// 过滤输入内容的恶意html标记
        /// </summary>
        /// <param name="text">输入内容</param>
        /// <returns>过滤后的内容</returns>
        public static string InputText(string text)
        {
            return InputText(text, text.Length);
        }

        /// <summary>
        /// 过滤html，文本显示
        /// </summary>
        /// <param name="text">输入内容</param>
        /// <returns>过滤后的内容</returns>
        public static string FinalHtml(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = Regex.Replace(text, "[\\s]{2,}", " ");//两个或两个以上空格
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);//其他标记
            text = text.Replace("'", "''");
            return text;
        }

        /// <summary>
        /// 过滤输入内容的恶意html标记
        /// </summary>
        /// <param name="text">输入内容</param>
        /// <param name="maxLength">指定需过滤字符串长度</param>
        /// <returns>过滤后的内容</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");//两个或两个以上空格
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);//其他标记
            text = text.Replace("'", "''");
            return text;
        }


        /// <summary>
        /// 含有textarea的字符串转化到显示格式p
        /// </summary>
        /// <param name="encodeText"></param>
        /// <returns></returns>
        public static string EncodeToString(string encodeText)
        {
            var sb = new StringBuilder();
            if (encodeText != null)
            {
                var temp1 = encodeText.Split('\r');
                foreach (var t in temp1)
                {
                    var temp2 = t.Trim();
                    if (!temp2.Equals("\n") && !string.IsNullOrEmpty(temp2))
                    {
                        sb.AppendFormat("<p>{0}</p>", temp2);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 含有p的字符串转化到textarea显示格式
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static string StringToEncode(string theString)
        {
            var str = string.Empty;
            if (theString != null)
            {
                theString = theString.Replace("</p><p>", "\r\n");
                theString = theString.Replace("<p>", "");
                theString = theString.Replace("</p>", "\r\n");
                str = theString;
            }
            return str;
        }



        /// <summary>
        /// 判断一个List是否为空或者未初始化
        /// </summary>
        /// <typeparam name="T">任意Model</typeparam>
        /// <param name="list">任意实现Ilist接口的类型</param>
        /// <returns>返回true表示空，否则不为空</returns>
        public static bool ListIsNullOrEmpty<T>(IList<T> list)
        {
            return list == null || list.Count.Equals(0);
        }

        #region 日期处理
        /// <summary>
        /// 格式化日期为2006-12-22
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime dTime)
        {
            return dTime.Year + "-" + dTime.Month + "-" + dTime.Day;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static string GetWeek(DateTime sDate)
        {
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;
            var rStr = "";
            switch (myCal.GetDayOfWeek(sDate).ToString())
            {
                case "Sunday":
                    rStr = "星期日";
                    break;
                case "Monday":
                    rStr = "星期一";
                    break;
                case "Tuesday":
                    rStr = "星期二";
                    break;
                case "Wednesday":
                    rStr = "星期三";
                    break;
                case "Thursday":
                    rStr = "星期四";
                    break;
                case "Friday":
                    rStr = "星期五";
                    break;
                case "Saturday":
                    rStr = "星期六";
                    break;
            }
            return rStr;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static string GetWeekNum(DateTime sDate)
        {
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;
            var rStr = "";
            switch (myCal.GetDayOfWeek(sDate).ToString())
            {
                case "Sunday":
                    rStr = "日";
                    break;
                case "Monday":
                    rStr = "一";
                    break;
                case "Tuesday":
                    rStr = "二";
                    break;
                case "Wednesday":
                    rStr = "三";
                    break;
                case "Thursday":
                    rStr = "四";
                    break;
                case "Friday":
                    rStr = "五";
                    break;
                case "Saturday":
                    rStr = "六";
                    break;
            }
            return rStr;
        }

        /// <summary>
        /// 获取两日期相差天数
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">截止日期</param>
        /// <returns>System.Int32.</returns>
        public static int GetDay(DateTime startTime, DateTime endTime)
        {
            var startSpan = new TimeSpan(startTime.Ticks);
            var endSpan = new TimeSpan(endTime.Ticks);
            var ts = endSpan.Subtract(startSpan).Duration();
            return ts.Days;
        }

        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="vcodeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int vcodeNum)
        {
            var sb = new StringBuilder(vcodeNum);
            var rand = new Random();
            for (int i = 1; i < vcodeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="strText">需加密的字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5(string strText)
        {
            var data = Encoding.Unicode.GetBytes(strText);
            MD5 md5 = new MD5CryptoServiceProvider();
            var result = md5.ComputeHash(data);
            return result.Aggregate("", (current, t1) => current + Convert.ToString(t1, 16));
        }

        #region 使用 给定密钥字符串 加密/解密string
        /// <summary>
        /// 使用给定密钥字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }
        /// <summary>
        /// 使用给定密钥字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, System.Text.Encoding.Default);
        }
        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>明文</returns>
        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            try
            {
                byte[] buff = Convert.FromBase64String(encrypted);
                byte[] kb = System.Text.Encoding.Default.GetBytes(key);
                return encoding.GetString(Decrypt(buff, kb));
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 使用给定密钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }
        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }
        /// <summary>
        /// 使用给定密钥解密数据
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }
        #endregion
        #region 加密
        public static string Encrypt(string toEncrypt, string key, string iv)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string toDecrypt, string key, string iv)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion




        ///// <summary>
        ///// 实体转为Json格式
        ///// </summary>
        ///// <param name="entity">实体</param>
        ///// <returns></returns>
        //public static string ToJson(object entity)
        //{
        //    var serializer = new DataContractJsonSerializer(entity.GetType());
        //    using (var ms = new MemoryStream())
        //    {
        //        serializer.WriteObject(ms, entity);
        //        var sb = new StringBuilder();
        //        sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
        //        return sb.ToString();
        //    }
        //}
        /// <summary>
        /// 将分页数据对象转换为Json数据
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <returns>System.String.</returns>
        public static string ToJson(object obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            return result;
        }

        #region 按照长度截取字符串，加省略号

        public static string GetStrByLength(string str, int length)
        {
            if (str.Length <= length)
                return str;
            else
                return str.Substring(0, length - 4) + "...";

        }

        #endregion
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime dt)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (long)Math.Round((dt - startTime).TotalSeconds, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 加载处根节点之外的列表集合
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="parentId">父节点Id</param>
        /// <param name="resourceList">需要递归的列表集合</param>
        /// <param name="lists">新的集合</param>
        /// <param name="blank">空格</param>
        /// <returns></returns>
        protected static List<T> GetChildren<T>(long parentId, List<T> resourceList, List<T> lists, string blank) where T : new()
        {
            blank += "　";
            foreach (dynamic t in resourceList)
            {
                if (t.ParentId != parentId || t.ParentId <= 0) continue;
                dynamic it = new T();
                it.Id = t.Id;
                it.Name = blank + "|—" + t.Name;
                it.ParentId = t.ParentId;
                lists.Add(it);
                GetChildren(t.Id, resourceList, lists, blank);
            }
            return lists;
        }

        /// <summary>
        /// 加载处根节点之外的列表集合
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="parentId">父节点Id</param>
        /// <param name="resourceList">需要递归的列表集合</param>
        /// <param name="lists">新的集合</param>
        /// <returns></returns>
        public static List<T> GetChildren<T>(long parentId, List<T> resourceList, List<T> lists) where T : new()
        {
            foreach (dynamic t in resourceList)
            {
                if (t.ParentId == parentId && t.ParentId > 0)
                {
                    lists.Add(t);
                    GetChildren(t.Id, resourceList, lists);
                }
            }
            return lists;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal StrToDecimal(string strValue, decimal defValue)
        {
            if (strValue.Length == 0 || strValue.Length > 16)
            {
                return defValue;
            }
            return Convert.ToDecimal(strValue);
        }

        #region 计算两个时间的间隔
        /// <summary>
        /// 计算两个时间的间隔
        /// 根据printType的值有不同的输出,已满足不通显示要求
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="printType">输出类型(目前只支持0)</param>
        /// <returns></returns>
        public static string GetTwoDateSpace(string dateBegin, string dateEnd, int printType)
        {
            string dateDiff = string.Empty;
            try
            {
                TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(dateEnd).Ticks);
                TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(dateBegin).Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (printType == 0) //显示天/小时/分钟
                {
                    if (ts.Days > 0)
                    {
                        dateDiff = string.Format("{0}天{1}时{2}分", ts.Days, ts.Hours, ts.Minutes);
                    }
                    else
                    {
                        dateDiff = string.Format("{0}时{1}分", ts.Hours, ts.Minutes);
                    }
                }
            }
            catch
            {
                dateDiff = "日期格式错误";
            }
            return dateDiff;
        }
        #endregion

        #region 获取时间（周，月）
        public static DateTime GetWeekDateStart()
        {
            //本周
            int weeknow = Convert.ToInt32(DateTime.Now.DayOfWeek);
            //星期日 获取weeknow为0
            weeknow = weeknow == 0 ? 7 : weeknow;
            int daydiff = (-1) * weeknow + 1;
            //本周第一天
            return DateTime.Now.AddDays(daydiff);
        }
        public static DateTime GetWeekDateEnd()
        {
            //本周
            int weeknow = Convert.ToInt32(DateTime.Now.DayOfWeek);
            //星期日 获取weeknow为0
            weeknow = weeknow == 0 ? 7 : weeknow;
            int dayadd = 7 - weeknow;
            //本周最后一天
            return DateTime.Now.AddDays(dayadd);
        }
        public static DateTime GetMonthDateStart()
        {
            DateTime dt = DateTime.Now;
            //本月第一天时间 
            DateTime firstDate = dt.AddDays(-(dt.Day) + 1);
            return firstDate;
        }
        public static DateTime GetMonthDateEnd()
        {
            DateTime dt = DateTime.Now;
            //将本月月数+1 
            DateTime dt2 = dt.AddMonths(1);
            //本月最后一天时间 
            DateTime lastDate = dt2.AddDays(-(dt.Day));
            return lastDate;
        }
        #endregion

        /// <summary>
        /// 获取同比
        /// </summary>
        /// <param name="currentYear">本期数据</param>
        /// <param name="lastYear">上期数据</param>
        /// <returns></returns>
        public static string GetYearToYear(decimal currentYear, decimal lastYear)
        {
            if (lastYear == 0)
            {
                return "-";
            }
            return string.Format("{0:n2}%", ((currentYear - lastYear) / lastYear) * 100);
        }

        /// <summary>
        /// 向页面输出excel文件
        /// 添加人：刘文信
        /// 添加时间：2013-05-09
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="excelName">Excel的名称</param>
        public static void ResponseExcel(Workbook workbook, string excelName)
        {
            var rootPath = HttpContext.Current.Server.MapPath("~/UploadFiles/Excel/");
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            var title = "/" + excelName + ".xlsx";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
            {
                if (HttpContext.Current.Request.Browser.Browser.ToLower().IndexOf("ie") >= 0)
                {
                    title = HttpContext.Current.Server.UrlEncode(title);
                }
            }
            var fs = new FileStream(rootPath + "/" + excelName + ".xlsx", FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();
            //把文件以流方式指定xls格式提供下载
            fs = File.OpenRead(rootPath + "/" + excelName + ".xlsx");
            var fileArray = new byte[fs.Length];
            fs.Read(fileArray, 0, fileArray.Length);
            fs.Close();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + title);
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Length", fileArray.Length.ToString());
            HttpContext.Current.Response.BinaryWrite(fileArray);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Clear();
        }

        /// <summary>
        /// 向页面输出excel文件
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="fileName"></param>
        public static void WriteExcle(MemoryStream ms, string fileName)
        {
            var rootPath = HttpContext.Current.Server.MapPath("~/UploadFiles/Excel/");
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            var title = "/" + fileName + ".xlsx";

            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
            {
                if (HttpContext.Current.Request.Browser.Browser.ToLower().IndexOf("ie") >= 0)
                {
                    title = HttpContext.Current.Server.UrlEncode(title);
                }
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + title);
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Length", ms.Length.ToString());
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Clear();
        }

        /// <summary>
        /// 保存文件到硬盘
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="fileName"></param>
        public static void SaveToFile(MemoryStream ms, string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }

        }

        /// <summary>
        /// 根据索引返回颜色
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public static string GetAllColors(int index)
        {
            var allColor = new[] { "#FF6600", "#008000", "#4B0082", "#800000", "#008080", "#6A5ACD", "#C2B9FF", "#00BFFF", "#FFF0F5","#32CD32" 
           ,"#8B7500"  ,"#228B22" ,"#6B8E23" ,"#8B6914" ,"#8B658B" ,"#CD5C5C" ,"#FF6A6A" ,"#8B3A3A" ,"#FF0000" ,"#FF3030" ,"#8B7D6B" ,"#836FFF" ,"#473C8B" ,"#0000CD" ,"#7A378B" ,"#607B8B" ,"#1C1C1C" ,"#696969" ,"#008B8B" ,"#B2DFEE" ,"#7A8B8B" };
            return allColor.Length < index ? allColor[0] : allColor[index];
        }

        /// <summary>
        /// Get方式获取url地址输出内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string SendRequestByGetMethod(string url, Encoding encoding)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();
        }
        /// <summary>
        /// 获取客户端真实IP地址(可穿过代理服务器)
        /// </summary>
        /// <returns></returns>
        public static string ClientIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理 
                if (result.IndexOf(".") == -1)     //没有“.”肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i]) && temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];     //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null;     //代理中的内容 非IP，取IP 
                }
            }

            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (null == result || result == String.Empty)
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;

            return result;
        }

        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        /// <summary>
        /// 金额转大写
        /// </summary>
        /// <param name="strAmount"></param>
        /// <returns></returns>
        public static string MoneyToUpper(string strAmount)
        {
            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数
            if (strAmount.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数
                strAmount = strAmount.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            strAmount = Math.Round(double.Parse(strAmount), 2).ToString();
            if (strAmount.IndexOf(".") > 0)
            {
                if (strAmount.IndexOf(".") == strAmount.Length - 2)
                {
                    strAmount = strAmount + "0";
                }
            }
            else
            {
                strAmount = strAmount + ".00";
            }
            strLower = strAmount;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "元";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零元", "亿元");
            strUpper = strUpper.Replace("亿零万零元", "亿元");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零元", "万元");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零元", "元");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹元以下的金额的处理
            if (strUpper.Substring(0, 1) == "元")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零元整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }

        #region 日期的转大写
        //把数字转换为大写
        public static string NumtoUpper(int num)
        {
            String str = num.ToString();
            string rstr = "";
            int n;
            for (int i = 0; i < str.Length; i++)
            {
                n = Convert.ToInt16(str[i].ToString());//char转数字,转换为字符串，再转数字
                switch (n)
                {
                    case 0: rstr = rstr + "〇"; break;
                    case 1: rstr = rstr + "一"; break;
                    case 2: rstr = rstr + "二"; break;
                    case 3: rstr = rstr + "三"; break;
                    case 4: rstr = rstr + "四"; break;
                    case 5: rstr = rstr + "五"; break;
                    case 6: rstr = rstr + "六"; break;
                    case 7: rstr = rstr + "七"; break;
                    case 8: rstr = rstr + "八"; break;
                    default: rstr = rstr + "九"; break;
                }
            }
            return rstr;
        }

        //月转化为大写
        public static string MonthtoUpper(int month)
        {
            if (month < 10)
            {
                return NumtoUpper(month);
            }
            else
                if (month == 10) { return "十"; }
                else
                {
                    return "十" + NumtoUpper(month - 10);
                }
        }
        //日转化为大写
        public static string DaytoUpper(int day)
        {
            if (day < 20)
            {
                return MonthtoUpper(day);
            }
            else
            {
                String str = day.ToString();
                if (str[1] == '0')
                {
                    return NumtoUpper(Convert.ToInt16(str[0].ToString())) + "十";

                }
                else
                {
                    return NumtoUpper(Convert.ToInt16(str[0].ToString())) + "十"
                        + NumtoUpper(Convert.ToInt16(str[1].ToString()));
                }
            }
        }

        //日期转换为大写
        public static string DateToUpper(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            return NumtoUpper(year) + "年" + MonthtoUpper(month) + "月" + DaytoUpper(day) + "日";
        }
        #endregion

        #region 获取当前请求的网络段


        /// <summary>
        /// 网络访问枚举
        /// </summary>
        public enum NetWorkEnum
        {
            /// <summary>
            /// 内网
            /// </summary>
            [Description("内网")]
            Intranet = 1,

            /// <summary>
            /// 外网
            /// </summary>
            [Description("外网")]
            OutNet = 2,
        }

        /// <summary>
        /// 当前请求网络所属段（内、外）
        /// 添加人：周 鹏
        /// 添加时间：2015-06-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>NetWorkEnum.</returns>
        public static NetWorkEnum GetNetWork()
        {
            var url = HttpContext.Current.Request.Url.Host;
            if (url.Equals(AppConfig.Intranet))     //内网
            {
                return NetWorkEnum.Intranet;
            }
            return url.Equals(AppConfig.OutNet) ? NetWorkEnum.OutNet : NetWorkEnum.Intranet;
        }

        #endregion

        /// <summary>
        /// 将分页数据对象转换为Json数据
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <returns>System.String.</returns>
        public static string PageToJson(object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(obj, timeConverter);
            return result;
        }

        /// <summary>
        /// 将Page对象转换成JqGridPage
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <returns>JqGrid 分页对象.</returns>
        public static JqDataGrid<T> PageToJqDataGrid<T>(Page<T> page)
        {
            var result = new JqDataGrid<T>()
            {
                page = page.CurrentPage.ToInt32(),
                total = page.TotalPages.ToInt32(),
                records = page.TotalRecords.ToInt32(),
                rows = page.Items
            };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Model.JqDataGrid<T> ConvertToJqDataGrid<T>(int pageIndex, int pageSize, int totalRecords, List<T> list)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new Model.JqDataGrid<T>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 序列化公共方法
        /// </summary>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return json;
        }

        /// <summary>
        /// 重新生成文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static string FileReName(string filename)
        {
            var random = new Random();
            var extension = ".jpg";
            if (filename.Contains("."))
            {
                extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                ? filename.Substring(filename.IndexOf('.'))
                                : ".jpg";
            }
            return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
        }

        /// <summary>
        /// 文件后缀
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static string FileExt(string filename)
        {
            var extension = ".jpg";
            if (filename.Contains("."))
            {
                extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                ? filename.Substring(filename.IndexOf('.'))
                                : ".jpg";
            }

            return extension;
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public static bool HttpDownload(string url, string path)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            System.Drawing.Image iSource = null;
            Bitmap ob = null;
            try
            {
                string pathDirec = path.Substring(0, path.LastIndexOf("/"));

                if (!System.IO.Directory.Exists(pathDirec))
                {
                    System.IO.Directory.CreateDirectory(pathDirec);//不存在就创建目录 
                }

                WebClient webClient = new WebClient();
                //
                webClient.DownloadFile(url, path);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (iSource != null)
                {
                    iSource.Dispose();
                }
                if (ob != null)
                {
                    ob.Dispose();
                }
            }
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public static void HttpDownloadII(string url, string path)
        {
            System.GC.Collect(); //垃圾回收，回收没有正常关闭的http连接

            System.Drawing.Image iSource = null;
            Bitmap ob = null;
            try
            {
                string pathDirec = path.Substring(0, path.LastIndexOf("/"));

                if (!System.IO.Directory.Exists(pathDirec))
                {
                    System.IO.Directory.CreateDirectory(pathDirec); //不存在就创建目录 
                }

                WebClient client = new WebClient();
                Stream str = client.OpenRead(url);
                StreamReader reader = new StreamReader(str);
                byte[] mbyte = new byte[1000000];
                int allmybyte = (int)mbyte.Length;
                int startmbyte = 0;

                while (allmybyte > 0)
                {

                    int m = str.Read(mbyte, startmbyte, allmybyte);
                    if (m == 0)
                        break;

                    startmbyte += m;
                    allmybyte -= m;
                }

                reader.Dispose();
                str.Dispose();

                FileStream fstr = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                fstr.Write(mbyte, 0, startmbyte);
                fstr.Flush();
                fstr.Close();

            }
            catch
            {

            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }


        /// <summary>
        /// 返回指示文件是否已被其它程序使用的布尔值
        /// </summary>
        /// <param name="fileFullName">文件的完全限定名，例如：“C:\MyFile.txt”。</param>
        /// <returns>如果文件已被其它程序使用，则为 true；否则为 false。</returns>
        public static Boolean FileIsUsed(String fileFullName)
        {
            Boolean result = false;


            //判断文件是否存在，如果不存在，直接返回 false
            if (!System.IO.File.Exists(fileFullName))
            {
                result = false;
            }//end: 如果文件不存在的处理逻辑
            else
            {
                //如果文件存在，则继续判断文件是否已被其它程序使用
                //逻辑：尝试执行打开文件的操作，如果文件已经被其它程序使用，则打开失败，抛出异常，根据此类异常可以判断文件是否已被其它程序使用。
                System.IO.FileStream fileStream = null;
                try
                {
                    fileStream = System.IO.File.Open(fileFullName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
                    result = false;
                }
                catch (System.IO.IOException ioEx)
                {
                    result = true;
                }
                catch (System.Exception ex)
                {
                    result = true;
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }


            }//end: 如果文件存在的处理逻辑
            //返回指示文件是否已被其它程序使用的值
            return result;
        }//end method FileIsUsed



        ///
        /// 判断字符串中是否有SQL攻击代码
        /// 传入用户提交数据
        /// true-安全；false-有注入攻击现有；
        public static bool ProcessSqlStr(string inputString)
        {
            //string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            //try
            //{
            //    if ((inputString != null) && (inputString != String.Empty))
            //    {
            //        string str_Regex = @"\b(" + SqlStr + @")\b";

            //        Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
            //        //string s = Regex.Match(inputString).Value; 
            //        if (true == Regex.IsMatch(inputString))
            //            return false;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}
            //return true;

            return true;
        }

    }
}