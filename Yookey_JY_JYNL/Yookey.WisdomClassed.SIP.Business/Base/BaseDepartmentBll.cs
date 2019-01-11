//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_DepartmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_Department业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Business.Base
{
    /// <summary>
    /// Base_Department业务逻辑
    /// </summary>
    public class BaseDepartmentBll
    {
        public BaseDepartmentBll() { }

        /// <summary>
        /// 查询所有部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllDepartments(string CompanyId)
        {
            try
            {
                return new BaseDepartmentDal().GetAllDepartments(CompanyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询数据实体
        /// 添加人：周 鹏
        /// 添加时间：2015-02-26
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public BaseDepartmentEntity Get(string id)
        {
            try
            {
                return new BaseDepartmentDal().Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询部分部门
        /// 添加人;叶念
        /// 添加时间：2015-07-15
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<BaseDepartmentEntity> GetAllDetachments(string type = "lochus")
        {
            try
            {
                return new BaseDepartmentDal().GetAllDetachments(type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 所有执法大队
        /// </summary>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllsDetachments()
        {
            try
            {
                return new BaseDepartmentDal().GetAllsDetachments();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        

        /// <summary>
        /// 查询所有执法大队下面的部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-27
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-04-20 周 鹏 细化查询条件
        /// </history>
        /// <param name="type">查询类型：lochus->只查中队,all->大队下所有部门</param>
        /// <returns></returns>
        public List<BaseDepartmentEntity> GetAllDetachment(string type = "lochus")
        {
            try
            {
                return new BaseDepartmentDal().GetAllDetachment(type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
