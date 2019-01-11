//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttributeValueEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:45
//  功能描述：ComAttributeValue表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.ModelImp;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 基础数据属性数据
    /// </summary>
    [Serializable]
    public class ComAttributeValueEntity : BaseModel<ComAttributeValueEntity>
    {
       	public ComAttributeValueEntity()
		{
			TB_Name = TB_ComAttributeValue;
			Parm_Id = Parm_ComAttributeValue_Id;
			Parm_Version = Parm_ComAttributeValue_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComAttributeValue_Insert;
			Sql_Update = Sql_ComAttributeValue_Update;
			Sql_Delete = Sql_ComAttributeValue_Delete;
		}
       	#region Const of table ComAttributeValue
		/// <summary>
		/// Table ComAttributeValue
		/// </summary>
		public const string TB_ComAttributeValue = "ComAttributeValue";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AttributeId
		/// </summary>
		public const string Parm_ComAttributeValue_AttributeId = "AttributeId";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComAttributeValue_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComAttributeValue_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComAttributeValue_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComAttributeValue_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComAttributeValue_RowStatus = "RowStatus";
		/// <summary>
		/// Parm RsId
		/// </summary>
		public const string Parm_ComAttributeValue_RsId = "RsId";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComAttributeValue_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComAttributeValue_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComAttributeValue_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Value
		/// </summary>
		public const string Parm_ComAttributeValue_Value = "Value";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComAttributeValue_Version = "Version";
		/// <summary>
		/// Insert Query Of ComAttributeValue
		/// </summary>
		public const string Sql_ComAttributeValue_Insert = "insert into ComAttributeValue(AttributeId,CreateBy,CreateOn,CreatorId,RowStatus,RsId,UpdateBy,UpdateId,UpdateOn,Value) values(@AttributeId,@CreateBy,@CreateOn,@CreatorId,@RowStatus,@RsId,@UpdateBy,@UpdateId,@UpdateOn,@Value);select @@identity;";
		/// <summary>
		/// Update Query Of ComAttributeValue
		/// </summary>
		public const string Sql_ComAttributeValue_Update = "update ComAttributeValue set AttributeId=@AttributeId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RowStatus=@RowStatus,RsId=@RsId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,Value=@Value where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComAttributeValue_Delete = "update ComAttributeValue set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _rsId = string.Empty;
		/// <summary>
		/// 对应ComResource主键
		/// </summary>
		public string RsId
		{
			get{return _rsId ?? string.Empty;}
			set{_rsId = value;}
		}
		private int _attributeId;
		/// <summary>
		/// 对应ComAttribute属性编号
		/// </summary>
		public int AttributeId
		{
			get{return _attributeId;}
			set{_attributeId = value;}
		}
		private string _value = string.Empty;
		/// <summary>
		/// 对应数据值
		/// </summary>
		public string Value
		{
			get{return _value ?? string.Empty;}
			set{_value = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComAttributeValueEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComAttributeValueEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComAttributeValueEntity();
          			if (fields.Contains(Parm_ComAttributeValue_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComAttributeValue_Id].ToString();
			if (fields.Contains(Parm_ComAttributeValue_RsId) || fields.Contains("*"))
				tmp.RsId = dr[Parm_ComAttributeValue_RsId].ToString();
			if (fields.Contains(Parm_ComAttributeValue_AttributeId) || fields.Contains("*"))
				tmp.AttributeId = int.Parse(dr[Parm_ComAttributeValue_AttributeId].ToString());
			if (fields.Contains(Parm_ComAttributeValue_Value) || fields.Contains("*"))
				tmp.Value = dr[Parm_ComAttributeValue_Value].ToString();
			if (fields.Contains(Parm_ComAttributeValue_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComAttributeValue_RowStatus].ToString());
			if (fields.Contains(Parm_ComAttributeValue_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComAttributeValue_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComAttributeValue_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComAttributeValue_CreatorId].ToString();
			if (fields.Contains(Parm_ComAttributeValue_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComAttributeValue_CreateBy].ToString();
			if (fields.Contains(Parm_ComAttributeValue_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComAttributeValue_CreateOn].ToString());
			if (fields.Contains(Parm_ComAttributeValue_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComAttributeValue_UpdateId].ToString();
			if (fields.Contains(Parm_ComAttributeValue_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComAttributeValue_UpdateBy].ToString();
			if (fields.Contains(Parm_ComAttributeValue_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComAttributeValue_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comattributevalue">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComAttributeValueEntity comattributevalue, SqlParameter[] parms)
		{
            				parms[0].Value = comattributevalue.RsId;
				parms[1].Value = comattributevalue.AttributeId;
				parms[2].Value = comattributevalue.Value;
				parms[3].Value = comattributevalue.RowStatus;
				parms[4].Value = comattributevalue.CreatorId;
				parms[5].Value = comattributevalue.CreateBy;
				parms[6].Value = comattributevalue.CreateOn;
				parms[7].Value = comattributevalue.UpdateId;
				parms[8].Value = comattributevalue.UpdateBy;
				parms[9].Value = comattributevalue.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComAttributeValueEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComAttributeValue_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComAttributeValue_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttributeValue_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComAttributeValue_RsId, SqlDbType.VarChar, 32),
					new SqlParameter(Parm_ComAttributeValue_AttributeId, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComAttributeValue_Value, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_ComAttributeValue_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComAttributeValue_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttributeValue_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttributeValue_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComAttributeValue_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttributeValue_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttributeValue_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttributeValue_Insert, parms);
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
