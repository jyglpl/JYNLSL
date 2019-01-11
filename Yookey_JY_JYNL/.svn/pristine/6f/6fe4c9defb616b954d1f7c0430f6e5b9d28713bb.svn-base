//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WF_ProcessEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/8 16:15:10
//  功能描述：WF_Process表实体
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
    public class WfProcessEntity : ModelImp.BaseModel<WfProcessEntity>
    {
       	public WfProcessEntity()
		{
			TB_Name = TB_WF_Process;
			Parm_Id = Parm_WF_Process_Id;
			Parm_Version = Parm_WF_Process_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_WF_Process_Insert;
			Sql_Update = Sql_WF_Process_Update;
			Sql_Delete = Sql_WF_Process_Delete;
		}
       	#region Const of table WF_Process
		/// <summary>
		/// Table WF_Process
		/// </summary>
		public const string TB_WF_Process = "WF_Process";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_WF_Process_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_WF_Process_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_WF_Process_CreatorId = "CreatorId";
		/// <summary>
		/// Parm CVersion
		/// </summary>
		public const string Parm_WF_Process_CVersion = "CVersion";
		/// <summary>
		/// Parm Description
		/// </summary>
		public const string Parm_WF_Process_Description = "Description";
		/// <summary>
		/// Parm EscalationRule
		/// </summary>
		public const string Parm_WF_Process_EscalationRule = "EscalationRule";
		/// <summary>
		/// Parm EscalationTime
		/// </summary>
		public const string Parm_WF_Process_EscalationTime = "EscalationTime";
		/// <summary>
		/// Parm FullName
		/// </summary>
		public const string Parm_WF_Process_FullName = "FullName";
		/// <summary>
		/// Parm Height
		/// </summary>
		public const string Parm_WF_Process_Height = "Height";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_WF_Process_Id = "Id";
		/// <summary>
		/// Parm IsCurrentVersion
		/// </summary>
		public const string Parm_WF_Process_IsCurrentVersion = "IsCurrentVersion";
		/// <summary>
		/// Parm MessageType
		/// </summary>
		public const string Parm_WF_Process_MessageType = "MessageType";
		/// <summary>
		/// Parm Name
		/// </summary>
		public const string Parm_WF_Process_Name = "Name";
		/// <summary>
		/// Parm ProjectSource
		/// </summary>
		public const string Parm_WF_Process_ProjectSource = "ProjectSource";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_WF_Process_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_WF_Process_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_WF_Process_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_WF_Process_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_WF_Process_Version = "Version";
		/// <summary>
		/// Parm Width
		/// </summary>
		public const string Parm_WF_Process_Width = "Width";
		/// <summary>
		/// Insert Query Of WF_Process
		/// </summary>
		public const string Sql_WF_Process_Insert = "insert into WF_Process(CreateBy,CreateOn,CreatorId,CVersion,Description,EscalationRule,EscalationTime,FullName,Height,IsCurrentVersion,MessageType,Name,ProjectSource,RowStatus,UpdateBy,UpdateId,UpdateOn,Width) values(@CreateBy,@CreateOn,@CreatorId,@CVersion,@Description,@EscalationRule,@EscalationTime,@FullName,@Height,@IsCurrentVersion,@MessageType,@Name,@ProjectSource,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Width);select @@identity;";
		/// <summary>
		/// Update Query Of WF_Process
		/// </summary>
		public const string Sql_WF_Process_Update = "update WF_Process set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,CVersion=@CVersion,Description=@Description,EscalationRule=@EscalationRule,EscalationTime=@EscalationTime,FullName=@FullName,Height=@Height,IsCurrentVersion=@IsCurrentVersion,MessageType=@MessageType,Name=@Name,ProjectSource=@ProjectSource,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Width=@Width where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_WF_Process_Delete = "update WF_Process set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _name = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get{return _name ?? string.Empty;}
			set{_name = value;}
		}
		private string _fullName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			get{return _fullName ?? string.Empty;}
			set{_fullName = value;}
		}
		private string _description = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get{return _description ?? string.Empty;}
			set{_description = value;}
		}
		private string _cVersion = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CVersion
		{
			get{return _cVersion ?? string.Empty;}
			set{_cVersion = value;}
		}
		private string _projectSource = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ProjectSource
		{
			get{return _projectSource ?? string.Empty;}
			set{_projectSource = value;}
		}
		private string _escalationTime = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string EscalationTime
		{
			get{return _escalationTime ?? string.Empty;}
			set{_escalationTime = value;}
		}
		private string _escalationRule = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string EscalationRule
		{
			get{return _escalationRule ?? string.Empty;}
			set{_escalationRule = value;}
		}
		private string _isCurrentVersion = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string IsCurrentVersion
		{
			get{return _isCurrentVersion ?? string.Empty;}
			set{_isCurrentVersion = value;}
		}
		private string _messageType = string.Empty;
		/// <summary>
		/// 消息类型
		/// </summary>
		public string MessageType
		{
			get{return _messageType ?? string.Empty;}
			set{_messageType = value;}
		}
		private int _width;
		/// <summary>
		/// 
		/// </summary>
		public int Width
		{
			get{return _width;}
			set{_width = value;}
		}
		private string _height = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Height
		{
			get{return _height ?? string.Empty;}
			set{_height = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override WfProcessEntity SetModelValueByDataRow(DataRow dr)
      	{
            IList<string> fields = new List<string> {"*"};
   	    	return SetModelValueByDataRow(dr,fields);
        }

		/// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
		public override WfProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WfProcessEntity();
          			if (fields.Contains(Parm_WF_Process_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_WF_Process_Id].ToString();
			if (fields.Contains(Parm_WF_Process_Name) || fields.Contains("*"))
				tmp.Name = dr[Parm_WF_Process_Name].ToString();
			if (fields.Contains(Parm_WF_Process_FullName) || fields.Contains("*"))
				tmp.FullName = dr[Parm_WF_Process_FullName].ToString();
			if (fields.Contains(Parm_WF_Process_Description) || fields.Contains("*"))
				tmp.Description = dr[Parm_WF_Process_Description].ToString();
			if (fields.Contains(Parm_WF_Process_CVersion) || fields.Contains("*"))
				tmp.CVersion = dr[Parm_WF_Process_CVersion].ToString();
			if (fields.Contains(Parm_WF_Process_ProjectSource) || fields.Contains("*"))
				tmp.ProjectSource = dr[Parm_WF_Process_ProjectSource].ToString();
			if (fields.Contains(Parm_WF_Process_EscalationTime) || fields.Contains("*"))
				tmp.EscalationTime = dr[Parm_WF_Process_EscalationTime].ToString();
			if (fields.Contains(Parm_WF_Process_EscalationRule) || fields.Contains("*"))
				tmp.EscalationRule = dr[Parm_WF_Process_EscalationRule].ToString();
			if (fields.Contains(Parm_WF_Process_IsCurrentVersion) || fields.Contains("*"))
				tmp.IsCurrentVersion = dr[Parm_WF_Process_IsCurrentVersion].ToString();
			if (fields.Contains(Parm_WF_Process_MessageType) || fields.Contains("*"))
				tmp.MessageType = dr[Parm_WF_Process_MessageType].ToString();
			if (fields.Contains(Parm_WF_Process_Width) || fields.Contains("*"))
				tmp.Width = int.Parse(dr[Parm_WF_Process_Width].ToString());
			if (fields.Contains(Parm_WF_Process_Height) || fields.Contains("*"))
				tmp.Height = dr[Parm_WF_Process_Height].ToString();
			if (fields.Contains(Parm_WF_Process_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_WF_Process_RowStatus].ToString());
			if (fields.Contains(Parm_WF_Process_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_WF_Process_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_WF_Process_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_WF_Process_CreatorId].ToString();
			if (fields.Contains(Parm_WF_Process_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_WF_Process_CreateBy].ToString();
			if (fields.Contains(Parm_WF_Process_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_WF_Process_CreateOn].ToString());
			if (fields.Contains(Parm_WF_Process_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_WF_Process_UpdateId].ToString();
			if (fields.Contains(Parm_WF_Process_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_WF_Process_UpdateBy].ToString();
			if (fields.Contains(Parm_WF_Process_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_WF_Process_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wf_process">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(WfProcessEntity wf_process, SqlParameter[] parms)
		{
            				parms[0].Value = wf_process.Name;
				parms[1].Value = wf_process.FullName;
				parms[2].Value = wf_process.Description;
				parms[3].Value = wf_process.CVersion;
				parms[4].Value = wf_process.ProjectSource;
				parms[5].Value = wf_process.EscalationTime;
				parms[6].Value = wf_process.EscalationRule;
				parms[7].Value = wf_process.IsCurrentVersion;
				parms[8].Value = wf_process.MessageType;
				parms[9].Value = wf_process.Width;
				parms[10].Value = wf_process.Height;
				parms[11].Value = wf_process.RowStatus;
				parms[12].Value = wf_process.CreatorId;
				parms[13].Value = wf_process.CreateBy;
				parms[14].Value = wf_process.CreateOn;
				parms[15].Value = wf_process.UpdateId;
				parms[16].Value = wf_process.UpdateBy;
				parms[17].Value = wf_process.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(WfProcessEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WF_Process_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WF_Process_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WF_Process_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_WF_Process_Name, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_WF_Process_FullName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_WF_Process_Description, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_WF_Process_CVersion, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_ProjectSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_EscalationTime, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_EscalationRule, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_IsCurrentVersion, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_MessageType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_Width, SqlDbType.Int, 10),
					new SqlParameter(Parm_WF_Process_Height, SqlDbType.NChar, 10),
					new SqlParameter(Parm_WF_Process_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WF_Process_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WF_Process_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WF_Process_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WF_Process_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
