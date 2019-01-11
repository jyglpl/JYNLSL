//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WF_ProcessInstanceEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 15:35:02
//  功能描述：WF_ProcessInstance表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.WorkFlow
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WfProcessInstanceEntity : ModelImp.BaseModel<WfProcessInstanceEntity>
    {
        public WfProcessInstanceEntity()
        {
            TB_Name = TB_WF_ProcessInstance;
            Parm_Id = Parm_WF_ProcessInstance_Id;
            Parm_Version = Parm_WF_ProcessInstance_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WF_ProcessInstance_Insert;
            Sql_Update = Sql_WF_ProcessInstance_Update;
            Sql_Delete = Sql_WF_ProcessInstance_Delete;
        }
        #region Const of table WF_ProcessInstance
        /// <summary>
        /// Table WF_ProcessInstance
        /// </summary>
        public const string TB_WF_ProcessInstance = "WF_ProcessInstance";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WF_ProcessInstance_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WF_ProcessInstance_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WF_ProcessInstance_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        public const string Parm_WF_ProcessInstance_EndDate = "EndDate";
        /// <summary>
        /// Parm FormData
        /// </summary>
        public const string Parm_WF_ProcessInstance_FormData = "FormData";
        /// <summary>
        /// Parm FormID
        /// </summary>
        public const string Parm_WF_ProcessInstance_FormID = "FormID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WF_ProcessInstance_Id = "Id";
        /// <summary>
        /// Parm Originator
        /// </summary>
        public const string Parm_WF_ProcessInstance_Originator = "Originator";
        /// <summary>
        /// Parm ProcessID
        /// </summary>
        public const string Parm_WF_ProcessInstance_ProcessID = "ProcessID";
        /// <summary>
        /// Parm Rounds
        /// </summary>
        public const string Parm_WF_ProcessInstance_Rounds = "Rounds";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WF_ProcessInstance_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        public const string Parm_WF_ProcessInstance_StartDate = "StartDate";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_WF_ProcessInstance_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WF_ProcessInstance_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WF_ProcessInstance_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WF_ProcessInstance_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WF_ProcessInstance_Version = "Version";
        /// <summary>
        /// Insert Query Of WF_ProcessInstance
        /// </summary>
        public const string Sql_WF_ProcessInstance_Insert = "insert into WF_ProcessInstance(CreateBy,CreateOn,CreatorId,EndDate,FormData,FormID,Originator,ProcessID,Rounds,RowStatus,StartDate,Status,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@EndDate,@FormData,@FormID,@Originator,@ProcessID,@Rounds,@RowStatus,@StartDate,@Status,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of WF_ProcessInstance
        /// </summary>
        public const string Sql_WF_ProcessInstance_Update = "update WF_ProcessInstance set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndDate=@EndDate,FormData=@FormData,FormID=@FormID,Originator=@Originator,ProcessID=@ProcessID,Rounds=@Rounds,RowStatus=@RowStatus,StartDate=@StartDate,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WF_ProcessInstance_Delete = "update WF_ProcessInstance set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _processID = string.Empty;
        /// <summary>
        /// 流程编号
        /// </summary>
        public string ProcessID
        {
            get { return _processID ?? string.Empty; }
            set { _processID = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private string _originator = string.Empty;
        /// <summary>
        /// 发启人
        /// </summary>
        public string Originator
        {
            get { return _originator ?? string.Empty; }
            set { _originator = value; }
        }
        private int _status;
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _formID = string.Empty;
        /// <summary>
        /// 表单编号
        /// </summary>
        public string FormID
        {
            get { return _formID ?? string.Empty; }
            set { _formID = value; }
        }
        private string _formData = string.Empty;
        /// <summary>
        /// 开启流程意见
        /// </summary>
        public string FormData
        {
            get { return _formData ?? string.Empty; }
            set { _formData = value; }
        }
        private DateTime _endDate = MinDate;
        /// <summary>
        /// 流程结束日期
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        private int _rounds;
        /// <summary>
        /// 
        /// </summary>
        public int Rounds
        {
            get { return _rounds; }
            set { _rounds = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WfProcessInstanceEntity SetModelValueByDataRow(DataRow dr)
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
        public override WfProcessInstanceEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WfProcessInstanceEntity();
            if (fields.Contains(Parm_WF_ProcessInstance_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WF_ProcessInstance_Id].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_ProcessID) || fields.Contains("*"))
                tmp.ProcessID = dr[Parm_WF_ProcessInstance_ProcessID].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_StartDate) || fields.Contains("*"))
                tmp.StartDate = DateTime.Parse(dr[Parm_WF_ProcessInstance_StartDate].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_Originator) || fields.Contains("*"))
                tmp.Originator = dr[Parm_WF_ProcessInstance_Originator].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_Status) || fields.Contains("*"))
                tmp.Status = int.Parse(dr[Parm_WF_ProcessInstance_Status].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_FormID) || fields.Contains("*"))
                tmp.FormID = dr[Parm_WF_ProcessInstance_FormID].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_FormData) || fields.Contains("*"))
                tmp.FormData = dr[Parm_WF_ProcessInstance_FormData].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_EndDate) || fields.Contains("*"))
                tmp.EndDate = DateTime.Parse(dr[Parm_WF_ProcessInstance_EndDate].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_Rounds) || fields.Contains("*"))
                tmp.Rounds = int.Parse(dr[Parm_WF_ProcessInstance_Rounds].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WF_ProcessInstance_RowStatus].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WF_ProcessInstance_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WF_ProcessInstance_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WF_ProcessInstance_CreatorId].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WF_ProcessInstance_CreateBy].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WF_ProcessInstance_CreateOn].ToString());
            if (fields.Contains(Parm_WF_ProcessInstance_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WF_ProcessInstance_UpdateId].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WF_ProcessInstance_UpdateBy].ToString();
            if (fields.Contains(Parm_WF_ProcessInstance_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WF_ProcessInstance_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wf_processinstance">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WfProcessInstanceEntity wf_processinstance, SqlParameter[] parms)
        {
            parms[0].Value = wf_processinstance.ProcessID;
            parms[1].Value = wf_processinstance.StartDate;
            parms[2].Value = wf_processinstance.Originator;
            parms[3].Value = wf_processinstance.Status;
            parms[4].Value = wf_processinstance.FormID;
            parms[5].Value = wf_processinstance.FormData;
            parms[6].Value = wf_processinstance.EndDate;
            parms[7].Value = wf_processinstance.Rounds;
            parms[8].Value = wf_processinstance.RowStatus;
            parms[9].Value = wf_processinstance.CreatorId;
            parms[10].Value = wf_processinstance.CreateBy;
            parms[11].Value = wf_processinstance.CreateOn;
            parms[12].Value = wf_processinstance.UpdateId;
            parms[13].Value = wf_processinstance.UpdateBy;
            parms[14].Value = wf_processinstance.UpdateOn;
            parms[15].Value = wf_processinstance.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WfProcessInstanceEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }

            //parms[parms.Length - 2] = new SqlParameter(Parm_WF_ProcessInstance_Id, model.Id);
            //parms[parms.Length - 1] = new SqlParameter(Parm_WF_ProcessInstance_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WF_ProcessInstance_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WF_ProcessInstance_ProcessID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WF_ProcessInstance_Originator, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_WF_ProcessInstance_FormID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_FormData, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WF_ProcessInstance_Rounds, SqlDbType.Int, 10),
					new SqlParameter(Parm_WF_ProcessInstance_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WF_ProcessInstance_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WF_ProcessInstance_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_ProcessInstance_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_WF_ProcessInstance_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WF_ProcessInstance_Insert, parms);
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

