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
    /// WZDSTORAGE数据访问操作
    /// </summary>
    public class WZDSTORAGEDal : DalImp.BaseDal<WZDSTORAGEEntity>
    {
        public WZDSTORAGEDal()
        {
            Model = new WZDSTORAGEEntity();
        }

        /// <summary>
        /// 大队入库主表
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public string InsertWZDSTORAGE(WZDSTORAGEEntity Entity)
        {
            try
            {
                string sql = string.Format(@"insert into WZDSTORAGE ([Id]
           ,[AUTOID]
           ,[WSTYPE]
           ,[RECORDID]
           ,[INVALID]
           ,[DESID]
           ,[USEID]
           ,[DEPTID]
           ,[WSNO]
           ,[WSTATE]
           ,[ISDESTROY]
           ,[RowStatus]
           , Version
           ,[CreatorId]
           ,[CreateBy]
           ,[CreateOn]
           ,[UpdateId]
           ,[UpdateBy]
           ,[UpdateOn]) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10}, {11} ,NULL,'{12}','{13}','{14}','{15}','{16}','{17}') ",
                    Entity.Id, Entity.AUTOID, Entity.WSTYPE, Entity.RECORDID, Entity.INVALID,
                    Entity.DESID, Entity.USEID, Entity.DEPTID, Entity.WSNO, Entity.WSTATE, Entity.ISDESTROY,
                    Entity.RowStatus, Entity.CreatorId, Entity.CreateBy, Entity.CreateOn, Entity.UpdateId,
                    Entity.UpdateBy, Entity.UpdateOn);
                return sql;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 获得分配给中队的文书编号是否可以领用
        /// </summary>
        /// <param name="deptid">部门编号</param>
        /// <param name="startno">开始号</param>
        /// <param name="endno">结束号</param>
        /// <returns></returns>
        public DataTable IsGet(  string startno, string endno, string wtype,string DeptId)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select count(*) num from (");
                sql.Append(" select ws.deptid,ws.wsno,ws.wstate,ws.wstype,isdestroy ");
                sql.Append(" from WZDSTORAGE ws");
                sql.Append(" inner join wstockrecord wr on ws.recordid=wr.recordid");
                sql.AppendFormat(" ) TB  where TB.deptid='{0}'", DeptId);
                sql.AppendFormat(" and TB.wsno between '{0}' and '{1}' and TB.wstype='{2}'  ", startno, endno, wtype);
                sql.AppendFormat(" and TB.wstate=0 and TB.isdestroy=0");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        ///  获得需要分配给队员的文书编号信息

        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="startno"></param>
        /// <param name="endno"></param>
        /// <param name="wtype"></param>
        /// <returns></returns>
        public DataTable InsertUseWsno(string deptid, string startno, string endno, string wtype)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select * from (");
                sql.Append(" select ws.recordid,ws.deptid,ws.wsno,ws.wstate,ws.wstype,isdestroy ");
                sql.Append(" from WZDSTORAGE ws");
                sql.Append(" inner join wstockrecord wr on ws.recordid=wr.recordid");
                sql.AppendFormat(" ) TB  where TB.deptid='{0}'", deptid);
                sql.AppendFormat(" and TB.wsno between '{0}' and '{1}' and TB.wstype='{2}'", startno, endno, wtype);
                sql.AppendFormat(" and TB.wstate=0 and TB.isdestroy=0 order by TB.wsno");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}

