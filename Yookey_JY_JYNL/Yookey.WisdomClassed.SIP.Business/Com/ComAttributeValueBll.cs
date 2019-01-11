//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttributeValueBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:45
//  功能描述：ComAttributeValue业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComAttributeValue业务逻辑
    /// </summary>
    public class ComAttributeValueBll : BaseBll<ComAttributeValueEntity>
    {
        public ComAttributeValueBll()
        {
            BaseDal = new ComAttributeValueDal();
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ComAttributeValueEntity> GetSearchResult(ComAttributeValueEntity search)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(ComAttributeValueEntity.Parm_ComAttributeValue_RowStatus, "1");
                if (!string.IsNullOrEmpty(search.RsId))
                {
                    queryCondition.AddEqual(ComAttributeValueEntity.Parm_ComAttributeValue_RsId, search.RsId);
                }
                if (search.AttributeId != 0)
                {
                    queryCondition.AddEqual(ComAttributeValueEntity.Parm_ComAttributeValue_AttributeId, search.AttributeId.ToString());
                }
                //排序
                queryCondition.AddOrderBy(ComAttributeValueEntity.Parm_ComAttributeValue_AttributeId, true);
                return Query(queryCondition);
            }
            catch (Exception)
            {
                return new List<ComAttributeValueEntity>();
            }
        }

        
    }
}
