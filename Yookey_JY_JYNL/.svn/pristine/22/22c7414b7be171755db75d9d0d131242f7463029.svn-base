using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{ /// <summary>
    /// ComNotice业务逻辑
    /// </summary>
    public class ComNoticeBll : BaseBll<ComNoticeEntity>
    {
        public ComNoticeBll()
        {
            BaseDal = new ComNoticeDal();
        }

        /// <summary>
        /// 保存公告通知
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        public bool SaveNotice(ComNoticeEntity entity)
        {
            try
            {
                return new ComNoticeDal().SaveNotice(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取用户公告信息
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="totalRecords">总记录条数</param>
        /// <returns>Columns->Id:主编号,Title:标题,SendTime:发布时间,UserName:发布人</returns>
        public DataTable GetUserNotice(string userId, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                return new ComNoticeDal().GetUserNotice(userId, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取用户未读的公告条数
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public int GetUserNoticeNoRead(string userId)
        {
            try
            {
                return new ComNoticeDal().GetUserNoticeNoRead(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更改公告通知信息为已读
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户ID</param>
        /// <param name="noticeId">公告通知ID</param>
        /// <returns></returns>
        public bool SetNoticeIsRead(string userId, string noticeId)
        {
            try
            {
                return new ComNoticeDal().SetNoticeIsRead(userId, noticeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取所有公告通知
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns>Columns->Id:主编号,Title:标题,SendTime:发布时间,UserName:发布人</returns>
        public DataTable GetNotices(int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                return new ComNoticeDal().GetNotices(pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除公告
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">待删除的公告值</param>
        /// <returns></returns>
        public bool DeleteNotice(string ids)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                var worklistsplit = ids.Split(',');
                list.AddRange(worklistsplit);
                return new ComNoticeDal().DeleteNotice(list);
            }
            return false;
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
        public Page<ComNoticeEntity> GetSearchResult(ComNoticeEntity search, int pageIndex = 1, int pageSzie = 15)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComNoticeEntity.Parm_ComNotice_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Title))
            {
                queryCondition.AddLike(ComNoticeEntity.Parm_ComNotice_Title, search.Title);
            }
            //排序
            queryCondition.AddOrderBy(ComNoticeEntity.Parm_ComNotice_CreateOn, true).SetPager(pageIndex, pageSzie);
            int totalRecord, totalPage;
            var list = Query(queryCondition, out totalRecord, out totalPage);
            return new Page<ComNoticeEntity>
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
