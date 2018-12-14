//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationGistEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/6/25 13:00:41
//  功能描述：LegislationGist表实体
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
    /// 法律法规（法律条例）
    /// </summary>
    [Serializable]
    public class LegislationGistEntity : ModelImp.BaseModel<LegislationGistEntity>
    {
       	public LegislationGistEntity()
		{
			TB_Name = TB_LegislationGist;
			Parm_Id = Parm_LegislationGist_Id;
			Parm_Version = Parm_LegislationGist_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_LegislationGist_Insert;
			Sql_Update = Sql_LegislationGist_Update;
			Sql_Delete = Sql_LegislationGist_Delete;
		}
       	#region Const of table LegislationGist
		/// <summary>
		/// Table LegislationGist
		/// </summary>
		public const string TB_LegislationGist = "LegislationGist";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CheckRecords
		/// </summary>
		public const string Parm_LegislationGist_CheckRecords = "CheckRecords";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_LegislationGist_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_LegislationGist_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_LegislationGist_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DutyClause
		/// </summary>
		public const string Parm_LegislationGist_DutyClause = "DutyClause";
		/// <summary>
		/// Parm DutyItem
		/// </summary>
		public const string Parm_LegislationGist_DutyItem = "DutyItem";
		/// <summary>
		/// Parm DutyName
		/// </summary>
		public const string Parm_LegislationGist_DutyName = "DutyName";
		/// <summary>
		/// Parm DutyStrip
		/// </summary>
		public const string Parm_LegislationGist_DutyStrip = "DutyStrip";
		/// <summary>
		/// Parm EndCaseAbstract
		/// </summary>
		public const string Parm_LegislationGist_EndCaseAbstract = "EndCaseAbstract";
		/// <summary>
		/// Parm EndExecute
		/// </summary>
		public const string Parm_LegislationGist_EndExecute = "EndExecute";
		/// <summary>
		/// Parm EndLawsuit
		/// </summary>
		public const string Parm_LegislationGist_EndLawsuit = "EndLawsuit";
		/// <summary>
		/// Parm EndOpinion
		/// </summary>
		public const string Parm_LegislationGist_EndOpinion = "EndOpinion";
		/// <summary>
		/// Parm EndPunishments
		/// </summary>
		public const string Parm_LegislationGist_EndPunishments = "EndPunishments";
		/// <summary>
		/// Parm GistClause
		/// </summary>
		public const string Parm_LegislationGist_GistClause = "GistClause";
		/// <summary>
		/// Parm GistItem
		/// </summary>
		public const string Parm_LegislationGist_GistItem = "GistItem";
		/// <summary>
		/// Parm GistName
		/// </summary>
		public const string Parm_LegislationGist_GistName = "GistName";
		/// <summary>
		/// Parm GistStrip
		/// </summary>
		public const string Parm_LegislationGist_GistStrip = "GistStrip";
		/// <summary>
		/// Parm HaCaseAbstract
		/// </summary>
		public const string Parm_LegislationGist_HaCaseAbstract = "HaCaseAbstract";
		/// <summary>
		/// Parm HaOpinion
		/// </summary>
		public const string Parm_LegislationGist_HaOpinion = "HaOpinion";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_LegislationGist_Id = "Id";
		/// <summary>
		/// Parm IsSync
		/// </summary>
		public const string Parm_LegislationGist_IsSync = "IsSync";
		/// <summary>
		/// Parm ItemNo
		/// </summary>
		public const string Parm_LegislationGist_ItemNo = "ItemNo";
		/// <summary>
		/// Parm LawContent
		/// </summary>
		public const string Parm_LegislationGist_LawContent = "LawContent";
		/// <summary>
		/// Parm LegalProvisions
		/// </summary>
		public const string Parm_LegislationGist_LegalProvisions = "LegalProvisions";
		/// <summary>
		/// Parm LegalProvisionsClause
		/// </summary>
		public const string Parm_LegislationGist_LegalProvisionsClause = "LegalProvisionsClause";
		/// <summary>
		/// Parm LegalProvisionsInfo
		/// </summary>
		public const string Parm_LegislationGist_LegalProvisionsInfo = "LegalProvisionsInfo";
		/// <summary>
		/// Parm LegalProvisionsItem
		/// </summary>
		public const string Parm_LegislationGist_LegalProvisionsItem = "LegalProvisionsItem";
		/// <summary>
		/// Parm LegalProvisionsStrip
		/// </summary>
		public const string Parm_LegislationGist_LegalProvisionsStrip = "LegalProvisionsStrip";
		/// <summary>
		/// Parm LegislationId
		/// </summary>
		public const string Parm_LegislationGist_LegislationId = "LegislationId";
		/// <summary>
		/// Parm LegislationItemId
		/// </summary>
		public const string Parm_LegislationGist_LegislationItemId = "LegislationItemId";
		/// <summary>
		/// Parm Num
		/// </summary>
		public const string Parm_LegislationGist_Num = "Num";
		/// <summary>
		/// Parm OrderNo
		/// </summary>
		public const string Parm_LegislationGist_OrderNo = "OrderNo";
		/// <summary>
		/// Parm PunishmentBasis
		/// </summary>
		public const string Parm_LegislationGist_PunishmentBasis = "PunishmentBasis";
		/// <summary>
		/// Parm PunishmentBasisClause
		/// </summary>
		public const string Parm_LegislationGist_PunishmentBasisClause = "PunishmentBasisClause";
		/// <summary>
		/// Parm PunishmentBasisInfo
		/// </summary>
		public const string Parm_LegislationGist_PunishmentBasisInfo = "PunishmentBasisInfo";
		/// <summary>
		/// Parm PunishmentBasisItem
		/// </summary>
		public const string Parm_LegislationGist_PunishmentBasisItem = "PunishmentBasisItem";
		/// <summary>
		/// Parm PunishmentBasisStrip
		/// </summary>
		public const string Parm_LegislationGist_PunishmentBasisStrip = "PunishmentBasisStrip";
		/// <summary>
		/// Parm PunishMethod
		/// </summary>
		public const string Parm_LegislationGist_PunishMethod = "PunishMethod";
		/// <summary>
		/// Parm ReCaseAbstract
		/// </summary>
		public const string Parm_LegislationGist_ReCaseAbstract = "ReCaseAbstract";
		/// <summary>
		/// Parm Records
		/// </summary>
		public const string Parm_LegislationGist_Records = "Records";
		/// <summary>
		/// Parm ReHarm
		/// </summary>
		public const string Parm_LegislationGist_ReHarm = "ReHarm";
		/// <summary>
		/// Parm ReOpinion
		/// </summary>
		public const string Parm_LegislationGist_ReOpinion = "ReOpinion";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_LegislationGist_RowStatus = "RowStatus";
		/// <summary>
		/// Parm StipulateFirst
		/// </summary>
		public const string Parm_LegislationGist_StipulateFirst = "StipulateFirst";
		/// <summary>
		/// Parm StipulateSecond
		/// </summary>
		public const string Parm_LegislationGist_StipulateSecond = "StipulateSecond";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_LegislationGist_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_LegislationGist_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_LegislationGist_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_LegislationGist_Version = "Version";
		/// <summary>
		/// Insert Query Of LegislationGist
		/// </summary>
		public const string Sql_LegislationGist_Insert = "insert into LegislationGist(CheckRecords,CreateBy,CreateOn,CreatorId,DutyClause,DutyItem,DutyName,DutyStrip,EndCaseAbstract,EndExecute,EndLawsuit,EndOpinion,EndPunishments,GistClause,GistItem,GistName,GistStrip,HaCaseAbstract,HaOpinion,IsSync,ItemNo,LawContent,LegalProvisions,LegalProvisionsClause,LegalProvisionsInfo,LegalProvisionsItem,LegalProvisionsStrip,LegislationId,LegislationItemId,Num,OrderNo,PunishmentBasis,PunishmentBasisClause,PunishmentBasisInfo,PunishmentBasisItem,PunishmentBasisStrip,PunishMethod,ReCaseAbstract,Records,ReHarm,ReOpinion,RowStatus,StipulateFirst,StipulateSecond,UpdateBy,UpdateId,UpdateOn) values(@CheckRecords,@CreateBy,@CreateOn,@CreatorId,@DutyClause,@DutyItem,@DutyName,@DutyStrip,@EndCaseAbstract,@EndExecute,@EndLawsuit,@EndOpinion,@EndPunishments,@GistClause,@GistItem,@GistName,@GistStrip,@HaCaseAbstract,@HaOpinion,@IsSync,@ItemNo,@LawContent,@LegalProvisions,@LegalProvisionsClause,@LegalProvisionsInfo,@LegalProvisionsItem,@LegalProvisionsStrip,@LegislationId,@LegislationItemId,@Num,@OrderNo,@PunishmentBasis,@PunishmentBasisClause,@PunishmentBasisInfo,@PunishmentBasisItem,@PunishmentBasisStrip,@PunishMethod,@ReCaseAbstract,@Records,@ReHarm,@ReOpinion,@RowStatus,@StipulateFirst,@StipulateSecond,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of LegislationGist
		/// </summary>
		public const string Sql_LegislationGist_Update = "update LegislationGist set CheckRecords=@CheckRecords,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyClause=@DutyClause,DutyItem=@DutyItem,DutyName=@DutyName,DutyStrip=@DutyStrip,EndCaseAbstract=@EndCaseAbstract,EndExecute=@EndExecute,EndLawsuit=@EndLawsuit,EndOpinion=@EndOpinion,EndPunishments=@EndPunishments,GistClause=@GistClause,GistItem=@GistItem,GistName=@GistName,GistStrip=@GistStrip,HaCaseAbstract=@HaCaseAbstract,HaOpinion=@HaOpinion,IsSync=@IsSync,ItemNo=@ItemNo,LawContent=@LawContent,LegalProvisions=@LegalProvisions,LegalProvisionsClause=@LegalProvisionsClause,LegalProvisionsInfo=@LegalProvisionsInfo,LegalProvisionsItem=@LegalProvisionsItem,LegalProvisionsStrip=@LegalProvisionsStrip,LegislationId=@LegislationId,LegislationItemId=@LegislationItemId,Num=@Num,OrderNo=@OrderNo,PunishmentBasis=@PunishmentBasis,PunishmentBasisClause=@PunishmentBasisClause,PunishmentBasisInfo=@PunishmentBasisInfo,PunishmentBasisItem=@PunishmentBasisItem,PunishmentBasisStrip=@PunishmentBasisStrip,PunishMethod=@PunishMethod,ReCaseAbstract=@ReCaseAbstract,Records=@Records,ReHarm=@ReHarm,ReOpinion=@ReOpinion,RowStatus=@RowStatus,StipulateFirst=@StipulateFirst,StipulateSecond=@StipulateSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_LegislationGist_Delete = "update LegislationGist set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _legislationItemId = string.Empty;
		/// <summary>
		/// 对应ItemId
		/// </summary>
		public string LegislationItemId
		{
			get{return _legislationItemId ?? string.Empty;}
			set{_legislationItemId = value;}
		}
		private string _num = string.Empty;
		/// <summary>
		/// 序号
		/// </summary>
		public string Num
		{
			get{return _num ?? string.Empty;}
			set{_num = value;}
		}
		private string _itemNo = string.Empty;
		/// <summary>
		/// 案由编号
		/// </summary>
		public string ItemNo
		{
			get{return _itemNo ?? string.Empty;}
			set{_itemNo = value;}
		}
		private string _gistName = string.Empty;
		/// <summary>
		/// nvarchar 管理依据（违法法律）
		/// </summary>
		public string GistName
		{
			get{return _gistName ?? string.Empty;}
			set{_gistName = value;}
		}
		private string _gistStrip = string.Empty;
		/// <summary>
		/// nvarchar 管理依据->条
		/// </summary>
		public string GistStrip
		{
			get{return _gistStrip ?? string.Empty;}
			set{_gistStrip = value;}
		}
		private string _gistClause = string.Empty;
		/// <summary>
		/// nvarchar 管理依据->款
		/// </summary>
		public string GistClause
		{
			get{return _gistClause ?? string.Empty;}
			set{_gistClause = value;}
		}
		private string _gistItem = string.Empty;
		/// <summary>
		/// nvarchar 管理依据->项
		/// </summary>
		public string GistItem
		{
			get{return _gistItem ?? string.Empty;}
			set{_gistItem = value;}
		}
		private string _dutyName = string.Empty;
		/// <summary>
		/// nvarchar 法律责任（依据法律）
		/// </summary>
		public string DutyName
		{
			get{return _dutyName ?? string.Empty;}
			set{_dutyName = value;}
		}
		private string _dutyStrip = string.Empty;
		/// <summary>
		/// nvarchar 法律责任->条
		/// </summary>
		public string DutyStrip
		{
			get{return _dutyStrip ?? string.Empty;}
			set{_dutyStrip = value;}
		}
		private string _dutyClause = string.Empty;
		/// <summary>
		/// nvarchar 法律责任->款
		/// </summary>
		public string DutyClause
		{
			get{return _dutyClause ?? string.Empty;}
			set{_dutyClause = value;}
		}
		private string _dutyItem = string.Empty;
		/// <summary>
		/// nvarchar 法律责任->项
		/// </summary>
		public string DutyItem
		{
			get{return _dutyItem ?? string.Empty;}
			set{_dutyItem = value;}
		}
		private string _lawContent = string.Empty;
		/// <summary>
		/// nvarchar 法律全文
		/// </summary>
		public string LawContent
		{
			get{return _lawContent ?? string.Empty;}
			set{_lawContent = value;}
		}
		private string _stipulateFirst = string.Empty;
		/// <summary>
		/// nvarchar 处罚规定一
		/// </summary>
		public string StipulateFirst
		{
			get{return _stipulateFirst ?? string.Empty;}
			set{_stipulateFirst = value;}
		}
		private string _stipulateSecond = string.Empty;
		/// <summary>
		/// nvarchar 处罚规定二
		/// </summary>
		public string StipulateSecond
		{
			get{return _stipulateSecond ?? string.Empty;}
			set{_stipulateSecond = value;}
		}
		private string _reCaseAbstract = string.Empty;
		/// <summary>
		/// 立案案情摘要
		/// </summary>
		public string ReCaseAbstract
		{
			get{return _reCaseAbstract ?? string.Empty;}
			set{_reCaseAbstract = value;}
		}
		private string _reOpinion = string.Empty;
		/// <summary>
		/// 立案审批承办人意见
		/// </summary>
		public string ReOpinion
		{
			get{return _reOpinion ?? string.Empty;}
			set{_reOpinion = value;}
		}
		private string _reHarm = string.Empty;
		/// <summary>
		/// 立案审批危害或损失情况
		/// </summary>
		public string ReHarm
		{
			get{return _reHarm ?? string.Empty;}
			set{_reHarm = value;}
		}
		private string _haCaseAbstract = string.Empty;
		/// <summary>
		/// 处理审批案情摘要
		/// </summary>
		public string HaCaseAbstract
		{
			get{return _haCaseAbstract ?? string.Empty;}
			set{_haCaseAbstract = value;}
		}
		private string _haOpinion = string.Empty;
		/// <summary>
		/// 处理审批承办人意见
		/// </summary>
		public string HaOpinion
		{
			get{return _haOpinion ?? string.Empty;}
			set{_haOpinion = value;}
		}
		private string _endCaseAbstract = string.Empty;
		/// <summary>
		/// 结案审批案情摘要及调查经过
		/// </summary>
		public string EndCaseAbstract
		{
			get{return _endCaseAbstract ?? string.Empty;}
			set{_endCaseAbstract = value;}
		}
		private string _endPunishments = string.Empty;
		/// <summary>
		/// 结案审批处理或处罚情况
		/// </summary>
		public string EndPunishments
		{
			get{return _endPunishments ?? string.Empty;}
			set{_endPunishments = value;}
		}
		private string _endExecute = string.Empty;
		/// <summary>
		/// 结案审批执行情况
		/// </summary>
		public string EndExecute
		{
			get{return _endExecute ?? string.Empty;}
			set{_endExecute = value;}
		}
		private string _endLawsuit = string.Empty;
		/// <summary>
		/// 结案审批复议和诉讼情况
		/// </summary>
		public string EndLawsuit
		{
			get{return _endLawsuit ?? string.Empty;}
			set{_endLawsuit = value;}
		}
		private string _endOpinion = string.Empty;
		/// <summary>
		/// 结案审批承办人意见
		/// </summary>
		public string EndOpinion
		{
			get{return _endOpinion ?? string.Empty;}
			set{_endOpinion = value;}
		}
		private string _punishMethod = string.Empty;
		/// <summary>
		/// 处罚方法
		/// </summary>
		public string PunishMethod
		{
			get{return _punishMethod ?? string.Empty;}
			set{_punishMethod = value;}
		}
		private string _checkRecords = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CheckRecords
		{
			get{return _checkRecords ?? string.Empty;}
			set{_checkRecords = value;}
		}
		private string _records = string.Empty;
		/// <summary>
		/// 笔录情况
		/// </summary>
		public string Records
		{
			get{return _records ?? string.Empty;}
			set{_records = value;}
		}
		private int _orderNo;
		/// <summary>
		/// 排序编号
		/// </summary>
		public int OrderNo
		{
			get{return _orderNo;}
			set{_orderNo = value;}
		}
		private string _legislationId = string.Empty;
		/// <summary>
		/// 对应Legislation主键
		/// </summary>
		public string LegislationId
		{
			get{return _legislationId ?? string.Empty;}
			set{_legislationId = value;}
		}
		private string _legalProvisions = string.Empty;
		/// <summary>
		/// 法律规定
		/// </summary>
		public string LegalProvisions
		{
			get{return _legalProvisions ?? string.Empty;}
			set{_legalProvisions = value;}
		}
		private string _legalProvisionsInfo = string.Empty;
		/// <summary>
		/// 法律规定详情
		/// </summary>
		public string LegalProvisionsInfo
		{
			get{return _legalProvisionsInfo ?? string.Empty;}
			set{_legalProvisionsInfo = value;}
		}
		private string _legalProvisionsStrip = string.Empty;
		/// <summary>
		/// 法律规定->条
		/// </summary>
		public string LegalProvisionsStrip
		{
			get{return _legalProvisionsStrip ?? string.Empty;}
			set{_legalProvisionsStrip = value;}
		}
		private string _legalProvisionsClause = string.Empty;
		/// <summary>
		/// 法律规定->款
		/// </summary>
		public string LegalProvisionsClause
		{
			get{return _legalProvisionsClause ?? string.Empty;}
			set{_legalProvisionsClause = value;}
		}
		private string _legalProvisionsItem = string.Empty;
		/// <summary>
		/// 法律规定->项
		/// </summary>
		public string LegalProvisionsItem
		{
			get{return _legalProvisionsItem ?? string.Empty;}
			set{_legalProvisionsItem = value;}
		}
		private string _punishmentBasis = string.Empty;
		/// <summary>
		/// 处罚依据
		/// </summary>
		public string PunishmentBasis
		{
			get{return _punishmentBasis ?? string.Empty;}
			set{_punishmentBasis = value;}
		}
		private string _punishmentBasisInfo = string.Empty;
		/// <summary>
		/// 处罚依据详情
		/// </summary>
		public string PunishmentBasisInfo
		{
			get{return _punishmentBasisInfo ?? string.Empty;}
			set{_punishmentBasisInfo = value;}
		}
		private string _punishmentBasisStrip = string.Empty;
		/// <summary>
		/// 处罚依据->条
		/// </summary>
		public string PunishmentBasisStrip
		{
			get{return _punishmentBasisStrip ?? string.Empty;}
			set{_punishmentBasisStrip = value;}
		}
		private string _punishmentBasisClause = string.Empty;
		/// <summary>
		/// 处罚依据->款
		/// </summary>
		public string PunishmentBasisClause
		{
			get{return _punishmentBasisClause ?? string.Empty;}
			set{_punishmentBasisClause = value;}
		}
		private string _punishmentBasisItem = string.Empty;
		/// <summary>
		/// 处罚依据->项
		/// </summary>
		public string PunishmentBasisItem
		{
			get{return _punishmentBasisItem ?? string.Empty;}
			set{_punishmentBasisItem = value;}
		}
		private string _isSync = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string IsSync
		{
			get{return _isSync ?? string.Empty;}
			set{_isSync = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override LegislationGistEntity SetModelValueByDataRow(DataRow dr)
      	{
            IList<string> fields = new List<string> {"*"};
   	    	return SetModelValueByDataRow(dr,fields);
        }

		/// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
		public override LegislationGistEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LegislationGistEntity();
          			if (fields.Contains(Parm_LegislationGist_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_LegislationGist_Id].ToString();
			if (fields.Contains(Parm_LegislationGist_LegislationItemId) || fields.Contains("*"))
				tmp.LegislationItemId = dr[Parm_LegislationGist_LegislationItemId].ToString();
			if (fields.Contains(Parm_LegislationGist_Num) || fields.Contains("*"))
				tmp.Num = dr[Parm_LegislationGist_Num].ToString();
			if (fields.Contains(Parm_LegislationGist_ItemNo) || fields.Contains("*"))
				tmp.ItemNo = dr[Parm_LegislationGist_ItemNo].ToString();
			if (fields.Contains(Parm_LegislationGist_GistName) || fields.Contains("*"))
				tmp.GistName = dr[Parm_LegislationGist_GistName].ToString();
			if (fields.Contains(Parm_LegislationGist_GistStrip) || fields.Contains("*"))
				tmp.GistStrip = dr[Parm_LegislationGist_GistStrip].ToString();
			if (fields.Contains(Parm_LegislationGist_GistClause) || fields.Contains("*"))
				tmp.GistClause = dr[Parm_LegislationGist_GistClause].ToString();
			if (fields.Contains(Parm_LegislationGist_GistItem) || fields.Contains("*"))
				tmp.GistItem = dr[Parm_LegislationGist_GistItem].ToString();
			if (fields.Contains(Parm_LegislationGist_DutyName) || fields.Contains("*"))
				tmp.DutyName = dr[Parm_LegislationGist_DutyName].ToString();
			if (fields.Contains(Parm_LegislationGist_DutyStrip) || fields.Contains("*"))
				tmp.DutyStrip = dr[Parm_LegislationGist_DutyStrip].ToString();
			if (fields.Contains(Parm_LegislationGist_DutyClause) || fields.Contains("*"))
				tmp.DutyClause = dr[Parm_LegislationGist_DutyClause].ToString();
			if (fields.Contains(Parm_LegislationGist_DutyItem) || fields.Contains("*"))
				tmp.DutyItem = dr[Parm_LegislationGist_DutyItem].ToString();
			if (fields.Contains(Parm_LegislationGist_LawContent) || fields.Contains("*"))
				tmp.LawContent = dr[Parm_LegislationGist_LawContent].ToString();
			if (fields.Contains(Parm_LegislationGist_StipulateFirst) || fields.Contains("*"))
				tmp.StipulateFirst = dr[Parm_LegislationGist_StipulateFirst].ToString();
			if (fields.Contains(Parm_LegislationGist_StipulateSecond) || fields.Contains("*"))
				tmp.StipulateSecond = dr[Parm_LegislationGist_StipulateSecond].ToString();
			if (fields.Contains(Parm_LegislationGist_ReCaseAbstract) || fields.Contains("*"))
				tmp.ReCaseAbstract = dr[Parm_LegislationGist_ReCaseAbstract].ToString();
			if (fields.Contains(Parm_LegislationGist_ReOpinion) || fields.Contains("*"))
				tmp.ReOpinion = dr[Parm_LegislationGist_ReOpinion].ToString();
			if (fields.Contains(Parm_LegislationGist_ReHarm) || fields.Contains("*"))
				tmp.ReHarm = dr[Parm_LegislationGist_ReHarm].ToString();
			if (fields.Contains(Parm_LegislationGist_HaCaseAbstract) || fields.Contains("*"))
				tmp.HaCaseAbstract = dr[Parm_LegislationGist_HaCaseAbstract].ToString();
			if (fields.Contains(Parm_LegislationGist_HaOpinion) || fields.Contains("*"))
				tmp.HaOpinion = dr[Parm_LegislationGist_HaOpinion].ToString();
			if (fields.Contains(Parm_LegislationGist_EndCaseAbstract) || fields.Contains("*"))
				tmp.EndCaseAbstract = dr[Parm_LegislationGist_EndCaseAbstract].ToString();
			if (fields.Contains(Parm_LegislationGist_EndPunishments) || fields.Contains("*"))
				tmp.EndPunishments = dr[Parm_LegislationGist_EndPunishments].ToString();
			if (fields.Contains(Parm_LegislationGist_EndExecute) || fields.Contains("*"))
				tmp.EndExecute = dr[Parm_LegislationGist_EndExecute].ToString();
			if (fields.Contains(Parm_LegislationGist_EndLawsuit) || fields.Contains("*"))
				tmp.EndLawsuit = dr[Parm_LegislationGist_EndLawsuit].ToString();
			if (fields.Contains(Parm_LegislationGist_EndOpinion) || fields.Contains("*"))
				tmp.EndOpinion = dr[Parm_LegislationGist_EndOpinion].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishMethod) || fields.Contains("*"))
				tmp.PunishMethod = dr[Parm_LegislationGist_PunishMethod].ToString();
			if (fields.Contains(Parm_LegislationGist_CheckRecords) || fields.Contains("*"))
				tmp.CheckRecords = dr[Parm_LegislationGist_CheckRecords].ToString();
			if (fields.Contains(Parm_LegislationGist_Records) || fields.Contains("*"))
				tmp.Records = dr[Parm_LegislationGist_Records].ToString();
			if (fields.Contains(Parm_LegislationGist_OrderNo) || fields.Contains("*"))
				tmp.OrderNo = int.Parse(dr[Parm_LegislationGist_OrderNo].ToString());
			if (fields.Contains(Parm_LegislationGist_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_LegislationGist_RowStatus].ToString());
			if (fields.Contains(Parm_LegislationGist_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_LegislationGist_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_LegislationGist_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_LegislationGist_CreatorId].ToString();
			if (fields.Contains(Parm_LegislationGist_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_LegislationGist_CreateBy].ToString();
			if (fields.Contains(Parm_LegislationGist_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_LegislationGist_CreateOn].ToString());
			if (fields.Contains(Parm_LegislationGist_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_LegislationGist_UpdateId].ToString();
			if (fields.Contains(Parm_LegislationGist_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_LegislationGist_UpdateBy].ToString();
			if (fields.Contains(Parm_LegislationGist_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_LegislationGist_UpdateOn].ToString());
			if (fields.Contains(Parm_LegislationGist_LegislationId) || fields.Contains("*"))
				tmp.LegislationId = dr[Parm_LegislationGist_LegislationId].ToString();
			if (fields.Contains(Parm_LegislationGist_LegalProvisions) || fields.Contains("*"))
				tmp.LegalProvisions = dr[Parm_LegislationGist_LegalProvisions].ToString();
			if (fields.Contains(Parm_LegislationGist_LegalProvisionsInfo) || fields.Contains("*"))
				tmp.LegalProvisionsInfo = dr[Parm_LegislationGist_LegalProvisionsInfo].ToString();
			if (fields.Contains(Parm_LegislationGist_LegalProvisionsStrip) || fields.Contains("*"))
				tmp.LegalProvisionsStrip = dr[Parm_LegislationGist_LegalProvisionsStrip].ToString();
			if (fields.Contains(Parm_LegislationGist_LegalProvisionsClause) || fields.Contains("*"))
				tmp.LegalProvisionsClause = dr[Parm_LegislationGist_LegalProvisionsClause].ToString();
			if (fields.Contains(Parm_LegislationGist_LegalProvisionsItem) || fields.Contains("*"))
				tmp.LegalProvisionsItem = dr[Parm_LegislationGist_LegalProvisionsItem].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishmentBasis) || fields.Contains("*"))
				tmp.PunishmentBasis = dr[Parm_LegislationGist_PunishmentBasis].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishmentBasisInfo) || fields.Contains("*"))
				tmp.PunishmentBasisInfo = dr[Parm_LegislationGist_PunishmentBasisInfo].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishmentBasisStrip) || fields.Contains("*"))
				tmp.PunishmentBasisStrip = dr[Parm_LegislationGist_PunishmentBasisStrip].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishmentBasisClause) || fields.Contains("*"))
				tmp.PunishmentBasisClause = dr[Parm_LegislationGist_PunishmentBasisClause].ToString();
			if (fields.Contains(Parm_LegislationGist_PunishmentBasisItem) || fields.Contains("*"))
				tmp.PunishmentBasisItem = dr[Parm_LegislationGist_PunishmentBasisItem].ToString();
			if (fields.Contains(Parm_LegislationGist_IsSync) || fields.Contains("*"))
				tmp.IsSync = dr[Parm_LegislationGist_IsSync].ToString();

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="legislationgist">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(LegislationGistEntity legislationgist, SqlParameter[] parms)
		{
            				parms[0].Value = legislationgist.LegislationItemId;
				parms[1].Value = legislationgist.Num;
				parms[2].Value = legislationgist.ItemNo;
				parms[3].Value = legislationgist.GistName;
				parms[4].Value = legislationgist.GistStrip;
				parms[5].Value = legislationgist.GistClause;
				parms[6].Value = legislationgist.GistItem;
				parms[7].Value = legislationgist.DutyName;
				parms[8].Value = legislationgist.DutyStrip;
				parms[9].Value = legislationgist.DutyClause;
				parms[10].Value = legislationgist.DutyItem;
				parms[11].Value = legislationgist.LawContent;
				parms[12].Value = legislationgist.StipulateFirst;
				parms[13].Value = legislationgist.StipulateSecond;
				parms[14].Value = legislationgist.ReCaseAbstract;
				parms[15].Value = legislationgist.ReOpinion;
				parms[16].Value = legislationgist.ReHarm;
				parms[17].Value = legislationgist.HaCaseAbstract;
				parms[18].Value = legislationgist.HaOpinion;
				parms[19].Value = legislationgist.EndCaseAbstract;
				parms[20].Value = legislationgist.EndPunishments;
				parms[21].Value = legislationgist.EndExecute;
				parms[22].Value = legislationgist.EndLawsuit;
				parms[23].Value = legislationgist.EndOpinion;
				parms[24].Value = legislationgist.PunishMethod;
				parms[25].Value = legislationgist.CheckRecords;
				parms[26].Value = legislationgist.Records;
				parms[27].Value = legislationgist.OrderNo;
				parms[28].Value = legislationgist.RowStatus;
				parms[29].Value = legislationgist.CreatorId;
				parms[30].Value = legislationgist.CreateBy;
				parms[31].Value = legislationgist.CreateOn;
				parms[32].Value = legislationgist.UpdateId;
				parms[33].Value = legislationgist.UpdateBy;
				parms[34].Value = legislationgist.UpdateOn;
				parms[35].Value = legislationgist.LegislationId;
				parms[36].Value = legislationgist.LegalProvisions;
				parms[37].Value = legislationgist.LegalProvisionsInfo;
				parms[38].Value = legislationgist.LegalProvisionsStrip;
				parms[39].Value = legislationgist.LegalProvisionsClause;
				parms[40].Value = legislationgist.LegalProvisionsItem;
				parms[41].Value = legislationgist.PunishmentBasis;
				parms[42].Value = legislationgist.PunishmentBasisInfo;
				parms[43].Value = legislationgist.PunishmentBasisStrip;
				parms[44].Value = legislationgist.PunishmentBasisClause;
				parms[45].Value = legislationgist.PunishmentBasisItem;
				parms[46].Value = legislationgist.IsSync;
                parms[47].Value = legislationgist.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(LegislationGistEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationGist_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_LegislationGist_LegislationItemId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationGist_Num, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_ItemNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_GistName, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_GistStrip, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_GistClause, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_GistItem, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_DutyName, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_DutyStrip, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_DutyClause, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_DutyItem, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_LawContent, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_LegislationGist_StipulateFirst, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_LegislationGist_StipulateSecond, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_LegislationGist_ReCaseAbstract, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_LegislationGist_ReOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_ReHarm, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_HaCaseAbstract, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_HaOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_EndCaseAbstract, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_EndPunishments, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_EndExecute, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_EndLawsuit, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_EndOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_PunishMethod, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_CheckRecords, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_LegislationGist_Records, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_LegislationGist_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationGist_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationGist_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationGist_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationGist_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LegislationGist_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationGist_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationGist_UpdateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LegislationGist_LegislationId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_LegislationGist_LegalProvisions, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_LegalProvisionsInfo, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_LegislationGist_LegalProvisionsStrip, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_LegalProvisionsClause, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_LegalProvisionsItem, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_PunishmentBasis, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationGist_PunishmentBasisInfo, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_LegislationGist_PunishmentBasisStrip, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_PunishmentBasisClause, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_PunishmentBasisItem, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationGist_IsSync, SqlDbType.VarChar, 10),
                    new SqlParameter(Parm_LegislationGist_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationGist_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
