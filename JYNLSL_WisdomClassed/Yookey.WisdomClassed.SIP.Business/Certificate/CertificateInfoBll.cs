using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Certificate;
using Yookey.WisdomClassed.SIP.Model.Certificate;

namespace Yookey.WisdomClassed.SIP.Business.Certificate
{
    public class CertificateInfoBll
    {
        public static readonly CertificateInfoDal Dal = new CertificateInfoDal();

        /// <summary>
        /// 获取执法证信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public PetaPoco.Page<CertificateInfoEntity> GetSearchResult(CertificateInfoEntity search)
        {
            return Dal.GetSearchResult(search);
        }

        /// <summary>
        /// 根据条件获取执法证信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<CertificateInfoEntity> GetCertificateResult(CertificateInfoEntity search)
        {
            return Dal.GetCertificateResult(search);
        }

        /// <summary>
        /// 新增执法证信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertCertificateInfo(CertificateInfoEntity entity)
        {
            return Dal.InsertCertificateInfo(entity);
        }

        /// <summary>
        /// 更新执法证实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateCertificateInfo(CertificateInfoEntity entity)
        {
            return Dal.UpdateCertificateInfo(entity);
        }

        /// <summary>
        /// 删除执法证
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public bool DeleteCertificate(string Pk_Id)
        {
            return Dal.DeleteCertificate(Pk_Id);
        }
    }
}
