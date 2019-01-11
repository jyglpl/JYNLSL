using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.DataAccess.Approval
{
    public class TcDictionaryDataDal : BaseDal<TcDictionaryDataEntity>
    {
        public List<TcDictionaryDataEntity> GetSearchResult(TcDictionaryDataEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TC_DICTIONARY_DATA WHERE 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.CODE))
            {
                strSql.AppendFormat(@" AND CODE='{0}'", search.CODE);
            }
            return WriteDatabase.Query<TcDictionaryDataEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
