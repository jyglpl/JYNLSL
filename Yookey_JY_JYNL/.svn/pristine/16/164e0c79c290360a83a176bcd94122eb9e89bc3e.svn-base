//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_TARGETEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:20
//  功能描述：INF_PUNISH_TARGET表实体
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
    /// 其它当事人信息
    /// </summary>
    [Serializable]
    public class InfPunishTargetEntity : ModelImp.BaseModel<InfPunishTargetEntity>
    {
       	public InfPunishTargetEntity()
		{
			TB_Name = TB_INF_PUNISH_TARGET;
			Parm_Id = Parm_INF_PUNISH_TARGET_Id;
			Parm_Version = Parm_INF_PUNISH_TARGET_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_TARGET_Insert;
			Sql_Update = Sql_INF_PUNISH_TARGET_Update;
			Sql_Delete = Sql_INF_PUNISH_TARGET_Delete;
		}
       	#region Const of table INF_PUNISH_TARGET
		/// <summary>
		/// Table INF_PUNISH_TARGET
		/// </summary>
		public const string TB_INF_PUNISH_TARGET = "INF_PUNISH_TARGET";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_RowStatus = "RowStatus";
		/// <summary>
		/// Parm TargetAddress
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetAddress = "TargetAddress";
		/// <summary>
		/// Parm TargetAge
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetAge = "TargetAge";
		/// <summary>
		/// Parm TargetDuty
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetDuty = "TargetDuty";
		/// <summary>
		/// Parm TargetEmail
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetEmail = "TargetEmail";
		/// <summary>
		/// Parm TargetGender
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetGender = "TargetGender";
		/// <summary>
		/// Parm TargetMobile
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetMobile = "TargetMobile";
		/// <summary>
		/// Parm TargetName
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetName = "TargetName";
		/// <summary>
		/// Parm TargetPaperNum
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetPaperNum = "TargetPaperNum";
		/// <summary>
		/// Parm TargetPaperType
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetPaperType = "TargetPaperType";
		/// <summary>
		/// Parm TargetPhone
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetPhone = "TargetPhone";
		/// <summary>
		/// Parm TargetType
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetType = "TargetType";
		/// <summary>
		/// Parm TargetUnit
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetUnit = "TargetUnit";
		/// <summary>
		/// Parm TargetZipCode
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_TargetZipCode = "TargetZipCode";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_TARGET_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_TARGET
		/// </summary>
		public const string Sql_INF_PUNISH_TARGET_Insert = "insert into INF_PUNISH_TARGET(CaseInfoId,CreateBy,CreateOn,CreatorId,RowStatus,TargetAddress,TargetAge,TargetDuty,TargetEmail,TargetGender,TargetMobile,TargetName,TargetPaperNum,TargetPaperType,TargetPhone,TargetType,TargetUnit,TargetZipCode,UpdateBy,UpdateId,UpdateOn) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@RowStatus,@TargetAddress,@TargetAge,@TargetDuty,@TargetEmail,@TargetGender,@TargetMobile,@TargetName,@TargetPaperNum,@TargetPaperType,@TargetPhone,@TargetType,@TargetUnit,@TargetZipCode,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_TARGET
		/// </summary>
		public const string Sql_INF_PUNISH_TARGET_Update = "update INF_PUNISH_TARGET set CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RowStatus=@RowStatus,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetDuty=@TargetDuty,TargetEmail=@TargetEmail,TargetGender=@TargetGender,TargetMobile=@TargetMobile,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,TargetPhone=@TargetPhone,TargetType=@TargetType,TargetUnit=@TargetUnit,TargetZipCode=@TargetZipCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_TARGET_Delete = "update INF_PUNISH_TARGET set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
		private string _targetType = string.Empty;
		/// <summary>
		/// nvarchar 	当事人类型
		/// </summary>
		public string TargetType
		{
			get{return _targetType ?? string.Empty;}
			set{_targetType = value;}
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
		private string _targetAge = string.Empty;
		/// <summary>
		/// int 	当事人年龄
		/// </summary>
		public string TargetAge
		{
			get{return _targetAge ?? string.Empty;}
			set{_targetAge = value;}
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
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishTargetEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishTargetEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishTargetEntity();
          			if (fields.Contains(Parm_INF_PUNISH_TARGET_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_TARGET_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_TARGET_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetType) || fields.Contains("*"))
				tmp.TargetType = dr[Parm_INF_PUNISH_TARGET_TargetType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetName) || fields.Contains("*"))
				tmp.TargetName = dr[Parm_INF_PUNISH_TARGET_TargetName].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetAddress) || fields.Contains("*"))
				tmp.TargetAddress = dr[Parm_INF_PUNISH_TARGET_TargetAddress].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetPaperType) || fields.Contains("*"))
				tmp.TargetPaperType = dr[Parm_INF_PUNISH_TARGET_TargetPaperType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetPaperNum) || fields.Contains("*"))
				tmp.TargetPaperNum = dr[Parm_INF_PUNISH_TARGET_TargetPaperNum].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetGender) || fields.Contains("*"))
				tmp.TargetGender = dr[Parm_INF_PUNISH_TARGET_TargetGender].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetAge) || fields.Contains("*"))
				tmp.TargetAge = dr[Parm_INF_PUNISH_TARGET_TargetAge].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetUnit) || fields.Contains("*"))
				tmp.TargetUnit = dr[Parm_INF_PUNISH_TARGET_TargetUnit].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetDuty) || fields.Contains("*"))
				tmp.TargetDuty = dr[Parm_INF_PUNISH_TARGET_TargetDuty].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetPhone) || fields.Contains("*"))
				tmp.TargetPhone = dr[Parm_INF_PUNISH_TARGET_TargetPhone].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetMobile) || fields.Contains("*"))
				tmp.TargetMobile = dr[Parm_INF_PUNISH_TARGET_TargetMobile].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetZipCode) || fields.Contains("*"))
				tmp.TargetZipCode = dr[Parm_INF_PUNISH_TARGET_TargetZipCode].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_TargetEmail) || fields.Contains("*"))
				tmp.TargetEmail = dr[Parm_INF_PUNISH_TARGET_TargetEmail].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_TARGET_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_TARGET_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_TARGET_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_TARGET_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_TARGET_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_TARGET_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_TARGET_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_TARGET_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_TARGET_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_TARGET_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_TARGET_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_TARGET_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_target">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishTargetEntity inf_punish_target, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_target.CaseInfoId;
				parms[1].Value = inf_punish_target.TargetType;
				parms[2].Value = inf_punish_target.TargetName;
				parms[3].Value = inf_punish_target.TargetAddress;
				parms[4].Value = inf_punish_target.TargetPaperType;
				parms[5].Value = inf_punish_target.TargetPaperNum;
				parms[6].Value = inf_punish_target.TargetGender;
				parms[7].Value = inf_punish_target.TargetAge;
				parms[8].Value = inf_punish_target.TargetUnit;
				parms[9].Value = inf_punish_target.TargetDuty;
				parms[10].Value = inf_punish_target.TargetPhone;
				parms[11].Value = inf_punish_target.TargetMobile;
				parms[12].Value = inf_punish_target.TargetZipCode;
				parms[13].Value = inf_punish_target.TargetEmail;
				parms[14].Value = inf_punish_target.RowStatus;
				parms[15].Value = inf_punish_target.CreatorId;
				parms[16].Value = inf_punish_target.CreateBy;
				parms[17].Value = inf_punish_target.CreateOn;
				parms[18].Value = inf_punish_target.UpdateId;
				parms[19].Value = inf_punish_target.UpdateBy;
				parms[20].Value = inf_punish_target.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishTargetEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_INF_PUNISH_TARGET_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_INF_PUNISH_TARGET_Version, model.Version);
            return parms;
        }

        	/// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] GetParms()
        {
	     	try
	     	{
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_TARGET_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_TARGET_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetGender, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetAge, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetUnit, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetDuty, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetPhone, SqlDbType.VarChar, 13),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetMobile, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetZipCode, SqlDbType.VarChar, 6),
					new SqlParameter(Parm_INF_PUNISH_TARGET_TargetEmail, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_TARGET_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_TARGET_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_TARGET_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_TARGET_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
