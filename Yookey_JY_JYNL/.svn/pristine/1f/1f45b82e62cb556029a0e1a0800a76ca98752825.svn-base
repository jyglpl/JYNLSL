using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.SealUp
{
    /// <summary>
    /// 查封管理
    /// </summary>
    [Serializable]
    public class SealUpEntity : ModelImp.BaseModel<SealUpEntity>
    {
        public SealUpEntity()
        {
            TB_Name = TB_SealUp;
            Parm_Id = Parm_SealUp_Id;
            Parm_Version = Parm_SealUp_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_SealUp_Insert;
            Sql_Update = Sql_SealUp_Update;
            Sql_Delete = Sql_SealUp_Delete;
        }
        #region Const of table SealUp
        /// <summary>
        /// Table SealUp
        /// </summary>
        public const string TB_SealUp = "SealUp";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseAddress
        /// </summary>
        public const string Parm_SealUp_CaseAddress = "CaseAddress";
        /// <summary>
        /// Parm CaseDate
        /// </summary>
        public const string Parm_SealUp_CaseDate = "CaseDate";
        /// <summary>
        /// Parm CaseFact
        /// </summary>
        public const string Parm_SealUp_CaseFact = "CaseFact";
        /// <summary>
        /// Parm CaseInfoNo
        /// </summary>
        public const string Parm_SealUp_CaseInfoNo = "CaseInfoNo";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_SealUp_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_SealUp_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_SealUp_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_SealUp_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_SealUp_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DataSource
        /// </summary>
        public const string Parm_SealUp_DataSource = "DataSource";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_SealUp_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm DepartmentName
        /// </summary>
        public const string Parm_SealUp_DepartmentName = "DepartmentName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_SealUp_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_SealUp_Remark = "Remark";
        /// <summary>
        /// Parm RePersonelIdFist
        /// </summary>
        public const string Parm_SealUp_RePersonelIdFist = "RePersonelIdFist";
        /// <summary>
        /// Parm RePersonelIdSecond
        /// </summary>
        public const string Parm_SealUp_RePersonelIdSecond = "RePersonelIdSecond";
        /// <summary>
        /// Parm RePersonelNameFist
        /// </summary>
        public const string Parm_SealUp_RePersonelNameFist = "RePersonelNameFist";
        /// <summary>
        /// Parm RePersonelNameSecond
        /// </summary>
        public const string Parm_SealUp_RePersonelNameSecond = "RePersonelNameSecond";
        /// <summary>
        /// Parm ReSource
        /// </summary>
        public const string Parm_SealUp_ReSource = "ReSource";
        /// <summary>
        /// Parm ReSourceName
        /// </summary>
        public const string Parm_SealUp_ReSourceName = "ReSourceName";
        /// <summary>
        /// Parm RoadName
        /// </summary>
        public const string Parm_SealUp_RoadName = "RoadName";
        /// <summary>
        /// Parm RoadNo
        /// </summary>
        public const string Parm_SealUp_RoadNo = "RoadNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_SealUp_RowStatus = "RowStatus";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_SealUp_State = "State";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_SealUp_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetAge
        /// </summary>
        public const string Parm_SealUp_TargetAge = "TargetAge";
        /// <summary>
        /// Parm TargetDuty
        /// </summary>
        public const string Parm_SealUp_TargetDuty = "TargetDuty";
        /// <summary>
        /// Parm TargetEmail
        /// </summary>
        public const string Parm_SealUp_TargetEmail = "TargetEmail";
        /// <summary>
        /// Parm TargetGender
        /// </summary>
        public const string Parm_SealUp_TargetGender = "TargetGender";
        /// <summary>
        /// Parm TargetMobile
        /// </summary>
        public const string Parm_SealUp_TargetMobile = "TargetMobile";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_SealUp_TargetName = "TargetName";
        /// <summary>
        /// Parm TargetPaperNum
        /// </summary>
        public const string Parm_SealUp_TargetPaperNum = "TargetPaperNum";
        /// <summary>
        /// Parm TargetPaperType
        /// </summary>
        public const string Parm_SealUp_TargetPaperType = "TargetPaperType";
        /// <summary>
        /// Parm TargetPhone
        /// </summary>
        public const string Parm_SealUp_TargetPhone = "TargetPhone";
        /// <summary>
        /// Parm TargetType
        /// </summary>
        public const string Parm_SealUp_TargetType = "TargetType";
        /// <summary>
        /// Parm TargetUnit
        /// </summary>
        public const string Parm_SealUp_TargetUnit = "TargetUnit";
        /// <summary>
        /// Parm TargetZipCode
        /// </summary>
        public const string Parm_SealUp_TargetZipCode = "TargetZipCode";
        /// <summary>
        /// Parm UdPersonelIdFirst
        /// </summary>
        public const string Parm_SealUp_UdPersonelIdFirst = "UdPersonelIdFirst";
        /// <summary>
        /// Parm UdPersonelIdSecond
        /// </summary>
        public const string Parm_SealUp_UdPersonelIdSecond = "UdPersonelIdSecond";
        /// <summary>
        /// Parm UdPersonelNameFirst
        /// </summary>
        public const string Parm_SealUp_UdPersonelNameFirst = "UdPersonelNameFirst";
        /// <summary>
        /// Parm UdPersonelNameSecond
        /// </summary>
        public const string Parm_SealUp_UdPersonelNameSecond = "UdPersonelNameSecond";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_SealUp_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_SealUp_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_SealUp_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_SealUp_Version = "Version";
        /// <summary>
        /// Insert Query Of SealUp
        /// </summary>
        public const string Sql_SealUp_Insert = "insert into SealUp(CaseAddress,CaseDate,CaseFact,CaseInfoNo,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DataSource,DepartmentId,DepartmentName,Remark,RePersonelIdFist,RePersonelIdSecond,RePersonelNameFist,RePersonelNameSecond,ReSource,ReSourceName,RoadName,RoadNo,RowStatus,State,TargetAddress,TargetAge,TargetDuty,TargetEmail,TargetGender,TargetMobile,TargetName,TargetPaperNum,TargetPaperType,TargetPhone,TargetType,TargetUnit,TargetZipCode,UdPersonelIdFirst,UdPersonelIdSecond,UdPersonelNameFirst,UdPersonelNameSecond,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseAddress,@CaseDate,@CaseFact,@CaseInfoNo,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DataSource,@DepartmentId,@DepartmentName,@Remark,@RePersonelIdFist,@RePersonelIdSecond,@RePersonelNameFist,@RePersonelNameSecond,@ReSource,@ReSourceName,@RoadName,@RoadNo,@RowStatus,@State,@TargetAddress,@TargetAge,@TargetDuty,@TargetEmail,@TargetGender,@TargetMobile,@TargetName,@TargetPaperNum,@TargetPaperType,@TargetPhone,@TargetType,@TargetUnit,@TargetZipCode,@UdPersonelIdFirst,@UdPersonelIdSecond,@UdPersonelNameFirst,@UdPersonelNameSecond,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of SealUp
        /// </summary>
        public const string Sql_SealUp_Update = "update SealUp set CaseAddress=@CaseAddress,CaseDate=@CaseDate,CaseFact=@CaseFact,CaseInfoNo=@CaseInfoNo,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DataSource=@DataSource,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,Remark=@Remark,RePersonelIdFist=@RePersonelIdFist,RePersonelIdSecond=@RePersonelIdSecond,RePersonelNameFist=@RePersonelNameFist,RePersonelNameSecond=@RePersonelNameSecond,ReSource=@ReSource,ReSourceName=@ReSourceName,RoadName=@RoadName,RoadNo=@RoadNo,RowStatus=@RowStatus,State=@State,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetDuty=@TargetDuty,TargetEmail=@TargetEmail,TargetGender=@TargetGender,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,TargetPhone=@TargetPhone,TargetType=@TargetType,TargetUnit=@TargetUnit,TargetZipCode=@TargetZipCode,UdPersonelIdFirst=@UdPersonelIdFirst,UdPersonelIdSecond=@UdPersonelIdSecond,UdPersonelNameFirst=@UdPersonelNameFirst,UdPersonelNameSecond=@UdPersonelNameSecond,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_SealUp_Delete = "update SealUp set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoNo = string.Empty;
        /// <summary>
        /// 案件内部编号
        /// </summary>
        public string CaseInfoNo
        {
            get { return _caseInfoNo ?? string.Empty; }
            set { _caseInfoNo = value; }
        }
        private int _dataSource;
        /// <summary>
        /// 案件登记来源（1：手机 2：PC）
        /// </summary>
        public int DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }
        private string _reSource = string.Empty;
        /// <summary>
        /// 案件来源（多个来源使用逗号分隔）
        /// </summary>
        public string ReSource
        {
            get { return _reSource ?? string.Empty; }
            set { _reSource = value; }
        }
        private string _reSourceName = string.Empty;
        /// <summary>
        /// 案件来源中文名称
        /// </summary>
        public string ReSourceName
        {
            get { return _reSourceName ?? string.Empty; }
            set { _reSourceName = value; }
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
        private string _departmentId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _departmentName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName ?? string.Empty; }
            set { _departmentName = value; }
        }
        private string _rePersonelIdFist = string.Empty;
        /// <summary>
        /// 执法队员一（编号）
        /// </summary>
        public string RePersonelIdFist
        {
            get { return _rePersonelIdFist ?? string.Empty; }
            set { _rePersonelIdFist = value; }
        }
        private string _rePersonelIdSecond = string.Empty;
        /// <summary>
        /// 执法队员二（编号）
        /// </summary>
        public string RePersonelIdSecond
        {
            get { return _rePersonelIdSecond ?? string.Empty; }
            set { _rePersonelIdSecond = value; }
        }
        private string _rePersonelNameFist = string.Empty;
        /// <summary>
        /// 执法队员一（姓名）
        /// </summary>
        public string RePersonelNameFist
        {
            get { return _rePersonelNameFist ?? string.Empty; }
            set { _rePersonelNameFist = value; }
        }
        private string _rePersonelNameSecond = string.Empty;
        /// <summary>
        /// 执法队员二（姓名）
        /// </summary>
        public string RePersonelNameSecond
        {
            get { return _rePersonelNameSecond ?? string.Empty; }
            set { _rePersonelNameSecond = value; }
        }
        private string _udPersonelIdFirst = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UdPersonelIdFirst
        {
            get { return _udPersonelIdFirst ?? string.Empty; }
            set { _udPersonelIdFirst = value; }
        }
        private string _udPersonelIdSecond = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UdPersonelIdSecond
        {
            get { return _udPersonelIdSecond ?? string.Empty; }
            set { _udPersonelIdSecond = value; }
        }
        private string _udPersonelNameFirst = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UdPersonelNameFirst
        {
            get { return _udPersonelNameFirst ?? string.Empty; }
            set { _udPersonelNameFirst = value; }
        }
        private string _udPersonelNameSecond = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UdPersonelNameSecond
        {
            get { return _udPersonelNameSecond ?? string.Empty; }
            set { _udPersonelNameSecond = value; }
        }
        private DateTime _caseDate = MinDate;
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime CaseDate
        {
            get { return _caseDate; }
            set { _caseDate = value; }
        }
        private string _caseAddress = string.Empty;
        /// <summary>
        /// 登记地点
        /// </summary>
        public string CaseAddress
        {
            get { return _caseAddress ?? string.Empty; }
            set { _caseAddress = value; }
        }
        private string _roadNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RoadNo
        {
            get { return _roadNo ?? string.Empty; }
            set { _roadNo = value; }
        }
        private string _roadName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RoadName
        {
            get { return _roadName ?? string.Empty; }
            set { _roadName = value; }
        }
        private string _caseFact = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CaseFact
        {
            get { return _caseFact ?? string.Empty; }
            set { _caseFact = value; }
        }
        private string _targetType = string.Empty;
        /// <summary>
        /// 当事人类型
        /// </summary>
        public string TargetType
        {
            get { return _targetType ?? string.Empty; }
            set { _targetType = value; }
        }
        private string _targetName = string.Empty;
        /// <summary>
        /// 当事人姓名/负责人姓名
        /// </summary>
        public string TargetName
        {
            get { return _targetName ?? string.Empty; }
            set { _targetName = value; }
        }
        private string _targetAddress = string.Empty;
        /// <summary>
        /// 当事人地址
        /// </summary>
        public string TargetAddress
        {
            get { return _targetAddress ?? string.Empty; }
            set { _targetAddress = value; }
        }
        private string _targetPaperType = string.Empty;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string TargetPaperType
        {
            get { return _targetPaperType ?? string.Empty; }
            set { _targetPaperType = value; }
        }
        private string _targetPaperNum = string.Empty;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string TargetPaperNum
        {
            get { return _targetPaperNum ?? string.Empty; }
            set { _targetPaperNum = value; }
        }
        private string _targetGender = string.Empty;
        /// <summary>
        /// 当事人姓名（1：男 0：女）
        /// </summary>
        public string TargetGender
        {
            get { return _targetGender ?? string.Empty; }
            set { _targetGender = value; }
        }
        private int _targetAge;
        /// <summary>
        /// 当事人年龄
        /// </summary>
        public int TargetAge
        {
            get { return _targetAge; }
            set { _targetAge = value; }
        }
        private string _targetUnit = string.Empty;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string TargetUnit
        {
            get { return _targetUnit ?? string.Empty; }
            set { _targetUnit = value; }
        }
        private string _targetDuty = string.Empty;
        /// <summary>
        /// 当事人职务
        /// </summary>
        public string TargetDuty
        {
            get { return _targetDuty ?? string.Empty; }
            set { _targetDuty = value; }
        }
        private string _targetPhone = string.Empty;
        /// <summary>
        /// 当事人联系电话
        /// </summary>
        public string TargetPhone
        {
            get { return _targetPhone ?? string.Empty; }
            set { _targetPhone = value; }
        }
        private string _targetMobile = string.Empty;
        /// <summary>
        /// 当事人手机号
        /// </summary>
        public string TargetMobile
        {
            get { return _targetMobile ?? string.Empty; }
            set { _targetMobile = value; }
        }
        private string _targetZipCode = string.Empty;
        /// <summary>
        /// 邮编
        /// </summary>
        public string TargetZipCode
        {
            get { return _targetZipCode ?? string.Empty; }
            set { _targetZipCode = value; }
        }
        private string _targetEmail = string.Empty;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string TargetEmail
        {
            get { return _targetEmail ?? string.Empty; }
            set { _targetEmail = value; }
        }
        private int _state;
        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override SealUpEntity SetModelValueByDataRow(DataRow dr)
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
        public override SealUpEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new SealUpEntity();
            if (fields.Contains(Parm_SealUp_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_SealUp_Id].ToString();
            if (fields.Contains(Parm_SealUp_CaseInfoNo) || fields.Contains("*"))
                tmp.CaseInfoNo = dr[Parm_SealUp_CaseInfoNo].ToString();
            if (fields.Contains(Parm_SealUp_DataSource) || fields.Contains("*"))
                tmp.DataSource = int.Parse(dr[Parm_SealUp_DataSource].ToString());
            if (fields.Contains(Parm_SealUp_ReSource) || fields.Contains("*"))
                tmp.ReSource = dr[Parm_SealUp_ReSource].ToString();
            if (fields.Contains(Parm_SealUp_ReSourceName) || fields.Contains("*"))
                tmp.ReSourceName = dr[Parm_SealUp_ReSourceName].ToString();
            if (fields.Contains(Parm_SealUp_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_SealUp_CompanyId].ToString();
            if (fields.Contains(Parm_SealUp_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_SealUp_CompanyName].ToString();
            if (fields.Contains(Parm_SealUp_DepartmentId) || fields.Contains("*"))
                tmp.DepartmentId = dr[Parm_SealUp_DepartmentId].ToString();
            if (fields.Contains(Parm_SealUp_DepartmentName) || fields.Contains("*"))
                tmp.DepartmentName = dr[Parm_SealUp_DepartmentName].ToString();
            if (fields.Contains(Parm_SealUp_RePersonelIdFist) || fields.Contains("*"))
                tmp.RePersonelIdFist = dr[Parm_SealUp_RePersonelIdFist].ToString();
            if (fields.Contains(Parm_SealUp_RePersonelIdSecond) || fields.Contains("*"))
                tmp.RePersonelIdSecond = dr[Parm_SealUp_RePersonelIdSecond].ToString();
            if (fields.Contains(Parm_SealUp_RePersonelNameFist) || fields.Contains("*"))
                tmp.RePersonelNameFist = dr[Parm_SealUp_RePersonelNameFist].ToString();
            if (fields.Contains(Parm_SealUp_RePersonelNameSecond) || fields.Contains("*"))
                tmp.RePersonelNameSecond = dr[Parm_SealUp_RePersonelNameSecond].ToString();
            if (fields.Contains(Parm_SealUp_UdPersonelIdFirst) || fields.Contains("*"))
                tmp.UdPersonelIdFirst = dr[Parm_SealUp_UdPersonelIdFirst].ToString();
            if (fields.Contains(Parm_SealUp_UdPersonelIdSecond) || fields.Contains("*"))
                tmp.UdPersonelIdSecond = dr[Parm_SealUp_UdPersonelIdSecond].ToString();
            if (fields.Contains(Parm_SealUp_UdPersonelNameFirst) || fields.Contains("*"))
                tmp.UdPersonelNameFirst = dr[Parm_SealUp_UdPersonelNameFirst].ToString();
            if (fields.Contains(Parm_SealUp_UdPersonelNameSecond) || fields.Contains("*"))
                tmp.UdPersonelNameSecond = dr[Parm_SealUp_UdPersonelNameSecond].ToString();
            if (fields.Contains(Parm_SealUp_CaseDate) || fields.Contains("*"))
                tmp.CaseDate = DateTime.Parse(dr[Parm_SealUp_CaseDate].ToString());
            if (fields.Contains(Parm_SealUp_CaseAddress) || fields.Contains("*"))
                tmp.CaseAddress = dr[Parm_SealUp_CaseAddress].ToString();
            if (fields.Contains(Parm_SealUp_RoadNo) || fields.Contains("*"))
                tmp.RoadNo = dr[Parm_SealUp_RoadNo].ToString();
            if (fields.Contains(Parm_SealUp_RoadName) || fields.Contains("*"))
                tmp.RoadName = dr[Parm_SealUp_RoadName].ToString();
            if (fields.Contains(Parm_SealUp_CaseFact) || fields.Contains("*"))
                tmp.CaseFact = dr[Parm_SealUp_CaseFact].ToString();
            if (fields.Contains(Parm_SealUp_TargetType) || fields.Contains("*"))
                tmp.TargetType = dr[Parm_SealUp_TargetType].ToString();
            if (fields.Contains(Parm_SealUp_TargetName) || fields.Contains("*"))
                tmp.TargetName = dr[Parm_SealUp_TargetName].ToString();
            if (fields.Contains(Parm_SealUp_TargetAddress) || fields.Contains("*"))
                tmp.TargetAddress = dr[Parm_SealUp_TargetAddress].ToString();
            if (fields.Contains(Parm_SealUp_TargetPaperType) || fields.Contains("*"))
                tmp.TargetPaperType = dr[Parm_SealUp_TargetPaperType].ToString();
            if (fields.Contains(Parm_SealUp_TargetPaperNum) || fields.Contains("*"))
                tmp.TargetPaperNum = dr[Parm_SealUp_TargetPaperNum].ToString();
            if (fields.Contains(Parm_SealUp_TargetGender) || fields.Contains("*"))
                tmp.TargetGender = dr[Parm_SealUp_TargetGender].ToString();
            if (fields.Contains(Parm_SealUp_TargetAge) || fields.Contains("*"))
                tmp.TargetAge = int.Parse(dr[Parm_SealUp_TargetAge].ToString());
            if (fields.Contains(Parm_SealUp_TargetUnit) || fields.Contains("*"))
                tmp.TargetUnit = dr[Parm_SealUp_TargetUnit].ToString();
            if (fields.Contains(Parm_SealUp_TargetDuty) || fields.Contains("*"))
                tmp.TargetDuty = dr[Parm_SealUp_TargetDuty].ToString();
            if (fields.Contains(Parm_SealUp_TargetPhone) || fields.Contains("*"))
                tmp.TargetPhone = dr[Parm_SealUp_TargetPhone].ToString();
            if (fields.Contains(Parm_SealUp_TargetMobile) || fields.Contains("*"))
                tmp.TargetMobile = dr[Parm_SealUp_TargetMobile].ToString();
            if (fields.Contains(Parm_SealUp_TargetZipCode) || fields.Contains("*"))
                tmp.TargetZipCode = dr[Parm_SealUp_TargetZipCode].ToString();
            if (fields.Contains(Parm_SealUp_TargetEmail) || fields.Contains("*"))
                tmp.TargetEmail = dr[Parm_SealUp_TargetEmail].ToString();
            if (fields.Contains(Parm_SealUp_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_SealUp_State].ToString());
            if (fields.Contains(Parm_SealUp_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_SealUp_Remark].ToString();
            if (fields.Contains(Parm_SealUp_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_SealUp_RowStatus].ToString());
            if (fields.Contains(Parm_SealUp_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_SealUp_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_SealUp_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_SealUp_CreatorId].ToString();
            if (fields.Contains(Parm_SealUp_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_SealUp_CreateBy].ToString();
            if (fields.Contains(Parm_SealUp_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_SealUp_CreateOn].ToString());
            if (fields.Contains(Parm_SealUp_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_SealUp_UpdateId].ToString();
            if (fields.Contains(Parm_SealUp_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_SealUp_UpdateBy].ToString();
            if (fields.Contains(Parm_SealUp_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_SealUp_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="sealup">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(SealUpEntity sealup, SqlParameter[] parms)
        {
            parms[0].Value = sealup.CaseInfoNo;
            parms[1].Value = sealup.DataSource;
            parms[2].Value = sealup.ReSource;
            parms[3].Value = sealup.ReSourceName;
            parms[4].Value = sealup.CompanyId;
            parms[5].Value = sealup.CompanyName;
            parms[6].Value = sealup.DepartmentId;
            parms[7].Value = sealup.DepartmentName;
            parms[8].Value = sealup.RePersonelIdFist;
            parms[9].Value = sealup.RePersonelIdSecond;
            parms[10].Value = sealup.RePersonelNameFist;
            parms[11].Value = sealup.RePersonelNameSecond;
            parms[12].Value = sealup.UdPersonelIdFirst;
            parms[13].Value = sealup.UdPersonelIdSecond;
            parms[14].Value = sealup.UdPersonelNameFirst;
            parms[15].Value = sealup.UdPersonelNameSecond;
            parms[16].Value = sealup.CaseDate;
            parms[17].Value = sealup.CaseAddress;
            parms[18].Value = sealup.RoadNo;
            parms[19].Value = sealup.RoadName;
            parms[20].Value = sealup.CaseFact;
            parms[21].Value = sealup.TargetType;
            parms[22].Value = sealup.TargetName;
            parms[23].Value = sealup.TargetAddress;
            parms[24].Value = sealup.TargetPaperType;
            parms[25].Value = sealup.TargetPaperNum;
            parms[26].Value = sealup.TargetGender;
            parms[27].Value = sealup.TargetAge;
            parms[28].Value = sealup.TargetUnit;
            parms[29].Value = sealup.TargetDuty;
            parms[30].Value = sealup.TargetPhone;
            parms[31].Value = sealup.TargetMobile;
            parms[32].Value = sealup.TargetZipCode;
            parms[33].Value = sealup.TargetEmail;
            parms[34].Value = sealup.State;
            parms[35].Value = sealup.Remark;
            parms[36].Value = sealup.RowStatus;
            parms[37].Value = sealup.CreatorId;
            parms[38].Value = sealup.CreateBy;
            parms[39].Value = sealup.CreateOn;
            parms[40].Value = sealup.UpdateId;
            parms[41].Value = sealup.UpdateBy;
            parms[42].Value = sealup.UpdateOn;
            parms[43].Value = sealup.Id;

            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(SealUpEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUp_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_SealUp_CaseInfoNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_DataSource, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUp_ReSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_ReSourceName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_SealUp_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_DepartmentName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_RePersonelIdFist, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_RePersonelIdSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_RePersonelNameFist, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_RePersonelNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UdPersonelIdFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UdPersonelIdSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UdPersonelNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UdPersonelNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_CaseDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SealUp_CaseAddress, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_SealUp_RoadNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_SealUp_RoadName, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_SealUp_CaseFact, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_SealUp_TargetType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_TargetName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_TargetAddress, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_SealUp_TargetPaperType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_TargetPaperNum, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_TargetGender, SqlDbType.VarChar, 1),
					new SqlParameter(Parm_SealUp_TargetAge, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUp_TargetUnit, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_SealUp_TargetDuty, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_TargetPhone, SqlDbType.VarChar, 13),
					new SqlParameter(Parm_SealUp_TargetMobile, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_SealUp_TargetZipCode, SqlDbType.VarChar, 6),
					new SqlParameter(Parm_SealUp_TargetEmail, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUp_Remark, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_SealUp_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUp_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SealUp_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUp_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_SealUp_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUp_Insert, parms);
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
