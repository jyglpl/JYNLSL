using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.OnlineClass;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.OnlineClass
{
    public class CourseController : BaseController
    {
        /// <summary>
        /// 课件中心
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="categoryId">分类编号</param>
        /// <param name="courseTypeId">课程类型</param>
        /// <param name="page">当前索引页</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public ActionResult CourseCenter(string categoryId, string courseTypeId, int? page, string keyword)
        {
            var user = CurrentUser.CrmUser;
            //课程分类
            var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0007" });
            ViewData["Classify"] = courseClassify;
            ViewBag.Keyword = keyword;

            const int pageSize = 20;
            PageObject<DataTable> models;
            if (!string.IsNullOrEmpty(courseTypeId))
            {
                models = new OnlineClassCourseBll().Course(user.Id, (CourseType)Enum.Parse(typeof(CourseType), courseTypeId), categoryId,
                                                           page ?? 1, pageSize, "<>", keyword);
            }
            else
            {
                models = new OnlineClassCourseBll().Course(user.Id, null, categoryId,
                                                           page ?? 1, pageSize, "<>", keyword);
            }
            return View(models);
        }

        /// <summary>
        /// 个人中心
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult PersonalCenter(string keyword, int rows = 20, int page = 1)
        {
            // 设置搜索内容
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            else
            {
                ViewBag.keyword = keyword;
            }

            var user = CurrentUser.CrmUser;
            ////登录名
            //ViewBag.UserName = user.UserName;
            ////查询积分及排名
            //var sroceandrank = new OnlineClassStatisticBll().PersonalSroceAndRank(user.Id);
            //var sroce = sroceandrank.Rows.Count > 0 ? sroceandrank.Rows[0]["SumScore"].ToString() : "0";
            //var rank = sroceandrank.Rows.Count > 0 ? sroceandrank.Rows[0]["UserRank"].ToString() : "0";
            ////当前学分
            //ViewBag.Source = sroce;
            ////学分排名
            //ViewBag.Rank = rank;
            ////消息通知
            //ViewBag.NoticeStayRead = new ComNoticeBll().NoticeStayRead(user.Id);
            ////课件学习排行
            //var topCourse = new OnlineClassCourseBll().StudyCount();
            ////动态数据
            //var dynamic = new OnlineClassStatisticBll().DynamicData();

            //正在学习的课程

            //var electives = new OnlineClassCourseBll().PersonelCourse(user.Id, 20, CourseQueryType.Electives, keyword);
            var electives = new OnlineClassCourseBll().PersonelCourse(user.Id,
                                                                   (CourseQueryType)
                                                                   Enum.Parse(typeof(CourseQueryType), "1"),
                                                                   page,
                                                                   rows, keyword);
            //必修的课程
            //var required = new OnlineClassCourseBll().PersonelCourse(user.Id, 20, CourseQueryType.Required, keyword);
            var required = new OnlineClassCourseBll().PersonelCourse(user.Id,
                                                                  (CourseQueryType)
                                                                  Enum.Parse(typeof(CourseQueryType), "2"),
                                                                  page,
                                                                  rows, keyword);
            //已完成的课程
            //var finish = new OnlineClassCourseBll().PersonelCourse(user.Id, 20, CourseQueryType.Finish, keyword);
            var finish = new OnlineClassCourseBll().PersonelCourse(user.Id,
                                                                  (CourseQueryType)
                                                                  Enum.Parse(typeof(CourseQueryType), "3"),
                                                                  page,
                                                                  rows, keyword);
            //ViewBag.Online = GetOnlineUserCount();

            //ViewData["TopCourse"] = topCourse;
            //ViewData["Dynamic"] = dynamic;

            //课程类型
            ViewData["CourseType"] = EnumOperate.ConvertEnumToDictionary(typeof(CourseType));

            ViewData["Electives"] = electives;
            ViewData["Required"] = required;
            ViewData["Finish"] = finish;

            return View();
        }

        /// <summary>
        /// 个人中心->课程列表（正在学习的课程、必修的课程、已完成的课程）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult PersonalCourse(string typeId)
        {
            var user = CurrentUser.CrmUser;
            //登录名
            ViewBag.UserName = user.UserName;

            //查询积分及排名
            //var sroceandrank = new OnlineClassStatisticBll().PersonalSroceAndRank(user.Id);
            //var sroce = sroceandrank.Rows.Count > 0 ? sroceandrank.Rows[0]["SumScore"].ToString() : "0";
            //var rank = sroceandrank.Rows.Count > 0 ? sroceandrank.Rows[0]["UserRank"].ToString() : "0";

            ////当前学分
            //ViewBag.Source = sroce;
            ////学分排名
            //ViewBag.Rank = rank;
            ////消息通知
            //ViewBag.NoticeStayRead = new ComNoticeBll().NoticeStayRead(user.Id);
            ////课件学习排行
            //var topCourse = new OnlineClassCourseBll().StudyCount();
            ////动态数据
            //var dynamic = new OnlineClassStatisticBll().DynamicData();

            //ViewData["TopCourse"] = topCourse;
            //ViewData["Dynamic"] = dynamic;

            //ViewBag.OnLine = GetOnlineUserCount();

            //查询类型编号
            ViewBag.TypeId = typeId;
            //查询类型名称
            ViewBag.TypeName = EnumOperate.GetEnumDesc((CourseQueryType)Enum.Parse(typeof(CourseQueryType), typeId));

            return View();
        }

        /// <summary>
        /// 个人中心课程列表
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="typeId">查询类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public ActionResult PersonalCourseType(string typeId, string keyword, int rows = 30, int page = 1)
        {
            //if (!Request.IsAjaxRequest())
            //{
            //    return View();
            //}
            var user = CurrentUser.CrmUser;
            //const int pageSize = 20; //分页大小
            var models = new OnlineClassCourseBll().PersonelCourse(user.Id,
                                                                   (CourseQueryType)
                                                                   Enum.Parse(typeof(CourseQueryType), typeId),
                                                                   page,
                                                                   rows, keyword);
            //查询类型
            ViewBag.TypeName = EnumOperate.GetEnumDesc((CourseQueryType)Enum.Parse(typeof(CourseQueryType), typeId));
            //课程类型
            ViewData["CourseType"] = EnumOperate.ConvertEnumToDictionary(typeof(CourseType));
            ViewBag.TypeId = typeId;
            return View("PersonalCourseType", models);
        }


        /// <summary>
        /// 课程详情
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程详情</param>
        /// <returns></returns>
        public ActionResult CourseDetails(string courseId)
        {
            DataTable dt = null;
            if (!string.IsNullOrEmpty(courseId))
            {
                dt = new OnlineClassCourseBll().CouserDetails(CurrentUser.CrmUser.Id, courseId);
            }


            //课程分类
            var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0007" });
            ViewData["Classify"] = courseClassify;

            string title = "", score = "", duration = "", progress = "", category = "", courseType = "", courseTypeId = "", describle = "", linkurl = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                title = dt.Rows[0]["Title"].ToString();
                score = dt.Rows[0]["Score"].ToString();
                duration = dt.Rows[0]["Duration"].ToString();
                progress = dt.Rows[0]["Progress"].ToString();
                category = dt.Rows[0]["Category"].ToString();
                describle = dt.Rows[0]["Describle"].ToString();
                courseTypeId = dt.Rows[0]["CourseType"].ToString();
                linkurl = dt.Rows[0]["LinkUrl"].ToString();
                courseType = EnumOperate.GetEnumDesc((CourseType)Enum.Parse(typeof(CourseType), courseTypeId));
            }
            ViewBag.Id = courseId;
            ViewBag.Title = title;
            ViewBag.Score = score;
            ViewBag.Duration = duration;
            ViewBag.Progress = progress;
            ViewBag.Category = category;
            ViewBag.CourseType = courseType;
            ViewBag.CourseTypeId = courseTypeId;
            ViewBag.Describle = describle;
            ViewBag.LinkUrl = linkurl;
            return View();
        }



        /// <summary>
        /// 批量选课
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courses">课件编号</param>
        /// <returns></returns>
        [HttpPost]
        public string BatchCourse(string courses)
        {
            if (!string.IsNullOrEmpty(courses))
            {
                var isOk = new OnlineClassCourseBll().ChoiceCourse(CurrentUser.CrmUser.Id, courses);
                return isOk ? "OK" : "Error";
            }
            return "Error";
        }


        /// <summary>
        /// 视频播放
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult VedioPlay(string courseId)
        {
            DataTable attachments = null;
            if (!string.IsNullOrEmpty(courseId))
            {
                var user = CurrentUser.CrmUser;
                //验证是否选择该课程
                new OnlineClassProgressBll().CheckCourseIsChoice(user.Id, courseId);
                attachments = new OnlineClassCourseAttachBll().QueryCourseAttachment(user.Id, courseId);
                ViewBag.Title = new OnlineClassCourseBll().Get(courseId).Title;
            }

            if (attachments != null && attachments.Rows.Count > 0)
            {
                ViewBag.FileAddress = AppConfig.OnlineClassFileUrl + attachments.Rows[0]["FileAddress"];
                var addr = AppConfig.OnlineClassFileUrl + attachments.Rows[0]["FileAddress"];
                var lastStudySec = attachments.Rows[0]["LastStudySec"].ToString();
                ViewBag.LastStudySec = string.IsNullOrEmpty(lastStudySec) ? "0" : lastStudySec;
            }
            else
            {
                var att = new OnlineClassAttachmentBll().GetAttachmentByCourseId(courseId);
                ViewBag.FileAddress = AppConfig.OnlineClassFileUrl + att.Rows[0]["FileAddress"];
                ViewBag.LastStudySec = 0;
            }

            ViewBag.StartTime = DateTime.Now.ToString(AppConst.DateFormatLong);
            ViewBag.CourseId = courseId;
            return View();
        }


        /// <summary>
        /// 图文学习
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public ActionResult PoliticalDetails(string courseId)
        {
            ViewBag.Content = "";

            if (!string.IsNullOrEmpty(courseId))
            {
                var user = CurrentUser.CrmUser;
                //验证是否选择该课程
                new OnlineClassProgressBll().CheckCourseIsChoice(user.Id, courseId);
                DataTable attachments = new OnlineClassCourseAttachBll().QueryCourseAttachment(user.Id, courseId);
                ViewData["Files"] = attachments;

                var entity = new OnlineClassCourseBll().Get(courseId);
                ViewBag.Content = entity.Contents;
                ViewBag.Title = entity.Title;

                ViewBag.StartTime = DateTime.Now;
                ViewBag.CourseId = courseId;
            }
            return View();
        }

        /// <summary>
        /// 音频学习
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public ActionResult VoicePlay(string courseId)
        {
            DataTable attachments = null;
            if (!string.IsNullOrEmpty(courseId))
            {
                var user = CurrentUser.CrmUser;
                //验证是否选择该课程
                new OnlineClassProgressBll().CheckCourseIsChoice(user.Id, courseId);
                attachments = new OnlineClassCourseAttachBll().QueryCourseAttachment(user.Id, courseId);
                var entity = new OnlineClassCourseBll().Get(courseId);
                ViewBag.Title = entity.Title;
                ViewBag.CreateDate = entity.CreateOn.ToString(AppConst.DateFormatLong);
            }
            if (attachments != null && attachments.Rows.Count > 0)
            {
                ViewBag.FileAddress = AppConfig.OnlineClassFileUrl + attachments.Rows[0]["FileAddress"];

                var lastStudySec = attachments.Rows[0]["LastStudySec"].ToString();
                ViewBag.LastStudySec = string.IsNullOrEmpty(lastStudySec) ? "0" : lastStudySec;
            }

            ViewBag.StartTime = DateTime.Now.ToString(AppConst.DateFormatLong);
            ViewBag.CourseId = courseId;
            return View();
        }


        /// <summary>
        /// 保存学习记录
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <param name="courseType">课程类型</param>
        /// <param name="startTime">开始学习时间</param>
        /// <param name="studyTime">本次学习时长</param>
        /// <param name="studySec">最后一次学习记录（注：视频播放已学习时长,其它学习用不到）</param>
        /// <param name="isFinish">是否学习完成（注：视频播放是否播放完成,其它学习用不到）</param>
        /// <param name="videoTime">视频时长（注：视频时长，其它学习用不到）</param>
        /// <returns></returns>
        public string StudyRecord(string courseId, string courseType, string startTime, int studyTime, string studySec, string isFinish, string videoTime)
        {
            try
            {
                var ctype = (CourseType)Enum.Parse(typeof(CourseType), courseType);

                var ip = CommonMethod.ClientIP();   //获取客户端IP
                var isOk = new OnlineClassProgressBll().StudyRecord(CurrentUser.CrmUser.Id, courseId, ctype, startTime, studyTime, studySec, isFinish, videoTime, ip);
                return isOk ? "OK" : "Error";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// 下载中心
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="categoryId">分类编号</param>
        /// <param name="courseTypeId">课程类型</param>
        /// <param name="page">当前索引页</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public ActionResult DownLoadCenter(string categoryId, string courseTypeId, int? page, string keyword)
        {
            var user = CurrentUser.CrmUser;
            //课程分类
            var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0007" });
            ViewData["Classify"] = courseClassify;
            ViewBag.Keyword = keyword;

            const int pageSize = 20;
            PageObject<DataTable> models;
            if (!string.IsNullOrEmpty(courseTypeId))
            {
                models = new OnlineClassCourseBll().Course(user.Id, (CourseType)Enum.Parse(typeof(CourseType), courseTypeId), categoryId,
                                                           page ?? 1, pageSize, "=");
            }
            else
            {
                models = new OnlineClassCourseBll().Course(user.Id, null, categoryId,
                                                           page ?? 1, pageSize, "=");
            }
            return View(models);
        }

        /// <summary>
        /// 课件排行
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult CourseOrder(int? page)
        {
            const int pageSize = 20;
            //课程分类
            var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0007" });
            ViewData["Classify"] = courseClassify;

            //课程类型
            ViewData["CourseType"] = EnumOperate.ConvertEnumToDictionary(typeof(CourseType));

            //课件学习排行
            var topCourse = new OnlineClassCourseBll().StudyCount(page ?? 1, pageSize);
            return View(topCourse);
        }

        /// <summary>
        /// 删除个人的选修类课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-18
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">课程编号</param>
        /// <returns></returns>
        public string DelPersonalElectives(string id)
        {
            try
            {
                return !string.IsNullOrEmpty(id) ? new OnlineClassProgressBll().DeleteChoice(CurrentUser.CrmUser.Id, id) : "Error";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        /// <summary>
        /// 外部链接视频播放
        /// 添加人：周 鹏
        /// 添加时间：2014-11-25
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public ActionResult VedioUrlPlay(string courseId)
        {
            if (!string.IsNullOrEmpty(courseId))
            {
                var user = CurrentUser.CrmUser;
                //验证是否选择该课程
                new OnlineClassProgressBll().CheckCourseIsChoice(user.Id, courseId);
                var entity = new OnlineClassCourseBll().Get(courseId);
                ViewBag.Title = entity.Title;
                ViewData["video"] = entity.LinkUrl;
            }
            ViewBag.StartTime = DateTime.Now.ToString(AppConst.DateFormatLong);
            ViewBag.CourseId = courseId;
            return View();
        }


        /// <summary>
        /// 下载课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-30
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public ActionResult CourseDown(string courseId)
        {
            ViewBag.Describle = "";

            if (!string.IsNullOrEmpty(courseId))
            {
                var user = CurrentUser.CrmUser;
                DataTable attachments = new OnlineClassCourseAttachBll().QueryCourseAttachment(courseId);
                ViewData["Files"] = attachments;

                var entity = new OnlineClassCourseBll().Get(courseId);
                ViewBag.Describle = entity.Describle;
                ViewBag.Title = entity.Title;
            }
            return View();
        }
    }
}
