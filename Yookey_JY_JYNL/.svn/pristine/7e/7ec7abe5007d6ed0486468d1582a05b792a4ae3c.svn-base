//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementProcessEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:35
//  功能描述：TeamManagementProcess表实体
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
    public class TeamManagementProcessEntity : ModelImp.BaseModel<TeamManagementProcessEntity>
    {
        public TeamManagementProcessEntity()
        {
            TB_Name = TB_TeamManagementProcess;
            Parm_Id = Parm_TeamManagementProcess_Id;
            Parm_Version = Parm_TeamManagementProcess_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TeamManagementProcess_Insert;
            Sql_Update = Sql_TeamManagementProcess_Update;
            Sql_Delete = Sql_TeamManagementProcess_Delete;
        }
        #region Const of table TeamManagementProcess
        /// <summary>
        /// Table TeamManagementProcess
        /// </summary>
        public const string TB_TeamManagementProcess = "TeamManagementProcess";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm TeamManagementId
        /// </summary>
        public const string Parm_TeamManagementProcess_TeamManagementId = "TeamManagementId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TeamManagementProcess_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TeamManagementProcess_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TeamManagementProcess_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TeamManagementProcess_Id = "Id";
        /// <summary>
        /// Parm Idea
        /// </summary>
        public const string Parm_TeamManagementProcess_Idea = "Idea";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TeamManagementProcess_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_TeamManagementProcess_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TeamManagementProcess_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TeamManagementProcess_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TeamManagementProcess_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_TeamManagementProcess_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_TeamManagementProcess_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TeamManagementProcess_Version = "Version";
        /// <summary>
        /// Insert Query Of TeamManagementProcess
        /// </summary>
        public const string Sql_TeamManagementProcess_Insert = "insert into TeamManagementProcess(TeamManagementId,CreateBy,CreateOn,CreatorId,Idea,RowStatus,Status,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Id) values(@TeamManagementId,@CreateBy,@CreateOn,@CreatorId,@Idea,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TeamManagementProcess
        /// </summary>
        public const string Sql_TeamManagementProcess_Update = "update TeamManagementProcess set TeamManagementId=@TeamManagementId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Idea=@Idea,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TeamManagementProcess_Delete = "update TeamManagementProcess set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _teamManagementId = string.Empty;
        /// <summary>
        /// 任务外键
        /// </summary>
        public string TeamManagementId
        {
            get { return _teamManagementId ?? string.Empty; }
            set { _teamManagementId = value; }
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
        public override TeamManagementProcessEntity SetModelValueByDataRow(DataRow dr)
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
        public override TeamManagementProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TeamManagementProcessEntity();
            if (fields.Contains(Parm_TeamManagementProcess_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_TeamManagementProcess_Id].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_TeamManagementId) || fields.Contains("*"))
                tmp.TeamManagementId = dr[Parm_TeamManagementProcess_TeamManagementId].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_TeamManagementProcess_UserId].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_UserName) || fields.Contains("*"))
                tmp.UserName = dr[Parm_TeamManagementProcess_UserName].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_Idea) || fields.Contains("*"))
                tmp.Idea = dr[Parm_TeamManagementProcess_Idea].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_Status) || fields.Contains("*"))
                tmp.Status = int.Parse(dr[Parm_TeamManagementProcess_Status].ToString());
            if (fields.Contains(Parm_TeamManagementProcess_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_TeamManagementProcess_RowStatus].ToString());
            if (fields.Contains(Parm_TeamManagementProcess_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_TeamManagementProcess_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_TeamManagementProcess_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_TeamManagementProcess_CreatorId].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_TeamManagementProcess_CreateBy].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TeamManagementProcess_CreateOn].ToString());
            if (fields.Contains(Parm_TeamManagementProcess_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_TeamManagementProcess_UpdateId].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_TeamManagementProcess_UpdateBy].ToString();
            if (fields.Contains(Parm_TeamManagementProcess_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TeamManagementProcess_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="teammanagementprocess">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TeamManagementProcessEntity teammanagementprocess, SqlParameter[] parms)
        {
            parms[0].Value = teammanagementprocess.TeamManagementId;
            parms[1].Value = teammanagementprocess.UserId;
            parms[2].Value = teammanagementprocess.UserName;
            parms[3].Value = teammanagementprocess.Idea;
            parms[4].Value = teammanagementprocess.Status;
            parms[5].Value = teammanagementprocess.RowStatus;
            parms[6].Value = teammanagementprocess.CreatorId;
            parms[7].Value = teammanagementprocess.CreateBy;
            parms[8].Value = teammanagementprocess.CreateOn;
            parms[9].Value = teammanagementprocess.UpdateId;
            parms[10].Value = teammanagementprocess.UpdateBy;
            parms[11].Value = teammanagementprocess.UpdateOn;
            parms[12].Value = teammanagementprocess.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TeamManagementProcessEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementProcess_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                new SqlParameter(Parm_TeamManagementProcess_TeamManagementId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_Idea, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagementProcess_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagementProcess_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagementProcess_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagementProcess_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagementProcess_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TeamManagementProcess_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementProcess_Insert, parms);
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

