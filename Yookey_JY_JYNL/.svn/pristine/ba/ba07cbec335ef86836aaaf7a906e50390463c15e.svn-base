//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_INFORMEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/7 10:38:31
//  功能描述：INF_PUNISH_INFORM表实体
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
    /// 告知书
    /// </summary>
    [Serializable]
    public class InfPunishInformEntity : ModelImp.BaseModel<InfPunishInformEntity>
    {
       	public InfPunishInformEntity()
		{
			TB_Name = TB_INF_PUNISH_INFORM;
			Parm_Id = Parm_INF_PUNISH_INFORM_Id;
			Parm_Version = Parm_INF_PUNISH_INFORM_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_INFORM_Insert;
			Sql_Update = Sql_INF_PUNISH_INFORM_Update;
			Sql_Delete = Sql_INF_PUNISH_INFORM_Delete;
		}
       	#region Const of table INF_PUNISH_INFORM
		/// <summary>
		/// Table INF_PUNISH_INFORM
		/// </summary>
		public const string TB_INF_PUNISH_INFORM = "INF_PUNISH_INFORM";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Authority
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_Authority = "Authority";
		/// <summary>
		/// Parm CaseAddr
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CaseAddr = "CaseAddr";
		/// <summary>
		/// Parm CaseDate
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CaseDate = "CaseDate";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DutyClause
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_DutyClause = "DutyClause";
		/// <summary>
		/// Parm DutyItem
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_DutyItem = "DutyItem";
		/// <summary>
		/// Parm DutyName
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_DutyName = "DutyName";
		/// <summary>
		/// Parm DutyStrip
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_DutyStrip = "DutyStrip";
		/// <summary>
		/// Parm FileDate
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_FileDate = "FileDate";
		/// <summary>
		/// Parm FileDateCapital
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_FileDateCapital = "FileDateCapital";
		/// <summary>
		/// Parm FileNumber
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_FileNumber = "FileNumber";
		/// <summary>
		/// Parm GistClause
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_GistClause = "GistClause";
		/// <summary>
		/// Parm GistItem
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_GistItem = "GistItem";
		/// <summary>
		/// Parm GistName
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_GistName = "GistName";
		/// <summary>
		/// Parm GistStrip
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_GistStrip = "GistStrip";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_Id = "Id";
		/// <summary>
		/// Parm ItemName
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_ItemName = "ItemName";
		/// <summary>
		/// Parm PunishContent
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_PunishContent = "PunishContent";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_RowStatus = "RowStatus";
		/// <summary>
		/// Parm State
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_State = "State";
		/// <summary>
		/// Parm TargetAddress
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_TargetAddress = "TargetAddress";
		/// <summary>
		/// Parm TargetName
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_TargetName = "TargetName";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_INFORM_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_INFORM
		/// </summary>
		public const string Sql_INF_PUNISH_INFORM_Insert = "insert into INF_PUNISH_INFORM(Authority,CaseAddr,CaseDate,CaseInfoId,CreateBy,CreateOn,CreatorId,DutyClause,DutyItem,DutyName,DutyStrip,FileDate,FileDateCapital,FileNumber,GistClause,GistItem,GistName,GistStrip,ItemName,PunishContent,RowStatus,State,TargetAddress,TargetName,UpdateBy,UpdateId,UpdateOn,Id) values(@Authority,@CaseAddr,@CaseDate,@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@DutyClause,@DutyItem,@DutyName,@DutyStrip,@FileDate,@FileDateCapital,@FileNumber,@GistClause,@GistItem,@GistName,@GistStrip,@ItemName,@PunishContent,@RowStatus,@State,@TargetAddress,@TargetName,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_INFORM
		/// </summary>
		public const string Sql_INF_PUNISH_INFORM_Update = "update INF_PUNISH_INFORM set Authority=@Authority,CaseAddr=@CaseAddr,CaseDate=@CaseDate,CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyClause=@DutyClause,DutyItem=@DutyItem,DutyName=@DutyName,DutyStrip=@DutyStrip,FileDate=@FileDate,FileDateCapital=@FileDateCapital,FileNumber=@FileNumber,GistClause=@GistClause,GistItem=@GistItem,GistName=@GistName,GistStrip=@GistStrip,ItemName=@ItemName,PunishContent=@PunishContent,RowStatus=@RowStatus,State=@State,TargetAddress=@TargetAddress,TargetName=@TargetName,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_INFORM_Delete = "update INF_PUNISH_INFORM set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _caseInfoId = string.Empty;
		/// <summary>
		/// nvarchar
		/// </summary>
		public string CaseInfoId
		{
			get{return _caseInfoId ?? string.Empty;}
			set{_caseInfoId = value;}
		}
		private string _fileNumber = string.Empty;
		/// <summary>
		/// nvarchar 	告知书编号
		/// </summary>
		public string FileNumber
		{
			get{return _fileNumber ?? string.Empty;}
			set{_fileNumber = value;}
		}
		private DateTime _fileDate = MinDate;
		/// <summary>
		/// datetime 	告知书日期
		/// </summary>
		public DateTime FileDate
		{
			get{return _fileDate;}
			set{_fileDate = value;}
		}
		private string _fileDateCapital = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string FileDateCapital
		{
			get{return _fileDateCapital ?? string.Empty;}
			set{_fileDateCapital = value;}
		}
		private string _targetName = string.Empty;
		/// <summary>
		/// nvarchar 	当事人姓名/负责人姓名
		/// </summary>
		public string TargetName
		{
			get{return _targetName ?? string.Empty;}
			set{_targetName = value;}
		}
		private string _targetAddress = string.Empty;
		/// <summary>
		/// nvarchar 	当事人地址
		/// </summary>
		public string TargetAddress
		{
			get{return _targetAddress ?? string.Empty;}
			set{_targetAddress = value;}
		}
		private DateTime _caseDate = MinDate;
		/// <summary>
		/// datetime 	案发日期
		/// </summary>
		public DateTime CaseDate
		{
			get{return _caseDate;}
			set{_caseDate = value;}
		}
		private string _caseAddr = string.Empty;
		/// <summary>
		/// nvarchar 	案发地点
		/// </summary>
		public string CaseAddr
		{
			get{return _caseAddr ?? string.Empty;}
			set{_caseAddr = value;}
		}
		private string _itemName = string.Empty;
		/// <summary>
		/// nvarchar 	案由名称
		/// </summary>
		public string ItemName
		{
			get{return _itemName ?? string.Empty;}
			set{_itemName = value;}
		}
		private string _gistName = string.Empty;
		/// <summary>
		/// nvarchar 	管理依据（违法法律）
		/// </summary>
		public string GistName
		{
			get{return _gistName ?? string.Empty;}
			set{_gistName = value;}
		}
		private string _gistStrip = string.Empty;
		/// <summary>
		/// nvarchar 	管理依据->条
		/// </summary>
		public string GistStrip
		{
			get{return _gistStrip ?? string.Empty;}
			set{_gistStrip = value;}
		}
		private string _gistClause = string.Empty;
		/// <summary>
		/// nvarchar 	管理依据->款
		/// </summary>
		public string GistClause
		{
			get{return _gistClause ?? string.Empty;}
			set{_gistClause = value;}
		}
		private string _gistItem = string.Empty;
		/// <summary>
		/// nvarchar 	管理依据->项
		/// </summary>
		public string GistItem
		{
			get{return _gistItem ?? string.Empty;}
			set{_gistItem = value;}
		}
		private string _dutyName = string.Empty;
		/// <summary>
		/// nvarchar 	法律责任（依据法律）
		/// </summary>
		public string DutyName
		{
			get{return _dutyName ?? string.Empty;}
			set{_dutyName = value;}
		}
		private string _dutyStrip = string.Empty;
		/// <summary>
		/// nvarchar 	法律责任->条
		/// </summary>
		public string DutyStrip
		{
			get{return _dutyStrip ?? string.Empty;}
			set{_dutyStrip = value;}
		}
		private string _dutyClause = string.Empty;
		/// <summary>
		/// nvarchar 	法律责任->款
		/// </summary>
		public string DutyClause
		{
			get{return _dutyClause ?? string.Empty;}
			set{_dutyClause = value;}
		}
		private string _dutyItem = string.Empty;
		/// <summary>
		/// nvarchar 	法律责任->项
		/// </summary>
		public string DutyItem
		{
			get{return _dutyItem ?? string.Empty;}
			set{_dutyItem = value;}
		}
		private string _punishContent = string.Empty;
		/// <summary>
		/// nvarchar 	处罚内容
		/// </summary>
		public string PunishContent
		{
			get{return _punishContent ?? string.Empty;}
			set{_punishContent = value;}
		}
		private int _authority;
		/// <summary>
		/// int 	享受权利
		/// </summary>
		public int Authority
		{
			get{return _authority;}
			set{_authority = value;}
		}
		private int _state;
		/// <summary>
		/// int 	状态
		/// </summary>
		public int State
		{
			get{return _state;}
			set{_state = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishInformEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishInformEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishInformEntity();
          			if (fields.Contains(Parm_INF_PUNISH_INFORM_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_INFORM_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_INFORM_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_FileNumber) || fields.Contains("*"))
				tmp.FileNumber = dr[Parm_INF_PUNISH_INFORM_FileNumber].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_FileDate) || fields.Contains("*"))
				tmp.FileDate = DateTime.Parse(dr[Parm_INF_PUNISH_INFORM_FileDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_FileDateCapital) || fields.Contains("*"))
				tmp.FileDateCapital = dr[Parm_INF_PUNISH_INFORM_FileDateCapital].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_TargetName) || fields.Contains("*"))
				tmp.TargetName = dr[Parm_INF_PUNISH_INFORM_TargetName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_TargetAddress) || fields.Contains("*"))
				tmp.TargetAddress = dr[Parm_INF_PUNISH_INFORM_TargetAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CaseDate) || fields.Contains("*"))
				tmp.CaseDate = DateTime.Parse(dr[Parm_INF_PUNISH_INFORM_CaseDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CaseAddr) || fields.Contains("*"))
				tmp.CaseAddr = dr[Parm_INF_PUNISH_INFORM_CaseAddr].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_ItemName) || fields.Contains("*"))
				tmp.ItemName = dr[Parm_INF_PUNISH_INFORM_ItemName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_GistName) || fields.Contains("*"))
				tmp.GistName = dr[Parm_INF_PUNISH_INFORM_GistName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_GistStrip) || fields.Contains("*"))
				tmp.GistStrip = dr[Parm_INF_PUNISH_INFORM_GistStrip].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_GistClause) || fields.Contains("*"))
				tmp.GistClause = dr[Parm_INF_PUNISH_INFORM_GistClause].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_GistItem) || fields.Contains("*"))
				tmp.GistItem = dr[Parm_INF_PUNISH_INFORM_GistItem].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_DutyName) || fields.Contains("*"))
				tmp.DutyName = dr[Parm_INF_PUNISH_INFORM_DutyName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_DutyStrip) || fields.Contains("*"))
				tmp.DutyStrip = dr[Parm_INF_PUNISH_INFORM_DutyStrip].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_DutyClause) || fields.Contains("*"))
				tmp.DutyClause = dr[Parm_INF_PUNISH_INFORM_DutyClause].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_DutyItem) || fields.Contains("*"))
				tmp.DutyItem = dr[Parm_INF_PUNISH_INFORM_DutyItem].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_PunishContent) || fields.Contains("*"))
				tmp.PunishContent = dr[Parm_INF_PUNISH_INFORM_PunishContent].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_Authority) || fields.Contains("*"))
				tmp.Authority = int.Parse(dr[Parm_INF_PUNISH_INFORM_Authority].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_State) || fields.Contains("*"))
				tmp.State = int.Parse(dr[Parm_INF_PUNISH_INFORM_State].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_INFORM_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_INFORM_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_INFORM_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_INFORM_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_INFORM_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_INFORM_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_INFORM_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_INFORM_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_INFORM_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_INFORM_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_inform">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishInformEntity inf_punish_inform, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_inform.CaseInfoId;
				parms[1].Value = inf_punish_inform.FileNumber;
				parms[2].Value = inf_punish_inform.FileDate;
				parms[3].Value = inf_punish_inform.FileDateCapital;
				parms[4].Value = inf_punish_inform.TargetName;
				parms[5].Value = inf_punish_inform.TargetAddress;
				parms[6].Value = inf_punish_inform.CaseDate;
				parms[7].Value = inf_punish_inform.CaseAddr;
				parms[8].Value = inf_punish_inform.ItemName;
				parms[9].Value = inf_punish_inform.GistName;
				parms[10].Value = inf_punish_inform.GistStrip;
				parms[11].Value = inf_punish_inform.GistClause;
				parms[12].Value = inf_punish_inform.GistItem;
				parms[13].Value = inf_punish_inform.DutyName;
				parms[14].Value = inf_punish_inform.DutyStrip;
				parms[15].Value = inf_punish_inform.DutyClause;
				parms[16].Value = inf_punish_inform.DutyItem;
				parms[17].Value = inf_punish_inform.PunishContent;
				parms[18].Value = inf_punish_inform.Authority;
				parms[19].Value = inf_punish_inform.State;
				parms[20].Value = inf_punish_inform.RowStatus;
				parms[21].Value = inf_punish_inform.CreatorId;
				parms[22].Value = inf_punish_inform.CreateBy;
				parms[23].Value = inf_punish_inform.CreateOn;
				parms[24].Value = inf_punish_inform.UpdateId;
				parms[25].Value = inf_punish_inform.UpdateBy;
				parms[26].Value = inf_punish_inform.UpdateOn;
                parms[27].Value = inf_punish_inform.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishInformEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_INFORM_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_INFORM_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_FileNumber, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_FileDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_INFORM_FileDateCapital, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_TargetName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_TargetAddress, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_INFORM_CaseDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_INFORM_CaseAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_INFORM_ItemName, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_INFORM_GistName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_INFORM_GistStrip, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_GistClause, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_GistItem, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_DutyName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_INFORM_DutyStrip, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_DutyClause, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_DutyItem, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_INF_PUNISH_INFORM_PunishContent, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_INFORM_Authority, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_INFORM_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_INFORM_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_INFORM_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_INFORM_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_INFORM_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_INFORM_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_INFORM_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
