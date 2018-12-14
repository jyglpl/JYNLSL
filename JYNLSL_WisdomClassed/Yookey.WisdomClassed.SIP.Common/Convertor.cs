//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Convertor.cs">
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

namespace Yookey.WisdomClassed.SIP.Common
{
    public static class Convertor
    {
        #region 数据格式转换
        /// <summary>
        ///  转换成Int
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static int ToInt(this object inputValue)
        {
            if (inputValue.IsInt())
            {
                return int.Parse(inputValue.ToStringValue());
            }
            return 0;
        }
        /// <summary>
        ///  转换成Int32
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static int ToInt32(this object inputValue)
        {
            if (inputValue.IsInt())
            {
                return Convert.ToInt32(inputValue);
            }
            return 0;
        }
        /// <summary>
        ///  转换成Int64
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static long ToInt64(this object inputValue)
        {
            if (inputValue.IsInt())
            {
                return Convert.ToInt64(inputValue);
            }
            return 0;
        }
        /// <summary>
        ///  转换成Double
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static Double ToDouble(this object inputValue)
        {
            if (!inputValue.IsNullOrEmpty())
            {
                return Convert.ToDouble(inputValue);
            }
            return 0;
        }
        /// <summary>
        ///  转换成Decimal
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static Decimal ToDecimal(this object inputValue)
        {
            if (!inputValue.IsNullOrEmpty())
            {
                return Convert.ToDecimal(inputValue);
            }
            return 0;
        }
        /// <summary>
        ///  转换成Int64
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static bool ToBool(this object inputValue)
        {
            if (inputValue.IsNullOrEmpty())
            {
                return false;
            }
            return bool.Parse(inputValue.ToStringValue());
        }
        /// <summary>
        ///  转换obj 成string
        /// </summary>
        /// <param name="inputValue">object</param>
        /// <returns></returns>
        public static string ToStringValue(this object inputValue)
        {
            if (inputValue == null)
            {
                return "";
            }
            return inputValue.ToString();
        }

        /// <summary>
        ///  转换成数据库字符串
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static string ToDbString(this object inputValue)
        {
            if (!inputValue.IsNullOrEmpty())
            {
                return ("'" + inputValue.ToStringValue().Trim().Replace("'", "''") + "'");
            }
            return "''";
        }
        /// <summary>
        ///  转换成时间类型yyyy-MM-dd
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object inputValue)
        {
            if (inputValue.IsNullOrEmpty())
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(inputValue);
        }
        /// <summary>
        ///  转换成时间类型
        /// </summary>
        /// <param name="inputValue">输入值</param>
        /// <param name="format">时间格式</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object inputValue, string format)
        {
            return DateTime.ParseExact(inputValue.ToStringValue(), format, null);
        }
        #endregion


        public static bool ToIsDesc(this object inputValue)
        {
            if (!inputValue.IsNullOrEmpty())
            {
                if (inputValue.Equals("asc"))
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
