using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Instrument;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.Business.Instrument
{
    /// <summary>
    /// WSTOCKCRECORD业务逻辑
    /// </summary>
    public class WSTOCKCRECORDBll : BaseBll<WSTOCKCRECORDEntity>
    {
        public WSTOCKCRECORDBll()
        {
            BaseDal = new WSTOCKCRECORDDal();
        }

        /// <summary>
        /// 保存文书入库主表
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public string SaveWSTOCKCRECORD(WSTOCKCRECORDEntity entity)
        {
            return new WSTOCKCRECORDDal().SaveWSTOCKCRECORD(entity);
        }
        public void InsertStock(List<string> sql)
        {
            new WSTOCKCRECORDDal().InsertStock(sql);
        }

    }
}
