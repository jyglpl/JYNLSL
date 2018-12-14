//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserMenuBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmUserMenu业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmUserMenu业务逻辑
    /// </summary>
    public class CrmUserMenuBll : BaseBll<CrmUserMenuEntity>
    {
        public CrmUserMenuBll()
        {
            BaseDal = new CrmUserMenuDal();
        }

        /// <summary>
        /// 更新用户菜单
        /// 添加人：周 鹏 
        /// 添加时间：2014-04-10
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

        /// <summary>
        /// 根据菜单编号获取用户信息
        /// 添加人：张晖   
        /// 添加时间：2014-04-08
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>     
        /// <param name="menuId">菜单编号</param>
        /// <returns>用户列表</returns>
        public List<CrmUserEntity> GetUserByMenu(string menuId)
        {
            return new CrmUserMenuDal().GetUserByMenu(menuId);
        }

        public string GetUserNameByMenuId(string menuId)
        {
            var users = GetUserByMenu(menuId);
            var sb = new StringBuilder();
            if (users.Count != 0)
            {
                foreach (CrmUserEntity item in users)
                {
                    if (item == users[0])
                    {
                        sb.Append(item.RealName);
                    }
                    else
                    {
                        sb.Append("," + item.RealName);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 验证用户指定功能（菜单）权限
        /// 添加人：周 鹏
        /// 添加时间：2015-07-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="menuId">菜单编号</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool GetUserMenu(string userId, string menuId)
        {
            return new CrmUserMenuDal().GetUserMenu(userId, menuId);
        }
    }
}
