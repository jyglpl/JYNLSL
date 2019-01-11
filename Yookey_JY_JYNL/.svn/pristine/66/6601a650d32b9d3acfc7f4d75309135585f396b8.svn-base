//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_RuleCodeEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:33
//  功能描述：FE_RuleCode表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.FlowEditor
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FeRuleCodeEntity : ModelImp.BaseModel<FeRuleCodeEntity>
    {
        public FeRuleCodeEntity()
        {
            TB_Name = TB_FE_RuleCode;
            Parm_Id = Parm_FE_RuleCode_Id;
            Parm_Version = Parm_FE_RuleCode_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FE_RuleCode_Insert;
            Sql_Update = Sql_FE_RuleCode_Update;
            Sql_Delete = Sql_FE_RuleCode_Delete;
        }
        #region Const of table FE_RuleCode
        /// <summary>
        /// Table FE_RuleCode
        /// </summary>
        public const string TB_FE_RuleCode = "FE_RuleCode";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ActivityID
        /// </summary>
        public const string Parm_FE_RuleCode_ActivityID = "ActivityID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FE_RuleCode_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateDate
        /// </summary>
        public const string Parm_FE_RuleCode_CreateDate = "CreateDate";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FE_RuleCode_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FE_RuleCode_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FulfillAssemblyName
        /// </summary>
        public const string Parm_FE_RuleCode_FulfillAssemblyName = "FulfillAssemblyName";
        /// <summary>
        /// Parm FulfillClassFullName
        /// </summary>
        public const string Parm_FE_RuleCode_FulfillClassFullName = "FulfillClassFullName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FE_RuleCode_Id = "Id";
        /// <summary>
        /// Parm IsUnlock
        /// </summary>
        public const string Parm_FE_RuleCode_IsUnlock = "IsUnlock";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_FE_RuleCode_Remark = "Remark";
        /// <summary>
        /// Parm RiolationRuleID
        /// </summary>
        public const string Parm_FE_RuleCode_RiolationRuleID = "RiolationRuleID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FE_RuleCode_RowStatus = "RowStatus";
        /// <summary>
        /// Parm RuleClauses
        /// </summary>
        public const string Parm_FE_RuleCode_RuleClauses = "RuleClauses";
        /// <summary>
        /// Parm RuleCodeID
        /// </summary>
        public const string Parm_FE_RuleCode_RuleCodeID = "RuleCodeID";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FE_RuleCode_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FE_RuleCode_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FE_RuleCode_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FE_RuleCode_Version = "Version";
        /// <summary>
        /// Insert Query Of FE_RuleCode
        /// </summary>
        public const string Sql_FE_RuleCode_Insert = "insert into FE_RuleCode(ActivityID,CreateBy,CreateDate,CreateOn,CreatorId,FulfillAssemblyName,FulfillClassFullName,IsUnlock,Remark,RiolationRuleID,RowStatus,RuleClauses,RuleCodeID,UpdateBy,UpdateId,UpdateOn) values(@ActivityID,@CreateBy,@CreateDate,@CreateOn,@CreatorId,@FulfillAssemblyName,@FulfillClassFullName,@IsUnlock,@Remark,@RiolationRuleID,@RowStatus,@RuleClauses,@RuleCodeID,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
        /// <summary>
        /// Update Query Of FE_RuleCode
        /// </summary>
        public const string Sql_FE_RuleCode_Update = "update FE_RuleCode set ActivityID=@ActivityID,CreateBy=@CreateBy,CreateDate=@CreateDate,CreateOn=@CreateOn,CreatorId=@CreatorId,FulfillAssemblyName=@FulfillAssemblyName,FulfillClassFullName=@FulfillClassFullName,IsUnlock=@IsUnlock,Remark=@Remark,RiolationRuleID=@RiolationRuleID,RowStatus=@RowStatus,RuleClauses=@RuleClauses,RuleCodeID=@RuleCodeID,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FE_RuleCode_Delete = "update FE_RuleCode set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _ruleCodeID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RuleCodeID
        {
            get { return _ruleCodeID ?? string.Empty; }
            set { _ruleCodeID = value; }
        }
        private string _activityID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ActivityID
        {
            get { return _activityID ?? string.Empty; }
            set { _activityID = value; }
        }
        private string _ruleClauses = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RuleClauses
        {
            get { return _ruleClauses ?? string.Empty; }
            set { _ruleClauses = value; }
        }
        private string _riolationRuleID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RiolationRuleID
        {
            get { return _riolationRuleID ?? string.Empty; }
            set { _riolationRuleID = value; }
        }
        private string _fulfillAssemblyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FulfillAssemblyName
        {
            get { return _fulfillAssemblyName ?? string.Empty; }
            set { _fulfillAssemblyName = value; }
        }
        private string _fulfillClassFullName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FulfillClassFullName
        {
            get { return _fulfillClassFullName ?? string.Empty; }
            set { _fulfillClassFullName = value; }
        }
        private bool _isUnlock = false;
        /// <summary>
        /// 
        /// </summary>
        public bool IsUnlock
        {
            get { return _isUnlock; }
            set { _isUnlock = value; }
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
        private DateTime _createDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FeRuleCodeEntity SetModelValueByDataRow(DataRow dr)
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
        public override FeRuleCodeEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeRuleCodeEntity();
            if (fields.Contains(Parm_FE_RuleCode_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FE_RuleCode_Id].ToString();
            if (fields.Contains(Parm_FE_RuleCode_RuleCodeID) || fields.Contains("*"))
                tmp.RuleCodeID = dr[Parm_FE_RuleCode_RuleCodeID].ToString();
            if (fields.Contains(Parm_FE_RuleCode_ActivityID) || fields.Contains("*"))
                tmp.ActivityID = dr[Parm_FE_RuleCode_ActivityID].ToString();
            if (fields.Contains(Parm_FE_RuleCode_RuleClauses) || fields.Contains("*"))
                tmp.RuleClauses = dr[Parm_FE_RuleCode_RuleClauses].ToString();
            if (fields.Contains(Parm_FE_RuleCode_RiolationRuleID) || fields.Contains("*"))
                tmp.RiolationRuleID = dr[Parm_FE_RuleCode_RiolationRuleID].ToString();
            if (fields.Contains(Parm_FE_RuleCode_FulfillAssemblyName) || fields.Contains("*"))
                tmp.FulfillAssemblyName = dr[Parm_FE_RuleCode_FulfillAssemblyName].ToString();
            if (fields.Contains(Parm_FE_RuleCode_FulfillClassFullName) || fields.Contains("*"))
                tmp.FulfillClassFullName = dr[Parm_FE_RuleCode_FulfillClassFullName].ToString();
            if (fields.Contains(Parm_FE_RuleCode_IsUnlock) || fields.Contains("*"))
                tmp.IsUnlock = bool.Parse(dr[Parm_FE_RuleCode_IsUnlock].ToString());
            if (fields.Contains(Parm_FE_RuleCode_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_FE_RuleCode_Remark].ToString();
            if (fields.Contains(Parm_FE_RuleCode_CreateDate) || fields.Contains("*"))
                tmp.CreateDate = DateTime.Parse(dr[Parm_FE_RuleCode_CreateDate].ToString());
            if (fields.Contains(Parm_FE_RuleCode_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FE_RuleCode_RowStatus].ToString());
            if (fields.Contains(Parm_FE_RuleCode_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FE_RuleCode_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FE_RuleCode_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FE_RuleCode_CreatorId].ToString();
            if (fields.Contains(Parm_FE_RuleCode_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FE_RuleCode_CreateBy].ToString();
            if (fields.Contains(Parm_FE_RuleCode_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FE_RuleCode_CreateOn].ToString());
            if (fields.Contains(Parm_FE_RuleCode_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FE_RuleCode_UpdateId].ToString();
            if (fields.Contains(Parm_FE_RuleCode_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FE_RuleCode_UpdateBy].ToString();
            if (fields.Contains(Parm_FE_RuleCode_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_RuleCode_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_rulecode">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FeRuleCodeEntity fe_rulecode, SqlParameter[] parms)
        {
            parms[0].Value = fe_rulecode.RuleCodeID;
            parms[1].Value = fe_rulecode.ActivityID;
            parms[2].Value = fe_rulecode.RuleClauses;
            parms[3].Value = fe_rulecode.RiolationRuleID;
            parms[4].Value = fe_rulecode.FulfillAssemblyName;
            parms[5].Value = fe_rulecode.FulfillClassFullName;
            parms[6].Value = fe_rulecode.IsUnlock;
            parms[7].Value = fe_rulecode.Remark;
            parms[8].Value = fe_rulecode.CreateDate;
            parms[9].Value = fe_rulecode.RowStatus;
            parms[10].Value = fe_rulecode.CreatorId;
            parms[11].Value = fe_rulecode.CreateBy;
            parms[12].Value = fe_rulecode.CreateOn;
            parms[13].Value = fe_rulecode.UpdateId;
            parms[14].Value = fe_rulecode.UpdateBy;
            parms[15].Value = fe_rulecode.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FeRuleCodeEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_RuleCode_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_RuleCode_Version, model.Version);
            return parms;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_RuleCode_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FE_RuleCode_RuleCodeID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_RuleCode_ActivityID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_RuleCode_RuleClauses, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_FE_RuleCode_RiolationRuleID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_RuleCode_FulfillAssemblyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_RuleCode_FulfillClassFullName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_FE_RuleCode_IsUnlock, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_RuleCode_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_RuleCode_CreateDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_RuleCode_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_RuleCode_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_RuleCode_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_RuleCode_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_RuleCode_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_RuleCode_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_RuleCode_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_RuleCode_Insert, parms);
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

