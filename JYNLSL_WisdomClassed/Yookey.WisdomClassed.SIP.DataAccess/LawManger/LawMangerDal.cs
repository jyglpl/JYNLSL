using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.LawManger;

namespace Yookey.WisdomClassed.SIP.DataAccess.LawManger
{
    public  class LawMangerDal : BaseDal<LawMangerEntity>
    {
        /// <summary>
        /// add by lpl
        /// 2019-1-9
        /// 法律法规表数据查询
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<LawMangerEntity> QueryList(LawMangerEntity entity)
        {
            var strSql = new StringBuilder(" Where Rowsatus = 1");
            var args = new List<object>();

            if (!string.IsNullOrEmpty(entity.Id))
            {
                strSql.AppendFormat(" AND Id = '{0}'", entity.Id);
            }

            if (!string.IsNullOrEmpty(entity.ParentId))
            {
                strSql.Append(" AND ParentId = @ParentId");
                args.Add(new{ ParentId = entity.ParentId});
            }

            return ReadDatabase.Query<LawMangerEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
