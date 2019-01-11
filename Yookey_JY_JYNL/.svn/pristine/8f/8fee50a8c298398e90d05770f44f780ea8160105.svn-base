//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_ATTACHEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/10 16:30:18
//  功能描述：INF_CAR_ATTACH表实体
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
    public class InfCarAttachEntity : ModelImp.BaseModel<InfCarAttachEntity>
    {
       	public InfCarAttachEntity()
		{
			TB_Name = TB_INF_CAR_ATTACH;
			Parm_Id = Parm_INF_CAR_ATTACH_Id;
			Parm_Version = Parm_INF_CAR_ATTACH_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_CAR_ATTACH_Insert;
			Sql_Update = Sql_INF_CAR_ATTACH_Update;
			Sql_Delete = Sql_INF_CAR_ATTACH_Delete;
		}
       	#region Const of table INF_CAR_ATTACH
		/// <summary>
		/// Table INF_CAR_ATTACH
		/// </summary>
		public const string TB_INF_CAR_ATTACH = "INF_CAR_ATTACH";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ClassNo
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_ClassNo = "ClassNo";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateDate
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_CreateDate = "CreateDate";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FileDesc
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_FileDesc = "FileDesc";
		/// <summary>
		/// Parm FileName
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_FileName = "FileName";
		/// <summary>
		/// Parm FilereMark
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_FilereMark = "FilereMark";
		/// <summary>
		/// Parm FileType
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_FileType = "FileType";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_Id = "Id";
		/// <summary>
		/// Parm ImgAddress
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_ImgAddress = "ImgAddress";
		/// <summary>
		/// Parm ResourceId
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_ResourceId = "ResourceId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_RowStatus = "RowStatus";
		/// <summary>
		/// Parm ShootTime
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_ShootTime = "ShootTime";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_CAR_ATTACH_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_CAR_ATTACH
		/// </summary>
		public const string Sql_INF_CAR_ATTACH_Insert = "insert into INF_CAR_ATTACH(ClassNo,CreateBy,CreateDate,CreateOn,CreatorId,FileDesc,FileName,FilereMark,FileType,ImgAddress,ResourceId,RowStatus,ShootTime,UpdateBy,UpdateId,UpdateOn) values(@ClassNo,@CreateBy,@CreateDate,@CreateOn,@CreatorId,@FileDesc,@FileName,@FilereMark,@FileType,@ImgAddress,@ResourceId,@RowStatus,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of INF_CAR_ATTACH
		/// </summary>
		public const string Sql_INF_CAR_ATTACH_Update = "update INF_CAR_ATTACH set ClassNo=@ClassNo,CreateBy=@CreateBy,CreateDate=@CreateDate,CreateOn=@CreateOn,CreatorId=@CreatorId,FileDesc=@FileDesc,FileName=@FileName,FilereMark=@FilereMark,FileType=@FileType,ImgAddress=@ImgAddress,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_CAR_ATTACH_Delete = "update INF_CAR_ATTACH set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _resourceId = string.Empty;
		/// <summary>
		/// String(50
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
		private string _fileDesc = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileDesc
		{
			get{return _fileDesc ?? string.Empty;}
			set{_fileDesc = value;}
		}
		private string _classNo = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ClassNo
		{
			get{return _classNo ?? string.Empty;}
			set{_classNo = value;}
		}
		private DateTime _createDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			get{return _createDate;}
			set{_createDate = value;}
		}
		private string _fileType = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileType
		{
			get{return _fileType ?? string.Empty;}
			set{_fileType = value;}
		}
		private string _filereMark = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FilereMark
		{
			get{return _filereMark ?? string.Empty;}
			set{_filereMark = value;}
		}
		private string _imgAddress = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ImgAddress
		{
			get{return _imgAddress ?? string.Empty;}
			set{_imgAddress = value;}
		}
		private DateTime _shootTime = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime ShootTime
		{
			get{return _shootTime;}
			set{_shootTime = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfCarAttachEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfCarAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfCarAttachEntity();
          			if (fields.Contains(Parm_INF_CAR_ATTACH_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_CAR_ATTACH_Id].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_ResourceId) || fields.Contains("*"))
				tmp.ResourceId = dr[Parm_INF_CAR_ATTACH_ResourceId].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_FileName) || fields.Contains("*"))
				tmp.FileName = dr[Parm_INF_CAR_ATTACH_FileName].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_FileDesc) || fields.Contains("*"))
				tmp.FileDesc = dr[Parm_INF_CAR_ATTACH_FileDesc].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_ClassNo) || fields.Contains("*"))
				tmp.ClassNo = dr[Parm_INF_CAR_ATTACH_ClassNo].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_CreateDate) || fields.Contains("*"))
				tmp.CreateDate = DateTime.Parse(dr[Parm_INF_CAR_ATTACH_CreateDate].ToString());
			if (fields.Contains(Parm_INF_CAR_ATTACH_FileType) || fields.Contains("*"))
				tmp.FileType = dr[Parm_INF_CAR_ATTACH_FileType].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_FilereMark) || fields.Contains("*"))
				tmp.FilereMark = dr[Parm_INF_CAR_ATTACH_FilereMark].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_ImgAddress) || fields.Contains("*"))
				tmp.ImgAddress = dr[Parm_INF_CAR_ATTACH_ImgAddress].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_ShootTime) || fields.Contains("*"))
				tmp.ShootTime = DateTime.Parse(dr[Parm_INF_CAR_ATTACH_ShootTime].ToString());
			if (fields.Contains(Parm_INF_CAR_ATTACH_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_CAR_ATTACH_RowStatus].ToString());
			if (fields.Contains(Parm_INF_CAR_ATTACH_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_CAR_ATTACH_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_CAR_ATTACH_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_CAR_ATTACH_CreatorId].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_CAR_ATTACH_CreateBy].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_CAR_ATTACH_CreateOn].ToString());
			if (fields.Contains(Parm_INF_CAR_ATTACH_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_CAR_ATTACH_UpdateId].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_CAR_ATTACH_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_CAR_ATTACH_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_CAR_ATTACH_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_car_attach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfCarAttachEntity inf_car_attach, SqlParameter[] parms)
		{
            				parms[0].Value = inf_car_attach.ResourceId;
				parms[1].Value = inf_car_attach.FileName;
				parms[2].Value = inf_car_attach.FileDesc;
				parms[3].Value = inf_car_attach.ClassNo;
				parms[4].Value = inf_car_attach.CreateDate;
				parms[5].Value = inf_car_attach.FileType;
				parms[6].Value = inf_car_attach.FilereMark;
				parms[7].Value = inf_car_attach.ImgAddress;
				parms[8].Value = inf_car_attach.ShootTime;
				parms[9].Value = inf_car_attach.RowStatus;
				parms[10].Value = inf_car_attach.CreatorId;
				parms[11].Value = inf_car_attach.CreateBy;
				parms[12].Value = inf_car_attach.CreateOn;
				parms[13].Value = inf_car_attach.UpdateId;
				parms[14].Value = inf_car_attach.UpdateBy;
				parms[15].Value = inf_car_attach.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfCarAttachEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_INF_CAR_ATTACH_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_INF_CAR_ATTACH_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_ATTACH_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_CAR_ATTACH_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_FileName, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_CAR_ATTACH_FileDesc, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_CAR_ATTACH_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_CreateDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_ATTACH_FileType, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_ATTACH_FilereMark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_CAR_ATTACH_ImgAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_CAR_ATTACH_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_ATTACH_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_ATTACH_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_ATTACH_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_UpdateBy, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_CAR_ATTACH_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_ATTACH_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
