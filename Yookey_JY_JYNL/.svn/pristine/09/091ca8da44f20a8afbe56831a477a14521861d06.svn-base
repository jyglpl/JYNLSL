using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.TeamManagement;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.TeamManagement
{
    /// <summary>
    /// 队伍管理标准
    /// </summary>
    public class TeamManagementStandardController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly TeamManagementStandardBll _teamManagementStandardBll = new TeamManagementStandardBll();

        #region 字典列表
        /// <summary>
        /// 字典列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 请求Grid数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetGridJson(string classTypeId)
        {
            IList<TeamManagementStandardEntity> resourceList = new List<TeamManagementStandardEntity>();
            if (!string.IsNullOrEmpty(classTypeId))
            {
                resourceList = _teamManagementStandardBll.GetSearchResult(new TeamManagementStandardEntity() { ClassTypeId = classTypeId });
            }
            var result = new PageJqDatagrid<TeamManagementStandardEntity>()
            {
                rows = resourceList
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 请求TreeJson
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeDictionary()
        {
            var resourceList = _comResourceBll.GetSearchResult(new ComResourceEntity() { ParentId = "0050" });

            var result = (from crmRoleEntity in resourceList
                          select new TreeNode()
                          {
                              id = crmRoleEntity.Id,
                              text = crmRoleEntity.RsKey,
                              showcheck = false,
                              isexpand = true,
                              complete = true,
                              hasChildren = false,
                              ChildNodes = null
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  新增、编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id, string classTypeId, string classTypeName)
        {
            var entity = new TeamManagementStandardEntity();
            entity.ClassTypeId = classTypeId;
            entity.ClassTypeIdName = classTypeName;

            if (!string.IsNullOrEmpty(id))
            {
                entity = _teamManagementStandardBll.Get(id);
            }

            return View(entity);
        }

        /// <summary>
        /// 保存字典
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="comResource">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Submit(TeamManagementStandardEntity teamManagementStandard)
        {
            var rtState = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    teamManagementStandard.RowStatus = 1;
                    if (string.IsNullOrEmpty(teamManagementStandard.Id))
                    {
                        teamManagementStandard.Id = Guid.NewGuid().ToString();
                        teamManagementStandard.CreateBy = CurrentUser.CrmUser.UserName;
                        teamManagementStandard.CreateOn = DateTime.Now;
                        teamManagementStandard.CreatorId = CurrentUser.CrmUser.Id;
                        teamManagementStandard.UpdateBy = CurrentUser.CrmUser.UserName;
                        teamManagementStandard.UpdateId = CurrentUser.CrmUser.Id;
                        teamManagementStandard.UpdateOn = DateTime.Now;

                        _teamManagementStandardBll.Add(teamManagementStandard);
                    }
                    else
                    {

                        teamManagementStandard.UpdateBy = CurrentUser.CrmUser.UserName;
                        teamManagementStandard.UpdateId = CurrentUser.CrmUser.Id;
                        teamManagementStandard.UpdateOn = DateTime.Now;
                        _teamManagementStandardBll.Update(teamManagementStandard);
                    }
                    rtState = 0;
                }
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
        #endregion

        #region 列表删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = _teamManagementStandardBll.BatchDelete("'" + id + "'") ? 1 : 0;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
