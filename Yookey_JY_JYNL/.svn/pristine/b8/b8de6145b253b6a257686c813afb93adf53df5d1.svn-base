using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OfficeIndex;
using Yookey.WisdomClassed.SIP.Model.Exam;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OfficeIndex
{
    public class OfficeIndexBll
    {
        private readonly OfficeIndexDal Dal = new OfficeIndexDal();
        /// <summary>
        /// 获取全部课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> GetAllCourseTypeCount()
        {
            return Dal.GetAllCourseTypeCount();
        }

        /// <summary>
        /// 获取视频类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> VideoCourseTypeCount()
        {
            return Dal.VideoCourseTypeCount();
        }

        /// <summary>
        /// 获取音频类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> AudioCourseTypeCount()
        {
            return Dal.AudioCourseTypeCount();
        }

        /// <summary>
        /// 获取图文类课件总数
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassCourseEntity> GraphicCourseTypeCount()
        {
            return Dal.GraphicCourseTypeCount();
        }

        /// <summary>
        /// 获取参考人员总数
        /// </summary>
        /// <returns></returns>
        public int ReferencepeopleCount()
        {
            return Dal.ReferencepeopleCount();
        }

        /// <summary>
        /// 获取参考次数
        /// </summary>
        /// <returns></returns>
        public List<ExamInfoMationEntity> Ksnumber()
        {
            return Dal.Ksnumber();
        }

        /// <summary>
        /// 获取今日案件投诉量
        /// </summary>
        /// <returns></returns>
        public int TodayCount()
        {
            return Dal.TodayCount();
        }

        /// <summary>
        /// 获取今日投诉处理
        /// </summary>
        /// <returns></returns>
        public int TodaydealCount()
        {
            return Dal.TodaydealCount();
        }

        /// <summary>
        /// 获取信访投诉办结率
        /// </summary>
        /// <returns></returns>
        public int Todaydealrate()
        {
            return Dal.Todaydealrate();
        }

        /// <summary>
        /// 获取阳光信访
        /// </summary>
        /// <returns></returns>
        public int Complaintreporting()
        {
            return Dal.Complaintreporting();
        }

        /// <summary>
        /// 获取区党政办
        /// </summary>
        /// <returns></returns>
        public int Districtparty()
        {
            return Dal.Districtparty();
        }

        /// <summary>
        /// 获取区信访科
        /// </summary>
        /// <returns></returns>
        public int AreaComplaintreporting()
        {
            return Dal.AreaComplaintreporting();
        }

        /// <summary>
        /// 获取区公众监督
        /// </summary>
        /// <returns></returns>
        public int AreaPublic()
        {
            return Dal.AreaPublic();
        }

        /// <summary>
        /// 获取市局
        /// </summary>
        /// <returns></returns>
        public int Citybureau()
        {
            return Dal.Citybureau();
        }

        /// <summary>
        /// 获取学习时长TOP10
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetOnlineClassSumTime()
        {
            return Dal.GetOnlineClassSumTime();
        }
    }
}
