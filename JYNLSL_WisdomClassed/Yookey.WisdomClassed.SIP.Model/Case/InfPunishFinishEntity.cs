//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_FINISHEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/27 15:38:18
//  功能描述：INF_PUNISH_FINISH表实体
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
    /// 结案
    /// </summary>
    [Serializable]
    public class InfPunishFinishEntity : ModelImp.BaseModel<InfPunishFinishEntity>
    {
       	public InfPunishFinishEntity()
		{
			TB_Name = TB_INF_PUNISH_FINISH;
			Parm_Id = Parm_INF_PUNISH_FINISH_Id;
			Parm_Version = Parm_INF_PUNISH_FINISH_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_INF_PUNISH_FINISH_Insert;
			Sql_Update = Sql_INF_PUNISH_FINISH_Update;
			Sql_Delete = Sql_INF_PUNISH_FINISH_Delete;
		}
       	#region Const of table INF_PUNISH_FINISH
		/// <summary>
		/// Table INF_PUNISH_FINISH
		/// </summary>
		public const string TB_INF_PUNISH_FINISH = "INF_PUNISH_FINISH";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CaseInfoId
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_CaseInfoId = "CaseInfoId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_CreatorId = "CreatorId";
		/// <summary>
		/// Parm ExecuteDesc
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_ExecuteDesc = "ExecuteDesc";
		/// <summary>
		/// Parm FinishDate
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_FinishDate = "FinishDate";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_Id = "Id";
		/// <summary>
		/// Parm IsLawsuit
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_IsLawsuit = "IsLawsuit";
		/// <summary>
		/// Parm LawsuitDate
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_LawsuitDate = "LawsuitDate";
		/// <summary>
		/// Parm LawsuitDesc
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_LawsuitDesc = "LawsuitDesc";
		/// <summary>
		/// Parm PaymentNum
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_PaymentNum = "PaymentNum";
		/// <summary>
		/// Parm PaymentType
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_PaymentType = "PaymentType";
		/// <summary>
		/// Parm PunishContent
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_PunishContent = "PunishContent";
		/// <summary>
		/// Parm ReformDesc
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_ReformDesc = "ReformDesc";
		/// <summary>
		/// Parm Remark
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_Remark = "Remark";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_INF_PUNISH_FINISH_Version = "Version";
		/// <summary>
		/// Insert Query Of INF_PUNISH_FINISH
		/// </summary>
		public const string Sql_INF_PUNISH_FINISH_Insert = "insert into INF_PUNISH_FINISH(CaseInfoId,CreateBy,CreateOn,CreatorId,ExecuteDesc,FinishDate,IsLawsuit,LawsuitDate,LawsuitDesc,PaymentNum,PaymentType,PunishContent,ReformDesc,Remark,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@ExecuteDesc,@FinishDate,@IsLawsuit,@LawsuitDate,@LawsuitDesc,@PaymentNum,@PaymentType,@PunishContent,@ReformDesc,@Remark,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of INF_PUNISH_FINISH
		/// </summary>
		public const string Sql_INF_PUNISH_FINISH_Update = "update INF_PUNISH_FINISH set CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ExecuteDesc=@ExecuteDesc,FinishDate=@FinishDate,IsLawsuit=@IsLawsuit,LawsuitDate=@LawsuitDate,LawsuitDesc=@LawsuitDesc,PaymentNum=@PaymentNum,PaymentType=@PaymentType,PunishContent=@PunishContent,ReformDesc=@ReformDesc,Remark=@Remark,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_INF_PUNISH_FINISH_Delete = "update INF_PUNISH_FINISH set RowStatus=0 where Id=@Id;select @@rowcount;";
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
		private DateTime _finishDate = MinDate;
		/// <summary>
		/// datetime 	结案日期
		/// </summary>
		public DateTime FinishDate
		{
			get{return _finishDate;}
			set{_finishDate = value;}
		}
		private string _punishContent = string.Empty;
		/// <summary>
		/// nvarchar 	处理情况
		/// </summary>
		public string PunishContent
		{
			get{return _punishContent ?? string.Empty;}
			set{_punishContent = value;}
		}
		private string _executeDesc = string.Empty;
		/// <summary>
		/// nvarchar 	执行情况
		/// </summary>
		public string ExecuteDesc
		{
			get{return _executeDesc ?? string.Empty;}
			set{_executeDesc = value;}
		}
		private string _reformDesc = string.Empty;
		/// <summary>
		/// 整改情况
		/// </summary>
		public string ReformDesc
		{
			get{return _reformDesc ?? string.Empty;}
			set{_reformDesc = value;}
		}
		private string _paymentType = string.Empty;
		/// <summary>
		/// nvarchar 	罚没款交纳方式
		/// </summary>
		public string PaymentType
		{
			get{return _paymentType ?? string.Empty;}
			set{_paymentType = value;}
		}
		private string _paymentNum = string.Empty;
		/// <summary>
		/// 罚没款票据号
		/// </summary>
		public string PaymentNum
		{
			get{return _paymentNum ?? string.Empty;}
			set{_paymentNum = value;}
		}
		private int _isLawsuit;
		/// <summary>
		/// int 	是否诉讼（0：无、1：诉讼、2：复议）
		/// </summary>
		public int IsLawsuit
		{
			get{return _isLawsuit;}
			set{_isLawsuit = value;}
		}
		private string _lawsuitDesc = string.Empty;
		/// <summary>
		/// nvarchar 	诉讼情况说明
		/// </summary>
		public string LawsuitDesc
		{
			get{return _lawsuitDesc ?? string.Empty;}
			set{_lawsuitDesc = value;}
		}
		private DateTime _lawsuitDate = MinDate;
		/// <summary>
		/// datetime 	诉讼时间
		/// </summary>
		public DateTime LawsuitDate
		{
			get{return _lawsuitDate;}
			set{_lawsuitDate = value;}
		}
		private string _remark = string.Empty;
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			get{return _remark ?? string.Empty;}
			set{_remark = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override InfPunishFinishEntity SetModelValueByDataRow(DataRow dr)
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
		public override InfPunishFinishEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishFinishEntity();
          			if (fields.Contains(Parm_INF_PUNISH_FINISH_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_INF_PUNISH_FINISH_Id].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_CaseInfoId) || fields.Contains("*"))
				tmp.CaseInfoId = dr[Parm_INF_PUNISH_FINISH_CaseInfoId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_FinishDate) || fields.Contains("*"))
				tmp.FinishDate = DateTime.Parse(dr[Parm_INF_PUNISH_FINISH_FinishDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_FINISH_PunishContent) || fields.Contains("*"))
				tmp.PunishContent = dr[Parm_INF_PUNISH_FINISH_PunishContent].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_ExecuteDesc) || fields.Contains("*"))
				tmp.ExecuteDesc = dr[Parm_INF_PUNISH_FINISH_ExecuteDesc].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_ReformDesc) || fields.Contains("*"))
				tmp.ReformDesc = dr[Parm_INF_PUNISH_FINISH_ReformDesc].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_PaymentType) || fields.Contains("*"))
				tmp.PaymentType = dr[Parm_INF_PUNISH_FINISH_PaymentType].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_PaymentNum) || fields.Contains("*"))
				tmp.PaymentNum = dr[Parm_INF_PUNISH_FINISH_PaymentNum].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_IsLawsuit) || fields.Contains("*"))
				tmp.IsLawsuit = int.Parse(dr[Parm_INF_PUNISH_FINISH_IsLawsuit].ToString());
			if (fields.Contains(Parm_INF_PUNISH_FINISH_LawsuitDesc) || fields.Contains("*"))
				tmp.LawsuitDesc = dr[Parm_INF_PUNISH_FINISH_LawsuitDesc].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_LawsuitDate) || fields.Contains("*"))
				tmp.LawsuitDate = DateTime.Parse(dr[Parm_INF_PUNISH_FINISH_LawsuitDate].ToString());
			if (fields.Contains(Parm_INF_PUNISH_FINISH_Remark) || fields.Contains("*"))
				tmp.Remark = dr[Parm_INF_PUNISH_FINISH_Remark].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_FINISH_RowStatus].ToString());
			if (fields.Contains(Parm_INF_PUNISH_FINISH_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_INF_PUNISH_FINISH_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_INF_PUNISH_FINISH_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_INF_PUNISH_FINISH_CreatorId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_INF_PUNISH_FINISH_CreateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_FINISH_CreateOn].ToString());
			if (fields.Contains(Parm_INF_PUNISH_FINISH_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_INF_PUNISH_FINISH_UpdateId].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_INF_PUNISH_FINISH_UpdateBy].ToString();
			if (fields.Contains(Parm_INF_PUNISH_FINISH_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_FINISH_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_finish">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishFinishEntity inf_punish_finish, SqlParameter[] parms)
		{
            				parms[0].Value = inf_punish_finish.CaseInfoId;
				parms[1].Value = inf_punish_finish.FinishDate;
				parms[2].Value = inf_punish_finish.PunishContent;
				parms[3].Value = inf_punish_finish.ExecuteDesc;
				parms[4].Value = inf_punish_finish.ReformDesc;
				parms[5].Value = inf_punish_finish.PaymentType;
				parms[6].Value = inf_punish_finish.PaymentNum;
				parms[7].Value = inf_punish_finish.IsLawsuit;
				parms[8].Value = inf_punish_finish.LawsuitDesc;
				parms[9].Value = inf_punish_finish.LawsuitDate;
				parms[10].Value = inf_punish_finish.Remark;
				parms[11].Value = inf_punish_finish.RowStatus;
				parms[12].Value = inf_punish_finish.CreatorId;
				parms[13].Value = inf_punish_finish.CreateBy;
				parms[14].Value = inf_punish_finish.CreateOn;
				parms[15].Value = inf_punish_finish.UpdateId;
				parms[16].Value = inf_punish_finish.UpdateBy;
				parms[17].Value = inf_punish_finish.UpdateOn;
                parms[18].Value = inf_punish_finish.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishFinishEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_FINISH_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_INF_PUNISH_FINISH_CaseInfoId, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_FinishDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_FINISH_PunishContent, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_FINISH_ExecuteDesc, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_FINISH_ReformDesc, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_INF_PUNISH_FINISH_PaymentType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_PaymentNum, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_IsLawsuit, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_FINISH_LawsuitDesc, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_INF_PUNISH_FINISH_LawsuitDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_FINISH_Remark, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_PUNISH_FINISH_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_FINISH_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_FINISH_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_FINISH_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_FINISH_Id, SqlDbType.NVarChar, 50)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_FINISH_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
