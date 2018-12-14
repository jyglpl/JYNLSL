using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    public class OnlineClassReceiveDal : BaseDal<OnlineClassReceiveEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassReceiveEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassReceive WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.Single<OnlineClassReceiveEntity>(strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-18
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<OnlineClassReceiveEntity> GetSearchResult(OnlineClassReceiveEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassReceiveEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassReceiveEntity>(" and {0} = @p1 ", t => t.CourseId));
                args.Add(new { p1 = search.CourseId });
            }
            if (!string.IsNullOrEmpty(search.UserId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassReceiveEntity>(" and {0} = @p2 ", t => t.UserId));
                args.Add(new { p2 = search.UserId });
            }
            var list = WriteDatabase.Query<OnlineClassReceiveEntity>(sbWhere.ToString(), args.ToArray()).ToList();
            return (list != null && list.Count > 0)? list : new List<OnlineClassReceiveEntity>();
        }
       
        /// <summary>
        /// 删除接收人
        /// 时间：20147-12-1
        /// 添加人：张西琼
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public bool DelRecieveByCourseId(string courseId)
        {
            try
            {
                if (!string.IsNullOrEmpty(courseId))
                {
                    string str = string.Format(@"update OnlineClassReceive set RowStatus=0 where CourseId='{0}'", courseId);
                    return WriteDatabase.Execute(str) > 0;
                }
                else return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassReceiveEntity search)
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
            if (!string.IsNullOrEmpty(search.ReceiveType.ToString()))
            {
                strSqlLink.AppendFormat(@" ReceiveType = '{0}',", search.ReceiveType);
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
            var strSql = string.Format(@"UPDATE OnlineClassReceive SET {0} RowStatus={1}  WHERE Id='{2}'", strSqlLink, search.RowStatus, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

         /// <summary>
        /// 根据CourseId和UserId更新实体(必修)
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateBy(string courseId, string userId)
        {
           var strSql = string.Format(@" UPDATE OnlineClassReceive SET ReceiveType={0} WHERE CourseId='{1}' AND UserId='{2}';", (int)CourseQueryType.Required, courseId, userId);
           return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassReceiveEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassReceive]
           ([Id],[CourseId],[UserId],[ReceiveType]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
               entity.Id, entity.CourseId, entity.UserId, entity.ReceiveType,
               entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}