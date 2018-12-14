
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 每日一题  实体类
    /// </summary>
    [Serializable]
    public class CrmDailyOneProblemEntity : ModelImp.BaseModel<CrmDailyOneProblemEntity>
    {
        public CrmDailyOneProblemEntity()
        {
            TB_Name = TB_CrmDailyOneProblem;
            Parm_Id = Parm_CrmDailyOneProblem_Id;
            Parm_Version = Parm_CrmDailyOneProblem_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmDailyOneProblem_Insert;
            Sql_Update = Sql_CrmDailyOneProblem_Update;
            Sql_Delete = Sql_CrmDailyOneProblem_Delete;
        }
        #region Const of table CrmDailyOneProblem
        /// <summary>
        /// Table CrmDailyOneProblem
        /// </summary>
        public const string TB_CrmDailyOneProblem = "CrmDailyOneProblem";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm QuestionBankType
        /// </summary>
        public const string Parm_CrmDailyOneProblem_QuestionBankType = "QuestionBankType";
        /// <summary>
        /// Parm Answer
        /// </summary>
        public const string Parm_CrmDailyOneProblem_Answer = "Answer";
        /// <summary>
        /// Parm AppointedDay
        /// </summary>
        public const string Parm_CrmDailyOneProblem_AppointedDay = "AppointedDay";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmDailyOneProblem_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmDailyOneProblem_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmDailyOneProblem_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmDailyOneProblem_Id = "Id";
        /// <summary>
        /// Parm OptionA
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionA = "OptionA";
        /// <summary>
        /// Parm OptionB
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionB = "OptionB";
        /// <summary>
        /// Parm OptionC
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionC = "OptionC";
        /// <summary>
        /// Parm OptionD
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionD = "OptionD";
        /// <summary>
        /// Parm OptionE
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionE = "OptionE";
        /// <summary>
        /// Parm OptionF
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionF = "OptionF";
        /// <summary>
        /// Parm OptionG
        /// </summary>
        public const string Parm_CrmDailyOneProblem_OptionG = "OptionG";
        /// <summary>
        /// Parm Question
        /// </summary>
        public const string Parm_CrmDailyOneProblem_Question = "Question";
        /// <summary>
        /// Parm QuestionsTypeId
        /// </summary>
        public const string Parm_CrmDailyOneProblem_QuestionsTypeId = "QuestionsTypeId";
        /// <summary>
        /// Parm QuestionsTypeName
        /// </summary>
        public const string Parm_CrmDailyOneProblem_QuestionsTypeName = "QuestionsTypeName";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmDailyOneProblem_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Time
        /// </summary>
        public const string Parm_CrmDailyOneProblem_Time = "Time";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmDailyOneProblem_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmDailyOneProblem_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmDailyOneProblem_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmDailyOneProblem_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmDailyOneProblem
        /// </summary>
        public const string Sql_CrmDailyOneProblem_Insert = "insert into CrmDailyOneProblem(Answer,AppointedDay,CreateBy,CreateOn,CreatorId,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,Question,QuestionsTypeId,QuestionsTypeName,RowStatus,Time,UpdateBy,UpdateId,UpdateOn,Id,QuestionBankType) values(@Answer,@AppointedDay,@CreateBy,@CreateOn,@CreatorId,@OptionA,@OptionB,@OptionC,@OptionD,@OptionE,@OptionF,@OptionG,@Question,@QuestionsTypeId,@QuestionsTypeName,@RowStatus,@Time,@UpdateBy,@UpdateId,@UpdateOn,@Id,@QuestionBankType);select @@identity;";
        /// <summary>
        /// Update Query Of CrmDailyOneProblem
        /// </summary>
        public const string Sql_CrmDailyOneProblem_Update = "update CrmDailyOneProblem set Answer=@Answer,AppointedDay=@AppointedDay,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OptionA=@OptionA,OptionB=@OptionB,OptionC=@OptionC,OptionD=@OptionD,OptionE=@OptionE,OptionF=@OptionF,OptionG=@OptionG,Question=@Question,QuestionsTypeId=@QuestionsTypeId,QuestionsTypeName=@QuestionsTypeName,RowStatus=@RowStatus,Time=@Time,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,QuestionBankType=@QuestionBankType where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmDailyOneProblem_Delete = "update CrmDailyOneProblem set RowStatus=0 where Id=@Id ;select @@rowcount;";
        #endregion

        #region Properties
        private string _questionBankType = string.Empty;
        /// <summary>
        /// 题库类型
        /// </summary>
        public string QuestionBankType
        {
            get { return _questionBankType ?? string.Empty; }
            set { _questionBankType = value; }
        }
        private string _questionsTypeId = string.Empty;
        /// <summary>
        /// 题目类型-Id
        /// </summary>
        public string QuestionsTypeId
        {
            get { return _questionsTypeId ?? string.Empty; }
            set { _questionsTypeId = value; }
        }
        private string _questionsTypeName = string.Empty;
        /// <summary>
        /// 题目类型-名称
        /// </summary>
        public string QuestionsTypeName
        {
            get { return _questionsTypeName ?? string.Empty; }
            set { _questionsTypeName = value; }
        }
        private string _question = string.Empty;
        /// <summary>
        /// 问题
        /// </summary>
        public string Question
        {
            get { return _question ?? string.Empty; }
            set { _question = value; }
        }
        private string _optionA = string.Empty;
        /// <summary>
        /// 选项A
        /// </summary>
        public string OptionA
        {
            get { return _optionA ?? string.Empty; }
            set { _optionA = value; }
        }
        private string _optionB = string.Empty;
        /// <summary>
        /// 选项B
        /// </summary>
        public string OptionB
        {
            get { return _optionB ?? string.Empty; }
            set { _optionB = value; }
        }
        private string _optionC = string.Empty;
        /// <summary>
        /// 选项C
        /// </summary>
        public string OptionC
        {
            get { return _optionC ?? string.Empty; }
            set { _optionC = value; }
        }
        private string _optionD = string.Empty;
        /// <summary>
        /// 选项D
        /// </summary>
        public string OptionD
        {
            get { return _optionD ?? string.Empty; }
            set { _optionD = value; }
        }
        private string _optionE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string OptionE
        {
            get { return _optionE ?? string.Empty; }
            set { _optionE = value; }
        }
        private string _optionF = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string OptionF
        {
            get { return _optionF ?? string.Empty; }
            set { _optionF = value; }
        }
        private string _optionG = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string OptionG
        {
            get { return _optionG ?? string.Empty; }
            set { _optionG = value; }
        }
        private string _answer = string.Empty;
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer
        {
            get { return _answer ?? string.Empty; }
            set { _answer = value; }
        }
        private DateTime _time = MinDate;
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
        private DateTime _appointedDay = MinDate;
        /// <summary>
        /// 指定日期
        /// </summary>
        public DateTime AppointedDay
        {
            get { return _appointedDay; }
            set { _appointedDay = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmDailyOneProblemEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmDailyOneProblemEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmDailyOneProblemEntity();
            if (fields.Contains(Parm_CrmDailyOneProblem_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmDailyOneProblem_Id].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_QuestionsTypeId) || fields.Contains("*"))
                tmp.QuestionsTypeId = dr[Parm_CrmDailyOneProblem_QuestionsTypeId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_QuestionsTypeName) || fields.Contains("*"))
                tmp.QuestionsTypeName = dr[Parm_CrmDailyOneProblem_QuestionsTypeName].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_Question) || fields.Contains("*"))
                tmp.Question = dr[Parm_CrmDailyOneProblem_Question].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionA) || fields.Contains("*"))
                tmp.OptionA = dr[Parm_CrmDailyOneProblem_OptionA].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionB) || fields.Contains("*"))
                tmp.OptionB = dr[Parm_CrmDailyOneProblem_OptionB].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionC) || fields.Contains("*"))
                tmp.OptionC = dr[Parm_CrmDailyOneProblem_OptionC].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionD) || fields.Contains("*"))
                tmp.OptionD = dr[Parm_CrmDailyOneProblem_OptionD].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionE) || fields.Contains("*"))
                tmp.OptionE = dr[Parm_CrmDailyOneProblem_OptionE].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionF) || fields.Contains("*"))
                tmp.OptionF = dr[Parm_CrmDailyOneProblem_OptionF].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_OptionG) || fields.Contains("*"))
                tmp.OptionG = dr[Parm_CrmDailyOneProblem_OptionG].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_Answer) || fields.Contains("*"))
                tmp.Answer = dr[Parm_CrmDailyOneProblem_Answer].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_Time) || fields.Contains("*"))
                tmp.Time = DateTime.Parse(dr[Parm_CrmDailyOneProblem_Time].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblem_AppointedDay) || fields.Contains("*"))
                tmp.AppointedDay = DateTime.Parse(dr[Parm_CrmDailyOneProblem_AppointedDay].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblem_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmDailyOneProblem_RowStatus].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblem_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmDailyOneProblem_CreatorId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmDailyOneProblem_CreateBy].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmDailyOneProblem_CreateOn].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblem_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmDailyOneProblem_UpdateId].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmDailyOneProblem_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmDailyOneProblem_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmDailyOneProblem_UpdateOn].ToString());
            if (fields.Contains(Parm_CrmDailyOneProblem_QuestionBankType) || fields.Contains("*"))
                tmp.QuestionBankType = dr[Parm_CrmDailyOneProblem_QuestionBankType].ToString();
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmdailyoneproblem">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmDailyOneProblemEntity crmdailyoneproblem, SqlParameter[] parms)
        {
            parms[0].Value = crmdailyoneproblem.QuestionsTypeId;
            parms[1].Value = crmdailyoneproblem.QuestionsTypeName;
            parms[2].Value = crmdailyoneproblem.Question;
            parms[3].Value = crmdailyoneproblem.OptionA;
            parms[4].Value = crmdailyoneproblem.OptionB;
            parms[5].Value = crmdailyoneproblem.OptionC;
            parms[6].Value = crmdailyoneproblem.OptionD;
            parms[7].Value = crmdailyoneproblem.OptionE;
            parms[8].Value = crmdailyoneproblem.OptionF;
            parms[9].Value = crmdailyoneproblem.OptionG;
            parms[10].Value = crmdailyoneproblem.Answer;
            parms[11].Value = crmdailyoneproblem.Time;
            parms[12].Value = crmdailyoneproblem.AppointedDay;
            parms[13].Value = crmdailyoneproblem.RowStatus;
            parms[14].Value = crmdailyoneproblem.CreatorId;
            parms[15].Value = crmdailyoneproblem.CreateBy;
            parms[16].Value = crmdailyoneproblem.CreateOn;
            parms[17].Value = crmdailyoneproblem.UpdateId;
            parms[18].Value = crmdailyoneproblem.UpdateBy;
            parms[19].Value = crmdailyoneproblem.UpdateOn;
            parms[20].Value = crmdailyoneproblem.Id;
            parms[21].Value = crmdailyoneproblem.QuestionBankType;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmDailyOneProblemEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDailyOneProblem_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmDailyOneProblem_QuestionsTypeId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_QuestionsTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_Question, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionA, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionB, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionC, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionD, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionE, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionF, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_OptionG, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_CrmDailyOneProblem_Answer, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_CrmDailyOneProblem_Time, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmDailyOneProblem_AppointedDay, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmDailyOneProblem_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmDailyOneProblem_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmDailyOneProblem_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmDailyOneProblem_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmDailyOneProblem_Id, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_CrmDailyOneProblem_QuestionBankType, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmDailyOneProblem_Insert, parms);
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

