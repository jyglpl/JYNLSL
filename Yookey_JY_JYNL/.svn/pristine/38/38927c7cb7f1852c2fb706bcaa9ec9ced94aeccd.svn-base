//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/23 17:18:37
//  功能描述：Base_Certificate表实体
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
    /// 证件管理\基础信息
    /// </summary>
    [Serializable]
    public class BaseCertificateEntity : ModelImp.BaseModel<BaseCertificateEntity>
    {
        public BaseCertificateEntity()
        {
            TB_Name = TB_Base_Certificate;
            Parm_Id = Parm_Base_Certificate_Id;
            Parm_Version = Parm_Base_Certificate_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Base_Certificate_Insert;
            Sql_Update = Sql_Base_Certificate_Update;
            Sql_Delete = Sql_Base_Certificate_Delete;
        }
        #region Const of table Base_Certificate
        /// <summary>
        /// Table Base_Certificate
        /// </summary>
        public const string TB_Base_Certificate = "Base_Certificate";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CertificateNo
        /// </summary>
        public const string Parm_Base_Certificate_CertificateNo = "CertificateNo";
        /// <summary>
        /// Parm CertificateType
        /// </summary>
        public const string Parm_Base_Certificate_CertificateType = "CertificateType";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Base_Certificate_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Base_Certificate_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Base_Certificate_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Base_Certificate_Id = "Id";
        /// <summary>
        /// Parm LeaveRoleId
        /// </summary>
        public const string Parm_Base_Certificate_LeaveRoleId = "LeaveRoleId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Base_Certificate_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Base_Certificate_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Base_Certificate_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Base_Certificate_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_Base_Certificate_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Base_Certificate_Version = "Version";
        /// <summary>
        /// Insert Query Of Base_Certificate
        /// </summary>
        public const string Sql_Base_Certificate_Insert = "insert into Base_Certificate(CertificateNo,CertificateType,CreateBy,CreateOn,CreatorId,LeaveRoleId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,Id) values(@CertificateNo,@CertificateType,@CreateBy,@CreateOn,@CreatorId,@LeaveRoleId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Base_Certificate
        /// </summary>
        public const string Sql_Base_Certificate_Update = "update Base_Certificate set CertificateNo=@CertificateNo,CertificateType=@CertificateType,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,LeaveRoleId=@LeaveRoleId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Base_Certificate_Delete = "update Base_Certificate set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _userId = string.Empty;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _certificateType = string.Empty;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType
        {
            get { return _certificateType ?? string.Empty; }
            set { _certificateType = value; }
        }
        private string _certificateNo = string.Empty;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNo
        {
            get { return _certificateNo ?? string.Empty; }
            set { _certificateNo = value; }
        }
        private string _leaveRoleId = string.Empty;
        /// <summary>
        /// 请假对应角色
        /// </summary>
        public string LeaveRoleId
        {
            get { return _leaveRoleId ?? string.Empty; }
            set { _leaveRoleId = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override BaseCertificateEntity SetModelValueByDataRow(DataRow dr)
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
        public override BaseCertificateEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new BaseCertificateEntity();
            if (fields.Contains(Parm_Base_Certificate_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Base_Certificate_Id].ToString();
            if (fields.Contains(Parm_Base_Certificate_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_Base_Certificate_UserId].ToString();
            if (fields.Contains(Parm_Base_Certificate_CertificateType) || fields.Contains("*"))
                tmp.CertificateType = dr[Parm_Base_Certificate_CertificateType].ToString();
            if (fields.Contains(Parm_Base_Certificate_CertificateNo) || fields.Contains("*"))
                tmp.CertificateNo = dr[Parm_Base_Certificate_CertificateNo].ToString();
            if (fields.Contains(Parm_Base_Certificate_LeaveRoleId) || fields.Contains("*"))
                tmp.LeaveRoleId = dr[Parm_Base_Certificate_LeaveRoleId].ToString();
            if (fields.Contains(Parm_Base_Certificate_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Base_Certificate_RowStatus].ToString());
            if (fields.Contains(Parm_Base_Certificate_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Base_Certificate_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Base_Certificate_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Base_Certificate_CreatorId].ToString();
            if (fields.Contains(Parm_Base_Certificate_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Base_Certificate_CreateBy].ToString();
            if (fields.Contains(Parm_Base_Certificate_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Base_Certificate_CreateOn].ToString());
            if (fields.Contains(Parm_Base_Certificate_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Base_Certificate_UpdateId].ToString();
            if (fields.Contains(Parm_Base_Certificate_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Base_Certificate_UpdateBy].ToString();
            if (fields.Contains(Parm_Base_Certificate_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Base_Certificate_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="base_certificate">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(BaseCertificateEntity base_certificate, SqlParameter[] parms)
        {
            parms[0].Value = base_certificate.UserId;
            parms[1].Value = base_certificate.CertificateType;
            parms[2].Value = base_certificate.CertificateNo;
            parms[3].Value = base_certificate.LeaveRoleId;
            parms[4].Value = base_certificate.RowStatus;
            parms[5].Value = base_certificate.CreatorId;
            parms[6].Value = base_certificate.CreateBy;
            parms[7].Value = base_certificate.CreateOn;
            parms[8].Value = base_certificate.UpdateId;
            parms[9].Value = base_certificate.UpdateBy;
            parms[10].Value = base_certificate.UpdateOn;
            parms[11].Value = base_certificate.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(BaseCertificateEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Base_Certificate_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Base_Certificate_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_CertificateType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_CertificateNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_LeaveRoleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Base_Certificate_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Base_Certificate_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_Certificate_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Base_Certificate_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Base_Certificate_Insert, parms);
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

