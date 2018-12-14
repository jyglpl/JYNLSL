using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WUSERECORD数据访问操作
    /// </summary>
    public class WUSERECORDDal : DalImp.BaseDal<WUSERECORDEntity>
    {
        public WUSERECORDDal()
        {
            Model = new WUSERECORDEntity();
        }
    }
}

