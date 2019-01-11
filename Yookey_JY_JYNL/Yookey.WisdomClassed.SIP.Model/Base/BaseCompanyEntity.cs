//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CompanyEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:44
//  功能描述：Base_Company表实体
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
    /// 公司管理表
    /// </summary>
    [Serializable]
    public class BaseCompanyEntity
    {
        #region Properties
        private string _companyId = string.Empty;
        /// <summary>
        /// 公司主键
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _parentId = string.Empty;
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId
        {
            get { return _parentId ?? string.Empty; }
            set { _parentId = value; }
        }
        private string _category = string.Empty;
        /// <summary>
        /// 公司分类
        /// </summary>
        public string Category
        {
            get { return _category ?? string.Empty; }
            set { _category = value; }
        }
        private string _code = string.Empty;
        /// <summary>
        /// 公司编码
        /// </summary>
        public string Code
        {
            get { return _code ?? string.Empty; }
            set { _code = value; }
        }
        private string _fullName = string.Empty;
        /// <summary>
        /// 公司名称
        /// </summary>
        public string FullName
        {
            get { return _fullName ?? string.Empty; }
            set { _fullName = value; }
        }
        private string _shortName = string.Empty;
        /// <summary>
        /// 公司简称
        /// </summary>
        public string ShortName
        {
            get { return _shortName ?? string.Empty; }
            set { _shortName = value; }
        }
        private string _nature = string.Empty;
        /// <summary>
        /// 公司性质
        /// </summary>
        public string Nature
        {
            get { return _nature ?? string.Empty; }
            set { _nature = value; }
        }
        private string _manager = string.Empty;
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string Manager
        {
            get { return _manager ?? string.Empty; }
            set { _manager = value; }
        }
        private string _contact = string.Empty;
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            get { return _contact ?? string.Empty; }
            set { _contact = value; }
        }
        private string _phone = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone ?? string.Empty; }
            set { _phone = value; }
        }
        private string _fax = string.Empty;
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _fax ?? string.Empty; }
            set { _fax = value; }
        }
        private string _email = string.Empty;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            get { return _email ?? string.Empty; }
            set { _email = value; }
        }
        private string _provinceId = string.Empty;
        /// <summary>
        /// 省主键
        /// </summary>
        public string ProvinceId
        {
            get { return _provinceId ?? string.Empty; }
            set { _provinceId = value; }
        }
        private string _province = string.Empty;
        /// <summary>
        /// 省
        /// </summary>
        public string Province
        {
            get { return _province ?? string.Empty; }
            set { _province = value; }
        }
        private string _cityId = string.Empty;
        /// <summary>
        /// 市主键
        /// </summary>
        public string CityId
        {
            get { return _cityId ?? string.Empty; }
            set { _cityId = value; }
        }
        private string _city = string.Empty;
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            get { return _city ?? string.Empty; }
            set { _city = value; }
        }
        private string _countyId = string.Empty;
        /// <summary>
        /// 县/区主键
        /// </summary>
        public string CountyId
        {
            get { return _countyId ?? string.Empty; }
            set { _countyId = value; }
        }
        private string _county = string.Empty;
        /// <summary>
        /// 县/区
        /// </summary>
        public string County
        {
            get { return _county ?? string.Empty; }
            set { _county = value; }
        }
        private string _address = string.Empty;
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get { return _address ?? string.Empty; }
            set { _address = value; }
        }
        private string _accountInfo = string.Empty;
        /// <summary>
        /// 开户信息
        /// </summary>
        public string AccountInfo
        {
            get { return _accountInfo ?? string.Empty; }
            set { _accountInfo = value; }
        }
        private string _postalcode = string.Empty;
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postalcode
        {
            get { return _postalcode ?? string.Empty; }
            set { _postalcode = value; }
        }
        private string _web = string.Empty;
        /// <summary>
        /// 网址
        /// </summary>
        public string Web
        {
            get { return _web ?? string.Empty; }
            set { _web = value; }
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

    }
}

