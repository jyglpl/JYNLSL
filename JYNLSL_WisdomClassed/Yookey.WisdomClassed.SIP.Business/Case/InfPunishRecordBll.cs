//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_RECORDBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_RECORD业务逻辑类
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
    /// 调查询问笔录业务逻辑
    /// </summary>
    public class InfPunishRecordBll : BaseBll<InfPunishRecordEntity>
    {
        public InfPunishRecordBll()
        {
            BaseDal = new InfPunishRecordDal();
        }

        /// <summary>
        /// 加载笔录
        /// 添加人：周 鹏
        /// 添加时间：2015-02-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public InfPunishRecordEntity GetRecord(string id)
        {
            try
            {
                var entity = new InfPunishRecordEntity();
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishRecordEntity.Parm_INF_PUNISH_RECORD_RowStatus, "1");
                //案由编号
                if (!string.IsNullOrEmpty(id))
                {
                    queryCondition.AddEqual(InfPunishRecordEntity.Parm_INF_PUNISH_RECORD_CaseInfoId, id);
                }
                var list = Query(queryCondition) as List<InfPunishRecordEntity>;
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

                    var legislationGistEntity = new LegislationGistBll().Get(casePunishEntity.LegislationGistId);   //请求的法律条文

                    entity.CaseInfoId = id;
                    entity.CaseInfoNo = caseEntity.CaseInfoNo;
                    entity.ItemName = casePunishEntity.ItemName;
                    entity.StartDate = DateTime.Now;
                    entity.EndDate = DateTime.Now.AddMinutes(30);
                    entity.Address = AppConst.SurveyAddress;    //询问地址默认城市管理

                    if (caseEntity.CaseType.Equals(AppConst.CaseTypeCityManagement))   //城市管理
                    {
                        if (caseEntity.CompanyName.Equals("唯亭街道综合执法大队"))
                        {
                            entity.Address = "苏州工业园区葑亭大道608号";
                        }
                    }
                    else if (caseEntity.CaseType.Equals(AppConst.CaseTypeLand))  //国土监管
                    {
                        entity.Address = AppConst.LandSurveyAddress; ;
                    }

                    entity.QuestionerFirstName = caseEntity.UdPersonelNameFirst;
                    entity.QuestionerSecondName = caseEntity.UdPersonelNameSecond;
                    entity.RecordsName = caseEntity.UdPersonelNameFirst;
                    //当事人是法人时，当事人基本信息栏为空
                    if (caseEntity.TargetType == "00120002")
                    {
                        entity.TargetName = "";
                        entity.TargetGender = "";
                        entity.BirthDate = "";
                        entity.TargetPaperNum = "";
                        entity.TargetPhone = "";
                        entity.TargetAddress = "";
                        entity.TargetUnit = "";
                        entity.TargetPaperType = "00130001";
                        entity.TargetDuty = "";
                        entity.TargetZipCode = "";
                    }
                    else if (caseEntity.TargetType == "00120001")
                    {
                        entity.TargetName = caseEntity.TargetName;
                        entity.TargetAddress = caseEntity.TargetAddress;
                        entity.TargetPaperType = caseEntity.TargetPaperType;
                        entity.TargetPaperNum = caseEntity.TargetPaperNum;
                        entity.TargetGender = caseEntity.TargetGender;

                        if (caseEntity.TargetPaperType.Equals("00130001") && !string.IsNullOrEmpty(caseEntity.TargetPaperNum))
                        {
                            entity.BirthDate = caseEntity.TargetPaperNum.Substring(6, 4) + "-" + caseEntity.TargetPaperNum.Substring(10, 2) + "-" + caseEntity.TargetPaperNum.Substring(12, 2);
                        }
                        entity.TargetUnit = caseEntity.TargetUnit;
                        entity.TargetDuty = caseEntity.TargetDuty;
                        entity.TargetPhone = caseEntity.TargetPhone;
                        entity.TargetMobile = caseEntity.TargetMobile;
                        entity.TargetZipCode = caseEntity.TargetZipCode;
                        entity.TargetEmail = caseEntity.TargetEmail;
                    }
                    var records = "";
                    if (legislationGistEntity != null)
                    {
                        records = legislationGistEntity.Records;
                        records = records.Replace("${CaseDate}", caseEntity.CaseDate.ToString("yyyy年MM月dd日"));
                        records = records.Replace("${TargetName}", caseEntity.TargetName);
                        records = records.Replace("${Address}", caseEntity.CaseAddress);
                        records = records.Replace("${ItemAct}", casePunishEntity.ItemAct);
                    }

                    entity.RecordInfo = records;

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
        public List<InfPunishRecordEntity> GetSearchResult(InfPunishRecordEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishRecordEntity.Parm_INF_PUNISH_RECORD_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishRecordEntity.Parm_INF_PUNISH_RECORD_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<InfPunishRecordEntity>;
        }

        /// <summary>
        /// 保存笔录
        /// 添加人：周 鹏
        /// 添加时间：2015-02-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">案件实价</param>
        /// <returns></returns>
        public bool Save(InfPunishRecordEntity entity, string targetShxym, string targetZdm, string targetGsdj, string targetSwdj)
        {
            entity.RowStatus = 1;
            if (!string.IsNullOrEmpty(entity.CaseInfoId))
            {
                var records = GetSearchResult(new InfPunishRecordEntity() { CaseInfoId = entity.CaseInfoId });
                var caseEntity = new InfPunishCaseinfoBll().Get(entity.CaseInfoId);
                caseEntity.TargetSHXYM = targetShxym;
                caseEntity.TargetZDM = targetZdm;
                caseEntity.TargetGSDJ = targetGsdj;
                caseEntity.TargetSWDJ = targetSwdj;
                new InfPunishCaseinfoBll().Update(caseEntity);
                if (records.Any())
                {
                    var oldEntity = records[0];
                    entity.Id = oldEntity.Id;
                    entity.CreateBy = oldEntity.CreateBy;
                    entity.CreateOn = oldEntity.CreateOn;
                    //先删除已经生成的文书
                    new InfPunishDocumentBll().DeleteDocument("Record", entity.CaseInfoId);
                    return Update(entity) > 0;
                }
                else
                {
                    entity.Id = Guid.NewGuid().ToString();
                    Add(entity);
                    return true;
                }
            }
            return false;
        }
    }
}
