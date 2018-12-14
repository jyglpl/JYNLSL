using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmEnterpriseDal : BaseDal<TmEnterpriseEntity>
    {
        public List<TmEnterpriseEntity> GetSearchResult(TmEnterpriseEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_ENTERPRISE WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            return WriteDatabase.Query<TmEnterpriseEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
