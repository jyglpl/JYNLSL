using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.DataAccess.OA
{
    /// <summary>
    /// add by lpl
    /// 2018-12-24
    /// 公告管理表
    /// </summary>
    public class DocumentNotificationDal : BaseDal<DocumentNotificationEntity>
    {
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<DocumentNotificationEntity> GetAllResult(DocumentNotificationEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append("Where ROWSTATUS = 1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.Append(Database.GetFormatSql<DocumentNotificationEntity>(" and {0} = @p1 ", t => t.Id));
                args.Add(new { p1 = search.Id });
            }


            if (!string.IsNullOrEmpty(search.Title))
            {
                sbWhere.Append(Database.GetFormatSql<DocumentNotificationEntity>(" and Title like @p1 "));
                args.Add(new { p1 = "%" + search.Title + "%" });
            }

            sbWhere.Append(" ORDER BY  CreateOn");
            return WriteDatabase.Query<DocumentNotificationEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public List<DocumentNotificationEntity> SearchQuery(DocumentNotificationEntity entity,string limittime = null,string jieshouGuid=null)
        {
            try
            {
                var strSql = new StringBuilder("SELECT * FROM dbo.DocumentNotification WHERE 1=1");

                //标题搜索
                if (!string.IsNullOrEmpty(entity.Title))
                {
                    strSql.AppendFormat("AND Title LIKE '%{0}%'", entity.Title);
                }

                //时间范围搜索
                if (!string.IsNullOrEmpty(limittime))
                {
                    string[] arryTime = limittime.Split('至');

                    string startTime = arryTime[0];
                    string endTime = arryTime[1];

                    strSql.AppendFormat("AND ReleaseTime > '{0}' AND ReleaseTime < '{1}'", startTime, endTime);
                }

                //通告类型
                if (!string.IsNullOrEmpty(entity.Category))
                {
                    strSql.AppendFormat("AND Category = '{0}'", entity.Category);
                }


                if (!string.IsNullOrEmpty(jieshouGuid))
                {
                    strSql.AppendFormat("AND Id IN ({0})", jieshouGuid);
                }


                var args = new List<object>();

                return WriteDatabase.Query<DocumentNotificationEntity>(strSql.ToString(), args.ToArray()).ToList();
            }
            catch (Exception e)
            {
       
                throw e;
            }

        }


       
    }
}
