using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.GridManagement
{
    public class GridManagementFileInfoDal : BaseDal<GridManagementFileInfoEntity>
    {
        /// <summary>
        /// 台账管理数据信息查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<GridManagementFileInfoEntity> GetSearchResult(GridManagementFileInfoEntity search)
        {
            var sbSql = new StringBuilder();
            sbSql.Append(@"SELECT CD.FullName AS DepartmentName,GMF.* FROM GridManagementFileInfo AS GMF
LEFT JOIN CrmDepartment AS CD ON GMF.DeptId=CD.Id
LEFT JOIN CrmCompany AS CC ON GMF.CompanyId=CC.Id WHERE GMF.RowStatus=1");

            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                sbSql.AppendFormat(@" AND GMF.CompanyId='{0}'", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DeptId))
            {
                sbSql.AppendFormat(@" AND GMF.DeptId='{0}'", search.DeptId);
            }
            if (!string.IsNullOrEmpty(search.GmId))
            {
                sbSql.AppendFormat(@" AND GMF.GMId='{0}'", search.GmId);
            }

            int totalRecords;
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "Create_On", "DESC", search.page.CurrentPage, search.page.PageSize, out totalRecords);

            var list = ConvertListHelper<GridManagementFileInfoEntity>.ConvertToList(data);   //将DT转成集合类型
            var page = new PageJqDatagrid<GridManagementFileInfoEntity>()
            {
                page = search.page.CurrentPage,
                PageSize = search.page.PageSize,
                total = (totalRecords + search.page.PageSize - 1) / search.page.PageSize,
                records = totalRecords,
                rows = list
            };
            return page;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">数据集</param>
        /// <returns></returns>
        public bool BatchDeleteFiles(List<string> list)
        {
            BeginTransaction();
            try
            {
                foreach (var id in list)
                {
                    var sbSql = new StringBuilder();
                    sbSql.AppendFormat(@"UPDATE GridManagementFileInfo SET RowStatus=0 WHERE Id='{0}'", id);

                    WriteDatabase.Comment = new StringExtension.SqlComment
                    {
                        Author = "周鹏",
                        FileName = "GridManagementFileInfoDal.cs",
                        ForUse = "批量删除已上传的文件",
                        FunName = "BatchDeleteFiles"
                    };
                    WriteDatabase.Execute(sbSql.ToString());
                }
            }
            catch (Exception ex)
            {
                AbortTransaction();
                return false;
            }
            CommitTransaction();
            return true;
        }
    }
}
