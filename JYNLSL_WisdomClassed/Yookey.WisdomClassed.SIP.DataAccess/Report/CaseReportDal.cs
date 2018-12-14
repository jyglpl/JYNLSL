using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Report
{
    /// <summary>
    /// 案件相关统计
    /// </summary>
    public class CaseReportDal
    {
        /// <summary>
        /// 处理情况统计表
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2017-03-16 周 鹏 增加单位编号
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable. Columns :SumCount 已开停违单 SumHandle 未处理单 CarCount 已开停违单 CarHandle 未处理单 CaseCount 已开停违单 CaseHandle 未处理单</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryHandlingInformation(string companyId, string caseType, string startTime, string endTime)
        {
            try
            {
                var strSql = string.Format("EXEC Report_HandlInformation  @StartTime='{0}',@EndTime='{1}',@CompanyId='{2}',@CaseType='{3}'", startTime, endTime, companyId, caseType);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 案件明细统计
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable QueryCaseDetailsInformation(string startTime, string endTime, string deptid, string ProcessTypeId, string State, string ClassNo, string targetType, string keywords, string sidx, string sord)
        {
            try
            {
                if (string.IsNullOrEmpty(sidx) || string.IsNullOrEmpty(sord))
                {
                    sord = "";
                    sidx = "";
                }

                var CaseType = "";
                switch (ProcessTypeId)
                {
                    case "00280001":
                        CaseType = "JY"; //简易 ： 简易+违停
                        break;
                    case "00280002":     //一般  ：一般+重大
                        ProcessTypeId = "00280002'',''00280003";
                        CaseType = "YB";
                        break;
                    default:             //所有 ： 简易+一般+ 重大+违停
                        CaseType = "All";
                        break;
                }
                var strSql = string.Format("EXEC Report_CaseDetails @StartTime='{0}',@EndTime='{1}',@ProcessTypeId='{2}',@CaseType='{3}',@CaseState='{4}',@DepId='{5}',@ClassNo='{6}',@TargetType='{7}', @Sidx='{8}',@Sord='{9}',@Keywords='{10}'", startTime, endTime, ProcessTypeId, CaseType, State, deptid, ClassNo, targetType, sidx, sord, keywords);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        #region 用于计算年度统计

        /// <summary>
        /// 年度停违数（注：只查含有通知书编号的案件）
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-08-21 周 鹏 修改计算方式
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable. Columns-> DeptId:部门ID MM:月份 CarCount:违停数量</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseCountDistinctNotice(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");

                strSql.AppendFormat(@"SELECT DeptId,SUM(CaseCount) AS CaseCount FROM (
SELECT DeptId,COUNT(Id) AS CaseCount FROM INF_PUNISH_CASEINFO WHERE NoticeNo<>'' AND RowStatus=1 AND CreateOn>='{0}' AND CreateOn<='{1} 23:59:59'
GROUP BY DeptId
UNION ALL
SELECT DeptId,COUNT(Id) AS CaseCount FROM INF_CAR_CHECKSIGN WHERE NoticeNo<>'' AND RowStatus=1 AND CreateOn>='{0}' AND CreateOn<='{1} 23:59:59'
GROUP BY DeptId) AS TB 
GROUP BY TB.DeptId", startTime, endTime);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 年度案件罚款案件量及金额汇总
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-08-21 周 鹏 修改计算方式
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable. Columns-> DeptId:部门ID MM:月份 HandleMoney:罚款金额</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseHandle(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TB.DeptId,SUM(CaseCount) AS CaseCount,SUM(HandleMoney) AS HandleMoney FROM (
SELECT DeptId,COUNT(Id) AS CaseCount,CONVERT(INT,SUM([Money])) AS HandleMoney FROM INF_CAR_CHECKSIGN WHERE [State]=511 AND CbrDate>='{0}' AND CbrDate<='{1} 23:59:59'
GROUP BY DeptId
UNION ALL
SELECT IPC.DeptId,COUNT(IPC.Id) AS CaseCount,SUM(IPL.PunishAmount) AS HandleMoney FROM INF_PUNISH_CASEINFO AS IPC
JOIN INF_PUNISH_LEGISLATION AS IPL ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD ON IPC.Id=IPD.CaseInfoId
WHERE IPC.RowStatus=1 AND IPD.RowStatus=1 AND IPL.RowStatus=1 AND IPD.FileDate>='{0}' AND IPD.FileDate<='{1} 23:59:59'
GROUP BY IPC.DeptId) AS TB
GROUP BY TB.DeptId", startTime, endTime);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 统计2015年1至4月的案件汇总信息
        /// 添加人：周 鹏
        /// 添加时间：2015-08-18
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable OldYearReportTotal()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT SUM([Ed_00090001]) [Ed_00090001]
,SUM([Ed_00090002]) [Ed_00090002]
,SUM([Ed_00090003]) [Ed_00090003]
,SUM([Ed_00090004]) [Ed_00090004]
,SUM([Ed_00090005]) [Ed_00090005]
,SUM([Ed_00090006]) [Ed_00090006]
,SUM([Ed_00090007]) [Ed_00090007]
,SUM([Ed_00090008]) [Ed_00090008]
,SUM([Ed_TotalCount]) [Ed_TotalCount]
,SUM([Case_00090001]) [Case_00090001]
,SUM([Case_00090002]) [Case_00090002]
,SUM([Case_00090003]) [Case_00090003]
,SUM([Case_00090004]) [Case_00090004]
,SUM([Case_00090005]) [Case_00090005]
,SUM([Case_00090006]) [Case_00090006]
,SUM([Case_00090007]) [Case_00090007]
,SUM([Case_00090008]) [Case_00090008]
,SUM([Case_TotalCount]) [Case_TotalCount]
,SUM([Case_00090001_Money]) [Case_00090001_Money]
,SUM([Case_00090002_Money]) [Case_00090002_Money]
,SUM([Case_00090003_Money]) [Case_00090003_Money]
,SUM([Case_00090004_Money]) [Case_00090004_Money]
,SUM([Case_00090005_Money]) [Case_00090005_Money]
,SUM([Case_00090006_Money]) [Case_00090006_Money]
,SUM([Case_00090007_Money]) [Case_00090007_Money]
,SUM([Case_00090008_Money]) [Case_00090008_Money]
,SUM([Case_TotalMoney]) [Case_TotalMoney]
,SUM([Case_Punish]) [Case_Punish]
,SUM([Case_PunishMoney]) [Case_PunishMoney]
,SUM([Case_Simple]) [Case_Simple]
,SUM([Case_SimpleMoney]) [Case_SimpleMoney]
  FROM [dbo].[OldMonthReportTotal]");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取月的记录老数据
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public DataTable OldYearReportTotal(string month)
        {
            if (string.IsNullOrEmpty(month))
            {
                return new DataTable();
            }
            var strSql = new StringBuilder("");
            strSql.AppendFormat("select *from OldMonthReportTotal where ReportDate='{0}'", month);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }



        #endregion

        #region 用于计算案件分类汇总

        /// <summary>
        /// 案件的处理量汇总【案件分类汇总】
        /// 添加人：周 鹏
        /// 添加时间：2015-05-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable CaseCatalogSumary(string companyId, string caseType, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                if (caseType == "00280001")
                {
                    strSql.AppendFormat(@"
SELECT TB.ItemNo,TB.ItemName,COUNT(ItemNo) AS CT,SUM(CFMoney) AS CFMoney FROM (
SELECT IPL.ItemNo,IPL.ItemName,IPL.PunishAmount AS CFMoney,IPC.CreateOn AS CaseDate,IPD.FileDate AS HandleDate,IPC.CompanyId FROM dbo.INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId 
WHERE IPC.RowStatus=1 AND IPL.RowStatus=1 AND IPD.RowStatus=1 AND IPC.PunishProcess='{0}' ", caseType);
                    strSql.AppendFormat(@"
UNION ALL
SELECT '8002' AS ItemNo,'不按照规定在城市人行道上停放机动车的' AS ItemName, CONVERT(INT,[Money]) AS CFMoney ,ICC.CreateOn AS CaseDate,CbrDate AS HandleDate,CC.CompanyId FROM INF_CAR_CHECKSIGN AS ICC LEFT JOIN CrmDepartment AS CC ON CC.Id=ICC.DeptId WHERE [State]=511 AND ICC.RowStatus=1 ) AS TB
WHERE TB.HandleDate>='{0}' AND TB.HandleDate<='{1} 23:59:59'", startTime, endTime);
                }
                else if (caseType == "00280002")
                {
                    strSql.AppendFormat(@"
SELECT TB.ItemNo,TB.ItemName,COUNT(ItemNo) AS CT,SUM(CFMoney) AS CFMoney FROM (
SELECT IPL.ItemNo,IPL.ItemName,IPL.PunishAmount AS CFMoney,IPC.CreateOn AS CaseDate,IPD.FileDate AS HandleDate,IPC.CompanyId FROM dbo.INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId 
WHERE IPC.RowStatus=1 AND IPL.RowStatus=1 AND IPD.RowStatus=1 AND IPC.PunishProcess='{0}') AS TB
WHERE TB.HandleDate>='{1}' AND TB.HandleDate<='{2} 23:59:59'", caseType, startTime, endTime);
                }
                else
                {
                    strSql.AppendFormat(@"
SELECT TB.ItemNo,TB.ItemName,COUNT(ItemNo) AS CT,SUM(CFMoney) AS CFMoney FROM (
SELECT IPL.ItemNo,IPL.ItemName,IPL.PunishAmount AS CFMoney,IPC.CreateOn AS CaseDate,IPD.FileDate AS HandleDate,IPC.CompanyId FROM dbo.INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId 
WHERE IPC.RowStatus=1 AND IPL.RowStatus=1 AND IPD.RowStatus=1
UNION ALL
SELECT '8002' AS ItemNo,'不按照规定在城市人行道上停放机动车的' AS ItemName, CONVERT(INT,[Money]) AS CFMoney ,ICC.CreateOn AS CaseDate,CbrDate AS HandleDate,CC.CompanyId FROM INF_CAR_CHECKSIGN AS ICC LEFT JOIN CrmDepartment AS CC ON CC.Id=ICC.DeptId WHERE [State]=511 AND ICC.RowStatus=1 ) AS TB
WHERE TB.HandleDate>='{0}' AND TB.HandleDate<='{1} 23:59:59'", startTime, endTime);
                }

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(" AND TB.CompanyId='{0}'", companyId);
                }
                strSql.Append(" GROUP BY TB.ItemNo,TB.ItemName ORDER BY TB.ItemNo");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 统计2015年1至7月的案件汇总信息
        /// 添加人：周 鹏
        /// 添加时间：2015-08-18
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable OldCatalogSumaryTotal()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM OldCatalogSumaryTotal");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #endregion

        #region 用于计算执法月报

        /// <summary>
        /// 根据案件类型（八大类）统计案件处理情况
        /// 添加人：周 鹏
        /// 添加时间：2015-05-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns->ClassNo 八大类, CaseCount 案件量, CFMoney 处罚金额</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable CaseHandleInfo(string companyId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT ClassNo,SUM(CaseCount) AS CaseCount,SUM(CFMoney) AS CFMoney FROM (SELECT ClassNo,COUNT(*) AS CaseCount,ISNULL(SUM(IPL.PunishAmount),0) AS CFMoney FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId
WHERE IPD.FileDate>='{0}' AND IPD.FileDate<'{1} 23:59:59' AND IPC.RowStatus=1 AND IPD.RowStatus=1 AND IPL.RowStatus=1 ", startTime, endTime);

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND IPC.CompanyId='{0}'", companyId);
                }
                strSql.AppendFormat(@"
GROUP BY ClassNo
UNION ALL
SELECT '00090005' AS ClassNo,COUNT(*) AS CaseCount,ISNULL(SUM(CONVERT(INT,[Money])),0) AS CFMoney FROM dbo.INF_CAR_CHECKSIGN AS ICC LEFT JOIN CrmDepartment AS CD ON CD.Id=ICC.DeptId WHERE CbrDate>='{0}' AND CbrDate<='{1} 23:59:59' AND State=511 AND ICC.RowStatus=1 ", startTime, endTime);

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND CD.CompanyId='{0}'", companyId);
                }
                strSql.Append(" ) AS TB GROUP BY TB.ClassNo");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据案件类型（简易、一般）统计案件处理情况
        /// 添加人：周 鹏
        /// 添加时间：2015-05-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns->ClassNo 八大类, CaseCount 案件量, CFMoney 处罚金额</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable CaseHandleInfoByPunishProcess(string companyId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT PunishProcess,SUM(CaseCount) AS CaseCount,SUM(CFMoney) AS CFMoney FROM (SELECT IPC.PunishProcess,COUNT(*) AS CaseCount,ISNULL(SUM(IPL.PunishAmount),0) AS CFMoney FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId
WHERE IPD.FileDate>='{0}' AND IPD.FileDate<'{1} 23:59:59' AND IPC.RowStatus=1 AND IPD.RowStatus=1 AND IPL.RowStatus=1 ", startTime, endTime);

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND IPC.CompanyId='{0}'", companyId);
                }
                strSql.AppendFormat(@"
GROUP BY IPC.PunishProcess
UNION ALL
SELECT '00280001' AS PunishProcess,COUNT(*) AS CaseCount,ISNULL(SUM(CONVERT(INT,[Money])),0) AS CFMoney FROM INF_CAR_CHECKSIGN AS ICC LEFT JOIN CrmDepartment AS CD ON CD.Id=ICC.DeptId WHERE CbrDate>='{0}' AND CbrDate<='{1} 23:59:59' AND State=511 AND ICC.RowStatus=1 ", startTime, endTime);

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat("AND CD.CompanyId='{0}'", companyId);
                }
                strSql.Append(" ) AS TB GROUP BY TB.PunishProcess");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 教育纠处案件
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns->ClassNo 八大类, Number 案件量</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable CaseEducation(string companyId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT CR.Id AS ClassNo, COUNT(*) AS Number FROM Education
LEFT JOIN CrmDepartment AS CD ON CD.Id=Education.DepartmentId
LEFT JOIN Legislation ON Education.LegislationId=Legislation.Id
LEFT JOIN dbo.ComResource AS CR ON Legislation.ClassNo=CR.Id 
WHERE CR.ParentId='0009' AND Education.EducationTime>='{0}' AND Education.EducationTime<='{1} 23:59:59'", startTime, endTime);

                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(" AND CD.CompanyId='{0}'", companyId);
                }

                strSql.AppendFormat("GROUP BY CR.Id");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 统计拆除违章建筑和户外广告
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="typeNo">数据类型：2 违法建筑 3 户外广告</param>
        /// <returns>DataTable Columns->Number 数量 Area 面积</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable DismantleAdAndBd(string startTime, string endTime, int typeNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT ISNULL(SUM(Number),0) AS Number,ISNULL(SUM(Area),0) AS Area FROM INF_CASE_COLLECT AS ICC
WHERE TypeNo={0} AND ICC.ReportingPeriod>'{1}' AND ICC.ReportingPeriod<'{2} 23:59:59'", typeNo, startTime, endTime);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 统计2015年1至7月的案件汇总信息
        /// 添加人：周 鹏
        /// 添加时间：2015-08-18
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable OldMonthReportTotal()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM OldMonthReportTotal");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region 违法停车单项统计

        /// <summary>
        /// 违法停车统计
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetCarReport(string companyId, string deptId, string startTime, string endTime)
        {
            var strSql = new StringBuilder();
            if (companyId == "all")
            {
                strSql.AppendFormat("EXEC Report_Car @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
            }
            if (companyId != "all" && deptId == "all")
            {
                strSql.AppendFormat("EXEC Report_CarByDept @CompanyId='{0}',@StartTime='{1}',@EndTime='{2}'", companyId, startTime, endTime);
            }
            if (companyId != "all" && deptId != "all")
            {
                strSql.AppendFormat("EXEC Report_CarByUser @CompanyId='{0}',@DeptId='{1}',@StartTime='{2}',@EndTime='{3}'", companyId, deptId, startTime, endTime);
            }
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        #endregion


        #region 行政执法数据统计分析

        /// <summary>
        /// 行政执法案件处理情况（城管+国土）
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public DataTable CaseCatalogDay(string startTime, string endTime)
        {
            var sbSql = string.Format(@"SELECT COUNT(*) AS CaseCount,ISNULL(SUM(IPL.PunishAmount),0) AS CFMoney FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
JOIN INF_PUNISH_DECISION AS IPD WITH(NOLOCK) ON IPC.Id=IPD.CaseInfoId
WHERE IPD.FileDate>='{0}' AND IPD.FileDate<'{1}' AND IPC.RowStatus=1 AND IPD.RowStatus=1 AND IPL.RowStatus=1 ", startTime, endTime);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).Tables[0];
        }

        /// <summary>
        /// 获取案件总量（城管+国土）
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetCaseCount(string startTime, string endTime)
        {
            var sbSql = string.Format(@"SELECT COUNT(*) AS Total FROM INF_PUNISH_CASEINFO AS IPC WHERE RowStatus=1 AND CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999'", startTime, endTime);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).ToString());
        }

        /// <summary>
        /// 获取违法停车量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetCarCount(string startTime, string endTime)
        {
            var sbSql =
                string.Format(
                    @"SELECT COUNT(*) AS Total FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999'", startTime, endTime);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).ToString());
        }

        /// <summary>
        /// 获取教育纠处量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetEducationCount(string startTime, string endTime)
        {
            var sbSql =
                string.Format(
                    @"SELECT COUNT(*) AS Total FROM Education AS IPC WHERE RowStatus=1 AND CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999'", startTime, endTime);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).ToString());
        }



        


        #endregion

    }
}
