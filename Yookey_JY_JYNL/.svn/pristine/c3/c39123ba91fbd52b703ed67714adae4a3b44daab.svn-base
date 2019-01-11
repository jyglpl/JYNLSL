//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainAttachBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainAttach业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TempDetain;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.TempDetain
{
    /// <summary>
    /// TempDetainAttach业务逻辑
    /// </summary>
    public class TempDetainAttachBll : BaseBll<TempDetainAttachEntity>
    {
       public TempDetainAttachBll()
        {
            BaseDal = new TempDetainAttachDal();
        }

       /// <summary>
       /// 创建修改暂扣基本信息
       /// 创建人：周庆
       /// 创建日期：2015年5月4日
       /// </summary>
       /// <param name="entity"></param>
       /// <returns>返回主键ID</returns>
       public string CreateTempDetainInfo(TempDetainAttachEntity entity)
       {
           if (string.IsNullOrEmpty(entity.ResourceId)) return null;

           //var info = new TempDetainInfoDal().Get(entity.ResourceId);
           //if (info == null)
           //    return null;
           string Id = entity.Id= Guid.NewGuid().ToString();
           entity.RowStatus = 1;
           BaseDal.Add(entity);
           return Id;
       }

        
        /// <summary>
        /// 获取暂扣的所有附件
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="TempId"></param>
        /// <returns></returns>
       public List<TempDetainAttachEntity> GetTempDetainAttachsByTempId(string TempId)
       {
           if (string.IsNullOrEmpty(TempId)) return null;
          return  new TempDetainAttachDal().GetTempDetainAttachsByTempId(TempId);
       }


       /// <summary>
       /// 查询案件对应的附件
       /// </summary>
       /// <param name="search">查询条件</param>
       /// <returns></returns>
       public List<TempDetainAttachEntity> GetSearchResult(TempDetainAttachEntity search)
       {
           var queryCondition = QueryCondition.Instance.AddEqual(TempDetainAttachEntity.Parm_TempDetainAttach_RowStatus, "1");
           if (!string.IsNullOrEmpty(search.ResourceId))
           {
               queryCondition.AddEqual(TempDetainAttachEntity.Parm_TempDetainAttach_ResourceId, search.ResourceId);
           }
           queryCondition.AddOrderBy(TempDetainAttachEntity.Parm_TempDetainAttach_CreateOn, true);
           return Query(queryCondition) as List<TempDetainAttachEntity>;
       }

       /// <summary>
       /// 查询案件对应的附件
       /// </summary>
       /// <param name="search">查询条件</param>
       /// <param name="types">附件的类型</param>
       /// <returns></returns>
       public List<TempDetainAttachEntity> GetSearchResult(TempDetainAttachEntity search, List<string> types)
       {
           var queryCondition = QueryCondition.Instance.AddEqual(TempDetainAttachEntity.Parm_TempDetainAttach_RowStatus, "1");
           if (!string.IsNullOrEmpty(search.ResourceId))
           {
               queryCondition.AddEqual(TempDetainAttachEntity.Parm_TempDetainAttach_ResourceId, search.ResourceId);
           }
           if (types != null && types.Count > 0)
           {
               queryCondition.AddIn(TempDetainAttachEntity.Parm_TempDetainAttach_FileType, string.Join(",", types.ToArray()));
           }
           queryCondition.AddOrderBy(TempDetainAttachEntity.Parm_TempDetainAttach_CreateOn, true);
           return Query(queryCondition) as List<TempDetainAttachEntity>;
       }

       /// <summary>
       /// 批量删除照片
       /// 添加人：周 鹏
       /// 添加时间：2015-03-03
       /// </summary>
       /// <history>
       /// 修改描述：时间+作者+描述
       /// </history>
       /// <param name="ids">照片数据集,使用逗号分隔开</param>
       /// <returns></returns>
       public bool DeleteAttach(string ids)
       {
           return new TempDetainAttachDal().DeleteAttach(ids);
       }
    }
}                                                                                                                 
