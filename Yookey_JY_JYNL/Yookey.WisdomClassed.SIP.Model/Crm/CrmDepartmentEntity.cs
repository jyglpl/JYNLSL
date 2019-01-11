//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmDepartmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:38:46
//  功能描述：CrmDepartment表实体
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
    public class CrmDepartmentEntity : ModelImp.BaseModel<CrmDepartmentEntity>
    {
        public CrmDepartmentEntity()
        {
            TB_Name = TB_CrmDepartment;
            Parm_Id = Parm_CrmDepartment_Id;
            Parm_Version = Parm_CrmDepartment_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmDepartment_Insert;
            Sql_Update = Sql_CrmDepartment_Update;
            Sql_Delete = Sql_CrmDepartment_Delete;
        }
        #region Const of table CrmDepartment
        /// <summary>
        /// Table CrmDepartment
        /// </summary>
        public const string TB_CrmDepartment = "CrmDepartment";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_CrmDepartment_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_CrmDepartment_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmDepartment_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmDepartment_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmDepartment_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Email
        /// </summary>
        public const string Parm_CrmDepartment_Email = "Email";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_CrmDepartment_Enabled = "Enabled";
        /// <summary>
        /// Parm Fax
        /// </summary>
        public const string Parm_CrmDepartment_Fax = "Fax";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_CrmDepartment_FullName = "FullName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmDepartment_Id = "Id";
        /// <summary>
        /// Parm Manager
        /// </summary>
        public const string Parm_CrmDepartment_Manager = "Manager";
        /// <summary>
        /// Parm Nature
        /// </summary>
        public const string Parm_CrmDepartment_Nature = "Nature";
        /// <summary>
        /// Parm ParentId
        /// </summary>
        public const string Parm_CrmDepartment_ParentId = "ParentId";
        /// <summary>
        /// Parm Phone
        /// </summary>
        public const string Parm_CrmDepartment_Phone = "Phone";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_CrmDepartment_Remark = "Remark";
        /// <summary>
        /// Parm Ledger
        /// </summary>
        public const string Parm_CrmDepartment_IsLedger = "IsLedger";
        /// <summary>
        /// Parm DeptType
        /// </summary>
        public const string Parm_CrmDepartment_DeptType = "DeptType";
        /// <summary>
        /// Parm Address
        /// </summary>
        public const string Parm_CrmDepartment_Address = "Address";

        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmDepartment_RowStatus = "RowStatus";
        /// <summary>
        /// Parm ShortName
        /// </summary>
        public const string Parm_CrmDepartment_ShortName = "ShortName";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_CrmDepartment_SortCode = "SortCode";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmDepartment_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmDepartment_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmDepartment_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmDepartment_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmDepartment
        /// </summary>
        public const string Sql_CrmDepartment_Insert = "insert into CrmDepartment(Code,CompanyId,CreateBy,CreateOn,CreatorId,Email,Enabled,Fax,FullName,Manager,Nature,ParentId,Phone,Remark,RowStatus,ShortName,SortCode,UpdateBy,UpdateId,UpdateOn,Address,Id) values(@Code,@CompanyId,@CreateBy,@CreateOn,@CreatorId,@Email,@Enabled,@Fax,@FullName,@Manager,@Nature,@ParentId,@Phone,@Remark,@RowStatus,@ShortName,@SortCode,@UpdateBy,@UpdateId,@UpdateOn,@Address,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmDepartment
        /// </summary>
        public const string Sql_CrmDepartment_Update = "update CrmDepartment set Code=@Code,CompanyId=@CompanyId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Email=@Email,Enabled=@Enabled,Fax=@Fax,FullName=@FullName,Manager=@Manager,Nature=@Nature,ParentId=@ParentId,Phone=@Phone,Remark=@Remark,RowStatus=@RowStatus,ShortName=@ShortName,SortCode=@SortCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Address=@Address where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmDepartment_Delete = "update CrmDepartment set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _parentId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ParentId
        {
            get { return _parentId ?? string.Empty; }
            set { _parentId = value; }
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
        private int _ledger;
        /// <summary>
        /// 是否设置为电子台账单位
        /// </summary>
        public int IsLedger
        {
            get { return _ledger; }
            set { _ledger = value; }
        }
        private int _depttype;
        /// <summary>
        /// 是否为区局
        /// </summary>
        public int DeptType
        {
            get { return _depttype; }
            set { _depttype = value; }
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

        public string Address { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmDepartmentEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmDepartmentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmDepartmentEntity();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Id))
                tmp.Id = dr[Parm_CrmDepartment_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_CompanyId))
                tmp.CompanyId = dr[Parm_CrmDepartment_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_ParentId))
                tmp.ParentId = dr[Parm_CrmDepartment_ParentId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Code))
                tmp.Code = dr[Parm_CrmDepartment_Code].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_FullName))
                tmp.FullName = dr[Parm_CrmDepartment_FullName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_ShortName))
                tmp.ShortName = dr[Parm_CrmDepartment_ShortName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Nature))
                tmp.Nature = dr[Parm_CrmDepartment_Nature].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Manager))
                tmp.Manager = dr[Parm_CrmDepartment_Manager].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Phone))
                tmp.Phone = dr[Parm_CrmDepartment_Phone].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Fax))
                tmp.Fax = dr[Parm_CrmDepartment_Fax].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Email))
                tmp.Email = dr[Parm_CrmDepartment_Email].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Remark))
                tmp.Remark = dr[Parm_CrmDepartment_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Enabled))
                tmp.Enabled = int.Parse(dr[Parm_CrmDepartment_Enabled].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_SortCode))
                tmp.SortCode = int.Parse(dr[Parm_CrmDepartment_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmDepartment_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Version))
            {
                var bts = (byte[])(dr[Parm_CrmDepartment_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_CreatorId))
                tmp.CreatorId = dr[Parm_CrmDepartment_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_CreateBy))
                tmp.CreateBy = dr[Parm_CrmDepartment_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmDepartment_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_UpdateId))
                tmp.UpdateId = dr[Parm_CrmDepartment_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmDepartment_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmDepartment_UpdateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmDepartment_Address))
                tmp.Address = dr[Parm_CrmDepartment_Address].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmdepartment">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmDepartmentEntity crmdepartment, SqlParameter[] parms)
        {
            parms[0].Value = crmdepartment.CompanyId;
            parms[1].Value = crmdepartment.ParentId;
            parms[2].Value = crmdepartment.Code;
            parms[3].Value = crmdepartment.FullName;
            parms[4].Value = crmdepartment.ShortName;
            parms[5].Value = crmdepartment.Nature;
            parms[6].Value = crmdepartment.Manager;
            parms[7].Value = crmdepartment.Phone;
            parms[8].Value = crmdepartment.Fax;
            parms[9].Value = crmdepartment.Email;
            parms[10].Value = crmdepartment.Remark;
            parms[11].Value = crmdepartment.Enabled;
            parms[12].Value = crmdepartment.SortCode;
            parms[13].Value = crmdepartment.RowStatus;
            parms[14].Value = crmdepartment.CreatorId;
            parms[15].Value = crmdepartment.CreateBy;
            parms[16].Value = crmdepartment.CreateOn;
            parms[17].Value = crmdepartment.UpdateId;
            parms[18].Value = crmdepartment.UpdateBy;
            parms[19].Value = crmdepartment.UpdateOn;
            parms[20].Value = crmdepartment.Address;
            parms[21].Value = crmdepartment.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmDepartmentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDepartment_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_CrmDepartment_CompanyId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_ParentId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Code, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_FullName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_ShortName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Nature, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Manager, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Phone, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Fax, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Email, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Remark, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Enabled, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmDepartment_SortCode, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmDepartment_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_CrmDepartment_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmDepartment_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_CrmDepartment_Address, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_CrmDepartment_Id, SqlDbType.NVarChar, 50)
                        };

                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDepartment_Insert, parms);
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

