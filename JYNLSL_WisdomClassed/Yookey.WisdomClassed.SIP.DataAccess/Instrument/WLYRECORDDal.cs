using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WLYRECORD数据访问操作
    /// </summary>
    public class WLYRECORDDal : DalImp.BaseDal<WLYRECORDEntity>
    {
        public WLYRECORDDal()
        {
            Model = new WLYRECORDEntity();
        }
    }
}

