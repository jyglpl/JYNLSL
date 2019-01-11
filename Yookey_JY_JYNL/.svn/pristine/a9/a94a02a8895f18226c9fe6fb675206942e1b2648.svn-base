//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_HANDLEREntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/23 17:29:48
//  功能描述：INF_CAR_HANDLER表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Case
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class InfCarHandlerEntity : ModelImp.BaseModel<InfCarHandlerEntity>
    {
       	public InfCarHandlerEntity()
		{
			TB_Name = TB_INF_CAR_HANDLER;
			Parm_Id = Parm_INF_CAR_HANDLER_Id;
			Parm_Version = Parm_INF_CAR_HANDLER_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_CAR_HANDLER_Insert;
			Sql_Update = Sql_INF_CAR_HANDLER_Update;
			Sql_Delete = Sql_INF_CAR_HANDLER_Delete;
		}
       	#region Const of table INF_CAR_HANDLER
		/// <summary>
		/// Table INF_CAR_HANDLER
		/// </summary>
		public const string TB_INF_CAR_HANDLER = "INF_CAR_HANDLER";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AffirmPersone
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_AffirmPersone = "AffirmPersone";
		/// <summary>
		/// Parm CheckSigniId
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_CheckSigniId = "CheckSigniId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_CreatorId = "CreatorId";
		/// <summary>
		/// Parm HandContent
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandContent = "HandContent";
		/// <summary>
		/// Parm HandDate
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandDate = "HandDate";
		/// <summary>
		/// Parm HandleIp
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandleIp = "HandleIp";
		/// <summary>
		/// Parm HandPersonId
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandPersonId = "HandPersonId";
		/// <summary>
		/// Parm HandReason
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandReason = "HandReason";
		/// <summary>
		/// Parm HandType
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_HandType = "HandType";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_CAR_HANDLER_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_CAR_HANDLER
		/// </summary>
		public const string Sql_INF_CAR_HANDLER_Insert = "insert into INF_CAR_HANDLER(AffirmPersone,CheckSigniId,CreateBy,CreateOn,CreatorId,HandContent,HandDate,HandleIp,HandPersonId,HandReason,HandType,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@AffirmPersone,@CheckSigniId,@CreateBy,@CreateOn,@CreatorId,@HandContent,@HandDate,@HandleIp,@HandPersonId,@HandReason,@HandType,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of INF_CAR_HANDLER
		/// </summary>
		public const string Sql_INF_CAR_HANDLER_Update = "update INF_CAR_HANDLER set AffirmPersone=@AffirmPersone,CheckSigniId=@CheckSigniId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,HandContent=@HandContent,HandDate=@HandDate,HandleIp=@HandleIp,HandPersonId=@HandPersonId,HandReason=@HandReason,HandType=@HandType,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_CAR_HANDLER_Delete = "update INF_CAR_HANDLER set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _checkSigniId = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string CheckSigniId
		{
			get{return _checkSigniId ?? string.Empty;}
			set{_checkSigniId = value;}
		}
		private string _handPersonId = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string HandPersonId
		{
			get{return _handPersonId ?? string.Empty;}
			set{_handPersonId = value;}
		}
		private string _affirmPersone = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string AffirmPersone
		{
			get{return _affirmPersone ?? string.Empty;}
			set{_affirmPersone = value;}
		}
		private string _handType = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string HandType
		{
			get{return _handType ?? string.Empty;}
			set{_handType = value;}
		}
		private string _handContent = string.Empty;
		/// <summary>
		/// String(200
		/// </summary>
		public string HandContent
		{
			get{return _handContent ?? string.Empty;}
			set{_handContent = value;}
		}
		private string _handleIp = string.Empty;
		/// <summary>
		/// String(20
		/// </summary>
		public string HandleIp
		{
			get{return _handleIp ?? string.Empty;}
			set{_handleIp = value;}
		}
		private DateTime _handDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime HandDate
		{
			get{return _handDate;}
			set{_handDate = value;}
		}
		private string _handReason = string.Empty;
		/// <summary>
		/// String(1000
		/// </summary>
		public string HandReason
		{
			get{return _handReason ?? string.Empty;}
			set{_handReason = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfCarHandlerEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfCarHandlerEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfCarHandlerEntity();
          			if (fields.Contains(Parm_INF_CAR_HANDLER_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_CAR_HANDLER_Id].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_CheckSigniId) || fields.Contains("*"))
				tmp.CheckSigniId = dr[Parm_INF_CAR_HANDLER_CheckSigniId].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandPersonId) || fields.Contains("*"))
				tmp.HandPersonId = dr[Parm_INF_CAR_HANDLER_HandPersonId].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_AffirmPersone) || fields.Contains("*"))
				tmp.AffirmPersone = dr[Parm_INF_CAR_HANDLER_AffirmPersone].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandType) || fields.Contains("*"))
				tmp.HandType = dr[Parm_INF_CAR_HANDLER_HandType].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandContent) || fields.Contains("*"))
				tmp.HandContent = dr[Parm_INF_CAR_HANDLER_HandContent].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandleIp) || fields.Contains("*"))
				tmp.HandleIp = dr[Parm_INF_CAR_HANDLER_HandleIp].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandDate) || fields.Contains("*"))
				tmp.HandDate = DateTime.Parse(dr[Parm_INF_CAR_HANDLER_HandDate].ToString());
			if (fields.Contains(Parm_INF_CAR_HANDLER_HandReason) || fields.Contains("*"))
				tmp.HandReason = dr[Parm_INF_CAR_HANDLER_HandReason].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_CAR_HANDLER_RowStatus].ToString());
			if (fields.Contains(Parm_INF_CAR_HANDLER_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_CAR_HANDLER_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_CAR_HANDLER_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_CAR_HANDLER_CreatorId].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_CAR_HANDLER_CreateBy].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_CAR_HANDLER_CreateOn].ToString());
			if (fields.Contains(Parm_INF_CAR_HANDLER_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_CAR_HANDLER_UpdateId].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_CAR_HANDLER_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_CAR_HANDLER_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_CAR_HANDLER_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_car_handler">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfCarHandlerEntity inf_car_handler, SqlParameter[] parms)
		{
            				parms[0].Value = inf_car_handler.CheckSigniId;
				parms[1].Value = inf_car_handler.HandPersonId;
				parms[2].Value = inf_car_handler.AffirmPersone;
				parms[3].Value = inf_car_handler.HandType;
				parms[4].Value = inf_car_handler.HandContent;
				parms[5].Value = inf_car_handler.HandleIp;
				parms[6].Value = inf_car_handler.HandDate;
				parms[7].Value = inf_car_handler.HandReason;
				parms[8].Value = inf_car_handler.RowStatus;
				parms[9].Value = inf_car_handler.CreatorId;
				parms[10].Value = inf_car_handler.CreateBy;
				parms[11].Value = inf_car_handler.CreateOn;
				parms[12].Value = inf_car_handler.UpdateId;
				parms[13].Value = inf_car_handler.UpdateBy;
				parms[14].Value = inf_car_handler.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfCarHandlerEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_INF_CAR_HANDLER_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_INF_CAR_HANDLER_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_HANDLER_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_CAR_HANDLER_CheckSigniId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandPersonId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_AffirmPersone, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandContent, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandleIp, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_HANDLER_HandReason, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_INF_CAR_HANDLER_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_HANDLER_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_HANDLER_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_UpdateBy, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_CAR_HANDLER_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_HANDLER_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
