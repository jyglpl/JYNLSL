//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ExcavationEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/9/21 14:58:04
//  功能描述：Excavation表实体
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
    /// 许可-开挖
    /// </summary>
    [Serializable]
    public class ExcavationEntity : ModelImp.BaseModel<ExcavationEntity>
    {
        public ExcavationEntity()
        {
            TB_Name = TB_Excavation;
            Parm_Id = Parm_Excavation_Id;
            Parm_Version = Parm_Excavation_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Excavation_Insert;
            Sql_Update = Sql_Excavation_Update;
            Sql_Delete = Sql_Excavation_Delete;
        }
        #region Const of table Excavation
        /// <summary>
        /// Table Excavation
        /// </summary>
        public const string TB_Excavation = "Excavation";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BatchNum
        /// </summary>
        public const string Parm_Excavation_BatchNum = "BatchNum";
        /// <summary>
        /// Parm OwnerCompanyId
        /// </summary>
        public const string Parm_Excavation_OwnerCompanyId = "OwnerCompanyId";
        /// <summary>
        /// Parm OwnerCompanyName
        /// </summary>
        public const string Parm_Excavation_OwnerCompanyName = "OwnerCompanyName";

        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_Excavation_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Excavation_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Excavation_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Excavation_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Details
        /// </summary>
        public const string Parm_Excavation_Details = "Details";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        public const string Parm_Excavation_EndDate = "EndDate";
        /// <summary>
        /// Parm ExcavationNo
        /// </summary>
        public const string Parm_Excavation_ExcavationNo = "ExcavationNo";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Excavation_Id = "Id";
        /// <summary>
        /// Parm Mobile
        /// </summary>
        public const string Parm_Excavation_Mobile = "Mobile";
        /// <summary>
        /// Parm Proposer
        /// </summary>
        public const string Parm_Excavation_Proposer = "Proposer";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Excavation_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        public const string Parm_Excavation_StartDate = "StartDate";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Excavation_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Excavation_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Excavation_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Excavation_Version = "Version";
        /// <summary>
        /// Insert Query Of Excavation
        /// </summary>
        public const string Sql_Excavation_Insert = "insert into Excavation(BatchNum,OwnerCompanyId,OwnerCompanyName,CompanyName,CreateBy,CreateOn,CreatorId,Details,EndDate,ExcavationNo,Mobile,Proposer,RowStatus,StartDate,UpdateBy,UpdateId,UpdateOn,Id) values(@BatchNum,@OwnerCompanyId,@OwnerCompanyName,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@Details,@EndDate,@ExcavationNo,@Mobile,@Proposer,@RowStatus,@StartDate,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Excavation
        /// </summary>
        public const string Sql_Excavation_Update = "update Excavation set BatchNum=@BatchNum,OwnerCompanyId=@OwnerCompanyId,OwnerCompanyName=@OwnerCompanyName,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Details=@Details,EndDate=@EndDate,ExcavationNo=@ExcavationNo,Mobile=@Mobile,Proposer=@Proposer,RowStatus=@RowStatus,StartDate=@StartDate,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Excavation_Delete = "update Excavation set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _batchNum = string.Empty;
        /// <summary>
        /// 档案编号
        /// </summary>
        public string BatchNum
        {
            get { return _batchNum ?? string.Empty; }
            set { _batchNum = value; }
        }



        private string _excavationNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ExcavationNo
        {
            get { return _excavationNo ?? string.Empty; }
            set { _excavationNo = value; }
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
        private string _proposer = string.Empty;
        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer
        {
            get { return _proposer ?? string.Empty; }
            set { _proposer = value; }
        }
        private string _mobile = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobile
        {
            get { return _mobile ?? string.Empty; }
            set { _mobile = value; }
        }
        private string _details = string.Empty;
        /// <summary>
        /// 挖掘（占用）事由及范围
        /// </summary>
        public string Details
        {
            get { return _details ?? string.Empty; }
            set { _details = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 开工日期
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private DateTime _endDate = MinDate;
        /// <summary>
        /// 竣工日期
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
        /// 所属片区ID
        /// </summary>
        public string OwnerCompanyId { get; set; }

        /// <summary>
        /// 所属片区名称
        /// </summary>
        public string OwnerCompanyName { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ExcavationEntity SetModelValueByDataRow(DataRow dr)
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
        public override ExcavationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ExcavationEntity();
            if (fields.Contains(Parm_Excavation_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Excavation_Id].ToString();
            if (fields.Contains(Parm_Excavation_BatchNum) || fields.Contains("*"))
                tmp.BatchNum = dr[Parm_Excavation_BatchNum].ToString();
            if (fields.Contains(Parm_Excavation_ExcavationNo) || fields.Contains("*"))
                tmp.ExcavationNo = dr[Parm_Excavation_ExcavationNo].ToString();
            if (fields.Contains(Parm_Excavation_OwnerCompanyId) || fields.Contains("*"))
                tmp.OwnerCompanyId = dr[Parm_Excavation_OwnerCompanyId].ToString();
            if (fields.Contains(Parm_Excavation_OwnerCompanyName) || fields.Contains("*"))
                tmp.OwnerCompanyName = dr[Parm_Excavation_OwnerCompanyName].ToString();
            if (fields.Contains(Parm_Excavation_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_Excavation_CompanyName].ToString();
            if (fields.Contains(Parm_Excavation_Proposer) || fields.Contains("*"))
                tmp.Proposer = dr[Parm_Excavation_Proposer].ToString();
            if (fields.Contains(Parm_Excavation_Mobile) || fields.Contains("*"))
                tmp.Mobile = dr[Parm_Excavation_Mobile].ToString();
            if (fields.Contains(Parm_Excavation_Details) || fields.Contains("*"))
                tmp.Details = dr[Parm_Excavation_Details].ToString();
            if (fields.Contains(Parm_Excavation_StartDate) || fields.Contains("*"))
                tmp.StartDate = DateTime.Parse(dr[Parm_Excavation_StartDate].ToString());
            if (fields.Contains(Parm_Excavation_EndDate) || fields.Contains("*"))
                tmp.EndDate = DateTime.Parse(dr[Parm_Excavation_EndDate].ToString());
            if (fields.Contains(Parm_Excavation_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Excavation_RowStatus].ToString());
            if (fields.Contains(Parm_Excavation_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Excavation_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Excavation_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Excavation_CreatorId].ToString();
            if (fields.Contains(Parm_Excavation_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Excavation_CreateBy].ToString();
            if (fields.Contains(Parm_Excavation_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Excavation_CreateOn].ToString());
            if (fields.Contains(Parm_Excavation_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Excavation_UpdateId].ToString();
            if (fields.Contains(Parm_Excavation_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Excavation_UpdateBy].ToString();
            if (fields.Contains(Parm_Excavation_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Excavation_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="excavation">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ExcavationEntity excavation, SqlParameter[] parms)
        {
            parms[0].Value = excavation.BatchNum;
            parms[1].Value = excavation.ExcavationNo;
            parms[2].Value = excavation.OwnerCompanyId;
            parms[3].Value = excavation.OwnerCompanyName;
            parms[4].Value = excavation.CompanyName;
            parms[5].Value = excavation.Proposer;
            parms[6].Value = excavation.Mobile;
            parms[7].Value = excavation.Details;
            parms[8].Value = excavation.StartDate;
            parms[9].Value = excavation.EndDate;
            parms[10].Value = excavation.RowStatus;
            parms[11].Value = excavation.CreatorId;
            parms[12].Value = excavation.CreateBy;
            parms[13].Value = excavation.CreateOn;
            parms[14].Value = excavation.UpdateId;
            parms[15].Value = excavation.UpdateBy;
            parms[16].Value = excavation.UpdateOn;
            parms[17].Value = excavation.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ExcavationEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Excavation_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Excavation_BatchNum, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Excavation_ExcavationNo, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_Excavation_OwnerCompanyId, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_Excavation_OwnerCompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_Proposer, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_Mobile, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_Details, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_Excavation_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Excavation_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Excavation_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Excavation_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Excavation_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Excavation_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Excavation_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Excavation_Insert, parms);
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

