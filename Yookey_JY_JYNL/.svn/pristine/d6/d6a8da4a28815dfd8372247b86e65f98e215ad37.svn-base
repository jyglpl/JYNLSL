using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class SystemPageController : BaseController
    {
        //
        // GET: /SystemPage/
        public ActionResult Index(string menuID)
        {
            ComMenuBll cb = new ComMenuBll();
            ComMenuEntity cm = cb.GetMenuByID(menuID);
            return View(cm);
        }

        public ActionResult Left(string menuID)
        {
            ViewBag.menuId = menuID;
            return View();
        }
        public ActionResult Mid()
        {
            return View();
        }

        public ActionResult Right(string menuID)
        {

            ComMenuEntity cm = new ComMenuBll().GetMenuByID(menuID);
            List<ComMenuEntity> allmenu = new ComMenuBll().GetUserMenus(CurrentUser.CrmUser.Id) as List<ComMenuEntity>;
            Dictionary<ComMenuEntity, List<ComMenuEntity>> dic = new Dictionary<ComMenuEntity, List<ComMenuEntity>>();
            List<ComMenuEntity> menuLsit = allmenu.Where(t => t.ParentMenuId == menuID).ToList();
            List<ComMenuEntity> temp;
            int count = 0;
            foreach (ComMenuEntity item in menuLsit)
            {
                temp = allmenu.Where(t => t.MenuLevel > 1 && t.Id.Substring(0, 8).Equals(item.Id) && !string.IsNullOrEmpty(t.MenuUrl)).ToList();
                foreach (var item2 in temp)
                {
                    item2.MenuUrl = GetUrl(item2.Id);
                }
                if (temp.Count > 0)
                {
                    dic.Add(item, temp);
                }
                else
                {
                    item.MenuUrl = GetUrl(item.Id);
                    temp = new List<ComMenuEntity>();
                    temp.Add(item);
                    dic.Add(item, temp);
                }
                if (count == 3)
                {
                    break;
                }
                count++;

            }

            ViewData["MenuList"] = dic;
            return View(cm);
        }

        /// <summary>
        /// 获取系统功能菜单Json 数据
        /// 添加人：周 鹏
        /// 添加时间：2014-03-26
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public JsonResult GetLeftMenu(string menuId)
        {
            ComMenuEntity titleMenu = new ComMenuBll().GetMenuByID(menuId);
            var menus = new ComMenuBll().GetUserMenus(CurrentUser.CrmUser.Id);
            menus = menus.Where(t => t.Id.Substring(0, 4).ToString().Equals(menuId) && !t.Id.Equals(menuId)).ToList();
            var menuList = menus.Select(comMenuEntity => new ZTreeNode()
            {
                id = comMenuEntity.Id,
                pId = comMenuEntity.ParentMenuId,
                name = comMenuEntity.MenuName,
                openFlag=comMenuEntity.OpenType.ToString(),
                icon = string.IsNullOrEmpty(comMenuEntity.IconPic) ? "/Content/Theme/Default/Images/treesystem.gif" : comMenuEntity.IconPic,
                open = false
            }).ToList();

            var rtEntity = new StatusModel<ZTreeNode>
            {
                rtData = menuList,
                rtMsrg = titleMenu.MenuName,
                rtState = 0

            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUrlLink(string id)
        {
            int openflag=0;
            string linkUrl = GetUrl(id,out openflag);

            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = linkUrl+"|"+openflag.ToString(),
                rtState = 0
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        public string GetUrl(string id)
        {
            ComMenuEntity cm = new ComMenuBll().GetMenuByID(id);
            string systemid = cm.SystemId;
            string url = cm.MenuUrl;
            string linkUrl = cm.MenuUrl;
            if (!url.Equals(string.Empty))
            {
                if (!string.IsNullOrEmpty(systemid))
                {

                    //应用系统地址
                    var attrValues =
                        new ComAttributeValueBll().GetSearchResult(new ComAttributeValueEntity()
                        {
                            RsId = systemid,
                            AttributeId = 1
                        });

                    var attrUserLogin = new CrmUserMapBll().GetAllUserMaps(CurrentUser.CrmUser.Id, systemid);

                    if (attrValues.Any() && attrUserLogin.Any())
                    {
                        var chqm = url.IndexOf("?", StringComparison.Ordinal);
                        var parameter = attrUserLogin[0].LoginName + "|" + DateTime.Now.ToString(AppConst.DateFormatLong);
                        var md5Parm = HttpUtility.UrlEncode(CommonMethod.Encrypt(parameter, AppConst.EncryptKey, AppConst.EncryptKey));
                        //拼接URL
                        linkUrl = attrValues[0].Value + url + (chqm == -1 ? "?" : "&") + "uid=" + md5Parm;
                    }
                }
                else
                    linkUrl = "../" + url;

            }            
            return linkUrl;
        }

        public string GetUrl(string id,out int openFlag)
        {
            ComMenuEntity cm = new ComMenuBll().GetMenuByID(id);
            string systemid = cm.SystemId;
            string url = cm.MenuUrl;
            string linkUrl = cm.MenuUrl;
            if (!url.Equals(string.Empty))
            {
                if (!string.IsNullOrEmpty(systemid))
                {

                    //应用系统地址
                    var attrValues =
                        new ComAttributeValueBll().GetSearchResult(new ComAttributeValueEntity()
                        {
                            RsId = systemid,
                            AttributeId = 1
                        });

                    var attrUserLogin = new CrmUserMapBll().GetAllUserMaps(CurrentUser.CrmUser.Id, systemid);

                    if (attrValues.Any() && attrUserLogin.Any())
                    {
                        var chqm = url.IndexOf("?", StringComparison.Ordinal);
                        var parameter = attrUserLogin[0].LoginName + "|" + DateTime.Now.ToString(AppConst.DateFormatLong);
                        var md5Parm = HttpUtility.UrlEncode(CommonMethod.Encrypt(parameter, AppConst.EncryptKey, AppConst.EncryptKey));

                        //拼接URL
                        linkUrl = attrValues[0].Value + url + (chqm == -1 ? "?" : "&") + "uid=" + md5Parm;
                    }
                }
                else
                    linkUrl = "../" + url;

            }
            openFlag = cm.OpenType;
            return linkUrl;
        }
    }
}
