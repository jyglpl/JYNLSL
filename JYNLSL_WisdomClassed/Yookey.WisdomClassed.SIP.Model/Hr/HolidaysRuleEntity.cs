//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="HolidaysRuleEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-31 01:37:01
//  功能描述：HolidaysRule表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Hr
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class HolidaysRuleEntity : ModelImp.BaseModel<HolidaysRuleEntity>
    {
       	public HolidaysRuleEntity()
		{
			TB_Name = TB_HolidaysRule;
			Parm_Id = Parm_HolidaysRule_Id;
			Parm_Version = Parm_HolidaysRule_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_HolidaysRule_Insert;
			Sql_Update = Sql_HolidaysRule_Update;
			Sql_Delete = Sql_HolidaysRule_Delete;
		}
       	#region Const of table HolidaysRule
		/// <summary>
		/// Table HolidaysRule
		/// </summary>
		public const string TB_HolidaysRule = "HolidaysRule";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_HolidaysRule_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_HolidaysRule_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_HolidaysRule_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DayType
		/// </summary>
		public const string Parm_HolidaysRule_DayType = "DayType";
		/// <summary>
		/// Parm DayValue
		/// </summary>
		public const string Parm_HolidaysRule_DayValue = "DayValue";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_HolidaysRule_Id = "Id";
		/// <summary>
		/// Parm Remark
		/// </summary>
		public const string Parm_HolidaysRule_Remark = "Remark";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_HolidaysRule_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_HolidaysRule_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_HolidaysRule_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_HolidaysRule_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_HolidaysRule_Version = "Version";
		/// <summary>
		/// Insert Query Of HolidaysRule
		/// </summary>
		public const string Sql_HolidaysRule_Insert = "insert into HolidaysRule(CreateBy,CreateOn,CreatorId,DayType,DayValue,Remark,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@DayType,@DayValue,@Remark,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of HolidaysRule
		/// </summary>
		public const string Sql_HolidaysRule_Update = "update HolidaysRule set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DayType=@DayType,DayValue=@DayValue,Remark=@Remark,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_HolidaysRule_Delete = "update HolidaysRule set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private DateTime _dayValue = MinDate;
		/// <summary>
		/// 日期的值
		/// </summary>
		public DateTime DayValue
		{
			get{return _dayValue;}
			set{_dayValue = value;}
		}
		private string _dayType = string.Empty;
		/// <summary>
		/// 节假日类型
		/// </summary>
		public string DayType
		{
			get{return _dayType ?? string.Empty;}
			set{_dayType = value;}
		}
		private string _remark = string.Empty;
		/// <summary>
		/// 
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
		public override HolidaysRuleEntity SetModelValueByDataRow(DataRow dr)
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
		public override HolidaysRuleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new HolidaysRuleEntity();
          			if (fields.Contains(Parm_HolidaysRule_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_HolidaysRule_Id].ToString();
			if (fields.Contains(Parm_HolidaysRule_DayValue) || fields.Contains("*"))
				tmp.DayValue = DateTime.Parse(dr[Parm_HolidaysRule_DayValue].ToString());
			if (fields.Contains(Parm_HolidaysRule_DayType) || fields.Contains("*"))
				tmp.DayType = dr[Parm_HolidaysRule_DayType].ToString();
			if (fields.Contains(Parm_HolidaysRule_Remark) || fields.Contains("*"))
				tmp.Remark = dr[Parm_HolidaysRule_Remark].ToString();
			if (fields.Contains(Parm_HolidaysRule_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_HolidaysRule_RowStatus].ToString());
			if (fields.Contains(Parm_HolidaysRule_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_HolidaysRule_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_HolidaysRule_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_HolidaysRule_CreatorId].ToString();
			if (fields.Contains(Parm_HolidaysRule_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_HolidaysRule_CreateBy].ToString();
			if (fields.Contains(Parm_HolidaysRule_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_HolidaysRule_CreateOn].ToString());
			if (fields.Contains(Parm_HolidaysRule_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_HolidaysRule_UpdateId].ToString();
			if (fields.Contains(Parm_HolidaysRule_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_HolidaysRule_UpdateBy].ToString();
			if (fields.Contains(Parm_HolidaysRule_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_HolidaysRule_UpdateOn].ToString());
         
	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="holidaysrule">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(HolidaysRuleEntity holidaysrule, SqlParameter[] parms)
		{
            				parms[0].Value = holidaysrule.DayValue;
				parms[1].Value = holidaysrule.DayType;
				parms[2].Value = holidaysrule.Remark;
				parms[3].Value = holidaysrule.RowStatus;
				parms[4].Value = holidaysrule.CreatorId;
				parms[5].Value = holidaysrule.CreateBy;
				parms[6].Value = holidaysrule.CreateOn;
				parms[7].Value = holidaysrule.UpdateId;
				parms[8].Value = holidaysrule.UpdateBy;
				parms[9].Value = holidaysrule.UpdateOn;
                parms[15].Value = holidaysrule.Id;
             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(HolidaysRuleEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_HolidaysRule_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_HolidaysRule_DayValue, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_HolidaysRule_DayType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_HolidaysRule_Remark, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_HolidaysRule_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_HolidaysRule_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_HolidaysRule_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_HolidaysRule_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_HolidaysRule_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_HolidaysRule_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_HolidaysRule_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_HolidaysRule_Id, SqlDbType.NVarChar, 50)
				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_HolidaysRule_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
