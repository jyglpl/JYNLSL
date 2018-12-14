//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttributeEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:44
//  功能描述：ComAttribute表实体
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
    /// 基础数据属性
    /// </summary>
    [Serializable]
    public class ComAttributeEntity : BaseModel<ComAttributeEntity>
    {
       	public ComAttributeEntity()
		{
			TB_Name = TB_ComAttribute;
			Parm_Id = Parm_ComAttribute_Id;
			Parm_Version = Parm_ComAttribute_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComAttribute_Insert;
			Sql_Update = Sql_ComAttribute_Update;
			Sql_Delete = Sql_ComAttribute_Delete;
		}
       	#region Const of table ComAttribute
		/// <summary>
		/// Table ComAttribute
		/// </summary>
		public const string TB_ComAttribute = "ComAttribute";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AttributeId
		/// </summary>
		public const string Parm_ComAttribute_AttributeId = "AttributeId";
		/// <summary>
		/// Parm AttributeName
		/// </summary>
		public const string Parm_ComAttribute_AttributeName = "AttributeName";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComAttribute_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComAttribute_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComAttribute_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DateType
		/// </summary>
		public const string Parm_ComAttribute_DateType = "DateType";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComAttribute_Id = "Id";
		/// <summary>
		/// Parm ListSql
		/// </summary>
		public const string Parm_ComAttribute_ListSql = "ListSql";
		/// <summary>
		/// Parm OrderNo
		/// </summary>
		public const string Parm_ComAttribute_OrderNo = "OrderNo";
		/// <summary>
		/// Parm RegExpression
		/// </summary>
		public const string Parm_ComAttribute_RegExpression = "RegExpression";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComAttribute_RowStatus = "RowStatus";
		/// <summary>
		/// Parm RsId
		/// </summary>
		public const string Parm_ComAttribute_RsId = "RsId";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComAttribute_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComAttribute_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComAttribute_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComAttribute_Version = "Version";
		/// <summary>
		/// Insert Query Of ComAttribute
		/// </summary>
		public const string Sql_ComAttribute_Insert = "insert into ComAttribute(AttributeId,AttributeName,CreateBy,CreateOn,CreatorId,DateType,ListSql,OrderNo,RegExpression,RowStatus,RsId,UpdateBy,UpdateId,UpdateOn) values(@AttributeId,@AttributeName,@CreateBy,@CreateOn,@CreatorId,@DateType,@ListSql,@OrderNo,@RegExpression,@RowStatus,@RsId,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of ComAttribute
		/// </summary>
		public const string Sql_ComAttribute_Update = "update ComAttribute set AttributeId=@AttributeId,AttributeName=@AttributeName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DateType=@DateType,ListSql=@ListSql,OrderNo=@OrderNo,RegExpression=@RegExpression,RowStatus=@RowStatus,RsId=@RsId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComAttribute_Delete = "update ComAttribute set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
		/// 属性编号
		/// </summary>
		public int AttributeId
		{
			get{return _attributeId;}
			set{_attributeId = value;}
		}
		private string _attributeName = string.Empty;
		/// <summary>
		/// 属性名称
		/// </summary>
		public string AttributeName
		{
			get{return _attributeName ?? string.Empty;}
			set{_attributeName = value;}
		}
		private string _dateType = string.Empty;
		/// <summary>
		/// 属性类型(string,list,password,bool,date)
		/// </summary>
		public string DateType
		{
			get{return _dateType ?? string.Empty;}
			set{_dateType = value;}
		}
		private string _regExpression = string.Empty;
		/// <summary>
		/// 描述
		/// </summary>
		public string RegExpression
		{
			get{return _regExpression ?? string.Empty;}
			set{_regExpression = value;}
		}
		private string _listSql = string.Empty;
		/// <summary>
		/// 属性类型为list时，绑定语句
		/// </summary>
		public string ListSql
		{
			get{return _listSql ?? string.Empty;}
			set{_listSql = value;}
		}
		private int _orderNo;
		/// <summary>
		/// 排序编号
		/// </summary>
		public int OrderNo
		{
			get{return _orderNo;}
			set{_orderNo = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComAttributeEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComAttributeEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComAttributeEntity();
          			if (fields.Contains(Parm_ComAttribute_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComAttribute_Id].ToString();
			if (fields.Contains(Parm_ComAttribute_RsId) || fields.Contains("*"))
				tmp.RsId = dr[Parm_ComAttribute_RsId].ToString();
			if (fields.Contains(Parm_ComAttribute_AttributeId) || fields.Contains("*"))
				tmp.AttributeId = int.Parse(dr[Parm_ComAttribute_AttributeId].ToString());
			if (fields.Contains(Parm_ComAttribute_AttributeName) || fields.Contains("*"))
				tmp.AttributeName = dr[Parm_ComAttribute_AttributeName].ToString();
			if (fields.Contains(Parm_ComAttribute_DateType) || fields.Contains("*"))
				tmp.DateType = dr[Parm_ComAttribute_DateType].ToString();
			if (fields.Contains(Parm_ComAttribute_RegExpression) || fields.Contains("*"))
				tmp.RegExpression = dr[Parm_ComAttribute_RegExpression].ToString();
			if (fields.Contains(Parm_ComAttribute_ListSql) || fields.Contains("*"))
				tmp.ListSql = dr[Parm_ComAttribute_ListSql].ToString();
			if (fields.Contains(Parm_ComAttribute_OrderNo) || fields.Contains("*"))
				tmp.OrderNo = int.Parse(dr[Parm_ComAttribute_OrderNo].ToString());
			if (fields.Contains(Parm_ComAttribute_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComAttribute_RowStatus].ToString());
			if (fields.Contains(Parm_ComAttribute_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComAttribute_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComAttribute_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComAttribute_CreatorId].ToString();
			if (fields.Contains(Parm_ComAttribute_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComAttribute_CreateBy].ToString();
			if (fields.Contains(Parm_ComAttribute_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComAttribute_CreateOn].ToString());
			if (fields.Contains(Parm_ComAttribute_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComAttribute_UpdateId].ToString();
			if (fields.Contains(Parm_ComAttribute_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComAttribute_UpdateBy].ToString();
			if (fields.Contains(Parm_ComAttribute_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComAttribute_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comattribute">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComAttributeEntity comattribute, SqlParameter[] parms)
		{
            				parms[0].Value = comattribute.RsId;
				parms[1].Value = comattribute.AttributeId;
				parms[2].Value = comattribute.AttributeName;
				parms[3].Value = comattribute.DateType;
				parms[4].Value = comattribute.RegExpression;
				parms[5].Value = comattribute.ListSql;
				parms[6].Value = comattribute.OrderNo;
				parms[7].Value = comattribute.RowStatus;
				parms[8].Value = comattribute.CreatorId;
				parms[9].Value = comattribute.CreateBy;
				parms[10].Value = comattribute.CreateOn;
				parms[11].Value = comattribute.UpdateId;
				parms[12].Value = comattribute.UpdateBy;
				parms[13].Value = comattribute.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComAttributeEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComAttribute_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComAttribute_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttribute_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComAttribute_RsId, SqlDbType.VarChar, 32),
					new SqlParameter(Parm_ComAttribute_AttributeId, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComAttribute_AttributeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttribute_DateType, SqlDbType.VarChar, 32),
					new SqlParameter(Parm_ComAttribute_RegExpression, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComAttribute_ListSql, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_ComAttribute_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComAttribute_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComAttribute_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttribute_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttribute_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComAttribute_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttribute_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComAttribute_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComAttribute_Insert, parms);
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
