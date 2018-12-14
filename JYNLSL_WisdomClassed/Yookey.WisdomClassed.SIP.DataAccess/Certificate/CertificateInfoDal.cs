using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Certificate;

namespace Yookey.WisdomClassed.SIP.DataAccess.Certificate
{
    public class CertificateInfoDal : BaseDal<CertificateInfoEntity>
    {
        /// <summary>
        /// 新增执法证信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertCertificateInfo(CertificateInfoEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO PERSONAL_ENFORCE_MANAGE (ID,USER_ID,TARGET_PAPER_TYPE,TARGET_PAPER_NUM,ACCOUNT,NAME,SEX,MOBILE,PHONE,MAIL,COMPANY,DEPTNAME,ROLE,GETCARDTIME,REPLACEMENTTIME,DESCRIPTION,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
            entity.ID, entity.USER_ID, entity.TARGET_PAPER_TYPE, entity.TARGET_PAPER_NUM, entity.ACCOUNT, entity.NAME, entity.SEX, entity.MOBILE, entity.PHONE, entity.MAIL, entity.COMPANY, entity.DEPTNAME, entity.ROLE, entity.GETCARDTIME, entity.REPLACEMENTTIME, entity.DESCRIPTION, entity.ROWSTATUS,
            entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新执法证实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateCertificateInfo(CertificateInfoEntity entity)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(entity.TARGET_PAPER_TYPE))
            {
                strSqlLink.AppendFormat(@" TARGET_PAPER_TYPE = '{0}',", entity.TARGET_PAPER_TYPE);
            }
            if (!string.IsNullOrEmpty(entity.ROLE))
            {
                strSqlLink.AppendFormat(@" ROLE = '{0}',", entity.ROLE);
            }
            if (!string.IsNullOrEmpty(entity.NAME))
            {
                strSqlLink.AppendFormat(@" NAME = '{0}',", entity.NAME);
            }
            if (!string.IsNullOrEmpty(entity.DEPTNAME))
            {
                strSqlLink.AppendFormat(@" DEPTNAME = '{0}',", entity.DEPTNAME);
            }
            if (!string.IsNullOrEmpty(entity.SEX))
            {
                strSqlLink.AppendFormat(@" SEX = '{0}',", entity.SEX);
            }
            if (!string.IsNullOrEmpty(entity.TARGET_PAPER_NUM))
            {
                strSqlLink.AppendFormat(@" TARGET_PAPER_NUM = '{0}',", entity.TARGET_PAPER_NUM);
            }
            if (!string.IsNullOrEmpty(entity.GETCARDTIME))
            {
                strSqlLink.AppendFormat(@" GETCARDTIME = '{0}',", entity.GETCARDTIME);
            }
            if (!string.IsNullOrEmpty(entity.REPLACEMENTTIME))
            {
                strSqlLink.AppendFormat(@" REPLACEMENTTIME = '{0}',", entity.REPLACEMENTTIME);
            }
            if (!string.IsNullOrEmpty(entity.DESCRIPTION))
            {
                strSqlLink.AppendFormat(@" DESCRIPTION = '{0}',", entity.DESCRIPTION);
            }
            var strSql = string.Format(@"UPDATE PERSONAL_ENFORCE_MANAGE SET {0} ROWSTATUS=1  WHERE ID='{1}'", strSqlLink, entity.ID);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 获取执法证信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<CertificateInfoEntity> GetSearchResult(CertificateInfoEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ACCOUNT))
            {
                sbWhere.AppendFormat(@" AND ACCOUNT LIKE '%{0}%'", search.ACCOUNT);
            }
            if (!string.IsNullOrEmpty(search.TARGET_PAPER_TYPE))
            {
                sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>(" AND {0}=@p1", t => t.TARGET_PAPER_TYPE));
                args.Add(new { p1 = search.TARGET_PAPER_TYPE });
            }
            if (!string.IsNullOrEmpty(search.DEPTNAME))
            {
                sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>(" AND {0}=@p2", t => t.DEPTNAME));
                args.Add(new { p2 = search.DEPTNAME });
            }
            if (!string.IsNullOrEmpty(search.GetBegin))
            {
                sbWhere.AppendFormat(@" AND GETCARDTIME >= '{0}'", search.GetBegin);
            }
            if (!string.IsNullOrEmpty(search.GetEnd))
            {
                sbWhere.AppendFormat(@" AND GETCARDTIME <= '{0}'", search.GetEnd);
            }
            if (!string.IsNullOrEmpty(search.ReplaceBegin))
            {
                sbWhere.AppendFormat(@" AND REPLACEMENTTIME >= '{0}'", search.ReplaceBegin);
            }
            if (!string.IsNullOrEmpty(search.ReplaceEnd))
            {
                sbWhere.AppendFormat(@" AND REPLACEMENTTIME <= '{0}'", search.ReplaceEnd);
            }
            //排序
            sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>(" order by {0} desc", t => t.CREATE_ON));
            return ReadDatabase.Page<CertificateInfoEntity>(search.page.CurrentPage, search.page.PageSize, sbWhere.ToString(), args.ToArray());
        }

        /// <summary>
        /// 根据条件获取执法证信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<CertificateInfoEntity> GetCertificateResult(CertificateInfoEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<CertificateInfoEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            return WriteDatabase.Query<CertificateInfoEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 删除执法证
        /// </summary>
        /// <param name="Pk_Id"></param>
        /// <returns></returns>
        public bool DeleteCertificate(string Pk_Id)
        {
            var strSql = string.Format(@"UPDATE PERSONAL_ENFORCE_MANAGE SET ROWSTATUS='{0}' WHERE PK_ID='{1}'", (int)RowStatus.Delete, Pk_Id);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
