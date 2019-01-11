//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComLoginLogEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:40
//  功能描述：ComLoginLog表实体
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
    /// 登录日志
    /// </summary>
    [Serializable]
    public class ComLoginLogEntity : ModelImp.BaseModel<ComLoginLogEntity>
    {
       	public ComLoginLogEntity()
		{
			TB_Name = TB_ComLoginLog;
			Parm_Id = Parm_ComLoginLog_Id;
			Parm_Version = Parm_ComLoginLog_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComLoginLog_Insert;
			Sql_Update = Sql_ComLoginLog_Update;
			Sql_Delete = Sql_ComLoginLog_Delete;
		}
       	#region Const of table ComLoginLog
		/// <summary>
		/// Table ComLoginLog
		/// </summary>
		public const string TB_ComLoginLog = "ComLoginLog";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComLoginLog_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComLoginLog_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComLoginLog_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComLoginLog_Id = "Id";
		/// <summary>
		/// Parm Ip
		/// </summary>
		public const string Parm_ComLoginLog_Ip = "Ip";
		/// <summary>
		/// Parm Note
		/// </summary>
		public const string Parm_ComLoginLog_Note = "Note";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComLoginLog_RowStatus = "RowStatus";
		/// <summary>
		/// Parm Source
		/// </summary>
		public const string Parm_ComLoginLog_Source = "Source";
		/// <summary>
		/// Parm Status
		/// </summary>
		public const string Parm_ComLoginLog_Status = "Status";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComLoginLog_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComLoginLog_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComLoginLog_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComLoginLog_Version = "Version";
		/// <summary>
		/// Insert Query Of ComLoginLog
		/// </summary>
		public const string Sql_ComLoginLog_Insert = "insert into ComLoginLog(CreateBy,CreateOn,CreatorId,Ip,Note,RowStatus,Source,Status,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@Ip,@Note,@RowStatus,@Source,@Status,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of ComLoginLog
		/// </summary>
		public const string Sql_ComLoginLog_Update = "update ComLoginLog set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Ip=@Ip,Note=@Note,RowStatus=@RowStatus,Source=@Source,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComLoginLog_Delete = "update ComLoginLog set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private int _source;
		/// <summary>
		/// 来源：PDA、网页
		/// </summary>
		public int Source
		{
			get{return _source;}
			set{_source = value;}
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
		private string _note = string.Empty;
		/// <summary>
		/// 操作说明
		/// </summary>
		public string Note
		{
			get{return _note ?? string.Empty;}
			set{_note = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComLoginLogEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComLoginLogEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComLoginLogEntity();
          			if (fields.Contains(Parm_ComLoginLog_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComLoginLog_Id].ToString();
			if (fields.Contains(Parm_ComLoginLog_Source) || fields.Contains("*"))
				tmp.Source = int.Parse(dr[Parm_ComLoginLog_Source].ToString());
			if (fields.Contains(Parm_ComLoginLog_Ip) || fields.Contains("*"))
				tmp.Ip = dr[Parm_ComLoginLog_Ip].ToString();
			if (fields.Contains(Parm_ComLoginLog_Status) || fields.Contains("*"))
				tmp.Status = int.Parse(dr[Parm_ComLoginLog_Status].ToString());
			if (fields.Contains(Parm_ComLoginLog_Note) || fields.Contains("*"))
				tmp.Note = dr[Parm_ComLoginLog_Note].ToString();
			if (fields.Contains(Parm_ComLoginLog_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComLoginLog_RowStatus].ToString());
			if (fields.Contains(Parm_ComLoginLog_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComLoginLog_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComLoginLog_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComLoginLog_CreatorId].ToString();
			if (fields.Contains(Parm_ComLoginLog_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComLoginLog_CreateBy].ToString();
			if (fields.Contains(Parm_ComLoginLog_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComLoginLog_CreateOn].ToString());
			if (fields.Contains(Parm_ComLoginLog_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComLoginLog_UpdateId].ToString();
			if (fields.Contains(Parm_ComLoginLog_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComLoginLog_UpdateBy].ToString();
			if (fields.Contains(Parm_ComLoginLog_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComLoginLog_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comloginlog">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComLoginLogEntity comloginlog, SqlParameter[] parms)
		{
            				parms[0].Value = comloginlog.Source;
				parms[1].Value = comloginlog.Ip;
				parms[2].Value = comloginlog.Status;
				parms[3].Value = comloginlog.Note;
				parms[4].Value = comloginlog.RowStatus;
				parms[5].Value = comloginlog.CreatorId;
				parms[6].Value = comloginlog.CreateBy;
				parms[7].Value = comloginlog.CreateOn;
				parms[8].Value = comloginlog.UpdateId;
				parms[9].Value = comloginlog.UpdateBy;
				parms[10].Value = comloginlog.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComLoginLogEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComLoginLog_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComLoginLog_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComLoginLog_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComLoginLog_Source, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComLoginLog_Ip, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_ComLoginLog_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComLoginLog_Note, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_ComLoginLog_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComLoginLog_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComLoginLog_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComLoginLog_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComLoginLog_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComLoginLog_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComLoginLog_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComLoginLog_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
