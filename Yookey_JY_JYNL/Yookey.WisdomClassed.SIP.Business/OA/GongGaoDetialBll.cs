using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Business.OA
{
    public class GongGaoDetialBll
    {
        private static readonly GongGaoDetialDal Dal = new GongGaoDetialDal();

        /// <summary>
        /// 查询公文详情
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <returns></returns>
        public List<GongGaoDetialEntity> QueryList(string userid = null)
        {
            try
            {
                return Dal.QueryList(userid);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
