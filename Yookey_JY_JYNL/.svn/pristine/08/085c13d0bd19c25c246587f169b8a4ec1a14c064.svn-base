using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.ShowVideo;

namespace Yookey.WisdomClassed.SIP.DataAccess.ShowVideo
{
    /// <summary>
    /// ShowVideo数据访问操作
    /// </summary>
    public class ShowVideoDal : DalImp.BaseDal<ShowVideoEntity>
    {
        public ShowVideoDal()
        {
            Model = new ShowVideoEntity();
        }

       /// <summary>
        /// 查询所有有效的演示视频
       /// </summary>
       /// <returns></returns>
        public List<ShowVideoEntity> GetAllVideos( )
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM  ShowVideo WHERE RowStatus=1  ORDER BY OrderNo");
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<ShowVideoEntity>();
        }

    }
}
