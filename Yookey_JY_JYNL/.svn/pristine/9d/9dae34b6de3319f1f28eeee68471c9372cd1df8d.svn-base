using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{

    public class PermissionController : BaseController
    {
        CrmMessageWorkBll _CMessage = new CrmMessageWorkBll();
        /// <summary>
        /// 收文分配角色成员
        /// </summary>
        /// <returns></returns>
        public ActionResult AllotMember(string SwId, string conttypeId, string titles, string Address, string Unit, string CBR, string ShouWenTime, string XiandinTime, string Content,string State)
        {
            ViewBag.SwId = SwId;//收文主键Id
            ViewBag.conttypeId = conttypeId;//内容类型Id
            ViewBag.titles = titles;//文件主题
            ViewBag.formaddress = Address;//页面位置
            ViewBag.Unit = Unit;
            ViewBag.CBR = CBR;
            ViewBag.ShouWenTime = ShouWenTime;
            ViewBag.XiandinTime = XiandinTime;
            ViewBag.Content = Content;
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 公文分配角色成员
        /// </summary>
        /// <returns></returns>
        public ActionResult OfficialAllotMember(string OfficialId, string conttypeId, string titles, string Address, string LWDW, string WH, string QCR, string BMFZR, string Startime, string Endtime)
        {
            ViewBag.OfficialId = OfficialId;//公文主键Id
            ViewBag.conttypeId = conttypeId;//内容类型Id
            ViewBag.titles = titles;//文件主题
            ViewBag.formaddress = Address;//页面位置
            ViewBag.LWDW = LWDW;
            ViewBag.WH = WH;
            ViewBag.QCR = QCR;
            ViewBag.BMFZR = BMFZR;
            ViewBag.Startime = Startime;
            ViewBag.Endtime = Endtime;
            return View();
        }

        /// <summary>
        /// 角色成员批量设置
        /// </summary>
        /// <returns></returns>
        public ActionResult AllotMemberBatch()
        {
            return View();
        }

        /// <summary>
        /// 权限设置
        /// </summary>
        /// <param name="id">编号：角色、用户</param>
        /// <param name="type">设置类型：角色、用户</param>
        /// <returns></returns>
        public ActionResult AllotPermission(string id, string type)
        {
            ViewData["Id"] = id;
            ViewData["IdType"] = type;
            List<ComMenuEntity> menus;
            if (!string.IsNullOrEmpty(type) && type.Equals("user"))
            {
                menus = new ComMenuBll().GetUserMenus(id);    //人员菜单
            }
            else
            {
                menus = new ComMenuBll().GetRoleMenus(id);    //角色菜单
            }
            ViewData["MenuList"] = menus;
            var allMenus = new ComMenuBll().GetAllMenu(new ComMenuEntity());
            return View(allMenus);
        }

        #region 单位和角色TreeJson

        /// <summary>
        /// 单位与角色TreeJson
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public JsonResult ScopeRoleList()
        {
            var companys = new CrmCompanyBll().GetAllCompany();
            var roles = new CrmRoleBll().GetAllRoles();

            //企业
            var topCompany = companys.Where(x => x.ParentId == "0").ToList();
            var result = (from companyEntity in topCompany
                          let childs = ChildCompany(companys, roles, companyEntity.Id)
                          select new TreeNode()
                          {
                              id = companyEntity.Id,
                              text = companyEntity.FullName,
                              value = "company",
                              img = "/Content/Images/Icon16/molecule.png",//tree.js处理路径
                              showcheck = false,
                              isexpand = true,
                              complete = true,
                              hasChildren = childs.Count > 0,
                              ChildNodes = childs
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载子公司信息
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companys">单位数据集</param>
        /// <param name="roles">角色数据集</param>
        /// <param name="parentId">公司父编号</param>
        /// <returns></returns>
        public List<TreeNode> ChildCompany(IEnumerable<CrmCompanyEntity> companys, IEnumerable<CrmRoleEntity> roles, string parentId)
        {
            var baseCompanyEntities = companys as CrmCompanyEntity[] ?? companys.ToArray();
            var childList = baseCompanyEntities.Where(t => t.ParentId == parentId).ToList();

            var list = new List<TreeNode>();
            foreach (var companyEntity in childList)
            {
                var childs = ChildCompany(baseCompanyEntities, roles, companyEntity.Id);

                var roleList = ChildRole(roles, companyEntity.Id);
                if (roleList.Any())
                {
                    childs.AddRange(roleList);
                }

                list.Add(new TreeNode()
                {
                    id = companyEntity.Id,
                    text = companyEntity.FullName,
                    value = "company",
                    img = "/Content/Images/Icon16/hostname.png", //tree.js处理路径
                    showcheck = false,
                    isexpand = false,
                    complete = true,
                    hasChildren = childs.Count > 0,
                    ChildNodes = childs
                });
            }
            return list;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roles">角色集</param>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public List<TreeNode> ChildRole(IEnumerable<CrmRoleEntity> roles, string companyId)
        {
            var baseRoleEntities = roles as CrmRoleEntity[] ?? roles.ToArray();
            var childList = baseRoleEntities.Where(t => t.CompanyId == companyId).ToList();
            return (from companyEntity in childList
                    select new TreeNode()
                    {
                        id = companyEntity.Id,
                        text = companyEntity.FullName,
                        value = "role",
                        img = "/Content/Images/Icon16/role.png",
                        showcheck = false,
                        isexpand = true,
                        complete = true,
                        hasChildren = false,
                        ChildNodes = null
                    }).ToList();
        }

        #endregion

        /// <summary>
        /// 根据角色请求人员
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public string MemberList(string companyId, string roleId)
        {
            try
            {
                var str = new StringBuilder();
                if (!string.IsNullOrEmpty(roleId))
                {
                    var users = new CrmUserBll().GetUsersByRole(companyId, roleId);   //根据角色编号查询已设置和未设置的人员
                    if (users.Any())
                    {
                        foreach (var userEntity in users)
                        {
                            //显示的图标
                            var icon = !string.IsNullOrEmpty(userEntity.Gender) && userEntity.Gender.Equals("女") ? "user_female.png" : "user_green.png";
                            str.AppendFormat("<li class='{0} {1}'>", userEntity.DepartmentId, userEntity.IsSetRole == 1 ? "selected" : "");
                            str.AppendFormat("<a {0} id='{1}' title='{2}'><img src='/Content/Images/Icon16/{3}'>{4}</a><i></i>",
                                userEntity.IsSetRole == 1 ? "class='a_selected'" : "",
                                userEntity.Id,
                                "账号：" + userEntity.Account,
                                icon,
                                userEntity.RealName);
                            str.Append("</li>");
                        }
                    }
                    return str.ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 保存收文待办事宜
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="processinstanceId"></param>
        /// <param name="sendactivityId"></param>
        /// <param name="activityinstanceId"></param>
        /// <param name="user"></param>
        /// <param name="OfficialId"></param>
        /// <param name="formdata"></param>
        /// <param name="formaddress"></param>
        /// <param name="conttypeId"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public string UnfinishedThing(string titles, string processinstanceId, string sendactivityId, string activityinstanceId, string user, string SwId, string formdata, string formaddress, string conttypeId, string note)
        {
            var isOk = false;
            string rtMsrg;
            int rtState;
            string[] UserId = user.Split(',').ToArray();
            try
            {
                for (int i = 0; i < UserId.Length; i++)
                {
                    var EntEntity = new CrmMessageWorkEntity();
                    EntEntity.Id = Guid.NewGuid().ToString();
                    EntEntity.Titles = titles;
                    EntEntity.ProcessInstanceID = processinstanceId;
                    EntEntity.SendActivityID = sendactivityId;
                    EntEntity.ActivityInstanceID = activityinstanceId;
                    EntEntity.StartDate = DateTime.Now;
                    EntEntity.SenderID = CurrentUser.CrmUser.Id;
                    EntEntity.ExecuteDate = DateTime.Now;
                    EntEntity.ActionerID = UserId[i];
                    EntEntity.FormID = SwId;
                    EntEntity.FormData = formdata;
                    EntEntity.FormAddress = formaddress;
                    EntEntity.ContentTypeID = conttypeId;
                    EntEntity.IsReply = 0;
                    EntEntity.State = 0;
                    EntEntity.Note = note;
                    EntEntity.RowStatus = 1;
                    EntEntity.CreatorId = "";
                    EntEntity.CreateBy = "";
                    EntEntity.CreateOn = DateTime.Now;
                    EntEntity.UpdateId = "";
                    EntEntity.UpdateBy = "";
                    EntEntity.UpdateOn = DateTime.Now;
                    isOk = _CMessage.Insert(EntEntity);
                }
                rtMsrg = isOk ? "操作成功" : "操作失败";
                rtState = isOk ? (int)OperationState.Success : (int)OperationState.Failure;
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

        /// <summary>
        /// 保存发文待办事宜
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="processinstanceId"></param>
        /// <param name="sendactivityId"></param>
        /// <param name="activityinstanceId"></param>
        /// <param name="user"></param>
        /// <param name="OfficialId"></param>
        /// <param name="formdata"></param>
        /// <param name="formaddress"></param>
        /// <param name="conttypeId"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public string OfficialUnfinishedThing(string titles, string processinstanceId, string sendactivityId, string activityinstanceId, string user, string OfficialId, string formdata, string formaddress, string conttypeId, string note)
        {
            var isOk = false;
            string rtMsrg;
            int rtState;
            string[] UserId = user.Split(',').ToArray();
            try
            {
                for (int i = 0; i < UserId.Length; i++)
                {
                    var EntEntity = new CrmMessageWorkEntity();
                    EntEntity.Id = Guid.NewGuid().ToString();
                    EntEntity.Titles = titles;
                    EntEntity.ProcessInstanceID = processinstanceId;
                    EntEntity.SendActivityID = sendactivityId;
                    EntEntity.ActivityInstanceID = activityinstanceId;
                    EntEntity.StartDate = DateTime.Now;
                    EntEntity.SenderID = CurrentUser.CrmUser.Id;
                    EntEntity.ExecuteDate = DateTime.Now;
                    EntEntity.ActionerID = UserId[i];
                    EntEntity.FormID = OfficialId;
                    EntEntity.FormData = formdata;
                    EntEntity.FormAddress = formaddress;
                    EntEntity.ContentTypeID = conttypeId;
                    EntEntity.IsReply = 0;
                    EntEntity.State = 0;
                    EntEntity.Note = note;
                    EntEntity.RowStatus = 1;
                    EntEntity.CreatorId = "";
                    EntEntity.CreateBy = "";
                    EntEntity.CreateOn = DateTime.Now;
                    EntEntity.UpdateId = "";
                    EntEntity.UpdateBy = "";
                    EntEntity.UpdateOn = DateTime.Now;
                    isOk = _CMessage.Insert(EntEntity);
                }
                rtMsrg = isOk ? "操作成功" : "操作失败";
                rtState = isOk ? (int)OperationState.Success : (int)OperationState.Failure;
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

        /// <summary>
        /// 保存权限设置
        /// </summary>
        /// <param name="formCollection">FormCollection</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SavePermission(FormCollection formCollection)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var id = formCollection["Id"];
                var idType = formCollection["idType"];

                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(idType))
                {
                    var flag = false;
                    if (idType.Equals("role")) //设置角色权限
                    {
                        flag = new CrmRoleMenuBll().UpdateRoleMenu(id, formCollection["chkRoleMenu"]);
                    }
                    else if (idType.Equals("user")) //设置人员权限
                    {
                        flag = new CrmRoleMenuBll().UpdateUserMenu(id, formCollection["chkRoleMenu"]);
                    }
                    rtMsrg = flag ? "保存成功" : "保存失败";
                    rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
                }
                else
                {
                    rtMsrg = "保存失败，请确定参数是否缺失！";
                    rtState = (int)OperationState.Failure;
                }
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
            return Json(rtEntity);
        }



    }
}
