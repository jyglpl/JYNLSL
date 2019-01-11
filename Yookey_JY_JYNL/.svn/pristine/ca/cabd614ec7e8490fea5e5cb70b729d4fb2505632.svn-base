using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Petition
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PetitonProcessEntity : ModelImp.BaseModel<PetitonProcessEntity>
    {
        public PetitonProcessEntity()
        {
            TB_Name = TB_PetitonProcess;
            Parm_Id = Parm_PetitonProcess_Id;
            Parm_Version = Parm_PetitonProcess_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_PetitonProcess_Insert;
            Sql_Update = Sql_PetitonProcess_Update;
            Sql_Delete = Sql_PetitonProcess_Delete;
        }
        #region Const of table PetitonProcess
        /// <summary>
        /// Table PetitonProcess
        /// </summary>
        public const string TB_PetitonProcess = "PetitonProcess";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Content
        /// </summary>
        public const string Parm_PetitonProcess_Content = "Content";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_PetitonProcess_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_PetitonProcess_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_PetitonProcess_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_PetitonProcess_Id = "Id";
        /// <summary>
        /// Parm ReceiveUser
        /// </summary>
        public const string Parm_PetitonProcess_ReceiveUser = "ReceiveUser";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_PetitonProcess_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TaskUser
        /// </summary>
        public const string Parm_PetitonProcess_TaskUser = "TaskUser";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_PetitonProcess_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_PetitonProcess_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_PetitonProcess_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_PetitonProcess_Version = "Version";
        /// <summary>
        /// Parm WorkId
        /// </summary>
        public const string Parm_PetitonProcess_WorkId = "WorkId";
        /// <summary>
        /// Insert Query Of PetitonProcess
        /// </summary>
        public const string Sql_PetitonProcess_Insert = "insert into PetitonProcess(Content,CreateBy,CreateOn,CreatorId,ReceiveUser,RowStatus,TaskUser,UpdateBy,UpdateId,UpdateOn,WorkId,Id) values(@Content,@CreateBy,@CreateOn,@CreatorId,@ReceiveUser,@RowStatus,@TaskUser,@UpdateBy,@UpdateId,@UpdateOn,@WorkId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of PetitonProcess
        /// </summary>
        public const string Sql_PetitonProcess_Update = "update PetitonProcess set Content=@Content,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ReceiveUser=@ReceiveUser,RowStatus=@RowStatus,TaskUser=@TaskUser,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WorkId=@WorkId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_PetitonProcess_Delete = "update PetitonProcess set RowStatus=0 where Id=@Id;select @@rowcount;";
        #endregion

        #region Properties
        private string _workId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WorkId
        {
            get { return _workId ?? string.Empty; }
            set { _workId = value; }
        }
        private string _taskUser = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string TaskUser
        {
            get { return _taskUser ?? string.Empty; }
            set { _taskUser = value; }
        }
        private string _content = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return _content ?? string.Empty; }
            set { _content = value; }
        }
        private string _receiveUser = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveUser
        {
            get { return _receiveUser ?? string.Empty; }
            set { _receiveUser = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override PetitonProcessEntity SetModelValueByDataRow(DataRow dr)
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
        public override PetitonProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new PetitonProcessEntity();
            if (fields.Contains(Parm_PetitonProcess_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_PetitonProcess_Id].ToString();
            if (fields.Contains(Parm_PetitonProcess_WorkId) || fields.Contains("*"))
                tmp.WorkId = dr[Parm_PetitonProcess_WorkId].ToString();
            if (fields.Contains(Parm_PetitonProcess_TaskUser) || fields.Contains("*"))
                tmp.TaskUser = dr[Parm_PetitonProcess_TaskUser].ToString();
            if (fields.Contains(Parm_PetitonProcess_Content) || fields.Contains("*"))
                tmp.Content = dr[Parm_PetitonProcess_Content].ToString();
            if (fields.Contains(Parm_PetitonProcess_ReceiveUser) || fields.Contains("*"))
                tmp.ReceiveUser = dr[Parm_PetitonProcess_ReceiveUser].ToString();
            if (fields.Contains(Parm_PetitonProcess_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_PetitonProcess_RowStatus].ToString());
            if (fields.Contains(Parm_PetitonProcess_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_PetitonProcess_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_PetitonProcess_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_PetitonProcess_CreatorId].ToString();
            if (fields.Contains(Parm_PetitonProcess_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_PetitonProcess_CreateBy].ToString();
            if (fields.Contains(Parm_PetitonProcess_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_PetitonProcess_CreateOn].ToString());
            if (fields.Contains(Parm_PetitonProcess_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_PetitonProcess_UpdateId].ToString();
            if (fields.Contains(Parm_PetitonProcess_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_PetitonProcess_UpdateBy].ToString();
            if (fields.Contains(Parm_PetitonProcess_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_PetitonProcess_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="petitonprocess">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(PetitonProcessEntity petitonprocess, SqlParameter[] parms)
        {
            parms[0].Value = petitonprocess.WorkId;
            parms[1].Value = petitonprocess.TaskUser;
            parms[2].Value = petitonprocess.Content;
            parms[3].Value = petitonprocess.ReceiveUser;
            parms[4].Value = petitonprocess.RowStatus;
            parms[5].Value = petitonprocess.CreatorId;
            parms[6].Value = petitonprocess.CreateBy;
            parms[7].Value = petitonprocess.CreateOn;
            parms[8].Value = petitonprocess.UpdateId;
            parms[9].Value = petitonprocess.UpdateBy;
            parms[10].Value = petitonprocess.UpdateOn;
            parms[11].Value = petitonprocess.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(PetitonProcessEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_PetitonProcess_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_PetitonProcess_Version, model.Version);
            return parms;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_PetitonProcess_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_PetitonProcess_WorkId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_PetitonProcess_TaskUser, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_PetitonProcess_Content, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_PetitonProcess_ReceiveUser, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_PetitonProcess_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_PetitonProcess_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_PetitonProcess_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_PetitonProcess_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_PetitonProcess_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_PetitonProcess_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_PetitonProcess_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_PetitonProcess_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_PetitonProcess_Insert, parms);
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
