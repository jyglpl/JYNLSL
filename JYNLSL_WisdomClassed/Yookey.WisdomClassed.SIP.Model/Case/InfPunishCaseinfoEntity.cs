//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_CASEINFOEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/11/06 16:16:01
//  功能描述：INF_PUNISH_CASEINFO表实体
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
    /// 案件基本信息
    /// </summary>
    [Serializable]
    public class InfPunishCaseinfoEntity : ModelImp.BaseModel<InfPunishCaseinfoEntity>
    {
       	public InfPunishCaseinfoEntity()
		{
			TB_Name = TB_INF_PUNISH_CASEINFO;
			Parm_Id = Parm_INF_PUNISH_CASEINFO_Id;
			Parm_Version = Parm_INF_PUNISH_CASEINFO_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_CASEINFO_Insert;
			Sql_Update = Sql_INF_PUNISH_CASEINFO_Update;
			Sql_Delete = Sql_INF_PUNISH_CASEINFO_Delete;
		}
       	#region Const of table INF_PUNISH_CASEINFO
		/// <summary>
		/// Table INF_PUNISH_CASEINFO
		/// </summary>
		public const string TB_INF_PUNISH_CASEINFO = "INF_PUNISH_CASEINFO";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AcceptInvestigationDate
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_AcceptInvestigationDate = "AcceptInvestigationDate";
		/// <summary>
		/// Parm CarNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CarNo = "CarNo";
		/// <summary>
		/// Parm CarType
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CarType = "CarType";
		/// <summary>
		/// Parm CaseAddress
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseAddress = "CaseAddress";
		/// <summary>
		/// Parm CaseDate
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseDate = "CaseDate";
		/// <summary>
		/// Parm CaseFact
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseFact = "CaseFact";
		/// <summary>
		/// Parm CaseHurtInfo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseHurtInfo = "CaseHurtInfo";
		/// <summary>
		/// Parm CaseInfoNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseInfoNo = "CaseInfoNo";
		/// <summary>
		/// Parm CaseType
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CaseType = "CaseType";
		/// <summary>
		/// Parm CheckRecord
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CheckRecord = "CheckRecord";
		/// <summary>
		/// Parm CompanyId
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CompanyId = "CompanyId";
		/// <summary>
		/// Parm CompanyName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CompanyName = "CompanyName";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DataSource
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_DataSource = "DataSource";
		/// <summary>
		/// Parm DeptId
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_DeptId = "DeptId";
		/// <summary>
		/// Parm DeptName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_DeptName = "DeptName";
		/// <summary>
		/// Parm FirstTrialPersonelIdFirst
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdFirst = "FirstTrialPersonelIdFirst";
		/// <summary>
		/// Parm FirstTrialPersonelIdSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdSecond = "FirstTrialPersonelIdSecond";
		/// <summary>
		/// Parm FirstTrialPersonelNameFirst
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameFirst = "FirstTrialPersonelNameFirst";
		/// <summary>
		/// Parm FirstTrialPersonelNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameSecond = "FirstTrialPersonelNameSecond";
		/// <summary>
		/// Parm GDDate
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_GDDate = "GDDate";
		/// <summary>
		/// Parm HandleCaseFact
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_HandleCaseFact = "HandleCaseFact";
		/// <summary>
		/// Parm HaProof
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_HaProof = "HaProof";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Id = "Id";
		/// <summary>
		/// Parm InternalNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_InternalNo = "InternalNo";
		/// <summary>
		/// Parm IsPublic
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_IsPublic = "IsPublic";
		/// <summary>
		/// Parm IsRectification
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_IsRectification = "IsRectification";
		/// <summary>
		/// Parm IsSync
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_IsSync = "IsSync";
		/// <summary>
		/// Parm IsTempDetainInfo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_IsTempDetainInfo = "IsTempDetainInfo";
		/// <summary>
		/// Parm LandState
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_LandState = "LandState";
		/// <summary>
		/// Parm Lat
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Lat = "Lat";
		/// <summary>
		/// Parm Lng
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Lng = "Lng";
		/// <summary>
		/// Parm NoticeNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_NoticeNo = "NoticeNo";
		/// <summary>
		/// Parm PunishProcess
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_PunishProcess = "PunishProcess";
		/// <summary>
		/// Parm Reference1
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Reference1 = "Reference1";
		/// <summary>
		/// Parm Reference2
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Reference2 = "Reference2";
		/// <summary>
		/// Parm RePersonelIdFist
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RePersonelIdFist = "RePersonelIdFist";
		/// <summary>
		/// Parm RePersonelIdSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RePersonelIdSecond = "RePersonelIdSecond";
		/// <summary>
		/// Parm RePersonelNameFist
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RePersonelNameFist = "RePersonelNameFist";
		/// <summary>
		/// Parm RePersonelNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RePersonelNameSecond = "RePersonelNameSecond";
		/// <summary>
		/// Parm ReportAddress
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportAddress = "ReportAddress";
		/// <summary>
		/// Parm ReportData
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportData = "ReportData";
		/// <summary>
		/// Parm ReportEmail
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportEmail = "ReportEmail";
		/// <summary>
		/// Parm ReportMobile
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportMobile = "ReportMobile";
		/// <summary>
		/// Parm ReportName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportName = "ReportName";
		/// <summary>
		/// Parm ReportPaperNum
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportPaperNum = "ReportPaperNum";
		/// <summary>
		/// Parm ReportPaperType
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportPaperType = "ReportPaperType";
		/// <summary>
		/// Parm ReportPhone
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportPhone = "ReportPhone";
		/// <summary>
		/// Parm ReportZipCode
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReportZipCode = "ReportZipCode";
		/// <summary>
		/// Parm ReProof
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReProof = "ReProof";
		/// <summary>
		/// Parm ReSource
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReSource = "ReSource";
		/// <summary>
		/// Parm ReSourceName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_ReSourceName = "ReSourceName";
		/// <summary>
		/// Parm RoadName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RoadName = "RoadName";
		/// <summary>
		/// Parm RoadName1
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RoadName1 = "RoadName1";
		/// <summary>
		/// Parm RoadName2
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RoadName2 = "RoadName2";
		/// <summary>
		/// Parm RoadNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RoadNo = "RoadNo";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_RowStatus = "RowStatus";
		/// <summary>
		/// Parm State
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_State = "State";
		/// <summary>
		/// Parm TargetAddress
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetAddress = "TargetAddress";
		/// <summary>
		/// Parm TargetAge
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetAge = "TargetAge";
		/// <summary>
		/// Parm TargetDuty
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetDuty = "TargetDuty";
		/// <summary>
		/// Parm TargetEmail
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetEmail = "TargetEmail";
		/// <summary>
		/// Parm TargetGender
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetGender = "TargetGender";
		/// <summary>
		/// Parm TargetGSDJ
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetGSDJ = "TargetGSDJ";
		/// <summary>
		/// Parm TargetMobile
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetMobile = "TargetMobile";
		/// <summary>
		/// Parm TargetName
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetName = "TargetName";
		/// <summary>
		/// Parm TargetPaperNum
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetPaperNum = "TargetPaperNum";
		/// <summary>
		/// Parm TargetPaperType
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetPaperType = "TargetPaperType";
		/// <summary>
		/// Parm TargetPhone
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetPhone = "TargetPhone";
		/// <summary>
		/// Parm TargetSHXYM
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetSHXYM = "TargetSHXYM";
		/// <summary>
		/// Parm TargetSWDJ
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetSWDJ = "TargetSWDJ";
		/// <summary>
		/// Parm TargetType
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetType = "TargetType";
		/// <summary>
		/// Parm TargetUnit
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetUnit = "TargetUnit";
		/// <summary>
		/// Parm TargetZDM
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetZDM = "TargetZDM";
		/// <summary>
		/// Parm TargetZipCode
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TargetZipCode = "TargetZipCode";
		/// <summary>
		/// Parm TempId
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TempId = "TempId";
		/// <summary>
		/// Parm TempNo
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_TempNo = "TempNo";
		/// <summary>
		/// Parm UdPersonelIdFirst
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UdPersonelIdFirst = "UdPersonelIdFirst";
		/// <summary>
		/// Parm UdPersonelIdSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UdPersonelIdSecond = "UdPersonelIdSecond";
		/// <summary>
		/// Parm UdPersonelNameFirst
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UdPersonelNameFirst = "UdPersonelNameFirst";
		/// <summary>
		/// Parm UdPersonelNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UdPersonelNameSecond = "UdPersonelNameSecond";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm UpOthers
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UpOthers = "UpOthers";
		/// <summary>
		/// Parm UpSupervisory
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_UpSupervisory = "UpSupervisory";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_CASEINFO_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_CASEINFO
		/// </summary>
		public const string Sql_INF_PUNISH_CASEINFO_Insert = "insert into INF_PUNISH_CASEINFO(AcceptInvestigationDate,CarNo,CarType,CaseAddress,CaseDate,CaseFact,CaseHurtInfo,CaseInfoNo,CaseType,CheckRecord,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DataSource,DeptId,DeptName,FirstTrialPersonelIdFirst,FirstTrialPersonelIdSecond,FirstTrialPersonelNameFirst,FirstTrialPersonelNameSecond,GDDate,HandleCaseFact,HaProof,InternalNo,IsPublic,IsRectification,IsSync,IsTempDetainInfo,LandState,Lat,Lng,NoticeNo,PunishProcess,Reference1,Reference2,RePersonelIdFist,RePersonelIdSecond,RePersonelNameFist,RePersonelNameSecond,ReportAddress,ReportData,ReportEmail,ReportMobile,ReportName,ReportPaperNum,ReportPaperType,ReportPhone,ReportZipCode,ReProof,ReSource,ReSourceName,RoadName,RoadName1,RoadName2,RoadNo,RowStatus,State,TargetAddress,TargetAge,TargetDuty,TargetEmail,TargetGender,TargetGSDJ,TargetMobile,TargetName,TargetPaperNum,TargetPaperType,TargetPhone,TargetSHXYM,TargetSWDJ,TargetType,TargetUnit,TargetZDM,TargetZipCode,TempId,TempNo,UdPersonelIdFirst,UdPersonelIdSecond,UdPersonelNameFirst,UdPersonelNameSecond,UpdateBy,UpdateId,UpdateOn,UpOthers,UpSupervisory,Id) values(@AcceptInvestigationDate,@CarNo,@CarType,@CaseAddress,@CaseDate,@CaseFact,@CaseHurtInfo,@CaseInfoNo,@CaseType,@CheckRecord,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DataSource,@DeptId,@DeptName,@FirstTrialPersonelIdFirst,@FirstTrialPersonelIdSecond,@FirstTrialPersonelNameFirst,@FirstTrialPersonelNameSecond,@GDDate,@HandleCaseFact,@HaProof,@InternalNo,@IsPublic,@IsRectification,@IsSync,@IsTempDetainInfo,@LandState,@Lat,@Lng,@NoticeNo,@PunishProcess,@Reference1,@Reference2,@RePersonelIdFist,@RePersonelIdSecond,@RePersonelNameFist,@RePersonelNameSecond,@ReportAddress,@ReportData,@ReportEmail,@ReportMobile,@ReportName,@ReportPaperNum,@ReportPaperType,@ReportPhone,@ReportZipCode,@ReProof,@ReSource,@ReSourceName,@RoadName,@RoadName1,@RoadName2,@RoadNo,@RowStatus,@State,@TargetAddress,@TargetAge,@TargetDuty,@TargetEmail,@TargetGender,@TargetGSDJ,@TargetMobile,@TargetName,@TargetPaperNum,@TargetPaperType,@TargetPhone,@TargetSHXYM,@TargetSWDJ,@TargetType,@TargetUnit,@TargetZDM,@TargetZipCode,@TempId,@TempNo,@UdPersonelIdFirst,@UdPersonelIdSecond,@UdPersonelNameFirst,@UdPersonelNameSecond,@UpdateBy,@UpdateId,@UpdateOn,@UpOthers,@UpSupervisory,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_CASEINFO
		/// </summary>
		public const string Sql_INF_PUNISH_CASEINFO_Update = "update INF_PUNISH_CASEINFO set AcceptInvestigationDate=@AcceptInvestigationDate,CarNo=@CarNo,CarType=@CarType,CaseAddress=@CaseAddress,CaseDate=@CaseDate,CaseFact=@CaseFact,CaseHurtInfo=@CaseHurtInfo,CaseInfoNo=@CaseInfoNo,CaseType=@CaseType,CheckRecord=@CheckRecord,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataSource=@DataSource,DeptId=@DeptId,DeptName=@DeptName,FirstTrialPersonelIdFirst=@FirstTrialPersonelIdFirst,FirstTrialPersonelIdSecond=@FirstTrialPersonelIdSecond,FirstTrialPersonelNameFirst=@FirstTrialPersonelNameFirst,FirstTrialPersonelNameSecond=@FirstTrialPersonelNameSecond,GDDate=@GDDate,HandleCaseFact=@HandleCaseFact,HaProof=@HaProof,InternalNo=@InternalNo,IsPublic=@IsPublic,IsRectification=@IsRectification,IsSync=@IsSync,IsTempDetainInfo=@IsTempDetainInfo,LandState=@LandState,Lat=@Lat,Lng=@Lng,NoticeNo=@NoticeNo,PunishProcess=@PunishProcess,Reference1=@Reference1,Reference2=@Reference2,RePersonelIdFist=@RePersonelIdFist,RePersonelIdSecond=@RePersonelIdSecond,RePersonelNameFist=@RePersonelNameFist,RePersonelNameSecond=@RePersonelNameSecond,ReportAddress=@ReportAddress,ReportData=@ReportData,ReportEmail=@ReportEmail,ReportMobile=@ReportMobile,ReportName=@ReportName,ReportPaperNum=@ReportPaperNum,ReportPaperType=@ReportPaperType,ReportPhone=@ReportPhone,ReportZipCode=@ReportZipCode,ReProof=@ReProof,ReSource=@ReSource,ReSourceName=@ReSourceName,RoadName=@RoadName,RoadName1=@RoadName1,RoadName2=@RoadName2,RoadNo=@RoadNo,RowStatus=@RowStatus,State=@State,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetDuty=@TargetDuty,TargetEmail=@TargetEmail,TargetGender=@TargetGender,TargetGSDJ=@TargetGSDJ,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,TargetPhone=@TargetPhone,TargetSHXYM=@TargetSHXYM,TargetSWDJ=@TargetSWDJ,TargetType=@TargetType,TargetUnit=@TargetUnit,TargetZDM=@TargetZDM,TargetZipCode=@TargetZipCode,TempId=@TempId,TempNo=@TempNo,UdPersonelIdFirst=@UdPersonelIdFirst,UdPersonelIdSecond=@UdPersonelIdSecond,UdPersonelNameFirst=@UdPersonelNameFirst,UdPersonelNameSecond=@UdPersonelNameSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UpOthers=@UpOthers,UpSupervisory=@UpSupervisory where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_CASEINFO_Delete = "update INF_PUNISH_CASEINFO set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _caseType = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CaseType
		{
			get{return _caseType ?? string.Empty;}
			set{_caseType = value;}
		}
		private string _internalNo = string.Empty;
		/// <summary>
		/// varchar 	案件编号
		/// </summary>
		public string InternalNo
		{
			get{return _internalNo ?? string.Empty;}
			set{_internalNo = value;}
		}
		private string _noticeNo = string.Empty;
		/// <summary>
		/// varchar 	通知书编号
		/// </summary>
		public string NoticeNo
		{
			get{return _noticeNo ?? string.Empty;}
			set{_noticeNo = value;}
		}
		private string _caseInfoNo = string.Empty;
		/// <summary>
		/// varchar 	案件内部编号
		/// </summary>
		public string CaseInfoNo
		{
			get{return _caseInfoNo ?? string.Empty;}
			set{_caseInfoNo = value;}
		}
		private string _companyId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CompanyId
		{
			get{return _companyId ?? string.Empty;}
			set{_companyId = value;}
		}
		private string _companyName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			get{return _companyName ?? string.Empty;}
			set{_companyName = value;}
		}
		private string _deptId = string.Empty;
		/// <summary>
		/// nvarchar 	部门编号
		/// </summary>
		public string DeptId
		{
			get{return _deptId ?? string.Empty;}
			set{_deptId = value;}
		}
		private string _deptName = string.Empty;
		/// <summary>
		/// nvarchar 	部门名称
		/// </summary>
		public string DeptName
		{
			get{return _deptName ?? string.Empty;}
			set{_deptName = value;}
		}
		private int _dataSource;
		/// <summary>
		/// int 	案件登记来源（1：手机 2：PC）
		/// </summary>
		public int DataSource
		{
			get{return _dataSource;}
			set{_dataSource = value;}
		}
		private string _reSource = string.Empty;
		/// <summary>
		/// varchar 	案件来源（多个来源使用逗号分隔）
		/// </summary>
		public string ReSource
		{
			get{return _reSource ?? string.Empty;}
			set{_reSource = value;}
		}
		private string _reSourceName = string.Empty;
		/// <summary>
		/// 案件来源中文名称
		/// </summary>
		public string ReSourceName
		{
			get{return _reSourceName ?? string.Empty;}
			set{_reSourceName = value;}
		}
		private string _rePersonelIdFist = string.Empty;
		/// <summary>
		/// nvarchar 	执法队员一（编号）
		/// </summary>
		public string RePersonelIdFist
		{
			get{return _rePersonelIdFist ?? string.Empty;}
			set{_rePersonelIdFist = value;}
		}
		private string _rePersonelIdSecond = string.Empty;
		/// <summary>
		/// nvarchar 	执法队员二（编号）
		/// </summary>
		public string RePersonelIdSecond
		{
			get{return _rePersonelIdSecond ?? string.Empty;}
			set{_rePersonelIdSecond = value;}
		}
		private string _rePersonelNameSecond = string.Empty;
		/// <summary>
		/// nvarchar 	执法队员二（姓名）
		/// </summary>
		public string RePersonelNameSecond
		{
			get{return _rePersonelNameSecond ?? string.Empty;}
			set{_rePersonelNameSecond = value;}
		}
		private string _rePersonelNameFist = string.Empty;
		/// <summary>
		/// nvarchar 	执法队员一（姓名）
		/// </summary>
		public string RePersonelNameFist
		{
			get{return _rePersonelNameFist ?? string.Empty;}
			set{_rePersonelNameFist = value;}
		}
		private string _targetType = string.Empty;
		/// <summary>
		/// nvarchar 	当事人类型
		/// </summary>
		public string TargetType
		{
			get{return _targetType ?? string.Empty;}
			set{_targetType = value;}
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
		private string _targetPaperType = string.Empty;
		/// <summary>
		/// nvarchar 	证件类型
		/// </summary>
		public string TargetPaperType
		{
			get{return _targetPaperType ?? string.Empty;}
			set{_targetPaperType = value;}
		}
		private string _targetPaperNum = string.Empty;
		/// <summary>
		/// varchar 	证件号码
		/// </summary>
		public string TargetPaperNum
		{
			get{return _targetPaperNum ?? string.Empty;}
			set{_targetPaperNum = value;}
		}
		private string _targetGender = string.Empty;
		/// <summary>
		/// 当事人姓名（1：男  0：女）
		/// </summary>
		public string TargetGender
		{
			get{return _targetGender ?? string.Empty;}
			set{_targetGender = value;}
		}
		private int _targetAge;
		/// <summary>
		/// int 	当事人年龄
		/// </summary>
		public int TargetAge
		{
			get{return _targetAge;}
			set{_targetAge = value;}
		}
		private string _targetUnit = string.Empty;
		/// <summary>
		/// nvarchar 	单位名称
		/// </summary>
		public string TargetUnit
		{
			get{return _targetUnit ?? string.Empty;}
			set{_targetUnit = value;}
		}
		private string _targetDuty = string.Empty;
		/// <summary>
		/// nvarchar 	当事人职务
		/// </summary>
		public string TargetDuty
		{
			get{return _targetDuty ?? string.Empty;}
			set{_targetDuty = value;}
		}
		private string _targetPhone = string.Empty;
		/// <summary>
		/// varchar 	当事人联系电话
		/// </summary>
		public string TargetPhone
		{
			get{return _targetPhone ?? string.Empty;}
			set{_targetPhone = value;}
		}
		private string _targetMobile = string.Empty;
		/// <summary>
		/// varchar 	当事人手机号
		/// </summary>
		public string TargetMobile
		{
			get{return _targetMobile ?? string.Empty;}
			set{_targetMobile = value;}
		}
		private string _targetZipCode = string.Empty;
		/// <summary>
		/// varchar 	邮编
		/// </summary>
		public string TargetZipCode
		{
			get{return _targetZipCode ?? string.Empty;}
			set{_targetZipCode = value;}
		}
		private string _targetEmail = string.Empty;
		/// <summary>
		/// nvarchar 	电子邮件
		/// </summary>
		public string TargetEmail
		{
			get{return _targetEmail ?? string.Empty;}
			set{_targetEmail = value;}
		}
		private string _targetSHXYM = string.Empty;
		/// <summary>
		/// 行政相对人代码_1 (统一社会信用代码)
		/// </summary>
		public string TargetSHXYM
		{
			get{return _targetSHXYM ?? string.Empty;}
			set{_targetSHXYM = value;}
		}
		private string _targetZDM = string.Empty;
		/// <summary>
		/// 行政相对人代码_2 (组织机构代码)
		/// </summary>
		public string TargetZDM
		{
			get{return _targetZDM ?? string.Empty;}
			set{_targetZDM = value;}
		}
		private string _targetGSDJ = string.Empty;
		/// <summary>
		/// 行政相对人代码_3 (工商登记码)
		/// </summary>
		public string TargetGSDJ
		{
			get{return _targetGSDJ ?? string.Empty;}
			set{_targetGSDJ = value;}
		}
		private string _targetSWDJ = string.Empty;
		/// <summary>
		/// 行政相对人代码_4 (税务登记号)
		/// </summary>
		public string TargetSWDJ
		{
			get{return _targetSWDJ ?? string.Empty;}
			set{_targetSWDJ = value;}
		}
		private string _carType = string.Empty;
		/// <summary>
		/// nvarchar 	车辆类型
		/// </summary>
		public string CarType
		{
			get{return _carType ?? string.Empty;}
			set{_carType = value;}
		}
		private string _carNo = string.Empty;
		/// <summary>
		/// nvarchar 	车牌号码
		/// </summary>
		public string CarNo
		{
			get{return _carNo ?? string.Empty;}
			set{_carNo = value;}
		}
		private string _reportName = string.Empty;
		/// <summary>
		/// nvarchar 	举报人姓名
		/// </summary>
		public string ReportName
		{
			get{return _reportName ?? string.Empty;}
			set{_reportName = value;}
		}
		private DateTime _reportData = MinDate;
		/// <summary>
		/// datetime 	举报时间（yyyy-MM-dd hh24:mm:ss）
		/// </summary>
		public DateTime ReportData
		{
			get{return _reportData;}
			set{_reportData = value;}
		}
		private string _reportPaperType = string.Empty;
		/// <summary>
		/// nvarchar 	举报人证件类型
		/// </summary>
		public string ReportPaperType
		{
			get{return _reportPaperType ?? string.Empty;}
			set{_reportPaperType = value;}
		}
		private string _reportPaperNum = string.Empty;
		/// <summary>
		/// varchar 	举报人证件号码
		/// </summary>
		public string ReportPaperNum
		{
			get{return _reportPaperNum ?? string.Empty;}
			set{_reportPaperNum = value;}
		}
		private string _reportPhone = string.Empty;
		/// <summary>
		/// varchar 	举报人联系电话
		/// </summary>
		public string ReportPhone
		{
			get{return _reportPhone ?? string.Empty;}
			set{_reportPhone = value;}
		}
		private string _reportMobile = string.Empty;
		/// <summary>
		/// varchar 	举报人手机号
		/// </summary>
		public string ReportMobile
		{
			get{return _reportMobile ?? string.Empty;}
			set{_reportMobile = value;}
		}
		private string _reportAddress = string.Empty;
		/// <summary>
		/// nvarchar 	举报人地址
		/// </summary>
		public string ReportAddress
		{
			get{return _reportAddress ?? string.Empty;}
			set{_reportAddress = value;}
		}
		private string _reportZipCode = string.Empty;
		/// <summary>
		/// varchar 	举报人邮编
		/// </summary>
		public string ReportZipCode
		{
			get{return _reportZipCode ?? string.Empty;}
			set{_reportZipCode = value;}
		}
		private string _reportEmail = string.Empty;
		/// <summary>
		/// nvarchar 	举报人电子邮件
		/// </summary>
		public string ReportEmail
		{
			get{return _reportEmail ?? string.Empty;}
			set{_reportEmail = value;}
		}
		private DateTime _caseDate = MinDate;
		/// <summary>
		/// datetime 	案发日期（yyyy-MM-dd hh24:mm:ss）
		/// </summary>
		public DateTime CaseDate
		{
			get{return _caseDate;}
			set{_caseDate = value;}
		}
		private string _roadNo = string.Empty;
		/// <summary>
		/// 路段代码
		/// </summary>
		public string RoadNo
		{
			get{return _roadNo ?? string.Empty;}
			set{_roadNo = value;}
		}
		private string _roadName = string.Empty;
		/// <summary>
		/// 路段名称
		/// </summary>
		public string RoadName
		{
			get{return _roadName ?? string.Empty;}
			set{_roadName = value;}
		}
		private string _caseAddress = string.Empty;
		/// <summary>
		/// nvarchar 	案发地址
		/// </summary>
		public string CaseAddress
		{
			get{return _caseAddress ?? string.Empty;}
			set{_caseAddress = value;}
		}
		private string _caseFact = string.Empty;
		/// <summary>
		/// nvarchar 	案情摘要
		/// </summary>
		public string CaseFact
		{
			get{return _caseFact ?? string.Empty;}
			set{_caseFact = value;}
		}
		private string _handleCaseFact = string.Empty;
		/// <summary>
		/// nvarchar 	处理审批案情摘要
		/// </summary>
		public string HandleCaseFact
		{
			get{return _handleCaseFact ?? string.Empty;}
			set{_handleCaseFact = value;}
		}
		private string _caseHurtInfo = string.Empty;
		/// <summary>
		/// nvarchar 	危害情况
		/// </summary>
		public string CaseHurtInfo
		{
			get{return _caseHurtInfo ?? string.Empty;}
			set{_caseHurtInfo = value;}
		}
		private string _punishProcess = string.Empty;
		/// <summary>
		/// int 	案件处理模式（0：未区分 1：一般程序 2：简易案件）
		/// </summary>
		public string PunishProcess
		{
			get{return _punishProcess ?? string.Empty;}
			set{_punishProcess = value;}
		}
		private int _state;
		/// <summary>
		/// int 	案件状态
		/// </summary>
		public int State
		{
			get{return _state;}
			set{_state = value;}
		}
		private int _landState;
		/// <summary>
		/// 国土案件状态
		/// </summary>
		public int LandState
		{
			get{return _landState;}
			set{_landState = value;}
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
		private string _firstTrialPersonelIdFirst = string.Empty;
		/// <summary>
		/// 初审人员一
		/// </summary>
		public string FirstTrialPersonelIdFirst
		{
			get{return _firstTrialPersonelIdFirst ?? string.Empty;}
			set{_firstTrialPersonelIdFirst = value;}
		}
		private string _firstTrialPersonelIdSecond = string.Empty;
		/// <summary>
		/// 初审人员二
		/// </summary>
		public string FirstTrialPersonelIdSecond
		{
			get{return _firstTrialPersonelIdSecond ?? string.Empty;}
			set{_firstTrialPersonelIdSecond = value;}
		}
		private string _firstTrialPersonelNameFirst = string.Empty;
		/// <summary>
		/// 初审人员一姓名
		/// </summary>
		public string FirstTrialPersonelNameFirst
		{
			get{return _firstTrialPersonelNameFirst ?? string.Empty;}
			set{_firstTrialPersonelNameFirst = value;}
		}
		private string _firstTrialPersonelNameSecond = string.Empty;
		/// <summary>
		/// 初审人员二姓名
		/// </summary>
		public string FirstTrialPersonelNameSecond
		{
			get{return _firstTrialPersonelNameSecond ?? string.Empty;}
			set{_firstTrialPersonelNameSecond = value;}
		}
		private string _reProof = string.Empty;
		/// <summary>
		/// varchar 	立案证据情况
		/// </summary>
		public string ReProof
		{
			get{return _reProof ?? string.Empty;}
			set{_reProof = value;}
		}
		private string _haProof = string.Empty;
		/// <summary>
		/// varchar 	处理证据情况
		/// </summary>
		public string HaProof
		{
			get{return _haProof ?? string.Empty;}
			set{_haProof = value;}
		}
		private string _lng = string.Empty;
		/// <summary>
		/// 经度
		/// </summary>
		public string Lng
		{
			get{return _lng ?? string.Empty;}
			set{_lng = value;}
		}
		private string _lat = string.Empty;
		/// <summary>
		/// 纬度
		/// </summary>
		public string Lat
		{
			get{return _lat ?? string.Empty;}
			set{_lat = value;}
		}
		private int _upSupervisory;
		/// <summary>
		/// int 	上报监督局（0：未上报，1：基本信息已上报，2：结果信息已上报）
		/// </summary>
		public int UpSupervisory
		{
			get{return _upSupervisory;}
			set{_upSupervisory = value;}
		}
		private int _upOthers;
		/// <summary>
		/// int 	上报其它部门（渣土车）（0：未上报，1：已上报）
		/// </summary>
		public int UpOthers
		{
			get{return _upOthers;}
			set{_upOthers = value;}
		}
		private DateTime _gDDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime GDDate
		{
			get{return _gDDate;}
			set{_gDDate = value;}
		}
		private string _tempNo = string.Empty;
		/// <summary>
		/// 暂扣单号
		/// </summary>
		public string TempNo
		{
			get{return _tempNo ?? string.Empty;}
			set{_tempNo = value;}
		}
		private string _tempId = string.Empty;
		/// <summary>
		/// 暂扣主键ID
		/// </summary>
		public string TempId
		{
			get{return _tempId ?? string.Empty;}
			set{_tempId = value;}
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
		private int _isPublic;
		/// <summary>
		/// 是否已公示
		/// </summary>
		public int IsPublic
		{
			get{return _isPublic;}
			set{_isPublic = value;}
		}
		private string _checkRecord = string.Empty;
		/// <summary>
		/// 现场检查记录
		/// </summary>
		public string CheckRecord
		{
			get{return _checkRecord ?? string.Empty;}
			set{_checkRecord = value;}
		}
		private DateTime _acceptInvestigationDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime AcceptInvestigationDate
		{
			get{return _acceptInvestigationDate;}
			set{_acceptInvestigationDate = value;}
		}
		private string _roadName1 = string.Empty;
		/// <summary>
		/// 路段名称1
		/// </summary>
		public string RoadName1
		{
			get{return _roadName1 ?? string.Empty;}
			set{_roadName1 = value;}
		}
		private string _roadName2 = string.Empty;
		/// <summary>
		/// 路段名称2
		/// </summary>
		public string RoadName2
		{
			get{return _roadName2 ?? string.Empty;}
			set{_roadName2 = value;}
		}
		private string _reference1 = string.Empty;
		/// <summary>
		/// 参照物1
		/// </summary>
		public string Reference1
		{
			get{return _reference1 ?? string.Empty;}
			set{_reference1 = value;}
		}
		private string _reference2 = string.Empty;
		/// <summary>
		/// 参照物2
		/// </summary>
		public string Reference2
		{
			get{return _reference2 ?? string.Empty;}
			set{_reference2 = value;}
		}
		private int _isRectification;
		/// <summary>
		/// 是否开具整改单
		/// </summary>
		public int IsRectification
		{
			get{return _isRectification;}
			set{_isRectification = value;}
		}
		private int _isTempDetainInfo;
		/// <summary>
		/// 是否开具暂扣单
		/// </summary>
		public int IsTempDetainInfo
		{
			get{return _isTempDetainInfo;}
			set{_isTempDetainInfo = value;}
		}
		#endregion


        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string FileAddress { get; set; }
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishCaseinfoEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishCaseinfoEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishCaseinfoEntity();
          			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_CASEINFO_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseType) || fields.Contains("*"))
				tmp.CaseType = dr[Parm_INF_PUNISH_CASEINFO_CaseType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_InternalNo) || fields.Contains("*"))
				tmp.InternalNo = dr[Parm_INF_PUNISH_CASEINFO_InternalNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_NoticeNo) || fields.Contains("*"))
				tmp.NoticeNo = dr[Parm_INF_PUNISH_CASEINFO_NoticeNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseInfoNo) || fields.Contains("*"))
				tmp.CaseInfoNo = dr[Parm_INF_PUNISH_CASEINFO_CaseInfoNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CompanyId) || fields.Contains("*"))
				tmp.CompanyId = dr[Parm_INF_PUNISH_CASEINFO_CompanyId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CompanyName) || fields.Contains("*"))
				tmp.CompanyName = dr[Parm_INF_PUNISH_CASEINFO_CompanyName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_DeptId) || fields.Contains("*"))
				tmp.DeptId = dr[Parm_INF_PUNISH_CASEINFO_DeptId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_DeptName) || fields.Contains("*"))
				tmp.DeptName = dr[Parm_INF_PUNISH_CASEINFO_DeptName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_DataSource) || fields.Contains("*"))
				tmp.DataSource = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_DataSource].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReSource) || fields.Contains("*"))
				tmp.ReSource = dr[Parm_INF_PUNISH_CASEINFO_ReSource].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReSourceName) || fields.Contains("*"))
				tmp.ReSourceName = dr[Parm_INF_PUNISH_CASEINFO_ReSourceName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RePersonelIdFist) || fields.Contains("*"))
				tmp.RePersonelIdFist = dr[Parm_INF_PUNISH_CASEINFO_RePersonelIdFist].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RePersonelIdSecond) || fields.Contains("*"))
				tmp.RePersonelIdSecond = dr[Parm_INF_PUNISH_CASEINFO_RePersonelIdSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RePersonelNameSecond) || fields.Contains("*"))
				tmp.RePersonelNameSecond = dr[Parm_INF_PUNISH_CASEINFO_RePersonelNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RePersonelNameFist) || fields.Contains("*"))
				tmp.RePersonelNameFist = dr[Parm_INF_PUNISH_CASEINFO_RePersonelNameFist].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetType) || fields.Contains("*"))
				tmp.TargetType = dr[Parm_INF_PUNISH_CASEINFO_TargetType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetName) || fields.Contains("*"))
				tmp.TargetName = dr[Parm_INF_PUNISH_CASEINFO_TargetName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetAddress) || fields.Contains("*"))
				tmp.TargetAddress = dr[Parm_INF_PUNISH_CASEINFO_TargetAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetPaperType) || fields.Contains("*"))
				tmp.TargetPaperType = dr[Parm_INF_PUNISH_CASEINFO_TargetPaperType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetPaperNum) || fields.Contains("*"))
				tmp.TargetPaperNum = dr[Parm_INF_PUNISH_CASEINFO_TargetPaperNum].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetGender) || fields.Contains("*"))
				tmp.TargetGender = dr[Parm_INF_PUNISH_CASEINFO_TargetGender].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetAge) || fields.Contains("*"))
				tmp.TargetAge = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_TargetAge].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetUnit) || fields.Contains("*"))
				tmp.TargetUnit = dr[Parm_INF_PUNISH_CASEINFO_TargetUnit].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetDuty) || fields.Contains("*"))
				tmp.TargetDuty = dr[Parm_INF_PUNISH_CASEINFO_TargetDuty].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetPhone) || fields.Contains("*"))
				tmp.TargetPhone = dr[Parm_INF_PUNISH_CASEINFO_TargetPhone].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetMobile) || fields.Contains("*"))
				tmp.TargetMobile = dr[Parm_INF_PUNISH_CASEINFO_TargetMobile].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetZipCode) || fields.Contains("*"))
				tmp.TargetZipCode = dr[Parm_INF_PUNISH_CASEINFO_TargetZipCode].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetEmail) || fields.Contains("*"))
				tmp.TargetEmail = dr[Parm_INF_PUNISH_CASEINFO_TargetEmail].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetSHXYM) || fields.Contains("*"))
				tmp.TargetSHXYM = dr[Parm_INF_PUNISH_CASEINFO_TargetSHXYM].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetZDM) || fields.Contains("*"))
				tmp.TargetZDM = dr[Parm_INF_PUNISH_CASEINFO_TargetZDM].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetGSDJ) || fields.Contains("*"))
				tmp.TargetGSDJ = dr[Parm_INF_PUNISH_CASEINFO_TargetGSDJ].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TargetSWDJ) || fields.Contains("*"))
				tmp.TargetSWDJ = dr[Parm_INF_PUNISH_CASEINFO_TargetSWDJ].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CarType) || fields.Contains("*"))
				tmp.CarType = dr[Parm_INF_PUNISH_CASEINFO_CarType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CarNo) || fields.Contains("*"))
				tmp.CarNo = dr[Parm_INF_PUNISH_CASEINFO_CarNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportName) || fields.Contains("*"))
				tmp.ReportName = dr[Parm_INF_PUNISH_CASEINFO_ReportName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportData) || fields.Contains("*"))
				tmp.ReportData = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_ReportData].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportPaperType) || fields.Contains("*"))
				tmp.ReportPaperType = dr[Parm_INF_PUNISH_CASEINFO_ReportPaperType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportPaperNum) || fields.Contains("*"))
				tmp.ReportPaperNum = dr[Parm_INF_PUNISH_CASEINFO_ReportPaperNum].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportPhone) || fields.Contains("*"))
				tmp.ReportPhone = dr[Parm_INF_PUNISH_CASEINFO_ReportPhone].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportMobile) || fields.Contains("*"))
				tmp.ReportMobile = dr[Parm_INF_PUNISH_CASEINFO_ReportMobile].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportAddress) || fields.Contains("*"))
				tmp.ReportAddress = dr[Parm_INF_PUNISH_CASEINFO_ReportAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportZipCode) || fields.Contains("*"))
				tmp.ReportZipCode = dr[Parm_INF_PUNISH_CASEINFO_ReportZipCode].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReportEmail) || fields.Contains("*"))
				tmp.ReportEmail = dr[Parm_INF_PUNISH_CASEINFO_ReportEmail].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseDate) || fields.Contains("*"))
				tmp.CaseDate = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_CaseDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RoadNo) || fields.Contains("*"))
				tmp.RoadNo = dr[Parm_INF_PUNISH_CASEINFO_RoadNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RoadName) || fields.Contains("*"))
				tmp.RoadName = dr[Parm_INF_PUNISH_CASEINFO_RoadName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseAddress) || fields.Contains("*"))
				tmp.CaseAddress = dr[Parm_INF_PUNISH_CASEINFO_CaseAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseFact) || fields.Contains("*"))
				tmp.CaseFact = dr[Parm_INF_PUNISH_CASEINFO_CaseFact].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_HandleCaseFact) || fields.Contains("*"))
				tmp.HandleCaseFact = dr[Parm_INF_PUNISH_CASEINFO_HandleCaseFact].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CaseHurtInfo) || fields.Contains("*"))
				tmp.CaseHurtInfo = dr[Parm_INF_PUNISH_CASEINFO_CaseHurtInfo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_PunishProcess) || fields.Contains("*"))
				tmp.PunishProcess = dr[Parm_INF_PUNISH_CASEINFO_PunishProcess].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_State) || fields.Contains("*"))
				tmp.State = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_State].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_LandState) || fields.Contains("*"))
				tmp.LandState = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_LandState].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UdPersonelIdFirst) || fields.Contains("*"))
				tmp.UdPersonelIdFirst = dr[Parm_INF_PUNISH_CASEINFO_UdPersonelIdFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UdPersonelIdSecond) || fields.Contains("*"))
				tmp.UdPersonelIdSecond = dr[Parm_INF_PUNISH_CASEINFO_UdPersonelIdSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UdPersonelNameFirst) || fields.Contains("*"))
				tmp.UdPersonelNameFirst = dr[Parm_INF_PUNISH_CASEINFO_UdPersonelNameFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UdPersonelNameSecond) || fields.Contains("*"))
				tmp.UdPersonelNameSecond = dr[Parm_INF_PUNISH_CASEINFO_UdPersonelNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdFirst) || fields.Contains("*"))
				tmp.FirstTrialPersonelIdFirst = dr[Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdSecond) || fields.Contains("*"))
				tmp.FirstTrialPersonelIdSecond = dr[Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameFirst) || fields.Contains("*"))
				tmp.FirstTrialPersonelNameFirst = dr[Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameSecond) || fields.Contains("*"))
				tmp.FirstTrialPersonelNameSecond = dr[Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_ReProof) || fields.Contains("*"))
				tmp.ReProof = dr[Parm_INF_PUNISH_CASEINFO_ReProof].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_HaProof) || fields.Contains("*"))
				tmp.HaProof = dr[Parm_INF_PUNISH_CASEINFO_HaProof].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Lng) || fields.Contains("*"))
				tmp.Lng = dr[Parm_INF_PUNISH_CASEINFO_Lng].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Lat) || fields.Contains("*"))
				tmp.Lat = dr[Parm_INF_PUNISH_CASEINFO_Lat].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UpSupervisory) || fields.Contains("*"))
				tmp.UpSupervisory = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_UpSupervisory].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UpOthers) || fields.Contains("*"))
				tmp.UpOthers = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_UpOthers].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_GDDate) || fields.Contains("*"))
				tmp.GDDate = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_GDDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TempNo) || fields.Contains("*"))
				tmp.TempNo = dr[Parm_INF_PUNISH_CASEINFO_TempNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_TempId) || fields.Contains("*"))
				tmp.TempId = dr[Parm_INF_PUNISH_CASEINFO_TempId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_CASEINFO_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_CASEINFO_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_CASEINFO_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_CASEINFO_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_CASEINFO_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_UpdateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_IsSync) || fields.Contains("*"))
				tmp.IsSync = dr[Parm_INF_PUNISH_CASEINFO_IsSync].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_IsPublic) || fields.Contains("*"))
				tmp.IsPublic = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_IsPublic].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_CheckRecord) || fields.Contains("*"))
				tmp.CheckRecord = dr[Parm_INF_PUNISH_CASEINFO_CheckRecord].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_AcceptInvestigationDate) || fields.Contains("*"))
				tmp.AcceptInvestigationDate = DateTime.Parse(dr[Parm_INF_PUNISH_CASEINFO_AcceptInvestigationDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RoadName1) || fields.Contains("*"))
				tmp.RoadName1 = dr[Parm_INF_PUNISH_CASEINFO_RoadName1].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_RoadName2) || fields.Contains("*"))
				tmp.RoadName2 = dr[Parm_INF_PUNISH_CASEINFO_RoadName2].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Reference1) || fields.Contains("*"))
				tmp.Reference1 = dr[Parm_INF_PUNISH_CASEINFO_Reference1].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_Reference2) || fields.Contains("*"))
				tmp.Reference2 = dr[Parm_INF_PUNISH_CASEINFO_Reference2].ToString();
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_IsRectification) || fields.Contains("*"))
				tmp.IsRectification = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_IsRectification].ToString());
			if (fields.Contains(Parm_INF_PUNISH_CASEINFO_IsTempDetainInfo) || fields.Contains("*"))
				tmp.IsTempDetainInfo = int.Parse(dr[Parm_INF_PUNISH_CASEINFO_IsTempDetainInfo].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_caseinfo">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishCaseinfoEntity inf_punish_caseinfo, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_caseinfo.CaseType;
				parms[1].Value = inf_punish_caseinfo.InternalNo;
				parms[2].Value = inf_punish_caseinfo.NoticeNo;
				parms[3].Value = inf_punish_caseinfo.CaseInfoNo;
				parms[4].Value = inf_punish_caseinfo.CompanyId;
				parms[5].Value = inf_punish_caseinfo.CompanyName;
				parms[6].Value = inf_punish_caseinfo.DeptId;
				parms[7].Value = inf_punish_caseinfo.DeptName;
				parms[8].Value = inf_punish_caseinfo.DataSource;
				parms[9].Value = inf_punish_caseinfo.ReSource;
				parms[10].Value = inf_punish_caseinfo.ReSourceName;
				parms[11].Value = inf_punish_caseinfo.RePersonelIdFist;
				parms[12].Value = inf_punish_caseinfo.RePersonelIdSecond;
				parms[13].Value = inf_punish_caseinfo.RePersonelNameSecond;
				parms[14].Value = inf_punish_caseinfo.RePersonelNameFist;
				parms[15].Value = inf_punish_caseinfo.TargetType;
				parms[16].Value = inf_punish_caseinfo.TargetName;
				parms[17].Value = inf_punish_caseinfo.TargetAddress;
				parms[18].Value = inf_punish_caseinfo.TargetPaperType;
				parms[19].Value = inf_punish_caseinfo.TargetPaperNum;
				parms[20].Value = inf_punish_caseinfo.TargetGender;
				parms[21].Value = inf_punish_caseinfo.TargetAge;
				parms[22].Value = inf_punish_caseinfo.TargetUnit;
				parms[23].Value = inf_punish_caseinfo.TargetDuty;
				parms[24].Value = inf_punish_caseinfo.TargetPhone;
				parms[25].Value = inf_punish_caseinfo.TargetMobile;
				parms[26].Value = inf_punish_caseinfo.TargetZipCode;
				parms[27].Value = inf_punish_caseinfo.TargetEmail;
				parms[28].Value = inf_punish_caseinfo.TargetSHXYM;
				parms[29].Value = inf_punish_caseinfo.TargetZDM;
				parms[30].Value = inf_punish_caseinfo.TargetGSDJ;
				parms[31].Value = inf_punish_caseinfo.TargetSWDJ;
				parms[32].Value = inf_punish_caseinfo.CarType;
				parms[33].Value = inf_punish_caseinfo.CarNo;
				parms[34].Value = inf_punish_caseinfo.ReportName;
				parms[35].Value = inf_punish_caseinfo.ReportData;
				parms[36].Value = inf_punish_caseinfo.ReportPaperType;
				parms[37].Value = inf_punish_caseinfo.ReportPaperNum;
				parms[38].Value = inf_punish_caseinfo.ReportPhone;
				parms[39].Value = inf_punish_caseinfo.ReportMobile;
				parms[40].Value = inf_punish_caseinfo.ReportAddress;
				parms[41].Value = inf_punish_caseinfo.ReportZipCode;
				parms[42].Value = inf_punish_caseinfo.ReportEmail;
				parms[43].Value = inf_punish_caseinfo.CaseDate;
				parms[44].Value = inf_punish_caseinfo.RoadNo;
				parms[45].Value = inf_punish_caseinfo.RoadName;
				parms[46].Value = inf_punish_caseinfo.CaseAddress;
				parms[47].Value = inf_punish_caseinfo.CaseFact;
				parms[48].Value = inf_punish_caseinfo.HandleCaseFact;
				parms[49].Value = inf_punish_caseinfo.CaseHurtInfo;
				parms[50].Value = inf_punish_caseinfo.PunishProcess;
				parms[51].Value = inf_punish_caseinfo.State;
				parms[52].Value = inf_punish_caseinfo.LandState;
				parms[53].Value = inf_punish_caseinfo.UdPersonelIdFirst;
				parms[54].Value = inf_punish_caseinfo.UdPersonelIdSecond;
				parms[55].Value = inf_punish_caseinfo.UdPersonelNameFirst;
				parms[56].Value = inf_punish_caseinfo.UdPersonelNameSecond;
				parms[57].Value = inf_punish_caseinfo.FirstTrialPersonelIdFirst;
				parms[58].Value = inf_punish_caseinfo.FirstTrialPersonelIdSecond;
				parms[59].Value = inf_punish_caseinfo.FirstTrialPersonelNameFirst;
				parms[60].Value = inf_punish_caseinfo.FirstTrialPersonelNameSecond;
				parms[61].Value = inf_punish_caseinfo.ReProof;
				parms[62].Value = inf_punish_caseinfo.HaProof;
				parms[63].Value = inf_punish_caseinfo.Lng;
				parms[64].Value = inf_punish_caseinfo.Lat;
				parms[65].Value = inf_punish_caseinfo.UpSupervisory;
				parms[66].Value = inf_punish_caseinfo.UpOthers;
				parms[67].Value = inf_punish_caseinfo.GDDate;
				parms[68].Value = inf_punish_caseinfo.TempNo;
				parms[69].Value = inf_punish_caseinfo.TempId;
				parms[70].Value = inf_punish_caseinfo.RowStatus;
				parms[71].Value = inf_punish_caseinfo.CreatorId;
				parms[72].Value = inf_punish_caseinfo.CreateBy;
				parms[73].Value = inf_punish_caseinfo.CreateOn;
				parms[74].Value = inf_punish_caseinfo.UpdateId;
				parms[75].Value = inf_punish_caseinfo.UpdateBy;
				parms[76].Value = inf_punish_caseinfo.UpdateOn;
				parms[77].Value = inf_punish_caseinfo.IsSync;
				parms[78].Value = inf_punish_caseinfo.IsPublic;
				parms[79].Value = inf_punish_caseinfo.CheckRecord;
				parms[80].Value = inf_punish_caseinfo.AcceptInvestigationDate;
				parms[81].Value = inf_punish_caseinfo.RoadName1;
				parms[82].Value = inf_punish_caseinfo.RoadName2;
				parms[83].Value = inf_punish_caseinfo.Reference1;
				parms[84].Value = inf_punish_caseinfo.Reference2;
				parms[85].Value = inf_punish_caseinfo.IsRectification;
				parms[86].Value = inf_punish_caseinfo.IsTempDetainInfo;
                parms[87].Value = inf_punish_caseinfo.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishCaseinfoEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_CASEINFO_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_InternalNo, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_NoticeNo, SqlDbType.VarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseInfoNo, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_DeptId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_DeptName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_DataSource, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReSourceName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RePersonelIdFist, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RePersonelIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RePersonelNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RePersonelNameFist, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetGender, SqlDbType.VarChar, 1),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetAge, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetUnit, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetDuty, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetPhone, SqlDbType.VarChar, 13),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetMobile, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetZipCode, SqlDbType.VarChar, 6),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetEmail, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetSHXYM, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetZDM, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetGSDJ, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TargetSWDJ, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CarType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CarNo, SqlDbType.VarChar, 7),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportData, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportPhone, SqlDbType.VarChar, 13),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportMobile, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportZipCode, SqlDbType.VarChar, 6),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReportEmail, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RoadNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RoadName, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseAddress, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseFact, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_HandleCaseFact, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CaseHurtInfo, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_PunishProcess, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_LandState, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UdPersonelIdFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UdPersonelIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UdPersonelNameFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UdPersonelNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_FirstTrialPersonelNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_ReProof, SqlDbType.VarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_HaProof, SqlDbType.VarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_Lng, SqlDbType.VarChar, 9),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_Lat, SqlDbType.VarChar, 9),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UpSupervisory, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UpOthers, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_GDDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TempNo, SqlDbType.NVarChar, 150),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_TempId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_UpdateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_IsSync, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_IsPublic, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_CheckRecord, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_AcceptInvestigationDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RoadName1, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_RoadName2, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_Reference1, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_Reference2, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_IsRectification, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_CASEINFO_IsTempDetainInfo, SqlDbType.Int, 10),
                    new SqlParameter(Parm_INF_PUNISH_CASEINFO_Id, SqlDbType.NVarChar, 50)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_CASEINFO_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                       
