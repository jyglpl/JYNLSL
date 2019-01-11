using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Instrument;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.Business.Instrument
{
    /// <summary>
    /// WLYCRECORD业务逻辑
    /// </summary>
    public class WLYCRECORDBll : BaseBll<WLYCRECORDEntity> 
    {
        public WLYCRECORDBll()
        {
            BaseDal = new WLYCRECORDDal();
        }
        /// <summary>
        /// 向人员总分配表中插入分配记录

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertWLYCRECORD(WLYCRECORDEntity model)
        {
            return new WLYCRECORDDal().InsertWLYCRECORD(model);
        }
    }
}
