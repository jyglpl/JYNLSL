using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComNoticeAttach业务逻辑
    /// </summary>
    public class ComNoticeAttachBll : BaseBll<ComNoticeAttachEntity>
    {
        public ComNoticeAttachBll()
        {
            BaseDal = new ComNoticeAttachDal();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ComNoticeAttachEntity> GetSearchResult(ComNoticeAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComNoticeAttachEntity.Parm_ComNoticeAttach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(ComNoticeAttachEntity.Parm_ComNoticeAttach_ResourceId, search.ResourceId);
            }
            return Query(queryCondition) as List<ComNoticeAttachEntity>;
        }
    }
}
