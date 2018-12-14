using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    public class IllegalCaseVerifyDal : BaseDal<IllegalCaseVerifyEntity>
    {
        /// <summary>
        /// 获取违法案件核实信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseVerifyEntity> GetIllegalCaseResult(IllegalCaseVerifyEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<IllegalCaseVerifyEntity>("Where {0}=1 ", u => u.ROWSTATUS));
            if (!string.IsNullOrEmpty(search.ID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseVerifyEntity>(" AND {0}=@p1", t => t.ID));
                args.Add(new { p1 = search.ID });
            }
            if (!string.IsNullOrEmpty(search.CASE_INFO_NO))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseVerifyEntity>(" AND {0} =@p2", t => t.CASE_INFO_NO));
                args.Add(new { p2 = search.CASE_INFO_NO });
            }
            if (!string.IsNullOrEmpty(search.BUILDTYPEID))
            {
                sbWhere.Append(Database.GetFormatSql<IllegalCaseVerifyEntity>(" AND {0} =@p3", t => t.BUILDTYPEID));
                args.Add(new { p3 = search.BUILDTYPEID });
            }
            return WriteDatabase.Query<IllegalCaseVerifyEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增违法案件核实信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalVerifyInfo(IllegalCaseVerifyEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO ILLEGAL_VERIFY (ID,CASE_INFO_NO,LONG,WIDE,HIGH,BUILDTYPEID,BUILDTYPE,STRUCTUREID,STRUCTURE,COVERSAREA,BUILDAREA,DESCRIBE,VERIFYTIME,VERIFYSTATE,VERIFYRESULTS,ROWSTATUS,CREATOR_ID,CREATE_BY,CREATE_ON,UPDATE_ID,UPDATE_BY,UPDATE_ON,BUILDTIME,VERIFYTENDIME) 
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')",
            entity.ID, entity.CASE_INFO_NO, entity.LONG, entity.WIDE, entity.HIGH, entity.BUILDTYPEID, entity.BUILDTYPE, entity.STRUCTUREID, entity.STRUCTURE, entity.COVERSAREA, entity.BUILDAREA, entity.DESCRIBE, entity.VERIFYTIME, entity.VERIFYSTATE, entity.VERIFYRESULTS, entity.ROWSTATUS, entity.CREATOR_ID, entity.CREATE_BY, entity.CREATE_ON, entity.UPDATE_ID, entity.UPDATE_BY, entity.UPDATE_ON, entity.BUILDTIME, entity.VERIFYTENDIME);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
