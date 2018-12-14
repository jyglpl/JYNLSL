using DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WBRIGADE数据访问操作
    /// </summary>
    public class WBRIGADEDal : DalImp.BaseDal<WBRIGADEEntity>
    {
        public WBRIGADEDal()
        {
            Model = new WBRIGADEEntity();
        }
        /// <summary>
        /// 插入需要分配给队员的文书编号信息
        /// </summary>
        /// <returns></returns>
        public string InsertWBRIGADE(WBRIGADEEntity Entity)
        {

            try
            {
                string sql = string.Format(@" INSERT INTO  [dbo].[WBRIGADE]  VALUES 
              ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}',{9},{10},null,'{11}','{12}','{13}','{14}','{15}','{16}')", Entity.Id,
               Entity.AUTOID, Entity.WSTYPE, Entity.RECORDID, Entity.WSNO, Entity.WSTATE, Entity.USERS, Entity.USEDATE, Entity.WCREATEDATE,
               Entity.ISDESTROY, Entity.RowStatus, Entity.CreatorId, Entity.CreateBy,
               Entity.CreateOn, Entity.UpdateId, Entity.UpdateBy, Entity.UpdateOn);
                return sql;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 更新分配给人员的文书编号的文书状态

        /// </summary>
        /// <param name="recordid"></param>
        /// <param name="wstype"></param>
        /// <param name="wsno"></param>
        /// <returns></returns>
        public string UpdateWZDstorage(string recordid, string wstype, string wsno)
        {
            string sql = string.Format("Update WZDSTORAGE set wstate=3 where recordid='{0}' and wstype='{1}' and wsno='{2}'", recordid, wstype, wsno);
            return sql;
        }

        /// <summary>
        /// 执行多条SQL语句
        /// </summary>
        /// <param name="sql">添加的查询语句</param>
        /// <returns>int影响的行数</returns>
        public void InsertAdd(List<string> sql)
        {
            SqlHelper.ExecuteSqlTran(SqlHelper.SqlConnStringWrite, sql);
        }


       

    }
}