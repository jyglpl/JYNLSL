using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.DocumentManagement
{
    public class DocumentOfficialDal : BaseDal<DocumentOfficialEntity>
    {
        /// <summary>
        /// 发文登记
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertOfficial(DocumentOfficialEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO DOCUMNET_DISPATCH_INFO (ID,LWDW,LSSUED_STARTIME,LSSUED_ENDTIME,WH,QCR,BMFZR,DOCUMENT_TITLE,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON,Volume,DISPATCH_CSDW,DISPATCH_FGLD,DISPATCH_LDQF,DISPATCH_STATE) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
            entity.ID, entity.LWDW, entity.LSSUED_STARTIME, entity.LSSUED_ENDTIME, entity.WH, entity.QCR, entity.BMFZR, entity.DOCUMENT_TITLE,
            entity.ROWSTATUS, entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON, entity.Volume, entity.DISPATCH_CSDW,  entity.DISPATCH_FGLD, entity.DISPATCH_LDQF, entity.DISPATCH_STATE);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改发文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateOfficial(DocumentOfficialEntity entity)
        {
            var strSql = string.Format(@"UPDATE DOCUMNET_DISPATCH_INFO  SET
                                                    ID='{0}',
                                                    LWDW='{1}',
                                                    LSSUED_STARTIME='{2}',
                                                    LSSUED_ENDTIME='{3}',
                                                    WH='{4}'
                                                    QCR='{5}',
                                                    BMFZR='{6}',
                                                    DOCUMENT_TITLE='{7}',
                                                    Volume='{8}',
                                                    DISPATCH_CSDW='{9}',
                                                    DISPATCH_FGLD='{10}',
                                                    DISPATCH_LDQF='{11}',
                                                    DISPATCH_STATE='{12}'
                                                    ROWSTATUS='{13}',
                                                    CREATOR_ID='{14}',
                                                    CREATE_BY='{15}'
                                                    CREATE_ON='{16}',
                                                    UPDATE_ID='{17}',
                                                    UPDATE_BY='{18}',
                                                    UPDATE_ON='{19}'",
                                                    entity.ID,
                                                    entity.LWDW,
                                                    entity.LSSUED_STARTIME,
                                                    entity.LSSUED_ENDTIME,
                                                    entity.WH,
                                                    entity.QCR,
                                                    entity.BMFZR,
                                                    entity.DOCUMENT_TITLE,
                                                    entity.Volume,
                                                    entity.DISPATCH_CSDW,
                                                    entity.DISPATCH_FGLD,
                                                    entity.DISPATCH_LDQF,
                                                    entity.DISPATCH_STATE,
                                                    entity.ROWSTATUS,
                                                    entity.CREATOR_ID,
                                                    entity.CREATE_BY,
                                                    entity.CREATE_ON,
                                                    entity.UPDATE_ID,
                                                    entity.UPDATE_BY,
                                                    entity.UPDATE_ON
            );
            return WriteDatabase.Execute(strSql) > 0;
        }


        /// <summary>
        /// 获取发文集合
        /// </summary>
        /// <returns></returns>
        public List<DocumentOfficialEntity> GetSearchListOfficial(DocumentOfficialEntity search)
        {

            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<DocumentOfficialEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<DocumentOfficialEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            return WriteDatabase.Query<DocumentOfficialEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取发文
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DocumentOfficialEntity> GetSearchResult(string status, string userName, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM DOCUMNET_DISPATCH_INFO WHERE ROWSTATUS=1");
            if (!string.IsNullOrEmpty(userName))
            {
                strSql.AppendFormat(" AND (BMFZR LIKE '%{0}%' or LWDW LIKE '%{0}%' or DOCUMENT_TITLE LIKE '%{0}%' or WH LIKE '%{0}%' or QCR LIKE '%{0}%')", userName);
            }
            if (!string.IsNullOrEmpty(status))
            {
                strSql.AppendFormat(" AND DISPATCH_STATE ={0}", status);
            }
            var args = new List<object>();

            strSql.Append(" ORDER BY LSSUED_STARTIME Desc");
            return WriteDatabase.Page<DocumentOfficialEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 删除发文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteOfficial(string PK_ID)
        {
            var strSql = string.Format(@"UPDATE DOCUMNET_DISPATCH_INFO SET ROWSTATUS='{0}' WHERE ID='{1}'", (int)RowStatus.Delete, PK_ID);
            return WriteDatabase.Execute(strSql) > 0;
        }

    }
}
