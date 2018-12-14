using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TcAttachMentRefBll
    {
        private readonly TcAttachMentRefDal _dal = new TcAttachMentRefDal();

        public List<TcAttachMentRefEntity> GetSearchResult(TcAttachMentRefEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
