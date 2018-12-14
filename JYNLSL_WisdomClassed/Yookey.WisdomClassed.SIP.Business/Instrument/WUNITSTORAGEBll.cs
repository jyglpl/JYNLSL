using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Instrument;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.Business.Instrument
{
    /// <summary>
    /// WUNITSTORAGE业务逻辑
    /// </summary>
    public class 
        WUNITSTORAGEBll : BaseBll<WUNITSTORAGEEntity>
    {
        public WUNITSTORAGEBll()
        {
            BaseDal = new WUNITSTORAGEDal();
        }
        /// <summary>
        /// 大队入库主表
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public string InsertWUNITSTORAGE(WUNITSTORAGEEntity Entity)
        {
            return new WUNITSTORAGEDal().InsertWUNITSTORAGE(Entity);

        }
        /// <summary>
        /// 查询文书编号是否存在，或者被领用
        /// </summary>
        /// <param name="startno">开始编号</param>
        /// <param name="endno">结束编号</param>
        /// <param name="wtype">文书类型</param>
        /// <param name="wcount">张数</param>
        /// <returns></returns>
        public DataTable IsExitWUNITSTORAGE(string startno, string endno, string wtype)
        {
            try
            {
                return new WUNITSTORAGEDal().IsExitWUNITSTORAGE(startno, endno, wtype);
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
        public bool UpdateWUNITSTORAGE(string startno, string endno, string wtype, string recordid)
        {
            try
            {
                return new WUNITSTORAGEDal().UpdateWUNITSTORAGE(startno, endno, wtype, recordid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        public PageJqDatagrid<DataTable> GetInstrumentList(string startno, string endno, string deptid, string wtype, string sidx, string sord, int pageSize = 15,
                                                                int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data = new WUNITSTORAGEDal().GetInstrumentList(startno, endno, deptid, wtype, sidx, sord, pageSize, pageIndex, out totalRecords);

                data.TableName = "InstrumentDT";
                stopwatch.Stop();
                int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PageJqDatagrid<DataTable> QueryZDInstrumentList(string startno, string endno, string deptid, string wtype, string sidx, string sord, int pageSize = 15,
                                                                int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data = new WUNITSTORAGEDal().QueryZDInstrumentList(startno, endno, deptid, wtype, sidx, sord, pageSize, pageIndex, out totalRecords);

                data.TableName = "InstrumentDT";
                stopwatch.Stop();
                int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public PageJqDatagrid<DataTable> QueryGRInstrumentList(string startno, string endno, string deptid, string userid, string wtype, string sidx, string sord, int pageSize = 15,
                                                                int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data = new WUNITSTORAGEDal().QueryGRInstrumentList(startno, endno, deptid, userid, wtype, sidx, sord, pageSize, pageIndex, out totalRecords);

                data.TableName = "InstrumentDT";
                stopwatch.Stop();
                int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PageJqDatagrid<DataTable> QueryInstrumentSearch(string startno, string endno, string deptid, string userid, string wtype,string starttime,string endtime, string type,string sidx, string sord, int pageSize = 15,
                                                                int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data = new WUNITSTORAGEDal().QueryInstrumentSearch(startno, endno, deptid, userid, wtype, starttime, endtime, type,sidx, sord, pageSize, pageIndex, out totalRecords);

                data.TableName = "InstrumentDT";
                stopwatch.Stop();
                int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public PageJqDatagrid<DataTable> QueryInstrumentSearchKC(string startno, string endno , string wtype, string sidx, string sord, int pageSize = 15,
                                                                int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data = new WUNITSTORAGEDal().QueryInstrumentSearchKC(startno, endno, wtype, sidx, sord, pageSize, pageIndex, out totalRecords);

                data.TableName = "InstrumentDT";
                stopwatch.Stop();
                int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /// <summary>
       /// 获取文书库存
       /// </summary>
       /// <param name="wsTypts">文书类型ID</param>
       /// <param name="StorageType">部门</param>
       /// <returns></returns>
        public object GetStorageSelect(string wsTypts, string StorageType, string deptId, string daduiId)
        {
            var data = new WUNITSTORAGEDal().GetStorageSelect(wsTypts, StorageType, deptId, daduiId);
            var selectList = data.Item1.Select().Select(i => i["wsno"].ToString());
            var count = data.Item2;
            return new {selectList=selectList,count=count };
        }
      

    }
}
