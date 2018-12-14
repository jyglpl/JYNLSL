//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseAttachEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:44
//  功能描述：LicenseAttach表实体
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
    /// 许可附件表
    /// </summary>
    [Serializable]
    public class LicenseAttachEntity : ModelImp.BaseModel<LicenseAttachEntity>
    {
       	public LicenseAttachEntity()
		{
			TB_Name = TB_LicenseAttach;
			Parm_Id = Parm_LicenseAttach_Id;
			Parm_Version = Parm_LicenseAttach_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_LicenseAttach_Insert;
			Sql_Update = Sql_LicenseAttach_Update;
			Sql_Delete = Sql_LicenseAttach_Delete;
		}
       	#region Const of table LicenseAttach
		/// <summary>
		/// Table LicenseAttach
		/// </summary>
		public const string TB_LicenseAttach = "LicenseAttach";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_LicenseAttach_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_LicenseAttach_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_LicenseAttach_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FileAddress
		/// </summary>
		public const string Parm_LicenseAttach_FileAddress = "FileAddress";
		/// <summary>
		/// Parm FileName
		/// </summary>
		public const string Parm_LicenseAttach_FileName = "FileName";
		/// <summary>
		/// Parm FileRemark
		/// </summary>
		public const string Parm_LicenseAttach_FileRemark = "FileRemark";
		/// <summary>
		/// Parm FileReName
		/// </summary>
		public const string Parm_LicenseAttach_FileReName = "FileReName";
		/// <summary>
		/// Parm FileSize
		/// </summary>
		public const string Parm_LicenseAttach_FileSize = "FileSize";
		/// <summary>
		/// Parm FileType
		/// </summary>
		public const string Parm_LicenseAttach_FileType = "FileType";
		/// <summary>
		/// Parm FileTypeName
		/// </summary>
		public const string Parm_LicenseAttach_FileTypeName = "FileTypeName";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_LicenseAttach_Id = "Id";
		/// <summary>
		/// Parm ResourceId
		/// </summary>
		public const string Parm_LicenseAttach_ResourceId = "ResourceId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_LicenseAttach_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_LicenseAttach_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_LicenseAttach_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_LicenseAttach_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_LicenseAttach_Version = "Version";
		/// <summary>
		/// Insert Query Of LicenseAttach
		/// </summary>
		public const string Sql_LicenseAttach_Insert = "insert into LicenseAttach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,ResourceId,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@ResourceId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of LicenseAttach
		/// </summary>
		public const string Sql_LicenseAttach_Update = "update LicenseAttach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,ResourceId=@ResourceId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_LicenseAttach_Delete = "update LicenseAttach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _resourceId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ResourceId
		{
			get{return _resourceId ?? string.Empty;}
			set{_resourceId = value;}
		}
		private string _fileName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			get{return _fileName ?? string.Empty;}
			set{_fileName = value;}
		}
		private string _fileReName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileReName
		{
			get{return _fileReName ?? string.Empty;}
			set{_fileReName = value;}
		}
		private string _fileSize = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileSize
		{
			get{return _fileSize ?? string.Empty;}
			set{_fileSize = value;}
		}
		private string _fileAddress = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileAddress
		{
			get{return _fileAddress ?? string.Empty;}
			set{_fileAddress = value;}
		}
		private string _fileType = string.Empty;
		/// <summary>
		/// 类型：材料目录ID、踏验ID
		/// </summary>
		public string FileType
		{
			get{return _fileType ?? string.Empty;}
			set{_fileType = value;}
		}
		private string _fileTypeName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileTypeName
		{
			get{return _fileTypeName ?? string.Empty;}
			set{_fileTypeName = value;}
		}
		private string _fileRemark = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileRemark
		{
			get{return _fileRemark ?? string.Empty;}
			set{_fileRemark = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override LicenseAttachEntity SetModelValueByDataRow(DataRow dr)
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
		public override LicenseAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseAttachEntity();
          			if (fields.Contains(Parm_LicenseAttach_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_LicenseAttach_Id].ToString();
			if (fields.Contains(Parm_LicenseAttach_ResourceId) || fields.Contains("*"))
				tmp.ResourceId = dr[Parm_LicenseAttach_ResourceId].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileName) || fields.Contains("*"))
				tmp.FileName = dr[Parm_LicenseAttach_FileName].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileReName) || fields.Contains("*"))
				tmp.FileReName = dr[Parm_LicenseAttach_FileReName].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileSize) || fields.Contains("*"))
				tmp.FileSize = dr[Parm_LicenseAttach_FileSize].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileAddress) || fields.Contains("*"))
				tmp.FileAddress = dr[Parm_LicenseAttach_FileAddress].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileType) || fields.Contains("*"))
				tmp.FileType = dr[Parm_LicenseAttach_FileType].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileTypeName) || fields.Contains("*"))
				tmp.FileTypeName = dr[Parm_LicenseAttach_FileTypeName].ToString();
			if (fields.Contains(Parm_LicenseAttach_FileRemark) || fields.Contains("*"))
				tmp.FileRemark = dr[Parm_LicenseAttach_FileRemark].ToString();
			if (fields.Contains(Parm_LicenseAttach_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_LicenseAttach_RowStatus].ToString());
			if (fields.Contains(Parm_LicenseAttach_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_LicenseAttach_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_LicenseAttach_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_LicenseAttach_CreatorId].ToString();
			if (fields.Contains(Parm_LicenseAttach_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_LicenseAttach_CreateBy].ToString();
			if (fields.Contains(Parm_LicenseAttach_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseAttach_CreateOn].ToString());
			if (fields.Contains(Parm_LicenseAttach_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_LicenseAttach_UpdateId].ToString();
			if (fields.Contains(Parm_LicenseAttach_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_LicenseAttach_UpdateBy].ToString();
			if (fields.Contains(Parm_LicenseAttach_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseAttach_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licenseattach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(LicenseAttachEntity licenseattach, SqlParameter[] parms)
		{
            				parms[0].Value = licenseattach.ResourceId;
				parms[1].Value = licenseattach.FileName;
				parms[2].Value = licenseattach.FileReName;
				parms[3].Value = licenseattach.FileSize;
				parms[4].Value = licenseattach.FileAddress;
				parms[5].Value = licenseattach.FileType;
				parms[6].Value = licenseattach.FileTypeName;
				parms[7].Value = licenseattach.FileRemark;
				parms[8].Value = licenseattach.RowStatus;
				parms[9].Value = licenseattach.CreatorId;
				parms[10].Value = licenseattach.CreateBy;
				parms[11].Value = licenseattach.CreateOn;
				parms[12].Value = licenseattach.UpdateId;
				parms[13].Value = licenseattach.UpdateBy;
				parms[14].Value = licenseattach.UpdateOn;
                parms[15].Value = licenseattach.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseAttachEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseAttach_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_LicenseAttach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_LicenseAttach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseAttach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseAttach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseAttach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseAttach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseAttach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseAttach_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
