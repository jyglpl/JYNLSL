//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseMaterialCatalogueBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseMaterialCatalogue业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseMaterialCatalogue业务逻辑
    /// </summary>
    public class LicenseMaterialCatalogueBll : BaseBll<LicenseMaterialCatalogueEntity>
    {
       public LicenseMaterialCatalogueBll()
        {
            BaseDal = new LicenseMaterialCatalogueDal();
        }


       /// <summary>
       /// 获取材料目录
       /// 添加人：周 鹏
       /// 添加时间：2018-02-02
       /// </summary>
       /// <hisotry>
       /// 修改描述：时间+作者+描述
       /// </hisotry> 
       /// <param name="search">查询实体</param> 
       /// <returns></returns>
       public List<LicenseMaterialCatalogueEntity> GetSearchResult(LicenseMaterialCatalogueEntity search)
       {
           var queryCondition = QueryCondition.Instance.AddEqual(LicenseMaterialCatalogueEntity.Parm_LicenseMaterialCatalogue_RowStatus, "1");
           if (!string.IsNullOrEmpty(search.ItemCode))
           {
               queryCondition.AddLike(LicenseMaterialCatalogueEntity.Parm_LicenseMaterialCatalogue_ItemCode, search.ItemCode);
           }
           //排序
           queryCondition.AddOrderBy(LicenseMaterialCatalogueEntity.Parm_LicenseMaterialCatalogue_SortNo, true);
           return Query(queryCondition) as List<LicenseMaterialCatalogueEntity>;
       }
    }
}                                                                                                                 
