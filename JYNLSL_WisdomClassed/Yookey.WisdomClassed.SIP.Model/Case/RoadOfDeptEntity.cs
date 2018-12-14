//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="RoadOfDeptEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:16
//  功能描述：RoadOfDept表实体
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
    public class RoadOfDeptEntity : ModelImp.BaseModel<RoadOfDeptEntity>
    {
       	public RoadOfDeptEntity()
		{
			TB_Name = TB_RoadOfDept;
			Parm_Id = Parm_RoadOfDept_Id;
			Parm_Version = Parm_RoadOfDept_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_RoadOfDept_Insert;
			Sql_Update = Sql_RoadOfDept_Update;
			Sql_Delete = Sql_RoadOfDept_Delete;
		}
       	#region Const of table RoadOfDept
		/// <summary>
		/// Table RoadOfDept
		/// </summary>
		public const string TB_RoadOfDept = "RoadOfDept";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_RoadOfDept_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_RoadOfDept_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_RoadOfDept_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DeptId
		/// </summary>
		public const string Parm_RoadOfDept_DeptId = "DeptId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_RoadOfDept_Id = "Id";
		/// <summary>
		/// Parm RoadId
		/// </summary>
		public const string Parm_RoadOfDept_RoadId = "RoadId";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_RoadOfDept_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_RoadOfDept_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_RoadOfDept_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_RoadOfDept_Version = "Version";
		/// <summary>
		/// Insert Query Of RoadOfDept
		/// </summary>
		public const string Sql_RoadOfDept_Insert = "insert into RoadOfDept(CreateBy,CreateOn,CreatorId,DeptId,RoadId,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@DeptId,@RoadId,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of RoadOfDept
		/// </summary>
		public const string Sql_RoadOfDept_Update = "update RoadOfDept set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,RoadId=@RoadId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_RoadOfDept_Delete = "update RoadOfDept set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _roadId = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string RoadId
		{
			get{return _roadId ?? string.Empty;}
			set{_roadId = value;}
		}
		private string _deptId = string.Empty;
		/// <summary>
		/// String(50
		/// </summary>
		public string DeptId
		{
			get{return _deptId ?? string.Empty;}
			set{_deptId = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override RoadOfDeptEntity SetModelValueByDataRow(DataRow dr)
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
		public override RoadOfDeptEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new RoadOfDeptEntity();
          			if (fields.Contains(Parm_RoadOfDept_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_RoadOfDept_Id].ToString();
			if (fields.Contains(Parm_RoadOfDept_RoadId) || fields.Contains("*"))
				tmp.RoadId = dr[Parm_RoadOfDept_RoadId].ToString();
			if (fields.Contains(Parm_RoadOfDept_DeptId) || fields.Contains("*"))
				tmp.DeptId = dr[Parm_RoadOfDept_DeptId].ToString();
			if (fields.Contains(Parm_RoadOfDept_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_RoadOfDept_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_RoadOfDept_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_RoadOfDept_CreatorId].ToString();
			if (fields.Contains(Parm_RoadOfDept_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_RoadOfDept_CreateBy].ToString();
			if (fields.Contains(Parm_RoadOfDept_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_RoadOfDept_CreateOn].ToString());
			if (fields.Contains(Parm_RoadOfDept_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_RoadOfDept_UpdateId].ToString();
			if (fields.Contains(Parm_RoadOfDept_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_RoadOfDept_UpdateBy].ToString();
			if (fields.Contains(Parm_RoadOfDept_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_RoadOfDept_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="roadofdept">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(RoadOfDeptEntity roadofdept, SqlParameter[] parms)
		{
            				parms[0].Value = roadofdept.RoadId;
				parms[1].Value = roadofdept.DeptId;
				parms[2].Value = roadofdept.CreatorId;
				parms[3].Value = roadofdept.CreateBy;
				parms[4].Value = roadofdept.CreateOn;
				parms[5].Value = roadofdept.UpdateId;
				parms[6].Value = roadofdept.UpdateBy;
				parms[7].Value = roadofdept.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(RoadOfDeptEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_RoadOfDept_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_RoadOfDept_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_RoadOfDept_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_RoadOfDept_RoadId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadOfDept_DeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadOfDept_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadOfDept_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadOfDept_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_RoadOfDept_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_RoadOfDept_UpdateBy, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_RoadOfDept_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_RoadOfDept_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
