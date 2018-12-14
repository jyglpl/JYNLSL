//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseCheckSpecBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseCheckSpec业务逻辑类
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
    /// LicenseCheckSpec业务逻辑
    /// </summary>
    public class LicenseCheckSpecBll : BaseBll<LicenseCheckSpecEntity>
    {
        public LicenseCheckSpecBll()
        {
            BaseDal = new LicenseCheckSpecDal();
        }

        /// <summary>
        /// 获取现场勘验、验收的信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseCheckSpecEntity> GetSearchResult(LicenseCheckSpecEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddEqual(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_LicenseId, search.LicenseId);
            }

            if (search.CheckType > 0)
            {
                queryCondition.AddEqual(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_CheckType, search.CheckType.ToString());
            }

            //排序
            queryCondition.AddOrderBy(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_SortNo, true);
            return Query(queryCondition) as List<LicenseCheckSpecEntity>;
        }
    }
}
