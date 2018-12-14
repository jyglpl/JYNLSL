using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evidence;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.Business.Evidence
{
    public class ProofAttachBll
    {
        private ProofAttachDal _proofAttachDal = new ProofAttachDal();

        /// <summary>
        /// 获取执法记录附件
        /// </summary>
        /// <returns></returns>
        public List<ProofAttachEntity> GetSearchResult(ProofAttachEntity search)
        {
            return _proofAttachDal.GetSearchResult(search);
        }

        /// <summary>
        /// 获取执法记录附件
        /// </summary>
        /// <returns></returns>
        public List<ProofAttachEntity> GetSearchResult(ProofAttachEntity search, string UserId)
        {
            return _proofAttachDal.GetSearchResult(search, UserId);
        }

        /// <summary>
        /// 删除电子证据信息
        /// </summary>
        /// <param name="sid">电子证据编号</param>
        /// <param name="type">删除类型：1：临时删除，2：永久删除</param>
        /// <returns></returns>
        public bool DeleteEvidence(string sid, string type)
        {
            try
            {
                return _proofAttachDal.DeleteEvidence(sid, type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更新电子证据信息
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool UpdateEvidence(ProofAttachEntity search)
        {
            try
            {
                return _proofAttachDal.UpdateEvidence(search);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
