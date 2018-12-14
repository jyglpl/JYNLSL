using DBHelper;
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
    public class OnlineClassCourseDal : BaseDal<OnlineClassCourseEntity>
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassCourseEntity Get(string Id)
        {
            var args = new List<object>();
            var strSql = string.Format(@"SELECT * FROM OnlineClassCourse WHERE Id=@p1");
            args.Add(new { p1 = Id });
            return WriteDatabase.SingleOrDefault<OnlineClassCourseEntity>(strSql.ToString(), args.ToArray());
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassCourseEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.Title))
            {
                strSqlLink.AppendFormat(@" Title = '{0}',", search.Title);
            }
            if (!string.IsNullOrEmpty(search.Contents))
            {
                strSqlLink.AppendFormat(@" Contents = '{0}',", search.Contents);
            }
            if (!string.IsNullOrEmpty(search.Describle))
            {
                strSqlLink.AppendFormat(@" Describle = '{0}',", search.Describle);
            }
            if (!string.IsNullOrEmpty(search.LinkUrl))
            {
                strSqlLink.AppendFormat(@" LinkUrl = '{0}',", search.LinkUrl);
            }
            if (!string.IsNullOrEmpty(search.Cover))
            {
                strSqlLink.AppendFormat(@" Cover = '{0}',", search.Cover);
            }
            if (search.Score > 0)
            {
                strSqlLink.AppendFormat(@" Score = '{0}',", search.Score);
            }
            if (search.CourseType > 0 && search.CourseType < 5)
            {
                strSqlLink.AppendFormat(@" CourseType = '{0}',", search.CourseType);
            }
            if (!string.IsNullOrEmpty(search.CategoryId))
            {
                strSqlLink.AppendFormat(@" CategoryId = '{0}',", search.CategoryId);
            }
            if (search.Duration > 0)
            {
                strSqlLink.AppendFormat(@" Duration = '{0}',", search.Duration);
            }
            if (!string.IsNullOrEmpty(search.StartTime.ToString()))
            {
                strSqlLink.AppendFormat(@" StartTime = '{0}',", search.StartTime);
            }
            if (!string.IsNullOrEmpty(search.EndTime.ToString()))
            {
                strSqlLink.AppendFormat(@" EndTime = '{0}',", search.EndTime);
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
            var strSql = string.Format(@"UPDATE OnlineClassCourse SET {0} RowStatus={1}  WHERE Id='{2}'", strSqlLink, search.RowStatus, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 删除课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var strSql = string.Format(@"UPDATE OnlineClassCourse SET RowStatus='{0}' WHERE Id='{1}'", (int)RowStatus.Delete, id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassCourseEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassCourse]
           ([Id],[Title],[Contents],[Describle],[LinkUrl]
           ,[Cover],[Score],[CourseType],[CategoryId],[Duration]
           ,[StartTime],[EndTime]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
            entity.Id, entity.Title, entity.Contents, entity.Describle, entity.LinkUrl,
            entity.Cover, entity.Score, entity.CourseType, entity.CategoryId, entity.Duration,
            entity.StartTime, entity.EndTime,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 保存课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// 修改：OnlineClassProgress 插入时加入一个字段 LastStudyTime 时间：2014-11-29 张西琼
        /// </history>
        /// <param name="entity">课件实体</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool SaveCourse(OnlineClassCourseEntity entity)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                var sbSql = new StringBuilder();
                var courseId = entity.Id;   //课件编号
                var files = entity.Files.Trim(',');
                var receives = entity.Receives;

                var courseModel = Get(entity.Id);
                if (courseModel != null && !string.IsNullOrEmpty(courseModel.Id))
                {
                    sbSql.AppendFormat(UpdateStr(entity));
                    //Update(entity);
                }
                else
                {
                    sbSql.AppendFormat(InsertStr(entity));
                    //Insert(entity);

                    //删除附件
                    sbSql.AppendFormat(@"UPDATE [OnlineClassCourseAttach] SET RowStatus=0 WHERE [CourseId]='{0}';", courseId);

                    //保存附件
                    if (!(string.IsNullOrEmpty(files) || files.Trim(',').Length.Equals(0)))
                    {
                        var filesplit = files.Split(',');
                        foreach (var file in filesplit.Where(file => !string.IsNullOrEmpty(file)))
                        {
                            sbSql.AppendFormat(@"INSERT INTO [OnlineClassCourseAttach](CourseId,AttachmentId,RowStatus) Values ('{0}','{1}',{2});", courseId, file, 1);
                        }
                    }
                    //删除接收人
                    sbSql.AppendFormat(@"UPDATE [OnlineClassReceive] SET RowStatus=0 WHERE [CourseId]='{0}';", courseId);

                    //保存接收人及学习进度表
                    if (!(string.IsNullOrEmpty(receives) || receives.Trim(',').Length.Equals(0)))
                    {
                        var receivesplit = receives.Split(',');
                        foreach (var receive in receivesplit.Where(receive => !string.IsNullOrEmpty(receive)))
                        {
                            sbSql.AppendFormat(@"INSERT INTO [OnlineClassReceive](CourseId,UserId,ReceiveType,RowStatus) Values ('{0}','{1}',{2},1);INSERT INTO OnlineClassProgress(CourseId,UserId,LastStudyTime) Values ('{0}','{1}','{3}');", courseId, receive, (int)CourseQueryType.Required, DateTime.Now);
                        }
                    }
                }
                WriteDatabase.Execute(sbSql.ToString());
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }

        /// <summary>
        /// 保存课件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-23
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">课件实体</param>
        /// <param name="oldRecevices">课件所有学习的人员（包括：选修、必修的）</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool EditCourse(OnlineClassCourseEntity entity, List<OnlineClassReceiveEntity> oldRecevices)
        {
            WriteDatabase.BeginTransaction();
            try
            {
                var courseId = entity.Id;   //课件编号
                var files = entity.Files;
                var courseModel = Get(entity.Id);
                var listSql = new List<string>();
                if (courseModel != null && !string.IsNullOrEmpty(courseModel.Id))
                {
                    listSql.Add(UpdateStr(entity));
                    //Update(entity);
                }
                else
                {
                    listSql.Add(InsertStr(entity));
                    //Insert(entity);
                    //删除附件
                    listSql.Add(string.Format(@"UPDATE [OnlineClassCourseAttach] SET RowStatus=1 WHERE [CourseId]='{0}';", courseId));

                    //保存附件
                    if (!(string.IsNullOrEmpty(files) || files.Trim(',').Length.Equals(0)))
                    {
                        var filesplit = files.Split(',');
                        foreach (var file in filesplit.Where(file => !string.IsNullOrEmpty(file)))
                        {
                            listSql.Add(string.Format(@"INSERT INTO [OnlineClassCourseAttach](CourseId,AttachmentId,RowStatus) Values ('{0}','{1}',{2});", courseId, file, 1));
                        }
                    }
                }

                //本次修改保存的人员
                var recevicesList = new List<string>();
                var recevices = entity.Receives;
                //保存接收人及学习进度表
                if (!(string.IsNullOrEmpty(recevices) || recevices.Trim(',').Length.Equals(0)))
                {
                    var receivesplit = recevices.Split(',');
                    recevicesList.AddRange(receivesplit.Where(receive => !string.IsNullOrEmpty(receive)));
                }

                //要求1：已选修的人员，本次保存指定时，将这些人员的课程模式更改为必修
                //要求2：已必修人的员，本次保存未指定，将这些人员的课程模式更改为选修

                //实现方式：
                //        1、将所有课件的人员对应的课件类型全部更改为选修
                //        2、循环人员,已存在直接修改课程类型,不存的更改为

                var upSql = string.Format("UPDATE OnlineClassReceive SET ReceiveType={0} WHERE CourseId='{1}';", (int)CourseQueryType.Electives, courseId);
                listSql.Add(upSql);
                //WriteDatabase.Execute(upSql.ToString());

                //循环遍历当前课程所有人员
                foreach (var recevice in recevicesList)
                {
                    //验证当前保存人员是否已经保存,没有保存进行新增,否则将其类型更改为必修
                    var isExist = oldRecevices.Where(x => x.UserId == recevice).ToList();
                    if (isExist.Count <= 0)
                    {
                        listSql.Add(string.Format(@"INSERT INTO [OnlineClassReceive](CourseId,UserId,ReceiveType,RowStatus) Values ('{0}','{1}',{2},1);INSERT INTO OnlineClassProgress(CourseId,UserId,LastStudyTime) Values ('{0}','{1}','{3}');", courseId, recevice, (int)CourseQueryType.Required, DateTime.Now));
                    }
                    else
                    {
                        listSql.Add(string.Format(@"UPDATE OnlineClassReceive SET ReceiveType={0} WHERE CourseId='{1}' AND UserId='{2}';", (int)CourseQueryType.Required, courseId, recevice));
                    }
                }

                const int size = 20; //每次最多执行Sql条数
                //总页数
                var pagecount = Math.Ceiling(Convert.ToDouble(listSql.Count) / size);
                for (var i = 0; i < pagecount; i++)
                {
                    var list = listSql.Skip(i * size).Take(size);
                    var sql = string.Join("", list.ToArray());
                    WriteDatabase.Execute(sql);
                }
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }


        /// <summary>
        /// 选择课件（选修）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// 修改：OnlineClassProgress 插入时加入一个字段 LastStudyTime 时间：2014-11-29 张西琼
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseIds">课件编号</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool ChoiceCourse(string userId, string courseIds)
        {
            WriteDatabase.BeginTransaction();

            try
            {
                if (!string.IsNullOrEmpty(courseIds))
                {
                    var courseIdsplit = courseIds.Split(',');
                    var sbSql = new StringBuilder();
                    foreach (var courseId in courseIdsplit.Where(courseId => !string.IsNullOrEmpty(courseId)))
                    {
                        sbSql.AppendFormat(@"INSERT INTO [OnlineClassReceive](CourseId,UserId,ReceiveType,RowStatus) Values ('{0}','{1}',{2},1);INSERT INTO OnlineClassProgress(CourseId,UserId,LastStudyTime) Values ('{0}','{1}','{3}');", courseId, userId, (int)CourseQueryType.Electives, DateTime.Now);
                    }
                    if (sbSql.ToString().Length > 0)
                    {
                        WriteDatabase.Execute(sbSql.ToString());
                    }
                }
            }
            catch (Exception)
            {
                WriteDatabase.AbortTransaction();
                return false;
            }
            WriteDatabase.CompleteTransaction();
            return true;
        }


        /// <summary>
        /// 验证课程是否选过,没有选的话则创建
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// 修改：OnlineClassProgress 插入时加入一个字段 LastStudyTime 时间：2014-11-29 张西琼

        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseIds">课件编号</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public void CheckCourseIsChoice(string userId, string courseIds)
        {

            try
            {
                if (!string.IsNullOrEmpty(courseIds))
                {
                    var courseIdsplit = courseIds.Split(',');
                    var sbSql = new StringBuilder();
                    foreach (var courseId in courseIdsplit.Where(courseId => !string.IsNullOrEmpty(courseId)))
                    {
                        var strSql = string.Format("SELECT COUNT(*) FROM OnlineClassReceive WHERE CourseId='{0}' AND UserId='{1}' AND RowStatus=1", courseId, userId);
                        var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                        if (obj != null && int.Parse(obj.ToString()) == 0)
                        {
                            sbSql.AppendFormat(@"INSERT INTO [OnlineClassReceive](CourseId,UserId,ReceiveType,RowStatus) Values ('{0}','{1}',{2},1);INSERT INTO OnlineClassProgress(CourseId,UserId,LastStudyTime) Values ('{0}','{1}','{3}');", courseId, userId, (int)CourseQueryType.Electives, DateTime.Now);
                            SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 按学习次数查询前多少条课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>Columns->Num:序号,Title:标题,CourseId:课件编号,Scount:学习次数</returns>
        public DataTable StudyCount(int topNum)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP {0} ROW_NUMBER() OVER(ORDER BY TB.Scount) AS Num,OCC.Title ,isnull(TB.Scount,0) as Scount,OCC.Id as CourseId
FROM(SELECT CourseId ,COUNT(*) AS Scount 
FROM OnlineClassRecord AS OCR WITH ( NOLOCK )
GROUP BY  CourseId) AS TB
right JOIN OnlineClassCourse AS OCC WITH ( NOLOCK ) ON OCC.Id = TB.CourseId 
WHERE OCC.Rowstatus=1
ORDER BY TB.Scount DESC", topNum);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 按学习次数查询前多少条课件
        /// 添加人：周 鹏
        /// 添加时间：2015-01-04
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns>Columns->Num:序号,Title:标题,CourseId:课件编号,Scount:学习次数</returns>
        public DataTable StudyCount(int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT OCC.Title ,isnull(TB.Scount,0) as Scount,OCC.Id as CourseId,OCC.Score,OCC.CourseType
FROM(SELECT CourseId ,COUNT(*) AS Scount 
FROM OnlineClassRecord AS OCR WITH ( NOLOCK )
GROUP BY  CourseId) AS TB
RIGHT JOIN OnlineClassCourse AS OCC WITH ( NOLOCK ) ON OCC.Id = TB.CourseId 
WHERE OCC.rowstatus=1 AND CourseType<>{0}", (int)CourseType.Down);

                //                strSql.AppendFormat(@"SELECT TOP {0} ROW_NUMBER() OVER(ORDER BY TB.Scount) AS Num,OCC.Title ,TB.*
                //FROM(SELECT CourseId ,COUNT(*) AS Scount
                //FROM OnlineClassRecord AS OCR WITH ( NOLOCK )
                //GROUP BY  CourseId) AS TB
                //JOIN OnlineClassCourse AS OCC WITH ( NOLOCK ) ON OCC.Id = TB.CourseId
                //ORDER BY TB.Scount DESC", topNum);

                //return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "Scount", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 请求最新前多少条课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="topNum">前多少条</param>
        /// <param name="courseType">课件类型</param>
        /// <param name="oper">运算符</param>
        /// <returns>Columns->Num:编号,Id:编号,Title:标题,Cover:封面</returns>
        public DataTable QueryTopCourse(int topNum, CourseType courseType, string oper = "=")
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP {0} ROW_NUMBER() OVER(ORDER BY OCC.CreateOn DESC) AS Num,OCC.Id,Title,OCA.FileAddress AS Cover
FROM    OnlineClassCourse AS OCC WITH(NOLOCK)
LEFT JOIN OnlineClassAttachment AS OCA WITH(NOLOCK) ON OCC.Cover=OCA.Id ", topNum);

                strSql.AppendFormat(@"WHERE OCC.RowStatus=1 AND OCC.CourseType {0}{1} ", oper, (int)courseType);
                strSql.Append("ORDER BY OCC.CreateOn DESC");

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据课程类型查询个人的前多少件课程
        /// 添加人：周 鹏
        /// 添加时间：2014-11-13
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="topNum">前多少条</param>
        /// <param name="courseQueryType">查询类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Progress:学习进度,Score:课程分值,CourseType:课程类型,ReceiveType:学习类型（选修、必修）</returns>
        public DataTable PersonelCourse(string userId, int topNum, CourseQueryType courseQueryType, string keyword)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT TOP {0} OCC.Id,OCC.Title,Progress,OCC.Score,CourseType,OCR.ReceiveType FROM OnlineClassProgress AS OCP WITH(NOLOCK)
JOIN OnlineClassCourse AS OCC WITH(NOLOCK) ON OCP.CourseId=OCC.Id and OCC.RowStatus=1
JOIN OnlineClassReceive AS OCR WITH(NOLOCK) ON OCP.UserId=OCR.UserId AND OCP.CourseId=OCR.CourseId and OCR.RowStatus=1
WHERE OCP.RowStatus=1 AND OCP.UserId='{1}' AND OCC.CourseType<>4 ", topNum, userId);

                switch (courseQueryType)
                {
                    case CourseQueryType.Electives:    //正在学习
                        strSql.AppendFormat("AND OCP.Progress<100 AND OCR.ReceiveType={0}", (int)CourseQueryType.Electives);
                        break;
                    case CourseQueryType.Required:     //必修课
                        strSql.AppendFormat("AND OCP.Progress<100 AND OCR.ReceiveType={0}", (int)CourseQueryType.Required);
                        break;
                    case CourseQueryType.Finish:       //已完成
                        strSql.Append("AND OCP.Progress=100");
                        break;
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND OCC.Title LIKE '%{0}%' ", keyword);
                }
                strSql.Append("ORDER BY OCP.CreateOn DESC");   //按课程添加时间进行排序

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据课程类型查询个人课程
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseQueryType">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Progress:学习进度,Score:课程分值,CourseType:课程类型,CreateOn:课程选择（添加）日期</returns>
        public DataTable PersonelCourse(string userId, CourseQueryType courseQueryType, int pageIndex, int pageSize, out int totalRecords, string keyword = "")
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT OCC.Id,OCC.Title,Progress,OCC.Score,CourseType,OCR.ReceiveType,OCP.CreateOn FROM OnlineClassProgress AS OCP WITH(NOLOCK)
JOIN OnlineClassCourse AS OCC WITH(NOLOCK) ON OCP.CourseId=OCC.Id 
JOIN OnlineClassReceive AS OCR WITH(NOLOCK) ON OCP.UserId=OCR.UserId AND OCP.CourseId=OCR.CourseId 
WHERE OCR.RowStatus=1 AND OCC.RowStatus=1 AND OCP.RowStatus=1 AND OCP.UserId='{0}' AND OCC.CourseType<>4 ", userId);

                switch (courseQueryType)
                {
                    case CourseQueryType.Electives:    //正在学习
                        strSql.AppendFormat("AND OCP.Progress<100 AND OCR.ReceiveType={0}", (int)CourseQueryType.Electives);
                        break;
                    case CourseQueryType.Required:     //必修课
                        strSql.AppendFormat("AND OCP.Progress<100 AND OCR.ReceiveType={0}", (int)CourseQueryType.Required);
                        break;
                    case CourseQueryType.Finish:       //已完成
                        strSql.Append("AND OCP.Progress=100");
                        break;
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND OCC.Title LIKE '%{0}%'", keyword);
                }
                //strSql.Append("ORDER BY OCP.CreateOn DESC");   //按课程添加时间进行排序
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 课程查询
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// 修改：修改查询语句，查询选课类型  时间：2014-12-2 张西琼
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseType">课程类型</param>
        /// <param name="categoryId">课程分类</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="oper">运算符（不等号、等号）（默认不查询下载类课程）</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="keyword">查询关键字</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Score:课程分值,CourseType:课程类型,CreateOn:课程创建日期</returns>
        public DataTable Course(string userId, CourseType? courseType, string categoryId, int pageIndex, int pageSize, out int totalRecords, string oper = "<>", string keyword = "")
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT OCC.Id ,OCC.Title ,OCC.Score,OCC.CourseType,OCC.CreateOn,
(SELECT COUNT(*) FROM OnlineClassRecord WITH(NOLOCK) WHERE CourseId = OCC.Id) AS StudyCount,
ISNULL((SELECT COUNT(*) FROM OnlineClassReceive WITH(NOLOCK) WHERE CourseId=OCC.Id AND UserId='{0}' AND RowStatus=1),0) AS IsSelect
FROM OnlineClassCourse AS OCC WITH(NOLOCK) WHERE OCC.RowStatus=1 AND OCC.CourseType {1}{2}
", userId, oper, (int)CourseType.Down);

                if (!string.IsNullOrEmpty(categoryId))
                {
                    strSql.AppendFormat(@" AND CategoryId='{0}'", categoryId);
                }

                if (courseType != null)
                {
                    strSql.AppendFormat(@" AND OCC.CourseType={0}", (int)courseType);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND OCC.Title LIKE '%{0}%'", keyword);
                }

                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 课程查询（所有课程）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseType">课程类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="keyword">查询关键字</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Score:课程分值,CourseType:课程类型,CreateOn:课程创建日期</returns>
        //        public DataTable CourseManager(CourseType? courseType, int pageIndex, int pageSize, out int totalRecords, string keyword)
        //        {
        //            try
        //            {
        //                var strSql = new StringBuilder("");
        //                strSql.AppendFormat(@"SELECT OCC.Id ,OCC.Title ,OCC.Score,OCC.CourseType,OCC.CreateOn
        //FROM OnlineClassCourse AS OCC WITH(NOLOCK) WHERE OCC.RowStatus=1 ");

        //                if (courseType != null)
        //                {
        //                    strSql.AppendFormat(@" AND OCC.CourseType={0}", (int)courseType);
        //                }

        //                if (!string.IsNullOrEmpty(keyword))
        //                {
        //                    strSql.AppendFormat(@" AND OCC.Title LIKE '%{0}%'", keyword);
        //                }
        //                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message, ex);
        //            }
        //        }
        public Page<OnlineClassCourseEntity> GetCourseManager(string courseTypeId, int pageIndex, int pageSize, string keyword)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM OnlineClassCourse  WITH(NOLOCK) WHERE RowStatus=1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(courseTypeId))
            {
                strSql.AppendFormat(@" AND CourseType='{0}'", Convert.ToInt32(courseTypeId));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.AppendFormat(@"AND Title LIKE '%{0}%'", keyword);
            }
            strSql.Append(" ORDER BY CreateOn Desc");
            return WriteDatabase.Page<OnlineClassCourseEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }
        /// <summary>
        /// 课程详情
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseId">课程编号</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Score:课程分值,CourseType:课程类型,Progress:学习进度,Describle:学习时长,Category:课程分类</returns>
        public DataTable CouserDetails(string userId, string courseId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT OCC.Id,OCC.Title,OCC.Score,OCC.LinkUrl,OCC.CourseType,CR.RsKey AS Category,OCC.Describle,Duration,ISNULL(OCP.Progress,0) AS Progress FROM OnlineClassCourse AS OCC WITH(NOLOCK)
JOIN ComResource AS CR WITH(NOLOCK) ON OCC.CategoryId=CR.Id 
LEFT JOIN OnlineClassProgress AS OCP WITH(NOLOCK) ON OCC.Id=OCP.CourseId AND OCP.UserId='{0}'
WHERE OCP.RowStatus=1 AND OCC.Id='{1}'", userId, courseId);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取课程的接收人
        /// 添加人：周 鹏
        /// 添加时间：2015-01-04
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-03-23 周 鹏 增加必修作为条件进行过滤
        /// </history>
        /// /// <param name="courseId">课程编号</param>
        /// <returns>Columns->UserIds：用户编号集,UserNames：用姓名集</returns>
        public DataTable GetReceiveUsers(string courseId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT (
SELECT (SELECT LOWER(CU.Id)+',' FROM OnlineClassReceive AS OCR
JOIN CrmUser AS CU ON OCR.UserId=CU.Id AND CU.RowStatus=1
WHERE CourseId='{0}' 
AND OCR.RowStatus=1 AND OCR.ReceiveType={1}
FOR XML PATH('')) AS UserIds) UserIds,
(SELECT (SELECT CU.RealName+',' FROM OnlineClassReceive AS OCR
JOIN CrmUser AS CU ON OCR.UserId=CU.Id
JOIN OnlineClassUserGroup AS OCUG ON OCR.UserId=OCUG.UserId AND OCUG.RowStatus=1
WHERE CourseId='{0}' AND OCR.ReceiveType={1}
AND OCR.RowStatus=1 ORDER BY OCUG.SortNo
FOR XML PATH('')) AS UserNames) UserNames", courseId, (int)CourseQueryType.Required);

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// UpdateStr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public string UpdateStr(OnlineClassCourseEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.Title))
            {
                strSqlLink.AppendFormat(@" Title = '{0}',", search.Title);
            }
            if (!string.IsNullOrEmpty(search.Contents))
            {
                strSqlLink.AppendFormat(@" Contents = '{0}',", search.Contents);
            }
            if (!string.IsNullOrEmpty(search.Describle))
            {
                strSqlLink.AppendFormat(@" Describle = '{0}',", search.Describle);
            }
            if (!string.IsNullOrEmpty(search.LinkUrl))
            {
                strSqlLink.AppendFormat(@" LinkUrl = '{0}',", search.LinkUrl);
            }
            if (!string.IsNullOrEmpty(search.Cover))
            {
                strSqlLink.AppendFormat(@" Cover = '{0}',", search.Cover);
            }
            if (search.Score > 0)
            {
                strSqlLink.AppendFormat(@" Score = '{0}',", search.Score);
            }
            if (search.CourseType > 0 && search.CourseType < 5)
            {
                strSqlLink.AppendFormat(@" CourseType = '{0}',", search.CourseType);
            }
            if (!string.IsNullOrEmpty(search.CategoryId))
            {
                strSqlLink.AppendFormat(@" CategoryId = '{0}',", search.CategoryId);
            }
            if (search.Duration > 0)
            {
                strSqlLink.AppendFormat(@" Duration = '{0}',", search.Duration);
            }
            if (!string.IsNullOrEmpty(search.StartTime.ToString()))
            {
                strSqlLink.AppendFormat(@" StartTime = '{0}',", search.StartTime);
            }
            if (!string.IsNullOrEmpty(search.EndTime.ToString()))
            {
                strSqlLink.AppendFormat(@" EndTime = '{0}',", search.EndTime);
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
            var strSql = string.Format(@"UPDATE OnlineClassCourse SET {0} RowStatus={1}  WHERE Id='{2}';", strSqlLink, search.RowStatus, search.Id);
            return strSql;
        }
        /// <summary>
        /// 新增课件InsertStr
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string InsertStr(OnlineClassCourseEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[OnlineClassCourse]
           ([Id],[Title],[Contents],[Describle],[LinkUrl]
           ,[Cover],[Score],[CourseType],[CategoryId],[Duration]
           ,[StartTime],[EndTime]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}');",
            entity.Id, entity.Title, entity.Contents, entity.Describle, entity.LinkUrl,
            entity.Cover, entity.Score, entity.CourseType, entity.CategoryId, entity.Duration,
            entity.StartTime, entity.EndTime,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return strSql;
        }
    }
}