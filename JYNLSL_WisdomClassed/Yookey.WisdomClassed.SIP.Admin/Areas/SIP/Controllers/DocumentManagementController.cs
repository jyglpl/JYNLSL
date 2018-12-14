using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.DocumentManagement;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using System.IO;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class DocumentManagementController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        DocumentIncomingBll _IncomingBll = new DocumentIncomingBll();
        DocumentOfficialBll _OfficialBll = new DocumentOfficialBll();
        DocumentAttachBll _AttachBll = new DocumentAttachBll();
        //
        // GET: /ZFYWCL/DocumentManagement/


        #region 收文
        /// <summary>
        /// 收文主页面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DocumentIndex()
        {
            //bool setFlag = false;
            //var entity = new DocumentIncomingEntity();
            //if (string.IsNullOrEmpty(Id))
            //{
            //    ViewBag.Id = Guid.NewGuid().ToString();
            //}
            //else
            //{
            //    ViewBag.Id = Id;
            //    var IllegalcCase = _IncomingBll.GetSearchListIncoming(new DocumentIncomingEntity { PK_ID = Id });
            //    if (IllegalcCase != null && IllegalcCase.Any())
            //    {
            //        entity = IllegalcCase[0];
            //    }
            //    setFlag = true;
            //}

            //ViewBag.setFlag = setFlag;
            //return View(entity);
            return View();
        }

        //收文登记
        public ActionResult AddresseeRegistrtion(string Id, string conttypeId, string IsInitial,string types)
        {
            ViewBag.types = types;
            ViewBag.IsInitial = IsInitial;
            ViewBag.conttypeId = conttypeId;
            bool setFlag = false;
            var entity = new DocumentIncomingEntity();
            if (string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Guid.NewGuid().ToString();
            }
            else
            {
                ViewBag.Id = Id;
                var IllegalcCase = _IncomingBll.GetSearchListIncoming(new DocumentIncomingEntity { ID = Id });
                if (IllegalcCase != null && IllegalcCase.Any())
                {
                    entity = IllegalcCase[0];
                }
                setFlag = true;
            }

            ViewBag.setFlag = setFlag;
            return View(entity);
        }

        /// <summary>
        /// 删除收文
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public JsonResult DeleteIncoming(string Pk_Id)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(Pk_Id))
                {
                    isOk = _IncomingBll.DeleteIncoming(Pk_Id);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //查询收文
        public string GetCompanyIncoming(string status, string Unit, int rows = 30, int page = 10)
        {
            var data = _IncomingBll.GetSearchResult(status, Unit, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            return result;
        }
        /// <summary>
        /// 保存收文登记
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <param name="Unit"></param>
        /// <param name="CBR"></param>
        /// <param name="ShouWenTime"></param>
        /// <param name="XiandinTime"></param>
        /// <param name="Content"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public ActionResult SubmitCaseData(string PK_ID, string Unit,  string ShouWenTime, string XiandinTime, string Content, string State, string Simulation, string Instructions, string Results,string WenHao)
        {
            var isOk = false;
            try
            {
                var IllegalcCase = _IncomingBll.GetSearchListIncoming(new DocumentIncomingEntity { ID = PK_ID });
                if (!IllegalcCase.Any())
                {
                    var CaseInfoEntity = new DocumentIncomingEntity
                    {
                        ID = PK_ID,
                        INCOMING_UNIT = Unit,
                        INCOMING_DATE = ShouWenTime,
                        QUALIFIED_DATE = XiandinTime,
                        DOCUMENT_CONTENT = Content,
                        INCOMING_STATE = State,
                        INCOMING_NBYJ = Simulation,
                        INCOMING_PS = Instructions,
                        CLJG = Results,
                        DOCUMENT_HAO=WenHao,
                        IsInitial="1",
                        ROWSTATUS = 1,
                        CREATOR_ID = "",
                        CREATE_BY = "",
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = "",
                        UPDATE_BY = "",
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _IncomingBll.InsertIncoming(CaseInfoEntity);
                }
                else
                {
                    var CaseInfoEntity = new DocumentIncomingEntity
                    {
                        ID = PK_ID,
                        INCOMING_UNIT = Unit,
                        INCOMING_DATE = ShouWenTime,
                        QUALIFIED_DATE = XiandinTime,
                        DOCUMENT_CONTENT = Content,
                        INCOMING_STATE = State,
                        INCOMING_NBYJ = Simulation,
                        INCOMING_PS = Instructions,
                        CLJG = Results,
                        DOCUMENT_HAO=WenHao,
                        ROWSTATUS = 1,
                        CREATOR_ID = "",
                        CREATE_BY = "",
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = "",
                        UPDATE_BY = "",
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _IncomingBll.UpdateIncoming(CaseInfoEntity);
                }
                if (isOk)
                {
                    var user=CurrentUser.CrmUser;
                    _IncomingBll.UpdateStatus(user.Id, PK_ID);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 收文基本详情
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public ActionResult IndexDetail(string Pk_Id)
        {
            var entity = new DocumentIncomingEntity();
            if (!string.IsNullOrEmpty(Pk_Id))
            {
                var IndexdetailcCase = _IncomingBll.GetSearchListIncoming(new DocumentIncomingEntity { ID = Pk_Id });
                if (IndexdetailcCase != null && IndexdetailcCase.Any())
                {
                    entity = IndexdetailcCase[0];
                }
            }
            return View(entity);
        }
        #endregion


        #region 发文
        public ActionResult DocumentOfficial()
        {
            return View();
        }

        //发文登记页面
        public ActionResult OfficialRegistrtion(string Id, string conttypeId, string IsInitial)
        {
            ViewBag.conttypeId = conttypeId;
            ViewBag.IsInitial = IsInitial;
            bool setFlag = false;
            var entity = new DocumentOfficialEntity();
            if (string.IsNullOrEmpty(Id))
            {
                ViewBag.Id = Guid.NewGuid().ToString();
            }
            else
            {
                ViewBag.Id = Id;
                var IllegalcCase = _OfficialBll.GetSearchListOfficial(new DocumentOfficialEntity { ID = Id });
                if (IllegalcCase != null && IllegalcCase.Any())
                {
                    entity = IllegalcCase[0];
                }
                setFlag = true;
            }

            ViewBag.setFlag = setFlag;
            return View(entity);
        }
        //查询发文
        public string GetCompanyOfficial(string status, string userName, int rows = 30, int page = 10)
        {
            var data = _OfficialBll.GetSearchResult(status, userName, rows, page);
            var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            return result;
        }
        /// <summary>
        /// 删除发文
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public JsonResult DeleteOfficial(string Pk_Id)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(Pk_Id))
                {
                    isOk = _OfficialBll.DeleteOfficial(Pk_Id);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 发文基本详情
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public ActionResult OfficialDetail(string Pk_Id)
        {
            var entity = new DocumentOfficialEntity();
            if (!string.IsNullOrEmpty(Pk_Id))
            {
                var OfficialcCase = _OfficialBll.GetSearchListOfficial(new DocumentOfficialEntity { ID = Pk_Id });
                if (OfficialcCase != null && OfficialcCase.Any())
                {
                    entity = OfficialcCase[0];
                }
            }
            return View(entity);
        }

        /// <summary>
        /// 发文登记
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <param name="Title"></param>
        /// <param name="WH"></param>
        /// <param name="QCR"></param>
        /// <param name="BMFZR"></param>
        /// <param name="Startime"></param>
        /// <param name="Endtime"></param>
        /// <param name="LWDW"></param>
        /// <returns></returns>
        public ActionResult SubmitCaseDataOfficial(string PK_ID, string Title, string WH, string QCR, string BMFZR, string Startime, string Endtime, string LWDW, string Volume, string CSDW, string FGDW, string LDQF)
        {
            var isOk = false;
            try
            {
                var IllegalcCase = _OfficialBll.GetSearchListOfficial(new DocumentOfficialEntity { ID = PK_ID });
                if (!IllegalcCase.Any())
                {
                    var CaseInfoEntity = new DocumentOfficialEntity
                    {
                        ID = PK_ID,
                        DOCUMENT_TITLE = Title,
                        LWDW = LWDW,
                        WH = WH,
                        QCR = QCR,
                        BMFZR = BMFZR,
                        LSSUED_STARTIME = Startime,
                        LSSUED_ENDTIME = Endtime,
                        Volume = Volume,
                        DISPATCH_CSDW = CSDW,
                        DISPATCH_FGLD = FGDW,
                        DISPATCH_LDQF = LDQF,
                        ROWSTATUS = 1,
                        DISPATCH_STATE = 0,
                        CREATOR_ID = "",
                        CREATE_BY = "",
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = "",
                        UPDATE_BY = "",
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _OfficialBll.InsertOfficial(CaseInfoEntity);
                }
                else
                {
                    var CaseInfoEntity = new DocumentOfficialEntity
                    {
                        ID = PK_ID,
                        DOCUMENT_TITLE = Title,
                        LWDW = LWDW,
                        WH = WH,
                        QCR = QCR,
                        BMFZR = BMFZR,
                        LSSUED_STARTIME = Startime,
                        LSSUED_ENDTIME = Endtime,
                        Volume = Volume,
                        DISPATCH_CSDW = CSDW,
                        DISPATCH_FGLD = FGDW,
                        DISPATCH_LDQF = LDQF,
                        ROWSTATUS = 1,
                        DISPATCH_STATE = 0,
                        CREATOR_ID = "",
                        CREATE_BY = "",
                        CREATE_ON = DateTime.Now,
                        UPDATE_ID = "",
                        UPDATE_BY = "",
                        UPDATE_ON = DateTime.Now
                    };
                    isOk = _OfficialBll.UpdateOfficial(CaseInfoEntity);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 收发文统计
        public ActionResult Statistical()
        {
            return View();
        }

        //收文统计
        public string GetStatistical(string startime, string endtime)
        {

            var data = _IncomingBll.GetDeptStatisticsData();
            var result = JsonConvert.SerializeObject(data);
            return result;
        }
        //发文统计
        public string GetGwStatisticsData(string startime, string endtime)
        {

            var data = _IncomingBll.GetGwStatisticsData();
            var result = JsonConvert.SerializeObject(data);
            return result;
        }
        #endregion

        #region 审批流程
        /// <summary>
        /// 审批走到哪儿
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CaseFlow(string id, string types)
        {
            var data = _crmMessageWorkBll.GetCaseFlow(id);
            ViewData["Flow"] = data;
            ViewBag.types = types;
            return View();
        }
        #endregion
        #region 附件
        public ActionResult FilesTab(string resourceId, string evtache, string isupload, string isdeleted, string istime)
        {
            List<ComResourceEntity> lstResource = new List<ComResourceEntity>();
            string parentId = "";
            string fileTypeName = "";
            if (!string.IsNullOrEmpty(evtache))
            {
                if (evtache.Equals("case"))
                {
                    parentId = "0052";
                    fileTypeName = "00520001";
                    lstResource = _comResourceBll.GetListBy(parentId, fileTypeName);
                    lstResource.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(lstResource, "Id", "RSKEY");
                }
            }
            //查询材料对应的附件
            if (!string.IsNullOrEmpty(resourceId) && lstResource.Any())
            {
                var filetypelist = (from type in lstResource where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _AttachBll.GetAllResult(new DocumentIncomingAttachEntity() { GL_RESOURCE_ID = resourceId });
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
                //var newFileReName = fileName + GetFileCount(resourceId, fileTypeName) + fileSuffix;
                var newFileAddress = fileAddress.Replace(fileReName, "");
                newFileAddress = newFileAddress + resourceId + "/";
                if (!Directory.Exists(AppConfig.FileSaveAddr + newFileAddress))
                {
                    Directory.CreateDirectory(AppConfig.FileSaveAddr + newFileAddress);
                }
                newFileAddress = newFileAddress + fileName;
                FileInfo fileInfo = new FileInfo(AppConfig.FileSaveAddr + fileAddress);
                fileInfo.MoveTo(AppConfig.FileSaveAddr + newFileAddress);
                var sameId = Guid.NewGuid().ToString();
                var entity = new DocumentIncomingAttachEntity()
                {
                    ID = result,
                    GL_RESOURCE_ID = resourceId,
                    FILE_NAME = fileName,
                    FILE_RENAME = fileName,
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
                _AttachBll.InsertDocumentCaseAttach(entity);
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
        /// 根据ID删除附件 图片 (缩略图)
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public JsonResult DeleteImgAttach(string fileId)
        {
            var isOk = 0;
            if (!string.IsNullOrEmpty(fileId))
            {
                isOk = _AttachBll.UpdateIllegalCaseAttach(fileId);
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
        /// 获取材料数量
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="fileTypeName"></param>
        /// <returns></returns>
        public int GetFileCount(string resourceId, string fileTypeName)
        {
            var fileCount = 0;
            var getFileList = _AttachBll.GetAllResult(new DocumentIncomingAttachEntity { GL_RESOURCE_ID = resourceId, FILE_TYPE_NAME = fileTypeName });
            if (getFileList.Any())
            {
                fileCount = getFileList.Count() + 1;
            }
            return fileCount;
        }
        #endregion
    }
}
