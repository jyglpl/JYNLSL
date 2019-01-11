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
    public class ComArticleBll : BaseBll<ComArticleEntity>
    {
        public ComArticleBll()
        {
            BaseDal = new ComArticleDal();
        }


        /// <summary>
        /// 保存通用文章
        /// 添加人：张西琼
        /// 时间：2014-11-13
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public ComArticleEntity SaveArticle(ComArticleEntity entity)
        {
            try
            {
                return BaseDal.Add(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 公告通知查询
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询对象</param>
        /// <param name="pageSzie">分页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <returns></returns>
        public Page<ComArticleEntity> GetSearchResult(ComArticleEntity search, int pageIndex = 1, int pageSzie = 15)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComArticleEntity.Parm_ComArticle_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Title))
            {
                queryCondition.AddLike(ComArticleEntity.Parm_ComArticle_Title, search.Title);
            }
            //排序
            queryCondition.AddOrderBy(ComArticleEntity.Parm_ComArticle_CreateOn, true).SetPager(pageIndex, pageSzie);
            int totalRecord, totalPage;
            var list = Query(queryCondition, out totalRecord, out totalPage);
            return new Page<ComArticleEntity>
            {
                CurrentPage = pageIndex,
                Items = list,
                PageSize = pageSzie,
                TotalPages = totalPage,
                TotalRecords = totalRecord
            };
        }
    }
}
