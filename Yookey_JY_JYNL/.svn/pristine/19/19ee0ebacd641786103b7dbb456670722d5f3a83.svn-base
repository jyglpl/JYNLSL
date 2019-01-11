//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_HEAREntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:23
//  功能描述：INF_PUNISH_HEAR表实体
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
    /// 陈述申辩（听证）
    /// </summary>
    [Serializable]
    public class InfPunishHearEntity : ModelImp.BaseModel<InfPunishHearEntity>
    {
        public InfPunishHearEntity()
		{
			TB_Name = TB_INF_PUNISH_HEAR;
			Parm_Id = Parm_INF_PUNISH_HEAR_Id;
			Parm_Version = Parm_INF_PUNISH_HEAR_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_HEAR_Insert;
			Sql_Update = Sql_INF_PUNISH_HEAR_Update;
			Sql_Delete = Sql_INF_PUNISH_HEAR_Delete;
		}
       	#region Const of table INF_PUNISH_HEAR
		/// <summary>
		/// Table INF_PUNISH_HEAR
		/// </summary>
		public const string TB_INF_PUNISH_HEAR = "INF_PUNISH_HEAR";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm ApplyAddress
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_ApplyAddress = "ApplyAddress";
		/// <summary>
		/// Parm ApplyNumber
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_ApplyNumber = "ApplyNumber";
		/// <summary>
		/// Parm ApplyType
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_ApplyType = "ApplyType";
		/// <summary>
		/// Parm Attendances
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Attendances = "Attendances";
		/// <summary>
		/// Parm BePunishedAgentPerson
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_BePunishedAgentPerson = "BePunishedAgentPerson";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm Compere
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Compere = "Compere";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DeptId
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_DeptId = "DeptId";
		/// <summary>
		/// Parm DeptName
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_DeptName = "DeptName";
		/// <summary>
		/// Parm EndDate
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_EndDate = "EndDate";
		/// <summary>
		/// Parm EnforceAgentPerson
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_EnforceAgentPerson = "EnforceAgentPerson";
		/// <summary>
		/// Parm Entrust
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Entrust = "Entrust";
		/// <summary>
		/// Parm HearContent
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_HearContent = "HearContent";
		/// <summary>
		/// Parm HearingOpinion
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_HearingOpinion = "HearingOpinion";
		/// <summary>
		/// Parm HearingType
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_HearingType = "HearingType";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Id = "Id";
		/// <summary>
		/// Parm PunishPerson
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_PunishPerson = "PunishPerson";
		/// <summary>
		/// Parm Reason
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Reason = "Reason";
		/// <summary>
		/// Parm Records
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Records = "Records";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_RowStatus = "RowStatus";
		/// <summary>
		/// Parm StartDate
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_StartDate = "StartDate";
		/// <summary>
		/// Parm UdPersonelIdFirst
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UdPersonelIdFirst = "UdPersonelIdFirst";
		/// <summary>
		/// Parm UdPersonelIdSecond
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UdPersonelIdSecond = "UdPersonelIdSecond";
		/// <summary>
		/// Parm UdPersonelNameFirst
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UdPersonelNameFirst = "UdPersonelNameFirst";
		/// <summary>
		/// Parm UdPersonelNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UdPersonelNameSecond = "UdPersonelNameSecond";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_HEAR_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_HEAR
		/// </summary>
		public const string Sql_INF_PUNISH_HEAR_Insert = "insert into INF_PUNISH_HEAR(ApplyAddress,ApplyNumber,ApplyType,Attendances,BePunishedAgentPerson,CaseInfoId,Compere,CreateBy,CreateOn,CreatorId,DeptId,DeptName,EndDate,EnforceAgentPerson,Entrust,HearContent,HearingOpinion,HearingType,PunishPerson,Reason,Records,RowStatus,StartDate,UdPersonelIdFirst,UdPersonelIdSecond,UdPersonelNameFirst,UdPersonelNameSecond,UpdateBy,UpdateId,UpdateOn,Id) values(@ApplyAddress,@ApplyNumber,@ApplyType,@Attendances,@BePunishedAgentPerson,@CaseInfoId,@Compere,@CreateBy,@CreateOn,@CreatorId,@DeptId,@DeptName,@EndDate,@EnforceAgentPerson,@Entrust,@HearContent,@HearingOpinion,@HearingType,@PunishPerson,@Reason,@Records,@RowStatus,@StartDate,@UdPersonelIdFirst,@UdPersonelIdSecond,@UdPersonelNameFirst,@UdPersonelNameSecond,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_HEAR
		/// </summary>
		public const string Sql_INF_PUNISH_HEAR_Update = "update INF_PUNISH_HEAR set ApplyAddress=@ApplyAddress,ApplyNumber=@ApplyNumber,ApplyType=@ApplyType,Attendances=@Attendances,BePunishedAgentPerson=@BePunishedAgentPerson,CaseInfoId=@CaseInfoId,Compere=@Compere,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,DeptName=@DeptName,EndDate=@EndDate,EnforceAgentPerson=@EnforceAgentPerson,Entrust=@Entrust,HearContent=@HearContent,HearingOpinion=@HearingOpinion,HearingType=@HearingType,PunishPerson=@PunishPerson,Reason=@Reason,Records=@Records,RowStatus=@RowStatus,StartDate=@StartDate,UdPersonelIdFirst=@UdPersonelIdFirst,UdPersonelIdSecond=@UdPersonelIdSecond,UdPersonelNameFirst=@UdPersonelNameFirst,UdPersonelNameSecond=@UdPersonelNameSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_HEAR_Delete = "update INF_PUNISH_HEAR set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _caseInfoId = string.Empty;
		/// <summary>
		/// nvarchar 	案件编号
		/// </summary>
		public string CaseInfoId
		{
			get{return _caseInfoId ?? string.Empty;}
			set{_caseInfoId = value;}
		}
		private int _applyType;
		/// <summary>
		/// int 	是否放弃陈述申辩（听证）0：放弃 1、陈述申辩 2、听证
		/// </summary>
		public int ApplyType
		{
			get{return _applyType;}
			set{_applyType = value;}
		}
		private DateTime _startDate = MinDate;
		/// <summary>
		/// datetime 	陈述申辩/听证日期 开始
		/// </summary>
		public DateTime StartDate
		{
			get{return _startDate;}
			set{_startDate = value;}
		}
		private DateTime _endDate = MinDate;
		/// <summary>
		/// datetime 	陈述申辩/听证日期 结束
		/// </summary>
		public DateTime EndDate
		{
			get{return _endDate;}
			set{_endDate = value;}
		}
		private string _applyNumber = string.Empty;
		/// <summary>
		/// varchar 	编号
		/// </summary>
		public string ApplyNumber
		{
			get{return _applyNumber ?? string.Empty;}
			set{_applyNumber = value;}
		}
		private string _applyAddress = string.Empty;
		/// <summary>
		/// nvarchar 	陈述申辩/听证地点
		/// </summary>
		public string ApplyAddress
		{
			get{return _applyAddress ?? string.Empty;}
			set{_applyAddress = value;}
		}
		private string _udPersonelIdFirst = string.Empty;
		/// <summary>
		/// nvarchar 	承办人一（编号）
		/// </summary>
		public string UdPersonelIdFirst
		{
			get{return _udPersonelIdFirst ?? string.Empty;}
			set{_udPersonelIdFirst = value;}
		}
		private string _udPersonelIdSecond = string.Empty;
		/// <summary>
		/// nvarchar 	承办人二（编号）
		/// </summary>
		public string UdPersonelIdSecond
		{
			get{return _udPersonelIdSecond ?? string.Empty;}
			set{_udPersonelIdSecond = value;}
		}
		private string _udPersonelNameFirst = string.Empty;
		/// <summary>
		/// nvarchar 	承办人一（姓名）
		/// </summary>
		public string UdPersonelNameFirst
		{
			get{return _udPersonelNameFirst ?? string.Empty;}
			set{_udPersonelNameFirst = value;}
		}
		private string _udPersonelNameSecond = string.Empty;
		/// <summary>
		/// nvarchar 	承办人二（姓名）
		/// </summary>
		public string UdPersonelNameSecond
		{
			get{return _udPersonelNameSecond ?? string.Empty;}
			set{_udPersonelNameSecond = value;}
		}
		private string _deptId = string.Empty;
		/// <summary>
		/// nvarchar 	部门编号（承办部门）
		/// </summary>
		public string DeptId
		{
			get{return _deptId ?? string.Empty;}
			set{_deptId = value;}
		}
		private string _deptName = string.Empty;
		/// <summary>
		/// nvarchar 	部门名称（承办部门）
		/// </summary>
		public string DeptName
		{
			get{return _deptName ?? string.Empty;}
			set{_deptName = value;}
		}
		private string _records = string.Empty;
		/// <summary>
		/// nvarchar 	记录人
		/// </summary>
		public string Records
		{
			get{return _records ?? string.Empty;}
			set{_records = value;}
		}
		private string _entrust = string.Empty;
		/// <summary>
		/// nvarchar 	委托代理人/被处罚代理人
		/// </summary>
		public string Entrust
		{
			get{return _entrust ?? string.Empty;}
			set{_entrust = value;}
		}
		private string _hearContent = string.Empty;
		/// <summary>
		/// nvarchar 	陈述申辩内容
		/// </summary>
		public string HearContent
		{
			get{return _hearContent ?? string.Empty;}
			set{_hearContent = value;}
		}
		private string _compere = string.Empty;
		/// <summary>
		/// nvarchar 	听证主持人
		/// </summary>
		public string Compere
		{
			get{return _compere ?? string.Empty;}
			set{_compere = value;}
		}
		private string _punishPerson = string.Empty;
		/// <summary>
		/// nvarchar 	被处罚人
		/// </summary>
		public string PunishPerson
		{
			get{return _punishPerson ?? string.Empty;}
			set{_punishPerson = value;}
		}
		private string _attendances = string.Empty;
		/// <summary>
		/// nvarchar 	列席人
		/// </summary>
		public string Attendances
		{
			get{return _attendances ?? string.Empty;}
			set{_attendances = value;}
		}
		private string _reason = string.Empty;
		/// <summary>
		/// nvarchar 	当事人主要理由
		/// </summary>
		public string Reason
		{
			get{return _reason ?? string.Empty;}
			set{_reason = value;}
		}
		private int _hearingType;
		/// <summary>
		/// 听证会方式（1公开  0不公开）
		/// </summary>
		public int HearingType
		{
			get{return _hearingType;}
			set{_hearingType = value;}
		}
		private string _enforceAgentPerson = string.Empty;
		/// <summary>
		/// 执法代理人
		/// </summary>
		public string EnforceAgentPerson
		{
			get{return _enforceAgentPerson ?? string.Empty;}
			set{_enforceAgentPerson = value;}
		}
		private string _bePunishedAgentPerson = string.Empty;
		/// <summary>
		/// 被处罚代理人
		/// </summary>
		public string BePunishedAgentPerson
		{
			get{return _bePunishedAgentPerson ?? string.Empty;}
			set{_bePunishedAgentPerson = value;}
		}
		private string _hearingOpinion = string.Empty;
		/// <summary>
		/// 听证意见
		/// </summary>
		public string HearingOpinion
		{
			get{return _hearingOpinion ?? string.Empty;}
			set{_hearingOpinion = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishHearEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishHearEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishHearEntity();
          			if (fields.Contains(Parm_INF_PUNISH_HEAR_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_HEAR_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_HEAR_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_ApplyType) || fields.Contains("*"))
				tmp.ApplyType = int.Parse(dr[Parm_INF_PUNISH_HEAR_ApplyType].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_StartDate) || fields.Contains("*"))
				tmp.StartDate = DateTime.Parse(dr[Parm_INF_PUNISH_HEAR_StartDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_EndDate) || fields.Contains("*"))
				tmp.EndDate = DateTime.Parse(dr[Parm_INF_PUNISH_HEAR_EndDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_ApplyNumber) || fields.Contains("*"))
				tmp.ApplyNumber = dr[Parm_INF_PUNISH_HEAR_ApplyNumber].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_ApplyAddress) || fields.Contains("*"))
				tmp.ApplyAddress = dr[Parm_INF_PUNISH_HEAR_ApplyAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UdPersonelIdFirst) || fields.Contains("*"))
				tmp.UdPersonelIdFirst = dr[Parm_INF_PUNISH_HEAR_UdPersonelIdFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UdPersonelIdSecond) || fields.Contains("*"))
				tmp.UdPersonelIdSecond = dr[Parm_INF_PUNISH_HEAR_UdPersonelIdSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UdPersonelNameFirst) || fields.Contains("*"))
				tmp.UdPersonelNameFirst = dr[Parm_INF_PUNISH_HEAR_UdPersonelNameFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UdPersonelNameSecond) || fields.Contains("*"))
				tmp.UdPersonelNameSecond = dr[Parm_INF_PUNISH_HEAR_UdPersonelNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_DeptId) || fields.Contains("*"))
				tmp.DeptId = dr[Parm_INF_PUNISH_HEAR_DeptId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_DeptName) || fields.Contains("*"))
				tmp.DeptName = dr[Parm_INF_PUNISH_HEAR_DeptName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Records) || fields.Contains("*"))
				tmp.Records = dr[Parm_INF_PUNISH_HEAR_Records].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Entrust) || fields.Contains("*"))
				tmp.Entrust = dr[Parm_INF_PUNISH_HEAR_Entrust].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_HearContent) || fields.Contains("*"))
				tmp.HearContent = dr[Parm_INF_PUNISH_HEAR_HearContent].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Compere) || fields.Contains("*"))
				tmp.Compere = dr[Parm_INF_PUNISH_HEAR_Compere].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_PunishPerson) || fields.Contains("*"))
				tmp.PunishPerson = dr[Parm_INF_PUNISH_HEAR_PunishPerson].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Attendances) || fields.Contains("*"))
				tmp.Attendances = dr[Parm_INF_PUNISH_HEAR_Attendances].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Reason) || fields.Contains("*"))
				tmp.Reason = dr[Parm_INF_PUNISH_HEAR_Reason].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_HearingType) || fields.Contains("*"))
				tmp.HearingType = int.Parse(dr[Parm_INF_PUNISH_HEAR_HearingType].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_EnforceAgentPerson) || fields.Contains("*"))
				tmp.EnforceAgentPerson = dr[Parm_INF_PUNISH_HEAR_EnforceAgentPerson].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_BePunishedAgentPerson) || fields.Contains("*"))
				tmp.BePunishedAgentPerson = dr[Parm_INF_PUNISH_HEAR_BePunishedAgentPerson].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_HearingOpinion) || fields.Contains("*"))
				tmp.HearingOpinion = dr[Parm_INF_PUNISH_HEAR_HearingOpinion].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_HEAR_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_HEAR_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_HEAR_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_HEAR_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_HEAR_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_HEAR_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_HEAR_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_HEAR_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_HEAR_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_HEAR_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_hear">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishHearEntity inf_punish_hear, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_hear.CaseInfoId;
				parms[1].Value = inf_punish_hear.ApplyType;
				parms[2].Value = inf_punish_hear.StartDate;
				parms[3].Value = inf_punish_hear.EndDate;
				parms[4].Value = inf_punish_hear.ApplyNumber;
				parms[5].Value = inf_punish_hear.ApplyAddress;
				parms[6].Value = inf_punish_hear.UdPersonelIdFirst;
				parms[7].Value = inf_punish_hear.UdPersonelIdSecond;
				parms[8].Value = inf_punish_hear.UdPersonelNameFirst;
				parms[9].Value = inf_punish_hear.UdPersonelNameSecond;
				parms[10].Value = inf_punish_hear.DeptId;
				parms[11].Value = inf_punish_hear.DeptName;
				parms[12].Value = inf_punish_hear.Records;
				parms[13].Value = inf_punish_hear.Entrust;
				parms[14].Value = inf_punish_hear.HearContent;
				parms[15].Value = inf_punish_hear.Compere;
				parms[16].Value = inf_punish_hear.PunishPerson;
				parms[17].Value = inf_punish_hear.Attendances;
				parms[18].Value = inf_punish_hear.Reason;
				parms[19].Value = inf_punish_hear.HearingType;
				parms[20].Value = inf_punish_hear.EnforceAgentPerson;
				parms[21].Value = inf_punish_hear.BePunishedAgentPerson;
				parms[22].Value = inf_punish_hear.HearingOpinion;
				parms[23].Value = inf_punish_hear.RowStatus;
				parms[24].Value = inf_punish_hear.CreatorId;
				parms[25].Value = inf_punish_hear.CreateBy;
				parms[26].Value = inf_punish_hear.CreateOn;
				parms[27].Value = inf_punish_hear.UpdateId;
				parms[28].Value = inf_punish_hear.UpdateBy;
				parms[29].Value = inf_punish_hear.UpdateOn;
                parms[30].Value = inf_punish_hear.Id;
             return parms;
        }
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishHearEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_HEAR_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_HEAR_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_ApplyType, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_HEAR_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_HEAR_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_HEAR_ApplyNumber, SqlDbType.VarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_HEAR_ApplyAddress, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UdPersonelIdFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UdPersonelIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UdPersonelNameFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UdPersonelNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_DeptId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_DeptName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_Records, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_Entrust, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_HearContent, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_HEAR_Compere, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_PunishPerson, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_HEAR_Attendances, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_HEAR_Reason, SqlDbType.VarChar, 1000),
					new SqlParameter(Parm_INF_PUNISH_HEAR_HearingType, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_HEAR_EnforceAgentPerson, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_BePunishedAgentPerson, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_HearingOpinion, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_HEAR_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_HEAR_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_HEAR_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_HEAR_Id, SqlDbType.NVarChar, 50)
				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_HEAR_Insert, parms);
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

