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
    /// WZDSTORAGE业务逻辑
    /// </summary>
    public class WZDSTORAGEBll : BaseBll<WZDSTORAGEEntity> 
    {
        public WZDSTORAGEBll()
        {
            BaseDal = new WZDSTORAGEDal();
        }

        /// <summary>
        /// 中队入库主表
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public string InsertWZDSTORAGE(WZDSTORAGEEntity Entity)
        {
            return new WZDSTORAGEDal().InsertWZDSTORAGE(Entity);

        }
        /// <summary>
        /// 获得分配给中队的文书编号是否可以领用
        /// </summary>
        /// <param name="deptid">部门编号</param>
        /// <param name="startno">开始号</param>
        /// <param name="endno">结束号</param>
        /// <returns></returns>
        public DataTable IsGet(  string startno, string endno, string wtype,string DeptId)
        {
            try
            {
                return new WZDSTORAGEDal().IsGet( startno, endno, wtype, DeptId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///  获得需要分配给队员的文书编号信息

        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="startno"></param>
        /// <param name="endno"></param>
        /// <param name="wtype"></param>
        /// <returns></returns>
        public DataTable InsertUseWsno(string deptid, string startno, string endno, string wtype)
        {
            try
            {
                return  new WZDSTORAGEDal().InsertUseWsno(deptid, startno, endno, wtype);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}