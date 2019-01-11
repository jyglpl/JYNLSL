using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.SealUp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.SealUp
{
    public class SealUpController : BaseController
    {
        readonly ComNumberBll _comNumberBll = new ComNumberBll();          //编号
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        readonly BaseUserBll _crmUserBll = new BaseUserBll();
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();      //审批意见
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();               //消息、待办
        readonly SealUpAttachBll _sealUpAttachBll = new SealUpAttachBll();               //查封附件
        readonly SealUpGoodsBll _sealUpGoodsBll = new SealUpGoodsBll();               //查封物品
        readonly SealUpLegislationBll _sealUpLegislationBll = new SealUpLegislationBll();               //查封法律法规


        #region View
        //
        // GET: /SealUp/SealUp/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 案件结案
        /// </summary>
        /// <param name="id">案件编号</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public JsonResult Archive(string id, string worklistId)
        {
            var isOk = false;
            try
            {
                var entity = new SealUpBll().Get(id);
                if (entity.State == 10)
                {
                    isOk = new SealUpBll().UpdateCaseState(id, 20);
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    isOk = new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);
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
        /// 编辑
        /// </summary>
        /// <param name="id">查封主键</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public ActionResult Edit(string id, string worklistId)
        {
            var user = CurrentUser.CrmUser;
            var entity = new SealUpEntity();
            var messagelist = new List<CrmMessageWorkEntity>();
            var CompanyId = user.CompanyId;
            if (!string.IsNullOrEmpty(id))
            {
                entity = new SealUpBll().Get(id);
                CompanyId = entity.CompanyId;

                //获取查封物品信息
                List<SealUpGoodsEntity> sealUpGoodsList =
                    _sealUpGoodsBll.GetSearchResult(new SealUpGoodsEntity() { SealUpId = id });
                ViewData["SealUpGoodsList"] = sealUpGoodsList;

                var punishLegislations = _sealUpLegislationBll.GetSearchResult(new SealUpLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    SealUpLegislationEntity legislationEntity = punishLegislations[0];

                    ViewBag.ClassNo = legislationEntity.ClassNo;
                    ViewBag.LegislationId = legislationEntity.LegislationId;
                    ViewBag.LegislationItemId = legislationEntity.LegislationItemId;
                    ViewBag.LegislationGistId = legislationEntity.LegislationGistId;
                }

                messagelist = new CrmMessageWorkBll().GetSearchResult(new CrmMessageWorkEntity() { FormID = id, State = 2 });

                if (!string.IsNullOrEmpty(worklistId))
                {
                    var messDt = new CrmMessageWorkBll().GetUnHandleMessage(CurrentUser.CrmUser.Id, id);
                    if (messDt != null && messDt.Rows.Count > 0)
                    {
                        worklistId = messDt.Rows[0]["Id"].ToString();
                    }
                }
            }
            else
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.CompanyId = user.CompanyId;
                entity.DepartmentId = user.DeptId;
                entity.CaseDate = DateTime.Now;
                entity.ReSource = "";
            }
            if (!string.IsNullOrEmpty(worklistId))
            {
                var messageEntity = new CrmMessageWorkBll().Get(worklistId);

                //当前消息接收人是发启人
                if (messageEntity != null && messageEntity.FormAddress.IndexOf("FE_End=true") > 0)
                {
                    messageEntity.State = 2;
                    new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                }
                messagelist.Add(messageEntity); //将消息增加到集合
                if (!string.IsNullOrEmpty(messageEntity.FormID))
                {
                    entity = new SealUpBll().Get(messageEntity.FormID); //请假登记实体
                }
            }
            else
            {
                worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, id);
            }
            #region 默认值

            //案件来源
            var resources = new ComResourceBll().GetResourcesByParentId("0010");
            ViewData["Sources"] = resources;

            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            //两个执法人员
            var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = entity.DepartmentId }).ToList();
            users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            //当事人类型
            var targetTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0012" }).ToList();
            targetTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetTypes"] = new SelectList(targetTypes, "Id", "RsKey");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //查封审批
            ViewData["FlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "查封审批", "reper");
            ViewData["FlowIdeaNO"] = _crmIdeaListBll.GetFlowIdea(id, "查封审批", "", 1);
            //解封审批
            ViewData["UnFlowIdea"] = _crmIdeaListBll.GetFlowIdea(id, "解封审批", "reper");
            ViewData["UnFlowIdeaNO"] = _crmIdeaListBll.GetFlowIdea(id, "解封审批", "", 1);

            var articleTypeList = _comResourceBll.GetResourceLikeId("0039");
            ViewBag.ArticleTypeList = articleTypeList;

            //材质
            var material = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0053" });
            material.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Materials"] = new SelectList(material, "Id", "RsKey", "");
            ViewBag.Material = material;

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");
            #endregion

            #region 验证按钮权限

            bool btnApply = false;  //审批按钮
            bool BtnUnApply = false;//查封审批 同意 
            bool btnApplication = false; //申请解封按钮
            bool btnApplicationSealUp = false; //申请查封按钮
            bool btnEnd = false; //打印退还
            if (!string.IsNullOrEmpty(worklistId))
            {
                var caseState = entity.State;
                if (caseState > 0 && caseState < 10)
                {
                    btnApply = true;
                    //btnFastApply = IsAllowed("PenaltyCase", "FiledFastApply");
                }
                else if (caseState == 10)
                {
                    btnApply = false;
                }
                else if (caseState > 10 && caseState < 20)
                {
                    BtnUnApply = true;
                }

            }
            if (entity.State == 10)
            {
                btnApplication = true;
            }
            else if (entity.State == 0 && !string.IsNullOrEmpty(id))
            {
                btnApplicationSealUp = true;
            }
            if (entity.State == 20)
            {
                btnEnd = true;
            }
            ViewBag.BtnApply = btnApply;//审批按钮
            //ViewBag.BtnEnd = btnEnd; //结案按钮
            ViewBag.worklistId = worklistId;
            ViewBag.Application = btnApplication;//申请解封
            ViewBag.btnApplicationSealUp = btnApplicationSealUp;//申请查封
            ViewBag.BtnUnApply = BtnUnApply;
            ViewBag.BtnEnd = btnEnd;
            #endregion

            ViewBag.WorkListId = string.IsNullOrEmpty(worklistId) ? "" : worklistId;
            return View(entity);
        }


        # endregion

        #region AJAX

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2016-01-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keywords">查询关键字</param>
        /// <param name="rows">每页请求条数</param>
        /// <param name="page">当前页码</param>
        /// <returns>System.String.</returns>
        public string GetSealJson(string keywords, int rows = 30, int page = 1)
        {
            var data = new SealUpBll().GetSearchResult(keywords, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 保存查封
        /// 添加人：周 鹏
        /// 添加时间：2016-01-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">查封实体</param>
        /// <returns>System.String.</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveSealUp(SealUpEntity entity)
        {
            int rtState = 0;
            var isOk = false;
            try
            {
                var isAdd = string.IsNullOrEmpty(entity.Id);
                var SealUpEntity = new SealUpBll().Get(entity.Id);
                if (SealUpEntity == null)
                {
                    entity.CaseInfoNo = _comNumberBll.GetNumber(AppConst.NumSealUp, "", null);
                    entity.RowStatus = (int)RowStatus.Normal;
                    entity.CreateBy = CurrentUser.CrmUser.UserName;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.CreateOn = DateTime.Now;
                    entity.UpdateBy = CurrentUser.CrmUser.UserName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    new SealUpBll().Add(entity);
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.UserName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    new SealUpBll().Update(entity);
                }

                #region 查封物品

                // 物品名称
                List<string> articleNameList = Request["Name"] != null ? Request["Name"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 位置
                List<string> locationList = Request["Location"] != null ? Request["Location"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 方向
                List<string> directionList = Request["Direction"] != null ? Request["Direction"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                // 面积
                List<string> areaList = Request["Area"] != null ? Request["Area"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                //材质
                List<string> materialList = Request["Material"] != null ? Request["Material"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();

                List<SealUpGoodsEntity> sealUpGoodsList = new List<SealUpGoodsEntity>();

                int indexStr = 0;
                foreach (string item in articleNameList)
                {
                    var model = new SealUpGoodsEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        SealUpId = entity.Id,
                        Name = item,
                        Location = locationList[indexStr],
                        Direction = directionList[indexStr],
                        Area = areaList[indexStr],
                        MaterialId = materialList[indexStr],
                        RowStatus = (int)RowStatus.Normal,
                        CreateBy = CurrentUser.CrmUser.UserName,
                        CreatorId = CurrentUser.CrmUser.Id,
                        CreateOn = DateTime.Now,
                        UpdateBy = CurrentUser.CrmUser.UserName,
                        UpdateId = CurrentUser.CrmUser.Id,
                        UpdateOn = DateTime.Now,
                    };
                    indexStr++;
                    sealUpGoodsList.Add(model);
                }

                #endregion

                //法律法规
                var legislationId = Request["LegislationId"];
                var legislationItemId = Request["LegislationItemId"];
                var legislationGistId = Request["LegislationGistId"];

                isOk = new SealUpBll().TransactionSave(entity, sealUpGoodsList, legislationId, legislationItemId, legislationGistId);
            }
            catch (Exception ex)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 删除查封
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="Id">查封主键编号</param>
        /// <returns>删除结果</returns>
        [HttpPost]
        public string DeleteSealUp(string Id)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = new SealUpBll().BatchDelete(Id);
                rtMsrg = flag ? "删除成功" : "删除失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }

        #endregion

        #region 附件材料相关


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
                if (evtache.Equals("SealUp"))    //查封
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0052" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
            }

            //查询材料对应的材料
            if (!string.IsNullOrEmpty(resourceId) && evidences.Any())
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _sealUpAttachBll.GetSearchResult(new SealUpAttachEntity() { ResourceId = resourceId }, filetypelist);
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

                var result = Guid.NewGuid().ToString();
                var entity = new SealUpAttachEntity()
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
                _sealUpAttachBll.Add(entity);
                return result;
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
                var files = _sealUpAttachBll.GetSearchResult(new SealUpAttachEntity() { ResourceId = resourceId });

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
            var entity = new SealUpAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = _sealUpAttachBll.Get(fileId);
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
                var entity = _sealUpAttachBll.Get(fileId);
                entity.FileRemark = remark;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = _sealUpAttachBll.Update(entity);  //更新
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
                var entity = _sealUpAttachBll.Get(fileId);
                entity.RowStatus = 0;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                isOk = _sealUpAttachBll.Update(entity);
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
                var files = _sealUpAttachBll.GetSearchResult(new SealUpAttachEntity() { ResourceId = resourceId });
                ViewData["Files"] = files;
            }
            return View("FileBreviaryView");
        }

        #endregion

    }
}
