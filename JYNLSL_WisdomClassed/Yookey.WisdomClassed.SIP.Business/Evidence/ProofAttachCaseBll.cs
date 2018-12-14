using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.Business.Evidence
{
    public class ProofAttachCaseBll
    {
        private ProofAttachCaseDal _proofAttachDal = new ProofAttachCaseDal();

         /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(ProofAttachCaseEntity entity)
        {
            return _proofAttachDal.Insert(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(ProofAttachCaseEntity entity)
        {
            return _proofAttachDal.PersistDeletedItem(entity);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<ProofAttachCaseEntity> SearchQuery(ProofAttachCaseEntity entity)
        {
            return _proofAttachDal.SearchQuery(entity);
        }

        /// <summary>
        /// 变更删除状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteAttachCase(string Id)
        {
            return _proofAttachDal.DeleteAttachCase(Id);
        }
    }
}
