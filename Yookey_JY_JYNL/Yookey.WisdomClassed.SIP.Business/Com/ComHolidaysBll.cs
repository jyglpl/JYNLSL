//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComHolidaysBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/20 9:42:35
//  功能描述：ComHolidays业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComHolidays业务逻辑
    /// </summary>
    public class ComHolidaysBll : BaseBll<ComHolidaysEntity>
    {
        public ComHolidaysBll()
        {
            BaseDal = new ComHolidaysDal();
        }

        /// <summary>
        /// 保存一个月的节假日设定
        /// 添加人：周 鹏
        /// 添加时间：2014-03-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="list">节假日集</param>
        /// <param name="sTime">设定月份</param>
        /// <returns></returns>
        public bool SaveHostDate(List<ComHolidaysEntity> list, DateTime sTime)
        {
            try
            {
                return new ComHolidaysDal().SaveHostDate(list, sTime);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<ComHolidaysEntity> GetSearchResult(ComHolidaysEntity search)
        {
            try
            {
                return new ComHolidaysDal().GetSearchResult(search);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取工日时间
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="time">时间</param>
        /// <param name="limit">审批时限</param>
        /// <returns></returns>
        public DateTime GetWorkTime(DateTime time, int limit = 3)
        {
            try
            {
                return new ComHolidaysDal().GetWorkTime(time, limit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取法定节假日时间差
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>天数</returns>
        public bool HolidaySpan(DateTime start, DateTime endTime, int limit)
        {
            var holidDayTime = this.GetWorkTime(start, limit);
            return holidDayTime > endTime;
        }
    }
}
