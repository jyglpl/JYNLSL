//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DECISIONEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/5 18:21:01
//  功能描述：INF_PUNISH_DECISION表实体
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
    /// 处罚决定书
    /// </summary>
    [Serializable]
    public class InfPunishDecisionEntity : ModelImp.BaseModel<InfPunishDecisionEntity>
    {
        public InfPunishDecisionEntity()
        {
            TB_Name = TB_INF_PUNISH_DECISION;
            Parm_Id = Parm_INF_PUNISH_DECISION_Id;
            Parm_Version = Parm_INF_PUNISH_DECISION_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_DECISION_Insert;
            Sql_Update = Sql_INF_PUNISH_DECISION_Update;
            Sql_Delete = Sql_INF_PUNISH_DECISION_Delete;
        }
        #region Const of table INF_PUNISH_DECISION
        /// <summary>
        /// Table INF_PUNISH_DECISION
        /// </summary>
        public const string TB_INF_PUNISH_DECISION = "INF_PUNISH_DECISION";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseAddr
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CaseAddr = "CaseAddr";
        /// <summary>
        /// Parm CaseDate
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CaseDate = "CaseDate";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DutyClause
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_DutyClause = "DutyClause";
        /// <summary>
        /// Parm DutyItem
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_DutyItem = "DutyItem";
        /// <summary>
        /// Parm DutyName
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_DutyName = "DutyName";
        /// <summary>
        /// Parm DutyStrip
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_DutyStrip = "DutyStrip";
        /// <summary>
        /// Parm FileDate
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_FileDate = "FileDate";
        /// <summary>
        /// Parm FileDateCapital
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_FileDateCapital = "FileDateCapital";
        /// <summary>
        /// Parm FileNumber
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_FileNumber = "FileNumber";
        /// <summary>
        /// Parm GistClause
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_GistClause = "GistClause";
        /// <summary>
        /// Parm GistItem
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_GistItem = "GistItem";
        /// <summary>
        /// Parm GistName
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_GistName = "GistName";
        /// <summary>
        /// Parm GistStrip
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_GistStrip = "GistStrip";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_Id = "Id";
        /// <summary>
        /// Parm InformReceptDate
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_InformReceptDate = "InformReceptDate";
        /// <summary>
        /// Parm IsGiveUp
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_IsGiveUp = "IsGiveUp";
        /// <summary>
        /// Parm ItemAct
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_ItemAct = "ItemAct";
        /// <summary>
        /// Parm ItemName
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_ItemName = "ItemName";
        /// <summary>
        /// Parm OrganIdea
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_OrganIdea = "OrganIdea";
        /// <summary>
        /// Parm PunishAmount
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_PunishAmount = "PunishAmount";
        /// <summary>
        /// Parm PunishContent
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_PunishContent = "PunishContent";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_RowStatus = "RowStatus";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_State = "State";
        /// <summary>
        /// Parm StatementDate
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_StatementDate = "StatementDate";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_TargetName = "TargetName";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_DECISION_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_PUNISH_DECISION
        /// </summary>

        public const string Sql_INF_PUNISH_DECISION_Insert = "insert into INF_PUNISH_DECISION(CaseAddr,CaseDate,CaseInfoId,CreateBy,CreateOn,CreatorId,DutyClause,DutyItem,DutyName,DutyStrip,FileDate,FileDateCapital,FileNumber,GistClause,GistItem,GistName,GistStrip,InformReceptDate,IsGiveUp,ItemAct,ItemName,OrganIdea,PunishAmount,PunishContent,RowStatus,State,StatementDate,TargetAddress,TargetName,UpdateBy,UpdateId,UpdateOn) values(@CaseAddr,@CaseDate,@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@DutyClause,@DutyItem,@DutyName,@DutyStrip,@FileDate,@FileDateCapital,@FileNumber,@GistClause,@GistItem,@GistName,@GistStrip,@InformReceptDate,@IsGiveUp,@ItemAct,@ItemName,@OrganIdea,@PunishAmount,@PunishContent,@RowStatus,@State,@StatementDate,@TargetAddress,@TargetName,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";

        /// <summary>
        /// Update Query Of INF_PUNISH_DECISION
        /// </summary>

        public const string Sql_INF_PUNISH_DECISION_Update = "update INF_PUNISH_DECISION set CaseAddr=@CaseAddr,CaseDate=@CaseDate,CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyClause=@DutyClause,DutyItem=@DutyItem,DutyName=@DutyName,DutyStrip=@DutyStrip,FileDate=@FileDate,FileDateCapital=@FileDateCapital,FileNumber=@FileNumber,GistClause=@GistClause,GistItem=@GistItem,GistName=@GistName,GistStrip=@GistStrip,InformReceptDate=@InformReceptDate,IsGiveUp=@IsGiveUp,ItemAct=@ItemAct,ItemName=@ItemName,OrganIdea=@OrganIdea,PunishAmount=@PunishAmount,PunishContent=@PunishContent,RowStatus=@RowStatus,State=@State,StatementDate=@StatementDate,TargetAddress=@TargetAddress,TargetName=@TargetName,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";

        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_DECISION_Delete = "update INF_PUNISH_DECISION set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoId = string.Empty;
        /// <summary>
        /// nvarchar
        /// </summary>
        public string CaseInfoId
        {
            get { return _caseInfoId ?? string.Empty; }
            set { _caseInfoId = value; }
        }
        private string _fileNumber = string.Empty;
        /// <summary>
        /// nvarchar 	决定书编号
        /// </summary>
        public string FileNumber
        {
            get { return _fileNumber ?? string.Empty; }
            set { _fileNumber = value; }
        }

        private DateTime _fileDate = MinDate;

        /// <summary>
        /// datetime 	决定书日期
        /// </summary>

        public DateTime FileDate
        {
            get { return _fileDate; }
            set { _fileDate = value; }
        }

        private string _fileDateCapital = string.Empty;
        /// <summary>
        /// 大写文书日期
        /// </summary>
        public string FileDateCapital
        {
            get { return _fileDateCapital ?? string.Empty; }
            set { _fileDateCapital = value; }
        }

        private string _targetName = string.Empty;
        /// <summary>
        /// nvarchar 	当事人姓名/负责人姓名
        /// </summary>
        public string TargetName
        {
            get { return _targetName ?? string.Empty; }
            set { _targetName = value; }
        }
        private string _targetAddress = string.Empty;
        /// <summary>
        /// nvarchar 	当事人地址
        /// </summary>
        public string TargetAddress
        {
            get { return _targetAddress ?? string.Empty; }
            set { _targetAddress = value; }
        }
        private DateTime _caseDate = MinDate;
        /// <summary>
        /// datetime 	案发日期
        /// </summary>
        public DateTime CaseDate
        {
            get { return _caseDate; }
            set { _caseDate = value; }
        }
        private string _caseAddr = string.Empty;
        /// <summary>
        /// nvarchar 	案发地点
        /// </summary>
        public string CaseAddr
        {
            get { return _caseAddr ?? string.Empty; }
            set { _caseAddr = value; }
        }
        private string _itemName = string.Empty;
        /// <summary>
        /// nvarchar 	案由名称
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? string.Empty; }
            set { _itemName = value; }
        }
        private string _itemAct = string.Empty;
        /// <summary>
        /// 违法行为
        /// </summary>
        public string ItemAct
        {
            get { return _itemAct ?? string.Empty; }
            set { _itemAct = value; }
        }
        private string _gistName = string.Empty;
        /// <summary>
        /// nvarchar 	管理依据（违法法律）
        /// </summary>
        public string GistName
        {
            get { return _gistName ?? string.Empty; }
            set { _gistName = value; }
        }
        private string _gistStrip = string.Empty;
        /// <summary>
        /// nvarchar 	管理依据->条
        /// </summary>
        public string GistStrip
        {
            get { return _gistStrip ?? string.Empty; }
            set { _gistStrip = value; }
        }
        private string _gistClause = string.Empty;
        /// <summary>
        /// nvarchar 	管理依据->款
        /// </summary>
        public string GistClause
        {
            get { return _gistClause ?? string.Empty; }
            set { _gistClause = value; }
        }
        private string _gistItem = string.Empty;
        /// <summary>
        /// nvarchar 	管理依据->项
        /// </summary>
        public string GistItem
        {
            get { return _gistItem ?? string.Empty; }
            set { _gistItem = value; }
        }
        private string _dutyName = string.Empty;
        /// <summary>
        /// nvarchar 	法律责任（依据法律）
        /// </summary>
        public string DutyName
        {
            get { return _dutyName ?? string.Empty; }
            set { _dutyName = value; }
        }
        private string _dutyStrip = string.Empty;
        /// <summary>
        /// nvarchar 	法律责任->条
        /// </summary>
        public string DutyStrip
        {
            get { return _dutyStrip ?? string.Empty; }
            set { _dutyStrip = value; }
        }
        private string _dutyClause = string.Empty;
        /// <summary>
        /// nvarchar 	法律责任->款
        /// </summary>
        public string DutyClause
        {
            get { return _dutyClause ?? string.Empty; }
            set { _dutyClause = value; }
        }
        private string _dutyItem = string.Empty;
        /// <summary>
        /// nvarchar 	法律责任->项
        /// </summary>
        public string DutyItem
        {
            get { return _dutyItem ?? string.Empty; }
            set { _dutyItem = value; }
        }
        private string _punishAmount = string.Empty;
        /// <summary>
        /// 处罚金额
        /// </summary>
        public string PunishAmount
        {
            get { return _punishAmount ?? string.Empty; }
            set { _punishAmount = value; }
        }
        private string _punishContent = string.Empty;
        /// <summary>
        /// nvarchar 	处罚内容
        /// </summary>
        public string PunishContent
        {
            get { return _punishContent ?? string.Empty; }
            set { _punishContent = value; }
        }
        private int _isGiveUp;
        /// <summary>
        /// int 	是否放弃陈述申辩（听证）0：放弃 1、陈述申辩 2、听证
        /// </summary>
        public int IsGiveUp
        {
            get { return _isGiveUp; }
            set { _isGiveUp = value; }
        }
        private string _statementDate = string.Empty;
        /// <summary>
        /// datetime 	陈述申辩（听证）日期
        /// </summary>
        public string StatementDate
        {
            get { return _statementDate ?? string.Empty; }
            set { _statementDate = value; }
        }
        private string _organIdea = string.Empty;
        /// <summary>
        /// nvarchar 	本机关意见
        /// </summary>
        public string OrganIdea
        {
            get { return _organIdea ?? string.Empty; }
            set { _organIdea = value; }
        }
        private string _informReceptDate = string.Empty;
        /// <summary>
        /// datetime 	告知书签收日期
        /// </summary>
        public string InformReceptDate
        {
            get { return _informReceptDate ?? string.Empty; }
            set { _informReceptDate = value; }
        }
        private int _state;
        /// <summary>
        /// int 	状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishDecisionEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishDecisionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishDecisionEntity();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_DECISION_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_DECISION_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_FileNumber) || fields.Contains("*"))
                tmp.FileNumber = dr[Parm_INF_PUNISH_DECISION_FileNumber].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_FileDate) || fields.Contains("*"))

                tmp.FileDate = DateTime.Parse(dr[Parm_INF_PUNISH_DECISION_FileDate].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_TargetName) || fields.Contains("*"))

                tmp.FileDate = DateTime.Parse(dr[Parm_INF_PUNISH_DECISION_FileDate].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_FileDateCapital) || fields.Contains("*"))
                tmp.FileDateCapital = dr[Parm_INF_PUNISH_DECISION_FileDateCapital].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_TargetName) || fields.Contains("*"))

                tmp.TargetName = dr[Parm_INF_PUNISH_DECISION_TargetName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_TargetAddress) || fields.Contains("*"))
                tmp.TargetAddress = dr[Parm_INF_PUNISH_DECISION_TargetAddress].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CaseDate) || fields.Contains("*"))
                tmp.CaseDate = DateTime.Parse(dr[Parm_INF_PUNISH_DECISION_CaseDate].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CaseAddr) || fields.Contains("*"))
                tmp.CaseAddr = dr[Parm_INF_PUNISH_DECISION_CaseAddr].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_ItemName) || fields.Contains("*"))
                tmp.ItemName = dr[Parm_INF_PUNISH_DECISION_ItemName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_ItemAct) || fields.Contains("*"))
                tmp.ItemAct = dr[Parm_INF_PUNISH_DECISION_ItemAct].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_GistName) || fields.Contains("*"))
                tmp.GistName = dr[Parm_INF_PUNISH_DECISION_GistName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_GistStrip) || fields.Contains("*"))
                tmp.GistStrip = dr[Parm_INF_PUNISH_DECISION_GistStrip].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_GistClause) || fields.Contains("*"))
                tmp.GistClause = dr[Parm_INF_PUNISH_DECISION_GistClause].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_GistItem) || fields.Contains("*"))
                tmp.GistItem = dr[Parm_INF_PUNISH_DECISION_GistItem].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_DutyName) || fields.Contains("*"))
                tmp.DutyName = dr[Parm_INF_PUNISH_DECISION_DutyName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_DutyStrip) || fields.Contains("*"))
                tmp.DutyStrip = dr[Parm_INF_PUNISH_DECISION_DutyStrip].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_DutyClause) || fields.Contains("*"))
                tmp.DutyClause = dr[Parm_INF_PUNISH_DECISION_DutyClause].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_DutyItem) || fields.Contains("*"))
                tmp.DutyItem = dr[Parm_INF_PUNISH_DECISION_DutyItem].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_PunishAmount) || fields.Contains("*"))
                tmp.PunishAmount = dr[Parm_INF_PUNISH_DECISION_PunishAmount].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_PunishContent) || fields.Contains("*"))
                tmp.PunishContent = dr[Parm_INF_PUNISH_DECISION_PunishContent].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_IsGiveUp) || fields.Contains("*"))
                tmp.IsGiveUp = int.Parse(dr[Parm_INF_PUNISH_DECISION_IsGiveUp].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_StatementDate) || fields.Contains("*"))
                tmp.StatementDate = dr[Parm_INF_PUNISH_DECISION_StatementDate].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_OrganIdea) || fields.Contains("*"))
                tmp.OrganIdea = dr[Parm_INF_PUNISH_DECISION_OrganIdea].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_InformReceptDate) || fields.Contains("*"))
                tmp.InformReceptDate = dr[Parm_INF_PUNISH_DECISION_InformReceptDate].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_INF_PUNISH_DECISION_State].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_DECISION_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_DECISION_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_DECISION_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_DECISION_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DECISION_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DECISION_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_DECISION_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_DECISION_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DECISION_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DECISION_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_decision">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishDecisionEntity inf_punish_decision, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_decision.CaseInfoId;
            parms[1].Value = inf_punish_decision.FileNumber;
            parms[2].Value = inf_punish_decision.FileDate;
            parms[3].Value = inf_punish_decision.FileDateCapital;
            parms[4].Value = inf_punish_decision.TargetName;
            parms[5].Value = inf_punish_decision.TargetAddress;
            parms[6].Value = inf_punish_decision.CaseDate;
            parms[7].Value = inf_punish_decision.CaseAddr;
            parms[8].Value = inf_punish_decision.ItemName;
            parms[9].Value = inf_punish_decision.ItemAct;
            parms[10].Value = inf_punish_decision.GistName;
            parms[11].Value = inf_punish_decision.GistStrip;
            parms[12].Value = inf_punish_decision.GistClause;
            parms[13].Value = inf_punish_decision.GistItem;
            parms[14].Value = inf_punish_decision.DutyName;
            parms[15].Value = inf_punish_decision.DutyStrip;
            parms[16].Value = inf_punish_decision.DutyClause;
            parms[17].Value = inf_punish_decision.DutyItem;
            parms[18].Value = inf_punish_decision.PunishAmount;
            parms[19].Value = inf_punish_decision.PunishContent;
            parms[20].Value = inf_punish_decision.IsGiveUp;
            parms[21].Value = inf_punish_decision.StatementDate;
            parms[22].Value = inf_punish_decision.OrganIdea;
            parms[23].Value = inf_punish_decision.InformReceptDate;
            parms[24].Value = inf_punish_decision.State;
            parms[25].Value = inf_punish_decision.RowStatus;
            parms[26].Value = inf_punish_decision.CreatorId;
            parms[27].Value = inf_punish_decision.CreateBy;
            parms[28].Value = inf_punish_decision.CreateOn;
            parms[29].Value = inf_punish_decision.UpdateId;
            parms[30].Value = inf_punish_decision.UpdateBy;
            parms[31].Value = inf_punish_decision.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishDecisionEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_INF_PUNISH_DECISION_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_INF_PUNISH_DECISION_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DECISION_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_DECISION_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_FileNumber, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_FileDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_DECISION_FileDateCapital, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_TargetName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_TargetAddress, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_DECISION_CaseDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_DECISION_CaseAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_DECISION_ItemName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_DECISION_ItemAct, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_DECISION_GistName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_DECISION_GistStrip, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_GistClause, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_GistItem, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_DutyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_DECISION_DutyStrip, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_DutyClause, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_DutyItem, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_DECISION_PunishAmount, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_PUNISH_DECISION_PunishContent, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_DECISION_IsGiveUp, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DECISION_StatementDate, SqlDbType.NVarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_DECISION_OrganIdea, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_DECISION_InformReceptDate, SqlDbType.NVarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_DECISION_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DECISION_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DECISION_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_DECISION_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DECISION_UpdateOn, SqlDbType.DateTime, 23)
                   

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DECISION_Insert, parms);
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

