using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;


namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    public class IllegalCaseInfoDal : BaseDal<IllegalCaseInfoEntity>
    {
        /// <summary>
        /// 新增违法案件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalCaseInfo(IllegalCaseInfoEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO ILLEGAL_CASEINFO (ID,REPORT_NAME,REPORT_PHONE,CASE_SOURCES,RE_SOURCE_NAME,CASE_FACT,DETAIL_ADDRESS,REPORT_CASE_DATE,CASE_STATUS,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON,DEPT_KEY_ID,ZF_DEPT_NAME,HANDLE_ID,HANDLE_NAME,CASE_REGISTRATION_SOURCE,COMPANY_ID,COMPANY_NAME) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
            entity.ID, entity.REPORT_NAME, entity.REPORT_PHONE, entity.CASE_SOURCES, entity.RE_SOURCE_NAME, entity.CASE_FACT, entity.DETAIL_ADDRESS, entity.REPORT_CASE_DATE, entity.CASE_STATUS,
            entity.ROWSTATUS, entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON, entity.DEPT_KEY_ID, entity.ZF_DEPT_NAME, entity.HANDLE_ID, entity.HANDLE_NAME, entity.CASE_REGISTRATION_SOURCE, entity.COMPANY_ID, entity.COMPANY_NAME);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 获取违法案件
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryIllegalCaseList(string companyId, string deptId, string source, string keyword, string userId, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append("SELECT * FROM ILLEGAL_CASEINFO WHERE ROWSTATUS = 1 ");
                if (!string.IsNullOrEmpty(companyId))
                {
                    strSql.AppendFormat(@" AND COMPANY_ID = '{0}'", companyId);
                }
                if (!string.IsNullOrEmpty(deptId))
                {
                    strSql.AppendFormat(@" AND DEPT_KEY_ID = '{0}'", deptId);
                }
                if (!string.IsNullOrEmpty(source))
                {
                    strSql.AppendFormat(@" AND CASE_SOURCES = '{0}'", source);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND REPORT_NAME LIKE '%{0}%'", keyword);
                }
                if (!string.IsNullOrEmpty(userId))
                {
                    strSql.AppendFormat(@" AND HANDLE_ID = '{0}'", userId);
                }
                var sortField = "CREATE_ON"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取违法案件集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseInfoEntity> GetIllegalCaseResult(IllegalCaseInfoEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            if (!string.IsNullOrEmpty(search.COMPANY_ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}=@p2", t => t.COMPANY_ID));
                args.Add(new { p2 = search.COMPANY_ID });
            }
            return WriteDatabase.Query<IllegalCaseInfoEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取某月违法案件集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseInfoEntity> GetIllegalCaseResult(IllegalCaseInfoEntity search, string startTime, string endTime)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            if (!string.IsNullOrEmpty(search.COMPANY_ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}=@p2", t => t.COMPANY_ID));
                args.Add(new { p2 = search.COMPANY_ID });
            }
            sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}>=@p3", t => t.CREATE_ON));
            args.Add(new { p3 = startTime });
            sbWhere.Append(Database.GetFormatSql<IllegalCaseInfoEntity>(" AND {0}<=@p4", t => t.CREATE_ON));
            args.Add(new { p4 = endTime });
            return WriteDatabase.Query<IllegalCaseInfoEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 删除违法案件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteIllegalCaseInfo(string Id)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET ROWSTATUS='{0}' WHERE ID='{1}'", (int)RowStatus.Delete, Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 直接结案
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EndIllegalCaseInfo(string Id)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET ISEND = 1 WHERE ID='{0}'", Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新案件状态
        /// </summary>
        /// <param name="Status">案件状态</param>
        /// <param name="PK_ID">案件主键</param>
        /// <returns></returns>
        public bool UpdateIllegalCaseStatus(string Status, string PK_ID)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET CASE_STATUS='{0}' WHERE ID='{1}'", Status, PK_ID);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新日期
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="Date"></param>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public bool UpdateIllegalCaseDate(string Status, string Date, string PK_ID)
        {
            var strSql = "";
            if (Status == "21")
            {
                strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET LASPDATE='{0}' WHERE ID='{1}'", Date, PK_ID);
            }
            else if (Status == "28")
            {
                strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET CFJDDATE='{0}' WHERE ID='{1}'", Date, PK_ID);
            }
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新案件状态
        /// </summary>
        /// <param name="Status">案件状态</param>
        /// <param name="PK_ID">案件主键</param>
        /// <returns></returns>
        public bool UpdateIllegalCaseNextStatus(string PK_ID)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET CASE_STATUS = CASE_STATUS + 1 WHERE ID='{0}'", PK_ID);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新案件实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateIllegalCase(IllegalCaseInfoEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.PLAN_FILE_NUMBER))
            {
                strSqlLink.AppendFormat(@" PLAN_FILE_NUMBER = '{0}',", search.PLAN_FILE_NUMBER);
            }
            if (!string.IsNullOrEmpty(search.PLAN_CUTOFF_DATE))
            {
                strSqlLink.AppendFormat(@" PLAN_CUTOFF_DATE = '{0}',", search.PLAN_CUTOFF_DATE);
            }
            if (!string.IsNullOrEmpty(search.PLAN_END_DATE))
            {
                strSqlLink.AppendFormat(@" PLAN_END_DATE = '{0}',", search.PLAN_END_DATE);
            }
            if (!string.IsNullOrEmpty(search.ISPUNISH))
            {
                strSqlLink.AppendFormat(@" ISPUNISH = '{0}',", search.ISPUNISH);
            }
            if (!string.IsNullOrEmpty(search.REPORT_NAME))
            {
                strSqlLink.AppendFormat(@" REPORT_NAME = '{0}',", search.REPORT_NAME);
            }
            if (!string.IsNullOrEmpty(search.REPORT_PHONE))
            {
                strSqlLink.AppendFormat(@" REPORT_PHONE = '{0}',", search.REPORT_PHONE);
            }
            if (!string.IsNullOrEmpty(search.CASE_SOURCES))
            {
                strSqlLink.AppendFormat(@" CASE_SOURCES = '{0}',", search.CASE_SOURCES);
            }
            if (!string.IsNullOrEmpty(search.RE_SOURCE_NAME))
            {
                strSqlLink.AppendFormat(@" RE_SOURCE_NAME = '{0}',", search.RE_SOURCE_NAME);
            }
            if (!string.IsNullOrEmpty(search.CASE_FACT))
            {
                strSqlLink.AppendFormat(@" CASE_FACT = '{0}',", search.CASE_FACT);
            }
            if (!string.IsNullOrEmpty(search.DETAIL_ADDRESS))
            {
                strSqlLink.AppendFormat(@" DETAIL_ADDRESS = '{0}',", search.DETAIL_ADDRESS);
            }
            if (!string.IsNullOrEmpty(search.REPORT_CASE_DATE))
            {
                strSqlLink.AppendFormat(@" REPORT_CASE_DATE = '{0}',", search.REPORT_CASE_DATE);
            }
            if (!string.IsNullOrEmpty(search.DEPT_KEY_ID))
            {
                strSqlLink.AppendFormat(@" DEPT_KEY_ID = '{0}',", search.DEPT_KEY_ID);
            }
            if (!string.IsNullOrEmpty(search.ZF_DEPT_NAME))
            {
                strSqlLink.AppendFormat(@" ZF_DEPT_NAME = '{0}',", search.ZF_DEPT_NAME);
            }
            if (!string.IsNullOrEmpty(search.HANDLE_ID))
            {
                strSqlLink.AppendFormat(@" HANDLE_ID = '{0}',", search.HANDLE_ID);
            }
            if (!string.IsNullOrEmpty(search.HANDLE_NAME))
            {
                strSqlLink.AppendFormat(@" HANDLE_NAME = '{0}',", search.HANDLE_NAME);
            }
            var strSql = string.Format(@"UPDATE ILLEGAL_CASEINFO SET {0} ROWSTATUS=1  WHERE ID='{1}'", strSqlLink, search.ID);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 按责任部门统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptStatisticsData()
        {
            try
            {
                var str = new StringBuilder("");
                str.Append(" SELECT * FROM (");
                str.AppendFormat(@" SELECT A.DEPT_KEY_ID,A.ZF_DEPT_NAME,(SELECT COUNT(*) FROM ILLEGAL_CASEINFO WHERE DEPT_KEY_ID=A.DEPT_KEY_ID) AS ALLCOUNT,
                (SELECT COUNT(*) FROM ILLEGAL_REMOVE  WHERE CASE_INFO_NO in (SELECT ID FROM ILLEGAL_CASEINFO where DEPT_KEY_ID=A.DEPT_KEY_ID)) AS REMOVECOUNT,
                (SELECT SUM(CAST(REMOVE_AREA AS INT)) FROM ILLEGAL_REMOVE WHERE CASE_INFO_NO in (SELECT ID FROM ILLEGAL_CASEINFO WHERE DEPT_KEY_ID=A.DEPT_KEY_ID)) AS AREA
                FROM ILLEGAL_CASEINFO A");
                str.Append(" GROUP BY A.DEPT_KEY_ID,A.ZF_DEPT_NAME) TB");
                return WriteDatabase.Query(str.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 按地域统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetAreaStatistics()
        {
            try
            {
                var str = new StringBuilder("");
                str.Append(" SELECT * FROM (");
                str.AppendFormat(@" SELECT A.SS_DISTRICT_ID,A.SS_DISTRICT_NAME,
                (SELECT COUNT(*) FROM ILLEGAL_CASEINFO WHERE SS_DISTRICT_ID=A.SS_DISTRICT_ID) AS FINDCOUNT,
                (SELECT COUNT(*) FROM ILLEGAL_VERIFY WHERE CASE_INFO_NO IN (SELECT ID FROM ILLEGAL_CASEINFO WHERE SS_DISTRICT_ID=A.SS_DISTRICT_ID)) AS VERIFYCOUNT
                FROM ILLEGAL_CASEINFO A");
                str.Append(" GROUP BY A.SS_DISTRICT_ID,A.SS_DISTRICT_NAME) TB");
                return WriteDatabase.Query(str.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
