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
    /// WUSERECORD业务逻辑
    /// </summary>
    public class WUSERECORDBll : BaseBll<WUSERECORDEntity> 
    {
        public WUSERECORDBll()
        {
            BaseDal = new WUSERECORDDal();
        }
    }
}
