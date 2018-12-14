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
    /// W_TYPETABLE业务逻辑
    /// </summary>
    public class W_TYPETABLEBll : BaseBll<W_TYPETABLEEntity>
    {
        public W_TYPETABLEBll()
        {
            BaseDal = new W_TYPETABLEDal();
        }
        /// <summary>
        /// 文书类型
        /// 添加日期：2017-03-13
        /// 添加人：叶念
        /// </summary>
        /// <param name="WRsCode">文书类型</param>
        /// <returns></returns>
        public DataTable GetWTypeByWRsCode(string WRsCode)
        {
            return new W_TYPETABLEDal().GetWTypeByWRsCode(WRsCode);
        }
        /// <summary>
        /// 文书类型
        /// 添加日期：2017-03-13
        /// 添加人：叶念
        /// </summary>
        /// <returns></returns>

        public IList<W_TYPETABLEEntity> GetTypeTables()
        {
            var queryCondition = QueryCondition.Instance.AddEqual(W_TYPETABLEEntity.Parm_W_TYPETABLE_RowStatus, "1");
            //排序
            queryCondition.AddOrderBy(W_TYPETABLEEntity.Parm_W_TYPETABLE_WRSCODE, true);
            return Query(queryCondition);
        }
        public PageJqDatagrid<DataTable> QueryTypeTable(string sidx, string sord, int pageSize = 15,
                                                              int pageIndex = 1)
        {
            try
            {

                //计时
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;

                var data =new W_TYPETABLEDal().QueryTypeTable(sidx, sord, pageSize, pageIndex, out totalRecords);

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
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveTypeTable(W_TYPETABLEEntity entity)
        {
            try
            {
                var caseEntity = Get(entity.Id);   //验证文书类别是否已经存在
                if (caseEntity != null)
                {

                    entity.RowStatus = 1;
                    entity.CreatorId = caseEntity.CreatorId;
                    entity.CreateBy = caseEntity.CreateBy;
                    entity.CreateOn = caseEntity.CreateOn;


                    return Update(entity) > 0;  //修改案件

                }
                else
                {
                    entity.RowStatus = 1;
                    entity.Id = Guid.NewGuid().ToString();

                    Add(entity);    //新增案件
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new W_TYPETABLEDal().BatchDelete(ids);
        }



    }
}
