//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Consent_AttachEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监支付认证
//  作    者：叶念
//  创建日期：2015/7/29 13:54:33
//  功能描述：Consent_Attach表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Consent
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Consent_AttachEntity : ModelImp.BaseModel<Consent_AttachEntity>
    {
        public Consent_AttachEntity()
        {
            TB_Name = TB_Consent_Attach;
            Parm_Id = Parm_Consent_Attach_Id;
            Parm_Version = Parm_Consent_Attach_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Consent_Attach_Insert;
            Sql_Update = Sql_Consent_Attach_Update;
            Sql_Delete = Sql_Consent_Attach_Delete;
        }
        #region Const of table Consent_Attach
        /// <summary>
        /// Table Consent_Attach
        /// </summary>
        public const string TB_Consent_Attach = "Consent_Attach";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Consent_Attach_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Consent_Attach_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Consent_Attach_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_Consent_Attach_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_Consent_Attach_FileName = "FileName";
        /// <summary>
        /// Parm FileRemark
        /// </summary>
        public const string Parm_Consent_Attach_FileRemark = "FileRemark";
        /// <summary>
        /// Parm FileReName
        /// </summary>
        public const string Parm_Consent_Attach_FileReName = "FileReName";
        /// <summary>
        /// Parm FileSize
        /// </summary>
        public const string Parm_Consent_Attach_FileSize = "FileSize";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_Consent_Attach_FileType = "FileType";
        /// <summary>
        /// Parm FileTypeName
        /// </summary>
        public const string Parm_Consent_Attach_FileTypeName = "FileTypeName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Consent_Attach_Id = "Id";
        /// <summary>
        /// Parm IsCompleted
        /// </summary>
        public const string Parm_Consent_Attach_IsCompleted = "IsCompleted";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_Consent_Attach_ResourceId = "ResourceId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Consent_Attach_RowStatus = "RowStatus";
        /// <summary>
        /// Parm ShootAddr
        /// </summary>
        public const string Parm_Consent_Attach_ShootAddr = "ShootAddr";
        /// <summary>
        /// Parm ShootPersoneFirst
        /// </summary>
        public const string Parm_Consent_Attach_ShootPersoneFirst = "ShootPersoneFirst";
        /// <summary>
        /// Parm ShootPersoneNameFirst
        /// </summary>
        public const string Parm_Consent_Attach_ShootPersoneNameFirst = "ShootPersoneNameFirst";
        /// <summary>
        /// Parm ShootPersoneNameSecond
        /// </summary>
        public const string Parm_Consent_Attach_ShootPersoneNameSecond = "ShootPersoneNameSecond";
        /// <summary>
        /// Parm ShootPersoneSecond
        /// </summary>
        public const string Parm_Consent_Attach_ShootPersoneSecond = "ShootPersoneSecond";
        /// <summary>
        /// Parm ShootTime
        /// </summary>
        public const string Parm_Consent_Attach_ShootTime = "ShootTime";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Consent_Attach_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Consent_Attach_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Consent_Attach_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Consent_Attach_Version = "Version";
        /// <summary>
        /// Insert Query Of Consent_Attach
        /// </summary>
        public const string Sql_Consent_Attach_Insert = "insert into Consent_Attach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,ShootAddr,ShootPersoneFirst,ShootPersoneNameFirst,ShootPersoneNameSecond,ShootPersoneSecond,ShootTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@ShootAddr,@ShootPersoneFirst,@ShootPersoneNameFirst,@ShootPersoneNameSecond,@ShootPersoneSecond,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Consent_Attach
        /// </summary>
        public const string Sql_Consent_Attach_Update = "update Consent_Attach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootAddr=@ShootAddr,ShootPersoneFirst=@ShootPersoneFirst,ShootPersoneNameFirst=@ShootPersoneNameFirst,ShootPersoneNameSecond=@ShootPersoneNameSecond,ShootPersoneSecond=@ShootPersoneSecond,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Consent_Attach_Delete = "update Consent_Attach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        public override Consent_AttachEntity SetModelValueByDataRow(DataRow dr)
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
        public override Consent_AttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new Consent_AttachEntity();
            if (fields.Contains(Parm_Consent_Attach_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Consent_Attach_Id].ToString();
            if (fields.Contains(Parm_Consent_Attach_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_Consent_Attach_ResourceId].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_Consent_Attach_FileName].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileReName) || fields.Contains("*"))
                tmp.FileReName = dr[Parm_Consent_Attach_FileReName].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileSize) || fields.Contains("*"))
                tmp.FileSize = dr[Parm_Consent_Attach_FileSize].ToString();
            if (fields.Contains(Parm_Consent_Attach_IsCompleted) || fields.Contains("*"))
                tmp.IsCompleted = int.Parse(dr[Parm_Consent_Attach_IsCompleted].ToString());
            if (fields.Contains(Parm_Consent_Attach_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_Consent_Attach_FileAddress].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_Consent_Attach_FileType].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileTypeName) || fields.Contains("*"))
                tmp.FileTypeName = dr[Parm_Consent_Attach_FileTypeName].ToString();
            if (fields.Contains(Parm_Consent_Attach_FileRemark) || fields.Contains("*"))
                tmp.FileRemark = dr[Parm_Consent_Attach_FileRemark].ToString();
            if (fields.Contains(Parm_Consent_Attach_ShootTime) || fields.Contains("*"))
                tmp.ShootTime = DateTime.Parse(dr[Parm_Consent_Attach_ShootTime].ToString());
            if (fields.Contains(Parm_Consent_Attach_ShootAddr) || fields.Contains("*"))
                tmp.ShootAddr = dr[Parm_Consent_Attach_ShootAddr].ToString();
            if (fields.Contains(Parm_Consent_Attach_ShootPersoneFirst) || fields.Contains("*"))
                tmp.ShootPersoneFirst = dr[Parm_Consent_Attach_ShootPersoneFirst].ToString();
            if (fields.Contains(Parm_Consent_Attach_ShootPersoneSecond) || fields.Contains("*"))
                tmp.ShootPersoneSecond = dr[Parm_Consent_Attach_ShootPersoneSecond].ToString();
            if (fields.Contains(Parm_Consent_Attach_ShootPersoneNameFirst) || fields.Contains("*"))
                tmp.ShootPersoneNameFirst = dr[Parm_Consent_Attach_ShootPersoneNameFirst].ToString();
            if (fields.Contains(Parm_Consent_Attach_ShootPersoneNameSecond) || fields.Contains("*"))
                tmp.ShootPersoneNameSecond = dr[Parm_Consent_Attach_ShootPersoneNameSecond].ToString();
            if (fields.Contains(Parm_Consent_Attach_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Consent_Attach_RowStatus].ToString());
            if (fields.Contains(Parm_Consent_Attach_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Consent_Attach_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Consent_Attach_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Consent_Attach_CreatorId].ToString();
            if (fields.Contains(Parm_Consent_Attach_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Consent_Attach_CreateBy].ToString();
            if (fields.Contains(Parm_Consent_Attach_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Consent_Attach_CreateOn].ToString());
            if (fields.Contains(Parm_Consent_Attach_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Consent_Attach_UpdateId].ToString();
            if (fields.Contains(Parm_Consent_Attach_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Consent_Attach_UpdateBy].ToString();
            if (fields.Contains(Parm_Consent_Attach_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Consent_Attach_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="consent_attach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(Consent_AttachEntity consent_attach, SqlParameter[] parms)
        {
            parms[0].Value = consent_attach.ResourceId;
            parms[1].Value = consent_attach.FileName;
            parms[2].Value = consent_attach.FileReName;
            parms[3].Value = consent_attach.FileSize;
            parms[4].Value = consent_attach.IsCompleted;
            parms[5].Value = consent_attach.FileAddress;
            parms[6].Value = consent_attach.FileType;
            parms[7].Value = consent_attach.FileTypeName;
            parms[8].Value = consent_attach.FileRemark;
            parms[9].Value = consent_attach.ShootTime;
            parms[10].Value = consent_attach.ShootAddr;
            parms[11].Value = consent_attach.ShootPersoneFirst;
            parms[12].Value = consent_attach.ShootPersoneSecond;
            parms[13].Value = consent_attach.ShootPersoneNameFirst;
            parms[14].Value = consent_attach.ShootPersoneNameSecond;
            parms[15].Value = consent_attach.RowStatus;
            parms[16].Value = consent_attach.CreatorId;
            parms[17].Value = consent_attach.CreateBy;
            parms[18].Value = consent_attach.CreateOn;
            parms[19].Value = consent_attach.UpdateId;
            parms[20].Value = consent_attach.UpdateBy;
            parms[21].Value = consent_attach.UpdateOn;
            parms[22].Value = consent_attach.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(Consent_AttachEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Consent_Attach_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Consent_Attach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_Consent_Attach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_Consent_Attach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Consent_Attach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Consent_Attach_ShootAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Consent_Attach_ShootPersoneFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_ShootPersoneSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_ShootPersoneNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_ShootPersoneNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Consent_Attach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Consent_Attach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Consent_Attach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Consent_Attach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Consent_Attach_Insert, parms);
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

