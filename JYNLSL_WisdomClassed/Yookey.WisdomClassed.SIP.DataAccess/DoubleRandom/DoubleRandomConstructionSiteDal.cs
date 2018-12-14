using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomConstructionSiteDal : BaseDal<DoubleRandomConstructionSiteEntity>
    {
        /// <summary>
        /// 获取建筑工地
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomConstructionSiteEntity> GetSearchListForSite()
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM DOUBLE_RANDOM_CONSTRUCTION_SITE WHERE Rowstatus = 1");
            return WriteDatabase.Query<DoubleRandomConstructionSiteEntity>(strSql.ToString()).ToList();
        }
    }
}
