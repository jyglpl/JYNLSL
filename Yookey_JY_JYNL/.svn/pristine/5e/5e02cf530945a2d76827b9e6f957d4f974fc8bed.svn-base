using Yookey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Mobile;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{

    /// <summary>
    /// Mobile_UserMenu数据访问操作
    /// </summary>
    public class MobileUserMenuDal : DalImp.BaseDal<MobileUserMenuEntity>
    {
        public MobileUserMenuDal()
        {
            Model = new MobileUserMenuEntity();
        }

        /// <summary>
        /// 根据用户编号查询菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-08-26
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable GetMenuByUserId(string userId)
        {
            var sbSql = string.Format("SELECT MenuId FROM Mobile_UserMenu WHERE UserId='{0}' AND RowStatus=1", userId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).Tables[0];
        }
    }
}

