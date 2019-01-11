//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfoDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainInfo数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Linq;
using DBHelper;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using System.Collections.Generic;
using System;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.DataAccess.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.TempDetain
{
    /// <summary>
    /// TempDetainInfo数据访问操作
    /// </summary>
    public class TempDetainInfoDal : DalImp.BaseDal<TempDetainInfoEntity>
    {

        readonly TempDetainGoodsDal _tempDetainGoodsDal = new TempDetainGoodsDal();
        public TempDetainInfoDal()
        {
            Model = new TempDetainInfoEntity();
        }

        /// <summary>
        /// 获取暂扣基本信息
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询截止时间</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns></returns>
        public List<TempDetainInfoEntity> GetAllTempDetainInfo(string companyId, string deptId, string startTime, string endTime, string keywords, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT TP.Id,TP.TempNo,TP.TempType,TP.TargetName,TP.TempAddress,TL.ItemNo,TL.ItemName,TP.DepartmentName,TP.RePersonelNameFist,TP.RePersonelNameSecond,TP.TempDateTime,TP.[State]
FROM TempDetainInfo AS TP WITH (NOLOCK)
LEFT JOIN TempDetainInfo_Legislation TL WITH (NOLOCK) ON TL.CaseInfoId = TP.Id
WHERE TP.RowStatus = 1 AND TL.RowStatus=1 ");

            if (!string.IsNullOrEmpty(companyId))
            {
                strSql.AppendFormat(" AND CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId))
            {
                strSql.AppendFormat(" AND DepartmentId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                strSql.AppendFormat(" AND (TP.TargetName like '%{0}%' or TP.TempAddress like '%{0}%'  or TP.TempNo like '%{0}%'or TP.RePersonelNameFist like '%{0}%' or TP.RePersonelIdSecond like '%{0}%') ", keywords);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strSql.AppendFormat(" AND TempDateTime>='{0}'", startTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND TempDateTime<='{0} 23:59:59.999'", endTime);
            }
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "TempDateTime", "Desc", pageIndex, pageSize, out totalRecords);
            return data != null && data.Rows.Count > 0 ? DataTableToList(data) : new List<TempDetainInfoEntity>();
        }

        /// <summary>
        /// 获取暂扣列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<TempDetainInfoEntity> GetStatistics(string startTime,string endTime)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"select * from [dbo].[TempDetainInfo] 
where [RowStatus]=1 and [CreateOn]>='{0}' and [CreateOn]<='{1}' ", startTime, endTime);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<TempDetainInfoEntity>();
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
            var transaction = new TransactionLoader().BeginTransaction("TempDetain");
            try
            {
                var checkEntity = Get(withhold.Id);
                var tempId = withhold.Id;


                if (checkEntity != null && !string.IsNullOrEmpty(checkEntity.Id))
                {
                    Update(withhold, transaction);  //修改
                }
                else
                {
                    Add(withhold, transaction);     //新增
                }

                if (withholdArticleList.Any())
                {
                    var sql = string.Format("DELETE TempDetainGoods WHERE TempId='{0}' ", withhold.Id);
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                }

                new TempDetainInfoLegislationDal().SavePunishLegislation(tempId, legislationId, legislationItemId,
                                                                         legislationGistId, transaction);

                var index = 0;
                foreach (var item in withholdArticleList)
                {
                    item.GoodsNo = withhold.TempNo + "-" + (index + 1).ToString("000");   //物品编号
                    new TempDetainGoodsDal().Add(item, transaction);
                    index++;
                }

                // 如果关联案件
                if (infPunishCaseinfoEntity != null)
                {
                    new InfPunishCaseinfoDal().Update(infPunishCaseinfoEntity, transaction);
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 事务修改暂扣状态和审核过程
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="tempDetainInfoProcess"></param>
        /// <returns></returns>
        public bool TransactionUpdateTempDetainInfoSaveProcess(TempDetainInfoEntity withhold, List<TempDetainGoodsEntity> tempDetainGoodList, TempDetainInfoProcessEntity tempDetainInfoProcess)
        {
            var transaction = new TransactionLoader().BeginTransaction("TempDetainProcess");
            try
            {
                Update(withhold, transaction);  //修改

                foreach (var item in tempDetainGoodList)
                {
                    _tempDetainGoodsDal.Update(item, transaction);
                }

                if (tempDetainInfoProcess != null)
                {
                    new TempDetainInfoProcessDal().Add(tempDetainInfoProcess, transaction);
                }

            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 批量删除暂扣
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE TempDetainInfo SET RowStatus =0 WHERE [Id] IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}

