//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_SURVEYBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_SURVEY业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 调查取证业务逻辑
    /// </summary>
    public class InfPunishSurveyBll : BaseBll<InfPunishSurveyEntity>
    {
        public InfPunishSurveyBll()
        {
            BaseDal = new InfPunishSurveyDal();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<InfPunishSurveyEntity> GetSearchResult(InfPunishSurveyEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishSurveyEntity.Parm_INF_PUNISH_SURVEY_RowStatus, "1");

            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishSurveyEntity.Parm_INF_PUNISH_SURVEY_CaseInfoId, search.CaseInfoId);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(InfPunishSurveyEntity.Parm_INF_PUNISH_SURVEY_Id, search.Id);
            }
            return Query(queryCondition) as List<InfPunishSurveyEntity>;
        }

        /// <summary>
        /// 保存调查
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool SaveSurvey(InfPunishSurveyEntity entity)
        {
            var surveyEntity = Get(entity.Id);
            if (surveyEntity != null && !string.IsNullOrEmpty(entity.CaseInfoId))
            {
                return Update(entity) > 0;
            }
            else
            {
                Add(entity);
                return true;
            }
        }
    }
}
