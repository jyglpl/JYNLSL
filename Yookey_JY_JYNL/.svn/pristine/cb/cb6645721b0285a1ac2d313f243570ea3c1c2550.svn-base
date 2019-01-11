using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    public class OnlineClassAttachmentDal : BaseDal<OnlineClassAttachmentEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassAttachmentEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassAttachment WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.Single<OnlineClassAttachmentEntity>(strSql.ToString(), args.ToArray());
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassAttachmentEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                strSqlLink.AppendFormat(@" ResourceId = '{0}',", search.ResourceId);
            }
            if (!string.IsNullOrEmpty(search.FileName))
            {
                strSqlLink.AppendFormat(@" FileName = '{0}',", search.FileName);
            }
            if (!string.IsNullOrEmpty(search.FileReName))
            {
                strSqlLink.AppendFormat(@" FileReName = '{0}',", search.FileReName);
            }
            if (!string.IsNullOrEmpty(search.FileSize))
            {
                strSqlLink.AppendFormat(@" FileSize = '{0}',", search.FileSize);
            }
            if (!string.IsNullOrEmpty(search.IsCompleted.ToString()))
            {
                strSqlLink.AppendFormat(@" IsCompleted = '{0}',", search.IsCompleted);
            }
            if (!string.IsNullOrEmpty(search.FileAddress))
            {
                strSqlLink.AppendFormat(@" FileAddress = '{0}',", search.FileAddress);
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
            var strSql = string.Format(@"UPDATE OnlineClassAttachment SET {0} Id={1}  WHERE Id='{2}'", strSqlLink, search.Id, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassAttachmentEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassAttachment]
           ([Id],[ResourceId],[FileName],[FileReName],[FileSize]
           ,[IsCompleted],[FileAddress]
           ,[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
            entity.Id, entity.ResourceId, entity.FileName, entity.FileReName, entity.FileSize,
            entity.IsCompleted, entity.FileAddress,
            entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据外键数据源获取附件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-18
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<OnlineClassAttachmentEntity> GetSearchResult(string recourceId)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassAttachmentEntity>("Where 1=1 "));
            if (!string.IsNullOrEmpty(recourceId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassAttachmentEntity>(" and {0} = @p1 ", t => t.ResourceId));
                args.Add(new { p1 = recourceId });
            }
            var list = WriteDatabase.Query<OnlineClassAttachmentEntity>(sbWhere.ToString()).ToList();
            return (list != null && list.Count > 0) ? list : new List<OnlineClassAttachmentEntity>();
        }

        /// <summary>
        /// 查询附件
        /// 添加人：张西琼
        /// 时间：2014-11-24
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public DataTable GetAttachmentByCourseId(string courseId)
        {
            try
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select OCA.* from OnlineClassCourseAttach AS OCCA 
JOIN OnlineClassAttachment AS OCA ON OCA.Id=OCCA.AttachmentId and OCCA.RowStatus=1");
                if (!string.IsNullOrEmpty(courseId))
                {
                    strSql.AppendFormat(@" where CourseId='{0}'", courseId);
                }
                return WriteDatabase.Query(strSql.ToString());
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
