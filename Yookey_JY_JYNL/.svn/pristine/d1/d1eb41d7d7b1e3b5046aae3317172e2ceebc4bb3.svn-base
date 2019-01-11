//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleMenuBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmRoleMenu业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmRoleMenu业务逻辑
    /// </summary>
    public class CrmRoleMenuBll : BaseBll<CrmRoleMenuEntity>
    {
        public CrmRoleMenuBll()
        {
            BaseDal = new CrmRoleMenuDal();
        }

        /// <summary>
        /// 更新角色菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="menuIds">菜单Id集合</param>
        /// <returns></returns>
        public bool UpdateRoleMenu(string roleId, string menuIds)
        {
            return new CrmRoleMenuDal().UpdateRoleMenu(roleId, menuIds);
        }

        /// <summary>
        /// 更新用户菜单
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户Id</param>
        /// <param name="menuIds">菜单Id集合</param>
        /// <returns></returns>
        public bool UpdateUserMenu(string userId, string menuIds)
        {
            return new CrmUserMenuDal().UpdateUserMenu(userId, menuIds);
        }
    }
}
