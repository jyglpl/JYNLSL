//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightOfEmpBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:47
//  功能描述：FlightOfEmp业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// 排班人员明细业务逻辑
    /// </summary>
    public class FlightOfEmpBll : BaseBll<FlightOfEmpEntity>
    {
        private readonly BaseUserBll _baseUserBll = new BaseUserBll();
        public FlightOfEmpBll()
        {
            BaseDal = new FlightOfEmpDal();
        }

        /// <summary>
        /// 保存人员排班数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-30 周 鹏 增加人员标识类型
        /// </history>
        /// <param name="particularId">排班明细ID</param>
        /// <param name="users">用户集</param>
        /// <param name="userType">人员标识类型：userId,userName</param>
        /// <param name="xxParticularId">删除休息排班人员</param>
        /// <returns><c>true</c>保存成功<c>false</c>保存失败</returns>
        public bool SaveFlightUsers(string particularId, string users, string userType, string deptId = "", string xxParticularId = "")
        {
            try
            {
                //当前部门下面所有人员
                var deptUsers = new CrmUserBll().GetAllUsers(new CrmUserEntity() { DepartmentId = deptId }).ToList();

                var userList = new List<string>();
                if (string.IsNullOrEmpty(userType) || userType.Equals("userId"))     //传入的数据是Id标识的直接分隔,如传入姓名,则需要根据姓名查询出对应的用户ID
                {
                    var userSplit = users.Split(',');
                    userList = userSplit.ToList();
                }
                else
                {
                    var userNames = users.Split(' ');
                    foreach (var userName in userNames)
                    {
                        if (!string.IsNullOrEmpty(userName))
                        {
                            //var userId = _baseUserBll.GetUserIdByRealName(userName, deptId);

                            if (!deptUsers.Any())
                            {
                                break;
                            }

                            var sUser = deptUsers.Where(x => x.RealName == userName).ToList();
                            if (sUser.Any())
                            {
                                if (!string.IsNullOrEmpty(sUser[0].Id))
                                {
                                    userList.Add(sUser[0].Id);
                                }
                            }
                        }
                    }
                }
                return new FlightOfEmpDal().SaveFlightUsers(particularId, xxParticularId, userList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据排班明细表编号查询出排班人员
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="particularId">排班明细表ID</param>
        /// <returns>DataTable.</returns>
        public DataTable GetUsersByParticular(string particularId)
        {
            try
            {
                return new FlightOfEmpDal().GetUsersByParticular(particularId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取整个部门当月的排班人员
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<UserDate> GetFlightOfUsersBydeptIdDate(string deptId, string date)
        {
            var datable = new FlightOfEmpDal().GetFlightOfUsersBydeptIdDate(deptId, date);
            if (datable == null && datable.Rows.Count == 0)
            {
                return new List<UserDate>();
            }
            var result = datable.Select().Select(i => new { UserId = i["UserId"].ToString(), FlightDays = i["FlightDays"].ToString() }).ToList();
            var resultLsit = new List<UserDate>();
            foreach (var item in result)
            {
                var mdoel = new UserDate { UserId = item.UserId, Date = item.FlightDays };
                resultLsit.Add(mdoel);
            }
            return resultLsit;
        }

        /// <summary>
        /// 通过日期和人员查询排班信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="flightDays"></param>
        /// <returns></returns>
        public DataTable GetFlightOfEmpByUserIdAndFlightDays(string userId, string flightDays)
        {
            return new FlightOfEmpDal().GetFlightOfEmpByUserIdAndFlightDays(userId, flightDays);
        }


        //排班人员ID和排班
        public class UserDate
        {
            public string UserId { get; set; }
            public string Date { get; set; }
        }
    }
}
