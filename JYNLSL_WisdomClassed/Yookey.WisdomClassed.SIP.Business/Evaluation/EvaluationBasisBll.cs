using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Business.Evaluation
{
    public class EvaluationBasisBll
    {
        private static readonly EvaluationBasisDal Dal = new EvaluationBasisDal();

        /// <summary>
        /// 获取考核细则
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<EvaluationBasisEntity> GetSearchResult(EvaluationBasisEntity search)
        {
            return Dal.GetSearchResult(search);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationBasisEntity Get(string Id)
        {
            return Dal.Get(Id);
        }

        /// <summary>
        /// 新增考核细则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(EvaluationBasisEntity entity)
        {
            return Dal.Insert(entity);
        }

        /// <summary>
        /// 保存考核细则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveBas(EvaluationBasisEntity entity)
        {
            return Dal.SaveBas(entity);
        }
    }
}
