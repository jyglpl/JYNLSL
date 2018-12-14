//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseSpecBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseSpec业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseSpec业务逻辑
    /// </summary>
    public class LicenseSpecBll : BaseBll<LicenseSpecEntity>
    {
        public LicenseSpecBll()
        {
            BaseDal = new LicenseSpecDal();
        }

        /// <summary>
        /// 获取规则信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseSpecEntity> GetSearchResult(LicenseSpecEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseSpecEntity.Parm_LicenseSpec_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddLike(LicenseSpecEntity.Parm_LicenseSpec_LicenseId, search.LicenseId);
            }
            //排序
            queryCondition.AddOrderBy(LicenseSpecEntity.Parm_LicenseSpec_SortNo, true);
            return Query(queryCondition) as List<LicenseSpecEntity>;
        }
    }
}
