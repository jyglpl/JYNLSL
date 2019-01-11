//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/6 20:52:52
//  功能描述：CrmRole表实体
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
    public class CrmRoleEntity : ModelImp.BaseModel<CrmRoleEntity>
    {
        public CrmRoleEntity()
        {
            TB_Name = TB_CrmRole;
            Parm_Id = Parm_CrmRole_Id;
            Parm_Version = Parm_CrmRole_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmRole_Insert;
            Sql_Update = Sql_CrmRole_Update;
            Sql_Delete = Sql_CrmRole_Delete;
        }
        #region Const of table CrmRole
        /// <summary>
        /// Table CrmRole
        /// </summary>
        public const string TB_CrmRole = "CrmRole";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Category
        /// </summary>
        public const string Parm_CrmRole_Category = "Category";
        /// <summary>
        /// Parm Code
        /// </summary>
        public const string Parm_CrmRole_Code = "Code";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_CrmRole_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmRole_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmRole_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmRole_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Enabled
        /// </summary>
        public const string Parm_CrmRole_Enabled = "Enabled";
        /// <summary>
        /// Parm FullName
        /// </summary>
        public const string Parm_CrmRole_FullName = "FullName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmRole_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_CrmRole_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmRole_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_CrmRole_SortCode = "SortCode";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmRole_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmRole_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmRole_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmRole_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmRole
        /// </summary>
        public const string Sql_CrmRole_Insert = "insert into CrmRole(Category,Code,CompanyId,CreateBy,CreateOn,CreatorId,Enabled,FullName,Remark,RowStatus,SortCode,UpdateBy,UpdateId,UpdateOn,Id) values(@Category,@Code,@CompanyId,@CreateBy,@CreateOn,@CreatorId,@Enabled,@FullName,@Remark,@RowStatus,@SortCode,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmRole
        /// </summary>
        public const string Sql_CrmRole_Update = "update CrmRole set Category=@Category,Code=@Code,CompanyId=@CompanyId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Enabled=@Enabled,FullName=@FullName,Remark=@Remark,RowStatus=@RowStatus,SortCode=@SortCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmRole_Delete = "update CrmRole set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        /// 角色成员人数
        /// </summary>
        public int Membercount { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public string CompanyName { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmRoleEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmRoleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmRoleEntity();
            if (dr.Table.Columns.Contains(Parm_CrmRole_Id))
                tmp.Id = dr[Parm_CrmRole_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_CompanyId))
                tmp.CompanyId = dr[Parm_CrmRole_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_Category))
                tmp.Category = dr[Parm_CrmRole_Category].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_Code))
                tmp.Code = dr[Parm_CrmRole_Code].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_FullName))
                tmp.FullName = dr[Parm_CrmRole_FullName].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_Remark))
                tmp.Remark = dr[Parm_CrmRole_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_Enabled))
                tmp.Enabled = int.Parse(dr[Parm_CrmRole_Enabled].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRole_SortCode))
                tmp.SortCode = int.Parse(dr[Parm_CrmRole_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRole_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmRole_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRole_Version))
            {
                var bts = (byte[])(dr[Parm_CrmRole_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmRole_CreatorId))
                tmp.CreatorId = dr[Parm_CrmRole_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_CreateBy))
                tmp.CreateBy = dr[Parm_CrmRole_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmRole_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRole_UpdateId))
                tmp.UpdateId = dr[Parm_CrmRole_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmRole_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRole_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmRole_UpdateOn].ToString());
            if (dr.Table.Columns.Contains("Membercount"))
            {
                tmp.Membercount = int.Parse(dr["Membercount"].ToString());
            }
            if (dr.Table.Columns.Contains("CompanyName"))
            {
                tmp.CompanyName = dr["CompanyName"].ToString();
            }
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmrole">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmRoleEntity crmrole, SqlParameter[] parms)
        {
            parms[0].Value = crmrole.CompanyId;
            parms[1].Value = crmrole.Category;
            parms[2].Value = crmrole.Code;
            parms[3].Value = crmrole.FullName;
            parms[4].Value = crmrole.Remark;
            parms[5].Value = crmrole.Enabled;
            parms[6].Value = crmrole.SortCode;
            parms[7].Value = crmrole.RowStatus;
            parms[8].Value = crmrole.CreatorId;
            parms[9].Value = crmrole.CreateBy;
            parms[10].Value = crmrole.CreateOn;
            parms[11].Value = crmrole.UpdateId;
            parms[12].Value = crmrole.UpdateBy;
            parms[13].Value = crmrole.UpdateOn;
            parms[14].Value = crmrole.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmRoleEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmRole_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmRole_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_Category, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_Code, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_FullName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmRole_Enabled, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmRole_SortCode, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmRole_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmRole_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmRole_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRole_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmRole_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmRole_Insert, parms);
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

