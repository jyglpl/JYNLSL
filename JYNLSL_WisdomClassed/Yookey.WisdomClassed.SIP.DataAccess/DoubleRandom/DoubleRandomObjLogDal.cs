using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomObjLogDal : BaseDal<DoubleRandomObjLogEntity>
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomObjLogEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[DoubleRandomObjLog]
           ([Id],[ParentId],[TeamId],[TypeId],[ObjId],
            [ObjName],[InspectorIds],[InspectorNames],IsDispatch,FinishBy,FinishPerson,FinishTime,Remark
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
            entity.Id,entity.ParentId ,entity.TeamId,entity.TypeId,entity.ObjId, entity.ObjName,
            entity.InspectorIds, entity.InspectorNames,entity.IsDispatch,entity.FinishBy,entity.FinishPerson,entity.FinishTime,entity.Remark,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }
      
        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomObjLogEntity> GetBy(string parentId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM DoubleRandomObjLog where RowStatus=1 ");
            if (!string.IsNullOrEmpty(parentId))
            {
                strSql.AppendFormat(" And ParentId = '{0}'", parentId);
            }
            return ReadDatabase.Query<DoubleRandomObjLogEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 删除随机记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool DeleteLog(string parentId)
        {
            var strSql = string.Format(@"DELETE FROM [dbo].[DoubleRandomObjLog] where ParentId='{0}'", parentId);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(DoubleRandomObjLogEntity entity)
        {
            var strSql = string.Format(@"UPDATE [dbo].[DoubleRandomObjLog] SET
            [ParentId] = '{1}',[TeamId]= '{2}',[TypeId]= '{3}',[ObjId]= '{4}',
            [ObjName]= '{5}',[InspectorIds]= '{6}',[InspectorNames]= '{7}',IsDispatch = '{8}',
            FinishBy = '{9}',FinishPerson = '{10}',FinishTime = '{11}',Remark = '{12}'
           ,[RowStatus]= '{13}',[CreatorId]= '{14}',[CreateBy]= '{15}',[CreateOn]= '{16}',[UpdateId]= '{17}',[UpdateBy]= '{18}',[UpdateOn]= '{19}'
            where Id = '{0}'",
            entity.Id, entity.ParentId, entity.TeamId, entity.TypeId, entity.ObjId, entity.ObjName,
            entity.InspectorIds, entity.InspectorNames,entity.IsDispatch,entity.FinishBy,entity.FinishPerson,entity.FinishTime,entity.Remark,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 派发随机记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool UpdateLog(string parentId)
        {
            var strSql = string.Format(@"Update [dbo].[DoubleRandomObjLog] set IsDispatch=1 where ParentId='{0}'", parentId);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
