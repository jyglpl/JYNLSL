//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseMaterialCatalogueEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:43
//  功能描述：LicenseMaterialCatalogue表实体
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
    /// 审批事项材料目录
    /// </summary>
    [Serializable]
    public class LicenseMaterialCatalogueEntity : ModelImp.BaseModel<LicenseMaterialCatalogueEntity>
    {
       	public LicenseMaterialCatalogueEntity()
		{
			TB_Name = TB_LicenseMaterialCatalogue;
			Parm_Id = Parm_LicenseMaterialCatalogue_Id;
			Parm_Version = Parm_LicenseMaterialCatalogue_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_LicenseMaterialCatalogue_Insert;
			Sql_Update = Sql_LicenseMaterialCatalogue_Update;
			Sql_Delete = Sql_LicenseMaterialCatalogue_Delete;
		}
       	#region Const of table LicenseMaterialCatalogue
		/// <summary>
		/// Table LicenseMaterialCatalogue
		/// </summary>
		public const string TB_LicenseMaterialCatalogue = "LicenseMaterialCatalogue";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_Id = "Id";
		/// <summary>
		/// Parm ItemCode
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_ItemCode = "ItemCode";
		/// <summary>
		/// Parm MaterialName
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_MaterialName = "MaterialName";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_RowStatus = "RowStatus";
		/// <summary>
		/// Parm SortNo
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_SortNo = "SortNo";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_LicenseMaterialCatalogue_Version = "Version";
		/// <summary>
		/// Insert Query Of LicenseMaterialCatalogue
		/// </summary>
		public const string Sql_LicenseMaterialCatalogue_Insert = "insert into LicenseMaterialCatalogue(CreateBy,CreateOn,CreatorId,ItemCode,MaterialName,RowStatus,SortNo,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@ItemCode,@MaterialName,@RowStatus,@SortNo,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of LicenseMaterialCatalogue
		/// </summary>
		public const string Sql_LicenseMaterialCatalogue_Update = "update LicenseMaterialCatalogue set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ItemCode=@ItemCode,MaterialName=@MaterialName,RowStatus=@RowStatus,SortNo=@SortNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_LicenseMaterialCatalogue_Delete = "update LicenseMaterialCatalogue set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _itemCode = string.Empty;
		/// <summary>
		/// 事项编码
		/// </summary>
		public string ItemCode
		{
			get{return _itemCode ?? string.Empty;}
			set{_itemCode = value;}
		}
		private string _materialName = string.Empty;
		/// <summary>
		/// 材料名称
		/// </summary>
		public string MaterialName
		{
			get{return _materialName ?? string.Empty;}
			set{_materialName = value;}
		}
		private int _sortNo;
		/// <summary>
		/// 
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
		public override LicenseMaterialCatalogueEntity SetModelValueByDataRow(DataRow dr)
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
		public override LicenseMaterialCatalogueEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseMaterialCatalogueEntity();
          			if (fields.Contains(Parm_LicenseMaterialCatalogue_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_LicenseMaterialCatalogue_Id].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_ItemCode) || fields.Contains("*"))
				tmp.ItemCode = dr[Parm_LicenseMaterialCatalogue_ItemCode].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_MaterialName) || fields.Contains("*"))
				tmp.MaterialName = dr[Parm_LicenseMaterialCatalogue_MaterialName].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_SortNo) || fields.Contains("*"))
				tmp.SortNo = int.Parse(dr[Parm_LicenseMaterialCatalogue_SortNo].ToString());
			if (fields.Contains(Parm_LicenseMaterialCatalogue_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_LicenseMaterialCatalogue_RowStatus].ToString());
			if (fields.Contains(Parm_LicenseMaterialCatalogue_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_LicenseMaterialCatalogue_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_LicenseMaterialCatalogue_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_LicenseMaterialCatalogue_CreatorId].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_LicenseMaterialCatalogue_CreateBy].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseMaterialCatalogue_CreateOn].ToString());
			if (fields.Contains(Parm_LicenseMaterialCatalogue_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_LicenseMaterialCatalogue_UpdateId].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_LicenseMaterialCatalogue_UpdateBy].ToString();
			if (fields.Contains(Parm_LicenseMaterialCatalogue_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseMaterialCatalogue_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensematerialcatalogue">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(LicenseMaterialCatalogueEntity licensematerialcatalogue, SqlParameter[] parms)
		{
            				parms[0].Value = licensematerialcatalogue.ItemCode;
				parms[1].Value = licensematerialcatalogue.MaterialName;
				parms[2].Value = licensematerialcatalogue.SortNo;
				parms[3].Value = licensematerialcatalogue.RowStatus;
				parms[4].Value = licensematerialcatalogue.CreatorId;
				parms[5].Value = licensematerialcatalogue.CreateBy;
				parms[6].Value = licensematerialcatalogue.CreateOn;
				parms[7].Value = licensematerialcatalogue.UpdateId;
				parms[8].Value = licensematerialcatalogue.UpdateBy;
				parms[9].Value = licensematerialcatalogue.UpdateOn;
                parms[10].Value = licensematerialcatalogue.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseMaterialCatalogueEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseMaterialCatalogue_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_LicenseMaterialCatalogue_ItemCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMaterialCatalogue_MaterialName, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_LicenseMaterialCatalogue_SortNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMaterialCatalogue_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMaterialCatalogue_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMaterialCatalogue_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMaterialCatalogue_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMaterialCatalogue_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMaterialCatalogue_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMaterialCatalogue_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseMaterialCatalogue_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseMaterialCatalogue_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
