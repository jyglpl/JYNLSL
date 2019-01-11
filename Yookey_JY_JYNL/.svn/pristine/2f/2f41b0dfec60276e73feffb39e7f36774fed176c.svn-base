using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OnlineClass;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Business.OnlineClass
{
    public class OnlineClassRecordBll
    {
        private readonly OnlineClassRecordDal _dal = new OnlineClassRecordDal();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OnlineClassRecordEntity Get(string Id)
        {
            return _dal.Get(Id);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Update(OnlineClassRecordEntity search)
        {
            return _dal.Update(search);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(OnlineClassRecordEntity entity)
        {
            return _dal.Insert(entity);
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <returns></returns>
        public List<OnlineClassRecordEntity> GetSearchResult(OnlineClassRecordEntity search)
        {
            return _dal.GetSearchResult(search);
        }

       
    }
}
