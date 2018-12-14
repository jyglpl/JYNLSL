using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComWhiteList数据访问操作
    /// </summary>
    public class ComWhiteListDal : DalImp.BaseDal<ComWhiteListEntity>
    {
        public ComWhiteListDal()
        {
            Model = new ComWhiteListEntity();
        }

        /// <summary>
        /// 查询所有白名单
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetSearchResult(string keyword, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.Append(@"SELECT * FROM ComWhiteList WHERE RowStatus=1");
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.AppendFormat(" AND PlateNumber LIKE '%{0}%'", keyword);
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "Desc", pageIndex, pageSize, out totalRecords);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [ComWhiteList] SET [RowStatus] =0 WHERE [Id]  IN ({0})", ids.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}
