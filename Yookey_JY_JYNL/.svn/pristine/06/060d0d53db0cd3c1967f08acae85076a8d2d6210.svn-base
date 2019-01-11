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
    /// WDEPTSTORAGE数据访问操作
    /// </summary>
    public class WDEPTSTORAGEDal : DalImp.BaseDal<WDEPTSTORAGEEntity>
    {
        public WDEPTSTORAGEDal()
        {
            Model = new WDEPTSTORAGEEntity();
        }

        /// <summary>
        /// 向WdeptStorage入库表中插入数据的SQL语句
        /// </summary>
        /// <param name="_WDEPTSTORAGE"></param>
        /// <returns></returns>
        public string InsertWDpetSQL(WDEPTSTORAGEEntity _WDEPTSTORAGE)
        {
            try
            {
                string sql = string.Format(@"insert into WDEPTSTORAGE ([Id]
           ,[AUTOID]
           ,[WSTYPE]
           ,[RECORDID]
           ,[INVALID]
           ,[DESID]
           ,[USEID]
           ,[DEPTID]
           ,[WSNO]
           ,[LYPID]
           ,[WSTATE]
           ,[ISDESTROY]
           ,[RowStatus]
           , Version
           ,[CreatorId]
           ,[CreateBy]
           ,[CreateOn]
           ,[UpdateId]
           ,[UpdateBy]
           ,[UpdateOn]) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10}, {11} ,{12},NULL,'{13}','{14}','{15}','{16}','{17}','{18}') ",
                    _WDEPTSTORAGE.Id, _WDEPTSTORAGE.AUTOID, _WDEPTSTORAGE.WSTYPE, _WDEPTSTORAGE.RECORDID, _WDEPTSTORAGE.INVALID,
                    _WDEPTSTORAGE.DESID, _WDEPTSTORAGE.USEID, _WDEPTSTORAGE.DEPTID, _WDEPTSTORAGE.WSNO, _WDEPTSTORAGE.LYPID, _WDEPTSTORAGE.WSTATE, _WDEPTSTORAGE.ISDESTROY,
                    _WDEPTSTORAGE.RowStatus, _WDEPTSTORAGE.CreatorId, _WDEPTSTORAGE.CreateBy, _WDEPTSTORAGE.CreateOn, _WDEPTSTORAGE.UpdateId,
                    _WDEPTSTORAGE.UpdateBy, _WDEPTSTORAGE.UpdateOn);
                return sql;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 查询文书编号是否存在，或者被领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <param name="wcount">张数</param>
        /// <returns></returns>
        public DataTable IsExitWDEPTSTORAGE(string startno, string endno, string wtype, string DeptId)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select count(*) num  from (");
                sql.Append(" select wstype,recordid,wsno,wstate,isdestroy");
                sql.Append("  from WDEPTSTORAGE ");
                sql.AppendFormat(" where wsno between '{0}' and '{1}' and wstype='{2}' and wstate=0 AND Deptid='{3}' ", startno, endno, wtype, DeptId);
                sql.AppendFormat(" ) TB where TB.isdestroy=0");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 更改入库表中的号码为领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <returns></returns>
        public bool UpdateWDEPTSTORAGE(string startno, string endno, string wtype, string recordid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(" update WDEPTSTORAGE set wstate=3,LYPID='{0}' where wsno between '{1}' and '{2}' and wstype='{3}'", recordid, startno, endno, wtype);
                sql.AppendFormat(" and isdestroy=0");
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sql.ToString()) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
