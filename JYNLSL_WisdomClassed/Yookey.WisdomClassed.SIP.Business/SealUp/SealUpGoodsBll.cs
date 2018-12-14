using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.SealUp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.Business.SealUp
{
    // <summary>
    /// SealUpGoods业务逻辑
    /// </summary>
    public class SealUpGoodsBll : BaseBll<SealUpGoodsEntity>
    {
        public SealUpGoodsBll()
        {
            BaseDal = new SealUpGoodsDal();
        }
        /// <summary>
        /// 查询物品清单
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<SealUpGoodsEntity> GetSearchResult(SealUpGoodsEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(SealUpGoodsEntity.Parm_SealUpGoods_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.SealUpId))
            {
                queryCondition.AddEqual(SealUpGoodsEntity.Parm_SealUpGoods_SealUpId, search.SealUpId);
            }
            //排序
            queryCondition.AddOrderBy(SealUpGoodsEntity.Parm_SealUpGoods_CreateOn, true);
            return Query(queryCondition) as List<SealUpGoodsEntity>;
        }

        /// <summary>
        /// 物品表
        /// </summary>
        /// <param name="CaseInfoId"></param>
        /// <returns></returns>
        public DataTable GetInventory(string caseInfoId)
        {
            return new SealUpGoodsDal().GetInventory(caseInfoId);
        }
    }
}
