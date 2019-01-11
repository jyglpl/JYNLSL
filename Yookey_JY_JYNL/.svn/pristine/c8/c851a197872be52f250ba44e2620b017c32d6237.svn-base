//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ImageHelper.cs">
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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class ImageHelper
    {
        /// <summary>
        /// 上传本地图片（包含缩略图），上传自动加上（/年/月/日/）文件夹
        /// 默认生成缩略图98*98，300*300
        /// 根据缩略图的宽和高，按照比例裁剪
        /// </summary>
        /// <param name="originalImagePath">原文件路径</param>
        /// <param name="imageTargetFolderPath">上传目标路径</param>
        /// <param name="newImgName">新图片名称</param>
        /// <returns>保存路径</returns>
        public UploadFileResult UploadForLocalThumbnail(string originalImagePath, string imageTargetFolderPath, string newImgName)
        {
            var imgParam = ConfigurationManager.AppSettings["ImgConfig"];
            if (imgParam != null)
            {
                var aryParam = imgParam.Split('|').Select(param => new UploadThumbnailImageParam
                                                                       {
                                                                           ImgWidth = ConvertHelper.ConvertToInt(param.Split('*')[0], 0),
                                                                           ImgHeight = ConvertHelper.ConvertToInt(Convert.ToInt32(param.Split('*')[1]), 0),
                                                                           ImgMode = param.Split('*')[2]
                                                                       }).ToList();
                return UploadYearFolderForLocal(originalImagePath, imageTargetFolderPath, aryParam, newImgName);
            }
            return null;
        }

        /// <summary>
        /// 上传本地图片，上传自动加上（/年/月/日/）文件夹
        /// </summary>
        /// <param name="originalImagePath">原文件路径</param>
        /// <param name="imageTargetFolderPath">上传目标路径</param>
        /// <param name="aryParam">缩略图集合 HW:指定高宽缩放；W:指定宽，高按比例；H:指定高，宽按比例；Cat:根据缩略图宽和高按比例裁剪</param>
        /// <param name="newImgName">新图片名称</param>
        /// <returns>保存路径</returns>
        public UploadFileResult UploadYearFolderForLocal(string originalImagePath, string imageTargetFolderPath, List<UploadThumbnailImageParam> aryParam, string newImgName)
        {
            var result = new UploadFileResult();
            try
            {
                if (string.IsNullOrEmpty(originalImagePath) || string.IsNullOrEmpty(imageTargetFolderPath))
                {
                    result.HasError = true;
                    result.ErrorMessage = "获取图片异常";
                    return result;
                }

                // ReSharper disable PossibleNullReferenceException
                string extention = Path.GetExtension(originalImagePath).ToLower();
                // ReSharper restore PossibleNullReferenceException

                result.HasError = false;
                result.RelativeFilePath = imageTargetFolderPath + newImgName + extention;
                result.AbsoluteFilePath = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + imageTargetFolderPath + newImgName + extention;

                //生成缩略图
                if (aryParam != null)
                {
                    foreach (UploadThumbnailImageParam imgParam in aryParam)
                    {
                        if (imgParam != null)
                        {
                            //缩略图以原图的名称后加上宽高来命名
                            string thumbnailImgName = newImgName + "_" + imgParam.ImgWidth + "_" + imgParam.ImgHeight + extention;
                            MakeThumbnail(originalImagePath, System.Web.HttpContext.Current.Server.MapPath(imageTargetFolderPath) + thumbnailImgName, imgParam.ImgWidth, imgParam.ImgHeight, imgParam.ImgMode, extention);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                result.HasError = true;
                result.ErrorMessage = e.ToString();
            }
            return result;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        /// <param name="extention">图片后缀名</param> 
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, string extention)
        {
            var originalImage = Image.FromFile(originalImagePath);
            var towidth = width;
            var toheight = height;

            var x = 0;
            var y = 0;
            var ow = originalImage.Width;
            var oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if (originalImage.Width / (double)originalImage.Height > towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                case "DB"://等比缩放（不变形，如果高大按高，宽大按宽缩放） 
                    if (originalImage.Width / (double)towidth < originalImage.Height / (double)toheight)
                    {
                        toheight = height;
                        towidth = originalImage.Width * height / originalImage.Height;
                    }
                    else
                    {
                        towidth = width;
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            Image bitmap = new Bitmap(towidth, toheight);

            //新建一个画板
            var g = Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

            try
            {
                //保存缩略图
                switch (extention)
                {
                    case ".jpg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".bmp":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".gif":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case ".png":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".icon":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Icon);
                        break;
                }
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /**/
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="path">原服务器图片路径</param>
        /// <param name="pathSy">生成的带文字水印的图片路径</param>
        protected void AddShuiYinWord(string path, string pathSy)
        {
            const string addText = "测试水印";
            var image = Image.FromFile(path);
            var g = Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            var f = new Font("Verdana", 16);
            Brush b = new SolidBrush(Color.Blue);

            g.DrawString(addText, f, b, 15, 15);
            g.Dispose();

            image.Save(pathSy);
            image.Dispose();
        }

        /**/

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="path">原服务器图片路径</param>
        /// <param name="pathSyp">生成的带图片水印的图片路径</param>
        /// <param name="shuiYinStr">水印内容</param>
        public void AddShuiYinPic(string path, string pathSyp, string shuiYinStr)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            //System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            //g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            //g.Dispose();

            //image.Save(Path_syp);
            //image.Dispose();


            //paramodel = new SiteParametersRule().GetSiteParametersByCodeName("SetUploadImg", "水印文字");
            Image simage = Image.FromFile(path);
            Graphics g = Graphics.FromImage(simage);
            g.DrawImage(simage, 0, 0, simage.Width, simage.Height);
            int xSize = 0;
            int ySize = 0;
            string addText = shuiYinStr;
            int fontSize = 0;
            int fontLen = addText.Length;
            int imgAra = simage.Width * simage.Height;
            if (imgAra > 0 && imgAra < 90000)
            {
                fontSize = 14;
                xSize = fontLen * 14;
                ySize = 15;
            }
            else if (imgAra > 90000 && imgAra < 160000)
            {
                fontSize = 20;
                xSize = fontLen * 25;
                ySize = 24;
            }
            else if (imgAra > 160000 && imgAra < 640000)
            {
                fontSize = 28;
                xSize = fontLen * 35;
                ySize = 30;
            }
            else if (imgAra > 640000)
            {
                fontSize = 36;
                xSize = fontLen * 50;
                ySize = 85;
            }
            var f = new Font("黑体", fontSize);
            Brush b = new SolidBrush(Color.Black);
            //string addText = SiteInfo.GetAddText();//从siteInfo.config获取水印内容
            g.DrawString(addText, f, b, simage.Width - xSize - 45, simage.Height - ySize - 20);
            g.Dispose();
            simage.Save(pathSyp);
            simage.Dispose();//保存后删除水印前的文件
            File.Delete(path);
        }


        #region 图片旋转函数


        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="pathFile">图片路径</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <returns></returns>
        public static bool RotateImg(string pathFile, int angle)
        {
            var bitmap = new Bitmap(pathFile);
            return Rotate(bitmap, angle, pathFile);
        }

        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <param name="pathFile">保存后文件的绝对路径</param>
        /// <returns></returns>
        public static bool Rotate(Bitmap b, int angle, string pathFile)
        {
            try
            {
                angle = angle % 360;
                //弧度转换
                double radian = angle * Math.PI / 180.0;
                double cos = Math.Cos(radian);
                double sin = Math.Sin(radian);
                //原图的宽和高
                int w = b.Width;
                int h = b.Height;
                int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
                int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
                //目标位图
                Bitmap dsImage = new Bitmap(W, H);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //计算偏移量
                Point Offset = new Point((W - w) / 2, (H - h) / 2);
                //构造图像显示区域：让图像的中心与窗口的中心点一致
                Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform(360 - angle);
                //恢复图像在水平和垂直方向的平移
                g.TranslateTransform(-center.X, -center.Y);
                g.DrawImage(b, rect);
                //重至绘图的所有变换
                g.ResetTransform();
                g.Save();
                g.Dispose();
                b.Dispose();
                dsImage.Save(pathFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }


        public static Bitmap RotateImage(Bitmap image, float rotateAtX, float rotateAtY, float angle, bool bNoClip)
        {
            int W, H, X, Y;
            if (bNoClip)
            {
                double dW = (double)image.Width;
                double dH = (double)image.Height;

                double degrees = Math.Abs(angle);
                if (degrees <= 90)
                {
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dH * dSin + dW * dCos);
                    H = (int)(dW * dSin + dH * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                }
                else
                {
                    degrees -= 90;
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dW * dSin + dH * dCos);
                    H = (int)(dH * dSin + dW * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                }
            }
            else
            {
                W = image.Width;
                H = image.Height;
                X = 0;
                Y = 0;
            }

            //create a new empty bitmap to hold rotated image
            Bitmap bmpRet = new Bitmap(W, H);
            bmpRet.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(bmpRet);

            //Put the rotation point in the "center" of the image
            g.TranslateTransform(rotateAtX + X, rotateAtY + Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-rotateAtX - X, -rotateAtY - Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0 + X, 0 + Y));

            return bmpRet;
        }

        #endregion 图片旋转函数

        /// <summary>
        /// 验证码生成类
        /// </summary>
        public class VerificationCodeHelper
        {
            /// <summary>
            /// 生成验证码
            /// </summary>
            /// <returns></returns>
            public static string GenerateCheckCode()
            {  //产生四位的随机字符串
                char code;
                var checkCode = String.Empty;

                var random = new Random();

                for (var i = 0; i < 4; i++)
                {
                    var number = random.Next();
                    code = (char)('0' + (char)(number % 10));
                    checkCode += code.ToString();
                }
                return checkCode;
            }

            public static FileContentResult CreateCheckCodeImage(string checkCode)
            {  //将验证码生成图片显示
                if (checkCode == null || checkCode.Trim() == String.Empty)
                    return null;
                var image = new Bitmap(55, 20);
                var g = Graphics.FromImage(image);

                try
                {
                    //生成随机生成器 
                    var random = new Random();

                    //清空图片背景色 
                    g.Clear(Color.White);

                    //画图片的背景噪音线 
                    for (int i = 0; i < 8; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int x2 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);
                        int y2 = random.Next(image.Height);

                        g.DrawLine(new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255))
                                       ), x1, y1, x2, y2);
                    }

                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                    List<FontStyle> a = GetColorList;
                    for (int i = 0; i < checkCode.Length; i++)
                    {
                        var ftyle = GetColor(a);
                        var font = new Font("Verdana", ftyle.FontSize, (System.Drawing.FontStyle.Bold));
                        var brush = new SolidBrush(ftyle.FontColor);
                        g.DrawString(checkCode.Substring(i, 1), font, brush, GetCodeRect(i), sf);
                    }
                    //画图片的边框线 
                    g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    g.Dispose();
                    image.Dispose();
                    return new FileContentResult(ms.GetBuffer(), "image/JPEG");
                }
                finally
                {
                    g.Dispose();
                    image.Dispose();
                }
            }

            /// <summary>
            /// 从颜色列表中随机选取颜色
            /// </summary>
            /// <param name="colorL"></param>
            /// <returns></returns>
            private static FontStyle GetColor(List<FontStyle> colorL)
            {
                var rnd = new Random();
                int i = rnd.Next(0, colorL.Count);
                FontStyle l = colorL[i];
                colorL.RemoveAt(i);
                return l;
            }

            /// <summary>
            /// 获取颜色列表
            /// </summary>
            private static List<FontStyle> GetColorList
            {
                get
                {
                    var a = new List<FontStyle>(4)
                            {
                                new FontStyle(Color.Red, 12),
                                new FontStyle(Color.Green, 12),
                                new FontStyle(Color.Blue, 12),
                                new FontStyle(Color.Black, 12)
                            };
                    return a;
                }
            }

            /// <summary>
            /// 获取单个字符的绘制区域
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns></returns>
            public static Rectangle GetCodeRect(int index)
            {
                // 计算一个字符应该分配有多宽的绘制区域（等分为CodeLength份）
                const int subWidth = 55 / 4;
                // 计算该字符左边的位置
                int subLeftPosition = subWidth * index;

                return new Rectangle(subLeftPosition + 1, 1, subWidth, 20);
            }

            public static string GetIpAddress()
            {
                System.Net.IPHostEntry ips = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                if (ips.AddressList.Count() > 0)
                {
                    return ips.AddressList[0].ToString();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 字体类
        /// </summary>
        public class FontStyle
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="fontColor">颜色</param>
            /// <param name="fontSize">字体大小</param>
            public FontStyle(Color fontColor, int fontSize)
            {
                FontColor = fontColor;
                FontSize = fontSize;
            }
            #region "Private Variables"

            #endregion

            #region "Public Variables"

            /// <summary>
            /// 字体颜色
            /// </summary>
            public Color FontColor { get; set; }

            /// <summary>
            /// 字体大小
            /// </summary>
            public int FontSize { get; set; }

            #endregion
        }
    }

    #region 上传缩略图参数
    /// <summary>
    /// 上传缩略图片参数
    /// </summary>
    public class UploadThumbnailImageParam
    {
        #region 成员

        #endregion

        #region 构造函数
        public UploadThumbnailImageParam()
        {
            ImgWidth = 0;
            ImgHeight = 0;
            ImgMode = string.Empty;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 图片宽带
        /// </summary>
        public int ImgWidth { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int ImgHeight { get; set; }

        /// <summary>
        /// 图片模式，HW:指定高宽缩放；W:指定宽，高按比例；H:指定高，宽按比例；Cat:根据缩略图宽和高按比例裁剪
        /// </summary>
        public string ImgMode { get; set; }

        #endregion
    }
    #endregion

    #region 上传文件结果
    /// <summary>
    /// 上传文件返回值
    /// </summary>
    public class UploadFileResult
    {
        #region 成员

        public UploadFileResult()
        {
            ErrorMessage = string.Empty;
            HasError = false;
            RelativeFilePath = string.Empty;
            AbsoluteFilePath = string.Empty;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 绝对路径
        /// </summary>
        public string AbsoluteFilePath { get; set; }

        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativeFilePath { get; set; }

        /// <summary>
        /// 是否发生错误
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion
    }
}
    #endregion

