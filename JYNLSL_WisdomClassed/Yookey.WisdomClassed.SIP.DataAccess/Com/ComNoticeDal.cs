using System.Text.RegularExpressions;
using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComNotice数据访问操作
    /// </summary>
    public class ComNoticeDal : DalImp.BaseDal<ComNoticeEntity>
    {
        public ComNoticeDal()
        {
            Model = new ComNoticeEntity();
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
            var transaction = new TransactionLoader().BeginTransaction("SaveNotice");
            try
            {
                var noticeId = "";
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    noticeId = entity.Id;
                    Update(entity, transaction);
                }
                else
                {
                    noticeId = Guid.NewGuid().ToString();
                    entity.Id = noticeId;
                    Add(entity, transaction);
                }

                //保存接收对象
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE ComNoticeReceive WHERE NoticeId='{0}'", noticeId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                if (!(string.IsNullOrEmpty(entity.Actioners) || entity.Actioners.Split(',').Length.Equals(0)))
                {
                    var actionerNames = entity.ActionerNames;

                    var receiveDal = new ComNoticeReceiveDal();
                    var splitUser = entity.Actioners.Split(',');
                    var splitUserName = actionerNames.Split(',');

                    int i = 0;
                    foreach (var user in splitUser)
                    {
                        var receiveEntity = new ComNoticeReceiveEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            NoticeId = noticeId,
                            UserId = user,
                            UserNameq = "",
                            RowStatus = 1,
                            CreateOn = DateTime.Now
                        };
                        receiveDal.Add(receiveEntity, transaction);


                        //var regex = new Regex(@"<[^>]+>|</[^>]+>");     //去掉尖括号里面的数据得到手机号码
                        //var phoneNum = regex.Replace(splitUserName[i], string.Empty);

                        //i++;

                        ////发短信
                        //if (string.IsNullOrEmpty(phoneNum) || phoneNum.Equals("&nbsp;")) continue;
                        //var noteEntity = new ComNoteEntity()
                        //    {
                        //        Id = Guid.NewGuid().ToString(),
                        //        ResourcesId = "",
                        //        ReceivePhone = phoneNum,
                        //        MistakeInfo = "公告通知：" + entity.Title + "，请查阅！",
                        //        ReceiveTime = DateTime.Now,
                        //        Status = 0,
                        //        RowStatus = 1
                        //    };
                        //new ComNoteDal().Add(noteEntity);
                    }
                }

                //保存附件
                sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE ComNoticeAttach WHERE ResourceId='{0}'", noticeId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                if (!(string.IsNullOrEmpty(entity.Attachment) || entity.Attachment.Split(',').Length.Equals(0)))
                {
                    var attachDal = new ComNoticeAttachDal();
                    var splitAttach = entity.Attachment.Split('|');
                    foreach (var attach in splitAttach)
                    {
                        var attachInfo = attach.Split(',');
                        var receiveEntity = new ComNoticeAttachEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourceId = noticeId,
                            FileName = attachInfo[2],
                            FileReName = attachInfo[3],
                            FileAddress = attachInfo[1],
                            RowStatus = 1,
                            CreateOn = DateTime.Now
                        };
                        attachDal.Add(receiveEntity, transaction);
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 获取用户公告信息
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="userId">用户编号</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns>Columns->Id:主编号,Title:标题,SendTime:发布时间,UserName:发布人</returns>
        public DataTable GetUserNotice(string userId, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CN.Id,Title,CN.CreateOn AS SendTime,BU.realname,CN.IsTop FROM ComNotice AS CN WITH(NOLOCK)
JOIN CrmUser AS BU ON BU.Id=CN.CreatorId
JOIN ComNoticeReceive AS CNR WITH(NOLOCK) ON CN.Id=CNR.NoticeId
WHERE CN.RowStatus=1 AND CNR.UserId='{0}'", userId);

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "IsTop,SendTime", "DESC", pageIndex, pageSize, out totalRecords);
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT COUNT(*) AS NoReadCount FROM ComNotice AS CN WITH(NOLOCK)
JOIN CrmUser AS BU ON BU.Id=CN.CreatorId
JOIN ComNoticeReceive AS CNR WITH(NOLOCK) ON CN.Id=CNR.NoticeId
WHERE CN.RowStatus=1 AND CNR.UserId='{0}' AND CNR.IsRead=0", userId);

            return int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).ToString());
        }

        /// <summary>
        /// 获取所有公告通知
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="totalRecords">总记录数</param>
        /// <returns>Columns->Id:主编号,Title:标题,SendTime:发布时间,UserName:发布人</returns>
        public DataTable GetNotices(int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(
                @"SELECT CN.Id,Title,CN.CreateOn AS SendTime,BU.Realname,CN.IsTop FROM ComNotice AS CN WITH(NOLOCK)
JOIN CrmUser AS BU ON BU.Id=CN.CreatorId
WHERE CN.RowStatus=1 ");

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "IsTop,SendTime", "DESC", pageIndex, pageSize, out totalRecords);
        }


        /// <summary>
        /// 删除公告
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="list">待删除的消息集</param>
        /// <returns></returns>
        public bool DeleteNotice(List<string> list)
        {
            if (list.Any())
            {
                var transaction = new TransactionLoader().BeginTransaction("DeleteWorkList");
                try
                {
                    var sbSql = new StringBuilder();
                    if (list.Count >= 5)
                    {
                        foreach (var id in list)
                        {
                            sbSql.AppendFormat(@"UPDATE [ComNotice] SET RowStatus={0} WHERE [Id] ='{1}';", 0, id);
                        }
                    }
                    else
                    {
                        sbSql.AppendFormat(@"UPDATE [ComNotice] SET RowStatus={0} WHERE [Id] IN ('{1}');", 0, string.Join("','", list.ToArray()));
                    }
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
                return true;
            }
            return false;
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(
                @"UPDATE ComNoticeReceive SET IsRead=1,LastReadTime=GETDATE() WHERE NoticeId='{0}' AND UserId='{1}'", noticeId, userId);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;
        }
    }
}
