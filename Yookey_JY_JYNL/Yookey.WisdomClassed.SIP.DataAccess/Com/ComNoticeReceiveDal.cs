using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComNoticeReceive数据访问操作
    /// </summary>
    public class ComNoticeReceiveDal : DalImp.BaseDal<ComNoticeReceiveEntity>
    {
        public ComNoticeReceiveDal()
        {
            Model = new ComNoticeReceiveEntity();
        }
    }
}