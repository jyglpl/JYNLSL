using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmEnterpriseBll
    {
        private readonly TmEnterpriseDal _dal = new TmEnterpriseDal();

        public List<TmEnterpriseEntity> GetSearchResult(TmEnterpriseEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
