//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_WorkListEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:33
//  功能描述：FE_WorkList表实体
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
    public class FeWorkListEntity : ModelImp.BaseModel<FeWorkListEntity>
    {
       	public FeWorkListEntity()
		{
			TB_Name = TB_FE_WorkList;
			Parm_Id = Parm_FE_WorkList_Id;
			Parm_Version = Parm_FE_WorkList_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FE_WorkList_Insert;
			Sql_Update = Sql_FE_WorkList_Update;
			Sql_Delete = Sql_FE_WorkList_Delete;
		}
       	#region Const of table FE_WorkList
		/// <summary>
		/// Table FE_WorkList
		/// </summary>
		public const string TB_FE_WorkList = "FE_WorkList";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ActionerID
		/// </summary>
		public const string Parm_FE_WorkList_ActionerID = "ActionerID";
		/// <summary>
		/// Parm ActivityID
		/// </summary>
		public const string Parm_FE_WorkList_ActivityID = "ActivityID";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FE_WorkList_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FE_WorkList_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FE_WorkList_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Deleted
		/// </summary>
		public const string Parm_FE_WorkList_Deleted = "Deleted";
		/// <summary>
		/// Parm ExecuteDate
		/// </summary>
		public const string Parm_FE_WorkList_ExecuteDate = "ExecuteDate";
		/// <summary>
		/// Parm FormAddress
		/// </summary>
		public const string Parm_FE_WorkList_FormAddress = "FormAddress";
		/// <summary>
		/// Parm FormID
		/// </summary>
		public const string Parm_FE_WorkList_FormID = "FormID";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FE_WorkList_Id = "Id";
		/// <summary>
		/// Parm Idea
		/// </summary>
		public const string Parm_FE_WorkList_Idea = "Idea";
		/// <summary>
		/// Parm ProcessID
		/// </summary>
		public const string Parm_FE_WorkList_ProcessID = "ProcessID";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FE_WorkList_RowStatus = "RowStatus";
		/// <summary>
		/// Parm SenderDate
		/// </summary>
		public const string Parm_FE_WorkList_SenderDate = "SenderDate";
		/// <summary>
		/// Parm SenderID
		/// </summary>
		public const string Parm_FE_WorkList_SenderID = "SenderID";
		/// <summary>
		/// Parm Status
		/// </summary>
		public const string Parm_FE_WorkList_Status = "Status";
		/// <summary>
		/// Parm Titles
		/// </summary>
		public const string Parm_FE_WorkList_Titles = "Titles";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FE_WorkList_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FE_WorkList_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FE_WorkList_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FE_WorkList_Version = "Version";
		/// <summary>
		/// Parm WorkListID
		/// </summary>
		public const string Parm_FE_WorkList_WorkListID = "WorkListID";
		/// <summary>
		/// Insert Query Of FE_WorkList
		/// </summary>
		public const string Sql_FE_WorkList_Insert = "insert into FE_WorkList(ActionerID,ActivityID,CreateBy,CreateOn,CreatorId,Deleted,ExecuteDate,FormAddress,FormID,Idea,ProcessID,RowStatus,SenderDate,SenderID,Status,Titles,UpdateBy,UpdateId,UpdateOn,WorkListID) values(@ActionerID,@ActivityID,@CreateBy,@CreateOn,@CreatorId,@Deleted,@ExecuteDate,@FormAddress,@FormID,@Idea,@ProcessID,@RowStatus,@SenderDate,@SenderID,@Status,@Titles,@UpdateBy,@UpdateId,@UpdateOn,@WorkListID);select @@identity;";
		/// <summary>
		/// Update Query Of FE_WorkList
		/// </summary>
		public const string Sql_FE_WorkList_Update = "update FE_WorkList set ActionerID=@ActionerID,ActivityID=@ActivityID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Deleted=@Deleted,ExecuteDate=@ExecuteDate,FormAddress=@FormAddress,FormID=@FormID,Idea=@Idea,ProcessID=@ProcessID,RowStatus=@RowStatus,SenderDate=@SenderDate,SenderID=@SenderID,Status=@Status,Titles=@Titles,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WorkListID=@WorkListID where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_FE_WorkList_Delete = "update FE_WorkList set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _workListID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string WorkListID
		{
			get{return _workListID ?? string.Empty;}
			set{_workListID = value;}
		}
		private string _titles = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Titles
		{
			get{return _titles ?? string.Empty;}
			set{_titles = value;}
		}
		private string _processID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ProcessID
		{
			get{return _processID ?? string.Empty;}
			set{_processID = value;}
		}
		private string _activityID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActivityID
		{
			get{return _activityID ?? string.Empty;}
			set{_activityID = value;}
		}
		private string _senderID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string SenderID
		{
			get{return _senderID ?? string.Empty;}
			set{_senderID = value;}
		}
		private DateTime _senderDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime SenderDate
		{
			get{return _senderDate;}
			set{_senderDate = value;}
		}
		private string _actionerID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActionerID
		{
			get{return _actionerID ?? string.Empty;}
			set{_actionerID = value;}
		}
		private string _formID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FormID
		{
			get{return _formID ?? string.Empty;}
			set{_formID = value;}
		}
		private string _formAddress = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FormAddress
		{
			get{return _formAddress ?? string.Empty;}
			set{_formAddress = value;}
		}
		private string _idea = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Idea
		{
			get{return _idea ?? string.Empty;}
			set{_idea = value;}
		}
		private DateTime _executeDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime ExecuteDate
		{
			get{return _executeDate;}
			set{_executeDate = value;}
		}
		private int _status;
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			get{return _status;}
			set{_status = value;}
		}
		private bool _deleted = false;
		/// <summary>
		/// 
		/// </summary>
		public bool Deleted
		{
			get{return _deleted;}
			set{_deleted = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FeWorkListEntity SetModelValueByDataRow(DataRow dr)
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
		public override FeWorkListEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeWorkListEntity();
          			if (fields.Contains(Parm_FE_WorkList_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FE_WorkList_Id].ToString();
			if (fields.Contains(Parm_FE_WorkList_WorkListID) || fields.Contains("*"))
				tmp.WorkListID = dr[Parm_FE_WorkList_WorkListID].ToString();
			if (fields.Contains(Parm_FE_WorkList_Titles) || fields.Contains("*"))
				tmp.Titles = dr[Parm_FE_WorkList_Titles].ToString();
			if (fields.Contains(Parm_FE_WorkList_ProcessID) || fields.Contains("*"))
				tmp.ProcessID = dr[Parm_FE_WorkList_ProcessID].ToString();
			if (fields.Contains(Parm_FE_WorkList_ActivityID) || fields.Contains("*"))
				tmp.ActivityID = dr[Parm_FE_WorkList_ActivityID].ToString();
			if (fields.Contains(Parm_FE_WorkList_SenderID) || fields.Contains("*"))
				tmp.SenderID = dr[Parm_FE_WorkList_SenderID].ToString();
			if (fields.Contains(Parm_FE_WorkList_SenderDate) || fields.Contains("*"))
				tmp.SenderDate = DateTime.Parse(dr[Parm_FE_WorkList_SenderDate].ToString());
			if (fields.Contains(Parm_FE_WorkList_ActionerID) || fields.Contains("*"))
				tmp.ActionerID = dr[Parm_FE_WorkList_ActionerID].ToString();
			if (fields.Contains(Parm_FE_WorkList_FormID) || fields.Contains("*"))
				tmp.FormID = dr[Parm_FE_WorkList_FormID].ToString();
			if (fields.Contains(Parm_FE_WorkList_FormAddress) || fields.Contains("*"))
				tmp.FormAddress = dr[Parm_FE_WorkList_FormAddress].ToString();
			if (fields.Contains(Parm_FE_WorkList_Idea) || fields.Contains("*"))
				tmp.Idea = dr[Parm_FE_WorkList_Idea].ToString();
			if (fields.Contains(Parm_FE_WorkList_ExecuteDate) || fields.Contains("*"))
				tmp.ExecuteDate = DateTime.Parse(dr[Parm_FE_WorkList_ExecuteDate].ToString());
			if (fields.Contains(Parm_FE_WorkList_Status) || fields.Contains("*"))
				tmp.Status = int.Parse(dr[Parm_FE_WorkList_Status].ToString());
			if (fields.Contains(Parm_FE_WorkList_Deleted) || fields.Contains("*"))
				tmp.Deleted = bool.Parse(dr[Parm_FE_WorkList_Deleted].ToString());
			if (fields.Contains(Parm_FE_WorkList_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FE_WorkList_RowStatus].ToString());
			if (fields.Contains(Parm_FE_WorkList_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FE_WorkList_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FE_WorkList_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FE_WorkList_CreatorId].ToString();
			if (fields.Contains(Parm_FE_WorkList_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FE_WorkList_CreateBy].ToString();
			if (fields.Contains(Parm_FE_WorkList_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FE_WorkList_CreateOn].ToString());
			if (fields.Contains(Parm_FE_WorkList_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FE_WorkList_UpdateId].ToString();
			if (fields.Contains(Parm_FE_WorkList_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FE_WorkList_UpdateBy].ToString();
			if (fields.Contains(Parm_FE_WorkList_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_WorkList_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_worklist">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FeWorkListEntity fe_worklist, SqlParameter[] parms)
		{
            				parms[0].Value = fe_worklist.WorkListID;
				parms[1].Value = fe_worklist.Titles;
				parms[2].Value = fe_worklist.ProcessID;
				parms[3].Value = fe_worklist.ActivityID;
				parms[4].Value = fe_worklist.SenderID;
				parms[5].Value = fe_worklist.SenderDate;
				parms[6].Value = fe_worklist.ActionerID;
				parms[7].Value = fe_worklist.FormID;
				parms[8].Value = fe_worklist.FormAddress;
				parms[9].Value = fe_worklist.Idea;
				parms[10].Value = fe_worklist.ExecuteDate;
				parms[11].Value = fe_worklist.Status;
				parms[12].Value = fe_worklist.Deleted;
				parms[13].Value = fe_worklist.RowStatus;
				parms[14].Value = fe_worklist.CreatorId;
				parms[15].Value = fe_worklist.CreateBy;
				parms[16].Value = fe_worklist.CreateOn;
				parms[17].Value = fe_worklist.UpdateId;
				parms[18].Value = fe_worklist.UpdateBy;
				parms[19].Value = fe_worklist.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FeWorkListEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_WorkList_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_WorkList_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_WorkList_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FE_WorkList_WorkListID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_WorkList_Titles, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_ProcessID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_WorkList_ActivityID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_WorkList_SenderID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_SenderDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_WorkList_ActionerID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_FormID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_FormAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_WorkList_Idea, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_FE_WorkList_ExecuteDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_WorkList_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_WorkList_Deleted, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_WorkList_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_WorkList_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_WorkList_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_WorkList_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_WorkList_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
