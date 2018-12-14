using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// SimpleProgram_Attach业务逻辑
    /// </summary>
    public class SimpleProgram_AttachBll : BaseBll<SimpleProgram_AttachEntity>
    {
        public SimpleProgram_AttachBll()
        {
            BaseDal = new SimpleProgram_AttachDal();
        }
    }
}
