using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    /// <summary>
    /// 网上课堂统计业务逻辑
    /// </summary>
    public class OnlineClassStatisticBll
    {
        private readonly OnlineClassStatisticDal _dal = new OnlineClassStatisticDal();
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
                return _dal.DynamicData();
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
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns>Columns->OrderNo:排名,Score:积分</returns>
        public DataTable PersonalSroceAndRank(string userId)
        {
            try
            {
                return _dal.PersonalSroceAndRank(userId);
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
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns>Colums->Electives:选修,[Required]:必修,Finished:已完成,Score:分值,OrderNo:排名</returns>
        public DataTable PersonalStatistic(string userId)
        {
            try
            {
                return _dal.PersonalStatistic(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 个人学习明细列表
        /// 添加人：周 鹏
        /// 添加时间：2014-11-17
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>Columns->Id:课件编号,Title:课件标题,Progress:学习进度,Score:学分,CourseType:课件类型,ReceiveType:学习类型,CreateOn</returns>
        public PageObject<DataTable> PersonalStatisticDetails(string userId, int pageIndex, int pageSize)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().PersonalStatisticDetails(userId, pageIndex, pageSize, out totalRecores);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
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
        /// <returns></returns>
        public PageObject<DataTable> IndividualSatistic(string userId, string courseId, int pageIndex, int pageSize)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().IndividualSatistic(userId, courseId, pageIndex, pageSize, out totalRecores);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据个人查看统计分析
        /// 添加人：张西琼
        /// 添加时间：2014-11-21
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-01-05 周 鹏 增加查询全部
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">当前大小</param>
        /// <param name="keyWords"></param>
        /// <param name="isPage">是否分页</param>
        /// <returns></returns>
        public PageObject<DataTable> StatisticByIndividual(string userId, int pageIndex, int pageSize, string keyWords, bool isPage = true)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().StatisticByIndividual(userId, pageIndex, pageSize, keyWords, out totalRecores, isPage);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据课程查看统计分析
        /// 添加人：张西琼
        /// 时间：2014-11-21
        /// </summary>
        /// <returns></returns>
        public PageObject<DataTable> StatisticByCourse(int pageIndex, int pageSize, bool isPage = true)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().StatisticByCourse(pageIndex, pageSize, out totalRecores, isPage);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            // return new OnlineClassStatisticDal().StatisticByCourse();
        }

        /// <summary>
        /// 根据课程查看统计分析明细
        /// 添加人：张西琼
        /// 时间：2014-11-21
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageObject<DataTable> StatisticByCourseDetails(string courseId, int pageIndex, int pageSize)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().StatisticByCourseDetails(courseId, pageIndex, pageSize, out totalRecores);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
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
        public PageObject<DataTable> IndividualCourseDetails(string userId, int pageIndex, int pageSize)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassStatisticDal().IndividualCourseDetails(userId, pageIndex, pageSize, out totalRecores);
                var page = new PageObject<DataTable>()
                {
                    CurrentPage = pageIndex,
                    PageSize = pageSize,
                    Items = dt,
                    TotalPages = (totalRecores + pageSize - 1) / pageSize,
                    TotalRecords = totalRecores
                };
                return page;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            //return new OnlineClassStatisticDal().IndividualCourseDetails(userId);
        }
    }
}
