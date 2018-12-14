//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:52:51
//  功能描述：CrmUser表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class CrmUserEntity : ModelImp.BaseModel<CrmUserEntity>
    {
        public CrmUserEntity()
        {
            TB_Name = TB_CrmUser;
            Parm_Id = Parm_CrmUser_Id;
            Parm_Version = Parm_CrmUser_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmUser_Insert;
            Sql_Update = Sql_CrmUser_Update;
            Sql_Delete = Sql_CrmUser_Delete;
        }
        #region Const of table CrmUser
        /// <summary>
        /// Table CrmUser
        /// </summary>
        public const string TB_CrmUser = "CrmUser";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Account
        /// </summary>
        public const string Parm_CrmUser_Account = "Account";
        /// <summary>
        /// Parm AuditDateTime
        /// </summary>
        public const string Parm_CrmUser_AuditDateTime = "AuditDateTime";
        /// <summary>
        /// Parm AuditStatus
        /// </summary>
        public const string Parm_CrmUser_AuditStatus = "AuditStatus";
        /// <summary>
        /// Parm AuditUserId
        /// </summary>
        public const string Parm_CrmUser_AuditUserId = "AuditUserId";
        /// <summary>
        /// Parm AuditUserName
        /// </summary>
        public const string Parm_CrmUser_AuditUserName = "AuditUserName";
        /// <summary>
        /// Parm Birthday
        /// </summary>
        public const string Parm_CrmUser_Birthday = "Birthday";
        /// <summary>
        /// Parm ChangePasswordDate
        /// </summary>
        public const string Parm_CrmUser_ChangePasswordDate = "ChangePasswordDate";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_CrmUser_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_CrmUser_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmUser_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmUser_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmUser_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_CrmUser_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm Email
        /// </summary>
        public const string Parm_CrmUser_Email = "Email";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_CrmUser_Enabled = "Enabled";
        /// <summary>
        /// Parm FirstVisit
        /// </summary>
        public const string Parm_CrmUser_FirstVisit = "FirstVisit";
        /// <summary>
        /// Parm Gender
        /// </summary>
        public const string Parm_CrmUser_Gender = "Gender";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmUser_Id = "Id";
        /// <summary>
        /// Parm InnerUser
        /// </summary>
        public const string Parm_CrmUser_InnerUser = "InnerUser";
        /// <summary>
        /// Parm IsCityManager
        /// </summary>
        public const string Parm_CrmUser_IsCityManager = "IsCityManager";

        /// <summary>
        /// Parm IsBorrow
        /// </summary>
        public const string Parm_CrmUser_IsBorrow = "IsBorrow";

        /// <summary>
        /// Parm LastVisit
        /// </summary>
        public const string Parm_CrmUser_LastVisit = "LastVisit";
        /// <summary>
        /// Parm LogOnCount
        /// </summary>
        public const string Parm_CrmUser_LogOnCount = "LogOnCount";
        /// <summary>
        /// Parm Mobile
        /// </summary>
        public const string Parm_CrmUser_Mobile = "Mobile";
        /// <summary>
        /// Parm OICQ
        /// </summary>
        public const string Parm_CrmUser_OICQ = "OICQ";
        /// <summary>
        /// Parm OpenId
        /// </summary>
        public const string Parm_CrmUser_OpenId = "OpenId";
        /// <summary>
        /// Parm Password
        /// </summary>
        public const string Parm_CrmUser_Password = "Password";
        /// <summary>
        /// Parm PreviousVisit
        /// </summary>
        public const string Parm_CrmUser_PreviousVisit = "PreviousVisit";
        /// <summary>
        /// Parm RealName
        /// </summary>
        public const string Parm_CrmUser_RealName = "RealName";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_CrmUser_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmUser_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Secretkey
        /// </summary>
        public const string Parm_CrmUser_Secretkey = "Secretkey";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_CrmUser_SortCode = "SortCode";

        /// <summary>
        /// Parm FlightSortCode
        /// </summary>
        public const string Parm_CrmUser_FlightSortCode = "FlightSortCode";

        /// <summary>
        /// Parm Spell
        /// </summary>
        public const string Parm_CrmUser_Spell = "Spell";
        /// <summary>
        /// Parm Telephone
        /// </summary>
        public const string Parm_CrmUser_Telephone = "Telephone";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmUser_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmUser_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmUser_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmUser_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmUser
        /// </summary>
        public const string Sql_CrmUser_Insert = "insert into CrmUser(Account,AuditDateTime,AuditStatus,AuditUserId,AuditUserName,Birthday,ChangePasswordDate,Code,CompanyId,CreateBy,CreateOn,CreatorId,DepartmentId,Email,Enabled,FirstVisit,Gender,InnerUser,IsCityManager,LastVisit,LogOnCount,Mobile,OICQ,OpenId,Password,PreviousVisit,RealName,Remark,RowStatus,Secretkey,SortCode,FlightSortCode,Spell,Telephone,UpdateBy,UpdateId,UpdateOn,IsBorrow,Id) values(@Account,@AuditDateTime,@AuditStatus,@AuditUserId,@AuditUserName,@Birthday,@ChangePasswordDate,@Code,@CompanyId,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@Email,@Enabled,@FirstVisit,@Gender,@InnerUser,@IsCityManager,@LastVisit,@LogOnCount,@Mobile,@OICQ,@OpenId,@Password,@PreviousVisit,@RealName,@Remark,@RowStatus,@Secretkey,@SortCode,@FlightSortCode,@Spell,@Telephone,@UpdateBy,@UpdateId,@UpdateOn,@IsBorrow,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmUser
        /// </summary>
        public const string Sql_CrmUser_Update = "update CrmUser set Account=@Account,AuditDateTime=@AuditDateTime,AuditStatus=@AuditStatus,AuditUserId=@AuditUserId,AuditUserName=@AuditUserName,Birthday=@Birthday,ChangePasswordDate=@ChangePasswordDate,Code=@Code,CompanyId=@CompanyId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,Email=@Email,Enabled=@Enabled,FirstVisit=@FirstVisit,Gender=@Gender,InnerUser=@InnerUser,IsCityManager=@IsCityManager,LastVisit=@LastVisit,LogOnCount=@LogOnCount,Mobile=@Mobile,OICQ=@OICQ,OpenId=@OpenId,Password=@Password,PreviousVisit=@PreviousVisit,RealName=@RealName,Remark=@Remark,RowStatus=@RowStatus,Secretkey=@Secretkey,SortCode=@SortCode,FlightSortCode=@FlightSortCode,Spell=@Spell,Telephone=@Telephone,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,IsBorrow=@IsBorrow where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmUser_Delete = "update CrmUser set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _companyId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _departmentId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private int _innerUser;
        /// <summary>
        /// 
        /// </summary>
        public int InnerUser
        {
            get { return _innerUser; }
            set { _innerUser = value; }
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
        private string _account = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            get { return _account ?? string.Empty; }
            set { _account = value; }
        }
        private string _password = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return _password ?? string.Empty; }
            set { _password = value; }
        }
        private string _secretkey = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Secretkey
        {
            get { return _secretkey ?? string.Empty; }
            set { _secretkey = value; }
        }
        private string _realName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            get { return _realName ?? string.Empty; }
            set { _realName = value; }
        }
        private string _spell = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Spell
        {
            get { return _spell ?? string.Empty; }
            set { _spell = value; }
        }
        private string _gender = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            get { return _gender ?? string.Empty; }
            set { _gender = value; }
        }
        private DateTime _birthday = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        private string _mobile = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            get { return _mobile ?? string.Empty; }
            set { _mobile = value; }
        }
        private string _telephone = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            get { return _telephone ?? string.Empty; }
            set { _telephone = value; }
        }
        private string _oICQ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string OICQ
        {
            get { return _oICQ ?? string.Empty; }
            set { _oICQ = value; }
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
        private DateTime _changePasswordDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangePasswordDate
        {
            get { return _changePasswordDate; }
            set { _changePasswordDate = value; }
        }
        private int _openId;
        /// <summary>
        /// 
        /// </summary>
        public int OpenId
        {
            get { return _openId; }
            set { _openId = value; }
        }
        private int _logOnCount;
        /// <summary>
        /// 
        /// </summary>
        public int LogOnCount
        {
            get { return _logOnCount; }
            set { _logOnCount = value; }
        }
        private DateTime _firstVisit = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FirstVisit
        {
            get { return _firstVisit; }
            set { _firstVisit = value; }
        }
        private DateTime _previousVisit = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime PreviousVisit
        {
            get { return _previousVisit; }
            set { _previousVisit = value; }
        }
        private DateTime _lastVisit = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastVisit
        {
            get { return _lastVisit; }
            set { _lastVisit = value; }
        }
        private string _auditStatus = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AuditStatus
        {
            get { return _auditStatus ?? string.Empty; }
            set { _auditStatus = value; }
        }
        private string _auditUserId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AuditUserId
        {
            get { return _auditUserId ?? string.Empty; }
            set { _auditUserId = value; }
        }
        private string _auditUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AuditUserName
        {
            get { return _auditUserName ?? string.Empty; }
            set { _auditUserName = value; }
        }
        private DateTime _auditDateTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuditDateTime
        {
            get { return _auditDateTime; }
            set { _auditDateTime = value; }
        }
        private string _isCityManager = string.Empty;
        /// <summary>
        /// 是否是“市容管理员”(1：是 ，0：否)
        /// </summary>
        public string IsCityManager
        {
            get { return _isCityManager ?? string.Empty; }
            set { _isCityManager = value; }
        }

        /// <summary>
        /// 是否是“外借人员”
        /// </summary>
        public int IsBorrow { get; set; }

        private string _remark = string.Empty;
        /// <summary>
        /// 
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

        /// <summary>
        /// 排班排序号
        /// </summary>
        public int FlightSortCode { get; set; }

        /// <summary>
        /// 是否设置角色 
        /// </summary>
        public int IsSetRole { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 学习时长
        /// </summary>
        public int timeLong { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmUserEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmUserEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmUserEntity();
            if (fields.Contains(Parm_CrmUser_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmUser_Id].ToString();
            if (fields.Contains(Parm_CrmUser_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_CrmUser_CompanyId].ToString();
            if (fields.Contains(Parm_CrmUser_DepartmentId) || fields.Contains("*"))
                tmp.DepartmentId = dr[Parm_CrmUser_DepartmentId].ToString();
            if (fields.Contains(Parm_CrmUser_InnerUser) || fields.Contains("*"))
                tmp.InnerUser = int.Parse(dr[Parm_CrmUser_InnerUser].ToString());
            if (fields.Contains(Parm_CrmUser_Code) || fields.Contains("*"))
                tmp.Code = dr[Parm_CrmUser_Code].ToString();
            if (fields.Contains(Parm_CrmUser_Account) || fields.Contains("*"))
                tmp.Account = dr[Parm_CrmUser_Account].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Password))
                tmp.Password = dr[Parm_CrmUser_Password].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Secretkey))
                tmp.Secretkey = dr[Parm_CrmUser_Secretkey].ToString();
            if (fields.Contains(Parm_CrmUser_RealName) || fields.Contains("*"))
                tmp.RealName = dr[Parm_CrmUser_RealName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Spell))
                tmp.Spell = dr[Parm_CrmUser_Spell].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Gender))
                tmp.Gender = dr[Parm_CrmUser_Gender].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Birthday) && !string.IsNullOrEmpty(dr[Parm_CrmUser_Birthday].ToString()))
                tmp.Birthday = DateTime.Parse(dr[Parm_CrmUser_Birthday].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_Mobile))
                tmp.Mobile = dr[Parm_CrmUser_Mobile].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Telephone))
                tmp.Telephone = dr[Parm_CrmUser_Telephone].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_OICQ))
                tmp.OICQ = dr[Parm_CrmUser_OICQ].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Email))
                tmp.Email = dr[Parm_CrmUser_Email].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_ChangePasswordDate) && !string.IsNullOrEmpty(dr[Parm_CrmUser_ChangePasswordDate].ToString()))
                tmp.ChangePasswordDate = DateTime.Parse(dr[Parm_CrmUser_ChangePasswordDate].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_OpenId) && !string.IsNullOrEmpty(dr[Parm_CrmUser_OpenId].ToString()))
                tmp.OpenId = int.Parse(dr[Parm_CrmUser_OpenId].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_LogOnCount) && !string.IsNullOrEmpty(dr[Parm_CrmUser_LogOnCount].ToString()))
                tmp.LogOnCount = int.Parse(dr[Parm_CrmUser_LogOnCount].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_FirstVisit) && !string.IsNullOrEmpty(dr[Parm_CrmUser_FirstVisit].ToString()))
                tmp.FirstVisit = DateTime.Parse(dr[Parm_CrmUser_FirstVisit].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_PreviousVisit) && !string.IsNullOrEmpty(dr[Parm_CrmUser_PreviousVisit].ToString()))
                tmp.PreviousVisit = DateTime.Parse(dr[Parm_CrmUser_PreviousVisit].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_LastVisit) && !string.IsNullOrEmpty(dr[Parm_CrmUser_LastVisit].ToString()))
                tmp.LastVisit = DateTime.Parse(dr[Parm_CrmUser_LastVisit].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_AuditStatus))
                tmp.AuditStatus = dr[Parm_CrmUser_AuditStatus].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_AuditUserId))
                tmp.AuditUserId = dr[Parm_CrmUser_AuditUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_AuditUserName))
                tmp.AuditUserName = dr[Parm_CrmUser_AuditUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_AuditDateTime) && !string.IsNullOrEmpty(dr[Parm_CrmUser_AuditDateTime].ToString()))
                tmp.AuditDateTime = DateTime.Parse(dr[Parm_CrmUser_AuditDateTime].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_Remark))
                tmp.Remark = dr[Parm_CrmUser_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_Enabled))
                tmp.Enabled = int.Parse(dr[Parm_CrmUser_Enabled].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_IsCityManager))
                tmp.IsCityManager = dr[Parm_CrmUser_IsCityManager].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_SortCode) && !string.IsNullOrEmpty(dr[Parm_CrmUser_SortCode].ToString()))
                tmp.SortCode = int.Parse(dr[Parm_CrmUser_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_FlightSortCode) && !string.IsNullOrEmpty(dr[Parm_CrmUser_FlightSortCode].ToString()))
                tmp.FlightSortCode = int.Parse(dr[Parm_CrmUser_FlightSortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmUser_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_Version))
            {
                var bts = (byte[])(dr[Parm_CrmUser_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmUser_CreatorId))
                tmp.CreatorId = dr[Parm_CrmUser_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_CreateBy))
                tmp.CreateBy = dr[Parm_CrmUser_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmUser_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUser_UpdateId))
                tmp.UpdateId = dr[Parm_CrmUser_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmUser_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUser_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmUser_UpdateOn].ToString());
            if (dr.Table.Columns.Contains("IsSetRole"))
                tmp.IsSetRole = int.Parse(dr["IsSetRole"].ToString());
            if (dr.Table.Columns.Contains("CompanyName"))
            {
                tmp.CompanyName = dr["CompanyName"].ToString();
            }
            if (dr.Table.Columns.Contains("DepartmentName"))
            {
                tmp.DepartmentName = dr["DepartmentName"].ToString();
            }
            if (dr.Table.Columns.Contains(Parm_CrmUser_IsBorrow))
            {
                tmp.IsBorrow = int.Parse(dr[Parm_CrmUser_IsBorrow].ToString());
            }

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmuser">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmUserEntity crmuser, SqlParameter[] parms)
        {
            parms[0].Value = crmuser.CompanyId;
            parms[1].Value = crmuser.DepartmentId;
            parms[2].Value = crmuser.InnerUser;
            parms[3].Value = crmuser.Code;
            parms[4].Value = crmuser.Account;
            parms[5].Value = crmuser.Password;
            parms[6].Value = crmuser.Secretkey;
            parms[7].Value = crmuser.RealName;
            parms[8].Value = crmuser.Spell;
            parms[9].Value = crmuser.Gender;
            parms[10].Value = crmuser.Birthday;
            parms[11].Value = crmuser.Mobile;
            parms[12].Value = crmuser.Telephone;
            parms[13].Value = crmuser.OICQ;
            parms[14].Value = crmuser.Email;
            parms[15].Value = crmuser.ChangePasswordDate;
            parms[16].Value = crmuser.OpenId;
            parms[17].Value = crmuser.LogOnCount;
            parms[18].Value = crmuser.FirstVisit;
            parms[19].Value = crmuser.PreviousVisit;
            parms[20].Value = crmuser.LastVisit;
            parms[21].Value = crmuser.AuditStatus;
            parms[22].Value = crmuser.AuditUserId;
            parms[23].Value = crmuser.AuditUserName;
            parms[24].Value = crmuser.AuditDateTime;
            parms[25].Value = crmuser.IsCityManager;
            parms[26].Value = crmuser.Remark;
            parms[27].Value = crmuser.Enabled;
            parms[28].Value = crmuser.SortCode;
            parms[29].Value = crmuser.FlightSortCode;
            parms[30].Value = crmuser.RowStatus;
            parms[31].Value = crmuser.CreatorId;
            parms[32].Value = crmuser.CreateBy;
            parms[33].Value = crmuser.CreateOn;
            parms[34].Value = crmuser.UpdateId;
            parms[35].Value = crmuser.UpdateBy;
            parms[36].Value = crmuser.UpdateOn;
            parms[37].Value = crmuser.IsBorrow;
            parms[38].Value = crmuser.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmUserEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUser_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmUser_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_InnerUser, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_Code, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Account, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Password, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Secretkey, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_RealName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Spell, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmUser_Gender, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Birthday, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_Mobile, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Telephone, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_OICQ, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Email, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_ChangePasswordDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_OpenId, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_LogOnCount, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_FirstVisit, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_PreviousVisit, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_LastVisit, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_AuditStatus, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_AuditUserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_AuditUserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_AuditDateTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_IsCityManager, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmUser_Enabled, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_SortCode, SqlDbType.Int, 10),
                    new SqlParameter(Parm_CrmUser_FlightSortCode, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUser_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUser_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUser_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmUser_IsBorrow, SqlDbType.Int, 10),
                    new SqlParameter(Parm_CrmUser_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUser_Insert, parms);
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

