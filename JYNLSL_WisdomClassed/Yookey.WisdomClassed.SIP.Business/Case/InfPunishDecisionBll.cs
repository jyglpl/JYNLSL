//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DECISIONBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_DECISION业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 行政处罚决定书业务逻辑
    /// </summary>
    public class InfPunishDecisionBll : BaseBll<InfPunishDecisionEntity>
    {
        public InfPunishDecisionBll()
        {
            BaseDal = new InfPunishDecisionDal();
        }

        /// <summary>
        /// 加载决定书
        /// 添加人：叶念
        /// 添加时间：2015-03-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public InfPunishDecisionEntity GetDescsion(string id)
        {
            try
            {
                var entity = new InfPunishDecisionEntity();
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishDecisionEntity.Parm_INF_PUNISH_DECISION_RowStatus, "1");
                //案件编号
                if (!string.IsNullOrEmpty(id))
                {
                    queryCondition.AddEqual(InfPunishDecisionEntity.Parm_INF_PUNISH_DECISION_CaseInfoId, id);
                }
                var list = Query(queryCondition) as List<InfPunishDecisionEntity>;
                if (list != null && list.Count > 0)
                {
                    entity = list[0];
                }
                else
                {
                    var casePunishEntity = new InfPunishLegislationEntity();
                    var caseEntity = new InfPunishCaseinfoBll().Get(id);
                    var punishitems = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                    if (punishitems != null && punishitems.Count > 0)
                    {
                        casePunishEntity = punishitems[0];
                    }

                    //告知书
                    var punishinform = new InfPunishInformBll().GetInform(id);

                    entity.Id = Guid.NewGuid().ToString();
                    entity.CaseInfoId = id;
                    entity.FileNumber = punishinform.FileNumber;
                    entity.TargetName = punishinform.TargetName;
                    entity.TargetAddress = caseEntity.TargetAddress;
                    entity.CaseDate = caseEntity.CaseDate;
                    entity.CaseAddr = caseEntity.CaseAddress;
                    //案情摘要
                    // entity.CaseFact = punishinform.CaseFact;
                    //违法事实
                    // entity.FactFinding = punishinform.FactFinding;
                    //证据情况
                    // entity.FactualEvidence = punishinform.FactualEvidence;
                    //违反法规
                    entity.GistName = punishinform.GistName;
                    //违法行为
                    entity.ItemAct = punishinform.ItemName;
                    //违法情节
                    //entity.ItemPlot = punishinform.ItemPlot;
                    //处罚依据
                    entity.DutyName = punishinform.DutyName;
                    ////处罚金额
                    //entity.PunishAmount = punishinform.PunishContent;
                    ////处罚内容
                    //entity.PunishContent = "根据" + casePunishEntity.GistName + "、" + casePunishEntity.DutyName +
                    //                       "的规定，本机关决定：对当事人" + entity.TargetName + "处罚款人民币" + entity.PunishAmount + "。";

                    entity.PunishAmount = "罚款" + CommonMethod.MoneyToUpper(casePunishEntity.PunishAmount.ToString());
                    entity.PunishContent = punishinform.PunishContent;


                    //告知书日期
                    entity.FileDate = DateTime.Now;
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<InfPunishDecisionEntity> GetSearchResult(InfPunishDecisionEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishDecisionEntity.Parm_INF_PUNISH_DECISION_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishDecisionEntity.Parm_INF_PUNISH_DECISION_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<InfPunishDecisionEntity>;
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveDecision(InfPunishDecisionEntity entity)
        {
            entity.RowStatus = 1;
            entity.FileDateCapital = CommonMethod.DateToUpper(entity.FileDate);

            if (!string.IsNullOrEmpty(entity.CaseInfoId))
            {
                var decisions = GetSearchResult(new InfPunishDecisionEntity() { CaseInfoId = entity.CaseInfoId });
                //先删除已经生成的文书
                new InfPunishDocumentBll().DeleteDocument("Decision", entity.CaseInfoId);
                //先删除已经生成的文书
                new InfPunishDocumentBll().DeleteDocument("DecisionTD", entity.CaseInfoId);

                if (decisions.Any())
                {
                    var oldEntity = decisions[0];
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
    }
}
