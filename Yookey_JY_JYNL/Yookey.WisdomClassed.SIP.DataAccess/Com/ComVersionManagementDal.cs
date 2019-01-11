using PetaPoco;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    public class ComVersionManagementDal : BaseDal<ComVersionManagementEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public Page<ComVersionManagementEntity> GetSearchResult(ComVersionManagementEntity search)
        {
            var args = new List<object>();
            var sbWhere = new StringBuilder();
            sbWhere.AppendFormat(" Where RowStatus=1 ");
            if (search.MobileType > 0)
            {
                sbWhere.Append(Database.GetFormatSql<ComVersionManagementEntity>(" and {0}=@MobileType ",
                    t => t.MobileType));
                args.Add(new { MobileType = search.MobileType });
            }
            //排序
            sbWhere.AppendFormat(" order by Id desc");
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "查询",
                FunName = "GetSearchResult"
            };
            return WriteDatabase.Page<ComVersionManagementEntity>(search.page.CurrentPage, search.page.PageSize,
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
            sbSql.AppendFormat("UPDATE [ComVersionManagement] SET [RowStatus] =0 WHERE [Id]  IN ({0})", ids.Trim(','));
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "批量删除",
                FunName = "BatchDelete"
            };
            return WriteDatabase.Execute(sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool NameExists(string name, int id, int mobileType)
        {
            if (string.IsNullOrEmpty(name)) return true;
            var args = new List<object> { new { Name = name, Id = id, MobileType = mobileType } };
            var sbWhere = new StringBuilder("SELECT COUNT(*) FROM VersionManagement ");
            sbWhere.AppendFormat(" Where RowStatus = 1 ");
            sbWhere.AppendFormat(" and Name = @Name ");
            sbWhere.AppendFormat(" and MobileType = @MobileType ");
            if (id > 0)
            {
                sbWhere.Append(" and Id <> @Id ");
            }
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "查询",
                FunName = "NameExists"
            };
            return WriteDatabase.ExecuteScalar<int>(sbWhere.ToString(), args.ToArray()) > 0;
        }

        /// <summary>
        /// 验证版本序列号
        /// </summary>
        /// <param name="versionNo">验证的版本序列号</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool VersionNoExists(int versionNo, int mobileType)
        {
            var args = new List<object> { new { VersionNo = versionNo, MobileType = mobileType } };
            var sbWhere = new StringBuilder("SELECT COUNT(*) FROM VersionManagement ");
            sbWhere.AppendFormat(" Where RowStatus=1 ");
            sbWhere.AppendFormat(" and VersionNo >= @VersionNo ");
            sbWhere.AppendFormat(" and MobileType = @MobileType ");
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "验证版本序列号",
                FunName = "VersionNoExists"
            };
            return WriteDatabase.ExecuteScalar<int>(sbWhere.ToString(), args.ToArray()) > 0;
        }

        /// <summary>
        /// 验证文件版本号
        /// </summary>
        /// <param name="fileVersionNo">验证的文件版本号</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool FileVersionExists(string fileVersionNo, int mobileType)
        {
            var args = new List<object> { new { FileVersion = fileVersionNo, MobileType = mobileType } };
            var sbWhere = new StringBuilder("SELECT COUNT(*) FROM ComVersionManagement ");
            sbWhere.AppendFormat(" Where RowStatus=1 ");
            sbWhere.AppendFormat(" and FileVersion = @FileVersion ");
            sbWhere.AppendFormat(" and MobileType = @MobileType ");
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "验证文件版本号",
                FunName = "FileVersionExists"
            };
            return WriteDatabase.ExecuteScalar<int>(sbWhere.ToString(), args.ToArray()) > 0;
        }

        /// <summary>
        /// 根据手机类型获取最新版本信息
        /// </summary>
        /// <returns></returns>
        public ComVersionManagementEntity GetNewVersionInfo(int mobileType)
        {
            var strsql = new StringBuilder();
            strsql.AppendFormat(
                @"SELECT TOP 1 *
                FROM ComVersionManagement WITH(NOLOCK)  Where RowStatus=1 AND MobileType={0} ORDER BY VersionNo DESC",
                mobileType);
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "",
                FileName = "ComVersionManagementDal.cs",
                ForUse = "根据手机类型获取最新版本信息",
                FunName = "GetNewVersionInfo"
            };
            var dt = WriteDatabase.Query(strsql.ToString());
            var list = ConvertListHelper<ComVersionManagementEntity>.ConvertToList(dt);
            return list.Any() ? list[0] : new ComVersionManagementEntity();
        }
    }
}