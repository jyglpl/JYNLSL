//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:36:05
//  功能描述：用户数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Linq;
using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmUser数据访问操作
    /// </summary>
    public class CrmUserDal : BaseDal<CrmUserEntity>
    {
        public CrmUserDal()
        {
            Model = new CrmUserEntity();
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
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public bool SaveUser(CrmUserEntity user, string userroles, string usermenus, out string userId)
        {
            userId = "";
            var transaction = new TransactionLoader().BeginTransaction("SaveUser");

            try
            {
                var userModel = Get(user.Id);
                if (!string.IsNullOrEmpty(userModel.Id))
                    Update(user, transaction);
                else
                    Add(user, transaction);

                userId = user.Id;
                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"DELETE FROM [CrmUserRole] WHERE [UserId]='{0}';", user.Id);
                if (!(string.IsNullOrEmpty(userroles) || userroles.Trim(',').Length.Equals(0)))
                {
                    sbSql.AppendFormat(
                        @"INSERT INTO [CrmUserRole](UserId,RoleId,RowStatus) 
                              SELECT {0} AS UserId,Id,1 AS RowStatus FROM CrmRole with(nolock)
                              WHERE Id IN ({1});",
                        user.Id, userroles);
                }
                sbSql.AppendFormat(@"DELETE FROM [CrmUserMenu] WHERE UserId='{0}';", user.Id);
                if (!(string.IsNullOrEmpty(usermenus) || usermenus.Trim(',').Length.Equals(0)))
                {
                    sbSql.AppendFormat(
                        @"INSERT INTO [CrmUserMenu]([UserId],[MenuId],[RowStatus])
                              SELECT {0} AS UserId,Id AS MenuId,1 AS RowStatus
                              FROM ComMenu with(nolock) 
                              WHERE Id IN ({1})",
                        user.Id, usermenus);
                }
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
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
            var transaction = new TransactionLoader().BeginTransaction("SaveUser");
            try
            {
                var userModel = Get(user.Id);
                if (userModel != null && !string.IsNullOrEmpty(userModel.Id))
                {
                    Update(user, transaction);
                }
                else
                {
                    Add(user, transaction);
                }

                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"DELETE FROM [CrmUserRole] WHERE [UserId]='{0}';", user.Id);
                if (!(string.IsNullOrEmpty(userroles) || userroles.Trim(',').Length.Equals(0)))
                {
                    sbSql.AppendFormat(
                        @"INSERT INTO [CrmUserRole](UserId,RoleId,RowStatus) 
                              SELECT '{0}' AS UserId,Id,1 AS RowStatus FROM CrmRole with(nolock)
                              WHERE Id IN ({1});",
                        user.Id, userroles);
                }
                if (!(string.IsNullOrEmpty(usermenus) || usermenus.Trim(',').Length.Equals(0)))
                {
                    sbSql.AppendFormat(@"DELETE FROM [CrmUserMenu] WHERE UserId='{0}';", user.Id);
                    sbSql.AppendFormat(
                        @"INSERT INTO [CrmUserMenu]([UserId],[MenuId],[RowStatus])
                              SELECT {0} AS UserId,Id AS MenuId,1 AS RowStatus
                              FROM ComMenu with(nolock) 
                              WHERE Id IN ({1})",
                        user.Id, usermenus);
                }
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 重置密码
        /// 添加人：叶 念
        /// 添加时间：2014-04-02
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ResetPsw(string userid, string password)
        {
            try
            {
                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"update dbo.CrmUser set PassWord='{0}' where Id='{1}';", password, userid);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除用户
        /// 添加人：周 鹏
        /// 添加时间：2013-09-09
        /// </summary>
        /// <param name="userIds">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDeleteUser(string userIds)
        {
            if (string.IsNullOrEmpty(userIds) || userIds.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [CrmUser] SET [RowStatus] =0 WHERE [Id]  IN ({0})", userIds.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }

        public bool UpdatePsw(string id, string newpassword)
        {
            try
            {
                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"UPDATE dbo.CrmUser set PassWord='{0}' where Id='{1}';", newpassword, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
            }
            catch (Exception)
            {
                return false;
            }
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
            if (string.IsNullOrEmpty(username)) return true;
            var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
            queryCondition.AddEqual(CrmUserEntity.Parm_CrmUser_Account, username);
            if (string.IsNullOrEmpty(userid))
            {
                queryCondition.AddNotEqual(CrmUserEntity.Parm_CrmUser_Id, userid);
            }
            return QueryCount(queryCondition) > 0;
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
            var sbSql = new StringBuilder(@"SELECT * FROM CrmUser WHERE RowStatus=1 ");
            if (uList.Count > 0)
            {
                sbSql.AppendFormat("AND Id IN ('{0}')", string.Join("','", uList.ToArray()));
            }
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<CrmUserEntity>();
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
            var transaction = new TransactionLoader().BeginTransaction("SaveUserMenu");
            try
            {
                var sbSql = new StringBuilder();
                sbSql.AppendFormat(@"DELETE FROM [CrmUserMenu] WHERE UserId='{0}';", userid);
                if (!(string.IsNullOrEmpty(usermenus) || usermenus.Trim(',').Length.Equals(0)))
                {
                    sbSql.AppendFormat(
                        @"INSERT INTO [CrmUserMenu]([UserId],[MenuId],[RowStatus])
                              SELECT {0} AS UserId,Id AS MenuId,1 AS RowStatus
                              FROM ComMenu with(nolock) 
                              WHERE Id IN ({1})",
                        userid, usermenus);
                }
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
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
            try
            {
                var sbSqlList = new List<string>();
                foreach (var usermenu in usersmenus)
                {
                    var userid = usermenu.Key;
                    var usermenus = usermenu.Value;

                    sbSqlList.Add(string.Format("DELETE FROM [CrmUserMenu] WHERE UserId='{0}'", userid));

                    if (!(string.IsNullOrEmpty(usermenus) || usermenus.Trim(',').Length.Equals(0)))
                    {
                        sbSqlList.Add(string.Format(
                            @"INSERT INTO [CrmUserMenu]([UserId],[MenuId],[RowStatus])
                              SELECT {0} AS UserId,Id AS MenuId,1 AS RowStatus
                              FROM ComMenu with(nolock) 
                              WHERE Id IN ({1})",
                            userid, usermenus));
                    }
                }
                SqlHelper.ExecuteSqlTran(SqlHelper.SqlConnStringWrite, sbSqlList);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 查询部门人员
        /// 添加人：叶 念
        /// 添加时间：2014-01-03
        /// </summary>
        /// <param name="depid">部门编号</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetDepUser(string depid)
        {
            var sbSql = new StringBuilder("");
            sbSql.AppendFormat(@"SELECT CrmRole.RoleName,* FROM CrmUser 
LEFT JOIN CrmRole ON CrmRole.Id=CrmUser.RoleId WHERE CrmUser.RowStatus=1 AND DepartmentId='{0}' ORDER BY CrmUser.SortValue", depid);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<CrmUserEntity>();
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
            var strSql = string.Format("SELECT Id,UserName FROM CrmUser WHERE DeptId='{0}'", deptId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 查询用户的基本信息
        /// 添加人：叶念
        /// 添加时间：2014-12-23
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string MobileUserInfo(string loginName, string pwd)
        {
            try
            {
                var strSql = string.Format("EXEC Mobile_UserInfo {0},'{1}'", loginName, pwd);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                if (obj != null)
                    return obj.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return "";
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
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(CrmUserEntity.Parm_CrmUser_RowStatus, "1");
                return Query(queryCondition) as List<CrmUserEntity>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查找除了管理员之外的用户
        /// add by lpl
        /// 2018-12-18
        /// </summary>
        /// <returns></returns>
        public List<CrmUserEntity> GetUsers()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT * FROM dbo.CrmUser WHERE RowStatus = 1 AND CompanyId = 'f31af89b-d6d3-4c37-8864-f1a29313173a'");

                var list = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
            try
            {
                if (string.IsNullOrEmpty(qvalue)) return new CrmUserEntity();
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT BU.*,BC.FullName AS CompanyName,
BD.FullName AS DepartmentName,BC.SortCode AS CompanySortCode,BD.SortCode AS DepartmentSortCode,BU.SortCode AS UserSortCode
FROM CrmUser BU
LEFT JOIN CrmCompany BC ON BU.CompanyId=BC.Id 
LEFT JOIN CrmDepartment BD ON BD.Id=BU.DepartmentId WHERE BU.RowStatus=1");

                switch (qtype)
                {
                    case "Account":
                        strSql.AppendFormat(" AND (BU.Account='{0}' OR BU.Mobile='{0}')", qvalue);
                        break;
                    case "Id":
                        strSql.AppendFormat(" AND BU.Id='{0}'", qvalue);
                        break;
                }
                var list = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
                return list.Any() ? list[0] : new CrmUserEntity();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetSearchResult(CrmUserEntity search, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT Id,Code,Enabled,InnerUser,Account,RealName,Gender,
Mobile,Telephone,Email,CompanyId,CompanyName,DepartmentId,DepartmentName, CompanySortCode,DepartmentSortCode, UserSortCode
FROM(
SELECT CU.Id,CU.Code,CU.Enabled,CU.InnerUser,CU.Account,CU.RealName,CU.Gender,
CU.Mobile,CU.Telephone,CU.Email,CU.CompanyId AS CompanyId,CC.FullName AS CompanyName,CU.DepartmentId AS DepartmentId,
CD.FullName AS DepartmentName,CC.SortCode AS CompanySortCode,CD.SortCode AS DepartmentSortCode,CU.SortCode AS UserSortCode
FROM CrmUser CU
LEFT JOIN CrmCompany CC ON CU.CompanyId=CC.Id 
LEFT JOIN CrmDepartment CD ON CD.Id=CU.DepartmentId WHERE CU.RowStatus=1)A WHERE 1=1");

            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                strSql.AppendFormat(" AND CompanyId='{0}'", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DepartmentId))
            {
                strSql.AppendFormat(" AND DepartmentId='{0}'", search.DepartmentId);
            }
            if (!string.IsNullOrEmpty(search.RealName))
            {
                strSql.AppendFormat(" AND Account LIKE '%{0}%' OR RealName LIKE '%{0}%'", search.RealName);
            }
            var data = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CompanySortCode,DepartmentSortCode,UserSortCode", "ASC", search.PageIndex, search.PageSize, out totalRecords);
            return DataTableToList(data);
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CrmUser.* FROM crmuser 
            LEFT JOIN CrmCompany ON CrmUser.CompanyId=CrmCompany.ID
            LEFT JOIN CrmDepartment ON CrmDepartment.ID=CrmUser.DepartmentId WHERE CrmUser.RowStatus=1 ");
            if (!string.IsNullOrEmpty(search.CompanyId))
            {
                strSql.AppendFormat(@" AND crmuser.Companyid='{0}'  ", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DepartmentId))
            {
                strSql.AppendFormat(@" AND crmuser.DepartmentId='{0}'  ", search.DepartmentId);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                strSql.AppendFormat(@" AND crmuser.id='{0}'  ", search.Id);
            }
            if (!string.IsNullOrEmpty(search.IsCityManager))
            {
                strSql.AppendFormat(@" AND crmuser.IsCityManager='{0}'  ", search.IsCityManager);
            }

            strSql.Append("ORDER BY CrmCompany.SortCode,CrmDepartment.SortCode,CrmUser.SortCode");

            return
                DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
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
            var strWhere = new StringBuilder("");
            //构建查询条件
            if (!string.IsNullOrEmpty(companyId))
            {
                strWhere.AppendFormat("AND CompanyId='{0}'", companyId);
            }

            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CU.*,1 AS IsSetRole FROM CrmUser CU
            LEFT JOIN CrmUserRole CUR ON CU.Id=CUR.UserId
            WHERE CU.RowStatus=1 {0} AND CUR.RoleId='{1}'
            UNION
            SELECT CU.*,0 AS IsSetRole FROM CrmUser CU
            WHERE CU.RowStatus=1 {0}
            AND CU.Id NOT IN(SELECT UserId FROM CrmUserRole WHERE RoleId='{1}') ORDER BY IsSetRole DESC,SortCode ", strWhere, roleId);

            return DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 根据部门编号查询当前部门下所有人员
        /// TODO 此处需要结合执法证
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="departmentId">部门编号</param>
        /// <returns></returns>
        public List<CrmUserEntity> GetUsersByDepartment(string departmentId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM CrmUser WHERE DepartmentId='{0}' and Rowstatus = 1 ORDER BY SortCode", departmentId);

            return DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT*
                            FROM CrmUser  CU with(nolock)
                            INNER JOIN  CrmUserRole CUR with(nolock)
                            ON CU.Id=CUR.UserId
                            INNER JOIN CrmRole CR with(nolock)
                            ON CR.Id=Cur.RoleId

                            WHERE CU.CompanyId='{0}' and CU.DepartmentId='{1}' 
                            and CR.FullName like '%{2}%'   ", companyId, departmentId, position);

            return DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0]);
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids">用户Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE CrmUser SET RowStatus =0 WHERE Id IN ('{0}')", string.Join(",'", ids));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()) > 0;
        }

        /// <summary>
        /// 根据用户ID获取设置的角色信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>Columns-> RoleName:角色名称</returns>
        public DataTable GetUserRoleName(string userId)
        {
            var sbSql = new StringBuilder();
            sbSql.AppendFormat(@"SELECT CR.FullName AS RoleName FROM CrmUserRole AS CUR
JOIN CrmRole AS CR ON CUR.RoleId=CR.Id
WHERE UserId='{0}'", userId);


            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).Tables[0];
        }

        public CrmUserEntity GetUserById(string Id)
        {
            var sqlstr = new StringBuilder();
            sqlstr.AppendFormat("select RealName from CrmUser where Id={0}", Id);
            var list = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sqlstr.ToString()).Tables[0]);
            return list.Any() ? list[0] : new CrmUserEntity();
        }

        /// <summary>
        /// 判断许可领导
        /// </summary>        
        /// <returns>人员编号集合</returns>
        public List<string> GetLicenseDirector()
        {
            var strSql = string.Format(@"select AI.UserID from FE_Activity AC LEFT JOIN FE_ActionInstance AI ON AC.ActivityID=AI.ActivityID LEFT JOIN FE_Process PC ON PC.ProcessID=AC.ProcessID
where PC.ProcessID IN ('9d261780-26c1-45f2-802d-6ee671c78b77'
,'cdc59ca3-9316-4bbf-8e6d-ca2bcc542c7e'
,'43c8cc4b-c895-43f2-9c7a-ffa68f2be149'
,'11eda7ac-205b-437d-83a0-6555daeaeaac'
,'607dd36f-43f4-4d92-977b-8641a3491a07'
,'6a8d2596-f793-4fc6-8636-70da571ca2b0') AND AC.NoneName IN('终审','批文领导审核')
group by AI.UserID");
            var date = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (date != null && date.Rows.Count > 0)
            {
                return date.Select().Select(i => i["UserID"].ToString()).ToList();
            }
            else
            {
                return new List<string>();
            }
        }


        /// <summary>
        /// 获取许可的节点的人员
        /// </summary>
        /// 节点名称
        /// <returns>人员编号集合</returns>
        public List<string> GetLicenseActionUsers(string actionName)
        {
            var strSql = string.Format(@"select AI.UserID from FE_Activity AC LEFT JOIN FE_ActionInstance AI ON AC.ActivityID=AI.ActivityID LEFT JOIN FE_Process PC ON PC.ProcessID=AC.ProcessID
where PC.ProcessID IN ('9d261780-26c1-45f2-802d-6ee671c78b77'
,'cdc59ca3-9316-4bbf-8e6d-ca2bcc542c7e'
,'43c8cc4b-c895-43f2-9c7a-ffa68f2be149'
,'11eda7ac-205b-437d-83a0-6555daeaeaac'
,'607dd36f-43f4-4d92-977b-8641a3491a07'
,'6a8d2596-f793-4fc6-8636-70da571ca2b0') AND AC.NoneName IN('{0}')
group by AI.UserID", actionName);
            var date = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (date != null && date.Rows.Count > 0)
            {
                return date.Select().Select(i => i["UserID"].ToString()).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
