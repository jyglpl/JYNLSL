//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="PetitionEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-08-06 21:49:46
//  功能描述：Petition表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Petition
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PetitionEntity : ModelImp.BaseModel<PetitionEntity>
    {
        public PetitionEntity()
        {
            TB_Name = TB_Petition;
            Parm_Id = Parm_Petition_Id;
            Parm_Version = Parm_Petition_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Petition_Insert;
            Sql_Update = Sql_Petition_Update;
            Sql_Delete = Sql_Petition_Delete;
        }
        #region Const of table Petition
        /// <summary>
        /// Table Petition
        /// </summary>
        public const string TB_Petition = "Petition";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Address
        /// </summary>
        public const string Parm_Petition_Address = "Address";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Petition_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Petition_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Petition_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptSeal
        /// </summary>
        public const string Parm_Petition_DeptSeal = "DeptSeal";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        public const string Parm_Petition_EndDate = "EndDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Petition_Id = "Id";
        /// <summary>
        /// Parm IsFZCBack
        /// </summary>
        public const string Parm_Petition_IsFZCBack = "IsFZCBack";
        /// <summary>
        /// Parm IsLastProcess
        /// </summary>
        public const string Parm_Petition_IsLastProcess = "IsLastProcess";
        /// <summary>
        /// Parm OfficeSeal
        /// </summary>
        public const string Parm_Petition_OfficeSeal = "OfficeSeal";
        /// <summary>
        /// Parm PetitionCompany
        /// </summary>
        public const string Parm_Petition_PetitionCompany = "PetitionCompany";
        /// <summary>
        /// Parm PetitionCompanyName
        /// </summary>
        public const string Parm_Petition_PetitionCompanyName = "PetitionCompanyName";
        /// <summary>
        /// Parm PetitionContent
        /// </summary>
        public const string Parm_Petition_PetitionContent = "PetitionContent";
        /// <summary>
        /// Parm PetitionNo
        /// </summary>
        public const string Parm_Petition_PetitionNo = "PetitionNo";
        /// <summary>
        /// Parm PetitionSource
        /// </summary>
        public const string Parm_Petition_PetitionSource = "PetitionSource";
        /// <summary>
        /// Parm PetitionTitile
        /// </summary>
        public const string Parm_Petition_PetitionTitile = "PetitionTitile";
        /// <summary>
        /// Parm PetitionType
        /// </summary>
        public const string Parm_Petition_PetitionType = "PetitionType";
        /// <summary>
        /// Parm PetitionUser
        /// </summary>
        public const string Parm_Petition_PetitionUser = "PetitionUser";
        /// <summary>
        /// Parm Phone
        /// </summary>
        public const string Parm_Petition_Phone = "Phone";
        /// <summary>
        /// Parm Priority
        /// </summary>
        public const string Parm_Petition_Priority = "Priority";
        /// <summary>
        /// Parm ReceiveDate
        /// </summary>
        public const string Parm_Petition_ReceiveDate = "ReceiveDate";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Petition_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SourceNo
        /// </summary>
        public const string Parm_Petition_SourceNo = "SourceNo";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_Petition_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Petition_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Petition_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Petition_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Petition_Version = "Version";
        /// <summary>
        /// Insert Query Of Petition
        /// </summary>
        public const string Sql_Petition_Insert = "insert into Petition(Address,CreateBy,CreateOn,CreatorId,DeptSeal,EndDate,IsFZCBack,IsLastProcess,OfficeSeal,PetitionCompany,PetitionCompanyName,PetitionContent,PetitionNo,PetitionSource,PetitionTitile,PetitionType,PetitionUser,Phone,Priority,ReceiveDate,RowStatus,SourceNo,Status,UpdateBy,UpdateId,UpdateOn,Id) values(@Address,@CreateBy,@CreateOn,@CreatorId,@DeptSeal,@EndDate,@IsFZCBack,@IsLastProcess,@OfficeSeal,@PetitionCompany,@PetitionCompanyName,@PetitionContent,@PetitionNo,@PetitionSource,@PetitionTitile,@PetitionType,@PetitionUser,@Phone,@Priority,@ReceiveDate,@RowStatus,@SourceNo,@Status,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Petition
        /// </summary>
        public const string Sql_Petition_Update = "update Petition set Address=@Address,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptSeal=@DeptSeal,EndDate=@EndDate,IsFZCBack=@IsFZCBack,IsLastProcess=@IsLastProcess,OfficeSeal=@OfficeSeal,PetitionCompany=@PetitionCompany,PetitionCompanyName=@PetitionCompanyName,PetitionContent=@PetitionContent,PetitionNo=@PetitionNo,PetitionSource=@PetitionSource,PetitionTitile=@PetitionTitile,PetitionType=@PetitionType,PetitionUser=@PetitionUser,Phone=@Phone,Priority=@Priority,ReceiveDate=@ReceiveDate,RowStatus=@RowStatus,SourceNo=@SourceNo,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Petition_Delete = "update Petition set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _petitionUser = string.Empty;
        /// <summary>
        /// 信访人
        /// </summary>
        public string PetitionUser
        {
            get { return _petitionUser ?? string.Empty; }
            set { _petitionUser = value; }
        }
        private string _petitionCompany = string.Empty;
        /// <summary>
        /// 所属大队
        /// </summary>
        public string PetitionCompany
        {
            get { return _petitionCompany ?? string.Empty; }
            set { _petitionCompany = value; }
        }
        private string _sourceNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SourceNo
        {
            get { return _sourceNo ?? string.Empty; }
            set { _sourceNo = value; }
        }
        private string _petitionNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionNo
        {
            get { return _petitionNo ?? string.Empty; }
            set { _petitionNo = value; }
        }
        private DateTime _receiveDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }
        private string _phone = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            get { return _phone ?? string.Empty; }
            set { _phone = value; }
        }
        private string _address = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get { return _address ?? string.Empty; }
            set { _address = value; }
        }
        private string _petitionTitile = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionTitile
        {
            get { return _petitionTitile ?? string.Empty; }
            set { _petitionTitile = value; }
        }
        private string _priority = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Priority
        {
            get { return _priority ?? string.Empty; }
            set { _priority = value; }
        }
        private string _petitionSource = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionSource
        {
            get { return _petitionSource ?? string.Empty; }
            set { _petitionSource = value; }
        }
        private string _petitionType = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionType
        {
            get { return _petitionType ?? string.Empty; }
            set { _petitionType = value; }
        }
        private int _status;
        /// <summary>
        /// 当前状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
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
        private string _petitionContent = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionContent
        {
            get { return _petitionContent ?? string.Empty; }
            set { _petitionContent = value; }
        }
        private int _isLastProcess;
        /// <summary>
        /// 
        /// </summary>
        public int IsLastProcess
        {
            get { return _isLastProcess; }
            set { _isLastProcess = value; }
        }
        private int _isFZCBack;
        /// <summary>
        /// 
        /// </summary>
        public int IsFZCBack
        {
            get { return _isFZCBack; }
            set { _isFZCBack = value; }
        }
        private string _petitionCompanyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PetitionCompanyName
        {
            get { return _petitionCompanyName ?? string.Empty; }
            set { _petitionCompanyName = value; }
        }
        private int _deptSeal;
        /// <summary>
        /// 部门盖章
        /// </summary>
        public int DeptSeal
        {
            get { return _deptSeal; }
            set { _deptSeal = value; }
        }
        private int _officeSeal;
        /// <summary>
        /// 处办盖章
        /// </summary>
        public int OfficeSeal
        {
            get { return _officeSeal; }
            set { _officeSeal = value; }
        }
        /// <summary>
        /// 附件材料
        /// </summary>
        public string Attachment { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public string AttachmentType { get; set; }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override PetitionEntity SetModelValueByDataRow(DataRow dr)
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
        public override PetitionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new PetitionEntity();
            if (fields.Contains(Parm_Petition_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Petition_Id].ToString();
            if (fields.Contains(Parm_Petition_PetitionUser) || fields.Contains("*"))
                tmp.PetitionUser = dr[Parm_Petition_PetitionUser].ToString();
            if (fields.Contains(Parm_Petition_PetitionCompany) || fields.Contains("*"))
                tmp.PetitionCompany = dr[Parm_Petition_PetitionCompany].ToString();
            if (fields.Contains(Parm_Petition_SourceNo) || fields.Contains("*"))
                tmp.SourceNo = dr[Parm_Petition_SourceNo].ToString();
            if (fields.Contains(Parm_Petition_PetitionNo) || fields.Contains("*"))
                tmp.PetitionNo = dr[Parm_Petition_PetitionNo].ToString();
            if (fields.Contains(Parm_Petition_ReceiveDate) || fields.Contains("*"))
                tmp.ReceiveDate = DateTime.Parse(dr[Parm_Petition_ReceiveDate].ToString());
            if (fields.Contains(Parm_Petition_Phone) || fields.Contains("*"))
                tmp.Phone = dr[Parm_Petition_Phone].ToString();
            if (fields.Contains(Parm_Petition_Address) || fields.Contains("*"))
                tmp.Address = dr[Parm_Petition_Address].ToString();
            if (fields.Contains(Parm_Petition_PetitionTitile) || fields.Contains("*"))
                tmp.PetitionTitile = dr[Parm_Petition_PetitionTitile].ToString();
            if (fields.Contains(Parm_Petition_Priority) || fields.Contains("*"))
                tmp.Priority = dr[Parm_Petition_Priority].ToString();
            if (fields.Contains(Parm_Petition_PetitionSource) || fields.Contains("*"))
                tmp.PetitionSource = dr[Parm_Petition_PetitionSource].ToString();
            if (fields.Contains(Parm_Petition_PetitionType) || fields.Contains("*"))
                tmp.PetitionType = dr[Parm_Petition_PetitionType].ToString();
            if (fields.Contains(Parm_Petition_Status) || fields.Contains("*"))
                tmp.Status = int.Parse(dr[Parm_Petition_Status].ToString());
            if (fields.Contains(Parm_Petition_EndDate) || fields.Contains("*"))
                tmp.EndDate = DateTime.Parse(dr[Parm_Petition_EndDate].ToString());
            if (fields.Contains(Parm_Petition_PetitionContent) || fields.Contains("*"))
                tmp.PetitionContent = dr[Parm_Petition_PetitionContent].ToString();
            if (fields.Contains(Parm_Petition_IsLastProcess) || fields.Contains("*"))
                tmp.IsLastProcess = int.Parse(dr[Parm_Petition_IsLastProcess].ToString());
            if (fields.Contains(Parm_Petition_IsFZCBack) || fields.Contains("*"))
                tmp.IsFZCBack = int.Parse(dr[Parm_Petition_IsFZCBack].ToString());
            if (fields.Contains(Parm_Petition_PetitionCompanyName) || fields.Contains("*"))
                tmp.PetitionCompanyName = dr[Parm_Petition_PetitionCompanyName].ToString();
            if (fields.Contains(Parm_Petition_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Petition_RowStatus].ToString());
            if (fields.Contains(Parm_Petition_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Petition_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Petition_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Petition_CreatorId].ToString();
            if (fields.Contains(Parm_Petition_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Petition_CreateBy].ToString();
            if (fields.Contains(Parm_Petition_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Petition_CreateOn].ToString());
            if (fields.Contains(Parm_Petition_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Petition_UpdateId].ToString();
            if (fields.Contains(Parm_Petition_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Petition_UpdateBy].ToString();
            if (fields.Contains(Parm_Petition_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Petition_UpdateOn].ToString());
            if (fields.Contains(Parm_Petition_DeptSeal) || fields.Contains("*"))
                tmp.DeptSeal = int.Parse(dr[Parm_Petition_DeptSeal].ToString());
            if (fields.Contains(Parm_Petition_OfficeSeal) || fields.Contains("*"))
                tmp.OfficeSeal = int.Parse(dr[Parm_Petition_OfficeSeal].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="petition">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(PetitionEntity petition, SqlParameter[] parms)
        {
            parms[0].Value = petition.PetitionUser;
            parms[1].Value = petition.PetitionCompany;
            parms[2].Value = petition.SourceNo;
            parms[3].Value = petition.PetitionNo;
            parms[4].Value = petition.ReceiveDate;
            parms[5].Value = petition.Phone;
            parms[6].Value = petition.Address;
            parms[7].Value = petition.PetitionTitile;
            parms[8].Value = petition.Priority;
            parms[9].Value = petition.PetitionSource;
            parms[10].Value = petition.PetitionType;
            parms[11].Value = petition.Status;
            parms[12].Value = petition.EndDate;
            parms[13].Value = petition.PetitionContent;
            parms[14].Value = petition.IsLastProcess;
            parms[15].Value = petition.IsFZCBack;
            parms[16].Value = petition.PetitionCompanyName;
            parms[17].Value = petition.RowStatus;
            parms[18].Value = petition.CreatorId;
            parms[19].Value = petition.CreateBy;
            parms[20].Value = petition.CreateOn;
            parms[21].Value = petition.UpdateId;
            parms[22].Value = petition.UpdateBy;
            parms[23].Value = petition.UpdateOn;
            parms[24].Value = petition.DeptSeal;
            parms[25].Value = petition.OfficeSeal;
            parms[26].Value = petition.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(PetitionEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Petition_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Petition_PetitionUser, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_PetitionCompany, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_SourceNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_PetitionNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_ReceiveDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Petition_Phone, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_Address, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_Petition_PetitionTitile, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_Petition_Priority, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_PetitionSource, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_PetitionType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_Petition_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Petition_PetitionContent, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_Petition_IsLastProcess, SqlDbType.Int, 10),
					new SqlParameter(Parm_Petition_IsFZCBack, SqlDbType.Int, 10),
					new SqlParameter(Parm_Petition_PetitionCompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Petition_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Petition_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Petition_UpdateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Petition_DeptSeal, SqlDbType.Int, 10),
					new SqlParameter(Parm_Petition_OfficeSeal, SqlDbType.Int, 10),
                    new SqlParameter(Parm_Petition_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Petition_Insert, parms);
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

