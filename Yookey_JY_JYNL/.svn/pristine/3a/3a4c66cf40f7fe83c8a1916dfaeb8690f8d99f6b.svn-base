using System;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Common;
using System.Web.Services;
using System.Drawing;
using System.Drawing.Imaging;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;
using Yookey.WisdomClassed.SIP.Business.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class UploadController : BaseController
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
            if (!result.Equals(3)) return defaulturl;
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

            var urlpath = string.Format(@"/{0}/{1}/{2}/", folderName.Equals("PetitionReply") ? "Petition" : folderName, DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
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

                if (folderName.Equals("PetitionReply"))   //只有信访投诉回复内容上传
                {
                    folderName = "Petition";
                    const string wordFileExt = "*.doc;*.docx;";

                    var user = CurrentUser.CrmUser;

                    //验证是否是Work文件并且是局机关上传附件，自动增加“倪局”的签名
                    //局机关ID：f31af89b-d6d3-4c37-8864-f1a29313173a，（上传意见的科室为信访科，所属局机关）TODO：这里先写固定值用于判断，后续可根据权限来控制
                    if (wordFileExt.Contains(wordFileExt) && user.CompanyId.Equals("f31af89b-d6d3-4c37-8864-f1a29313173a") && user.DeptId.Equals("79ea38c2-2ee7-487c-8f30-96a8f53e0ceb"))
                    {
                        var newId = Guid.NewGuid().ToString();
                        var fileReName = newId + extension; //重命名
                        postedFile.SaveAs(dirpath + fileReName); //存储至服务器

                        var addSignFileReName = Guid.NewGuid().ToString() + extension; //新的文件名称
                        //添加签名
                        var isOk = new InfWritBll().AddLeaderSign(dirpath + fileReName, dirpath + addSignFileReName);

                        if (isOk)
                        {
                            //原始文件（未添加签名的文件）
                            FileStream originalStream = new FileInfo(dirpath + fileReName).OpenRead();
                            byte[] originalFileData = new byte[originalStream.Length + 1];
                            originalStream.Read(originalFileData, 0, Convert.ToInt32(originalStream.Length));
                            originalStream.Close();

                            //调用服务进行存储
                            var originalFilePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond(folderName, CommonMethod.FileExt(postedFile.FileName), fileReName, originalFileData);


                            //增加签名后的文件
                            FileStream stream = new FileInfo(dirpath + addSignFileReName).OpenRead();
                            byte[] fileData = new byte[stream.Length + 1];
                            stream.Read(fileData, 0, Convert.ToInt32(stream.Length));
                            stream.Close();

                            //调用WebService进行文件存储
                            var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond(folderName, CommonMethod.FileExt(postedFile.FileName), addSignFileReName, fileData);

                            //删除添加签名后的文件
                            System.IO.File.Delete(dirpath + addSignFileReName);
                            //删除原始文件
                            System.IO.File.Delete(dirpath + fileReName);

                            //文件预览路径|文件虚拟路径|文件名称|文件重命名后名称|文件增加签名后的名称
                            return returntype.Equals(1) ? string.Format("{0}{1}", urlpath, filename) : string.Format("{0}|{1}|{2}|{3}|{4}", (AppConfig.FileViewLink + originalFilePath), originalFilePath, postedFile.FileName, filename, filePath);
                        }
                    }
                    else
                    {
                        filename = CommonMethod.FileReName(postedFile.FileName);   //重新生成命称

                        var stream = postedFile.InputStream;
                        var bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, bytes.Length);
                        var imageData = bytes;

                        //调用WebService进行文件存储.FileExt(postedFile.FileName) AppConfig.FileSaveServiceLink
                        var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond(folderName, CommonMethod.FileExt(postedFile.FileName), filename, imageData);
                        return returntype.Equals(1) ? string.Format("{0}{1}", urlpath, filename) : string.Format("{0}|{1}|{2}|{3}", (AppConfig.FileViewLink + filePath), filePath, postedFile.FileName, filename);
                    }
                }
                else
                {
                    filename = CommonMethod.FileReName(postedFile.FileName);   //重新生成命称

                    var stream = postedFile.InputStream;
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    var imageData = bytes;

                    //调用WebService进行文件存储.FileExt(postedFile.FileName) AppConfig.FileSaveServiceLink
                    var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond(folderName, CommonMethod.FileExt(postedFile.FileName), filename, imageData);
                    return returntype.Equals(1) ? string.Format("{0}{1}", urlpath, filename) : string.Format("{0}|{1}|{2}|{3}", (AppConfig.FileViewLink + filePath), filePath, postedFile.FileName, filename);
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// 仅仅只是上传文件
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="gmId">网格分类ID</param>
        /// <returns></returns>
        public string LedgerFileUpload(string folderName, string gmId)
        {
            var urlpath = string.Format(@"/{0}/{1}{2}/{3}/", folderName, DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"), DateTime.Now.Day.ToString("d2"));
            var dirpath = AppConfig.FileSaveAddr + urlpath;
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            try
            {
                var postedFile = System.Web.HttpContext.Current.Request.Files["Filedata"];
                if (postedFile == null)
                {
                    return string.Empty;
                }
                var filename = postedFile.FileName.ToLower();
                var extension = "";
                if (filename.Contains("."))
                {
                    extension = filename.Substring(filename.LastIndexOf('.')).Length > 0 ? filename.Substring(filename.LastIndexOf('.')) : "";
                }
                extension = extension.ToLower();
                const string fileExt = "*.jpg;*.jpeg;*.gif;*.png;*.rar;*.zip;*.doc;*.docx;*.xls;*.xlsx;*.ppt;.*.pdf;";   //可上传文件后缀
                const string toPdfFileExt = "*.doc;*.docx;*.xls;*.xlsx;";   //需要转换成PDF文件格式

                const string wordFileExt = "*.doc;*.docx;";   //需要转换成PDF文件格式
                const string excelFileExt = "*.xls;*.xlsx;";   //需要转换成PDF文件格式

                var returnFileName = "";   //返回文件名称
                var returnFileAddress = ""; //返回文件存储路径
                var returnConvertFileAddress = "";    //返回转换后的文件存储路径

                if (fileExt.Contains(extension))
                {
                    if (!System.IO.File.Exists(filename))
                    {
                        var newId = Guid.NewGuid().ToString();
                        var fileReName = newId + extension;   //重命名

                        postedFile.SaveAs(dirpath + fileReName);   //存储至服务器

                        var isToPdf = toPdfFileExt.Contains(extension);  //是否需要将文件转换成PDF
                        if (isToPdf)
                        {
                            #region 将文件转换成PDF

                            var flag = false;
                            var filePdfName = newId + ".pdf";
                            if (wordFileExt.Contains(extension))
                            {
                                flag = ConvertHelper.ConvertWordToPdf(dirpath + fileReName, dirpath + filePdfName);
                            }
                            else if (excelFileExt.Contains(extension))
                            {
                                flag = ConvertHelper.ConvertExcelToPdf(dirpath + fileReName, dirpath + filePdfName);
                            }

                            if (flag) //转换成功
                            {
                                FileStream stream = new FileInfo(dirpath + filePdfName).OpenRead();
                                byte[] fileData = new byte[stream.Length + 1];
                                stream.Read(fileData, 0, Convert.ToInt32(stream.Length));
                                stream.Close();

                                //调用服务存储文件
                                var filePath =
                                    new PictureService.PictureService(AppConfig.LedgerFileServiceLink).WriteFile(
                                        folderName, filePdfName, extension, fileData);

                                //原始上传文件流
                                var streamOriginal = postedFile.InputStream;
                                var originalFileData = new byte[streamOriginal.Length];
                                streamOriginal.Read(originalFileData, 0, originalFileData.Length);
                                streamOriginal.Close();

                                //调用服务存储文件
                                filePath =
                                    new PictureService.PictureService(AppConfig.LedgerFileServiceLink).WriteFile(
                                        folderName, fileReName, extension, originalFileData);

                                //删除PDF文件
                                System.IO.File.Delete(dirpath + filePdfName);
                                //删除原始文件
                                System.IO.File.Delete(dirpath + fileReName);

                                returnConvertFileAddress = urlpath + filePdfName;
                            }

                            returnFileName = filename;
                            returnFileAddress = urlpath + fileReName;

                            #endregion
                        }
                        else
                        {
                            //原始上传文件流
                            var streamOriginal = postedFile.InputStream;
                            var originalFileData = new byte[streamOriginal.Length];
                            streamOriginal.Read(originalFileData, 0, originalFileData.Length);
                            streamOriginal.Close();

                            //调用服务存储文件
                            var filePath =
                                new PictureService.PictureService(AppConfig.LedgerFileServiceLink).WriteFile(
                                    folderName, fileReName, extension, originalFileData);

                            returnFileName = filename;
                            returnFileAddress = urlpath + fileReName;

                            //删除原始文件
                            System.IO.File.Delete(dirpath + fileReName);
                        }

                        return string.Format("{0}|{1}|{2}", returnFileName, returnFileAddress, returnConvertFileAddress);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                //return string.Empty;
                return ex.Message;
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

        #region 上传图片
        /// <summary>
        /// 上传图片（用于课件封面）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-15
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string UploadImageFor()
        {
            try
            {
                var file = Request.Files[0];
                var uploadPath = AppConfig.OnlineClassFileSave;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //生成根据当天的文件夹
                var wenjianjia = DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(uploadPath + "/" + wenjianjia))
                {
                    Directory.CreateDirectory(uploadPath + "/" + wenjianjia);
                }
                if (file != null)
                {
                    var fileName = file.FileName; //获取上传文件的文件名,包括后缀
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\", StringComparison.Ordinal) + 1);

                    var extenName = Path.GetExtension(fileName); //获取扩展名
                    var newName = Guid.NewGuid().ToString().Replace("-", "");
                    var saveFileName = Path.Combine(uploadPath + "/" + wenjianjia, newName + extenName);

                    //合并两个路径为上传到服务器上的全路径
                    file.SaveAs(saveFileName);
                    var uploadfilename = "/" + wenjianjia + "/" + newName + extenName;

                    var id = Guid.NewGuid().ToString();

                    var upresult = new UploadResult
                    {
                        ResourceId = id,
                        FileName = fileName,
                        FileNewName = newName,
                        SaveAddress = uploadfilename,
                        ViewAddress = AppConfig.OnlineClassFileUrl + uploadfilename,
                        Status = "success"
                    };

                    var user = CurrentUser.CrmUser;
                    //数据保存
                    var attachment = new OnlineClassAttachmentEntity
                    {
                        Id = id,
                        ResourceId = "",
                        FileName = fileName,
                        FileReName = newName,
                        FileAddress = uploadfilename,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };

                    //将附件保存至数据库
                    new OnlineClassAttachmentBll().Insert(attachment);

                    return JsonConvert.SerializeObject(upresult);
                }
                return JsonConvert.SerializeObject(new UploadResult { Status = "error" });
            }
            catch
            {
                return JsonConvert.SerializeObject(new UploadResult { Status = "error" });
            }
        }
        #region 上传结果类
        /// <summary>
        /// 上传结果类
        /// </summary>
        public class UploadResult
        {
            /// <summary>
            /// 资料编号
            /// </summary>
            public string ResourceId { get; set; }

            /// <summary>
            /// 文档名称（原始名称）
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// 文件新名称
            /// </summary>
            public string FileNewName { get; set; }

            /// <summary>
            /// 保存地址
            /// </summary>
            public string SaveAddress { get; set; }

            /// <summary>
            /// 预览地址
            /// </summary>
            public string ViewAddress { get; set; }

            /// <summary>
            /// 上传状态
            /// </summary>
            public string Status { get; set; }
        }
        #endregion 
        #endregion

        /// <summary>
        /// 用于uploadify 上传
        /// 添加人：周 鹏
        /// 添加时间：2014-11-15
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="folder">无用</param>
        /// <param name="returntype">无用</param>
        /// <param name="zip">无用</param>
        /// <returns></returns>
        public string UploadFile(string resourceId, string folder, string fileTypeName, bool zip = false)
        {
            try
            {
                var postedFile = System.Web.HttpContext.Current.Request.Files["Filedata"];
                if (postedFile == null)
                {
                    return string.Empty;
                }
                var filename = postedFile.FileName;

                var newFilename = CommonMethod.FileReName(filename);   //重新生成命称
                Stream fileStream = postedFile.InputStream;
                byte[] fileData = null;
                int fileLength = postedFile.ContentLength;
                fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);

                var filePath = UploadFileCommon.WriteFile(folder, CommonMethod.FileExt(filename), newFilename, fileData);

                if (!Directory.Exists(AppConfig.FileSaveAddr + folder))
                {
                    Directory.CreateDirectory(AppConfig.FileSaveAddr + folder);
                }
                if (postedFile != null)
                {
                    var fileName = postedFile.FileName;
                    var extenName = Path.GetExtension(fileName); //获取扩展名
                    var newName = Guid.NewGuid().ToString().Replace("-", "");
                    var user = CurrentUser.CrmUser;
                    //数据保存
                    var attachment = new OnlineClassAttachmentEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        ResourceId = resourceId,
                        FileName = fileName,
                        FileReName = newName,
                        FileAddress = filePath,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };
                    //将附件保存至数据库
                    new OnlineClassAttachmentBll().Insert(attachment);

                    return JsonConvert.SerializeObject(new
                    {
                        RtMsrg = "成功",
                        RtState = 1,
                        AttachmentId = attachment.Id,
                        FileAddress = filePath,
                        FileViewLink = AppConfig.FileViewLink + filePath,
                        FileName = fileName,
                        FileReName = newName,
                        FileLength = (postedFile.ContentLength / 1024f / 1024f).ToString("0.00") + "MB",
                        ExtenName = extenName
                    });
                }
                return JsonConvert.SerializeObject(new
                {
                    RtMsrg = "失败！",
                    RtState = 0,
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    RtMsrg = "失败！",
                    RtState = 0,
                });
            }
        }
        
    }
}