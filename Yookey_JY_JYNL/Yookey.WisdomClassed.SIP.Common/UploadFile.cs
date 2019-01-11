using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Common
{
    public static class UploadFileCommon
    {
        public static object Ob = new object();

        /// <summary>
        /// 写图片 返回图片路径
        /// </summary>
        /// <param name="fielType">上传文件类别,简易案件：Simple ,违停：Car</param>
        /// <param name="fileExt">文件扩展名</param>
        /// <param name="ff">图片二进制</param>
        public static string WriteFile(string fielType, string fileExt, byte[] ff)
        {
            lock (Ob)
            {
                try
                {
                    var rootDirectory = AppConfig.FileSaveAddr;  //上传图片所对应的文件夹
                    var dirPath = rootDirectory + GetUpLoadPath(fielType);   //上传图片所对应的文件夹
                    if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    var fileName = GetRamCode() + "." + fileExt; //随机文件名
                    var serverFileName = GetUpLoadPath(fielType) + fileName;  //上传图片路径(不包括根目录)
                    //执行写入图片
                    var fs = new FileStream(rootDirectory + serverFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, ff.Length, false);
                    fs.Write(ff, 0, ff.Length);
                    fs.Close();
                    fs.Dispose();
                    return serverFileName;
                }
                catch (Exception ex)
                {
                    var errorLog = ConfigurationManager.AppSettings["ErrroLog"];  //错误日志记录路径
                    var insetFile = errorLog + @"\WritePicture" + DateTime.Now.ToLongDateString() + "Log.txt";
                    var insertStream = new StreamWriter(insetFile, true);
                    insertStream.WriteLine("执行写入二进制图片出现异常，当前时间为：" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "，异常信息：" + ex.Message);
                    insertStream.Close();
                    return "";
                }
            }
        }

        /// <summary>
        /// 写图片 返回图片路径
        /// </summary>
        /// <param name="fielType">上传文件类别,简易案件：Simple ,违停：Car</param>
        /// <param name="fileExt">文件扩展名</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="ff">图片二进制</param>
        public static string WriteFile(string fielType, string fileExt, string fileName, byte[] ff)
        {
            lock (Ob)
            {
                try
                {
                    var rootDirectory = AppConfig.FileSaveAddr;  //上传图片所对应的文件夹
                    var dirPath = rootDirectory + GetUpLoadPath(fielType);   //上传图片所对应的文件夹
                    if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    var serverFileName = GetUpLoadPath(fielType) + fileName;  //上传图片路径(不包括根目录)
                    //执行写入图片
                    var fs = new FileStream(rootDirectory + serverFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, ff.Length, false);
                    fs.Write(ff, 0, ff.Length);
                    fs.Close();
                    fs.Dispose();
                    return serverFileName;
                }
                catch (Exception ex)
                {
                    var errorLog = ConfigurationManager.AppSettings["ErrroLog"];  //错误日志记录路径
                    var insetFile = errorLog + @"\WritePicture" + DateTime.Now.ToLongDateString() + "Log.txt";
                    var insertStream = new StreamWriter(insetFile, true);
                    insertStream.WriteLine("执行写入二进制图片出现异常，当前时间为：" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "，异常信息：" + ex.Message);
                    insertStream.Close();
                    return "";
                }
            }
        }

        #region  合成照片
        /// <summary>
        /// 合成照片
        /// </summary>
        /// <param name="FilePath1"></param>
        /// <param name="FilePath2"></param>
        /// <param name="FilePath3"></param>
        /// <param name="FileName"></param>
        /// <param name="checktime"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string MakewatermarkNew(string FilePath1, string FilePath2, string FilePath3, string FileName, string checktime, int width, int height, string mode, string type)
        {
            try
            {
                string FileSave = AppConfig.FileSaveAddr;
                bool FExit1 = FilePath1 != "" ? File.Exists(FileSave + FilePath1) : false;
                bool FExit2 = FilePath2 != "" ? File.Exists(FileSave + FilePath2) : false;
                bool FExit3 = FilePath3 != "" ? File.Exists(FileSave + FilePath3) : false;
                int towidth = width;
                int toheight = height;
                Bitmap bmp1 = null;
                Bitmap bmp2 = null;
                Bitmap bmp3 = null;
                int ow1 = 0;
                int oh1 = 0;
                int ow2 = 0;
                int oh2 = 0;
                int ow3 = 0;
                int oh3 = 0;
                if (type == "1")//磁盘读取
                {
                    if (FilePath1 != "" && FExit1)
                    {
                        bmp1 = new Bitmap(FileSave + FilePath1);//新建一个bmp图片
                        ow1 = bmp1.Width;
                        oh1 = bmp1.Height;
                    }
                    if (FilePath2 != "" && FExit2)
                    {
                        bmp2 = new Bitmap(FileSave + FilePath2);//新建一个bmp图片 
                        ow2 = bmp2.Width;
                        oh2 = bmp2.Height;
                    }
                    if (FilePath3 != "" && FExit3)
                    {
                        bmp3 = new Bitmap(FileSave + FilePath3);//新建一个bmp图片
                        ow3 = bmp3.Width;
                        oh3 = bmp3.Height;
                    }
                }

                switch (mode)
                {
                    case "HW"://指定高宽缩放（可能变形）   
                        towidth = ow1 + ow2;
                        toheight = oh1 > oh2 ? oh1 : oh2;
                        toheight = oh3 > 0 ? oh1 + oh3 : toheight;
                        break;
                    case "W"://指定宽，高按比例                    
                        toheight = bmp1.Height * width / bmp1.Width;
                        break;
                    case "H"://指定高，宽按比例
                        towidth = bmp1.Width * height / bmp1.Height;
                        break;
                    case "Cut"://指定高宽裁减（不变形）                
                        if (FilePath1 != "" && FExit1 && ((double)bmp1.Width / (double)bmp1.Height > (double)towidth / (double)toheight))
                        {
                            oh1 = bmp1.Height;
                            ow1 = bmp1.Height * towidth / toheight;
                        }
                        else if (FilePath1 != "" && FExit1)
                        {
                            ow1 = bmp1.Width;
                            oh1 = bmp1.Width * height / towidth;
                        }
                        if (FilePath2 != "" && FExit2 && ((double)bmp2.Width / (double)bmp2.Height > (double)towidth / (double)toheight))
                        {
                            oh2 = bmp2.Height;
                            ow2 = bmp2.Height * towidth / toheight;
                        }
                        else if (FilePath2 != "" && FExit2)
                        {
                            ow2 = bmp2.Width;
                            oh2 = bmp2.Width * height / towidth;
                        }
                        if (FilePath3 != "" && FExit3 && ((double)bmp3.Width / (double)bmp3.Height > (double)towidth / (double)toheight))
                        {
                            oh3 = bmp3.Height;
                            ow3 = bmp3.Height * towidth / toheight;
                        }
                        else if (FilePath3 != "" && FExit3)
                        {
                            ow3 = bmp3.Width;
                            oh3 = bmp3.Width * height / towidth;
                        }
                        break;
                    default:
                        break;
                }
                int w = 0;

                if (FilePath1 != "" && FExit1)
                    w += ow1;
                if (FilePath2 != "" && FExit2)
                    w += ow2;
                if (FilePath3 != "" && FExit3)
                    w += ow3;

                if (FExit1 || FExit2 || FExit3)
                {
                    Bitmap Zbmp = new Bitmap(ow1 + ow2, toheight, PixelFormat.Format16bppRgb555);//新建一个bmp图片 
                    //创建画布
                    Graphics draw = Graphics.FromImage(Zbmp);
                    //设置高质量插值法
                    draw.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    //设置高质量,低速度呈现平滑程度
                    draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //清空画布并以透明背景色填充

                    draw.Clear(Color.Snow);
                    //设置每个图片的大小和位置
                    if (FilePath1 != "" && FExit1)
                        draw.DrawImage(bmp1, 0, 0, ow1, oh1);
                    if (FilePath2 != "" && FExit2)
                        draw.DrawImage(bmp2, ow1, 0, ow2, oh2);
                    if (FilePath3 != "" && FExit3)
                        draw.DrawImage(bmp3, 0, oh1, ow3, oh3);

                    ////设置水印文字效果
                    //Font f = new Font("Verdana", 12, FontStyle.Bold);
                    //Brush b = new SolidBrush(Color.BurlyWood);
                    //string addText = checktime.Trim();
                    //draw.DrawString(addText, f, b, Zbmp.Width - 270, Zbmp.Height - 200);//设置检查时间位置


                    //判断是否存在存在合成照片，如果不存在则创建

                    string dirPath = FileSave + GetUpLoadPath("Synthesis");   //上传图片所对应的文件夹
                    if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string serverFileName = GetUpLoadPath("Synthesis") + FileName;

                    //判断是否存在存在合成照片，如果不存在则创建

                    FileInfo finfo = new FileInfo(FileSave + serverFileName);
                    if (finfo.Directory.Exists)
                    {
                        Zbmp.Save(FileSave + serverFileName, System.Drawing.Imaging.ImageFormat.Jpeg);//以jpg格式保存缩略图 
                    }
                    Zbmp.Dispose();//释放资源 
                    draw.Dispose();
                    if (FilePath1 != "" && FExit1)
                        bmp1.Dispose();
                    if (FilePath2 != "" && FExit2)
                        bmp2.Dispose();
                    if (FilePath3 != "" && FExit3)
                        bmp3.Dispose();
                    return serverFileName;
                }
            }
            catch (Exception ex)
            {
                string ErrorLog = ConfigurationManager.AppSettings["ErrroLog"];  //错误日志记录路径
                string InsetFile = ErrorLog + @"\ComPicture" + DateTime.Now.ToLongDateString() + "Log.txt";
                StreamWriter InsertStream = new StreamWriter(InsetFile, true);
                InsertStream.WriteLine("合成照片时出错，当前时间为：" + DateTime.Now.ToString() + "，异常信息：" + ex.Message);
                InsertStream.Close();
                return "";
            }

            return "";
        }

        #endregion

        #region  合成4照片
        public static string MakewatermarkFour(string FilePath1, string FilePath2, string FilePath3, string FilePath4, string FileName)
        {
            try
            {
                string FileSave = AppConfig.FileSaveAddr;
                bool FExit1 = FilePath1 != "" ? File.Exists(FileSave + FilePath1) : false;
                bool FExit2 = FilePath2 != "" ? File.Exists(FileSave + FilePath2) : false;
                bool FExit3 = FilePath3 != "" ? File.Exists(FileSave + FilePath3) : false;
                bool FExit4 = FilePath4 != "" ? File.Exists(FileSave + FilePath4) : false;
                Bitmap bmp1 = null;
                Bitmap bmp2 = null;
                Bitmap bmp3 = null;
                Bitmap bmp4 = null;


                if (FilePath1 != "" && FExit1)
                {
                    bmp1 = new Bitmap(FileSave + FilePath1);//新建一个bmp图片
                }
                if (FilePath2 != "" && FExit2)
                {
                    bmp2 = new Bitmap(FileSave + FilePath2);//新建一个bmp图片 
                }
                if (FilePath3 != "" && FExit3)
                {
                    bmp3 = new Bitmap(FileSave + FilePath3);//新建一个bmp图片
                }
                if (FilePath4 != "" && FExit4)
                {
                    bmp4 = new Bitmap(FileSave + FilePath4);//新建一个bmp图片
                }

                if (FExit1 || FExit2 || FExit3 || FExit4)
                {
                    //int X = 800;
                    //int Y = 600;
                    int X = 1280;
                    int Y = 960;
                    Bitmap Zbmp = new Bitmap(X, Y, PixelFormat.Format16bppRgb555);//新建一个bmp图片 
                    //创建画布
                    Graphics draw = Graphics.FromImage(Zbmp);
                    //设置高质量插值法
                    draw.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    //设置高质量,低速度呈现平滑程度
                    draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //清空画布并以透明背景色填充

                    draw.Clear(Color.Snow);
                    //设置每个图片的大小和位置
                    if (FilePath1 != "" && FExit1)
                        draw.DrawImage(bmp1, 0, 0, 640, 480);
                    if (FilePath2 != "" && FExit2)
                        draw.DrawImage(bmp2, 640, 0, 640, 480);
                    if (FilePath3 != "" && FExit3)
                        draw.DrawImage(bmp3, 0, 480, 640, 480);
                    if (FilePath4 != "" && FExit4)
                        draw.DrawImage(bmp4, 640, 480, 640, 480);


                    //判断是否存在存在合成照片，如果不存在则创建

                    string dirPath = FileSave + GetUpLoadPath("Synthesis");   //上传图片所对应的文件夹
                    if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    string serverFileName = GetUpLoadPath("Synthesis") + FileName;

                    //判断是否存在存在合成照片，如果不存在则创建

                    FileInfo finfo = new FileInfo(FileSave + serverFileName);
                    if (finfo.Directory.Exists)
                    {
                        Zbmp.Save(FileSave + serverFileName, System.Drawing.Imaging.ImageFormat.Jpeg);//以jpg格式保存缩略图 
                    }
                    Zbmp.Dispose();//释放资源 
                    draw.Dispose();
                    if (FilePath1 != "" && FExit1)
                        bmp1.Dispose();
                    if (FilePath2 != "" && FExit2)
                        bmp2.Dispose();
                    if (FilePath3 != "" && FExit3)
                        bmp3.Dispose();
                    if (FilePath4 != "" && FExit4)
                        bmp4.Dispose();

                    return serverFileName;
                }
            }
            catch (Exception ex)
            {
                string ErrorLog = ConfigurationManager.AppSettings["ErrroLog"];  //错误日志记录路径
                string InsetFile = ErrorLog + @"\ComPicture" + DateTime.Now.ToLongDateString() + "Log.txt";
                StreamWriter InsertStream = new StreamWriter(InsetFile, true);
                InsertStream.WriteLine("合成照片时出错，当前时间为：" + DateTime.Now.ToString() + "，异常信息：" + ex.Message);
                InsertStream.Close();
                return "";
            }

            return "";
        }

        #endregion

        #region  复制一张照片，并重命名
        public static string CopNewPic(string FilePath, string FileName)
        {
            try
            {
                string FileSave = AppConfig.FileSaveAddr;
                string dirPath = FileSave + GetUpLoadPath("Synthesis");   //上传图片所对应的文件夹
                if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                {
                    Directory.CreateDirectory(dirPath);
                }

                string serverFileName = GetUpLoadPath("Synthesis") + FileName;

                File.Copy(FileSave + FilePath, FileSave + serverFileName, true);

                return serverFileName;
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region  私有方法

        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileType">上传文件类别</param>
        private static string GetUpLoadPath(string fileType)
        {
            string path = "/" + fileType + "/";//图片保存的文件夹
            if (fileType == "Synthesis")  //如果传的文件夹类型是Synthesis（合成照片）,则将图片保存到Synthesis下面的SJ文件夹下面。
            {
                path += "SJ/";
            }
            path += DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("dd");
            return path + "/";
        }

        /// <summary>
        /// 生成日期随机码

        /// </summary>
        /// <returns></returns>
        public static string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }

        #endregion




    }
}
