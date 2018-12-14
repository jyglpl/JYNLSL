using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    public class OnlineClassCourseAttachDal : BaseDal<OnlineClassCourseAttachEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassCourseAttachEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassCourseAttach WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.Single<OnlineClassCourseAttachEntity>(strSql.ToString(), args.ToArray());
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
        public List<OnlineClassCourseAttachEntity> GetSearchResult(OnlineClassCourseAttachEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassCourseAttachEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassCourseAttachEntity>(" and {0} = @p1 ", t => t.CourseId));
                args.Add(new { p1 = search.CourseId });
            }
            if (!string.IsNullOrEmpty(search.AttachmentId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassCourseAttachEntity>(" and {0} = @p2 ", t => t.AttachmentId));
                args.Add(new { p2 = search.AttachmentId });
            }
            var list = WriteDatabase.Query<OnlineClassCourseAttachEntity>(sbWhere.ToString()).ToList();
            return (list != null && list.Count > 0) ? list : new List<OnlineClassCourseAttachEntity>();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassCourseAttachEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                strSqlLink.AppendFormat(@" CourseId = '{0}',", search.CourseId);
            }
            if (!string.IsNullOrEmpty(search.AttachmentId))
            {
                strSqlLink.AppendFormat(@" AttachmentId = '{0}',", search.AttachmentId);
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
            var strSql = string.Format(@"UPDATE OnlineClassCourseAttach SET {0} RowStatus={1}  WHERE Id='{2}'", strSqlLink, search.RowStatus, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 删除课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var strSql = string.Format(@"UPDATE OnlineClassCourseAttach SET RowStatus='{0}' WHERE Id='{1}'", (int)RowStatus.Delete, id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据课件编号删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteBy(string courseId)
        {
            var strSql = string.Format(@"UPDATE OnlineClassCourseAttach SET RowStatus='{0}' WHERE CourseId='{1}'", (int)RowStatus.Delete, courseId);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassCourseAttachEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassCourseAttach]
           ([Id],[CourseId],[AttachmentId]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
            entity.Id, entity.CourseId, entity.AttachmentId,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 查询课程附件
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId">课程编号</param>
        /// <returns>Columns->LastStudySec:资源学习时间,FileAddress:资料路径,FileName:附件名称</returns>
        public DataTable QueryCourseAttachment(string userId, string courseId)
        {
            try
            {
                var strSql = string.Format(@"SELECT LastStudySec,OCA.FileAddress,OCA.FileName FROM OnlineClassProgress AS OCP
JOIN OnlineClassCourseAttach AS OCCA ON OCCA.CourseId=OCP.CourseId
JOIN OnlineClassAttachment AS OCA ON OCA.Id=OCCA.AttachmentId
WHERE UserId='{0}' AND OCP.CourseId='{1}'", userId, courseId);

                return WriteDatabase.Query(strSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询课程附件
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns>Columns->FileAddress:资料路径,FileName:附件名称</returns>
        public DataTable QueryCourseAttachment(string courseId)
        {
            try
            {
                var strSql = string.Format(@"SELECT FileName,OCA.FileAddress FROM OnlineClassCourseAttach AS OCCA
JOIN OnlineClassAttachment AS OCA ON OCCA.AttachmentId=OCA.Id
WHERE OCCA.CourseId='{0}'", courseId);

                return WriteDatabase.Query(strSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
