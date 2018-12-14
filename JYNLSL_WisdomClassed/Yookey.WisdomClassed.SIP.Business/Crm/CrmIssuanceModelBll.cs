//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIssuanceModelBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/7 10:37:34
//  功能描述：CrmIssuanceModel业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmIssuanceModel业务逻辑
    /// </summary>
    public class CrmIssuanceModelBll : BaseBll<CrmIssuanceModelEntity>
    {
        public CrmIssuanceModelBll()
        {
            BaseDal = new CrmIssuanceModelDal();
        }

        /// <summary>
        /// 查询数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <returns></returns>
        public List<CrmIssuanceModelEntity> GetSearchResult(CrmIssuanceModelEntity entity)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmIssuanceModelEntity.Parm_CrmIssuanceModel_RowStatus, "1");
            if (!string.IsNullOrEmpty(entity.Id))
            {
                queryCondition.AddEqual(CrmIssuanceModelEntity.Parm_CrmIssuanceModel_Id, entity.Id);
            }
            if (!string.IsNullOrEmpty(entity.ModelIdentify))
            {
                queryCondition.AddEqual(CrmIssuanceModelEntity.Parm_CrmIssuanceModel_ModelIdentify, entity.ModelIdentify);
            }
            if (!string.IsNullOrEmpty(entity.ModelIdentify))
            {
                queryCondition.AddEqual(CrmIssuanceModelEntity.Parm_CrmIssuanceModel_ModelIdentify, entity.ModelIdentify);
            }
            if (!string.IsNullOrEmpty(entity.ModelName))
            {
                queryCondition.AddEqual(CrmIssuanceModelEntity.Parm_CrmIssuanceModel_ModelName, entity.ModelName);
            }

            var list = Query(queryCondition) as List<CrmIssuanceModelEntity>;
            return list;
        }
    }
}
