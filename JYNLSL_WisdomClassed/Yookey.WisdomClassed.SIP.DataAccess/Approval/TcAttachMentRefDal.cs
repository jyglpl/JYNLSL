using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TcAttachMentRefDal : BaseDal<TcAttachMentRefEntity>
    {
        public List<TcAttachMentRefEntity> GetSearchResult(TcAttachMentRefEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TC_ATTACHMENT_REF WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.REF_TYPE))
            {
                strSql.AppendFormat(@" AND REF_TYPE='{0}'", search.REF_TYPE);
            }
            if (!string.IsNullOrEmpty(search.REF_RECORD_ID))
            {
                strSql.AppendFormat(@" AND REF_RECORD_ID='{0}'", search.REF_RECORD_ID);
            }
            return WriteDatabase.Query<TcAttachMentRefEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
