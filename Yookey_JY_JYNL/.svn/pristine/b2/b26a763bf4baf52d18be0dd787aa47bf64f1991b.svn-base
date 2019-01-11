//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightParticularBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightParticular业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// 排班明细业务 逻辑
    /// </summary>
    public class FlightParticularBll : BaseBll<FlightParticularEntity>
    {
        private readonly FlightParticularDal _flightParticularDal = new FlightParticularDal();
        private readonly FlightOfEmpBll _flightOfEmpBll = new FlightOfEmpBll();

        private readonly ComNumberBll _comNumberBll = new ComNumberBll();

        public FlightParticularBll()
        {
            BaseDal = new FlightParticularDal();
        }

        /// <summary>
        /// 查询排班明细记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表对应ID</param>
        /// <param name="classesId">排班部门对应表的ID</param>
        /// <param name="flightDays">排班日期</param>
        /// <returns>DataTable.</returns>
        public DataTable SelectParticular(string appearId, string classesId, string flightDays)
        {
            try
            {
                return _flightParticularDal.SelectParticular(appearId, classesId, flightDays);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查询出排班排班日期范围内的所有记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表对应ID</param>
        /// <param name="flightDays">排班日期</param>
        /// <returns>DataTable.</returns>
        public DataTable SelectParticular(string appearId, string flightDays)
        {
            try
            {
                return _flightParticularDal.SelectParticular(appearId, flightDays);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据排班主表ID查询所有明细记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="appearId">排班主表ID</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable SelectParticular(string appearId)
        {
            try
            {
                return _flightParticularDal.SelectParticular(appearId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取个人当月之后排班记录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="date">排班日期：yyyy-MM-dd</param>
        /// <param name="userId">用户编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetAppearByUser(string date, string userId)
        {
            try
            {
                var flightDate = Convert.ToDateTime(date);

                DateTime accountBeginDate =Convert.ToDateTime(flightDate.ToString("yyyy-MM") + "-01");
                DateTime accountEndDate=accountBeginDate.AddMonths(1).AddDays(-1);
                
                return _flightParticularDal.GetAppearByUser(accountBeginDate.ToString(AppConst.DateFormat),
                                                            accountEndDate.ToString(AppConst.DateFormat), userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取明细表的
        /// </summary>
        /// <param name="classesId">排班类型编号</param>
        /// <param name="flightDays">排班日期</param>
        /// <returns></returns>
        public DataTable SelectParticularNoappearId(string classesId, string flightDays)
        {
            try
            {
                return _flightParticularDal.SelectParticularNoappearId(classesId, flightDays);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
