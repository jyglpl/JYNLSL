using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Certificate;
using Yookey.WisdomClassed.SIP.Model.Certificate;

namespace Yookey.WisdomClassed.SIP.Business.Certificate
{
    public class CertificateAttachBll
    {
        public static readonly CertificateAttachDal Dal = new CertificateAttachDal();

        /// <summary>
        /// 查询执法证对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<CertificateAttachEntity> GetSearchResult(CertificateAttachEntity search)
        {
            return Dal.GetSearchResult(search);
        }

        /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertCertificateAttach(CertificateAttachEntity search)
        {
            return Dal.InsertCertificateAttach(search);
        }

        /// <summary>
        /// 更新附件
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateCertificateAttach(CertificateAttachEntity search)
        {
            return Dal.UpdateCertificateAttach(search);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public int DeleteCertificateAttach(string Pk_Id)
        {
            return Dal.DeleteCertificateAttach(Pk_Id);
        }
    }
}
