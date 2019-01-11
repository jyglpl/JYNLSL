//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComOperationLogEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:40
//  功能描述：ComOperationLog表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 系统操作、错误日志
    /// </summary>
    [Serializable]
    public class ComOperationLogEntity : ModelImp.BaseModel<ComOperationLogEntity>
    {
       	public ComOperationLogEntity()
		{
			TB_Name = TB_ComOperationLog;
			Parm_Id = Parm_ComOperationLog_Id;
			Parm_Version = Parm_ComOperationLog_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComOperationLog_Insert;
			Sql_Update = Sql_ComOperationLog_Update;
			Sql_Delete = Sql_ComOperationLog_Delete;
		}
       	#region Const of table ComOperationLog
		/// <summary>
		/// Table ComOperationLog
		/// </summary>
		public const string TB_ComOperationLog = "ComOperationLog";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Action
		/// </summary>
		public const string Parm_ComOperationLog_Action = "Action";
		/// <summary>
		/// Parm Controller
		/// </summary>
		public const string Parm_ComOperationLog_Controller = "Controller";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComOperationLog_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComOperationLog_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComOperationLog_CreatorId = "CreatorId";
		/// <summary>
		/// Parm HandleTypeId
		/// </summary>
		public const string Parm_ComOperationLog_HandleTypeId = "HandleTypeId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComOperationLog_Id = "Id";
		/// <summary>
		/// Parm Ip
		/// </summary>
		public const string Parm_ComOperationLog_Ip = "Ip";
		/// <summary>
		/// Parm LogType
		/// </summary>
		public const string Parm_ComOperationLog_LogType = "LogType";
		/// <summary>
		/// Parm ModelName
		/// </summary>
		public const string Parm_ComOperationLog_ModelName = "ModelName";
		/// <summary>
		/// Parm Note
		/// </summary>
		public const string Parm_ComOperationLog_Note = "Note";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComOperationLog_RowStatus = "RowStatus";
		/// <summary>
		/// Parm Status
		/// </summary>
		public const string Parm_ComOperationLog_Status = "Status";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComOperationLog_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComOperationLog_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComOperationLog_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComOperationLog_Version = "Version";
		/// <summary>
		/// Insert Query Of ComOperationLog
		/// </summary>
		public const string Sql_ComOperationLog_Insert = "insert into ComOperationLog(Action,Controller,CreateBy,CreateOn,CreatorId,HandleTypeId,Ip,LogType,ModelName,Note,RowStatus,Status,UpdateBy,UpdateId,UpdateOn) values(@Action,@Controller,@CreateBy,@CreateOn,@CreatorId,@HandleTypeId,@Ip,@LogType,@ModelName,@Note,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of ComOperationLog
		/// </summary>
		public const string Sql_ComOperationLog_Update = "update ComOperationLog set Action=@Action,Controller=@Controller,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,HandleTypeId=@HandleTypeId,Ip=@Ip,LogType=@LogType,ModelName=@ModelName,Note=@Note,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComOperationLog_Delete = "update ComOperationLog set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private int _logType;
		/// <summary>
		/// 日志类型：错误日志、操作日志
		/// </summary>
		public int LogType
		{
			get{return _logType;}
			set{_logType = value;}
		}
		private string _controller = string.Empty;
		/// <summary>
		/// 控制器名称
		/// </summary>
		public string Controller
		{
			get{return _controller ?? string.Empty;}
			set{_controller = value;}
		}
		private string _modelName = string.Empty;
		/// <summary>
		/// 操作模块名称
		/// </summary>
		public string ModelName
		{
			get{return _modelName ?? string.Empty;}
			set{_modelName = value;}
		}
		private string _action = string.Empty;
		/// <summary>
		/// Action 方法
		/// </summary>
		public string Action
		{
			get{return _action ?? string.Empty;}
			set{_action = value;}
		}
		private string _handleTypeId = string.Empty;
		/// <summary>
		/// 访问、离开、新增、修改（保存）、删除
		/// </summary>
		public string HandleTypeId
		{
			get{return _handleTypeId ?? string.Empty;}
			set{_handleTypeId = value;}
		}
		private string _note = string.Empty;
		/// <summary>
		/// 操作说明
		/// </summary>
		public string Note
		{
			get{return _note ?? string.Empty;}
			set{_note = value;}
		}
		private string _ip = string.Empty;
		/// <summary>
		/// IP地址
		/// </summary>
		public string Ip
		{
			get{return _ip ?? string.Empty;}
			set{_ip = value;}
		}
		private int _status;
		/// <summary>
		/// 操作状态：成功、失败
		/// </summary>
		public int Status
		{
			get{return _status;}
			set{_status = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComOperationLogEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComOperationLogEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComOperationLogEntity();
          			if (fields.Contains(Parm_ComOperationLog_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComOperationLog_Id].ToString();
			if (fields.Contains(Parm_ComOperationLog_LogType) || fields.Contains("*"))
				tmp.LogType = int.Parse(dr[Parm_ComOperationLog_LogType].ToString());
			if (fields.Contains(Parm_ComOperationLog_Controller) || fields.Contains("*"))
				tmp.Controller = dr[Parm_ComOperationLog_Controller].ToString();
			if (fields.Contains(Parm_ComOperationLog_ModelName) || fields.Contains("*"))
				tmp.ModelName = dr[Parm_ComOperationLog_ModelName].ToString();
			if (fields.Contains(Parm_ComOperationLog_Action) || fields.Contains("*"))
				tmp.Action = dr[Parm_ComOperationLog_Action].ToString();
			if (fields.Contains(Parm_ComOperationLog_HandleTypeId) || fields.Contains("*"))
				tmp.HandleTypeId = dr[Parm_ComOperationLog_HandleTypeId].ToString();
			if (fields.Contains(Parm_ComOperationLog_Note) || fields.Contains("*"))
				tmp.Note = dr[Parm_ComOperationLog_Note].ToString();
			if (fields.Contains(Parm_ComOperationLog_Ip) || fields.Contains("*"))
				tmp.Ip = dr[Parm_ComOperationLog_Ip].ToString();
			if (fields.Contains(Parm_ComOperationLog_Status) || fields.Contains("*"))
				tmp.Status = int.Parse(dr[Parm_ComOperationLog_Status].ToString());
			if (fields.Contains(Parm_ComOperationLog_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComOperationLog_RowStatus].ToString());
			if (fields.Contains(Parm_ComOperationLog_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComOperationLog_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComOperationLog_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComOperationLog_CreatorId].ToString();
			if (fields.Contains(Parm_ComOperationLog_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComOperationLog_CreateBy].ToString();
			if (fields.Contains(Parm_ComOperationLog_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComOperationLog_CreateOn].ToString());
			if (fields.Contains(Parm_ComOperationLog_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComOperationLog_UpdateId].ToString();
			if (fields.Contains(Parm_ComOperationLog_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComOperationLog_UpdateBy].ToString();
			if (fields.Contains(Parm_ComOperationLog_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComOperationLog_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comoperationlog">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComOperationLogEntity comoperationlog, SqlParameter[] parms)
		{
            				parms[0].Value = comoperationlog.LogType;
				parms[1].Value = comoperationlog.Controller;
				parms[2].Value = comoperationlog.ModelName;
				parms[3].Value = comoperationlog.Action;
				parms[4].Value = comoperationlog.HandleTypeId;
				parms[5].Value = comoperationlog.Note;
				parms[6].Value = comoperationlog.Ip;
				parms[7].Value = comoperationlog.Status;
				parms[8].Value = comoperationlog.RowStatus;
				parms[9].Value = comoperationlog.CreatorId;
				parms[10].Value = comoperationlog.CreateBy;
				parms[11].Value = comoperationlog.CreateOn;
				parms[12].Value = comoperationlog.UpdateId;
				parms[13].Value = comoperationlog.UpdateBy;
				parms[14].Value = comoperationlog.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComOperationLogEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComOperationLog_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComOperationLog_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComOperationLog_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComOperationLog_LogType, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComOperationLog_Controller, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_ModelName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_Action, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_HandleTypeId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_Note, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_ComOperationLog_Ip, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_ComOperationLog_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComOperationLog_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComOperationLog_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComOperationLog_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComOperationLog_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComOperationLog_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
