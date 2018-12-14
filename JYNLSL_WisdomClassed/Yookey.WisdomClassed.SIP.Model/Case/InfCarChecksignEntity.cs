//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/6/4 9:11:54
//  功能描述：INF_CAR_CHECKSIGN表实体
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
    /// 违法停车主表
    /// </summary>
    [Serializable]
    public class InfCarChecksignEntity : ModelImp.BaseModel<InfCarChecksignEntity>
    {
        public InfCarChecksignEntity()
        {
            TB_Name = TB_INF_CAR_CHECKSIGN;
            Parm_Id = Parm_INF_CAR_CHECKSIGN_Id;
            Parm_Version = Parm_INF_CAR_CHECKSIGN_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_CAR_CHECKSIGN_Insert;
            Sql_Update = Sql_INF_CAR_CHECKSIGN_Update;
            Sql_Delete = Sql_INF_CAR_CHECKSIGN_Delete;
        }
        #region Const of table INF_CAR_CHECKSIGN
        /// <summary>
        /// Table INF_CAR_CHECKSIGN
        /// </summary>
        public const string TB_INF_CAR_CHECKSIGN = "INF_CAR_CHECKSIGN";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Address
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Address = "Address";
        /// <summary>
        /// Parm Age
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Age = "Age";
        /// <summary>
        /// Parm AuditDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_AuditDate = "AuditDate";
        /// <summary>
        /// Parm BackDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_BackDate = "BackDate";
        /// <summary>
        /// Parm CarNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CarNo = "CarNo";
        /// <summary>
        /// Parm CarType
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CarType = "CarType";
        /// <summary>
        /// Parm CbrDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CbrDate = "CbrDate";
        /// <summary>
        /// Parm CfAddress
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CfAddress = "CfAddress";
        /// <summary>
        /// Parm CfapproveNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CfapproveNo = "CfapproveNo";
        /// <summary>
        /// Parm CheckDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CheckDate = "CheckDate";
        /// <summary>
        /// Parm CheckSignAddress
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CheckSignAddress = "CheckSignAddress";
        /// <summary>
        /// Parm CheckSignNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CheckSignNo = "CheckSignNo";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DataBytes
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_DataBytes = "DataBytes";
        /// <summary>
        /// Parm DataSource
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_DataSource = "DataSource";
        /// <summary>
        /// Parm DealDeptId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_DealDeptId = "DealDeptId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_DeptName = "DeptName";
        /// <summary>
        /// Parm EditDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_EditDate = "EditDate";
        /// <summary>
        /// Parm FinishDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_FinishDate = "FinishDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Id = "Id";
        /// <summary>
        /// Parm Isaudit
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isaudit = "Isaudit";
        /// <summary>
        /// Parm IsAutoaudit
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_IsAutoaudit = "IsAutoaudit";
        /// <summary>
        /// Parm Isedit
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isedit = "Isedit";
        /// <summary>
        /// Parm Isfilter
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isfilter = "Isfilter";
        /// <summary>
        /// Parm Isgq
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isgq = "Isgq";
        /// <summary>
        /// Parm Isonline
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isonline = "Isonline";
        /// <summary>
        /// Parm IsRead
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_IsRead = "IsRead";
        /// <summary>
        /// Parm Isrk
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Isrk = "Isrk";
        /// <summary>
        /// Parm Job
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Job = "Job";
        /// <summary>
        /// Parm Latitude
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Latitude = "Latitude";
        /// <summary>
        /// Parm Longitude
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Longitude = "Longitude";
        /// <summary>
        /// Parm Money
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Money = "Money";
        /// <summary>
        /// Parm Name
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Name = "Name";
        /// <summary>
        /// Parm NoticeNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_NoticeNo = "NoticeNo";
        /// <summary>
        /// Parm PaymentNum
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PaymentNum = "PaymentNum";
        /// <summary>
        /// Parm PdaNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PdaNo = "PdaNo";
        /// <summary>
        /// Parm PersonId1
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PersonId1 = "PersonId1";
        /// <summary>
        /// Parm PersonId2
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PersonId2 = "PersonId2";
        /// <summary>
        /// Parm PersonName1
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PersonName1 = "PersonName1";
        /// <summary>
        /// Parm PersonName2
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PersonName2 = "PersonName2";
        /// <summary>
        /// Parm PersonNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PersonNo = "PersonNo";
        /// <summary>
        /// Parm PostNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_PostNo = "PostNo";
        /// <summary>
        /// Parm Printjds
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Printjds = "Printjds";
        /// <summary>
        /// Parm Printtzs
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Printtzs = "Printtzs";
        /// <summary>
        /// Parm Realman
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Realman = "Realman";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Remark = "Remark";
        /// <summary>
        /// Parm ReSourceId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_ReSourceId = "ReSourceId";
        /// <summary>
        /// Parm Road
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Road = "Road";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Sex
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Sex = "Sex";
        /// <summary>
        /// Parm SimpleInfo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_SimpleInfo = "SimpleInfo";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_State = "State";
        /// <summary>
        /// Parm Telephone
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Telephone = "Telephone";
        /// <summary>
        /// Parm Toward
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Toward = "Toward";
        /// <summary>
        /// Parm TypeNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_TypeNo = "TypeNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UpDatetime
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_UpDatetime = "UpDatetime";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Version = "Version";
        /// <summary>
        /// Parm Whqk
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_Whqk = "Whqk";
        /// <summary>
        /// Parm ZjType
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGN_ZjType = "ZjType";
        /// <summary>
        /// Insert Query Of INF_CAR_CHECKSIGN
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGN_Insert = "insert into INF_CAR_CHECKSIGN(Address,Age,AuditDate,BackDate,CarNo,CarType,CbrDate,CfAddress,CfapproveNo,CheckDate,CheckSignAddress,CheckSignNo,CreateBy,CreateOn,CreatorId,DataBytes,DataSource,DealDeptId,DeptId,DeptName,EditDate,FinishDate,Isaudit,IsAutoaudit,Isedit,Isfilter,Isgq,Isonline,IsRead,Isrk,Job,Latitude,Longitude,Money,Name,NoticeNo,PaymentNum,PdaNo,PersonId1,PersonId2,PersonName1,PersonName2,PersonNo,PostNo,Printjds,Printtzs,Realman,Remark,ReSourceId,Road,RowStatus,Sex,SimpleInfo,State,Telephone,Toward,TypeNo,UpdateBy,UpdateId,UpdateOn,UpDatetime,Whqk,ZjType,Id) values(@Address,@Age,@AuditDate,@BackDate,@CarNo,@CarType,@CbrDate,@CfAddress,@CfapproveNo,@CheckDate,@CheckSignAddress,@CheckSignNo,@CreateBy,@CreateOn,@CreatorId,@DataBytes,@DataSource,@DealDeptId,@DeptId,@DeptName,@EditDate,@FinishDate,@Isaudit,@IsAutoaudit,@Isedit,@Isfilter,@Isgq,@Isonline,@IsRead,@Isrk,@Job,@Latitude,@Longitude,@Money,@Name,@NoticeNo,@PaymentNum,@PdaNo,@PersonId1,@PersonId2,@PersonName1,@PersonName2,@PersonNo,@PostNo,@Printjds,@Printtzs,@Realman,@Remark,@ReSourceId,@Road,@RowStatus,@Sex,@SimpleInfo,@State,@Telephone,@Toward,@TypeNo,@UpdateBy,@UpdateId,@UpdateOn,@UpDatetime,@Whqk,@ZjType,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_CAR_CHECKSIGN
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGN_Update = "update INF_CAR_CHECKSIGN set Address=@Address,Age=@Age,AuditDate=@AuditDate,BackDate=@BackDate,CarNo=@CarNo,CarType=@CarType,CbrDate=@CbrDate,CfAddress=@CfAddress,CfapproveNo=@CfapproveNo,CheckDate=@CheckDate,CheckSignAddress=@CheckSignAddress,CheckSignNo=@CheckSignNo,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataBytes=@DataBytes,DataSource=@DataSource,DealDeptId=@DealDeptId,DeptId=@DeptId,DeptName=@DeptName,EditDate=@EditDate,FinishDate=@FinishDate,Isaudit=@Isaudit,IsAutoaudit=@IsAutoaudit,Isedit=@Isedit,Isfilter=@Isfilter,Isgq=@Isgq,Isonline=@Isonline,IsRead=@IsRead,Isrk=@Isrk,Job=@Job,Latitude=@Latitude,Longitude=@Longitude,Money=@Money,Name=@Name,NoticeNo=@NoticeNo,PaymentNum=@PaymentNum,PdaNo=@PdaNo,PersonId1=@PersonId1,PersonId2=@PersonId2,PersonName1=@PersonName1,PersonName2=@PersonName2,PersonNo=@PersonNo,PostNo=@PostNo,Printjds=@Printjds,Printtzs=@Printtzs,Realman=@Realman,Remark=@Remark,ReSourceId=@ReSourceId,Road=@Road,RowStatus=@RowStatus,Sex=@Sex,SimpleInfo=@SimpleInfo,State=@State,Telephone=@Telephone,Toward=@Toward,TypeNo=@TypeNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UpDatetime=@UpDatetime,Whqk=@Whqk,ZjType=@ZjType where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGN_Delete = "update INF_CAR_CHECKSIGN set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _checkSignNo = string.Empty;
        /// <summary>
        /// 案件编号
        /// </summary>
        public string CheckSignNo
        {
            get { return _checkSignNo ?? string.Empty; }
            set { _checkSignNo = value; }
        }
        private string _typeNo = string.Empty;
        /// <summary>
        /// 案件类别
        /// </summary>
        public string TypeNo
        {
            get { return _typeNo ?? string.Empty; }
            set { _typeNo = value; }
        }
        private string _reSourceId = string.Empty;
        /// <summary>
        /// 案件来源编号
        /// </summary>
        public string ReSourceId
        {
            get { return _reSourceId ?? string.Empty; }
            set { _reSourceId = value; }
        }
        private int _dataSource;
        /// <summary>
        /// 数据来源0为系统登记1为PDA上报2为区级数据自动上报
        /// </summary>
        public int DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }
        private string _deptId = string.Empty;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId
        {
            get { return _deptId ?? string.Empty; }
            set { _deptId = value; }
        }
        private string _deptName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            get { return _deptName ?? string.Empty; }
            set { _deptName = value; }
        }
        private DateTime _checkDate = MinDate;
        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime CheckDate
        {
            get { return _checkDate; }
            set { _checkDate = value; }
        }
        private string _personId1 = string.Empty;
        /// <summary>
        /// 执法队员1
        /// </summary>
        public string PersonId1
        {
            get { return _personId1 ?? string.Empty; }
            set { _personId1 = value; }
        }
        private string _personId2 = string.Empty;
        /// <summary>
        /// 执法队员2
        /// </summary>
        public string PersonId2
        {
            get { return _personId2 ?? string.Empty; }
            set { _personId2 = value; }
        }
        private string _personName1 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PersonName1
        {
            get { return _personName1 ?? string.Empty; }
            set { _personName1 = value; }
        }
        private string _personName2 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PersonName2
        {
            get { return _personName2 ?? string.Empty; }
            set { _personName2 = value; }
        }
        private string _name = string.Empty;
        /// <summary>
        /// 当事人姓名
        /// </summary>
        public string Name
        {
            get { return _name ?? string.Empty; }
            set { _name = value; }
        }
        private int _age;
        /// <summary>
        /// 当事人年龄
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private int _sex;
        /// <summary>
        /// 当事人性别
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _personNo = string.Empty;
        /// <summary>
        /// 身份证编号
        /// </summary>
        public string PersonNo
        {
            get { return _personNo ?? string.Empty; }
            set { _personNo = value; }
        }
        private string _address = string.Empty;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address ?? string.Empty; }
            set { _address = value; }
        }
        private string _telephone = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get { return _telephone ?? string.Empty; }
            set { _telephone = value; }
        }
        private string _carNo = string.Empty;
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNo
        {
            get { return _carNo ?? string.Empty; }
            set { _carNo = value; }
        }
        private string _carType = string.Empty;
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CarType
        {
            get { return _carType ?? string.Empty; }
            set { _carType = value; }
        }
        private string _road = string.Empty;
        /// <summary>
        /// 路段
        /// </summary>
        public string Road
        {
            get { return _road ?? string.Empty; }
            set { _road = value; }
        }
        private string _toward = string.Empty;
        /// <summary>
        /// 方向
        /// </summary>
        public string Toward
        {
            get { return _toward ?? string.Empty; }
            set { _toward = value; }
        }
        private string _checkSignAddress = string.Empty;
        /// <summary>
        /// 违章地点
        /// </summary>
        public string CheckSignAddress
        {
            get { return _checkSignAddress ?? string.Empty; }
            set { _checkSignAddress = value; }
        }
        private string _simpleInfo = string.Empty;
        /// <summary>
        /// 案情摘要
        /// </summary>
        public string SimpleInfo
        {
            get { return _simpleInfo ?? string.Empty; }
            set { _simpleInfo = value; }
        }
        private string _noticeNo = string.Empty;
        /// <summary>
        /// 通知书编号(贴单编号)
        /// </summary>
        public string NoticeNo
        {
            get { return _noticeNo ?? string.Empty; }
            set { _noticeNo = value; }
        }
        private string _whqk = string.Empty;
        /// <summary>
        /// 危害情况
        /// </summary>
        public string Whqk
        {
            get { return _whqk ?? string.Empty; }
            set { _whqk = value; }
        }
        private string _cfapproveNo = string.Empty;
        /// <summary>
        /// 处罚决定书编号
        /// </summary>
        public string CfapproveNo
        {
            get { return _cfapproveNo ?? string.Empty; }
            set { _cfapproveNo = value; }
        }
        private string _postNo = string.Empty;
        /// <summary>
        /// 事先通知书号
        /// </summary>
        public string PostNo
        {
            get { return _postNo ?? string.Empty; }
            set { _postNo = value; }
        }
        private string _job = string.Empty;
        /// <summary>
        /// 罚没款缴纳方式
        /// </summary>
        public string Job
        {
            get { return _job ?? string.Empty; }
            set { _job = value; }
        }
        private DateTime _cbrDate = MinDate;
        /// <summary>
        /// 处理，移交，销案日期
        /// </summary>
        public DateTime CbrDate
        {
            get { return _cbrDate; }
            set { _cbrDate = value; }
        }
        private double _money;
        /// <summary>
        /// 罚款金额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }
        private string _paymentNum = string.Empty;
        /// <summary>
        /// 罚没款票据号
        /// </summary>
        public string PaymentNum
        {
            get { return _paymentNum ?? string.Empty; }
            set { _paymentNum = value; }
        }
        private int _state;
        /// <summary>
        /// 状态(-1销案，0未处理，511已处理，888-已移交，999已归档)
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 状态（中文）
        /// </summary>
        public string RsState { get; set; }

        /// <summary>
        /// 图片附件
        /// </summary>
        public List<string> FileList { get; set; }

        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private DateTime _finishDate = MinDate;
        /// <summary>
        /// 结案日期
        /// </summary>
        public DateTime FinishDate
        {
            get { return _finishDate; }
            set { _finishDate = value; }
        }
        private string _isfilter = string.Empty;
        /// <summary>
        /// 是否打包给交警(保存交警返回的结果)
        /// </summary>
        public string Isfilter
        {
            get { return _isfilter ?? string.Empty; }
            set { _isfilter = value; }
        }
        private DateTime _upDatetime = MinDate;
        /// <summary>
        /// 最后一次修改日期
        /// </summary>
        public DateTime UpDatetime
        {
            get { return _upDatetime; }
            set { _upDatetime = value; }
        }
        private string _realman = string.Empty;
        /// <summary>
        /// 处理人
        /// </summary>
        public string Realman
        {
            get { return _realman ?? string.Empty; }
            set { _realman = value; }
        }
        private int _isRead;
        /// <summary>
        /// 是否已读1已读0否
        /// </summary>
        public int IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }
        private string _zjType = string.Empty;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string ZjType
        {
            get { return _zjType ?? string.Empty; }
            set { _zjType = value; }
        }
        private string _cfAddress = string.Empty;
        /// <summary>
        /// 处罚地点
        /// </summary>
        public string CfAddress
        {
            get { return _cfAddress ?? string.Empty; }
            set { _cfAddress = value; }
        }
        private int _isonline;
        /// <summary>
        /// 是否已经传到网上违停数据库 （0否1是)
        /// </summary>
        public int Isonline
        {
            get { return _isonline; }
            set { _isonline = value; }
        }
        private string _dealDeptId = string.Empty;
        /// <summary>
        /// 处理人员所在部门
        /// </summary>
        public string DealDeptId
        {
            get { return _dealDeptId ?? string.Empty; }
            set { _dealDeptId = value; }
        }
        private int _isgq;
        /// <summary>
        /// 是否挂起1是0否
        /// </summary>
        public int Isgq
        {
            get { return _isgq; }
            set { _isgq = value; }
        }
        private string _longitude = string.Empty;
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            get { return _longitude ?? string.Empty; }
            set { _longitude = value; }
        }
        private string _latitude = string.Empty;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude
        {
            get { return _latitude ?? string.Empty; }
            set { _latitude = value; }
        }
        private string _pdaNo = string.Empty;
        /// <summary>
        /// 识符号
        /// </summary>
        public string PdaNo
        {
            get { return _pdaNo ?? string.Empty; }
            set { _pdaNo = value; }
        }
        private int _printtzs;
        /// <summary>
        /// 否打印通知书0否1是
        /// </summary>
        public int Printtzs
        {
            get { return _printtzs; }
            set { _printtzs = value; }
        }
        private int _printjds;
        /// <summary>
        /// 否打印决定书0否1是
        /// </summary>
        public int Printjds
        {
            get { return _printjds; }
            set { _printjds = value; }
        }
        private int _dataBytes;
        /// <summary>
        /// 
        /// </summary>
        public int DataBytes
        {
            get { return _dataBytes; }
            set { _dataBytes = value; }
        }
        private int _isaudit;
        /// <summary>
        /// 大队是已否审核 状态 1、审核通过 2、建议作废 -1、同意作废 3、不同意作废
        /// </summary>
        public int Isaudit
        {
            get { return _isaudit; }
            set { _isaudit = value; }
        }
        private int _isedit;
        /// <summary>
        /// 是否修改（-1表示发回到中队，0表示未修改，1表示审核人修改，2表示中队修改）
        /// </summary>
        public int Isedit
        {
            get { return _isedit; }
            set { _isedit = value; }
        }
        private DateTime _auditDate = MinDate;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }
        private DateTime _backDate = MinDate;
        /// <summary>
        /// 退回时间
        /// </summary>
        public DateTime BackDate
        {
            get { return _backDate; }
            set { _backDate = value; }
        }
        private DateTime _editDate = MinDate;
        /// <summary>
        /// 修改完成时间
        /// </summary>
        public DateTime EditDate
        {
            get { return _editDate; }
            set { _editDate = value; }
        }
        private int _isrk;
        /// <summary>
        /// 是否进交警库，0表示不进，1表示进
        /// </summary>
        public int Isrk
        {
            get { return _isrk; }
            set { _isrk = value; }
        }
        private int _isAutoaudit;
        /// <summary>
        /// PDA案件一级审核是否是系统自动审核的
        /// </summary>
        public int IsAutoaudit
        {
            get { return _isAutoaudit; }
            set { _isAutoaudit = value; }
        }

        //合成照片路径
        private string _bigPicAddress;
        public string BigPicAddress
        {
            get { return _bigPicAddress; }
            set { _bigPicAddress = value; }
        }
        //合成文件名称
        private string _bigPicName;
        public string BigPicName
        {
            get { return _bigPicName; }
            set { _bigPicName = value; }
        }

        private string _reason;
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        private int _dayYJ;
        public int DayYJ
        {
            get { return _dayYJ; }
            set { _dayYJ = value; }
        }


        /// <summary>
        /// 合成照片的主键
        /// </summary>
        public string BigPicId { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfCarChecksignEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfCarChecksignEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfCarChecksignEntity();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_CAR_CHECKSIGN_Id].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CheckSignNo) || fields.Contains("*"))
                tmp.CheckSignNo = dr[Parm_INF_CAR_CHECKSIGN_CheckSignNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_TypeNo) || fields.Contains("*"))
                tmp.TypeNo = dr[Parm_INF_CAR_CHECKSIGN_TypeNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_ReSourceId) || fields.Contains("*"))
                tmp.ReSourceId = dr[Parm_INF_CAR_CHECKSIGN_ReSourceId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_DataSource) || fields.Contains("*"))
                tmp.DataSource = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_DataSource].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_INF_CAR_CHECKSIGN_DeptId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_DeptName) || fields.Contains("*"))
                tmp.DeptName = dr[Parm_INF_CAR_CHECKSIGN_DeptName].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CheckDate) || fields.Contains("*"))
                tmp.CheckDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_CheckDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PersonId1) || fields.Contains("*"))
                tmp.PersonId1 = dr[Parm_INF_CAR_CHECKSIGN_PersonId1].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PersonId2) || fields.Contains("*"))
                tmp.PersonId2 = dr[Parm_INF_CAR_CHECKSIGN_PersonId2].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PersonName1) || fields.Contains("*"))
                tmp.PersonName1 = dr[Parm_INF_CAR_CHECKSIGN_PersonName1].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PersonName2) || fields.Contains("*"))
                tmp.PersonName2 = dr[Parm_INF_CAR_CHECKSIGN_PersonName2].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Name) || fields.Contains("*"))
                tmp.Name = dr[Parm_INF_CAR_CHECKSIGN_Name].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Age) || fields.Contains("*"))
                tmp.Age = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Age].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Sex) || fields.Contains("*"))
                tmp.Sex = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Sex].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PersonNo) || fields.Contains("*"))
                tmp.PersonNo = dr[Parm_INF_CAR_CHECKSIGN_PersonNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Address) || fields.Contains("*"))
                tmp.Address = dr[Parm_INF_CAR_CHECKSIGN_Address].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Telephone) || fields.Contains("*"))
                tmp.Telephone = dr[Parm_INF_CAR_CHECKSIGN_Telephone].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CarNo) || fields.Contains("*"))
                tmp.CarNo = dr[Parm_INF_CAR_CHECKSIGN_CarNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CarType) || fields.Contains("*"))
                tmp.CarType = dr[Parm_INF_CAR_CHECKSIGN_CarType].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Road) || fields.Contains("*"))
                tmp.Road = dr[Parm_INF_CAR_CHECKSIGN_Road].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Toward) || fields.Contains("*"))
                tmp.Toward = dr[Parm_INF_CAR_CHECKSIGN_Toward].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CheckSignAddress) || fields.Contains("*"))
                tmp.CheckSignAddress = dr[Parm_INF_CAR_CHECKSIGN_CheckSignAddress].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_SimpleInfo) || fields.Contains("*"))
                tmp.SimpleInfo = dr[Parm_INF_CAR_CHECKSIGN_SimpleInfo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_NoticeNo) || fields.Contains("*"))
                tmp.NoticeNo = dr[Parm_INF_CAR_CHECKSIGN_NoticeNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Whqk) || fields.Contains("*"))
                tmp.Whqk = dr[Parm_INF_CAR_CHECKSIGN_Whqk].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CfapproveNo) || fields.Contains("*"))
                tmp.CfapproveNo = dr[Parm_INF_CAR_CHECKSIGN_CfapproveNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PostNo) || fields.Contains("*"))
                tmp.PostNo = dr[Parm_INF_CAR_CHECKSIGN_PostNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Job) || fields.Contains("*"))
                tmp.Job = dr[Parm_INF_CAR_CHECKSIGN_Job].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CbrDate) || fields.Contains("*"))
                tmp.CbrDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_CbrDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Money) || fields.Contains("*"))
                tmp.Money = double.Parse(dr[Parm_INF_CAR_CHECKSIGN_Money].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PaymentNum) || fields.Contains("*"))
                tmp.PaymentNum = dr[Parm_INF_CAR_CHECKSIGN_PaymentNum].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_State].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_INF_CAR_CHECKSIGN_Remark].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_FinishDate) || fields.Contains("*"))
                tmp.FinishDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_FinishDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isfilter) || fields.Contains("*"))
                tmp.Isfilter = dr[Parm_INF_CAR_CHECKSIGN_Isfilter].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_UpDatetime) || fields.Contains("*"))
                tmp.UpDatetime = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_UpDatetime].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Realman) || fields.Contains("*"))
                tmp.Realman = dr[Parm_INF_CAR_CHECKSIGN_Realman].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_IsRead) || fields.Contains("*"))
                tmp.IsRead = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_IsRead].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_ZjType) || fields.Contains("*"))
                tmp.ZjType = dr[Parm_INF_CAR_CHECKSIGN_ZjType].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CfAddress) || fields.Contains("*"))
                tmp.CfAddress = dr[Parm_INF_CAR_CHECKSIGN_CfAddress].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isonline) || fields.Contains("*"))
                tmp.Isonline = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Isonline].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_DealDeptId) || fields.Contains("*"))
                tmp.DealDeptId = dr[Parm_INF_CAR_CHECKSIGN_DealDeptId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isgq) || fields.Contains("*"))
                tmp.Isgq = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Isgq].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Longitude) || fields.Contains("*"))
                tmp.Longitude = dr[Parm_INF_CAR_CHECKSIGN_Longitude].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Latitude) || fields.Contains("*"))
                tmp.Latitude = dr[Parm_INF_CAR_CHECKSIGN_Latitude].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_PdaNo) || fields.Contains("*"))
                tmp.PdaNo = dr[Parm_INF_CAR_CHECKSIGN_PdaNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Printtzs) || fields.Contains("*"))
                tmp.Printtzs = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Printtzs].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Printjds) || fields.Contains("*"))
                tmp.Printjds = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Printjds].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_DataBytes) || fields.Contains("*"))
                tmp.DataBytes = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_DataBytes].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isaudit) || fields.Contains("*"))
                tmp.Isaudit = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Isaudit].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isedit) || fields.Contains("*"))
                tmp.Isedit = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Isedit].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_AuditDate) || fields.Contains("*"))
                tmp.AuditDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_AuditDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_BackDate) || fields.Contains("*"))
                tmp.BackDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_BackDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_EditDate) || fields.Contains("*"))
                tmp.EditDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_EditDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Isrk) || fields.Contains("*"))
                tmp.Isrk = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_Isrk].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_IsAutoaudit) || fields.Contains("*"))
                tmp.IsAutoaudit = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_IsAutoaudit].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_CAR_CHECKSIGN_RowStatus].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_CAR_CHECKSIGN_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_CAR_CHECKSIGN_CreatorId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_CAR_CHECKSIGN_CreateBy].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_CreateOn].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_CAR_CHECKSIGN_UpdateId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_CAR_CHECKSIGN_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGN_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGN_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_car_checksign">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfCarChecksignEntity inf_car_checksign, SqlParameter[] parms)
        {
            parms[0].Value = inf_car_checksign.CheckSignNo;
            parms[1].Value = inf_car_checksign.TypeNo;
            parms[2].Value = inf_car_checksign.ReSourceId;
            parms[3].Value = inf_car_checksign.DataSource;
            parms[4].Value = inf_car_checksign.DeptId;
            parms[5].Value = inf_car_checksign.DeptName;
            parms[6].Value = inf_car_checksign.CheckDate;
            parms[7].Value = inf_car_checksign.PersonId1;
            parms[8].Value = inf_car_checksign.PersonId2;
            parms[9].Value = inf_car_checksign.PersonName1;
            parms[10].Value = inf_car_checksign.PersonName2;
            parms[11].Value = inf_car_checksign.Name;
            parms[12].Value = inf_car_checksign.Age;
            parms[13].Value = inf_car_checksign.Sex;
            parms[14].Value = inf_car_checksign.PersonNo;
            parms[15].Value = inf_car_checksign.Address;
            parms[16].Value = inf_car_checksign.Telephone;
            parms[17].Value = inf_car_checksign.CarNo;
            parms[18].Value = inf_car_checksign.CarType;
            parms[19].Value = inf_car_checksign.Road;
            parms[20].Value = inf_car_checksign.Toward;
            parms[21].Value = inf_car_checksign.CheckSignAddress;
            parms[22].Value = inf_car_checksign.SimpleInfo;
            parms[23].Value = inf_car_checksign.NoticeNo;
            parms[24].Value = inf_car_checksign.Whqk;
            parms[25].Value = inf_car_checksign.CfapproveNo;
            parms[26].Value = inf_car_checksign.PostNo;
            parms[27].Value = inf_car_checksign.Job;
            parms[28].Value = inf_car_checksign.CbrDate;
            parms[29].Value = inf_car_checksign.Money;
            parms[30].Value = inf_car_checksign.PaymentNum;
            parms[31].Value = inf_car_checksign.State;
            parms[32].Value = inf_car_checksign.Remark;
            parms[33].Value = inf_car_checksign.FinishDate;
            parms[34].Value = inf_car_checksign.Isfilter;
            parms[35].Value = inf_car_checksign.UpDatetime;
            parms[36].Value = inf_car_checksign.Realman;
            parms[37].Value = inf_car_checksign.IsRead;
            parms[38].Value = inf_car_checksign.ZjType;
            parms[39].Value = inf_car_checksign.CfAddress;
            parms[40].Value = inf_car_checksign.Isonline;
            parms[41].Value = inf_car_checksign.DealDeptId;
            parms[42].Value = inf_car_checksign.Isgq;
            parms[43].Value = inf_car_checksign.Longitude;
            parms[44].Value = inf_car_checksign.Latitude;
            parms[45].Value = inf_car_checksign.PdaNo;
            parms[46].Value = inf_car_checksign.Printtzs;
            parms[47].Value = inf_car_checksign.Printjds;
            parms[48].Value = inf_car_checksign.DataBytes;
            parms[49].Value = inf_car_checksign.Isaudit;
            parms[50].Value = inf_car_checksign.Isedit;
            parms[51].Value = inf_car_checksign.AuditDate;
            parms[52].Value = inf_car_checksign.BackDate;
            parms[53].Value = inf_car_checksign.EditDate;
            parms[54].Value = inf_car_checksign.Isrk;
            parms[55].Value = inf_car_checksign.IsAutoaudit;
            parms[56].Value = inf_car_checksign.RowStatus;
            parms[57].Value = inf_car_checksign.CreatorId;
            parms[58].Value = inf_car_checksign.CreateBy;
            parms[59].Value = inf_car_checksign.CreateOn;
            parms[60].Value = inf_car_checksign.UpdateId;
            parms[61].Value = inf_car_checksign.UpdateBy;
            parms[62].Value = inf_car_checksign.UpdateOn;
            parms[63].Value = inf_car_checksign.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfCarChecksignEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_CHECKSIGN_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_CAR_CHECKSIGN_CheckSignNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_TypeNo, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_ReSourceId, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_DataSource, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_DeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_DeptName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CheckDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PersonId1, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PersonId2, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PersonName1, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PersonName2, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Name, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Age, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Sex, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PersonNo, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Address, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Telephone, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CarNo, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CarType, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Road, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Toward, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CheckSignAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_SimpleInfo, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_NoticeNo, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Whqk, SqlDbType.NVarChar, 400),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CfapproveNo, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PostNo, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Job, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CbrDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Money, SqlDbType.Money, 19),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PaymentNum, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Remark, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_FinishDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isfilter, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_UpDatetime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Realman, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_IsRead, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_ZjType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CfAddress, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isonline, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_DealDeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isgq, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Longitude, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Latitude, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_PdaNo, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Printtzs, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Printjds, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_DataBytes, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isaudit, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isedit, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_AuditDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_BackDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_EditDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_Isrk, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_IsAutoaudit, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CAR_CHECKSIGN_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_CAR_CHECKSIGN_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_CHECKSIGN_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }

    public class CheckSignDetails
    {
        /// <summary>
        /// 车辆主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        public string CheckDate { get; set; }

        /// <summary>
        /// 合成照片ID
        /// </summary>
        public string BigPicId { get; set; }

        /// <summary>
        /// 合成照片名称
        /// </summary>
        public string BigPicAddress { get; set; }

        /// <summary>
        /// 合成照片名称
        /// </summary>
        public string BigPicName { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int Andit { get; set; }
    }
}

