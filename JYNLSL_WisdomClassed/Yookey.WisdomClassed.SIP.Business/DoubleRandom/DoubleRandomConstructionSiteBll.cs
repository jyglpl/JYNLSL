using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomConstructionSiteBll
    {
        private static readonly DoubleRandomConstructionSiteDal Dal = new DoubleRandomConstructionSiteDal();

        /// <summary>
        /// 获取建筑工地
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomConstructionSiteEntity> GetSearchListForSite()
        {
            return Dal.GetSearchListForSite();
        }
    }
}
