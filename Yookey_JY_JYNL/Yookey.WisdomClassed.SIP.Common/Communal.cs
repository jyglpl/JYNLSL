using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class Communal
    {
        #region 图像转换为Base64编码
        #region 把图片转换成二进制
        //将图片以二进制流
        public byte[] SaveImageBase64(String path)
        {
            try
            {
                byte[] imgBytesIn = null;
                if (File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                }
                return imgBytesIn;
            }
            catch
            {

                return null;
            }

        }
        #endregion
        /// <summary>
        /// 图像转Base64 
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        public string ImageToBase64(string ImagePath)
        {
            try
            {
                Bitmap bmp = new Bitmap(ImagePath);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region Base64编码转换为图像
        /// <summary>
        /// Base64编码转换为图像
        /// </summary>
        /// <param name="base64String">Base64字符串</param>
        /// <returns>转换成功返回图像；失败返回null</returns>
        public static Image Base64ToImage(byte[] base64String, string savePath)
        {
            MemoryStream ms = null;
            Image image = null;
            try
            {
                byte[] imageBytes = base64String;
                ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = Image.FromStream(ms, true);
                image.Save(savePath);
            }
            catch
            {
            }
            finally
            {
                if (ms != null) ms.Close();
            }
            return image;
        }

        #endregion

        #region 公用方法
        public string SwitchCase(string TargetType)
        {
            var NewTargetType = "";
            switch (TargetType)
            {
                case "自然人":
                    NewTargetType = "0";
                    break;
                case "法人":
                    NewTargetType = "1";
                    break;
                case "其他":
                    NewTargetType = "2";
                    break;
            }
            return NewTargetType;
        }
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="Gener"></param>
        /// <returns></returns>
        public string SwichGener(string Gener)
        {
            var NewGener = "";
            switch (Gener)
            {
                case "女":
                    NewGener = "0";
                    break;
                case "男":
                    NewGener = "1";
                    break;
                case "其他":
                    NewGener = "2";
                    break;
            }
            return NewGener;
        }
        /// <summary>
        /// 证件
        /// </summary>
        /// <param name="PaperType"></param>
        /// <returns></returns>
        public string SwichTargetPaperType(string PaperType)
        {
            var NewPaperType = "";
            switch (PaperType)
            {
                case "身份证":
                    NewPaperType = "0";
                    break;
                case "护照":
                    NewPaperType = "1";
                    break;
                case "回乡证":
                    NewPaperType = "2";
                    break;
                case "居住证":
                    NewPaperType = "3";
                    break;
                case "军官证":
                    NewPaperType = "4";
                    break;
                case "特区护照":
                    NewPaperType = "5";
                    break;
                case "通行证":
                    NewPaperType = "6";
                    break;
                case "台胞证":
                    NewPaperType = "7";
                    break;
                case "其他":
                    NewPaperType = "10";
                    break;
            }
            return NewPaperType;
        }
        /// <summary>
        /// 办理过程名称
        /// </summary>
        /// <param name="Process"></param>
        /// <returns></returns>
        public string SwichProcess(string Process)
        {
            var NewProcess = "";
            switch (Process)
            {
                case "立案审批":
                    NewProcess = "0";
                    break;
                case "处理审批":
                    NewProcess = "1";
                    break;
                case "处罚告知":
                    NewProcess = "2";
                    break;
                case "陈述、申辩、听证情况":
                    NewProcess = "3";
                    break;
                case "处罚决定":
                    NewProcess = "4";
                    break;
                case "结案":
                    NewProcess = "5";
                    break;
                case "归档":
                    NewProcess = "6";
                    break;
            }
            return NewProcess;
        }
        /// <summary>
        /// 是否诉讼
        /// </summary>
        /// <param name="Lawsui"></param>
        /// <returns></returns>
        public string SwichLawsui(string Lawsui)
        {
            var NewLawsui = "";
            switch (Lawsui)
            {
                case "无":
                    NewLawsui = "0";
                    break;
                case "诉讼":
                    NewLawsui = "1";
                    break;
                case "复议":
                    NewLawsui = "2";
                    break;
            }
            return NewLawsui;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TacheName"></param>
        /// <returns></returns>
        public string SwichTacheName(string TacheName)
        {
            var NewTacheName = "";
            switch (TacheName)
            {
                case "立案":
                    NewTacheName = "1";
                    break;
                case "调查取证":
                    NewTacheName = "2";
                    break;
                case "告知":
                    NewTacheName = "3";
                    break;
                case "处罚决定":
                    NewTacheName = "4";
                    break;
                case "决定送达":
                    NewTacheName = "5";
                    break;
                case "结案":
                    NewTacheName = "6";
                    break;
                case "其他":
                    NewTacheName = "7";
                    break;
            }
            return NewTacheName;
        }

        #region 日志插入
        /// <summary>
        /// 日志插入
        /// </summary>
        /// <param name="mess"></param>
        public void InsertLog(string mess)
        {
            var insetFile = AppConfig.ErrroLogAddress + @"\DataDocking" + DateTime.Now.ToLongDateString() + "Log.txt";
            var insertStream = new StreamWriter(insetFile, true);
            insertStream.WriteLine("判断是否执行出现异常，当前时间为：" + DateTime.Now.ToString() + "，信息：" + mess);
            insertStream.Close();
        }
        #endregion
        #endregion
    }
}
