//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="RoadManagerEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:16
//  功能描述：RoadManager表实体
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
    public class RoadManagerEntity : ModelImp.BaseModel<RoadManagerEntity>
    {
       	public RoadManagerEntity()
		{
			TB_Name = TB_RoadManager;
			Parm_Id = Parm_RoadManager_Id;
			Parm_Version = Parm_RoadManager_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_RoadManager_Insert;
			Sql_Update = Sql_RoadManager_Update;
			Sql_Delete = Sql_RoadManager_Delete;
		}
       	#region Const of table RoadManager
		/// <summary>
		/// Table RoadManager
		/// </summary>
		public const string TB_RoadManager = "RoadManager";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_RoadManager_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_RoadManager_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_RoadManager_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_RoadManager_Id = "Id";
		/// <summary>
		/// Parm RoadName
		/// </summary>
		public const string Parm_RoadManager_RoadName = "RoadName";
		/// <summary>
		/// Parm RoadNo
		/// </summary>
		public const string Parm_RoadManager_RoadNo = "RoadNo";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_RoadManager_RowStatus = "RowStatus";
		/// <summary>
		/// Parm TownName
		/// </summary>
		public const string Parm_RoadManager_TownName = "TownName";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_RoadManager_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_RoadManager_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_RoadManager_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_RoadManager_Version = "Version";
		/// <summary>
		/// Insert Query Of RoadManager
		/// </summary>
		public const string Sql_RoadManager_Insert = "insert into RoadManager(CreateBy,CreateOn,CreatorId,RoadName,RoadNo,RowStatus,TownName,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@RoadName,@RoadNo,@RowStatus,@TownName,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of RoadManager
		/// </summary>
		public const string Sql_RoadManager_Update = "update RoadManager set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RoadName=@RoadName,RoadNo=@RoadNo,RowStatus=@RowStatus,TownName=@TownName,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_RoadManager_Delete = "update RoadManager set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _roadNo = string.Empty;
		/// <summary>
		///  路段编号
		/// </summary>
		public string RoadNo
		{
			get{return _roadNo ?? string.Empty;}
			set{_roadNo = value;}
		}
		private string _roadName = string.Empty;
		/// <summary>
		///  路段名称
		/// </summary>
		public string RoadName
		{
			get{return _roadName ?? string.Empty;}
			set{_roadName = value;}
		}
		private string _townName = string.Empty;
		/// <summary>
		///  区域名称
		/// </summary>
		public string TownName
		{
			get{return _townName ?? string.Empty;}
			set{_townName = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override RoadManagerEntity SetModelValueByDataRow(DataRow dr)
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
		public override RoadManagerEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new RoadManagerEntity();
          			if (fields.Contains(Parm_RoadManager_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_RoadManager_Id].ToString();
			if (fields.Contains(Parm_RoadManager_RoadNo) || fields.Contains("*"))
				tmp.RoadNo = dr[Parm_RoadManager_RoadNo].ToString();
			if (fields.Contains(Parm_RoadManager_RoadName) || fields.Contains("*"))
				tmp.RoadName = dr[Parm_RoadManager_RoadName].ToString();
			if (fields.Contains(Parm_RoadManager_TownName) || fields.Contains("*"))
				tmp.TownName = dr[Parm_RoadManager_TownName].ToString();
			if (fields.Contains(Parm_RoadManager_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_RoadManager_RowStatus].ToString());
			if (fields.Contains(Parm_RoadManager_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_RoadManager_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_RoadManager_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_RoadManager_CreatorId].ToString();
			if (fields.Contains(Parm_RoadManager_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_RoadManager_CreateBy].ToString();
			if (fields.Contains(Parm_RoadManager_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_RoadManager_CreateOn].ToString());
			if (fields.Contains(Parm_RoadManager_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_RoadManager_UpdateId].ToString();
			if (fields.Contains(Parm_RoadManager_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_RoadManager_UpdateBy].ToString();
			if (fields.Contains(Parm_RoadManager_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_RoadManager_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="roadmanager">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(RoadManagerEntity roadmanager, SqlParameter[] parms)
		{
            				parms[0].Value = roadmanager.RoadNo;
				parms[1].Value = roadmanager.RoadName;
				parms[2].Value = roadmanager.TownName;
				parms[3].Value = roadmanager.RowStatus;
				parms[4].Value = roadmanager.CreatorId;
				parms[5].Value = roadmanager.CreateBy;
				parms[6].Value = roadmanager.CreateOn;
				parms[7].Value = roadmanager.UpdateId;
				parms[8].Value = roadmanager.UpdateBy;
				parms[9].Value = roadmanager.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(RoadManagerEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_RoadManager_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_RoadManager_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_RoadManager_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_RoadManager_RoadNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_RoadName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_TownName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_RoadManager_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_RoadManager_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadManager_UpdateBy, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_RoadManager_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_RoadManager_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
