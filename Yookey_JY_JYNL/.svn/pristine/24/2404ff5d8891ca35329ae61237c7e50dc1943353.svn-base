//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfo_LegislationEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/10 14:04:46
//  功能描述：TempDetainInfo_Legislation表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TempDetain
{
    /// <summary>
    /// 暂扣对应法律法规
    /// </summary>
    [Serializable]
    public class TempDetainInfoLegislationEntity : ModelImp.BaseModel<TempDetainInfoLegislationEntity>
    {
       	public TempDetainInfoLegislationEntity()
		{
			TB_Name = TB_TempDetainInfo_Legislation;
			Parm_Id = Parm_TempDetainInfo_Legislation_Id;
			Parm_Version = Parm_TempDetainInfo_Legislation_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_TempDetainInfo_Legislation_Insert;
			Sql_Update = Sql_TempDetainInfo_Legislation_Update;
			Sql_Delete = Sql_TempDetainInfo_Legislation_Delete;
		}
       	#region Const of table TempDetainInfo_Legislation
		/// <summary>
		/// Table TempDetainInfo_Legislation
		/// </summary>
		public const string TB_TempDetainInfo_Legislation = "TempDetainInfo_Legislation";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm ClassNo
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ClassNo = "ClassNo";
		/// <summary>
		/// Parm ClassNoName
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ClassNoName = "ClassNoName";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DutyName
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_DutyName = "DutyName";
		/// <summary>
		/// Parm ForfeitureAmount
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ForfeitureAmount = "ForfeitureAmount";
		/// <summary>
		/// Parm GistName
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_GistName = "GistName";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_Id = "Id";
		/// <summary>
		/// Parm ItemAct
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ItemAct = "ItemAct";
		/// <summary>
		/// Parm ItemCode
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ItemCode = "ItemCode";
		/// <summary>
		/// Parm ItemName
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ItemName = "ItemName";
		/// <summary>
		/// Parm ItemNo
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ItemNo = "ItemNo";
		/// <summary>
		/// Parm ItemType
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_ItemType = "ItemType";
		/// <summary>
		/// Parm LegislationGistId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_LegislationGistId = "LegislationGistId";
		/// <summary>
		/// Parm LegislationId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_LegislationId = "LegislationId";
		/// <summary>
		/// Parm LegislationItemId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_LegislationItemId = "LegislationItemId";
		/// <summary>
		/// Parm LegislationRuleId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_LegislationRuleId = "LegislationRuleId";
		/// <summary>
		/// Parm Measurement
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_Measurement = "Measurement";
		/// <summary>
		/// Parm PunishAmount
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_PunishAmount = "PunishAmount";
		/// <summary>
		/// Parm PunishContent
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_PunishContent = "PunishContent";
		/// <summary>
		/// Parm PunishMax
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_PunishMax = "PunishMax";
		/// <summary>
		/// Parm PunishMin
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_PunishMin = "PunishMin";
		/// <summary>
		/// Parm PunishType
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_PunishType = "PunishType";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_RowStatus = "RowStatus";
		/// <summary>
		/// Parm StipulateFirst
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_StipulateFirst = "StipulateFirst";
		/// <summary>
		/// Parm StipulateSecond
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_StipulateSecond = "StipulateSecond";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_TempDetainInfo_Legislation_Version = "Version";
		/// <summary>
		/// Insert Query Of TempDetainInfo_Legislation
		/// </summary>
		public const string Sql_TempDetainInfo_Legislation_Insert = "insert into TempDetainInfo_Legislation(CaseInfoId,ClassNo,ClassNoName,CreateBy,CreateOn,CreatorId,DutyName,ForfeitureAmount,GistName,ItemAct,ItemCode,ItemName,ItemNo,ItemType,LegislationGistId,LegislationId,LegislationItemId,LegislationRuleId,Measurement,PunishAmount,PunishContent,PunishMax,PunishMin,PunishType,RowStatus,StipulateFirst,StipulateSecond,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@ClassNo,@ClassNoName,@CreateBy,@CreateOn,@CreatorId,@DutyName,@ForfeitureAmount,@GistName,@ItemAct,@ItemCode,@ItemName,@ItemNo,@ItemType,@LegislationGistId,@LegislationId,@LegislationItemId,@LegislationRuleId,@Measurement,@PunishAmount,@PunishContent,@PunishMax,@PunishMin,@PunishType,@RowStatus,@StipulateFirst,@StipulateSecond,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of TempDetainInfo_Legislation
		/// </summary>
		public const string Sql_TempDetainInfo_Legislation_Update = "update TempDetainInfo_Legislation set CaseInfoId=@CaseInfoId,ClassNo=@ClassNo,ClassNoName=@ClassNoName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyName=@DutyName,ForfeitureAmount=@ForfeitureAmount,GistName=@GistName,ItemAct=@ItemAct,ItemCode=@ItemCode,ItemName=@ItemName,ItemNo=@ItemNo,ItemType=@ItemType,LegislationGistId=@LegislationGistId,LegislationId=@LegislationId,LegislationItemId=@LegislationItemId,LegislationRuleId=@LegislationRuleId,Measurement=@Measurement,PunishAmount=@PunishAmount,PunishContent=@PunishContent,PunishMax=@PunishMax,PunishMin=@PunishMin,PunishType=@PunishType,RowStatus=@RowStatus,StipulateFirst=@StipulateFirst,StipulateSecond=@StipulateSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_TempDetainInfo_Legislation_Delete = "update TempDetainInfo_Legislation set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _caseInfoId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CaseInfoId
		{
			get{return _caseInfoId ?? string.Empty;}
			set{_caseInfoId = value;}
		}
		private string _legislationId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LegislationId
		{
			get{return _legislationId ?? string.Empty;}
			set{_legislationId = value;}
		}
		private string _itemCode = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ItemCode
		{
			get{return _itemCode ?? string.Empty;}
			set{_itemCode = value;}
		}
		private string _itemType = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ItemType
		{
			get{return _itemType ?? string.Empty;}
			set{_itemType = value;}
		}
		private string _itemNo = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ItemNo
		{
			get{return _itemNo ?? string.Empty;}
			set{_itemNo = value;}
		}
		private string _itemAct = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ItemAct
		{
			get{return _itemAct ?? string.Empty;}
			set{_itemAct = value;}
		}
		private string _classNo = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ClassNo
		{
			get{return _classNo ?? string.Empty;}
			set{_classNo = value;}
		}
		private string _classNoName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ClassNoName
		{
			get{return _classNoName ?? string.Empty;}
			set{_classNoName = value;}
		}
		private string _legislationItemId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LegislationItemId
		{
			get{return _legislationItemId ?? string.Empty;}
			set{_legislationItemId = value;}
		}
		private string _itemName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			get{return _itemName ?? string.Empty;}
			set{_itemName = value;}
		}
		private string _legislationGistId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LegislationGistId
		{
			get{return _legislationGistId ?? string.Empty;}
			set{_legislationGistId = value;}
		}
		private string _gistName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string GistName
		{
			get{return _gistName ?? string.Empty;}
			set{_gistName = value;}
		}
		private string _dutyName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string DutyName
		{
			get{return _dutyName ?? string.Empty;}
			set{_dutyName = value;}
		}
		private string _stipulateFirst = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string StipulateFirst
		{
			get{return _stipulateFirst ?? string.Empty;}
			set{_stipulateFirst = value;}
		}
		private string _stipulateSecond = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string StipulateSecond
		{
			get{return _stipulateSecond ?? string.Empty;}
			set{_stipulateSecond = value;}
		}
		private string _legislationRuleId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string LegislationRuleId
		{
			get{return _legislationRuleId ?? string.Empty;}
			set{_legislationRuleId = value;}
		}
		private string _punishContent = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string PunishContent
		{
			get{return _punishContent ?? string.Empty;}
			set{_punishContent = value;}
		}
		private string _punishType = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string PunishType
		{
			get{return _punishType ?? string.Empty;}
			set{_punishType = value;}
		}
		private string _measurement = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Measurement
		{
			get{return _measurement ?? string.Empty;}
			set{_measurement = value;}
		}
		private int _punishMax;
		/// <summary>
		/// 
		/// </summary>
		public int PunishMax
		{
			get{return _punishMax;}
			set{_punishMax = value;}
		}
		private int _punishMin;
		/// <summary>
		/// 
		/// </summary>
		public int PunishMin
		{
			get{return _punishMin;}
			set{_punishMin = value;}
		}
		private Double _punishAmount;
		/// <summary>
		/// 
		/// </summary>
		public Double PunishAmount
		{
			get{return _punishAmount;}
			set{_punishAmount = value;}
		}
		private Double _forfeitureAmount;
		/// <summary>
		/// 
		/// </summary>
		public Double ForfeitureAmount
		{
			get{return _forfeitureAmount;}
			set{_forfeitureAmount = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override TempDetainInfoLegislationEntity SetModelValueByDataRow(DataRow dr)
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
		public override TempDetainInfoLegislationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainInfoLegislationEntity();
          			if (fields.Contains(Parm_TempDetainInfo_Legislation_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_TempDetainInfo_Legislation_Id].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_TempDetainInfo_Legislation_CaseInfoId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_LegislationId) || fields.Contains("*"))
				tmp.LegislationId = dr[Parm_TempDetainInfo_Legislation_LegislationId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ItemCode) || fields.Contains("*"))
				tmp.ItemCode = dr[Parm_TempDetainInfo_Legislation_ItemCode].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ItemType) || fields.Contains("*"))
				tmp.ItemType = dr[Parm_TempDetainInfo_Legislation_ItemType].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ItemNo) || fields.Contains("*"))
				tmp.ItemNo = dr[Parm_TempDetainInfo_Legislation_ItemNo].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ItemAct) || fields.Contains("*"))
				tmp.ItemAct = dr[Parm_TempDetainInfo_Legislation_ItemAct].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ClassNo) || fields.Contains("*"))
				tmp.ClassNo = dr[Parm_TempDetainInfo_Legislation_ClassNo].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ClassNoName) || fields.Contains("*"))
				tmp.ClassNoName = dr[Parm_TempDetainInfo_Legislation_ClassNoName].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_LegislationItemId) || fields.Contains("*"))
				tmp.LegislationItemId = dr[Parm_TempDetainInfo_Legislation_LegislationItemId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ItemName) || fields.Contains("*"))
				tmp.ItemName = dr[Parm_TempDetainInfo_Legislation_ItemName].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_LegislationGistId) || fields.Contains("*"))
				tmp.LegislationGistId = dr[Parm_TempDetainInfo_Legislation_LegislationGistId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_GistName) || fields.Contains("*"))
				tmp.GistName = dr[Parm_TempDetainInfo_Legislation_GistName].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_DutyName) || fields.Contains("*"))
				tmp.DutyName = dr[Parm_TempDetainInfo_Legislation_DutyName].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_StipulateFirst) || fields.Contains("*"))
				tmp.StipulateFirst = dr[Parm_TempDetainInfo_Legislation_StipulateFirst].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_StipulateSecond) || fields.Contains("*"))
				tmp.StipulateSecond = dr[Parm_TempDetainInfo_Legislation_StipulateSecond].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_LegislationRuleId) || fields.Contains("*"))
				tmp.LegislationRuleId = dr[Parm_TempDetainInfo_Legislation_LegislationRuleId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_PunishContent) || fields.Contains("*"))
				tmp.PunishContent = dr[Parm_TempDetainInfo_Legislation_PunishContent].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_PunishType) || fields.Contains("*"))
				tmp.PunishType = dr[Parm_TempDetainInfo_Legislation_PunishType].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_Measurement) || fields.Contains("*"))
				tmp.Measurement = dr[Parm_TempDetainInfo_Legislation_Measurement].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_PunishMax) || fields.Contains("*"))
				tmp.PunishMax = int.Parse(dr[Parm_TempDetainInfo_Legislation_PunishMax].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_PunishMin) || fields.Contains("*"))
				tmp.PunishMin = int.Parse(dr[Parm_TempDetainInfo_Legislation_PunishMin].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_PunishAmount) || fields.Contains("*"))
				tmp.PunishAmount = Double.Parse(dr[Parm_TempDetainInfo_Legislation_PunishAmount].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_ForfeitureAmount) || fields.Contains("*"))
				tmp.ForfeitureAmount = Double.Parse(dr[Parm_TempDetainInfo_Legislation_ForfeitureAmount].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_TempDetainInfo_Legislation_RowStatus].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_TempDetainInfo_Legislation_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_TempDetainInfo_Legislation_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_TempDetainInfo_Legislation_CreatorId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_TempDetainInfo_Legislation_CreateBy].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainInfo_Legislation_CreateOn].ToString());
			if (fields.Contains(Parm_TempDetainInfo_Legislation_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_TempDetainInfo_Legislation_UpdateId].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_TempDetainInfo_Legislation_UpdateBy].ToString();
			if (fields.Contains(Parm_TempDetainInfo_Legislation_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainInfo_Legislation_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetaininfo_legislation">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainInfoLegislationEntity tempdetaininfo_legislation, SqlParameter[] parms)
		{
                parms[0].Value = tempdetaininfo_legislation.CaseInfoId;
				parms[1].Value = tempdetaininfo_legislation.LegislationId;
				parms[2].Value = tempdetaininfo_legislation.ItemCode;
				parms[3].Value = tempdetaininfo_legislation.ItemType;
				parms[4].Value = tempdetaininfo_legislation.ItemNo;
				parms[5].Value = tempdetaininfo_legislation.ItemAct;
				parms[6].Value = tempdetaininfo_legislation.ClassNo;
				parms[7].Value = tempdetaininfo_legislation.ClassNoName;
				parms[8].Value = tempdetaininfo_legislation.LegislationItemId;
				parms[9].Value = tempdetaininfo_legislation.ItemName;
				parms[10].Value = tempdetaininfo_legislation.LegislationGistId;
				parms[11].Value = tempdetaininfo_legislation.GistName;
				parms[12].Value = tempdetaininfo_legislation.DutyName;
				parms[13].Value = tempdetaininfo_legislation.StipulateFirst;
				parms[14].Value = tempdetaininfo_legislation.StipulateSecond;
				parms[15].Value = tempdetaininfo_legislation.LegislationRuleId;
				parms[16].Value = tempdetaininfo_legislation.PunishContent;
				parms[17].Value = tempdetaininfo_legislation.PunishType;
				parms[18].Value = tempdetaininfo_legislation.Measurement;
				parms[19].Value = tempdetaininfo_legislation.PunishMax;
				parms[20].Value = tempdetaininfo_legislation.PunishMin;
				parms[21].Value = tempdetaininfo_legislation.PunishAmount;
				parms[22].Value = tempdetaininfo_legislation.ForfeitureAmount;
				parms[23].Value = tempdetaininfo_legislation.RowStatus;
				parms[24].Value = tempdetaininfo_legislation.CreatorId;
				parms[25].Value = tempdetaininfo_legislation.CreateBy;
				parms[26].Value = tempdetaininfo_legislation.CreateOn;
				parms[27].Value = tempdetaininfo_legislation.UpdateId;
				parms[28].Value = tempdetaininfo_legislation.UpdateBy;
				parms[29].Value = tempdetaininfo_legislation.UpdateOn;
                parms[30].Value = tempdetaininfo_legislation.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainInfoLegislationEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Legislation_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_TempDetainInfo_Legislation_CaseInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_LegislationId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ItemCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ItemType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ItemNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ItemAct, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ClassNoName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_LegislationItemId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ItemName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_LegislationGistId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_GistName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_TempDetainInfo_Legislation_DutyName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_TempDetainInfo_Legislation_StipulateFirst, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_TempDetainInfo_Legislation_StipulateSecond, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_TempDetainInfo_Legislation_LegislationRuleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_PunishContent, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TempDetainInfo_Legislation_PunishType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_Measurement, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_PunishMax, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainInfo_Legislation_PunishMin, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainInfo_Legislation_PunishAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_TempDetainInfo_Legislation_ForfeitureAmount, SqlDbType.Float, 53),
					new SqlParameter(Parm_TempDetainInfo_Legislation_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainInfo_Legislation_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainInfo_Legislation_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Legislation_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TempDetainInfo_Legislation_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Legislation_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
