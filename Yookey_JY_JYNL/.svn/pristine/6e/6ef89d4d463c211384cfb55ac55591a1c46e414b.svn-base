//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightClassesOfDeptmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：
//  创建日期：
//  功能描述：FlightClassesOfDeptment业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// 班次与部门对应关系业务逻辑
    /// </summary>
    public class FlightClassesOfDeptmentBll : BaseBll<FlightClassesOfDeptmentEntity>
    {
        private readonly FlightClassesOfDeptmentDal _baseUserDal = new FlightClassesOfDeptmentDal();

        public FlightClassesOfDeptmentBll()
        {
            BaseDal = new FlightClassesOfDeptmentDal();
        }

        /// <summary>
        /// 通过部门Id查询部门班别设定信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<FlightClassesOfDeptmentEntity> GetFlightClassesOfDeptmentListByDeptId(string deptId)
        {
            return _baseUserDal.GetFlightClassesOfDeptmentListByDeptId(deptId);
        }

        /// <summary>
        /// 批量保存数据
        /// </summary>
        /// <param name="particularId"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public bool TransactionSave(List<FlightClassesOfDeptmentEntity> modelList)
        {
            return _baseUserDal.TransactionSave(modelList);
        }

        /// <summary>
        /// 设置部门默认排班
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public bool SetDefault(string deptId)
        {
            if (string.IsNullOrEmpty(deptId)||GetFlightClassesOfDeptmentListByDeptId(deptId).Find(i => i.ClassesId == "休息") != null)
                return false;
            return _baseUserDal.SetDefault(deptId);
        }

    }
}
