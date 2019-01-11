using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassReceiveBll 
    {
        private readonly OnlineClassReceiveDal _dal = new OnlineClassReceiveDal();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassReceiveEntity Get(string Id)
        {
           return _dal.Get(Id);
        }
        
        /// <summary>
        /// 删除接收人
        /// 时间：20147-12-1
        /// 添加人：张西琼
        /// </summary>
        /// <param name="courseId">课程编号</param>
        /// <returns></returns>
        public bool DelRecieveByCourseId(string courseId)
        {
            return _dal.DelRecieveByCourseId(courseId);
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
        public List<OnlineClassReceiveEntity> GetSearchResult(OnlineClassReceiveEntity search)
        {
            return _dal.GetSearchResult(search);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassReceiveEntity search)
        {
            return _dal.Update(search);
        }

        /// <summary>
        /// 根据CourseId和UserId更新实体(必修)
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateBy(string courseId,  string userId)
        {
            return _dal.UpdateBy(courseId,userId);
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassReceiveEntity entity)
        {
            return _dal.Insert(entity);
        }
    }
}
