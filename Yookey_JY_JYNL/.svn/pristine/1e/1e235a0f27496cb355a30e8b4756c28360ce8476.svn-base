using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Work;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Work;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Work
{
    public class FolderController : BaseController
    {
        private FolderBll _folderBll = new FolderBll();
        private FolderPermitionBll _folderPermitionBll = new FolderPermitionBll();
        //
        // GET: /Folder/

        #region 视图
        /// <summary>
        /// 文档管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

       
        /// <summary>
        /// 创建文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="ParentId">父目录Id</param>
        /// <param name="ParentName">父目录名称</param>
        /// <returns></returns>
        public ActionResult AddFolder(string ParentId,string ParentName) {
            ViewBag.ParentId = ParentId;
            ViewBag.ParentName = ParentName;
            return View();
        }

        /// <summary>
        /// 创建文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="ParentId">父目录Id</param>
        /// <param name="ParentName">父目录名称</param>
        /// <returns></returns>
        public ActionResult AddFile(string ParentId, string ParentName)
        {
            ViewBag.ParentId = ParentId;
            ViewBag.ParentName = ParentName;
            return View();
        }

        /// <summary>
        /// 设置权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        public ActionResult SetPermition(string FolderId) {
            //当前部门Id
            ViewBag.FolderId = FolderId;
            List<string> lstInfo=_folderPermitionBll.GetShareFolderUserInfo(FolderId, FolderPermitionEntity.PermitionTypeEnum.View);
            if (lstInfo.Count >= 2)
            {
                ViewBag.Ids = lstInfo[0];
                ViewBag.Names = lstInfo[1];
            }
            else {
                ViewBag.Ids = "";
                ViewBag.Names = "";
            }

            return View();
        }
        #endregion

        #region Ajax请求数据
        /// <summary>
        /// 获取所有部门
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        public JsonResult GetAllDepartments(string FolderId)
        {
            //获取所有部门
            var Depts = new BaseDepartmentBll().GetAllDetachment("all");
             List<TreeNode> nodes = new List<TreeNode>();
            //根节点
             TreeNode rootNode=new TreeNode()
             {
                 id = "",
                 text = "所有部门",
                 value = "",
                 img = "/Content/Images/Icon16/church.png",//tree.js处理路径
                 showcheck = true,
                 isexpand = true,
                 complete = true,
                 hasChildren = false,
                 ChildNodes = null
             };
            //所有部门数据
             List<TreeNode> deptNodes = Depts.Select(x => new TreeNode()
             {
                 id = x.DepartmentId,
                 text = x.FullName,
                 value = "dept",
                 img = "/Content/Images/Icon16/circus.png",//tree.js处理路径
                 showcheck = true,
                 isexpand = false,
                 complete = true,
                 hasChildren = false,
                 ChildNodes = null
             }).ToList();

             rootNode.hasChildren = deptNodes.Count > 0;
             rootNode.ChildNodes = deptNodes;
            //选中人员
             List<string> lstIds=_folderPermitionBll.GetShareFolderUserId(FolderId, FolderPermitionEntity.PermitionTypeEnum.View);

            //绑定人员
             List<TreeNode> user = null;
             for (int i = 0, j = deptNodes.Count; i < j; i++)
             {
                 user = GetUserTreeNodesByDeptId(deptNodes[i].id, lstIds);
                 deptNodes[i].hasChildren = user.Count > 0;
                 deptNodes[i].ChildNodes = user;
 
             }
             nodes.Add(rootNode);
             return Json(nodes, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 获取文件列表（文件夹和文件）
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        public string GetFileList(string FolderId)
        {
           var data= _folderBll.GetFolderFilesAndFolders(FolderId, CurrentUser.CrmUser.Id);
           var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
           var result = JsonConvert.SerializeObject(data, timeConverter);
           return result;

        }

        /// <summary>
        /// 获取当前用户文件树形数据
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCurrentUserFolders()
        {
            var user = CurrentUser.CrmUser;
            #region 自己的文件夹
            List<FolderEntity> lstFolders= _folderBll.GetUserFolders(user.Id);
           List<TreeNode> nodes = new List<TreeNode>();
            nodes.Add(new TreeNode()
                {
                    id = "",
                    text = "我的文档",
                    value = "",
                    img = "/Content/Images/Icon16/folder_user.png",//tree.js处理路径
                    showcheck = false,
                    isexpand = true,
                    complete = true,
                    hasChildren = false,
                    ChildNodes = null
                });
            GetChildFolders(nodes, lstFolders);
            #endregion
            #region 共享文件夹
            //共享文件夹
            List<FolderEntity> lstShareFolder = _folderBll.GetShareFolder(user.Id);
            List<TreeNode> treeShareFolder = lstShareFolder.Select(x => new TreeNode() {
                id = x.Id,
                text = string.Format("{0}({1})",x.FolderName,x.CreateBy),
                value = "share",//共享文件夹
                img = "/Content/Images/Icon16/network_folder.png",//tree.js处理路径
                showcheck = false,
                isexpand = true,
                complete = true,
                hasChildren = false,
                ChildNodes = null
            }).ToList();
            nodes.Add(new TreeNode()
            {
                id = "share",
                text = "共享文档",
                value = "share",
                img = "/Content/Images/Icon16/folder_explore.png",//tree.js处理路径
                showcheck = false,
                isexpand = true,
                complete = true,
                hasChildren = treeShareFolder.Count > 0,
                ChildNodes = treeShareFolder
            });
            #endregion
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取目录的面包屑
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        public JsonResult GetActiveDirPath(string FolderId) {
            var user = CurrentUser.CrmUser;
             List<string> path= _folderBll.GetActiveFolderPath(FolderId,user.Id);
             return Json(path,JsonRequestBehavior.AllowGet);
        }
      

        #endregion

        #region Ajax提交数据

        /// <summary>
        /// 创建文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="ParentId">父目录Id</param>
        /// <param name="FolderName">文件夹名称</param>
        /// <returns></returns>
        public JsonResult CreateFolder(string ParentId, string FolderName)
        {
            var user = CurrentUser.CrmUser;
            string Id = "";
            string msg = "";
            bool state=false;
            //判断文件夹是否存在
            if (!_folderBll.ExistFolderName(ParentId, FolderName, user.Id))
            {
                FolderEntity entity = new FolderEntity();
                entity.ParentId = ParentId;
                entity.FolderName = FolderName;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                Id = _folderBll.CreateOrUpdateFolder(entity);
                state=true;
            }
            else
                msg += FolderName+"文件夹已经存在！";
            return Json(new { State=state,Id=Id,Msg=msg},JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <returns></returns>
        public JsonResult DeleteFolder(string FolderId) {
            _folderBll.DeleteFolder(FolderId, CurrentUser.CrmUser.Id, CurrentUser.CrmUser.UserName);
            return Json(new { State=true},JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除文件
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public JsonResult DeleteFile(string FilePath) {

            FilePath = Server.UrlDecode(FilePath);
            bool state = true;
            string msg = "";
            try
            {
                _folderBll.DeleteFile(FilePath);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return Json(new { State=state,Msg=msg});
        }

        /// <summary>
        /// 保存权限
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UsersContext"></param>
        /// <returns></returns>
        public string SavePermition(string FolderId, string UsersContext)
        {
            List<string> Users = UsersContext.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string result = "";
            //todo：默认设置查看权限（后期可能会增加其他权限）
            result = _folderPermitionBll.SetFolderPermition(FolderId, Users,FolderPermitionEntity.PermitionTypeEnum.View,CurrentUser.CrmUser).ToString();
            return result;
        }

        #endregion

        #region 逻辑代码区（由于treenode在view层无法封装到bll层）

        /// <summary>
        /// 获取部门下的所有人员
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        private List<TreeNode> GetUserTreeNodesByDeptId(string DeptId,List<string> lstSelected)
        {
            var users = new BaseUserBll().GetDeptsUsers(new BaseUserEntity { DeptId = DeptId }).ToList();
            //todo: 父节点选中状态没有递归上去（有待优化）
            List<TreeNode> treeNodes = users.Select(x => new TreeNode()
            {
                id = x.Id,
                text = x.UserName,
                value = "user",
                img = "/Content/Images/Icon16/peak_cap.png",//tree.js处理路径
                showcheck = true,
                isexpand = false,
                complete = true,
                hasChildren = false,
                ChildNodes = null,
                checkstate=lstSelected.Exists(m=>m==x.Id) ? 1 :0
            }).ToList();
            return treeNodes;
        }

        /// <summary>
        /// 递回获取子目录
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="lstFolders"></param>
        private void GetChildFolders(List<TreeNode> nodes, List<FolderEntity> lstFolders)
        {
            foreach (TreeNode node in nodes)
            {
                List<TreeNode> childNodes = lstFolders.Where(x => x.ParentId == node.id).Select(x => new TreeNode()
                {
                    id = x.Id,
                    text = x.FolderName,
                    value = x.Id,
                    img = "/Content/Images/Icon16/folder.png",//tree.js处理路径
                    showcheck = false,
                    isexpand = false,
                    complete = true,
                    hasChildren = false,
                    ChildNodes = null
                }).ToList();
                node.hasChildren = childNodes.Count > 0;
                node.ChildNodes = childNodes;
                GetChildFolders(childNodes, lstFolders);
            }

        }
        #endregion

    }
}
