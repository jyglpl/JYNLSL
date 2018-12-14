using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;
using Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Business.DoubleRandom
{
    public class DoubleRandomEnterpriseBll
    {
        private static readonly DoubleRandomEnterpriseDal Dal = new DoubleRandomEnterpriseDal();

        /// <summary>
        /// 获取企业列表
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomEnterpriseEntity> GetSearchListForEnterprise(DoubleRandomEnterpriseEntity search)
        {
            return Dal.GetSearchListForEnterprise(search);
        }

        /// <summary>
        /// 查询企业双随机企业列表
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        //public PetaPoco.Page<DoubleRandomEnterpriseEntity> GetSearchResult(DoubleRandomEnterpriseEntity search)
        //{
        //    return Dal.GetSearchResult(search);
        //}

        public Page<DoubleRandomEnterpriseEntity> GetSearchResult(string paperType, string txtName, int pageSize = 30, int pageIndex = 1)
        {
            return Dal.GetSearchResult(paperType, txtName, pageSize, pageIndex);
        }

        /// <summary>
        /// 新增企业
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertEnt(DoubleRandomEnterpriseEntity entity)
        {
            return Dal.InsertEnt(entity);
        }

        /// <summary>
        /// 更新企业
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEnt(DoubleRandomEnterpriseEntity entity)
        {
            return Dal.UpdateEnt(entity);
        }
    }
}
