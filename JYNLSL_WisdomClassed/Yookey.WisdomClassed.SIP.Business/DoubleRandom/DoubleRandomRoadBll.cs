using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomRoadBll
    {
        private static readonly DoubleRandomRoadDal Dal = new DoubleRandomRoadDal();

        /// <summary>
        /// 获取重点路段
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomRoadEntity> GetSearchListForRoad()
        {
            return Dal.GetSearchListForRoad();
        }
    }
}
