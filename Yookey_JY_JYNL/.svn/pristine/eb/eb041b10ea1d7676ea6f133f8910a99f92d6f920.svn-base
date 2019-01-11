//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_ITEMEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/3 15:56:30
//  功能描述：INF_PUNISH_ITEM表实体
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
    /// 法律法规
    /// </summary>
    [Serializable]
    public class InfPunishItemEntity : ModelImp.BaseModel<InfPunishItemEntity>
    {
        public InfPunishItemEntity()
        {
            TB_Name = TB_INF_PUNISH_ITEM;
            Parm_Id = Parm_INF_PUNISH_ITEM_Id;
            Parm_Version = Parm_INF_PUNISH_ITEM_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_ITEM_Insert;
            Sql_Update = Sql_INF_PUNISH_ITEM_Update;
            Sql_Delete = Sql_INF_PUNISH_ITEM_Delete;
        }
        #region Const of table INF_PUNISH_ITEM
        /// <summary>
        /// Table INF_PUNISH_ITEM
        /// </summary>
        public const string TB_INF_PUNISH_ITEM = "INF_PUNISH_ITEM";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm ClassNo
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ClassNo = "ClassNo";
        /// <summary>
        /// Parm ClassNoName
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ClassNoName = "ClassNoName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DutyClause
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_DutyClause = "DutyClause";
        /// <summary>
        /// Parm DutyItem
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_DutyItem = "DutyItem";
        /// <summary>
        /// Parm DutyName
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_DutyName = "DutyName";
        /// <summary>
        /// Parm DutyStrip
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_DutyStrip = "DutyStrip";
        /// <summary>
        /// Parm ForfeitureAmount
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ForfeitureAmount = "ForfeitureAmount";
        /// <summary>
        /// Parm GistClause
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_GistClause = "GistClause";
        /// <summary>
        /// Parm GistItem
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_GistItem = "GistItem";
        /// <summary>
        /// Parm GistName
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_GistName = "GistName";
        /// <summary>
        /// Parm GistStrip
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_GistStrip = "GistStrip";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_Id = "Id";
        /// <summary>
        /// Parm ItemAct
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemAct = "ItemAct";
        /// <summary>
        /// Parm ItemCode
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemCode = "ItemCode";
        /// <summary>
        /// Parm ItemId
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemId = "ItemId";
        /// <summary>
        /// Parm ItemName
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemName = "ItemName";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemNo = "ItemNo";
        /// <summary>
        /// Parm ItemType
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_ItemType = "ItemType";
        /// <summary>
        /// Parm LawContent
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_LawContent = "LawContent";
        /// <summary>
        /// Parm Measurement
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_Measurement = "Measurement";
        /// <summary>
        /// Parm PunishAmount
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_PunishAmount = "PunishAmount";
        /// <summary>
        /// Parm PunishContent
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_PunishContent = "PunishContent";
        /// <summary>
        /// Parm PunishMax
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_PunishMax = "PunishMax";
        /// <summary>
        /// Parm PunishMin
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_PunishMin = "PunishMin";
        /// <summary>
        /// Parm PunishType
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_PunishType = "PunishType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_RowStatus = "RowStatus";
        /// <summary>
        /// Parm RuleId
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_RuleId = "RuleId";
        /// <summary>
        /// Parm StipulateFirst
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_StipulateFirst = "StipulateFirst";
        /// <summary>
        /// Parm StipulateSecond
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_StipulateSecond = "StipulateSecond";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_ITEM_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_PUNISH_ITEM
        /// </summary>
        public const string Sql_INF_PUNISH_ITEM_Insert = "insert into INF_PUNISH_ITEM(CaseInfoId,ClassNo,ClassNoName,CreateBy,CreateOn,CreatorId,DutyClause,DutyItem,DutyName,DutyStrip,ForfeitureAmount,GistClause,GistItem,GistName,GistStrip,ItemAct,ItemCode,ItemId,ItemName,ItemNo,ItemType,LawContent,Measurement,PunishAmount,PunishContent,PunishMax,PunishMin,PunishType,RowStatus,RuleId,StipulateFirst,StipulateSecond,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@ClassNo,@ClassNoName,@CreateBy,@CreateOn,@CreatorId,@DutyClause,@DutyItem,@DutyName,@DutyStrip,@ForfeitureAmount,@GistClause,@GistItem,@GistName,@GistStrip,@ItemAct,@ItemCode,@ItemId,@ItemName,@ItemNo,@ItemType,@LawContent,@Measurement,@PunishAmount,@PunishContent,@PunishMax,@PunishMin,@PunishType,@RowStatus,@RuleId,@StipulateFirst,@StipulateSecond,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_PUNISH_ITEM
        /// </summary>
        public const string Sql_INF_PUNISH_ITEM_Update = "update INF_PUNISH_ITEM set CaseInfoId=@CaseInfoId,ClassNo=@ClassNo,ClassNoName=@ClassNoName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyClause=@DutyClause,DutyItem=@DutyItem,DutyName=@DutyName,DutyStrip=@DutyStrip,ForfeitureAmount=@ForfeitureAmount,GistClause=@GistClause,GistItem=@GistItem,GistName=@GistName,GistStrip=@GistStrip,ItemAct=@ItemAct,ItemCode=@ItemCode,ItemId=@ItemId,ItemName=@ItemName,ItemNo=@ItemNo,ItemType=@ItemType,LawContent=@LawContent,Measurement=@Measurement,PunishAmount=@PunishAmount,PunishContent=@PunishContent,PunishMax=@PunishMax,PunishMin=@PunishMin,PunishType=@PunishType,RowStatus=@RowStatus,RuleId=@RuleId,StipulateFirst=@StipulateFirst,StipulateSecond=@StipulateSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_ITEM_Delete = "update INF_PUNISH_ITEM set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _itemId = string.Empty;
        /// <summary>
        /// varchar 	自由裁量主表编号
        /// </summary>
        public string ItemId
        {
            get { return _itemId ?? string.Empty; }
            set { _itemId = value; }
        }
        private string _itemCode = string.Empty;
        /// <summary>
        /// varchar 	权力编码
        /// </summary>
        public string ItemCode
        {
            get { return _itemCode ?? string.Empty; }
            set { _itemCode = value; }
        }
        private string _itemType = string.Empty;
        /// <summary>
        /// nvarchar 	权力类型
        /// </summary>
        public string ItemType
        {
            get { return _itemType ?? string.Empty; }
            set { _itemType = value; }
        }
        private string _itemNo = string.Empty;
        /// <summary>
        /// varchar 	案由编号
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _itemAct = string.Empty;
        /// <summary>
        /// nvarchar 	违法行为
        /// </summary>
        public string ItemAct
        {
            get { return _itemAct ?? string.Empty; }
            set { _itemAct = value; }
        }
        private string _classNo = string.Empty;
        /// <summary>
        /// nvarchar 	所属类型（大类）
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
        private string _itemName = string.Empty;
        /// <summary>
        /// nvarchar 	适用案由
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? string.Empty; }
            set { _itemName = value; }
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
        private string _lawContent = string.Empty;
        /// <summary>
        /// nvarchar 	法律全文
        /// </summary>
        public string LawContent
        {
            get { return _lawContent ?? string.Empty; }
            set { _lawContent = value; }
        }
        private string _stipulateFirst = string.Empty;
        /// <summary>
        /// nvarchar 	处罚规定一
        /// </summary>
        public string StipulateFirst
        {
            get { return _stipulateFirst ?? string.Empty; }
            set { _stipulateFirst = value; }
        }
        private string _stipulateSecond = string.Empty;
        /// <summary>
        /// nvarchar 	处罚规定二
        /// </summary>
        public string StipulateSecond
        {
            get { return _stipulateSecond ?? string.Empty; }
            set { _stipulateSecond = value; }
        }
        private string _ruleId = string.Empty;
        /// <summary>
        /// nvarchar 	自由裁量明细表编号
        /// </summary>
        public string RuleId
        {
            get { return _ruleId ?? string.Empty; }
            set { _ruleId = value; }
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
        /// int 	处罚标准上限
        /// </summary>
        public int PunishMax
        {
            get { return _punishMax; }
            set { _punishMax = value; }
        }
        private int _punishMin;
        /// <summary>
        /// int 	处罚标准下限
        /// </summary>
        public int PunishMin
        {
            get { return _punishMin; }
            set { _punishMin = value; }
        }
        private Double _punishAmount;
        /// <summary>
        /// 	处罚金额
        /// </summary>
        public Double PunishAmount
        {
            get { return _punishAmount; }
            set { _punishAmount = value; }
        }
        private Double _forfeitureAmount;
        /// <summary>
        /// 没收金额
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
        public override InfPunishItemEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishItemEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishItemEntity();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_ITEM_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_ITEM_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemId) || fields.Contains("*"))
                tmp.ItemId = dr[Parm_INF_PUNISH_ITEM_ItemId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemCode) || fields.Contains("*"))
                tmp.ItemCode = dr[Parm_INF_PUNISH_ITEM_ItemCode].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemType) || fields.Contains("*"))
                tmp.ItemType = dr[Parm_INF_PUNISH_ITEM_ItemType].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_INF_PUNISH_ITEM_ItemNo].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemAct) || fields.Contains("*"))
                tmp.ItemAct = dr[Parm_INF_PUNISH_ITEM_ItemAct].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ClassNo) || fields.Contains("*"))
                tmp.ClassNo = dr[Parm_INF_PUNISH_ITEM_ClassNo].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ClassNoName) || fields.Contains("*"))
                tmp.ClassNoName = dr[Parm_INF_PUNISH_ITEM_ClassNoName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ItemName) || fields.Contains("*"))
                tmp.ItemName = dr[Parm_INF_PUNISH_ITEM_ItemName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_GistName) || fields.Contains("*"))
                tmp.GistName = dr[Parm_INF_PUNISH_ITEM_GistName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_GistStrip) || fields.Contains("*"))
                tmp.GistStrip = dr[Parm_INF_PUNISH_ITEM_GistStrip].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_GistClause) || fields.Contains("*"))
                tmp.GistClause = dr[Parm_INF_PUNISH_ITEM_GistClause].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_GistItem) || fields.Contains("*"))
                tmp.GistItem = dr[Parm_INF_PUNISH_ITEM_GistItem].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_DutyName) || fields.Contains("*"))
                tmp.DutyName = dr[Parm_INF_PUNISH_ITEM_DutyName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_DutyStrip) || fields.Contains("*"))
                tmp.DutyStrip = dr[Parm_INF_PUNISH_ITEM_DutyStrip].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_DutyClause) || fields.Contains("*"))
                tmp.DutyClause = dr[Parm_INF_PUNISH_ITEM_DutyClause].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_DutyItem) || fields.Contains("*"))
                tmp.DutyItem = dr[Parm_INF_PUNISH_ITEM_DutyItem].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_LawContent) || fields.Contains("*"))
                tmp.LawContent = dr[Parm_INF_PUNISH_ITEM_LawContent].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_StipulateFirst) || fields.Contains("*"))
                tmp.StipulateFirst = dr[Parm_INF_PUNISH_ITEM_StipulateFirst].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_StipulateSecond) || fields.Contains("*"))
                tmp.StipulateSecond = dr[Parm_INF_PUNISH_ITEM_StipulateSecond].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_RuleId) || fields.Contains("*"))
                tmp.RuleId = dr[Parm_INF_PUNISH_ITEM_RuleId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_PunishContent) || fields.Contains("*"))
                tmp.PunishContent = dr[Parm_INF_PUNISH_ITEM_PunishContent].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_PunishType) || fields.Contains("*"))
                tmp.PunishType = dr[Parm_INF_PUNISH_ITEM_PunishType].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_Measurement) || fields.Contains("*"))
                tmp.Measurement = dr[Parm_INF_PUNISH_ITEM_Measurement].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_PunishMax) || fields.Contains("*"))
                tmp.PunishMax = int.Parse(dr[Parm_INF_PUNISH_ITEM_PunishMax].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_PunishMin) || fields.Contains("*"))
                tmp.PunishMin = int.Parse(dr[Parm_INF_PUNISH_ITEM_PunishMin].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_PunishAmount) || fields.Contains("*"))
                tmp.PunishAmount = Double.Parse(dr[Parm_INF_PUNISH_ITEM_PunishAmount].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_ForfeitureAmount) || fields.Contains("*"))
                tmp.ForfeitureAmount = Double.Parse(dr[Parm_INF_PUNISH_ITEM_ForfeitureAmount].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_ITEM_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_ITEM_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_ITEM_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_ITEM_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_ITEM_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_ITEM_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_ITEM_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_ITEM_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_ITEM_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_ITEM_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_ITEM_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_item">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishItemEntity inf_punish_item, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_item.CaseInfoId;
            parms[1].Value = inf_punish_item.ItemId;
            parms[2].Value = inf_punish_item.ItemCode;
            parms[3].Value = inf_punish_item.ItemType;
            parms[4].Value = inf_punish_item.ItemNo;
            parms[5].Value = inf_punish_item.ItemAct;
            parms[6].Value = inf_punish_item.ClassNo;
            parms[7].Value = inf_punish_item.ClassNoName;
            parms[8].Value = inf_punish_item.ItemName;
            parms[9].Value = inf_punish_item.GistName;
            parms[10].Value = inf_punish_item.GistStrip;
            parms[11].Value = inf_punish_item.GistClause;
            parms[12].Value = inf_punish_item.GistItem;
            parms[13].Value = inf_punish_item.DutyName;
            parms[14].Value = inf_punish_item.DutyStrip;
            parms[15].Value = inf_punish_item.DutyClause;
            parms[16].Value = inf_punish_item.DutyItem;
            parms[17].Value = inf_punish_item.LawContent;
            parms[18].Value = inf_punish_item.StipulateFirst;
            parms[19].Value = inf_punish_item.StipulateSecond;
            parms[20].Value = inf_punish_item.RuleId;
            parms[21].Value = inf_punish_item.PunishContent;
            parms[22].Value = inf_punish_item.PunishType;
            parms[23].Value = inf_punish_item.Measurement;
            parms[24].Value = inf_punish_item.PunishMax;
            parms[25].Value = inf_punish_item.PunishMin;
            parms[26].Value = inf_punish_item.PunishAmount;
            parms[27].Value = inf_punish_item.ForfeitureAmount;
            parms[28].Value = inf_punish_item.RowStatus;
            parms[29].Value = inf_punish_item.CreatorId;
            parms[30].Value = inf_punish_item.CreateBy;
            parms[31].Value = inf_punish_item.CreateOn;
            parms[32].Value = inf_punish_item.UpdateId;
            parms[33].Value = inf_punish_item.UpdateBy;
            parms[34].Value = inf_punish_item.UpdateOn;
            parms[35].Value = inf_punish_item.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishItemEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_ITEM_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_ITEM_CaseInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemAct, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ClassNoName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ItemName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ITEM_GistName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_ITEM_GistStrip, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_GistClause, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_GistItem, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_DutyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_ITEM_DutyStrip, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_DutyClause, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_DutyItem, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_LawContent, SqlDbType.NVarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_ITEM_StipulateFirst, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ITEM_StipulateSecond, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_ITEM_RuleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_PunishContent, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_ITEM_PunishType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_Measurement, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_PunishMax, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_ITEM_PunishMin, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_ITEM_PunishAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_INF_PUNISH_ITEM_ForfeitureAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_INF_PUNISH_ITEM_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_ITEM_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_ITEM_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_ITEM_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_ITEM_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_ITEM_Insert, parms);
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

