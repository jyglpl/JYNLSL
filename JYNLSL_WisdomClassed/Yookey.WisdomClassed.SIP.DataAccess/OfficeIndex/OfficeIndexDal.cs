using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OfficeIndex
{
    public class OfficeIndexDal : BaseDal<OnlineClassProgressEntity>
    {
        /// <summary>
        /// 获取全部课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> GetAllCourseTypeCount()
        {
            var strSql = string.Format("SELECT * FROM OnlineClassCourse WHERE RowStatus=1");
            return WriteDatabase.Query<OnlineClassCourseEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取视频类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> VideoCourseTypeCount()
        {
            var strSql = string.Format("SELECT * FROM OnlineClassCourse WHERE RowStatus=1 AND Coursetype='1' ");
            return WriteDatabase.Query<OnlineClassCourseEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取音频类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> AudioCourseTypeCount()
        {
            var strSql = string.Format("SELECT * FROM OnlineClassCourse WHERE RowStatus=1 AND Coursetype='2' ");
            return WriteDatabase.Query<OnlineClassCourseEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取图文类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> GraphicCourseTypeCount()
        {
            var strSql = string.Format("SELECT * FROM OnlineClassCourse WHERE RowStatus=1 AND Coursetype='3' ");
            return WriteDatabase.Query<OnlineClassCourseEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取参考次数
        /// </summary>
        /// <returns></returns>
        public List<ExamInfoMationEntity> Ksnumber()
        {
            var strSql = string.Format("SELECT * FROM ExamInfomation WHERE 1=1");
            return WriteDatabase.Query<ExamInfoMationEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 获取参考人员总数
        /// </summary>
        /// <returns></returns>
        public int ReferencepeopleCount()
        {
            var strSql = string.Format("SELECT COUNT(*) FROM CrmUser");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取今日案件投诉量
        /// </summary>
        /// <returns></returns>
        public int TodayCount()
        {
            var strSql = string.Format("select count(*) from petition where ReceiveDate=DATENAME(year,GETDATE())+'-'+ DATENAME(MONTH,GETDATE())+'-'+ DATENAME(DAY,GETDATE())");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取今日投诉处理
        /// </summary>
        /// <returns></returns>
        public int TodaydealCount()
        {
            var strSql = string.Format("select COUNT(*) from Petition where Status = 30 and ReceiveDate=DATENAME(year,GETDATE())+'-'+ DATENAME(MONTH,GETDATE())+'-'+ DATENAME(DAY,GETDATE())");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取信访投诉办结率
        /// </summary>
        /// <returns></returns>
        public int Todaydealrate()
        {
            var strSql = string.Format("select cast(round(((select COUNT(*) from Petition where Status = 30)/((select count(*) from petition)*1.0))*100,2)as int)");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取阳光信访
        /// </summary>
        /// <returns></returns>
        public int Complaintreporting()
        {
            var strSql = string.Format("select count(*) from petition where PetitionSource like '%00810001%'");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取区党政办
        /// </summary>
        /// <returns></returns>
        public int Districtparty()
        {
            var strSql = string.Format("select COUNT(*) from petition where PetitionSource like '%00810002%'");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取区信访科
        /// </summary>
        /// <returns></returns>
        public int AreaComplaintreporting()
        {
            var strSql = string.Format("select count(*) from petition where PetitionSource like '%00810003%'");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取区公众监督
        /// </summary>
        /// <returns></returns>
        public int AreaPublic()
        {
            var strSql = string.Format("select count(*) from petition where PetitionSource like '%00810004%'");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取市局
        /// </summary>
        /// <returns></returns>
        public int Citybureau()
        {
            var strSql = string.Format("select count(*) from petition where PetitionSource like '%00810005%'");
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取学习时长TOP10
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetOnlineClassSumTime()
        {
            try
            {
                var str = new StringBuilder("");
                str.AppendFormat(@"select top 10 userId,sum(cast(totaltime as int))/60/60 SumTime from OnlineClassProgress 
                                                         group by userId
                                                         order by sum(cast(totaltime as int)) desc");
                return WriteDatabase.Query<OnlineClassProgressEntity>(str.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
