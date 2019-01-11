//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightMonitorBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightMonitor业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// 排班值班业务逻辑
    /// </summary>
    public class FlightMonitorBll : BaseBll<FlightMonitorEntity>
    {
        public FlightMonitorBll()
        {
            BaseDal = new FlightMonitorDal();
        }

        /// <summary>
        /// 根据值班时间获取数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="day">值班日期</param>
        /// <returns>FlightMonitorEntity.</returns>
        public FlightMonitorEntity GetEntityByDay(string day)
        {
            return new FlightMonitorDal().GetEntityByDay(day);
        }

        /// <summary>
        /// 查询出一个月内所有值班信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="day">日期</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDataSource(string day)
        {
            return new FlightMonitorDal().GetDataSource(day);
        }

        /// <summary>
        /// 保存值班
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="flightDate">值班日期</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="userId">值班人员ID</param>
        /// <param name="userName">值班人员姓名</param>
        /// <param name="ctype">值班类型</param>
        /// <param name="createId">创建人ID</param>
        /// <param name="createName">创建人姓名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SaveMonitor(string flightDate, string deptId, string userId, string userName, string ctype, string createId, string createName)
        {
            try
            {
                var entity = GetEntityByDay(flightDate);
                //不存在新增,存在修改
                if (entity == null)
                {
                    entity = new FlightMonitorEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ChiefWatch = ctype.Equals("watch") ? userId : "",
                        ChiefWatchName = ctype.Equals("watch") ? userName : "",
                        ChiefMonitor = ctype.Equals("monitor") ? userId : "",
                        ChiefMonitorName = ctype.Equals("monitor") ? userName : "",
                        DeputyMonitor = ctype.Equals("depudy") ? userId : "",
                        DeputyMonitorName = ctype.Equals("depudy") ? userName : "",
                        OndutyDate = Convert.ToDateTime(flightDate),
                        DeptIdI = ctype.Equals("watch") ? deptId : "",
                        DeptIdII = ctype.Equals("monitor") ? deptId : "",
                        DeptIdIII = ctype.Equals("depudy") ? deptId : "",

                        RowStatus = 1,
                        CreatorId = createId,
                        CreateBy = createName,
                        CreateOn = DateTime.Now
                    };
                    Add(entity);
                }
                else
                {
                    if (ctype.Equals("watch"))
                    {
                        entity.ChiefWatch = userId;
                        entity.ChiefWatchName = userName;
                        entity.DeptIdI = deptId;
                    }
                    else if (ctype.Equals("monitor"))
                    {
                        entity.ChiefMonitor = userId;
                        entity.ChiefMonitorName = userName;
                        entity.DeptIdII = deptId;
                    }
                    else
                    {
                        entity.DeputyMonitor = userId;
                        entity.DeputyMonitorName = userName;
                        entity.DeptIdIII = deptId;
                    }
                    Update(entity);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
