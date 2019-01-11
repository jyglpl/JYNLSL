//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DOCUMENTEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/11/06 19:58:35
//  功能描述：INF_PUNISH_DOCUMENT表实体
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
    public class InfPunishDocumentEntity : ModelImp.BaseModel<InfPunishDocumentEntity>
    {
        public InfPunishDocumentEntity()
        {
            TB_Name = TB_INF_PUNISH_DOCUMENT;
            Parm_Id = Parm_INF_PUNISH_DOCUMENT_Id;
            Parm_Version = Parm_INF_PUNISH_DOCUMENT_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_DOCUMENT_Insert;
            Sql_Update = Sql_INF_PUNISH_DOCUMENT_Update;
            Sql_Delete = Sql_INF_PUNISH_DOCUMENT_Delete;
        }
        #region Const of table INF_PUNISH_DOCUMENT
        /// <summary>
        /// Table INF_PUNISH_DOCUMENT
        /// </summary>
        public const string TB_INF_PUNISH_DOCUMENT = "INF_PUNISH_DOCUMENT";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_FileType = "FileType";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_Id = "Id";
        /// <summary>
        /// Parm ModelId
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_ModelId = "ModelId";
        /// <summary>
        /// Parm ModelIdentify
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_ModelIdentify = "ModelIdentify";
        /// <summary>
        /// Parm ModelName
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_ModelName = "ModelName";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_Version = "Version";
        /// <summary>
        /// Parm WritAddress
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_WritAddress = "WritAddress";
        /// <summary>
        /// Parm WritName
        /// </summary>
        public const string Parm_INF_PUNISH_DOCUMENT_WritName = "WritName";
        /// <summary>
        /// Insert Query Of INF_PUNISH_DOCUMENT
        /// </summary>
        public const string Sql_INF_PUNISH_DOCUMENT_Insert = "insert into INF_PUNISH_DOCUMENT(CaseInfoId,CreateBy,CreateOn,CreatorId,FileType,ModelId,ModelIdentify,ModelName,RowStatus,UpdateBy,UpdateId,UpdateOn,WritAddress,WritName,Id) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@FileType,@ModelId,@ModelIdentify,@ModelName,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@WritAddress,@WritName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_PUNISH_DOCUMENT
        /// </summary>
        public const string Sql_INF_PUNISH_DOCUMENT_Update = "update INF_PUNISH_DOCUMENT set CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileType=@FileType,ModelId=@ModelId,ModelIdentify=@ModelIdentify,ModelName=@ModelName,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WritAddress=@WritAddress,WritName=@WritName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_DOCUMENT_Delete = "update INF_PUNISH_DOCUMENT set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoId = string.Empty;
        /// <summary>
        /// 案件编号
        /// </summary>
        public string CaseInfoId
        {
            get { return _caseInfoId ?? string.Empty; }
            set { _caseInfoId = value; }
        }
        private string _modelId = string.Empty;
        /// <summary>
        /// 模板编号
        /// </summary>
        public string ModelId
        {
            get { return _modelId ?? string.Empty; }
            set { _modelId = value; }
        }
        private string _modelIdentify = string.Empty;
        /// <summary>
        /// 模板标识
        /// </summary>
        public string ModelIdentify
        {
            get { return _modelIdentify ?? string.Empty; }
            set { _modelIdentify = value; }
        }
        private string _modelName = string.Empty;
        /// <summary>
        /// 模板名称
        /// </summary>
        public string ModelName
        {
            get { return _modelName ?? string.Empty; }
            set { _modelName = value; }
        }
        private string _writName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WritName
        {
            get { return _writName ?? string.Empty; }
            set { _writName = value; }
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
        private string _writAddress = string.Empty;
        /// <summary>
        /// 生成存储路径
        /// </summary>
        public string WritAddress
        {
            get { return _writAddress ?? string.Empty; }
            set { _writAddress = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishDocumentEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishDocumentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishDocumentEntity();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_DOCUMENT_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_DOCUMENT_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_ModelId) || fields.Contains("*"))
                tmp.ModelId = dr[Parm_INF_PUNISH_DOCUMENT_ModelId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_ModelIdentify) || fields.Contains("*"))
                tmp.ModelIdentify = dr[Parm_INF_PUNISH_DOCUMENT_ModelIdentify].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_ModelName) || fields.Contains("*"))
                tmp.ModelName = dr[Parm_INF_PUNISH_DOCUMENT_ModelName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_WritName) || fields.Contains("*"))
                tmp.WritName = dr[Parm_INF_PUNISH_DOCUMENT_WritName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_INF_PUNISH_DOCUMENT_FileType].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_WritAddress) || fields.Contains("*"))
                tmp.WritAddress = dr[Parm_INF_PUNISH_DOCUMENT_WritAddress].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_DOCUMENT_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_DOCUMENT_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_DOCUMENT_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_DOCUMENT_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DOCUMENT_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_DOCUMENT_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_DOCUMENT_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DOCUMENT_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DOCUMENT_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_document">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishDocumentEntity inf_punish_document, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_document.CaseInfoId;
            parms[1].Value = inf_punish_document.ModelId;
            parms[2].Value = inf_punish_document.ModelIdentify;
            parms[3].Value = inf_punish_document.ModelName;
            parms[4].Value = inf_punish_document.WritName;
            parms[5].Value = inf_punish_document.FileType;
            parms[6].Value = inf_punish_document.WritAddress;
            parms[7].Value = inf_punish_document.RowStatus;
            parms[8].Value = inf_punish_document.CreatorId;
            parms[9].Value = inf_punish_document.CreateBy;
            parms[10].Value = inf_punish_document.CreateOn;
            parms[11].Value = inf_punish_document.UpdateId;
            parms[12].Value = inf_punish_document.UpdateBy;
            parms[13].Value = inf_punish_document.UpdateOn;
            parms[14].Value = inf_punish_document.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishDocumentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DOCUMENT_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_DOCUMENT_CaseInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_ModelId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_ModelIdentify, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_ModelName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_WritName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_WritAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DOCUMENT_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_DOCUMENT_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DOCUMENT_Insert, parms);
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

