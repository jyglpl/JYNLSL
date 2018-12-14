using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.GridManagement
{
  public  class GridManagementFileScoreInfoDal : BaseDal<GridManagementInfoEntity>
    {
        /// <summary>
        /// 查询各个区域扣分情况
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param>
        /// <returns></returns>
        public DataTable GetData(int year, int quarter)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT CC.Id,CC.ShortName AS CompanyName, ABS(ISNULL(TB.Score,0)) AS Score FROM CrmCompany AS CC WITH(NOLOCK)
LEFT JOIN (SELECT CompanyId,SUM(FileScore) AS Score FROM GridManagementFileScoreInfo WHERE RowStatus=1 AND GradeYear={0} AND GradeQuarter={1} 
GROUP BY CompanyId) AS TB ON CC.Id=TB.CompanyId
WHERE CC.RowStatus=1 AND CC.IsLedger=1 ORDER BY SortCode", year, quarter);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询各个网格扣分情况
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param>
        /// <returns></returns>
        public DataTable GetGmData(int year, int quarter)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT GMI.GMName, ISNULL(TB.Score, 0) AS Score
FROM GridManagementInfo AS GMI 
LEFT JOIN (SELECT GMI.ParentId, SUM(TB.Score) AS Score
		   FROM GridManagementInfo GMI
			INNER JOIN (
				SELECT GMId, ABS(SUM(FileScore)) AS Score
				FROM GridManagementFileScoreInfo
				WHERE GMId IS NOT NULL AND GradeYear={0} AND GradeQuarter={1} GROUP BY GMId
			) TB ON GMI.Id = TB.GMId WHERE GMI.GMType=0
			GROUP BY GMI.ParentId) AS TB ON TB.ParentId=GMI.Id
WHERE GMI.RowStatus = 1	
AND GMI.GMType=0 AND GMI.CompanyId = '' AND GMI.DeptId = '' AND GMI.ParentId = ''", year, quarter);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 扣分内容TOP10
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param> 
        /// <returns></returns>
        public DataTable GetContentTop(int year, int quarter)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP 10 GMI.ParentId, GMI.GMName, TB.GMId, TB.Score FROM GridManagementInfo GMI
INNER JOIN (SELECT GMId, ABS(SUM(FileScore)) AS Score FROM GridManagementFileScoreInfo WHERE GMId IS NOT NULL AND GradeYear={0} AND GradeQuarter={1} GROUP BY GMId ) TB ON GMI.Id = TB.GMId 
ORDER BY  TB.Score DESC", year, quarter);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询扣分详情TOP10数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(int year, int month)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP 10 GFS.Id,COM.ShortName AS CompanyName ,DEP.ShortName AS DeptName ,GFS.CreateBy ,GFS.UpdateOn ,GFS.FileScore AS Score,GMF.GMFileName,
GMF.FileUrl,GMF.ConvertFileUrl
FROM GridManagementFileScoreInfo AS GFS 
LEFT JOIN CrmCompany AS COM ON COM.Id = GFS.CompanyId 
LEFT JOIN CrmDepartment AS DEP  ON DEP.Id =GFS.DeptId  
LEFT JOIN GridManagementFileInfo AS GMF ON GMF.Id=GFS.GMFileInfoId
WHERE GFS.RowStatus=1 AND GFS.GradeYear={0} AND GFS.GradeQuarter={1}
ORDER BY GFS.UpdateOn DESC ", year, month);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取已扣分的年度
        /// </summary>
        /// <returns></returns>
        public DataTable GetYears()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT GradeYear FROM [GridManagementFileScoreInfo] GROUP BY GradeYear ORDER BY GradeYear DESC");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据年份获取已扣分的季度
        /// </summary>
        /// <returns></returns>
        public DataTable GetQuarters(int year)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT GradeQuarter FROM [GridManagementFileScoreInfo] WHERE GradeYear={0} GROUP BY GradeQuarter ORDER BY GradeQuarter DESC",
                    year);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查询扣分详情列表
        /// </summary>
        /// <param name="year">所属年份</param>
        /// <param name="month">所属季度</param>
        /// <param name="keywords">查询关键字</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetGradeData(int year, int month, string keywords, int pageIndex, int pageSize)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT GFS.Id,COM.ShortName AS CompanyName ,DEP.ShortName AS DeptName,GFS.CreateBy ,GFS.UpdateOn ,GFS.FileScore AS Score,GMF.GMFileName,
GMF.FileUrl,GMF.ConvertFileUrl
FROM GridManagementFileScoreInfo AS GFS 
LEFT JOIN CrmCompany AS COM ON COM.Id = GFS.CompanyId 
LEFT JOIN CrmDepartment AS DEP ON DEP.Id =GFS.DeptId  
LEFT JOIN GridManagementFileInfo AS GMF ON GMF.Id=GFS.GMFileInfoId
WHERE GFS.RowStatus=1 AND GFS.GradeYear={0} AND GFS.GradeQuarter={1} ", year, month);

                if (!string.IsNullOrEmpty(keywords))
                {
                    strSql.AppendFormat(@"AND GMF.GMFileName LIKE '%{0}%'", keywords);
                }

                int totalRecords;
                var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "UpdateOn", "DESC", pageIndex, pageSize, out totalRecords);

                var page = new PageJqDatagrid<DataTable>()
                {
                    page = pageIndex,
                    PageSize = pageSize,
                    total = (totalRecords + pageSize - 1) / pageSize,
                    records = totalRecords,
                    rows = data
                };
                return page;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
