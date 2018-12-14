//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_CASEINFODal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_CASEINFO数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 案件基本信息数据访问操作
    /// </summary>
    public class InfPunishCaseinfoDal : DalImp.BaseDal<InfPunishCaseinfoEntity>
    {
        public InfPunishCaseinfoDal()
        {
            Model = new InfPunishCaseinfoEntity();
        }

        /// <summary>
        /// 查询案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-02-28 周 鹏 添加预审数据查询
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="userDeptId">当前登录部门的Id</param>
        /// <param name="deptId">部门编号,查询指定部门的数据,不传则查所有</param>
        /// <returns>DataTable Columns->FirstTrial:预审,Untreated:待处理,Untreated:处理中,Processed:已处理,StayClose:待结案,CloseJugee:已结案,Archived:已归档,All:全部</returns>
        public DataTable GetCaseStateCount(string companyId, string deptId, string userDeptId, string caseType = "00950001")
        {
            var strSql = new StringBuilder("");
            var childSql = new StringBuilder("");
            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                childSql.AppendFormat("AND CompanyId='{0}' ", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                childSql.AppendFormat("AND DeptId='{0}' ", deptId);
            }

            if (!string.IsNullOrEmpty(caseType))
            {
                childSql.AppendFormat("AND CaseType='{0}' ", caseType);
            }

            //var childSql2 = new StringBuilder("");
            //if (string.IsNullOrEmpty(companyId) || companyId.Equals("all"))
            //{
            //    childSql2.AppendFormat("AND DeptId='{0}' ", userDeptId);
            //}

            strSql.AppendFormat(@"SELECT
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]<10 {0}) AS 'FirstTrial',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]=10 {0}) AS 'Untreated',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]>10 AND [State]<80 {0}) AS 'InHand',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]>=80 AND [State]<90 {0}) AS 'StayClose',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]>=90 {0}) AS 'CloseJugee',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 AND [State]=100 {0}) AS 'Archived',
(SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE RowStatus=1 {0}) AS 'All'", childSql);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取案件列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCaseList(string keywords, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT * FROM INF_PUNISH_CASEINFO WHERE RowStatus = 1 ");
                if (!string.IsNullOrEmpty(keywords))
                {
                    strSql.AppendFormat(@" AND(TargetName LIKE '%{0}%' OR TargetUnit LIKE '%{0}%')", keywords);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-02-28 周 鹏 增加预审的状态控制
        ///           2015-07-15 周 鹏 增加动态排序
        ///           2015-07-21 周 鹏 当前登录部门的ID
        ///           2015-09-28 周 鹏 修改待结案处Sql
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="queryType">查询类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="userDeptId">当前登录部门的ID</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryCaseList(CaseStateType caseStateType, CaseQueryType queryType, string companyId,
                                       string deptId, string userDeptId, string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord, string caseType, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(
                    @"SELECT IPC.Id,CaseInfoNo,NoticeNo,DeptName,(CASE WHEN TargetType='00120001' THEN TargetName ELSE TargetUnit END) AS TargetName,CONVERT(VARCHAR(10),CaseDate,25) AS 'CaseDate',CaseAddress,ISNULL(IPI.ItemName,'') AS ItemName,IPC.CreateOn,'' AS DecisionDate FROM INF_PUNISH_CASEINFO AS IPC WITH (NOLOCK)
LEFT JOIN INF_PUNISH_LEGISLATION AS IPI WITH(NOLOCK) ON IPC.Id=IPI.CaseInfoId WHERE 1=1 AND IPC.RowStatus=1 AND IPI.RowStatus=1 ");

                //状态分类
                switch (caseStateType)
                {
                    case CaseStateType.FirstTrial:
                        {
                            strSql.AppendFormat("AND [State]<10 ");
                        }
                        break;
                    case CaseStateType.Untreated:
                        strSql.AppendFormat("AND [State]=10");
                        break;
                    case CaseStateType.InHand:
                        strSql.AppendFormat("AND [State]>10 AND [State]<80 ");
                        break;
                    case CaseStateType.StayClose:
                        {
                            strSql = new StringBuilder("");
                            strSql.AppendFormat(@"SELECT IPC.Id,CaseInfoNo,NoticeNo,DeptName,(CASE WHEN TargetType='00120001' THEN IPC.TargetName ELSE TargetUnit END) AS TargetName,CONVERT(VARCHAR(10),IPC.CaseDate,25) AS 'CaseDate',CaseAddress,ISNULL(IPI.ItemName,'') AS ItemName,IPC.CreateOn ,(CASE WHEN CONVERT(VARCHAR(10),DATEADD(MONTH,{0},IPD.FileDate),23)<=GETDATE() THEN 'Red' ELSE '' END) AS DecisionDate
FROM INF_PUNISH_CASEINFO AS IPC WITH (NOLOCK)
LEFT JOIN INF_PUNISH_LEGISLATION AS IPI WITH(NOLOCK) ON IPC.Id=IPI.CaseInfoId
LEFT JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId
WHERE 1=1 AND IPC.RowStatus=1 AND IPI.RowStatus=1
AND IPC.[State]>=80 AND IPC.[State]<90
AND PunishType<>'00280001'", AppConfig.FinishMonth);
                        }
                        break;
                    case CaseStateType.CloseJugee:
                        strSql.AppendFormat("AND [State]>=90 ");
                        break;
                    case CaseStateType.Archived:
                        strSql.AppendFormat("AND [State]=100 ");
                        break;
                    case CaseStateType.All:
                        break;
                }

                //查询类型
                switch (queryType)
                {
                    case CaseQueryType.CaseInfoNo:
                        strSql.AppendFormat("AND CaseInfoNo LIKE '%{0}%' ", keyword);
                        break;
                    case CaseQueryType.NoticeNo:
                        strSql.AppendFormat("AND NoticeNo LIKE '%{0}%' ", keyword);
                        break;
                    case CaseQueryType.TargetName:
                        strSql.AppendFormat("AND (TargetName LIKE '%{0}%' OR TargetUnit LIKE '%{0}%')", keyword);
                        break;
                }
                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND CompanyId='{0}' ", companyId);
                }
                if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
                {
                    strSql.AppendFormat("AND DeptId='{0}' ", deptId);
                }

                if (!string.IsNullOrEmpty(caseType))
                {
                    strSql.AppendFormat("AND CaseType='{0}' ", caseType);
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
        /// 查询案件详细信息
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseDetails(string id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC CaseInfo '{0}'", id);
                return
                    SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询案件详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-03-31
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public DataTable GetMobileCaseDetails(string id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC Mobile_CaseInfo '{0}'", id);
                return
                    SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 更改案件的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id)
        {
            var strSql = string.Format("UPDATE INF_PUNISH_CASEINFO SET [State]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 更改案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id, int state)
        {
            try
            {
                var strSql = string.Format("UPDATE INF_PUNISH_CASEINFO SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 叶念
        /// </summary>
        /// <param name="id">更新归档日期</param>
        /// <returns></returns>
        public bool UpdateCaseGdd(string id)
        {
            try
            {
                var strSql = string.Format("UPDATE INF_PUNISH_CASEINFO SET GDDate=GETDATE() WHERE Id='{0}'", id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询照片的详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID信息</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryPhotoDetails(string fileId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT IPL.ItemName,(CASE WHEN IPA.ShootTime='' OR IPA.ShootTime IS NULL THEN IPA.CreateOn ELSE IPA.ShootTime END) AS ShootTime,IPC.CaseAddress,IPC.RePersonelNameFist,IPC.RePersonelNameSecond,IPA.FileAddress AS ImgAddress FROM INF_PUNISH_ATTACH AS IPA
JOIN INF_PUNISH_CASEINFO AS IPC ON IPA.ResourceId=IPC.Id
JOIN INF_PUNISH_LEGISLATION AS IPL ON IPA.ResourceId=IPL.CaseInfoId
WHERE IPA.Id='{0}'", fileId);

                return
                    SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 验证通知书编号是否可用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <returns></returns>
        public bool CheckNoticeNo(string caseinfoId, string noticeNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                if (!string.IsNullOrEmpty(caseinfoId))
                {
                    strSql.AppendFormat(
                        @"SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE Id<>'{0}' AND  NoticeNo='{1}'", caseinfoId,
                        noticeNo);
                }
                else
                {
                    strSql.AppendFormat(@"SELECT COUNT(*) FROM dbo.INF_PUNISH_CASEINFO WHERE NoticeNo='{0}'", noticeNo);
                }
                var cnt =
                    int.Parse(
                        SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString())
                                 .ToString());
                return cnt == 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 通通知书编号查询案件信息
        /// </summary>
        /// <param name="noticeNo"></param>
        /// <returns></returns>
        public InfPunishCaseinfoEntity GetCaseInfoByNoticeNo(string noticeNo)
        {
            string sqlStr = string.Format("  SELECT * FROM INF_PUNISH_CASEINFO WHERE NoticeNo='{0}' ", noticeNo);

            var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sqlStr).Tables[0];

            return data != null && data.Rows.Count > 0 ? DataTableToList(data)[0] : null;

        }


        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2015-05-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="caseStartTime">案发开始时间</param>
        /// <param name="caseEndTime">案发截止时间</param>
        /// <param name="classI">大类</param>
        /// <param name="classIi">小类</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryQueryCaseList(string deptId, string caseStartTime, string caseEndTime, string classI,
                                            string classIi, int pageSize,
                                            int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(
                    @"SELECT IPC.Id,CaseInfoNo,(CASE WHEN TargetType='00120001' THEN TargetName ELSE TargetUnit END) AS TargetName,
(CASE WHEN LEN(ISNULL(IPI.ItemName,''))>8 THEN SUBSTRING(ISNULL(IPI.ItemName,''),0,9)+'...' ELSE ISNULL(IPI.ItemName,'') END) AS ItemName,
CONVERT(VARCHAR(4),YEAR(IPF.FinishDate))+'年'+CONVERT(NVARCHAR(4),MONTH(IPF.FinishDate))+'月'+CONVERT(NVARCHAR(4),DAY(IPF.FinishDate)) AS FinishDate
FROM INF_PUNISH_CASEINFO AS IPC WITH (NOLOCK)
LEFT JOIN INF_PUNISH_LEGISLATION AS IPI WITH(NOLOCK) ON IPC.Id=IPI.CaseInfoId 
LEFT JOIN INF_PUNISH_FINISH AS IPF WITH(NOLOCK) ON IPC.Id=IPF.CaseInfoId
WHERE 1=1 AND IPC.RowStatus=1 AND IPI.RowStatus=1 AND [State]=80 AND IPC.PunishProcess='00280002'");

                if (!string.IsNullOrEmpty(deptId))
                {
                    strSql.AppendFormat(" AND DeptId='{0}' ", deptId);
                }
                if (!string.IsNullOrEmpty(caseStartTime) && !string.IsNullOrEmpty(caseEndTime))
                {
                    strSql.AppendFormat(" AND IPC.CaseDate>='{0}' AND IPC.CaseDate<='{1}'", caseStartTime, caseEndTime);
                }
                if (!string.IsNullOrEmpty(classI))
                {
                    strSql.AppendFormat(" AND IPI.ClassNo='{0}'", classI);
                }
                if (!string.IsNullOrEmpty(classIi))
                {
                    strSql.AppendFormat(" AND IPI.LegislationItemId='{0}'", classIi);
                }

                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "FinishDate",
                                                "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件初审
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formId">表单编号</param>
        /// <param name="state">状态值</param>
        /// <param name="firstTrialType">初审类型</param>
        /// <param name="personId">初审人员Id</param>
        /// <param name="personName">初审人员姓名</param>
        /// <returns></returns>
        public bool UpdateFirstTrial(string formId, int state, string firstTrialType, string personId, string personName)
        {
            try
            {
                var strSql = new StringBuilder("");
                if (firstTrialType.Equals("First"))
                {
                    strSql.AppendFormat(
                        "UPDATE INF_PUNISH_CASEINFO SET FirstTrialPersonelIdFirst='{0}',FirstTrialPersonelNameFirst='{1}',[State]={2} WHERE Id='{3}'",
                        personId, personName, state, formId);
                }
                else if (firstTrialType.Equals("Second"))
                {
                    strSql.AppendFormat(
                        "UPDATE INF_PUNISH_CASEINFO SET FirstTrialPersonelIdSecond='{0}',FirstTrialPersonelNameSecond='{1}',[State]={2} WHERE Id='{3}'",
                        personId, personName, state, formId);
                }

                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 将案件恢复成未处理
        /// 添加人：周 鹏
        /// 添加时间：2015-09-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseInfoId">案件主键编号</param>
        /// <returns></returns>
        public bool CancelHandle(string caseInfoId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"UPDATE INF_PUNISH_CASEINFO SET [State]=0 WHERE Id='{0}';
DELETE INF_PUNISH_DECISION WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_DOCUMENT WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_FINISH WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_INFORM WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_RECORD WHERE CaseInfoId='{0}';
DELETE WF_ProcessInstance WHERE FormID='{0}';
DELETE CrmIdeaList WHERE ResourceID='{0}' AND ProcessID<>0;
DELETE CrmMessageWork WHERE FormID='{0}' AND ProcessInstanceID<>'';", caseInfoId);


                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件删除
        /// 添加人：周 鹏
        /// 添加时间：2017-01-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseInfoId">案件主键编号</param>
        /// <returns></returns>
        public bool CaseDelete(string caseInfoId)
        {
            try
            {
                //var strSql = new StringBuilder("");
                //strSql.AppendFormat(@"DELETE INF_PUNISH_CASEINFO WHERE Id='{0}'", caseInfoId);

                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"DELETE INF_PUNISH_CASEINFO WHERE Id='{0}';
DELETE INF_PUNISH_DECISION WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_DOCUMENT WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_FINISH WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_INFORM WHERE CaseInfoId='{0}';
DELETE INF_PUNISH_RECORD WHERE CaseInfoId='{0}';
DELETE WF_ProcessInstance WHERE FormID='{0}';
DELETE CrmIdeaList WHERE ResourceID='{0}' AND ProcessID<>0;
DELETE CrmMessageWork WHERE FormID='{0}' AND ProcessInstanceID<>'';", caseInfoId);


                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查询人的工作量化
        /// 添加人：周 鹏
        /// 添加时间：2017-03-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns->A:教育纠处 B:违法停车 C:简易程序 D:一般程序 E:现场考核 F:暂扣物品</returns>
        public DataTable GetInteralDetailsByUserId(string userId, string startTime, string endTime)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT 
(SELECT COUNT(*) FROM Education WHERE (FirstUserId='{0}' OR SecondUserId='{0}') AND CreateOn>='{1}' AND CreateOn<='{2}') AS A,
(SELECT COUNT(*) FROM INF_CAR_CHECKSIGNMIDDLE WHERE (PersonId1='{0}' OR PersonId2='{0}') AND CreateOn>='{1}' AND CreateOn<='{2}') AS B,
(SELECT COUNT(*) FROM INF_PUNISH_CASEINFO WHERE (RePersonelIdFist='{0}' OR RePersonelIdSecond='{0}') AND CreateOn>='{1}' AND CreateOn<='{2}' AND PunishProcess='00280001') AS C,
(SELECT COUNT(*) FROM INF_PUNISH_CASEINFO WHERE (RePersonelIdFist='{0}' OR RePersonelIdSecond='{0}') AND CreateOn>='{1}' AND CreateOn<='{2}' AND PunishProcess IN ('00280002','00280003')) AS D,
(SELECT COUNT(*) FROM Assessment ASS WITH(NOLOCK) WHERE AssignUserId='{0}' AND [Status] >=2 AND HandlingTime>='{1}' AND HandlingTime<='{2}') AS E,
(SELECT COUNT(*) FROM TempDetainInfo Temp WITH(NOLOCK) WHERE (RePersonelIdFist='{0}' OR RePersonelIdSecond='{0}') AND TempDateTime>='{1}' AND TempDateTime<= '{2}') AS F",
                                userId, startTime, endTime);

            var dt =
                SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            return dt;
        }


        /// <summary>
        /// 查询人的工作量化 明细
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="caseType">A:教育纠处 B:违法停车 C:简易程序 D:一般程序 E:现场考核 F:暂扣物品</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="totalRecords">总记录条数</param>
        /// <returns></returns>
        public DataTable GetInteralDetails(string userId, string caseType, string startTime, string endTime,
                                           int pageSize,
                                           int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            string sortField = "";

            switch (caseType)
            {
                case "A":
                    {
                        strSql.AppendFormat(@"SELECT L.ClassName,E.ItemName,EducationTime,EducationAddress,E.IsRefused,E.TargetName,E.CreateOn FROM Education AS E
LEFT JOIN Legislation AS L ON E.LegislationId=L.Id
WHERE (E.FirstUserId='{0}' OR E.SecondUserId='{0}') 
AND CONVERT(VARCHAR(100), E.CreateOn, 23)>='{1}' AND CONVERT(VARCHAR(100), E.CreateOn, 23)<='{2}' ", userId, startTime,
                                            endTime);

                        sortField = "CreateOn";
                    }
                    break;
                case "B":
                    {
                        strSql.AppendFormat(@"SELECT NoticeNo,PersonName1,PersonName2,CarNo,CONVERT(VARCHAR(19),CheckDate,25) AS CheckDate,CheckSignAddress FROM INF_CAR_CHECKSIGNMIDDLE 
WHERE (PersonId1='{0}' OR PersonId2='{0}') AND  CONVERT(varchar(100), CreateOn, 23) >= '{1}' 
AND CONVERT(varchar(100), CreateOn, 23) <= '{2}' ", userId, startTime, endTime);

                        sortField = "CheckDate";
                    }
                    break;
                case "C":
                    {
                        strSql.AppendFormat(@"SELECT NoticeNo,IPL.ClassNoName,IPL.ItemName,
(CASE WHEN TargetType='00120001' THEN TargetName WHEN TargetType='00120002' THEN TargetUnit END) AS TargetName,CONVERT(VARCHAR(19),CaseDate,25) AS CaseDate,CaseAddress 
FROM INF_PUNISH_CASEINFO AS IPC
LEFT JOIN INF_PUNISH_LEGISLATION AS IPL ON IPC.Id=IPL.CaseInfoId 
WHERE (IPC.RePersonelIdFist='{0}' OR IPC.RePersonelIdSecond='{0}') 
AND CONVERT(VARCHAR(100),IPC.CreateOn, 23) >= '{1}' AND CONVERT(VARCHAR(100), IPC.CreateOn,23)<='{2}' 
AND IPC.PunishProcess='00280001' ", userId, startTime, endTime);

                        sortField = "CaseDate";
                    }
                    break;
                case "D":
                    {
                        strSql.AppendFormat(@"SELECT NoticeNo,IPL.ClassNoName,IPL.ItemName,
(CASE WHEN TargetType='00120001' THEN TargetName WHEN TargetType='00120002' THEN TargetUnit END) AS TargetName,CONVERT(VARCHAR(19),CaseDate,25) AS CaseDate,CaseAddress 
FROM INF_PUNISH_CASEINFO AS IPC
LEFT JOIN INF_PUNISH_LEGISLATION AS IPL ON IPC.Id=IPL.CaseInfoId 
WHERE (IPC.RePersonelIdFist='{0}' OR IPC.RePersonelIdSecond='{0}') 
AND CONVERT(VARCHAR(100), IPC.CreateOn, 23)>='{1}' 
AND CONVERT(VARCHAR(100), IPC.CreateOn, 23)<='{2}' 
AND IPC.PunishProcess IN ('00280002','00280003') ", userId, startTime, endTime);

                        sortField = "CaseDate";
                    }
                    break;
                case "E":
                    {
                        strSql.AppendFormat(@"SELECT ClassName,CONVERT(VARCHAR(19),AssessmentTime,25) AS AssessmentTime,AssessmentAddress,Remark FROM Assessment ASS WITH(NOLOCK) WHERE AssignUserId='{0}' 
AND [Status]>=2 AND CONVERT(VARCHAR(100),HandlingTime,23)>= '{1}' 
AND CONVERT(VARCHAR(100), HandlingTime, 23)<='{2}' ", userId, startTime, endTime);

                        sortField = "AssessmentTime";
                    }
                    break;
                case "F":
                    {
                        strSql.AppendFormat(@"SELECT TempNo,TDL.ClassNoName,TDL.ItemName,IsRefused,(CASE WHEN TargetType='00120001' THEN TargetName WHEN TargetType='00120002' THEN TargetUnit END) AS TargetName,CONVERT(VARCHAR(19),TempDateTime,25) TempDateTime,TempAddress,(SELECT ISNULL(SUM(GoodsCount),0) FROM TempDetainGoods WHERE TempId=TD.Id) AS GoodsCount FROM TempDetainInfo AS TD
LEFT JOIN TempDetainInfo_Legislation AS TDL ON TD.Id=TDL.CaseInfoId
WHERE (TD.RePersonelIdFist='{0}' OR TD.RePersonelIdSecond='{0}') AND CONVERT(VARCHAR(100),TempDateTime,23)>='{1}' 
AND CONVERT(varchar(100), TempDateTime, 23)<='{2}'", userId, startTime, endTime);

                        sortField = "TempDateTime";
                    }
                    break;
            }

            var dt = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, "DESC",
                                              pageIndex, pageSize, out totalRecords);
            return dt;
        }

        /// <summary>
        /// 获取行政处罚系统中未公示的处罚数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnPublicPunishment()
        {
            var strSql = new StringBuilder("");
            strSql.Append(
                @"SELECT IPC.Id AS Id,IPC.CaseInfoNo,'苏姑综法罚决字['+(SUBSTRING(IPC.CaseInfoNo,3,4))+']第'+(SUBSTRING(IPC.CaseInfoNo,8,10))+'号' AS CF_WSH,
IPL.ItemAct AS CF_AJMC,IPL.ItemNo AS CF_BM,
(CASE WHEN IPL.PunishAmount>0 THEN '罚款' ELSE '其他' END) AS CF_CFLB1,'' AS CF_CFLB2,
IPL.ItemName AS CF_SY,IPL.DutyName AS CF_YJ,IPC.TargetType,
(CASE WHEN IPC.TargetType='00120001' THEN IPC.TargetName ELSE TargetUnit END) AS CF_XDR_MC,
IPC.TargetSHXYM AS CF_XDR_SHXYM,
IPC.TargetZDM AS CF_XDR_ZDM,
(CASE WHEN IPC.TargetType='00120002' AND IPC.TargetPaperType='00130001' THEN IPC.TargetPaperNum ELSE IPC.TargetGSDJ END) AS CF_XDR_GSJD,
IPC.TargetSWDJ AS CF_XDR_SWDJ,
(CASE WHEN IPC.TargetType='00120001' THEN IPC.TargetPaperNum ELSE '' END) AS CF_XDR_SFZ,
(CASE WHEN IPC.TargetType='00120002' THEN IPC.TargetName ELSE '' END) AS CF_FR,
IPD.PunishContent AS CF_JG,
CONVERT(VARCHAR(10),IPD.FileDate,111) AS FileDate,
'苏州市姑苏区综合行政执法局' AS CFJG,0 AS ZT,'' AS BZ,0 AS FW,1 AS SXDJ,'' AS JZQ
FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CASEINFOID
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CASEINFOID
WHERE IPC.RowStatus=1 AND IPD.RowStatus=1 AND IPL.RowStatus=1 AND IPC.PunishProcess<>'00280001' AND IPC.[State]>=80 
AND IPD.FileDate>='2017-11-26' AND (IPC.IsPublic IS NULL OR IPC.IsPublic=0)");

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 批量更新处罚系统同步状态
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public bool UpdatePublicState(List<string> lists)
        {
            var transaction = new TransactionLoader().BeginTransaction("UpdatePublicState");
            try
            {
                foreach (var str in lists)
                {
                    var sbSql = new StringBuilder("");
                    sbSql.AppendFormat("UPDATE INF_PUNISH_CASEINFO SET IsPublic=1 WHERE Id='{0}'", str);
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }
    }
}

