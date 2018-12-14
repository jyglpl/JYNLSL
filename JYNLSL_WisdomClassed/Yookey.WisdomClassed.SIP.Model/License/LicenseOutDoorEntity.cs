//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseOutDoorEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-01 16:46:13
//  功能描述：LicenseOutDoor表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.License
{
    /// <summary>
    /// 户外广告信息详情
    /// </summary>
    [Serializable]
    public class LicenseOutDoorEntity : ModelImp.BaseModel<LicenseOutDoorEntity>
    {
        public LicenseOutDoorEntity()
        {
            TB_Name = TB_LicenseOutDoor;
            Parm_Id = Parm_LicenseOutDoor_Id;
            Parm_Version = Parm_LicenseOutDoor_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicenseOutDoor_Insert;
            Sql_Update = Sql_LicenseOutDoor_Update;
            Sql_Delete = Sql_LicenseOutDoor_Delete;
        }
        #region Const of table LicenseOutDoor
        /// <summary>
        /// Table LicenseOutDoor
        /// </summary>
        public const string TB_LicenseOutDoor = "LicenseOutDoor";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AcceptanceCheckNumbers
        /// </summary>
        public const string Parm_LicenseOutDoor_AcceptanceCheckNumbers = "AcceptanceCheckNumbers";
        /// <summary>
        /// Parm AcceptType
        /// </summary>
        public const string Parm_LicenseOutDoor_AcceptType = "AcceptType";
        /// <summary>
        /// Parm CheckLeftHeight
        /// </summary>
        public const string Parm_LicenseOutDoor_CheckLeftHeight = "CheckLeftHeight";
        /// <summary>
        /// Parm CheckLeftLogn
        /// </summary>
        public const string Parm_LicenseOutDoor_CheckLeftLogn = "CheckLeftLogn";
        /// <summary>
        /// Parm CheckNumbers
        /// </summary>
        public const string Parm_LicenseOutDoor_CheckNumbers = "CheckNumbers";
        /// <summary>
        /// Parm CheckRightHeight
        /// </summary>
        public const string Parm_LicenseOutDoor_CheckRightHeight = "CheckRightHeight";
        /// <summary>
        /// Parm CheckRightLogn
        /// </summary>
        public const string Parm_LicenseOutDoor_CheckRightLogn = "CheckRightLogn";
        /// <summary>
        /// Parm Content
        /// </summary>
        public const string Parm_LicenseOutDoor_Content = "Content";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicenseOutDoor_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicenseOutDoor_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicenseOutDoor_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Enterprise
        /// </summary>
        public const string Parm_LicenseOutDoor_Enterprise = "Enterprise";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicenseOutDoor_Id = "Id";
        /// <summary>
        /// Parm InstallEndDate
        /// </summary>
        public const string Parm_LicenseOutDoor_InstallEndDate = "InstallEndDate";
        /// <summary>
        /// Parm InstallStartDate
        /// </summary>
        public const string Parm_LicenseOutDoor_InstallStartDate = "InstallStartDate";
        /// <summary>
        /// Parm IsCheck
        /// </summary>
        public const string Parm_LicenseOutDoor_IsCheck = "IsCheck";
        /// <summary>
        /// Parm IsInquest
        /// </summary>
        public const string Parm_LicenseOutDoor_IsInquest = "IsInquest";
        /// <summary>
        /// Parm LaneArea
        /// </summary>
        public const string Parm_LicenseOutDoor_LaneArea = "LaneArea";
        /// <summary>
        /// Parm LicenseId
        /// </summary>
        public const string Parm_LicenseOutDoor_LicenseId = "LicenseId";
        /// <summary>
        /// Parm Nature
        /// </summary>
        public const string Parm_LicenseOutDoor_Nature = "Nature";
        /// <summary>
        /// Parm Numbers
        /// </summary>
        public const string Parm_LicenseOutDoor_Numbers = "Numbers";
        /// <summary>
        /// Parm OutdoorType
        /// </summary>
        public const string Parm_LicenseOutDoor_OutdoorType = "OutdoorType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicenseOutDoor_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SetUpCycle
        /// </summary>
        public const string Parm_LicenseOutDoor_SetUpCycle = "SetUpCycle";
        /// <summary>
        /// Parm SetUpCycleDetails
        /// </summary>
        public const string Parm_LicenseOutDoor_SetUpCycleDetails = "SetUpCycleDetails";
        /// <summary>
        /// Parm SetUpCycleOther
        /// </summary>
        public const string Parm_LicenseOutDoor_SetUpCycleOther = "SetUpCycleOther";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicenseOutDoor_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicenseOutDoor_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicenseOutDoor_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicenseOutDoor_Version = "Version";
        /// <summary>
        /// Insert Query Of LicenseOutDoor
        /// </summary>
        public const string Sql_LicenseOutDoor_Insert = "insert into LicenseOutDoor(AcceptanceCheckNumbers,AcceptType,CheckLeftHeight,CheckLeftLogn,CheckNumbers,CheckRightHeight,CheckRightLogn,Content,CreateBy,CreateOn,CreatorId,Enterprise,InstallEndDate,InstallStartDate,IsCheck,IsInquest,LaneArea,LicenseId,Nature,Numbers,OutdoorType,RowStatus,SetUpCycle,SetUpCycleDetails,SetUpCycleOther,UpdateBy,UpdateId,UpdateOn,Id) values(@AcceptanceCheckNumbers,@AcceptType,@CheckLeftHeight,@CheckLeftLogn,@CheckNumbers,@CheckRightHeight,@CheckRightLogn,@Content,@CreateBy,@CreateOn,@CreatorId,@Enterprise,@InstallEndDate,@InstallStartDate,@IsCheck,@IsInquest,@LaneArea,@LicenseId,@Nature,@Numbers,@OutdoorType,@RowStatus,@SetUpCycle,@SetUpCycleDetails,@SetUpCycleOther,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicenseOutDoor
        /// </summary>
        public const string Sql_LicenseOutDoor_Update = "update LicenseOutDoor set AcceptanceCheckNumbers=@AcceptanceCheckNumbers,AcceptType=@AcceptType,CheckLeftHeight=@CheckLeftHeight,CheckLeftLogn=@CheckLeftLogn,CheckNumbers=@CheckNumbers,CheckRightHeight=@CheckRightHeight,CheckRightLogn=@CheckRightLogn,Content=@Content,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Enterprise=@Enterprise,InstallEndDate=@InstallEndDate,InstallStartDate=@InstallStartDate,IsCheck=@IsCheck,IsInquest=@IsInquest,LaneArea=@LaneArea,LicenseId=@LicenseId,Nature=@Nature,Numbers=@Numbers,OutdoorType=@OutdoorType,RowStatus=@RowStatus,SetUpCycle=@SetUpCycle,SetUpCycleDetails=@SetUpCycleDetails,SetUpCycleOther=@SetUpCycleOther,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicenseOutDoor_Delete = "update LicenseOutDoor set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _licenseId = string.Empty;
        /// <summary>
        /// 许可主键ID
        /// </summary>
        public string LicenseId
        {
            get { return _licenseId ?? string.Empty; }
            set { _licenseId = value; }
        }
        private string _content = string.Empty;
        /// <summary>
        /// 广告内容
        /// </summary>
        public string Content
        {
            get { return _content ?? string.Empty; }
            set { _content = value; }
        }
        private int _numbers;
        /// <summary>
        /// 申请设置数量
        /// </summary>
        public int Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }
        private string _outdoorType = string.Empty;
        /// <summary>
        /// 广告类型：0056
        /// </summary>
        public string OutdoorType
        {
            get { return _outdoorType ?? string.Empty; }
            set { _outdoorType = value; }
        }
        private string _nature = string.Empty;
        /// <summary>
        /// 广告性质：0058
        /// </summary>
        public string Nature
        {
            get { return _nature ?? string.Empty; }
            set { _nature = value; }
        }
        private string _setUpCycle = string.Empty;
        /// <summary>
        /// 设置周期：0059
        /// </summary>
        public string SetUpCycle
        {
            get { return _setUpCycle ?? string.Empty; }
            set { _setUpCycle = value; }
        }
        private string _setUpCycleDetails = string.Empty;
        /// <summary>
        /// 设置周期：0060
        /// </summary>
        public string SetUpCycleDetails
        {
            get { return _setUpCycleDetails ?? string.Empty; }
            set { _setUpCycleDetails = value; }
        }
        private string _setUpCycleOther = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SetUpCycleOther
        {
            get { return _setUpCycleOther ?? string.Empty; }
            set { _setUpCycleOther = value; }
        }
        private DateTime _installStartDate = MinDate;
        /// <summary>
        /// 安装开始日期
        /// </summary>
        public DateTime InstallStartDate
        {
            get { return _installStartDate; }
            set { _installStartDate = value; }
        }
        private DateTime _installEndDate = MinDate;
        /// <summary>
        /// 安装截止日期
        /// </summary>
        public DateTime InstallEndDate
        {
            get { return _installEndDate; }
            set { _installEndDate = value; }
        }
        private string _laneArea = string.Empty;
        /// <summary>
        /// 占道面积
        /// </summary>
        public string LaneArea
        {
            get { return _laneArea ?? string.Empty; }
            set { _laneArea = value; }
        }
        private string _acceptType = string.Empty;
        /// <summary>
        /// 受理类型：0061
        /// </summary>
        public string AcceptType
        {
            get { return _acceptType ?? string.Empty; }
            set { _acceptType = value; }
        }
        private string _enterprise = string.Empty;
        /// <summary>
        /// 环保企业分类别
        /// </summary>
        public string Enterprise
        {
            get { return _enterprise ?? string.Empty; }
            set { _enterprise = value; }
        }
        private string _checkLeftHeight = string.Empty;
        /// <summary>
        /// 勘验左领高度
        /// </summary>
        public string CheckLeftHeight
        {
            get { return _checkLeftHeight ?? string.Empty; }
            set { _checkLeftHeight = value; }
        }
        private string _checkRightHeight = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CheckRightHeight
        {
            get { return _checkRightHeight ?? string.Empty; }
            set { _checkRightHeight = value; }
        }
        private string _checkLeftLogn = string.Empty;
        /// <summary>
        /// 勘验左领外挑
        /// </summary>
        public string CheckLeftLogn
        {
            get { return _checkLeftLogn ?? string.Empty; }
            set { _checkLeftLogn = value; }
        }
        private string _checkRightLogn = string.Empty;
        /// <summary>
        /// 勘验右领外挑
        /// </summary>
        public string CheckRightLogn
        {
            get { return _checkRightLogn ?? string.Empty; }
            set { _checkRightLogn = value; }
        }
        private int _checkNumbers;
        /// <summary>
        /// 勘验检查数量
        /// </summary>
        public int CheckNumbers
        {
            get { return _checkNumbers; }
            set { _checkNumbers = value; }
        }
        private int _acceptanceCheckNumbers;
        /// <summary>
        /// 验收检查数量
        /// </summary>
        public int AcceptanceCheckNumbers
        {
            get { return _acceptanceCheckNumbers; }
            set { _acceptanceCheckNumbers = value; }
        }
        private string _isInquest = string.Empty;
        /// <summary>
        /// 确认勘验（1.符合 2.不符合）
        /// </summary>
        public string IsInquest
        {
            get { return _isInquest ?? string.Empty; }
            set { _isInquest = value; }
        }
        private string _isCheck = string.Empty;
        /// <summary>
        /// 确认验收（1.符合 2.不符合）
        /// </summary>
        public string IsCheck
        {
            get { return _isCheck ?? string.Empty; }
            set { _isCheck = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicenseOutDoorEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicenseOutDoorEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseOutDoorEntity();
            if (fields.Contains(Parm_LicenseOutDoor_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicenseOutDoor_Id].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_LicenseId) || fields.Contains("*"))
                tmp.LicenseId = dr[Parm_LicenseOutDoor_LicenseId].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_Content) || fields.Contains("*"))
                tmp.Content = dr[Parm_LicenseOutDoor_Content].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_Numbers) || fields.Contains("*"))
                tmp.Numbers = int.Parse(dr[Parm_LicenseOutDoor_Numbers].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_OutdoorType) || fields.Contains("*"))
                tmp.OutdoorType = dr[Parm_LicenseOutDoor_OutdoorType].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_Nature) || fields.Contains("*"))
                tmp.Nature = dr[Parm_LicenseOutDoor_Nature].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_SetUpCycle) || fields.Contains("*"))
                tmp.SetUpCycle = dr[Parm_LicenseOutDoor_SetUpCycle].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_SetUpCycleDetails) || fields.Contains("*"))
                tmp.SetUpCycleDetails = dr[Parm_LicenseOutDoor_SetUpCycleDetails].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_SetUpCycleOther) || fields.Contains("*"))
                tmp.SetUpCycleOther = dr[Parm_LicenseOutDoor_SetUpCycleOther].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_InstallStartDate) || fields.Contains("*"))
                tmp.InstallStartDate = DateTime.Parse(dr[Parm_LicenseOutDoor_InstallStartDate].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_InstallEndDate) || fields.Contains("*"))
                tmp.InstallEndDate = DateTime.Parse(dr[Parm_LicenseOutDoor_InstallEndDate].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_LaneArea) || fields.Contains("*"))
                tmp.LaneArea = dr[Parm_LicenseOutDoor_LaneArea].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_AcceptType) || fields.Contains("*"))
                tmp.AcceptType = dr[Parm_LicenseOutDoor_AcceptType].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_Enterprise) || fields.Contains("*"))
                tmp.Enterprise = dr[Parm_LicenseOutDoor_Enterprise].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CheckLeftHeight) || fields.Contains("*"))
                tmp.CheckLeftHeight = dr[Parm_LicenseOutDoor_CheckLeftHeight].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CheckRightHeight) || fields.Contains("*"))
                tmp.CheckRightHeight = dr[Parm_LicenseOutDoor_CheckRightHeight].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CheckLeftLogn) || fields.Contains("*"))
                tmp.CheckLeftLogn = dr[Parm_LicenseOutDoor_CheckLeftLogn].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CheckRightLogn) || fields.Contains("*"))
                tmp.CheckRightLogn = dr[Parm_LicenseOutDoor_CheckRightLogn].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CheckNumbers) || fields.Contains("*"))
                tmp.CheckNumbers = int.Parse(dr[Parm_LicenseOutDoor_CheckNumbers].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_AcceptanceCheckNumbers) || fields.Contains("*"))
                tmp.AcceptanceCheckNumbers = int.Parse(dr[Parm_LicenseOutDoor_AcceptanceCheckNumbers].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_IsInquest) || fields.Contains("*"))
                tmp.IsInquest = dr[Parm_LicenseOutDoor_IsInquest].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_IsCheck) || fields.Contains("*"))
                tmp.IsCheck = dr[Parm_LicenseOutDoor_IsCheck].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicenseOutDoor_RowStatus].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicenseOutDoor_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicenseOutDoor_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicenseOutDoor_CreatorId].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicenseOutDoor_CreateBy].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseOutDoor_CreateOn].ToString());
            if (fields.Contains(Parm_LicenseOutDoor_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicenseOutDoor_UpdateId].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicenseOutDoor_UpdateBy].ToString();
            if (fields.Contains(Parm_LicenseOutDoor_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseOutDoor_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licenseoutdoor">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicenseOutDoorEntity licenseoutdoor, SqlParameter[] parms)
        {
            parms[0].Value = licenseoutdoor.LicenseId;
            parms[1].Value = licenseoutdoor.Content;
            parms[2].Value = licenseoutdoor.Numbers;
            parms[3].Value = licenseoutdoor.OutdoorType;
            parms[4].Value = licenseoutdoor.Nature;
            parms[5].Value = licenseoutdoor.SetUpCycle;
            parms[6].Value = licenseoutdoor.SetUpCycleDetails;
            parms[7].Value = licenseoutdoor.SetUpCycleOther;
            parms[8].Value = licenseoutdoor.InstallStartDate;
            parms[9].Value = licenseoutdoor.InstallEndDate;
            parms[10].Value = licenseoutdoor.LaneArea;
            parms[11].Value = licenseoutdoor.AcceptType;
            parms[12].Value = licenseoutdoor.Enterprise;
            parms[13].Value = licenseoutdoor.CheckLeftHeight;
            parms[14].Value = licenseoutdoor.CheckRightHeight;
            parms[15].Value = licenseoutdoor.CheckLeftLogn;
            parms[16].Value = licenseoutdoor.CheckRightLogn;
            parms[17].Value = licenseoutdoor.CheckNumbers;
            parms[18].Value = licenseoutdoor.AcceptanceCheckNumbers;
            parms[19].Value = licenseoutdoor.IsInquest;
            parms[20].Value = licenseoutdoor.IsCheck;
            parms[21].Value = licenseoutdoor.RowStatus;
            parms[22].Value = licenseoutdoor.CreatorId;
            parms[23].Value = licenseoutdoor.CreateBy;
            parms[24].Value = licenseoutdoor.CreateOn;
            parms[25].Value = licenseoutdoor.UpdateId;
            parms[26].Value = licenseoutdoor.UpdateBy;
            parms[27].Value = licenseoutdoor.UpdateOn;
            parms[28].Value = licenseoutdoor.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseOutDoorEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseOutDoor_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicenseOutDoor_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_Content, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseOutDoor_Numbers, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseOutDoor_OutdoorType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_Nature, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_SetUpCycle, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_SetUpCycleDetails, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_SetUpCycleOther, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_InstallStartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseOutDoor_InstallEndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseOutDoor_LaneArea, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseOutDoor_AcceptType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_Enterprise, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_CheckLeftHeight, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseOutDoor_CheckRightHeight, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseOutDoor_CheckLeftLogn, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseOutDoor_CheckRightLogn, SqlDbType.NVarChar, 5),
					new SqlParameter(Parm_LicenseOutDoor_CheckNumbers, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseOutDoor_AcceptanceCheckNumbers, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseOutDoor_IsInquest, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_IsCheck, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseOutDoor_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseOutDoor_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseOutDoor_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicenseOutDoor_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseOutDoor_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }

    #region 勘验、现场验收信息

    /// <summary>
    /// 户外广告现场勘验、现场验收规格信息
    /// </summary>
    public class LicenseOutDoorCheckSpec
    {
        /// <summary>
        /// 宽
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 外挑
        /// </summary>
        public string Long { get; set; }
    }

    /// <summary>
    /// 经纬度信息
    /// </summary>
    public class Latitude
    {
        public decimal GpsLat { get; set; }

        public decimal GpsLng { get; set; }

        public decimal BaiDuLat { get; set; }

        public decimal BaiDuLng { get; set; }
    }

    /// <summary>
    /// “户外广告现场勘验”请求实体
    /// </summary>
    public class RequestOutDoorInquestCheckSpec
    {
        /// <summary>
        /// 许可主键
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// 勘验左领高度
        /// </summary>
        public string CheckLeftHeight { get; set; }

        /// <summary>
        /// 勘验右领高度
        /// </summary>
        public string CheckRightHeight { get; set; }

        /// <summary>
        /// 勘验左领外挑
        /// </summary>
        public string CheckLeftLogn { get; set; }

        /// <summary>
        /// 勘验右领外挑
        /// </summary>
        public string CheckRightLogn { get; set; }

        /// <summary>
        /// 勘验检查数量
        /// </summary>
        public string CheckNumbers { get; set; }

        /// <summary>
        /// 确认勘验（0068）
        /// </summary>
        public string IsInquest { get; set; }

        /// <summary>
        /// 经纬度信息
        /// </summary>
        public Latitude Latitude { get; set; }
        
        /// <summary>
        /// 尺寸信息
        /// </summary>
        public List<LicenseOutDoorCheckSpec> Specs { get; set; }

        /// <summary>
        /// 操作人的编号
        /// </summary>
        public string HandUserId { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string ClosedIdea { get; set; }
    }

    /// <summary>
    /// “户外广告现场验收”请求实体
    /// </summary>
    public class RequestOutDoorAcceptanceCheckSpec
    {
        /// <summary>
        /// 许可主键
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// 经纬度信息
        /// </summary>
        public Latitude Latitude { get; set; }

        /// <summary>
        /// 确认验收（0068）
        /// </summary>
        public string IsCheck { get; set; }

        /// <summary>
        /// 验收检查数量
        /// </summary>
        public string AcceptanceCheckNumbers { get; set; }

        /// <summary>
        /// 尺寸信息
        /// </summary>
        public List<LicenseOutDoorCheckSpec> Specs { get; set; }

        /// <summary>
        /// 操作人的编号
        /// </summary>
        public string HandUserId { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string ClosedIdea { get; set; }
    }
   

    #endregion
}

