using System;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;


namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    public class RoleController : BaseController
    {
        //
        // GET: /CommonModule/Role/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增/编辑
        /// </summary>
        /// <param name="companyId">单位编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public ActionResult Edit(string companyId, string roleId)
        {
            var entity = new CrmRoleEntity();
            if (!string.IsNullOrEmpty(roleId))
            {
                entity = new CrmRoleBll().Get(roleId);
            }
            else if (!string.IsNullOrEmpty(companyId))
            {
                entity.CompanyId = companyId;
            }
            return View(entity);
        }

        /// <summary>
        /// 请求角色GridListJson
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="rows">请求条数</param>
        /// <param name="page">请求页数</param>
        /// <returns></returns>
        public string GridListJson(string companyId, int rows, int page)
        {
            var departments = new CrmRoleBll().GetSearchResult(new CrmRoleEntity { CompanyId = companyId, PageIndex = page, PageSize = rows });
            return CommonMethod.PageToJson(departments);
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">角色实体</param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public string SubmitRoleForm(CrmRoleEntity entity, FormCollection collection)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var isAdd = string.IsNullOrEmpty(entity.Id);
                bool flag;
                if (isAdd)
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = (int)RowStatus.Normal;
                    entity.CreateBy = CurrentUser.CrmUser.LoginName;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.CreateOn = DateTime.Now;
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmRoleBll().Add(entity) != null;
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmRoleBll().Update(entity) > 0;
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
        /// 删除角色
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roleId">角色主键编号</param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteRole(string roleId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = new CrmRoleBll().BatchDelete(roleId);
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
    }
}
