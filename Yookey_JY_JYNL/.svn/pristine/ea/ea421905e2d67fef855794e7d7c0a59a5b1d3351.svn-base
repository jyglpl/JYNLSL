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
    /// WSTOCKTABLE业务逻辑
    /// </summary>
    public class WSTOCKTABLEBll : BaseBll<WSTOCKTABLEEntity> 
    {
        public WSTOCKTABLEBll()
        {
            BaseDal = new WSTOCKTABLEDal();
        }
        public string UpdateWSTOCKTABLE(int count, int count1, string wrscode)
        {
            return new WSTOCKTABLEDal().UpdateWSTOCKTABLE(count, count1, wrscode);
        }
    }
}
