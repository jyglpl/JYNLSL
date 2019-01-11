using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    public class IllegalCaseRemoveDal : BaseDal<IllegalCaseRemoveEntity>
    {
        /// <summary>
        /// 获取违法案件违法拆除信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseRemoveEntity> GetIllegalCaseResult(IllegalCaseRemoveEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<IllegalCaseRemoveEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseRemoveEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            if (!string.IsNullOrEmpty(search.CASE_INFO_NO))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseRemoveEntity>(" AND {0} =@p2", t => t.CASE_INFO_NO));
                args.Add(new { p2 = search.CASE_INFO_NO });
            }
            return WriteDatabase.Query<IllegalCaseRemoveEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增违法案件违法拆除信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalRemoveInfo(IllegalCaseRemoveEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO ILLEGAL_REMOVE (ID,CASE_INFO_NO,REMOVE_FINISH_DATE,KEEP_GARBAGE,REMOVE_AREA,REMOVAL_METHOD_ID,REMOVAL_METHOD_NAME,REMOVE_NO,REMOVE_DESCRIPTION,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON) 
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')",
            entity.ID, entity.CASE_INFO_NO, entity.REMOVE_FINISH_DATE, entity.KEEP_GARBAGE, entity.REMOVE_AREA, entity.REMOVAL_METHOD_ID, entity.REMOVAL_METHOD_NAME, entity.REMOVE_NO, entity.REMOVE_DESCRIPTION, entity.ROWSTATUS, entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
