using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomAttachDal : BaseDal<DoubleRandomAttachEntity>
    {

        /// <summary>
        /// 新增双随机附件
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool Add(DoubleRandomAttachEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[DoubleRandomAttach]
           ([Id],[ResourceId],[FileName],[FileReName],[FileSize]
           ,[FileAddress],[FileType],[FileTypeName],[IsCompleted],[FileRemark]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",
             entity.Id, entity.ResourceId, entity.FileName, entity.FileReName, entity.FileSize,
             entity.FileAddress, entity.FileType, entity.FileTypeName, entity.IsCompleted, entity.FileRemark,
             entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据对象查询列表
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public List<DoubleRandomAttachEntity> Search(DoubleRandomAttachEntity Entity)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM DoubleRandomAttach WHERE ROWSTATUS = 1");
            if (!string.IsNullOrEmpty(Entity.ResourceId))
            {
                strSql.AppendFormat(" And ResourceId = '{0}'", Entity.ResourceId);
            }
            return WriteDatabase.Query<DoubleRandomAttachEntity>(strSql.ToString()).ToList();
        }
    }
}
