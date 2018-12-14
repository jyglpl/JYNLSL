using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.FingerPrint;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.FingerPrint;

namespace Yookey.WisdomClassed.SIP.Business.FingerPrint
{
    /// <summary>
    /// FingerPrint业务逻辑
    /// </summary>
    public class FingerPrintBll : BaseBll<FingerPrintEntity>
    {
        public FingerPrintBll()
        {
            BaseDal = new FingerPrintDal();
        }

       /// <summary>
        /// 根据用户编号,指纹序列查找用户信息
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="serialnumber"></param>
       /// <returns></returns>
        public List<FingerPrintEntity> GetSearchResult(string userId, string serialnumber)
        {
            return new FingerPrintDal().GetSearchResult(userId, serialnumber);
        }

        /// <summary>
        /// 更新指纹绑定状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public bool UpdateFnierPrintStatus(int status, string serialNumber)
        {
            return new FingerPrintDal().UpdateFnierPrintStatus(status, serialNumber);
        }
    }
}
