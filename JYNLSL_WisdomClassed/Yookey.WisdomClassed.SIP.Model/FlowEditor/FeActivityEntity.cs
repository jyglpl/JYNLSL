//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActivityEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:34
//  功能描述：FE_Activity表实体
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
    public class FeActivityEntity : ModelImp.BaseModel<FeActivityEntity>
    {
       	public FeActivityEntity()
		{
			TB_Name = TB_FE_Activity;
			Parm_Id = Parm_FE_Activity_Id;
			Parm_Version = Parm_FE_Activity_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FE_Activity_Insert;
			Sql_Update = Sql_FE_Activity_Update;
			Sql_Delete = Sql_FE_Activity_Delete;
		}
       	#region Const of table FE_Activity
		/// <summary>
		/// Table FE_Activity
		/// </summary>
		public const string TB_FE_Activity = "FE_Activity";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ActivityID
		/// </summary>
		public const string Parm_FE_Activity_ActivityID = "ActivityID";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FE_Activity_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FE_Activity_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FE_Activity_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DefaultSay
		/// </summary>
		public const string Parm_FE_Activity_DefaultSay = "DefaultSay";
		/// <summary>
		/// Parm FormAddress
		/// </summary>
		public const string Parm_FE_Activity_FormAddress = "FormAddress";
		/// <summary>
		/// Parm FulfillAssemblyName
		/// </summary>
		public const string Parm_FE_Activity_FulfillAssemblyName = "FulfillAssemblyName";
		/// <summary>
		/// Parm FulfillClassFullName
		/// </summary>
		public const string Parm_FE_Activity_FulfillClassFullName = "FulfillClassFullName";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FE_Activity_Id = "Id";
		/// <summary>
		/// Parm IsContrastCommunity
		/// </summary>
		public const string Parm_FE_Activity_IsContrastCommunity = "IsContrastCommunity";
		/// <summary>
		/// Parm IsContrastRule
		/// </summary>
		public const string Parm_FE_Activity_IsContrastRule = "IsContrastRule";
		/// <summary>
		/// Parm IsSendOnOpener
		/// </summary>
		public const string Parm_FE_Activity_IsSendOnOpener = "IsSendOnOpener";
		/// <summary>
		/// Parm NoneDisposeManner
		/// </summary>
		public const string Parm_FE_Activity_NoneDisposeManner = "NoneDisposeManner";
		/// <summary>
		/// Parm NoneDisposeTime
		/// </summary>
		public const string Parm_FE_Activity_NoneDisposeTime = "NoneDisposeTime";
		/// <summary>
		/// Parm NoneID
		/// </summary>
		public const string Parm_FE_Activity_NoneID = "NoneID";
		/// <summary>
		/// Parm NoneName
		/// </summary>
		public const string Parm_FE_Activity_NoneName = "NoneName";
		/// <summary>
		/// Parm OverdueAssemblyName
		/// </summary>
		public const string Parm_FE_Activity_OverdueAssemblyName = "OverdueAssemblyName";
		/// <summary>
		/// Parm OverdueClassFullName
		/// </summary>
		public const string Parm_FE_Activity_OverdueClassFullName = "OverdueClassFullName";
		/// <summary>
		/// Parm OverdueHour
		/// </summary>
		public const string Parm_FE_Activity_OverdueHour = "OverdueHour";
		/// <summary>
		/// Parm ProcessID
		/// </summary>
		public const string Parm_FE_Activity_ProcessID = "ProcessID";
		/// <summary>
		/// Parm Remark
		/// </summary>
		public const string Parm_FE_Activity_Remark = "Remark";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FE_Activity_RowStatus = "RowStatus";
		/// <summary>
		/// Parm SendORWithdrawalActivityID
		/// </summary>
		public const string Parm_FE_Activity_SendORWithdrawalActivityID = "SendORWithdrawalActivityID";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FE_Activity_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FE_Activity_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FE_Activity_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FE_Activity_Version = "Version";
		/// <summary>
		/// Insert Query Of FE_Activity
		/// </summary>
		public const string Sql_FE_Activity_Insert = "insert into FE_Activity(ActivityID,CreateBy,CreateOn,CreatorId,DefaultSay,FormAddress,FulfillAssemblyName,FulfillClassFullName,IsContrastCommunity,IsContrastRule,IsSendOnOpener,NoneDisposeManner,NoneDisposeTime,NoneID,NoneName,OverdueAssemblyName,OverdueClassFullName,OverdueHour,ProcessID,Remark,RowStatus,SendORWithdrawalActivityID,UpdateBy,UpdateId,UpdateOn) values(@ActivityID,@CreateBy,@CreateOn,@CreatorId,@DefaultSay,@FormAddress,@FulfillAssemblyName,@FulfillClassFullName,@IsContrastCommunity,@IsContrastRule,@IsSendOnOpener,@NoneDisposeManner,@NoneDisposeTime,@NoneID,@NoneName,@OverdueAssemblyName,@OverdueClassFullName,@OverdueHour,@ProcessID,@Remark,@RowStatus,@SendORWithdrawalActivityID,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of FE_Activity
		/// </summary>
        public const string Sql_FE_Activity_Update = "update FE_Activity set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DefaultSay=@DefaultSay,FormAddress=@FormAddress,FulfillAssemblyName=@FulfillAssemblyName,FulfillClassFullName=@FulfillClassFullName,IsContrastCommunity=@IsContrastCommunity,IsContrastRule=@IsContrastRule,IsSendOnOpener=@IsSendOnOpener,NoneDisposeManner=@NoneDisposeManner,NoneDisposeTime=@NoneDisposeTime,NoneID=@NoneID,NoneName=@NoneName,OverdueAssemblyName=@OverdueAssemblyName,OverdueClassFullName=@OverdueClassFullName,OverdueHour=@OverdueHour,ProcessID=@ProcessID,Remark=@Remark,RowStatus=@RowStatus,SendORWithdrawalActivityID=@SendORWithdrawalActivityID,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where ActivityID=@ActivityID;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_FE_Activity_Delete = "update FE_Activity set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _activityID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActivityID
		{
			get{return _activityID ?? string.Empty;}
			set{_activityID = value;}
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
		private string _noneID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string NoneID
		{
			get{return _noneID ?? string.Empty;}
			set{_noneID = value;}
		}
		private string _noneName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string NoneName
		{
			get{return _noneName ?? string.Empty;}
			set{_noneName = value;}
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
		private int _noneDisposeManner;
		/// <summary>
		/// 
		/// </summary>
		public int NoneDisposeManner
		{
			get{return _noneDisposeManner;}
			set{_noneDisposeManner = value;}
		}
		private int _noneDisposeTime;
		/// <summary>
		/// 
		/// </summary>
		public int NoneDisposeTime
		{
			get{return _noneDisposeTime;}
			set{_noneDisposeTime = value;}
		}
		private string _sendORWithdrawalActivityID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string SendORWithdrawalActivityID
		{
			get{return _sendORWithdrawalActivityID ?? string.Empty;}
			set{_sendORWithdrawalActivityID = value;}
		}
		private string _fulfillAssemblyName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FulfillAssemblyName
		{
			get{return _fulfillAssemblyName ?? string.Empty;}
			set{_fulfillAssemblyName = value;}
		}
		private string _fulfillClassFullName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FulfillClassFullName
		{
			get{return _fulfillClassFullName ?? string.Empty;}
			set{_fulfillClassFullName = value;}
		}
		private string _overdueAssemblyName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string OverdueAssemblyName
		{
			get{return _overdueAssemblyName ?? string.Empty;}
			set{_overdueAssemblyName = value;}
		}
		private string _overdueClassFullName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string OverdueClassFullName
		{
			get{return _overdueClassFullName ?? string.Empty;}
			set{_overdueClassFullName = value;}
		}
		private int _overdueHour;
		/// <summary>
		/// 
		/// </summary>
		public int OverdueHour
		{
			get{return _overdueHour;}
			set{_overdueHour = value;}
		}
		private bool _isContrastCommunity = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsContrastCommunity
		{
			get{return _isContrastCommunity;}
			set{_isContrastCommunity = value;}
		}
		private bool _isContrastRule = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsContrastRule
		{
			get{return _isContrastRule;}
			set{_isContrastRule = value;}
		}
		private bool _isSendOnOpener = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsSendOnOpener
		{
			get{return _isSendOnOpener;}
			set{_isSendOnOpener = value;}
		}
		private string _remark = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			get{return _remark ?? string.Empty;}
			set{_remark = value;}
		}
		private string _defaultSay = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string DefaultSay
		{
			get{return _defaultSay ?? string.Empty;}
			set{_defaultSay = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FeActivityEntity SetModelValueByDataRow(DataRow dr)
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
		public override FeActivityEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeActivityEntity();
          			if (fields.Contains(Parm_FE_Activity_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FE_Activity_Id].ToString();
			if (fields.Contains(Parm_FE_Activity_ActivityID) || fields.Contains("*"))
				tmp.ActivityID = dr[Parm_FE_Activity_ActivityID].ToString();
			if (fields.Contains(Parm_FE_Activity_ProcessID) || fields.Contains("*"))
				tmp.ProcessID = dr[Parm_FE_Activity_ProcessID].ToString();
			if (fields.Contains(Parm_FE_Activity_NoneID) || fields.Contains("*"))
				tmp.NoneID = dr[Parm_FE_Activity_NoneID].ToString();
			if (fields.Contains(Parm_FE_Activity_NoneName) || fields.Contains("*"))
				tmp.NoneName = dr[Parm_FE_Activity_NoneName].ToString();
			if (fields.Contains(Parm_FE_Activity_FormAddress) || fields.Contains("*"))
				tmp.FormAddress = dr[Parm_FE_Activity_FormAddress].ToString();
			if (fields.Contains(Parm_FE_Activity_NoneDisposeManner) || fields.Contains("*"))
				tmp.NoneDisposeManner = int.Parse(dr[Parm_FE_Activity_NoneDisposeManner].ToString());
			if (fields.Contains(Parm_FE_Activity_NoneDisposeTime) || fields.Contains("*"))
				tmp.NoneDisposeTime = int.Parse(dr[Parm_FE_Activity_NoneDisposeTime].ToString());
			if (fields.Contains(Parm_FE_Activity_SendORWithdrawalActivityID) || fields.Contains("*"))
				tmp.SendORWithdrawalActivityID = dr[Parm_FE_Activity_SendORWithdrawalActivityID].ToString();
			if (fields.Contains(Parm_FE_Activity_FulfillAssemblyName) || fields.Contains("*"))
				tmp.FulfillAssemblyName = dr[Parm_FE_Activity_FulfillAssemblyName].ToString();
			if (fields.Contains(Parm_FE_Activity_FulfillClassFullName) || fields.Contains("*"))
				tmp.FulfillClassFullName = dr[Parm_FE_Activity_FulfillClassFullName].ToString();
			if (fields.Contains(Parm_FE_Activity_OverdueAssemblyName) || fields.Contains("*"))
				tmp.OverdueAssemblyName = dr[Parm_FE_Activity_OverdueAssemblyName].ToString();
			if (fields.Contains(Parm_FE_Activity_OverdueClassFullName) || fields.Contains("*"))
				tmp.OverdueClassFullName = dr[Parm_FE_Activity_OverdueClassFullName].ToString();
			if (fields.Contains(Parm_FE_Activity_OverdueHour) || fields.Contains("*"))
				tmp.OverdueHour = int.Parse(dr[Parm_FE_Activity_OverdueHour].ToString());
			if (fields.Contains(Parm_FE_Activity_IsContrastCommunity) || fields.Contains("*"))
				tmp.IsContrastCommunity = bool.Parse(dr[Parm_FE_Activity_IsContrastCommunity].ToString());
			if (fields.Contains(Parm_FE_Activity_IsContrastRule) || fields.Contains("*"))
				tmp.IsContrastRule = bool.Parse(dr[Parm_FE_Activity_IsContrastRule].ToString());
			if (fields.Contains(Parm_FE_Activity_IsSendOnOpener) || fields.Contains("*"))
				tmp.IsSendOnOpener = bool.Parse(dr[Parm_FE_Activity_IsSendOnOpener].ToString());
			if (fields.Contains(Parm_FE_Activity_Remark) || fields.Contains("*"))
				tmp.Remark = dr[Parm_FE_Activity_Remark].ToString();
			if (fields.Contains(Parm_FE_Activity_DefaultSay) || fields.Contains("*"))
				tmp.DefaultSay = dr[Parm_FE_Activity_DefaultSay].ToString();
			if (fields.Contains(Parm_FE_Activity_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FE_Activity_RowStatus].ToString());
			if (fields.Contains(Parm_FE_Activity_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FE_Activity_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FE_Activity_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FE_Activity_CreatorId].ToString();
			if (fields.Contains(Parm_FE_Activity_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FE_Activity_CreateBy].ToString();
			if (fields.Contains(Parm_FE_Activity_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FE_Activity_CreateOn].ToString());
			if (fields.Contains(Parm_FE_Activity_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FE_Activity_UpdateId].ToString();
			if (fields.Contains(Parm_FE_Activity_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FE_Activity_UpdateBy].ToString();
			if (fields.Contains(Parm_FE_Activity_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_Activity_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_activity">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FeActivityEntity fe_activity, SqlParameter[] parms)
		{
            				parms[0].Value = fe_activity.ActivityID;
				parms[1].Value = fe_activity.ProcessID;
				parms[2].Value = fe_activity.NoneID;
				parms[3].Value = fe_activity.NoneName;
				parms[4].Value = fe_activity.FormAddress;
				parms[5].Value = fe_activity.NoneDisposeManner;
				parms[6].Value = fe_activity.NoneDisposeTime;
				parms[7].Value = fe_activity.SendORWithdrawalActivityID;
				parms[8].Value = fe_activity.FulfillAssemblyName;
				parms[9].Value = fe_activity.FulfillClassFullName;
				parms[10].Value = fe_activity.OverdueAssemblyName;
				parms[11].Value = fe_activity.OverdueClassFullName;
				parms[12].Value = fe_activity.OverdueHour;
				parms[13].Value = fe_activity.IsContrastCommunity;
				parms[14].Value = fe_activity.IsContrastRule;
				parms[15].Value = fe_activity.IsSendOnOpener;
				parms[16].Value = fe_activity.Remark;
				parms[17].Value = fe_activity.DefaultSay;
				parms[18].Value = fe_activity.RowStatus;
				parms[19].Value = fe_activity.CreatorId;
				parms[20].Value = fe_activity.CreateBy;
				parms[21].Value = fe_activity.CreateOn;
				parms[22].Value = fe_activity.UpdateId;
				parms[23].Value = fe_activity.UpdateBy;
				parms[24].Value = fe_activity.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FeActivityEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_Activity_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_Activity_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Activity_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FE_Activity_ActivityID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Activity_ProcessID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Activity_NoneID, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_FE_Activity_NoneName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_FE_Activity_FormAddress, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_FE_Activity_NoneDisposeManner, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Activity_NoneDisposeTime, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Activity_SendORWithdrawalActivityID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Activity_FulfillAssemblyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_Activity_FulfillClassFullName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_FE_Activity_OverdueAssemblyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_Activity_OverdueClassFullName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_FE_Activity_OverdueHour, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Activity_IsContrastCommunity, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_Activity_IsContrastRule, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_Activity_IsSendOnOpener, SqlDbType.Bit, 1),
					new SqlParameter(Parm_FE_Activity_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_Activity_DefaultSay, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FE_Activity_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Activity_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Activity_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Activity_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_Activity_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Activity_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Activity_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Activity_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
