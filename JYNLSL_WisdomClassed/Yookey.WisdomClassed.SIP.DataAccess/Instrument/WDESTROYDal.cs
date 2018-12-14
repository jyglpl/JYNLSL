using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess;
using Yookey.WisdomClassed.SIP.Model.Instrument;


namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WDESTROY数据访问操作
    /// </summary>
    public class WDESTROYDal :  DalImp.BaseDal<WDESTROYEntity>
    {
        public WDESTROYDal()
        {
            Model = new WDESTROYEntity();
        }
    }
}

