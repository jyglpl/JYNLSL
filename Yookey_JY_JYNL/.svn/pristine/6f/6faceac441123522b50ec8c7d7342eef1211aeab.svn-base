//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseSpecEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/2 17:01:09
//  功能描述：LicenseSpec表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.License
{
    /// <summary>
    /// 许可申请规格
    /// </summary>
    [Serializable]
    public class LicenseSpecEntity : ModelImp.BaseModel<LicenseSpecEntity>
    {
        public LicenseSpecEntity()
        {
            TB_Name = TB_LicenseSpec;
            Parm_Id = Parm_LicenseSpec_Id;
            Parm_Version = Parm_LicenseSpec_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicenseSpec_Insert;
            Sql_Update = Sql_LicenseSpec_Update;
            Sql_Delete = Sql_LicenseSpec_Delete;
        }
        #region Const of table LicenseSpec
        /// <summary>
        /// Table LicenseSpec
        /// </summary>
        public const string TB_LicenseSpec = "LicenseSpec";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicenseSpec_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicenseSpec_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicenseSpec_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FacilityType
        /// </summary>
        public const string Parm_LicenseSpec_FacilityType = "FacilityType";
        /// <summary>
        /// Parm Height
        /// </summary>
        public const string Parm_LicenseSpec_Height = "Height";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicenseSpec_Id = "Id";
        /// <summary>
        /// Parm LicenseId
        /// </summary>
        public const string Parm_LicenseSpec_LicenseId = "LicenseId";
        /// <summary>
        /// Parm Long
        /// </summary>
        public const string Parm_LicenseSpec_Long = "Long";
        /// <summary>
        /// Parm OtherType
        /// </summary>
        public const string Parm_LicenseSpec_OtherType = "OtherType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicenseSpec_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SortNo
        /// </summary>
        public const string Parm_LicenseSpec_SortNo = "SortNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicenseSpec_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicenseSpec_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicenseSpec_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicenseSpec_Version = "Version";
        /// <summary>
        /// Parm Width
        /// </summary>
        public const string Parm_LicenseSpec_Width = "Width";
        /// <summary>
        /// Insert Query Of LicenseSpec
        /// </summary>
        public const string Sql_LicenseSpec_Insert = "insert into LicenseSpec(CreateBy,CreateOn,CreatorId,FacilityType,Height,LicenseId,Long,OtherType,RowStatus,SortNo,UpdateBy,UpdateId,UpdateOn,Width,Id) values(@CreateBy,@CreateOn,@CreatorId,@FacilityType,@Height,@LicenseId,@Long,@OtherType,@RowStatus,@SortNo,@UpdateBy,@UpdateId,@UpdateOn,@Width,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicenseSpec
        /// </summary>
        public const string Sql_LicenseSpec_Update = "update LicenseSpec set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FacilityType=@FacilityType,Height=@Height,LicenseId=@LicenseId,Long=@Long,OtherType=@OtherType,RowStatus=@RowStatus,SortNo=@SortNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Width=@Width where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicenseSpec_Delete = "update LicenseSpec set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _licenseId = string.Empty;
        /// <summary>
        /// 许可办件主键
        /// </summary>
        public string LicenseId
        {
            get { return _licenseId ?? string.Empty; }
            set { _licenseId = value; }
        }
        private string _width = string.Empty;
        /// <summary>
        /// 宽
        /// </summary>
        public string Width
        {
            get { return _width ?? string.Empty; }
            set { _width = value; }
        }
        private string _height = string.Empty;
        /// <summary>
        /// 高
        /// </summary>
        public string Height
        {
            get { return _height ?? string.Empty; }
            set { _height = value; }
        }
        private string _long = string.Empty;
        /// <summary>
        /// 外挑/架空
        /// </summary>
        public string Long
        {
            get { return _long ?? string.Empty; }
            set { _long = value; }
        }
        private string _facilityType = string.Empty;
        /// <summary>
        /// 设施类型
        /// </summary>
        public string FacilityType
        {
            get { return _facilityType ?? string.Empty; }
            set { _facilityType = value; }
        }
        private string _otherType = string.Empty;
        /// <summary>
        /// 其他类型
        /// </summary>
        public string OtherType
        {
            get { return _otherType ?? string.Empty; }
            set { _otherType = value; }
        }
        private int _sortNo;
        /// <summary>
        /// 索引
        /// </summary>
        public int SortNo
        {
            get { return _sortNo; }
            set { _sortNo = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicenseSpecEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicenseSpecEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseSpecEntity();
            if (fields.Contains(Parm_LicenseSpec_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicenseSpec_Id].ToString();
            if (fields.Contains(Parm_LicenseSpec_LicenseId) || fields.Contains("*"))
                tmp.LicenseId = dr[Parm_LicenseSpec_LicenseId].ToString();
            if (fields.Contains(Parm_LicenseSpec_Width) || fields.Contains("*"))
                tmp.Width = dr[Parm_LicenseSpec_Width].ToString();
            if (fields.Contains(Parm_LicenseSpec_Height) || fields.Contains("*"))
                tmp.Height = dr[Parm_LicenseSpec_Height].ToString();
            if (fields.Contains(Parm_LicenseSpec_Long) || fields.Contains("*"))
                tmp.Long = dr[Parm_LicenseSpec_Long].ToString();
            if (fields.Contains(Parm_LicenseSpec_FacilityType) || fields.Contains("*"))
                tmp.FacilityType = dr[Parm_LicenseSpec_FacilityType].ToString();
            if (fields.Contains(Parm_LicenseSpec_OtherType) || fields.Contains("*"))
                tmp.OtherType = dr[Parm_LicenseSpec_OtherType].ToString();
            if (fields.Contains(Parm_LicenseSpec_SortNo) || fields.Contains("*"))
                tmp.SortNo = int.Parse(dr[Parm_LicenseSpec_SortNo].ToString());
            if (fields.Contains(Parm_LicenseSpec_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicenseSpec_RowStatus].ToString());
            if (fields.Contains(Parm_LicenseSpec_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicenseSpec_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicenseSpec_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicenseSpec_CreatorId].ToString();
            if (fields.Contains(Parm_LicenseSpec_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicenseSpec_CreateBy].ToString();
            if (fields.Contains(Parm_LicenseSpec_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseSpec_CreateOn].ToString());
            if (fields.Contains(Parm_LicenseSpec_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicenseSpec_UpdateId].ToString();
            if (fields.Contains(Parm_LicenseSpec_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicenseSpec_UpdateBy].ToString();
            if (fields.Contains(Parm_LicenseSpec_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseSpec_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensespec">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicenseSpecEntity licensespec, SqlParameter[] parms)
        {
            parms[0].Value = licensespec.LicenseId;
            parms[1].Value = licensespec.Width;
            parms[2].Value = licensespec.Height;
            parms[3].Value = licensespec.Long;
            parms[4].Value = licensespec.FacilityType;
            parms[5].Value = licensespec.OtherType;
            parms[6].Value = licensespec.SortNo;
            parms[7].Value = licensespec.RowStatus;
            parms[8].Value = licensespec.CreatorId;
            parms[9].Value = licensespec.CreateBy;
            parms[10].Value = licensespec.CreateOn;
            parms[11].Value = licensespec.UpdateId;
            parms[12].Value = licensespec.UpdateBy;
            parms[13].Value = licensespec.UpdateOn;
            parms[14].Value = licensespec.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseSpecEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseSpec_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicenseSpec_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_Width, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseSpec_Height, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseSpec_Long, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseSpec_FacilityType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_OtherType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_SortNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseSpec_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseSpec_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseSpec_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseSpec_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseSpec_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseSpec_Insert, parms);
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

