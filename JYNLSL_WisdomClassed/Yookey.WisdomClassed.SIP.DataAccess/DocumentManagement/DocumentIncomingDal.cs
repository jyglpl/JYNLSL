using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.DocumentManagement
{
    public class DocumentIncomingDal : BaseDal<DocumentIncomingEntity>
    {
        /// <summary>
        /// 收文登记
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIncoming(DocumentIncomingEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO DOCUMENT_INCOMING_INFO (ID,INCOMING_UNIT,CBR,INCOMING_DATE,QUALIFIED_DATE,DOCUMENT_CONTENT,INCOMING_STATE,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON,INCOMING_NBYJ,INCOMING_PS,CLJG,DOCUMENT_HAO,IsInitial) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
            entity.ID, entity.INCOMING_UNIT, entity.CBR, entity.INCOMING_DATE, entity.QUALIFIED_DATE, entity.DOCUMENT_CONTENT, entity.INCOMING_STATE,
            entity.ROWSTATUS, entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON, entity.INCOMING_NBYJ, entity.INCOMING_PS, entity.CLJG, entity.DOCUMENT_HAO, entity.IsInitial);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改收文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateIncoming(DocumentIncomingEntity entity)
        {
            var strSql = string.Format(@"UPDATE DOCUMENT_INCOMING_INFO  SET
                                                    INCOMING_UNIT='{1}',
                                                    INCOMING_DATE='{2}',
                                                    QUALIFIED_DATE='{3}',
                                                    DOCUMENT_CONTENT='{4}',
                                                    INCOMING_STATE='{5}',
                                                    ROWSTATUS='{6}',
                                                    CREATOR_ID='{7}',
                                                    CREATE_BY='{8}',
                                                    CREATE_ON='{9}',
                                                    UPDATE_ID='{10}',
                                                    UPDATE_BY='{11}',
                                                    UPDATE_ON='{12}',
                                                    INCOMING_NBYJ='{13}',
                                                    INCOMING_PS='{14}',
                                                    CLJG='{15}',
                                                    DOCUMENT_HAO='{16}'
                                                    where ID='{0}'
                                                    ",
                                                    entity.ID,
                                                    entity.INCOMING_UNIT,
                                                    entity.INCOMING_DATE,
                                                    entity.QUALIFIED_DATE,
                                                    entity.DOCUMENT_CONTENT,
                                                    entity.INCOMING_STATE,
                                                    entity.ROWSTATUS,
                                                    entity.CREATOR_ID,
                                                    entity.CREATE_BY,
                                                    entity.CREATE_ON,
                                                    entity.UPDATE_ID,
                                                    entity.UPDATE_BY,
                                                    entity.UPDATE_ON,
                                                    entity.INCOMING_NBYJ,
                                                    entity.INCOMING_PS,
                                                    entity.CLJG,
                                                    entity.DOCUMENT_HAO
            );
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateStatus(string UserId,string FormID)
        {
            var strSql = string.Format(@"Update CrmMessageWork set State=2 where Id=(Select ID from CrmMessageWork where FormID='{0}' and ActionerID='{1}')",FormID,UserId);
            return WriteDatabase.Execute(strSql) > 0;
        }

 

        /// <summary>
        /// 获取收文集合
        /// </summary>
        /// <returns></returns>
        public List<DocumentIncomingEntity> GetSearchListIncoming(DocumentIncomingEntity search)
        {

            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<DocumentIncomingEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<DocumentIncomingEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            return WriteDatabase.Query<DocumentIncomingEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取收文
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DocumentIncomingEntity> GetSearchResult(string status, string Unit, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM DOCUMENT_INCOMING_INFO WHERE ROWSTATUS=1");
            if (!string.IsNullOrEmpty(Unit))
            {
                strSql.AppendFormat(" AND (INCOMING_UNIT LIKE '%{0}%' or DOCUMENT_CONTENT LIKE '%{0}%' or CBR LIKE '%{0}%')", Unit);
            }
            if (!string.IsNullOrEmpty(status))
            {
                strSql.AppendFormat(" AND INCOMING_STATE ={0}", status);
            }
            var args = new List<object>();

            strSql.Append(" ORDER BY INCOMING_DATE Desc");
            return WriteDatabase.Page<DocumentIncomingEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 未完成查询收文
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>

        public Page<DocumentIncomingEntity> GetSearchResultwwc(string paperType, string txtName, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM DOCUMENT_INCOMING_INFO WHERE INCOMING_STATE='编辑中'");
            var args = new List<object>();

            strSql.Append(" ORDER BY INCOMING_DATE Desc");
            return WriteDatabase.Page<DocumentIncomingEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 删除收文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteIncoming(string Pk_Id)
        {
            var strSql = string.Format(@"UPDATE DOCUMENT_INCOMING_INFO SET ROWSTATUS='{0}' WHERE PK_ID='{1}'", (int)RowStatus.Delete, Pk_Id);
            return WriteDatabase.Execute(strSql) > 0;
        }


        /// <summary>
        /// 收文统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptStatisticsData(string startime, string endtime)
        {
            try
            {
                var str = new StringBuilder("");
                str.AppendFormat(@" select  DATEPART(month,INCOMING_DATE) Month,COUNT(*) CT from DOCUMENT_INCOMING_INFO where INCOMING_DATE>='{0} 00:00:00' and INCOMING_DATE<='{1} 23:59:59' group by DATEPART(month,INCOMING_DATE)  order by  DATEPART(month,INCOMING_DATE)", startime, endtime);
                return WriteDatabase.Query(str.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 发文文统计
        /// </summary>
        /// <param name="startime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable GetGwStatisticsData(string startime, string endtime)
        {
            try
            {
                var str = new StringBuilder("");
                str.AppendFormat(@" select  DATEPART(month,	LSSUED_STARTIME) Month,COUNT(*) CT from DOCUMNET_DISPATCH_INFO where LSSUED_STARTIME>='2018-1-1 00:00:00' and LSSUED_ENDTIME<='2018-12-31 23:59:59' group by DATEPART(month,LSSUED_STARTIME)  order by  DATEPART(month,LSSUED_STARTIME)", startime, endtime);
                return WriteDatabase.Query(str.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
