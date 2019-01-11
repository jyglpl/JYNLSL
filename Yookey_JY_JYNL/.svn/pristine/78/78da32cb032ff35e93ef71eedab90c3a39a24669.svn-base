//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_RECEIPTEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/27 11:10:38
//  功能描述：INF_PUNISH_RECEIPT表实体
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
    /// 送达回执
    /// </summary>
    [Serializable]
    public class InfPunishReceiptEntity : ModelImp.BaseModel<InfPunishReceiptEntity>
    {
       	public InfPunishReceiptEntity()
		{
			TB_Name = TB_INF_PUNISH_RECEIPT;
			Parm_Id = Parm_INF_PUNISH_RECEIPT_Id;
			Parm_Version = Parm_INF_PUNISH_RECEIPT_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_RECEIPT_Insert;
			Sql_Update = Sql_INF_PUNISH_RECEIPT_Update;
			Sql_Delete = Sql_INF_PUNISH_RECEIPT_Delete;
		}
       	#region Const of table INF_PUNISH_RECEIPT
		/// <summary>
		/// Table INF_PUNISH_RECEIPT
		/// </summary>
		public const string TB_INF_PUNISH_RECEIPT = "INF_PUNISH_RECEIPT";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_Id = "Id";
		/// <summary>
		/// Parm ReceiptPersonIdFirst
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdFirst = "ReceiptPersonIdFirst";
		/// <summary>
		/// Parm ReceiptPersonIdSecond
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdSecond = "ReceiptPersonIdSecond";
		/// <summary>
		/// Parm ReceiptPersonNameFirst
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameFirst = "ReceiptPersonNameFirst";
		/// <summary>
		/// Parm ReceiptPersonNameSecond
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameSecond = "ReceiptPersonNameSecond";
		/// <summary>
		/// Parm ReceiptType
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ReceiptType = "ReceiptType";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_RowStatus = "RowStatus";
		/// <summary>
		/// Parm ServiceType
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_ServiceType = "ServiceType";
		/// <summary>
		/// Parm SigninPerson
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_SigninPerson = "SigninPerson";
		/// <summary>
		/// Parm SinginDate
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_SinginDate = "SinginDate";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_RECEIPT_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_RECEIPT
		/// </summary>
		public const string Sql_INF_PUNISH_RECEIPT_Insert = "INSERT INTO INF_PUNISH_RECEIPT(CaseInfoId,CreateBy,CreateOn,CreatorId,ReceiptPersonIdFirst,ReceiptPersonIdSecond,ReceiptPersonNameFirst,ReceiptPersonNameSecond,ReceiptType,RowStatus,ServiceType,SigninPerson,SinginDate,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@ReceiptPersonIdFirst,@ReceiptPersonIdSecond,@ReceiptPersonNameFirst,@ReceiptPersonNameSecond,@ReceiptType,@RowStatus,@ServiceType,@SigninPerson,@SinginDate,@UpdateBy,@UpdateId,@UpdateOn,@Id);SELECT @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_RECEIPT
		/// </summary>
		public const string Sql_INF_PUNISH_RECEIPT_Update = "UPDATE INF_PUNISH_RECEIPT SET CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ReceiptPersonIdFirst=@ReceiptPersonIdFirst,ReceiptPersonIdSecond=@ReceiptPersonIdSecond,ReceiptPersonNameFirst=@ReceiptPersonNameFirst,ReceiptPersonNameSecond=@ReceiptPersonNameSecond,ReceiptType=@ReceiptType,RowStatus=@RowStatus,ServiceType=@ServiceType,SigninPerson=@SigninPerson,SinginDate=@SinginDate,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn WHERE Id=@Id;SELECT @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_RECEIPT_Delete = "UPDATE INF_PUNISH_RECEIPT SET RowStatus=0 where Id=@Id;SELECT @@rowcount;";
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
		private string _receiptType = string.Empty;
		/// <summary>
		/// nvarchar 	送达方式
		/// </summary>
		public string ReceiptType
		{
			get{return _receiptType ?? string.Empty;}
			set{_receiptType = value;}
		}
		private string _receiptPersonIdFirst = string.Empty;
		/// <summary>
		/// nvarchar 	送达人员一（编号）
		/// </summary>
		public string ReceiptPersonIdFirst
		{
			get{return _receiptPersonIdFirst ?? string.Empty;}
			set{_receiptPersonIdFirst = value;}
		}
		private string _receiptPersonNameFirst = string.Empty;
		/// <summary>
		/// nvarchar 	送达人员一（姓名）
		/// </summary>
		public string ReceiptPersonNameFirst
		{
			get{return _receiptPersonNameFirst ?? string.Empty;}
			set{_receiptPersonNameFirst = value;}
		}
		private string _receiptPersonIdSecond = string.Empty;
		/// <summary>
		/// nvarchar 	送达人员二（编号）
		/// </summary>
		public string ReceiptPersonIdSecond
		{
			get{return _receiptPersonIdSecond ?? string.Empty;}
			set{_receiptPersonIdSecond = value;}
		}
		private string _receiptPersonNameSecond = string.Empty;
		/// <summary>
		/// nvarchar 	送达人员二（姓名）
		/// </summary>
		public string ReceiptPersonNameSecond
		{
			get{return _receiptPersonNameSecond ?? string.Empty;}
			set{_receiptPersonNameSecond = value;}
		}
		private string _signinPerson = string.Empty;
		/// <summary>
		/// nvarchar 	签收人
		/// </summary>
		public string SigninPerson
		{
			get{return _signinPerson ?? string.Empty;}
			set{_signinPerson = value;}
		}
		private DateTime _singinDate = MinDate;
		/// <summary>
		/// 签收日期
		/// </summary>
		public DateTime SinginDate
		{
			get{return _singinDate;}
			set{_singinDate = value;}
		}
		private int _serviceType;
		/// <summary>
		/// int 	所属环节（1：告知，2：处罚决定）
		/// </summary>
		public int ServiceType
		{
			get{return _serviceType;}
			set{_serviceType = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishReceiptEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishReceiptEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishReceiptEntity();
          			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_RECEIPT_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_RECEIPT_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ReceiptType) || fields.Contains("*"))
				tmp.ReceiptType = dr[Parm_INF_PUNISH_RECEIPT_ReceiptType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdFirst) || fields.Contains("*"))
				tmp.ReceiptPersonIdFirst = dr[Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameFirst) || fields.Contains("*"))
				tmp.ReceiptPersonNameFirst = dr[Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameFirst].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdSecond) || fields.Contains("*"))
				tmp.ReceiptPersonIdSecond = dr[Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameSecond) || fields.Contains("*"))
				tmp.ReceiptPersonNameSecond = dr[Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameSecond].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_SigninPerson) || fields.Contains("*"))
				tmp.SigninPerson = dr[Parm_INF_PUNISH_RECEIPT_SigninPerson].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_SinginDate) || fields.Contains("*"))
				tmp.SinginDate = DateTime.Parse(dr[Parm_INF_PUNISH_RECEIPT_SinginDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_ServiceType) || fields.Contains("*"))
				tmp.ServiceType = int.Parse(dr[Parm_INF_PUNISH_RECEIPT_ServiceType].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_RECEIPT_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_RECEIPT_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_RECEIPT_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_RECEIPT_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_RECEIPT_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_RECEIPT_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_RECEIPT_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_RECEIPT_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_RECEIPT_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_receipt">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishReceiptEntity inf_punish_receipt, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_receipt.CaseInfoId;
				parms[1].Value = inf_punish_receipt.ReceiptType;
				parms[2].Value = inf_punish_receipt.ReceiptPersonIdFirst;
				parms[3].Value = inf_punish_receipt.ReceiptPersonNameFirst;
				parms[4].Value = inf_punish_receipt.ReceiptPersonIdSecond;
				parms[5].Value = inf_punish_receipt.ReceiptPersonNameSecond;
				parms[6].Value = inf_punish_receipt.SigninPerson;
				parms[7].Value = inf_punish_receipt.SinginDate;
				parms[8].Value = inf_punish_receipt.ServiceType;
				parms[9].Value = inf_punish_receipt.RowStatus;
				parms[10].Value = inf_punish_receipt.CreatorId;
				parms[11].Value = inf_punish_receipt.CreateBy;
				parms[12].Value = inf_punish_receipt.CreateOn;
				parms[13].Value = inf_punish_receipt.UpdateId;
				parms[14].Value = inf_punish_receipt.UpdateBy;
				parms[15].Value = inf_punish_receipt.UpdateOn;
                parms[16].Value = inf_punish_receipt.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishReceiptEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_RECEIPT_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_RECEIPT_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ReceiptType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameFirst, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ReceiptPersonIdSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ReceiptPersonNameSecond, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_SigninPerson, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_SinginDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_ServiceType, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_RECEIPT_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_RECEIPT_Id, SqlDbType.NVarChar, 50)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_RECEIPT_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
