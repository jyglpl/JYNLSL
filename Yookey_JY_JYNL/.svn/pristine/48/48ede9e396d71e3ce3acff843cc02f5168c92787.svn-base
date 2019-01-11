using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    public class OnlineClassRecordDal : BaseDal<OnlineClassRecordEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassRecordEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassRecord WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.Single<OnlineClassRecordEntity>(strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassRecordEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                strSqlLink.AppendFormat(@" CourseId = '{0}',", search.CourseId);
            }
            if (!string.IsNullOrEmpty(search.UserId))
            {
                strSqlLink.AppendFormat(@" UserId = '{0}',", search.UserId);
            }
            if (!string.IsNullOrEmpty(search.StartTime.ToString()))
            {
                strSqlLink.AppendFormat(@" StartTime = '{0}',", search.StartTime);
            }
            if (!string.IsNullOrEmpty(search.EndTime.ToString()))
            {
                strSqlLink.AppendFormat(@" EndTime = '{0}',", search.EndTime);
            }
            if (!string.IsNullOrEmpty(search.StudyTime))
            {
                strSqlLink.AppendFormat(@" StudyTime = '{0}',", search.StudyTime);
            }
            if (!string.IsNullOrEmpty(search.Ip))
            {
                strSqlLink.AppendFormat(@" Ip = '{0}',", search.Ip);
            }
            if (!string.IsNullOrEmpty(search.RowStatus.ToString()))
            {
                strSqlLink.AppendFormat(@" RowStatus = '{0}',", search.RowStatus);
            }
            if (!string.IsNullOrEmpty(search.CreatorId))
            {
                strSqlLink.AppendFormat(@" CreatorId = '{0}',", search.CreatorId);
            }
            if (!string.IsNullOrEmpty(search.CreateBy))
            {
                strSqlLink.AppendFormat(@" CreateBy = '{0}',", search.CreateBy);
            }
            if (!string.IsNullOrEmpty(search.CreateOn.ToString()))
            {
                strSqlLink.AppendFormat(@" CreateOn = '{0}',", search.CreateOn);
            }
            if (!string.IsNullOrEmpty(search.UpdateId))
            {
                strSqlLink.AppendFormat(@" UpdateId = '{0}',", search.UpdateId);
            }
            if (!string.IsNullOrEmpty(search.UpdateBy))
            {
                strSqlLink.AppendFormat(@" UpdateBy = '{0}',", search.UpdateBy);
            }
            if (!string.IsNullOrEmpty(search.UpdateOn.ToString()))
            {
                strSqlLink.AppendFormat(@" UpdateOn = '{0}',", search.UpdateOn);
            }
            var strSql = string.Format(@"UPDATE OnlineClassRecord SET {0} Id={1}  WHERE Id='{2}'", strSqlLink, search.Id, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassRecordEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassRecord]
           ([Id],[CourseId],[UserId],[StartTime],[EndTime]
           ,[StudyTime],[Ip]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
            entity.Id, entity.CourseId, entity.UserId, entity.StartTime, entity.EndTime,
            entity.StudyTime, entity.Ip,
            entity.RowStatus,entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassRecordEntity> GetSearchResult(OnlineClassRecordEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassRecordEntity>("Where {0}=1 ",t=>t.RowStatus));
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassRecordEntity>(" and {0} = @p1 ", t => t.CourseId));
                args.Add(new { p1 = search.CourseId });
            }
            if (!string.IsNullOrEmpty(search.UserId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassRecordEntity>(" and {0} = @p1 ", t => t.UserId));
                args.Add(new { p1 = search.UserId });
            }
            var list = WriteDatabase.Query<OnlineClassRecordEntity>(sbWhere.ToString()).ToList();
            return (list != null && list.Count > 0) ? list : new List<OnlineClassRecordEntity>();
        }
    }
}
