//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionInstanceEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:35
//  功能描述：FE_ActionInstance表实体
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
    public class FeActionInstanceEntity : ModelImp.BaseModel<FeActionInstanceEntity>
    {
       	public FeActionInstanceEntity()
		{
			TB_Name = TB_FE_ActionInstance;
			Parm_Id = Parm_FE_ActionInstance_Id;
			Parm_Version = Parm_FE_ActionInstance_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FE_ActionInstance_Insert;
			Sql_Update = Sql_FE_ActionInstance_Update;
			Sql_Delete = Sql_FE_ActionInstance_Delete;
		}
       	#region Const of table FE_ActionInstance
		/// <summary>
		/// Table FE_ActionInstance
		/// </summary>
		public const string TB_FE_ActionInstance = "FE_ActionInstance";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ActionInstanceID
		/// </summary>
		public const string Parm_FE_ActionInstance_ActionInstanceID = "ActionInstanceID";
		/// <summary>
		/// Parm ActivityID
		/// </summary>
		public const string Parm_FE_ActionInstance_ActivityID = "ActivityID";
		/// <summary>
		/// Parm CommunityID
		/// </summary>
		public const string Parm_FE_ActionInstance_CommunityID = "CommunityID";
		/// <summary>
		/// Parm CommunityName
		/// </summary>
		public const string Parm_FE_ActionInstance_CommunityName = "CommunityName";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FE_ActionInstance_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FE_ActionInstance_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FE_ActionInstance_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FE_ActionInstance_Id = "Id";
		/// <summary>
		/// Parm IsUnlock
		/// </summary>
		public const string Parm_FE_ActionInstance_IsUnlock = "IsUnlock";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FE_ActionInstance_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FE_ActionInstance_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FE_ActionInstance_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FE_ActionInstance_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm UserID
		/// </summary>
		public const string Parm_FE_ActionInstance_UserID = "UserID";
		/// <summary>
		/// Parm UserName
		/// </summary>
		public const string Parm_FE_ActionInstance_UserName = "UserName";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FE_ActionInstance_Version = "Version";
		/// <summary>
		/// Insert Query Of FE_ActionInstance
		/// </summary>
		public const string Sql_FE_ActionInstance_Insert = "insert into FE_ActionInstance(ActionInstanceID,ActivityID,CommunityID,CommunityName,CreateBy,CreateOn,CreatorId,IsUnlock,RowStatus,UpdateBy,UpdateId,UpdateOn,UserID,UserName) values(@ActionInstanceID,@ActivityID,@CommunityID,@CommunityName,@CreateBy,@CreateOn,@CreatorId,@IsUnlock,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserID,@UserName);select @@identity;";
		/// <summary>
		/// Update Query Of FE_ActionInstance
		/// </summary>
		public const string Sql_FE_ActionInstance_Update = "update FE_ActionInstance set ActionInstanceID=@ActionInstanceID,ActivityID=@ActivityID,CommunityID=@CommunityID,CommunityName=@CommunityName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,IsUnlock=@IsUnlock,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserID=@UserID,UserName=@UserName where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_FE_ActionInstance_Delete = "update FE_ActionInstance set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _actionInstanceID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActionInstanceID
		{
			get{return _actionInstanceID ?? string.Empty;}
			set{_actionInstanceID = value;}
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
		private string _communityID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CommunityID
		{
			get{return _communityID ?? string.Empty;}
			set{_communityID = value;}
		}
		private string _communityName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CommunityName
		{
			get{return _communityName ?? string.Empty;}
			set{_communityName = value;}
		}
		private string _userID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			get{return _userID ?? string.Empty;}
			set{_userID = value;}
		}
		private string _userName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			get{return _userName ?? string.Empty;}
			set{_userName = value;}
		}
		private bool _isUnlock = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsUnlock
		{
			get{return _isUnlock;}
			set{_isUnlock = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FeActionInstanceEntity SetModelValueByDataRow(DataRow dr)
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
		public override FeActionInstanceEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeActionInstanceEntity();
          			if (fields.Contains(Parm_FE_ActionInstance_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FE_ActionInstance_Id].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_ActionInstanceID) || fields.Contains("*"))
				tmp.ActionInstanceID = dr[Parm_FE_ActionInstance_ActionInstanceID].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_ActivityID) || fields.Contains("*"))
				tmp.ActivityID = dr[Parm_FE_ActionInstance_ActivityID].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_CommunityID) || fields.Contains("*"))
				tmp.CommunityID = dr[Parm_FE_ActionInstance_CommunityID].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_CommunityName) || fields.Contains("*"))
				tmp.CommunityName = dr[Parm_FE_ActionInstance_CommunityName].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_UserID) || fields.Contains("*"))
				tmp.UserID = dr[Parm_FE_ActionInstance_UserID].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_UserName) || fields.Contains("*"))
				tmp.UserName = dr[Parm_FE_ActionInstance_UserName].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_IsUnlock) || fields.Contains("*"))
				tmp.IsUnlock = bool.Parse(dr[Parm_FE_ActionInstance_IsUnlock].ToString());
			if (fields.Contains(Parm_FE_ActionInstance_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FE_ActionInstance_RowStatus].ToString());
			if (fields.Contains(Parm_FE_ActionInstance_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FE_ActionInstance_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FE_ActionInstance_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FE_ActionInstance_CreatorId].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FE_ActionInstance_CreateBy].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FE_ActionInstance_CreateOn].ToString());
			if (fields.Contains(Parm_FE_ActionInstance_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FE_ActionInstance_UpdateId].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FE_ActionInstance_UpdateBy].ToString();
			if (fields.Contains(Parm_FE_ActionInstance_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_ActionInstance_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_actioninstance">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FeActionInstanceEntity fe_actioninstance, SqlParameter[] parms)
		{
            				parms[0].Value = fe_actioninstance.ActionInstanceID;
				parms[1].Value = fe_actioninstance.ActivityID;
				parms[2].Value = fe_actioninstance.CommunityID;
				parms[3].Value = fe_actioninstance.CommunityName;
				parms[4].Value = fe_actioninstance.UserID;
				parms[5].Value = fe_actioninstance.UserName;
				parms[6].Value = fe_actioninstance.IsUnlock;
				parms[7].Value = fe_actioninstance.RowStatus;
				parms[8].Value = fe_actioninstance.CreatorId;
				parms[9].Value = fe_actioninstance.CreateBy;
				parms[10].Value = fe_actioninstance.CreateOn;
				parms[11].Value = fe_actioninstance.UpdateId;
				parms[12].Value = fe_actioninstance.UpdateBy;
				parms[13].Value = fe_actioninstance.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FeActionInstanceEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_ActionInstance_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_ActionInstance_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_ActionInstance_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FE_ActionInstance_ActionInstanceID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_ActionInstance_ActivityID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_ActionInstance_CommunityID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_CommunityName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_UserID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_IsUnlock, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_ActionInstance_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_ActionInstance_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_ActionInstance_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_ActionInstance_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_ActionInstance_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
