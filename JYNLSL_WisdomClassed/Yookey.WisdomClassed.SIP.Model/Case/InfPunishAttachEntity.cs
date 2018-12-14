//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_ATTACHEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/21 13:30:38
//  功能描述：INF_PUNISH_ATTACH表实体
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
    /// 案件附件
    /// </summary>
    [Serializable]
    public class InfPunishAttachEntity : ModelImp.BaseModel<InfPunishAttachEntity>
    {
       	public InfPunishAttachEntity()
		{
			TB_Name = TB_INF_PUNISH_ATTACH;
			Parm_Id = Parm_INF_PUNISH_ATTACH_Id;
			Parm_Version = Parm_INF_PUNISH_ATTACH_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_ATTACH_Insert;
			Sql_Update = Sql_INF_PUNISH_ATTACH_Update;
			Sql_Delete = Sql_INF_PUNISH_ATTACH_Delete;
		}
       	#region Const of table INF_PUNISH_ATTACH
		/// <summary>
		/// Table INF_PUNISH_ATTACH
		/// </summary>
		public const string TB_INF_PUNISH_ATTACH = "INF_PUNISH_ATTACH";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FileAddress
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileAddress = "FileAddress";
		/// <summary>
		/// Parm FileName
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileName = "FileName";
		/// <summary>
		/// Parm FileRemark
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileRemark = "FileRemark";
		/// <summary>
		/// Parm FileReName
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileReName = "FileReName";
		/// <summary>
		/// Parm FileSize
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileSize = "FileSize";
		/// <summary>
		/// Parm FileType
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileType = "FileType";
		/// <summary>
		/// Parm FileTypeName
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_FileTypeName = "FileTypeName";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_Id = "Id";
		/// <summary>
		/// Parm IsCompleted
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_IsCompleted = "IsCompleted";
		/// <summary>
		/// Parm ResourceId
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ResourceId = "ResourceId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_RowStatus = "RowStatus";
		/// <summary>
		/// Parm ShootAddr
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootAddr = "ShootAddr";
		/// <summary>
		/// Parm ShootPersoneFirst
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootPersoneFirst = "ShootPersoneFirst";
		/// <summary>
		/// Parm ShootPersoneNameFirst
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootPersoneNameFirst = "ShootPersoneNameFirst";
		/// <summary>
		/// Parm ShootPersoneNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootPersoneNameSecond = "ShootPersoneNameSecond";
		/// <summary>
		/// Parm ShootPersoneSecond
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootPersoneSecond = "ShootPersoneSecond";
		/// <summary>
		/// Parm ShootTime
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_ShootTime = "ShootTime";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_ATTACH_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_ATTACH
		/// </summary>
		public const string Sql_INF_PUNISH_ATTACH_Insert = "insert into INF_PUNISH_ATTACH(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,ShootAddr,ShootPersoneFirst,ShootPersoneNameFirst,ShootPersoneNameSecond,ShootPersoneSecond,ShootTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@ShootAddr,@ShootPersoneFirst,@ShootPersoneNameFirst,@ShootPersoneNameSecond,@ShootPersoneSecond,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_ATTACH
		/// </summary>
		public const string Sql_INF_PUNISH_ATTACH_Update = "update INF_PUNISH_ATTACH set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootAddr=@ShootAddr,ShootPersoneFirst=@ShootPersoneFirst,ShootPersoneNameFirst=@ShootPersoneNameFirst,ShootPersoneNameSecond=@ShootPersoneNameSecond,ShootPersoneSecond=@ShootPersoneSecond,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_ATTACH_Delete = "update INF_PUNISH_ATTACH set RowStatus=0 where Id=@Id;select @@rowcount;";
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
		private int _isCompleted;
		/// <summary>
		/// 
		/// </summary>
		public int IsCompleted
		{
			get{return _isCompleted;}
			set{_isCompleted = value;}
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
		/// 所属类型
		/// </summary>
		public string FileType
		{
			get{return _fileType ?? string.Empty;}
			set{_fileType = value;}
		}
		private string _fileTypeName = string.Empty;
		/// <summary>
		/// 文件类型名称
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
		private DateTime _shootTime = MinDate;
		/// <summary>
		/// 拍摄时间
		/// </summary>
		public DateTime ShootTime
		{
			get{return _shootTime;}
			set{_shootTime = value;}
		}
		private string _shootAddr = string.Empty;
		/// <summary>
		/// 拍摄地点
		/// </summary>
		public string ShootAddr
		{
			get{return _shootAddr ?? string.Empty;}
			set{_shootAddr = value;}
		}
		private string _shootPersoneFirst = string.Empty;
		/// <summary>
		/// 拍摄人员一
		/// </summary>
		public string ShootPersoneFirst
		{
			get{return _shootPersoneFirst ?? string.Empty;}
			set{_shootPersoneFirst = value;}
		}
		private string _shootPersoneSecond = string.Empty;
		/// <summary>
		/// 拍摄人员二
		/// </summary>
		public string ShootPersoneSecond
		{
			get{return _shootPersoneSecond ?? string.Empty;}
			set{_shootPersoneSecond = value;}
		}
		private string _shootPersoneNameFirst = string.Empty;
		/// <summary>
		/// 拍摄人员一名称
		/// </summary>
		public string ShootPersoneNameFirst
		{
			get{return _shootPersoneNameFirst ?? string.Empty;}
			set{_shootPersoneNameFirst = value;}
		}
		private string _shootPersoneNameSecond = string.Empty;
		/// <summary>
		/// 拍摄人员二名称
		/// </summary>
		public string ShootPersoneNameSecond
		{
			get{return _shootPersoneNameSecond ?? string.Empty;}
			set{_shootPersoneNameSecond = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishAttachEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishAttachEntity();
          			if (fields.Contains(Parm_INF_PUNISH_ATTACH_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_ATTACH_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ResourceId) || fields.Contains("*"))
				tmp.ResourceId = dr[Parm_INF_PUNISH_ATTACH_ResourceId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileName) || fields.Contains("*"))
				tmp.FileName = dr[Parm_INF_PUNISH_ATTACH_FileName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileReName) || fields.Contains("*"))
				tmp.FileReName = dr[Parm_INF_PUNISH_ATTACH_FileReName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileSize) || fields.Contains("*"))
				tmp.FileSize = dr[Parm_INF_PUNISH_ATTACH_FileSize].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_IsCompleted) || fields.Contains("*"))
				tmp.IsCompleted = int.Parse(dr[Parm_INF_PUNISH_ATTACH_IsCompleted].ToString());
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileAddress) || fields.Contains("*"))
				tmp.FileAddress = dr[Parm_INF_PUNISH_ATTACH_FileAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileType) || fields.Contains("*"))
				tmp.FileType = dr[Parm_INF_PUNISH_ATTACH_FileType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileTypeName) || fields.Contains("*"))
				tmp.FileTypeName = dr[Parm_INF_PUNISH_ATTACH_FileTypeName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_FileRemark) || fields.Contains("*"))
				tmp.FileRemark = dr[Parm_INF_PUNISH_ATTACH_FileRemark].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootTime) || fields.Contains("*"))
				tmp.ShootTime = DateTime.Parse(dr[Parm_INF_PUNISH_ATTACH_ShootTime].ToString());
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootAddr) || fields.Contains("*"))
				tmp.ShootAddr = dr[Parm_INF_PUNISH_ATTACH_ShootAddr].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootPersoneFirst) || fields.Contains("*"))
				tmp.ShootPersoneFirst = dr[Parm_INF_PUNISH_ATTACH_ShootPersoneFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootPersoneSecond) || fields.Contains("*"))
				tmp.ShootPersoneSecond = dr[Parm_INF_PUNISH_ATTACH_ShootPersoneSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootPersoneNameFirst) || fields.Contains("*"))
				tmp.ShootPersoneNameFirst = dr[Parm_INF_PUNISH_ATTACH_ShootPersoneNameFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_ShootPersoneNameSecond) || fields.Contains("*"))
				tmp.ShootPersoneNameSecond = dr[Parm_INF_PUNISH_ATTACH_ShootPersoneNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_ATTACH_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_ATTACH_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_ATTACH_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_ATTACH_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_ATTACH_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_ATTACH_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_ATTACH_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_ATTACH_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_ATTACH_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_attach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishAttachEntity inf_punish_attach, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_attach.ResourceId;
				parms[1].Value = inf_punish_attach.FileName;
				parms[2].Value = inf_punish_attach.FileReName;
				parms[3].Value = inf_punish_attach.FileSize;
				parms[4].Value = inf_punish_attach.IsCompleted;
				parms[5].Value = inf_punish_attach.FileAddress;
				parms[6].Value = inf_punish_attach.FileType;
				parms[7].Value = inf_punish_attach.FileTypeName;
				parms[8].Value = inf_punish_attach.FileRemark;
				parms[9].Value = inf_punish_attach.ShootTime;
				parms[10].Value = inf_punish_attach.ShootAddr;
				parms[11].Value = inf_punish_attach.ShootPersoneFirst;
				parms[12].Value = inf_punish_attach.ShootPersoneSecond;
				parms[13].Value = inf_punish_attach.ShootPersoneNameFirst;
				parms[14].Value = inf_punish_attach.ShootPersoneNameSecond;
				parms[15].Value = inf_punish_attach.RowStatus;
				parms[16].Value = inf_punish_attach.CreatorId;
				parms[17].Value = inf_punish_attach.CreateBy;
				parms[18].Value = inf_punish_attach.CreateOn;
				parms[19].Value = inf_punish_attach.UpdateId;
				parms[20].Value = inf_punish_attach.UpdateBy;
				parms[21].Value = inf_punish_attach.UpdateOn;
                parms[22].Value = inf_punish_attach.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishAttachEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_ATTACH_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_ATTACH_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileReName, SqlDbType.NVarChar, 60),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileSize, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_FileRemark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootAddr, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootPersoneFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootPersoneSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootPersoneNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_ShootPersoneNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ATTACH_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_ATTACH_Id, SqlDbType.NVarChar, 50)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_ATTACH_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
