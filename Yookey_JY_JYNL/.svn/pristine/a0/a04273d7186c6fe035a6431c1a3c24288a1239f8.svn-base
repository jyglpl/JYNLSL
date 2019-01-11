//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseInquestSizeEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-04-03 11:11:59
//  功能描述：LicenseInquestSize表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.License
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LicenseInquestSizeEntity : ModelImp.BaseModel<LicenseInquestSizeEntity>
    {
       	public LicenseInquestSizeEntity()
		{
			TB_Name = TB_LicenseInquestSize;
			Parm_Id = Parm_LicenseInquestSize_Id;
			Parm_Version = Parm_LicenseInquestSize_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_LicenseInquestSize_Insert;
			Sql_Update = Sql_LicenseInquestSize_Update;
			Sql_Delete = Sql_LicenseInquestSize_Delete;
		}
       	#region Const of table LicenseInquestSize
		/// <summary>
		/// Table LicenseInquestSize
		/// </summary>
		public const string TB_LicenseInquestSize = "LicenseInquestSize";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CheckLeftHeight
		/// </summary>
		public const string Parm_LicenseInquestSize_CheckLeftHeight = "CheckLeftHeight";
		/// <summary>
		/// Parm CheckLeftLogn
		/// </summary>
		public const string Parm_LicenseInquestSize_CheckLeftLogn = "CheckLeftLogn";
		/// <summary>
		/// Parm CheckRightHeight
		/// </summary>
		public const string Parm_LicenseInquestSize_CheckRightHeight = "CheckRightHeight";
		/// <summary>
		/// Parm CheckRightLogn
		/// </summary>
		public const string Parm_LicenseInquestSize_CheckRightLogn = "CheckRightLogn";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_LicenseInquestSize_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_LicenseInquestSize_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_LicenseInquestSize_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_LicenseInquestSize_Id = "Id";
		/// <summary>
		/// Parm LicenseId
		/// </summary>
		public const string Parm_LicenseInquestSize_LicenseId = "LicenseId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_LicenseInquestSize_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_LicenseInquestSize_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_LicenseInquestSize_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_LicenseInquestSize_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_LicenseInquestSize_Version = "Version";
		/// <summary>
		/// Insert Query Of LicenseInquestSize
		/// </summary>
		public const string Sql_LicenseInquestSize_Insert = "insert into LicenseInquestSize(CheckLeftHeight,CheckLeftLogn,CheckRightHeight,CheckRightLogn,CreateBy,CreateOn,CreatorId,LicenseId,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CheckLeftHeight,@CheckLeftLogn,@CheckRightHeight,@CheckRightLogn,@CreateBy,@CreateOn,@CreatorId,@LicenseId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of LicenseInquestSize
		/// </summary>
		public const string Sql_LicenseInquestSize_Update = "update LicenseInquestSize set CheckLeftHeight=@CheckLeftHeight,CheckLeftLogn=@CheckLeftLogn,CheckRightHeight=@CheckRightHeight,CheckRightLogn=@CheckRightLogn,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,LicenseId=@LicenseId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_LicenseInquestSize_Delete = "update LicenseInquestSize set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _licenseId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LicenseId
		{
			get{return _licenseId ?? string.Empty;}
			set{_licenseId = value;}
		}
		private string _checkLeftHeight = string.Empty;
		/// <summary>
		/// 勘验左领高度
		/// </summary>
		public string CheckLeftHeight
		{
			get{return _checkLeftHeight ?? string.Empty;}
			set{_checkLeftHeight = value;}
		}
		private string _checkRightHeight = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CheckRightHeight
		{
			get{return _checkRightHeight ?? string.Empty;}
			set{_checkRightHeight = value;}
		}
		private string _checkLeftLogn = string.Empty;
		/// <summary>
		/// 勘验左领外挑
		/// </summary>
		public string CheckLeftLogn
		{
			get{return _checkLeftLogn ?? string.Empty;}
			set{_checkLeftLogn = value;}
		}
		private string _checkRightLogn = string.Empty;
		/// <summary>
		/// 勘验右领外挑
		/// </summary>
		public string CheckRightLogn
		{
			get{return _checkRightLogn ?? string.Empty;}
			set{_checkRightLogn = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override LicenseInquestSizeEntity SetModelValueByDataRow(DataRow dr)
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
		public override LicenseInquestSizeEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseInquestSizeEntity();
          			if (fields.Contains(Parm_LicenseInquestSize_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_LicenseInquestSize_Id].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_LicenseId) || fields.Contains("*"))
				tmp.LicenseId = dr[Parm_LicenseInquestSize_LicenseId].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CheckLeftHeight) || fields.Contains("*"))
				tmp.CheckLeftHeight = dr[Parm_LicenseInquestSize_CheckLeftHeight].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CheckRightHeight) || fields.Contains("*"))
				tmp.CheckRightHeight = dr[Parm_LicenseInquestSize_CheckRightHeight].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CheckLeftLogn) || fields.Contains("*"))
				tmp.CheckLeftLogn = dr[Parm_LicenseInquestSize_CheckLeftLogn].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CheckRightLogn) || fields.Contains("*"))
				tmp.CheckRightLogn = dr[Parm_LicenseInquestSize_CheckRightLogn].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_LicenseInquestSize_RowStatus].ToString());
			if (fields.Contains(Parm_LicenseInquestSize_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_LicenseInquestSize_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_LicenseInquestSize_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_LicenseInquestSize_CreatorId].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_LicenseInquestSize_CreateBy].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseInquestSize_CreateOn].ToString());
			if (fields.Contains(Parm_LicenseInquestSize_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_LicenseInquestSize_UpdateId].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_LicenseInquestSize_UpdateBy].ToString();
			if (fields.Contains(Parm_LicenseInquestSize_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseInquestSize_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licenseinquestsize">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(LicenseInquestSizeEntity licenseinquestsize, SqlParameter[] parms)
		{
            				parms[0].Value = licenseinquestsize.LicenseId;
				parms[1].Value = licenseinquestsize.CheckLeftHeight;
				parms[2].Value = licenseinquestsize.CheckRightHeight;
				parms[3].Value = licenseinquestsize.CheckLeftLogn;
				parms[4].Value = licenseinquestsize.CheckRightLogn;
				parms[5].Value = licenseinquestsize.RowStatus;
				parms[6].Value = licenseinquestsize.CreatorId;
				parms[7].Value = licenseinquestsize.CreateBy;
				parms[8].Value = licenseinquestsize.CreateOn;
				parms[9].Value = licenseinquestsize.UpdateId;
				parms[10].Value = licenseinquestsize.UpdateBy;
				parms[11].Value = licenseinquestsize.UpdateOn;
                parms[12].Value = licenseinquestsize.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseInquestSizeEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseInquestSize_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_LicenseInquestSize_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseInquestSize_CheckLeftHeight, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseInquestSize_CheckRightHeight, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseInquestSize_CheckLeftLogn, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseInquestSize_CheckRightLogn, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseInquestSize_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseInquestSize_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseInquestSize_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseInquestSize_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseInquestSize_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseInquestSize_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseInquestSize_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseInquestSize_Id, SqlDbType.NVarChar, 50)
				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseInquestSize_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
