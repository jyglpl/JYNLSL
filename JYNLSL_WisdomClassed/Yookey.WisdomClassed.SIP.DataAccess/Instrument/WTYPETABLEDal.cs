using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;
using Yookey.WisdomClassed.SIP.DataAccess;
using System.Data;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// W_TYPETABLE数据访问操作
    /// </summary>
    public class W_TYPETABLEDal : DalImp.BaseDal<W_TYPETABLEEntity>
    {
        public W_TYPETABLEDal()
        {
            Model = new W_TYPETABLEEntity();
        }
        /// <summary>
        /// 文书类型
        /// 添加日期：2017-03-13
        /// 添加人：叶念
        /// </summary>
        /// <param name="WRsCode">文书类型</param>
        /// <returns></returns>
        public DataTable GetWTypeByWRsCode(string WRsCode)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@" select Id, WRSCODE,WRSKEY,WCOUNT,WSAFECOUNT,CHECKCOUNT,WSTATE from W_TYPETABLE WHERE RowStatus=1 and WRsCode='{0}'  order by W_TYPETABLE.wrscode ", WRsCode);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public DataTable QueryTypeTable(string sidx, string sord, int pageSize,
                                                            int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("select  * from W_TYPETABLE where rowstatus=1");
                var sortField = "WRSCODE";   //排序字段
                var sortType = "DESC";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 批量删除文书类型
        /// </summary>
        /// <param name="ids">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE W_TYPETABLE SET RowStatus =0 WHERE Id IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()) > 0;
        }



    }
}
