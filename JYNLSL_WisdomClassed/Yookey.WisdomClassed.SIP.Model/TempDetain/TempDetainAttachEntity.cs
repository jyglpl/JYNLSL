//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainAttachEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:16
//  功能描述：TempDetainAttach表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TempDetain
{
    /// <summary>
    /// 暂扣附件
    /// </summary>
    [Serializable]
    public class TempDetainAttachEntity : ModelImp.BaseModel<TempDetainAttachEntity>
    {
        public TempDetainAttachEntity()
        {
            TB_Name = TB_TempDetainAttach;
            Parm_Id = Parm_TempDetainAttach_Id;
            Parm_Version = Parm_TempDetainAttach_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TempDetainAttach_Insert;
            Sql_Update = Sql_TempDetainAttach_Update;
            Sql_Delete = Sql_TempDetainAttach_Delete;
        }

        /// <summary>
        /// 构造函数
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="reader"></param>
        public TempDetainAttachEntity(SqlDataReader reader) {
            Id = reader["Id"].ToString();
            ResourceId = reader["ResourceId"].ToString();
            FileName = reader["FileName"].ToString();
            FileReName = reader["FileReName"].ToString();
            FileSize = reader["FileSize"].ToString();
            IsCompleted = Convert.ToInt32(reader["IsCompleted"]);
            FileAddress = reader["FileAddress"].ToString();
            FileType = reader["FileType"].ToString();
            FileTypeName = reader["FileTypeName"].ToString();
            ShootTime = Convert.ToDateTime(reader["ShootTime"]);
            ShootAddr = reader["ShootAddr"].ToString();
            ShootPersoneFirst = reader["ShootPersoneFirst"].ToString();
            ShootPersoneSecond = reader["ShootPersoneSecond"].ToString();
            ShootPersoneNameFirst = reader["ShootPersoneNameFirst"].ToString();
            ShootPersoneNameSecond = reader["ShootPersoneNameSecond"].ToString();
            RowStatus = Convert.ToInt32(reader["RowStatus"]);
            CreatorId = reader["CreatorId"].ToString();
            CreateBy = reader["CreateBy"].ToString();
            CreateOn = Convert.ToDateTime(reader["CreateOn"]);
            UpdateId = reader["UpdateId"].ToString();
            UpdateBy = reader["UpdateBy"].ToString();
            UpdateOn = Convert.ToDateTime(reader["UpdateOn"]);
        }

        #region Const of table TempDetainAttach
        /// <summary>
        /// Table TempDetainAttach
        /// </summary>
        public const string TB_TempDetainAttach = "TempDetainAttach";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TempDetainAttach_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TempDetainAttach_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TempDetainAttach_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_TempDetainAttach_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_TempDetainAttach_FileName = "FileName";
        /// <summary>
        /// Parm FileRemark
        /// </summary>
        public const string Parm_TempDetainAttach_FileRemark = "FileRemark";
        /// <summary>
        /// Parm FileReName
        /// </summary>
        public const string Parm_TempDetainAttach_FileReName = "FileReName";
        /// <summary>
        /// Parm FileSize
        /// </summary>
        public const string Parm_TempDetainAttach_FileSize = "FileSize";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_TempDetainAttach_FileType = "FileType";
        /// <summary>
        /// Parm FileTypeName
        /// </summary>
        public const string Parm_TempDetainAttach_FileTypeName = "FileTypeName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TempDetainAttach_Id = "Id";
        /// <summary>
        /// Parm IsCompleted
        /// </summary>
        public const string Parm_TempDetainAttach_IsCompleted = "IsCompleted";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_TempDetainAttach_ResourceId = "ResourceId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TempDetainAttach_RowStatus = "RowStatus";
        /// <summary>
        /// Parm ShootAddr
        /// </summary>
        public const string Parm_TempDetainAttach_ShootAddr = "ShootAddr";
        /// <summary>
        /// Parm ShootPersoneFirst
        /// </summary>
        public const string Parm_TempDetainAttach_ShootPersoneFirst = "ShootPersoneFirst";
        /// <summary>
        /// Parm ShootPersoneNameFirst
        /// </summary>
        public const string Parm_TempDetainAttach_ShootPersoneNameFirst = "ShootPersoneNameFirst";
        /// <summary>
        /// Parm ShootPersoneNameSecond
        /// </summary>
        public const string Parm_TempDetainAttach_ShootPersoneNameSecond = "ShootPersoneNameSecond";
        /// <summary>
        /// Parm ShootPersoneSecond
        /// </summary>
        public const string Parm_TempDetainAttach_ShootPersoneSecond = "ShootPersoneSecond";
        /// <summary>
        /// Parm ShootTime
        /// </summary>
        public const string Parm_TempDetainAttach_ShootTime = "ShootTime";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TempDetainAttach_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TempDetainAttach_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TempDetainAttach_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainAttach_Version = "Version";
        /// <summary>
        /// Insert Query Of TempDetainAttach
        /// </summary>
        public const string Sql_TempDetainAttach_Insert = "insert into TempDetainAttach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,ShootAddr,ShootPersoneFirst,ShootPersoneNameFirst,ShootPersoneNameSecond,ShootPersoneSecond,ShootTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@ShootAddr,@ShootPersoneFirst,@ShootPersoneNameFirst,@ShootPersoneNameSecond,@ShootPersoneSecond,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TempDetainAttach
        /// </summary>
        public const string Sql_TempDetainAttach_Update = "update TempDetainAttach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootAddr=@ShootAddr,ShootPersoneFirst=@ShootPersoneFirst,ShootPersoneNameFirst=@ShootPersoneNameFirst,ShootPersoneNameSecond=@ShootPersoneNameSecond,ShootPersoneSecond=@ShootPersoneSecond,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TempDetainAttach_Delete = "update TempDetainAttach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _resourceId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ResourceId
        {
            get { return _resourceId ?? string.Empty; }
            set { _resourceId = value; }
        }
        private string _fileName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName ?? string.Empty; }
            set { _fileName = value; }
        }
        private string _fileReName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileReName
        {
            get { return _fileReName ?? string.Empty; }
            set { _fileReName = value; }
        }
        private string _fileSize = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileSize
        {
            get { return _fileSize ?? string.Empty; }
            set { _fileSize = value; }
        }
        private int _isCompleted;
        /// <summary>
        /// 
        /// </summary>
        public int IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
        private string _fileAddress = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileAddress
        {
            get { return _fileAddress ?? string.Empty; }
            set { _fileAddress = value; }
        }
        private string _fileType = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileType
        {
            get { return _fileType ?? string.Empty; }
            set { _fileType = value; }
        }
        private string _fileTypeName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileTypeName
        {
            get { return _fileTypeName ?? string.Empty; }
            set { _fileTypeName = value; }
        }
        private string _fileRemark = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileRemark
        {
            get { return _fileRemark ?? string.Empty; }
            set { _fileRemark = value; }
        }
        private DateTime _shootTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ShootTime
        {
            get { return _shootTime; }
            set { _shootTime = value; }
        }
        private string _shootAddr = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShootAddr
        {
            get { return _shootAddr ?? string.Empty; }
            set { _shootAddr = value; }
        }
        private string _shootPersoneFirst = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShootPersoneFirst
        {
            get { return _shootPersoneFirst ?? string.Empty; }
            set { _shootPersoneFirst = value; }
        }
        private string _shootPersoneSecond = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShootPersoneSecond
        {
            get { return _shootPersoneSecond ?? string.Empty; }
            set { _shootPersoneSecond = value; }
        }
        private string _shootPersoneNameFirst = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShootPersoneNameFirst
        {
            get { return _shootPersoneNameFirst ?? string.Empty; }
            set { _shootPersoneNameFirst = value; }
        }
        private string _shootPersoneNameSecond = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ShootPersoneNameSecond
        {
            get { return _shootPersoneNameSecond ?? string.Empty; }
            set { _shootPersoneNameSecond = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override TempDetainAttachEntity SetModelValueByDataRow(DataRow dr)
        {
            IList<string> fields = new List<string> { "*" };
            return SetModelValueByDataRow(dr, fields);
        }

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public override TempDetainAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainAttachEntity();
            if (fields.Contains(Parm_TempDetainAttach_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_TempDetainAttach_Id].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_TempDetainAttach_ResourceId].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_TempDetainAttach_FileName].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileReName) || fields.Contains("*"))
                tmp.FileReName = dr[Parm_TempDetainAttach_FileReName].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileSize) || fields.Contains("*"))
                tmp.FileSize = dr[Parm_TempDetainAttach_FileSize].ToString();
            if (fields.Contains(Parm_TempDetainAttach_IsCompleted) || fields.Contains("*"))
                tmp.IsCompleted = int.Parse(dr[Parm_TempDetainAttach_IsCompleted].ToString());
            if (fields.Contains(Parm_TempDetainAttach_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_TempDetainAttach_FileAddress].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_TempDetainAttach_FileType].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileTypeName) || fields.Contains("*"))
                tmp.FileTypeName = dr[Parm_TempDetainAttach_FileTypeName].ToString();
            if (fields.Contains(Parm_TempDetainAttach_FileRemark) || fields.Contains("*"))
                tmp.FileRemark = dr[Parm_TempDetainAttach_FileRemark].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ShootTime) || fields.Contains("*"))
                tmp.ShootTime = DateTime.Parse(dr[Parm_TempDetainAttach_ShootTime].ToString());
            if (fields.Contains(Parm_TempDetainAttach_ShootAddr) || fields.Contains("*"))
                tmp.ShootAddr = dr[Parm_TempDetainAttach_ShootAddr].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ShootPersoneFirst) || fields.Contains("*"))
                tmp.ShootPersoneFirst = dr[Parm_TempDetainAttach_ShootPersoneFirst].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ShootPersoneSecond) || fields.Contains("*"))
                tmp.ShootPersoneSecond = dr[Parm_TempDetainAttach_ShootPersoneSecond].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ShootPersoneNameFirst) || fields.Contains("*"))
                tmp.ShootPersoneNameFirst = dr[Parm_TempDetainAttach_ShootPersoneNameFirst].ToString();
            if (fields.Contains(Parm_TempDetainAttach_ShootPersoneNameSecond) || fields.Contains("*"))
                tmp.ShootPersoneNameSecond = dr[Parm_TempDetainAttach_ShootPersoneNameSecond].ToString();
            if (fields.Contains(Parm_TempDetainAttach_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_TempDetainAttach_RowStatus].ToString());
            if (fields.Contains(Parm_TempDetainAttach_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_TempDetainAttach_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_TempDetainAttach_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_TempDetainAttach_CreatorId].ToString();
            if (fields.Contains(Parm_TempDetainAttach_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_TempDetainAttach_CreateBy].ToString();
            if (fields.Contains(Parm_TempDetainAttach_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainAttach_CreateOn].ToString());
            if (fields.Contains(Parm_TempDetainAttach_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_TempDetainAttach_UpdateId].ToString();
            if (fields.Contains(Parm_TempDetainAttach_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_TempDetainAttach_UpdateBy].ToString();
            if (fields.Contains(Parm_TempDetainAttach_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainAttach_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetainattach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainAttachEntity tempdetainattach, SqlParameter[] parms)
        {
            parms[0].Value = tempdetainattach.ResourceId;
            parms[1].Value = tempdetainattach.FileName;
            parms[2].Value = tempdetainattach.FileReName;
            parms[3].Value = tempdetainattach.FileSize;
            parms[4].Value = tempdetainattach.IsCompleted;
            parms[5].Value = tempdetainattach.FileAddress;
            parms[6].Value = tempdetainattach.FileType;
            parms[7].Value = tempdetainattach.FileTypeName;
            parms[8].Value = tempdetainattach.FileRemark;
            parms[9].Value = tempdetainattach.ShootTime;
            parms[10].Value = tempdetainattach.ShootAddr;
            parms[11].Value = tempdetainattach.ShootPersoneFirst;
            parms[12].Value = tempdetainattach.ShootPersoneSecond;
            parms[13].Value = tempdetainattach.ShootPersoneNameFirst;
            parms[14].Value = tempdetainattach.ShootPersoneNameSecond;
            parms[15].Value = tempdetainattach.RowStatus;
            parms[16].Value = tempdetainattach.CreatorId;
            parms[17].Value = tempdetainattach.CreateBy;
            parms[18].Value = tempdetainattach.CreateOn;
            parms[19].Value = tempdetainattach.UpdateId;
            parms[20].Value = tempdetainattach.UpdateBy;
            parms[21].Value = tempdetainattach.UpdateOn;
            parms[22].Value = tempdetainattach.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainAttachEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainAttach_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_TempDetainAttach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_TempDetainAttach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainAttach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TempDetainAttach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainAttach_ShootAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TempDetainAttach_ShootPersoneFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_ShootPersoneSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_ShootPersoneNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_ShootPersoneNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainAttach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainAttach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainAttach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TempDetainAttach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainAttach_Insert, parms);
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

