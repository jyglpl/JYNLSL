//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="RegexHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：正则表达式验证
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Text.RegularExpressions;

namespace Yookey.WisdomClassed.SIP.Common
{
    /// <summary>
    /// 正则公共处理类
    /// </summary>
    public class RegexHelper
    {
        #region 正则判断
        /// <summary>
        /// 获取用于判断正浮点数的正则表达式(包含0) 
        /// </summary>
        public const string InculudeZeroDecimalRegex = @"^\d+(\.\d+)?$";

        /// <summary>
        /// 获取用于判断正浮点数的正则表达式(不包含0)
        /// </summary>
        public const string NotInculudeZeroDecimalRegex = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>
        /// 获取用于判断非负整数的正则表达式(包含0)
        /// </summary>
        public const string InculudeZeroIntRegex = @"^\d+$";

        /// <summary>
        /// 获取用于判断>=-1 的浮点数正则表达式(包含0) 
        /// </summary>
        public const string GreaterThanOrEqual_1ToRegex = @"^(\d+(\.\d+)?)|(-1)$";

        /// <summary>
        /// 获取用于判断整数的正则表达式(包含0)
        /// </summary>
        public const string NumRegex = @"^-?[1-9]\d*|0$";

        /// <summary>
        /// 获取用于判断非负整数的正则表达式(不包含0)
        /// </summary>
        public const string NotInculudeZeroIntRegex = @"^[1-9][0-9]*$";

        /// <summary>
        /// 获取用于判断身份证的正则表达式
        /// </summary>
        public const string IdentificationCardRegex = @"(^\d{15}$)|(^\d{17}(?:\d|x)$)";

        /// <summary>
        /// 获取用于判断年份的正则表达式
        /// </summary>
        public const string CheckYearRegex = @"^19\d\d|20\d\d$";

        /// <summary>
        /// 获取用于判断月份的正则表达式
        /// </summary>
        public const string CheckMonthRegex = @"^(0?[1-9]|1[0-2])$";

        /// <summary>
        /// 获取用于判断日的正则表达式
        /// </summary>
        public const string CheckDayRegex = @"^((0?[1-9])|((1|2)[0-9])|30|31)$";

        /// <summary>
        /// 获取用于判断邮箱的正则表达式
        /// </summary>
        public const string CheckEmailRegex = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";

        /// <summary>
        /// 获取用于判断手机号码的正则表达式
        /// </summary>
        public const string CheckMobileRegex = @"^1(([358]\d{9})|(47\d{8}))$";
        /// <summary>
        /// 获取用于判断电话号码的正则表达式
        /// </summary>
        public const string CheckPhoneRegex = @"^(\+86\s{1,1})?((\d{3,4}\-)\d{7,8})$";
        /// <summary>
        /// 获取用于判断邮政编码的正则表达式
        /// </summary>
        public const string CheckPostCode = @"^[1-9]\d{5}(?!\d)$";

        /// <summary>
        /// 判断是否全是数字
        /// </summary>
        public const string IsAllNumbers = "^[0-9]*$";
        #endregion 

        #region "正式表达式验证"
        /// <summary>
        /// 正式表达式验证
        /// </summary>
        /// <param name="cValue">验证字符</param>
        /// <param name="cStr">正式表达式</param>
        /// <returns>符合true不符合false</returns>
        public static bool CheckRegEx(string cValue, string cStr)
        {
            var objAlphaPatt = new Regex(cStr, RegexOptions.Compiled);
            return objAlphaPatt.Match(cValue).Success;
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="strMobile">待测试手机号字符串</param>
        /// <returns>是手机格式就返回true;否则返回false</returns>
        public static bool CheckMobile(string strMobile)
        {
            return strMobile != null && Regex.IsMatch(strMobile.Trim(), CheckMobileRegex);
        }

        #endregion
    }
}
