//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmPostEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:52:52
//  功能描述：CrmPost表实体
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
    public class CrmPostEntity : ModelImp.BaseModel<CrmPostEntity>
    {
        public CrmPostEntity()
        {
            TB_Name = TB_CrmPost;
            Parm_Id = Parm_CrmPost_Id;
            Parm_Version = Parm_CrmPost_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmPost_Insert;
            Sql_Update = Sql_CrmPost_Update;
            Sql_Delete = Sql_CrmPost_Delete;
        }
        #region Const of table CrmPost
        /// <summary>
        /// Table CrmPost
        /// </summary>
        public const string TB_CrmPost = "CrmPost";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_CrmPost_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_CrmPost_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmPost_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmPost_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmPost_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_CrmPost_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_CrmPost_Enabled = "Enabled";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_CrmPost_FullName = "FullName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmPost_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_CrmPost_Remark = "Remark";
        /// <summary>
        /// Parm RoleId
        /// </summary>
        public const string Parm_CrmPost_RoleId = "RoleId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmPost_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_CrmPost_SortCode = "SortCode";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmPost_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmPost_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmPost_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmPost_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmPost
        /// </summary>
        public const string Sql_CrmPost_Insert = "insert into CrmPost(Code,CompanyId,CreateBy,CreateOn,CreatorId,DepartmentId,Enabled,FullName,Remark,RoleId,RowStatus,SortCode,UpdateBy,UpdateId,UpdateOn,Id) values(@Code,@CompanyId,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@Enabled,@FullName,@Remark,@RoleId,@RowStatus,@SortCode,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmPost
        /// </summary>
        public const string Sql_CrmPost_Update = "update CrmPost set Code=@Code,CompanyId=@CompanyId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,Enabled=@Enabled,FullName=@FullName,Remark=@Remark,RoleId=@RoleId,RowStatus=@RowStatus,SortCode=@SortCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmPost_Delete = "update CrmPost set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _roleId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RoleId
        {
            get { return _roleId ?? string.Empty; }
            set { _roleId = value; }
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmPostEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmPostEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmPostEntity();
            if (dr.Table.Columns.Contains(Parm_CrmPost_Id))
                tmp.Id = dr[Parm_CrmPost_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_CompanyId))
                tmp.CompanyId = dr[Parm_CrmPost_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_DepartmentId))
                tmp.DepartmentId = dr[Parm_CrmPost_DepartmentId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_RoleId))
                tmp.RoleId = dr[Parm_CrmPost_RoleId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_Code))
                tmp.Code = dr[Parm_CrmPost_Code].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_FullName))
                tmp.FullName = dr[Parm_CrmPost_FullName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_Remark))
                tmp.Remark = dr[Parm_CrmPost_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_Enabled))
                tmp.Enabled = int.Parse(dr[Parm_CrmPost_Enabled].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmPost_SortCode))
                tmp.SortCode = int.Parse(dr[Parm_CrmPost_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmPost_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmPost_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmPost_Version))
            {
                var bts = (byte[])(dr[Parm_CrmPost_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmPost_CreatorId))
                tmp.CreatorId = dr[Parm_CrmPost_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_CreateBy))
                tmp.CreateBy = dr[Parm_CrmPost_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmPost_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmPost_UpdateId))
                tmp.UpdateId = dr[Parm_CrmPost_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmPost_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmPost_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmPost_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmpost">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmPostEntity crmpost, SqlParameter[] parms)
        {
            parms[0].Value = crmpost.CompanyId;
            parms[1].Value = crmpost.DepartmentId;
            parms[2].Value = crmpost.RoleId;
            parms[3].Value = crmpost.Code;
            parms[4].Value = crmpost.FullName;
            parms[5].Value = crmpost.Remark;
            parms[6].Value = crmpost.Enabled;
            parms[7].Value = crmpost.SortCode;
            parms[8].Value = crmpost.RowStatus;
            parms[9].Value = crmpost.CreatorId;
            parms[10].Value = crmpost.CreateBy;
            parms[11].Value = crmpost.CreateOn;
            parms[12].Value = crmpost.UpdateId;
            parms[13].Value = crmpost.UpdateBy;
            parms[14].Value = crmpost.UpdateOn;
            parms[15].Value = crmpost.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmPostEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmPost_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmPost_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_RoleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_Code, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_FullName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_Remark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_Enabled, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmPost_SortCode, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmPost_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmPost_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmPost_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmPost_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmPost_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmPost_Insert, parms);
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

