using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComNoticeAttach数据访问操作
    /// </summary>
    public class ComNoticeAttachDal : DalImp.BaseDal<ComNoticeAttachEntity>
    {
        public ComNoticeAttachDal()
        {
            Model = new ComNoticeAttachEntity();
        }
    }
}

