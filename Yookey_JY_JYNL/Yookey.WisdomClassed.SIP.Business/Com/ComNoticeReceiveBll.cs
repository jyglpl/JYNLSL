using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComNoticeReceive业务逻辑
    /// </summary>
    public class ComNoticeReceiveBll : BaseBll<ComNoticeReceiveEntity>
    {
        public ComNoticeReceiveBll()
        {
            BaseDal = new ComNoticeReceiveDal();
        }
    }
}
