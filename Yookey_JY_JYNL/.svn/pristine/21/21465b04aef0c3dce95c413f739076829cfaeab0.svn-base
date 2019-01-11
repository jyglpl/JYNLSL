//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNMIDDLEBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_CHECKSIGNMIDDLE业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 违法停车手机数据 业务逻辑
    /// </summary>
    public class InfCarChecksignmiddleBll : BaseBll<InfCarChecksignmiddleEntity>
    {
        public InfCarChecksignmiddleBll()
        {
            BaseDal = new InfCarChecksignmiddleDal();
        }


        /// <summary>
        /// 获取数据列表
        /// 添加人：张 晖
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-03 周 鹏 更新数据查询方式
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<CarList> GetSearchResult(CarList search)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new InfCarChecksignmiddleDal().GetSearchResult(search);
            var list = ConvertListHelper<CarList>.ConvertToList(data);
            foreach (var entity in list)
            {
                var nowSpan = new TimeSpan(DateTime.Now.Ticks);
                var createSpan = new TimeSpan(entity.CheckDate.Ticks);
                var ts = createSpan.Subtract(nowSpan).Duration();  //上传日期与当前日期间隔时长

                var hours = AppConfig.DayNum * 24 - ts.TotalHours;
                if (hours < 0)
                    hours = 0;
                entity.Hours = hours.ToString("f2") + "小时";
            }
            stopwatch.Stop();
            return new PageJqDatagrid<CarList>
            {
                page = 1,
                rows = list,
                total = 1,
                records = list.Count,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 获取所有未审核的数据
        /// 添加人：周 鹏
        /// 添加时间：2015-07-29
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        public DataTable GetSearchAllUnCheck()
        {
            var data = new InfCarChecksignmiddleDal().GetSearchAllUnCheck();
            return data;
        }

        /// <summary>
        /// 验证通知书编号是否可以被使用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="noticeNo">通知书编号</param>
        /// <returns></returns>
        public bool CheckNoticeNo(string noticeNo)
        {
            try
            {
                return new InfCarChecksignmiddleDal().CheckNoticeNo(noticeNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
