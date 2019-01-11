using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Common
{
    public static class FileHelper
    {
        /// <summary>
        /// 返回缩略图路径
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Icon(this HtmlHelper helper, string path)
        {
            var num = path.LastIndexOf('.');
            var ImgPath = "";
            if (num > 0)
            {
                var Express = path.Substring(path.LastIndexOf('.'));
                //根据后缀名显示相应的缩略图
                switch (Express.ToLower())
                {
                    case ".ai": ImgPath = "../../../Content/img/IconImages/my_file_001.png"; break;
                    case ".aiff": ImgPath = "../../../Content/img/IconImages/my_file_002.png"; break;
                    case ".ani": ImgPath = "../../../Content/img/IconImages/my_file_003.png"; break;
                    case ".asf": ImgPath = "../../../Content/img/IconImages/my_file_004.png"; break;
                    case ".au": ImgPath = "../../../Content/img/IconImages/my_file_005.png"; break;
                    case ".avi": ImgPath = "../../../Content/img/IconImages/my_file_006.png"; break;
                    case ".bat": ImgPath = "../../../Content/img/IconImages/my_file_007.png"; break;
                    case ".bin": ImgPath = "../../../Content/img/IconImages/my_file_008.png"; break;
                    case ".bmp": ImgPath = "../../../Content/img/IconImages/my_file_009.png"; break;
                    case ".bup": ImgPath = "../../../Content/img/IconImages/my_file_010.png"; break;
                    case ".cab": ImgPath = "../../../Content/img/IconImages/my_file_011.png"; break;
                    case ".cal": ImgPath = "../../../Content/img/IconImages/my_file_012.png"; break;
                    case ".cat": ImgPath = "../../../Content/img/IconImages/my_file_013.png"; break;
                    case ".cur": ImgPath = "../../../Content/img/IconImages/my_file_014.png"; break;
                    case ".dat": ImgPath = "../../../Content/img/IconImages/my_file_015.png"; break;
                    case ".dcr": ImgPath = "../../../Content/img/IconImages/my_file_016.png"; break;
                    case ".der": ImgPath = "../../../Content/img/IconImages/my_file_017.png"; break;
                    case ".dic": ImgPath = "../../../Content/img/IconImages/my_file_018.png"; break;
                    case ".dll": ImgPath = "../../../Content/img/IconImages/my_file_019.png"; break;
                    case ".doc": ImgPath = "../../../Content/img/IconImages/my_file_020.png"; break;
                    case ".docx": ImgPath = "../../../Content/img/IconImages/my_file_021.png"; break;
                    case ".dvd": ImgPath = "../../../Content/img/IconImages/my_file_022.png"; break;
                    case ".dwg": ImgPath = "../../../Content/img/IconImages/my_file_023.png"; break;
                    case ".fon": ImgPath = "../../../Content/img/IconImages/my_file_025.png"; break;
                    case ".gif": ImgPath = "../../../Content/img/IconImages/my_file_026.png"; break;
                    case ".hlp": ImgPath = "../../../Content/img/IconImages/my_file_027.png"; break;
                    case ".hst": ImgPath = "../../../Content/img/IconImages/my_file_028.png"; break;
                    case ".html": ImgPath = "../../../Content/img/IconImages/my_file_029.png"; break;
                    case ".icon": ImgPath = "../../../Content/img/IconImages/my_file_030.png"; break;
                    case ".ifo": ImgPath = "../../../Content/img/IconImages/my_file_031.png"; break;
                    case ".inf": ImgPath = "../../../Content/img/IconImages/my_file_032.png"; break;
                    case ".ini": ImgPath = "../../../Content/img/IconImages/my_file_033.png"; break;
                    case ".java": ImgPath = "../../../Content/img/IconImages/my_file_034.png"; break;
                    case ".jif": ImgPath = "../../../Content/img/IconImages/my_file_035.png"; break;
                    case ".jpg": ImgPath = "../../../Content/img/IconImages/my_file_036.png"; break;
                    case ".log": ImgPath = "../../../Content/img/IconImages/my_file_037.png"; break;
                    case ".m4a": ImgPath = "../../../Content/img/IconImages/my_file_038.png"; break;
                    case ".mmf": ImgPath = "../../../Content/img/IconImages/my_file_039.png"; break;
                    case ".mmm": ImgPath = "../../../Content/img/IconImages/my_file_040.png"; break;
                    case ".mov": ImgPath = "../../../Content/img/IconImages/my_file_041.png"; break;
                    case ".mp2": ImgPath = "../../../Content/img/IconImages/my_file_042.png"; break;
                    case ".mp2v": ImgPath = "../../../Content/img/IconImages/my_file_043.png"; break;
                    case ".mp3": ImgPath = "../../../Content/img/IconImages/my_file_044.png"; break;
                    case ".mp4": ImgPath = "../../../Content/img/IconImages/my_file_045.png"; break;
                    case ".mpeg": ImgPath = "../../../Content/img/IconImages/my_file_046.png"; break;
                    case ".msp": ImgPath = "../../../Content/img/IconImages/my_file_047.png"; break;
                    case ".pdf": ImgPath = "../../../Content/img/IconImages/my_file_048.png"; break;
                    case ".png": ImgPath = "../../../Content/img/IconImages/my_file_049.png"; break;
                    case ".ppt": ImgPath = "../../../Content/img/IconImages/my_file_050.png"; break;
                    case ".pptx": ImgPath = "../../../Content/img/IconImages/my_file_051.png"; break;
                    case ".psd": ImgPath = "../../../Content/img/IconImages/my_file_052.png"; break;
                    case ".ra": ImgPath = "../../../Content/img/IconImages/my_file_053.png"; break;
                    case ".rar": ImgPath = "../../../Content/img/IconImages/my_file_054.png"; break;
                    case ".reg": ImgPath = "../../../Content/img/IconImages/my_file_055.png"; break;
                    case ".rtf": ImgPath = "../../../Content/img/IconImages/my_file_056.png"; break;
                    case ".theme": ImgPath = "../../../Content/img/IconImages/my_file_057.png"; break;
                    case ".tiff": ImgPath = "../../../Content/img/IconImages/my_file_058.png"; break;
                    case ".tlb": ImgPath = "../../../Content/img/IconImages/my_file_059.png"; break;
                    case ".ttf": ImgPath = "../../../Content/img/IconImages/my_file_060.png"; break;
                    case ".txt": ImgPath = "../../../Content/img/IconImages/my_file_061.png"; break;
                    case ".vob": ImgPath = "../../../Content/img/IconImages/my_file_062.png"; break;
                    case ".wav": ImgPath = "../../../Content/img/IconImages/my_file_063.png"; break;
                    case ".wma": ImgPath = "../../../Content/img/IconImages/my_file_064.png"; break;
                    case ".wmv": ImgPath = "../../../Content/img/IconImages/my_file_065.png"; break;
                    case ".wpl": ImgPath = "../../../Content/img/IconImages/my_file_066.png"; break;
                    case ".wri": ImgPath = "../../../Content/img/IconImages/my_file_067.png"; break;
                    case ".xls": ImgPath = "../../../Content/img/IconImages/my_file_068.png"; break;
                    case ".xlsx": ImgPath = "../../../Content/img/IconImages/my_file_069.png"; break;
                    case ".xml": ImgPath = "../../../Content/img/IconImages/my_file_070.png"; break;
                    case ".xsl": ImgPath = "../../../Content/img/IconImages/my_file_071.png"; break;
                    case ".zip": ImgPath = "../../../Content/img/IconImages/my_file_072.png"; break;
                    case ".ac3": ImgPath = "../../../Content/img/IconImages/my_file_073.png"; break;
                    default: ImgPath = "../../../Content/img/IconImages/nogs.gif"; break;
                }
            }
            else
            {
                ImgPath = "../../../Content/img/IconImages/wjj.png";
            }
            return ImgPath;
        }

        /// <summary>
        /// 判断是否是图片
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsImg(this HtmlHelper helper, string path)
        {
            var num = path.LastIndexOf('.');
            var ispic = false;
            if (num > 0)
            {
                var Express = path.Substring(path.LastIndexOf('.'));
                //根据后缀名显示相应的缩略图
                switch (Express.ToLower())
                {
                    case ".bmp": ispic = true; break;
                    case ".gif": ispic = true; break;
                    case ".icon": ispic = true; break;
                    case ".jpg": ispic = true; break;
                    case ".mpeg": ispic = true; break;
                    case ".png": ispic = true; break;
                    default: ispic = false; break;
                }
            }
            else
            {
                return ispic;
            }
            return ispic;
        }
    }
}
