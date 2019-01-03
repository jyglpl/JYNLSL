using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.DataAccess.OA
{
    public class GongGaoDetialDal : BaseDal<GongGaoDetialEntity>
    {
        /// <summary>
        /// 直接查询list
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <returns></returns>
        public List<GongGaoDetialEntity> QueryList(string userid = null)
        {
            var strSql = new StringBuilder("SELECT * FROM dbo.GongGaoDetial WHERE 1=1");

            var args = new List<object>();

            if (string.IsNullOrEmpty(userid))
            {
                strSql.AppendFormat(" UserId  = '{0}'", userid);
            }

            return WriteDatabase.Query<GongGaoDetialEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
