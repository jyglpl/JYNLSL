//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ActivityBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Activity业务逻辑类
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
    /// Activity业务逻辑
    /// </summary>
    public class ActivityBll : BaseBll<ActivityEntity>
    {
        public ActivityBll()
        {
            BaseDal = new ActivityDal();
        }
        /// <summary>
        /// 保存举办活动
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveActivity(ActivityEntity entity)
        {
            return new ActivityDal().SaveActivity(entity);
        }

        /// <summary>
        /// 举办活动查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="keyword"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryActivityList(string startTime, string endTime, string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new ActivityDal().QueryActivityList(startTime, endTime, keyword, pageSzie, pageIndex, out totalRecords);

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
        /// 手机端举办活动查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable MobileQueryActivityList(string keyword, int pageSzie = 15, int pageIndex = 1)
        {
            int totalRecords;
            var data = new ActivityDal().QueryActivityList("", "", keyword, pageSzie, pageIndex, out totalRecords);
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
            return new ActivityDal().GetDetail(id);
        }

        /// <summary>
        /// 删除举办活动
        /// </summary>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool BatchDeleteConsent(string menuIds)
        {
            return new ActivityDal().BatchDeleteConsent(menuIds);
        }

    }
}
