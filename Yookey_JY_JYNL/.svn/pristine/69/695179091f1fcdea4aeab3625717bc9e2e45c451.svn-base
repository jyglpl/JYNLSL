using DBHelper;
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
    public class OnlineClassProgressDal : BaseDal<OnlineClassProgressEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassProgressEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassProgress WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.Single<OnlineClassProgressEntity>(strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetSearchResult(OnlineClassProgressEntity search)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.CourseId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>(" and {0} = @p1 ", t => t.CourseId));
                args.Add(new { p1 = search.CourseId });
            }
            if (!string.IsNullOrEmpty(search.UserId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>(" and {0} = @p2 ", t => t.UserId));
                args.Add(new { p2 = search.UserId });
            }
            var list = WriteDatabase.Query<OnlineClassProgressEntity>(sbWhere.ToString(), args.ToArray()).ToList();
            return (list != null && list.Count > 0) ? list : new List<OnlineClassProgressEntity>();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetSearchResult(OnlineClassProgressEntity search,string startTime,string endTime)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.UserId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>(" and {0} = @p2 ", t => t.UserId));
                args.Add(new { p2 = search.UserId });
            }
            sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>(" and {0} >= @p3 ", t => t.LastStudyTime));
            args.Add(new { p3 = startTime });
            sbWhere.Append(Database.GetFormatSql<OnlineClassProgressEntity>(" and {0} <= @p4 ", t => t.LastStudyTime));
            args.Add(new { p4 = endTime });

            var list = WriteDatabase.Query<OnlineClassProgressEntity>(sbWhere.ToString(), args.ToArray()).ToList();
            return (list != null && list.Count > 0) ? list : new List<OnlineClassProgressEntity>();
        }

        /// <summary>
        /// 删除接收人
        /// 不确定根据什么删除
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public bool Delete(string courseId)
        {
            try
            {
                if (!string.IsNullOrEmpty(courseId))
                {
                    string str = string.Format(@"update OnlineClassProgress set RowStatus=0 where CourseId='{0}'", courseId);
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
        public bool Update(OnlineClassProgressEntity search)
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
            if (!string.IsNullOrEmpty(search.LastStudyTime.ToString()))
            {
                strSqlLink.AppendFormat(@" LastStudyTime = '{0}',", search.LastStudyTime);
            }
            if (!string.IsNullOrEmpty(search.LastStudySec))
            {
                strSqlLink.AppendFormat(@" LastStudySec = '{0}',", search.LastStudySec);
            }
            if (search.Progress >= 0 && search.Progress<=100)
            {
                strSqlLink.AppendFormat(@" Progress = '{0}',", search.Progress);
            }
            if (!string.IsNullOrEmpty(search.FinishTime.ToString()))
            {
                strSqlLink.AppendFormat(@" FinishTime = '{0}',", search.FinishTime);
            }
            if (!string.IsNullOrEmpty(search.TotalTime))
            {
                strSqlLink.AppendFormat(@" TotalTime = '{0}',", search.TotalTime);
            }
            if (!string.IsNullOrEmpty(search.Integral.ToString()))
            {
                strSqlLink.AppendFormat(@" Integral = '{0}',", search.Integral);
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
            var strSql = string.Format(@"UPDATE OnlineClassProgress SET {0} Id={1}  WHERE Id='{2}'", strSqlLink, search.Id, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassProgressEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassProgress]
           ([Id],[CourseId],[UserId],[LastStudyTime],[LastStudySec]
           ,[Progress],[FinishTime],[TotalTime],[Integral]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')",
               entity.Id, entity.CourseId, entity.UserId, entity.LastStudyTime,entity.LastStudySec
               ,entity.Progress,entity.FinishTime,entity.TotalTime,entity.Integral,
               entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 学习记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="courseId">课程编号</param>
        /// <param name="startTime">开始学习时间</param>
        /// <param name="progress"></param>
        /// <param name="score">学习积分</param>
        /// <param name="totalTime">总共学习时长</param>
        /// <param name="studyTime">本次学习时长</param>
        /// <param name="lastStudySec">最后一次学习时间（用于记录视频）</param>
        /// <param name="ip">获取客户端IP</param>
        /// <returns></returns>
        public bool SaveProgress(string userId, string courseId, string startTime, int progress, double score, string totalTime, int studyTime, string lastStudySec, string ip)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"UPDATE OnlineClassProgress SET LastStudyTime=GETDATE(),LastStudySec='{0}',Progress={1},TotalTime={2},Integral={3} WHERE CourseId='{4}' AND UserId='{5}';", lastStudySec, progress, totalTime, score, courseId, userId);
                if (progress >= 100)
                {
                    //更新学习完成时间
                    strSql.AppendFormat("UPDATE OnlineClassProgress SET FinishTime=GETDATE()  WHERE CourseId='{0}' AND UserId='{1}' AND Progress<100;", courseId, userId);
                }
                strSql.AppendFormat(@"INSERT INTO OnlineClassRecord (CourseId,UserId,StartTime,EndTime,StudyTime,Ip)VALUES ('{0}','{1}','{2}',GETDATE(),{3},'{4}');", courseId, userId, startTime, studyTime, ip);

                WriteDatabase.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }

        /// <summary>
        /// 删除选修课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-18
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseId">课件编号</param>
        /// <returns></returns>
        public string DeleteChoice(string userId, string courseId)
        {
            try
            {
                if (!string.IsNullOrEmpty(courseId))
                {
                    var sbSql = new StringBuilder();
                    var strSql = string.Format("SELECT Progress FROM OnlineClassProgress WHERE CourseId='{0}' AND UserId='{1}'", courseId, userId);
                    //var obj = WriteDatabase.ExecuteScalar<OnlineClassProgressEntity>(strSql.ToString());
                    var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                    if (obj != null && int.Parse(obj.ToString()) < 11)
                    {
                        sbSql.AppendFormat(
                            @"UPDATE [OnlineClassReceive] SET RowStatus=0 WHERE UserId='{0}' AND CourseId='{1}';UPDATE OnlineClassProgress SET RowStatus=0 WHERE UserId='{0}' AND CourseId='{1}';",
                            userId, courseId);
                        //return WriteDatabase.Execute(sbSql.ToString()) > 0 ? "Ok" : "Error";
                        return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()) > 0 ? "Ok" : "Error";
                    }
                    else
                    {
                        return "UnDelete";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return "Ok";
        }
    }
}
