using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Business.Evaluation
{
    public class EvaluationLogBll
    {
        private static readonly EvaluationLogDal Dal = new EvaluationLogDal();

        /// <summary>
        /// 新增考核记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationLogEntity entity)
        {
            return Dal.Insert(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(EvaluationLogEntity entity)
        {
            return Dal.Update(entity);
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
            return Dal.GetEvaluationLogInfo(evaluationObjId, evaluationModId, evaluationProcId,isRewards, startTime, endTime, pageSize, pageIndex);
        }

        /// <summary>
        /// 根据考核对象及考核模块获取分值
        /// </summary>
        /// <param name="evalObjId">对象</param>
        /// <param name="evalModId">模块</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public LogStatisticsEntity GetLogInfo(string evalObjId, string evalModId, string startTime, string endTime)
        {
            LogStatisticsEntity logEntity = new LogStatisticsEntity();
           
            //考核模块
            var evalMod = new ComResourceBll().Get(evalModId);
            if (evalMod!=null&& !string.IsNullOrEmpty(evalMod.Id))
	        {
                logEntity.ObjId = evalObjId;
                logEntity.ObjName = "";//考核对象名称
                logEntity.EvalModId = evalModId;
                logEntity.EvalModName = evalMod.RsKey;//考核模块名称
		        //考核项
                var evalProc = new EvaluationProcBll().GetSearchResult(new EvaluationProcEntity { ParentId = evalModId }).ToList();
                foreach (var eval in evalProc)
                {
                    //考核项下所有记录
                    var evalLog = Dal.GetLogList(evalObjId, evalModId, eval.Id, startTime, endTime).ToList();
                    LogStatisticsEntity basEntity = new LogStatisticsEntity();
                    foreach (var log in evalLog)
                    {
                        //考核项总扣分
                        if (log.IsRewards == 0)
                        {
                            basEntity.Punishment += log.Points;
                        }
                        //考核项总加分
                        else
                        {
                            basEntity.Reward += log.Points;
                        }
                    }
                    //考核模块分值
                    logEntity.Punishment += basEntity.Punishment > eval.Points ? eval.Points : basEntity.Punishment;
                    logEntity.Reward += basEntity.Reward;
                }
            }
            return logEntity;
       }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EvaluationLogEntity Get(string id)
        {
            return Dal.Get(id);
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
            return Dal.GetLogList(evaluationObjId, evaluationModId, evaluationProcId, startTime, endTime);
        }

        /// <summary>
        /// 获取考核记录
        /// </summary>
        /// <returns></returns>
        public List<EvaluationLogEntity> GetSearchListForLog(EvaluationLogEntity search)
        {
            return Dal.GetSearchListForLog(search);
        }
    }
}
