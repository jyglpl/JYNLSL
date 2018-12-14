//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：Folder表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Work
{
    /// <summary>
    /// 文件夹
    /// </summary>
    [Serializable]
    public class FolderEntity : ModelImp.BaseModel<FolderEntity>
    {
        public FolderEntity()
        {
            TB_Name = TB_Folder;
            Parm_Id = Parm_Folder_Id;
            Parm_Version = Parm_Folder_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Folder_Insert;
            Sql_Update = Sql_Folder_Update;
            Sql_Delete = Sql_Folder_Delete;
        }

        /// <summary>
        /// 构造函数
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="reader"></param>
        public FolderEntity(SqlDataReader reader):this()
        {
            Id = reader["Id"].ToString();
            FolderName = reader["FolderName"].ToString();
            ParentId = reader["ParentId"].ToString();
            RowStatus = Convert.ToInt32(reader["RowStatus"]);
            CreatorId = reader["CreatorId"].ToString();
            CreateBy = reader["CreateBy"].ToString();
            CreateOn = Convert.ToDateTime(reader["CreateOn"]);
            UpdateId = reader["UpdateId"].ToString();
            UpdateBy = reader["UpdateBy"].ToString();
            UpdateOn = Convert.ToDateTime(reader["UpdateOn"]);
        }
        #region Const of table Folder
        /// <summary>
        /// Table Folder
        /// </summary>
        public const string TB_Folder = "Folder";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Folder_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Folder_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Folder_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FolderName
        /// </summary>
        public const string Parm_Folder_FolderName = "FolderName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Folder_Id = "Id";
        /// <summary>
        /// Parm ParentId
        /// </summary>
        public const string Parm_Folder_ParentId = "ParentId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Folder_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Folder_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Folder_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Folder_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Folder_Version = "Version";
        /// <summary>
        /// Insert Query Of Folder
        /// </summary>
        public const string Sql_Folder_Insert = "insert into Folder(CreateBy,CreateOn,CreatorId,FolderName,ParentId,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FolderName,@ParentId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Folder
        /// </summary>
        public const string Sql_Folder_Update = "update Folder set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FolderName=@FolderName,ParentId=@ParentId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Folder_Delete = "update Folder set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _folderName = string.Empty;
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string FolderName
        {
            get { return _folderName ?? string.Empty; }
            set { _folderName = value; }
        }
        private string _parentId = string.Empty;
        /// <summary>
        /// 父编号
        /// </summary>
        public string ParentId
        {
            get { return _parentId ?? string.Empty; }
            set { _parentId = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FolderEntity SetModelValueByDataRow(DataRow dr)
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
        public override FolderEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FolderEntity();
            if (fields.Contains(Parm_Folder_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Folder_Id].ToString();
            if (fields.Contains(Parm_Folder_FolderName) || fields.Contains("*"))
                tmp.FolderName = dr[Parm_Folder_FolderName].ToString();
            if (fields.Contains(Parm_Folder_ParentId) || fields.Contains("*"))
                tmp.ParentId = dr[Parm_Folder_ParentId].ToString();
            if (fields.Contains(Parm_Folder_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Folder_RowStatus].ToString());
            if (fields.Contains(Parm_Folder_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Folder_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Folder_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Folder_CreatorId].ToString();
            if (fields.Contains(Parm_Folder_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Folder_CreateBy].ToString();
            if (fields.Contains(Parm_Folder_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Folder_CreateOn].ToString());
            if (fields.Contains(Parm_Folder_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Folder_UpdateId].ToString();
            if (fields.Contains(Parm_Folder_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Folder_UpdateBy].ToString();
            if (fields.Contains(Parm_Folder_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Folder_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="folder">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FolderEntity folder, SqlParameter[] parms)
        {
            parms[0].Value = folder.FolderName;
            parms[1].Value = folder.ParentId;
            parms[2].Value = folder.RowStatus;
            parms[3].Value = folder.CreatorId;
            parms[4].Value = folder.CreateBy;
            parms[5].Value = folder.CreateOn;
            parms[6].Value = folder.UpdateId;
            parms[7].Value = folder.UpdateBy;
            parms[8].Value = folder.UpdateOn;
            parms[9].Value = folder.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FolderEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Folder_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Folder_FolderName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_Folder_ParentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Folder_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Folder_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Folder_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Folder_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Folder_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Folder_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Folder_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Folder_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Folder_Insert, parms);
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

