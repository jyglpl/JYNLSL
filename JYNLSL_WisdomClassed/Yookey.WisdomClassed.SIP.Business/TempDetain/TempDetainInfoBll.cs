//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfoBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainInfo业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TempDetain;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.TempDetain
{
    /// <summary>
    /// TempDetainInfo业务逻辑
    /// </summary>
    public class TempDetainInfoBll : BaseBll<TempDetainInfoEntity>
    {
        #region 状态代码

        /// <summary>
        /// 入库
        /// </summary>
        public static int CodePutin = 0;
        /// <summary>
        /// 发还
        /// </summary>
        public static int CodeReturn = 1;
        /// <summary>
        /// 移交
        /// </summary>
        public static int CodeTransfer = 2;
        /// <summary>
        /// 作废
        /// </summary>
        public static int CodeCancel = 3;

        #endregion

        readonly TempDetainInfoLegislationBll _tempDetainInfoLegislationBll = new TempDetainInfoLegislationBll();   //暂扣法律法规

        public TempDetainInfoBll()
        {
            BaseDal = new TempDetainInfoDal();
        }


        /// <summary>
        /// 创建修改暂扣基本信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="legislationId">违法行为主键</param>
        /// <param name="legislationItemId">适用案由主键</param>
        /// <param name="legislationGistId">法律条文主键</param>
        /// <returns>返回主键ID</returns>
        public string CreateOrUpdateTempDetainInfo(TempDetainInfoEntity entity, string legislationId, string legislationItemId, string legislationGistId)
        {
            var id = entity.Id;
            if (!string.IsNullOrEmpty(id))
            {
                var model = BaseDal.Get(id);
                if (model != null && !string.IsNullOrEmpty(model.Id)) //修改操作
                {
                    entity.State = model.State;
                    entity.CreatorId = model.CreatorId;
                    entity.CreateOn = model.CreateOn;
                    entity.CreateBy = model.CreateBy;
                    entity.RowStatus = model.RowStatus;
                    var isOk = Update(entity) > 0;
                    if (isOk)
                    {
                        //保存法律法规
                        _tempDetainInfoLegislationBll.SavePunishLegislation(entity.Id, legislationId, legislationItemId,
                                                                            legislationGistId);
                    }
                    return id;
                }
                else
                {
                    //没有Id就重新生成Id
                    entity.Id = id;
                    //新增操作
                    entity.State = CodePutin;
                    entity.RowStatus = 1;

                    if (Add(entity) != null)
                    {
                        _tempDetainInfoLegislationBll.SavePunishLegislation(id, legislationId, legislationItemId, legislationGistId);
                    }

                    return id;
                }
            }
            else
            {
                //没有Id就重新生成Id
                entity.Id = id;
                //新增操作
                entity.State = CodePutin;
                entity.RowStatus = 1;

                if (Add(entity) != null)
                {
                    _tempDetainInfoLegislationBll.SavePunishLegislation(id, legislationId, legislationItemId, legislationGistId);
                }

                return id;
            }
            return id;
        }

        /// <summary>
        /// 修改暂扣基本信息的状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="StatusCode">已入库：0 已发还：1已移交：2已作废：3</param>
        /// <param name="UpdateId">修改人Id</param>
        /// <param name="UpdateBy">修改人姓名</param>
        /// <returns></returns>
        public int ChangeTempDetainInfoStatus(string Id, int StatusCode, string UpdateId, string UpdateBy)
        {
            int res = 0;
            if (!string.IsNullOrEmpty(Id))
            {
                TempDetainInfoEntity entity = BaseDal.Get(Id);
                if (entity != null)
                {
                    entity.State = StatusCode;
                    entity.UpdateOn = DateTime.Now;
                    entity.UpdateId = UpdateId;
                    entity.UpdateBy = UpdateBy;
                    res = Update(entity);
                }
            }
            return res;
        }

        /// <summary>
        /// 获取暂扣基本信息记录
        /// </summary>
        /// <param name="deptId">部门id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="pageSize">每页大小（默认30）</param>
        /// <param name="pageIndex">当前索引页（默认1）</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetAllTempDetainInfo(string companyId, string deptId, string startTime, string endTime, string keywords, int pageSize = 30, int pageIndex = 1)
        {
            int totalRecords;
            var data = new TempDetainInfoDal().GetAllTempDetainInfo(companyId, deptId, startTime, endTime, keywords, pageSize, pageIndex, out totalRecords);
            data.ForEach(t => t.ShowState = EnumOperate.GetEnumDesc((TempDetainSate)t.State));

            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };
        }


        /// <summary>
        /// 事务保存暂扣物品信息
        /// </summary>
        /// <param name="withhold">暂扣实体</param>
        /// <param name="withholdArticleList">物品集合</param>
        /// <param name="legislationId">违法行为ID</param>
        /// <param name="legislationItemId">适用案由ID</param>
        /// <param name="legislationGistId">法律条款ID</param>
        /// <returns></returns>
        public bool TransactionSave(TempDetainInfoEntity withhold, List<TempDetainGoodsEntity> withholdArticleList,
                                    string legislationId, string legislationItemId, string legislationGistId, InfPunishCaseinfoEntity infPunishCaseinfoEntity)
        {
            return new TempDetainInfoDal().TransactionSave(withhold, withholdArticleList, legislationId,
                                                           legislationItemId, legislationGistId, infPunishCaseinfoEntity);

        }

        /// <summary>
        /// 事务修改暂扣状态和审核过程
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="tempDetainInfoProcess"></param>
        /// <returns></returns>
        public bool TransactionUpdateTempDetainInfoSaveProcess(TempDetainInfoEntity withhold, List<TempDetainGoodsEntity> tempDetainGoodList, TempDetainInfoProcessEntity tempDetainInfoProcess)
        {
            return new TempDetainInfoDal().TransactionUpdateTempDetainInfoSaveProcess(withhold, tempDetainGoodList, tempDetainInfoProcess);
        }
        
          /// <summary>
        /// 批量删除暂扣
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new TempDetainInfoDal().BatchDelete(ids);
        }

        /// <summary>
        /// 获取统计列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<TempDetainInfoEntity> GetStatistics(string startTime, string endTime)
        {
            return new TempDetainInfoDal().GetStatistics(startTime, endTime);
        }
    }
}
