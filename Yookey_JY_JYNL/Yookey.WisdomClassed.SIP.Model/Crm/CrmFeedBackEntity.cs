//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmFeedBackEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/7/15 14:44:43
//  功能描述：CrmFeedBack表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class CrmFeedBackEntity : ModelImp.BaseModel<CrmFeedBackEntity>
    {
        public CrmFeedBackEntity()
        {
            TB_Name = TB_CrmFeedBack;
            Parm_Id = Parm_CrmFeedBack_Id;
            Parm_Version = Parm_CrmFeedBack_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmFeedBack_Insert;
            Sql_Update = Sql_CrmFeedBack_Update;
            Sql_Delete = Sql_CrmFeedBack_Delete;
        }
        #region Const of table CrmFeedBack
        /// <summary>
        /// Table CrmFeedBack
        /// </summary>
        public const string TB_CrmFeedBack = "CrmFeedBack";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmFeedBack_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmFeedBack_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmFeedBack_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmFeedBack_Id = "Id";
        /// <summary>
        /// Parm Idea
        /// </summary>
        public const string Parm_CrmFeedBack_Idea = "Idea";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmFeedBack_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmFeedBack_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmFeedBack_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmFeedBack_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_CrmFeedBack_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_CrmFeedBack_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmFeedBack_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmFeedBack
        /// </summary>
        public const string Sql_CrmFeedBack_Insert = "insert into CrmFeedBack(CreateBy,CreateOn,CreatorId,Idea,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Id) values(@CreateBy,@CreateOn,@CreatorId,@Idea,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmFeedBack
        /// </summary>
        public const string Sql_CrmFeedBack_Update = "update CrmFeedBack set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Idea=@Idea,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmFeedBack_Delete = "update CrmFeedBack set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _idea = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Idea
        {
            get { return _idea ?? string.Empty; }
            set { _idea = value; }
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
        private string _userName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmFeedBackEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmFeedBackEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmFeedBackEntity();
            if (fields.Contains(Parm_CrmFeedBack_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmFeedBack_Id].ToString();
            if (fields.Contains(Parm_CrmFeedBack_Idea) || fields.Contains("*"))
                tmp.Idea = dr[Parm_CrmFeedBack_Idea].ToString();
            if (fields.Contains(Parm_CrmFeedBack_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_CrmFeedBack_UserId].ToString();
            if (fields.Contains(Parm_CrmFeedBack_UserName) || fields.Contains("*"))
                tmp.UserName = dr[Parm_CrmFeedBack_UserName].ToString();
            if (fields.Contains(Parm_CrmFeedBack_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmFeedBack_RowStatus].ToString());
            if (fields.Contains(Parm_CrmFeedBack_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_CrmFeedBack_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_CrmFeedBack_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmFeedBack_CreatorId].ToString();
            if (fields.Contains(Parm_CrmFeedBack_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmFeedBack_CreateBy].ToString();
            if (fields.Contains(Parm_CrmFeedBack_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmFeedBack_CreateOn].ToString());
            if (fields.Contains(Parm_CrmFeedBack_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmFeedBack_UpdateId].ToString();
            if (fields.Contains(Parm_CrmFeedBack_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmFeedBack_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmFeedBack_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmFeedBack_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmfeedback">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmFeedBackEntity crmfeedback, SqlParameter[] parms)
        {
            parms[0].Value = crmfeedback.Idea;
            parms[1].Value = crmfeedback.UserId;
            parms[2].Value = crmfeedback.UserName;
            parms[3].Value = crmfeedback.RowStatus;
            parms[4].Value = crmfeedback.CreatorId;
            parms[5].Value = crmfeedback.CreateBy;
            parms[6].Value = crmfeedback.CreateOn;
            parms[7].Value = crmfeedback.UpdateId;
            parms[8].Value = crmfeedback.UpdateBy;
            parms[9].Value = crmfeedback.UpdateOn;
            parms[10].Value = crmfeedback.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmFeedBackEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmFeedBack_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmFeedBack_Idea, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmFeedBack_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmFeedBack_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmFeedBack_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmFeedBack_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmFeedBack_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmFeedBack_Insert, parms);
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

