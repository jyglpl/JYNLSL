//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DISCUSSBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/11/02 14:09:59
//  功能描述：INF_PUNISH_DISCUSS业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 案审、集体讨论逻辑
    /// </summary>
    public class InfPunishDiscussBll : BaseBll<InfPunishDiscussEntity>
    {
        public InfPunishDiscussBll()
        {
            BaseDal = new InfPunishDiscussDal();
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
                return new InfPunishDiscussDal().GetSearchResult(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveDiscuss(InfPunishDiscussEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(entity.CaseInfoId))
                {
                    var list = GetSearchResult(new InfPunishDiscussEntity() { CaseInfoId = entity.CaseInfoId, DiscussType = entity.DiscussType });

                    if (list.Any())
                    {
                        var oldEntity = list[0];
                        entity.Id = oldEntity.Id;
                        entity.CreateBy = oldEntity.CreateBy;
                        entity.CreateOn = oldEntity.CreateOn;

                        //执行更新
                        return Update(entity) > 0;
                    }
                    else
                    {
                        Add(entity);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
