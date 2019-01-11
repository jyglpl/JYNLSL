using System;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Common;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class SIPUploadController : Controller
    {

        //
        // GET: /Upload/
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="folderName">对应的文件夹</param>
        /// <returns></returns>
        public string PicUpload(string folderName)
        {
            const string defaulturl = "/Avatar/userImg.jpg";
            return System.Web.HttpContext.Current.Request.Files["Filedata"] == null ? defaulturl : FileUpload(folderName);
        }


        public string PicWTUpload(string folderName)
        {
            const string defaulturl = "/Avatar/userImg.jpg";
            return System.Web.HttpContext.Current.Request.Files["Filedata"] == null ? defaulturl : FileWTUpload(folderName);
            //return "{msg: 1, msbox: \"" + resylt + "\"}";
        }
        //"{msg: 1, msbox: \"" + returnFileName + "\"}";

        // GET: /Upload/
        /// <summary>
        /// 上传图片和缩略图
        /// </summary>
        /// <param name="folderName">对应的文件夹</param>
        /// <returns></returns>
        public string ThumbnailUpload(string folderName)
        {
            const string defaulturl = "/Avatar/userImg.jpg";
            if (System.Web.HttpContext.Current.Request.Files["Filedata"] == null)
            {
                return defaulturl;
            }
            var result = FileUpload(folderName, 2).Split('|');
            //if (!result.Equals(3)) return defaulturl;
            var thfileName = result[2].Substring(0, result[2].IndexOf('.'));
            new ImageHelper().UploadForLocalThumbnail(result[0] + result[2], result[1], thfileName);//上传缩略图
            return string.Format("{0}{1}", result[2], result[1]);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="folderName">上传文件夹名称</param>
        /// <param name="returntype">返回类型(1:返回文件URL 2:返回附件预览地址|文件URL(url)|原始名称|重命名后名称</param>
        /// <param name="zip">是否需要压缩文件(1:是 0:否)</param>
        /// <returns></returns>
        public string FileUpload(string folderName, int returntype = 2, bool zip = false)
        {
            var urlpath = string.Format(@"/{0}/{1}/{2}/", folderName, DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
            var dirpath = AppConfig.FileSaveAddr + urlpath;
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            var postedFile = System.Web.HttpContext.Current.Request.Files["Filedata"];
            if (postedFile == null)
            {
                return string.Empty;
            }
            var filename = postedFile.FileName;
            var extension = "";
            if (filename.Contains("."))
            {
                extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                ? filename.Substring(filename.LastIndexOf('.'))
                                : "";
            }
            extension = extension.ToLower();
            const string fileExt = "*.jpg;*.jpeg;*.gif;*.png;*.rar;*.zip;*.doc;*.docx;*.xls;*.xlsx;*.ppt;.*.pdf;";
            if (fileExt.Contains(extension))
            {
                filename = GetFileName(postedFile.FileName.ToLower());
                postedFile.SaveAs(dirpath + filename);
                if (zip && !filename.Contains(".zip") && !filename.Contains(".rar"))
                {
                    var zipfilename = String.Format("{0}.zip", filename.Substring(0, filename.LastIndexOf(".")));
                    ZipHelper.CreateZipFile(dirpath + filename, dirpath + zipfilename);
                    System.IO.File.Delete(dirpath + filename);
                    filename = zipfilename;
                }
                return returntype.Equals(1) ? string.Format("{0}{1}", urlpath, filename) : string.Format("{0}|{1}|{2}|{3}", (AppConfig.FileViewLink + urlpath + filename), urlpath + filename, postedFile.FileName, filename);
            }
            return string.Empty;
        }

        /// <summary>
        /// 仅仅只是上传文件
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public string FileUploadOnly(string folderName)
        {
            var dirpath = AppConfig.FileSaveAddr + folderName;
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            var postedFile = System.Web.HttpContext.Current.Request.Files["Filedata"];
            if (postedFile == null)
            {
                return string.Empty;
            }
            var filename = postedFile.FileName.ToLower();
            var extension = "";
            if (filename.Contains("."))
            {
                extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                ? filename.Substring(filename.LastIndexOf('.'))
                                : "";
            }
            extension = extension.ToLower();
            const string fileExt = "*.jpg;*.jpeg;*.gif;*.png;*.rar;*.zip;*.doc;*.docx;*.xls;*.xlsx;*.ppt;.*.pdf;";
            if (fileExt.Contains(extension))
            {

                if (!System.IO.File.Exists(filename))
                {
                    postedFile.SaveAs(dirpath + filename);
                    return string.Format("{0}{1}", folderName, filename);
                }
                else
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        private static string GetFileName(string filename)
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

        public string UploadImage()
        {
            try
            {
                var file = Request.Files[0];
                string uploadfilename = "";
                string uploadPath = Server.MapPath("~/User/images/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //生成根据当天的文件夹
                string wenjianjia = DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(uploadPath + "/" + wenjianjia))
                {
                    Directory.CreateDirectory(uploadPath + "/" + wenjianjia);
                }
                if (file != null)
                {
                    string fileName = file.FileName; //获取上传文件的文件名,包括后缀
                    string extenName = Path.GetExtension(fileName); //获取扩展名
                    string newName = Guid.NewGuid().ToString().Replace("-", "");
                    string saveFileName = Path.Combine(uploadPath + "/" + wenjianjia, newName + extenName);
                    //合并两个路径为上传到服务器上的全路径
                    file.SaveAs(saveFileName);
                    uploadfilename = "/" + wenjianjia + "/" + newName + extenName;
                }
                return JsonConvert.SerializeObject(uploadfilename);
            }
            catch
            {
                return JsonConvert.SerializeObject("error");
            }
        }

        #region 违停数据上传
        public string FileWTUpload(string folderName, int returntype = 2, bool zip = false)
        {
            try
            {
                var urlpath = string.Format(@"/{0}/{1}/{2}/", folderName, DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
                var dirpath = AppConfig.FileSaveAddr + urlpath;
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
                var postedFile = System.Web.HttpContext.Current.Request.Files["Filedata"];
                if (postedFile == null)
                {
                    return string.Empty;
                }
                var filename = GetFileName(postedFile.FileName.ToLower());
                postedFile.SaveAs(dirpath + filename);
                if (zip && !filename.Contains(".zip") && !filename.Contains(".rar"))
                {
                    var zipfilename = String.Format("{0}.zip", filename.Substring(0, filename.LastIndexOf(".")));
                    ZipHelper.CreateZipFile(dirpath + filename, dirpath + zipfilename);
                    System.IO.File.Delete(dirpath + filename);
                    filename = zipfilename;
                }
                string ss = "{\"State\":\"1\",\"LinkUrl\":\"" + AppConfig.FileViewLink + urlpath + filename + "\",\"OldFileName\":\"" + postedFile.FileName + "\",\"NewFileName\":\"" + filename + "\",\"SaveUrl\":\"" + urlpath + filename + "\"}";

                return ss;
            }
            catch (Exception)
            {

                return "{\"State\":\"0\"}";
            }
        }


        #endregion

    }
}