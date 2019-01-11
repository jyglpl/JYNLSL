using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomObjDal : BaseDal<DoubleRandomObjEntity>
    {
        /// <summary>
        /// 获取随机对象列表
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomObjEntity> GetSearchList(DoubleRandomObjEntity search)
        {
            var sbWhere = new StringBuilder();
            sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>("Where {0}=1 ", u => u.RowStatus));
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Id))
            {
                sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>(" and {0} = @p1 ", t => t.Id));
                args.Add(new { p1 = search.Id });
            }
            //根据大队Id
            if (!string.IsNullOrEmpty(search.TeamId))
            {
                sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>(" and {0} = @p2 ", t => t.TeamId));
                args.Add(new { p2 = search.TeamId });
            }
            //根据类型Id
            if (!string.IsNullOrEmpty(search.TypeId))
            {
                sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>(" and {0} = @p3 ", t => t.TypeId));
                args.Add(new { p3 = search.TypeId });
            }
            //根据名称
            if (!string.IsNullOrEmpty(search.ObjName))
            {
                sbWhere.AppendFormat(@" and ObjName like '%{0}%' ", search.ObjName);
            }
            sbWhere.Append(" ORDER BY CreateOn desc");

            return WriteDatabase.Query<DoubleRandomObjEntity>(sbWhere.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取抽查对象
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DoubleRandomObjEntity> GetDoubleRandomObjList(string teamId, string typeId, string objName, int pageSize, int pageIndex)
        {
            var sbWhere = new StringBuilder();
            var args = new List<object>();
            sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>("Where {0}=1 ", t => t.RowStatus));
            if (!string.IsNullOrEmpty(teamId))
            {
                 sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>(" and {0} = @p1 ", t => t.TeamId));
                args.Add(new { p1 = teamId });
            }
            //根据类型Id
            if (!string.IsNullOrEmpty(typeId))
            {
                sbWhere.Append(Database.GetFormatSql<DoubleRandomObjEntity>(" and {0} = @p2 ", t => t.TypeId));
                args.Add(new { p2 = typeId });
            }
            //根据名称
            if (!string.IsNullOrEmpty(objName))
            {
                sbWhere.AppendFormat(@" and ObjName like '%{0}%' ", objName);
            }
            sbWhere.Append(" ORDER BY CreateOn desc");
            return WriteDatabase.Page<DoubleRandomObjEntity>(pageIndex, pageSize, sbWhere.ToString(), args.ToArray());
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DoubleRandomObjEntity Get(string Id)
        {
            var strSql = string.Format(@"SELECT * FROM DoubleRandomObj WHERE Id='{0}'", Id);
            return WriteDatabase.SingleOrDefault<DoubleRandomObjEntity>(strSql);
        }

        /// <summary>
        /// 获取当前大队下最大随机数
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public int GetRandomNo(string teamId)
        {
            var strSql = string.Format(@"SELECT max(RandomNo) FROM DoubleRandomObj WHERE [TeamId]='{0}'", teamId);
            int num=WriteDatabase.ExecuteScalar<int>(strSql.ToString());
            return num;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomObjEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[DoubleRandomObj]
           ([Id],[TeamId],[TypeId],[ObjName],[Position]
           ,[Developer],[Property],[PropertyFZR],[PhoneNo],[RandomNo]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",
             entity.Id, entity.TeamId, entity.TypeId, entity.ObjName,entity.Position,
             entity.Developer, entity.Property,entity.PropertyFZR,entity.PhoneNo,entity.RandomNo,
             entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);

            return WriteDatabase.Execute(strSql) > 0;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(DoubleRandomObjEntity search)
        {
            var strSqlLink = new StringBuilder();
            if (!string.IsNullOrEmpty(search.TeamId))
            {
                strSqlLink.AppendFormat(@" TeamId = '{0}',", search.TeamId);
            }
            if (!string.IsNullOrEmpty(search.TypeId))
            {
                strSqlLink.AppendFormat(@" TypeId = '{0}',", search.TypeId);
            }
            if (!string.IsNullOrEmpty(search.ObjName))
            {
                strSqlLink.AppendFormat(@" ObjName = '{0}',", search.ObjName);
            }
            if (!string.IsNullOrEmpty(search.Position))
            {
                strSqlLink.AppendFormat(@" Position = '{0}',", search.Position);
            }
            if (!string.IsNullOrEmpty(search.Developer))
            {
                strSqlLink.AppendFormat(@" Developer = '{0}',", search.Developer);
            }
            if (!string.IsNullOrEmpty(search.Property))
            {
                strSqlLink.AppendFormat(@" Property = '{0}',", search.Property);
            }
            if (!string.IsNullOrEmpty(search.PropertyFZR))
            {
                strSqlLink.AppendFormat(@" PropertyFZR = '{0}',", search.PropertyFZR);
            }
            if (!string.IsNullOrEmpty(search.PhoneNo))
            {
                strSqlLink.AppendFormat(@" PhoneNo = '{0}',", search.PhoneNo);
            }
            if (!string.IsNullOrEmpty(search.UpdateId))
            {
                strSqlLink.AppendFormat(@" UpdateId = '{0}',", search.UpdateId);
            }
            if (!string.IsNullOrEmpty(search.UpdateBy))
            {
                strSqlLink.AppendFormat(@" UpdateBy = '{0}',", search.UpdateBy);
            }
            if (!string.IsNullOrEmpty((search.UpdateOn).ToString()))
            {
                strSqlLink.AppendFormat(@" UpdateOn = '{0}',", search.UpdateOn);
            }
            var strSql = string.Format(@"UPDATE [DoubleRandomObj] SET {0} ROWSTATUS=1  WHERE Id='{1}'", strSqlLink, search.Id);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteObj(string id)
        {
            var strSql = string.Format(@"UPDATE [DoubleRandomObj] SET  ROWSTATUS=0  WHERE Id='{0}'", id);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
