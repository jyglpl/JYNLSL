//-------------------------------------------------------------------------
// <copyright  company="苏州友科软件" file="CrmUserRoleBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmUserRole业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmUserRole业务逻辑
    /// </summary>
    public class CrmUserRoleBll : BaseBll<CrmUserRoleEntity>
    {
        public CrmUserRoleBll()
        {
            BaseDal = new CrmUserRoleDal();
        }


        private static readonly CrmUserRoleDal Dal = new CrmUserRoleDal();
        /// <summary>
        /// 获取所有用户与角色对应的数据
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmUserRoleEntity> GetAllUsers()
        {
            return Dal.GetAllUsers();
        }

        /// <summary>
        /// 查询用户与角色对应的数据
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmUserRoleEntity> GetSearchResult(CrmUserRoleEntity search)
        {
            return Dal.GetSearchResult(search);
        }

        /// <summary>
        /// 保存用户与角色对应
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userIds">用户编号集,使用逗号分隔</param>
        /// <param name="roleId">用户角色</param>
        /// <param name="createId">操作人ID</param>
        /// <param name="createBy">操作人</param>
        /// <returns></returns>
        public bool SaveUserRole(string userIds, string roleId, string createId, string createBy)
        {
            var list = new List<CrmUserRoleEntity>();
            userIds = userIds.Trim(',');
            var userSplit = userIds.Split(',');
            if (userSplit.Length > 0)
            {
                list.AddRange(from userId in userSplit
                              where !string.IsNullOrEmpty(userId)
                              select new CrmUserRoleEntity
                              {
                                  Id = Guid.NewGuid().ToString(),
                                  UserId = userId,
                                  RoleId = roleId,
                                  RowStatus = 1,
                                  CreatorId = createId,
                                  CreateBy = createBy,
                                  CreateOn = DateTime.Now,
                                  UpdateBy = createBy,
                                  UpdateId = createId,
                                  UpdateOn = DateTime.Now
                              });
            }

            return Dal.SaveUserRole(list, roleId);
        }
    }
}
