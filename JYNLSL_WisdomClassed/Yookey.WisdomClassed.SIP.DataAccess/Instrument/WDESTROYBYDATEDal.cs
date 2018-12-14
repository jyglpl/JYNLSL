using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WDESTROYBYDATE数据访问操作
    /// </summary>
    public class WDESTROYBYDATEDal : DalImp.BaseDal<WDESTROYBYDATEEntity>
    {
        public WDESTROYBYDATEDal()
        {
            Model = new WDESTROYBYDATEEntity();
        }
    }
}
