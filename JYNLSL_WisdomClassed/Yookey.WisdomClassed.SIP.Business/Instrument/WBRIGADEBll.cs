using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Instrument;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.Business.Instrument
{
    /// <summary>
    /// WBRIGADE业务逻辑
    /// </summary>
    public class WBRIGADEBll : BaseBll<WBRIGADEEntity>
    {
        public WBRIGADEBll()
        {
            BaseDal = new WBRIGADEDal();
        }
        /// <summary>
        /// 插入需要分配给队员的文书编号信息

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertWBRIGADE(WBRIGADEEntity model)
        {
            try
            {
                return new WBRIGADEDal().InsertWBRIGADE(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        /// 更新分配给人员的文书编号的文书状态

        /// </summary>
        /// <param name="recordid"></param>
        /// <param name="wstype"></param>
        /// <param name="wsno"></param>
        /// <returns></returns>
        public string UpdateWZDstorage(string recordid, string wstype, string wsno )
        {
            return new WBRIGADEDal().UpdateWZDstorage(recordid, wstype, wsno );
        }


        /// <summary>
        /// 执行多条SQL语句
        /// </summary>
        /// <param name="sql">添加的查询语句</param>
        /// <returns>int影响的行数</returns>
        public void InsertAdd(List<string> sql)
        {
            new WBRIGADEDal().InsertAdd(sql);
        }
        
 


    }
}
