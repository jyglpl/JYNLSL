//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_RolesEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_Roles表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    /// <summary>
    /// 角色管理表
    /// </summary>
    [Serializable]
    public class BaseRolesEntity
    {
        #region Const of table Base_Roles
        /// <summary>
        /// Table Base_Roles
        /// </summary>
        public const string TB_Base_Roles = "Base_Roles";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Category
        /// </summary>
        public const string Parm_Base_Roles_Category = "Category";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_Base_Roles_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_Base_Roles_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateDate
        /// </summary>
        public const string Parm_Base_Roles_CreateDate = "CreateDate";
        /// <summary>
        /// Parm CreateUserId
        /// </summary>
        public const string Parm_Base_Roles_CreateUserId = "CreateUserId";
        /// <summary>
        /// Parm CreateUserName
        /// </summary>
        public const string Parm_Base_Roles_CreateUserName = "CreateUserName";
        /// <summary>
        /// Parm DeleteMark
        /// </summary>
        public const string Parm_Base_Roles_DeleteMark = "DeleteMark";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_Base_Roles_Enabled = "Enabled";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_Base_Roles_FullName = "FullName";
        /// <summary>
        /// Parm ModifyDate
        /// </summary>
        public const string Parm_Base_Roles_ModifyDate = "ModifyDate";
        /// <summary>
        /// Parm ModifyUserId
        /// </summary>
        public const string Parm_Base_Roles_ModifyUserId = "ModifyUserId";
        /// <summary>
        /// Parm ModifyUserName
        /// </summary>
        public const string Parm_Base_Roles_ModifyUserName = "ModifyUserName";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_Base_Roles_Remark = "Remark";
        /// <summary>
        /// Parm RoleId
        /// </summary>
        public const string Parm_Base_Roles_RoleId = "RoleId";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_Base_Roles_SortCode = "SortCode";
        /// <summary>
        /// Insert Query Of Base_Roles
        /// </summary>
        public const string Sql_Base_Roles_Insert = "insert into Base_Roles(Category,Code,CompanyId,CreateDate,CreateUserId,CreateUserName,DeleteMark,Enabled,FullName,ModifyDate,ModifyUserId,ModifyUserName,Remark,SortCode) values(@Category,@Code,@CompanyId,@CreateDate,@CreateUserId,@CreateUserName,@DeleteMark,@Enabled,@FullName,@ModifyDate,@ModifyUserId,@ModifyUserName,@Remark,@SortCode);select @@identity;";
        /// <summary>
        /// Update Query Of Base_Roles
        /// </summary>
        public const string Sql_Base_Roles_Update = "update Base_Roles set Category=@Category,Code=@Code,CompanyId=@CompanyId,CreateDate=@CreateDate,CreateUserId=@CreateUserId,CreateUserName=@CreateUserName,DeleteMark=@DeleteMark,Enabled=@Enabled,FullName=@FullName,ModifyDate=@ModifyDate,ModifyUserId=@ModifyUserId,ModifyUserName=@ModifyUserName,Remark=@Remark,SortCode=@SortCode where RoleId=@RoleId;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Base_Roles_Delete = "update Base_Roles set RowStatus=0 where RoleId=@RoleId;select @@rowcount;";
        #endregion

        #region Properties
        private string _roleId = string.Empty;
        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId
        {
            get { return _roleId ?? string.Empty; }
            set { _roleId = value; }
        }
        private string _companyId = string.Empty;
        /// <summary>
        /// 公司主键
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _category = string.Empty;
        /// <summary>
        /// 角色分类
        /// </summary>
        public string Category
        {
            get { return _category ?? string.Empty; }
            set { _category = value; }
        }
        private string _code = string.Empty;
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code
        {
            get { return _code ?? string.Empty; }
            set { _code = value; }
        }
        private string _fullName = string.Empty;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string FullName
        {
            get { return _fullName ?? string.Empty; }
            set { _fullName = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private int _enabled;
        /// <summary>
        /// 
        /// </summary>
        public int Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        private int _sortCode;
        /// <summary>
        /// 
        /// </summary>
        public int SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; }
        }
        private int _deleteMark;
        /// <summary>
        /// 
        /// </summary>
        public int DeleteMark
        {
            get { return _deleteMark; }
            set { _deleteMark = value; }
        }
        private int _createDate;
        /// <summary>
        /// 
        /// </summary>
        public int CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private string _createUserId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CreateUserId
        {
            get { return _createUserId ?? string.Empty; }
            set { _createUserId = value; }
        }
        private string _createUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CreateUserName
        {
            get { return _createUserName ?? string.Empty; }
            set { _createUserName = value; }
        }
        private int _modifyDate;
        /// <summary>
        /// 
        /// </summary>
        public int ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }
        private string _modifyUserId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ModifyUserId
        {
            get { return _modifyUserId ?? string.Empty; }
            set { _modifyUserId = value; }
        }
        private string _modifyUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ModifyUserName
        {
            get { return _modifyUserName ?? string.Empty; }
            set { _modifyUserName = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public BaseRolesEntity SetModelValueByDataRow(DataRow dr)
        {
            IList<string> fields = new List<string> { "*" };
            return SetModelValueByDataRow(dr, fields);
        }

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public BaseRolesEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new BaseRolesEntity();
            if (fields.Contains(Parm_Base_Roles_RoleId) || fields.Contains("*"))
                tmp.RoleId = dr[Parm_Base_Roles_RoleId].ToString();
            if (fields.Contains(Parm_Base_Roles_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_Base_Roles_CompanyId].ToString();
            if (fields.Contains(Parm_Base_Roles_Category) || fields.Contains("*"))
                tmp.Category = dr[Parm_Base_Roles_Category].ToString();
            if (fields.Contains(Parm_Base_Roles_Code) || fields.Contains("*"))
                tmp.Code = dr[Parm_Base_Roles_Code].ToString();
            if (fields.Contains(Parm_Base_Roles_FullName) || fields.Contains("*"))
                tmp.FullName = dr[Parm_Base_Roles_FullName].ToString();
            if (fields.Contains(Parm_Base_Roles_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_Base_Roles_Remark].ToString();
            if (fields.Contains(Parm_Base_Roles_Enabled) || fields.Contains("*"))
                tmp.Enabled = int.Parse(dr[Parm_Base_Roles_Enabled].ToString());
            if (fields.Contains(Parm_Base_Roles_SortCode) || fields.Contains("*"))
                tmp.SortCode = int.Parse(dr[Parm_Base_Roles_SortCode].ToString());
            if (fields.Contains(Parm_Base_Roles_DeleteMark) || fields.Contains("*"))
                tmp.DeleteMark = int.Parse(dr[Parm_Base_Roles_DeleteMark].ToString());
            if (fields.Contains(Parm_Base_Roles_CreateDate) || fields.Contains("*"))
                tmp.CreateDate = int.Parse(dr[Parm_Base_Roles_CreateDate].ToString());
            if (fields.Contains(Parm_Base_Roles_CreateUserId) || fields.Contains("*"))
                tmp.CreateUserId = dr[Parm_Base_Roles_CreateUserId].ToString();
            if (fields.Contains(Parm_Base_Roles_CreateUserName) || fields.Contains("*"))
                tmp.CreateUserName = dr[Parm_Base_Roles_CreateUserName].ToString();
            if (fields.Contains(Parm_Base_Roles_ModifyDate) || fields.Contains("*"))
                tmp.ModifyDate = int.Parse(dr[Parm_Base_Roles_ModifyDate].ToString());
            if (fields.Contains(Parm_Base_Roles_ModifyUserId) || fields.Contains("*"))
                tmp.ModifyUserId = dr[Parm_Base_Roles_ModifyUserId].ToString();
            if (fields.Contains(Parm_Base_Roles_ModifyUserName) || fields.Contains("*"))
                tmp.ModifyUserName = dr[Parm_Base_Roles_ModifyUserName].ToString();

            return tmp;
        }
    }
}

