//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AdvertisingBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Advertising业务逻辑类
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
    /// Advertising业务逻辑
    /// </summary>
    public class AdvertisingBll : BaseBll<AdvertisingEntity>
    {

        public AdvertisingBll()
        {
            BaseDal = new AdvertisingDal();
        }
        /// <summary>
        /// 户外广告保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveAdvertis(AdvertisingEntity entity)
        {
            return new AdvertisingDal().SaveAdvertis(entity);
        }

        /// <summary>
        /// 户外广告查询
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="TypeId"></param>
        /// <param name="keyword"></param>
        /// <param name="companyId"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryAdvertingList(string StartTime, string EndTime, string TypeId, string keyword, string companyId,
                                                            int pageSzie = 15,
                                                           int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new AdvertisingDal().QueryAdvertingList(StartTime, EndTime, TypeId, keyword, companyId, pageSzie, pageIndex,
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
        /// 手机端户外广告查询
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页请求条数</param>
        /// <param name="pageIndex">当前请求页</param>
        /// <returns></returns>
        public DataTable MobileQueryAdvertingList(string companyId, string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            int totalRecords;
            var data = new AdvertisingDal().QueryAdvertingList("", "", "", keyword, companyId, pageSzie, pageIndex, out totalRecords);
            return data;
        }


        /// <summary>
        /// 手机端户外广告查询
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页请求条数</param>
        /// <param name="pageIndex">当前请求页</param>
        /// <returns></returns>
        public DataTable MobileQueryLicenseList(string companyId, string StartTime, string EndTime, string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            int totalRecords;
            var data = new AdvertisingDal().QueryLicenseList(StartTime, EndTime, "", keyword, companyId, pageSzie, pageIndex, out totalRecords);
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
            return new AdvertisingDal().GetDetail(id);
        }

        /// <summary>
        /// 户外广告删除
        /// </summary>
        /// <param name="menuIds">信访编号</param>
        /// <returns></returns>
        public bool BatchDeleteConsent(string menuIds)
        {
            return new AdvertisingDal().BatchDeleteConsent(menuIds);
        }
    }
}
