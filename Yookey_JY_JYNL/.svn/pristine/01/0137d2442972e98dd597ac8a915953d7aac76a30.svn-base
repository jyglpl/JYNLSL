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
    /// WDEPTSTORAGE业务逻辑
    /// </summary>
    public class WDEPTSTORAGEBll : BaseBll<WDEPTSTORAGEEntity> 
    {
        public WDEPTSTORAGEBll()
        {
            BaseDal = new WDEPTSTORAGEDal();
        }
        public string InsertWDpetSQL(WDEPTSTORAGEEntity _WDEPTSTORAGE)
        {
            try
            {
                return new WDEPTSTORAGEDal().InsertWDpetSQL(_WDEPTSTORAGE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
             /// <summary>
        /// 查询文书编号是否存在，或者被领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <param name="wcount">张数</param>
        /// <returns></returns>
        public DataTable IsExitWDEPTSTORAGE(string startno, string endno, string wtype,string DeptId)
        {
            try
            {
                return new WDEPTSTORAGEDal().IsExitWDEPTSTORAGE(startno, endno, wtype, DeptId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region 文书大队领用
        /// <summary>
        /// 更改入库表中的号码为领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <returns></returns>
        public bool UpdateWDEPTSTORAGE(string startno, string endno, string wtype, string recordid)
        {
            try
            {
                return new WDEPTSTORAGEDal().UpdateWDEPTSTORAGE(startno, endno, wtype, recordid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
