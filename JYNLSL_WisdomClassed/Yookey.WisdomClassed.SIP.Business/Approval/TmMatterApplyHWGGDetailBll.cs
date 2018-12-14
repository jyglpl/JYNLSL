using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmMatterApplyHWGGDetailBll
    {
        private readonly TmMatterApplyHWGGDetailDal _dal = new TmMatterApplyHWGGDetailDal();

        public List<TmMatterApplyHWGGDetailEntity> GetSearchResult(TmMatterApplyHWGGDetailEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
