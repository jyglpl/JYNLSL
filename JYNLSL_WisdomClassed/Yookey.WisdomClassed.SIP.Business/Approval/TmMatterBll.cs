using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmMatterBll
    {
        private readonly TmMatterDal _dal = new TmMatterDal();

        public List<TmMatterEntity> GetSearchResult(TmMatterEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
