using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Certificate;

namespace Yookey.WisdomClassed.SIP.DataAccess.Certificate
{
    public class CertificateAttachDal : BaseDal<CertificateAttachEntity>
    {
        /// <summary>
        /// 查询执法证对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<CertificateAttachEntity> GetSearchResult(CertificateAttachEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append(" Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<CertificateAttachEntity>(" and {0} = @p1 ", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            if (!string.IsNullOrEmpty(search.USER_ID))
            {
                sbWhere.Append(Database.GetFormatSql<CertificateAttachEntity>(" and {0} = @p2 ", t => t.USER_ID));
                args.Add(new { p2 = search.USER_ID });
            }
            sbWhere.Append(" ORDER BY CREATE_ON ");
            return WriteDatabase.Query<CertificateAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }


        /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertCertificateAttach(CertificateAttachEntity search)
        {
            var strSql = string.Format(@"INSERT INTO ENFORCE_ATTACH (ID,USER_ID,FILE_NAME,FILE_ADDRESS,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", search.ID, search.USER_ID, search.FILE_NAME, search.FILE_ADDRESS, search.ROWSTATUS, search.CREATOR_ID, search.CREATE_BY, search.CREATE_ON, search.UPDATE_ID, search.UPDATE_BY, search.UPDATE_ON);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新附件
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateCertificateAttach(CertificateAttachEntity search)
        {
            var strSql = string.Format(@"UPDATE ENFORCE_ATTACH SET FILE_NAME='{0}',FILE_ADDRESS='{1}' WHERE ID='{2}'", search.FILE_NAME, search.FILE_ADDRESS, search.ID);
            return WriteDatabase.Execute(strSql);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public int DeleteCertificateAttach(string Pk_Id)
        {
            var strSql = string.Format(@"DELETE FROM  ENFORCE_ATTACH  WHERE PK_ID='{0}'", Pk_Id);
            return WriteDatabase.Execute(strSql);
        }
    }
}
