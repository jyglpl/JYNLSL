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
    /// ComWhiteList业务逻辑
    /// </summary>
    public class ComWhiteListBll : BaseBll<ComWhiteListEntity>
    {
        public ComWhiteListBll()
        {
            BaseDal = new ComWhiteListDal();
        }

        /// <summary>
        /// 查询所有白名单
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        //public PageJqDatagrid<ComWhiteListEntity> GetSearchResult(string keyword, int pageSize, int pageIndex)
        //{
        //    int totalRecords;
        //    var data = new ComWhiteListDal().GetSearchResult(keyword, pageSize, pageIndex, out totalRecords);
        //    var totalPage = (totalRecords + pageSize - 1) / pageSize;
        //    return new PageJqDatagrid<ComWhiteListEntity>
        //    {
        //        page = pageIndex,
        //        rows = data,
        //        total = totalPage,
        //        records = totalRecords
        //    };
        //}

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ComWhiteListEntity> GetSearchResult(ComWhiteListEntity search)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(ComWhiteListEntity.Parm_ComWhiteList_RowStatus, "1");
                if (!string.IsNullOrEmpty(search.PlateNumber))
                {
                    queryCondition.AddLike(ComWhiteListEntity.Parm_ComWhiteList_PlateNumber, search.PlateNumber);
                }
                //排序
                queryCondition.AddOrderBy(ComWhiteListEntity.Parm_ComWhiteList_CreateOn, true);
                return Query(queryCondition);
            }
            catch (Exception)
            {
                return new List<ComWhiteListEntity>();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new ComWhiteListDal().BatchDelete(ids);
        }
    }
}
