//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Action表实体
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
    public class FeActionEntity : ModelImp.BaseModel<FeActionEntity>
    {
       	public FeActionEntity()
		{
			TB_Name = TB_FE_Action;
			Parm_Id = Parm_FE_Action_Id;
			Parm_Version = Parm_FE_Action_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FE_Action_Insert;
			Sql_Update = Sql_FE_Action_Update;
			Sql_Delete = Sql_FE_Action_Delete;
		}
       	#region Const of table FE_Action
		/// <summary>
		/// Table FE_Action
		/// </summary>
		public const string TB_FE_Action = "FE_Action";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ActionID
		/// </summary>
		public const string Parm_FE_Action_ActionID = "ActionID";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FE_Action_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FE_Action_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FE_Action_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FromPoint
		/// </summary>
		public const string Parm_FE_Action_FromPoint = "FromPoint";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FE_Action_Id = "Id";
		/// <summary>
		/// Parm LineID
		/// </summary>
		public const string Parm_FE_Action_LineID = "LineID";
		/// <summary>
		/// Parm ProcessID
		/// </summary>
		public const string Parm_FE_Action_ProcessID = "ProcessID";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FE_Action_RowStatus = "RowStatus";
		/// <summary>
		/// Parm Topoint
		/// </summary>
		public const string Parm_FE_Action_Topoint = "Topoint";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FE_Action_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FE_Action_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FE_Action_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FE_Action_Version = "Version";
		/// <summary>
		/// Insert Query Of FE_Action
		/// </summary>
		public const string Sql_FE_Action_Insert = "insert into FE_Action(ActionID,CreateBy,CreateOn,CreatorId,FromPoint,LineID,ProcessID,RowStatus,Topoint,UpdateBy,UpdateId,UpdateOn) values(@ActionID,@CreateBy,@CreateOn,@CreatorId,@FromPoint,@LineID,@ProcessID,@RowStatus,@Topoint,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of FE_Action
		/// </summary>
		public const string Sql_FE_Action_Update = "update FE_Action set ActionID=@ActionID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FromPoint=@FromPoint,LineID=@LineID,ProcessID=@ProcessID,RowStatus=@RowStatus,Topoint=@Topoint,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_FE_Action_Delete = "update FE_Action set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _actionID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ActionID
		{
			get{return _actionID ?? string.Empty;}
			set{_actionID = value;}
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
		private string _fromPoint = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FromPoint
		{
			get{return _fromPoint ?? string.Empty;}
			set{_fromPoint = value;}
		}
		private string _topoint = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Topoint
		{
			get{return _topoint ?? string.Empty;}
			set{_topoint = value;}
		}
		private string _lineID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LineID
		{
			get{return _lineID ?? string.Empty;}
			set{_lineID = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FeActionEntity SetModelValueByDataRow(DataRow dr)
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
		public override FeActionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FeActionEntity();
          			if (fields.Contains(Parm_FE_Action_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FE_Action_Id].ToString();
			if (fields.Contains(Parm_FE_Action_ActionID) || fields.Contains("*"))
				tmp.ActionID = dr[Parm_FE_Action_ActionID].ToString();
			if (fields.Contains(Parm_FE_Action_ProcessID) || fields.Contains("*"))
				tmp.ProcessID = dr[Parm_FE_Action_ProcessID].ToString();
			if (fields.Contains(Parm_FE_Action_FromPoint) || fields.Contains("*"))
				tmp.FromPoint = dr[Parm_FE_Action_FromPoint].ToString();
			if (fields.Contains(Parm_FE_Action_Topoint) || fields.Contains("*"))
				tmp.Topoint = dr[Parm_FE_Action_Topoint].ToString();
			if (fields.Contains(Parm_FE_Action_LineID) || fields.Contains("*"))
				tmp.LineID = dr[Parm_FE_Action_LineID].ToString();
			if (fields.Contains(Parm_FE_Action_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FE_Action_RowStatus].ToString());
			if (fields.Contains(Parm_FE_Action_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FE_Action_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FE_Action_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FE_Action_CreatorId].ToString();
			if (fields.Contains(Parm_FE_Action_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FE_Action_CreateBy].ToString();
			if (fields.Contains(Parm_FE_Action_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FE_Action_CreateOn].ToString());
			if (fields.Contains(Parm_FE_Action_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FE_Action_UpdateId].ToString();
			if (fields.Contains(Parm_FE_Action_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FE_Action_UpdateBy].ToString();
			if (fields.Contains(Parm_FE_Action_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FE_Action_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fe_action">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FeActionEntity fe_action, SqlParameter[] parms)
		{
            				parms[0].Value = fe_action.ActionID;
				parms[1].Value = fe_action.ProcessID;
				parms[2].Value = fe_action.FromPoint;
				parms[3].Value = fe_action.Topoint;
				parms[4].Value = fe_action.LineID;
				parms[5].Value = fe_action.RowStatus;
				parms[6].Value = fe_action.CreatorId;
				parms[7].Value = fe_action.CreateBy;
				parms[8].Value = fe_action.CreateOn;
				parms[9].Value = fe_action.UpdateId;
				parms[10].Value = fe_action.UpdateBy;
				parms[11].Value = fe_action.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FeActionEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_FE_Action_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_FE_Action_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Action_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FE_Action_ActionID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Action_ProcessID, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_FE_Action_FromPoint, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_Topoint, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_LineID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FE_Action_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FE_Action_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FE_Action_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FE_Action_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
