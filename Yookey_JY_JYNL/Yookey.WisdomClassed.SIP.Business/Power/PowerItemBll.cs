using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Power;
using Yookey.WisdomClassed.SIP.Model.Power;

namespace Yookey.WisdomClassed.SIP.Business.Power
{
    public class PowerItemBll
    {
        private  static  readonly  PowerItemDal Dal = new PowerItemDal();

        /// <summary>
        /// 直接查询list，不分页
        /// ad by lpl
        /// 2019-1-3
        /// </summary>
        /// <returns></returns>
        public List<PowerItemEntity> QueryList(PowerItemEntity powerItemEntity)
        {
            try
            {
                return Dal.QueryList(powerItemEntity);
            }
            catch (Exception e)
            {
    
                throw e;
            }
        }

        /// <summary>
        /// 查询单个实体
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PowerItemEntity Single(string Id)
        {
            try
            {
                return Dal.Single(Id);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        /// <summary>
        /// 新增数据
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="powerItemEntity"></param>
        /// <returns></returns>
        public bool Add(PowerItemEntity powerItemEntity)
        {
            try
            {
                return Dal.PersistNewItem(powerItemEntity);
            }
            catch (Exception e)
            {
      
                throw e;
            }

        }

        /// <summary>
        /// 更新数据
        /// add by lpl
        /// 2019-1-3
        /// </summary>
        /// <param name="powerItemEntity"></param>
        /// <returns></returns>
        public  bool Update(PowerItemEntity powerItemEntity)
        {
            try
            {
                return Dal.PersistUpdatedItem(powerItemEntity);
            }
            catch (Exception e)
            {
         
                throw e;
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="powerItemEntity"></param>
        /// <returns></returns>
        public bool Delete(PowerItemEntity powerItemEntity)
        {
            try
            {
                return Dal.PersistDeletedItem(powerItemEntity);
            }
            catch (Exception e)
            {
     
                throw e;
            }

        }


    }
}
