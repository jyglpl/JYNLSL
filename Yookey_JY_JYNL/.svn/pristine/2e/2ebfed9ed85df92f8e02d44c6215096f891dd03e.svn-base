using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.PenaltyCaseSafty
{
    public class EnterpriseDal
    {
        /// <summary>
        /// 请求企业信息列表
        /// </summary>
        /// <param name="companyName">企业名称</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryEnterpriseList(string companyName, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_QYZCXX WHERE 1 = 1");
                if (!string.IsNullOrEmpty(companyName))
                {
                    strSql.AppendFormat(" AND 企业名称 LIKE '%{0}%'", companyName);
                }
                var sortField = "企业名称";
                var sortType = "ASC";
                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询所有企业列表
        /// </summary>
        /// <returns></returns>
        public DataTable QueryEnterpriseList()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM VIEW_QYZCXX WHERE 1 = 1");

                return SqlHelper.QueryBySql(SqlHelper.SqlConnStringRead, strSql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取企业详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetEnterpriseDetail(string CompanyName)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT * FROM VIEW_QYZCXX WHERE 1=1 AND 企业名称 = '{0}'", CompanyName);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region 统计分析数据


        /// <summary>
        /// 查询所属区镇企业数
        /// </summary>
        /// <returns></returns>
        public DataTable QueryEnterpriseListForAnalysis()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select 所属区镇,count(所属区镇) CT from [dbo].[VIEW_QYZCXX]
where 所属区镇 is not null
group by 所属区镇
order by count(所属区镇) desc");

                return SqlHelper.QueryBySql(SqlHelper.SqlConnStringRead, strSql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion
    }
}
