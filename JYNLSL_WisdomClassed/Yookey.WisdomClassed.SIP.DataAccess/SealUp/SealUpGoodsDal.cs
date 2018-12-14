using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.DataAccess.SealUp
{
    /// <summary>
    /// SealUpGoods数据访问操作
    /// </summary>
    public class SealUpGoodsDal : DalImp.BaseDal<SealUpGoodsEntity>
    {
        public SealUpGoodsDal()
        {
            Model = new SealUpGoodsEntity();
        }

        /// <summary>
        /// 物品表
        /// </summary>
        /// <param name="CaseInfoId"></param>
        /// <returns></returns>
        public DataTable GetInventory(string caseInfoId)
        {
            var strSql = new StringBuilder("");

            strSql.AppendFormat(@"select ROW_NUMBER() OVER (ORDER BY TG.createon) AS Num ,
       TG.Name ArticleName,  TG.Area Specifications, Unit.RsKey Number,TG.Remark
 from SealUpGoods  TG with(nolock)
  inner join ComResource Unit with(nolock)
 on TG.MaterialId=Unit.Id
 where TG.RowStatus=1 AND TG.SealUpId='{0}' ", caseInfoId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
}
