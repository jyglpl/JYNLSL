//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AssessmentProcessEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/14 15:04:11
//  功能描述：AssessmentProcess表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Assessment
{
    /// <summary>
    /// 路面考核流程
    /// </summary>
    [Serializable]
    public class AssessmentProcessEntity : ModelImp.BaseModel<AssessmentProcessEntity>
    {
        public AssessmentProcessEntity()
        {
            TB_Name = TB_AssessmentProcess;
            Parm_Id = Parm_AssessmentProcess_Id;
            Parm_Version = Parm_AssessmentProcess_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_AssessmentProcess_Insert;
            Sql_Update = Sql_AssessmentProcess_Update;
            Sql_Delete = Sql_AssessmentProcess_Delete;
        }
        #region Const of table AssessmentProcess
        /// <summary>
        /// Table AssessmentProcess
        /// </summary>
        public const string TB_AssessmentProcess = "AssessmentProcess";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AssessmentId
        /// </summary>
        public const string Parm_AssessmentProcess_AssessmentId = "AssessmentId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_AssessmentProcess_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_AssessmentProcess_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_AssessmentProcess_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_AssessmentProcess_Id = "Id";
        /// <summary>
        /// Parm Idea
        /// </summary>
        public const string Parm_AssessmentProcess_Idea = "Idea";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_AssessmentProcess_Status = "Status";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_AssessmentProcess_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_AssessmentProcess_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_AssessmentProcess_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_AssessmentProcess_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_AssessmentProcess_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_AssessmentProcess_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_AssessmentProcess_Version = "Version";
        /// <summary>
        /// Insert Query Of AssessmentProcess
        /// </summary>
        public const string Sql_AssessmentProcess_Insert = "insert into AssessmentProcess(AssessmentId,CreateBy,CreateOn,CreatorId,Idea,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Status,Id) values(@AssessmentId,@CreateBy,@CreateOn,@CreatorId,@Idea,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Status,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of AssessmentProcess
        /// </summary>
        public const string Sql_AssessmentProcess_Update = "update AssessmentProcess set AssessmentId=@AssessmentId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Idea=@Idea,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName,Status=@Status where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_AssessmentProcess_Delete = "update AssessmentProcess set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _assessmentId = string.Empty;
        /// <summary>
        /// 任务外键
        /// </summary>
        public string AssessmentId
        {
            get { return _assessmentId ?? string.Empty; }
            set { _assessmentId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 处理人编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _userName = string.Empty;
        /// <summary>
        /// 处理人姓名
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        private string _idea = string.Empty;
        /// <summary>
        /// 处理意见
        /// </summary>
        public string Idea
        {
            get { return _idea ?? string.Empty; }
            set { _idea = value; }
        }

        private int _status;
        /// <summary>
        /// 状态：0:待处理,1:处理中,2:已处理,3:已核查
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override AssessmentProcessEntity SetModelValueByDataRow(DataRow dr)
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
        public override AssessmentProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AssessmentProcessEntity();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_Id))
                tmp.Id = dr[Parm_AssessmentProcess_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_AssessmentId))
                tmp.AssessmentId = dr[Parm_AssessmentProcess_AssessmentId].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_UserId))
                tmp.UserId = dr[Parm_AssessmentProcess_UserId].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_UserName))
                tmp.UserName = dr[Parm_AssessmentProcess_UserName].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_Idea))
                tmp.Idea = dr[Parm_AssessmentProcess_Idea].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_AssessmentProcess_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_Version))
            {
                var bts = (byte[])(dr[Parm_AssessmentProcess_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_CreatorId))
                tmp.CreatorId = dr[Parm_AssessmentProcess_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_CreateBy))
                tmp.CreateBy = dr[Parm_AssessmentProcess_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_AssessmentProcess_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_UpdateId))
                tmp.UpdateId = dr[Parm_AssessmentProcess_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_UpdateBy))
                tmp.UpdateBy = dr[Parm_AssessmentProcess_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_AssessmentProcess_UpdateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AssessmentProcess_Status))
                tmp.Status = int.Parse(dr[Parm_AssessmentProcess_Status].ToString());
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="assessmentprocess">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AssessmentProcessEntity assessmentprocess, SqlParameter[] parms)
        {
            parms[0].Value = assessmentprocess.AssessmentId;
            parms[1].Value = assessmentprocess.UserId;
            parms[2].Value = assessmentprocess.UserName;
            parms[3].Value = assessmentprocess.Idea;
            parms[4].Value = assessmentprocess.RowStatus;
            parms[5].Value = assessmentprocess.CreatorId;
            parms[6].Value = assessmentprocess.CreateBy;
            parms[7].Value = assessmentprocess.CreateOn;
            parms[8].Value = assessmentprocess.UpdateId;
            parms[9].Value = assessmentprocess.UpdateBy;
            parms[10].Value = assessmentprocess.UpdateOn;
            parms[11].Value = assessmentprocess.Status;
            parms[12].Value = assessmentprocess.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AssessmentProcessEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_AssessmentProcess_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_AssessmentProcess_AssessmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_Idea, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_AssessmentProcess_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_AssessmentProcess_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_AssessmentProcess_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AssessmentProcess_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_AssessmentProcess_Status, SqlDbType.Int, 10),
                    new SqlParameter(Parm_AssessmentProcess_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_AssessmentProcess_Insert, parms);
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

