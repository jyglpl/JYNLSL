//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_HEARBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_HEAR业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 陈述申辩与听证业务逻辑
    /// </summary>
    public class InfPunishHearBll : BaseBll<InfPunishHearEntity>
    {
        public InfPunishHearBll()
        {
            BaseDal = new InfPunishHearDal();
        }

        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();        //案件基本信息

        public InfPunishHearEntity GetHearEntity(string caseid)
        {

            try
            {
                InfPunishHearEntity entity = null;
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishHearEntity.Parm_INF_PUNISH_HEAR_RowStatus, "1");
                //案件编号
                if (!string.IsNullOrEmpty(caseid))
                {
                    queryCondition.AddEqual(InfPunishHearEntity.Parm_INF_PUNISH_HEAR_CaseInfoId, caseid);
                }
                var list = Query(queryCondition) as List<InfPunishHearEntity>;
                if (list != null && list.Count > 0)
                {
                    entity = new InfPunishHearEntity();
                    entity = list[0];
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 保存陈述申辩/听证信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ApplyTime"></param>
        /// <param name="ApplyAddress"></param>
        /// <param name="UdPersonel"></param>
        /// <param name="Records"></param>
        /// <param name="Entrust"></param>
        /// <param name="HearContent"></param>
        /// <param name="ApplyTime2"></param>
        /// <param name="ApplyNumber"></param>
        /// <param name="HearDate"></param>
        /// <param name="ApplyAddress2"></param>
        /// <param name="Compere"></param>
        /// <param name="PunishPerson"></param>
        /// <param name="UdPersonel2"></param>
        /// <param name="DeptId"></param>
        /// <param name="DeptName"></param>
        /// <param name="Attendances"></param>
        /// <param name="Reason"></param>
        /// <param name="ApplyType"></param>
        /// <returns></returns>
        public bool SaveCaseCT(string id, string StartDate, string EndDate, string ApplyAddress, string Records, string Entrust,
            string HearContent, string StartDate2, string EndDate2, string ApplyNumber, string HearDate, string ApplyAddress2, string Compere,
            string Attendances, string Reason, string EnforceAgentPerson, string BePunishedAgentPerson, string HearingOpinion, int ApplyType, int HearingType)
        {
            try
            {
                var caseEntity = _infPunishCaseinfoBll.Get(id);
                var hearEntity = GetHearEntity(id);
                var PunishHearid = Guid.NewGuid().ToString();
                var result = true;
                //更新
                if (hearEntity != null)
                {
                    PunishHearid = hearEntity.Id;
                    hearEntity.ApplyType = ApplyType;
                    hearEntity.ApplyNumber = ApplyNumber;
                    hearEntity.ApplyAddress = string.IsNullOrEmpty(ApplyAddress) ? ApplyAddress2 : ApplyAddress;
                    hearEntity.StartDate = string.IsNullOrEmpty(StartDate) ? Convert.ToDateTime(StartDate2) : Convert.ToDateTime(StartDate);
                    hearEntity.EndDate = string.IsNullOrEmpty(EndDate) ? Convert.ToDateTime(EndDate2) : Convert.ToDateTime(EndDate);
                    hearEntity.UdPersonelNameFirst = caseEntity.RePersonelNameFist;
                    hearEntity.UdPersonelNameSecond = caseEntity.RePersonelNameSecond;
                    hearEntity.DeptId = caseEntity.DeptId;
                    hearEntity.DeptName = caseEntity.DeptName;
                    hearEntity.Records = Records;
                    hearEntity.Entrust = Entrust;
                    hearEntity.HearContent = HearContent;
                    hearEntity.Compere = Compere;
                    hearEntity.PunishPerson = caseEntity.TargetName;
                    hearEntity.Attendances = Attendances;
                    hearEntity.Reason = Reason;
                    hearEntity.EnforceAgentPerson = EnforceAgentPerson;
                    hearEntity.BePunishedAgentPerson = BePunishedAgentPerson;
                    hearEntity.HearingOpinion = HearingOpinion;
                    hearEntity.HearingType = HearingType;
                    result = Update(hearEntity) > 0 ? true : false;
                }
                else
                {
                    //保存
                    var entity = new InfPunishHearEntity();
                    entity.Id = PunishHearid;
                    entity.CaseInfoId = id;
                    entity.ApplyType = ApplyType;
                    entity.StartDate = string.IsNullOrEmpty(StartDate) ? Convert.ToDateTime(StartDate2) : Convert.ToDateTime(StartDate);
                    entity.EndDate = string.IsNullOrEmpty(EndDate) ? Convert.ToDateTime(EndDate2) : Convert.ToDateTime(EndDate);
                    entity.ApplyNumber = ApplyNumber;
                    entity.ApplyAddress = string.IsNullOrEmpty(ApplyAddress) ? ApplyAddress2 : ApplyAddress;
                    entity.UdPersonelNameFirst = caseEntity.RePersonelNameFist;
                    entity.UdPersonelNameSecond = caseEntity.RePersonelNameSecond;
                    entity.DeptId = caseEntity.DeptId;
                    entity.DeptName = caseEntity.DeptName;
                    entity.Records = Records;
                    entity.Entrust = Entrust;
                    entity.HearContent = HearContent;
                    entity.Compere = Compere;
                    entity.PunishPerson = caseEntity.TargetName;
                    entity.Attendances = Attendances;
                    entity.Reason = Reason;
                    entity.EnforceAgentPerson = EnforceAgentPerson;
                    entity.BePunishedAgentPerson = BePunishedAgentPerson;
                    entity.HearingOpinion = HearingOpinion;
                    entity.HearingType = HearingType;
                    entity.RowStatus = 1;
                    Add(entity);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
