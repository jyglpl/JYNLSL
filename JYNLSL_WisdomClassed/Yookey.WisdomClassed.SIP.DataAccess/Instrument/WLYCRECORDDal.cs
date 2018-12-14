using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WLYCRECORD数据访问操作
    /// </summary>
    public class WLYCRECORDDal : DalImp.BaseDal<WLYCRECORDEntity>
    {
        public WLYCRECORDDal()
        {
            Model = new WLYCRECORDEntity();
        }

        /// <summary>
        /// 向人员总分配表中插入分配记录

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertWLYCRECORD(WLYCRECORDEntity model)
        {
            string sql = string.Format(@"insert into WLYCRECORD (Id, AUTOID, RECORDID, WSTYPE, DEPTID, WCOUNT, WSTARTNO, WENDNO, WUSER, WCREATEDATE, RowStatus, Version, CreatorId, CreateBy, CreateOn, UpdateId, UpdateBy, UpdateOn) values
                ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}',{10},null,'{11}','{12}','{13}','{14}','{15}','{16}')",
             model.Id, model.AUTOID, model.RECORDID, model.WSTYPE, model.DEPTID, model.WCOUNT, model.WSTARTNO, model.WENDNO, model.WUSER,
             model.WCREATEDATE, model.RowStatus, model.CreatorId, model.CreateBy, model.CreateOn, model.UpdateId, model.UpdateBy, model.UpdateOn);
            return sql;
        }
    }
}

