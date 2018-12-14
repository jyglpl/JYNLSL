using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomSpotChecksBll
    {
        private static readonly DoubleRandomSpotChecksDal dal = new DoubleRandomSpotChecksDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(DoubleRandomSpotChecksEntity entity)
        {
            return dal.Insert(entity);
        }

        /// <summary>
        /// 查询所有抽查数据
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public List<DoubleRandomSpotChecksEntity> GetSearchList(DoubleRandomSpotChecksEntity Search)
        {
            return dal.GetSearchList(Search);
        }

        /// <summary>
        /// 获取抽查批次
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public Page<DoubleRandomSpotChecksEntity> GetDoubleRandomSpotChecksList(string startTime, string endTime,string type, int pageSize, int pageIndex)
        {
            return dal.GetDoubleRandomSpotChecksList(startTime, endTime,type, pageSize, pageIndex);
        }

        public List<DoubleRandomSpotChecksEntity> GetRandomCount(string startTime, string endTime, string type)
        {
            return dal.GetRandomCount(startTime, endTime,type);
        }

        /// <summary>
        /// 删除抽查批次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSpot(string id)
        {
            return dal.DeleteSpot(id);
        }
        
        /// <summary>
        /// 更新抽查派发状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateIsDispatch(string Id)
        {
            return dal.UpdateIsDispatch(Id);
        }
    }
}
