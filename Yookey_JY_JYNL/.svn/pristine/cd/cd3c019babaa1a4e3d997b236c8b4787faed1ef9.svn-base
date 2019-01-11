using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.DataAccess.Evaluation
{
    public class ProofAttachCaseDal : BaseDal<ProofAttachCaseEntity>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ProofAttachCaseEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[INF_PUNISH_ATTACH_CASE]
           ([ID],[CASEID],[PROOFATTACHID],[PENALTYCASE]
           ,[PENALTY],[STATE])
     VALUES ('{0}','{1}','{2}','{3}','{4}','1')",
            entity.Id, entity.CaseId, entity.ProofAttachId, entity.PenaltyCase,
            entity.Penalty);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<ProofAttachCaseEntity> SearchQuery(ProofAttachCaseEntity entity)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM INF_PUNISH_ATTACH_CASE Where STATE = 1");
            var args = new List<object>();

            if (!string.IsNullOrEmpty(entity.Penalty))
            {
                strSql.AppendFormat(@" AND Penalty='{0}'", entity.Penalty);
            }
            if (!string.IsNullOrEmpty(entity.PenaltyCase))
            {
                strSql.AppendFormat(@" AND PenaltyCase='{0}'", entity.PenaltyCase);
            }
            if (!string.IsNullOrEmpty(entity.CaseId))
            {
                strSql.AppendFormat(@" AND CASEID='{0}'", entity.CaseId);
            }
            if (!string.IsNullOrEmpty(entity.ProofAttachId))
            {
                strSql.AppendFormat(@" AND ProofAttachId='{0}'", entity.ProofAttachId);
            }

            return WriteDatabase.Query<ProofAttachCaseEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 变更删除状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteAttachCase(string Id)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"UPDATE INF_PUNISH_ATTACH_CASE SET STATE = 0 WHERE ProofAttachId = '{0}'",Id);
            return WriteDatabase.Execute(strSql.ToString()) > 0;
        }
    }
}
