using DBHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WSTOCKCRECORD数据访问操作
    /// </summary>
    public class WSTOCKCRECORDDal : DalImp.BaseDal<WSTOCKCRECORDEntity>
    {
        public WSTOCKCRECORDDal()
        {
            Model = new WSTOCKCRECORDEntity();
        }
        /// <summary>
        /// 入库子表中插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string SaveWSTOCKCRECORD(WSTOCKCRECORDEntity entity)
        {
            string sql = string.Format("insert into WSTOCKCRECORD values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}',{8},null,'{9}','{10}','{11}','{12}','{13}')",
                entity.Id, entity.CHILDID, entity.RECORDID, entity.WSTYPE, entity.BCOUNT, entity.WCOUNT, entity.WSTARTNO, entity.WENDNO,
                entity.RowStatus, entity.CreatorId, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);
            return sql;
        }
        /// <summary>
        /// 添加文书库存（库存主表，库存子表，中队或大队库存明细表）
        /// </summary>
        /// <param name="sql">添加的查询语句</param>
        /// <returns>int影响的行数</returns>
        public void InsertStock(List<string> sql)
        {

           SqlHelper.ExecuteSqlTran(SqlHelper.SqlConnStringWrite,sql);
        }
    }
}
