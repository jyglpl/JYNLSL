//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmOpinionsEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/26 15:16:41
//  功能描述：CrmOpinions表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 常用意见
    /// </summary>
    [Serializable]
    public class CrmOpinionsEntity : ModelImp.BaseModel<CrmOpinionsEntity>
    {
       	public CrmOpinionsEntity()
		{
			TB_Name = TB_CrmOpinions;
			Parm_Id = Parm_CrmOpinions_Id;
			Parm_Version = Parm_CrmOpinions_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_CrmOpinions_Insert;
			Sql_Update = Sql_CrmOpinions_Update;
			Sql_Delete = Sql_CrmOpinions_Delete;
		}
       	#region Const of table CrmOpinions
		/// <summary>
		/// Table CrmOpinions
		/// </summary>
		public const string TB_CrmOpinions = "CrmOpinions";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Contents
		/// </summary>
		public const string Parm_CrmOpinions_Contents = "Contents";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_CrmOpinions_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_CrmOpinions_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_CrmOpinions_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_CrmOpinions_Id = "Id";
		/// <summary>
		/// Parm OpType
		/// </summary>
		public const string Parm_CrmOpinions_OpType = "OpType";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_CrmOpinions_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_CrmOpinions_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_CrmOpinions_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_CrmOpinions_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_CrmOpinions_Version = "Version";
		/// <summary>
		/// Insert Query Of CrmOpinions
		/// </summary>
		public const string Sql_CrmOpinions_Insert = "insert into CrmOpinions(Contents,CreateBy,CreateOn,CreatorId,OpType,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@Contents,@CreateBy,@CreateOn,@CreatorId,@OpType,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of CrmOpinions
		/// </summary>
		public const string Sql_CrmOpinions_Update = "update CrmOpinions set Contents=@Contents,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OpType=@OpType,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_CrmOpinions_Delete = "update CrmOpinions set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _contents = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Contents
		{
			get{return _contents ?? string.Empty;}
			set{_contents = value;}
		}
		private string _opType = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string OpType
		{
			get{return _opType ?? string.Empty;}
			set{_opType = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override CrmOpinionsEntity SetModelValueByDataRow(DataRow dr)
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
		public override CrmOpinionsEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmOpinionsEntity();
          			if (fields.Contains(Parm_CrmOpinions_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_CrmOpinions_Id].ToString();
			if (fields.Contains(Parm_CrmOpinions_Contents) || fields.Contains("*"))
				tmp.Contents = dr[Parm_CrmOpinions_Contents].ToString();
			if (fields.Contains(Parm_CrmOpinions_OpType) || fields.Contains("*"))
				tmp.OpType = dr[Parm_CrmOpinions_OpType].ToString();
			if (fields.Contains(Parm_CrmOpinions_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_CrmOpinions_RowStatus].ToString());
			if (fields.Contains(Parm_CrmOpinions_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_CrmOpinions_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_CrmOpinions_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_CrmOpinions_CreatorId].ToString();
			if (fields.Contains(Parm_CrmOpinions_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_CrmOpinions_CreateBy].ToString();
			if (fields.Contains(Parm_CrmOpinions_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_CrmOpinions_CreateOn].ToString());
			if (fields.Contains(Parm_CrmOpinions_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_CrmOpinions_UpdateId].ToString();
			if (fields.Contains(Parm_CrmOpinions_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_CrmOpinions_UpdateBy].ToString();
			if (fields.Contains(Parm_CrmOpinions_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmOpinions_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmopinions">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(CrmOpinionsEntity crmopinions, SqlParameter[] parms)
		{
            				parms[0].Value = crmopinions.Contents;
				parms[1].Value = crmopinions.OpType;
				parms[2].Value = crmopinions.RowStatus;
				parms[3].Value = crmopinions.CreatorId;
				parms[4].Value = crmopinions.CreateBy;
				parms[5].Value = crmopinions.CreateOn;
				parms[6].Value = crmopinions.UpdateId;
				parms[7].Value = crmopinions.UpdateBy;
				parms[8].Value = crmopinions.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(CrmOpinionsEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_CrmOpinions_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_CrmOpinions_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmOpinions_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_CrmOpinions_Contents, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmOpinions_OpType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmOpinions_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmOpinions_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmOpinions_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmOpinions_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmOpinions_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmOpinions_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmOpinions_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmOpinions_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
