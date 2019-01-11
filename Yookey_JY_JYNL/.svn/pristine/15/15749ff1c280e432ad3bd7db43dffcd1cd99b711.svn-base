//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IllegalConstructionDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/4/14 14:05:55
//  功能描述：IllegalConstruction数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Enumerate;

namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    /// <summary>
    /// IllegalConstruction数据访问操作
    /// </summary>
    public class IllegalConstructionDal : DalImp.BaseDal<IllegalConstructionEntity>
    {
        public IllegalConstructionDal()
        {
            Model = new IllegalConstructionEntity();
        }


        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-04-18
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="dismantlingType">拆除类型</param>
        /// <param name="unbuiltState">违建状态</param>
        /// <param name="startDate">违建日期（开始）</param>
        /// <param name="endDate">违建日期（截止）</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryIllegalConstructionList(IllegalConstructionStateType caseStateType, string companyId, string dismantlingType, string unbuiltState, string startDate, string endDate, string keyword, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT IC.Id, CompanyName,DeptName,CRDataSource.RsKey AS DataSource,CRUnState.RsKey AS UnbuiltState,UnbuiltDate,IC.CreateOn,IC.DismantlingType,
(CASE WHEN IC.DismantlingType='00820002' THEN CRAdvertisement.RsKey ELSE CRHousStructure.RsKey END) AS HousStructure,
AreaOfStructure,TargetName,TargetAddress,ApplicationUserName,NoticeNo,DismantleCompany.RsKey DismantleCompany,LetterOfPresentationSetTime,
(CASE WHEN IC.State=0 THEN '已登记' 
WHEN IC.State>0 AND IC.State<10 THEN '拆除申请审批中' 
WHEN IC.State=10 THEN '拆除申请审批已通过'
WHEN IC.State>10 AND IC.State<20 THEN '拆除结果上报审批中'
WHEN IC.State=20 THEN '已办结'
WHEN IC.State=30 THEN '已结算' END) AS StateDesc
FROM IllegalConstruction AS IC
LEFT JOIN ComResource AS CRDataSource ON IC.DataSource=CRDataSource.Id AND CRDataSource.ParentId='0073'
LEFT JOIN ComResource AS CRUnState ON IC.UnbuiltState=CRUnState.Id AND CRUnState.ParentId='0074'
LEFT JOIN ComResource AS CRHousStructure ON IC.HousStructure=CRHousStructure.Id AND CRHousStructure.ParentId='0075'
LEFT JOIN ComResource AS DismantleCompany ON IC.DismantleCompanyId=DismantleCompany.Id AND DismantleCompany.ParentId='0077'
LEFT JOIN ComResource AS CRAdvertisement ON IC.AdvertisementType=CRAdvertisement.Id AND CRAdvertisement.ParentId='0066'
WHERE 1=1 and IC.RowStatus=1");

                switch (caseStateType)
                {
                    case IllegalConstructionStateType.Registered:
                        strSql.Append(" AND [State]=0 ");
                        break;
                    case IllegalConstructionStateType.Dismantling:
                        strSql.Append(" AND [State]>=1 AND [State]<=20");
                        break;
                    case IllegalConstructionStateType.Application:
                        strSql.Append(" AND [State]>=1 AND [State]<=10");
                        break;
                    case IllegalConstructionStateType.Result:
                        strSql.Append(" AND [State]>=11 AND [State]<=20");
                        break;
                    case IllegalConstructionStateType.Settlement:
                        strSql.Append(" AND [State]=30");
                        break;
                    case IllegalConstructionStateType.All:
                        break;
                }

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND CompanyId='{0}' ", companyId);
                }
                if (!string.IsNullOrEmpty(unbuiltState))
                {
                    strSql.AppendFormat(" AND IC.UnbuiltState='{0}' ", unbuiltState);
                }
                if (!string.IsNullOrEmpty(dismantlingType))
                {
                    strSql.AppendFormat(" AND IC.DismantlingType='{0}' ", dismantlingType);
                }
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    strSql.AppendFormat(" AND IC.LetterOfPresentationSetTime>='{0}' AND IC.LetterOfPresentationSetTime<='{1} 23:59:59' ", startDate, endDate);
                }
                else if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
                {
                    strSql.AppendFormat(" AND IC.CreateOn>='{0}' ", startDate);
                }
                else if (string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    strSql.AppendFormat(" AND IC.CreateOn<='{0} 23:59:59' ", endDate);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(" AND (IC.TargetAddress like '%{0}%' or IC.NoticeNo like '%{0}%')", keyword);
                }

                var sortField = "CreateOn"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 结算统计
        /// </summary>
        /// <param name="drpCompany">所属片区</param>
        /// <param name="dismantleCompanyId">所属拆除公司</param>
        /// <param name="settlementStartDate">结算日期始</param>
        /// <param name="settlementEndDate">结算日期止</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetIllegalConstructionStatisticList(int rows, int page, string sidx, string sord, out int totalRecords, string dismantleCompanyId, string settlementStartDate, string settlementEndDate, string drpCompany)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT IC.Id,LetterOfPresentationSetTime,
                                ISNULL(DismantleCompany.RsKey,'') DismantleCompany,
                                ISNULL(CompanyName,'') CompanyName,
                                ISNULL(CASE WHEN SettlementType='00830001' THEN '人工'
                                WHEN SettlementType='00830002' THEN '拆防盗窗'
                                WHEN SettlementType='00830003' THEN '系数'
                                WHEN SettlementType='00830004' THEN '整体性'
                                WHEN SettlementType='00830005' THEN '封墙' end,'') AS SettlementType,
                                ISNULL(FloorSpace,'') FloorSpace,ISNULL(Factor,'') Factor,
                                ISNULL(DismantleArea,'') DismantleArea,
                                '' DismantlePrice,isnull(Manpower,'') Manpower,'' ManpowerPrice,
                                ISNULL(SecurityWindow,0) SecurityWindow,
                                '' SecurityWindowPrice,ISNULL(WholeReason,'')  WholeReason,
                                ISNULL(Wall,'0') FqArea,'' FqPrice,
                                GarbageCar,'' GarbagePrice,'' Other,'' OtherPrice,'' CountPrice,
                                ManpowerOnPrice,WailOnPrice,DismantleOnPrice,SecurityWindowOnPrice,GarbageCarOnPrice,IC.UpdateOn
                                FROM IllegalConstruction IC
                                LEFT JOIN ComResource AS DismantleCompany 
                                ON IC.DismantleCompanyId=DismantleCompany.Id 
                                AND DismantleCompany.ParentId='0077'
                                WHERE State=30 AND IC.RowStatus=1");
                if (!string.IsNullOrEmpty(dismantleCompanyId))
                {
                    strSql.AppendFormat("AND DismantleCompanyId='{0}'", dismantleCompanyId);
                }

                if (!string.IsNullOrEmpty(settlementStartDate) && !string.IsNullOrEmpty(settlementEndDate))
                {
                    strSql.AppendFormat("AND IC.UpdateOn>='{0}' AND IC.UpdateOn<='{1} 23:59:59'", settlementStartDate,
                                        settlementEndDate);
                }
                else if (!string.IsNullOrEmpty(settlementStartDate) && string.IsNullOrEmpty(settlementEndDate))
                {
                    strSql.AppendFormat("AND IC.UpdateOn>='{0}' ", settlementStartDate);
                }
                else if (string.IsNullOrEmpty(settlementStartDate) && !string.IsNullOrEmpty(settlementEndDate))
                {
                    strSql.AppendFormat("AND IC.UpdateOn<='{0} 23:59:59'", settlementEndDate);
                }

                if (!string.IsNullOrEmpty(drpCompany) && drpCompany != "all")
                {
                    strSql.AppendFormat("AND CompanyId='{0}'", drpCompany);
                }
                var sortField = "UpdateOn"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, page, rows, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="DismantleCompanyId"></param>
        /// <param name="SetTime"></param>
        /// <param name="drpCompany"></param>
        /// <returns></returns>
        public DataTable Export(string DismantleCompanyId, string SetTime, string drpCompany)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select IC.Id,LetterOfPresentationSetTime,
                                isnull(DismantleCompany.RsKey,'') DismantleCompany,
                                isnull(CompanyName,'') CompanyName,
                                isnull(case when SettlementType='00830001' then '人工'
                                when SettlementType='00830002' then '拆防盗窗'
                                when SettlementType='00830003' then '系数'
                                when SettlementType='00830004' then '整体性'
                                when SettlementType='00830005' then '封墙' end,'') as SettlementType,
                                isnull(FloorSpace,'') FloorSpace,isnull(Factor,'') Factor,
                                ISNULL(DismantleArea,'') DismantleArea,
                                '' DismantlePrice,isnull(Manpower,'') Manpower,'' ManpowerPrice,
                                isnull(SecurityWindow,0) SecurityWindow,
                                '' SecurityWindowPrice,isnull(WholeReason,'')  WholeReason,
                                ISNULL(Wall,'0') FqArea,'' FqPrice,
                                GarbageCar,'' GarbagePrice,'' Other,'' OtherPrice,'' CountPrice,
                                ManpowerOnPrice,WailOnPrice,DismantleOnPrice,SecurityWindowOnPrice,GarbageCarOnPrice
                                from IllegalConstruction IC
                                LEFT JOIN ComResource AS DismantleCompany 
                                ON IC.DismantleCompanyId=DismantleCompany.Id 
                                AND DismantleCompany.ParentId='0077'
                                where State=30 and IC.RowStatus=1");
                if (!string.IsNullOrEmpty(DismantleCompanyId))
                {
                    strSql.AppendFormat("AND DismantleCompanyId='{0}'", DismantleCompanyId);
                }

                if (!string.IsNullOrEmpty(SetTime))
                {
                    strSql.AppendFormat("AND CONVERT(nvarchar(100),LetterOfPresentationSetTime,23) = '{0}'", SetTime);
                }
                if (!string.IsNullOrEmpty(drpCompany) && drpCompany != "all")
                {
                    strSql.AppendFormat("AND CompanyId='{0}'", drpCompany);
                }

                strSql.Append("order by LetterOfPresentationSetTime DESC");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更改办件的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2018-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            var strSql = string.Format("UPDATE IllegalConstruction SET [State]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 更改办件的状态
        /// 添加人：周 鹏
        /// 添加时间：2018-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            try
            {
                var strSql = string.Format("UPDATE IllegalConstruction SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <param name="companyId">所属单位</param>
        /// <param name="dismantlingType">拆除类型</param>
        /// <param name="unbuiltState">违建设状态</param>
        /// <param name="unbuiltStartDate">开始日期</param>
        /// <param name="unbuiltEndDate">截止日期</param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public DataTable GetIllegalConstructionCount(string companyId, string dismantlingType, string unbuiltState, string unbuiltStartDate,
                                                   string unbuiltEndDate, string keyword)
        {
            try
            {
                var whereSql = new StringBuilder("");
                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    whereSql.AppendFormat(" AND CompanyId='{0}' ", companyId);
                }
                if (!string.IsNullOrEmpty(unbuiltState))
                {
                    whereSql.AppendFormat(" AND UnbuiltState='{0}' ", unbuiltState);
                }
                if (!string.IsNullOrEmpty(dismantlingType))
                {
                    whereSql.AppendFormat(" AND DismantlingType='{0}' ", dismantlingType);
                }
                if (!string.IsNullOrEmpty(unbuiltStartDate) && !string.IsNullOrEmpty(unbuiltEndDate))
                {
                    whereSql.AppendFormat(" AND LetterOfPresentationSetTime>='{0}' AND LetterOfPresentationSetTime<='{1} 23:59:59' ", unbuiltStartDate, unbuiltEndDate);
                }

                var strSql = new StringBuilder("");

                strSql.AppendFormat(@"SELECT (SELECT COUNT(*) FROM IllegalConstruction WHERE [STATE]=0 {0}) AS Registered,
(SELECT COUNT(*) FROM IllegalConstruction WHERE [STATE]>=1 AND [STATE]<=20 AND ROWSTATUS=1 {0}) AS Dismantling,
(SELECT COUNT(*) FROM IllegalConstruction WHERE [STATE]>=1 AND [STATE]<=10 AND ROWSTATUS=1 {0}) AS [Application],
(SELECT COUNT(*) FROM IllegalConstruction WHERE [STATE]>=11 AND [STATE]<=20 AND ROWSTATUS=1 {0}) AS Result,
(SELECT COUNT(*) FROM IllegalConstruction WHERE [STATE]=30 AND ROWSTATUS=1 {0}) AS Settlement,
(SELECT COUNT(*) FROM IllegalConstruction WHERE  ROWSTATUS=1 {0}) AS [All]", whereSql);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取统计报表数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable IllegalConstructionStatistics(string beginTime, string endTime)
        {
            try
            {
                var strSqlWhere = string.Empty;
                if (!string.IsNullOrEmpty(beginTime))
                {
                    strSqlWhere += string.Format(" AND LetterOfPresentationSetTime>'{0}'", beginTime);
                }
                if (!string.IsNullOrEmpty(endTime))
                {
                    strSqlWhere += string.Format(" AND LetterOfPresentationSetTime<'{0} 23:59:59'", beginTime);
                }
                var strSql = string.Format(@"WITH NUMBERDATA AS
(
   SELECT COMPANYID,DISMANTLECOMPANYID,COUNT(*) NUMBER FROM ILLEGALCONSTRUCTION 
   WHERE DISMANTLECOMPANYID<>''
   {0}
   GROUP BY COMPANYID,DISMANTLECOMPANYID
)
SELECT FULLNAME,
ISNULL((SELECT NUMBER FROM NUMBERDATA WHERE COMPANYID=ID AND DISMANTLECOMPANYID='00770001'),0) COMPANY1, 
ISNULL((SELECT NUMBER FROM NUMBERDATA WHERE COMPANYID=ID AND DISMANTLECOMPANYID='00770002'),0) COMPANY2, 
ISNULL((SELECT NUMBER FROM NUMBERDATA WHERE COMPANYID=ID AND DISMANTLECOMPANYID='00770003'),0) COMPANY3,
ISNULL((SELECT NUMBER FROM NUMBERDATA WHERE COMPANYID=ID AND DISMANTLECOMPANYID='00770004'),0) COMPANY4
FROM [DBO].[CRMCOMPANY]
WHERE PARENTID='D51BBD91-1381-4D02-8910-E3654F34D6A0' ", strSqlWhere);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

