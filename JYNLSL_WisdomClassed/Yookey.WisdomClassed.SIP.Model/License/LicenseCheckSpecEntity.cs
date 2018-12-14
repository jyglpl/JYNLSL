//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseCheckSpecEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/2/5 15:50:54
//  功能描述：LicenseCheckSpec表实体
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
    /// 许可现场踏勘规格信息
    /// </summary>
    [Serializable]
    public class LicenseCheckSpecEntity : ModelImp.BaseModel<LicenseCheckSpecEntity>
    {
       	public LicenseCheckSpecEntity()
		{
			TB_Name = TB_LicenseCheckSpec;
			Parm_Id = Parm_LicenseCheckSpec_Id;
			Parm_Version = Parm_LicenseCheckSpec_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_LicenseCheckSpec_Insert;
			Sql_Update = Sql_LicenseCheckSpec_Update;
			Sql_Delete = Sql_LicenseCheckSpec_Delete;
		}
       	#region Const of table LicenseCheckSpec
		/// <summary>
		/// Table LicenseCheckSpec
		/// </summary>
		public const string TB_LicenseCheckSpec = "LicenseCheckSpec";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CheckType
		/// </summary>
		public const string Parm_LicenseCheckSpec_CheckType = "CheckType";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_LicenseCheckSpec_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_LicenseCheckSpec_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_LicenseCheckSpec_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FacilityType
		/// </summary>
		public const string Parm_LicenseCheckSpec_FacilityType = "FacilityType";
		/// <summary>
		/// Parm Height
		/// </summary>
		public const string Parm_LicenseCheckSpec_Height = "Height";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_LicenseCheckSpec_Id = "Id";
		/// <summary>
		/// Parm LicenseId
		/// </summary>
		public const string Parm_LicenseCheckSpec_LicenseId = "LicenseId";
		/// <summary>
		/// Parm Long
		/// </summary>
		public const string Parm_LicenseCheckSpec_Long = "Long";
		/// <summary>
		/// Parm OtherType
		/// </summary>
		public const string Parm_LicenseCheckSpec_OtherType = "OtherType";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_LicenseCheckSpec_RowStatus = "RowStatus";
		/// <summary>
		/// Parm SortNo
		/// </summary>
		public const string Parm_LicenseCheckSpec_SortNo = "SortNo";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_LicenseCheckSpec_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_LicenseCheckSpec_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_LicenseCheckSpec_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_LicenseCheckSpec_Version = "Version";
		/// <summary>
		/// Parm Width
		/// </summary>
		public const string Parm_LicenseCheckSpec_Width = "Width";
		/// <summary>
		/// Insert Query Of LicenseCheckSpec
		/// </summary>
		public const string Sql_LicenseCheckSpec_Insert = "insert into LicenseCheckSpec(CheckType,CreateBy,CreateOn,CreatorId,FacilityType,Height,LicenseId,Long,OtherType,RowStatus,SortNo,UpdateBy,UpdateId,UpdateOn,Width,Id) values(@CheckType,@CreateBy,@CreateOn,@CreatorId,@FacilityType,@Height,@LicenseId,@Long,@OtherType,@RowStatus,@SortNo,@UpdateBy,@UpdateId,@UpdateOn,@Width,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of LicenseCheckSpec
		/// </summary>
		public const string Sql_LicenseCheckSpec_Update = "update LicenseCheckSpec set CheckType=@CheckType,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FacilityType=@FacilityType,Height=@Height,LicenseId=@LicenseId,Long=@Long,OtherType=@OtherType,RowStatus=@RowStatus,SortNo=@SortNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Width=@Width where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_LicenseCheckSpec_Delete = "update LicenseCheckSpec set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _licenseId = string.Empty;
		/// <summary>
		/// 许可办件主键
		/// </summary>
		public string LicenseId
		{
			get{return _licenseId ?? string.Empty;}
			set{_licenseId = value;}
		}
		private int _checkType;
		/// <summary>
		/// 0：现场勘验  1：现场验收
		/// </summary>
		public int CheckType
		{
			get{return _checkType;}
			set{_checkType = value;}
		}
		private string _width = string.Empty;
		/// <summary>
		/// 宽
		/// </summary>
		public string Width
		{
			get{return _width ?? string.Empty;}
			set{_width = value;}
		}
		private string _height = string.Empty;
		/// <summary>
		/// 高
		/// </summary>
		public string Height
		{
			get{return _height ?? string.Empty;}
			set{_height = value;}
		}
		private string _long = string.Empty;
		/// <summary>
		/// 外挑/架空
		/// </summary>
		public string Long
		{
			get{return _long ?? string.Empty;}
			set{_long = value;}
		}
		private string _facilityType = string.Empty;
		/// <summary>
		/// 设施类型
		/// </summary>
		public string FacilityType
		{
			get{return _facilityType ?? string.Empty;}
			set{_facilityType = value;}
		}
		private string _otherType = string.Empty;
		/// <summary>
		/// 其他类型
		/// </summary>
		public string OtherType
		{
			get{return _otherType ?? string.Empty;}
			set{_otherType = value;}
		}
		private int _sortNo;
		/// <summary>
		/// 排列顺序
		/// </summary>
		public int SortNo
		{
			get{return _sortNo;}
			set{_sortNo = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override LicenseCheckSpecEntity SetModelValueByDataRow(DataRow dr)
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
		public override LicenseCheckSpecEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseCheckSpecEntity();
          			if (fields.Contains(Parm_LicenseCheckSpec_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_LicenseCheckSpec_Id].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_LicenseId) || fields.Contains("*"))
				tmp.LicenseId = dr[Parm_LicenseCheckSpec_LicenseId].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_CheckType) || fields.Contains("*"))
				tmp.CheckType = int.Parse(dr[Parm_LicenseCheckSpec_CheckType].ToString());
			if (fields.Contains(Parm_LicenseCheckSpec_Width) || fields.Contains("*"))
				tmp.Width = dr[Parm_LicenseCheckSpec_Width].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_Height) || fields.Contains("*"))
				tmp.Height = dr[Parm_LicenseCheckSpec_Height].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_Long) || fields.Contains("*"))
				tmp.Long = dr[Parm_LicenseCheckSpec_Long].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_FacilityType) || fields.Contains("*"))
				tmp.FacilityType = dr[Parm_LicenseCheckSpec_FacilityType].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_OtherType) || fields.Contains("*"))
				tmp.OtherType = dr[Parm_LicenseCheckSpec_OtherType].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_SortNo) || fields.Contains("*"))
				tmp.SortNo = int.Parse(dr[Parm_LicenseCheckSpec_SortNo].ToString());
			if (fields.Contains(Parm_LicenseCheckSpec_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_LicenseCheckSpec_RowStatus].ToString());
			if (fields.Contains(Parm_LicenseCheckSpec_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_LicenseCheckSpec_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_LicenseCheckSpec_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_LicenseCheckSpec_CreatorId].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_LicenseCheckSpec_CreateBy].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseCheckSpec_CreateOn].ToString());
			if (fields.Contains(Parm_LicenseCheckSpec_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_LicenseCheckSpec_UpdateId].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_LicenseCheckSpec_UpdateBy].ToString();
			if (fields.Contains(Parm_LicenseCheckSpec_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseCheckSpec_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensecheckspec">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(LicenseCheckSpecEntity licensecheckspec, SqlParameter[] parms)
		{
            				parms[0].Value = licensecheckspec.LicenseId;
				parms[1].Value = licensecheckspec.CheckType;
				parms[2].Value = licensecheckspec.Width;
				parms[3].Value = licensecheckspec.Height;
				parms[4].Value = licensecheckspec.Long;
				parms[5].Value = licensecheckspec.FacilityType;
				parms[6].Value = licensecheckspec.OtherType;
				parms[7].Value = licensecheckspec.SortNo;
				parms[8].Value = licensecheckspec.RowStatus;
				parms[9].Value = licensecheckspec.CreatorId;
				parms[10].Value = licensecheckspec.CreateBy;
				parms[11].Value = licensecheckspec.CreateOn;
				parms[12].Value = licensecheckspec.UpdateId;
				parms[13].Value = licensecheckspec.UpdateBy;
				parms[14].Value = licensecheckspec.UpdateOn;
                parms[15].Value = licensecheckspec.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseCheckSpecEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseCheckSpec_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_LicenseCheckSpec_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_CheckType, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseCheckSpec_Width, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseCheckSpec_Height, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseCheckSpec_Long, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseCheckSpec_FacilityType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_OtherType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_SortNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseCheckSpec_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseCheckSpec_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseCheckSpec_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseCheckSpec_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseCheckSpec_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseCheckSpec_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                       
