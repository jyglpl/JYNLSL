using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.LawManger;
using Yookey.WisdomClassed.SIP.Model.LawManger;

namespace Yookey.WisdomClassed.SIP.Business.LawManger
{
    public class LawMangerBll:BaseBll<LawMangerEntity>
    {
        private static readonly LawMangerDal Dal = new LawMangerDal();

        /// <summary>
        /// add by lpl
        /// 2019-1-9
        /// 查询法律法规所有数据集合
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<LawMangerEntity> QueryList(LawMangerEntity entity)
        {
            return Dal.QueryList(entity);
        }
    }
}
