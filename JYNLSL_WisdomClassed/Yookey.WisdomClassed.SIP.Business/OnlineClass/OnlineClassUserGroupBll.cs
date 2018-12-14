using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    /// <summary>
    /// 人员分组业务逻辑
    /// </summary>
    public class OnlineClassUserGroupBll 
    {
        private readonly OnlineClassUserGroupDal _dal = new OnlineClassUserGroupDal();
        /// <summary>
        /// 获取所有人员
        /// 添加人：周 鹏 
        /// 添加时间：2014-11-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public IList<OnlineClassUserGroupEntity> GetAllUsers()
        {
            return _dal.GetAllUsers();
        }
        /// <summary>
        /// 根据用户编号获取用户组信息
        /// 添加人：张西琼
        /// 时间：2014-11-17
        /// </summary>
        /// <returns></returns>
        public DataTable GetEntityByUserId(string userId)
        {
            return _dal.GetEntityByUserId(userId);
        }
        /// <summary>
        /// 删除实体
        /// 添加人：张西琼
        /// 时间：2014-11-18
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEntity(string id)
        {
            return _dal.DeleteEntity(id);
        }
    }
}
