using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.DataAccess.OnlineClass
{
    /// <summary>
    /// OnlineClassUserGroup数据访问操作
    /// </summary>
    public class OnlineClassUserGroupDal : BaseDal<OnlineClassUserGroupEntity>
    {
        
        /// <summary>
        /// 查询所有分组人员
        /// </summary>
        /// <returns></returns>
        public IList<OnlineClassUserGroupEntity> GetAllUsers()
        {
//            var strSql = string.Format(@"SELECT OCU.UserId,OCU.GroupId,CU.RealName FROM OnlineClassUserGroup AS OCU WITH (NOLOCK)
//JOIN dbo.CrmUser AS CU WITH(NOLOCK) ON OCU.UserId=CU.Id WHERE OCU.RowStatus=1
//ORDER BY OCU.SortNo");
            var strSql = string.Format(@"SELECT OCU.UserId,OCU.GroupId FROM OnlineClassUserGroup AS OCU WITH (NOLOCK)
WHERE OCU.RowStatus=1 ORDER BY OCU.SortNo");

            var list = WriteDatabase.Query<OnlineClassUserGroupEntity>(strSql.ToString()).ToList();
            return list != null && list.Count > 0 ? list : new List<OnlineClassUserGroupEntity>();
        }
        /// <summary>
        /// 根据用户编号获取用户组信息
        /// 添加人：张西琼
        /// 时间：2014-11-17
        /// </summary>
        /// <returns></returns>
        public DataTable GetEntityByUserId(string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    string strSql = string.Format(@"select * from OnlineClassUserGroup where  RowStatus=1 and UserId='{0}'", userId);
                    return WriteDatabase.Query(strSql.ToString());
                }
                else return new DataTable();

            }
            catch (System.Exception)
            {

                throw;
            }

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
            try
            {
                string strSql = string.Format(@" update OnlineClassUserGroup set RowStatus=0 where id='{0}'", id);
                return WriteDatabase.Execute(strSql) > 0;
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
        }
    }
}