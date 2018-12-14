//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TemporaryEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/9/21 15:28:45
//  功能描述：Temporary表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Consent
{
    /// <summary>
    /// 许可-占道经营
    /// </summary>
    [Serializable]
    public class TemporaryEntity : ModelImp.BaseModel<TemporaryEntity>
    {
        public TemporaryEntity()
        {
            TB_Name = TB_Temporary;
            Parm_Id = Parm_Temporary_Id;
            Parm_Version = Parm_Temporary_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Temporary_Insert;
            Sql_Update = Sql_Temporary_Update;
            Sql_Delete = Sql_Temporary_Delete;
        }
        #region Const of table Temporary
        /// <summary>
        /// Table Temporary
        /// </summary>
        public const string TB_Temporary = "Temporary";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ApplicationName
        /// </summary>
        public const string Parm_Temporary_ApplicationName = "ApplicationName";
        /// <summary>
        /// Parm BatchNum
        /// </summary>
        public const string Parm_Temporary_BatchNum = "BatchNum";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Temporary_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Temporary_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Temporary_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        public const string Parm_Temporary_EndDate = "EndDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Temporary_Id = "Id";
        /// <summary>
        /// Parm INTERNAL_NO
        /// </summary>
        public const string Parm_Temporary_INTERNAL_NO = "INTERNAL_NO";
        /// <summary>
        /// Parm JeevesAddress
        /// </summary>
        public const string Parm_Temporary_JeevesAddress = "JeevesAddress";
        /// <summary>
        /// Parm JeevesCause
        /// </summary>
        public const string Parm_Temporary_JeevesCause = "JeevesCause";

        /// <summary>
        /// Parm FloorArea
        /// </summary>
        public const string Parm_Temporary_FloorArea = "FloorArea";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Temporary_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        public const string Parm_Temporary_StartDate = "StartDate";
        /// <summary>
        /// Parm TemporaryNo
        /// </summary>
        public const string Parm_Temporary_TemporaryNo = "TemporaryNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Temporary_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Temporary_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Temporary_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Temporary_Version = "Version";

        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_Temporary_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_Temporary_CompanyName = "CompanyName";

        /// <summary>
        /// Insert Query Of Temporary
        /// </summary>
        public const string Sql_Temporary_Insert = "insert into Temporary(CompanyId,CompanyName,ApplicationName,BatchNum,CreateBy,CreateOn,CreatorId,EndDate,INTERNAL_NO,JeevesAddress,JeevesCause,RowStatus,StartDate,TemporaryNo,UpdateBy,UpdateId,UpdateOn,FloorArea,Id) values(@CompanyId,@CompanyName,@ApplicationName,@BatchNum,@CreateBy,@CreateOn,@CreatorId,@EndDate,@INTERNAL_NO,@JeevesAddress,@JeevesCause,@RowStatus,@StartDate,@TemporaryNo,@UpdateBy,@UpdateId,@UpdateOn,@FloorArea,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Temporary
        /// </summary>
        public const string Sql_Temporary_Update = "update Temporary set ApplicationName=@ApplicationName,BatchNum=@BatchNum,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndDate=@EndDate,INTERNAL_NO=@INTERNAL_NO,JeevesAddress=@JeevesAddress,JeevesCause=@JeevesCause,RowStatus=@RowStatus,StartDate=@StartDate,TemporaryNo=@TemporaryNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,FloorArea=@FloorArea,CompanyName=@CompanyName,CompanyId=@CompanyId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Temporary_Delete = "update Temporary set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _batchNum = string.Empty;
        /// <summary>
        /// 存档编号
        /// </summary>
        public string BatchNum
        {
            get { return _batchNum ?? string.Empty; }
            set { _batchNum = value; }
        }
        private string _temporaryNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string TemporaryNo
        {
            get { return _temporaryNo ?? string.Empty; }
            set { _temporaryNo = value; }
        }
        private string _iNTERNAL_NO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string INTERNAL_NO
        {
            get { return _iNTERNAL_NO ?? string.Empty; }
            set { _iNTERNAL_NO = value; }
        }
        private string _applicationName = string.Empty;
        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplicationName
        {
            get { return _applicationName ?? string.Empty; }
            set { _applicationName = value; }
        }
        private string _jeevesAddress = string.Empty;
        /// <summary>
        /// 占道地点
        /// </summary>
        public string JeevesAddress
        {
            get { return _jeevesAddress ?? string.Empty; }
            set { _jeevesAddress = value; }
        }
        private string _jeevesCause = string.Empty;
        /// <summary>
        /// 占道原因
        /// </summary>
        public string JeevesCause
        {
            get { return _jeevesCause ?? string.Empty; }
            set { _jeevesCause = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private DateTime _endDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /// <summary>
        /// 附件信息
        /// </summary>
        public string Attachment { get; set; }

        /// <summary>
        /// 占道面积
        /// </summary>
        public string FloorArea { get; set; }

        /// <summary>
        /// 大队ID
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 大队名称
        /// </summary>
        public string CompanyName { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override TemporaryEntity SetModelValueByDataRow(DataRow dr)
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
        public override TemporaryEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TemporaryEntity();
            if (fields.Contains(Parm_Temporary_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Temporary_Id].ToString();
            if (fields.Contains(Parm_Temporary_BatchNum) || fields.Contains("*"))
                tmp.BatchNum = dr[Parm_Temporary_BatchNum].ToString();
            if (fields.Contains(Parm_Temporary_TemporaryNo) || fields.Contains("*"))
                tmp.TemporaryNo = dr[Parm_Temporary_TemporaryNo].ToString();
            if (fields.Contains(Parm_Temporary_INTERNAL_NO) || fields.Contains("*"))
                tmp.INTERNAL_NO = dr[Parm_Temporary_INTERNAL_NO].ToString();
            if (fields.Contains(Parm_Temporary_ApplicationName) || fields.Contains("*"))
                tmp.ApplicationName = dr[Parm_Temporary_ApplicationName].ToString();
            if (fields.Contains(Parm_Temporary_JeevesAddress) || fields.Contains("*"))
                tmp.JeevesAddress = dr[Parm_Temporary_JeevesAddress].ToString();
            if (fields.Contains(Parm_Temporary_JeevesCause) || fields.Contains("*"))
                tmp.JeevesCause = dr[Parm_Temporary_JeevesCause].ToString();
            if (fields.Contains(Parm_Temporary_StartDate) || fields.Contains("*"))
                tmp.StartDate = DateTime.Parse(dr[Parm_Temporary_StartDate].ToString());
            if (fields.Contains(Parm_Temporary_EndDate) || fields.Contains("*"))
                tmp.EndDate = DateTime.Parse(dr[Parm_Temporary_EndDate].ToString());
            if (fields.Contains(Parm_Temporary_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Temporary_RowStatus].ToString());
            if (fields.Contains(Parm_Temporary_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Temporary_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Temporary_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Temporary_CreatorId].ToString();
            if (fields.Contains(Parm_Temporary_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Temporary_CreateBy].ToString();
            if (fields.Contains(Parm_Temporary_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Temporary_CreateOn].ToString());
            if (fields.Contains(Parm_Temporary_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Temporary_UpdateId].ToString();
            if (fields.Contains(Parm_Temporary_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Temporary_UpdateBy].ToString();
            if (fields.Contains(Parm_Temporary_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Temporary_UpdateOn].ToString());
            if (fields.Contains(Parm_Temporary_FloorArea) || fields.Contains("*"))
                tmp.FloorArea = dr[Parm_Temporary_FloorArea].ToString();
            if (fields.Contains(Parm_Temporary_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_Temporary_CompanyId].ToString();
            if (fields.Contains(Parm_Temporary_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_Temporary_CompanyName].ToString();
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="temporary">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TemporaryEntity temporary, SqlParameter[] parms)
        {   
            parms[0].Value = temporary.BatchNum;
            parms[1].Value = temporary.TemporaryNo;
            parms[2].Value = temporary.INTERNAL_NO;
            parms[3].Value = temporary.ApplicationName;
            parms[4].Value = temporary.JeevesAddress;
            parms[5].Value = temporary.JeevesCause;
            parms[6].Value = temporary.StartDate;
            parms[7].Value = temporary.EndDate;
            parms[8].Value = temporary.RowStatus;
            parms[9].Value = temporary.CreatorId;
            parms[10].Value = temporary.CreateBy;
            parms[11].Value = temporary.CreateOn;
            parms[12].Value = temporary.UpdateId;
            parms[13].Value = temporary.UpdateBy;
            parms[14].Value = temporary.UpdateOn;   
            parms[15].Value = temporary.FloorArea;
            parms[16].Value = temporary.CompanyId;
            parms[17].Value = temporary.CompanyName;
            parms[18].Value = temporary.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TemporaryEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite,
                                                                          Sql_Temporary_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_Temporary_BatchNum, SqlDbType.VarChar, 50),
                            new SqlParameter(Parm_Temporary_TemporaryNo, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_INTERNAL_NO, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_ApplicationName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_JeevesAddress, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_JeevesCause, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_StartDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_Temporary_EndDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_Temporary_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_Temporary_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_Temporary_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_Temporary_FloorArea, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_CompanyId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_CompanyName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_Temporary_Id, SqlDbType.NVarChar, 50)
                            
                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Temporary_Insert, parms);
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


