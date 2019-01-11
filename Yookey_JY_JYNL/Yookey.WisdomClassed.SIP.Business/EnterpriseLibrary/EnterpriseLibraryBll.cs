using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.DataAccess.EnterpriseLibrary;
using Yookey.WisdomClassed.SIP.Model.EnterpriseLibrary;

namespace Yookey.WisdomClassed.SIP.Business.EnterpriseLibrary
{
    /// <summary>
    /// add by lpl
    /// 2019-1-10
    /// 经营单位业务逻辑层
    /// </summary>
    public class EnterpriseLibraryBll:BaseBll<EnterpriseLibraryEntity>
    {
        private static readonly EnterpriseLibraryDal Dal = new EnterpriseLibraryDal();
    }
}
