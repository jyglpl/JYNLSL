using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WUNITSTORAGE数据访问操作
    /// </summary>
    public class WUNITSTORAGEDal : DalImp.BaseDal<WUNITSTORAGEEntity>
    {
        public WUNITSTORAGEDal()
        {
            Model = new WUNITSTORAGEEntity();
        }
        /// <summary>
        /// 大队入库主表
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public string InsertWUNITSTORAGE(WUNITSTORAGEEntity Entity)
        {
            string sql = string.Format(@"insert into WUNITSTORAGE values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',
            '{8}', {9} , {10} , {11} ,null,'{12}','{13}','{14}','{15}','{16}')",
                Entity.Id, Entity.AUTOID, Entity.WSTYPE, Entity.RECORDID, Entity.INVALID, Entity.DESID, Entity.LYPID, Entity.UNIT, Entity.WSNO,
             Entity.WSTATE, Entity.ISDESTROY, Entity.RowStatus, Entity.CreatorId, Entity.CreateOn, Entity.UpdateId, Entity.UpdateBy, Entity.UpdateOn);
            return sql;

        }

        /// <summary>
        /// 查询文书编号是否存在，或者被领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <param name="wcount">张数</param>
        /// <returns></returns>
        public DataTable IsExitWUNITSTORAGE(string startno, string endno, string wtype)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select count(*) num  from (");
                sql.Append(" select wstype,recordid,lypid,unit,wsno,wstate,isdestroy");
                sql.Append("  from WUnitStorage ");
                sql.AppendFormat(" where wsno between '{0}' and '{1}' and wstype='{2}' and wstate=0", startno, endno, wtype);
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
        public bool UpdateWUNITSTORAGE(string startno, string endno, string wtype, string recordid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(" update WUnitStorage set wstate=3,lypid='{0}' where wsno between '{1}' and '{2}' and wstype='{3}'", recordid, startno, endno, wtype);
                sql.AppendFormat(" and isdestroy=0");
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sql.ToString()) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable GetInstrumentList(string startno, string endno, string deptid, string wtype, string sidx, string sord, int pageSize,
                                                               int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select recordid Id,createdate,wstype,bcount,wcount,wstartno,wendno,deptid,LYNum,SYNum,KCNum,HXNum,
(select FullName from CrmCompany od where tb.deptid=od.id) deptname,
(select wrskey from w_typetable wp where wp.wrscode=tb.wstype) wstypec
from (
 select deptid,recordid,createdate,
  (select wstype from wstockcrecord wc where wc.recordid=wr.recordid) wstype,
  (select bcount from wstockcrecord wc where wc.recordid=wr.recordid) bcount,
  (select wcount from wstockcrecord wc where wc.recordid=wr.recordid) wcount,
   (select wstartno from wstockcrecord wc where wc.recordid=wr.recordid) wstartno,
    (select wendno from wstockcrecord wc where wc.recordid=wr.recordid) wendno,
    (select count(*) from WDEPTSTORAGE wu where wu.recordid=wr.recordid and wu.wstate=3) LYNum,
    ((select wcount from wstockcrecord wc where wc.recordid=wr.recordid)-
     (select count(*) from WDEPTSTORAGE wu where wu.recordid=wr.recordid and wu.wstate=3)) KCNum,
     (select count(*) from wdeptstorage ws where ws.recordid=wr.recordid and wstate=3) SYNum,
     (select count(*) from WDEPTSTORAGE wu where wu.recordid=wr.recordid and isdestroy=1) HXNum
      from wstockrecord wr where isunit=1) tb where 1=1");
                if (!string.IsNullOrEmpty(deptid) && !deptid.Equals("all"))
                {
                    strSql.Append(@" AND  deptid ='" + deptid + "'  ");
                }

                if (startno != "" && endno != "" && startno != null && endno != null)
                {
                    strSql.Append(" and tb.wstartno='" + startno + "' and tb.wendno='" + endno + "' ");
                }
                if (wtype != null && wtype != "")
                {
                    strSql.Append(" and tb.wstype='" + wtype + "'");
                }
                var sortField = "createdate";   //排序字段
                var sortType = "DESC";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 中队领用查询
        /// </summary>
        /// <param name="startno"></param>
        /// <param name="endno"></param>
        /// <param name="deptid"></param>
        /// <param name="wtype"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryZDInstrumentList(string startno, string endno, string deptid, string wtype, string sidx, string sord, int pageSize,
                                                               int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select recordid Id,createdate,wstype,bcount,wcount,wstartno,wendno,deptid,LYNum,SYNum,KCNum,HXNum,
(select FullName from CrmDepartment od where tb.deptid=od.id) deptname,
(select wrskey from w_typetable wp where wp.wrscode=tb.wstype) wstypec
from (
 select deptid,recordid,createdate,
  (select wstype from wstockcrecord wc where wc.recordid=wr.recordid) wstype,
  (select bcount from wstockcrecord wc where wc.recordid=wr.recordid) bcount,
  (select wcount from wstockcrecord wc where wc.recordid=wr.recordid) wcount,
   (select wstartno from wstockcrecord wc where wc.recordid=wr.recordid) wstartno,
    (select wendno from wstockcrecord wc where wc.recordid=wr.recordid) wendno,
    (select count(*) from WZDSTORAGE wu where wu.recordid=wr.recordid and wu.wstate=3) LYNum,
    ((select wcount from wstockcrecord wc where wc.recordid=wr.recordid)-
     (select count(*) from WZDSTORAGE wu where wu.recordid=wr.recordid and wu.wstate=3)) KCNum,
     (select count(*) from WZDSTORAGE ws where ws.recordid=wr.recordid and wstate=3) SYNum,
     (select count(*) from WZDSTORAGE wu where wu.recordid=wr.recordid and isdestroy=1) HXNum
      from wstockrecord wr   where isunit=0 ) tb where 1=1");
                if (!string.IsNullOrEmpty(deptid) && !deptid.Equals("all"))
                {
                    strSql.Append(@" AND  deptid ='" + deptid + "'  ");
                }

                if (startno != "" && endno != "" && startno != null && endno != null)
                {
                    strSql.Append(" and tb.wstartno='" + startno + "' and tb.wendno='" + endno + "' ");
                }
                if (wtype != null && wtype != "")
                {
                    strSql.Append(" and tb.wstype='" + wtype + "'");
                }
                var sortField = "createdate";   //排序字段
                var sortType = "DESC";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




        public DataTable QueryGRInstrumentList(string startno, string endno, string deptid, string userid, string wtype, string sidx, string sord, int pageSize,
                                                               int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select wcreatedate,(select FullName from CrmDepartment where CrmDepartment.id=deptid) deptname,deptid,
          (select wrskey from w_typetable where w_typetable.wrscode=wlycrecord.wstype) wtypec,
          wstype,wcount,wstartno,wendno,
          (select RealName from CrmUser where CrmUser.id=wlycrecord.wuser) uname,wuser,
           (select count(*) from wbrigade where wbrigade.recordid=wlycrecord.recordid 
           and wbrigade.users=wlycrecord.wuser and wbrigade.wstate=3 and wsno between wlycrecord.wstartno and wlycrecord.wendno) UseNum,
            (select count(*) from wbrigade where wbrigade.recordid=wlycrecord.recordid and wbrigade.isdestroy=1) HXNum
       from wlycrecord where 1=1");
                if (!string.IsNullOrEmpty(deptid) && !deptid.Equals("all"))
                {
                    strSql.Append(@" AND  deptid ='" + deptid + "'  ");
                }

                if (!string.IsNullOrEmpty(userid))
                {
                    strSql.Append(@" AND  wuser ='" + userid + "'  ");
                }
                if (startno != "" && endno != "" && startno != null && endno != null)
                {
                    strSql.Append(" and  wstartno='" + startno + "' and  wendno='" + endno + "' ");
                }
                if (wtype != null && wtype != "")
                {
                    strSql.Append(" and  wstype='" + wtype + "'");
                }
                var sortField = "wcreatedate";   //排序字段
                var sortType = "DESC";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




        public DataTable QueryInstrumentSearch(string startno, string endno, string deptid, string userid, string wtype, string starttime, string endtime, string type, string sidx, string sord, int pageSize,
                                                               int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@" select * ,(select wrskey from w_typetable where w_typetable.wrscode=tb.wstype) wtypec from (select tb.Id, CrmDepartment.id deptid,CrmDepartment.FullName deptpname , tb.wsno as QHCOUNT,createdate 
 as stime,wstype, (case wstate when 0 then '未领用' else '已领用' end) LState, (case isnull(UseState,0) 
 when 0 then '未使用' else '已使用' end) state,isnull((select RealName from CrmUser where tb.users=CrmUser.id),' ') 
 UserName,isnull(Users,' ') Users,(case isdestroy when 1 then '已核销' else '-' end) destroystate from  ( 
 select  WZDSTORAGE.id ,WZDSTORAGE.deptid,wsno,createdate,wstate,wstype,isdestroy, (select wstate from wbrigade where
  wbrigade.recordid=WZDSTORAGE.recordid and wbrigade.wsno=WZDSTORAGE.wsno) UseState,
   (select Users from wbrigade where wbrigade.recordid=WZDSTORAGE.recordid and wbrigade.wsno=WZDSTORAGE.wsno)
    Users, (select isdestroy from wbrigade where wbrigade.recordid=WZDSTORAGE.recordid
     and wbrigade.wsno=WZDSTORAGE.wsno) destroystate from WZDSTORAGE inner join wstockrecord 
     on WZDSTORAGE.recordid=wstockrecord.recordid   ) tb   inner join CrmDepartment on 
     tb.deptid=CrmDepartment.id 
      ) tb where 1=1   ");
                if (startno != "" && endno != "" && startno != null && endno != null)
                {
                    strSql.Append(" and QHCOUNT between '" + startno + "' and '" + endno + "' and wstype='" + wtype + "'");
                }
                if (startno != "" && endno == "" || endno != "" && startno == "" || startno != null && endno == null || endno != null && startno == null)
                {
                    if (startno != "" && startno != null)
                    {
                        strSql.Append(" and QHCOUNT = '" + startno + "' and wstype='" + wtype + "'");
                    }
                    if (endno != "" && endno != null)
                    {
                        strSql.Append(" and QHCOUNT = '" + endno + "' and wstype='" + wtype + "'");
                    }
                }
                if (type == "0")
                {
                    strSql.Append(" and state='未使用'");
                }
                if (userid != "" && userid != null)
                {
                    strSql.Append(" and Users='" + userid + "'");
                }
                if (!string.IsNullOrEmpty(deptid) && !deptid.Equals("all"))
                {
                    strSql.Append(" and deptid='" + deptid + "'");
                }
                if (wtype != "" && wtype != null)
                {
                    strSql.Append(" and wstype='" + wtype + "'");
                }

                var sortField = "QHCOUNT";   //排序字段
                var sortType = "asc";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable QueryInstrumentSearchKC(string startno, string endno,  string wtype, string sidx, string sord, int pageSize,
                                                              int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"   select recordid Id,createdate,wstype,bcount,wcount,wstartno,wendno,deptid,LYNum,SYNum,KCNum,HXNum,
(select FullName from CrmCompany od where tb.deptid=od.id) deptname,
(select wrskey from w_typetable wp where wp.wrscode=tb.wstype) wstypec
from (
 select deptid,recordid,createdate,
  (select wstype from wstockcrecord wc where wc.recordid=wr.recordid) wstype,
  (select bcount from wstockcrecord wc where wc.recordid=wr.recordid) bcount,
  (select wcount from wstockcrecord wc where wc.recordid=wr.recordid) wcount,
   (select wstartno from wstockcrecord wc where wc.recordid=wr.recordid) wstartno,
    (select wendno from wstockcrecord wc where wc.recordid=wr.recordid) wendno,
    (select count(*) from wunitstorage wu where wu.recordid=wr.recordid and wu.wstate=3) LYNum,
    ((select wcount from wstockcrecord wc where wc.recordid=wr.recordid)-
     (select count(*) from wunitstorage wu where wu.recordid=wr.recordid and wu.wstate=3)) KCNum,
     (select count(*) from wunitstorage ws where ws.recordid=wr.recordid and wstate=3) SYNum,
     (select count(*) from wunitstorage wu where wu.recordid=wr.recordid and isdestroy=1) HXNum
      from wstockrecord wr   where isunit=-1 ) tb where 1=1");
                if (!string.IsNullOrEmpty(startno ) && !string.IsNullOrEmpty(endno))
                {
                    strSql.Append(" and  wstartno='" + startno + "' and  wendno='" + endno + "' ");
                }
                if (!string.IsNullOrEmpty(wtype))
                {
                    strSql.Append(" and  wstype='" + wtype + "'");
                }
                var sortField = "createdate";   //排序字段
                var sortType = "DESC";        //排序类型
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
       /// <summary>
       /// 获取文书库存
       /// </summary>
       /// <param name="wsTypts">文书类型ID</param>
        /// <param name="StorageType">部门</param>WDEPTSTORAGE
       /// <returns></returns>
        public Tuple<DataTable,int> GetStorageSelect(string wsTypts, string StorageType,string deptId,string daduiId)
        {
            var strBulid = new StringBuilder();
            if (StorageType.Equals("WZDSTORAGE"))//是个人
            {
                strBulid.AppendFormat("select wsno from WZDSTORAGE wz inner join wstockrecord ws on ws.recordid=wz.recordid and ws.DEPTID='{0}' and wz.WSTYPE='{1}' and wz.WSTATE=0 order by wz.wsno", deptId, wsTypts);
            }
            else if (StorageType.Equals("WDEPTSTORAGE"))//是中队
            {
                strBulid.AppendFormat("select wsno from WDEPTSTORAGE wz inner join wstockrecord ws on ws.recordid=wz.recordid and ws.DEPTID='{0}' and wz.WSTYPE='{1}' and wz.WSTATE=0 order by wz.wsno", daduiId, wsTypts);
            }
            else
            {
                strBulid.AppendFormat("select wsno from {0}  where wstype='{1}' and WSTATE=0 order by wsno", StorageType, wsTypts);
            }
            var table = new DataTable();
            table=SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBulid.ToString()).Tables[0];
            strBulid=new StringBuilder();
            strBulid.AppendFormat("select WCOUNT from w_typetable where WRSCODE='{0}'", wsTypts);
            var count=Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead,CommandType.Text,strBulid.ToString()));
            return new Tuple<DataTable, int>(table, count);
        }

    }
}