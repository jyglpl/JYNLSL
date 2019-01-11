
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 每日一题 答题记录
    /// </summary>
    [Serializable]
    public class CrmDailyOneProblemRecordEntity : ModelImp.BaseModel<CrmDailyOneProblemRecordEntity>
    {
        public CrmDailyOneProblemRecordEntity()
        {
            TB_Name = TB_CrmDailyOneProblemRecord;
            Parm_Id = Parm_CrmDailyOneProblemRecord_Id;
            Parm_Version = Parm_CrmDailyOneProblemRecord_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmDailyOneProblemRecord_Insert;
            Sql_Update = Sql_CrmDailyOneProblemRecord_Update;
            Sql_Delete = Sql_CrmDailyOneProblemRecord_Delete;
        }
        #region Const of table CrmDailyOneProblemRecord
        /// <summary>
        /// Table CrmDailyOneProblemRecord
        /// </summary>
        public const string TB_CrmDailyOneProblemRecord = "CrmDailyOneProblemRecord";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_Id = "Id";
        /// <summary>
        /// Parm IsCorrect
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_IsCorrect = "IsCorrect";
        /// <summary>
        /// Parm ProblemId
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_ProblemId = "ProblemId";
        /// <summary>
        /// Parm RightAnswer
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_RightAnswer = "RightAnswer";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserAnswers
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UserAnswers = "UserAnswers";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmDailyOneProblemRecord_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmDailyOneProblemRecord
        /// </summary>
        public const string Sql_CrmDailyOneProblemRecord_Insert = "insert into CrmDailyOneProblemRecord(CreateBy,CreateOn,CreatorId,IsCorrect,ProblemId,RightAnswer,RowStatus,UpdateBy,UpdateId,UpdateOn,UserAnswers,UserId,UserName,Id) values(@CreateBy,@CreateOn,@CreatorId,@IsCorrect,@ProblemId,@RightAnswer,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserAnswers,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmDailyOneProblemRecord
        /// </summary>
        public const string Sql_CrmDailyOneProblemRecord_Update = "update CrmDailyOneProblemRecord set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,IsCorrect=@IsCorrect,ProblemId=@ProblemId,RightAnswer=@RightAnswer,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserAnswers=@UserAnswers,UserId=@UserId,UserName=@UserName where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmDailyOneProblemRecord_Delete = "update CrmDailyOneProblemRecord set RowStatus=0 where Id=@Id ;select @@rowcount;";
        #endregion

        #region Properties
        private string _problemId = string.Empty;
        /// <summary>
        /// 问题Id
        /// </summary>
        public string ProblemId
        {
            get { return _problemId ?? string.Empty; }
            set { _problemId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _userName = string.Empty;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        private string _rightAnswer = string.Empty;
        /// <summary>
        /// 正常答案
        /// </summary>
        public string RightAnswer
        {
            get { return _rightAnswer ?? string.Empty; }
            set { _rightAnswer = value; }
        }
        private string _userAnswers = string.Empty;
        /// <summary>
        /// 用户答案
        /// </summary>
        public string UserAnswers
        {
            get { return _userAnswers ?? string.Empty; }
            set { _userAnswers = value; }
        }
        private int _isCorrect;
        /// <summary>
        /// 是否正确认 1-正确 2-错误
        /// </summary>
        public int IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmDailyOneProblemRecordEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmDailyOneProblemRecordEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmDailyOneProblemRecordEntity();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmDailyOneProblemRecord_Id].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_ProblemId) || fields.Contains("*"))
                tmp.ProblemId = dr[Parm_CrmDailyOneProblemRecord_ProblemId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_CrmDailyOneProblemRecord_UserId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UserName) || fields.Contains("*"))
                tmp.UserName = dr[Parm_CrmDailyOneProblemRecord_UserName].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_RightAnswer) || fields.Contains("*"))
                tmp.RightAnswer = dr[Parm_CrmDailyOneProblemRecord_RightAnswer].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UserAnswers) || fields.Contains("*"))
                tmp.UserAnswers = dr[Parm_CrmDailyOneProblemRecord_UserAnswers].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_IsCorrect) || fields.Contains("*"))
                tmp.IsCorrect = int.Parse(dr[Parm_CrmDailyOneProblemRecord_IsCorrect].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmDailyOneProblemRecord_RowStatus].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmDailyOneProblemRecord_CreatorId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmDailyOneProblemRecord_CreateBy].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmDailyOneProblemRecord_CreateOn].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmDailyOneProblemRecord_UpdateId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmDailyOneProblemRecord_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblemRecord_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmDailyOneProblemRecord_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmdailyoneproblemrecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmDailyOneProblemRecordEntity crmdailyoneproblemrecord, SqlParameter[] parms)
        {
            parms[0].Value = crmdailyoneproblemrecord.ProblemId;
            parms[1].Value = crmdailyoneproblemrecord.UserId;
            parms[2].Value = crmdailyoneproblemrecord.UserName;
            parms[3].Value = crmdailyoneproblemrecord.RightAnswer;
            parms[4].Value = crmdailyoneproblemrecord.UserAnswers;
            parms[5].Value = crmdailyoneproblemrecord.IsCorrect;
            parms[6].Value = crmdailyoneproblemrecord.RowStatus;
            parms[7].Value = crmdailyoneproblemrecord.CreatorId;
            parms[8].Value = crmdailyoneproblemrecord.CreateBy;
            parms[9].Value = crmdailyoneproblemrecord.CreateOn;
            parms[10].Value = crmdailyoneproblemrecord.UpdateId;
            parms[11].Value = crmdailyoneproblemrecord.UpdateBy;
            parms[12].Value = crmdailyoneproblemrecord.UpdateOn;
            parms[13].Value = crmdailyoneproblemrecord.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmDailyOneProblemRecordEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDailyOneProblemRecord_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmDailyOneProblemRecord_ProblemId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_RightAnswer, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UserAnswers, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_IsCorrect, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblemRecord_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmDailyOneProblemRecord_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDailyOneProblemRecord_Insert, parms);
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

