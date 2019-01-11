using PetaPoco;
using System;
using System.Collections.Generic;
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
    public class OnlineClassGroupBll 
    {
        private readonly OnlineClassGroupDal _onlineClassGroupDal = new OnlineClassGroupDal();

        /// <summary>
        /// 获取所有部门
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public IEnumerable<OnlineClassGroupEntity> GetAllDepts(OnlineClassGroupEntity search)
        {
            return _onlineClassGroupDal.GetAllDepts(search);
        }

        /// <summary>
        /// 分组查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<OnlineClassGroupEntity> GetSearchResult(OnlineClassGroupEntity search)
        {
            return _onlineClassGroupDal.GetSearchResult(search);
        }

        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<OnlineClassGroupEntity> GetAllGroup()
        {
            return _onlineClassGroupDal.GetAllGroup();
        }
       
        /// <summary>
        /// 删除分组
        /// 添加人：张西琼
        /// 时间：2014-11-25
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool DeleteGroup(OnlineClassGroupEntity group)
        {
            return _onlineClassGroupDal.DeleteGroup(group);
        }
    }
}
