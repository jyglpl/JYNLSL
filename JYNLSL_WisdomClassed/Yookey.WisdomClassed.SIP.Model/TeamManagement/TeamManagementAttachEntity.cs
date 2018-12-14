//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementAttachEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:35
//  功能描述：TeamManagementAttach表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TeamManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TeamManagementAttachEntity : ModelImp.BaseModel<TeamManagementAttachEntity>
    {
       	public TeamManagementAttachEntity()
		{
			TB_Name = TB_TeamManagementAttach;
			Parm_Id = Parm_TeamManagementAttach_Id;
			Parm_Version = Parm_TeamManagementAttach_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_TeamManagementAttach_Insert;
			Sql_Update = Sql_TeamManagementAttach_Update;
			Sql_Delete = Sql_TeamManagementAttach_Delete;
		}
       	#region Const of table TeamManagementAttach
		/// <summary>
		/// Table TeamManagementAttach
		/// </summary>
		public const string TB_TeamManagementAttach = "TeamManagementAttach";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_TeamManagementAttach_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_TeamManagementAttach_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_TeamManagementAttach_CreatorId = "CreatorId";
		/// <summary>
		/// Parm FileAddress
		/// </summary>
		public const string Parm_TeamManagementAttach_FileAddress = "FileAddress";
		/// <summary>
		/// Parm FileName
		/// </summary>
		public const string Parm_TeamManagementAttach_FileName = "FileName";
		/// <summary>
		/// Parm FileRemark
		/// </summary>
		public const string Parm_TeamManagementAttach_FileRemark = "FileRemark";
		/// <summary>
		/// Parm FileReName
		/// </summary>
		public const string Parm_TeamManagementAttach_FileReName = "FileReName";
		/// <summary>
		/// Parm FileSize
		/// </summary>
		public const string Parm_TeamManagementAttach_FileSize = "FileSize";
		/// <summary>
		/// Parm FileType
		/// </summary>
		public const string Parm_TeamManagementAttach_FileType = "FileType";
		/// <summary>
		/// Parm FileTypeName
		/// </summary>
		public const string Parm_TeamManagementAttach_FileTypeName = "FileTypeName";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_TeamManagementAttach_Id = "Id";
		/// <summary>
		/// Parm IsCompleted
		/// </summary>
		public const string Parm_TeamManagementAttach_IsCompleted = "IsCompleted";
		/// <summary>
		/// Parm ResourceId
		/// </summary>
		public const string Parm_TeamManagementAttach_ResourceId = "ResourceId";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_TeamManagementAttach_RowStatus = "RowStatus";
		/// <summary>
		/// Parm ShootAddr
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootAddr = "ShootAddr";
		/// <summary>
		/// Parm ShootPersoneFirst
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootPersoneFirst = "ShootPersoneFirst";
		/// <summary>
		/// Parm ShootPersoneNameFirst
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootPersoneNameFirst = "ShootPersoneNameFirst";
		/// <summary>
		/// Parm ShootPersoneNameSecond
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootPersoneNameSecond = "ShootPersoneNameSecond";
		/// <summary>
		/// Parm ShootPersoneSecond
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootPersoneSecond = "ShootPersoneSecond";
		/// <summary>
		/// Parm ShootTime
		/// </summary>
		public const string Parm_TeamManagementAttach_ShootTime = "ShootTime";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_TeamManagementAttach_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_TeamManagementAttach_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_TeamManagementAttach_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_TeamManagementAttach_Version = "Version";
		/// <summary>
		/// Insert Query Of TeamManagementAttach
		/// </summary>
		public const string Sql_TeamManagementAttach_Insert = "insert into TeamManagementAttach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,ShootAddr,ShootPersoneFirst,ShootPersoneNameFirst,ShootPersoneNameSecond,ShootPersoneSecond,ShootTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@ShootAddr,@ShootPersoneFirst,@ShootPersoneNameFirst,@ShootPersoneNameSecond,@ShootPersoneSecond,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of TeamManagementAttach
		/// </summary>
		public const string Sql_TeamManagementAttach_Update = "update TeamManagementAttach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootAddr=@ShootAddr,ShootPersoneFirst=@ShootPersoneFirst,ShootPersoneNameFirst=@ShootPersoneNameFirst,ShootPersoneNameSecond=@ShootPersoneNameSecond,ShootPersoneSecond=@ShootPersoneSecond,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_TeamManagementAttach_Delete = "update TeamManagementAttach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _resourceId = string.Empty;
		/// <summary>
		/// 案件编号
		/// </summary>
		public string ResourceId
		{
			get{return _resourceId ?? string.Empty;}
			set{_resourceId = value;}
		}
		private string _fileName = string.Empty;
		/// <summary>
		/// 附件名称
		/// </summary>
		public string FileName
		{
			get{return _fileName ?? string.Empty;}
			set{_fileName = value;}
		}
		private string _fileReName = string.Empty;
		/// <summary>
		/// 重命名后名称
		/// </summary>
		public string FileReName
		{
			get{return _fileReName ?? string.Empty;}
			set{_fileReName = value;}
		}
		private string _fileSize = string.Empty;
		/// <summary>
		/// 附件大小
		/// </summary>
		public string FileSize
		{
			get{return _fileSize ?? string.Empty;}
			set{_fileSize = value;}
		}
		private int _isCompleted;
		/// <summary>
		/// 是否上传完成
		/// </summary>
		public int IsCompleted
		{
			get{return _isCompleted;}
			set{_isCompleted = value;}
		}
		private string _fileAddress = string.Empty;
		/// <summary>
		/// 附件保存路径
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
		/// 附件类型名称
		/// </summary>
		public string FileTypeName
		{
			get{return _fileTypeName ?? string.Empty;}
			set{_fileTypeName = value;}
		}
		private string _fileRemark = string.Empty;
		/// <summary>
		/// 附件备注
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
		public override TeamManagementAttachEntity SetModelValueByDataRow(DataRow dr)
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
		public override TeamManagementAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TeamManagementAttachEntity();
            if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_Id))
				tmp.Id = dr[Parm_TeamManagementAttach_Id].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ResourceId) )
				tmp.ResourceId = dr[Parm_TeamManagementAttach_ResourceId].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileName) )
				tmp.FileName = dr[Parm_TeamManagementAttach_FileName].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileReName) )
				tmp.FileReName = dr[Parm_TeamManagementAttach_FileReName].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileSize) )
				tmp.FileSize = dr[Parm_TeamManagementAttach_FileSize].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_IsCompleted) )
				tmp.IsCompleted = int.Parse(dr[Parm_TeamManagementAttach_IsCompleted].ToString());
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileAddress) )
				tmp.FileAddress = dr[Parm_TeamManagementAttach_FileAddress].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileType) )
				tmp.FileType = dr[Parm_TeamManagementAttach_FileType].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileTypeName) )
				tmp.FileTypeName = dr[Parm_TeamManagementAttach_FileTypeName].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_FileRemark) )
				tmp.FileRemark = dr[Parm_TeamManagementAttach_FileRemark].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootTime) )
				tmp.ShootTime = DateTime.Parse(dr[Parm_TeamManagementAttach_ShootTime].ToString());
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootAddr) )
				tmp.ShootAddr = dr[Parm_TeamManagementAttach_ShootAddr].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootPersoneFirst) )
				tmp.ShootPersoneFirst = dr[Parm_TeamManagementAttach_ShootPersoneFirst].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootPersoneSecond) )
				tmp.ShootPersoneSecond = dr[Parm_TeamManagementAttach_ShootPersoneSecond].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootPersoneNameFirst) )
				tmp.ShootPersoneNameFirst = dr[Parm_TeamManagementAttach_ShootPersoneNameFirst].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_ShootPersoneNameSecond) )
				tmp.ShootPersoneNameSecond = dr[Parm_TeamManagementAttach_ShootPersoneNameSecond].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_RowStatus) )
				tmp.RowStatus = int.Parse(dr[Parm_TeamManagementAttach_RowStatus].ToString());
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_Version) )
			{
				var bts = (byte[])(dr[Parm_TeamManagementAttach_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_CreatorId) )
				tmp.CreatorId = dr[Parm_TeamManagementAttach_CreatorId].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_CreateBy) )
				tmp.CreateBy = dr[Parm_TeamManagementAttach_CreateBy].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_CreateOn) )
				tmp.CreateOn = DateTime.Parse(dr[Parm_TeamManagementAttach_CreateOn].ToString());
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_UpdateId) )
				tmp.UpdateId = dr[Parm_TeamManagementAttach_UpdateId].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_UpdateBy) )
				tmp.UpdateBy = dr[Parm_TeamManagementAttach_UpdateBy].ToString();
			if (dr.Table.Columns.Contains(Parm_TeamManagementAttach_UpdateOn) )
				tmp.UpdateOn = DateTime.Parse(dr[Parm_TeamManagementAttach_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="teammanagementattach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(TeamManagementAttachEntity teammanagementattach, SqlParameter[] parms)
		{
            				parms[0].Value = teammanagementattach.ResourceId;
				parms[1].Value = teammanagementattach.FileName;
				parms[2].Value = teammanagementattach.FileReName;
				parms[3].Value = teammanagementattach.FileSize;
				parms[4].Value = teammanagementattach.IsCompleted;
				parms[5].Value = teammanagementattach.FileAddress;
				parms[6].Value = teammanagementattach.FileType;
				parms[7].Value = teammanagementattach.FileTypeName;
				parms[8].Value = teammanagementattach.FileRemark;
				parms[9].Value = teammanagementattach.ShootTime;
				parms[10].Value = teammanagementattach.ShootAddr;
				parms[11].Value = teammanagementattach.ShootPersoneFirst;
				parms[12].Value = teammanagementattach.ShootPersoneSecond;
				parms[13].Value = teammanagementattach.ShootPersoneNameFirst;
				parms[14].Value = teammanagementattach.ShootPersoneNameSecond;
				parms[15].Value = teammanagementattach.RowStatus;
				parms[16].Value = teammanagementattach.CreatorId;
				parms[17].Value = teammanagementattach.CreateBy;
				parms[18].Value = teammanagementattach.CreateOn;
				parms[19].Value = teammanagementattach.UpdateId;
				parms[20].Value = teammanagementattach.UpdateBy;
				parms[21].Value = teammanagementattach.UpdateOn;
                parms[22].Value = teammanagementattach.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(TeamManagementAttachEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementAttach_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_TeamManagementAttach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_TeamManagementAttach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagementAttach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagementAttach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagementAttach_ShootAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagementAttach_ShootPersoneFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_ShootPersoneSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_ShootPersoneNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_ShootPersoneNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagementAttach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagementAttach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementAttach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TeamManagementAttach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementAttach_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
