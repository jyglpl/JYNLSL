//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ConvertHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：类型转换
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class ConvertHelper
    {

        #region 类型转换

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool ConvertToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression.ToString(), "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(expression.ToString(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        /// <summary>
        /// 转换为int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">返回的默认值</param>
        /// <returns></returns>
        public static int ConvertToInt(object obj, int defaultValue)
        {
            return ConvertToInt(obj, defaultValue, NumberStyles.Number);
        }

        /// <summary>
        /// 转换为int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">返回的默认值</param>
        /// <param name="numStyle">数字格式</param>
        /// <returns></returns>
        private static int ConvertToInt(object obj, int defaultValue, NumberStyles numStyle)
        {
            var result = defaultValue;
            if (obj != null && obj != DBNull.Value)
            {
                if (!int.TryParse(obj.ToString().Trim(), numStyle, null, out result))
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        /// <summary>
        /// 转换为decimal类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">返回的默认值</param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(object obj, decimal defaultValue)
        {
            var result = defaultValue;
            if (obj != null && obj != DBNull.Value)
            {
                if (!decimal.TryParse(obj.ToString().Trim(), out result))
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        /// <summary>
        /// 转换为double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">返回的默认值</param>
        /// <returns></returns>
        public static double ConvertToDouble(object obj, int defaultValue)
        {
            var result = Convert.ToDouble(defaultValue);
            if (obj != null && obj != DBNull.Value)
            {
                if (!double.TryParse(obj.ToString().Trim(), out result))
                {
                    result = Convert.ToDouble(defaultValue);
                }
            }
            return result;
        }

        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">返回的默认值</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(object obj, DateTime defaultValue)
        {
            var result = defaultValue;
            if (obj != null)
            {
                if (!DateTime.TryParse(obj.ToString().Trim(), out result))
                {
                    result = defaultValue;
                }
            }
            return result;
        }
        #endregion

        #region  Word 转PDF

        /// <summary>
        /// 转换word 成PDF文档
        /// </summary>
        /// <param name="_lstrInputFile">原文件路径</param>
        /// <param name="_lstrOutFile">pdf文件输出路径</param>
        /// <returns>true 成功</returns>
        public static bool ConvertWordToPdf(string _lstrInputFile, string _lstrOutFile)
        {
            Microsoft.Office.Interop.Word.Application application = null;
            Word.Document document = null;
            try
            {
                application = new Microsoft.Office.Interop.Word.Application();
                application.Visible = false;
                document = application.Documents.Open(_lstrInputFile);
                document.ExportAsFixedFormat(_lstrOutFile, Word.WdExportFormat.wdExportFormatPDF);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (document != null)
                {
                    document.Close();
                }
                if (application != null)
                {
                    application.Quit();
                }
            }
        }

        #endregion



        /// <summary>
        /// 将EXCEL文档转换成PDF格式
        /// </summary>
        /// <param name="_lstrInputFile"></param>
        /// <param name="_lstrOutFile"></param>
        /// <returns></returns>
        public static bool ConvertExcelToPdf(string _lstrInputFile, string _lstrOutFile)
        {
            Excel.XlFixedFormatType parameter = Excel.XlFixedFormatType.xlTypePDF;

            bool result;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Excel.ApplicationClass application = null;
            Excel.Workbook workBook = null;
            try
            {
                application = new Microsoft.Office.Interop.Excel.ApplicationClass();
                object target = _lstrOutFile;
                object type = parameter;
                workBook = application.Workbooks.Open(_lstrInputFile, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(parameter, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
    }
}
