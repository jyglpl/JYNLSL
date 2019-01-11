using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    public class ComResourceController : BaseController
    {
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
        public string GetGridJson(string id)
        {
            var resourceList = new List<ComResourceEntity>();
            if (!string.IsNullOrEmpty(id))
            {
                resourceList = new ComResourceBll().GetResourcesByParentId(id);
            }
            var result = new PageJqDatagrid<ComResourceEntity>()
            {
                rows = resourceList
            };
            return JsonConvert.SerializeObject(result);
        }


        #endregion

        #region  新增、编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            var entity = new ComResourceEntity();
            
            if (!string.IsNullOrEmpty(id))
            {
                entity = new ComResourceBll().Get(id);
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
        public JsonResult Submit(ComResourceEntity comResource)
        {
            var rtState = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    comResource.RowStatus = 1;
                    if (string.IsNullOrEmpty(comResource.Id))
                    {
                        comResource.Id = new ComResourceBll().GetMaxId(comResource.ParentId);
                        comResource.CreateBy = CurrentUser.CrmUser.UserName;
                        comResource.CreateOn = DateTime.Now;
                        comResource.CreatorId = CurrentUser.CrmUser.Id;
                        comResource.UpdateBy = CurrentUser.CrmUser.UserName;
                        comResource.UpdateId = CurrentUser.CrmUser.Id;
                        comResource.UpdateOn = DateTime.Now;

                        new ComResourceBll().Add(comResource);
                    }
                    else
                    {
                        if ((DateTime.Compare(comResource.CreateOn, Convert.ToDateTime("1901-01-01")) < 0))
                        {
                            comResource.CreateOn = Convert.ToDateTime("1901-01-01");
                        }
                        comResource.UpdateBy = CurrentUser.CrmUser.UserName;
                        comResource.UpdateId = CurrentUser.CrmUser.Id;
                        comResource.UpdateOn = DateTime.Now;
                        new ComResourceBll().Update(comResource);
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

        /// <summary>
        /// 请求TreeJson
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeDictionary(string parentId = "", string id = "")
        {
            var resourceList = new ComResourceBll().GetSearchResult(new ComResourceEntity() { });

            var topResource = resourceList.Where(x => x.ParentId == parentId).ToList();
            var result = (from crmRoleEntity in topResource
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


        /// <summary>
        /// 请求TreeJson
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeDetailsDictionary(string dataDictionaryId = "")
        {
            var resourceList = new ComResourceBll().GetSearchResult(new ComResourceEntity() { });

            var topResource = resourceList.Where(x => x.Id == dataDictionaryId).ToList();

            var result = (from resourceEntity in topResource
                          let childs = ChildTree(resourceList, resourceEntity.Id)
                          select new TreeNode()
                          {
                              id = resourceEntity.Id,
                              text = resourceEntity.RsKey,
                              showcheck = false,
                              isexpand = false,
                              complete = true,
                              hasChildren = childs.Count > 0,
                              ChildNodes = childs
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载子角色
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceLists"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> ChildTree(IEnumerable<ComResourceEntity> resourceLists, string parentId)
        {
            var resourceEntities = resourceLists as ComResourceEntity[] ?? resourceLists.ToArray();
            var childList = resourceEntities.Where(t => t.ParentId == parentId).ToList();
            return (from crmRoleEntity in childList
                    let childs = ChildTree(resourceEntities, crmRoleEntity.Id)
                    select new TreeNode()
                    {
                        id = crmRoleEntity.Id,
                        text = crmRoleEntity.RsKey,
                        showcheck = false,
                        isexpand = false,
                        complete = true,
                        hasChildren = childs.Count > 0,
                        ChildNodes = childs
                    }).ToList();
        }

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
                rtState = new ComResourceBll().BatchDelete("'" + id + "'") ? 1 : 0;
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
