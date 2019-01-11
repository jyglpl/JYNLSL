//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DOCUMENTBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/7 11:04:12
//  功能描述：INF_PUNISH_DOCUMENT业务逻辑类
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
    /// 文书业务逻辑
    /// </summary>
    public class InfPunishDocumentBll : BaseBll<InfPunishDocumentEntity>
    {
        public InfPunishDocumentBll()
        {
            BaseDal = new InfPunishDocumentDal();
        }

        /// <summary>
        /// 查询数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary> 
        /// <param name="entity">查询实体</param>
        /// <returns></returns>
        public List<InfPunishDocumentEntity> GetSearchResult(InfPunishDocumentEntity entity)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(InfPunishDocumentEntity.Parm_INF_PUNISH_DOCUMENT_RowStatus, "1");
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    queryCondition.AddEqual(InfPunishDocumentEntity.Parm_INF_PUNISH_DOCUMENT_Id, entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.CaseInfoId))
                {
                    queryCondition.AddEqual(InfPunishDocumentEntity.Parm_INF_PUNISH_DOCUMENT_CaseInfoId, entity.CaseInfoId);
                }
                if (!string.IsNullOrEmpty(entity.ModelIdentify))
                {
                    queryCondition.AddEqual(InfPunishDocumentEntity.Parm_INF_PUNISH_DOCUMENT_ModelIdentify, entity.ModelIdentify);
                }
                var list = Query(queryCondition) as List<InfPunishDocumentEntity>;
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除已生成的文书
        /// 添加人：叶念
        /// 添加时间：2015-03-05
        /// </summary>
        /// <param name="modelIdentify">类型</param>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocument(string modelIdentify, string caseinfoId)
        {
            try
            {
                return new InfPunishDocumentDal().DeleteDocument(modelIdentify, caseinfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除已生成的文书
        /// </summary>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocument(string caseinfoId)
        {
            try
            {
                return new InfPunishDocumentDal().DeleteDocument(caseinfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除已生成的文书
        /// 添加人：叶念
        /// 添加时间：2015-03-05
        /// </summary>
        /// <param name="modelIdentify">类型</param>
        /// <param name="caseinfoId">案件编号</param>
        /// <returns></returns>
        public bool DeleteDocumentLicense(string modelIdentify, string caseinfoId)
        {
            try
            {
                return new InfPunishDocumentDal().DeleteDocumentLicense(modelIdentify, caseinfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
