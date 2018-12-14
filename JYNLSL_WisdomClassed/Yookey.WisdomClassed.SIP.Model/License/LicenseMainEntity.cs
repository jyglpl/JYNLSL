//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseMainEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-05-29 14:03:35
//  功能描述：LicenseMain表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Model.License
{
    /// <summary>
    /// 行政许可主表
    /// </summary>
    [Serializable]
    public class LicenseMainEntity : ModelImp.BaseModel<LicenseMainEntity>
    {
        public LicenseMainEntity()
        {
            TB_Name = TB_LicenseMain;
            Parm_Id = Parm_LicenseMain_Id;
            Parm_Version = Parm_LicenseMain_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicenseMain_Insert;
            Sql_Update = Sql_LicenseMain_Update;
            Sql_Delete = Sql_LicenseMain_Delete;
        }
        #region Const of table LicenseMain
        /// <summary>
        /// Table LicenseMain
        /// </summary>
        public const string TB_LicenseMain = "LicenseMain";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AcceptanceCheck
        /// </summary>
        public const string Parm_LicenseMain_AcceptanceCheck = "AcceptanceCheck";
        /// <summary>
        /// Parm AcceptanceDate
        /// </summary>
        public const string Parm_LicenseMain_AcceptanceDate = "AcceptanceDate";
        /// <summary>
        /// Parm AcceptanceId
        /// </summary>
        public const string Parm_LicenseMain_AcceptanceId = "AcceptanceId";
        /// <summary>
        /// Parm AcceptanceName
        /// </summary>
        public const string Parm_LicenseMain_AcceptanceName = "AcceptanceName";
        /// <summary>
        /// Parm ApplicantName
        /// </summary>
        public const string Parm_LicenseMain_ApplicantName = "ApplicantName";
        /// <summary>
        /// Parm ApplicantType
        /// </summary>
        public const string Parm_LicenseMain_ApplicantType = "ApplicantType";
        /// <summary>
        /// Parm ApplicationDate
        /// </summary>
        public const string Parm_LicenseMain_ApplicationDate = "ApplicationDate";
        /// <summary>
        /// Parm Area
        /// </summary>
        public const string Parm_LicenseMain_Area = "Area";
        /// <summary>
        /// Parm AreaAgentId
        /// </summary>
        public const string Parm_LicenseMain_AreaAgentId = "AreaAgentId";
        /// <summary>
        /// Parm AreaAgentName
        /// </summary>
        public const string Parm_LicenseMain_AreaAgentName = "AreaAgentName";
        /// <summary>
        /// Parm AreaAuditorId
        /// </summary>
        public const string Parm_LicenseMain_AreaAuditorId = "AreaAuditorId";
        /// <summary>
        /// Parm AreaAuditorName
        /// </summary>
        public const string Parm_LicenseMain_AreaAuditorName = "AreaAuditorName";
        /// <summary>
        /// Parm BaiduLat
        /// </summary>
        public const string Parm_LicenseMain_BaiduLat = "BaiduLat";
        /// <summary>
        /// Parm BaiduLng
        /// </summary>
        public const string Parm_LicenseMain_BaiduLng = "BaiduLng";
        /// <summary>
        /// Parm ClosedDate
        /// </summary>
        public const string Parm_LicenseMain_ClosedDate = "ClosedDate";
        /// <summary>
        /// Parm ClosedIdea
        /// </summary>
        public const string Parm_LicenseMain_ClosedIdea = "ClosedIdea";
        /// <summary>
        /// Parm CompanyAddress
        /// </summary>
        public const string Parm_LicenseMain_CompanyAddress = "CompanyAddress";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicenseMain_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicenseMain_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicenseMain_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DataSource
        /// </summary>
        public const string Parm_LicenseMain_DataSource = "DataSource";
        /// <summary>
        /// Parm Email
        /// </summary>
        public const string Parm_LicenseMain_Email = "Email";
        /// <summary>
        /// Parm Fax
        /// </summary>
        public const string Parm_LicenseMain_Fax = "Fax";
        /// <summary>
        /// Parm GPSLat
        /// </summary>
        public const string Parm_LicenseMain_GPSLat = "GPSLat";
        /// <summary>
        /// Parm GPSLng
        /// </summary>
        public const string Parm_LicenseMain_GPSLng = "GPSLng";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicenseMain_Id = "Id";
        /// <summary>
        /// Parm IsPublic
        /// </summary>
        public const string Parm_LicenseMain_IsPublic = "IsPublic";
        /// <summary>
        /// Parm IsTest
        /// </summary>
        public const string Parm_LicenseMain_IsTest = "IsTest";
        /// <summary>
        /// Parm IsUpOneNet
        /// </summary>
        public const string Parm_LicenseMain_IsUpOneNet = "IsUpOneNet";
        /// <summary>
        /// Parm ItemCode
        /// </summary>
        public const string Parm_LicenseMain_ItemCode = "ItemCode";
        /// <summary>
        /// Parm LegalPersonId
        /// </summary>
        public const string Parm_LicenseMain_LegalPersonId = "LegalPersonId";
        /// <summary>
        /// Parm LegalPersonName
        /// </summary>
        public const string Parm_LicenseMain_LegalPersonName = "LegalPersonName";
        /// <summary>
        /// Parm LicenseNo
        /// </summary>
        public const string Parm_LicenseMain_LicenseNo = "LicenseNo";
        /// <summary>
        /// Parm LicenseSetNo
        /// </summary>
        public const string Parm_LicenseMain_LicenseSetNo = "LicenseSetNo";
        /// <summary>
        /// Parm LinkMan
        /// </summary>
        public const string Parm_LicenseMain_LinkMan = "LinkMan";
        /// <summary>
        /// Parm LinkMobile
        /// </summary>
        public const string Parm_LicenseMain_LinkMobile = "LinkMobile";
        /// <summary>
        /// Parm LinkTel
        /// </summary>
        public const string Parm_LicenseMain_LinkTel = "LinkTel";
        /// <summary>
        /// Parm PaperCode
        /// </summary>
        public const string Parm_LicenseMain_PaperCode = "PaperCode";
        /// <summary>
        /// Parm PaperType
        /// </summary>
        public const string Parm_LicenseMain_PaperType = "PaperType";
        /// <summary>
        /// Parm PromiseEndDate
        /// </summary>
        public const string Parm_LicenseMain_PromiseEndDate = "PromiseEndDate";
        /// <summary>
        /// Parm PromiseStartDate
        /// </summary>
        public const string Parm_LicenseMain_PromiseStartDate = "PromiseStartDate";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicenseMain_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SetUpAddress
        /// </summary>
        public const string Parm_LicenseMain_SetUpAddress = "SetUpAddress";
        /// <summary>
        /// Parm SetUpEndDate
        /// </summary>
        public const string Parm_LicenseMain_SetUpEndDate = "SetUpEndDate";
        /// <summary>
        /// Parm SetUpStartDate
        /// </summary>
        public const string Parm_LicenseMain_SetUpStartDate = "SetUpStartDate";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_LicenseMain_State = "State";
        /// <summary>
        /// Parm SurveyDate
        /// </summary>
        public const string Parm_LicenseMain_SurveyDate = "SurveyDate";
        /// <summary>
        /// Parm TestRemark
        /// </summary>
        public const string Parm_LicenseMain_TestRemark = "TestRemark";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicenseMain_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicenseMain_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicenseMain_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicenseMain_Version = "Version";
        /// <summary>
        /// Parm ZipCode
        /// </summary>
        public const string Parm_LicenseMain_ZipCode = "ZipCode";
        /// <summary>
        /// Insert Query Of LicenseMain
        /// </summary>
        public const string Sql_LicenseMain_Insert = "insert into LicenseMain(AcceptanceCheck,AcceptanceDate,AcceptanceId,AcceptanceName,ApplicantName,ApplicantType,ApplicationDate,Area,AreaAgentId,AreaAgentName,AreaAuditorId,AreaAuditorName,BaiduLat,BaiduLng,ClosedDate,ClosedIdea,CompanyAddress,CreateBy,CreateOn,CreatorId,DataSource,Email,Fax,GPSLat,GPSLng,IsPublic,IsTest,IsUpOneNet,ItemCode,LegalPersonId,LegalPersonName,LicenseNo,LicenseSetNo,LinkMan,LinkMobile,LinkTel,PaperCode,PaperType,PromiseEndDate,PromiseStartDate,RowStatus,SetUpAddress,SetUpEndDate,SetUpStartDate,State,SurveyDate,TestRemark,UpdateBy,UpdateId,UpdateOn,ZipCode,Id) values(@AcceptanceCheck,@AcceptanceDate,@AcceptanceId,@AcceptanceName,@ApplicantName,@ApplicantType,@ApplicationDate,@Area,@AreaAgentId,@AreaAgentName,@AreaAuditorId,@AreaAuditorName,@BaiduLat,@BaiduLng,@ClosedDate,@ClosedIdea,@CompanyAddress,@CreateBy,@CreateOn,@CreatorId,@DataSource,@Email,@Fax,@GPSLat,@GPSLng,@IsPublic,@IsTest,@IsUpOneNet,@ItemCode,@LegalPersonId,@LegalPersonName,@LicenseNo,@LicenseSetNo,@LinkMan,@LinkMobile,@LinkTel,@PaperCode,@PaperType,@PromiseEndDate,@PromiseStartDate,@RowStatus,@SetUpAddress,@SetUpEndDate,@SetUpStartDate,@State,@SurveyDate,@TestRemark,@UpdateBy,@UpdateId,@UpdateOn,@ZipCode,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicenseMain
        /// </summary>
        public const string Sql_LicenseMain_Update = "update LicenseMain set AcceptanceCheck=@AcceptanceCheck,AcceptanceDate=@AcceptanceDate,AcceptanceId=@AcceptanceId,AcceptanceName=@AcceptanceName,ApplicantName=@ApplicantName,ApplicantType=@ApplicantType,ApplicationDate=@ApplicationDate,Area=@Area,AreaAgentId=@AreaAgentId,AreaAgentName=@AreaAgentName,AreaAuditorId=@AreaAuditorId,AreaAuditorName=@AreaAuditorName,BaiduLat=@BaiduLat,BaiduLng=@BaiduLng,ClosedDate=@ClosedDate,ClosedIdea=@ClosedIdea,CompanyAddress=@CompanyAddress,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataSource=@DataSource,Email=@Email,Fax=@Fax,GPSLat=@GPSLat,GPSLng=@GPSLng,IsPublic=@IsPublic,IsTest=@IsTest,IsUpOneNet=@IsUpOneNet,ItemCode=@ItemCode,LegalPersonId=@LegalPersonId,LegalPersonName=@LegalPersonName,LicenseNo=@LicenseNo,LicenseSetNo=@LicenseSetNo,LinkMan=@LinkMan,LinkMobile=@LinkMobile,LinkTel=@LinkTel,PaperCode=@PaperCode,PaperType=@PaperType,PromiseEndDate=@PromiseEndDate,PromiseStartDate=@PromiseStartDate,RowStatus=@RowStatus,SetUpAddress=@SetUpAddress,SetUpEndDate=@SetUpEndDate,SetUpStartDate=@SetUpStartDate,State=@State,SurveyDate=@SurveyDate,TestRemark=@TestRemark,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,ZipCode=@ZipCode where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicenseMain_Delete = "update LicenseMain set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _dataSource = string.Empty;
        /// <summary>
        /// 办件来源（1.窗口 2.历史数据）
        /// </summary>
        public string DataSource
        {
            get { return _dataSource ?? string.Empty; }
            set { _dataSource = value; }
        }
        private string _licenseNo = string.Empty;
        /// <summary>
        /// 许可流水号
        /// </summary>
        public string LicenseNo
        {
            get { return _licenseNo ?? string.Empty; }
            set { _licenseNo = value; }
        }
        private string _licenseSetNo = string.Empty;
        /// <summary>
        /// 设置证号
        /// </summary>
        public string LicenseSetNo
        {
            get { return _licenseSetNo ?? string.Empty; }
            set { _licenseSetNo = value; }
        }
        private string _itemCode = string.Empty;
        /// <summary>
        /// 审批事项编码
        /// </summary>
        public string ItemCode
        {
            get { return _itemCode ?? string.Empty; }
            set { _itemCode = value; }
        }
        private DateTime _promiseStartDate = MinDate;
        /// <summary>
        /// 承诺开始日期
        /// </summary>
        public DateTime PromiseStartDate
        {
            get { return _promiseStartDate; }
            set { _promiseStartDate = value; }
        }
        private DateTime _promiseEndDate = MinDate;
        /// <summary>
        /// 承诺截止日期
        /// </summary>
        public DateTime PromiseEndDate
        {
            get { return _promiseEndDate; }
            set { _promiseEndDate = value; }
        }
        private string _applicantType = string.Empty;
        /// <summary>
        /// 申请人类型
        /// </summary>
        public string ApplicantType
        {
            get { return _applicantType ?? string.Empty; }
            set { _applicantType = value; }
        }
        private string _paperType = string.Empty;
        /// <summary>
        /// 申请人证照类型
        /// </summary>
        public string PaperType
        {
            get { return _paperType ?? string.Empty; }
            set { _paperType = value; }
        }
        private string _paperCode = string.Empty;
        /// <summary>
        /// 申请人证照编号
        /// </summary>
        public string PaperCode
        {
            get { return _paperCode ?? string.Empty; }
            set { _paperCode = value; }
        }
        private string _applicantName = string.Empty;
        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplicantName
        {
            get { return _applicantName ?? string.Empty; }
            set { _applicantName = value; }
        }
        private string _companyAddress = string.Empty;
        /// <summary>
        /// 单位地址
        /// </summary>
        public string CompanyAddress
        {
            get { return _companyAddress ?? string.Empty; }
            set { _companyAddress = value; }
        }
        private string _legalPersonName = string.Empty;
        /// <summary>
        /// 法人代表姓名
        /// </summary>
        public string LegalPersonName
        {
            get { return _legalPersonName ?? string.Empty; }
            set { _legalPersonName = value; }
        }
        private string _legalPersonId = string.Empty;
        /// <summary>
        /// 法人代表身份证
        /// </summary>
        public string LegalPersonId
        {
            get { return _legalPersonId ?? string.Empty; }
            set { _legalPersonId = value; }
        }
        private string _linkMan = string.Empty;
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get { return _linkMan ?? string.Empty; }
            set { _linkMan = value; }
        }
        private string _linkTel = string.Empty;
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LinkTel
        {
            get { return _linkTel ?? string.Empty; }
            set { _linkTel = value; }
        }
        private string _linkMobile = string.Empty;
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LinkMobile
        {
            get { return _linkMobile ?? string.Empty; }
            set { _linkMobile = value; }
        }
        private string _zipCode = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ZipCode
        {
            get { return _zipCode ?? string.Empty; }
            set { _zipCode = value; }
        }
        private string _email = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return _email ?? string.Empty; }
            set { _email = value; }
        }
        private string _fax = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return _fax ?? string.Empty; }
            set { _fax = value; }
        }
        private DateTime _setUpStartDate = MinDate;
        /// <summary>
        /// 设置开始日期
        /// </summary>
        public DateTime SetUpStartDate
        {
            get { return _setUpStartDate; }
            set { _setUpStartDate = value; }
        }
        private DateTime _setUpEndDate = MinDate;
        /// <summary>
        /// 设置截止日期
        /// </summary>
        public DateTime SetUpEndDate
        {
            get { return _setUpEndDate; }
            set { _setUpEndDate = value; }
        }
        private string _setUpAddress = string.Empty;
        /// <summary>
        /// 设置地址
        /// </summary>
        public string SetUpAddress
        {
            get { return _setUpAddress ?? string.Empty; }
            set { _setUpAddress = value; }
        }
        private string _area = string.Empty;
        /// <summary>
        /// 所属片区
        /// </summary>
        public string Area
        {
            get { return _area ?? string.Empty; }
            set { _area = value; }
        }
        private string _areaAgentId = string.Empty;
        /// <summary>
        /// 片区经办人ID
        /// </summary>
        public string AreaAgentId
        {
            get { return _areaAgentId ?? string.Empty; }
            set { _areaAgentId = value; }
        }
        private string _areaAgentName = string.Empty;
        /// <summary>
        /// 片区经办人姓名
        /// </summary>
        public string AreaAgentName
        {
            get { return _areaAgentName ?? string.Empty; }
            set { _areaAgentName = value; }
        }
        private string _areaAuditorId = string.Empty;
        /// <summary>
        /// 片区审核人ID
        /// </summary>
        public string AreaAuditorId
        {
            get { return _areaAuditorId ?? string.Empty; }
            set { _areaAuditorId = value; }
        }
        private string _areaAuditorName = string.Empty;
        /// <summary>
        /// 片区审核人姓名
        /// </summary>
        public string AreaAuditorName
        {
            get { return _areaAuditorName ?? string.Empty; }
            set { _areaAuditorName = value; }
        }
        private string _acceptanceId = string.Empty;
        /// <summary>
        /// 受理人ID
        /// </summary>
        public string AcceptanceId
        {
            get { return _acceptanceId ?? string.Empty; }
            set { _acceptanceId = value; }
        }
        private string _acceptanceName = string.Empty;
        /// <summary>
        /// 受理人姓名
        /// </summary>
        public string AcceptanceName
        {
            get { return _acceptanceName ?? string.Empty; }
            set { _acceptanceName = value; }
        }
        private DateTime _acceptanceDate = MinDate;
        /// <summary>
        /// 受理日期
        /// </summary>
        public DateTime AcceptanceDate
        {
            get { return _acceptanceDate; }
            set { _acceptanceDate = value; }
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
        private decimal _gPSLat;
        /// <summary>
        /// GPS经度
        /// </summary>
        public decimal GPSLat
        {
            get { return _gPSLat; }
            set { _gPSLat = value; }
        }
        private decimal _gPSLng;
        /// <summary>
        /// GPS纬度
        /// </summary>
        public decimal GPSLng
        {
            get { return _gPSLng; }
            set { _gPSLng = value; }
        }
        private decimal _baiduLat;
        /// <summary>
        /// 百度经度
        /// </summary>
        public decimal BaiduLat
        {
            get { return _baiduLat; }
            set { _baiduLat = value; }
        }
        private decimal _baiduLng;
        /// <summary>
        /// 百度纬度
        /// </summary>
        public decimal BaiduLng
        {
            get { return _baiduLng; }
            set { _baiduLng = value; }
        }
        private DateTime _surveyDate = MinDate;
        /// <summary>
        /// 现场踏勘日期
        /// </summary>
        public DateTime SurveyDate
        {
            get { return _surveyDate; }
            set { _surveyDate = value; }
        }
        private DateTime _acceptanceCheck = MinDate;
        /// <summary>
        /// 现场验收日期
        /// </summary>
        public DateTime AcceptanceCheck
        {
            get { return _acceptanceCheck; }
            set { _acceptanceCheck = value; }
        }
        private DateTime _closedDate = MinDate;
        /// <summary>
        /// 办结日期
        /// </summary>
        public DateTime ClosedDate
        {
            get { return _closedDate; }
            set { _closedDate = value; }
        }
        private string _closedIdea = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ClosedIdea
        {
            get { return _closedIdea ?? string.Empty; }
            set { _closedIdea = value; }
        }
        private int _isTest;
        /// <summary>
        /// 是否是测试办件
        /// </summary>
        public int IsTest
        {
            get { return _isTest; }
            set { _isTest = value; }
        }
        private string _testRemark = string.Empty;
        /// <summary>
        /// 测试说明
        /// </summary>
        public string TestRemark
        {
            get { return _testRemark ?? string.Empty; }
            set { _testRemark = value; }
        }
        private DateTime _applicationDate = MinDate;
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplicationDate
        {
            get { return _applicationDate; }
            set { _applicationDate = value; }
        }
        private int _isUpOneNet;
        /// <summary>
        /// 一张网上传(1.已上传)
        /// </summary>
        public int IsUpOneNet
        {
            get { return _isUpOneNet; }
            set { _isUpOneNet = value; }
        }
        private int _isPublic;
        /// <summary>
        /// 是否公示
        /// </summary>
        public int IsPublic
        {
            get { return _isPublic; }
            set { _isPublic = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicenseMainEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicenseMainEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseMainEntity();
            if (fields.Contains(Parm_LicenseMain_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicenseMain_Id].ToString();
            if (fields.Contains(Parm_LicenseMain_DataSource) || fields.Contains("*"))
                tmp.DataSource = dr[Parm_LicenseMain_DataSource].ToString();
            if (fields.Contains(Parm_LicenseMain_LicenseNo) || fields.Contains("*"))
                tmp.LicenseNo = dr[Parm_LicenseMain_LicenseNo].ToString();
            if (fields.Contains(Parm_LicenseMain_LicenseSetNo) || fields.Contains("*"))
                tmp.LicenseSetNo = dr[Parm_LicenseMain_LicenseSetNo].ToString();
            if (fields.Contains(Parm_LicenseMain_ItemCode) || fields.Contains("*"))
                tmp.ItemCode = dr[Parm_LicenseMain_ItemCode].ToString();
            if (fields.Contains(Parm_LicenseMain_PromiseStartDate) || fields.Contains("*"))
                tmp.PromiseStartDate = DateTime.Parse(dr[Parm_LicenseMain_PromiseStartDate].ToString());
            if (fields.Contains(Parm_LicenseMain_PromiseEndDate) || fields.Contains("*"))
                tmp.PromiseEndDate = DateTime.Parse(dr[Parm_LicenseMain_PromiseEndDate].ToString());
            if (fields.Contains(Parm_LicenseMain_ApplicantType) || fields.Contains("*"))
                tmp.ApplicantType = dr[Parm_LicenseMain_ApplicantType].ToString();
            if (fields.Contains(Parm_LicenseMain_PaperType) || fields.Contains("*"))
                tmp.PaperType = dr[Parm_LicenseMain_PaperType].ToString();
            if (fields.Contains(Parm_LicenseMain_PaperCode) || fields.Contains("*"))
                tmp.PaperCode = dr[Parm_LicenseMain_PaperCode].ToString();
            if (fields.Contains(Parm_LicenseMain_ApplicantName) || fields.Contains("*"))
                tmp.ApplicantName = dr[Parm_LicenseMain_ApplicantName].ToString();
            if (fields.Contains(Parm_LicenseMain_CompanyAddress) || fields.Contains("*"))
                tmp.CompanyAddress = dr[Parm_LicenseMain_CompanyAddress].ToString();
            if (fields.Contains(Parm_LicenseMain_LegalPersonName) || fields.Contains("*"))
                tmp.LegalPersonName = dr[Parm_LicenseMain_LegalPersonName].ToString();
            if (fields.Contains(Parm_LicenseMain_LegalPersonId) || fields.Contains("*"))
                tmp.LegalPersonId = dr[Parm_LicenseMain_LegalPersonId].ToString();
            if (fields.Contains(Parm_LicenseMain_LinkMan) || fields.Contains("*"))
                tmp.LinkMan = dr[Parm_LicenseMain_LinkMan].ToString();
            if (fields.Contains(Parm_LicenseMain_LinkTel) || fields.Contains("*"))
                tmp.LinkTel = dr[Parm_LicenseMain_LinkTel].ToString();
            if (fields.Contains(Parm_LicenseMain_LinkMobile) || fields.Contains("*"))
                tmp.LinkMobile = dr[Parm_LicenseMain_LinkMobile].ToString();
            if (fields.Contains(Parm_LicenseMain_ZipCode) || fields.Contains("*"))
                tmp.ZipCode = dr[Parm_LicenseMain_ZipCode].ToString();
            if (fields.Contains(Parm_LicenseMain_Email) || fields.Contains("*"))
                tmp.Email = dr[Parm_LicenseMain_Email].ToString();
            if (fields.Contains(Parm_LicenseMain_Fax) || fields.Contains("*"))
                tmp.Fax = dr[Parm_LicenseMain_Fax].ToString();
            if (fields.Contains(Parm_LicenseMain_SetUpStartDate) || fields.Contains("*"))
                tmp.SetUpStartDate = DateTime.Parse(dr[Parm_LicenseMain_SetUpStartDate].ToString());
            if (fields.Contains(Parm_LicenseMain_SetUpEndDate) || fields.Contains("*"))
                tmp.SetUpEndDate = DateTime.Parse(dr[Parm_LicenseMain_SetUpEndDate].ToString());
            if (fields.Contains(Parm_LicenseMain_SetUpAddress) || fields.Contains("*"))
                tmp.SetUpAddress = dr[Parm_LicenseMain_SetUpAddress].ToString();
            if (fields.Contains(Parm_LicenseMain_Area) || fields.Contains("*"))
                tmp.Area = dr[Parm_LicenseMain_Area].ToString();
            if (fields.Contains(Parm_LicenseMain_AreaAgentId) || fields.Contains("*"))
                tmp.AreaAgentId = dr[Parm_LicenseMain_AreaAgentId].ToString();
            if (fields.Contains(Parm_LicenseMain_AreaAgentName) || fields.Contains("*"))
                tmp.AreaAgentName = dr[Parm_LicenseMain_AreaAgentName].ToString();
            if (fields.Contains(Parm_LicenseMain_AreaAuditorId) || fields.Contains("*"))
                tmp.AreaAuditorId = dr[Parm_LicenseMain_AreaAuditorId].ToString();
            if (fields.Contains(Parm_LicenseMain_AreaAuditorName) || fields.Contains("*"))
                tmp.AreaAuditorName = dr[Parm_LicenseMain_AreaAuditorName].ToString();
            if (fields.Contains(Parm_LicenseMain_AcceptanceId) || fields.Contains("*"))
                tmp.AcceptanceId = dr[Parm_LicenseMain_AcceptanceId].ToString();
            if (fields.Contains(Parm_LicenseMain_AcceptanceName) || fields.Contains("*"))
                tmp.AcceptanceName = dr[Parm_LicenseMain_AcceptanceName].ToString();
            if (fields.Contains(Parm_LicenseMain_AcceptanceDate) || fields.Contains("*"))
                tmp.AcceptanceDate = DateTime.Parse(dr[Parm_LicenseMain_AcceptanceDate].ToString());
            if (fields.Contains(Parm_LicenseMain_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_LicenseMain_State].ToString());
            if (fields.Contains(Parm_LicenseMain_GPSLat) || fields.Contains("*"))
                tmp.GPSLat = decimal.Parse(dr[Parm_LicenseMain_GPSLat].ToString());
            if (fields.Contains(Parm_LicenseMain_GPSLng) || fields.Contains("*"))
                tmp.GPSLng = decimal.Parse(dr[Parm_LicenseMain_GPSLng].ToString());
            if (fields.Contains(Parm_LicenseMain_BaiduLat) || fields.Contains("*"))
                tmp.BaiduLat = decimal.Parse(dr[Parm_LicenseMain_BaiduLat].ToString());
            if (fields.Contains(Parm_LicenseMain_BaiduLng) || fields.Contains("*"))
                tmp.BaiduLng = decimal.Parse(dr[Parm_LicenseMain_BaiduLng].ToString());
            if (fields.Contains(Parm_LicenseMain_SurveyDate) || fields.Contains("*"))
                tmp.SurveyDate = DateTime.Parse(dr[Parm_LicenseMain_SurveyDate].ToString());
            if (fields.Contains(Parm_LicenseMain_AcceptanceCheck) || fields.Contains("*"))
                tmp.AcceptanceCheck = DateTime.Parse(dr[Parm_LicenseMain_AcceptanceCheck].ToString());
            if (fields.Contains(Parm_LicenseMain_ClosedDate) || fields.Contains("*"))
                tmp.ClosedDate = DateTime.Parse(dr[Parm_LicenseMain_ClosedDate].ToString());
            if (fields.Contains(Parm_LicenseMain_ClosedIdea) || fields.Contains("*"))
                tmp.ClosedIdea = dr[Parm_LicenseMain_ClosedIdea].ToString();
            if (fields.Contains(Parm_LicenseMain_IsTest) || fields.Contains("*"))
                tmp.IsTest = int.Parse(dr[Parm_LicenseMain_IsTest].ToString());
            if (fields.Contains(Parm_LicenseMain_TestRemark) || fields.Contains("*"))
                tmp.TestRemark = dr[Parm_LicenseMain_TestRemark].ToString();
            if (fields.Contains(Parm_LicenseMain_ApplicationDate) || fields.Contains("*"))
                tmp.ApplicationDate = DateTime.Parse(dr[Parm_LicenseMain_ApplicationDate].ToString());
            if (fields.Contains(Parm_LicenseMain_IsUpOneNet) || fields.Contains("*"))
                tmp.IsUpOneNet = int.Parse(dr[Parm_LicenseMain_IsUpOneNet].ToString());
            if (fields.Contains(Parm_LicenseMain_IsPublic) || fields.Contains("*"))
                tmp.IsPublic = int.Parse(dr[Parm_LicenseMain_IsPublic].ToString());
            if (fields.Contains(Parm_LicenseMain_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicenseMain_RowStatus].ToString());
            if (fields.Contains(Parm_LicenseMain_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicenseMain_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicenseMain_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicenseMain_CreatorId].ToString();
            if (fields.Contains(Parm_LicenseMain_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicenseMain_CreateBy].ToString();
            if (fields.Contains(Parm_LicenseMain_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseMain_CreateOn].ToString());
            if (fields.Contains(Parm_LicenseMain_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicenseMain_UpdateId].ToString();
            if (fields.Contains(Parm_LicenseMain_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicenseMain_UpdateBy].ToString();
            if (fields.Contains(Parm_LicenseMain_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseMain_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensemain">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicenseMainEntity licensemain, SqlParameter[] parms)
        {
            parms[0].Value = licensemain.DataSource;
            parms[1].Value = licensemain.LicenseNo;
            parms[2].Value = licensemain.LicenseSetNo;
            parms[3].Value = licensemain.ItemCode;
            parms[4].Value = licensemain.PromiseStartDate;
            parms[5].Value = licensemain.PromiseEndDate;
            parms[6].Value = licensemain.ApplicantType;
            parms[7].Value = licensemain.PaperType;
            parms[8].Value = licensemain.PaperCode;
            parms[9].Value = licensemain.ApplicantName;
            parms[10].Value = licensemain.CompanyAddress;
            parms[11].Value = licensemain.LegalPersonName;
            parms[12].Value = licensemain.LegalPersonId;
            parms[13].Value = licensemain.LinkMan;
            parms[14].Value = licensemain.LinkTel;
            parms[15].Value = licensemain.LinkMobile;
            parms[16].Value = licensemain.ZipCode;
            parms[17].Value = licensemain.Email;
            parms[18].Value = licensemain.Fax;
            parms[19].Value = licensemain.SetUpStartDate;
            parms[20].Value = licensemain.SetUpEndDate;
            parms[21].Value = licensemain.SetUpAddress;
            parms[22].Value = licensemain.Area;
            parms[23].Value = licensemain.AreaAgentId;
            parms[24].Value = licensemain.AreaAgentName;
            parms[25].Value = licensemain.AreaAuditorId;
            parms[26].Value = licensemain.AreaAuditorName;
            parms[27].Value = licensemain.AcceptanceId;
            parms[28].Value = licensemain.AcceptanceName;
            parms[29].Value = licensemain.AcceptanceDate;
            parms[30].Value = licensemain.State;
            parms[31].Value = licensemain.GPSLat;
            parms[32].Value = licensemain.GPSLng;
            parms[33].Value = licensemain.BaiduLat;
            parms[34].Value = licensemain.BaiduLng;
            parms[35].Value = licensemain.SurveyDate;
            parms[36].Value = licensemain.AcceptanceCheck;
            parms[37].Value = licensemain.ClosedDate;
            parms[38].Value = licensemain.ClosedIdea;
            parms[39].Value = licensemain.IsTest;
            parms[40].Value = licensemain.TestRemark;
            parms[41].Value = licensemain.ApplicationDate;
            parms[42].Value = licensemain.IsUpOneNet;
            parms[43].Value = licensemain.IsPublic;
            parms[44].Value = licensemain.RowStatus;
            parms[45].Value = licensemain.CreatorId;
            parms[46].Value = licensemain.CreateBy;
            parms[47].Value = licensemain.CreateOn;
            parms[48].Value = licensemain.UpdateId;
            parms[49].Value = licensemain.UpdateBy;
            parms[50].Value = licensemain.UpdateOn;
            parms[51].Value = licensemain.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseMainEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseMain_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicenseMain_DataSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_LicenseNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_LicenseSetNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_ItemCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_PromiseStartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_PromiseEndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_ApplicantType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_PaperType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_PaperCode, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_ApplicantName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_CompanyAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseMain_LegalPersonName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_LegalPersonId, SqlDbType.NVarChar, 18),
					new SqlParameter(Parm_LicenseMain_LinkMan, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_LinkTel, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_LicenseMain_LinkMobile, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_LicenseMain_ZipCode, SqlDbType.NVarChar, 8),
					new SqlParameter(Parm_LicenseMain_Email, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_Fax, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_SetUpStartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_SetUpEndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_SetUpAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseMain_Area, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AreaAgentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AreaAgentName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AreaAuditorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AreaAuditorName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AcceptanceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AcceptanceName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_AcceptanceDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMain_GPSLat, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicenseMain_GPSLng, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicenseMain_BaiduLat, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicenseMain_BaiduLng, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicenseMain_SurveyDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_AcceptanceCheck, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_ClosedDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_ClosedIdea, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_LicenseMain_IsTest, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMain_TestRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_ApplicationDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_IsUpOneNet, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMain_IsPublic, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMain_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseMain_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseMain_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseMain_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseMain_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseMain_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }
    /// <summary>
    /// 许可统计信息
    /// </summary>
    public class LicenseCountInfo
    {
        /// <summary>
        /// 受理办件数
        /// </summary>
        public List<HandTimeArea> AcceptanceCount { get; set; }

        /// <summary>
        /// 按期办理数
        /// </summary>
        public List<HandTimeArea> HandleSchedule { get; set; }

        /// <summary>
        /// 超期办理数
        /// </summary>
        public List<HandTimeArea> HandExceed { get; set; }

        /// <summary>
        /// 完成验收数
        /// </summary>
        public List<HandTimeArea> CheckedCount { get; set; }

        /// <summary>
        /// 按时验收数
        /// </summary>
        public List<HandTimeArea> CheckSchedule { get; set; }

        /// <summary>
        /// 超期验收数
        /// </summary>
        public List<HandTimeArea> CheckExceed { get; set; }

        /// <summary>
        /// 合计
        /// </summary>
        public HandTimeAreaTotal HandTimeAreaTotal { get; set; }
    }
}

