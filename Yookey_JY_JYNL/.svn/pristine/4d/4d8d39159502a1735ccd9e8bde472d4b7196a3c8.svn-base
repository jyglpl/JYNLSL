//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderPermitionEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：FolderPermition表实体
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
    /// 文件夹权限
    /// </summary>
    [Serializable]
    public class FolderPermitionEntity : ModelImp.BaseModel<FolderPermitionEntity>
    {
        /// <summary>
        /// 权限类型
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        public enum PermitionTypeEnum
        {
            /// <summary>
            /// 新增
            /// </summary>
            Create=1,
           /// <summary>
           /// 删除
           /// </summary>
            Delete,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 设置权限
            /// </summary>
            SetPermition
        }
        public FolderPermitionEntity()
        {
            TB_Name = TB_FolderPermition;
            Parm_Id = Parm_FolderPermition_Id;
            Parm_Version = Parm_FolderPermition_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FolderPermition_Insert;
            Sql_Update = Sql_FolderPermition_Update;
            Sql_Delete = Sql_FolderPermition_Delete;
        }

        /// <summary>
        /// 构造函数
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="reader"></param>
        public FolderPermitionEntity(SqlDataReader reader):this()
        {
            Id = reader["Id"].ToString();
            FolderId = reader["FolderId"].ToString();
            UserId = reader["UserId"].ToString();
            Permition = Convert.ToInt32(reader["Permition"]);
            RowStatus = Convert.ToInt32(reader["RowStatus"]);
            CreatorId = reader["CreatorId"].ToString();
            CreateBy = reader["CreateBy"].ToString();
            CreateOn = Convert.ToDateTime(reader["CreateOn"]);
            UpdateId = reader["UpdateId"].ToString();
            UpdateBy = reader["UpdateBy"].ToString();
            UpdateOn = Convert.ToDateTime(reader["UpdateOn"]);
        }
        #region Const of table FolderPermition
        /// <summary>
        /// Table FolderPermition
        /// </summary>
        public const string TB_FolderPermition = "FolderPermition";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FolderPermition_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FolderPermition_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FolderPermition_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FolderId
        /// </summary>
        public const string Parm_FolderPermition_FolderId = "FolderId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FolderPermition_Id = "Id";
        /// <summary>
        /// Parm Permition
        /// </summary>
        public const string Parm_FolderPermition_Permition = "Permition";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FolderPermition_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FolderPermition_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FolderPermition_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FolderPermition_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_FolderPermition_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FolderPermition_Version = "Version";
        /// <summary>
        /// Insert Query Of FolderPermition
        /// </summary>
        public const string Sql_FolderPermition_Insert = "insert into FolderPermition(CreateBy,CreateOn,CreatorId,FolderId,Permition,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,Id) values(@CreateBy,@CreateOn,@CreatorId,@FolderId,@Permition,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FolderPermition
        /// </summary>
        public const string Sql_FolderPermition_Update = "update FolderPermition set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FolderId=@FolderId,Permition=@Permition,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FolderPermition_Delete = "update FolderPermition set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _folderId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FolderId
        {
            get { return _folderId ?? string.Empty; }
            set { _folderId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private int _permition;
        /// <summary>
        /// 
        /// </summary>
        public int Permition
        {
            get { return _permition; }
            set { _permition = value; }
        }
        /// <summary>
        /// 权限类型
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        public PermitionTypeEnum PermitionType {
            get { return (PermitionTypeEnum)Enum.ToObject(typeof(PermitionTypeEnum), Permition); }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FolderPermitionEntity SetModelValueByDataRow(DataRow dr)
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
        public override FolderPermitionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FolderPermitionEntity();
            if (fields.Contains(Parm_FolderPermition_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FolderPermition_Id].ToString();
            if (fields.Contains(Parm_FolderPermition_FolderId) || fields.Contains("*"))
                tmp.FolderId = dr[Parm_FolderPermition_FolderId].ToString();
            if (fields.Contains(Parm_FolderPermition_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_FolderPermition_UserId].ToString();
            if (fields.Contains(Parm_FolderPermition_Permition) || fields.Contains("*"))
                tmp.Permition = int.Parse(dr[Parm_FolderPermition_Permition].ToString());
            if (fields.Contains(Parm_FolderPermition_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FolderPermition_RowStatus].ToString());
            if (fields.Contains(Parm_FolderPermition_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FolderPermition_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FolderPermition_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FolderPermition_CreatorId].ToString();
            if (fields.Contains(Parm_FolderPermition_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FolderPermition_CreateBy].ToString();
            if (fields.Contains(Parm_FolderPermition_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FolderPermition_CreateOn].ToString());
            if (fields.Contains(Parm_FolderPermition_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FolderPermition_UpdateId].ToString();
            if (fields.Contains(Parm_FolderPermition_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FolderPermition_UpdateBy].ToString();
            if (fields.Contains(Parm_FolderPermition_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FolderPermition_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="folderpermition">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FolderPermitionEntity folderpermition, SqlParameter[] parms)
        {
            parms[0].Value = folderpermition.FolderId;
            parms[1].Value = folderpermition.UserId;
            parms[2].Value = folderpermition.Permition;
            parms[3].Value = folderpermition.RowStatus;
            parms[4].Value = folderpermition.CreatorId;
            parms[5].Value = folderpermition.CreateBy;
            parms[6].Value = folderpermition.CreateOn;
            parms[7].Value = folderpermition.UpdateId;
            parms[8].Value = folderpermition.UpdateBy;
            parms[9].Value = folderpermition.UpdateOn;
            parms[10].Value = folderpermition.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FolderPermitionEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FolderPermition_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FolderPermition_FolderId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_Permition, SqlDbType.Int, 10),
					new SqlParameter(Parm_FolderPermition_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FolderPermition_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FolderPermition_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FolderPermition_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FolderPermition_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FolderPermition_Insert, parms);
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

