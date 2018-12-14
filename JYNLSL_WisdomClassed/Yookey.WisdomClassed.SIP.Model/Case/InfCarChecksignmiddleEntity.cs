//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNMIDDLEEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/6/4 9:11:56
//  功能描述：INF_CAR_CHECKSIGNMIDDLE表实体
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
    /// 违法停车手机上传表
    /// </summary>
    [Serializable]
    public class InfCarChecksignmiddleEntity : ModelImp.BaseModel<InfCarChecksignmiddleEntity>
    {
        public InfCarChecksignmiddleEntity()
        {
            TB_Name = TB_INF_CAR_CHECKSIGNMIDDLE;
            Parm_Id = Parm_INF_CAR_CHECKSIGNMIDDLE_Id;
            Parm_Version = Parm_INF_CAR_CHECKSIGNMIDDLE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_CAR_CHECKSIGNMIDDLE_Insert;
            Sql_Update = Sql_INF_CAR_CHECKSIGNMIDDLE_Update;
            Sql_Delete = Sql_INF_CAR_CHECKSIGNMIDDLE_Delete;
        }
        #region Const of table INF_CAR_CHECKSIGNMIDDLE
        /// <summary>
        /// Table INF_CAR_CHECKSIGNMIDDLE
        /// </summary>
        public const string TB_INF_CAR_CHECKSIGNMIDDLE = "INF_CAR_CHECKSIGNMIDDLE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Address
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Address = "Address";
        /// <summary>
        /// Parm Age
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Age = "Age";
        /// <summary>
        /// Parm CarNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CarNo = "CarNo";
        /// <summary>
        /// Parm CarType
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CarType = "CarType";
        /// <summary>
        /// Parm Cbrdate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Cbrdate = "Cbrdate";
        /// <summary>
        /// Parm CfAddress
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CfAddress = "CfAddress";
        /// <summary>
        /// Parm Cfapproveno
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Cfapproveno = "Cfapproveno";
        /// <summary>
        /// Parm CheckDate
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CheckDate = "CheckDate";
        /// <summary>
        /// Parm CheckSignAddress
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignAddress = "CheckSignAddress";
        /// <summary>
        /// Parm CheckSignNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignNo = "CheckSignNo";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DataBytes
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_DataBytes = "DataBytes";
        /// <summary>
        /// Parm DataSource
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_DataSource = "DataSource";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_DeptName = "DeptName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Id = "Id";
        /// <summary>
        /// Parm Job
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Job = "Job";
        /// <summary>
        /// Parm Latitude
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Latitude = "Latitude";
        /// <summary>
        /// Parm Longitude
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Longitude = "Longitude";
        /// <summary>
        /// Parm Money
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Money = "Money";
        /// <summary>
        /// Parm Name
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Name = "Name";
        /// <summary>
        /// Parm NoticeNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_NoticeNo = "NoticeNo";
        /// <summary>
        /// Parm PDANo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PDANo = "PDANo";
        /// <summary>
        /// Parm PersonId1
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId1 = "PersonId1";
        /// <summary>
        /// Parm PersonId2
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId2 = "PersonId2";
        /// <summary>
        /// Parm PersonName1
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName1 = "PersonName1";
        /// <summary>
        /// Parm PersonName2
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName2 = "PersonName2";
        /// <summary>
        /// Parm Personno
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Personno = "Personno";
        /// <summary>
        /// Parm PostNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_PostNo = "PostNo";
        /// <summary>
        /// Parm Printjds
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Printjds = "Printjds";
        /// <summary>
        /// Parm Printtzs
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Printtzs = "Printtzs";
        /// <summary>
        /// Parm Realman
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Realman = "Realman";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Remark = "Remark";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_ResourceId = "ResourceId";
        /// <summary>
        /// Parm Road
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Road = "Road";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Sex
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Sex = "Sex";
        /// <summary>
        /// Parm Simpleinfo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Simpleinfo = "Simpleinfo";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_State = "State";
        /// <summary>
        /// Parm Telephone
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Telephone = "Telephone";
        /// <summary>
        /// Parm Toward
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Toward = "Toward";
        /// <summary>
        /// Parm TypeNo
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_TypeNo = "TypeNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Version = "Version";
        /// <summary>
        /// Parm Whqk
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Whqk = "Whqk";
        /// <summary>
        /// Parm Zjtype
        /// </summary>
        public const string Parm_INF_CAR_CHECKSIGNMIDDLE_Zjtype = "Zjtype";
        /// <summary>
        /// Insert Query Of INF_CAR_CHECKSIGNMIDDLE
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGNMIDDLE_Insert = "insert into INF_CAR_CHECKSIGNMIDDLE(Address,Age,CarNo,CarType,Cbrdate,CfAddress,Cfapproveno,CheckDate,CheckSignAddress,CheckSignNo,CreateBy,CreateOn,CreatorId,DataBytes,DataSource,DeptId,DeptName,Job,Latitude,Longitude,Money,Name,NoticeNo,PDANo,PersonId1,PersonId2,PersonName1,PersonName2,Personno,PostNo,Printjds,Printtzs,Realman,Remark,ResourceId,Road,RowStatus,Sex,Simpleinfo,State,Telephone,Toward,TypeNo,UpdateBy,UpdateId,UpdateOn,Whqk,Zjtype,Id) values(@Address,@Age,@CarNo,@CarType,@Cbrdate,@CfAddress,@Cfapproveno,@CheckDate,@CheckSignAddress,@CheckSignNo,@CreateBy,@CreateOn,@CreatorId,@DataBytes,@DataSource,@DeptId,@DeptName,@Job,@Latitude,@Longitude,@Money,@Name,@NoticeNo,@PDANo,@PersonId1,@PersonId2,@PersonName1,@PersonName2,@Personno,@PostNo,@Printjds,@Printtzs,@Realman,@Remark,@ResourceId,@Road,@RowStatus,@Sex,@Simpleinfo,@State,@Telephone,@Toward,@TypeNo,@UpdateBy,@UpdateId,@UpdateOn,@Whqk,@Zjtype,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_CAR_CHECKSIGNMIDDLE
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGNMIDDLE_Update = "update INF_CAR_CHECKSIGNMIDDLE set Address=@Address,Age=@Age,CarNo=@CarNo,CarType=@CarType,Cbrdate=@Cbrdate,CfAddress=@CfAddress,Cfapproveno=@Cfapproveno,CheckDate=@CheckDate,CheckSignAddress=@CheckSignAddress,CheckSignNo=@CheckSignNo,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataBytes=@DataBytes,DataSource=@DataSource,DeptId=@DeptId,DeptName=@DeptName,Job=@Job,Latitude=@Latitude,Longitude=@Longitude,Money=@Money,Name=@Name,NoticeNo=@NoticeNo,PDANo=@PDANo,PersonId1=@PersonId1,PersonId2=@PersonId2,PersonName1=@PersonName1,PersonName2=@PersonName2,Personno=@Personno,PostNo=@PostNo,Printjds=@Printjds,Printtzs=@Printtzs,Realman=@Realman,Remark=@Remark,ResourceId=@ResourceId,Road=@Road,RowStatus=@RowStatus,Sex=@Sex,Simpleinfo=@Simpleinfo,State=@State,Telephone=@Telephone,Toward=@Toward,TypeNo=@TypeNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Whqk=@Whqk,Zjtype=@Zjtype where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_CAR_CHECKSIGNMIDDLE_Delete = "update INF_CAR_CHECKSIGNMIDDLE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _checkSignNo = string.Empty;
        /// <summary>
        /// Varchar2(50    案件编号
        /// </summary>
        public string CheckSignNo
        {
            get { return _checkSignNo ?? string.Empty; }
            set { _checkSignNo = value; }
        }
        private string _resourceId = string.Empty;
        /// <summary>
        /// Varchar2(20    案件来源编号
        /// </summary>
        public string ResourceId
        {
            get { return _resourceId ?? string.Empty; }
            set { _resourceId = value; }
        }
        private int _dataSource;
        /// <summary>
        /// Number(38,0    来源
        /// </summary>
        public int DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }
        private DateTime _checkDate = MinDate;
        /// <summary>
        /// Date,    检查日期
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
        /// 执法队员1姓名
        /// </summary>
        public string PersonName1
        {
            get { return _personName1 ?? string.Empty; }
            set { _personName1 = value; }
        }
        private string _personName2 = string.Empty;
        /// <summary>
        /// 执法队员2姓名
        /// </summary>
        public string PersonName2
        {
            get { return _personName2 ?? string.Empty; }
            set { _personName2 = value; }
        }
        private string _carNo = string.Empty;
        /// <summary>
        /// 车牌号
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
        ///  路段代码
        /// </summary>
        public string Road
        {
            get { return _road ?? string.Empty; }
            set { _road = value; }
        }
        private string _toward = string.Empty;
        /// <summary>
        /// 方向（已废弃）
        /// </summary>
        public string Toward
        {
            get { return _toward ?? string.Empty; }
            set { _toward = value; }
        }
        private string _checkSignAddress = string.Empty;
        /// <summary>
        /// 违章详细地点
        /// </summary>
        public string CheckSignAddress
        {
            get { return _checkSignAddress ?? string.Empty; }
            set { _checkSignAddress = value; }
        }
        private string _noticeNo = string.Empty;
        /// <summary>
        /// 通知书编号
        /// </summary>
        public string NoticeNo
        {
            get { return _noticeNo ?? string.Empty; }
            set { _noticeNo = value; }
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
        private string _pDANo = string.Empty;
        /// <summary>
        /// 设备编号
        /// </summary>
        public string PDANo
        {
            get { return _pDANo ?? string.Empty; }
            set { _pDANo = value; }
        }
        private int _printtzs;
        /// <summary>
        /// 是否打印通知书
        /// </summary>
        public int Printtzs
        {
            get { return _printtzs; }
            set { _printtzs = value; }
        }
        private int _printjds;
        /// <summary>
        /// 是否打印决定书（已废弃）
        /// </summary>
        public int Printjds
        {
            get { return _printjds; }
            set { _printjds = value; }
        }
        private int _dataBytes;
        /// <summary>
        /// 上传的字节数
        /// </summary>
        public int DataBytes
        {
            get { return _dataBytes; }
            set { _dataBytes = value; }
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
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _zjtype = string.Empty;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string Zjtype
        {
            get { return _zjtype ?? string.Empty; }
            set { _zjtype = value; }
        }
        private string _personno = string.Empty;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string Personno
        {
            get { return _personno ?? string.Empty; }
            set { _personno = value; }
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
        ///  电话
        /// </summary>
        public string Telephone
        {
            get { return _telephone ?? string.Empty; }
            set { _telephone = value; }
        }
        private string _simpleinfo = string.Empty;
        /// <summary>
        /// 案情摘要
        /// </summary>
        public string Simpleinfo
        {
            get { return _simpleinfo ?? string.Empty; }
            set { _simpleinfo = value; }
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
        private string _cfapproveno = string.Empty;
        /// <summary>
        /// 处罚决定书号
        /// </summary>
        public string Cfapproveno
        {
            get { return _cfapproveno ?? string.Empty; }
            set { _cfapproveno = value; }
        }
        private string _postNo = string.Empty;
        /// <summary>
        /// 事件通乱书编号
        /// </summary>
        public string PostNo
        {
            get { return _postNo ?? string.Empty; }
            set { _postNo = value; }
        }
        private string _job = string.Empty;
        /// <summary>
        /// 罚没款方式
        /// </summary>
        public string Job
        {
            get { return _job ?? string.Empty; }
            set { _job = value; }
        }
        private DateTime _cbrdate = MinDate;
        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime Cbrdate
        {
            get { return _cbrdate; }
            set { _cbrdate = value; }
        }
        private Double _money;
        /// <summary>
        /// 处罚金额
        /// </summary>
        public Double Money
        {
            get { return _money; }
            set { _money = value; }
        }
        private string _state = string.Empty;
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            get { return _state ?? string.Empty; }
            set { _state = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
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
        private string _realman = string.Empty;
        /// <summary>
        /// 处理人
        /// </summary>
        public string Realman
        {
            get { return _realman ?? string.Empty; }
            set { _realman = value; }
        }
        private string _deptId = string.Empty;
        /// <summary>
        /// 
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfCarChecksignmiddleEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfCarChecksignmiddleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfCarChecksignmiddleEntity();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Id].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignNo) || fields.Contains("*"))
                tmp.CheckSignNo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_ResourceId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_DataSource) || fields.Contains("*"))
                tmp.DataSource = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_DataSource].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckDate) || fields.Contains("*"))
                tmp.CheckDate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CheckDate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId1) || fields.Contains("*"))
                tmp.PersonId1 = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId1].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId2) || fields.Contains("*"))
                tmp.PersonId2 = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId2].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName1) || fields.Contains("*"))
                tmp.PersonName1 = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName1].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName2) || fields.Contains("*"))
                tmp.PersonName2 = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName2].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CarNo) || fields.Contains("*"))
                tmp.CarNo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CarNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CarType) || fields.Contains("*"))
                tmp.CarType = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CarType].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Road) || fields.Contains("*"))
                tmp.Road = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Road].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Toward) || fields.Contains("*"))
                tmp.Toward = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Toward].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignAddress) || fields.Contains("*"))
                tmp.CheckSignAddress = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignAddress].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_NoticeNo) || fields.Contains("*"))
                tmp.NoticeNo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_NoticeNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Longitude) || fields.Contains("*"))
                tmp.Longitude = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Longitude].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Latitude) || fields.Contains("*"))
                tmp.Latitude = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Latitude].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PDANo) || fields.Contains("*"))
                tmp.PDANo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PDANo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Printtzs) || fields.Contains("*"))
                tmp.Printtzs = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Printtzs].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Printjds) || fields.Contains("*"))
                tmp.Printjds = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Printjds].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_DataBytes) || fields.Contains("*"))
                tmp.DataBytes = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_DataBytes].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_TypeNo) || fields.Contains("*"))
                tmp.TypeNo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_TypeNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Name) || fields.Contains("*"))
                tmp.Name = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Name].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Age) || fields.Contains("*"))
                tmp.Age = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Age].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Sex) || fields.Contains("*"))
                tmp.Sex = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Sex].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Zjtype) || fields.Contains("*"))
                tmp.Zjtype = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Zjtype].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Personno) || fields.Contains("*"))
                tmp.Personno = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Personno].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Address) || fields.Contains("*"))
                tmp.Address = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Address].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Telephone) || fields.Contains("*"))
                tmp.Telephone = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Telephone].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Simpleinfo) || fields.Contains("*"))
                tmp.Simpleinfo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Simpleinfo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Whqk) || fields.Contains("*"))
                tmp.Whqk = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Whqk].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Cfapproveno) || fields.Contains("*"))
                tmp.Cfapproveno = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Cfapproveno].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_PostNo) || fields.Contains("*"))
                tmp.PostNo = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_PostNo].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Job) || fields.Contains("*"))
                tmp.Job = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Job].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Cbrdate) || fields.Contains("*"))
                tmp.Cbrdate = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Cbrdate].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Money) || fields.Contains("*"))
                tmp.Money = Double.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Money].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_State) || fields.Contains("*"))
                tmp.State = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_State].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Remark].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CfAddress) || fields.Contains("*"))
                tmp.CfAddress = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CfAddress].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Realman) || fields.Contains("*"))
                tmp.Realman = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Realman].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_DeptId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_DeptName) || fields.Contains("*"))
                tmp.DeptName = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_DeptName].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_RowStatus].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CreatorId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CreateBy].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_CreateOn].ToString());
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateId].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_car_checksignmiddle">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfCarChecksignmiddleEntity inf_car_checksignmiddle, SqlParameter[] parms)
        {
            parms[0].Value = inf_car_checksignmiddle.CheckSignNo;
            parms[1].Value = inf_car_checksignmiddle.ResourceId;
            parms[2].Value = inf_car_checksignmiddle.DataSource;
            parms[3].Value = inf_car_checksignmiddle.CheckDate;
            parms[4].Value = inf_car_checksignmiddle.PersonId1;
            parms[5].Value = inf_car_checksignmiddle.PersonId2;
            parms[6].Value = inf_car_checksignmiddle.PersonName1;
            parms[7].Value = inf_car_checksignmiddle.PersonName2;
            parms[8].Value = inf_car_checksignmiddle.CarNo;
            parms[9].Value = inf_car_checksignmiddle.CarType;
            parms[10].Value = inf_car_checksignmiddle.Road;
            parms[11].Value = inf_car_checksignmiddle.Toward;
            parms[12].Value = inf_car_checksignmiddle.CheckSignAddress;
            parms[13].Value = inf_car_checksignmiddle.NoticeNo;
            parms[14].Value = inf_car_checksignmiddle.Longitude;
            parms[15].Value = inf_car_checksignmiddle.Latitude;
            parms[16].Value = inf_car_checksignmiddle.PDANo;
            parms[17].Value = inf_car_checksignmiddle.Printtzs;
            parms[18].Value = inf_car_checksignmiddle.Printjds;
            parms[19].Value = inf_car_checksignmiddle.DataBytes;
            parms[20].Value = inf_car_checksignmiddle.TypeNo;
            parms[21].Value = inf_car_checksignmiddle.Name;
            parms[22].Value = inf_car_checksignmiddle.Age;
            parms[23].Value = inf_car_checksignmiddle.Sex;
            parms[24].Value = inf_car_checksignmiddle.Zjtype;
            parms[25].Value = inf_car_checksignmiddle.Personno;
            parms[26].Value = inf_car_checksignmiddle.Address;
            parms[27].Value = inf_car_checksignmiddle.Telephone;
            parms[28].Value = inf_car_checksignmiddle.Simpleinfo;
            parms[29].Value = inf_car_checksignmiddle.Whqk;
            parms[30].Value = inf_car_checksignmiddle.Cfapproveno;
            parms[31].Value = inf_car_checksignmiddle.PostNo;
            parms[32].Value = inf_car_checksignmiddle.Job;
            parms[33].Value = inf_car_checksignmiddle.Cbrdate;
            parms[34].Value = inf_car_checksignmiddle.Money;
            parms[35].Value = inf_car_checksignmiddle.State;
            parms[36].Value = inf_car_checksignmiddle.Remark;
            parms[37].Value = inf_car_checksignmiddle.CfAddress;
            parms[38].Value = inf_car_checksignmiddle.Realman;
            parms[39].Value = inf_car_checksignmiddle.DeptId;
            parms[40].Value = inf_car_checksignmiddle.DeptName;
            parms[41].Value = inf_car_checksignmiddle.RowStatus;
            parms[42].Value = inf_car_checksignmiddle.CreatorId;
            parms[43].Value = inf_car_checksignmiddle.CreateBy;
            parms[44].Value = inf_car_checksignmiddle.CreateOn;
            parms[45].Value = inf_car_checksignmiddle.UpdateId;
            parms[46].Value = inf_car_checksignmiddle.UpdateBy;
            parms[47].Value = inf_car_checksignmiddle.UpdateOn;
            parms[48].Value = inf_car_checksignmiddle.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfCarChecksignmiddleEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_CHECKSIGNMIDDLE_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignNo, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_ResourceId, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_DataSource, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId1, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonId2, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName1, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PersonName2, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CarNo, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CarType, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Road, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Toward, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CheckSignAddress, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_NoticeNo, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Longitude, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Latitude, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PDANo, SqlDbType.NVarChar, 1000),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Printtzs, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Printjds, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_DataBytes, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_TypeNo, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Name, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Age, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Sex, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Zjtype, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Personno, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Address, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Telephone, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Simpleinfo, SqlDbType.NVarChar, 500),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Whqk, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Cfapproveno, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_PostNo, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Job, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Cbrdate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Money, SqlDbType.Float, 53),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_State, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Remark, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CfAddress, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Realman, SqlDbType.NVarChar, 20),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_DeptId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_DeptName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateBy, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_INF_CAR_CHECKSIGNMIDDLE_Id, SqlDbType.NVarChar, 50)
                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CAR_CHECKSIGNMIDDLE_Insert, parms);
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
    /// 数据列表
    /// </summary>
    public class CarList
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 违章日期
        /// </summary>
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// 单位ID
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 剩余审批天数
        /// </summary>
        public int DayNum { get; set; }

        /// <summary>
        /// 剩余审批小时数
        /// </summary>
        public string Hours { get; set; }

        /// <summary>
        /// 通知书编号
        /// </summary>
        public string NoticeNo { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
    }

    public class CheckMiddleDetails
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 通知书编号
        /// </summary>
        public string NoticeNo { get; set; }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CarType { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 违章日期
        /// </summary>
        public string CheckDate { get; set; }
        /// <summary>
        /// 执法队员一
        /// </summary>
        public string PersonFirst { get; set; }
        /// <summary>
        /// 执法队员二
        /// </summary>
        public string PersonSecond { get; set; }
        /// <summary>
        /// 违章地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 违停图片集合
        /// </summary>
        public List<string> PicItems { get; set; }
    }
}

