//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserRoleEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:41
//  功能描述：CrmUserRole表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.ModelImp;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 用户角色对应关系
    /// </summary>
    [Serializable]
    public class CrmUserRoleEntity : BaseModel<CrmUserRoleEntity>
    {
       	public CrmUserRoleEntity()
		{
			TB_Name = TB_CrmUserRole;
			Parm_Id = Parm_CrmUserRole_Id;
			Parm_Version = Parm_CrmUserRole_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_CrmUserRole_Insert;
			Sql_Update = Sql_CrmUserRole_Update;
			Sql_Delete = Sql_CrmUserRole_Delete;
		}
       	#region Const of table CrmUserRole
		/// <summary>
		/// Table CrmUserRole
		/// </summary>
		public const string TB_CrmUserRole = "CrmUserRole";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_CrmUserRole_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_CrmUserRole_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_CrmUserRole_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_CrmUserRole_Id = "Id";
		/// <summary>
		/// Parm RoleId
		/// </summary>
		public const string Parm_CrmUserRole_RoleId = "RoleId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_CrmUserRole_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_CrmUserRole_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_CrmUserRole_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_CrmUserRole_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm UserId
		/// </summary>
		public const string Parm_CrmUserRole_UserId = "UserId";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_CrmUserRole_Version = "Version";
		/// <summary>
		/// Insert Query Of CrmUserRole
		/// </summary>
		public const string Sql_CrmUserRole_Insert = "insert into CrmUserRole(CreateBy,CreateOn,CreatorId,RoleId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId) values(@CreateBy,@CreateOn,@CreatorId,@RoleId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId);select @@identity;";
		/// <summary>
		/// Update Query Of CrmUserRole
		/// </summary>
		public const string Sql_CrmUserRole_Update = "update CrmUserRole set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RoleId=@RoleId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_CrmUserRole_Delete = "update CrmUserRole set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _userId = string.Empty;
		/// <summary>
		/// 用户编号
		/// </summary>
		public string UserId
		{
			get{return _userId ?? string.Empty;}
			set{_userId = value;}
		}
		private string _roleId = string.Empty;
		/// <summary>
		/// 角色编号
		/// </summary>
		public string RoleId
		{
			get{return _roleId ?? string.Empty;}
			set{_roleId = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override CrmUserRoleEntity SetModelValueByDataRow(DataRow dr)
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
		public override CrmUserRoleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmUserRoleEntity();
          			if (fields.Contains(Parm_CrmUserRole_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_CrmUserRole_Id].ToString();
			if (fields.Contains(Parm_CrmUserRole_UserId) || fields.Contains("*"))
				tmp.UserId = dr[Parm_CrmUserRole_UserId].ToString();
			if (fields.Contains(Parm_CrmUserRole_RoleId) || fields.Contains("*"))
				tmp.RoleId = dr[Parm_CrmUserRole_RoleId].ToString();
			if (fields.Contains(Parm_CrmUserRole_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_CrmUserRole_RowStatus].ToString());
			if (fields.Contains(Parm_CrmUserRole_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_CrmUserRole_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_CrmUserRole_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_CrmUserRole_CreatorId].ToString();
			if (fields.Contains(Parm_CrmUserRole_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_CrmUserRole_CreateBy].ToString();
			if (fields.Contains(Parm_CrmUserRole_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_CrmUserRole_CreateOn].ToString());
			if (fields.Contains(Parm_CrmUserRole_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_CrmUserRole_UpdateId].ToString();
			if (fields.Contains(Parm_CrmUserRole_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_CrmUserRole_UpdateBy].ToString();
			if (fields.Contains(Parm_CrmUserRole_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmUserRole_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmuserrole">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(CrmUserRoleEntity crmuserrole, SqlParameter[] parms)
		{
            				parms[0].Value = crmuserrole.UserId;
				parms[1].Value = crmuserrole.RoleId;
				parms[2].Value = crmuserrole.RowStatus;
				parms[3].Value = crmuserrole.CreatorId;
				parms[4].Value = crmuserrole.CreateBy;
				parms[5].Value = crmuserrole.CreateOn;
				parms[6].Value = crmuserrole.UpdateId;
				parms[7].Value = crmuserrole.UpdateBy;
				parms[8].Value = crmuserrole.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(CrmUserRoleEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_CrmUserRole_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_CrmUserRole_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUserRole_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_CrmUserRole_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_RoleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUserRole_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUserRole_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserRole_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUserRole_Insert, parms);
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
