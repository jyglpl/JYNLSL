using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Approval;
using Yookey.WisdomClassed.SIP.Model.Approval;

namespace Yookey.WisdomClassed.SIP.Business.Approval
{
    public class TmMatterApplyMajorBll
    {
        private readonly TmMatterApplyMajorDal _dal = new TmMatterApplyMajorDal();

        public List<TmMatterApplyMajorEntity> GetSearchResult(TmMatterApplyMajorEntity search)
        {
            return _dal.GetSearchResult(search);
        }

        /// <summary>
        /// 获取审批事项
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable GetApplyMajorList(string keywords, int pageIndex, int pageSize)
        {
            int totalRecords;
            return _dal.GetApplyMajorList(keywords, pageIndex, pageSize, out totalRecords);
        }
    }
}
