//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_RECORDEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/11/11 15:50:58
//  功能描述：INF_PUNISH_RECORD表实体
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
    /// 调查询问笔录
    /// </summary>
    [Serializable]
    public class InfPunishRecordEntity : ModelImp.BaseModel<InfPunishRecordEntity>
    {
       	public InfPunishRecordEntity()
		{
			TB_Name = TB_INF_PUNISH_RECORD;
			Parm_Id = Parm_INF_PUNISH_RECORD_Id;
			Parm_Version = Parm_INF_PUNISH_RECORD_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_RECORD_Insert;
			Sql_Update = Sql_INF_PUNISH_RECORD_Update;
			Sql_Delete = Sql_INF_PUNISH_RECORD_Delete;
		}
       	#region Const of table INF_PUNISH_RECORD
		/// <summary>
		/// Table INF_PUNISH_RECORD
		/// </summary>
		public const string TB_INF_PUNISH_RECORD = "INF_PUNISH_RECORD";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Address
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_Address = "Address";
		/// <summary>
		/// Parm BirthDate
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_BirthDate = "BirthDate";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm CaseInfoNo
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CaseInfoNo = "CaseInfoNo";
		/// <summary>
		/// Parm CaseRelationship
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CaseRelationship = "CaseRelationship";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_CreatorId = "CreatorId";
		/// <summary>
		/// Parm EndDate
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_EndDate = "EndDate";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_Id = "Id";
		/// <summary>
		/// Parm ItemName
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_ItemName = "ItemName";
		/// <summary>
		/// Parm QuestionerFirstId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_QuestionerFirstId = "QuestionerFirstId";
		/// <summary>
		/// Parm QuestionerFirstName
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_QuestionerFirstName = "QuestionerFirstName";
		/// <summary>
		/// Parm QuestionerSecondId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_QuestionerSecondId = "QuestionerSecondId";
		/// <summary>
		/// Parm QuestionerSecondName
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_QuestionerSecondName = "QuestionerSecondName";
		/// <summary>
		/// Parm RecordInfo
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_RecordInfo = "RecordInfo";
		/// <summary>
		/// Parm RecordsId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_RecordsId = "RecordsId";
		/// <summary>
		/// Parm RecordsName
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_RecordsName = "RecordsName";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_RowStatus = "RowStatus";
		/// <summary>
		/// Parm StartDate
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_StartDate = "StartDate";
		/// <summary>
		/// Parm TargetAddress
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetAddress = "TargetAddress";
		/// <summary>
		/// Parm TargetDuty
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetDuty = "TargetDuty";
		/// <summary>
		/// Parm TargetEmail
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetEmail = "TargetEmail";
		/// <summary>
		/// Parm TargetGender
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetGender = "TargetGender";
		/// <summary>
		/// Parm TargetMobile
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetMobile = "TargetMobile";
		/// <summary>
		/// Parm TargetName
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetName = "TargetName";
		/// <summary>
		/// Parm TargetPaperNum
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetPaperNum = "TargetPaperNum";
		/// <summary>
		/// Parm TargetPaperType
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetPaperType = "TargetPaperType";
		/// <summary>
		/// Parm TargetPhone
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetPhone = "TargetPhone";
		/// <summary>
		/// Parm TargetUnit
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetUnit = "TargetUnit";
		/// <summary>
		/// Parm TargetZipCode
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_TargetZipCode = "TargetZipCode";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_RECORD_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_RECORD
		/// </summary>
		public const string Sql_INF_PUNISH_RECORD_Insert = "insert into INF_PUNISH_RECORD(Address,BirthDate,CaseInfoId,CaseInfoNo,CaseRelationship,CreateBy,CreateOn,CreatorId,EndDate,ItemName,QuestionerFirstId,QuestionerFirstName,QuestionerSecondId,QuestionerSecondName,RecordInfo,RecordsId,RecordsName,RowStatus,StartDate,TargetAddress,TargetDuty,TargetEmail,TargetGender,TargetMobile,TargetName,TargetPaperNum,TargetPaperType,TargetPhone,TargetUnit,TargetZipCode,UpdateBy,UpdateId,UpdateOn,Id) values(@Address,@BirthDate,@CaseInfoId,@CaseInfoNo,@CaseRelationship,@CreateBy,@CreateOn,@CreatorId,@EndDate,@ItemName,@QuestionerFirstId,@QuestionerFirstName,@QuestionerSecondId,@QuestionerSecondName,@RecordInfo,@RecordsId,@RecordsName,@RowStatus,@StartDate,@TargetAddress,@TargetDuty,@TargetEmail,@TargetGender,@TargetMobile,@TargetName,@TargetPaperNum,@TargetPaperType,@TargetPhone,@TargetUnit,@TargetZipCode,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_RECORD
		/// </summary>
		public const string Sql_INF_PUNISH_RECORD_Update = "update INF_PUNISH_RECORD set Address=@Address,BirthDate=@BirthDate,CaseInfoId=@CaseInfoId,CaseInfoNo=@CaseInfoNo,CaseRelationship=@CaseRelationship,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndDate=@EndDate,ItemName=@ItemName,QuestionerFirstId=@QuestionerFirstId,QuestionerFirstName=@QuestionerFirstName,QuestionerSecondId=@QuestionerSecondId,QuestionerSecondName=@QuestionerSecondName,RecordInfo=@RecordInfo,RecordsId=@RecordsId,RecordsName=@RecordsName,RowStatus=@RowStatus,StartDate=@StartDate,TargetAddress=@TargetAddress,TargetDuty=@TargetDuty,TargetEmail=@TargetEmail,TargetGender=@TargetGender,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,TargetPhone=@TargetPhone,TargetUnit=@TargetUnit,TargetZipCode=@TargetZipCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_RECORD_Delete = "update INF_PUNISH_RECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _caseInfoId = string.Empty;
		/// <summary>
		/// nvarchar 	案件编号
		/// </summary>
		public string CaseInfoId
		{
			get{return _caseInfoId ?? string.Empty;}
			set{_caseInfoId = value;}
		}
		private string _caseInfoNo = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CaseInfoNo
		{
			get{return _caseInfoNo ?? string.Empty;}
			set{_caseInfoNo = value;}
		}
		private string _itemName = string.Empty;
		/// <summary>
		/// nvarchar 	适用案由
		/// </summary>
		public string ItemName
		{
			get{return _itemName ?? string.Empty;}
			set{_itemName = value;}
		}
		private DateTime _startDate = MinDate;
		/// <summary>
		/// datetime 	开始时间
		/// </summary>
		public DateTime StartDate
		{
			get{return _startDate;}
			set{_startDate = value;}
		}
		private DateTime _endDate = MinDate;
		/// <summary>
		/// datetime 	结束时间
		/// </summary>
		public DateTime EndDate
		{
			get{return _endDate;}
			set{_endDate = value;}
		}
		private string _address = string.Empty;
		/// <summary>
		/// nvarchar 	调查地点
		/// </summary>
		public string Address
		{
			get{return _address ?? string.Empty;}
			set{_address = value;}
		}
		private string _questionerFirstId = string.Empty;
		/// <summary>
		/// nvarchar 询问人1
		/// </summary>
		public string QuestionerFirstId
		{
			get{return _questionerFirstId ?? string.Empty;}
			set{_questionerFirstId = value;}
		}
		private string _questionerSecondId = string.Empty;
		/// <summary>
		/// 询问人2
		/// </summary>
		public string QuestionerSecondId
		{
			get{return _questionerSecondId ?? string.Empty;}
			set{_questionerSecondId = value;}
		}
		private string _questionerFirstName = string.Empty;
		/// <summary>
		/// 询问人1 姓名
		/// </summary>
		public string QuestionerFirstName
		{
			get{return _questionerFirstName ?? string.Empty;}
			set{_questionerFirstName = value;}
		}
		private string _questionerSecondName = string.Empty;
		/// <summary>
		/// 询问人2姓名
		/// </summary>
		public string QuestionerSecondName
		{
			get{return _questionerSecondName ?? string.Empty;}
			set{_questionerSecondName = value;}
		}
		private string _recordsId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string RecordsId
		{
			get{return _recordsId ?? string.Empty;}
			set{_recordsId = value;}
		}
		private string _recordsName = string.Empty;
		/// <summary>
		/// nvarchar 	记录人
		/// </summary>
		public string RecordsName
		{
			get{return _recordsName ?? string.Empty;}
			set{_recordsName = value;}
		}
		private string _targetName = string.Empty;
		/// <summary>
		/// nvarchar 	当事人姓名/负责人姓名
		/// </summary>
		public string TargetName
		{
			get{return _targetName ?? string.Empty;}
			set{_targetName = value;}
		}
		private string _targetAddress = string.Empty;
		/// <summary>
		/// nvarchar 	当事人地址
		/// </summary>
		public string TargetAddress
		{
			get{return _targetAddress ?? string.Empty;}
			set{_targetAddress = value;}
		}
		private string _targetPaperType = string.Empty;
		/// <summary>
		/// nvarchar 	证件类型
		/// </summary>
		public string TargetPaperType
		{
			get{return _targetPaperType ?? string.Empty;}
			set{_targetPaperType = value;}
		}
		private string _targetPaperNum = string.Empty;
		/// <summary>
		/// varchar 	证件号码
		/// </summary>
		public string TargetPaperNum
		{
			get{return _targetPaperNum ?? string.Empty;}
			set{_targetPaperNum = value;}
		}
		private string _targetGender = string.Empty;
		/// <summary>
		/// int 	当事人性别（0：女 1：男）
		/// </summary>
		public string TargetGender
		{
			get{return _targetGender ?? string.Empty;}
			set{_targetGender = value;}
		}
		private string _birthDate = string.Empty;
		/// <summary>
		/// 出生年月
		/// </summary>
		public string BirthDate
		{
			get{return _birthDate ?? string.Empty;}
			set{_birthDate = value;}
		}
		private string _targetUnit = string.Empty;
		/// <summary>
		/// nvarchar 	单位名称
		/// </summary>
		public string TargetUnit
		{
			get{return _targetUnit ?? string.Empty;}
			set{_targetUnit = value;}
		}
		private string _targetDuty = string.Empty;
		/// <summary>
		/// nvarchar 	当事人职务
		/// </summary>
		public string TargetDuty
		{
			get{return _targetDuty ?? string.Empty;}
			set{_targetDuty = value;}
		}
		private string _targetPhone = string.Empty;
		/// <summary>
		/// varchar 	当事人联系电话
		/// </summary>
		public string TargetPhone
		{
			get{return _targetPhone ?? string.Empty;}
			set{_targetPhone = value;}
		}
		private string _targetMobile = string.Empty;
		/// <summary>
		/// varchar 	当事人手机号
		/// </summary>
		public string TargetMobile
		{
			get{return _targetMobile ?? string.Empty;}
			set{_targetMobile = value;}
		}
		private string _targetZipCode = string.Empty;
		/// <summary>
		/// varchar 	邮编
		/// </summary>
		public string TargetZipCode
		{
			get{return _targetZipCode ?? string.Empty;}
			set{_targetZipCode = value;}
		}
		private string _targetEmail = string.Empty;
		/// <summary>
		/// nvarchar 	电子邮件
		/// </summary>
		public string TargetEmail
		{
			get{return _targetEmail ?? string.Empty;}
			set{_targetEmail = value;}
		}
		private string _caseRelationship = string.Empty;
		/// <summary>
		/// 与本案关系
		/// </summary>
		public string CaseRelationship
		{
			get{return _caseRelationship ?? string.Empty;}
			set{_caseRelationship = value;}
		}
		private string _recordInfo = string.Empty;
		/// <summary>
		/// 笔录内容
		/// </summary>
		public string RecordInfo
		{
			get{return _recordInfo ?? string.Empty;}
			set{_recordInfo = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishRecordEntity SetModelValueByDataRow(DataRow dr)
      	{
            IList<string> fields = new List<string> {"*"};
   	    	return SetModelValueByDataRow(dr,fields);
        }

		/// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
		public override InfPunishRecordEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishRecordEntity();
          			if (fields.Contains(Parm_INF_PUNISH_RECORD_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_RECORD_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_RECORD_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CaseInfoNo) || fields.Contains("*"))
				tmp.CaseInfoNo = dr[Parm_INF_PUNISH_RECORD_CaseInfoNo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_ItemName) || fields.Contains("*"))
				tmp.ItemName = dr[Parm_INF_PUNISH_RECORD_ItemName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_StartDate) || fields.Contains("*"))
				tmp.StartDate = DateTime.Parse(dr[Parm_INF_PUNISH_RECORD_StartDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECORD_EndDate) || fields.Contains("*"))
				tmp.EndDate = DateTime.Parse(dr[Parm_INF_PUNISH_RECORD_EndDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECORD_Address) || fields.Contains("*"))
				tmp.Address = dr[Parm_INF_PUNISH_RECORD_Address].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_QuestionerFirstId) || fields.Contains("*"))
				tmp.QuestionerFirstId = dr[Parm_INF_PUNISH_RECORD_QuestionerFirstId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_QuestionerSecondId) || fields.Contains("*"))
				tmp.QuestionerSecondId = dr[Parm_INF_PUNISH_RECORD_QuestionerSecondId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_QuestionerFirstName) || fields.Contains("*"))
				tmp.QuestionerFirstName = dr[Parm_INF_PUNISH_RECORD_QuestionerFirstName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_QuestionerSecondName) || fields.Contains("*"))
				tmp.QuestionerSecondName = dr[Parm_INF_PUNISH_RECORD_QuestionerSecondName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_RecordsId) || fields.Contains("*"))
				tmp.RecordsId = dr[Parm_INF_PUNISH_RECORD_RecordsId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_RecordsName) || fields.Contains("*"))
				tmp.RecordsName = dr[Parm_INF_PUNISH_RECORD_RecordsName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetName) || fields.Contains("*"))
				tmp.TargetName = dr[Parm_INF_PUNISH_RECORD_TargetName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetAddress) || fields.Contains("*"))
				tmp.TargetAddress = dr[Parm_INF_PUNISH_RECORD_TargetAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetPaperType) || fields.Contains("*"))
				tmp.TargetPaperType = dr[Parm_INF_PUNISH_RECORD_TargetPaperType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetPaperNum) || fields.Contains("*"))
				tmp.TargetPaperNum = dr[Parm_INF_PUNISH_RECORD_TargetPaperNum].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetGender) || fields.Contains("*"))
				tmp.TargetGender = dr[Parm_INF_PUNISH_RECORD_TargetGender].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_BirthDate) || fields.Contains("*"))
				tmp.BirthDate = dr[Parm_INF_PUNISH_RECORD_BirthDate].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetUnit) || fields.Contains("*"))
				tmp.TargetUnit = dr[Parm_INF_PUNISH_RECORD_TargetUnit].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetDuty) || fields.Contains("*"))
				tmp.TargetDuty = dr[Parm_INF_PUNISH_RECORD_TargetDuty].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetPhone) || fields.Contains("*"))
				tmp.TargetPhone = dr[Parm_INF_PUNISH_RECORD_TargetPhone].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetMobile) || fields.Contains("*"))
				tmp.TargetMobile = dr[Parm_INF_PUNISH_RECORD_TargetMobile].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetZipCode) || fields.Contains("*"))
				tmp.TargetZipCode = dr[Parm_INF_PUNISH_RECORD_TargetZipCode].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_TargetEmail) || fields.Contains("*"))
				tmp.TargetEmail = dr[Parm_INF_PUNISH_RECORD_TargetEmail].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CaseRelationship) || fields.Contains("*"))
				tmp.CaseRelationship = dr[Parm_INF_PUNISH_RECORD_CaseRelationship].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_RecordInfo) || fields.Contains("*"))
				tmp.RecordInfo = dr[Parm_INF_PUNISH_RECORD_RecordInfo].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_RECORD_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECORD_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_RECORD_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_RECORD_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_RECORD_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_RECORD_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECORD_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_RECORD_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_RECORD_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECORD_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_RECORD_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_record">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishRecordEntity inf_punish_record, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_record.CaseInfoId;
				parms[1].Value = inf_punish_record.CaseInfoNo;
				parms[2].Value = inf_punish_record.ItemName;
				parms[3].Value = inf_punish_record.StartDate;
				parms[4].Value = inf_punish_record.EndDate;
				parms[5].Value = inf_punish_record.Address;
				parms[6].Value = inf_punish_record.QuestionerFirstId;
				parms[7].Value = inf_punish_record.QuestionerSecondId;
				parms[8].Value = inf_punish_record.QuestionerFirstName;
				parms[9].Value = inf_punish_record.QuestionerSecondName;
				parms[10].Value = inf_punish_record.RecordsId;
				parms[11].Value = inf_punish_record.RecordsName;
				parms[12].Value = inf_punish_record.TargetName;
				parms[13].Value = inf_punish_record.TargetAddress;
				parms[14].Value = inf_punish_record.TargetPaperType;
				parms[15].Value = inf_punish_record.TargetPaperNum;
				parms[16].Value = inf_punish_record.TargetGender;
				parms[17].Value = inf_punish_record.BirthDate;
				parms[18].Value = inf_punish_record.TargetUnit;
				parms[19].Value = inf_punish_record.TargetDuty;
				parms[20].Value = inf_punish_record.TargetPhone;
				parms[21].Value = inf_punish_record.TargetMobile;
				parms[22].Value = inf_punish_record.TargetZipCode;
				parms[23].Value = inf_punish_record.TargetEmail;
				parms[24].Value = inf_punish_record.CaseRelationship;
				parms[25].Value = inf_punish_record.RecordInfo;
				parms[26].Value = inf_punish_record.RowStatus;
				parms[27].Value = inf_punish_record.CreatorId;
				parms[28].Value = inf_punish_record.CreateBy;
				parms[29].Value = inf_punish_record.CreateOn;
				parms[30].Value = inf_punish_record.UpdateId;
				parms[31].Value = inf_punish_record.UpdateBy;
				parms[32].Value = inf_punish_record.UpdateOn;
                parms[33].Value = inf_punish_record.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishRecordEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_RECORD_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_RECORD_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_CaseInfoNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_ItemName, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_INF_PUNISH_RECORD_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_RECORD_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_RECORD_Address, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_RECORD_QuestionerFirstId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_QuestionerSecondId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_QuestionerFirstName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_QuestionerSecondName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_RecordsId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_RecordsName, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetGender, SqlDbType.VarChar, 1),
					new SqlParameter(Parm_INF_PUNISH_RECORD_BirthDate, SqlDbType.VarChar, 15),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetUnit, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetDuty, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetPhone, SqlDbType.VarChar, 13),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetMobile, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetZipCode, SqlDbType.VarChar, 6),
					new SqlParameter(Parm_INF_PUNISH_RECORD_TargetEmail, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_CaseRelationship, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_RecordInfo, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_INF_PUNISH_RECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_RECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_RECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECORD_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_RECORD_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_RECORD_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                       
