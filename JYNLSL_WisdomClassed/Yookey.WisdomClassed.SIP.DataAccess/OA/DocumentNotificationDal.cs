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
          
            sbWhere.Append(" ORDER BY  CreateOn");
            return WriteDatabase.Query<DocumentNotificationEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }


        public List<DocumentNotificationEntity> SearchQuery(DocumentNotificationEntity entity)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"select top "+entity.page.PageSize+" * from (select row_number()over(order by CreateOn)rownumber,* from DocumentNotification)a1 where rownumber>"+(entity.page.CurrentPage - 1) * entity.page.PageSize + "");
            var args = new List<object>();

            return WriteDatabase.Query<DocumentNotificationEntity>(strSql.ToString(), args.ToArray()).ToList();
        }


        //     /// <summary>
        //     /// 数据查询
        //     /// </summary>
        //     /// <param name="search"></param>
        //     /// <param name="expressions"></param>
        //     /// <returns></returns>
        //     public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search, List<string> types)
        //     {
        //         var sbWhere = new StringBuilder();
        //         sbWhere.Append("Where ROWSTATUS = 1 ");
        //         var args = new List<object>();
        //         if (!string.IsNullOrEmpty(search.ResourceId))
        //         {
        //             sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p1 ", t => t.ResourceId));
        //             args.Add(new { p1 = search.ResourceId });
        //         }
        //         if (types != null && types.Count > 0)
        //         {
        //             sbWhere.AppendFormat("and FileType in  ('{0}')", string.Join("','", types.ToArray()));
        //         }
        //         sbWhere.Append(" ORDER BY CreateOn ");
        //         return WriteDatabase.Query<EvaluationAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        //     }

        //     public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search)
        //     {
        //         var sbWhere = new StringBuilder();
        //         sbWhere.Append("Where ROWSTATUS = 1 ");
        //         var args = new List<object>();
        //         if (!string.IsNullOrEmpty(search.ResourceId))
        //         {
        //             sbWhere.Append(Database.GetFormatSql<EvaluationAttachEntity>(" and {0} = @p1 ", t => t.ResourceId));
        //             args.Add(new { p1 = search.ResourceId });
        //         }
        //         sbWhere.Append(" ORDER BY CreateOn ");
        //         return WriteDatabase.Query<EvaluationAttachEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        //     }

        //     /// <summary>
        //     /// 新增附件材料
        //     /// </summary>
        //     /// <param name="search"></param>
        //     /// <returns></returns>
        //     public bool Insert(EvaluationAttachEntity search)
        //     {
        //         var strSql = string.Format(@"INSERT INTO [dbo].[EvaluationAttach]
        //        ([Id],[ResourceId],[FileName],[FileReName],[FileSize]
        //        ,[IsCompleted],[FileAddress],[FileType],[FileTypeName],[FileRemark]
        //        ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
        //VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')"
        //       , search.Id, search.ResourceId, search.FileName, search.FileReName, search.FileSize
        //       , search.IsCompleted, search.FileAddress, search.FileType, search.FileTypeName, search.FileRemark
        //       , search.RowStatus, search.CreatorId, search.CreateBy, search.CreateOn, search.UpdateId, search.UpdateBy, search.UpdateOn);
        //         return WriteDatabase.Execute(strSql) > 0;
        //     }

        //     /// <summary>
        //     /// 根据主键删除附件
        //     /// </summary>
        //     /// <param name="Id"></param>
        //     /// <returns></returns>
        //     public int Delete(string id)
        //     {
        //         var strSql = string.Format(@"UPDATE EvaluationAttach SET ROWSTATUS='{0}' WHERE Id='{1}'", (int)RowStatus.Delete, id);
        //         return WriteDatabase.Execute(strSql);
        //     }





       
    }
}
