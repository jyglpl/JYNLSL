using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmMatterApplyHWGGDetailDal : BaseDal<TmMatterApplyHWGGDetailEntity>
    {
        public List<TmMatterApplyHWGGDetailEntity> GetSearchResult(TmMatterApplyHWGGDetailEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_HWGG_DETAIL WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.MATTER_APPLY_HWGG_ID))
            {
                strSql.AppendFormat(@" AND MATTER_APPLY_HWGG_ID='{0}'", search.MATTER_APPLY_HWGG_ID);
            }
            return WriteDatabase.Query<TmMatterApplyHWGGDetailEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
