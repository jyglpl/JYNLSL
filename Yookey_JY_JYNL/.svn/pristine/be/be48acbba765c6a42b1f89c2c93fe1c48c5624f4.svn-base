using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.GridManagement
{
    public class GridManagementDal : BaseDal<GridManagementInfoEntity>
    {
        /// <summary>
        /// 查询文件 数据库访问操作
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DataTable GetGridManagementByCompanyId(string companyId)
        {
            var strSql = string.Format(@"SELECT * FROM [GridManagementFileInfo] WITH(NOLOCK) WHERE RowStatus=1 AND CompanyId='" + companyId + "'");
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt;
        }


        /// <summary>
        /// 根据单位ID获取单位的最新上传的情况
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <returns>Columns-> DeptId：部门ID DeptName：部门名称 NewTime：最新上传时间</returns>
        public DataTable GetCompanyNewUploadInfo(string companyId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP 2 DeptId,
(SELECT ShortName FROM CrmDepartment WHERE CompanyId='{0}' AND RowStatus=1 AND IsLedger=1 AND Id=DeptId) AS DeptName,
CONVERT(NVARCHAR(50),MAX(Create_On),20) AS NewTime FROM GridManagementFileInfo WITH(NOLOCK)
WHERE RowStatus=1 AND CompanyId='{0}' GROUP BY DeptId
ORDER BY NewTime DESC", companyId);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据单位ID获取单位上传的文件总数
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public int GetCompanyUpLoadCount(string companyId)
        {
            try
            {

                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT COUNT(*) AS UpCount FROM GridManagementFileInfo WITH(NOLOCK) WHERE RowStatus=1 AND CompanyId='{0}'", companyId);

                return int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取所有单位信息和已上传的情况
        /// </summary>
        /// <returns>Columns-> Id：单位ID FullName：单位全称 ShortName：单位简称 UpCount：已上传数</returns>
        public DataTable GetCompanys()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT Id,FullName,ShortName,
(SELECT COUNT(*) AS UpCount FROM GridManagementFileInfo WHERE RowStatus=1 AND CompanyId=CrmCompany.Id) AS UpCount
FROM CrmCompany WHERE RowStatus=1 AND IsLedger=1
ORDER BY SortCode");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查询网格化设置
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<GridManagementInfoEntity> GetSearchResult(GridManagementInfoEntity search, params Expression<Func<GridManagementInfoEntity, object>>[] expressions)
        {
            var sbWhere = new StringBuilder("");

            sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>("Where {0}=1", t => t.ROWSTATUS));
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>(" AND {0}=@ParentId ", t => t.ParentId));
                args.Add(new { ParentId = search.ParentId });
            }
            else
            {
                sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>(" AND {0}=@ParentId ", t => t.ParentId));
                args.Add(new { ParentId = "" });
            }

            if (!string.IsNullOrEmpty(search.CompanyId) && !string.IsNullOrEmpty(search.DeptId))
            {
                sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>(" AND ({0}='' OR {0}=@CompanyId", t => t.CompanyId));
                args.Add(new { CompanyId = search.CompanyId });

                sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>(" OR {0}=@DeptId)", t => t.DeptId));
                args.Add(new { DeptId = search.DeptId });
            }


            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<GridManagementInfoEntity>(" AND {0}=@Id ", t => t.ID));
                args.Add(new { Id = search.ID });
            }


            sbWhere.Append(" ORDER BY SortCode");
            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "周鹏",
                FileName = "GridManagementDal.cs",
                ForUse = "查询网格化文件夹设置",
                FunName = "GetSearchResult"
            };
            return ReadDatabase.QueryExtend(sbWhere.ToString(), args.ToArray(), expressions).ToList();
        }


        /// <summary>
        /// 查询网格化设置
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<GridManagementInfoEntity> GetSearchResult(GridManagementInfoEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM (
SELECT * FROM GridManagementInfo Where RowStatus=1 AND ParentId='{0}' AND CompanyId='' AND GMType='{1}'
UNION ALL
SELECT * FROM GridManagementInfo Where RowStatus=1 AND ParentId='{0}' AND GMType='{1}' AND CompanyId='{2}' AND DeptId=''
UNION ALL
SELECT * FROM GridManagementInfo Where RowStatus=1 AND ParentId='{0}' AND GMType='{1}' AND CompanyId='{2}' AND DeptId='{3}') AS TB
ORDER BY TB.SortCode", search.ParentId, search.GMType, search.CompanyId, search.DeptId);

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "周鹏",
                FileName = "GridManagementDal.cs",
                ForUse = "查询网格化文件夹设置",
                FunName = "GetSearchResult"
            };
            var list = ReadDatabase.QueryExtend(strSql.ToString());
            return list != null && list.Tables.Count > 0 ? ConvertListHelper<GridManagementInfoEntity>.ConvertToList(list.Tables[0]) : new List<GridManagementInfoEntity>();
        }

        /// <summary>
        /// 根据父编号获取文件夹子集数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ChildCount(string id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT COUNT(*) FROM GridManagementInfo Where RowStatus=1 AND ParentId='{0}'", id);
                return int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"UPDATE GridManagementInfo SET RowStatus=0 Where Id='{0}'", id);
                WriteDatabase.Comment = new StringExtension.SqlComment
                {
                    Author = "周鹏",
                    FileName = "GridManagementDal.cs",
                    ForUse = "删除",
                    FunName = "Delete"
                };
                return WriteDatabase.Execute(strSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
