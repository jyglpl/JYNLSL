//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_UserBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_User业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Business.Base
{
    /// <summary>
    /// Base_User业务逻辑
    /// </summary>
    public class BaseUserBll
    {
        private readonly BaseUserDal _baseUserDal = new BaseUserDal();

        public BaseUserBll()
        {
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// 添加人：周 鹏 
        /// 添加时间：2015-02-09
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public BaseUserEntity GetEntity(string id)
        {
            try
            {
                return _baseUserDal.GetEntity(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据ID获取用户信息
        /// 添加人：周 鹏 
        /// 添加时间：2015-02-09
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public BaseUserEntity Get(string id)
        {
            try
            {
                return _baseUserDal.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据用户名查询用户信息
        /// 添加人：周 鹏 
        /// 添加时间：2015-02-09
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="username">用户登录名</param>
        /// <returns></returns>
        public BaseUserEntity GetUserByUserName(string username)
        {
            try
            {
                return _baseUserDal.GetUserByUserName(username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门下面的人员
        /// 添加人：周 鹏 
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseUserEntity> GetDeptsUsers(BaseUserEntity seach)
        {
            try
            {
                return _baseUserDal.GetDeptsUsers(seach);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 查询部门下的人员
        /// 添加人;叶念
        /// 添加时间：2015-07-14
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseUserEntity> GetAllBaseUsers()
        {
            try
            {
                return _baseUserDal.GetAllBaseUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 分页查询人员数据
        /// 添加人：周 鹏 
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        /// <param name="keyword">查询关键字</param>
        /// <param name="companyId">企业编号</param>
        /// <param name="deparmentId">部门编号</param>
        /// <param name="pageSzie">每页请求条数</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetUsers(string keyword, string companyId, string deparmentId, int pageSzie,
                                                  int pageIndex)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = _baseUserDal.GetUsers(keyword, companyId, deparmentId, pageSzie, pageIndex, out totalRecords);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSzie - 1) / pageSzie; //计算页数
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
        /// 获取部门下面含有执法证件的人员
        /// 添加人：周 鹏 
        /// 添加时间：2015-04-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseUserEntity> GetDeptsUsersDistinctNoCarNo(BaseUserEntity seach)
        {
            try
            {
                return _baseUserDal.GetDeptsUsersDistinctNoCarNo(seach);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取用户角色ID
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户ID</param>
        /// <returns>System.String.</returns>
        public string UserRoleId(string userId)
        {
            try
            {
                return _baseUserDal.UserRoleId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据用户姓名查询用户ID
        /// 添加人：周 鹏 
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="realName">用户真实姓名</param>
        /// <returns></returns>
        public string GetUserIdByRealName(string realName, string deptId = "")
        {
            try
            {
                return _baseUserDal.GetUserIdByRealName(realName, deptId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取所有的用户信息
        /// 添加人：胡耀锋
        /// 添加时间：2015-05-06
        /// </summary>
        /// <returns></returns>
        public List<BaseUserEntity> GetAllUser()
        {
            try
            {
                return _baseUserDal.GetAllUser();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取所有用户ID和名字
        /// 添加人：xj
        /// 添加时间：2018-11-06
        /// </summary>
        /// <returns></returns>
        public List<BaseUserEntity> GetAllUserNew()
        {
            try
            {
                return _baseUserDal.GetAllUserNew();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 修改密码
        /// 添加人：周 鹏
        /// 添加时间：2015-06-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户ID</param>
        /// <param name="passWord">修改的密码</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool UpdatePassWord(string userId, string passWord)
        {
            try
            {
                return _baseUserDal.UpdatePassWord(userId, passWord);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
