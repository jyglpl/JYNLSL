//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_STALL_CASEINFOEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/1 17:50:32
//  功能描述：INF_STALL_CASEINFO表实体
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
    /// 流动摊贩基本信息
    /// </summary>
    [Serializable]
    public class InfStallCaseinfoEntity : ModelImp.BaseModel<InfStallCaseinfoEntity>
    {
        public InfStallCaseinfoEntity()
        {
            TB_Name = TB_INF_STALL_CASEINFO;
            Parm_Id = Parm_INF_STALL_CASEINFO_Id;
            Parm_Version = Parm_INF_STALL_CASEINFO_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_STALL_CASEINFO_Insert;
            Sql_Update = Sql_INF_STALL_CASEINFO_Update;
            Sql_Delete = Sql_INF_STALL_CASEINFO_Delete;
        }
        #region Const of table INF_STALL_CASEINFO
        /// <summary>
        /// Table INF_STALL_CASEINFO
        /// </summary>
        public const string TB_INF_STALL_CASEINFO = "INF_STALL_CASEINFO";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseAddress
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CaseAddress = "CaseAddress";
        /// <summary>
        /// Parm CaseDate
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CaseDate = "CaseDate";
        /// <summary>
        /// Parm CaseFact
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CaseFact = "CaseFact";
        /// <summary>
        /// Parm CaseInfoNo
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CaseInfoNo = "CaseInfoNo";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_DeptName = "DeptName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_Id = "Id";
        /// <summary>
        /// Parm ItemAct
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_ItemAct = "ItemAct";
        /// <summary>
        /// Parm ItemeNo
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_ItemeNo = "ItemeNo";
        /// <summary>
        /// Parm Lat
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_Lat = "Lat";
        /// <summary>
        /// Parm Lng
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_Lng = "Lng";
        /// <summary>
        /// Parm RePersonelIdFist
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RePersonelIdFist = "RePersonelIdFist";
        /// <summary>
        /// Parm RePersonelIdSecond
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RePersonelIdSecond = "RePersonelIdSecond";
        /// <summary>
        /// Parm RePersonelNameFist
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RePersonelNameFist = "RePersonelNameFist";
        /// <summary>
        /// Parm RePersonelNameSecond
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RePersonelNameSecond = "RePersonelNameSecond";
        /// <summary>
        /// Parm RoadName
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RoadName = "RoadName";
        /// <summary>
        /// Parm RoadNo
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RoadNo = "RoadNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetAge
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetAge = "TargetAge";
        /// <summary>
        /// Parm TargetGender
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetGender = "TargetGender";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetName = "TargetName";
        /// <summary>
        /// Parm TargetPaperNum
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetPaperNum = "TargetPaperNum";
        /// <summary>
        /// Parm TargetPaperType
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_TargetPaperType = "TargetPaperType";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_STALL_CASEINFO_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_STALL_CASEINFO
        /// </summary>
        public const string Sql_INF_STALL_CASEINFO_Insert = "insert into INF_STALL_CASEINFO(CaseAddress,CaseDate,CaseFact,CaseInfoNo,CreateBy,CreateOn,CreatorId,DeptId,DeptName,ItemAct,ItemeNo,Lat,Lng,RePersonelIdFist,RePersonelIdSecond,RePersonelNameFist,RePersonelNameSecond,RoadName,RoadNo,RowStatus,TargetAddress,TargetAge,TargetGender,TargetName,TargetPaperNum,TargetPaperType,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseAddress,@CaseDate,@CaseFact,@CaseInfoNo,@CreateBy,@CreateOn,@CreatorId,@DeptId,@DeptName,@ItemAct,@ItemeNo,@Lat,@Lng,@RePersonelIdFist,@RePersonelIdSecond,@RePersonelNameFist,@RePersonelNameSecond,@RoadName,@RoadNo,@RowStatus,@TargetAddress,@TargetAge,@TargetGender,@TargetName,@TargetPaperNum,@TargetPaperType,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_STALL_CASEINFO
        /// </summary>
        public const string Sql_INF_STALL_CASEINFO_Update = "update INF_STALL_CASEINFO set CaseAddress=@CaseAddress,CaseDate=@CaseDate,CaseFact=@CaseFact,CaseInfoNo=@CaseInfoNo,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,DeptName=@DeptName,ItemAct=@ItemAct,ItemeNo=@ItemeNo,Lat=@Lat,Lng=@Lng,RePersonelIdFist=@RePersonelIdFist,RePersonelIdSecond=@RePersonelIdSecond,RePersonelNameFist=@RePersonelNameFist,RePersonelNameSecond=@RePersonelNameSecond,RoadName=@RoadName,RoadNo=@RoadNo,RowStatus=@RowStatus,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetGender=@TargetGender,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_STALL_CASEINFO_Delete = "update INF_STALL_CASEINFO set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoNo = string.Empty;
        /// <summary>
        /// varchar 	案件内部编号
        /// </summary>
        public string CaseInfoNo
        {
            get { return _caseInfoNo ?? string.Empty; }
            set { _caseInfoNo = value; }
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
        private DateTime _caseDate = MinDate;
        /// <summary>
        /// datetime 	案发日期（yyyy-MM-dd hh24:mm:ss）
        /// </summary>
        public DateTime CaseDate
        {
            get { return _caseDate; }
            set { _caseDate = value; }
        }
        private string _roadNo = string.Empty;
        /// <summary>
        /// 路段代码
        /// </summary>
        public string RoadNo
        {
            get { return _roadNo ?? string.Empty; }
            set { _roadNo = value; }
        }
        private string _roadName = string.Empty;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string RoadName
        {
            get { return _roadName ?? string.Empty; }
            set { _roadName = value; }
        }
        private string _caseAddress = string.Empty;
        /// <summary>
        /// nvarchar 	案发地址
        /// </summary>
        public string CaseAddress
        {
            get { return _caseAddress ?? string.Empty; }
            set { _caseAddress = value; }
        }
        private string _caseFact = string.Empty;
        /// <summary>
        /// nvarchar 	案情摘要
        /// </summary>
        public string CaseFact
        {
            get { return _caseFact ?? string.Empty; }
            set { _caseFact = value; }
        }
        private string _itemeNo = string.Empty;
        /// <summary>
        /// 案由编号
        /// </summary>
        public string ItemeNo
        {
            get { return _itemeNo ?? string.Empty; }
            set { _itemeNo = value; }
        }
        private string _itemAct = string.Empty;
        /// <summary>
        /// 违法行为
        /// </summary>
        public string ItemAct
        {
            get { return _itemAct ?? string.Empty; }
            set { _itemAct = value; }
        }
        private string _rePersonelIdFist = string.Empty;
        /// <summary>
        /// nvarchar 	执法队员一（编号）
        /// </summary>
        public string RePersonelIdFist
        {
            get { return _rePersonelIdFist ?? string.Empty; }
            set { _rePersonelIdFist = value; }
        }
        private string _rePersonelIdSecond = string.Empty;
        /// <summary>
        /// nvarchar 	执法队员二（编号）
        /// </summary>
        public string RePersonelIdSecond
        {
            get { return _rePersonelIdSecond ?? string.Empty; }
            set { _rePersonelIdSecond = value; }
        }
        private string _rePersonelNameSecond = string.Empty;
        /// <summary>
        /// nvarchar 	执法队员二（姓名）
        /// </summary>
        public string RePersonelNameSecond
        {
            get { return _rePersonelNameSecond ?? string.Empty; }
            set { _rePersonelNameSecond = value; }
        }
        private string _rePersonelNameFist = string.Empty;
        /// <summary>
        /// nvarchar 	执法队员一（姓名）
        /// </summary>
        public string RePersonelNameFist
        {
            get { return _rePersonelNameFist ?? string.Empty; }
            set { _rePersonelNameFist = value; }
        }
        private string _targetName = string.Empty;
        /// <summary>
        /// nvarchar 	当事人姓名/负责人姓名
        /// </summary>
        public string TargetName
        {
            get { return _targetName ?? string.Empty; }
            set { _targetName = value; }
        }
        private string _targetAddress = string.Empty;
        /// <summary>
        /// nvarchar 	当事人地址
        /// </summary>
        public string TargetAddress
        {
            get { return _targetAddress ?? string.Empty; }
            set { _targetAddress = value; }
        }
        private string _targetPaperType = string.Empty;
        /// <summary>
        /// nvarchar 	证件类型
        /// </summary>
        public string TargetPaperType
        {
            get { return _targetPaperType ?? string.Empty; }
            set { _targetPaperType = value; }
        }
        private string _targetPaperNum = string.Empty;
        /// <summary>
        /// varchar 	证件号码
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
        /// int 	当事人年龄
        /// </summary>
        public int TargetAge
        {
            get { return _targetAge; }
            set { _targetAge = value; }
        }
        private string _lng = string.Empty;
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng
        {
            get { return _lng ?? string.Empty; }
            set { _lng = value; }
        }
        private string _lat = string.Empty;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat
        {
            get { return _lat ?? string.Empty; }
            set { _lat = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfStallCaseinfoEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfStallCaseinfoEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfStallCaseinfoEntity();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_STALL_CASEINFO_Id].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CaseInfoNo) || fields.Contains("*"))
                tmp.CaseInfoNo = dr[Parm_INF_STALL_CASEINFO_CaseInfoNo].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_INF_STALL_CASEINFO_DeptId].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_DeptName) || fields.Contains("*"))
                tmp.DeptName = dr[Parm_INF_STALL_CASEINFO_DeptName].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CaseDate) || fields.Contains("*"))
                tmp.CaseDate = DateTime.Parse(dr[Parm_INF_STALL_CASEINFO_CaseDate].ToString());
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RoadNo) || fields.Contains("*"))
                tmp.RoadNo = dr[Parm_INF_STALL_CASEINFO_RoadNo].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RoadName) || fields.Contains("*"))
                tmp.RoadName = dr[Parm_INF_STALL_CASEINFO_RoadName].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CaseAddress) || fields.Contains("*"))
                tmp.CaseAddress = dr[Parm_INF_STALL_CASEINFO_CaseAddress].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CaseFact) || fields.Contains("*"))
                tmp.CaseFact = dr[Parm_INF_STALL_CASEINFO_CaseFact].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_ItemeNo) || fields.Contains("*"))
                tmp.ItemeNo = dr[Parm_INF_STALL_CASEINFO_ItemeNo].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_ItemAct) || fields.Contains("*"))
                tmp.ItemAct = dr[Parm_INF_STALL_CASEINFO_ItemAct].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RePersonelIdFist) || fields.Contains("*"))
                tmp.RePersonelIdFist = dr[Parm_INF_STALL_CASEINFO_RePersonelIdFist].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RePersonelIdSecond) || fields.Contains("*"))
                tmp.RePersonelIdSecond = dr[Parm_INF_STALL_CASEINFO_RePersonelIdSecond].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RePersonelNameSecond) || fields.Contains("*"))
                tmp.RePersonelNameSecond = dr[Parm_INF_STALL_CASEINFO_RePersonelNameSecond].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RePersonelNameFist) || fields.Contains("*"))
                tmp.RePersonelNameFist = dr[Parm_INF_STALL_CASEINFO_RePersonelNameFist].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetName) || fields.Contains("*"))
                tmp.TargetName = dr[Parm_INF_STALL_CASEINFO_TargetName].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetAddress) || fields.Contains("*"))
                tmp.TargetAddress = dr[Parm_INF_STALL_CASEINFO_TargetAddress].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetPaperType) || fields.Contains("*"))
                tmp.TargetPaperType = dr[Parm_INF_STALL_CASEINFO_TargetPaperType].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetPaperNum) || fields.Contains("*"))
                tmp.TargetPaperNum = dr[Parm_INF_STALL_CASEINFO_TargetPaperNum].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetGender) || fields.Contains("*"))
                tmp.TargetGender = dr[Parm_INF_STALL_CASEINFO_TargetGender].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_TargetAge) || fields.Contains("*"))
                tmp.TargetAge = int.Parse(dr[Parm_INF_STALL_CASEINFO_TargetAge].ToString());
            if (fields.Contains(Parm_INF_STALL_CASEINFO_Lng) || fields.Contains("*"))
                tmp.Lng = dr[Parm_INF_STALL_CASEINFO_Lng].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_Lat) || fields.Contains("*"))
                tmp.Lat = dr[Parm_INF_STALL_CASEINFO_Lat].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_STALL_CASEINFO_RowStatus].ToString());
            if (fields.Contains(Parm_INF_STALL_CASEINFO_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_STALL_CASEINFO_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_STALL_CASEINFO_CreatorId].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_STALL_CASEINFO_CreateBy].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_STALL_CASEINFO_CreateOn].ToString());
            if (fields.Contains(Parm_INF_STALL_CASEINFO_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_STALL_CASEINFO_UpdateId].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_STALL_CASEINFO_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_STALL_CASEINFO_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_STALL_CASEINFO_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_stall_caseinfo">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfStallCaseinfoEntity inf_stall_caseinfo, SqlParameter[] parms)
        {
            parms[0].Value = inf_stall_caseinfo.CaseInfoNo;
            parms[1].Value = inf_stall_caseinfo.DeptId;
            parms[2].Value = inf_stall_caseinfo.DeptName;
            parms[3].Value = inf_stall_caseinfo.CaseDate;
            parms[4].Value = inf_stall_caseinfo.RoadNo;
            parms[5].Value = inf_stall_caseinfo.RoadName;
            parms[6].Value = inf_stall_caseinfo.CaseAddress;
            parms[7].Value = inf_stall_caseinfo.CaseFact;
            parms[8].Value = inf_stall_caseinfo.ItemeNo;
            parms[9].Value = inf_stall_caseinfo.ItemAct;
            parms[10].Value = inf_stall_caseinfo.RePersonelIdFist;
            parms[11].Value = inf_stall_caseinfo.RePersonelIdSecond;
            parms[12].Value = inf_stall_caseinfo.RePersonelNameSecond;
            parms[13].Value = inf_stall_caseinfo.RePersonelNameFist;
            parms[14].Value = inf_stall_caseinfo.TargetName;
            parms[15].Value = inf_stall_caseinfo.TargetAddress;
            parms[16].Value = inf_stall_caseinfo.TargetPaperType;
            parms[17].Value = inf_stall_caseinfo.TargetPaperNum;
            parms[18].Value = inf_stall_caseinfo.TargetGender;
            parms[19].Value = inf_stall_caseinfo.TargetAge;
            parms[20].Value = inf_stall_caseinfo.Lng;
            parms[21].Value = inf_stall_caseinfo.Lat;
            parms[22].Value = inf_stall_caseinfo.RowStatus;
            parms[23].Value = inf_stall_caseinfo.CreatorId;
            parms[24].Value = inf_stall_caseinfo.CreateBy;
            parms[25].Value = inf_stall_caseinfo.CreateOn;
            parms[26].Value = inf_stall_caseinfo.UpdateId;
            parms[27].Value = inf_stall_caseinfo.UpdateBy;
            parms[28].Value = inf_stall_caseinfo.UpdateOn;
            parms[29].Value = inf_stall_caseinfo.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfStallCaseinfoEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_STALL_CASEINFO_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_STALL_CASEINFO_CaseInfoNo, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_DeptId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_DeptName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CaseDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RoadNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RoadName, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CaseAddress, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CaseFact, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_STALL_CASEINFO_ItemeNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_STALL_CASEINFO_ItemAct, SqlDbType.NVarChar, 300),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RePersonelIdFist, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RePersonelIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RePersonelNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RePersonelNameFist, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetGender, SqlDbType.VarChar, 1),
					new SqlParameter(Parm_INF_STALL_CASEINFO_TargetAge, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_STALL_CASEINFO_Lng, SqlDbType.VarChar, 9),
					new SqlParameter(Parm_INF_STALL_CASEINFO_Lat, SqlDbType.VarChar, 9),
					new SqlParameter(Parm_INF_STALL_CASEINFO_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_STALL_CASEINFO_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_STALL_CASEINFO_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_STALL_CASEINFO_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_STALL_CASEINFO_Insert, parms);
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
    /// 流动摊贩查询界面实体
    /// </summary>
    [Serializable]
    public class CaseinfoEntityQuery
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 案由编号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 案件类型
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 路段
        /// </summary>
        public string RoadName { get; set; }
        /// <summary>
        /// 当事人
        /// </summary>
        public string TargetName { get; set; }
        /// <summary>
        /// 案发时间
        /// </summary>
        public DateTime CaseDate { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string CaseFact { get; set; }

        public CaseinfoEntityQuery GetList(DataRow row)
        {
            return new CaseinfoEntityQuery
            {
                Id = row["Id"].ToString(),
                ItemNo = row["ItemNo"].ToString(),
                ClassName = row["ClassName"].ToString(),
                RoadName = row["RoadName"].ToString(),
                CaseDate = Convert.ToDateTime(row["CaseDate"]),
                TargetName = row["TargetName"].ToString(),
                CaseFact = row["CaseFact"].ToString()
            };
        }
    }

    /// <summary>
    /// 流动摊贩详细信息
    /// </summary>
    public class CaseinfoEntityDetail 
    {
        public CaseinfoEntityDetail(InfStallCaseinfoEntity stallCase, List<InfStallAttachEntity> stallAttach)
        { 
            StallCase=stallCase;
            StallAttach = stallAttach;
        }

        public CaseinfoEntityDetail()
        {
            StallCase = new InfStallCaseinfoEntity();
            StallAttach = new List<InfStallAttachEntity>();
        }

        public InfStallCaseinfoEntity StallCase { get; set; }

        public List<InfStallAttachEntity> StallAttach { get; set; }
    }
}

