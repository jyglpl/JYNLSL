using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmMatterApplyCertificateBll
    {
        private TmMatterApplyCertificateDal _dal = new TmMatterApplyCertificateDal();

        public List<TmMatterApplyCertificate> GetSearchResult(TmMatterApplyCertificate search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
