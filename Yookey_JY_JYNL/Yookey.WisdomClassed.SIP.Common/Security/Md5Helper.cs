using System.Web.Security;

namespace Yookey.WisdomClassed.SIP.Common.Security
{
    public class Md5Helper
    {
        #region MD5加密
        /// <summary>
        /// 获取MD5加密后字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string Md5Encode(string sourceString)
        {
            return Md5Encode(sourceString, 32);
        }

        public static string Md5Encode(string sourceString, int digits)
        {
            return Md5Encode(sourceString, digits, true);
        }

        /// <summary>
        /// 获取获取MD5加密后字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="digits">加密位数(16或32)</param>
        /// <param name="isToUpper">是否大写</param>
        /// <returns></returns>
        public static string Md5Encode(string sourceString, int digits, bool isToUpper)
        {
            if (string.IsNullOrEmpty(sourceString))
                return string.Empty;
            var hashPasswordForStoringInConfigFile = FormsAuthentication.HashPasswordForStoringInConfigFile(sourceString, "MD5");
            if (hashPasswordForStoringInConfigFile != null)
            {
                var targetString = digits == 16
                                       ? hashPasswordForStoringInConfigFile.Substring(8, 16)
                                       : hashPasswordForStoringInConfigFile;
                return isToUpper ? targetString.ToUpper() : targetString.ToLower();
            }
            return null;
        }
        #endregion
    }
}
