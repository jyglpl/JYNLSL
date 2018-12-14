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
    public class EvaluationBasisDal : BaseDal<EvaluationBasisEntity>
    {
        /// <summary>
        /// 获取考核细则
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<EvaluationBasisEntity> GetSearchResult(EvaluationBasisEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<EvaluationBasisEntity>("Where {0}=1 ", u => u.RowStatus));
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationBasisEntity>(" and {0} = @p1 ", t => t.Id));
                args.Add(new { p1 = search.Id });
            }
            //根据考核项目Id
            if (!string.IsNullOrEmpty(search.EvaluationProcId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationBasisEntity>(" and {0} = @p2 ", t => t.EvaluationProcId));
                args.Add(new { p2 = search.EvaluationProcId });
            }
            sbWhere.Append(" ORDER BY CreateOn desc");

            return WriteDatabase.Query<EvaluationBasisEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationBasisEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM EvaluationBasis WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.SingleOrDefault<EvaluationBasisEntity>(strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 根据考核项删除所有考核细则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string evaluationProcId, EvaluationBasisEntity bas)
        {
            var strSql = string.Format(@"UPDATE EvaluationBasis SET RowStatus='{0}',UpdateId='{1}',UpdateBy='{2}',UpdateOn='{3}' WHERE EvaluationProcId='{4}'", (int)RowStatus.Delete, bas.UpdateId, bas.UpdateBy, bas.UpdateOn, evaluationProcId);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增考核细则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationBasisEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[EvaluationBasis]
           ([Id],[EvaluationProcId],[EvaluationDetail],[IsRewards]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
            entity.Id, entity.EvaluationProcId, entity.EvaluationDetail, entity.IsRewards,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 保存考核细则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveBas(EvaluationBasisEntity entity)
        {
            try
            {
                var EvaluationBasModel = Get(entity.Id);
                if (EvaluationBasModel != null && !string.IsNullOrEmpty(EvaluationBasModel.Id))
                {
                   return Update(entity);
                }
                else
                {
                    return Insert(entity);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(EvaluationBasisEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.EvaluationProcId))
            {
                strSqlLink.AppendFormat(@" EvaluationProcId = '{0}',", search.EvaluationProcId);
            }
            if (!string.IsNullOrEmpty(search.EvaluationDetail))
            {
                strSqlLink.AppendFormat(@" EvaluationDetail = '{0}',", search.EvaluationDetail);
            }
            strSqlLink.AppendFormat(@" IsRewards = '{0}',", search.IsRewards);

            if (!string.IsNullOrEmpty(search.UpdateId))
            {
                strSqlLink.AppendFormat(@" UpdateId = '{0}',", search.UpdateId);
            }
            if (!string.IsNullOrEmpty(search.UpdateBy))
            {
                strSqlLink.AppendFormat(@" UpdateBy = '{0}',", search.UpdateBy);
            }
            if (!string.IsNullOrEmpty(search.UpdateOn.ToString()))
            {
                strSqlLink.AppendFormat(@" UpdateOn = '{0}',", search.UpdateOn);
            }
            var strSql = string.Format(@"UPDATE EvaluationBasis SET {0} RowStatus=1  WHERE Id='{1}'", strSqlLink, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
