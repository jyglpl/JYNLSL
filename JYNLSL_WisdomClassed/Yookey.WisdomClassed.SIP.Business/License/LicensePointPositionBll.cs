//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicensePointPositionBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-13 17:14:03
//  功能描述：LicensePointPosition业务逻辑类
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
    /// LicensePointPosition业务逻辑
    /// </summary>
    public class LicensePointPositionBll : BaseBll<LicensePointPositionEntity>
    {
        public LicensePointPositionBll()
        {
            BaseDal = new LicensePointPositionDal();
        }

        /// <summary>
        /// 获取点位信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicensePointPositionEntity> GetSearchResult(LicensePointPositionEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddEqual(LicensePointPositionEntity.Parm_LicensePointPosition_LicenseId, search.LicenseId);
            }
            if (!string.IsNullOrEmpty(search.PointType))
            {
                queryCondition.AddEqual(LicensePointPositionEntity.Parm_LicensePointPosition_PointType, search.PointType.ToString());
            }
            //排序
            queryCondition.AddOrderBy(LicensePointPositionEntity.Parm_LicensePointPosition_CreateOn, false);
            return Query(queryCondition) as List<LicensePointPositionEntity>;
        }

    }
}
