//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_FINISHBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_FINISH业务逻辑类
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
    /// INF_PUNISH_FINISH业务逻辑
    /// </summary>
    public class InfPunishFinishBll : BaseBll<InfPunishFinishEntity>
    {
        public InfPunishFinishBll()
        {
            BaseDal = new InfPunishFinishDal();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<InfPunishFinishEntity> GetSearchResult(InfPunishFinishEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishFinishEntity.Parm_INF_PUNISH_FINISH_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishFinishEntity.Parm_INF_PUNISH_FINISH_CaseInfoId, search.CaseInfoId);
            }
            var list = Query(queryCondition) as List<InfPunishFinishEntity>;
            return list;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(InfPunishFinishEntity entity)
        {
            try
            {
                var list = GetSearchResult(new InfPunishFinishEntity() { CaseInfoId = entity.CaseInfoId });
                if (list.Count > 0)
                {
                    var oldEntity = list[0];
                    oldEntity.ExecuteDesc = entity.ExecuteDesc;
                    oldEntity.PunishContent = entity.PunishContent;
                    oldEntity.PaymentType = entity.PaymentType;
                    oldEntity.FinishDate = entity.FinishDate;
                    oldEntity.Remark = entity.Remark;
                    oldEntity.PaymentType = entity.PaymentType;
                    oldEntity.PaymentNum = entity.PaymentNum;
                    oldEntity.ReformDesc = entity.ReformDesc;

                    return Update(oldEntity) > 0;
                }
                else
                {
                    Add(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更改案件结案日期
        /// </summary>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="finishDate">结案日期</param>
        /// <returns></returns>
        public bool UpdateFinishDate(string caseinfoId, DateTime finishDate)
        {
            var list = GetSearchResult(new InfPunishFinishEntity() { CaseInfoId = caseinfoId });
            if (list.Count > 0)
            {
                var entity = list[0];
                entity.FinishDate = finishDate;
                return Update(entity) > 0;
            }
            return false;
        }
    }
}
