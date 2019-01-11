using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    public class IllegalCaseRemoveBll
    {
        public static readonly IllegalCaseRemoveDal Dal = new IllegalCaseRemoveDal();

        /// <summary>
        /// 获取违法案件违法拆除信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseRemoveEntity> GetIllegalCaseResult(IllegalCaseRemoveEntity search)
        {
            return Dal.GetIllegalCaseResult(search);
        }

        /// <summary>
        /// 新增违法案件违法拆除信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalRemoveInfo(IllegalCaseRemoveEntity entity)
        {
            return Dal.InsertIllegalRemoveInfo(entity);
        }
    }
}
