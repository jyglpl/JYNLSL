//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_GroupUserEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:43
//  功能描述：Base_GroupUser表实体
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
    /// 群组管理表
    /// </summary>
    [Serializable]
    public class BaseGroupUserEntity
    {

        #region Const of table Base_GroupUser
        /// <summary>
        /// Table Base_GroupUser
        /// </summary>
        public const string TB_Base_GroupUser = "Base_GroupUser";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Category
        /// </summary>
        public const string Parm_Base_GroupUser_Category = "Category";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_Base_GroupUser_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_Base_GroupUser_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateDate
        /// </summary>
        public const string Parm_Base_GroupUser_CreateDate = "CreateDate";
        /// <summary>
        /// Parm CreateUserId
        /// </summary>
        public const string Parm_Base_GroupUser_CreateUserId = "CreateUserId";
        /// <summary>
        /// Parm CreateUserName
        /// </summary>
        public const string Parm_Base_GroupUser_CreateUserName = "CreateUserName";
        /// <summary>
        /// Parm DeleteMark
        /// </summary>
        public const string Parm_Base_GroupUser_DeleteMark = "DeleteMark";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_Base_GroupUser_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_Base_GroupUser_Enabled = "Enabled";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_Base_GroupUser_FullName = "FullName";
        /// <summary>
        /// Parm GroupUserId
        /// </summary>
        public const string Parm_Base_GroupUser_GroupUserId = "GroupUserId";
        /// <summary>
        /// Parm ModifyDate
        /// </summary>
        public const string Parm_Base_GroupUser_ModifyDate = "ModifyDate";
        /// <summary>
        /// Parm ModifyUserId
        /// </summary>
        public const string Parm_Base_GroupUser_ModifyUserId = "ModifyUserId";
        /// <summary>
        /// Parm ModifyUserName
        /// </summary>
        public const string Parm_Base_GroupUser_ModifyUserName = "ModifyUserName";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_Base_GroupUser_Remark = "Remark";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_Base_GroupUser_SortCode = "SortCode";
        /// <summary>
        /// Insert Query Of Base_GroupUser
        /// </summary>
        public const string Sql_Base_GroupUser_Insert = "insert into Base_GroupUser(Category,Code,CompanyId,CreateDate,CreateUserId,CreateUserName,DeleteMark,DepartmentId,Enabled,FullName,ModifyDate,ModifyUserId,ModifyUserName,Remark,SortCode) values(@Category,@Code,@CompanyId,@CreateDate,@CreateUserId,@CreateUserName,@DeleteMark,@DepartmentId,@Enabled,@FullName,@ModifyDate,@ModifyUserId,@ModifyUserName,@Remark,@SortCode);select @@identity;";
        /// <summary>
        /// Update Query Of Base_GroupUser
        /// </summary>
        public const string Sql_Base_GroupUser_Update = "update Base_GroupUser set Category=@Category,Code=@Code,CompanyId=@CompanyId,CreateDate=@CreateDate,CreateUserId=@CreateUserId,CreateUserName=@CreateUserName,DeleteMark=@DeleteMark,DepartmentId=@DepartmentId,Enabled=@Enabled,FullName=@FullName,ModifyDate=@ModifyDate,ModifyUserId=@ModifyUserId,ModifyUserName=@ModifyUserName,Remark=@Remark,SortCode=@SortCode where GroupUserId=@GroupUserId;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Base_GroupUser_Delete = "update Base_GroupUser set RowStatus=0 where GroupUserId=@GroupUserId;select @@rowcount;";
        #endregion

        #region Properties
        private string _groupUserId = string.Empty;
        /// <summary>
        /// 群组主键
        /// </summary>
        public string GroupUserId
        {
            get { return _groupUserId ?? string.Empty; }
            set { _groupUserId = value; }
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
        private string _departmentId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _category = string.Empty;
        /// <summary>
        /// 群组分类
        /// </summary>
        public string Category
        {
            get { return _category ?? string.Empty; }
            set { _category = value; }
        }
        private string _code = string.Empty;
        /// <summary>
        /// 群组编码
        /// </summary>
        public string Code
        {
            get { return _code ?? string.Empty; }
            set { _code = value; }
        }
        private string _fullName = string.Empty;
        /// <summary>
        /// 群组名称
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
        private DateTime _createDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
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
        private DateTime _modifyDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifyDate
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
        public BaseGroupUserEntity SetModelValueByDataRow(DataRow dr)
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
        public BaseGroupUserEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new BaseGroupUserEntity();
            if (fields.Contains(Parm_Base_GroupUser_GroupUserId) || fields.Contains("*"))
                tmp.GroupUserId = dr[Parm_Base_GroupUser_GroupUserId].ToString();
            if (fields.Contains(Parm_Base_GroupUser_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_Base_GroupUser_CompanyId].ToString();
            if (fields.Contains(Parm_Base_GroupUser_DepartmentId) || fields.Contains("*"))
                tmp.DepartmentId = dr[Parm_Base_GroupUser_DepartmentId].ToString();
            if (fields.Contains(Parm_Base_GroupUser_Category) || fields.Contains("*"))
                tmp.Category = dr[Parm_Base_GroupUser_Category].ToString();
            if (fields.Contains(Parm_Base_GroupUser_Code) || fields.Contains("*"))
                tmp.Code = dr[Parm_Base_GroupUser_Code].ToString();
            if (fields.Contains(Parm_Base_GroupUser_FullName) || fields.Contains("*"))
                tmp.FullName = dr[Parm_Base_GroupUser_FullName].ToString();
            if (fields.Contains(Parm_Base_GroupUser_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_Base_GroupUser_Remark].ToString();
            if (fields.Contains(Parm_Base_GroupUser_Enabled) || fields.Contains("*"))
                tmp.Enabled = int.Parse(dr[Parm_Base_GroupUser_Enabled].ToString());
            if (fields.Contains(Parm_Base_GroupUser_SortCode) || fields.Contains("*"))
                tmp.SortCode = int.Parse(dr[Parm_Base_GroupUser_SortCode].ToString());
            if (fields.Contains(Parm_Base_GroupUser_DeleteMark) || fields.Contains("*"))
                tmp.DeleteMark = int.Parse(dr[Parm_Base_GroupUser_DeleteMark].ToString());
            if (fields.Contains(Parm_Base_GroupUser_CreateDate) || fields.Contains("*"))
                tmp.CreateDate = DateTime.Parse(dr[Parm_Base_GroupUser_CreateDate].ToString());
            if (fields.Contains(Parm_Base_GroupUser_CreateUserId) || fields.Contains("*"))
                tmp.CreateUserId = dr[Parm_Base_GroupUser_CreateUserId].ToString();
            if (fields.Contains(Parm_Base_GroupUser_CreateUserName) || fields.Contains("*"))
                tmp.CreateUserName = dr[Parm_Base_GroupUser_CreateUserName].ToString();
            if (fields.Contains(Parm_Base_GroupUser_ModifyDate) || fields.Contains("*"))
                tmp.ModifyDate = DateTime.Parse(dr[Parm_Base_GroupUser_ModifyDate].ToString());
            if (fields.Contains(Parm_Base_GroupUser_ModifyUserId) || fields.Contains("*"))
                tmp.ModifyUserId = dr[Parm_Base_GroupUser_ModifyUserId].ToString();
            if (fields.Contains(Parm_Base_GroupUser_ModifyUserName) || fields.Contains("*"))
                tmp.ModifyUserName = dr[Parm_Base_GroupUser_ModifyUserName].ToString();

            return tmp;
        }
    }
}

