using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Evidence;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Business.TempDetain;
using Yookey.WisdomClassed.SIP.Model.Evidence;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    /// <summary>
    /// 案件附件材料
    /// </summary>
    public class PenaltyCaseFileController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典
        readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll();      //附件材料
        readonly TempDetainAttachBll _tempDetainAttachBll = new TempDetainAttachBll();   //暂扣物品附件材料
        readonly IllegalConstructionAttachBll _illegalConstructionAttachBll = new IllegalConstructionAttachBll();  //违建拆除附件材料
        readonly ProofAttachCaseBll _proofAttachCaseBll = new ProofAttachCaseBll();         //执法记录附件
        readonly ProofAttachBll _proofAttachBll = new ProofAttachBll();         //执法记录附件

        /// <summary>
        /// 证据材料
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="evtache">证据环节</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult FilesTab(string resourceId, string evtache, string isupload, string isdeleted)
        {
            IList<ComResourceEntity> evidences = new List<ComResourceEntity>();
            if (!string.IsNullOrEmpty(evtache))
            {
                #region 材料类型
                if (evtache.Equals("case"))             //案件证据材料
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });
                    evidences.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("survey"))      //调查询问笔录
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160001").ToList();
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("inform"))      //告知书
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160002" || x.Id == "00160003").ToList();
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("decision"))    //决定书
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160004" || x.Id == "00160005").ToList();
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("tempdetain"))    //暂扣物品
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0032" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("CaseDiscuss"))  //案件审理（会审）
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160010").ToList();
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("CollectiveDiacuss"))  //集体讨论（会商）
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160011").ToList();
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }

                #endregion
            }

            //查询材料对应的材料
            if (!string.IsNullOrEmpty(resourceId) && evidences.Any())
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = resourceId }, filetypelist);
                ViewData["Files"] = files;
            }

            ViewBag.Evtache = evtache;         //证据类型
            ViewBag.ResourceId = resourceId;   //外键编号
            ViewBag.Isupload = isupload;       //是否可上传
            ViewBag.IsDeleted = isdeleted;     //是否可删除

            return View("FilesTab");
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
        public string UpSaveImage(string resourceId, string fileAddress, string fileType, string fileTypeName, string remark, string fileName, string fileReName)
        {
            try
            {
                var user = CurrentUser.CrmUser;

                //保存暂扣物品附件材料
                if (fileType.IndexOf("0032", System.StringComparison.Ordinal) > 0)
                {
                    var result = Guid.NewGuid().ToString();
                    var entity = new TempDetainAttachEntity()
                    {
                        Id = result,
                        ResourceId = resourceId,
                        FileType = fileType,
                        FileTypeName = fileTypeName,
                        FileAddress = fileAddress,
                        FileName = fileName,
                        FileReName = fileReName,
                        FileRemark = remark,
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };
                    _tempDetainAttachBll.Add(entity);
                    return result;
                }
                else if (fileType.Contains("0076"))   //违法建设附件材料
                {
                    var result = Guid.NewGuid().ToString();
                    var entity = new IllegalConstructionAttachEntity
                    {
                        Id = result,
                        ResourceId = resourceId,
                        FileType = fileType,
                        FileTypeName = fileTypeName,
                        FileAddress = fileAddress,
                        FileName = fileName,
                        FileReName = fileReName,
                        FileRemark = remark,
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };
                    _illegalConstructionAttachBll.Add(entity);
                    return result;
                }
                else
                {
                    var result = Guid.NewGuid().ToString();
                    var entity = new InfPunishAttachEntity()
                    {
                        Id = result,
                        ResourceId = resourceId,
                        FileType = fileType,
                        FileTypeName = fileTypeName,
                        FileAddress = fileAddress,
                        FileName = fileName,
                        FileReName = fileReName,
                        FileRemark = remark,
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };
                    _infPunishAttachBll.Add(entity);
                    return result;
                }
            }
            catch (Exception)
            {
                return "Error";
            }
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
                var files = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = resourceId });

                ViewData["Files"] = files;
            }
            ViewBag.DefaultPicId = defaultPicId;

            return View();
        }

        /// <summary>
        /// 请求附件详情
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult FileDetails(string fileId)
        {
            var entity = new InfPunishAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = _infPunishAttachBll.Get(fileId);
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
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = _infPunishAttachBll.Get(fileId);
                entity.FileRemark = remark;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = _infPunishAttachBll.Update(entity);  //更新
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
        /// 删除附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult DeleteFile(string fileId)
        {
            var isOk = 0;
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = _infPunishAttachBll.Get(fileId);
                entity.RowStatus = 0;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                isOk = _infPunishAttachBll.Update(entity);
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
        /// 附件缩略图预览,用于案件首页右侧
        /// </summary>
        /// <returns></returns>
        public ActionResult FileBreviaryView(string resourceId, string evtache)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = resourceId });
                ViewData["Files"] = files;
            }
            return View("FileBreviaryView");
        }

        /// <summary>
        /// 户外广告
        /// </summary>
        /// <param name="controlId">控制ID</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="fileType">案件照片类型</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult LicenseFilesTab(string controlId, string resourceId, string fileType, string isupload, string isdeleted)
        {
            if (!string.IsNullOrEmpty(resourceId) && !string.IsNullOrEmpty(fileType))
            {
                var files = new LicenseAttachBll().GetAttachList_CheckSpecType(resourceId, (LicenseCheckSpecType)Enum.Parse(typeof(LicenseCheckSpecType), fileType));
                ViewData["Files"] = files;
            }
            ViewBag.ControlId = controlId;
            ViewBag.ResourceId = resourceId;   //外键编号
            ViewBag.Isupload = isupload;       //是否可上传
            ViewBag.IsDeleted = isdeleted;     //是否可删除
            ViewBag.fileType = fileType;//案件照片类型            
            return View("LicenseFilesTab");
        }

        /// <summary>
        /// 附件放大预览列表
        /// <param name="resourceId">外键编号</param>
        /// <param name="fileType">图片类型</param>
        /// <param name="defaultPicId">默认显示图片ID</param>
        /// </summary>
        /// <returns></returns>
        public ActionResult LicenseFilesView(string resourceId, string fileType, string defaultPicId)
        {
            if (!string.IsNullOrEmpty(resourceId) && !string.IsNullOrEmpty(fileType))
            {
                var files = new LicenseAttachBll().GetAttachList_CheckSpecType(resourceId, (LicenseCheckSpecType)Enum.Parse(typeof(LicenseCheckSpecType), fileType));
                ViewData["Files"] = files;
            }
            ViewBag.fileType = fileType;

            return View();
        }

        /// <summary>
        /// 请求附件详情
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult LicenseFileDetails(string fileId)
        {
            var entity = new LicenseAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = new LicenseAttachBll().Get(fileId);
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
        /// 证据材料
        /// </summary>
        /// <param name="controlId">控件ID</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="evtache">证据环节</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult IllegalFilesTab(string controlId, string resourceId, string evtache, string isupload, string isdeleted)
        {
            IList<ComResourceEntity> evidences = new List<ComResourceEntity>();
            if (!string.IsNullOrEmpty(evtache))
            {
                #region 材料类型

                if (evtache.Equals("BeforeDismantling"))  //拆除前
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760001" });
                    evidences.Add(_comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760008" })[0]);

                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("Dismantling"))  //拆除中
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760002" });
                    evidences.Add(_comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760003" })[0]);
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("GarbageClear"))  //垃圾清运照片
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760004" });
                    evidences.Add(_comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760005" })[0]);
                    evidences.Add(_comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760006" })[0]);
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
                else if (evtache.Equals("ListEvidence"))  //纸质确认清单
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { Id = "00760007" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }

                #endregion
            }

            //查询材料对应的材料
            if (!string.IsNullOrEmpty(resourceId) && evidences.Any())
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _illegalConstructionAttachBll.GetSearchResult(new IllegalConstructionAttachEntity() { ResourceId = resourceId }, filetypelist);
                ViewData["Files"] = files;
            }

            ViewBag.ControlId = controlId;
            ViewBag.Evtache = evtache; //证据类型
            ViewBag.ResourceId = resourceId; //外键编号
            ViewBag.Isupload = isupload; //是否可上传
            ViewBag.IsDeleted = isdeleted; //是否可删除

            return View("IllegalFilesTab");
        }

        /// <summary>
        /// 执法全过程记录
        /// </summary>
        /// <param name="caseType">案件类别</param>
        /// <param name="process">所属过程</param>
        /// <param name="caseId">案件ID</param>
        /// <param name="userIdFirst">执法人员一</param>
        /// <param name="userIdSecond">执法人员二</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public ActionResult ElectronicEvidence(string caseType, string process, string caseId, string userIdFirst, string userIdSecond, string date)
        {

            List<ProofAttachCaseEntity> lst = _proofAttachCaseBll.SearchQuery(new ProofAttachCaseEntity()
                {
                    Penalty = caseType,
                    PenaltyCase = process,
                    CaseId = caseId
                });

            var attachList = new List<ProofAttachEntity>();
            var filePath = AppConfig.FileViewOutNetLink;
            for (var i = 0; i < lst.Count; i++)
            {
                ProofAttachEntity entity = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { SYS_ID = lst[i].ProofAttachId })[0];
                entity.FILETHUMBNAIL = filePath + "/" + entity.FILEADDRESS + "/" + entity.FILETHUMBNAIL;
                attachList.Add(entity);
            }

            ViewBag.CaseType = caseType;
            ViewBag.Process = process;
            ViewBag.CaseId = caseId;
            ViewBag.UserIdFirst = userIdFirst;
            ViewBag.UserIdSecond = userIdSecond;
            ViewBag.Date = date;


            ViewData["Attcase"] = attachList;

            return View("ElectronicEvidence");
        }

        /// <summary>
        /// 删除全过程附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteProof(string id)
        {
            var isOk = false;
            try
            {
                _proofAttachCaseBll.DeleteAttachCase(id);
                //_proofAttachBll.DeleteEvidence(id, "2");
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
    }
}
