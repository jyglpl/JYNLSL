using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    /// <summary>
    /// 网上课堂数据统计数据访问操作
    /// </summary>
    public class OnlineClassStatisticDal
    {
        /// <summary>
        /// 动态数据统计
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>Columns->Student:学员数,Visit:访问数,Course:课程数,StudyRecord:学习次数</returns>
        public DataTable DynamicData()
        {
            try
            {
                var sbSql = new StringBuilder("");
                sbSql.Append(@"SELECT 
(SELECT COUNT(*) FROM OnlineClassUserGroup AS OCUG WITH(NOLOCK) JOIN CrmUser AS CU WITH(NOLOCK) ON CU.Id=OCUG.UserId WHERE CU.RowStatus=1 AND OCUG.RowStatus=1) AS Student,
(SELECT COUNT(*) FROM ComVisitRecord WHERE DATEDIFF(DAY,GETDATE(),CreateOn)=0) AS Visit,
(SELECT COUNT(*) FROM OnlineClassCourse WHERE RowStatus=1 AND CourseType<>4) AS Course,
(SELECT COUNT(*) FROM OnlineClassRecord) AS StudyRecord");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 个人积分及排名
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2014-12-04 周 鹏 修改算法Sql
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns>Columns->OrderNo:排名,Score:积分</returns>
        public DataTable PersonalSroceAndRank(string userId)
        {
            try
            {
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat(@"EXEC OnlineClassPersonalSroceAndRank '{0}'", userId);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 个人统计
        /// 添加人：周 鹏
        /// 添加时间：2014-11-17
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2014-12-04 周 鹏 修改算法Sql
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns>Colums->Electives:选修,[Required]:必修,Finished:已完成,Score:分值,OrderNo:排名</returns>
        public DataTable PersonalStatistic(string userId)
        {
            try
            {
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat(@"EXEC OnlineClassPersonalSroceAndRank '{0}'", userId);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 个人学习明细统计
        /// 添加人：周 鹏
        /// 添加时间：2014-11-17
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns>Columns->Id:课件编号,Title:课件标题,Progress:学习进度,Score:学分,CourseType:课件类型,ReceiveType:学习类型,CreateOn</returns>
        public DataTable PersonalStatisticDetails(string userId, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat(@"SELECT OCC.Id,OCC.Title,Progress,OCC.Score AS Score,CourseType,OCR.ReceiveType,OCP.CreateOn FROM OnlineClassProgress AS OCP WITH(NOLOCK)
JOIN OnlineClassCourse AS OCC WITH(NOLOCK) ON OCP.CourseId=OCC.Id 
JOIN OnlineClassReceive AS OCR WITH(NOLOCK) ON OCP.UserId=OCR.UserId AND OCP.CourseId=OCR.CourseId 
WHERE OCP.RowStatus=1 AND ocr.RowStatus=1 AND OCP.UserId='{0}' AND OCC.CourseType<>4 ", userId);
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 课件学习明细
        /// 添加人：周 鹏
        /// 添加时间：2014-12-04
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseId">课件编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable IndividualSatistic(string userId, string courseId, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = 0;
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat(@"SELECT CourseId,UserId,OC.Title, CONVERT(VARCHAR(100), OCR.StartTime,20)AS StartTime,CONVERT(VARCHAR(100),OCR.EndTime,20)AS EndTime,ISNULL(Ip,'未知')as Ip,StudyTime  
FROM dbo.OnlineClassRecord  AS OCR 
JOIN  OnlineClassCourse AS OC ON OCR.CourseId=OC.Id
WHERE OCR.RowStatus=1 AND OC.RowStatus=1 AND OCR.UserId='{0}' and CourseId='{1}'", userId, courseId);

                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "StartTime", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据个人查看统计分析
        /// 添加人：张西琼
        /// 时间：2014-11-21
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2014-12-05 周 鹏 修改算法Sql
        ///           2014-12-10 周 鹏 修改为存储过程
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWords">查询关键字</param>
        /// <param name="totalRecords"></param>
        /// <param name="isPage">是否分页</param>
        /// <returns></returns>
        public DataTable StatisticByIndividual(string userId, int pageIndex, int pageSize, string keyWords, out int totalRecords, bool isPage = true)
        {
            try
            {
                using (var connection = new SqlConnection(SqlHelper.SqlConnStringRead))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "OnlineClassPersonalStatistics";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_Columns", SqlDbType.NVarChar);
                    cmd.Parameters["P_Columns"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_Columns"].Value = "*";
                    cmd.Parameters.Add("P_Condition", SqlDbType.NVarChar);
                    cmd.Parameters["P_Condition"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_Condition"].Value = "";
                    cmd.Parameters.Add("P_Dir", SqlDbType.NVarChar);
                    cmd.Parameters["P_Dir"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_Dir"].Value = "GroupSort,UserRank,UserName";
                    cmd.Parameters.Add("P_Sort", SqlDbType.NVarChar);
                    cmd.Parameters["P_Sort"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_Sort"].Value = "ASC";
                    cmd.Parameters.Add("IsPage", SqlDbType.Int);
                    cmd.Parameters["IsPage"].Direction = ParameterDirection.Input;
                    cmd.Parameters["IsPage"].Value = isPage ? 1 : 0;
                    cmd.Parameters.Add("P_PageIndex", SqlDbType.Int);
                    cmd.Parameters["P_PageIndex"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_PageIndex"].Value = pageIndex;
                    cmd.Parameters.Add("P_PageSize", SqlDbType.Int);
                    cmd.Parameters["P_PageSize"].Direction = ParameterDirection.Input;
                    cmd.Parameters["P_PageSize"].Value = pageSize;
                    cmd.Parameters.Add("KeyWords", SqlDbType.NVarChar);
                    cmd.Parameters["KeyWords"].Direction = ParameterDirection.Input;
                    cmd.Parameters["KeyWords"].Value = keyWords;

                    cmd.Parameters.Add("P_Totalrecords", SqlDbType.Int);
                    cmd.Parameters["P_Totalrecords"].Direction = ParameterDirection.Output;
                    cmd.Parameters["P_Totalrecords"].Value = 0;
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    dataAdapter.Fill(dt);
                    totalRecords = int.Parse(cmd.Parameters["P_Totalrecords"].Value.ToString());
                    connection.Close();
                    connection.Dispose();
                    cmd.Dispose();
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 根据课程统计分析
        /// 添加人：张西琼
        /// 时间：2014-11-21
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2014-12-05 周 鹏 修改算法Sql
        ///           2014-12-10 周 鹏 修改算法Sql
        ///           2015-01-05 周 鹏 增加是否分页
        /// </history>
        /// <returns></returns>
        public DataTable StatisticByCourse(int pageIndex, int pageSize, out int totalRecords, bool isPage = true)
        {
            try
            {
                string strSql = @"SELECT OCC.Id,OCC.Title,OCC.CourseType,OCC.Score,OCC.CreateOn,
(SELECT COUNT(*) FROM OnlineClassReceive AS OCR JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCR.UserId WHERE OCU.RowStatus=1 AND OCR.RowStatus=1 AND CourseId=OCC.Id AND OCR.RowStatus=1 AND OCR.ReceiveType=2) AS [ReNum],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=2 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>0) AS [Studyed],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=2 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>=100) AS [Finished],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=2 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>=100 AND YEAR(OCC.EndTime)<>1900 AND FinishTime>OCC.EndTime) AS [Delayed],
(SELECT COUNT(*) FROM OnlineClassReceive AS OCR JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCR.UserId WHERE OCU.RowStatus=1 AND CourseId=OCC.Id AND OCR.RowStatus=1 AND OCR.ReceiveType=1) AS [ElNum],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=1 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>0) AS [ELStudyed],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=1 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>=100) AS [ELFinished],
(SELECT COUNT(*) FROM OnlineClassProgress AS OCP JOIN OnlineClassUserGroup AS OCU ON OCU.UserId=OCP.UserId AND OCU.RowStatus=1 JOIN OnlineClassReceive AS OCR ON OCR.UserId=OCP.UserId AND OCR.CourseId=OCP.CourseId AND OCR.RowStatus=1 WHERE OCR.ReceiveType=1 AND OCP.RowStatus=1 AND OCP.CourseId=OCC.Id AND Progress>=100 AND YEAR(OCC.EndTime)<>1900 AND FinishTime>OCC.EndTime) AS [ELDelayed]
FROM OnlineClassCourse AS OCC WHERE OCC.RowStatus=1 AND OCC.CourseType<>4";

                if (isPage)
                {
                    return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql, "*", "", "CreateOn", "DESC",
                                                    pageIndex, pageSize, out totalRecords);
                }
                else
                {
                    strSql += "ORDER BY CreateOn DESC";
                    var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
                    totalRecords = dt.Rows.Count;
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据课程查看统计分析明细
        /// 添加人：张西琼
        /// 添加时间：2014-11-21
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2014-12-05 周 鹏 修改算法Sql
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable StatisticByCourseDetails(string courseId, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.AppendFormat(@"SELECT OCP.CourseId,OCUP.SortNo AS UserSort,OCP.UserId, (CASE OCR.ReceiveType WHEN 1 THEN '选修' WHEN 2 THEN '必修' END) AS ReceiveType,
CU.UserName,OCG.OrderNo AS GroupOrder,ISNULL(OCG.GroupName,'未知') AS GroupName,OCP.FinishTime,OCC.EndTime,OCP.Progress FROM OnlineClassProgress AS OCP
JOIN OnlineClassReceive AS OCR ON OCP.CourseId=OCR.CourseId AND OCP.UserId=OCR.UserId AND OCR.RowStatus=1
JOIN OnlineClassCourse AS OCC ON OCC.Id=OCP.CourseId AND OCC.RowStatus=1
JOIN CrmUser AS CU ON CU.Id=OCP.UserId
JOIN OnlineClassUserGroup as OCUP ON OCP.UserId=OCUP.UserId AND OCUP.RowStatus=1
JOIN OnlineClassGroup AS OCG ON OCUP.GroupId=OCG.Id AND OCG.RowStatus=1 
WHERE OCP.CourseId='{0}' AND OCP.RowStatus=1", courseId);
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "GroupOrder,UserSort", "ASC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 个人课程明细
        /// 添加人：张西琼
        /// 时间：2014-11-21
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable IndividualCourseDetails(string userId, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select OC.Id,OC.TITLE ,OCP.Integral ,OC.CourseType from dbo.OnlineClassProgress AS OCP 
JOIN dbo.OnlineClassCourse AS OC ON OCP.CourseId=OC.Id AND OC.RowStatus=1
 WHERE OCP.RowStatus=1 ");
                if (!string.IsNullOrEmpty(userId))
                {
                    strSql.AppendFormat(@" and UserId='{0}'", userId);

                }
                //strSql.Append(" ORDER BY CourseType");
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CourseType", "ASC", pageIndex, pageSize, out totalRecords);
                //return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}