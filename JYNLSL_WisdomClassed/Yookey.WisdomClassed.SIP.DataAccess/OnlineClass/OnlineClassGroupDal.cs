using DBHelper;
using PetaPoco;
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
    /// OnlineClassGroup数据访问操作
    /// </summary>
    public class OnlineClassGroupDal : BaseDal<OnlineClassGroupEntity>
    {
        
        // <summary>
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
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.GroupName))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" and {0} like '" + search.GroupName + "%' ", t => t.GroupName));                
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" and {0} like '" + search.Id + "%' ", t => t.Id));
            }
            return WriteDatabase.Query<OnlineClassGroupEntity>(sbWhere.ToString()).ToList();
        }
        /// <summary>
        /// 删除分组
        /// 添加人：张西琼
        /// 时间：2014-11-15
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool DeleteGroup(OnlineClassGroupEntity group)
        {
            try
            {
                //删除分组下人员
                string str = string.Format(@" update OnlineClassGroup  set RowStatus=0 where GroupId='{0}'", group.Id);
                return WriteDatabase.Execute(str) > 0;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 分组查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<OnlineClassGroupEntity> GetSearchResult(OnlineClassGroupEntity search)
        {
            
            
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>("Where {0}=1 ", u => u.RowStatus));
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" and {0} = @p1 ", t => t.Id));
                args.Add(new { p1 = search.Id });
            }
            if (!string.IsNullOrEmpty(search.GroupParentId))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" and {0} = @p2 ", t => t.GroupParentId));
                args.Add(new { p2 = search.GroupParentId });
            }
            if (!string.IsNullOrEmpty(search.GroupName))
            {
                sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" and {0} like '" + search.GroupName + "%' ", t => t.GroupName));
            }
            //排序
            sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>(" order by {0} asc", t => t.OrderNo));
            return ReadDatabase.Page<OnlineClassGroupEntity>(search.page.CurrentPage, search.page.PageSize,
                                                                   sbWhere.ToString(), args.ToArray());
        }

        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<OnlineClassGroupEntity> GetAllGroup()
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<OnlineClassGroupEntity>("Where {0}=1 ", u => u.RowStatus));
            
            return WriteDatabase.Query<OnlineClassGroupEntity>(sbWhere.ToString()).ToList();
        }
    }
}