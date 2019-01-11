//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DISCUSSDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/11/02 14:09:59
//  功能描述：INF_PUNISH_DISCUSS数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 案审、集体讨论数据访问操作
    /// </summary>
    public class InfPunishDiscussDal : DalImp.BaseDal<InfPunishDiscussEntity>
    {
        public InfPunishDiscussDal()
        {
            Model = new InfPunishDiscussEntity();
        }


        /// <summary>
        /// 查询数据
        /// 添加人：周 鹏
        /// 添加时间：2018-11-02
        /// </summary> 
        /// <param name="entity">查询实体</param>
        /// <returns></returns>
        public List<InfPunishDiscussEntity> GetSearchResult(InfPunishDiscussEntity entity)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishDiscussEntity.Parm_INF_PUNISH_DISCUSS_RowStatus, "1");
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    queryCondition.AddEqual(InfPunishDiscussEntity.Parm_INF_PUNISH_DISCUSS_Id, entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.CaseInfoId))
                {
                    queryCondition.AddEqual(InfPunishDiscussEntity.Parm_INF_PUNISH_DISCUSS_CaseInfoId, entity.CaseInfoId);
                }
                if (entity.DiscussType > -1)
                {
                    queryCondition.AddEqual(InfPunishDiscussEntity.Parm_INF_PUNISH_DISCUSS_DiscussType, entity.DiscussType.ToString());
                }
                var list = Query(queryCondition) as List<InfPunishDiscussEntity>;
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

