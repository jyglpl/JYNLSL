﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmMatterApplyHWGGBll
    {
        private readonly TmMatterApplyHWGGDal _dal = new TmMatterApplyHWGGDal();

        public List<TmMatterApplyHWGGEntity> GetSearchResult(TmMatterApplyHWGGEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
