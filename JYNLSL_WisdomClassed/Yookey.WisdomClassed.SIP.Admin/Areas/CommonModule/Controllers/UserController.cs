using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Common.Security;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;


namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /CommonModule/User/
        public ActionResult Index()
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

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">部门主键编号</param>
        /// <returns>删除结果</returns>
        [HttpPost]
        public string DeleteUser(string userId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = new CrmUserBll().BatchDelete(userId);
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


        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">部门主键编号</param>
        /// <returns>删除结果</returns>
        [HttpPost]
        public string ResetPwd(string userId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var entity = new CrmUserBll().Get(userId);
                entity.Password = DESHelper.ToDESEncrypt("123456", AppConst.EncryptKey);   //初始默认密码123456
                var flag = new CrmUserBll().Update(entity) > 0;
                rtMsrg = flag ? "密码已重置为：123456" : "密码已重置失败，请联系管理员";
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


        /// <summary>
        /// 新增/编辑
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <param name="departmentId">部门主键编号</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public ActionResult Edit(string companyId, string departmentId, string userId)
        {
            var entity = new CrmUserEntity();
            string roles = "";
            if (!string.IsNullOrEmpty(userId))
            {
                entity = new CrmUserBll().Get(userId);
                var userRole = new CrmUserRoleBll().GetSearchResult(new CrmUserRoleEntity() { UserId = userId });
                if (userRole != null && userRole.Any())
                {
                    foreach (var crmUserRoleEntity in userRole)
                    {
                        var roleEntity = new CrmRoleBll().Get(crmUserRoleEntity.RoleId);
                        if (roleEntity != null)
                            roles += roleEntity.FullName + ",";
                    }
                }
            }
            else if (!string.IsNullOrEmpty(companyId) && !string.IsNullOrEmpty(departmentId))
            {
                entity.CompanyId = companyId;
                entity.DepartmentId = departmentId;
            }
            ViewBag.Roles = roles;
            return View(entity);
        }


        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">用户实体</param>
        /// <returns>保存信息结果</returns>
        [HttpPost]
        [ValidateInput(false)]
        public string SubmitUserForm(CrmUserEntity entity)
        {
            string rtMsrg;
            int rtState;
            try
            {
                entity.Birthday = entity.Birthday.Year == 1 ? MinDate : entity.Birthday;

                var isAdd = string.IsNullOrEmpty(entity.Id);

                bool flag;
                if (isAdd)
                {
                    entity.Password = DESHelper.ToDESEncrypt("123456", AppConst.EncryptKey);   //初始默认密码123456
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = (int)RowStatus.Normal;
                    entity.CreateBy = CurrentUser.CrmUser.LoginName;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.CreateOn = DateTime.Now;
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmUserBll().Add(entity) != null;
                }
                else
                {
                    entity.Password = new CrmUserBll().Get(entity.Id).Password;    //修改用户信息密码保持不变
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmUserBll().Update(entity) > 0;
                }
                rtMsrg = flag ? "保存成功" : "保存失败";
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
        /// <summary>
        /// 用户信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UserDetails(string id)
        {
            var entity = new CrmUserBll().Get(id);
            return View(entity);
        }


        /// <summary>
        /// Ajax加载执法人员
        /// 添加人：周 鹏
        /// 添加时间：2014-12-20
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="controls">控件名称集</param>
        /// <param name="defaultSelId">默认选中的用户ID</param>
        /// <param name="defaultSel">是否默认选中当前用户</param>
        /// <param name="onlyLawUser">是否只加载执法人员</param>
        /// <returns></returns>
        public string GetUserDropList(string deptId, string controls, string defaultSelId, bool defaultSel = false, bool onlyLawUser = false)
        {
            var str = new StringBuilder();
            var user = CurrentUser.CrmUser;

            var selectIdSp = controls.Split(',');
            foreach (var selectId in selectIdSp)
            {
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", selectId);
            }
            if (!string.IsNullOrEmpty(deptId))
            {
                var users = new CrmUserBll().GetDeptsUsers(new CrmUserEntity() { DepartmentId = deptId }).ToList();
                if (onlyLawUser)
                {
                    users = users.Where(x => x.IsCityManager == "0").ToList();
                }
                if (users.Any() && users.Count > 0)
                {
                    var i = 1;
                    foreach (var t in users.Where(t => !string.IsNullOrEmpty(t.RealName)))
                    {
                        foreach (var selectId in selectIdSp)
                        {
                            str.Append("document.getElementById('" + selectId + "').options[" + i + "] = new Option('" + t.RealName + "', '" + t.Id + "', false, false);");

                            //默认选中本部门
                            if ((defaultSel && user.Id == t.Id) || t.Id == defaultSelId)
                            {
                                str.Append("document.getElementById('" + selectId + "').options[" + i + "].selected=true;");
                            }
                        }
                        i++;
                    }
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 数据同步
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public string DataTrans()
        {
            string rtMsrg;
            int rtState;
            try
            {

            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg = "",
                rtState = rtState = 0
            };
            return CommonMethod.ToJson(rtEntity);
        }
    }
}
