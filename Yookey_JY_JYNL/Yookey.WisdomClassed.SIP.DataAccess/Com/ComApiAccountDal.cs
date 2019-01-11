using PetaPoco;
using System.Collections.Generic;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// 接口帐号管理
    /// </summary>
    public class ComApiAccountDal : BaseDal<ComApiAccountEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public Page<ComApiAccountEntity> GetSearchResult(ComApiAccountEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ACCOUNTNAME))
            {
                sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>(" and {0} LIKE '%'+@p1+'%'",
                    t => t.ACCOUNTNAME));
                args.Add(new { p1 = search.ACCOUNTNAME });
            }
            //排序
            sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>(" order by  {0} desc", t => t.ID));
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComApiAccountDal.cs",
                ForUse = "查询",
                FunName = "GetSearchResult"
            };
            return WriteDatabase.Page<ComApiAccountEntity>(search.page.CurrentPage, search.page.PageSize,
                sbWhere.ToString(),
                args.ToArray());
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [ComApiAccount] SET [RowStatus] =0 WHERE [Id]  IN ({0})", ids.Trim(','));
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComApiAccountDal.cs",
                ForUse = "批量删除",
                FunName = "BatchDelete"
            };
            return WriteDatabase.Execute(sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 验证帐号ID是否存在
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="accountId">帐号ID</param>
        /// <returns></returns>
        public bool AccountIdExists(string accountId, int id)
        {
            if (string.IsNullOrEmpty(accountId)) return true;
            var args = new List<object> { new { p1 = accountId, p2 = id } };
            var sbWhere = new StringBuilder("SELECT COUNT(*) FROM ComApiAccount ");
            sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>("Where {0}=1 ", t => t.ROWSTATUS));
            sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>(" and {0} = @p1 ", t => t.ACCOUNTID));
            if (id > 0)
            {
                sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>(" and {0} <> @p2 ", t => t.ID));
            }
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComApiAccountDal.cs",
                ForUse = "验证帐号ID是否存在",
                FunName = "AccountIdExists"
            };
            return WriteDatabase.ExecuteScalar<int>(sbWhere.ToString(), args.ToArray()) > 0;
        }

        /// <summary>
        /// 根据接口账号获取实体
        /// </summary>
        /// <param name="accountId">帐号ID</param>
        /// <returns></returns>
        public ComApiAccountEntity GetComApiAccount(string accountId)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object> { new { AccountId = accountId } };
            sbWhere.Append(Database.GetFormatSql<ComApiAccountEntity>("WHERE {0}=1 ", t => t.ROWSTATUS));
            sbWhere.AppendFormat(" AND AccountId =@AccountId");
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComApiAccountDal.cs",
                ForUse = "根据接口账号获取实体",
                FunName = "GetComApiAccount"
            };
            return WriteDatabase.FirstOrDefault<ComApiAccountEntity>(sbWhere.ToString(), args.ToArray());
        }
    }
}