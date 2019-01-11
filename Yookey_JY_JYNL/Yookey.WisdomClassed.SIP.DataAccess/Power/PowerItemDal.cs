using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Power;

namespace Yookey.WisdomClassed.SIP.DataAccess.Power
{
    public class PowerItemDal:BaseDal<PowerItemEntity>
    {
        /// <summary>
        /// 直接查询list，不分页
        /// ad by lpl
        /// 2019-1-3
        /// </summary>
        /// <returns></returns>
        public List<PowerItemEntity> QueryList(PowerItemEntity powerItemEntity)
        {
            var strSql = new StringBuilder(@"SELECT Id, Item, CFZL, CFYJ, CFYJYW, WFFG, WFFGYW, (SELECT RsKey FROM dbo.ComResource WHERE ParentId = '0058' AND RsValue = LX) AS LX,LX AS LXValue  FROM dbo.PowerItem
            WHERE RowStatus = 1 ");
            var args = new List<object>();

            if (!string.IsNullOrEmpty(powerItemEntity.LX))
            {
                strSql.AppendFormat("AND LX = '{0}'", powerItemEntity.LX);
            }

     

            return WriteDatabase.Query<PowerItemEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
