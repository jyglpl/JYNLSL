//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfo_LegislationDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/10 14:04:47
//  功能描述：TempDetainInfo_Legislation数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.DataAccess.TempDetain
{
    /// <summary>
    /// 暂扣物品对应法律法规 数据访问操作
    /// </summary>
    public class TempDetainInfoLegislationDal : DalImp.BaseDal<TempDetainInfoLegislationEntity>
    {
        public TempDetainInfoLegislationDal()
        {
            Model = new TempDetainInfoLegislationEntity();
        }


        /// <summary>
        /// 新增案件时，保存法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键ID</param>
        /// <param name="legislationId">违法行为ID</param>
        /// <param name="legislationItemId">适用案由ID</param>
        /// <param name="legislationGistId">法律条文ID</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool SavePunishLegislation(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId, SqlTransaction transaction)
        {
            try
            {
                var punishLegislations = GetSearchResult(new TempDetainInfoLegislationEntity() { CaseInfoId = caseinfoId });

                //是否当前选择的法律法规与之前是否一样,不一样则需要进行变更,否则不执行操作
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    var punishLegislationEntity = punishLegislations[0];
                    if (!punishLegislationEntity.LegislationId.Equals(legislationId)
                        || !punishLegislationEntity.LegislationItemId.Equals(legislationItemId)
                        || !punishLegislationEntity.LegislationGistId.Equals(legislationGistId))
                    {
                        //将原有数据进行删除,插入新的数据
                        punishLegislationEntity.RowStatus = 0;
                        Update(punishLegislationEntity, transaction);
                        Add(caseinfoId, legislationId, legislationItemId, legislationGistId,transaction);
                    }
                }
                else
                {
                    Add(caseinfoId, legislationId, legislationItemId, legislationGistId, transaction);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件法律法规查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<TempDetainInfoLegislationEntity> GetSearchResult(TempDetainInfoLegislationEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(TempDetainInfoLegislationEntity.Parm_TempDetainInfo_Legislation_RowStatus, "1");
            //案由编号
            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddEqual(TempDetainInfoLegislationEntity.Parm_TempDetainInfo_Legislation_ItemNo, search.ItemNo);
            }
            //案由编号
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(TempDetainInfoLegislationEntity.Parm_TempDetainInfo_Legislation_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<TempDetainInfoLegislationEntity>;
        }

        /// <summary>
        /// 新增案件法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键ID</param>
        /// <param name="legislationId">违法行为ID</param>
        /// <param name="legislationItemId">适用案由ID</param>
        /// <param name="legislationGistId">法律条文ID</param>
        /// <param name="transaction">事务</param>
        private void Add(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId, SqlTransaction transaction)
        {
            try
            {
                var legislationEntity = new LegislationDal().Get(legislationId);
                var legislationItemEntity = new LegislationItemDal().Get(legislationItemId);
                var legislationGistEntity = new LegislationGistDal().Get(legislationGistId);

                var entity = new TempDetainInfoLegislationEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    CaseInfoId = caseinfoId,
                    LegislationId = legislationId,
                    ItemCode = legislationEntity.ItemCode,
                    ItemType = legislationEntity.ItemType,
                    ItemNo = legislationEntity.ItemNo,
                    ItemAct = legislationEntity.ItemAct,
                    ClassNo = legislationEntity.ClassNo,
                    ClassNoName = legislationEntity.ClassName,
                    LegislationItemId = legislationItemId,
                    ItemName = legislationItemEntity.ItemName,
                    LegislationGistId = legislationGistId,
                    GistName = legislationGistEntity.GistName,
                    DutyName = legislationGistEntity.DutyName,
                    StipulateFirst = legislationGistEntity.StipulateFirst,
                    StipulateSecond = legislationGistEntity.StipulateSecond,
                    RowStatus = 1,
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now
                };

                Add(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

