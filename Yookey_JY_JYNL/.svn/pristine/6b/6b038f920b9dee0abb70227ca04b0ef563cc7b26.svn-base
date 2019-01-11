//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TemporaryBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Temporary业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Consent;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.Business.Consent
{
    /// <summary>
    /// Temporary业务逻辑
    /// </summary>
    public class TemporaryBll : BaseBll<TemporaryEntity>
    {
        public TemporaryBll()
        {
            BaseDal = new TemporaryDal();
        }


        /// <summary>
        /// 临时占道
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryTemporaryList(string startTime, string endTime, string keyword, string CompanyId, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new TemporaryDal().QueryTemporaryList(startTime, endTime, keyword, CompanyId, pageSzie, pageIndex,
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
        /// 临时占道
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable MobileQueryTemporaryList(string companyId, string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            int totalRecords;
            var data = new TemporaryDal().QueryTemporaryList("", "", keyword, companyId, pageSzie, pageIndex, out totalRecords);
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
            return new TemporaryDal().GetDetail(id);
        }

        /// <summary>
        /// 保存占道经营
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveTemporary(TemporaryEntity entity)
        {
            return new TemporaryDal().SaveTemporary(entity);
        }

        /// <summary>
        /// 删除占道经营
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool BatchDeleteTemporary(string menuIds)
        {
            return new TemporaryDal().BatchDeleteTemporary(menuIds);
        }
    }
}
