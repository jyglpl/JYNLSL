using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Report
{
    /// <summary>
    /// 案件分析
    /// </summary>
    public class CaseAnalysisDal
    {
        /// <summary>
        /// 按八大类统计案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-11 周 鹏 增加按类型查询明细
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="classNo">类型编号</param>
        /// <returns>DataTable Columns-> ClassNo 类型编号 Total 案件量</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseTotalByClasses(string startTime, string endTime, string classNo, string caseType)
        {
            try
            {
                var strSql = new StringBuilder("");

                if (string.IsNullOrEmpty(classNo))
                {
                    if (string.IsNullOrEmpty(caseType))
                    {
                        strSql.AppendFormat(@"SELECT CR.RsKey AS ClassName,ISNULL(SUM(TB.CT),0) AS Total FROM (
SELECT IPL.ClassNo,COUNT(IPC.Id) AS CT FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
WHERE IPC.RowStatus=1 AND IPC.CreateOn>='{0}' AND IPC.CreateOn<'{1} 23:59:59.999'
GROUP BY IPL.ClassNo
UNION ALL
SELECT '00090005' AS ClassNo,COUNT(*) AS CT FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0
UNION ALL
SELECT '00090005' AS ClassNo,COUNT(*) AS CT FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999') AS TB
RIGHT JOIN ComResource AS CR ON CR.Id=TB.ClassNo
WHERE CR.ParentId='0009' AND CR.RowStatus=1
GROUP BY CR.RsKey", startTime, endTime);
                    }
                    if (caseType == "00280001")
                    {
                        strSql.AppendFormat(@"SELECT CR.RsKey AS ClassName,ISNULL(SUM(TB.CT),0) AS Total FROM (
SELECT IPL.ClassNo,COUNT(IPC.Id) AS CT FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
WHERE IPC.RowStatus=1 AND IPC.CreateOn>='{0}' AND IPC.CreateOn<'{1} 23:59:59.999' AND IPC.PunishProcess='{2}'
GROUP BY IPL.ClassNo
UNION ALL
SELECT '00090005' AS ClassNo,COUNT(*) AS CT FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0
UNION ALL
SELECT '00090005' AS ClassNo,COUNT(*) AS CT FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999') AS TB
RIGHT JOIN ComResource AS CR ON CR.Id=TB.ClassNo
WHERE CR.ParentId='0009' AND CR.RowStatus=1
GROUP BY CR.RsKey", startTime, endTime, caseType);
                    }
                    if (caseType == "00280002")
                    {
                        strSql.AppendFormat(@"SELECT CR.RsKey AS ClassName,ISNULL(SUM(TB.CT),0) AS Total FROM (
SELECT IPL.ClassNo,COUNT(IPC.Id) AS CT FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
WHERE IPC.RowStatus=1 AND IPC.CreateOn>='{0}' AND IPC.CreateOn<'{1} 23:59:59.999' AND IPC.PunishProcess='{2}'
GROUP BY IPL.ClassNo) AS TB
RIGHT JOIN ComResource AS CR ON CR.Id=TB.ClassNo
WHERE CR.ParentId='0009' AND CR.RowStatus=1
GROUP BY CR.RsKey", startTime, endTime, caseType);
                    }
                }
                else
                {
                    strSql.AppendFormat("EXEC [Report_Classes] '{0}','{1}','{2}','{3}'", classNo, caseType, startTime, endTime);
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按案件类别统计
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns-> CaseType 类型名称 Total 案件量</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseTotalByClassify(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC Report_Classify '{0}','{1}'", startTime, endTime);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按中队统计案件
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetCaseTotalByDept(string companyId, string deptId, string startTime, string endTime, string reportType = "Total")
        {
            try
            {
                var strSql = new StringBuilder("");

                if (reportType.Equals("Total"))
                {
                    var strWhere = new StringBuilder("");

                    //按单位统计
                    if (!string.IsNullOrEmpty(companyId) && companyId.Equals("all"))
                    {
                        strSql.AppendFormat(@"SELECT CC.FullName AS DeptName,ISNULL(SUM(TB.CT),0) AS Total FROM (
SELECT DeptId,COUNT(IPC.Id) AS CT FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
WHERE IPC.RowStatus=1 AND IPC.CreateOn>='{0}' AND IPC.CreateOn<'{1} 23:59:59.999'
GROUP BY DeptId
UNION ALL
SELECT DeptId,COUNT(*) AS CT FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0 GROUP BY DeptId
UNION ALL
SELECT DeptId,COUNT(*) AS CT FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY DeptId
UNION ALL
SELECT E.DepartmentId AS DeptId,COUNT(E.Id) AS Total FROM Education AS E WITH(NOLOCK)
WHERE E.RowStatus=1 AND E.CreateOn>='{0}' AND E.CreateOn<'{1} 23:59:59.999' GROUP BY E.DepartmentId
UNION ALL
SELECT TD.DepartmentId AS DeptId,COUNT(TD.Id) AS Total FROM TempDetainInfo AS TD WITH(NOLOCK)
WHERE TD.RowStatus=1 AND TD.CreateOn>='{0}' AND TD.CreateOn<'{1} 23:59:59.999' GROUP BY TD.DepartmentId ) AS TB
RIGHT JOIN CrmDepartment AS BD ON BD.Id=TB.DeptId
RIGHT JOIN CrmCompany AS CC ON BD.CompanyId=CC.Id
WHERE 1=1 AND BD.RowStatus=1 AND CC.RowStatus=1 AND CC.Enforcement=1
GROUP BY CC.FullName,CC.SortCode
ORDER BY CC.SortCode", startTime, endTime);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(companyId) && !string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
                        {
                            strWhere.AppendFormat(" AND BD.Id='{0}'", deptId);
                        }

                        strSql.AppendFormat(@"SELECT BD.FullName AS DeptName,ISNULL(SUM(TB.CT),0) AS Total FROM (
SELECT DeptId,COUNT(IPC.Id) AS CT FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CaseInfoId
WHERE IPC.RowStatus=1 AND IPC.CreateOn>='{0}' AND IPC.CreateOn<'{1} 23:59:59.999'
GROUP BY DeptId
UNION ALL
SELECT DeptId,COUNT(*) AS CT FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0 GROUP BY DeptId
UNION ALL
SELECT DeptId,COUNT(*) AS CT FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY DeptId
UNION ALL
SELECT E.DepartmentId AS DeptId,COUNT(E.Id) AS Total FROM Education AS E WITH(NOLOCK)
WHERE E.RowStatus=1 AND E.CreateOn>='{0}' AND E.CreateOn<'{1} 23:59:59.999' GROUP BY E.DepartmentId
UNION ALL
SELECT TD.DepartmentId AS DeptId,COUNT(TD.Id) AS Total FROM TempDetainInfo AS TD WITH(NOLOCK)
WHERE TD.RowStatus=1 AND TD.CreateOn>='{0}' AND TD.CreateOn<'{1} 23:59:59.999' GROUP BY TD.DepartmentId ) AS TB
RIGHT JOIN CrmDepartment AS BD ON BD.Id=TB.DeptId
WHERE BD.CompanyId='{2}' {3} AND BD.RowStatus=1
GROUP BY BD.FullName,BD.SortCode
ORDER BY BD.SortCode", startTime, endTime, companyId, strWhere);

                    }
                }
                else if (reportType.Equals("Classify"))   //按类型
                {
                    //按分类查询数据源
                    strSql.AppendFormat("EXEC Report_Department @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
                }
                else if (reportType.Equals("Legislation"))   //按八大类
                {
                    strSql.AppendFormat(@"EXEC [Report_DeptLeg] @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按日期统计每月的案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>DataTable</returns>
        public DataTable GetCaseTotalByDate(string startTime, string endTime, string reportType = "Total")
        {
            try
            {
                var strSql = new StringBuilder("");
                if (reportType.Equals("Total"))
                {
                    strSql.AppendFormat(@"SELECT TB.CaseDate,SUM(Total) AS Total FROM (
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate, COUNT(*) AS Total FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0 GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
UNION ALL
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate, COUNT(*) AS Total FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
UNION ALL
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate,COUNT(*) AS Total FROM INF_PUNISH_CASEINFO AS IPC WHERE RowStatus=1 AND CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
UNION ALL
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate,COUNT(*) AS Total FROM Education AS IPC WHERE RowStatus=1 AND CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
UNION ALL
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate,COUNT(*) AS Total FROM TempDetainInfo AS IPC WHERE RowStatus=1 AND CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
) AS TB
GROUP BY TB.CaseDate", startTime, endTime);
                }
                else
                {
                    strSql.AppendFormat("EXEC Report_Date @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按处理情况查询统计
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="caseType">案件类型</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseTotalByHandle(string startTime, string endTime, string caseType)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC [Report_Handle] @StartTime='{0}',@EndTime='{1}',@CaseType='{2}'", startTime, endTime, caseType);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按案件阶段查询案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseTotalByStage(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC [Report_Stage] @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 按城市顽疾分类统计
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCaseTotalByCityIlls(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("EXEC [Report_CityIlls] @StartTime='{0}',@EndTime='{1}'", startTime, endTime);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按时间区间统计每个月的违法停车案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetCarTotalByDate(string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT CaseDate,SUM(Total) AS Total FROM (
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate, COUNT(*) AS Total FROM INF_CAR_CHECKSIGNMIDDLE AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' AND [State]=0 GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)
UNION ALL
SELECT CONVERT(VARCHAR(7),IPC.CreateOn,23) AS CaseDate,COUNT(*) AS Total FROM INF_CAR_CHECKSIGN AS IPC WHERE CreateOn>='{0}' AND CreateOn<'{1} 23:59:59.999' GROUP BY CONVERT(VARCHAR(7),IPC.CreateOn,23)) AS TB GROUP BY CaseDate", startTime, endTime);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
