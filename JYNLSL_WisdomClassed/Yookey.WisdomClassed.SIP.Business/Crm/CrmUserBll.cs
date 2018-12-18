//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：CrmUser业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.Hr;
namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmUser业务逻辑
    /// </summary>
    public class CrmUserBll : BaseBll<CrmUserEntity>
    {
        public CrmUserBll()
        {
            BaseDal = new CrmUserDal();
        }

        /// <summary>
        /// 用户查询
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public PageJqDatagrid<CrmUserEntity> GetSearchResult(CrmUserEntity search, int pageSize = 10, int pageIndex = 1)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Account))
            {
                OrCondition orCondition = OrCondition.Instance.AddLike(CrmUserEntity.Parm_CrmUser_Account,
                                                                       search.Account);
                orCondition.AddLike(CrmUserEntity.Parm_CrmUser_RealName, search.Account);
                queryCondition.AddOr(orCondition);
            }
            if (!string.IsNullOrEmpty(search.DepartmentId))
            {
                queryCondition.AddEqual(CrmUserEntity.Parm_CrmUser_DepartmentId, search.DepartmentId);
            }
            //排序
            queryCondition.AddOrderBy(CrmUserEntity.Parm_CrmUser_SortCode, true);
            queryCondition.SetPager(pageIndex, pageSize);
            int totalRecord, totalPage;
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = Query(queryCondition, out totalRecord, out totalPage);
            stopwatch.Stop();
            return new PageJqDatagrid<CrmUserEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecord,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 根据用户名查询用户
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="username">用户登录名或真实姓名</param>
        /// <returns></returns>
        public CrmUserEntity GetUserByUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new CrmUserEntity();
            }
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
            var orCondition = OrCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_Account, username).AddEqual(CrmUserEntity.Parm_CrmUser_Account, username);
            queryCondition.AddOr(orCondition);
            var userList = Query(queryCondition);
            return (userList != null && userList.Count > 0) ? userList[0] : new CrmUserEntity();
        }

        /// <summary>
        /// 新增或更新用户
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="user">用户实体</param>
        /// <param name="userroles">用户角色(以,分隔，例如 1,2,3)</param>
        /// <param name="usermenus">用户菜单(以,分隔，例如 1,2,3)</param>
        /// <returns></returns>
        public bool SaveUser(CrmUserEntity user, string userroles, string usermenus)
        {
            return new CrmUserDal().SaveUser(user, userroles, usermenus);
        }

        /// <summary>
        /// 重置密码
        /// 添加人：叶 念
        /// 添加时间：2014-04-02
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ResetPsw(string userid, string password)
        {
            return new CrmUserDal().ResetPsw(userid, password);
        }
        /// <summary>
        /// 新增或更新用户
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="user">用户实体</param>
        /// <param name="userroles">用户角色(以,分隔，例如 1,2,3)</param>
        /// <param name="usermenus">用户菜单(以,分隔，例如 1,2,3)</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public bool SaveUser(CrmUserEntity user, string userroles, string usermenus, out string userId)
        {
            return new CrmUserDal().SaveUser(user, userroles, usermenus, out userId);
        }

        /// <summary>
        /// 批量删除用户
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <param name="userIds">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDeleteUser(string userIds)
        {
            return new CrmUserDal().BatchDeleteUser(userIds);
        }

        /// <summary>
        /// 判断用户登录名是否重复
        /// 添加人：周 鹏 
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="username">用户登录名</param>
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        public bool NameIsExists(string username, string userid)
        {
            return new CrmUserDal().NameIsExists(username, userid);
        }

        /// <summary>
        /// 获取用户列表
        /// 添加人：周 鹏
        /// 添加时间：2014-04-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="uList">用户集合</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUser(List<string> uList)
        {
            return new CrmUserDal().GetUser(uList);
        }

        /// <summary>
        /// 更新用户菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userid">用户编号</param>
        /// <param name="usermenus">用户菜单(以,分隔，例如 1,2,3)</param>
        /// <returns></returns>
        public bool SaveUserMenu(string userid, string usermenus)
        {
            return new CrmUserDal().SaveUserMenu(userid, usermenus);
        }

        /// <summary>
        /// 更新用户菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="usersmenus">用户编号,菜单集(以,分隔，例如 1,2,3)</param>
        /// <returns></returns>
        public bool SaveUsersMenu(Dictionary<string, string> usersmenus)
        {
            return new CrmUserDal().SaveUsersMenu(usersmenus);
        }

        /// <summary>
        /// 获取所有人员
        /// 添加人：周 鹏 
        /// 添加时间：2014-03-031
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// 修改人：张晖
        /// 修改时间：2014-04-09
        /// </history>
        /// <returns></returns>
        public List<CrmUserEntity> GetAllUsers(CrmUserEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.RealName))
            {
                queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_RealName, search.RealName);
            }
            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                queryCondition.AddEqual(CrmUserEntity.Parm_CrmUser_CompanyId, search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DepartmentId))
            {
                queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_DepartmentId, search.DepartmentId);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_Id, search.Id);
            }
            return Query(queryCondition) as List<CrmUserEntity>;
        }





        /// <summary>
        /// 获取所有人员
        /// 添加人：周 鹏 
        /// 添加时间：2014-12-20
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public IEnumerable<CrmUserEntity> GetDeptsUsers(CrmUserEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.RealName))
            {
                queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_RealName, search.RealName);
            }
            if (!string.IsNullOrEmpty(search.DepartmentId))
            {

                var departmentEntity = new CrmDepartmentBll().Get(search.DepartmentId);
                if (departmentEntity != null && !string.IsNullOrEmpty(search.DepartmentId))
                {
                    //获取到部门所属单位信息
                    var companyId = departmentEntity.CompanyId;

                    //度假区大队、高新区大队、开发区综合执法局 查询单位下面所有人员

                    if (companyId.Equals("67bd0612-ff57-4c3a-b777-31133c4427ee") ||
                        companyId.Equals("66a209db-6654-42e2-8df1-6b62ba1b0fcd") ||
                        companyId.Equals("4eb3b31a-c2ed-406a-bf9a-ec60025e48cd"))
                    {
                        queryCondition.AddEqual(CrmUserEntity.Parm_CrmUser_CompanyId, companyId);
                    }
                    else if (companyId.Equals("ee8caa80-7124-4978-b06f-918ea7f44a66"))
                    {
                        //queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_DepartmentId, search.DepartmentId);
                    }
                    else
                    {
                        queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_DepartmentId, search.DepartmentId);
                    }
                }

                //if (search.DepartmentId == "dec48af7-7cb7-4c14-93a1-02e584c9ae38")
                //{
                //    queryCondition.AddIn(CrmUserEntity.Parm_CrmUser_DepartmentId, "'dec48af7-7cb7-4c14-93a1-02e584c9ae38','c3ad845f-1959-4639-8bd3-d58f711d9d15','50c46c83-9b79-4e90-a615-f45afe6ce238','7a2e4bc5-b126-4721-97bf-0b83c683c18b','518b99ad-dfd1-4bfe-a710-8b5609c46927'");
                //}
                //else if (search.DepartmentId == "c3ad845f-1959-4639-8bd3-d58f711d9d15")
                //{
                //    queryCondition.AddIn(CrmUserEntity.Parm_CrmUser_DepartmentId, "'dec48af7-7cb7-4c14-93a1-02e584c9ae38','c3ad845f-1959-4639-8bd3-d58f711d9d15','50c46c83-9b79-4e90-a615-f45afe6ce238','7a2e4bc5-b126-4721-97bf-0b83c683c18b','518b99ad-dfd1-4bfe-a710-8b5609c46927'");
                //}
                //else if (search.DepartmentId == "50c46c83-9b79-4e90-a615-f45afe6ce238")
                //{
                //    queryCondition.AddIn(CrmUserEntity.Parm_CrmUser_DepartmentId, "'dec48af7-7cb7-4c14-93a1-02e584c9ae38','c3ad845f-1959-4639-8bd3-d58f711d9d15','50c46c83-9b79-4e90-a615-f45afe6ce238','7a2e4bc5-b126-4721-97bf-0b83c683c18b','518b99ad-dfd1-4bfe-a710-8b5609c46927'");
                //}
                //else if (search.DepartmentId == "7a2e4bc5-b126-4721-97bf-0b83c683c18b")
                //{
                //    queryCondition.AddIn(CrmUserEntity.Parm_CrmUser_DepartmentId, "'dec48af7-7cb7-4c14-93a1-02e584c9ae38','c3ad845f-1959-4639-8bd3-d58f711d9d15','50c46c83-9b79-4e90-a615-f45afe6ce238','7a2e4bc5-b126-4721-97bf-0b83c683c18b','518b99ad-dfd1-4bfe-a710-8b5609c46927'");
                //}
                //else if (search.DepartmentId == "518b99ad-dfd1-4bfe-a710-8b5609c46927")
                //{
                //    queryCondition.AddIn(CrmUserEntity.Parm_CrmUser_DepartmentId, "'dec48af7-7cb7-4c14-93a1-02e584c9ae38','c3ad845f-1959-4639-8bd3-d58f711d9d15','50c46c83-9b79-4e90-a615-f45afe6ce238','7a2e4bc5-b126-4721-97bf-0b83c683c18b','518b99ad-dfd1-4bfe-a710-8b5609c46927'");
                //}
                //else
                //{
                //    queryCondition.AddLike(CrmUserEntity.Parm_CrmUser_DepartmentId, search.DepartmentId);
                //}
            }
            else
            {
                return new List<CrmUserEntity>();
            }
            queryCondition.AddOrderBy(CrmUserEntity.Parm_CrmUser_DepartmentId, false);
            queryCondition.AddOrderBy(CrmUserEntity.Parm_CrmUser_SortCode, true);
            return Query(queryCondition) as List<CrmUserEntity>;
        }

        /// <summary>
        /// 查询部门人员
        /// </summary>
        /// <param name="roleId">部门编号</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetDepUser(string roleId)
        {
            return new CrmUserDal().GetDepUser(roleId);
        }

        /// <summary>
        /// 查询部门下面的所有人员
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <returns>Columns->Id:用户编号,UserName:用户名称</returns>
        public DataTable GetDeptUsers(string deptId)
        {
            return new CrmUserDal().GetDeptUsers(deptId);
        }

        public string MobileUserInfo(string loginName, string pwd)
        {

            return new CrmUserDal().MobileUserInfo(loginName, pwd);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newpassWord"></param>
        /// <returns></returns>
        public bool UpdatePsw(string id, string newpassWord)
        {
            return new CrmUserDal().UpdatePsw(id, newpassWord);
        }



        /// <summary>
        /// 获取所有人员
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmUserEntity> GetAllUsers()
        {
            return new CrmUserDal().GetAllUsers();
        }

        /// <summary>
        /// 查找除了管理员之外的用户
        /// add by lpl
        /// 2018-12-18
        /// </summary>
        /// <returns></returns>
        public List<CrmUserEntity> GetUser()
        {
            return new CrmUserDal().GetUsers();
        }


        /// <summary>
        /// 根据用户名、编号查询用户信息
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="qvalue">请求值</param>
        /// <param name="qtype">请求方式：Account账号 Id用户主键编号</param>
        /// <returns></returns>
        public CrmUserEntity GetUserEntity(string qvalue, string qtype = "Id")
        {
            return new CrmUserDal().GetUserEntity(qvalue, qtype);
        }

        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<CrmUserEntity> GetSearchResult(CrmUserEntity search)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new CrmUserDal().GetSearchResult(search, out totalRecords);
            stopwatch.Stop();
            int totalPage = (totalRecords + search.PageSize - 1) / search.PageSize;   //计算页数
            return new PageJqDatagrid<CrmUserEntity>
            {
                page = search.PageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUserList(CrmUserEntity search)
        {
            return new CrmUserDal().GetUserList(search);
        }

        /// <summary>
        /// 根据角色编号查询已设置和未设置的人员
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUsersByRole(string companyId, string roleId)
        {
            return new CrmUserDal().GetUsersByRole(companyId, roleId);
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new CrmUserDal().BatchDelete(ids);
        }

        /// <summary>
        /// 根据部门编号查询当前部门下所有人员
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="departmentId">部门编号</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUsersByDepartment(string departmentId)
        {
            return new CrmUserDal().GetUsersByDepartment(departmentId);
        }

        /// <summary>
        /// 根据用户ID获取设置的角色信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>Columns-> RoleName:角色名称</returns>
        public DataTable GetUserRoleName(string userId)
        {
            return new CrmUserDal().GetUserRoleName(userId);
        }


        /// <summary>
        /// 获取中队下所有中队长和副中队长
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <param name="position">职务名称（中队长、副大队长）</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUserListBySquadronLeader(string companyId, string departmentId, string position)
        {
            return new CrmUserDal().GetUserListBySquadronLeader(companyId, departmentId, position);
        }
    }
}
