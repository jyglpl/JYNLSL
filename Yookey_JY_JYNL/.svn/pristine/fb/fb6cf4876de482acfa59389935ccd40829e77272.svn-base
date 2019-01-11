//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_LEGISLATIONEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/31 9:17:26
//  功能描述：INF_PUNISH_LEGISLATION表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class InfPunishLegislationEntity : ModelImp.BaseModel<InfPunishLegislationEntity>
    {
        public InfPunishLegislationEntity()
        {
            TB_Name = TB_INF_PUNISH_LEGISLATION;
            Parm_Id = Parm_INF_PUNISH_LEGISLATION_Id;
            Parm_Version = Parm_INF_PUNISH_LEGISLATION_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_LEGISLATION_Insert;
            Sql_Update = Sql_INF_PUNISH_LEGISLATION_Update;
            Sql_Delete = Sql_INF_PUNISH_LEGISLATION_Delete;
        }
        #region Const of table INF_PUNISH_LEGISLATION
        /// <summary>
        /// Table INF_PUNISH_LEGISLATION
        /// </summary>
        public const string TB_INF_PUNISH_LEGISLATION = "INF_PUNISH_LEGISLATION";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm ClassNo
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ClassNo = "ClassNo";
        /// <summary>
        /// Parm ClassNoName
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ClassNoName = "ClassNoName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DutyName
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_DutyName = "DutyName";
        /// <summary>
        /// Parm ForfeitureAmount
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ForfeitureAmount = "ForfeitureAmount";
        /// <summary>
        /// Parm GistName
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_GistName = "GistName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_Id = "Id";
        /// <summary>
        /// Parm ItemAct
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ItemAct = "ItemAct";
        /// <summary>
        /// Parm ItemCode
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ItemCode = "ItemCode";
        /// <summary>
        /// Parm ItemName
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ItemName = "ItemName";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ItemNo = "ItemNo";
        /// <summary>
        /// Parm ItemType
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_ItemType = "ItemType";
        /// <summary>
        /// Parm LegislationGistId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_LegislationGistId = "LegislationGistId";
        /// <summary>
        /// Parm LegislationId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_LegislationId = "LegislationId";
        /// <summary>
        /// Parm LegislationItemId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_LegislationItemId = "LegislationItemId";
        /// <summary>
        /// Parm LegislationRuleId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_LegislationRuleId = "LegislationRuleId";
        /// <summary>
        /// Parm Measurement
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_Measurement = "Measurement";
        /// <summary>
        /// Parm PunishAmount
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_PunishAmount = "PunishAmount";
        /// <summary>
        /// Parm PunishContent
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_PunishContent = "PunishContent";
        /// <summary>
        /// Parm PunishMax
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_PunishMax = "PunishMax";
        /// <summary>
        /// Parm PunishMin
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_PunishMin = "PunishMin";
        /// <summary>
        /// Parm PunishType
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_PunishType = "PunishType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StipulateFirst
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_StipulateFirst = "StipulateFirst";
        /// <summary>
        /// Parm StipulateSecond
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_StipulateSecond = "StipulateSecond";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_LEGISLATION_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_PUNISH_LEGISLATION
        /// </summary>
        public const string Sql_INF_PUNISH_LEGISLATION_Insert = "insert into INF_PUNISH_LEGISLATION(CaseInfoId,ClassNo,ClassNoName,CreateBy,CreateOn,CreatorId,DutyName,ForfeitureAmount,GistName,ItemAct,ItemCode,ItemName,ItemNo,ItemType,LegislationGistId,LegislationId,LegislationItemId,LegislationRuleId,Measurement,PunishAmount,PunishContent,PunishMax,PunishMin,PunishType,RowStatus,StipulateFirst,StipulateSecond,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@ClassNo,@ClassNoName,@CreateBy,@CreateOn,@CreatorId,@DutyName,@ForfeitureAmount,@GistName,@ItemAct,@ItemCode,@ItemName,@ItemNo,@ItemType,@LegislationGistId,@LegislationId,@LegislationItemId,@LegislationRuleId,@Measurement,@PunishAmount,@PunishContent,@PunishMax,@PunishMin,@PunishType,@RowStatus,@StipulateFirst,@StipulateSecond,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_PUNISH_LEGISLATION
        /// </summary>
        public const string Sql_INF_PUNISH_LEGISLATION_Update = "update INF_PUNISH_LEGISLATION set CaseInfoId=@CaseInfoId,ClassNo=@ClassNo,ClassNoName=@ClassNoName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyName=@DutyName,ForfeitureAmount=@ForfeitureAmount,GistName=@GistName,ItemAct=@ItemAct,ItemCode=@ItemCode,ItemName=@ItemName,ItemNo=@ItemNo,ItemType=@ItemType,LegislationGistId=@LegislationGistId,LegislationId=@LegislationId,LegislationItemId=@LegislationItemId,LegislationRuleId=@LegislationRuleId,Measurement=@Measurement,PunishAmount=@PunishAmount,PunishContent=@PunishContent,PunishMax=@PunishMax,PunishMin=@PunishMin,PunishType=@PunishType,RowStatus=@RowStatus,StipulateFirst=@StipulateFirst,StipulateSecond=@StipulateSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_LEGISLATION_Delete = "update INF_PUNISH_LEGISLATION set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CaseInfoId
        {
            get { return _caseInfoId ?? string.Empty; }
            set { _caseInfoId = value; }
        }
        private string _legislationId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LegislationId
        {
            get { return _legislationId ?? string.Empty; }
            set { _legislationId = value; }
        }
        private string _itemCode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemCode
        {
            get { return _itemCode ?? string.Empty; }
            set { _itemCode = value; }
        }
        private string _itemType = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemType
        {
            get { return _itemType ?? string.Empty; }
            set { _itemType = value; }
        }
        private string _itemNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _itemAct = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemAct
        {
            get { return _itemAct ?? string.Empty; }
            set { _itemAct = value; }
        }
        private string _classNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ClassNo
        {
            get { return _classNo ?? string.Empty; }
            set { _classNo = value; }
        }
        private string _classNoName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ClassNoName
        {
            get { return _classNoName ?? string.Empty; }
            set { _classNoName = value; }
        }
        private string _legislationItemId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LegislationItemId
        {
            get { return _legislationItemId ?? string.Empty; }
            set { _legislationItemId = value; }
        }
        private string _itemName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? string.Empty; }
            set { _itemName = value; }
        }
        private string _legislationGistId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LegislationGistId
        {
            get { return _legislationGistId ?? string.Empty; }
            set { _legislationGistId = value; }
        }
        private string _gistName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string GistName
        {
            get { return _gistName ?? string.Empty; }
            set { _gistName = value; }
        }
        private string _dutyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DutyName
        {
            get { return _dutyName ?? string.Empty; }
            set { _dutyName = value; }
        }
        private string _stipulateFirst = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string StipulateFirst
        {
            get { return _stipulateFirst ?? string.Empty; }
            set { _stipulateFirst = value; }
        }
        private string _stipulateSecond = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string StipulateSecond
        {
            get { return _stipulateSecond ?? string.Empty; }
            set { _stipulateSecond = value; }
        }
        private string _legislationRuleId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LegislationRuleId
        {
            get { return _legislationRuleId ?? string.Empty; }
            set { _legislationRuleId = value; }
        }
        private string _punishContent = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PunishContent
        {
            get { return _punishContent ?? string.Empty; }
            set { _punishContent = value; }
        }
        private string _punishType = string.Empty;
        /// <summary>
        /// nvarchar 	处罚种类
        /// </summary>
        public string PunishType
        {
            get { return _punishType ?? string.Empty; }
            set { _punishType = value; }
        }
        private string _measurement = string.Empty;
        /// <summary>
        /// nvarchar 	处罚计量单位
        /// </summary>
        public string Measurement
        {
            get { return _measurement ?? string.Empty; }
            set { _measurement = value; }
        }
        private int _punishMax;
        /// <summary>
        /// 
        /// </summary>
        public int PunishMax
        {
            get { return _punishMax; }
            set { _punishMax = value; }
        }
        private int _punishMin;
        /// <summary>
        /// 
        /// </summary>
        public int PunishMin
        {
            get { return _punishMin; }
            set { _punishMin = value; }
        }
        private Double _punishAmount;
        /// <summary>
        /// 
        /// </summary>
        public Double PunishAmount
        {
            get { return _punishAmount; }
            set { _punishAmount = value; }
        }
        private Double _forfeitureAmount;
        /// <summary>
        /// 
        /// </summary>
        public Double ForfeitureAmount
        {
            get { return _forfeitureAmount; }
            set { _forfeitureAmount = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishLegislationEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishLegislationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishLegislationEntity();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_LEGISLATION_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_LEGISLATION_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_LegislationId) || fields.Contains("*"))
                tmp.LegislationId = dr[Parm_INF_PUNISH_LEGISLATION_LegislationId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ItemCode) || fields.Contains("*"))
                tmp.ItemCode = dr[Parm_INF_PUNISH_LEGISLATION_ItemCode].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ItemType) || fields.Contains("*"))
                tmp.ItemType = dr[Parm_INF_PUNISH_LEGISLATION_ItemType].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_INF_PUNISH_LEGISLATION_ItemNo].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ItemAct) || fields.Contains("*"))
                tmp.ItemAct = dr[Parm_INF_PUNISH_LEGISLATION_ItemAct].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ClassNo) || fields.Contains("*"))
                tmp.ClassNo = dr[Parm_INF_PUNISH_LEGISLATION_ClassNo].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ClassNoName) || fields.Contains("*"))
                tmp.ClassNoName = dr[Parm_INF_PUNISH_LEGISLATION_ClassNoName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_LegislationItemId) || fields.Contains("*"))
                tmp.LegislationItemId = dr[Parm_INF_PUNISH_LEGISLATION_LegislationItemId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ItemName) || fields.Contains("*"))
                tmp.ItemName = dr[Parm_INF_PUNISH_LEGISLATION_ItemName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_LegislationGistId) || fields.Contains("*"))
                tmp.LegislationGistId = dr[Parm_INF_PUNISH_LEGISLATION_LegislationGistId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_GistName) || fields.Contains("*"))
                tmp.GistName = dr[Parm_INF_PUNISH_LEGISLATION_GistName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_DutyName) || fields.Contains("*"))
                tmp.DutyName = dr[Parm_INF_PUNISH_LEGISLATION_DutyName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_StipulateFirst) || fields.Contains("*"))
                tmp.StipulateFirst = dr[Parm_INF_PUNISH_LEGISLATION_StipulateFirst].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_StipulateSecond) || fields.Contains("*"))
                tmp.StipulateSecond = dr[Parm_INF_PUNISH_LEGISLATION_StipulateSecond].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_LegislationRuleId) || fields.Contains("*"))
                tmp.LegislationRuleId = dr[Parm_INF_PUNISH_LEGISLATION_LegislationRuleId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_PunishContent) || fields.Contains("*"))
                tmp.PunishContent = dr[Parm_INF_PUNISH_LEGISLATION_PunishContent].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_PunishType) || fields.Contains("*"))
                tmp.PunishType = dr[Parm_INF_PUNISH_LEGISLATION_PunishType].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_Measurement) || fields.Contains("*"))
                tmp.Measurement = dr[Parm_INF_PUNISH_LEGISLATION_Measurement].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_PunishMax) || fields.Contains("*"))
                tmp.PunishMax = int.Parse(dr[Parm_INF_PUNISH_LEGISLATION_PunishMax].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_PunishMin) || fields.Contains("*"))
                tmp.PunishMin = int.Parse(dr[Parm_INF_PUNISH_LEGISLATION_PunishMin].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_PunishAmount) || fields.Contains("*"))
                tmp.PunishAmount = Double.Parse(dr[Parm_INF_PUNISH_LEGISLATION_PunishAmount].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_ForfeitureAmount) || fields.Contains("*"))
                tmp.ForfeitureAmount = Double.Parse(dr[Parm_INF_PUNISH_LEGISLATION_ForfeitureAmount].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_LEGISLATION_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_LEGISLATION_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_LEGISLATION_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_LEGISLATION_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_LEGISLATION_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_LEGISLATION_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_LEGISLATION_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_LEGISLATION_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_LEGISLATION_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_legislation">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishLegislationEntity inf_punish_legislation, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_legislation.CaseInfoId;
            parms[1].Value = inf_punish_legislation.LegislationId;
            parms[2].Value = inf_punish_legislation.ItemCode;
            parms[3].Value = inf_punish_legislation.ItemType;
            parms[4].Value = inf_punish_legislation.ItemNo;
            parms[5].Value = inf_punish_legislation.ItemAct;
            parms[6].Value = inf_punish_legislation.ClassNo;
            parms[7].Value = inf_punish_legislation.ClassNoName;
            parms[8].Value = inf_punish_legislation.LegislationItemId;
            parms[9].Value = inf_punish_legislation.ItemName;
            parms[10].Value = inf_punish_legislation.LegislationGistId;
            parms[11].Value = inf_punish_legislation.GistName;
            parms[12].Value = inf_punish_legislation.DutyName;
            parms[13].Value = inf_punish_legislation.StipulateFirst;
            parms[14].Value = inf_punish_legislation.StipulateSecond;
            parms[15].Value = inf_punish_legislation.LegislationRuleId;
            parms[16].Value = inf_punish_legislation.PunishContent;
            parms[17].Value = inf_punish_legislation.PunishType;
            parms[18].Value = inf_punish_legislation.Measurement;
            parms[19].Value = inf_punish_legislation.PunishMax;
            parms[20].Value = inf_punish_legislation.PunishMin;
            parms[21].Value = inf_punish_legislation.PunishAmount;
            parms[22].Value = inf_punish_legislation.ForfeitureAmount;
            parms[23].Value = inf_punish_legislation.RowStatus;
            parms[24].Value = inf_punish_legislation.CreatorId;
            parms[25].Value = inf_punish_legislation.CreateBy;
            parms[26].Value = inf_punish_legislation.CreateOn;
            parms[27].Value = inf_punish_legislation.UpdateId;
            parms[28].Value = inf_punish_legislation.UpdateBy;
            parms[29].Value = inf_punish_legislation.UpdateOn;
            parms[30].Value = inf_punish_legislation.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishLegislationEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_LEGISLATION_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_LEGISLATION_CaseInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_LegislationId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ItemCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ItemType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ItemNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ItemAct, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ClassNoName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_LegislationItemId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ItemName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_LegislationGistId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_GistName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_DutyName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_StipulateFirst, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_StipulateSecond, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_LegislationRuleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_PunishContent, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_PunishType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_Measurement, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_PunishMax, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_PunishMin, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_PunishAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_ForfeitureAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_LEGISLATION_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_LEGISLATION_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_LEGISLATION_Insert, parms);
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

