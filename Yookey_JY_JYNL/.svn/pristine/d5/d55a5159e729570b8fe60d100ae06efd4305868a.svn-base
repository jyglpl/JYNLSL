//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightParticularEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/21 14:00:54
//  功能描述：FlightParticular表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Hr
{
    /// <summary>
    /// 排班名细表
    /// </summary>
    [Serializable]
    public class FlightParticularEntity : ModelImp.BaseModel<FlightParticularEntity>
    {
       	public FlightParticularEntity()
		{
			TB_Name = TB_FlightParticular;
			Parm_Id = Parm_FlightParticular_Id;
			Parm_Version = Parm_FlightParticular_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_FlightParticular_Insert;
			Sql_Update = Sql_FlightParticular_Update;
			Sql_Delete = Sql_FlightParticular_Delete;
		}
       	#region Const of table FlightParticular
		/// <summary>
		/// Table FlightParticular
		/// </summary>
		public const string TB_FlightParticular = "FlightParticular";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AppearId
		/// </summary>
		public const string Parm_FlightParticular_AppearId = "AppearId";
		/// <summary>
		/// Parm ClassesId
		/// </summary>
		public const string Parm_FlightParticular_ClassesId = "ClassesId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_FlightParticular_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_FlightParticular_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_FlightParticular_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FlightDays
		/// </summary>
		public const string Parm_FlightParticular_FlightDays = "FlightDays";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_FlightParticular_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_FlightParticular_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_FlightParticular_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_FlightParticular_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_FlightParticular_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_FlightParticular_Version = "Version";
        /// <summary>
        /// Parm ClassName
        /// </summary>
        public const string Parm_FlightParticular_ClassName = "ClassName";
        /// <summary>
        /// Parm ClassBeginTime
        /// </summary>
        public const string Parm_FlightParticular_ClassBeginTime = "ClassBeginTime";
        /// <summary>
        /// Parm ClassEndTime
        /// </summary>
        public const string Parm_FlightParticular_ClassEndTime = "ClassEndTime";
		/// <summary>
		/// Insert Query Of FlightParticular
		/// </summary>
        public const string Sql_FlightParticular_Insert = "insert into FlightParticular(AppearId,ClassBeginTime,ClassEndTime,ClassesId,ClassName,CreateBy,CreateOn,CreatorId,FlightDays,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@AppearId,@ClassBeginTime,@ClassEndTime,@ClassesId,@ClassName,@CreateBy,@CreateOn,@CreatorId,@FlightDays,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of FlightParticular
		/// </summary>
        public const string Sql_FlightParticular_Update = "update FlightParticular set AppearId=@AppearId,ClassBeginTime=@ClassBeginTime,ClassEndTime=@ClassEndTime,ClassesId=@ClassesId,ClassName=@ClassName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FlightDays=@FlightDays,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
        public const string Sql_FlightParticular_Delete = "update FlightParticular set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _appearId = string.Empty;
		/// <summary>
		/// 对应排班主表编号
		/// </summary>
		public string AppearId
		{
			get{return _appearId ?? string.Empty;}
			set{_appearId = value;}
		}
		private string _classesId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ClassesId
		{
			get{return _classesId ?? string.Empty;}
			set{_classesId = value;}
		}
		private DateTime _flightDays = MinDate;
		/// <summary>
		/// 排班日期
		/// </summary>
		public DateTime FlightDays
		{
			get{return _flightDays;}
			set{_flightDays = value;}
		}
        private string _className = string.Empty;
        /// <summary>
        /// 排班类型名称
        /// </summary>
        public string ClassName
        {
            get { return _className ?? string.Empty; }
            set { _className = value; }
        }
        private string _classBeginTime = string.Empty;
        /// <summary>
        /// 排班类型开始时间
        /// </summary>
        public string ClassBeginTime
        {
            get { return _classBeginTime; }
            set { _classBeginTime = value; }
        }
        private string _classEndTime = string.Empty;
        /// <summary>
        /// 排班类型结束时间
        /// </summary>
        public string ClassEndTime
        {
            get { return _classEndTime; }
            set { _classEndTime = value; }
        }
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override FlightParticularEntity SetModelValueByDataRow(DataRow dr)
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
		public override FlightParticularEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightParticularEntity();
          			if (fields.Contains(Parm_FlightParticular_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_FlightParticular_Id].ToString();
			if (fields.Contains(Parm_FlightParticular_AppearId) || fields.Contains("*"))
				tmp.AppearId = dr[Parm_FlightParticular_AppearId].ToString();
			if (fields.Contains(Parm_FlightParticular_ClassesId) || fields.Contains("*"))
				tmp.ClassesId = dr[Parm_FlightParticular_ClassesId].ToString();
			if (fields.Contains(Parm_FlightParticular_FlightDays) || fields.Contains("*"))
				tmp.FlightDays = DateTime.Parse(dr[Parm_FlightParticular_FlightDays].ToString());
			if (fields.Contains(Parm_FlightParticular_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_FlightParticular_RowStatus].ToString());
			if (fields.Contains(Parm_FlightParticular_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_FlightParticular_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_FlightParticular_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_FlightParticular_CreatorId].ToString();
			if (fields.Contains(Parm_FlightParticular_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_FlightParticular_CreateBy].ToString();
			if (fields.Contains(Parm_FlightParticular_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_FlightParticular_CreateOn].ToString());
			if (fields.Contains(Parm_FlightParticular_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_FlightParticular_UpdateId].ToString();
			if (fields.Contains(Parm_FlightParticular_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_FlightParticular_UpdateBy].ToString();
			if (fields.Contains(Parm_FlightParticular_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightParticular_UpdateOn].ToString());
            if (fields.Contains(Parm_FlightParticular_ClassName) || fields.Contains("*"))
                tmp.ClassName = dr[Parm_FlightParticular_ClassName].ToString();
            if (fields.Contains(Parm_FlightParticular_ClassBeginTime) || fields.Contains("*"))
                tmp.ClassBeginTime = dr[Parm_FlightParticular_ClassBeginTime].ToString();
            if (fields.Contains(Parm_FlightParticular_ClassEndTime) || fields.Contains("*"))
                tmp.ClassEndTime = dr[Parm_FlightParticular_ClassEndTime].ToString();
	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightparticular">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(FlightParticularEntity flightparticular, SqlParameter[] parms)
		{
            				parms[0].Value = flightparticular.AppearId;
				parms[1].Value = flightparticular.ClassesId;
				parms[2].Value = flightparticular.FlightDays;
				parms[3].Value = flightparticular.RowStatus;
				parms[4].Value = flightparticular.CreatorId;
				parms[5].Value = flightparticular.CreateBy;
				parms[6].Value = flightparticular.CreateOn;
				parms[7].Value = flightparticular.UpdateId;
				parms[8].Value = flightparticular.UpdateBy;
				parms[9].Value = flightparticular.UpdateOn;
                parms[10].Value = flightparticular.Id;
                parms[11].Value = flightparticular.ClassName;
                parms[12].Value = flightparticular.ClassBeginTime;
                parms[13].Value = flightparticular.ClassEndTime;
             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(FlightParticularEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightParticular_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_FlightParticular_AppearId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_ClassesId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_FlightDays, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightParticular_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightParticular_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightParticular_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FlightParticular_Id, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_FlightParticular_ClassName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_ClassBeginTime, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightParticular_ClassEndTime, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightParticular_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
