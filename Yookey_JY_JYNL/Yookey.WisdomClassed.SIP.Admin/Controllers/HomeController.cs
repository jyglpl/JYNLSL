using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using System.Threading.Tasks;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 页面正在开发中
        /// </summary>
        /// <returns></returns>
        public ActionResult Development()
        {
            return View();
        }

        #region 手风琴菜单
        //
        // GET: /Home/AccordionIndex
        public ActionResult Index()
        {
            var user = CurrentUser.CrmUser;   //当前登录对象
            ViewBag.UseName = user.UserName;
            ViewBag.Account = user.LoginName + "（" + user.UserName + "）";

            //var isPrim = ActionAuthorization.IsAllowed(HttpContext, "LochusFlight", "FlightBackUp");

            return View();
        }

        //
        // GET: /Home/AccordionPage
        public ActionResult Page()
        {
            //违法停车权限
            ViewBag.IsPenaltyParkingIndex = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PenaltyParking", "Index"); //违法停车主界面权限

            //案件办理
            ViewBag.PenaltyCaseIndex = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "PenaltyCase", "Index");         //案件办理主界面权限

            //暂扣物品
            ViewBag.TempDetainIndex = new MembershipManager().VerificationPermissions(CurrentUser.CrmUser.Id, "TempDetain", "Index");           //暂扣物品主界面权限

            return View();
        }

        /// <summary>
        /// 加载手风琴菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public JsonResult LoadAccordionMenu()
        {
            try
            {
                var currentUser = CurrentUser.CrmUser;
                var userMenus = new ComMenuBll().GetUserMenus(currentUser.Id).Where(x => x.IsMenu == 1);
                var menuList = userMenus.Select(comMenuEntity => new TreeMenuNode()
                {
                    ModuleId = comMenuEntity.Id,
                    FullName = comMenuEntity.MenuName,
                    Icon = string.IsNullOrEmpty(comMenuEntity.IconPic) ? "messenger.png" : comMenuEntity.IconPic,
                    Location = comMenuEntity.MenuUrl,
                    ParentId = string.IsNullOrEmpty(comMenuEntity.ParentMenuId) ? "" : comMenuEntity.ParentMenuId,
                    MenuLevel = comMenuEntity.MenuLevel
                }).ToList();

                var json = Json(menuList, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 主题风格设置
        //
        // GET: /Home/SkinIndex
        public ActionResult SkinIndex()
        {
            return View();
        }

        //
        // POST: /Home/SwitchTheme
        public JsonResult SwitchTheme(string uItheme)
        {
            try
            {
                //设置Cookie信息
                CookieUtil.SetCookie(AppConst.Uitheme, uItheme, DateTime.MaxValue);
                var rtEntity = new StatusModel<TreeMenuNode>
                {
                    rtData = null,
                    rtMsrg = "成功",
                    rtState = 0
                };

                var json = Json(rtEntity, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region 树形菜单

        //
        // GET: /Home/TreeIndex
        public ActionResult TreeIndex()
        {
            return View();
        }

        //
        // GET: /Home/TreePage
        public ActionResult TreePage()
        {
            return View();
        }

        /// <summary>
        /// 加载菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="moduleId">菜单编号</param>
        /// <returns></returns>
        public JsonResult LoadTreeMenu(string moduleId)
        {
            try
            {
                var currentUser = CurrentUser.CrmUser;
                var userMenus = new ComMenuBll().GetUserMenus(currentUser.Id);

                List<ComMenuEntity> childMenus;
                if (!string.IsNullOrEmpty(moduleId))
                {
                    childMenus = userMenus.Where(x => x.ParentMenuId == moduleId).ToList();
                }
                else
                {
                    return null;
                }
                var menuList = (from comMenuEntity in childMenus
                                let childs = ChildTree(userMenus, comMenuEntity.Id)
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


        #endregion

        #region Windows 菜单

        //
        // GET: /Home/StartIndex
        public ActionResult StartIndex()
        {
            var user = CurrentUser.CrmUser;   //当前登录对象
            ViewBag.Account = user.LoginName + "（" + user.UserName + "）";
            return View();
        }

        //
        // GET: /Home/StartPanel
        public ActionResult StartPanel()
        {
            return View();
        }


        #endregion

        /// <summary>
        /// 操作手册
        /// 添加人：周 鹏
        /// 添加时间：2015-07-10
        /// </summary>
        public ActionResult Assist()
        {
            return View();
        }

        /// <summary>
        /// 通讯录
        /// 添加人：叶念
        /// 添加时间： 2017-03-24
        /// </summary>
        /// <returns></returns>
        public ActionResult Contacts()
        {
            return View();
        }
        /// <summary>
        /// 请求人员数据列表
        /// </summary>
        /// <param name="keywords">查询关键字</param>
        /// <param name="companyId">企业编号</param>
        /// <param name="departmentId">部门编号</param>
        /// <param name="rows">查询条数</param>
        /// <param name="page">当前页</param>
        /// <returns></returns>
        public string UserList(string keywords, string companyId, string departmentId, int rows, int page)
        {
            var data = new CrmUserBll().GetSearchResult(new CrmUserEntity()
            {
                RealName = keywords,
                CompanyId = companyId,
                DepartmentId = departmentId,
                PageIndex = page,
                PageSize = rows
            });
            return CommonMethod.PageToJson(data);
        }
    }
}
