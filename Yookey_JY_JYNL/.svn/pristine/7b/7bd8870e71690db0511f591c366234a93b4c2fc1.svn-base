using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomObjLogBll
    {
        private static readonly DoubleRandomObjLogDal dal = new DoubleRandomObjLogDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomObjLogEntity entity)
        {
            return dal.Insert(entity);
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomObjLogEntity> GetBy(string parentId)
        {
            return dal.GetBy(parentId);
        }

        /// <summary>
        /// 删除随机记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool DeleteLog(string parentId)
        {
            return dal.DeleteLog(parentId);
        }

        /// <summary>
        /// 更新随机记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool Update(DoubleRandomObjLogEntity entity)
        {
            return dal.Update(entity);
        }

        /// <summary>
        /// 派发随机记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public bool UpdateLog(string parentId)
        {
            return dal.UpdateLog(parentId);
        }
        
    }
}
