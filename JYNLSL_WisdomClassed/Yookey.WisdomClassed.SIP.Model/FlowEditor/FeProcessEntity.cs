//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ProcessEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:34
//  功能描述：FE_Process表实体
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
    public class FeProcessEntity : ModelImp.BaseModel<FeProcessEntity>
    {
        public FeProcessEntity()
        {
            TB_Name = TB_FE_Process;
            Parm_Id = Parm_FE_Process_Id;
            Parm_Version = Parm_FE_Process_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FE_Process_Insert;
            Sql_Update = Sql_FE_Process_Update;
            Sql_Delete = Sql_FE_Process_Delete;
        }
        #region Const of table FE_Process
        /// <summary>
        /// Table FE_Process
        /// </summary>
        public const string TB_FE_Process = "FE_Process";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FE_Process_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateDate
        /// </summary>
        public const string Parm_FE_Process_CreateDate = "CreateDate";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FE_Process_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FE_Process_CreatorId = "CreatorId";
        /// <summary>
        /// Parm CVersion
        /// </summary>
        public const string Parm_FE_Process_CVersion = "CVersion";
        /// <summary>
        /// Parm FlowChart
        /// </summary>
        public const string Parm_FE_Process_FlowChart = "FlowChart";
        /// <summary>
        /// Parm FlowName
        /// </summary>
        public const string Parm_FE_Process_FlowName = "FlowName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FE_Process_Id = "Id";
        /// <summary>
        /// Parm IsUnlock
        /// </summary>
        public const string Parm_FE_Process_IsUnlock = "IsUnlock";
        /// <summary>
        /// Parm ProcessID
        /// </summary>
        public const string Parm_FE_Process_ProcessID = "ProcessID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FE_Process_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FE_Process_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FE_Process_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FE_Process_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FE_Process_Version = "Version";
        /// <summary>
        /// Insert Query Of FE_Process
        /// </summary>
        public const string Sql_FE_Process_Insert = "insert into FE_Process(CreateBy,CreateDate,CreateOn,CreatorId,CVersion,FlowChart,FlowName,IsUnlock,ProcessID,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateDate,@CreateOn,@CreatorId,@CVersion,@FlowChart,@FlowName,@IsUnlock,@ProcessID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
        /// <summary>
        /// Update Query Of FE_Process
        /// </summary>
        public const string Sql_FE_Process_Update = "update FE_Process set CreateBy=@CreateBy,CreateDate=@CreateDate,CreateOn=@CreateOn,CreatorId=@CreatorId,CVersion=@CVersion,FlowChart=@FlowChart,FlowName=@FlowName,IsUnlock=@IsUnlock,Id=@Id,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where ProcessId=@ProcessId ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FE_Process_Delete = "update FE_Process set RowStatus=0 where ProcessId=@ProcessId And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _processID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ProcessID
        {
            get { return _processID ?? string.Empty; }
            set { _processID = value; }
        }
        private string _flowName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FlowName
        {
            get { return _flowName ?? string.Empty; }
            set { _flowName = value; }
        }
        private string _flowChart = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FlowChart
        {
            get { return _flowChart ?? string.Empty; }
            set { _flowChart = value; }
        }
        private string _cVersion = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CVersion
        {
            get { return _cVersion ?? string.Empty; }
            set { _cVersion = value; }
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
        public override FeProcessEntity SetModelValueByDataRow(DataRow dr)
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
        public override FeProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeProcessEntity();
            if (fields.Contains(Parm_FE_Process_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FE_Process_Id].ToString();
            if (fields.Contains(Parm_FE_Process_ProcessID) || fields.Contains("*"))
                tmp.ProcessID = dr[Parm_FE_Process_ProcessID].ToString();
            if (fields.Contains(Parm_FE_Process_FlowName) || fields.Contains("*"))
                tmp.FlowName = dr[Parm_FE_Process_FlowName].ToString();
            if (fields.Contains(Parm_FE_Process_FlowChart) || fields.Contains("*"))
                tmp.FlowChart = dr[Parm_FE_Process_FlowChart].ToString();
            if (fields.Contains(Parm_FE_Process_CVersion) || fields.Contains("*"))
                tmp.CVersion = dr[Parm_FE_Process_CVersion].ToString();
            if (fields.Contains(Parm_FE_Process_IsUnlock) || fields.Contains("*"))
                tmp.IsUnlock = bool.Parse(dr[Parm_FE_Process_IsUnlock].ToString());
            if (fields.Contains(Parm_FE_Process_CreateDate) || fields.Contains("*"))
                tmp.CreateDate = DateTime.Parse(dr[Parm_FE_Process_CreateDate].ToString());
            if (fields.Contains(Parm_FE_Process_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FE_Process_RowStatus].ToString());
            if (fields.Contains(Parm_FE_Process_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FE_Process_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FE_Process_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FE_Process_CreatorId].ToString();
            if (fields.Contains(Parm_FE_Process_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FE_Process_CreateBy].ToString();
            if (fields.Contains(Parm_FE_Process_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FE_Process_CreateOn].ToString());
            if (fields.Contains(Parm_FE_Process_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FE_Process_UpdateId].ToString();
            if (fields.Contains(Parm_FE_Process_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FE_Process_UpdateBy].ToString();
            if (fields.Contains(Parm_FE_Process_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_Process_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_process">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FeProcessEntity fe_process, SqlParameter[] parms)
        {
            parms[0].Value = fe_process.ProcessID;
            parms[1].Value = fe_process.FlowName;
            parms[2].Value = fe_process.FlowChart;
            parms[3].Value = fe_process.CVersion;
            parms[4].Value = fe_process.IsUnlock;
            parms[5].Value = fe_process.CreateDate;
            parms[6].Value = fe_process.RowStatus;
            parms[7].Value = fe_process.CreatorId;
            parms[8].Value = fe_process.CreateBy;
            parms[9].Value = fe_process.CreateOn;
            parms[10].Value = fe_process.UpdateId;
            parms[11].Value = fe_process.UpdateBy;
            parms[12].Value = fe_process.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FeProcessEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_Process_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_Process_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Process_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FE_Process_ProcessID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Process_FlowName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_Process_FlowChart, SqlDbType.Text, 2147483647),
					new SqlParameter(Parm_FE_Process_CVersion, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_FE_Process_IsUnlock, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_Process_CreateDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_Process_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Process_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Process_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Process_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_Process_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Process_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Process_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Process_Insert, parms);
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

