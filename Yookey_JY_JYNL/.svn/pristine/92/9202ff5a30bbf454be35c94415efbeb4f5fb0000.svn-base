using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassAttachmentBll
    {
        private readonly OnlineClassAttachmentDal _dal = new OnlineClassAttachmentDal();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassAttachmentEntity Get(string Id)
        {
            return _dal.Get(Id);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassAttachmentEntity search)
        {
            return _dal.Update(search);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassAttachmentEntity entity)
        {
            return _dal.Insert(entity);
        }

        /// <summary>
        /// 根据外键数据源获取附件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-18
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<OnlineClassAttachmentEntity> GetSearchResult(string recourceId)
        {
            return _dal.GetSearchResult(recourceId);
        }

        /// <summary>
        /// 查询附件
        /// 添加人：张西琼
        /// 时间：2014-11-24
        /// </summary>
        /// <param name="courseId">课程名称</param>
        /// <returns></returns>
        public DataTable GetAttachmentByCourseId(string courseId)
        {
            return _dal.GetAttachmentByCourseId(courseId);
        }
    }
}
