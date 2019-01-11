using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Business.Evaluation
{
    public class EvaluationProcBll
    {
        private static readonly EvaluationProcDal Dal = new EvaluationProcDal();
        /// <summary>
        /// 获取考核项目
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<EvaluationProcEntity> GetSearchResult(EvaluationProcEntity search)
        {
            return Dal.GetSearchResult(search);
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
            return Dal.GetEvaluationProcInfo(parentId, keywords, pageSize, pageIndex);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationProcEntity Get(string Id)
        {
            return Dal.Get(Id);
        }

        /// <summary>
        /// 新增考核项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationProcEntity entity)
        {
            return Dal.Insert(entity);
        }
        /// <summary>
        /// 更新案件实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(EvaluationProcEntity search)
        {
            return Dal.Update(search);
        }

        /// <summary>
        /// 保存考核项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveProc(EvaluationProcEntity entity,EvaluationBasisEntity bas)
        {
            return Dal.SaveProc(entity, bas);
        }

        /// <summary>
        /// 事务添加考核项及细则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="evaluationBasisList"></param>
        /// <returns></returns>
        public bool TransactionSave(EvaluationProcEntity entity, List<EvaluationBasisEntity> evaluationBasisList)
        {
            return Dal.TransactionSave(entity, evaluationBasisList);
        }

        /// <summary>
        /// 事务删除考核项及细则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="evaluationBasisList"></param>
        /// <returns></returns>
        public bool TransactionDelete(string id, EvaluationProcEntity proc, EvaluationBasisEntity bas)
        {
            return Dal.TransactionDelete(id, proc, bas);
        }

    }
}
