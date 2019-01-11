using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.AllotMember
{
    public class AllotMemberDal : BaseDal<CrmMessageWorkEntity>
    {

        /// <summary>
        /// 获取待办事件
        /// </summary>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetSearchListForMessage(CrmMessageWorkEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM CrmMessageWork WHERE Rowstatus = 1");
            if (!string.IsNullOrEmpty(search.Id))
            {
                strSql.AppendFormat(" And Id = '{0}'", search.Id);
            }

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "AllotMemberDal.cs",
                ForUse = "获取待办事宜",
                FunName = "GetSearchListForMessage"
            };
            return ReadDatabase.Query<CrmMessageWorkEntity>(strSql.ToString()).ToList();
        }


        /// <summary>
        /// 新增待办事宜
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(CrmMessageWorkEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[CrmMessageWork]
           ([Id],[Titles],[ProcessInstanceID],[SendActivityID],[ActivityInstanceID]
           ,[StartDate],[SenderID]
           ,[ExecuteDate],[ActionerID],[FormID],[FormData],[FormAddress]
           ,[ContentTypeID],[IsReply],[State],[Note]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
            entity.Id, entity.Titles, entity.ProcessInstanceID, entity.SendActivityID, entity.ActivityInstanceID,
            entity.StartDate, entity.SenderID, entity.ExecuteDate, entity.ActionerID,
            entity.FormID, entity.FormData, entity.FormAddress,
            entity.ContentTypeID, entity.IsReply, entity.State, entity.Note, 
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

    }
}
