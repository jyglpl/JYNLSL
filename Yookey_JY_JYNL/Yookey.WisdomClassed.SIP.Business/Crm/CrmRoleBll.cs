//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:52:52
//  功能描述：CrmRole业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmRole业务逻辑
    /// </summary>
    public class CrmRoleBll : BaseBll<CrmRoleEntity>
    {
        public CrmRoleBll()
        {
            BaseDal = new CrmRoleDal();
        }


        private readonly static CrmRoleDal Dal = new CrmRoleDal();

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmRoleEntity> GetAllRoles()
        {
            return Dal.GetAllRoles();
        }

        /// <summary>
        /// 角色查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<CrmRoleEntity> GetSearchResult(CrmRoleEntity search)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = Dal.GetSearchResult(search, out totalRecords);
            stopwatch.Stop();
            int totalPage = (totalRecords + search.PageSize - 1) / search.PageSize;   //计算页数
            return new PageJqDatagrid<CrmRoleEntity>
            {
                page = search.PageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 批量删除角色
        /// </summary>
        /// <param name="ids">角色Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return Dal.BatchDelete(ids);
        }


        /// <summary>
        /// 判断用户是否是中队长（副中队长）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsSquadronLeader(string userId)
        {
            return Dal.IsSquadronLeader(userId);
        }
    }
}
