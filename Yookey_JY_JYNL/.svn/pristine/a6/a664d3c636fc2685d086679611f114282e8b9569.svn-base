//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_SURVEYEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:21
//  功能描述：INF_PUNISH_SURVEY表实体
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
    /// 调查取证
    /// </summary>
    [Serializable]
    public class InfPunishSurveyEntity : ModelImp.BaseModel<InfPunishSurveyEntity>
    {
        public InfPunishSurveyEntity()
        {
            TB_Name = TB_INF_PUNISH_SURVEY;
            Parm_Id = Parm_INF_PUNISH_SURVEY_Id;
            Parm_Version = Parm_INF_PUNISH_SURVEY_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_SURVEY_Insert;
            Sql_Update = Sql_INF_PUNISH_SURVEY_Update;
            Sql_Delete = Sql_INF_PUNISH_SURVEY_Delete;
        }
        #region Const of table INF_PUNISH_SURVEY
        /// <summary>
        /// Table INF_PUNISH_SURVEY
        /// </summary>
        public const string TB_INF_PUNISH_SURVEY = "INF_PUNISH_SURVEY";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_Id = "Id";
        /// <summary>
        /// Parm RegisterDate
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_RegisterDate = "RegisterDate";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SurveyDesc
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_SurveyDesc = "SurveyDesc";
        /// <summary>
        /// Parm SurveyOjbect
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_SurveyOjbect = "SurveyOjbect";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_SURVEY_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_PUNISH_SURVEY
        /// </summary>
        public const string Sql_INF_PUNISH_SURVEY_Insert = "insert into INF_PUNISH_SURVEY(CaseInfoId,CreateBy,CreateOn,CreatorId,RegisterDate,RowStatus,SurveyDesc,SurveyOjbect,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@RegisterDate,@RowStatus,@SurveyDesc,@SurveyOjbect,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_PUNISH_SURVEY
        /// </summary>
        public const string Sql_INF_PUNISH_SURVEY_Update = "update INF_PUNISH_SURVEY set CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RegisterDate=@RegisterDate,RowStatus=@RowStatus,SurveyDesc=@SurveyDesc,SurveyOjbect=@SurveyOjbect,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_SURVEY_Delete = "update INF_PUNISH_SURVEY set RowStatus=0 where Id=@Id;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoId = string.Empty;
        /// <summary>
        /// nvarchar 	案件编号
        /// </summary>
        public string CaseInfoId
        {
            get { return _caseInfoId ?? string.Empty; }
            set { _caseInfoId = value; }
        }
        private string _registerDate = string.Empty;
        /// <summary>
        /// datetime 	调查时间（yyyy-Mm-dd hh24:mi:ss）
        /// </summary>
        public string RegisterDate
        {
            get { return _registerDate ?? string.Empty; }
            set { _registerDate = value; }
        }
        private string _surveyDesc = string.Empty;
        /// <summary>
        /// nvarchar 	调查情况
        /// </summary>
        public string SurveyDesc
        {
            get { return _surveyDesc ?? string.Empty; }
            set { _surveyDesc = value; }
        }
        private string _surveyOjbect = string.Empty;
        /// <summary>
        /// nvarchar 	调查对象
        /// </summary>
        public string SurveyOjbect
        {
            get { return _surveyOjbect ?? string.Empty; }
            set { _surveyOjbect = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishSurveyEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishSurveyEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishSurveyEntity();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_SURVEY_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_SURVEY_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_RegisterDate) || fields.Contains("*"))
                tmp.RegisterDate = dr[Parm_INF_PUNISH_SURVEY_RegisterDate].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_SurveyDesc) || fields.Contains("*"))
                tmp.SurveyDesc = dr[Parm_INF_PUNISH_SURVEY_SurveyDesc].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_SurveyOjbect) || fields.Contains("*"))
                tmp.SurveyOjbect = dr[Parm_INF_PUNISH_SURVEY_SurveyOjbect].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_SURVEY_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_SURVEY_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_SURVEY_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_SURVEY_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_SURVEY_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_SURVEY_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_SURVEY_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_SURVEY_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_SURVEY_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_survey">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishSurveyEntity inf_punish_survey, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_survey.CaseInfoId;
            parms[1].Value = inf_punish_survey.RegisterDate;
            parms[2].Value = inf_punish_survey.SurveyDesc;
            parms[3].Value = inf_punish_survey.SurveyOjbect;
            parms[4].Value = inf_punish_survey.RowStatus;
            parms[5].Value = inf_punish_survey.CreatorId;
            parms[6].Value = inf_punish_survey.CreateBy;
            parms[7].Value = inf_punish_survey.CreateOn;
            parms[8].Value = inf_punish_survey.UpdateId;
            parms[9].Value = inf_punish_survey.UpdateBy;
            parms[10].Value = inf_punish_survey.UpdateOn;
            parms[11].Value = inf_punish_survey.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishSurveyEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_SURVEY_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_SURVEY_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_RegisterDate, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_SurveyDesc, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_SurveyOjbect, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_SURVEY_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_SURVEY_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_SURVEY_Insert, parms);
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

