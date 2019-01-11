//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseJeevesEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-04-11 14:42:22
//  功能描述：LicenseJeeves表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class LicenseJeevesEntity : ModelImp.BaseModel<LicenseJeevesEntity>
    {
        public LicenseJeevesEntity()
        {
            TB_Name = TB_LicenseJeeves;
            Parm_Id = Parm_LicenseJeeves_Id;
            Parm_Version = Parm_LicenseJeeves_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicenseJeeves_Insert;
            Sql_Update = Sql_LicenseJeeves_Update;
            Sql_Delete = Sql_LicenseJeeves_Delete;
        }
        #region Const of table LicenseJeeves
        /// <summary>
        /// Table LicenseJeeves
        /// </summary>
        public const string TB_LicenseJeeves = "LicenseJeeves";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AcceptType
        /// </summary>
        public const string Parm_LicenseJeeves_AcceptType = "AcceptType";
        /// <summary>
        /// Parm CheckLength
        /// </summary>
        public const string Parm_LicenseJeeves_CheckLength = "CheckLength";
        /// <summary>
        /// Parm CheckWidth
        /// </summary>
        public const string Parm_LicenseJeeves_CheckWidth = "CheckWidth";
        /// <summary>
        /// Parm Content
        /// </summary>
        public const string Parm_LicenseJeeves_Content = "Content";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicenseJeeves_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicenseJeeves_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicenseJeeves_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Enterprise
        /// </summary>
        public const string Parm_LicenseJeeves_Enterprise = "Enterprise";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicenseJeeves_Id = "Id";
        /// <summary>
        /// Parm InquestAdress
        /// </summary>
        public const string Parm_LicenseJeeves_InquestAdress = "InquestAdress";
        /// <summary>
        /// Parm InquestLength
        /// </summary>
        public const string Parm_LicenseJeeves_InquestLength = "InquestLength";
        /// <summary>
        /// Parm InquestWidth
        /// </summary>
        public const string Parm_LicenseJeeves_InquestWidth = "InquestWidth";
        /// <summary>
        /// Parm IsCheck
        /// </summary>
        public const string Parm_LicenseJeeves_IsCheck = "IsCheck";
        /// <summary>
        /// Parm IsInquest
        /// </summary>
        public const string Parm_LicenseJeeves_IsInquest = "IsInquest";
        /// <summary>
        /// Parm JeevesAdress
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesAdress = "JeevesAdress";
        /// <summary>
        /// Parm JeevesArea
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesArea = "JeevesArea";
        /// <summary>
        /// Parm JeevesEndTime
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesEndTime = "JeevesEndTime";
        /// <summary>
        /// Parm JeevesLength
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesLength = "JeevesLength";
        /// <summary>
        /// Parm JeevesStartTime
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesStartTime = "JeevesStartTime";
        /// <summary>
        /// Parm JeevesWidth
        /// </summary>
        public const string Parm_LicenseJeeves_JeevesWidth = "JeevesWidth";
        /// <summary>
        /// Parm LicenseId
        /// </summary>
        public const string Parm_LicenseJeeves_LicenseId = "LicenseId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicenseJeeves_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SetUpCycleDetails
        /// </summary>
        public const string Parm_LicenseJeeves_SetUpCycleDetails = "SetUpCycleDetails";
        /// <summary>
        /// Parm SetUpCycleOther
        /// </summary>
        public const string Parm_LicenseJeeves_SetUpCycleOther = "SetUpCycleOther";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicenseJeeves_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicenseJeeves_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicenseJeeves_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicenseJeeves_Version = "Version";
        /// <summary>
        /// Insert Query Of LicenseJeeves
        /// </summary>
        public const string Sql_LicenseJeeves_Insert = "insert into LicenseJeeves(AcceptType,CheckLength,CheckWidth,Content,CreateBy,CreateOn,CreatorId,Enterprise,InquestAdress,InquestLength,InquestWidth,IsCheck,IsInquest,JeevesAdress,JeevesArea,JeevesEndTime,JeevesLength,JeevesStartTime,JeevesWidth,LicenseId,RowStatus,SetUpCycleDetails,SetUpCycleOther,UpdateBy,UpdateId,UpdateOn,Id) values(@AcceptType,@CheckLength,@CheckWidth,@Content,@CreateBy,@CreateOn,@CreatorId,@Enterprise,@InquestAdress,@InquestLength,@InquestWidth,@IsCheck,@IsInquest,@JeevesAdress,@JeevesArea,@JeevesEndTime,@JeevesLength,@JeevesStartTime,@JeevesWidth,@LicenseId,@RowStatus,@SetUpCycleDetails,@SetUpCycleOther,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicenseJeeves
        /// </summary>
        public const string Sql_LicenseJeeves_Update = "update LicenseJeeves set AcceptType=@AcceptType,CheckLength=@CheckLength,CheckWidth=@CheckWidth,Content=@Content,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Enterprise=@Enterprise,InquestAdress=@InquestAdress,InquestLength=@InquestLength,InquestWidth=@InquestWidth,IsCheck=@IsCheck,IsInquest=@IsInquest,JeevesAdress=@JeevesAdress,JeevesArea=@JeevesArea,JeevesEndTime=@JeevesEndTime,JeevesLength=@JeevesLength,JeevesStartTime=@JeevesStartTime,JeevesWidth=@JeevesWidth,LicenseId=@LicenseId,RowStatus=@RowStatus,SetUpCycleDetails=@SetUpCycleDetails,SetUpCycleOther=@SetUpCycleOther,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicenseJeeves_Delete = "update LicenseJeeves set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        /// 占道原因
        /// </summary>
        public string Content
        {
            get { return _content ?? string.Empty; }
            set { _content = value; }
        }
        private Double _jeevesWidth;
        /// <summary>
        /// 占道宽
        /// </summary>
        public Double JeevesWidth
        {
            get { return _jeevesWidth; }
            set { _jeevesWidth = value; }
        }
        private Double _jeevesLength;
        /// <summary>
        /// 占道长度
        /// </summary>
        public Double JeevesLength
        {
            get { return _jeevesLength; }
            set { _jeevesLength = value; }
        }
        private string _jeevesArea;
        /// <summary>
        /// 占道面积
        /// </summary>
        public string JeevesArea
        {
            get { return _jeevesArea; }
            set { _jeevesArea = value; }
        }
        private string _jeevesAdress = string.Empty;
        /// <summary>
        /// 占道地点
        /// </summary>
        public string JeevesAdress
        {
            get { return _jeevesAdress ?? string.Empty; }
            set { _jeevesAdress = value; }
        }
        private DateTime _jeevesStartTime = MinDate;
        /// <summary>
        /// 占道开始时间
        /// </summary>
        public DateTime JeevesStartTime
        {
            get { return _jeevesStartTime; }
            set { _jeevesStartTime = value; }
        }
        private DateTime _jeevesEndTime = MinDate;
        /// <summary>
        /// 占道结束时间
        /// </summary>
        public DateTime JeevesEndTime
        {
            get { return _jeevesEndTime; }
            set { _jeevesEndTime = value; }
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
        private string _isInquest = string.Empty;
        /// <summary>
        /// 确认勘验（0068）
        /// </summary>
        public string IsInquest
        {
            get { return _isInquest ?? string.Empty; }
            set { _isInquest = value; }
        }
        private string _isCheck = string.Empty;
        /// <summary>
        /// 确认验收（0068）
        /// </summary>
        public string IsCheck
        {
            get { return _isCheck ?? string.Empty; }
            set { _isCheck = value; }
        }
        private string _inquestAdress = string.Empty;
        /// <summary>
        /// 现场勘验地址门牌号
        /// </summary>
        public string InquestAdress
        {
            get { return _inquestAdress ?? string.Empty; }
            set { _inquestAdress = value; }
        }
        private Double _inquestWidth;
        /// <summary>
        /// 勘验宽
        /// </summary>
        public Double InquestWidth
        {
            get { return _inquestWidth; }
            set { _inquestWidth = value; }
        }
        private Double _inquestLength;
        /// <summary>
        /// 勘验长度
        /// </summary>
        public Double InquestLength
        {
            get { return _inquestLength; }
            set { _inquestLength = value; }
        }
        private Double _checkWidth;
        /// <summary>
        /// 现场验收宽
        /// </summary>
        public Double CheckWidth
        {
            get { return _checkWidth; }
            set { _checkWidth = value; }
        }
        private Double _checkLength;
        /// <summary>
        /// 现场验收长度
        /// </summary>
        public Double CheckLength
        {
            get { return _checkLength; }
            set { _checkLength = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicenseJeevesEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicenseJeevesEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicenseJeevesEntity();
            if (fields.Contains(Parm_LicenseJeeves_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicenseJeeves_Id].ToString();
            if (fields.Contains(Parm_LicenseJeeves_LicenseId) || fields.Contains("*"))
                tmp.LicenseId = dr[Parm_LicenseJeeves_LicenseId].ToString();
            if (fields.Contains(Parm_LicenseJeeves_Content) || fields.Contains("*"))
                tmp.Content = dr[Parm_LicenseJeeves_Content].ToString();
            if (fields.Contains(Parm_LicenseJeeves_JeevesWidth) || fields.Contains("*"))
                tmp.JeevesWidth = Double.Parse(dr[Parm_LicenseJeeves_JeevesWidth].ToString());
            if (fields.Contains(Parm_LicenseJeeves_JeevesLength) || fields.Contains("*"))
                tmp.JeevesLength = Double.Parse(dr[Parm_LicenseJeeves_JeevesLength].ToString());
            if (fields.Contains(Parm_LicenseJeeves_JeevesArea) || fields.Contains("*"))
                tmp.JeevesArea = dr[Parm_LicenseJeeves_JeevesArea].ToString();
            if (fields.Contains(Parm_LicenseJeeves_JeevesAdress) || fields.Contains("*"))
                tmp.JeevesAdress = dr[Parm_LicenseJeeves_JeevesAdress].ToString();
            if (fields.Contains(Parm_LicenseJeeves_JeevesStartTime) || fields.Contains("*"))
                tmp.JeevesStartTime = DateTime.Parse(dr[Parm_LicenseJeeves_JeevesStartTime].ToString());
            if (fields.Contains(Parm_LicenseJeeves_JeevesEndTime) || fields.Contains("*"))
                tmp.JeevesEndTime = DateTime.Parse(dr[Parm_LicenseJeeves_JeevesEndTime].ToString());
            if (fields.Contains(Parm_LicenseJeeves_SetUpCycleDetails) || fields.Contains("*"))
                tmp.SetUpCycleDetails = dr[Parm_LicenseJeeves_SetUpCycleDetails].ToString();
            if (fields.Contains(Parm_LicenseJeeves_SetUpCycleOther) || fields.Contains("*"))
                tmp.SetUpCycleOther = dr[Parm_LicenseJeeves_SetUpCycleOther].ToString();
            if (fields.Contains(Parm_LicenseJeeves_AcceptType) || fields.Contains("*"))
                tmp.AcceptType = dr[Parm_LicenseJeeves_AcceptType].ToString();
            if (fields.Contains(Parm_LicenseJeeves_Enterprise) || fields.Contains("*"))
                tmp.Enterprise = dr[Parm_LicenseJeeves_Enterprise].ToString();
            if (fields.Contains(Parm_LicenseJeeves_IsInquest) || fields.Contains("*"))
                tmp.IsInquest = dr[Parm_LicenseJeeves_IsInquest].ToString();
            if (fields.Contains(Parm_LicenseJeeves_IsCheck) || fields.Contains("*"))
                tmp.IsCheck = dr[Parm_LicenseJeeves_IsCheck].ToString();
            if (fields.Contains(Parm_LicenseJeeves_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicenseJeeves_RowStatus].ToString());
            if (fields.Contains(Parm_LicenseJeeves_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicenseJeeves_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicenseJeeves_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicenseJeeves_CreatorId].ToString();
            if (fields.Contains(Parm_LicenseJeeves_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicenseJeeves_CreateBy].ToString();
            if (fields.Contains(Parm_LicenseJeeves_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicenseJeeves_CreateOn].ToString());
            if (fields.Contains(Parm_LicenseJeeves_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicenseJeeves_UpdateId].ToString();
            if (fields.Contains(Parm_LicenseJeeves_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicenseJeeves_UpdateBy].ToString();
            if (fields.Contains(Parm_LicenseJeeves_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicenseJeeves_UpdateOn].ToString());
            if (fields.Contains(Parm_LicenseJeeves_InquestAdress) || fields.Contains("*"))
                tmp.InquestAdress = dr[Parm_LicenseJeeves_InquestAdress].ToString();
            if (fields.Contains(Parm_LicenseJeeves_InquestWidth) || fields.Contains("*"))
                tmp.InquestWidth = Double.Parse(dr[Parm_LicenseJeeves_InquestWidth].ToString());
            if (fields.Contains(Parm_LicenseJeeves_InquestLength) || fields.Contains("*"))
                tmp.InquestLength = Double.Parse(dr[Parm_LicenseJeeves_InquestLength].ToString());
            if (fields.Contains(Parm_LicenseJeeves_CheckWidth) || fields.Contains("*"))
                tmp.CheckWidth = Double.Parse(dr[Parm_LicenseJeeves_CheckWidth].ToString());
            if (fields.Contains(Parm_LicenseJeeves_CheckLength) || fields.Contains("*"))
                tmp.CheckLength = Double.Parse(dr[Parm_LicenseJeeves_CheckLength].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensejeeves">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicenseJeevesEntity licensejeeves, SqlParameter[] parms)
        {
            parms[0].Value = licensejeeves.LicenseId;
            parms[1].Value = licensejeeves.Content;
            parms[2].Value = licensejeeves.JeevesWidth;
            parms[3].Value = licensejeeves.JeevesLength;
            parms[4].Value = licensejeeves.JeevesArea;
            parms[5].Value = licensejeeves.JeevesAdress;
            parms[6].Value = licensejeeves.JeevesStartTime;
            parms[7].Value = licensejeeves.JeevesEndTime;
            parms[8].Value = licensejeeves.SetUpCycleDetails;
            parms[9].Value = licensejeeves.SetUpCycleOther;
            parms[10].Value = licensejeeves.AcceptType;
            parms[11].Value = licensejeeves.Enterprise;
            parms[12].Value = licensejeeves.IsInquest;
            parms[13].Value = licensejeeves.IsCheck;
            parms[14].Value = licensejeeves.RowStatus;
            parms[15].Value = licensejeeves.CreatorId;
            parms[16].Value = licensejeeves.CreateBy;
            parms[17].Value = licensejeeves.CreateOn;
            parms[18].Value = licensejeeves.UpdateId;
            parms[19].Value = licensejeeves.UpdateBy;
            parms[20].Value = licensejeeves.UpdateOn;
            parms[21].Value = licensejeeves.InquestAdress;
            parms[22].Value = licensejeeves.InquestWidth;
            parms[23].Value = licensejeeves.InquestLength;
            parms[24].Value = licensejeeves.CheckWidth;
            parms[25].Value = licensejeeves.CheckLength;
            parms[26].Value = licensejeeves.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicenseJeevesEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseJeeves_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicenseJeeves_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_Content, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseJeeves_JeevesWidth, SqlDbType.Float, 53),
					new SqlParameter(Parm_LicenseJeeves_JeevesLength, SqlDbType.Float, 53),
					new SqlParameter(Parm_LicenseJeeves_JeevesArea, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseJeeves_JeevesAdress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseJeeves_JeevesStartTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseJeeves_JeevesEndTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseJeeves_SetUpCycleDetails, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_SetUpCycleOther, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_AcceptType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_Enterprise, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_IsInquest, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_IsCheck, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicenseJeeves_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseJeeves_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicenseJeeves_UpdateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicenseJeeves_InquestAdress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LicenseJeeves_InquestWidth, SqlDbType.Float, 53),
					new SqlParameter(Parm_LicenseJeeves_InquestLength, SqlDbType.Float, 53),
					new SqlParameter(Parm_LicenseJeeves_CheckWidth, SqlDbType.Float, 53),
					new SqlParameter(Parm_LicenseJeeves_CheckLength, SqlDbType.Float, 53),
                    new SqlParameter(Parm_LicenseJeeves_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicenseJeeves_Insert, parms);
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
    /// “占道现场勘验”请求实体
    /// </summary>
    public class RequestJeevesInquest
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
        /// 现场勘验地址门牌号
        /// </summary>
        public string InquestAdress { get; set; }

        /// <summary>
        /// 勘验长度
        /// </summary>
        public double InquestLength { get; set; }

        /// <summary>
        /// 勘验面积
        /// </summary>
        public string InquestArea { get; set; }

        /// <summary>
        /// 勘验宽度
        /// </summary>
        public double InquestWidth { get; set; }

        /// <summary>
        /// 确认勘验（0068）
        /// </summary>
        public string IsInquest { get; set; }

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
    /// “占道现场现场验收”请求实体
    /// </summary>
    public class RequestJeevesCheck
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
        /// 现场验收长度
        /// </summary>
        public double CheckLength { get; set; }

        /// <summary>
        /// 现场验收宽度
        /// </summary>
        public double CheckWidth { get; set; }

        /// <summary>
        /// 现场验收面积
        /// </summary>
        public string CheckArea { get; set; }

        /// <summary>
        /// 操作人的编号
        /// </summary>
        public string HandUserId { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string ClosedIdea { get; set; }
    }
}

