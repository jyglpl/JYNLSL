//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_PickupUserEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:35
//  功能描述：FE_PickupUser表实体
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
    public class FePickupUserEntity : ModelImp.BaseModel<FePickupUserEntity>
    {
       	public FePickupUserEntity()
		{
			TB_Name = TB_FE_PickupUser;
			Parm_Id = Parm_FE_PickupUser_Id;
			Parm_Version = Parm_FE_PickupUser_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FE_PickupUser_Insert;
			Sql_Update = Sql_FE_PickupUser_Update;
			Sql_Delete = Sql_FE_PickupUser_Delete;
		}
       	#region Const of table FE_PickupUser
		/// <summary>
		/// Table FE_PickupUser
		/// </summary>
		public const string TB_FE_PickupUser = "FE_PickupUser";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ActionInstanceID
		/// </summary>
		public const string Parm_FE_PickupUser_ActionInstanceID = "ActionInstanceID";
		/// <summary>
		/// Parm AutoID
		/// </summary>
		public const string Parm_FE_PickupUser_AutoID = "AutoID";
		/// <summary>
		/// Parm BeginEffectiveDate
		/// </summary>
		public const string Parm_FE_PickupUser_BeginEffectiveDate = "BeginEffectiveDate";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FE_PickupUser_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateDate
		/// </summary>
		public const string Parm_FE_PickupUser_CreateDate = "CreateDate";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FE_PickupUser_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FE_PickupUser_CreatorId = "CreatorId";
		/// <summary>
		/// Parm EndEffectiveDate
		/// </summary>
		public const string Parm_FE_PickupUser_EndEffectiveDate = "EndEffectiveDate";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FE_PickupUser_Id = "Id";
		/// <summary>
		/// Parm NewUserID
		/// </summary>
		public const string Parm_FE_PickupUser_NewUserID = "NewUserID";
		/// <summary>
		/// Parm NewUserName
		/// </summary>
		public const string Parm_FE_PickupUser_NewUserName = "NewUserName";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FE_PickupUser_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FE_PickupUser_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FE_PickupUser_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FE_PickupUser_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FE_PickupUser_Version = "Version";
		/// <summary>
		/// Insert Query Of FE_PickupUser
		/// </summary>
		public const string Sql_FE_PickupUser_Insert = "insert into FE_PickupUser(ActionInstanceID,AutoID,BeginEffectiveDate,CreateBy,CreateDate,CreateOn,CreatorId,EndEffectiveDate,NewUserID,NewUserName,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@ActionInstanceID,@AutoID,@BeginEffectiveDate,@CreateBy,@CreateDate,@CreateOn,@CreatorId,@EndEffectiveDate,@NewUserID,@NewUserName,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of FE_PickupUser
		/// </summary>
		public const string Sql_FE_PickupUser_Update = "update FE_PickupUser set ActionInstanceID=@ActionInstanceID,AutoID=@AutoID,BeginEffectiveDate=@BeginEffectiveDate,CreateBy=@CreateBy,CreateDate=@CreateDate,CreateOn=@CreateOn,CreatorId=@CreatorId,EndEffectiveDate=@EndEffectiveDate,NewUserID=@NewUserID,NewUserName=@NewUserName,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_FE_PickupUser_Delete = "update FE_PickupUser set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _autoID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string AutoID
		{
			get{return _autoID ?? string.Empty;}
			set{_autoID = value;}
		}
		private string _actionInstanceID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActionInstanceID
		{
			get{return _actionInstanceID ?? string.Empty;}
			set{_actionInstanceID = value;}
		}
		private string _newUserID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string NewUserID
		{
			get{return _newUserID ?? string.Empty;}
			set{_newUserID = value;}
		}
		private string _newUserName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string NewUserName
		{
			get{return _newUserName ?? string.Empty;}
			set{_newUserName = value;}
		}
		private string _beginEffectiveDate = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string BeginEffectiveDate
		{
			get{return _beginEffectiveDate ?? string.Empty;}
			set{_beginEffectiveDate = value;}
		}
		private string _endEffectiveDate = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string EndEffectiveDate
		{
			get{return _endEffectiveDate ?? string.Empty;}
			set{_endEffectiveDate = value;}
		}
		private DateTime _createDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			get{return _createDate;}
			set{_createDate = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FePickupUserEntity SetModelValueByDataRow(DataRow dr)
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
		public override FePickupUserEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FePickupUserEntity();
          			if (fields.Contains(Parm_FE_PickupUser_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FE_PickupUser_Id].ToString();
			if (fields.Contains(Parm_FE_PickupUser_AutoID) || fields.Contains("*"))
				tmp.AutoID = dr[Parm_FE_PickupUser_AutoID].ToString();
			if (fields.Contains(Parm_FE_PickupUser_ActionInstanceID) || fields.Contains("*"))
				tmp.ActionInstanceID = dr[Parm_FE_PickupUser_ActionInstanceID].ToString();
			if (fields.Contains(Parm_FE_PickupUser_NewUserID) || fields.Contains("*"))
				tmp.NewUserID = dr[Parm_FE_PickupUser_NewUserID].ToString();
			if (fields.Contains(Parm_FE_PickupUser_NewUserName) || fields.Contains("*"))
				tmp.NewUserName = dr[Parm_FE_PickupUser_NewUserName].ToString();
			if (fields.Contains(Parm_FE_PickupUser_BeginEffectiveDate) || fields.Contains("*"))
				tmp.BeginEffectiveDate = dr[Parm_FE_PickupUser_BeginEffectiveDate].ToString();
			if (fields.Contains(Parm_FE_PickupUser_EndEffectiveDate) || fields.Contains("*"))
				tmp.EndEffectiveDate = dr[Parm_FE_PickupUser_EndEffectiveDate].ToString();
			if (fields.Contains(Parm_FE_PickupUser_CreateDate) || fields.Contains("*"))
				tmp.CreateDate = DateTime.Parse(dr[Parm_FE_PickupUser_CreateDate].ToString());
			if (fields.Contains(Parm_FE_PickupUser_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FE_PickupUser_CreateBy].ToString();
			if (fields.Contains(Parm_FE_PickupUser_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FE_PickupUser_RowStatus].ToString());
			if (fields.Contains(Parm_FE_PickupUser_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FE_PickupUser_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FE_PickupUser_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FE_PickupUser_CreatorId].ToString();
			if (fields.Contains(Parm_FE_PickupUser_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FE_PickupUser_CreateOn].ToString());
			if (fields.Contains(Parm_FE_PickupUser_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FE_PickupUser_UpdateId].ToString();
			if (fields.Contains(Parm_FE_PickupUser_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FE_PickupUser_UpdateBy].ToString();
			if (fields.Contains(Parm_FE_PickupUser_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_PickupUser_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_pickupuser">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FePickupUserEntity fe_pickupuser, SqlParameter[] parms)
		{
            				parms[0].Value = fe_pickupuser.AutoID;
				parms[1].Value = fe_pickupuser.ActionInstanceID;
				parms[2].Value = fe_pickupuser.NewUserID;
				parms[3].Value = fe_pickupuser.NewUserName;
				parms[4].Value = fe_pickupuser.BeginEffectiveDate;
				parms[5].Value = fe_pickupuser.EndEffectiveDate;
				parms[6].Value = fe_pickupuser.CreateDate;
				parms[7].Value = fe_pickupuser.CreateBy;
				parms[8].Value = fe_pickupuser.RowStatus;
				parms[9].Value = fe_pickupuser.CreatorId;
				parms[10].Value = fe_pickupuser.CreateOn;
				parms[11].Value = fe_pickupuser.UpdateId;
				parms[12].Value = fe_pickupuser.UpdateBy;
				parms[13].Value = fe_pickupuser.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FePickupUserEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_PickupUser_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_PickupUser_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_PickupUser_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FE_PickupUser_AutoID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_PickupUser_ActionInstanceID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_PickupUser_NewUserID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_NewUserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_BeginEffectiveDate, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_EndEffectiveDate, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_CreateDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_PickupUser_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_PickupUser_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_PickupUser_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_PickupUser_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_PickupUser_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
