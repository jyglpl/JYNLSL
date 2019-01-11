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
    public class EvaluationProcDal : BaseDal<EvaluationProcEntity>
    {
        /// <summary>
        /// 获取考核项目
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<EvaluationProcEntity> GetSearchResult(EvaluationProcEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationProcEntity>(" and {0} = @p1 ", t => t.ParentId));
                args.Add(new { p1 = search.ParentId });
            }

            sbWhere.Append(" ORDER BY SortNo ");
            return WriteDatabase.Query<EvaluationProcEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }
        /// <summary>
        /// 获取考核项目列表信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public Page<EvaluationProcEntity> GetEvaluationProcInfo(string parentId, string keywords, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM EvaluationProc Where 1=1 AND RowStatus = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(parentId))
            {
                strSql.AppendFormat(@" AND ParentId='{0}'", parentId);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                strSql.AppendFormat(@" AND EvaluationName LIKE '%{0}%'", keywords);
            }
            strSql.Append(" ORDER BY CreateOn ");
            return WriteDatabase.Page<EvaluationProcEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationProcEntity Get(string Id)
        {
            var strSql = string.Format(@"SELECT * FROM EvaluationProc WHERE Id='{0}'", Id);
            return WriteDatabase.SingleOrDefault<EvaluationProcEntity>(strSql);
        }

        /// <summary>
        /// 删除考核项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string id, EvaluationProcEntity proc)
        {
            var strSql = string.Format(@"UPDATE EvaluationProc SET RowStatus='{0}',UpdateId='{1}',UpdateBy='{2}',UpdateOn='{3}' WHERE Id='{4}'", (int)RowStatus.Delete, proc.UpdateId, proc.UpdateBy, proc.UpdateOn, id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增考核项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationProcEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[EvaluationProc]
           ([Id],[ParentId],[EvaluationName],[Points],[Score]
           ,[SortNo]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')"
           , entity.Id, entity.ParentId, entity.EvaluationName, entity.Points, entity.Score
           , entity.SortNo
           , entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新考核项
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(EvaluationProcEntity search)
        {
            var strSqlLink = new StringBuilder();
            strSqlLink.AppendFormat(@" Points = '{0}',", search.Points);
            if (!string.IsNullOrEmpty(search.ParentId))
            {
                strSqlLink.AppendFormat(@" ParentId = '{0}',", search.ParentId);
            }
            if (!string.IsNullOrEmpty(search.EvaluationName))
            {
                strSqlLink.AppendFormat(@" EvaluationName = '{0}',", search.EvaluationName);
            }
            if (!string.IsNullOrEmpty(search.UpdateId))
            {
                strSqlLink.AppendFormat(@" UpdateId = '{0}',", search.UpdateId);
            }
            if (!string.IsNullOrEmpty(search.UpdateBy))
            {
                strSqlLink.AppendFormat(@" UpdateBy = '{0}',", search.UpdateBy);
            }
            if (!string.IsNullOrEmpty((search.UpdateOn).ToString()))
            {
                strSqlLink.AppendFormat(@" UpdateOn = '{0}',", search.UpdateOn);
            }
            var strSql = string.Format(@"UPDATE EvaluationProc SET {0} ROWSTATUS=1  WHERE Id='{1}'", strSqlLink, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 保存考核项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveProc(EvaluationProcEntity entity, EvaluationBasisEntity bas)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                var EvaluationProcModel = Get(entity.Id);
                new EvaluationBasisDal().Delete(entity.Id, bas);
                if (EvaluationProcModel != null && !string.IsNullOrEmpty(EvaluationProcModel.Id))
                {
                    Update(entity);
                }
                else
                {
                    Insert(entity);
                }
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }

        /// <summary>
        /// 事务添加考核项及细则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="evaluationBasisList"></param>
        /// <returns></returns>
        public bool TransactionSave(EvaluationProcEntity entity, List<EvaluationBasisEntity> evaluationBasisList)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                var EvaluationProcModel = Get(entity.Id);
                if (EvaluationProcModel != null && !string.IsNullOrEmpty(EvaluationProcModel.Id))
                {
                    Update(entity);
                }
                else
                {
                    Insert(entity);
                }
                if (evaluationBasisList.Any())
                {
                    var sql = string.Format("DELETE EvaluationBasis WHERE RowStatus=1 and EvaluationProcId='{0}' ", entity.Id);
                    WriteDatabase.Execute(sql);
                }
                //循环遍历考核细则
                foreach (var evaluationBasis in evaluationBasisList)
                {
                    new EvaluationBasisDal().Insert(evaluationBasis);
                }
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }

        /// <summary>
        /// 事务删除考核项及细则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="evaluationBasisList"></param>
        /// <returns></returns>
        public bool TransactionDelete(string id, EvaluationProcEntity proc, EvaluationBasisEntity bas)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                Delete(id, proc);
                new EvaluationBasisDal().Delete(id, bas);
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }
    }
}
