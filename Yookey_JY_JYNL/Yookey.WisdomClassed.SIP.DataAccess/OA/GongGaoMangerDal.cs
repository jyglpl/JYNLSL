using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;
using PetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.DataAccess.OA
{
    public class GongGaoMangerDal : BaseDal<GongGaoMangerEntity>
    {
        /// <summary>
        /// 事务保存实体
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="listentity"></param>
        /// <returns></returns>
        public bool SaveGongGao(GongGaoMangerEntity entity,List<GongGaoDetialEntity> listentity)
        {
            //事务开始
            WriteDatabase.BeginTransaction();
            try
            {
                //公告管理表插入
                PersistNewItem(entity);

                //发送公告到个人表
                foreach (var liEntity in listentity)
                {
                     new GongGaoDetialDal().PersistNewItem(liEntity);
                }

            }
            catch (Exception e)
            {
                //事务回滚
                WriteDatabase.AbortTransaction();
                throw e;
            }
            //事务提交
            WriteDatabase.CompleteTransaction();
            return true;
        }

        /// <summary>
        /// 公文管理表
        /// 分页查询
        /// add by lpl
        /// 2019-1-2
        /// 效率为什么这么慢？？？
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<GongGaoMangerEntity> Query(long page, long pageSize)
        {
            try
            {
                var args = new List<object>();
                var strSql = new StringBuilder();
                strSql.Append(Database.GetFormatSql<GongGaoMangerEntity>(" Where {0} = @p1", t => t.RowStatus));
                args.Add(new { p1 = 1 });

                return WriteDatabase.Page<GongGaoMangerEntity>(page, pageSize, strSql.ToString(),args.ToArray());
            }
            catch (Exception e)
            {
            
                throw e;
            }
        }

        /// <summary>
        /// 直接查询list
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <returns></returns>
        public List<GongGaoMangerEntity> QueryList()
        {
            var strSql = new StringBuilder("SELECT * FROM dbo.GongWenManger WHERE 1=1");

            var args = new List<object>();

            return WriteDatabase.Query<GongGaoMangerEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

    }
}
