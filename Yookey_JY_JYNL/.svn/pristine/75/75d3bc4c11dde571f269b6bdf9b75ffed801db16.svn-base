using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    public class MenuController : BaseController
    {
        //
        // GET: /CommonModule/Menu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string menuId)
        {
            var comMenu = new ComMenuEntity();
            if (!string.IsNullOrEmpty(menuId))
            {
                comMenu = new ComMenuBll().Get(menuId);
                comMenu.IconPic = comMenu.IconPic;
            }
            SetDefaultData(comMenu);
            return View(comMenu);
        }


        /// <summary>
        /// 加载默认值
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="comMenu">ComMenu实体</param>
        private void SetDefaultData(ComMenuEntity comMenu)
        {
            //父级菜单
            var menus = new ComMenuBll().GetAllMenu(comMenu.MenuLevel - 1, 1);
            menus.Insert(0, new ComMenuEntity { Id = "", MenuName = "请选择父级菜单" });
            ViewData["ParentMenuList"] = new SelectList(menus, "Id", "MenuName", comMenu.ParentMenuId);
            //菜单级别
            var menuLevellist = EnumOperate.ConvertEnumToListItems(typeof(MenuLevel), comMenu.MenuLevel.ToString(CultureInfo.InvariantCulture));
            ViewData["MenuLevelList"] = menuLevellist;
            //打开方式
            var opTypelist = EnumOperate.ConvertEnumToListItems(typeof(OpenType), comMenu.OpenType.ToString(CultureInfo.InvariantCulture));
            ViewData["OpenTypeList"] = opTypelist;
            //来源
            var sourcelist = EnumOperate.ConvertEnumToListItems(typeof(Source), comMenu.Source.ToString(CultureInfo.InvariantCulture));
            ViewData["SourceList"] = sourcelist;
        }

        #region Ajax 请求操作
        /// <summary>
        /// 加载左侧TreeViewJson
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public JsonResult TreeMenu()
        {
            try
            {
                var menus = new ComMenuBll().GetAllMenu(new ComMenuEntity());
                var topMenus = menus.Where(x => x.ParentMenuId == "-").ToList();
                var menuList = (from comMenuEntity in topMenus
                                let childs = ChildTree(menus, comMenuEntity.Id)
                                select new TreeNode()
                                {
                                    id = comMenuEntity.Id,
                                    text = comMenuEntity.MenuName,
                                    img = !string.IsNullOrEmpty(comMenuEntity.IconPic) ? "/Content/Images/Icon16/" + comMenuEntity.IconPic : "/Content/Images/Icon16/messenger.png",
                                    Location = comMenuEntity.MenuUrl,
                                    showcheck = false,
                                    isexpand = true,
                                    complete = true,
                                    hasChildren = childs.Count > 0,
                                    ChildNodes = childs
                                }).ToList();

                return Json(menuList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 加载子菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userMenus"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> ChildTree(IEnumerable<ComMenuEntity> userMenus, string parentId)
        {
            var comMenuEntities = userMenus as ComMenuEntity[] ?? userMenus.ToArray();
            var childList = comMenuEntities.Where(t => t.IsMenu.Equals(1) && t.ParentMenuId == parentId).ToList();
            return (from comMenuEntity in childList
                    let childs = ChildTree(comMenuEntities, comMenuEntity.Id)
                    select new TreeNode()
                    {
                        id = comMenuEntity.Id,
                        text = comMenuEntity.MenuName,
                        img = !string.IsNullOrEmpty(comMenuEntity.IconPic) ? "/Content/Images/Icon16/" + comMenuEntity.IconPic : "/Content/Images/Icon16/messenger.png",
                        Location = comMenuEntity.MenuUrl,
                        showcheck = false,
                        isexpand = false,
                        complete = true,
                        hasChildren = childs.Count > 0,
                        ChildNodes = childs
                    }).ToList();
        }


        /// <summary>
        /// 加载右侧表格数据
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public string LoadGrid(string menuId)
        {
            var menus = new ComMenuBll().GetSearchResult(new ComMenuEntity { ParentMenuId = (menuId ?? string.Empty).Trim() }, 100);
            return CommonMethod.PageToJson(CommonMethod.PageToJqDataGrid(menus));
        }

        /// <summary>
        /// 菜单等级
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="menuLevel">菜单等级(1：一级菜单 2：二级菜单 3：三级菜单)</param>
        /// <returns></returns>
        public string AjaxLoadMenus(int menuLevel)
        {
            //父级菜单
            var menus = new ComMenuBll().GetAllMenu(menuLevel - 1);
            var sbMenus = new StringBuilder();
            sbMenus.AppendFormat("<option value=\"0\">请选择父级菜单</option>");
            if (menus.Count > 0)
            {
                foreach (var t in menus.Where(t => !string.IsNullOrEmpty(t.MenuName)))
                {
                    sbMenus.AppendFormat("<option value=\"" + t.Id + "\">" + t.MenuName + "</option>");
                }
            }
            return sbMenus.ToString();
        }

        #endregion

        /// <summary>
        /// 保存菜单信息
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="comMenu"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(ComMenuEntity comMenu)
        {
            var rtState = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    comMenu.RowStatus = 1;
                    comMenu.CreateBy = string.IsNullOrEmpty(comMenu.Id) ? CurrentUser.CrmUser.UserName : comMenu.CreateBy;
                    comMenu.CreateOn = string.IsNullOrEmpty(comMenu.Id) ? DateTime.Now : comMenu.CreateOn;
                    comMenu.CreatorId = string.IsNullOrEmpty(comMenu.Id) ? CurrentUser.CrmUser.Id : comMenu.CreatorId;
                    comMenu.UpdateBy = CurrentUser.CrmUser.UserName;
                    comMenu.UpdateId = CurrentUser.CrmUser.Id;
                    comMenu.UpdateOn = DateTime.Now;
                    if (string.IsNullOrEmpty(comMenu.Id))
                    {
                        new ComMenuBll().Add(comMenu);
                    }
                    else
                    {
                        new ComMenuBll().Update(comMenu);
                    }
                    rtState = 0;
                }
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
        /// 删除菜单
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">菜单编号</param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                rtState = new ComMenuBll().BatchDeleteMenu("'" + id + "'") ? 1 : 0;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
    }
}
