using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    public class IllegalCaseVerifyBll
    {
        public static readonly IllegalCaseVerifyDal Dal = new IllegalCaseVerifyDal();

        /// <summary>
        /// 获取违法案件核实信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseVerifyEntity> GetIllegalCaseResult(IllegalCaseVerifyEntity search)
        {
            return Dal.GetIllegalCaseResult(search);
        }

        /// <summary>
        /// 新增违法案件核实信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalVerifyInfo(IllegalCaseVerifyEntity entity)
        {
            return Dal.InsertIllegalVerifyInfo(entity);
        }
    }
}
