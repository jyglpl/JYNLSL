//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseInquestSizeBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-04-03 11:11:59
//  功能描述：LicenseInquestSize业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;
using System.Linq;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.Business.Crm;
using System;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseInquestSize业务逻辑
    /// </summary>
    public class LicenseInquestSizeBll : BaseBll<LicenseInquestSizeEntity>
    {
       public LicenseInquestSizeBll()
        {
            BaseDal = new LicenseInquestSizeDal();
        }

       /// <summary>
       /// 获取店招店牌的现场踏勘的左邻右邻
       /// 添加人：周 鹏
       /// 添加时间：2018-02-05
       /// </summary>
       /// <hisotry>
       /// 修改描述：时间+作者+描述
       /// </hisotry> 
       /// <param name="search">查询实体</param> 
       /// <returns></returns>
       public List<LicenseInquestSizeEntity> GetSearchResult(LicenseInquestSizeEntity search)
       {
           var queryCondition = QueryCondition.Instance.AddEqual(LicenseInquestSizeEntity.Parm_LicenseInquestSize_RowStatus, "1");
           if (!string.IsNullOrEmpty(search.LicenseId))
           {
               queryCondition.AddEqual(LicenseInquestSizeEntity.Parm_LicenseInquestSize_LicenseId, search.LicenseId);
           }   
           //排序
           queryCondition.AddOrderBy(LicenseInquestSizeEntity.Parm_LicenseInquestSize_CreateOn, false);
           return Query(queryCondition) as List<LicenseInquestSizeEntity>;
       }

    }

}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
