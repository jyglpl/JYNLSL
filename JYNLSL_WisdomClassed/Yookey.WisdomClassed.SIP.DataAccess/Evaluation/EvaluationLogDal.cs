using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.DataAccess.Evaluation
{
    public class EvaluationLogDal : BaseDal<EvaluationLogEntity>
    {
        /// <summary>
        /// 新增考核记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationLogEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[EvaluationLog]
           ([Id],[EvaluationObjId],[ObjName],[EvaluationModId],[ModName]
           ,[EvaluationProcId],[ProcName]
           ,[EvaluationBasisId],[BasisName],[EvaluationMethodId],[MethodName],[IsRewards]
           ,[Points],[Score],[Remark],[InspectorId],[InspectorName],[CheckDate]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')",
            entity.Id, entity.EvaluationObjId, entity.ObjName, entity.EvaluationModId, entity.ModName,
            entity.EvaluationProcId, entity.ProcName, entity.EvaluationBasisId, entity.BasisName,
            entity.EvaluationMethodId, entity.MethodName, entity.IsRewards,
            entity.Points, entity.Score, entity.Remark, entity.InspectorId, entity.InspectorName, entity.CheckDate,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(EvaluationLogEntity entity)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(entity.EvaluationObjId))
            {
                strSqlLink.AppendFormat(@" EvaluationObjId = '{0}',", entity.EvaluationObjId);
            }
            if (!string.IsNullOrEmpty(entity.ObjName))
            {
                strSqlLink.AppendFormat(@" ObjName = '{0}',", entity.ObjName);
            }
            if (!string.IsNullOrEmpty(entity.EvaluationModId))
            {
                strSqlLink.AppendFormat(@" EvaluationModId = '{0}',", entity.EvaluationModId);
            }
            if (!string.IsNullOrEmpty(entity.ModName))
            {
                strSqlLink.AppendFormat(@" ModName = '{0}',", entity.ModName);
            }
            if (!string.IsNullOrEmpty(entity.EvaluationProcId))
            {
                strSqlLink.AppendFormat(@" EvaluationProcId = '{0}',", entity.EvaluationProcId);
            }
            if (!string.IsNullOrEmpty(entity.ProcName))
            {
                strSqlLink.AppendFormat(@" ProcName = '{0}',", entity.ProcName);
            }
            if (!string.IsNullOrEmpty(entity.EvaluationBasisId))
            {
                strSqlLink.AppendFormat(@" EvaluationBasisId = '{0}',", entity.EvaluationBasisId);
            }
            if (!string.IsNullOrEmpty(entity.BasisName))
            {
                strSqlLink.AppendFormat(@" BasisName = '{0}',", entity.BasisName);
            }
            if (!string.IsNullOrEmpty(entity.EvaluationMethodId))
            {
                strSqlLink.AppendFormat(@" EvaluationMethodId = '{0}',", entity.EvaluationMethodId);
            }
            if (!string.IsNullOrEmpty(entity.MethodName))
            {
                strSqlLink.AppendFormat(@" MethodName = '{0}',", entity.MethodName);
            }
            if (!string.IsNullOrEmpty(entity.CheckDate.ToString()))
            {
                strSqlLink.AppendFormat(@" CheckDate = '{0}',", entity.CheckDate);
            }
            if (entity.IsRewards == 0 || entity.IsRewards==1)
            {
                strSqlLink.AppendFormat(@" IsRewards = '{0}',", entity.IsRewards);
            }
            if (!string.IsNullOrEmpty(entity.Remark))
            {
                strSqlLink.AppendFormat(@" Remark = '{0}',", entity.Remark);
            }
            strSqlLink.AppendFormat(@" Points = '{0}',", entity.Points);

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
            var strSql = string.Format(@"UPDATE EvaluationLog SET {0} ROWSTATUS=1  WHERE ID='{1}'", strSqlLink, entity.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 获取考核列表分页信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public Page<EvaluationLogEntity> GetEvaluationLogInfo(string evaluationObjId, string evaluationModId, string evaluationProcId,int isRewards, string startTime, string endTime, int pageSize, int pageIndex)
        {
            DateTime lastMonth = DateTime.Now;
            if (string.IsNullOrEmpty(startTime))
            {
                startTime = lastMonth.AddDays(1 - lastMonth.Day).ToString("yyyy-MM-dd") + " 00:00:00.000";

            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = lastMonth.AddDays(1 - lastMonth.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
            }
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>("Where {0}=1 ", u => u.RowStatus));
            var args = new List<object>();
            if (!string.IsNullOrEmpty(evaluationObjId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p1 ", t => t.EvaluationObjId));
                args.Add(new { p1 = evaluationObjId });
            }
            if (!string.IsNullOrEmpty(evaluationModId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p2 ", t => t.EvaluationModId));
                args.Add(new { p2 = evaluationModId });
            }
            //根据考核项目Id
            if (!string.IsNullOrEmpty(evaluationProcId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p3 ", t => t.EvaluationProcId));
                args.Add(new { p3 = evaluationProcId });
            }
            if (isRewards!=3)
            {
                 sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p6 ", t => t.IsRewards));
                 args.Add(new { p6 = isRewards });
            }

            sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} >=@p4  and {0}<=@p5", t => t.CheckDate));
            args.Add(new { p4 = startTime, p5 = endTime });
            sbWhere.Append(" ORDER BY CheckDate desc");
            return WriteDatabase.Page<EvaluationLogEntity>(pageIndex, pageSize, sbWhere.ToString(), args.ToArray());
        }

        /// <summary>
        ///  获取考核列表信息
        /// </summary>
        /// <param name="evaluationObjId"></param>
        /// <param name="evaluationModId"></param>
        /// <param name="evaluationProcId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<EvaluationLogEntity> GetLogList(string evaluationObjId, string evaluationModId, string evaluationProcId, string startTime, string endTime)
        {
            //DateTime lastMonth = DateTime.Now.AddMonths(-1);
            DateTime lastMonth = DateTime.Now;
            if (string.IsNullOrEmpty(startTime))
            {
                startTime = lastMonth.AddDays(1 - lastMonth.Day).ToString("yyyy-MM-dd") + " 00:00:00.000";
            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = lastMonth.AddDays(1 - lastMonth.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
            }
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>("Where {0}=1 ", u => u.RowStatus));
            var args = new List<object>();
            if (!string.IsNullOrEmpty(evaluationObjId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p1 ", t => t.EvaluationObjId));
                args.Add(new { p1 = evaluationObjId });
            }
            if (!string.IsNullOrEmpty(evaluationModId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p2 ", t => t.EvaluationModId));
                args.Add(new { p2 = evaluationModId });
            }
            //根据考核项目Id
            if (!string.IsNullOrEmpty(evaluationProcId))
            {
                sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} = @p3 ", t => t.EvaluationProcId));
                args.Add(new { p3 = evaluationProcId });
            }
            
            sbWhere.Append(Database.GetFormatSql<EvaluationLogEntity>(" and {0} >=@p4  and {0}<=@p5", t => t.CheckDate));
            args.Add(new { p4 = startTime, p5 = endTime });
            sbWhere.Append(" ORDER BY CreateOn desc");
            return WriteDatabase.Query<EvaluationLogEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EvaluationLogEntity Get(string id)
        {
            var strSql = string.Format(@"SELECT * FROM EvaluationLog WHERE Id='{0}'", id);
            return WriteDatabase.SingleOrDefault<EvaluationLogEntity>(strSql);
        }
        /// <summary>
        /// 获取考核记录
        /// </summary>
        /// <returns></returns>
        public List<EvaluationLogEntity> GetSearchListForLog(EvaluationLogEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM EvaluationLog where RowStatus=1 ");
            if (!string.IsNullOrEmpty(search.Id))
            {
                strSql.AppendFormat(" And Id = '{0}'", search.Id);
            }

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "EvaluationLogDal.cs",
                ForUse = "获取法人列表",
                FunName = "GetSearchListForLog"
            };
            return ReadDatabase.Query<EvaluationLogEntity>(strSql.ToString()).ToList();
        }

    }
}
