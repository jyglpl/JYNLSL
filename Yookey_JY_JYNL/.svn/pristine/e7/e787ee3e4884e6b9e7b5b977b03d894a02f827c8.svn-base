using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    public class IllegalCaseAttachDal : BaseDal<IllegalCaseAttachEntity>
    {
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<IllegalCaseAttachEntity> GetAllResult(IllegalCaseAttachEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.GL_RESOURCE_ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} = @p1 ", t => t.GL_RESOURCE_ID));
                args.Add(new { p1 = search.GL_RESOURCE_ID });
            }
            if (!string.IsNullOrEmpty(search.FILE_RENAME))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} like '" + search.FILE_RENAME + "%' ", t => t.FILE_RENAME));
            }
            if (!string.IsNullOrEmpty(search.ENCLOSURE_TYPE))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} = @p2 ", t => t.ENCLOSURE_TYPE));
                args.Add(new { p2 = search.ENCLOSURE_TYPE });
            }
            sbWhere.Append(" ORDER BY ENCLOSURE_TYPE ");
            return WriteDatabase.Query<IllegalCaseAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<IllegalCaseAttachEntity> GetSearchResult(IllegalCaseAttachEntity search, List<string> types)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.GL_RESOURCE_ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} = @p1 ", t => t.GL_RESOURCE_ID));
                args.Add(new { p1 = search.GL_RESOURCE_ID });
            }
            if (!string.IsNullOrEmpty(search.FILE_RENAME))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} like '" + search.FILE_RENAME + "%' ", t => t.FILE_RENAME));
            }
            if (!string.IsNullOrEmpty(search.ENCLOSURE_TYPE))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} = @p2 ", t => t.ENCLOSURE_TYPE));
                args.Add(new { p2 = search.ENCLOSURE_TYPE });
            }
            if (types != null && types.Count > 0)
            {
                //sbWhere.Append(Database.GetFormatSql<IllegalCaseAttachEntity>(" and {0} in  (@p3) ", t => t.ENCLOSURE_TYPE));
                //args.Add(new { p3 = string.Join(",", types.ToArray()) });
                sbWhere.AppendFormat("and ENCLOSURE_TYPE in  ('{0}')", string.Join("','", types.ToArray()));
            }
            sbWhere.Append(" ORDER BY ENCLOSURE_TYPE ");
            return WriteDatabase.Query<IllegalCaseAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertIllegalCaseAttach(IllegalCaseAttachEntity search)
        {
            var strSql = string.Format(@"INSERT INTO ILLEGAL_CASE_ATTACH (ID,GL_RESOURCE_ID,FILE_NAME,FILE_RENAME,FILE_STATE,ENCLOSURE_SIZE,FILE_ADDRESS,EVIDENCE_DATE,ENCLOSURE_TYPE,FILE_TYPE_NAME,REMARK,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON) 
            VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", search.ID, search.GL_RESOURCE_ID, search.FILE_NAME, search.FILE_RENAME, search.FILE_STATE, search.ENCLOSURE_SIZE, search.FILE_ADDRESS, search.EVIDENCE_DATE, search.ENCLOSURE_TYPE, search.FILE_TYPE_NAME, search.REMARK, search.ROWSTATUS, search.CREATOR_ID, search.CREATE_BY, search.CREATE_ON, search.UPDATE_ID, search.UPDATE_BY, search.UPDATE_ON);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据主键更新附件
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateIllegalCaseAttach(string PK_ID)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASE_ATTACH SET ROWSTATUS='{0}' WHERE ID='{1}'", (int)RowStatus.Delete, PK_ID);
            return WriteDatabase.Execute(strSql);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public IllegalCaseAttachEntity searchEntity(string PK_ID)
        {
            var strSql = string.Format(@"SELECT * FROM ILLEGAL_CASE_ATTACH WHERE ID='{0}'", PK_ID);
            return WriteDatabase.Single<IllegalCaseAttachEntity>(strSql);
        }


        /// <summary>
        /// 根据主键更新附件备注
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateRemark(string PK_ID, string Remark)
        {
            var strSql = string.Format(@"UPDATE ILLEGAL_CASE_ATTACH SET REMARK='{0}' WHERE ID='{1}'", Remark, PK_ID);
            return WriteDatabase.Execute(strSql);
        }
    }
}
