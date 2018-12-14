//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseHandUsersEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-22 12:09:33
//  功能描述：LicenseHandUsers表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class LicenseHandUsersEntity : ModelImp.BaseModel<LicenseHandUsersEntity>
    {
        public LicenseHandUsersEntity()
        {
            TB_Name = TB_LicenseHandUsers;
            Parm_Id = Parm_LicenseHandUsers_Id;
            Parm_Version = Parm_LicenseHandUsers_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicenseHandUsers_Insert;
            Sql_Update = Sql_LicenseHandUsers_Update;
            Sql_Delete = Sql_LicenseHandUsers_Delete;
        }
        #region Const of table LicenseHandUsers
        /// <summary>
        /// Table LicenseHandUsers
        /// </summary>
        public const string TB_LicenseHandUsers = "LicenseHandUsers";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicenseHandUsers_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicenseHandUsers_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicenseHandUsers_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FormId
        /// </summary>
        public const string Parm_LicenseHandUsers_FormId = "FormId";
        /// <summary>
        /// Parm HandleDate
        /// </summary>
        public const string Parm_LicenseHandUsers_HandleDate = "HandleDate";
        /// <summary>
        /// Parm HandType
        /// </summary>
        public const string Parm_LicenseHandUsers_HandType = "HandType";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicenseHandUsers_Id = "Id";
        /// <summary>
        /// Parm IsHandle
        /// </summary>
        public const string Parm_LicenseHandUsers_IsHandle = "IsHandle";
        /// <summary>
        /// Parm MessageWorkId
        /// </summary>
        public const string Parm_LicenseHandUsers_MessageWorkId = "MessageWorkId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicenseHandUsers_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicenseHandUsers_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicenseHandUsers_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicenseHandUsers_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_LicenseHandUsers_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicenseHandUsers_Version = "Version";
        /// <summary>
        /// Insert Query Of LicenseHandUsers
        /// </summary>
        public const string Sql_LicenseHandUsers_Insert = "insert into LicenseHandUsers(CreateBy,CreateOn,CreatorId,FormId,HandleDate,HandType,IsHandle,MessageWorkId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,Id) values(@CreateBy,@CreateOn,@CreatorId,@FormId,@HandleDate,@HandType,@IsHandle,@MessageWorkId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicenseHandUsers
        /// </summary>
        public const string Sql_LicenseHandUsers_Update = "update LicenseHandUsers set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FormId=@FormId,HandleDate=@HandleDate,HandType=@HandType,IsHandle=@IsHandle,MessageWorkId=@MessageWorkId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicenseHandUsers_Delete = "update LicenseHandUsers set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _formId = string.Empty;
        /// <summary>
        /// 许可案件编号
        /// </summary>
        public string FormId
        {
            get { return _formId ?? string.Empty; }
            set { _formId = value; }
        }
        private string _messageWorkId = string.Empty;
        /// <summary>
        /// 关联的待办ID
        /// </summary>
        public string MessageWorkId
        {
            get { return _messageWorkId ?? string.Empty; }
            set { _messageWorkId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 人员ID
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private int _isHandle;
        /// <summary>
        /// 是否处理(1.处理 0.未处理)
        /// </summary>
        public int IsHandle
        {
            get { return _isHandle; }
            set { _isHandle = value; }
        }
        private DateTime _handleDate = MinDate;
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime HandleDate
        {
            get { return _handleDate; }
            set { _handleDate = value; }
        }
        private int _handType;
        /// <summary>
        /// 派送类型（1.踏勘派送 2.验收派送）
        /// </summary>
        public int HandType
        {
            get { return _handType; }
            set { _handType = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicenseHandUsersEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicenseHandUsersEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseHandUsersEntity();
            if (fields.Contains(Parm_LicenseHandUsers_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicenseHandUsers_Id].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_FormId) || fields.Contains("*"))
                tmp.FormId = dr[Parm_LicenseHandUsers_FormId].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_MessageWorkId) || fields.Contains("*"))
                tmp.MessageWorkId = dr[Parm_LicenseHandUsers_MessageWorkId].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_LicenseHandUsers_UserId].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_IsHandle) || fields.Contains("*"))
                tmp.IsHandle = int.Parse(dr[Parm_LicenseHandUsers_IsHandle].ToString());
            if (fields.Contains(Parm_LicenseHandUsers_HandleDate) || fields.Contains("*"))
                tmp.HandleDate = DateTime.Parse(dr[Parm_LicenseHandUsers_HandleDate].ToString());
            if (fields.Contains(Parm_LicenseHandUsers_HandType) || fields.Contains("*"))
                tmp.HandType = int.Parse(dr[Parm_LicenseHandUsers_HandType].ToString());
            if (fields.Contains(Parm_LicenseHandUsers_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicenseHandUsers_RowStatus].ToString());
            if (fields.Contains(Parm_LicenseHandUsers_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicenseHandUsers_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicenseHandUsers_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicenseHandUsers_CreatorId].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicenseHandUsers_CreateBy].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseHandUsers_CreateOn].ToString());
            if (fields.Contains(Parm_LicenseHandUsers_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicenseHandUsers_UpdateId].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicenseHandUsers_UpdateBy].ToString();
            if (fields.Contains(Parm_LicenseHandUsers_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseHandUsers_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensehandusers">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicenseHandUsersEntity licensehandusers, SqlParameter[] parms)
        {
            parms[0].Value = licensehandusers.FormId;
            parms[1].Value = licensehandusers.MessageWorkId;
            parms[2].Value = licensehandusers.UserId;
            parms[3].Value = licensehandusers.IsHandle;
            parms[4].Value = licensehandusers.HandleDate;
            parms[5].Value = licensehandusers.HandType;
            parms[6].Value = licensehandusers.RowStatus;
            parms[7].Value = licensehandusers.CreatorId;
            parms[8].Value = licensehandusers.CreateBy;
            parms[9].Value = licensehandusers.CreateOn;
            parms[10].Value = licensehandusers.UpdateId;
            parms[11].Value = licensehandusers.UpdateBy;
            parms[12].Value = licensehandusers.UpdateOn;
            parms[13].Value = licensehandusers.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseHandUsersEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseHandUsers_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicenseHandUsers_FormId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_MessageWorkId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_IsHandle, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseHandUsers_HandleDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseHandUsers_HandType, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseHandUsers_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseHandUsers_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseHandUsers_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseHandUsers_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseHandUsers_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseHandUsers_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }

    /// <summary>
    /// 设置人员请求
    /// </summary>
    public class LicenseHandUserIdRequest
    {
        /// <summary>
        /// 许可案件编号
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// 处理类型（1.踏勘 2.验收）
        /// </summary>
        public int HandType { get; set; }

        /// <summary>
        /// 设置人员集合
        /// </summary>
        public List<string> UserIds { get; set; }

        /// <summary>
        /// 派送人ID
        /// </summary>
        public string SendUserId { get; set; }
    }


    public class LicenseHandLimitsRequest
    {
        /// <summary>
        /// 许可案件编号
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// 处理类型（1.踏勘 2.验收）
        /// </summary>
        public int HandType { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string HandUserId { get; set; }
    }
}

