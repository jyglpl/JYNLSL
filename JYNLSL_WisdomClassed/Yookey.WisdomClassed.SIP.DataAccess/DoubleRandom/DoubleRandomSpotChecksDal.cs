using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomSpotChecksDal : BaseDal<DoubleRandomSpotChecksEntity>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomSpotChecksEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[DoubleRandomSpotChecks]
           ([Id],[CheckNo],[CheckGroup],[CheckPersonNum],[ObjNo],[RandomType]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
           entity.Id, entity.CheckNo, entity.CheckGroup, entity.CheckPersonNum, entity.ObjNo, entity.RandomType,
           entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 获取抽查批次
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DoubleRandomSpotChecksEntity> GetDoubleRandomSpotChecksList(string startTime, string endTime, string type, int pageSize, int pageIndex)
        {
            DateTime lastMonth = DateTime.Now;
            if (string.IsNullOrEmpty(startTime))
            {
                startTime = lastMonth.AddDays(1 - lastMonth.Day).ToString("yyyy-MM-dd") + " 00:00:00.000";

            }
            if (string.IsNullOrEmpty(endTime))
            {
                endTime = lastMonth.AddDays(1 - lastMonth.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
            }
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<DoubleRandomSpotChecksEntity>("Where {0}=1 ", u => u.RowStatus));

            sbWhere.Append(Database.GetFormatSql<DoubleRandomSpotChecksEntity>(" and {0} >= @p1 ", t => t.CreateOn));
            args.Add(new { p1 = startTime });

            sbWhere.Append(Database.GetFormatSql<DoubleRandomSpotChecksEntity>(" and {0} <= @p2 ", t => t.CreateOn));
            args.Add(new { p2 = endTime });

            if (type !="-1")
            {
                sbWhere.Append(Database.GetFormatSql<DoubleRandomSpotChecksEntity>(" and {0} = @p3 ", t => t.RandomType));
                args.Add(new { p3 = type });
            }

            sbWhere.Append(" ORDER BY CreateOn desc");
            return WriteDatabase.Page<DoubleRandomSpotChecksEntity>(pageIndex, pageSize, sbWhere.ToString(), args.ToArray());
        }

        public List<DoubleRandomSpotChecksEntity> GetRandomCount(string startTime, string endTime, string type)
        {
            var strSql = string.Format(@"select * from [dbo].[DoubleRandomSpotChecks] where [RowStatus]=1 and [CreateOn]>='{0}' and [CreateOn]<='{1}' and RandomType={2} ", startTime, endTime, type);
            //return WriteDatabase.ExecuteScalar<int>(strSql.ToString());
            return WriteDatabase.Query<DoubleRandomSpotChecksEntity>(strSql.ToString()).ToList();

        }

        /// <summary>
        /// 删除抽查批次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSpot(string id)
        {
            var strSql = string.Format(@"DELETE FROM [dbo].[DoubleRandomSpotChecks] where Id='{0}'", id);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 查询所有抽查数据
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public List<DoubleRandomSpotChecksEntity> GetSearchList(DoubleRandomSpotChecksEntity Search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM [dbo].[DoubleRandomSpotChecks] where Rowstatus = 1");
            if (!string.IsNullOrEmpty(Search.Id))
            {
                strSql.AppendFormat(" And id = '{0}'", Search.Id);
            }
            if (!string.IsNullOrEmpty(Search.RandomType))
            {
                strSql.AppendFormat(" And RandomType = '{0}'", Search.RandomType);
            }

            return WriteDatabase.Query<DoubleRandomSpotChecksEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 更新抽查派发状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateIsDispatch(string Id)
        {
            var strSql = string.Format(@"UPDATE [DoubleRandomSpotChecks] SET IsDispatch = 1 where Id='{0}'", Id);

            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
