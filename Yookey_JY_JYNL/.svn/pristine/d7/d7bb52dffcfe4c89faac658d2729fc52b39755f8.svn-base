//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_RECEIPTBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_RECEIPT业务逻辑类
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
    /// 文书送达回执业务逻辑
    /// </summary>
    public class InfPunishReceiptBll : BaseBll<InfPunishReceiptEntity>
    {
        public InfPunishReceiptBll()
        {
            BaseDal = new InfPunishReceiptDal();
        }

        /// <summary>
        /// 查询案件对应的附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-27
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<InfPunishReceiptEntity> GetSearchResult(InfPunishReceiptEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishReceiptEntity.Parm_INF_PUNISH_RECEIPT_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(InfPunishReceiptEntity.Parm_INF_PUNISH_RECEIPT_CaseInfoId, search.CaseInfoId);
            }
            queryCondition.AddEqual(InfPunishReceiptEntity.Parm_INF_PUNISH_RECEIPT_ServiceType, search.ServiceType.ToString());
            return Query(queryCondition) as List<InfPunishReceiptEntity>;
        }
    }
}
