using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.SealUp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.Business.SealUp
{
    /// <summary>
    /// SealUp_Legislation业务逻辑
    /// </summary>
    public class SealUpLegislationBll : BaseBll<SealUpLegislationEntity>
    {
        public SealUpLegislationBll()
        {
            BaseDal = new SealUpLegislationDal();
        }

        /// <summary>
        /// 案件法律法规查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<SealUpLegislationEntity> GetSearchResult(SealUpLegislationEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_RowStatus, "1");
            //案由编号
            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_ItemNo, search.ItemNo);
            }
            //案由编号
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<SealUpLegislationEntity>;
        }
    }
}
