//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmCompanyEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/10 10:06:09
//  功能描述：CrmCompany表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 单位管理
    /// </summary>
    [Serializable]
    public class CrmCompanyEntity : ModelImp.BaseModel<CrmCompanyEntity>
    {
        public CrmCompanyEntity()
        {
            TB_Name = TB_CrmCompany;
            Parm_Id = Parm_CrmCompany_Id;
            Parm_Version = Parm_CrmCompany_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmCompany_Insert;
            Sql_Update = Sql_CrmCompany_Update;
            Sql_Delete = Sql_CrmCompany_Delete;
        }
        #region Const of table CrmCompany
        /// <summary>
        /// Table CrmCompany
        /// </summary>
        public const string TB_CrmCompany = "CrmCompany";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AccountInfo
        /// </summary>
        public const string Parm_CrmCompany_AccountInfo = "AccountInfo";
        /// <summary>
        /// Parm Address
        /// </summary>
        public const string Parm_CrmCompany_Address = "Address";
        /// <summary>
        /// Parm Category
        /// </summary>
        public const string Parm_CrmCompany_Category = "Category";
        /// <summary>
        /// Parm City
        /// </summary>
        public const string Parm_CrmCompany_City = "City";
        /// <summary>
        /// Parm CityId
        /// </summary>
        public const string Parm_CrmCompany_CityId = "CityId";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_CrmCompany_Code = "Code";
        /// <summary>
        /// Parm Contact
        /// </summary>
        public const string Parm_CrmCompany_Contact = "Contact";
        /// <summary>
        /// Parm County
        /// </summary>
        public const string Parm_CrmCompany_County = "County";
        /// <summary>
        /// Parm CountyId
        /// </summary>
        public const string Parm_CrmCompany_CountyId = "CountyId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmCompany_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateDate
        /// </summary>
        public const string Parm_CrmCompany_CreateDate = "CreateDate";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmCompany_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreateUserId
        /// </summary>
        public const string Parm_CrmCompany_CreateUserId = "CreateUserId";
        /// <summary>
        /// Parm CreateUserName
        /// </summary>
        public const string Parm_CrmCompany_CreateUserName = "CreateUserName";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmCompany_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeleteMark
        /// </summary>
        public const string Parm_CrmCompany_DeleteMark = "DeleteMark";
        /// <summary>
        /// Parm Email
        /// </summary>
        public const string Parm_CrmCompany_Email = "Email";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_CrmCompany_Enabled = "Enabled";
        /// <summary>
        /// Parm Enforcement
        /// </summary>
        public const string Parm_CrmCompany_Enforcement = "Enforcement";
        /// <summary>
        /// Parm Fax
        /// </summary>
        public const string Parm_CrmCompany_Fax = "Fax";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_CrmCompany_FullName = "FullName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmCompany_Id = "Id";
        /// <summary>
        /// Parm Manager
        /// </summary>
        public const string Parm_CrmCompany_Manager = "Manager";
        /// <summary>
        /// Parm ModifyDate
        /// </summary>
        public const string Parm_CrmCompany_ModifyDate = "ModifyDate";
        /// <summary>
        /// Parm ModifyUserId
        /// </summary>
        public const string Parm_CrmCompany_ModifyUserId = "ModifyUserId";
        /// <summary>
        /// Parm ModifyUserName
        /// </summary>
        public const string Parm_CrmCompany_ModifyUserName = "ModifyUserName";
        /// <summary>
        /// Parm Nature
        /// </summary>
        public const string Parm_CrmCompany_Nature = "Nature";
        /// <summary>
        /// Parm ParentId
        /// </summary>
        public const string Parm_CrmCompany_ParentId = "ParentId";
        /// <summary>
        /// Parm Phone
        /// </summary>
        public const string Parm_CrmCompany_Phone = "Phone";
        /// <summary>
        /// Parm Postalcode
        /// </summary>
        public const string Parm_CrmCompany_Postalcode = "Postalcode";
        /// <summary>
        /// Parm Province
        /// </summary>
        public const string Parm_CrmCompany_Province = "Province";
        /// <summary>
        /// Parm ProvinceId
        /// </summary>
        public const string Parm_CrmCompany_ProvinceId = "ProvinceId";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_CrmCompany_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmCompany_RowStatus = "RowStatus";
        /// <summary>
        /// Parm ShortName
        /// </summary>
        public const string Parm_CrmCompany_ShortName = "ShortName";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_CrmCompany_SortCode = "SortCode";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmCompany_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmCompany_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmCompany_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmCompany_Version = "Version";
        /// <summary>
        /// Parm Web
        /// </summary>
        public const string Parm_CrmCompany_Web = "Web";
        /// <summary>
        /// Insert Query Of CrmCompany
        /// </summary>
        public const string Sql_CrmCompany_Insert = "insert into CrmCompany(AccountInfo,Address,Category,City,CityId,Code,Contact,County,CountyId,CreateBy,CreateDate,CreateOn,CreateUserId,CreateUserName,CreatorId,DeleteMark,Email,Enabled,Enforcement,Fax,FullName,Manager,ModifyDate,ModifyUserId,ModifyUserName,Nature,ParentId,Phone,Postalcode,Province,ProvinceId,Remark,RowStatus,ShortName,SortCode,UpdateBy,UpdateId,UpdateOn,Web,Id) values(@AccountInfo,@Address,@Category,@City,@CityId,@Code,@Contact,@County,@CountyId,@CreateBy,@CreateDate,@CreateOn,@CreateUserId,@CreateUserName,@CreatorId,@DeleteMark,@Email,@Enabled,@Enforcement,@Fax,@FullName,@Manager,@ModifyDate,@ModifyUserId,@ModifyUserName,@Nature,@ParentId,@Phone,@Postalcode,@Province,@ProvinceId,@Remark,@RowStatus,@ShortName,@SortCode,@UpdateBy,@UpdateId,@UpdateOn,@Web,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmCompany
        /// </summary>
        public const string Sql_CrmCompany_Update = "update CrmCompany set AccountInfo=@AccountInfo,Address=@Address,Category=@Category,City=@City,CityId=@CityId,Code=@Code,Contact=@Contact,County=@County,CountyId=@CountyId,CreateBy=@CreateBy,CreateDate=@CreateDate,CreateOn=@CreateOn,CreateUserId=@CreateUserId,CreateUserName=@CreateUserName,CreatorId=@CreatorId,DeleteMark=@DeleteMark,Email=@Email,Enabled=@Enabled,Enforcement=@Enforcement,Fax=@Fax,FullName=@FullName,Manager=@Manager,ModifyDate=@ModifyDate,ModifyUserId=@ModifyUserId,ModifyUserName=@ModifyUserName,Nature=@Nature,ParentId=@ParentId,Phone=@Phone,Postalcode=@Postalcode,Province=@Province,ProvinceId=@ProvinceId,Remark=@Remark,RowStatus=@RowStatus,ShortName=@ShortName,SortCode=@SortCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Web=@Web where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmCompany_Delete = "update CrmCompany set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _parentId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ParentId
        {
            get { return _parentId ?? string.Empty; }
            set { _parentId = value; }
        }
        private string _category = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Category
        {
            get { return _category ?? string.Empty; }
            set { _category = value; }
        }
        private string _code = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get { return _code ?? string.Empty; }
            set { _code = value; }
        }
        private string _fullName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FullName
        {
            get { return _fullName ?? string.Empty; }
            set { _fullName = value; }
        }
        private string _shortName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShortName
        {
            get { return _shortName ?? string.Empty; }
            set { _shortName = value; }
        }
        private string _nature = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Nature
        {
            get { return _nature ?? string.Empty; }
            set { _nature = value; }
        }
        private string _manager = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Manager
        {
            get { return _manager ?? string.Empty; }
            set { _manager = value; }
        }
        private string _contact = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Contact
        {
            get { return _contact ?? string.Empty; }
            set { _contact = value; }
        }
        private string _phone = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            get { return _phone ?? string.Empty; }
            set { _phone = value; }
        }
        private string _fax = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return _fax ?? string.Empty; }
            set { _fax = value; }
        }
        private string _email = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return _email ?? string.Empty; }
            set { _email = value; }
        }
        private string _provinceId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceId
        {
            get { return _provinceId ?? string.Empty; }
            set { _provinceId = value; }
        }
        private string _province = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            get { return _province ?? string.Empty; }
            set { _province = value; }
        }
        private string _cityId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CityId
        {
            get { return _cityId ?? string.Empty; }
            set { _cityId = value; }
        }
        private string _city = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            get { return _city ?? string.Empty; }
            set { _city = value; }
        }
        private string _countyId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CountyId
        {
            get { return _countyId ?? string.Empty; }
            set { _countyId = value; }
        }
        private string _county = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string County
        {
            get { return _county ?? string.Empty; }
            set { _county = value; }
        }
        private string _address = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get { return _address ?? string.Empty; }
            set { _address = value; }
        }
        private string _accountInfo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccountInfo
        {
            get { return _accountInfo ?? string.Empty; }
            set { _accountInfo = value; }
        }
        private string _postalcode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Postalcode
        {
            get { return _postalcode ?? string.Empty; }
            set { _postalcode = value; }
        }
        private string _web = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Web
        {
            get { return _web ?? string.Empty; }
            set { _web = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private int _enforcement;
        /// <summary>
        /// 
        /// </summary>
        public int Enforcement
        {
            get { return _enforcement; }
            set { _enforcement = value; }
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
        private DateTime _createDate = MinDate;
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
        private DateTime _modifyDate = MinDate;
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
        public override CrmCompanyEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmCompanyEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmCompanyEntity();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Id))
                tmp.Id = dr[Parm_CrmCompany_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ParentId))
                tmp.ParentId = dr[Parm_CrmCompany_ParentId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Category))
                tmp.Category = dr[Parm_CrmCompany_Category].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Code))
                tmp.Code = dr[Parm_CrmCompany_Code].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_FullName))
                tmp.FullName = dr[Parm_CrmCompany_FullName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ShortName))
                tmp.ShortName = dr[Parm_CrmCompany_ShortName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Nature))
                tmp.Nature = dr[Parm_CrmCompany_Nature].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Manager))
                tmp.Manager = dr[Parm_CrmCompany_Manager].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Contact))
                tmp.Contact = dr[Parm_CrmCompany_Contact].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Phone))
                tmp.Phone = dr[Parm_CrmCompany_Phone].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Fax))
                tmp.Fax = dr[Parm_CrmCompany_Fax].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Email))
                tmp.Email = dr[Parm_CrmCompany_Email].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ProvinceId))
                tmp.ProvinceId = dr[Parm_CrmCompany_ProvinceId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Province))
                tmp.Province = dr[Parm_CrmCompany_Province].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CityId))
                tmp.CityId = dr[Parm_CrmCompany_CityId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_City))
                tmp.City = dr[Parm_CrmCompany_City].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CountyId))
                tmp.CountyId = dr[Parm_CrmCompany_CountyId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_County))
                tmp.County = dr[Parm_CrmCompany_County].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Address))
                tmp.Address = dr[Parm_CrmCompany_Address].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_AccountInfo))
                tmp.AccountInfo = dr[Parm_CrmCompany_AccountInfo].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Postalcode))
                tmp.Postalcode = dr[Parm_CrmCompany_Postalcode].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Web))
                tmp.Web = dr[Parm_CrmCompany_Web].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Remark))
                tmp.Remark = dr[Parm_CrmCompany_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Enforcement))
                tmp.Enforcement = int.Parse(dr[Parm_CrmCompany_Enforcement].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Enabled))
                tmp.Enabled = int.Parse(dr[Parm_CrmCompany_Enabled].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_SortCode))
                tmp.SortCode = int.Parse(dr[Parm_CrmCompany_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_DeleteMark))
                tmp.DeleteMark = int.Parse(dr[Parm_CrmCompany_DeleteMark].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreateDate))
                tmp.CreateDate = DateTime.Parse(dr[Parm_CrmCompany_CreateDate].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreateUserId))
                tmp.CreateUserId = dr[Parm_CrmCompany_CreateUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreateUserName))
                tmp.CreateUserName = dr[Parm_CrmCompany_CreateUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ModifyDate))
                tmp.ModifyDate = DateTime.Parse(dr[Parm_CrmCompany_ModifyDate].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ModifyUserId))
                tmp.ModifyUserId = dr[Parm_CrmCompany_ModifyUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_ModifyUserName))
                tmp.ModifyUserName = dr[Parm_CrmCompany_ModifyUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmCompany_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_Version))
            {
                var bts = (byte[])(dr[Parm_CrmCompany_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreatorId))
                tmp.CreatorId = dr[Parm_CrmCompany_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreateBy))
                tmp.CreateBy = dr[Parm_CrmCompany_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmCompany_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmCompany_UpdateId))
                tmp.UpdateId = dr[Parm_CrmCompany_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmCompany_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmCompany_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmCompany_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmcompany">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmCompanyEntity crmcompany, SqlParameter[] parms)
        {
            parms[0].Value = crmcompany.ParentId;
            parms[1].Value = crmcompany.Category;
            parms[2].Value = crmcompany.Code;
            parms[3].Value = crmcompany.FullName;
            parms[4].Value = crmcompany.ShortName;
            parms[5].Value = crmcompany.Nature;
            parms[6].Value = crmcompany.Manager;
            parms[7].Value = crmcompany.Contact;
            parms[8].Value = crmcompany.Phone;
            parms[9].Value = crmcompany.Fax;
            parms[10].Value = crmcompany.Email;
            parms[11].Value = crmcompany.ProvinceId;
            parms[12].Value = crmcompany.Province;
            parms[13].Value = crmcompany.CityId;
            parms[14].Value = crmcompany.City;
            parms[15].Value = crmcompany.CountyId;
            parms[16].Value = crmcompany.County;
            parms[17].Value = crmcompany.Address;
            parms[18].Value = crmcompany.AccountInfo;
            parms[19].Value = crmcompany.Postalcode;
            parms[20].Value = crmcompany.Web;
            parms[21].Value = crmcompany.Remark;
            parms[22].Value = crmcompany.Enforcement;
            parms[23].Value = crmcompany.Enabled;
            parms[24].Value = crmcompany.SortCode;
            parms[25].Value = crmcompany.DeleteMark;
            parms[26].Value = crmcompany.CreateDate;
            parms[27].Value = crmcompany.CreateUserId;
            parms[28].Value = crmcompany.CreateUserName;
            parms[29].Value = crmcompany.ModifyDate;
            parms[30].Value = crmcompany.ModifyUserId;
            parms[31].Value = crmcompany.ModifyUserName;
            parms[32].Value = crmcompany.RowStatus;
            parms[33].Value = crmcompany.CreatorId;
            parms[34].Value = crmcompany.CreateBy;
            parms[35].Value = crmcompany.CreateOn;
            parms[36].Value = crmcompany.UpdateId;
            parms[37].Value = crmcompany.UpdateBy;
            parms[38].Value = crmcompany.UpdateOn;
            parms[39].Value = crmcompany.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmCompanyEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
            return parsAll;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmCompany_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_CrmCompany_ParentId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Category, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Code, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_FullName, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_ShortName, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Nature, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Manager, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Contact, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Phone, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Fax, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Email, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_ProvinceId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Province, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_CityId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_City, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_CountyId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_County, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_Address, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_AccountInfo, SqlDbType.VarChar, 200),
                            new SqlParameter(Parm_CrmCompany_Postalcode, SqlDbType.VarChar, 200),
                            new SqlParameter(Parm_CrmCompany_Web, SqlDbType.VarChar, 200),
                            new SqlParameter(Parm_CrmCompany_Remark, SqlDbType.VarChar, 200),
                            new SqlParameter(Parm_CrmCompany_Enforcement, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmCompany_Enabled, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmCompany_SortCode, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmCompany_DeleteMark, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmCompany_CreateDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmCompany_CreateUserId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_CreateUserName, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_ModifyDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmCompany_ModifyUserId, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_ModifyUserName, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_CrmCompany_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmCompany_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmCompany_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmCompany_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmCompany_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmCompany_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmCompany_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmCompany_Id, SqlDbType.NVarChar, 50)

                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmCompany_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }
}

