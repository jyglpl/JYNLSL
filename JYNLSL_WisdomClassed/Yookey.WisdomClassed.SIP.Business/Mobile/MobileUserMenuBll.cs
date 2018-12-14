using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;
using Yookey.WisdomClassed.SIP.Model.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
    public class MobileUserMenuBll : BaseBll<MobileUserMenuEntity>
    {
        public MobileUserMenuBll()
        {
            BaseDal = new MobileUserMenuDal();
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
            return new MobileUserMenuDal().GetMenuByUserId(userId);
        }
    }
}
