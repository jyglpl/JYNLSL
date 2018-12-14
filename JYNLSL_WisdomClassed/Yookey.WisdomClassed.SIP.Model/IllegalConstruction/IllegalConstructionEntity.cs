//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IllegalConstructionEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/09/22 10:37:10
//  功能描述：IllegalConstruction表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.IllegalConstruction
{
    /// <summary>
    /// 违法建设拆除基本信息表
    /// </summary>
    [Serializable]
    public class IllegalConstructionEntity : ModelImp.BaseModel<IllegalConstructionEntity>
    {
        public IllegalConstructionEntity()
        {
            TB_Name = TB_IllegalConstruction;
            Parm_Id = Parm_IllegalConstruction_Id;
            Parm_Version = Parm_IllegalConstruction_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_IllegalConstruction_Insert;
            Sql_Update = Sql_IllegalConstruction_Update;
            Sql_Delete = Sql_IllegalConstruction_Delete;
        }
        #region Const of table IllegalConstruction
        /// <summary>
        /// Table IllegalConstruction
        /// </summary>
        public const string TB_IllegalConstruction = "IllegalConstruction";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AdvertisementType
        /// </summary>
        public const string Parm_IllegalConstruction_AdvertisementType = "AdvertisementType";
        /// <summary>
        /// Parm ApplicationMobile
        /// </summary>
        public const string Parm_IllegalConstruction_ApplicationMobile = "ApplicationMobile";
        /// <summary>
        /// Parm ApplicationType
        /// </summary>
        public const string Parm_IllegalConstruction_ApplicationType = "ApplicationType";
        /// <summary>
        /// Parm ApplicationUserId
        /// </summary>
        public const string Parm_IllegalConstruction_ApplicationUserId = "ApplicationUserId";
        /// <summary>
        /// Parm ApplicationUserName
        /// </summary>
        public const string Parm_IllegalConstruction_ApplicationUserName = "ApplicationUserName";
        /// <summary>
        /// Parm AreaOfStructure
        /// </summary>
        public const string Parm_IllegalConstruction_AreaOfStructure = "AreaOfStructure";
        /// <summary>
        /// Parm BrigadeSatisfaction
        /// </summary>
        public const string Parm_IllegalConstruction_BrigadeSatisfaction = "BrigadeSatisfaction";
        /// <summary>
        /// Parm CaseInfoNo
        /// </summary>
        public const string Parm_IllegalConstruction_CaseInfoNo = "CaseInfoNo";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_IllegalConstruction_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_IllegalConstruction_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_IllegalConstruction_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_IllegalConstruction_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_IllegalConstruction_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DataSource
        /// </summary>
        public const string Parm_IllegalConstruction_DataSource = "DataSource";
        /// <summary>
        /// Parm DataSourceNum
        /// </summary>
        public const string Parm_IllegalConstruction_DataSourceNum = "DataSourceNum";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_IllegalConstruction_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_IllegalConstruction_DeptName = "DeptName";
        /// <summary>
        /// Parm DismantleArea
        /// </summary>
        public const string Parm_IllegalConstruction_DismantleArea = "DismantleArea";
        /// <summary>
        /// Parm DismantleCompanyId
        /// </summary>
        public const string Parm_IllegalConstruction_DismantleCompanyId = "DismantleCompanyId";
        /// <summary>
        /// Parm DismantleLetterOfPresentation
        /// </summary>
        public const string Parm_IllegalConstruction_DismantleLetterOfPresentation = "DismantleLetterOfPresentation";
        /// <summary>
        /// Parm DismantleOnPrice
        /// </summary>
        public const string Parm_IllegalConstruction_DismantleOnPrice = "DismantleOnPrice";
        /// <summary>
        /// Parm DismantlingDate
        /// </summary>
        public const string Parm_IllegalConstruction_DismantlingDate = "DismantlingDate";
        /// <summary>
        /// Parm DismantlingType
        /// </summary>
        public const string Parm_IllegalConstruction_DismantlingType = "DismantlingType";
        /// <summary>
        /// Parm EquipmentRequirements
        /// </summary>
        public const string Parm_IllegalConstruction_EquipmentRequirements = "EquipmentRequirements";
        /// <summary>
        /// Parm Factor
        /// </summary>
        public const string Parm_IllegalConstruction_Factor = "Factor";
        /// <summary>
        /// Parm FloorSpace
        /// </summary>
        public const string Parm_IllegalConstruction_FloorSpace = "FloorSpace";
        /// <summary>
        /// Parm GarbageCar
        /// </summary>
        public const string Parm_IllegalConstruction_GarbageCar = "GarbageCar";
        /// <summary>
        /// Parm GarbageCarOnPrice
        /// </summary>
        public const string Parm_IllegalConstruction_GarbageCarOnPrice = "GarbageCarOnPrice";
        /// <summary>
        /// Parm GarbageTon
        /// </summary>
        public const string Parm_IllegalConstruction_GarbageTon = "GarbageTon";
        /// <summary>
        /// Parm Height
        /// </summary>
        public const string Parm_IllegalConstruction_Height = "Height";
        /// <summary>
        /// Parm HousStructure
        /// </summary>
        public const string Parm_IllegalConstruction_HousStructure = "HousStructure";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_IllegalConstruction_Id = "Id";
        /// <summary>
        /// Parm LeaderSatisfaction
        /// </summary>
        public const string Parm_IllegalConstruction_LeaderSatisfaction = "LeaderSatisfaction";
        /// <summary>
        /// Parm Length
        /// </summary>
        public const string Parm_IllegalConstruction_Length = "Length";
        /// <summary>
        /// Parm LetterOfPresentation
        /// </summary>
        public const string Parm_IllegalConstruction_LetterOfPresentation = "LetterOfPresentation";
        /// <summary>
        /// Parm LetterOfPresentationCollectionPlace
        /// </summary>
        public const string Parm_IllegalConstruction_LetterOfPresentationCollectionPlace = "LetterOfPresentationCollectionPlace";
        /// <summary>
        /// Parm LetterOfPresentationSetTime
        /// </summary>
        public const string Parm_IllegalConstruction_LetterOfPresentationSetTime = "LetterOfPresentationSetTime";
        /// <summary>
        /// Parm Manpower
        /// </summary>
        public const string Parm_IllegalConstruction_Manpower = "Manpower";
        /// <summary>
        /// Parm ManpowerOnPrice
        /// </summary>
        public const string Parm_IllegalConstruction_ManpowerOnPrice = "ManpowerOnPrice";
        /// <summary>
        /// Parm NoticeNo
        /// </summary>
        public const string Parm_IllegalConstruction_NoticeNo = "NoticeNo";
        /// <summary>
        /// Parm ReportDataSource
        /// </summary>
        public const string Parm_IllegalConstruction_ReportDataSource = "ReportDataSource";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_IllegalConstruction_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SecurityWindow
        /// </summary>
        public const string Parm_IllegalConstruction_SecurityWindow = "SecurityWindow";
        /// <summary>
        /// Parm SecurityWindowOnPrice
        /// </summary>
        public const string Parm_IllegalConstruction_SecurityWindowOnPrice = "SecurityWindowOnPrice";
        /// <summary>
        /// Parm SettlementType
        /// </summary>
        public const string Parm_IllegalConstruction_SettlementType = "SettlementType";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_IllegalConstruction_State = "State";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_IllegalConstruction_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetMobile
        /// </summary>
        public const string Parm_IllegalConstruction_TargetMobile = "TargetMobile";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_IllegalConstruction_TargetName = "TargetName";
        /// <summary>
        /// Parm TargetType
        /// </summary>
        public const string Parm_IllegalConstruction_TargetType = "TargetType";
        /// <summary>
        /// Parm UnbuiltDate
        /// </summary>
        public const string Parm_IllegalConstruction_UnbuiltDate = "UnbuiltDate";
        /// <summary>
        /// Parm UnbuiltState
        /// </summary>
        public const string Parm_IllegalConstruction_UnbuiltState = "UnbuiltState";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_IllegalConstruction_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_IllegalConstruction_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_IllegalConstruction_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_IllegalConstruction_Version = "Version";
        /// <summary>
        /// Parm VideoIdNo
        /// </summary>
        public const string Parm_IllegalConstruction_VideoIdNo = "VideoIdNo";
        /// <summary>
        /// Parm WailOnPrice
        /// </summary>
        public const string Parm_IllegalConstruction_WailOnPrice = "WailOnPrice";
        /// <summary>
        /// Parm Wall
        /// </summary>
        public const string Parm_IllegalConstruction_Wall = "Wall";
        /// <summary>
        /// Parm WholeReason
        /// </summary>
        public const string Parm_IllegalConstruction_WholeReason = "WholeReason";
        /// <summary>
        /// Parm Widht
        /// </summary>
        public const string Parm_IllegalConstruction_Widht = "Widht";
        /// <summary>
        /// Insert Query Of IllegalConstruction
        /// </summary>
        public const string Sql_IllegalConstruction_Insert = "insert into IllegalConstruction(AdvertisementType,ApplicationMobile,ApplicationType,ApplicationUserId,ApplicationUserName,AreaOfStructure,BrigadeSatisfaction,CaseInfoNo,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DataSource,DataSourceNum,DeptId,DeptName,DismantleArea,DismantleCompanyId,DismantleLetterOfPresentation,DismantleOnPrice,DismantlingDate,DismantlingType,EquipmentRequirements,Factor,FloorSpace,GarbageCar,GarbageCarOnPrice,GarbageTon,Height,HousStructure,LeaderSatisfaction,Length,LetterOfPresentation,LetterOfPresentationCollectionPlace,LetterOfPresentationSetTime,Manpower,ManpowerOnPrice,NoticeNo,ReportDataSource,RowStatus,SecurityWindow,SecurityWindowOnPrice,SettlementType,State,TargetAddress,TargetMobile,TargetName,TargetType,UnbuiltDate,UnbuiltState,UpdateBy,UpdateId,UpdateOn,VideoIdNo,WailOnPrice,Wall,WholeReason,Widht,Id) values(@AdvertisementType,@ApplicationMobile,@ApplicationType,@ApplicationUserId,@ApplicationUserName,@AreaOfStructure,@BrigadeSatisfaction,@CaseInfoNo,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DataSource,@DataSourceNum,@DeptId,@DeptName,@DismantleArea,@DismantleCompanyId,@DismantleLetterOfPresentation,@DismantleOnPrice,@DismantlingDate,@DismantlingType,@EquipmentRequirements,@Factor,@FloorSpace,@GarbageCar,@GarbageCarOnPrice,@GarbageTon,@Height,@HousStructure,@LeaderSatisfaction,@Length,@LetterOfPresentation,@LetterOfPresentationCollectionPlace,@LetterOfPresentationSetTime,@Manpower,@ManpowerOnPrice,@NoticeNo,@ReportDataSource,@RowStatus,@SecurityWindow,@SecurityWindowOnPrice,@SettlementType,@State,@TargetAddress,@TargetMobile,@TargetName,@TargetType,@UnbuiltDate,@UnbuiltState,@UpdateBy,@UpdateId,@UpdateOn,@VideoIdNo,@WailOnPrice,@Wall,@WholeReason,@Widht,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of IllegalConstruction
        /// </summary>
        public const string Sql_IllegalConstruction_Update = "update IllegalConstruction set AdvertisementType=@AdvertisementType,ApplicationMobile=@ApplicationMobile,ApplicationType=@ApplicationType,ApplicationUserId=@ApplicationUserId,ApplicationUserName=@ApplicationUserName,AreaOfStructure=@AreaOfStructure,BrigadeSatisfaction=@BrigadeSatisfaction,CaseInfoNo=@CaseInfoNo,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataSource=@DataSource,DataSourceNum=@DataSourceNum,DeptId=@DeptId,DeptName=@DeptName,DismantleArea=@DismantleArea,DismantleCompanyId=@DismantleCompanyId,DismantleLetterOfPresentation=@DismantleLetterOfPresentation,DismantleOnPrice=@DismantleOnPrice,DismantlingDate=@DismantlingDate,DismantlingType=@DismantlingType,EquipmentRequirements=@EquipmentRequirements,Factor=@Factor,FloorSpace=@FloorSpace,GarbageCar=@GarbageCar,GarbageCarOnPrice=@GarbageCarOnPrice,GarbageTon=@GarbageTon,Height=@Height,HousStructure=@HousStructure,LeaderSatisfaction=@LeaderSatisfaction,Length=@Length,LetterOfPresentation=@LetterOfPresentation,LetterOfPresentationCollectionPlace=@LetterOfPresentationCollectionPlace,LetterOfPresentationSetTime=@LetterOfPresentationSetTime,Manpower=@Manpower,ManpowerOnPrice=@ManpowerOnPrice,NoticeNo=@NoticeNo,ReportDataSource=@ReportDataSource,RowStatus=@RowStatus,SecurityWindow=@SecurityWindow,SecurityWindowOnPrice=@SecurityWindowOnPrice,SettlementType=@SettlementType,State=@State,TargetAddress=@TargetAddress,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetType=@TargetType,UnbuiltDate=@UnbuiltDate,UnbuiltState=@UnbuiltState,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,VideoIdNo=@VideoIdNo,WailOnPrice=@WailOnPrice,Wall=@Wall,WholeReason=@WholeReason,Widht=@Widht where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_IllegalConstruction_Delete = "update IllegalConstruction set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CaseInfoNo
        {
            get { return _caseInfoNo ?? string.Empty; }
            set { _caseInfoNo = value; }
        }
        private string _companyId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _companyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            get { return _companyName ?? string.Empty; }
            set { _companyName = value; }
        }
        private string _deptId = string.Empty;
        /// <summary>
        /// nvarchar 	部门编号
        /// </summary>
        public string DeptId
        {
            get { return _deptId ?? string.Empty; }
            set { _deptId = value; }
        }
        private string _deptName = string.Empty;
        /// <summary>
        /// nvarchar 	部门名称
        /// </summary>
        public string DeptName
        {
            get { return _deptName ?? string.Empty; }
            set { _deptName = value; }
        }
        private string _applicationType = string.Empty;
        /// <summary>
        /// 字典：申请类别
        /// </summary>
        public string ApplicationType
        {
            get { return _applicationType ?? string.Empty; }
            set { _applicationType = value; }
        }
        private string _applicationUserId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationUserId
        {
            get { return _applicationUserId ?? string.Empty; }
            set { _applicationUserId = value; }
        }
        private string _applicationUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationUserName
        {
            get { return _applicationUserName ?? string.Empty; }
            set { _applicationUserName = value; }
        }
        private string _applicationMobile = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationMobile
        {
            get { return _applicationMobile ?? string.Empty; }
            set { _applicationMobile = value; }
        }
        private string _dataSource = string.Empty;
        /// <summary>
        /// 字典：违建来源
        /// </summary>
        public string DataSource
        {
            get { return _dataSource ?? string.Empty; }
            set { _dataSource = value; }
        }
        private string _dataSourceNum = string.Empty;
        /// <summary>
        /// 来源编号
        /// </summary>
        public string DataSourceNum
        {
            get { return _dataSourceNum ?? string.Empty; }
            set { _dataSourceNum = value; }
        }
        private string _reportDataSource = string.Empty;
        /// <summary>
        /// 举报来源
        /// </summary>
        public string ReportDataSource
        {
            get { return _reportDataSource ?? string.Empty; }
            set { _reportDataSource = value; }
        }
        private string _length = string.Empty;
        /// <summary>
        /// 长
        /// </summary>
        public string Length
        {
            get { return _length ?? string.Empty; }
            set { _length = value; }
        }
        private string _widht = string.Empty;
        /// <summary>
        /// 宽
        /// </summary>
        public string Widht
        {
            get { return _widht ?? string.Empty; }
            set { _widht = value; }
        }
        private string _height = string.Empty;
        /// <summary>
        /// 高
        /// </summary>
        public string Height
        {
            get { return _height ?? string.Empty; }
            set { _height = value; }
        }
        private string _unbuiltState = string.Empty;
        /// <summary>
        /// 字典：违建设状态
        /// </summary>
        public string UnbuiltState
        {
            get { return _unbuiltState ?? string.Empty; }
            set { _unbuiltState = value; }
        }
        private string _unbuiltDate = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UnbuiltDate
        {
            get { return _unbuiltDate ?? string.Empty; }
            set { _unbuiltDate = value; }
        }
        private string _targetName = string.Empty;
        /// <summary>
        /// 当事人
        /// </summary>
        public string TargetName
        {
            get { return _targetName ?? string.Empty; }
            set { _targetName = value; }
        }
        private string _targetAddress = string.Empty;
        /// <summary>
        /// 地点
        /// </summary>
        public string TargetAddress
        {
            get { return _targetAddress ?? string.Empty; }
            set { _targetAddress = value; }
        }
        private string _targetType = string.Empty;
        /// <summary>
        /// 当事人类别
        /// </summary>
        public string TargetType
        {
            get { return _targetType ?? string.Empty; }
            set { _targetType = value; }
        }
        private string _targetMobile = string.Empty;
        /// <summary>
        /// 当事人联系电话
        /// </summary>
        public string TargetMobile
        {
            get { return _targetMobile ?? string.Empty; }
            set { _targetMobile = value; }
        }
        private string _housStructure = string.Empty;
        /// <summary>
        /// 字典：房屋结构
        /// </summary>
        public string HousStructure
        {
            get { return _housStructure ?? string.Empty; }
            set { _housStructure = value; }
        }
        private string _floorSpace = string.Empty;
        /// <summary>
        /// 占地面积
        /// </summary>
        public string FloorSpace
        {
            get { return _floorSpace ?? string.Empty; }
            set { _floorSpace = value; }
        }
        private string _areaOfStructure = string.Empty;
        /// <summary>
        /// 建筑面积
        /// </summary>
        public string AreaOfStructure
        {
            get { return _areaOfStructure ?? string.Empty; }
            set { _areaOfStructure = value; }
        }
        private string _letterOfPresentation = string.Empty;
        /// <summary>
        /// 情况说明备注
        /// </summary>
        public string LetterOfPresentation
        {
            get { return _letterOfPresentation ?? string.Empty; }
            set { _letterOfPresentation = value; }
        }
        private DateTime _letterOfPresentationSetTime = MinDate;
        /// <summary>
        /// 情况说明集合时间
        /// </summary>
        public DateTime LetterOfPresentationSetTime
        {
            get { return _letterOfPresentationSetTime; }
            set { _letterOfPresentationSetTime = value; }
        }
        private string _letterOfPresentationCollectionPlace = string.Empty;
        /// <summary>
        /// 集合地点
        /// </summary>
        public string LetterOfPresentationCollectionPlace
        {
            get { return _letterOfPresentationCollectionPlace ?? string.Empty; }
            set { _letterOfPresentationCollectionPlace = value; }
        }
        private string _equipmentRequirements = string.Empty;
        /// <summary>
        /// 拆除设备要求
        /// </summary>
        public string EquipmentRequirements
        {
            get { return _equipmentRequirements ?? string.Empty; }
            set { _equipmentRequirements = value; }
        }
        private string _noticeNo = string.Empty;
        /// <summary>
        /// 通知书单号
        /// </summary>
        public string NoticeNo
        {
            get { return _noticeNo ?? string.Empty; }
            set { _noticeNo = value; }
        }
        private string _dismantleArea = string.Empty;
        /// <summary>
        /// 实际拆除面积
        /// </summary>
        public string DismantleArea
        {
            get { return _dismantleArea ?? string.Empty; }
            set { _dismantleArea = value; }
        }
        private string _garbageTon = string.Empty;
        /// <summary>
        /// 实际清运垃圾吨数
        /// </summary>
        public string GarbageTon
        {
            get { return _garbageTon ?? string.Empty; }
            set { _garbageTon = value; }
        }
        private string _garbageCar = string.Empty;
        /// <summary>
        /// 实际清运垃圾多少车
        /// </summary>
        public string GarbageCar
        {
            get { return _garbageCar ?? string.Empty; }
            set { _garbageCar = value; }
        }
        private string _videoIdNo = string.Empty;
        /// <summary>
        /// 全过程摄像索引编号
        /// </summary>
        public string VideoIdNo
        {
            get { return _videoIdNo ?? string.Empty; }
            set { _videoIdNo = value; }
        }
        private string _dismantleLetterOfPresentation = string.Empty;
        /// <summary>
        /// 拆除情况描述
        /// </summary>
        public string DismantleLetterOfPresentation
        {
            get { return _dismantleLetterOfPresentation ?? string.Empty; }
            set { _dismantleLetterOfPresentation = value; }
        }
        private string _dismantleCompanyId = string.Empty;
        /// <summary>
        /// 字典：拆除公司
        /// </summary>
        public string DismantleCompanyId
        {
            get { return _dismantleCompanyId ?? string.Empty; }
            set { _dismantleCompanyId = value; }
        }
        private int _state;
        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _manpower = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Manpower
        {
            get { return _manpower ?? string.Empty; }
            set { _manpower = value; }
        }
        private string _securityWindow = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SecurityWindow
        {
            get { return _securityWindow ?? string.Empty; }
            set { _securityWindow = value; }
        }
        private string _factor = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Factor
        {
            get { return _factor ?? string.Empty; }
            set { _factor = value; }
        }
        private string _wholeReason = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WholeReason
        {
            get { return _wholeReason ?? string.Empty; }
            set { _wholeReason = value; }
        }
        private int _brigadeSatisfaction;
        /// <summary>
        /// 
        /// </summary>
        public int BrigadeSatisfaction
        {
            get { return _brigadeSatisfaction; }
            set { _brigadeSatisfaction = value; }
        }
        private int _leaderSatisfaction;
        /// <summary>
        /// 
        /// </summary>
        public int LeaderSatisfaction
        {
            get { return _leaderSatisfaction; }
            set { _leaderSatisfaction = value; }
        }
        private string _settlementType = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SettlementType
        {
            get { return _settlementType ?? string.Empty; }
            set { _settlementType = value; }
        }
        private string _dismantlingType = string.Empty;
        /// <summary>
        /// 拆除类型
        /// </summary>
        public string DismantlingType
        {
            get { return _dismantlingType ?? string.Empty; }
            set { _dismantlingType = value; }
        }
        private string _advertisementType = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AdvertisementType
        {
            get { return _advertisementType ?? string.Empty; }
            set { _advertisementType = value; }
        }
        private DateTime _dismantlingDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DismantlingDate
        {
            get { return _dismantlingDate; }
            set { _dismantlingDate = value; }
        }
        private string _wall = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Wall
        {
            get { return _wall ?? string.Empty; }
            set { _wall = value; }
        }
        private int _manpowerOnPrice;
        /// <summary>
        /// 
        /// </summary>
        public int ManpowerOnPrice
        {
            get { return _manpowerOnPrice; }
            set { _manpowerOnPrice = value; }
        }
        private int _wailOnPrice;
        /// <summary>
        /// 
        /// </summary>
        public int WailOnPrice
        {
            get { return _wailOnPrice; }
            set { _wailOnPrice = value; }
        }
        private int _dismantleOnPrice;
        /// <summary>
        /// 
        /// </summary>
        public int DismantleOnPrice
        {
            get { return _dismantleOnPrice; }
            set { _dismantleOnPrice = value; }
        }
        private int _securityWindowOnPrice;
        /// <summary>
        /// 
        /// </summary>
        public int SecurityWindowOnPrice
        {
            get { return _securityWindowOnPrice; }
            set { _securityWindowOnPrice = value; }
        }
        private int _garbageCarOnPrice;
        /// <summary>
        /// 
        /// </summary>
        public int GarbageCarOnPrice
        {
            get { return _garbageCarOnPrice; }
            set { _garbageCarOnPrice = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override IllegalConstructionEntity SetModelValueByDataRow(DataRow dr)
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
        public override IllegalConstructionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new IllegalConstructionEntity();
            if (fields.Contains(Parm_IllegalConstruction_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_IllegalConstruction_Id].ToString();
            if (fields.Contains(Parm_IllegalConstruction_CaseInfoNo) || fields.Contains("*"))
                tmp.CaseInfoNo = dr[Parm_IllegalConstruction_CaseInfoNo].ToString();
            if (fields.Contains(Parm_IllegalConstruction_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_IllegalConstruction_CompanyId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_IllegalConstruction_CompanyName].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_IllegalConstruction_DeptId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DeptName) || fields.Contains("*"))
                tmp.DeptName = dr[Parm_IllegalConstruction_DeptName].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ApplicationType) || fields.Contains("*"))
                tmp.ApplicationType = dr[Parm_IllegalConstruction_ApplicationType].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ApplicationUserId) || fields.Contains("*"))
                tmp.ApplicationUserId = dr[Parm_IllegalConstruction_ApplicationUserId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ApplicationUserName) || fields.Contains("*"))
                tmp.ApplicationUserName = dr[Parm_IllegalConstruction_ApplicationUserName].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ApplicationMobile) || fields.Contains("*"))
                tmp.ApplicationMobile = dr[Parm_IllegalConstruction_ApplicationMobile].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DataSource) || fields.Contains("*"))
                tmp.DataSource = dr[Parm_IllegalConstruction_DataSource].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DataSourceNum) || fields.Contains("*"))
                tmp.DataSourceNum = dr[Parm_IllegalConstruction_DataSourceNum].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ReportDataSource) || fields.Contains("*"))
                tmp.ReportDataSource = dr[Parm_IllegalConstruction_ReportDataSource].ToString();
            if (fields.Contains(Parm_IllegalConstruction_Length) || fields.Contains("*"))
                tmp.Length = dr[Parm_IllegalConstruction_Length].ToString();
            if (fields.Contains(Parm_IllegalConstruction_Widht) || fields.Contains("*"))
                tmp.Widht = dr[Parm_IllegalConstruction_Widht].ToString();
            if (fields.Contains(Parm_IllegalConstruction_Height) || fields.Contains("*"))
                tmp.Height = dr[Parm_IllegalConstruction_Height].ToString();
            if (fields.Contains(Parm_IllegalConstruction_UnbuiltState) || fields.Contains("*"))
                tmp.UnbuiltState = dr[Parm_IllegalConstruction_UnbuiltState].ToString();
            if (fields.Contains(Parm_IllegalConstruction_UnbuiltDate) || fields.Contains("*"))
                tmp.UnbuiltDate = dr[Parm_IllegalConstruction_UnbuiltDate].ToString();
            if (fields.Contains(Parm_IllegalConstruction_TargetName) || fields.Contains("*"))
                tmp.TargetName = dr[Parm_IllegalConstruction_TargetName].ToString();
            if (fields.Contains(Parm_IllegalConstruction_TargetAddress) || fields.Contains("*"))
                tmp.TargetAddress = dr[Parm_IllegalConstruction_TargetAddress].ToString();
            if (fields.Contains(Parm_IllegalConstruction_TargetType) || fields.Contains("*"))
                tmp.TargetType = dr[Parm_IllegalConstruction_TargetType].ToString();
            if (fields.Contains(Parm_IllegalConstruction_TargetMobile) || fields.Contains("*"))
                tmp.TargetMobile = dr[Parm_IllegalConstruction_TargetMobile].ToString();
            if (fields.Contains(Parm_IllegalConstruction_HousStructure) || fields.Contains("*"))
                tmp.HousStructure = dr[Parm_IllegalConstruction_HousStructure].ToString();
            if (fields.Contains(Parm_IllegalConstruction_FloorSpace) || fields.Contains("*"))
                tmp.FloorSpace = dr[Parm_IllegalConstruction_FloorSpace].ToString();
            if (fields.Contains(Parm_IllegalConstruction_AreaOfStructure) || fields.Contains("*"))
                tmp.AreaOfStructure = dr[Parm_IllegalConstruction_AreaOfStructure].ToString();
            if (fields.Contains(Parm_IllegalConstruction_LetterOfPresentation) || fields.Contains("*"))
                tmp.LetterOfPresentation = dr[Parm_IllegalConstruction_LetterOfPresentation].ToString();
            if (fields.Contains(Parm_IllegalConstruction_LetterOfPresentationSetTime) || fields.Contains("*"))
                tmp.LetterOfPresentationSetTime = DateTime.Parse(dr[Parm_IllegalConstruction_LetterOfPresentationSetTime].ToString());
            if (fields.Contains(Parm_IllegalConstruction_LetterOfPresentationCollectionPlace) || fields.Contains("*"))
                tmp.LetterOfPresentationCollectionPlace = dr[Parm_IllegalConstruction_LetterOfPresentationCollectionPlace].ToString();
            if (fields.Contains(Parm_IllegalConstruction_EquipmentRequirements) || fields.Contains("*"))
                tmp.EquipmentRequirements = dr[Parm_IllegalConstruction_EquipmentRequirements].ToString();
            if (fields.Contains(Parm_IllegalConstruction_NoticeNo) || fields.Contains("*"))
                tmp.NoticeNo = dr[Parm_IllegalConstruction_NoticeNo].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DismantleArea) || fields.Contains("*"))
                tmp.DismantleArea = dr[Parm_IllegalConstruction_DismantleArea].ToString();
            if (fields.Contains(Parm_IllegalConstruction_GarbageTon) || fields.Contains("*"))
                tmp.GarbageTon = dr[Parm_IllegalConstruction_GarbageTon].ToString();
            if (fields.Contains(Parm_IllegalConstruction_GarbageCar) || fields.Contains("*"))
                tmp.GarbageCar = dr[Parm_IllegalConstruction_GarbageCar].ToString();
            if (fields.Contains(Parm_IllegalConstruction_VideoIdNo) || fields.Contains("*"))
                tmp.VideoIdNo = dr[Parm_IllegalConstruction_VideoIdNo].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DismantleLetterOfPresentation) || fields.Contains("*"))
                tmp.DismantleLetterOfPresentation = dr[Parm_IllegalConstruction_DismantleLetterOfPresentation].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DismantleCompanyId) || fields.Contains("*"))
                tmp.DismantleCompanyId = dr[Parm_IllegalConstruction_DismantleCompanyId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_IllegalConstruction_State].ToString());
            if (fields.Contains(Parm_IllegalConstruction_Manpower) || fields.Contains("*"))
                tmp.Manpower = dr[Parm_IllegalConstruction_Manpower].ToString();
            if (fields.Contains(Parm_IllegalConstruction_SecurityWindow) || fields.Contains("*"))
                tmp.SecurityWindow = dr[Parm_IllegalConstruction_SecurityWindow].ToString();
            if (fields.Contains(Parm_IllegalConstruction_Factor) || fields.Contains("*"))
                tmp.Factor = dr[Parm_IllegalConstruction_Factor].ToString();
            if (fields.Contains(Parm_IllegalConstruction_WholeReason) || fields.Contains("*"))
                tmp.WholeReason = dr[Parm_IllegalConstruction_WholeReason].ToString();
            if (fields.Contains(Parm_IllegalConstruction_BrigadeSatisfaction) || fields.Contains("*"))
                tmp.BrigadeSatisfaction = int.Parse(dr[Parm_IllegalConstruction_BrigadeSatisfaction].ToString());
            if (fields.Contains(Parm_IllegalConstruction_LeaderSatisfaction) || fields.Contains("*"))
                tmp.LeaderSatisfaction = int.Parse(dr[Parm_IllegalConstruction_LeaderSatisfaction].ToString());
            if (fields.Contains(Parm_IllegalConstruction_SettlementType) || fields.Contains("*"))
                tmp.SettlementType = dr[Parm_IllegalConstruction_SettlementType].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DismantlingType) || fields.Contains("*"))
                tmp.DismantlingType = dr[Parm_IllegalConstruction_DismantlingType].ToString();
            if (fields.Contains(Parm_IllegalConstruction_AdvertisementType) || fields.Contains("*"))
                tmp.AdvertisementType = dr[Parm_IllegalConstruction_AdvertisementType].ToString();
            if (fields.Contains(Parm_IllegalConstruction_DismantlingDate) || fields.Contains("*"))
                tmp.DismantlingDate = DateTime.Parse(dr[Parm_IllegalConstruction_DismantlingDate].ToString());
            if (fields.Contains(Parm_IllegalConstruction_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_IllegalConstruction_RowStatus].ToString());
            if (fields.Contains(Parm_IllegalConstruction_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_IllegalConstruction_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_IllegalConstruction_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_IllegalConstruction_CreatorId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_IllegalConstruction_CreateBy].ToString();
            if (fields.Contains(Parm_IllegalConstruction_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_IllegalConstruction_CreateOn].ToString());
            if (fields.Contains(Parm_IllegalConstruction_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_IllegalConstruction_UpdateId].ToString();
            if (fields.Contains(Parm_IllegalConstruction_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_IllegalConstruction_UpdateBy].ToString();
            if (fields.Contains(Parm_IllegalConstruction_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_IllegalConstruction_UpdateOn].ToString());
            if (fields.Contains(Parm_IllegalConstruction_Wall) || fields.Contains("*"))
                tmp.Wall = dr[Parm_IllegalConstruction_Wall].ToString();
            if (fields.Contains(Parm_IllegalConstruction_ManpowerOnPrice) || fields.Contains("*"))
                tmp.ManpowerOnPrice = int.Parse(dr[Parm_IllegalConstruction_ManpowerOnPrice].ToString());
            if (fields.Contains(Parm_IllegalConstruction_WailOnPrice) || fields.Contains("*"))
                tmp.WailOnPrice = int.Parse(dr[Parm_IllegalConstruction_WailOnPrice].ToString());
            if (fields.Contains(Parm_IllegalConstruction_DismantleOnPrice) || fields.Contains("*"))
                tmp.DismantleOnPrice = int.Parse(dr[Parm_IllegalConstruction_DismantleOnPrice].ToString());
            if (fields.Contains(Parm_IllegalConstruction_SecurityWindowOnPrice) || fields.Contains("*"))
                tmp.SecurityWindowOnPrice = int.Parse(dr[Parm_IllegalConstruction_SecurityWindowOnPrice].ToString());
            if (fields.Contains(Parm_IllegalConstruction_GarbageCarOnPrice) || fields.Contains("*"))
                tmp.GarbageCarOnPrice = int.Parse(dr[Parm_IllegalConstruction_GarbageCarOnPrice].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="illegalconstruction">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(IllegalConstructionEntity illegalconstruction, SqlParameter[] parms)
        {
            parms[0].Value = illegalconstruction.CaseInfoNo;
            parms[1].Value = illegalconstruction.CompanyId;
            parms[2].Value = illegalconstruction.CompanyName;
            parms[3].Value = illegalconstruction.DeptId;
            parms[4].Value = illegalconstruction.DeptName;
            parms[5].Value = illegalconstruction.ApplicationType;
            parms[6].Value = illegalconstruction.ApplicationUserId;
            parms[7].Value = illegalconstruction.ApplicationUserName;
            parms[8].Value = illegalconstruction.ApplicationMobile;
            parms[9].Value = illegalconstruction.DataSource;
            parms[10].Value = illegalconstruction.DataSourceNum;
            parms[11].Value = illegalconstruction.ReportDataSource;
            parms[12].Value = illegalconstruction.Length;
            parms[13].Value = illegalconstruction.Widht;
            parms[14].Value = illegalconstruction.Height;
            parms[15].Value = illegalconstruction.UnbuiltState;
            parms[16].Value = illegalconstruction.UnbuiltDate;
            parms[17].Value = illegalconstruction.TargetName;
            parms[18].Value = illegalconstruction.TargetAddress;
            parms[19].Value = illegalconstruction.TargetType;
            parms[20].Value = illegalconstruction.TargetMobile;
            parms[21].Value = illegalconstruction.HousStructure;
            parms[22].Value = illegalconstruction.FloorSpace;
            parms[23].Value = illegalconstruction.AreaOfStructure;
            parms[24].Value = illegalconstruction.LetterOfPresentation;
            parms[25].Value = illegalconstruction.LetterOfPresentationSetTime;
            parms[26].Value = illegalconstruction.LetterOfPresentationCollectionPlace;
            parms[27].Value = illegalconstruction.EquipmentRequirements;
            parms[28].Value = illegalconstruction.NoticeNo;
            parms[29].Value = illegalconstruction.DismantleArea;
            parms[30].Value = illegalconstruction.GarbageTon;
            parms[31].Value = illegalconstruction.GarbageCar;
            parms[32].Value = illegalconstruction.VideoIdNo;
            parms[33].Value = illegalconstruction.DismantleLetterOfPresentation;
            parms[34].Value = illegalconstruction.DismantleCompanyId;
            parms[35].Value = illegalconstruction.State;
            parms[36].Value = illegalconstruction.Manpower;
            parms[37].Value = illegalconstruction.SecurityWindow;
            parms[38].Value = illegalconstruction.Factor;
            parms[39].Value = illegalconstruction.WholeReason;
            parms[40].Value = illegalconstruction.BrigadeSatisfaction;
            parms[41].Value = illegalconstruction.LeaderSatisfaction;
            parms[42].Value = illegalconstruction.SettlementType;
            parms[43].Value = illegalconstruction.DismantlingType;
            parms[44].Value = illegalconstruction.AdvertisementType;
            parms[45].Value = illegalconstruction.DismantlingDate;
            parms[46].Value = illegalconstruction.RowStatus;
            parms[47].Value = illegalconstruction.CreatorId;
            parms[48].Value = illegalconstruction.CreateBy;
            parms[49].Value = illegalconstruction.CreateOn;
            parms[50].Value = illegalconstruction.UpdateId;
            parms[51].Value = illegalconstruction.UpdateBy;
            parms[52].Value = illegalconstruction.UpdateOn;
            parms[53].Value = illegalconstruction.Wall;
            parms[54].Value = illegalconstruction.ManpowerOnPrice;
            parms[55].Value = illegalconstruction.WailOnPrice;
            parms[56].Value = illegalconstruction.DismantleOnPrice;
            parms[57].Value = illegalconstruction.SecurityWindowOnPrice;
            parms[58].Value = illegalconstruction.GarbageCarOnPrice;
            parms[59].Value = illegalconstruction.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(IllegalConstructionEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_IllegalConstruction_Insert); if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_IllegalConstruction_CaseInfoNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DeptId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DeptName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ApplicationType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ApplicationUserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ApplicationUserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ApplicationMobile, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DataSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DataSourceNum, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ReportDataSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_Length, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_Widht, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_Height, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_UnbuiltState, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_UnbuiltDate, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_TargetName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_TargetAddress, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_IllegalConstruction_TargetType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_TargetMobile, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_HousStructure, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_FloorSpace, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_AreaOfStructure, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_LetterOfPresentation, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_IllegalConstruction_LetterOfPresentationSetTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_IllegalConstruction_LetterOfPresentationCollectionPlace, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_EquipmentRequirements, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_IllegalConstruction_NoticeNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DismantleArea, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_GarbageTon, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_IllegalConstruction_GarbageCar, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_IllegalConstruction_VideoIdNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_DismantleLetterOfPresentation, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_IllegalConstruction_DismantleCompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_Manpower, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_SecurityWindow, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_Factor, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_WholeReason, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_BrigadeSatisfaction, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_LeaderSatisfaction, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_SettlementType, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_DismantlingType, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_AdvertisementType, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_IllegalConstruction_DismantlingDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_IllegalConstruction_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_IllegalConstruction_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_UpdateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_IllegalConstruction_Wall, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_IllegalConstruction_ManpowerOnPrice, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_WailOnPrice, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_DismantleOnPrice, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_SecurityWindowOnPrice, SqlDbType.Int, 10),
					new SqlParameter(Parm_IllegalConstruction_GarbageCarOnPrice, SqlDbType.Int, 10),
                    new SqlParameter(Parm_IllegalConstruction_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_IllegalConstruction_Insert, parms);
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

