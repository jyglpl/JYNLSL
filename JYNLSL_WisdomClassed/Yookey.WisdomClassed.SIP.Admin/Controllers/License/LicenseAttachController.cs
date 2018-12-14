using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.License;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Admin.Models;
using System.IO;
using Yookey.WisdomClassed.SIP.Common;
namespace Yookey.WisdomClassed.SIP.Admin.Controllers.License
{
    public class LicenseAttachController : BaseController
    {
        //
        // GET: /LicenseAttach/
        private LicenseAttachBll _bll = new LicenseAttachBll();
                
        public ActionResult Photograph()
        {
            return View();
        }

        /// <summary>
        /// 拍照上传
        /// </summary>
        /// <param name="resourceId">关联案件编号</param>
        /// <param name="fileType">材料目录</param>
        /// <returns></returns>
        [HttpGet]        
        public ActionResult Photograph(string resourceId, string fileType)
        {
            return View();
        }

        [HttpPost]
        public string UpLoadImage(string imageData, string fileReName, string resourceId, string fileType)
        {
            if (string.IsNullOrEmpty(imageData) || string.IsNullOrEmpty(resourceId) || string.IsNullOrEmpty(fileType))
                return SateStr("上传失败！", 0);
            try
            {
                byte[] imageBytes = Convert.FromBase64String(imageData);
                MemoryStream mstream = new MemoryStream(imageBytes);
                byte[] imageBinary = new byte[mstream.Length];//图片二进制
                mstream.Read(imageBinary, 0, imageBinary.Length);
                var fileName = CommonMethod.FileReName(fileReName);   //重新生成名称
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("License", "jpg", fileName, imageBinary);
                LicenseAttachEntity entity = new LicenseAttachEntity();
                entity.Id = Guid.NewGuid().ToString();
                entity.ResourceId = resourceId;
                entity.FileName = fileName;
                entity.FileReName = fileReName;
                entity.FileSize = imageBinary.Length.ToString();
                entity.FileAddress = filePath;
                entity.FileType = fileType;
                entity.FileTypeName = ".jpg";
                entity.RowStatus = 1;
                entity.CreateBy = CurrentUser.CrmUser.UserName;
                entity.CreatorId = CurrentUser.CrmUser.Id;
                entity.CreateOn = DateTime.Now;
                _bll.Add(entity);
                return SateStr("上传成功！", 0);
            }
            catch (Exception)
            { 
                return  SateStr("上传失败！", 0);
            }            
        }


        public ActionResult UpLoadImageList()
        {
            return View();
        }


        public ActionResult PreviewImageList(string itemCode)
        {
            //材料目录
            var material = new LicenseMaterialCatalogueBll().GetSearchResult(new LicenseMaterialCatalogueEntity() { ItemCode = itemCode });            
            ViewData["Material"] = material;
            return View();
        }


        private string SateStr(string message,int state)
        {
            return JsonConvert.SerializeObject((new { message = message, state = state }));
        }

        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="resourid">关联案件编号</param>
        /// <param name="fileType">配置文件编号</param>
        /// <returns></returns>
        public string GetLicenseAttachData(string resourceId, string fileType)
        {
            var result = _bll.GetLicenseAttachList(resourceId, fileType);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 新增附件
        /// </summary>
        /// <param name="resourid"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public string UpLoadAttach(LicenseAttachEntity entity)
        {

            var result = new StatusModel<LicenseAttachEntity>
            {
                rtState = 1,
                rtData = null,
                rtObj = null,
                rtMsrg = string.Empty
            }; 
            if (string.IsNullOrEmpty(entity.ResourceId) || string.IsNullOrEmpty(entity.FileType))
            {
                result.rtMsrg="上传失败！";
                result.rtState=0;
                return JsonConvert.SerializeObject(result);
            }
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.RowStatus = 1;
                entity.CreateBy = CurrentUser.CrmUser.UserName;
                entity.CreatorId = CurrentUser.CrmUser.Id;
                entity.CreateOn = DateTime.Now;
                var obj=_bll.Add(entity);
                result.rtMsrg = "上传成功！";
                result.rtState = 1;
                result.rtObj = obj;
                return JsonConvert.SerializeObject(result);
            }
            catch(Exception)
            {
                result.rtMsrg = "上传失败！";
                result.rtState = 0;
                return JsonConvert.SerializeObject(result);                
            }

        }

        /// <summary>
        /// 无效附件
        /// </summary>
        /// <param name="id">附件主键</param>
        /// <returns></returns>
        public string LicenseAttachDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return SateStr("上传失败！",0);
            }
            try
            {
                if (_bll.LicenseAttachDelete(id))
                {
                    return SateStr("上传成功！", 1);
                }
                else
                {
                    return SateStr("上传失败！", 0);
                }
            }
            catch(Exception)
            {
                return SateStr("上传失败！", 0);
            }
        }

        /// <summary>
        /// 许可附件视图
        /// </summary>
        /// <param name="licenseId">许可案件编号</param>
        /// <param name="itemCode">材料目录</param>
        /// <returns>视图</returns>
        public ActionResult LicenseView(string licenseId, string itemCode)
        {
            //材料目录
            var material = new LicenseMaterialCatalogueBll().GetSearchResult(new LicenseMaterialCatalogueEntity() { ItemCode = itemCode });
            ViewData["Material"] = material;
            ViewBag.licenseId = licenseId;
            ViewBag.itemCode = itemCode;
            //案件的所有材料
            var licenseAttach = new LicenseAttachBll().GetLicenseAttachList(licenseId, string.Empty);
            ViewData["LicenseAttach"] = licenseAttach;
            return View();
        }

        /// <summary>
        /// 获取附件数量
        /// </summary>
        /// <param name="resouceId">编号</param>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        public string GetAttachCount(string resouceId, string fileType)
        {
            if (string.IsNullOrEmpty(resouceId) || string.IsNullOrEmpty(fileType))
            {
                return string.Empty;
            }
            return new LicenseAttachBll().GetLicenseAttachList(resouceId, fileType).Count.ToString();
        }
    }
}
