using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.DataAccess.Evaluation
{
    public class EvaluationAttachDal : BaseDal<EvaluationAttachEntity>
    {
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<EvaluationAttachEntity> GetAllResult(EvaluationAttachEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p1 ", t => t.ResourceId));
                args.Add(new { p1 = search.ResourceId });
            }
            if (!string.IsNullOrEmpty(search.FileReName))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} like '" + search.FileReName + "%' ", t => t.FileReName));
            }
            if (!string.IsNullOrEmpty(search.FileType))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p2 ", t => t.FileType));
                args.Add(new { p2 = search.FileType });
            }
            sbWhere.Append(" ORDER BY FileType ");
            return WriteDatabase.Query<EvaluationAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search, List<string> types)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p1 ", t => t.ResourceId));
                args.Add(new { p1 = search.ResourceId });
            }
            if (types != null && types.Count > 0)
            {
                sbWhere.AppendFormat("and FileType in  ('{0}')", string.Join("','", types.ToArray()));
            }
            sbWhere.Append(" ORDER BY CreateOn ");
            return WriteDatabase.Query<EvaluationAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p1 ", t => t.ResourceId));
                args.Add(new { p1 = search.ResourceId });
            }
            sbWhere.Append(" ORDER BY CreateOn ");
            return WriteDatabase.Query<EvaluationAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(EvaluationAttachEntity search)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[EvaluationAttach]
           ([Id],[ResourceId],[FileName],[FileReName],[FileSize]
           ,[IsCompleted],[FileAddress],[FileType],[FileTypeName],[FileRemark]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
   VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')"
          , search.Id, search.ResourceId, search.FileName, search.FileReName, search.FileSize
          , search.IsCompleted, search.FileAddress, search.FileType, search.FileTypeName, search.FileRemark
          , search.RowStatus, search.CreatorId, search.CreateBy, search.CreateOn, search.UpdateId, search.UpdateBy, search.UpdateOn);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据主键删除附件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            var strSql = string.Format(@"UPDATE EvaluationAttach SET ROWSTATUS='{0}' WHERE Id='{1}'", (int)RowStatus.Delete, id);
            return WriteDatabase.Execute(strSql);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationAttachEntity Get(string Id)
        {
            var strSql = string.Format(@"SELECT * FROM EvaluationAttach WHERE Id='{0}'", Id);
            return WriteDatabase.Single<EvaluationAttachEntity>(strSql);
        }


        /// <summary>
        /// 根据主键更新附件备注
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int UpdateRemark(string Id, string Remark)
        {
            var strSql = string.Format(@"UPDATE EvaluationAttach SET FileRemark='{0}' WHERE Id='{1}'", Remark, Id);
            return WriteDatabase.Execute(strSql);
        }

        /// <summary>
        /// 修改附件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(EvaluationAttachEntity entity)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(entity.FileName))
            {
                strSqlLink.AppendFormat(@" FileName = '{0}',", entity.FileName);
            }
            if (!string.IsNullOrEmpty(entity.FileReName))
            {
                strSqlLink.AppendFormat(@" FileReName = '{0}',", entity.FileReName);
            }
            if (!string.IsNullOrEmpty(entity.FileType))
            {
                strSqlLink.AppendFormat(@" FileType = '{0}',", entity.FileType);
            }
            if (!string.IsNullOrEmpty(entity.FileTypeName))
            {
                strSqlLink.AppendFormat(@" FileTypeName = '{0}',", entity.FileTypeName);
            }
            if (!string.IsNullOrEmpty(entity.FileRemark))
            {
                strSqlLink.AppendFormat(@" FileRemark = '{0}',", entity.FileRemark);
            }

            if (!string.IsNullOrEmpty(entity.UpdateId))
            {
                strSqlLink.AppendFormat(@" UpdateId = '{0}',", entity.UpdateId);
            }
            if (!string.IsNullOrEmpty(entity.UpdateBy))
            {
                strSqlLink.AppendFormat(@" UpdateBy = '{0}',", entity.UpdateBy);
            }
            if (!string.IsNullOrEmpty(entity.UpdateOn.ToString()))
            {
                strSqlLink.AppendFormat(@" UpdateOn = '{0}',", entity.UpdateOn);
            }
            var strSql = string.Format(@"UPDATE [dbo].[EvaluationAttach] SET {0} RowStatus=1  WHERE Id='{1}'", strSqlLink, entity.Id);
            return WriteDatabase.Execute(strSql);
        }
    }
}
