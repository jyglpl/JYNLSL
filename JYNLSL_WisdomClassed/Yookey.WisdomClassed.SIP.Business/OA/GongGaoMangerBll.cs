using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using PetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Business.OA
{
    public class GongGaoMangerBll
    {
        private static readonly GongGaoMangerDal Dal = new GongGaoMangerDal();

        /// <summary>
        /// 事务保存实体
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="listentity"></param>
        /// <returns></returns>
        public bool SaveGongGao(GongGaoMangerEntity entity, List<GongGaoDetialEntity> listentity)
        {
            try
            {
                return Dal.SaveGongGao(entity, listentity);
            }
            catch (Exception e)
            {

                throw e;
            }
        
        }

        /// <summary>
        /// ORM分页查询公文管理表
        /// add by lpl
        /// 2019-1-2
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<GongGaoMangerEntity> Query(long page, long pageSize)
        {
            try
            {
                 return  Dal.Query(page, pageSize);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<GongGaoMangerEntity> QueryList()
        {
            try
            {
                return Dal.QueryList();
            }
            catch (Exception e)
            {
 
                throw e;
            }
        }


    }
}
