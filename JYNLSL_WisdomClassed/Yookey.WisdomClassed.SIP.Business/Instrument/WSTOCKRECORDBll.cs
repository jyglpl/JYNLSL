using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Model.Instrument;
using Yookey.WisdomClassed.SIP.DataAccess.Instrument;

namespace Yookey.WisdomClassed.SIP.Business.Instrument
{
    /// <summary>
    /// WSTOCKRECORD业务逻辑
    /// </summary>
    public class WSTOCKRECORDBll : BaseBll<WSTOCKRECORDEntity>
    {
        public WSTOCKRECORDBll()
        {
            BaseDal = new WSTOCKRECORDDal();
        }
        /// <summary>
        /// 保存文书入库主表
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public string  SaveWSTOCKRECOR(WSTOCKRECORDEntity entity)
        {
           return new WSTOCKRECORDDal().SaveWSTOCKRECOR(entity);
        }

        /// <summary>
        /// 判断入库子表中是否已经存在相同的入库记录
        /// </summary>
        /// <param name="StarNo"></param>
        /// <param name="EndNo"></param>
        /// <param name="WSType"></param>
        /// <returns></returns>
        public bool GetStockAdd(string StarNo, string EndNo, string WSType, string Year)
        {
            return new WSTOCKRECORDDal().GetStockAdd(StarNo, EndNo, WSType, Year);
        }


        /// <summary>
        /// 领用完入库判断号码是否存在

        /// </summary>
        /// <param name="StarNo"></param>
        /// <param name="EndNo"></param>
        /// <param name="WSType"></param>
        /// <returns></returns>
        public bool GetStockZDAdd(string StarNo, string EndNo, string WSType, string Year)
        {
            return new WSTOCKRECORDDal().GetStockZDAdd(StarNo, EndNo, WSType, Year);
        }

    }
}