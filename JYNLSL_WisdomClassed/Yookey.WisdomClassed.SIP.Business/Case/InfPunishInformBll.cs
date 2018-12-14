//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_INFORMBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_INFORM业务逻辑类
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
    /// 行政处罚告知书业务逻辑
    /// </summary>
    public class InfPunishInformBll : BaseBll<InfPunishInformEntity>
    {
        public InfPunishInformBll()
        {
            BaseDal = new InfPunishInformDal();
        }
        /// <summary>
        /// 告知书
        /// 添加人：周 鹏
        /// 添加时间：2015-02-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-14 周 鹏 将违法行为更改为自由裁量
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public InfPunishInformEntity GetInform(string id)
        {
            try
            {
                var entity = new InfPunishInformEntity();
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishInformEntity.Parm_INF_PUNISH_INFORM_RowStatus, "1");
                //案件编号
                if (!string.IsNullOrEmpty(id))
                {
                    queryCondition.AddEqual(InfPunishInformEntity.Parm_INF_PUNISH_INFORM_CaseInfoId, id);
                }
                var list = Query(queryCondition) as List<InfPunishInformEntity>;
                if (list != null && list.Count > 0)
                {
                    entity = list[0];
                }
                else
                {
                    var casePunishEntity = new InfPunishLegislationEntity();
                    var caseEntity = new InfPunishCaseinfoBll().Get(id);
                    var punishItems = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });

                    if (punishItems != null && punishItems.Count > 0)
                    {
                        casePunishEntity = punishItems[0];
                    }
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CaseInfoId = id;
                    entity.FileNumber = caseEntity.CaseInfoNo;
                    entity.TargetName = caseEntity.TargetName;
                    entity.CaseAddr = caseEntity.CaseAddress;
                    entity.CaseDate = caseEntity.CaseDate;
                    //案情摘要
                    //entity.CaseFact = caseEntity.CaseFact;
                    //违法事实
                    // entity.FactFinding = caseEntity.CaseFact;
                    //证据情况
                    // entity.FactualEvidence = "";
                    //违反法规
                    entity.GistName = casePunishEntity.GistName;
                    ////违法行为
                    //entity.ItemName = casePunishEntity.ItemAct;
                    entity.ItemName = casePunishEntity.ItemName;
                    //违法情节
                    //entity.ItemPlot = "";
                    //处罚依据
                    entity.DutyName = casePunishEntity.DutyName;
                    ////处罚内容
                    //entity.PunishContent = CommonMethod.MoneyToUpper(casePunishEntity.PunishAmount.ToString());

                    if (casePunishEntity.PunishAmount > 0)
                    {
                        entity.PunishContent = "罚款" + CommonMethod.MoneyToUpper(casePunishEntity.PunishAmount.ToString());
                    }
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
        public List<InfPunishInformEntity> GetSearchResult(InfPunishInformEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishInformEntity.Parm_INF_PUNISH_INFORM_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishInformEntity.Parm_INF_PUNISH_INFORM_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<InfPunishInformEntity>;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveInform(InfPunishInformEntity entity)
        {
            entity.RowStatus = 1;
            entity.FileDateCapital = CommonMethod.DateToUpper(entity.FileDate);
            if (!string.IsNullOrEmpty(entity.CaseInfoId))
            {
                var informs = GetSearchResult(new InfPunishInformEntity() { CaseInfoId = entity.CaseInfoId });

                //先删除已经生成的文书
                new InfPunishDocumentBll().DeleteDocument("Inform", entity.CaseInfoId);
                //先删除已经生成的文书
                new InfPunishDocumentBll().DeleteDocument("InformTD", entity.CaseInfoId);

                if (informs.Any())
                {
                    var oldEntity = informs[0];
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
