//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfoEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/11 9:27:57
//  功能描述：TempDetainInfo表实体
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
    /// 暂扣基本信息
    /// </summary>
    [Serializable]
    public class TempDetainInfoEntity : ModelImp.BaseModel<TempDetainInfoEntity>
    {
        public TempDetainInfoEntity()
        {
            TB_Name = TB_TempDetainInfo;
            Parm_Id = Parm_TempDetainInfo_Id;
            Parm_Version = Parm_TempDetainInfo_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TempDetainInfo_Insert;
            Sql_Update = Sql_TempDetainInfo_Update;
            Sql_Delete = Sql_TempDetainInfo_Delete;
        }
        #region Const of table TempDetainInfo
        /// <summary>
        /// Table TempDetainInfo
        /// </summary>
        public const string TB_TempDetainInfo = "TempDetainInfo";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_TempDetainInfo_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_TempDetainInfo_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TempDetainInfo_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TempDetainInfo_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TempDetainInfo_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_TempDetainInfo_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm DepartmentName
        /// </summary>
        public const string Parm_TempDetainInfo_DepartmentName = "DepartmentName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TempDetainInfo_Id = "Id";
        /// <summary>
        /// Parm IsRefused
        /// </summary>
        public const string Parm_TempDetainInfo_IsRefused = "IsRefused";
        /// <summary>
        /// Parm RePersonelIdFist
        /// </summary>
        public const string Parm_TempDetainInfo_RePersonelIdFist = "RePersonelIdFist";
        /// <summary>
        /// Parm RePersonelIdSecond
        /// </summary>
        public const string Parm_TempDetainInfo_RePersonelIdSecond = "RePersonelIdSecond";
        /// <summary>
        /// Parm RePersonelNameFist
        /// </summary>
        public const string Parm_TempDetainInfo_RePersonelNameFist = "RePersonelNameFist";
        /// <summary>
        /// Parm RePersonelNameSecond
        /// </summary>
        public const string Parm_TempDetainInfo_RePersonelNameSecond = "RePersonelNameSecond";
        /// <summary>
        /// Parm RoadName
        /// </summary>
        public const string Parm_TempDetainInfo_RoadName = "RoadName";
        /// <summary>
        /// Parm RoadNo
        /// </summary>
        public const string Parm_TempDetainInfo_RoadNo = "RoadNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TempDetainInfo_RowStatus = "RowStatus";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_TempDetainInfo_State = "State";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_TempDetainInfo_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetAge
        /// </summary>
        public const string Parm_TempDetainInfo_TargetAge = "TargetAge";
        /// <summary>
        /// Parm TargetDuty
        /// </summary>
        public const string Parm_TempDetainInfo_TargetDuty = "TargetDuty";
        /// <summary>
        /// Parm TargetEmail
        /// </summary>
        public const string Parm_TempDetainInfo_TargetEmail = "TargetEmail";
        /// <summary>
        /// Parm TargetGender
        /// </summary>
        public const string Parm_TempDetainInfo_TargetGender = "TargetGender";
        /// <summary>
        /// Parm TargetMobile
        /// </summary>
        public const string Parm_TempDetainInfo_TargetMobile = "TargetMobile";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_TempDetainInfo_TargetName = "TargetName";
        /// <summary>
        /// Parm TargetPaperNum
        /// </summary>
        public const string Parm_TempDetainInfo_TargetPaperNum = "TargetPaperNum";
        /// <summary>
        /// Parm TargetPaperType
        /// </summary>
        public const string Parm_TempDetainInfo_TargetPaperType = "TargetPaperType";
        /// <summary>
        /// Parm TargetPhone
        /// </summary>
        public const string Parm_TempDetainInfo_TargetPhone = "TargetPhone";
        /// <summary>
        /// Parm TargetType
        /// </summary>
        public const string Parm_TempDetainInfo_TargetType = "TargetType";
        /// <summary>
        /// Parm TargetUnit
        /// </summary>
        public const string Parm_TempDetainInfo_TargetUnit = "TargetUnit";
        /// <summary>
        /// Parm TargetZipCode
        /// </summary>
        public const string Parm_TempDetainInfo_TargetZipCode = "TargetZipCode";
        /// <summary>
        /// Parm TempAddress
        /// </summary>
        public const string Parm_TempDetainInfo_TempAddress = "TempAddress";
        /// <summary>
        /// Parm TempDateTime
        /// </summary>
        public const string Parm_TempDetainInfo_TempDateTime = "TempDateTime";

        /// <summary>
        /// Parm NoticeNo 通知书编号
        /// </summary>
        public const string Parm_TempDetainInfo_NoticeNo = "NoticeNo";
        /// <summary>
        /// Parm CaseId
        /// </summary>
        public const string Parm_TempDetainInfo_CaseId = "CaseId";

        /// <summary>
        /// Parm TempNo
        /// </summary>
        public const string Parm_TempDetainInfo_TempNo = "TempNo";
        /// <summary>
        /// Parm TempType
        /// </summary>
        public const string Parm_TempDetainInfo_TempType = "TempType";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TempDetainInfo_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TempDetainInfo_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TempDetainInfo_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainInfo_Version = "Version";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainInfo_WarehouseCode = "WarehouseCode";
        /// <summary>
        /// Insert Query Of TempDetainInfo
        /// </summary>
        public const string Sql_TempDetainInfo_Insert = "insert into TempDetainInfo(CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DepartmentId,DepartmentName,IsRefused,RePersonelIdFist,RePersonelIdSecond,RePersonelNameFist,RePersonelNameSecond,RoadName,RoadNo,RowStatus,State,TargetAddress,TargetAge,TargetDuty,TargetEmail,TargetGender,TargetMobile,TargetName,TargetPaperNum,TargetPaperType,TargetPhone,TargetType,TargetUnit,TargetZipCode,TempAddress,TempDateTime,TempNo,TempType,UpdateBy,UpdateId,UpdateOn,WarehouseCode,CaseId,NoticeNo,Id) values(@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@DepartmentName,@IsRefused,@RePersonelIdFist,@RePersonelIdSecond,@RePersonelNameFist,@RePersonelNameSecond,@RoadName,@RoadNo,@RowStatus,@State,@TargetAddress,@TargetAge,@TargetDuty,@TargetEmail,@TargetGender,@TargetMobile,@TargetName,@TargetPaperNum,@TargetPaperType,@TargetPhone,@TargetType,@TargetUnit,@TargetZipCode,@TempAddress,@TempDateTime,@TempNo,@TempType,@UpdateBy,@UpdateId,@UpdateOn,@WarehouseCode,@CaseId,@NoticeNo,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TempDetainInfo
        /// </summary>
        public const string Sql_TempDetainInfo_Update = "update TempDetainInfo set CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,IsRefused=@IsRefused,RePersonelIdFist=@RePersonelIdFist,RePersonelIdSecond=@RePersonelIdSecond,RePersonelNameFist=@RePersonelNameFist,RePersonelNameSecond=@RePersonelNameSecond,RoadName=@RoadName,RoadNo=@RoadNo,RowStatus=@RowStatus,State=@State,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetDuty=@TargetDuty,TargetEmail=@TargetEmail,TargetGender=@TargetGender,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,TargetPhone=@TargetPhone,TargetType=@TargetType,TargetUnit=@TargetUnit,TargetZipCode=@TargetZipCode,TempAddress=@TempAddress,TempDateTime=@TempDateTime,TempNo=@TempNo,TempType=@TempType,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WarehouseCode=@WarehouseCode,CaseId=@CaseId,NoticeNo=@NoticeNo where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TempDetainInfo_Delete = "update TempDetainInfo set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _tempNo = string.Empty;
        /// <summary>
        /// 暂扣单据编号
        /// </summary>
        public string TempNo
        {
            get { return _tempNo ?? string.Empty; }
            set { _tempNo = value; }
        }
        private string _tempType = string.Empty;
        /// <summary>
        /// 暂扣类型：暂扣、先行登记
        /// </summary>
        public string TempType
        {
            get { return _tempType ?? string.Empty; }
            set { _tempType = value; }
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
        /// 部门编号
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _departmentName = string.Empty;
        /// <summary>
        /// 部门名称
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
        private int _isRefused;
        /// <summary>
        /// 是否拒绝表达身份，1：是；0：否
        /// </summary>
        public int IsRefused
        {
            get { return _isRefused; }
            set { _isRefused = value; }
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
        /// 当事人姓名（1：男  0：女）
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
        /// 单位名称
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
        /// 电子邮件
        /// </summary>
        public string TargetEmail
        {
            get { return _targetEmail ?? string.Empty; }
            set { _targetEmail = value; }
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
        private DateTime _tempDateTime = MinDate;
        /// <summary>
        /// 查处日期
        /// </summary>
        public DateTime TempDateTime
        {
            get { return _tempDateTime; }
            set { _tempDateTime = value; }
        }
        private string _tempAddress = string.Empty;
        /// <summary>
        /// 查处地点
        /// </summary>
        public string TempAddress
        {
            get { return _tempAddress ?? string.Empty; }
            set { _tempAddress = value; }
        }
        private int _state;
        /// <summary>
        /// 状态  //待入库-0，已入库-1，教育处理-2,移交其它部门-3,转入处罚-4, 处罚处理-5，已发还-6    腐烂、无价-88
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _warehouseCode = string.Empty;
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseCode
        {
            get { return _warehouseCode ?? string.Empty; }
            set { _warehouseCode = value; }
        }


        private string _caseId = string.Empty;
        /// <summary>
        /// 案件主键
        /// </summary>
        public string CaseId
        {
            get { return _caseId ?? string.Empty; }
            set { _caseId = value; }
        }
        private string _noticeNo = string.Empty;
        /// <summary>
        /// 通知书编号
        /// </summary>
        public string NoticeNo
        {
            get { return _noticeNo ?? string.Empty; }
            set { _noticeNo = value; }
        }

        #endregion

        #region 辅助属性

        /// <summary>
        /// 显示状态
        /// </summary>
        public string ShowState { get; set; }

        /// <summary>
        /// 适用案由
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 统计检查总数
        /// </summary>
        public int TotalCount { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override TempDetainInfoEntity SetModelValueByDataRow(DataRow dr)
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
        public override TempDetainInfoEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainInfoEntity();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Id))
                tmp.Id = dr[Parm_TempDetainInfo_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TempNo))
                tmp.TempNo = dr[Parm_TempDetainInfo_TempNo].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TempType))
                tmp.TempType = dr[Parm_TempDetainInfo_TempType].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CompanyId))
                tmp.CompanyId = dr[Parm_TempDetainInfo_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CompanyName))
                tmp.CompanyName = dr[Parm_TempDetainInfo_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_DepartmentId))
                tmp.DepartmentId = dr[Parm_TempDetainInfo_DepartmentId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_DepartmentName))
                tmp.DepartmentName = dr[Parm_TempDetainInfo_DepartmentName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RePersonelIdFist))
                tmp.RePersonelIdFist = dr[Parm_TempDetainInfo_RePersonelIdFist].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RePersonelIdSecond))
                tmp.RePersonelIdSecond = dr[Parm_TempDetainInfo_RePersonelIdSecond].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RePersonelNameFist))
                tmp.RePersonelNameFist = dr[Parm_TempDetainInfo_RePersonelNameFist].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RePersonelNameSecond))
                tmp.RePersonelNameSecond = dr[Parm_TempDetainInfo_RePersonelNameSecond].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_IsRefused))
                tmp.IsRefused = int.Parse(dr[Parm_TempDetainInfo_IsRefused].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetType))
                tmp.TargetType = dr[Parm_TempDetainInfo_TargetType].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetName))
                tmp.TargetName = dr[Parm_TempDetainInfo_TargetName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetAddress))
                tmp.TargetAddress = dr[Parm_TempDetainInfo_TargetAddress].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetPaperType))
                tmp.TargetPaperType = dr[Parm_TempDetainInfo_TargetPaperType].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetPaperNum))
                tmp.TargetPaperNum = dr[Parm_TempDetainInfo_TargetPaperNum].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetGender))
                tmp.TargetGender = dr[Parm_TempDetainInfo_TargetGender].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetAge))
                tmp.TargetAge = int.Parse(dr[Parm_TempDetainInfo_TargetAge].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetUnit))
                tmp.TargetUnit = dr[Parm_TempDetainInfo_TargetUnit].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetDuty))
                tmp.TargetDuty = dr[Parm_TempDetainInfo_TargetDuty].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetPhone))
                tmp.TargetPhone = dr[Parm_TempDetainInfo_TargetPhone].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetMobile))
                tmp.TargetMobile = dr[Parm_TempDetainInfo_TargetMobile].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetZipCode))
                tmp.TargetZipCode = dr[Parm_TempDetainInfo_TargetZipCode].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TargetEmail))
                tmp.TargetEmail = dr[Parm_TempDetainInfo_TargetEmail].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RoadNo))
                tmp.RoadNo = dr[Parm_TempDetainInfo_RoadNo].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RoadName))
                tmp.RoadName = dr[Parm_TempDetainInfo_RoadName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TempDateTime))
                tmp.TempDateTime = DateTime.Parse(dr[Parm_TempDetainInfo_TempDateTime].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_TempAddress))
                tmp.TempAddress = dr[Parm_TempDetainInfo_TempAddress].ToString();

            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_WarehouseCode))
                tmp.WarehouseCode = dr[Parm_TempDetainInfo_WarehouseCode].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_State))
                tmp.State = int.Parse(dr[Parm_TempDetainInfo_State].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_TempDetainInfo_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Version))
            {
                var bts = (byte[])(dr[Parm_TempDetainInfo_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CreatorId))
                tmp.CreatorId = dr[Parm_TempDetainInfo_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CreateBy))
                tmp.CreateBy = dr[Parm_TempDetainInfo_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainInfo_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_UpdateId))
                tmp.UpdateId = dr[Parm_TempDetainInfo_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_UpdateBy))
                tmp.UpdateBy = dr[Parm_TempDetainInfo_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainInfo_UpdateOn].ToString());
            if (dr.Table.Columns.Contains("ItemName"))
                tmp.ItemName = dr["ItemName"].ToString();

            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_CaseId))
                tmp.CaseId = dr[Parm_TempDetainInfo_CaseId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_NoticeNo))
                tmp.NoticeNo = dr[Parm_TempDetainInfo_NoticeNo].ToString();
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetaininfo">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainInfoEntity tempdetaininfo,
                                                                  SqlParameter[] parms)
        {
            parms[0].Value = tempdetaininfo.TempNo;
            parms[1].Value = tempdetaininfo.TempType;
            parms[2].Value = tempdetaininfo.CompanyId;
            parms[3].Value = tempdetaininfo.CompanyName;
            parms[4].Value = tempdetaininfo.DepartmentId;
            parms[5].Value = tempdetaininfo.DepartmentName;
            parms[6].Value = tempdetaininfo.RePersonelIdFist;
            parms[7].Value = tempdetaininfo.RePersonelIdSecond;
            parms[8].Value = tempdetaininfo.RePersonelNameFist;
            parms[9].Value = tempdetaininfo.RePersonelNameSecond;
            parms[10].Value = tempdetaininfo.IsRefused;
            parms[11].Value = tempdetaininfo.TargetType;
            parms[12].Value = tempdetaininfo.TargetName;
            parms[13].Value = tempdetaininfo.TargetAddress;
            parms[14].Value = tempdetaininfo.TargetPaperType;
            parms[15].Value = tempdetaininfo.TargetPaperNum;
            parms[16].Value = tempdetaininfo.TargetGender;
            parms[17].Value = tempdetaininfo.TargetAge;
            parms[18].Value = tempdetaininfo.TargetUnit;
            parms[19].Value = tempdetaininfo.TargetDuty;
            parms[20].Value = tempdetaininfo.TargetPhone;
            parms[21].Value = tempdetaininfo.TargetMobile;
            parms[22].Value = tempdetaininfo.TargetZipCode;
            parms[23].Value = tempdetaininfo.TargetEmail;
            parms[24].Value = tempdetaininfo.RoadNo;
            parms[25].Value = tempdetaininfo.RoadName;
            parms[26].Value = tempdetaininfo.TempDateTime;
            parms[27].Value = tempdetaininfo.TempAddress;
            parms[28].Value = tempdetaininfo.State;
            parms[29].Value = tempdetaininfo.RowStatus;
            parms[30].Value = tempdetaininfo.CreatorId;
            parms[31].Value = tempdetaininfo.CreateBy;
            parms[32].Value = tempdetaininfo.CreateOn;
            parms[33].Value = tempdetaininfo.UpdateId;
            parms[34].Value = tempdetaininfo.UpdateBy;
            parms[35].Value = tempdetaininfo.UpdateOn;
            parms[36].Value = tempdetaininfo.WarehouseCode;
            parms[37].Value = tempdetaininfo.CaseId;
            parms[38].Value = tempdetaininfo.NoticeNo;
            parms[39].Value = tempdetaininfo.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainInfoEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Insert);
                if (parms == null)
                {
                    parms = new[]
				        {
				            new SqlParameter(Parm_TempDetainInfo_TempNo, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TempType, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_CompanyId, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_CompanyName, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_DepartmentId, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_DepartmentName, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_RePersonelIdFist, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_RePersonelIdSecond, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_RePersonelNameFist, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_RePersonelNameSecond, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_IsRefused, SqlDbType.Int, 10),
				            new SqlParameter(Parm_TempDetainInfo_TargetType, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TargetName, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TargetAddress, SqlDbType.NVarChar, 500),
				            new SqlParameter(Parm_TempDetainInfo_TargetPaperType, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TargetPaperNum, SqlDbType.NVarChar, 200),
				            new SqlParameter(Parm_TempDetainInfo_TargetGender, SqlDbType.VarChar, 1),
				            new SqlParameter(Parm_TempDetainInfo_TargetAge, SqlDbType.Int, 10),
				            new SqlParameter(Parm_TempDetainInfo_TargetUnit, SqlDbType.NVarChar, 200),
				            new SqlParameter(Parm_TempDetainInfo_TargetDuty, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TargetPhone, SqlDbType.VarChar, 13),
				            new SqlParameter(Parm_TempDetainInfo_TargetMobile, SqlDbType.VarChar, 11),
				            new SqlParameter(Parm_TempDetainInfo_TargetZipCode, SqlDbType.VarChar, 6),
				            new SqlParameter(Parm_TempDetainInfo_TargetEmail, SqlDbType.VarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_RoadNo, SqlDbType.NVarChar, 10),
				            new SqlParameter(Parm_TempDetainInfo_RoadName, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_TempDateTime, SqlDbType.DateTime, 23),
				            new SqlParameter(Parm_TempDetainInfo_TempAddress, SqlDbType.NVarChar, 200),
				            new SqlParameter(Parm_TempDetainInfo_State, SqlDbType.Int, 10),
				            new SqlParameter(Parm_TempDetainInfo_RowStatus, SqlDbType.Int, 10),
				            new SqlParameter(Parm_TempDetainInfo_CreatorId, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_CreateBy, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_CreateOn, SqlDbType.DateTime, 23),
				            new SqlParameter(Parm_TempDetainInfo_UpdateId, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_UpdateBy, SqlDbType.NVarChar, 50),
				            new SqlParameter(Parm_TempDetainInfo_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_TempDetainInfo_WarehouseCode, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_TempDetainInfo_CaseId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TempDetainInfo_NoticeNo, SqlDbType.NVarChar, 150),
                            new SqlParameter(Parm_TempDetainInfo_Id, SqlDbType.NVarChar, 50)
                             

				        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Insert, parms);
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

