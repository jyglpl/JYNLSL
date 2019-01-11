//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="NpoiHelper.cs">
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

using System.Web;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class NpoiHelper
    { 
        /// <summary>
        /// 设置excel公共样式，边框加黑线
        /// 添加人：李寿祥
        /// 添加时间：2013-9-25
        /// </summary>
        /// <param name="cs"></param>
        public static void SetExcelBoderStyle(ICellStyle cs)
        {
            cs.Alignment = HorizontalAlignment.CENTER;
            cs.VerticalAlignment = VerticalAlignment.CENTER;
            cs.BorderTop = BorderStyle.THIN;
            cs.BorderBottom = BorderStyle.THIN;
            cs.BorderLeft = BorderStyle.THIN;
            cs.BorderRight = BorderStyle.THIN;
            cs.TopBorderColor = IndexedColors.BLACK.Index;
            cs.BottomBorderColor = IndexedColors.BLACK.Index;
            cs.LeftBorderColor = IndexedColors.BLACK.Index;
            cs.RightBorderColor = IndexedColors.BLACK.Index;
        }
        /// <summary>
        /// 合并单元格
        /// 添加人：李寿祥
        /// 添加时间：2013-9-25
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            sheet.AddMergedRegion(new CellRangeAddress(rowstart, rowend, colstart, colend));
        }

        /// <summary>
        /// 向页面输出excel文件
        /// 添加人：李寿祥
        /// 添加时间：2013-09-29
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="excelName">Excel的名称</param>
        public static void WriteToFile(IWorkbook workbook, string excelName)
        {
            var ms = new System.IO.MemoryStream();
            workbook.Write(ms);
            string fileName = excelName + ".xlsx";
            if (HttpContext.Current.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            workbook = null;
            ms.Close();
            ms.Dispose();
        }
    }
}
