//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ExcavationBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/8/26 17:24:11
//  功能描述：Excavation业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Consent;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.Business.Consent
{
    /// <summary>
    /// 许可开挖业务逻辑
    /// </summary>
    public class ExcavationBll : BaseBll<ExcavationEntity>
    {
        public ExcavationBll()
        {
            BaseDal = new ExcavationDal();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(ExcavationEntity entity)
        {
            return new ExcavationDal().Save(entity);
        }

        /// <summary>
        /// 绿地挖掘
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="pageSzie">每页条数</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryExcavationList(string startTime, string endTime, string keyword, string companyId, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new ExcavationDal().QueryExcavationList(startTime, endTime, keyword, companyId, pageSzie, pageIndex,
                                                             out totalRecords);

            stopwatch.Stop();
            int totalPage = (totalRecords + pageSzie - 1) / pageSzie; //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }


        /// <summary>
        /// 手机查询绿地挖掘
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页条数</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public DataTable MobileQueryExcavationList(string companyId, string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            int totalRecords;
            var data = new ExcavationDal().QueryExcavationList("", "", keyword,companyId, pageSzie, pageIndex, out totalRecords);
            return data;
        }


        /// <summary>
        /// 请求详情
        /// 添加人：周 鹏
        /// 添加时间：2015-09-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDetail(string id)
        {
            return new ExcavationDal().GetDetail(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="menuIds">编号</param>
        /// <returns></returns>
        public bool BatchDeleteExcavation(string menuIds)
        {
            return new ExcavationDal().BatchDeleteConsent(menuIds);
        }
    }
}
