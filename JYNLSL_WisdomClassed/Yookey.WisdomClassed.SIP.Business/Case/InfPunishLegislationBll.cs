//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_LEGISLATIOINBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/30 9:37:10
//  功能描述：INF_PUNISH_LEGISLATIOIN业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 案件法律法规 业务逻辑
    /// </summary>
    public class InfPunishLegislatioinBll : BaseBll<InfPunishLegislationEntity>
    {
        readonly LegislationBll _legislationBll = new LegislationBll();             //法律法规-违法行为
        readonly LegislationItemBll _legislationItemBll = new LegislationItemBll(); //法律法规-适用案由
        readonly LegislationGistBll _legislationGistBll = new LegislationGistBll(); //法律法规-法律条文
        readonly LegislationRuleBll _legislationRuleBll = new LegislationRuleBll(); //法律法规-自由裁量

        public InfPunishLegislatioinBll()
        {
            BaseDal = new InfPunishLegislationDal();
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
        public List<InfPunishLegislationEntity> GetSearchResult(InfPunishLegislationEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishLegislationEntity.Parm_INF_PUNISH_LEGISLATION_RowStatus, "1");
            //案由编号
            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddEqual(InfPunishLegislationEntity.Parm_INF_PUNISH_LEGISLATION_ItemNo, search.ItemNo);
            }
            //案由编号
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishLegislationEntity.Parm_INF_PUNISH_LEGISLATION_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<InfPunishLegislationEntity>;
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
        /// <returns></returns>
        public bool SavePunishLegislation(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId)
        {
            try
            {
                var punishLegislations = GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = caseinfoId });

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
                        Update(punishLegislationEntity);
                        Add(caseinfoId, legislationId, legislationItemId, legislationGistId);
                    }
                }
                else
                {
                    Add(caseinfoId, legislationId, legislationItemId, legislationGistId);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
        private void Add(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId)
        {
            try
            {
                var legislationEntity = _legislationBll.Get(legislationId);
                var legislationItemEntity = _legislationItemBll.Get(legislationItemId);
                var legislationGistEntity = _legislationGistBll.Get(legislationGistId);

                var entity = new InfPunishLegislationEntity()
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

                Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存处罚标准、处罚金额
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键ID</param>
        /// <param name="ruleId">处罚标准ID</param>
        /// <param name="punishMoney">处罚金额</param>
        /// <returns></returns>
        public bool SavePunishRule(string caseinfoId, string ruleId, string punishMoney)
        {
            try
            {
                var punishLegislations = GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = caseinfoId });

                var punishLegislationEntity = new InfPunishLegislationEntity();

                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    punishLegislationEntity = punishLegislations[0];
                }

                if (!string.IsNullOrEmpty(ruleId))   //更新自由裁量相关信息
                {
                    var ruleEntity = _legislationRuleBll.Get(ruleId);

                    punishLegislationEntity.LegislationRuleId = ruleEntity.Id;
                    punishLegislationEntity.PunishContent = ruleEntity.PunishContent;
                    punishLegislationEntity.PunishType = ruleEntity.PunishType;
                    punishLegislationEntity.Measurement = ruleEntity.Measurement;
                    punishLegislationEntity.PunishMax = ruleEntity.PunishMax;
                    punishLegislationEntity.PunishMin = ruleEntity.PunishMin;
                }
                punishLegislationEntity.PunishAmount = double.Parse(punishMoney);
                return Update(punishLegislationEntity) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 保存案件的处罚金额
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="caseinfoId">案件ID</param>
        /// <param name="punishType">处罚方式</param>
        /// <param name="punishMoney">处罚金额</param>
        /// <param name="forfeitureAmount">没收金额</param>
        /// <returns></returns>
        public bool SaveSimpleCaseItem(string caseinfoId, string punishType, string punishMoney, string forfeitureAmount)
        {
            try
            {
                //案件法规
                var punishLegislations = GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = caseinfoId });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    var punishLegislationEntity = punishLegislations[0];

                    punishLegislationEntity.PunishType = punishType;
                    punishLegislationEntity.PunishAmount = double.Parse(string.IsNullOrEmpty(punishMoney) ? "0" : punishMoney);
                    punishLegislationEntity.ForfeitureAmount = double.Parse(string.IsNullOrEmpty(forfeitureAmount) ? "0" : forfeitureAmount);

                    return Update(punishLegislationEntity) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询法律法规对比数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetComparePunishItem()
        {
            return new InfPunishLegislationDal().GetComparePunishItem();
        }
    }
}
