//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIssuanceModelEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/7 10:37:34
//  功能描述：CrmIssuanceModel表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 打印模板
    /// </summary>
    [Serializable]
    public class CrmIssuanceModelEntity : ModelImp.BaseModel<CrmIssuanceModelEntity>
    {
        public CrmIssuanceModelEntity()
        {
            TB_Name = TB_CrmIssuanceModel;
            Parm_Id = Parm_CrmIssuanceModel_Id;
            Parm_Version = Parm_CrmIssuanceModel_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmIssuanceModel_Insert;
            Sql_Update = Sql_CrmIssuanceModel_Update;
            Sql_Delete = Sql_CrmIssuanceModel_Delete;
        }
        #region Const of table CrmIssuanceModel
        /// <summary>
        /// Table CrmIssuanceModel
        /// </summary>
        public const string TB_CrmIssuanceModel = "CrmIssuanceModel";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmIssuanceModel_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmIssuanceModel_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmIssuanceModel_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmIssuanceModel_Id = "Id";
        /// <summary>
        /// Parm ModelAddress
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelAddress = "ModelAddress";
        /// <summary>
        /// Parm ModelHeight
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelHeight = "ModelHeight";
        /// <summary>
        /// Parm ModelIdentify
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelIdentify = "ModelIdentify";
        /// <summary>
        /// Parm ModelName
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelName = "ModelName";
        /// <summary>
        /// Parm ModelType
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelType = "ModelType";
        /// <summary>
        /// Parm ModelWidth
        /// </summary>
        public const string Parm_CrmIssuanceModel_ModelWidth = "ModelWidth";
        /// <summary>
        /// Parm PictureSets
        /// </summary>
        public const string Parm_CrmIssuanceModel_PictureSets = "PictureSets";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmIssuanceModel_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StoredProcedure
        /// </summary>
        public const string Parm_CrmIssuanceModel_StoredProcedure = "StoredProcedure";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmIssuanceModel_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmIssuanceModel_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmIssuanceModel_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmIssuanceModel_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmIssuanceModel
        /// </summary>
        public const string Sql_CrmIssuanceModel_Insert = "insert into CrmIssuanceModel(CreateBy,CreateOn,CreatorId,ModelAddress,ModelHeight,ModelIdentify,ModelName,ModelType,ModelWidth,PictureSets,RowStatus,StoredProcedure,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@ModelAddress,@ModelHeight,@ModelIdentify,@ModelName,@ModelType,@ModelWidth,@PictureSets,@RowStatus,@StoredProcedure,@UpdateBy,@UpdateId,@UpdateOn,Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmIssuanceModel
        /// </summary>
        public const string Sql_CrmIssuanceModel_Update = "update CrmIssuanceModel set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ModelAddress=@ModelAddress,ModelHeight=@ModelHeight,ModelIdentify=@ModelIdentify,ModelName=@ModelName,ModelType=@ModelType,ModelWidth=@ModelWidth,PictureSets=@PictureSets,RowStatus=@RowStatus,StoredProcedure=@StoredProcedure,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmIssuanceModel_Delete = "update CrmIssuanceModel set RowStatus=0 where Id=@Id;select @@rowcount;";
        #endregion

        #region Properties
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
        /// 
        /// </summary>
        public string ModelName
        {
            get { return _modelName ?? string.Empty; }
            set { _modelName = value; }
        }
        private int _modelType;
        /// <summary>
        /// 模板类型（1：word,2：fastreport）
        /// </summary>
        public int ModelType
        {
            get { return _modelType; }
            set { _modelType = value; }
        }
        private string _modelAddress = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ModelAddress
        {
            get { return _modelAddress ?? string.Empty; }
            set { _modelAddress = value; }
        }
        private int _modelWidth;
        /// <summary>
        /// 
        /// </summary>
        public int ModelWidth
        {
            get { return _modelWidth; }
            set { _modelWidth = value; }
        }
        private int _modelHeight;
        /// <summary>
        /// 
        /// </summary>
        public int ModelHeight
        {
            get { return _modelHeight; }
            set { _modelHeight = value; }
        }
        private string _pictureSets = string.Empty;
        /// <summary>
        /// 图片设置
        /// </summary>
        public string PictureSets
        {
            get { return _pictureSets ?? string.Empty; }
            set { _pictureSets = value; }
        }
        private string _storedProcedure = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string StoredProcedure
        {
            get { return _storedProcedure ?? string.Empty; }
            set { _storedProcedure = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmIssuanceModelEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmIssuanceModelEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmIssuanceModelEntity();
            if (fields.Contains(Parm_CrmIssuanceModel_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmIssuanceModel_Id].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_ModelIdentify) || fields.Contains("*"))
                tmp.ModelIdentify = dr[Parm_CrmIssuanceModel_ModelIdentify].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_ModelName) || fields.Contains("*"))
                tmp.ModelName = dr[Parm_CrmIssuanceModel_ModelName].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_ModelType) || fields.Contains("*"))
                tmp.ModelType = int.Parse(dr[Parm_CrmIssuanceModel_ModelType].ToString());
            if (fields.Contains(Parm_CrmIssuanceModel_ModelAddress) || fields.Contains("*"))
                tmp.ModelAddress = dr[Parm_CrmIssuanceModel_ModelAddress].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_ModelWidth) || fields.Contains("*"))
                tmp.ModelWidth = int.Parse(dr[Parm_CrmIssuanceModel_ModelWidth].ToString());
            if (fields.Contains(Parm_CrmIssuanceModel_ModelHeight) || fields.Contains("*"))
                tmp.ModelHeight = int.Parse(dr[Parm_CrmIssuanceModel_ModelHeight].ToString());
            if (fields.Contains(Parm_CrmIssuanceModel_PictureSets) || fields.Contains("*"))
                tmp.PictureSets = dr[Parm_CrmIssuanceModel_PictureSets].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_StoredProcedure) || fields.Contains("*"))
                tmp.StoredProcedure = dr[Parm_CrmIssuanceModel_StoredProcedure].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmIssuanceModel_RowStatus].ToString());
            if (fields.Contains(Parm_CrmIssuanceModel_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_CrmIssuanceModel_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_CrmIssuanceModel_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmIssuanceModel_CreatorId].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmIssuanceModel_CreateBy].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmIssuanceModel_CreateOn].ToString());
            if (fields.Contains(Parm_CrmIssuanceModel_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmIssuanceModel_UpdateId].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmIssuanceModel_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmIssuanceModel_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmIssuanceModel_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmissuancemodel">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmIssuanceModelEntity crmissuancemodel, SqlParameter[] parms)
        {
            parms[0].Value = crmissuancemodel.ModelIdentify;
            parms[1].Value = crmissuancemodel.ModelName;
            parms[2].Value = crmissuancemodel.ModelType;
            parms[3].Value = crmissuancemodel.ModelAddress;
            parms[4].Value = crmissuancemodel.ModelWidth;
            parms[5].Value = crmissuancemodel.ModelHeight;
            parms[6].Value = crmissuancemodel.PictureSets;
            parms[7].Value = crmissuancemodel.StoredProcedure;
            parms[8].Value = crmissuancemodel.RowStatus;
            parms[9].Value = crmissuancemodel.CreatorId;
            parms[10].Value = crmissuancemodel.CreateBy;
            parms[11].Value = crmissuancemodel.CreateOn;
            parms[12].Value = crmissuancemodel.UpdateId;
            parms[13].Value = crmissuancemodel.UpdateBy;
            parms[14].Value = crmissuancemodel.UpdateOn;
            parms[15].Value = crmissuancemodel.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmIssuanceModelEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmIssuanceModel_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmIssuanceModel_ModelIdentify, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIssuanceModel_ModelName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_CrmIssuanceModel_ModelType, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIssuanceModel_ModelAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmIssuanceModel_ModelWidth, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIssuanceModel_ModelHeight, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIssuanceModel_PictureSets, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_CrmIssuanceModel_StoredProcedure, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_CrmIssuanceModel_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIssuanceModel_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIssuanceModel_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIssuanceModel_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmIssuanceModel_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIssuanceModel_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIssuanceModel_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmIssuanceModel_Id, SqlDbType.DateTime, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmIssuanceModel_Insert, parms);
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

