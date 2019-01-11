using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassCourseBll
    {
        private readonly OnlineClassCourseDal _onlineClassCourseDal = new OnlineClassCourseDal();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassCourseEntity Get(string Id)
        {
            return _onlineClassCourseDal.Get(Id);
        }
        
         /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassCourseEntity search)
        {
            return _onlineClassCourseDal.Update(search);
        }

        /// <summary>
        /// 删除课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return _onlineClassCourseDal.Delete(id);
        }

        /// <summary>
        /// 新增课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassCourseEntity entity)
        {
            return _onlineClassCourseDal.Insert(entity);
        }

        /// <summary>
        /// 保存课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">课件实体</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool SaveCourse(OnlineClassCourseEntity entity)
        {
            try
            {
                return new OnlineClassCourseDal().SaveCourse(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 修改课件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-23
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">课件实体</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool EditCourse(OnlineClassCourseEntity entity)
        {
            try
            {
                //查询出课件所有需要学习的人员（选修、必修的）
                var allRecevices = new OnlineClassReceiveBll().GetSearchResult(new OnlineClassReceiveEntity() { CourseId = entity.Id });
                return new OnlineClassCourseDal().EditCourse(entity, allRecevices);
                //return _onlineClassCourseDal.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 选择课件（选修）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseIds">课件编号</param>
        /// <returns>true:保存成功 false:保存失败</returns>
        public bool ChoiceCourse(string userId, string courseIds)
        {
            try
            {
                return new OnlineClassCourseDal().ChoiceCourse(userId, courseIds);
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
        public DataTable StudyCount(int topNum = 6)
        {
            try
            {
                var dt = new OnlineClassCourseDal().StudyCount(topNum);
                return dt;
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
        ///           2015-01-04 周 鹏 增加分页
        /// </history>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>Columns->Num:序号,Title:标题,CourseId:课件编号,Scount:学习次数</returns>
        public Yookey.WisdomClassed.SIP.Model.PageObject<DataTable> StudyCount(int pageIndex, int pageSize)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassCourseDal().StudyCount(pageIndex, pageSize, out totalRecores);
                var page = new Yookey.WisdomClassed.SIP.Model.PageObject<DataTable>()
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
                return new OnlineClassCourseDal().QueryTopCourse(topNum, courseType, oper);
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
                return new OnlineClassCourseDal().PersonelCourse(userId, topNum, courseQueryType, keyword);
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
        /// <returns>Columns->Id:课程编号,Title:标题,Progress:学习进度,Score:课程分值,CourseType:课程类型</returns>
        public Yookey.WisdomClassed.SIP.Model.PageObject<DataTable> PersonelCourse(string userId, CourseQueryType courseQueryType, int pageIndex,
                                                    int pageSize, string keyword)
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassCourseDal().PersonelCourse(userId, courseQueryType, pageIndex, pageSize,
                                                                   out totalRecores, keyword);
                var page = new Yookey.WisdomClassed.SIP.Model.PageObject<DataTable>()
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
        /// 课程查询（注：不查询下载类课程）
        /// 添加人：周 鹏
        /// 添加时间：2014-11-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="courseType">课件类型</param>
        /// <param name="categoryId">课程分类</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="oper">运算符（不等号、等号）（默认不查询下载类课程）</param>
        /// <param name="keyword">查询关键字</param>
        /// <returns>Columns->Id:课程编号,Title:标题,Score:课程分值,CourseType:课程类型,CreateOn:课程创建日期</returns>
        public Yookey.WisdomClassed.SIP.Model.PageObject<DataTable> Course(string userId, CourseType? courseType, string categoryId, int pageIndex,
                                            int pageSize, string oper = "<>", string keyword = "")
        {
            try
            {
                int totalRecores;
                var dt = new OnlineClassCourseDal().Course(userId, courseType, categoryId, pageIndex, pageSize,
                                                           out totalRecores, oper, keyword);
                var page = new Yookey.WisdomClassed.SIP.Model.PageObject<DataTable>()
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
        /// 课程查询（所有课程）
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>

        public Page<OnlineClassCourseEntity> GetCourseManager(string courseTypeId, int pageIndex, int pageSize, string keyword)
        {
            return _onlineClassCourseDal.GetCourseManager(courseTypeId, pageIndex, pageSize, keyword);
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
                return new OnlineClassCourseDal().CouserDetails(userId, courseId);
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
        /// </history>
        /// /// <param name="courseId">课程编号</param>
        /// <returns>Columns->UserIds：用户编号集,UserNames：用姓名集</returns>
        public DataTable GetReceiveUsers(string courseId)
        {
            try
            {
                return new OnlineClassCourseDal().GetReceiveUsers(courseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
