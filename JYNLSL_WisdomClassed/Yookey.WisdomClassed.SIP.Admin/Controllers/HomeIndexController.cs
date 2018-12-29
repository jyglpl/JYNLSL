using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;

using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;

using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.HomeIndex
{
    public class HomeIndexController : BaseController
    {
        private readonly CrmUserBll _crmUserBll = new CrmUserBll(); //用户

        private readonly CrmCompanyBll _crmCompanyBll = new CrmCompanyBll();//机构信息
        private readonly CrmDepartmentBll _crmDepartmentBll = new CrmDepartmentBll(); //部门

        //
        // GET: /HomeIndex/

        /// <summary>
        /// 系统主界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult  MainPage()
        {
            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            return View();
        }


        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// 框架首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Main(string Source)
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            if (Source == "1" || Source == "2" || Source == "3" || Source == "4")
            {
                Source = "000" + Source;
            }
            ViewBag.Source = Source;
            return View();
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public string LoadAccordionMenu(string source, string para)
        {
            try
            {
                if (string.IsNullOrEmpty(source))
                {
                    if (!string.IsNullOrEmpty(para))
                    {
                        source = "0000";
                    }
                    else
                    {
                        source = "0001";
                    }
                }
                var currentUser = CurrentUser.CrmUser;
                var list = new List<ComMenuEntity>();
                var userMenus = new ComMenuBll().GetAllMenu(new ComMenuEntity() { ParentMenuId = source });
                if (userMenus.Any())
                {
                    list.AddRange(userMenus);
                    var secMenuList = new ComMenuBll().GetAllMenu(new ComMenuEntity()).Where(x => userMenus.Any(y => y.Id == x.ParentMenuId)).ToList();
                    if (secMenuList.Any())
                    {
                        list.AddRange(secMenuList);
                    }
                }
                var menuList = list.Select(comMenuEntity => new TreeMenuNode()
                {
                    ModuleId = comMenuEntity.Id,
                    FullName = comMenuEntity.MenuName,
                    Icon = comMenuEntity.Action,
                    Location = comMenuEntity.MenuUrl,
                    ParentId = string.IsNullOrEmpty(comMenuEntity.ParentMenuId) ? "" : comMenuEntity.ParentMenuId,
                    MenuLevel = comMenuEntity.MenuLevel
                }).ToList();
                //var json = Json(menuList, JsonRequestBehavior.AllowGet);

                return JsonConvert.SerializeObject(menuList);
            }
            catch (Exception)
            {
                return null;
            }
        }




        /// <summary>
        /// 加载树
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadTree()
        {
            List<MenuModels> list = InitTree();
            return Json(list, "text/html", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 初始化树 默认找出顶级菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuModels> InitTree()
        {
            var TreeList = new ComMenuBll().GetAllMenu(new ComMenuEntity());
            List<MenuModels> rootNode = new List<MenuModels>();
            foreach (var plist in TreeList.Where(t => t.ParentMenuId == "00001"))
            {
                MenuModels jt = new MenuModels();
                jt.id = plist.Id;
                jt.text = plist.MenuName;
                jt.parentid = plist.ParentMenuId;
                jt.icon = "";
                jt.url = plist.MenuUrl;
                jt.attributes = CreateUrl(TreeList, jt);
                jt.menus = CreateChildTree(TreeList, jt);
                rootNode.Add(jt);
            }
            return rootNode;
        }
        /// <summary>
        /// 递归生成子树
        /// </summary>
        /// <param name="TreeList"></param>
        /// <param name="jt"></param>
        /// <returns></returns>
        private List<MenuModels> CreateChildTree(List<ComMenuEntity> TreeList, MenuModels jt)
        {
            string keyid = jt.id;//根节点ID
            List<MenuModels> nodeList = new List<MenuModels>();
            var children = TreeList.Where(t => t.ParentMenuId == keyid);
            foreach (var chl in children)
            {
                MenuModels node = new MenuModels();
                node.id = chl.Id;
                node.text = chl.MenuName;
                node.parentid = chl.ParentMenuId;
                node.icon = "";
                node.url = chl.MenuUrl;
                node.attributes = CreateUrl(TreeList, node);
                node.menus = CreateChildTree(TreeList, node);
                nodeList.Add(node);
            }
            return nodeList;
        }

        /// <summary>
        /// 把Url属性添加到attribute中，如果需要别的属性，也可以在这里添加
        /// </summary>
        /// <param name="TreeList"></param>
        /// <param name="jt"></param>
        /// <returns></returns>
        private Dictionary<string, string> CreateUrl(List<ComMenuEntity> TreeList, MenuModels jt)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string keyid = jt.id;
            var urlList = TreeList.Where(t => t.Id == keyid).SingleOrDefault();
            string Sysurl = urlList.MenuUrl;
            //string Indexurl = urlList.IndexUrl;
            dic.Add("sysurl", Sysurl);
            //dic.Add("indurl", Indexurl);
            dic.Add("close", "true");
            return dic;
        }



        #region 日常办公
        /// <summary>
        /// 日常办公页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OfficeIndex()
        {
            var user = CurrentUser.CrmUser;
            ViewBag.UserName = user.UserName;
            return View();
        }


        /// <summary>
        /// 日常办公页面右侧初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OfficeRight()
        {
            return View();
        }



        public class ScoreEntity
        {
            /// <summary>
            /// 部门
            /// </summary>
            public string deptName { get; set; }

            /// <summary>
            /// 平均分
            /// </summary>
            public double score { get; set; }
        }

        /// <summary>
        /// 获取前10学习 时长


        public class LongEntity
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 时长
            /// </summary>
            public double Time { get; set; }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>


        public class Statistics
        {
            /// <summary>
            /// 获取全部课件总数
            /// </summary>
            public int allCourse { get; set; }

            /// <summary>
            /// 获取视频类课件总数
            /// </summary>
            public int videoCourse { get; set; }

            /// <summary>
            /// 获取音频类课件总数
            /// </summary>
            public int audioCourse { get; set; }

            /// <summary>
            /// 获取图文类课件总数
            /// </summary>
            public int pictureCourse { get; set; }

            /// <summary>
            /// 获取参考人员总数
            /// </summary>
            public int joinUserCount { get; set; }

            /// <summary>
            /// 获取参考次数
            /// </summary>
            public int joinCount { get; set; }
        }
        #endregion





        #region 系統框架首頁
        public ActionResult AccordionIndex()
        {
            return View();
        }
        #endregion

    }
}
