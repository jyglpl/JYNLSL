using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TcAttachMentBll
    {
        private readonly TcAttachMentDal _dal = new TcAttachMentDal();

        public List<TcAttachMentEntity> GetSearchResult(TcAttachMentEntity search)
        {
            return _dal.GetSearchResult(search);
        }
    }
}
