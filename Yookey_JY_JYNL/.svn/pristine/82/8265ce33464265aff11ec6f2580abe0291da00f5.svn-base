//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementStandardBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagementStandard业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TeamManagement;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.Business.TeamManagement
{
    /// <summary>
    /// TeamManagementStandard业务逻辑
    /// </summary>
    public class TeamManagementStandardBll : BaseBll<TeamManagementStandardEntity>
    {
        readonly TeamManagementStandardDal _teamManagementStandardDal = new TeamManagementStandardDal();
        public TeamManagementStandardBll()
        {
            BaseDal = new TeamManagementStandardDal();
        }


        /// <summary>
        /// 获取数据列表
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<TeamManagementStandardEntity> GetSearchResult(TeamManagementStandardEntity search)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(TeamManagementStandardEntity.Parm_TeamManagementStandard_RowStatus, "1");
                if (!string.IsNullOrEmpty(search.ClassTypeId))
                {
                    queryCondition.AddEqual(TeamManagementStandardEntity.Parm_TeamManagementStandard_ClassTypeId, search.ClassTypeId);
                }
                if (!string.IsNullOrEmpty(search.StandardContent))
                {
                    queryCondition.AddLike(TeamManagementStandardEntity.Parm_TeamManagementStandard_StandardContent, search.StandardContent);
                }

                //排序
                queryCondition.AddOrderBy(TeamManagementStandardEntity.Parm_TeamManagementStandard_OrderNo, true);

                return Query(queryCondition);
            }
            catch (Exception ex)
            {
                return new List<TeamManagementStandardEntity>();
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="ids">数据Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return _teamManagementStandardDal.BatchDelete(ids);
        }
    }
}
