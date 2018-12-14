﻿//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttachmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/9/6 20:40:14
//  功能描述：ComAttachment表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 附件材料
    /// </summary>
    [Serializable]
    public class ComAttachmentEntity : ModelImp.BaseModel<ComAttachmentEntity>
    {
        public ComAttachmentEntity()
        {
            TB_Name = TB_ComAttachment;
            Parm_Id = Parm_ComAttachment_Id;
            Parm_Version = Parm_ComAttachment_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComAttachment_Insert;
            Sql_Update = Sql_ComAttachment_Update;
            Sql_Delete = Sql_ComAttachment_Delete;
        }
        #region Const of table ComAttachment
        /// <summary>
        /// Table ComAttachment
        /// </summary>
        public const string TB_ComAttachment = "ComAttachment";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComAttachment_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComAttachment_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComAttachment_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_ComAttachment_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileConvertAddress
        /// </summary>
        public const string Parm_ComAttachment_FileConvertAddress = "FileConvertAddress";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_ComAttachment_FileName = "FileName";
        /// <summary>
        /// Parm FileRemark
        /// </summary>
        public const string Parm_ComAttachment_FileRemark = "FileRemark";
        /// <summary>
        /// Parm FileReName
        /// </summary>
        public const string Parm_ComAttachment_FileReName = "FileReName";
        /// <summary>
        /// Parm FileSize
        /// </summary>
        public const string Parm_ComAttachment_FileSize = "FileSize";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_ComAttachment_FileType = "FileType";
        /// <summary>
        /// Parm FileTypeName
        /// </summary>
        public const string Parm_ComAttachment_FileTypeName = "FileTypeName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComAttachment_Id = "Id";
        /// <summary>
        /// Parm IsCompleted
        /// </summary>
        public const string Parm_ComAttachment_IsCompleted = "IsCompleted";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_ComAttachment_ResourceId = "ResourceId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComAttachment_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComAttachment_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComAttachment_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComAttachment_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComAttachment_Version = "Version";
        /// <summary>
        /// Insert Query Of ComAttachment
        /// </summary>
        public const string Sql_ComAttachment_Insert = "insert into ComAttachment(CreateBy,CreateOn,CreatorId,FileAddress,FileConvertAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileConvertAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComAttachment
        /// </summary>
        public const string Sql_ComAttachment_Update = "update ComAttachment set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileConvertAddress=@FileConvertAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComAttachment_Delete = "update ComAttachment set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _resourceId = string.Empty;
        /// <summary>
        /// 外键编号
        /// </summary>
        public string ResourceId
        {
            get { return _resourceId ?? string.Empty; }
            set { _resourceId = value; }
        }
        private string _fileName = string.Empty;
        /// <summary>
        /// 附件原始名称
        /// </summary>
        public string FileName
        {
            get { return _fileName ?? string.Empty; }
            set { _fileName = value; }
        }
        private string _fileReName = string.Empty;
        /// <summary>
        /// 重命名后名称
        /// </summary>
        public string FileReName
        {
            get { return _fileReName ?? string.Empty; }
            set { _fileReName = value; }
        }
        private string _fileSize = string.Empty;
        /// <summary>
        /// 附件大小
        /// </summary>
        public string FileSize
        {
            get { return _fileSize ?? string.Empty; }
            set { _fileSize = value; }
        }
        private int _isCompleted;
        /// <summary>
        /// 是否上传完成
        /// </summary>
        public int IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
        private string _fileAddress = string.Empty;
        /// <summary>
        /// 附件保存路径
        /// </summary>
        public string FileAddress
        {
            get { return _fileAddress ?? string.Empty; }
            set { _fileAddress = value; }
        }
        private string _fileType = string.Empty;
        /// <summary>
        /// 所属类型
        /// </summary>
        public string FileType
        {
            get { return _fileType ?? string.Empty; }
            set { _fileType = value; }
        }
        private string _fileTypeName = string.Empty;
        /// <summary>
        /// 附件类型名称
        /// </summary>
        public string FileTypeName
        {
            get { return _fileTypeName ?? string.Empty; }
            set { _fileTypeName = value; }
        }
        private string _fileRemark = string.Empty;
        /// <summary>
        /// 附件备注
        /// </summary>
        public string FileRemark
        {
            get { return _fileRemark ?? string.Empty; }
            set { _fileRemark = value; }
        }
        private string _fileConvertAddress = string.Empty;
        /// <summary>
        /// 文件转换后存储路径
        /// </summary>
        public string FileConvertAddress
        {
            get { return _fileConvertAddress ?? string.Empty; }
            set { _fileConvertAddress = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComAttachmentEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComAttachmentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComAttachmentEntity();
            if (fields.Contains(Parm_ComAttachment_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComAttachment_Id].ToString();
            if (fields.Contains(Parm_ComAttachment_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_ComAttachment_ResourceId].ToString();
            if (fields.Contains(Parm_ComAttachment_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_ComAttachment_FileName].ToString();
            if (fields.Contains(Parm_ComAttachment_FileReName) || fields.Contains("*"))
                tmp.FileReName = dr[Parm_ComAttachment_FileReName].ToString();
            if (fields.Contains(Parm_ComAttachment_FileSize) || fields.Contains("*"))
                tmp.FileSize = dr[Parm_ComAttachment_FileSize].ToString();
            if (fields.Contains(Parm_ComAttachment_IsCompleted) || fields.Contains("*"))
                tmp.IsCompleted = int.Parse(dr[Parm_ComAttachment_IsCompleted].ToString());
            if (fields.Contains(Parm_ComAttachment_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_ComAttachment_FileAddress].ToString();
            if (fields.Contains(Parm_ComAttachment_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_ComAttachment_FileType].ToString();
            if (fields.Contains(Parm_ComAttachment_FileTypeName) || fields.Contains("*"))
                tmp.FileTypeName = dr[Parm_ComAttachment_FileTypeName].ToString();
            if (fields.Contains(Parm_ComAttachment_FileRemark) || fields.Contains("*"))
                tmp.FileRemark = dr[Parm_ComAttachment_FileRemark].ToString();
            if (fields.Contains(Parm_ComAttachment_FileConvertAddress) || fields.Contains("*"))
                tmp.FileConvertAddress = dr[Parm_ComAttachment_FileConvertAddress].ToString();
            if (fields.Contains(Parm_ComAttachment_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComAttachment_RowStatus].ToString());
            if (fields.Contains(Parm_ComAttachment_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComAttachment_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComAttachment_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComAttachment_CreatorId].ToString();
            if (fields.Contains(Parm_ComAttachment_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComAttachment_CreateBy].ToString();
            if (fields.Contains(Parm_ComAttachment_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComAttachment_CreateOn].ToString());
            if (fields.Contains(Parm_ComAttachment_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComAttachment_UpdateId].ToString();
            if (fields.Contains(Parm_ComAttachment_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComAttachment_UpdateBy].ToString();
            if (fields.Contains(Parm_ComAttachment_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComAttachment_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comattachment">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComAttachmentEntity comattachment, SqlParameter[] parms)
        {
            parms[0].Value = comattachment.ResourceId;
            parms[1].Value = comattachment.FileName;
            parms[2].Value = comattachment.FileReName;
            parms[3].Value = comattachment.FileSize;
            parms[4].Value = comattachment.IsCompleted;
            parms[5].Value = comattachment.FileAddress;
            parms[6].Value = comattachment.FileType;
            parms[7].Value = comattachment.FileTypeName;
            parms[8].Value = comattachment.FileRemark;
            parms[9].Value = comattachment.FileConvertAddress;
            parms[10].Value = comattachment.RowStatus;
            parms[11].Value = comattachment.CreatorId;
            parms[12].Value = comattachment.CreateBy;
            parms[13].Value = comattachment.CreateOn;
            parms[14].Value = comattachment.UpdateId;
            parms[15].Value = comattachment.UpdateBy;
            parms[16].Value = comattachment.UpdateOn;
            parms[17].Value = comattachment.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComAttachmentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttachment_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_ComAttachment_ResourceId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_FileName, SqlDbType.NVarChar, 100),
                            new SqlParameter(Parm_ComAttachment_FileReName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_FileSize, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_IsCompleted, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComAttachment_FileAddress, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_ComAttachment_FileType, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_FileTypeName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_FileRemark, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_FileConvertAddress, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_ComAttachment_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComAttachment_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_ComAttachment_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComAttachment_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_ComAttachment_Id, SqlDbType.NVarChar, 50)
                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttachment_Insert,
                                                              parms);
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

