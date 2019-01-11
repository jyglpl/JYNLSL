using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Certificate;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Certificate;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class FileUploadController : BaseController
    {
        //
        // GET: /ZFYWCL/FileUpload/
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        readonly IllegalCaseAttachBll _illegalCaseAttachBll = new IllegalCaseAttachBll();      //附件材料
        readonly CertificateAttachBll _certificateAttachBll = new CertificateAttachBll(); //执法证附件
        /// <summary>
        /// 证据材料
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="evtache">证据环节</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult FilesTab(string resourceId, string evtache, string isupload, string isdeleted, string istime)
        {
            List<ComResourceEntity> lstResource = new List<ComResourceEntity>();
            string parentId = "";
            string fileTypeName = "";
            if (!string.IsNullOrEmpty(evtache))
            {
                if (evtache.Equals("case"))//受理上报附件
                {
                    parentId = "0052";
                    fileTypeName = "00520001";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("verify"))//核实认定
                {
                    parentId = "0032";
                    fileTypeName = "00320001";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("whthin"))//查档
                {
                    parentId = "0090";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("stop"))//停止违法行为通知书
                {
                    parentId = "0091";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("planning"))//规划认定
                {
                    parentId = "0088";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("remove"))//组织拆除
                {
                    parentId = "0087";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                #region 行政处罚
                else if (evtache.Equals("LASP"))//立案审批
                {
                    parentId = "0092";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("XWBL"))//当事人笔录或旁证笔录
                {
                    parentId = "0015";
                    fileTypeName = "00150007";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CHBG"))//测绘报告
                {
                    parentId = "0093";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("JTTL"))//集体讨论记录
                {
                    parentId = "0094";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("FZSHYJ"))//法制审核意见
                {
                    parentId = "0095";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CLSPYJ"))//处理审批意见
                {
                    parentId = "0096";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CFGZS"))//行政处罚告知书
                {
                    parentId = "0016";
                    fileTypeName = "00160002";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CFJDS"))//行政处罚决定书
                {
                    parentId = "0016";
                    fileTypeName = "00160004";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("XZQZS"))//申请行政强制文书
                {
                    parentId = "0008";
                    fileTypeName = "00080004";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CFCGS"))//履行行政处罚催告书
                {
                    parentId = "0097";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CFQZJDS"))//行政处罚强制决定书
                {
                    parentId = "0008";
                    fileTypeName = "00080004";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("CFQZCGS"))//履行行政处罚强制催告书
                {
                    parentId = "0098";
                    fileTypeName = "";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                else if (evtache.Equals("other"))//其他
                {
                    parentId = "0086";
                    fileTypeName = "00860001";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
                #endregion

            }
            //查询材料对应的附件
            if (!string.IsNullOrEmpty(resourceId) && lstResource.Any())
            {
                var filetypelist = (from type in lstResource where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _illegalCaseAttachBll.GetSearchResult(new IllegalCaseAttachEntity() { GL_RESOURCE_ID = resourceId }, filetypelist);
                ViewData["Files"] = files;
            }
            ViewBag.ControlId = evtache;
            ViewBag.Evtache = evtache;          //证据环节
            ViewBag.FileTypeName = fileTypeName;//附件类型
            ViewBag.ResourceId = resourceId;    //外键编号
            ViewBag.Isupload = isupload;        //是否可上传
            ViewBag.IsDeleted = isdeleted;      //是否可删除
            ViewBag.IsTime = istime;            //是否可上传时间
            return View("FilesTab");
        }

        /// <summary>
        /// 附件放大预览列表
        /// <param name="resourceId">外键编号</param>
        /// <param name="defaultPicId">默认显示图片ID</param>
        /// </summary>
        /// <returns></returns>
        public ActionResult FilesView(string resourceId, string defaultPicId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = _illegalCaseAttachBll.GetAllResult(new IllegalCaseAttachEntity() { GL_RESOURCE_ID = resourceId });
                ViewData["Files"] = files;
            }
            ViewBag.DefaultPicId = defaultPicId;
            return View();
        }


        /// <summary>
        /// 附件上传保存附件信息
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="fileAddress">附件保存地址</param>
        /// <param name="fileType">附件类型</param>
        /// <param name="fileTypeName">附件类型名称</param>
        /// <param name="remark">附件描述</param>
        /// <param name="fileName">上传时名称</param>
        /// <param name="fileReName">上传后重命名名称</param>
        /// <returns></returns>
        public string UpSaveImage(string resourceId, string fileAddress, string fileType, string fileTypeName, string remark, string fileName, string fileReName, string uploadTime)
        {
            try
            {
                var result = Guid.NewGuid().ToString();
                string fileSuffix = "";
                var num = fileAddress.LastIndexOf('.');
                if (num > 0)
                {
                    fileSuffix = fileAddress.Substring(fileAddress.LastIndexOf('.'));
                }
                var newFileReName = fileTypeName + GetFileCount(resourceId, fileTypeName) + fileSuffix;
                var newFileAddress = fileAddress.Replace(fileReName, "");
                newFileAddress = newFileAddress + resourceId + "/";
                if (!Directory.Exists(AppConfig.FileSaveAddr + newFileAddress))
                {
                    Directory.CreateDirectory(AppConfig.FileSaveAddr + newFileAddress);
                }
                newFileAddress = newFileAddress + newFileReName;
                FileInfo fileInfo = new FileInfo(AppConfig.FileSaveAddr + fileAddress);
                fileInfo.MoveTo(AppConfig.FileSaveAddr + newFileAddress);
                var sameId = Guid.NewGuid().ToString();
                var entity = new IllegalCaseAttachEntity()
                {
                    ID = result,
                    GL_RESOURCE_ID = resourceId,
                    FILE_NAME = fileName,
                    FILE_RENAME = newFileReName,
                    FILE_STATE = "",
                    ENCLOSURE_SIZE = "",
                    FILE_ADDRESS = newFileAddress,
                    EVIDENCE_DATE = !string.IsNullOrEmpty(uploadTime) ? Convert.ToDateTime(uploadTime) : Convert.ToDateTime("1900-01-01"),
                    ENCLOSURE_TYPE = fileType,
                    FILE_TYPE_NAME = fileTypeName,
                    REMARK = remark,
                    ROWSTATUS = (int)RowStatus.Normal,
                    CREATOR_ID = CurrentUser.CrmUser.Id,
                    CREATE_BY = CurrentUser.CrmUser.UserName,
                    CREATE_ON = DateTime.Now,
                    UPDATE_ID = CurrentUser.CrmUser.Id,
                    UPDATE_BY = CurrentUser.CrmUser.UserName,
                    UPDATE_ON = DateTime.Now
                };
                _illegalCaseAttachBll.InsertIllegalCaseAttach(entity);
                //生成缩略图
                //SaveThumbnail(resourceId, newFileAddress, fileType, fileTypeName, fileSuffix, newFileReName, sameId);
                result = result + "_" + AppConfig.FileViewLink + newFileAddress;
                return result;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// 获取材料数量
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="fileTypeName"></param>
        /// <returns></returns>
        public int GetFileCount(string resourceId, string fileTypeName)
        {
            var fileCount = 0;
            var getFileList = _illegalCaseAttachBll.GetAllResult(new IllegalCaseAttachEntity { GL_RESOURCE_ID = resourceId, FILE_TYPE_NAME = fileTypeName });
            if (getFileList.Any())
            {
                fileCount = getFileList.Count() + 1;
            }
            return fileCount;
        }

        /// <summary>
        /// 根据ID删除附件 图片 (缩略图)
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public JsonResult DeleteImgAttach(string fileId)
        {
            var isOk = 0;
            if (!string.IsNullOrEmpty(fileId))
            {
                isOk = _illegalCaseAttachBll.UpdateIllegalCaseAttach(fileId);
            }
            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 请求附件详情
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult FileDetails(string fileId)
        {
            var entity = new IllegalCaseAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = _illegalCaseAttachBll.searchEntity(fileId);
            }
            var result = new StatusModel<object>
            {
                rtState = 1,
                rtData = null,
                rtObj = entity,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <param name="remark">附件备注</param>
        /// <returns></returns>
        public JsonResult SaveFileDetails(string fileId, string remark)
        {
            var isOk = 0;
            if (!string.IsNullOrEmpty(fileId))
            {
                isOk = _illegalCaseAttachBll.UpdateRemark(fileId, remark);
            }
            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        public ActionResult FilesPicture(string Id, string userId)
        {
            ViewBag.Id = Id;
            ViewBag.userId = userId;
            string path = "";
            if (!string.IsNullOrEmpty(Id))
            {
                var list = _certificateAttachBll.GetSearchResult(new CertificateAttachEntity { ID = Id });
                if (list.Any())
                {
                    path = list[0].FILE_ADDRESS;
                }
            }
            ViewBag.paths = path;
            return View();
        }

        /// <summary>
        /// 上传图片至服务器
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string ReportFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string Id = Request["Id"];
                    string userId = Request["userId"];
                    Image image = Image.FromStream(file.InputStream);
                    byte[] byteArray = ImageToBytes(image);
                    var filename = CommonMethod.FileReName(file.FileName);
                    //调用WebService进行文件存储
                    var pictureService = new PictureService.PictureService(AppConfig.FileSaveServiceLink);
                    var filePath = pictureService.WritePictureSecond("Certificate", CommonMethod.FileReName(file.FileName), filename, byteArray);

                    //上传数据库附件表
                    var list = _certificateAttachBll.GetSearchResult(new CertificateAttachEntity { ID = Id, USER_ID = userId });
                    if (!list.Any())
                    {
                        var entity = new CertificateAttachEntity()
                        {
                            ID = Id,
                            USER_ID = userId,
                            FILE_NAME = filename,
                            FILE_ADDRESS = filePath,
                            ROWSTATUS = 1,
                            CREATOR_ID = CurrentUser.CrmUser.Id,
                            CREATE_BY = CurrentUser.CrmUser.UserName,
                            CREATE_ON = DateTime.Now,
                            UPDATE_ID = CurrentUser.CrmUser.Id,
                            UPDATE_BY = CurrentUser.CrmUser.UserName,
                            UPDATE_ON = DateTime.Now
                        };
                        _certificateAttachBll.InsertCertificateAttach(entity);
                    }
                    else
                    {
                        var entity = new CertificateAttachEntity()
                        {
                            ID = Id,
                            FILE_NAME = filename,
                            FILE_ADDRESS = filePath,
                        };
                        _certificateAttachBll.UpdateCertificateAttach(entity);
                    }
                }
                return "OK";
            }
            catch (Exception)
            {
                return "Error";
            }
        }


        /// <summary>
        /// image图片转byte[]字节
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// 删除执法证附件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public JsonResult DeleteCertificateAttach(string Pk_Id)
        {
            var isOk = 0;
            if (!string.IsNullOrEmpty(Pk_Id))
            {
                isOk = _certificateAttachBll.DeleteCertificateAttach(Pk_Id);
            }
            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
