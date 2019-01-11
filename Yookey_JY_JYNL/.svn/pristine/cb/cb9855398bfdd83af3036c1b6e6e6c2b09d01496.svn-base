//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseHandUsersBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-21 18:11:24
//  功能描述：LicenseHandUsers业务逻辑类
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
    /// LicenseHandUsers业务逻辑
    /// </summary>
    public class LicenseHandUsersBll : BaseBll<LicenseHandUsersEntity>
    {
       public LicenseHandUsersBll()
        {
            BaseDal = new LicenseHandUsersDal();
        }

       /// <summary>
       /// 获取许可案件派送人信息
       /// 添加人：周 鹏
       /// 添加时间：2018-02-05
       /// </summary>
       /// <hisotry>
       /// 修改描述：时间+作者+描述
       /// </hisotry> 
       /// <param name="search">查询实体</param> 
       /// <returns></returns>
       public List<LicenseHandUsersEntity> GetSearchResult(LicenseHandUsersEntity search)
       {
           var queryCondition = QueryCondition.Instance.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_RowStatus, "1");
           if (!string.IsNullOrEmpty(search.FormId))
           {
               queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_FormId, search.FormId);
           }

           if (!string.IsNullOrEmpty(search.UserId))
           {
               queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_UserId, search.UserId);
           }
           if (search.HandType != 0)
           {
               queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_HandType, search.HandType.ToString());
           }         
           //排序
           queryCondition.AddOrderBy(LicenseHandUsersEntity.Parm_LicenseHandUsers_CreateOn, true);
           return Query(queryCondition) as List<LicenseHandUsersEntity>;
       }

       /// <summary>
       /// 获取已选派送人员
       /// </summary>
       /// <param name="formId">案件编号</param>
       /// <param name="handType">处理类型（1.踏勘 2.验收）</param>
       /// <returns></returns>
       public List<string> GetLicenseHandUserIds(string formId, int handType)
       {
           var search = new LicenseHandUsersEntity() { FormId = formId, HandType = handType };
           var list = this.GetSearchResult(search);
           return list.Select(i => i.UserId).ToList();
       }

        /// <summary>
        /// 设置派送人员
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="handType"></param>
        /// <returns></returns>
       public bool SetLicenseHandUserIds(LicenseHandUserIdRequest setIds)
       {
           return new LicenseHandUsersDal().SetLicenseHandUserIds(setIds);
       }

       /// <summary>
       /// 获取是否有转派的操作权限
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public bool GetLicenseHandLimits(LicenseHandLimitsRequest limits)
       {
           var list = this.GetSearchResult(new LicenseHandUsersEntity() { FormId = limits.LicenseId, HandType = limits.HandType, UserId = limits.HandUserId });
           return list.Count > 0;
       }

        /// <summary>
        /// 设置已经处理（派送和待办）
        /// </summary>
        /// <param name="limits"></param>
        /// <returns></returns>
       public bool SetIsHandle(LicenseHandLimitsRequest limits, SqlTransaction transaction)
       {
           return new LicenseHandUsersDal().SetIsHandle(limits,transaction);
       }

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
