using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomRoadDal : BaseDal<DoubleRandomRoadEntity>
    {
        /// <summary>
        /// 获取重点路段
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomRoadEntity> GetSearchListForRoad()
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM DOUBLE_RANDOM_ROAD WHERE Rowstatus = 1");
            return WriteDatabase.Query<DoubleRandomRoadEntity>(strSql.ToString()).ToList();
        }
    }
}
