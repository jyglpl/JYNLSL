//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComHolidaysEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/20 9:42:35
//  功能描述：ComHolidays表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class ComHolidaysEntity : ModelImp.BaseModel<ComHolidaysEntity>
    {
       	public ComHolidaysEntity()
		{
			TB_Name = TB_ComHolidays;
			Parm_Id = Parm_ComHolidays_Id;
			Parm_Version = Parm_ComHolidays_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComHolidays_Insert;
			Sql_Update = Sql_ComHolidays_Update;
			Sql_Delete = Sql_ComHolidays_Delete;
		}
       	#region Const of table ComHolidays
		/// <summary>
		/// Table ComHolidays
		/// </summary>
		public const string TB_ComHolidays = "ComHolidays";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComHolidays_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComHolidays_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComHolidays_CreatorId = "CreatorId";
		/// <summary>
		/// Parm HostDate
		/// </summary>
		public const string Parm_ComHolidays_HostDate = "HostDate";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComHolidays_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComHolidays_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComHolidays_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComHolidays_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComHolidays_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComHolidays_Version = "Version";
		/// <summary>
		/// Insert Query Of ComHolidays
		/// </summary>
		public const string Sql_ComHolidays_Insert = "insert into ComHolidays(CreateBy,CreateOn,CreatorId,HostDate,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@HostDate,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of ComHolidays
		/// </summary>
		public const string Sql_ComHolidays_Update = "update ComHolidays set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,HostDate=@HostDate,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComHolidays_Delete = "update ComHolidays set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private DateTime _hostDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime HostDate
		{
			get{return _hostDate;}
			set{_hostDate = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComHolidaysEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComHolidaysEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComHolidaysEntity();
          			if (fields.Contains(Parm_ComHolidays_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComHolidays_Id].ToString();
			if (fields.Contains(Parm_ComHolidays_HostDate) || fields.Contains("*"))
				tmp.HostDate = DateTime.Parse(dr[Parm_ComHolidays_HostDate].ToString());
			if (fields.Contains(Parm_ComHolidays_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComHolidays_RowStatus].ToString());
			if (fields.Contains(Parm_ComHolidays_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComHolidays_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComHolidays_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComHolidays_CreatorId].ToString();
			if (fields.Contains(Parm_ComHolidays_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComHolidays_CreateBy].ToString();
			if (fields.Contains(Parm_ComHolidays_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComHolidays_CreateOn].ToString());
			if (fields.Contains(Parm_ComHolidays_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComHolidays_UpdateId].ToString();
			if (fields.Contains(Parm_ComHolidays_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComHolidays_UpdateBy].ToString();
			if (fields.Contains(Parm_ComHolidays_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComHolidays_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comholidays">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComHolidaysEntity comholidays, SqlParameter[] parms)
		{
            				parms[0].Value = comholidays.HostDate;
				parms[1].Value = comholidays.RowStatus;
				parms[2].Value = comholidays.CreatorId;
				parms[3].Value = comholidays.CreateBy;
				parms[4].Value = comholidays.CreateOn;
				parms[5].Value = comholidays.UpdateId;
				parms[6].Value = comholidays.UpdateBy;
				parms[7].Value = comholidays.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComHolidaysEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComHolidays_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComHolidays_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComHolidays_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComHolidays_HostDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComHolidays_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComHolidays_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComHolidays_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComHolidays_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComHolidays_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComHolidays_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComHolidays_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComHolidays_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
