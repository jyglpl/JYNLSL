using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WSTOCKTABLE数据访问操作
    /// </summary>
    public class WSTOCKRECORDDal : DalImp.BaseDal<WSTOCKRECORDEntity>
    {
        public WSTOCKRECORDDal()
        {
            Model = new WSTOCKRECORDEntity();
        }
        /// <summary>
        /// 入库记录主表中插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string SaveWSTOCKRECOR(WSTOCKRECORDEntity entity)
        {
            string sql = string.Format("insert into WStockRecord values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7},null,'{8}','{9}','{10}','{11}','{12}')",
                entity.Id, entity.RECORDID, entity.TITLE, entity.DEPTID, entity.ISUNIT, entity.CREATEBY, entity.CREATEDATE, entity.RowStatus, entity.CreatorId, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);
            return sql;
        }


        /// <summary>
        /// 判断入库子表中是否已经存在相同的入库记录
        /// </summary>
        /// <param name="StarNo">开始编号</param>
        /// <param name="EndNo">结束编号</param>
        /// <param name="WSType">文书类别</param>
        /// <returns></returns>
        public bool GetStockAdd(string StarNo, string EndNo, string WSType, string Year)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"select * from (
select childid,recordid,wstype,bcount,wcount,wstartno,wendno,
CONVERT(varchar(100),(select CreateOn from wstockrecord  where wstockrecord.recordid=WStockCRecord.recordid), 120) CreateOn
from WStockCRecord where 
(convert(int,'{0}')  between WStartNo and WEndNo) or ( convert(int,'{1}')  between WStartNo and WEndNo)
 ) tb where  YEAR(tb.CreateOn)='2018' and wstype = '{2}'", StarNo, EndNo, WSType);
            object obj = SqlHelper.ExecuteScalar (SqlHelper.SqlConnStringRead, CommandType.Text, sql.ToString());
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool GetStockZDAdd(string StarNo, string EndNo, string WSType, string Year)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from (");
            sql.Append(" select  WC.childid,WC.recordid,WC.wstype,WC.bcount,WC.wcount,WC.wstartno,WC.wendno,CONVERT(varchar(100),WR.createdate,120) createdate");
            sql.Append(" from WStockCRecord WC inner join WStockRecord WR");
            sql.Append(" on WC.RecordID = WR.RecordID where IsUnit=1 ");
            sql.AppendFormat(" and WC.wstype = '{0}'", WSType);
            sql.AppendFormat(" and (( convert(int,'{0}') between WC.WStartNo and WC.WEndNo) or ( convert(int,'{1}') between WC.WStartNo and WC.WEndNo)", StarNo, EndNo);
            sql.AppendFormat(" or ( convert(int,'{0}')< convert(int,WC.WStartNo) ", StarNo);
            sql.AppendFormat(" and  convert(int,'{0}')> convert(int,WC.WEndNo)))", EndNo);
            sql.AppendFormat(" ) TB where TB.createdate='{0}'", Year);
            object obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sql.ToString());
            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
