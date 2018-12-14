using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassCourseAttachBll
    {
        private readonly OnlineClassCourseAttachDal _dal = new OnlineClassCourseAttachDal();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassCourseAttachEntity Get(string Id)
        {
            return _dal.Get(Id);
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
            return _dal.GetSearchResult(search);
        }

         /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassCourseAttachEntity search)
        {
            return _dal.Update(search);
        }

        /// <summary>
        /// 删除课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return _dal.Delete(id);
        }

        /// <summary>
        /// 新增课件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassCourseAttachEntity entity)
        {
            return _dal.Insert(entity);
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
                return new OnlineClassCourseAttachDal().QueryCourseAttachment(userId, courseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询课程附件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-30
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseId">课程编号</param>
        /// <returns>Columns->FileAddress:资料路径,FileName:附件名称</returns>
        public DataTable QueryCourseAttachment(string courseId)
        {
            try
            {
                return new OnlineClassCourseAttachDal().QueryCourseAttachment(courseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
