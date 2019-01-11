using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomObjBll
    {
        private static readonly DoubleRandomObjDal Dal = new DoubleRandomObjDal();

        /// <summary>
        /// 获取随机对象列表
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomObjEntity> GetSearchList(DoubleRandomObjEntity search)
        {
            return Dal.GetSearchList(search);
        }

        /// <summary>
        /// 获取抽查对象
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DoubleRandomObjEntity> GetDoubleRandomObjList(string teamId, string typeId, string objName, int pageSize, int pageIndex)
        {
            return Dal.GetDoubleRandomObjList(teamId, typeId,objName, pageSize, pageIndex);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DoubleRandomObjEntity Get(string Id)
        {
            return Dal.Get(Id);
        }
        /// <summary>
        /// 获取当前大队下最大随机数
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public int GetRandomNo(string teamId)
        {
            return Dal.GetRandomNo(teamId);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomObjEntity entity)
        {
            return Dal.Insert(entity);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(DoubleRandomObjEntity search)
        {
            return Dal.Update(search);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteObj(string id)
        {
            return Dal.DeleteObj(id);
        }
    }
}
