//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_UserDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_User数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// Base_User数据访问操作
    /// </summary>
    public class BaseUserDal
    {
        public BaseUserDal() { }

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
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT [Id],[CompanyId],[DepartmentId], RealName AS 'UserName' FROM CrmUser AS CU WHERE CU.[Enabled]=1 AND CU.Id='{0}'", id);
                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql.ToString()).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)[0]
                           : new BaseUserEntity();
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
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT CU.Id AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,CU.CompanyId,CU.DepartmentId AS 'DeptId',CD.FullName AS DeptName,Mobile FROM CrmUser AS CU
LEFT JOIN CrmDepartment AS CD ON CU.DepartmentId=CD.Id
WHERE CU.[Enabled]=1 AND CU.Id='{0}'", id);
                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql.ToString()).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)[0]
                           : new BaseUserEntity();
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
                var strSql = string.Format(@"SELECT CU.Id AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',
  Secretkey,CU.DepartmentId AS 'DeptId',CD.FullName AS DeptName, Mobile,BC.CertificateNo,
  CU.CompanyId,CCP.FullName CompanyName,CU.ChangePasswordDate
FROM CrmUser AS CU WITH(NOLOCK)
JOIN CrmDepartment AS CD WITH(NOLOCK) ON CU.DepartmentId=CD.Id
join  CrmCompany as CCP WITH(NOLOCK) ON CU.CompanyId=CCP.Id
LEFT JOIN Base_Certificate AS BC WITH(NOLOCK) ON BC.UserId=CU.Id
WHERE CU.RowStatus=1 AND CU.[Enabled]=1 AND (Account='{0}' OR Mobile='{0}')", username);
                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)[0]
                           : new BaseUserEntity();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public IEnumerable<BaseUserEntity> GetAllBaseUsers()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT Id AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,DepartmentId AS 'DeptId',Mobile FROM CrmUser WHERE [Enabled]=1");
                strSql.Append(" ORDER BY SortCode");

                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql.ToString()).Tables[0];
                return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)
                          : new List<BaseUserEntity>();
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
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT Id AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,DepartmentId AS 'DeptId' FROM CrmUser WHERE [Enabled]=1");
                if (!string.IsNullOrEmpty(seach.DeptId))
                {
                    strSql.AppendFormat(@" AND DepartmentId='{0}'", seach.DeptId);
                }

                strSql.Append(" ORDER BY SortCode");

                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
                return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)
                          : new List<BaseUserEntity>();
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
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetUsers(string keyword, string companyId, string deparmentId, int pageSzie, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CU.Id AS UserId,CU.Code,CU.Account,CU.RealName,CU.Gender,CU.Mobile,CU.Telephone,CU.Email,CC.FullName AS CompanyName, CD.FullName AS DepartmentName,CC.SortCode AS CompanySortCode,CD.SortCode AS DepartmentSortCode,CU.SortCode AS UserSortCode
FROM CrmUser AS CU WITH(NOLOCK)
JOIN CrmCompany AS CC WITH(NOLOCK) ON CU.CompanyId=CC.Id
JOIN CrmDepartment AS CD WITH(NOLOCK) ON CD.DepartmentId=CU.DepartmentId WHERE CU.Enabled=1 ");

            if (!string.IsNullOrEmpty(companyId))
            {
                strSql.AppendFormat(" AND CC.CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deparmentId))
            {
                strSql.AppendFormat(" AND CD.DepartmentId='{0}'", deparmentId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.AppendFormat(" AND CU.Account LIKE '%{0}%' OR CU.RealName LIKE '%{0}%'", keyword);
            }


            var execlSql = new StringBuilder("");
            execlSql.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY CompanySortCode,DepartmentSortCode,UserSortCode) AS RowId,* FROM ({0}) AS TB ) AS SP WHERE RowId BETWEEN {1} AND {2}", strSql, (pageIndex - 1) * pageSzie + 1, pageIndex * pageSzie);
            var countSql = new StringBuilder("");
            countSql.AppendFormat("SELECT COUNT(*) FROM ({0}) AS TB ", strSql);

            totalRecords = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, countSql.ToString()));

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, execlSql.ToString()).Tables[0];
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
                var strSql = new StringBuilder("");
                //                strSql.AppendFormat(
                //                    @"SELECT BU.UserId AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,DepartmentId AS 'DeptId' FROM Base_User AS BU
                //JOIN Base_Certificate AS BC ON BU.UserId=BC.UserId
                //WHERE [Enabled]=1");


                strSql.AppendFormat(
                    @"SELECT BU.Id AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,DepartmentId AS 'DeptId' FROM CrmUser AS BU
WHERE [Enabled]=1");

                if (!string.IsNullOrEmpty(seach.DeptId))
                {
                    strSql.AppendFormat(@" AND DepartmentId='{0}'", seach.DeptId);
                }

                strSql.Append(" ORDER BY SortCode");

                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql.ToString()).Tables[0];
                return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)
                          : new List<BaseUserEntity>();
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
            var strSql = string.Format("SELECT LeaveRoleId FROM dbo.Base_Certificate WHERE UserId='{0}'", userId);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0 ? list.Rows[0]["LeaveRoleId"].ToString() : "";
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
        public string GetUserIdByRealName(string realName, string deptId)
        {
            try
            {
                var strSql = string.Format(@"SELECT UserId FROM Base_User WHERE RealName='{0}'", realName);

                if (!string.IsNullOrEmpty(deptId))
                {
                    strSql = strSql + string.Format(" And DepartmentId='{0}'", deptId);
                }

                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? list.Rows[0]["UserId"].ToString()
                           : "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取所以得用户信息
        /// 添加人：胡耀锋
        /// 添加时间：2015-05-06
        /// </summary>
        /// <returns></returns>
        public List<BaseUserEntity> GetAllUser()
        {
            try
            {
                var strSql = string.Format(@"SELECT BU.UserId AS 'Id',Account AS 'LoginName',RealName AS 'UserName',[Password] AS 'PassWord',Secretkey,DepartmentId AS 'DeptId',Mobile,BC.CertificateNo
                                    FROM CrmUser AS BU
                                    LEFT JOIN Base_Certificate  AS BC ON BC.UserId=BU.UserId
                                    WHERE [Enabled]=1 ");
                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)
                           : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取所有用户的ID和名字
        /// 添加人：xj
        /// 添加时间：2018-11-06
        /// </summary>
        /// <returns></returns>
        public List<BaseUserEntity> GetAllUserNew()
        {
            try
            {
                var strSql = string.Format(@"SELECT ID,REALNAME UserName FROM CRMUSER WHERE ROWSTATUS = 1");
                var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
                return list != null && list.Rows.Count > 0
                           ? ConvertListHelper<BaseUserEntity>.ConvertToList(list)
                           : null;
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
                var strSql = string.Format("UPDATE CrmUser SET [Password]='{0}',ChangePasswordDate='{1}' WHERE Id='{2}'", passWord, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), userId);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

