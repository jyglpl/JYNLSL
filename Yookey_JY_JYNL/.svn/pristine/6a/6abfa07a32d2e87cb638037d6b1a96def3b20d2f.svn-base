using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Yookey.WisdomClassed.SIP.DataAccess.OA;

using Yookey.WisdomClassed.SIP.Model.OA;


namespace Yookey.WisdomClassed.SIP.Business.OA
{
    public class DocumentNotificationBll
    {
        private static readonly DocumentNotificationDal Dal = new DocumentNotificationDal();
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<DocumentNotificationEntity> GetAllResult(DocumentNotificationEntity search)
        {
            return Dal.GetAllResult(search);
        }

        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="search"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public List<DocumentNotificationEntity> SearchQuery(DocumentNotificationEntity search,string limittime = null,string jieshouGuid=null)
        {
            return Dal.SearchQuery(search, limittime, jieshouGuid);
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(DocumentNotificationEntity search)
        {
            return Dal.PersistNewItem(search);
        }


     
    }
}
