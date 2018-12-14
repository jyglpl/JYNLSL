using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TmMatterApplyZTYSVehicleDal : BaseDal<TmMatterApplyZTYSVehicleEntity>
    {
        public List<TmMatterApplyZTYSVehicleEntity> GetSearchResult(TmMatterApplyZTYSVehicleEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TM_MATTER_APPLY_ZTYS_VEHICLE WHERE DELETED = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(@" AND ID='{0}'", search.ID);
            }
            if (!string.IsNullOrEmpty(search.MATTER_APPLY_ZTYS_ID))
            {
                strSql.AppendFormat(@" AND MATTER_APPLY_ZTYS_ID='{0}'", search.MATTER_APPLY_ZTYS_ID);
            }
            return WriteDatabase.Query<TmMatterApplyZTYSVehicleEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
