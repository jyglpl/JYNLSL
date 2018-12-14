using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Business.Petition;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Petition;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Petition
{
    public class PetitionController : BaseController
    {
        PetitionBll _petitionbll = new PetitionBll();
        PetitonProcessBll _petitionprocessbll = new PetitonProcessBll();
        readonly FeProcessBll _feProcessBll = new FeProcessBll();
        private readonly ComAttachmentBll _comAttachmentBll = new ComAttachmentBll();

        //
        // GET: /Petition/

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<ComResourceEntity> list2 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0080" });
            list2.Insert(0, new ComResourceEntity() { Id = "", RsKey = "==请选择==" });
            ViewData["petitionType"] = new SelectList(list2, "Id", "Rskey");

            IList<ComResourceEntity> list = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0078" });
            list.Insert(0, new ComResourceEntity() { Id = "", RsKey = "==请选择==" });
            ViewData["TSSource"] = new SelectList(list, "Id", "Rskey");

            IList<ComResourceEntity> list1 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0079" });
            list1.Insert(0, new ComResourceEntity() { Id = "", RsKey = "==请选择==" });
            ViewData["yxj"] = new SelectList(list1, "Id", "Rskey");

            return View();
        }

        public class TSSource
        {
            public string Id { get; set; }
            public string RsKey { get; set; }
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            PetitionEntity pe = new PetitionEntity();
            pe.Id = Guid.NewGuid().ToString();
            pe.Status = 0;

            //类型

            IList<ComResourceEntity> list = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0078" });
            ViewData["TSSource"] = new SelectList(list, "Id", "Rskey");


            IList<ComResourceEntity> list1 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0079" });
            ViewData["priorityList"] = new SelectList(list1, "Id", "Rskey");


            IList<ComResourceEntity> list2 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0080" });
            ViewData["petitionType"] = new SelectList(list2, "Id", "Rskey");



            return View(pe);
        }


        public string GetPriorityList(string controlId, string defaultSelId, bool defaultSel = false)
        {
            var str = new StringBuilder();
            try
            {
                var user = CurrentUser.CrmUser;
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", controlId);
                var companys = new CrmCompanyBll().GetAllEnforcementUnit();

                IList<ComResourceEntity> list1 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0079" });
                str.Append("document.getElementById('" + controlId + "').options[" + 0 + "] = new Option('==请选择==', 'all', true, false);");
                for (int i = 0; i < list1.Count; i++)
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + i + 1 + "] = new Option('" + list1[i].RsKey + "', '" + list1[i].RsValue + "', true, false);");
                }

            }
            catch (Exception)
            {
                //ignored
            }
            return str.ToString();
        }

        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="worklistId">待办事宜</param>
        /// <returns></returns>
        public ActionResult Detail(string Id, string worklistId)
        {
            var pe = _petitionbll.Get(Id);


            ViewBag.SourceName = new ComResourceBll().Get(pe.PetitionSource).RsKey;//案件投诉来源

            //附件
            var files = _comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = Id, FileType = "1" });
            ViewData["Files"] = files;

            //附件
            var Idealfiles = _comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = Id, FileType = "2" });
            ViewData["Idealfiles"] = Idealfiles;

            //类型

            IList<ComResourceEntity> list = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0078" });
            ViewData["TSSource"] = new SelectList(list, "Id", "Rskey");


            IList<ComResourceEntity> list1 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0079" });
            ViewData["priorityList"] = new SelectList(list1, "Id", "Rskey");


            IList<ComResourceEntity> list2 = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0080" });
            ViewData["petitionTypes"] = new SelectList(list2, "Id", "Rskey");



            ViewData["FlowIdea"] = new CrmIdeaListBll().GetIdeaListByPetition(Id);

            //如果案件的消息ID为空,则查询出当前登录账号对应该条案件未处理的待办事宜
            if (string.IsNullOrEmpty(worklistId))
            {
                worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(CurrentUser.CrmUser.Id, Id);
            }

            ViewBag.WorkListId = worklistId;


            //验证当前登录账号是否有受理权限
            var acceptPer = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PetitionApproval", "Accept");

            //保存、受理、申请、同意、退回、提交（街道勘验）、下一步、办结
            bool
                btnAgree = false,
                //同意
                //发送 
                btnApply = false,
                //退回 
                btnDisAgree = false,
                //办结     
                btnClosed = false,
                //保存 
                btnSave = false,
                //登记材料
                registeredFile = false,
                //回复材料 
                idealFile = false,
                //是否已过终审
                isFinalExamine = false;

            //if (acceptPer)
            //{
            //    btnApply = true;
            //    btnSave = true;
            //}
            if (pe.Status == 10)
            {
                if (string.IsNullOrEmpty(worklistId))
                {
                    btnApply = true;
                }
                registeredFile = true;
            }

            if (!string.IsNullOrEmpty(worklistId))
            {
                btnSave = true;
                if (pe.Status > 10 && pe.Status < 20)
                {
                    btnAgree = true;
                    btnDisAgree = true;
                }
                if (pe.Status > 10 && pe.Status < 20)
                {
                    btnApply = false;
                    idealFile = true;
                }
                if (pe.Status == 20)
                {
                    btnClosed = true;
                }
            }

            //验证是否已通过终审环节
            if (!string.IsNullOrEmpty(Id))
            {
                isFinalExamine = new PetitionBll().CheckIsFinalExamine(Id);
            }

            ViewBag.BtnAgree = btnAgree;
            ViewBag.BtnDisAgree = btnDisAgree;
            ViewBag.BtnClosed = btnClosed;
            ViewBag.BtnApply = btnApply;
            ViewBag.BtnSave = btnSave;
            ViewBag.IdealFile = idealFile;
            ViewBag.RegisteredFile = registeredFile;
            ViewBag.IsFinalExamine = isFinalExamine;
            return View(pe);
        }

        /// <summary>
        /// Turn
        /// </summary>
        /// <returns></returns>
        public ActionResult Turn(string Id)
        {
            var pe = _petitionbll.Get(Id);
            return View(pe);
        }


        /// <summary>
        /// 新增信访
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SubmitForm(PetitionEntity entity)
        {
            var rtState = 0;
            try
            {

                string id = entity.Id;
                var aEntity = new PetitionBll().Get(id);
                if (aEntity == null)
                {
                    PetitionEntity education = new PetitionEntity();

                    education.Id = id;
                    education.PetitionUser = entity.PetitionUser;
                    education.PetitionCompany = entity.PetitionCompany;
                    education.PetitionSource = entity.PetitionSource;
                    education.SourceNo = entity.SourceNo;
                    education.PetitionNo = entity.PetitionNo;
                    education.ReceiveDate = entity.ReceiveDate;
                    education.Phone = entity.Phone;
                    education.Address = entity.Address;
                    education.PetitionTitile = entity.PetitionTitile;
                    education.Priority = entity.Priority;
                    education.PetitionType = entity.PetitionType;
                    education.EndDate = entity.EndDate;
                    education.PetitionContent = entity.PetitionContent;
                    education.Attachment = entity.Attachment;
                    education.DeptSeal = entity.DeptSeal;
                    education.OfficeSeal = entity.OfficeSeal;
                    education.IsLastProcess = entity.IsLastProcess;
                    education.PetitionCompanyName = entity.PetitionCompanyName;
                    education.AttachmentType = "1";
                    education.Status = 10;
                    education.RowStatus = (int)RowStatus.Normal;
                    education.CreateBy = CurrentUser.CrmUser.UserName;
                    education.CreatorId = CurrentUser.CrmUser.Id;
                    education.CreateOn = DateTime.Now;
                    education.UpdateBy = CurrentUser.CrmUser.UserName;
                    education.UpdateId = CurrentUser.CrmUser.Id;
                    education.UpdateOn = DateTime.Now;
                    _petitionbll.Add(education);
                    _petitionbll.SaveFile(education, CurrentUser.CrmUser.Id);
                }
                else
                {
                    entity.Attachment = entity.Attachment;
                    entity.AttachmentType = "2";
                    entity.CreateOn = aEntity.CreateOn;
                    entity.CreatorId = aEntity.CreatorId;
                    entity.CreateBy = aEntity.CreateBy;
                    entity.RowStatus = 1;
                    entity.UpdateBy = CurrentUser.CrmUser.UserName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    _petitionbll.Update(entity);
                    _petitionbll.SaveFile(entity, CurrentUser.CrmUser.Id);
                }
                rtState = 0;
            }
            catch (Exception)
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
        /// 查询
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string GridJson(string StartTime,
               string EndTime,
                string yxj,
                string source,
                string companyId,
                string petitionType,
                string status,
                string keyWords,
            int rows, int page)
        {
            var user = CurrentUser.CrmUser;
            string userDeptId = user.DeptId;
            if (!string.IsNullOrEmpty(source))//投诉来源子目录条件
            {
                var childList = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = source });
                if (childList.Count > 0)
                {
                    source = string.Join("','", childList.Select(i => i.Id));
                }
            }
            var data = _petitionbll.QueryList(new PetitionEntity { Priority = yxj, PetitionSource = source, PetitionCompany = companyId, PetitionType = petitionType }, keyWords, status, "", "", rows, page, StartTime, EndTime);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 办结
        /// </summary>
        /// <param name="licenseId">案件编号</param>
        /// <returns></returns>
        public JsonResult PetetionColsed(string licenseId)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(licenseId))
                {
                    var user = CurrentUser.CrmUser;
                    var entity = _petitionbll.Get(licenseId);
                    entity.Status = 30;
                    isOk = _petitionbll.Update(entity) > 0;
                    if (isOk)
                    {
                        new CrmMessageWorkBll().UpdateUnHandleMessage(licenseId);
                    }
                    rtMsg = "办结操作成功";
                }
                else
                {
                    isOk = false;
                    rtMsg = "请传入信访主键值";
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string GetBh(string resourId)
        {
            var entity = new ComResourceBll().GetSearchResult(new ComResourceEntity { Id = resourId })[0];
            string value = entity.RsValue;
            string No = new PetitionBll().GetNo(value);
            return No;
        }


        /// <summary>
        /// 文书打印页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DocReportPrint(string id)
        {
            ViewBag.Id = id;
            return View();
        }



        [HttpGet]
        public JsonResult GetAreaList()
        {
            var isAll = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "Petition", "Index");
            var areaList = new List<dynamic>();
            areaList.Add(new { Name = "沧浪新城", Value = "a7cf4225-5f67-478b-ae0a-c42b6bf6f17c" });
            areaList.Add(new { Name = "金阊新城", Value = "9c3e77ad-4ba6-475b-a570-aa90d7236435" });
            areaList.Add(new { Name = "平江新城", Value = "a8f910a4-dd36-42b7-8fa1-0dae2d557f3b" });
            areaList.Add(new { Name = "山塘片区", Value = "76cc500d-11d0-4470-90aa-7d3c038a9456" });
            areaList.Add(new { Name = "盘门片区", Value = "29d765c2-1f9c-4789-b4eb-0cdc6249bc9b" });
            areaList.Add(new { Name = "葑门片区", Value = "091091cd-5d60-43df-9032-8a78d6632c01" });
            areaList.Add(new { Name = "拙政园片区", Value = "1750b921-66a2-49d7-98bb-2380a2daf68e" });
            areaList.Add(new { Name = "阊门片区", Value = "34e22708-a0e9-455b-8a19-126ee8b4327e" });
            areaList.Add(new { Name = "直属大队", Value = "0d138e94-cd6c-46f3-a6cb-7ca9f93199d0" });
            areaList.Add(new { Name = "火车站大队", Value = "9b713b58-2582-4d18-8bca-11b7154a7140" });
            areaList.Add(new { Name = "办公室", Value = "39d7f803-aea9-4377-9e7b-e453ea0cca0d" });
            areaList.Add(new { Name = "环卫处", Value = "503c2d50-287d-4c23-a889-80b2ef816f91" });
            areaList.Add(new { Name = "市容处", Value = "1ef87a75-ef1e-46cf-8b5d-ec25fad5c9c2" });
            areaList.Add(new { Name = "市政处", Value = "4e0df1fe-07e1-42a8-8fd1-f3b66993a33f" });
            areaList.Add(new { Name = "执法处", Value = "34fe9bdc-fdb3-43d0-913b-fef7d72c4a74" });
            areaList.Add(new { Name = "法制处", Value = "34e0fedd-dac1-4639-b54c-ace832242a16" });
            areaList.Add(new { Name = "监督考核处", Value = "79ea38c2-2ee7-487c-8f30-96a8f53e0ceb" });
            if (!isAll)
            {
                var userCompanyId = CurrentUser.CrmUser.CompanyId;
                var userDeptid = CurrentUser.CrmUser.DeptId;
                areaList = areaList.Where(i => i.Value == userCompanyId || i.Value == userDeptid).ToList();
            }
            else
            {
                areaList.Insert(0, new { Name = "==请选择==", Value = string.Empty });
            }
            return Json(areaList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 投诉来源TreeJson
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeJson()
        {
            var comresourBll = new ComResourceBll();

            var resourall = comresourBll.GetSearchResult(new ComResourceEntity());

            //企业
            var topResour = resourall.Where(x => x.ParentId == "0081").ToList();
            var childs = new List<ComResourceBll.TreeNode>();
            var treeNodeList = new List<ComResourceBll.TreeNode>();
            foreach (var item in topResour)
            {
                childs = comresourBll.ChildResour(resourall, item.Id);
                treeNodeList.Add(new ComResourceBll.TreeNode
                {
                    id = item.Id,
                    text = item.RsKey,
                    value = "source",
                    img = "/Content/Images/Icon16/molecule.png",//tree.js处理路径
                    showcheck = false,
                    isexpand = true,
                    complete = true,
                    hasChildren = childs.Count > 0,
                    ChildNodes = childs
                });
            }
            return Json(treeNodeList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <returns></returns>
        public string GetPetitionCount()
        {
            var data = _petitionbll.GetPetitionCount();
            return CommonMethod.ToJson(data);
        }
    }
}
