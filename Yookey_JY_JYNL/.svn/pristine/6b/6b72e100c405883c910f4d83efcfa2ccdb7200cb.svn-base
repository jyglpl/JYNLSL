using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassProgressBll
    {
        private readonly OnlineClassProgressDal _dal = new OnlineClassProgressDal();

         /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassProgressEntity Get(string Id)
        {
            return _dal.Get(Id);
        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetSearchResult(OnlineClassProgressEntity search)
        {
            return _dal.GetSearchResult(search);
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassProgressEntity> GetSearchResult(OnlineClassProgressEntity search, string startTime, string endTime)
        {
            return _dal.GetSearchResult(search, startTime, endTime);
        }

        /// <summary>
        /// 删除接收人
        /// 不确定根据什么删除
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public bool Delete(string courseId)
        {
            return _dal.Delete(courseId);
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
            return _dal.DeleteChoice(userId, courseId);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassProgressEntity entity)
        {
            return _dal.Update(entity);
        }

         /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassProgressEntity entity)
        {
            return _dal.Insert(entity);
        }

        /// <summary>
        /// 验证课程是否选过,没有选的话则创建
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public void CheckCourseIsChoice(string userId, string courseId)
        {
            try
            {
                new OnlineClassCourseDal().CheckCourseIsChoice(userId, courseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 学习记录
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseId">课程编号</param>
        /// <param name="courseType">课程类型</param>
        /// <param name="startTime">开始学习时间</param>
        /// <param name="studyTime">本次学习时长</param>
        /// <param name="studySec">最后一次学习记录（注：视频播放已学习时长,其它学习用不到）</param>
        /// <param name="isFinish">是否学习完成（注：视频播放已学习时长,其它学习用不到）</param>
        /// <param name="videoTime">视频时长（注：视频时长，其它学习用不到）</param>
        /// <param name="ip">客户端IP</param>
        /// <returns></returns>
        public bool StudyRecord(string userId, string courseId, CourseType courseType, string startTime, int studyTime,
                                string studySec, string isFinish, string videoTime, string ip)
        {
            try
            {
                //课件基本信息
                var courseEntity = new OnlineClassCourseBll().Get(courseId);

                //学习进度相关信息
                OnlineClassProgressEntity OCPEntity=new OnlineClassProgressEntity();
                OCPEntity.CourseId=courseId;
                OCPEntity.UserId=userId;
                var list = _dal.GetSearchResult(OCPEntity);

                if (list == null || list.Count <= 0) return false;

                var duration = courseEntity.Duration; //课件时长
                var score = courseEntity.Score; //课件积分

                var lastStudySec = list[0].LastStudySec; //最后一次学习的秒
                var totalTime = list[0].TotalTime; //累计学习时长
                var progress = list[0].Progress; //学习进度
                var integral = list[0].Integral; //学习积分

                switch (courseType)
                {
                    case CourseType.Video: //视频计算学习进度及积分
                        {
                            lastStudySec = studySec;
                            //与本次学习时间进行累加
                            totalTime = (Convert.ToInt32(totalTime) + studyTime).ToString();

                            if (isFinish.Equals("1") || progress >= 100) //当前学习完成或者已经学习过
                            {
                                integral = score;
                                progress = 100;
                            }

                            //计算学习进度
                            if (progress < 100)
                            {
                                //学习进度=已学习时长/视频总时长*100
                                progress = Convert.ToInt32(double.Parse(lastStudySec) / double.Parse(videoTime) * 100);
                                progress = progress > 100 ? 100 : progress;
                            }
                        }
                        break;
                    case CourseType.Voice: //音频、图片计算学习进度及积分
                    case CourseType.Political:
                        {
                            //与本次学习时间进行累加
                            totalTime = (Convert.ToInt32(totalTime) + studyTime).ToString();

                            if (progress >= 100) //已经学习过
                            {
                                integral = score;
                                progress = 100;
                            }
                            else if (Convert.ToInt32(totalTime) >= (duration * 60)) //当前学习完成（根据时间累计）
                            {
                                integral = score;
                                progress = 100;
                            }

                            //计算学习进度
                            if (progress < 100)
                            {
                                //学习进度=已学习时长/课件设置时长*100
                                progress = Convert.ToInt32(double.Parse(totalTime) / (duration * 60) * 100);
                                progress = progress > 100 ? 100 : progress;
                            }
                        }
                        break;
                }
                return new OnlineClassProgressDal().SaveProgress(userId, courseId, startTime, progress, integral,
                                                                 totalTime,
                                                                 studyTime, lastStudySec, ip);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
