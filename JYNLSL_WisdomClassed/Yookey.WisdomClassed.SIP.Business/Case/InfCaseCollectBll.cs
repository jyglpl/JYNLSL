//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CASE_COLLECTBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/25 9:28:46
//  功能描述：INF_CASE_COLLECT业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 其他类案件汇总 业务逻辑
    /// </summary>
    public class InfCaseCollectBll : BaseBll<InfCaseCollectEntity>
    {
       public InfCaseCollectBll()
        {
            BaseDal = new InfCaseCollectDal();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
       public int DeleteCaseCollect(string Id, BaseUserEntity user)
       {
           int res=0;
           if(!string.IsNullOrEmpty(Id))
           {
              InfCaseCollectEntity entity=Get(Id);
              if (entity != null)
              {
                  entity.RowStatus = 0;
                  entity.UpdateId = user.Id;
                  entity.UpdateBy = user.UserName;
                  entity.UpdateOn = DateTime.Now;
                  res=Update(entity);
              }
           }
               return res;
       }


        /// <summary>
        /// 添加案件
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="user"></param>
        /// <returns></returns>
       public InfCaseCollectEntity AddOrUpdateCaseCollect(InfCaseCollectEntity entity, BaseUserEntity user)
       {
           
           if (entity != null)
           {
               if (!string.IsNullOrEmpty(entity.Id))
               {
                   InfCaseCollectEntity one = BaseDal.Get(entity.Id);
                   if (one != null)//修改
                   {
                       entity.RowStatus = 1;
                       entity.UpdateId = user.Id;
                       entity.UpdateBy = user.UserName;
                       entity.UpdateOn = DateTime.Now;
                       Update(entity);
                       return entity;
                   }
               }
               //新增
               entity.Id = Guid.NewGuid().ToString();
               entity.RowStatus = 1;
               entity.CreatorId = user.Id;
               entity.CreateBy = user.UserName;
               entity.CreateOn = DateTime.Now;

               entity.UpdateId = user.Id;
               entity.UpdateBy = user.UserName;
               entity.UpdateOn = DateTime.Now;
               return base.Add(entity);
           }
           return null;
       }

       /// <summary>
       /// 查找案件记录
       /// 创建人：周庆
       /// 创建日期：2015年5月25日
       /// </summary>
       /// <param name="deptId">部门Id</param>
       /// <param name="period">时间（月）</param>
       /// <param name="classNo">类别</param>
       /// <param name="caseType">案件类别</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
       public PageJqDatagrid<DataTable> SearchCaseCollect(string deptId, string period, string classNo, InfCaseCollectEntity.CaseType caseType, int pageSize = 30, int pageIndex = 1)
       {
           int totalRecords;
           var data = new InfCaseCollectDal().SearchCaseCollect(deptId, period, classNo, caseType,pageSize, pageIndex, out totalRecords);
           var totalPage = (totalRecords + pageSize - 1) / pageSize;
           return new PageJqDatagrid<DataTable>
           {
               page = pageIndex,
               rows = data,
               total = totalPage,
               records = totalRecords,
           };
       }

       /// <summary>
       /// 获取案件信息
       /// 创建人：周庆
       /// 创建日期：2015年5月26日
       /// </summary>
       /// <param name="deptId">部门Id</param>
       /// <param name="period">所属日期</param>
       /// <param name="classNo">类型</param>
       /// <param name="caseType">案件类型</param>
       /// <returns></returns>
       public InfCaseCollectEntity GetCaseCollent(string deptId, string period, string classNo, InfCaseCollectEntity.CaseType caseType)
       {
           return new InfCaseCollectDal().GetCaseCollent(deptId, period, classNo, caseType);
       }

        
    }
}                                                                                                                 
