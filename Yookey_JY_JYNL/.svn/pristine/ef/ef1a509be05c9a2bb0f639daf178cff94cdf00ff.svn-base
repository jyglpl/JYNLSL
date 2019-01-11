//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_ObjectUserRelationEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:43
//  功能描述：Base_ObjectUserRelation表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    /// <summary>
    /// 用户对应关系表
    /// </summary>
    [Serializable]
    public class BaseObjectUserRelationEntity
    {
       	
       	#region Const of table Base_ObjectUserRelation
		/// <summary>
		/// Table Base_ObjectUserRelation
		/// </summary>
		public const string TB_Base_ObjectUserRelation = "Base_ObjectUserRelation";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Category
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_Category = "Category";
		/// <summary>
		/// Parm CreateDate
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_CreateDate = "CreateDate";
		/// <summary>
		/// Parm CreateUserId
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_CreateUserId = "CreateUserId";
		/// <summary>
		/// Parm CreateUserName
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_CreateUserName = "CreateUserName";
		/// <summary>
		/// Parm ObjectId
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_ObjectId = "ObjectId";
		/// <summary>
		/// Parm ObjectUserRelationId
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_ObjectUserRelationId = "ObjectUserRelationId";
		/// <summary>
		/// Parm SortCode
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_SortCode = "SortCode";
		/// <summary>
		/// Parm UserId
		/// </summary>
		public const string Parm_Base_ObjectUserRelation_UserId = "UserId";
		/// <summary>
		/// Insert Query Of Base_ObjectUserRelation
		/// </summary>
		public const string Sql_Base_ObjectUserRelation_Insert = "insert into Base_ObjectUserRelation(Category,CreateDate,CreateUserId,CreateUserName,ObjectId,SortCode,UserId) values(@Category,@CreateDate,@CreateUserId,@CreateUserName,@ObjectId,@SortCode,@UserId);select @@identity;";
		/// <summary>
		/// Update Query Of Base_ObjectUserRelation
		/// </summary>
		public const string Sql_Base_ObjectUserRelation_Update = "update Base_ObjectUserRelation set Category=@Category,CreateDate=@CreateDate,CreateUserId=@CreateUserId,CreateUserName=@CreateUserName,ObjectId=@ObjectId,SortCode=@SortCode,UserId=@UserId where ObjectUserRelationId=@ObjectUserRelationId;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_Base_ObjectUserRelation_Delete = "update Base_ObjectUserRelation set RowStatus=0 where ObjectUserRelationId=@ObjectUserRelationId;select @@rowcount;";
		#endregion

       	#region Properties
		private string _objectUserRelationId = string.Empty;
		/// <summary>
		/// 对象用户关系主键
		/// </summary>
		public string ObjectUserRelationId
		{
			get{return _objectUserRelationId ?? string.Empty;}
			set{_objectUserRelationId = value;}
		}
		private string _category = string.Empty;
		/// <summary>
		/// 对象分类:1-部门2-角色3-岗位4-群组
		/// </summary>
		public string Category
		{
			get{return _category ?? string.Empty;}
			set{_category = value;}
		}
		private string _objectId = string.Empty;
		/// <summary>
		/// 对象主键
		/// </summary>
		public string ObjectId
		{
			get{return _objectId ?? string.Empty;}
			set{_objectId = value;}
		}
		private string _userId = string.Empty;
		/// <summary>
		/// 用户主键
		/// </summary>
		public string UserId
		{
			get{return _userId ?? string.Empty;}
			set{_userId = value;}
		}
		private int _sortCode;
		/// <summary>
		/// 
		/// </summary>
		public int SortCode
		{
			get{return _sortCode;}
			set{_sortCode = value;}
		}
		private DateTime _createDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			get{return _createDate;}
			set{_createDate = value;}
		}
		private string _createUserId = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CreateUserId
		{
			get{return _createUserId ?? string.Empty;}
			set{_createUserId = value;}
		}
		private string _createUserName = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string CreateUserName
		{
			get{return _createUserName ?? string.Empty;}
			set{_createUserName = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public BaseObjectUserRelationEntity SetModelValueByDataRow(DataRow dr)
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
		public BaseObjectUserRelationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new BaseObjectUserRelationEntity();
          			if (fields.Contains(Parm_Base_ObjectUserRelation_ObjectUserRelationId) || fields.Contains("*"))
				tmp.ObjectUserRelationId = dr[Parm_Base_ObjectUserRelation_ObjectUserRelationId].ToString();
			if (fields.Contains(Parm_Base_ObjectUserRelation_Category) || fields.Contains("*"))
				tmp.Category = dr[Parm_Base_ObjectUserRelation_Category].ToString();
			if (fields.Contains(Parm_Base_ObjectUserRelation_ObjectId) || fields.Contains("*"))
				tmp.ObjectId = dr[Parm_Base_ObjectUserRelation_ObjectId].ToString();
			if (fields.Contains(Parm_Base_ObjectUserRelation_UserId) || fields.Contains("*"))
				tmp.UserId = dr[Parm_Base_ObjectUserRelation_UserId].ToString();
			if (fields.Contains(Parm_Base_ObjectUserRelation_SortCode) || fields.Contains("*"))
				tmp.SortCode = int.Parse(dr[Parm_Base_ObjectUserRelation_SortCode].ToString());
			if (fields.Contains(Parm_Base_ObjectUserRelation_CreateDate) || fields.Contains("*"))
				tmp.CreateDate = DateTime.Parse(dr[Parm_Base_ObjectUserRelation_CreateDate].ToString());
			if (fields.Contains(Parm_Base_ObjectUserRelation_CreateUserId) || fields.Contains("*"))
				tmp.CreateUserId = dr[Parm_Base_ObjectUserRelation_CreateUserId].ToString();
			if (fields.Contains(Parm_Base_ObjectUserRelation_CreateUserName) || fields.Contains("*"))
				tmp.CreateUserName = dr[Parm_Base_ObjectUserRelation_CreateUserName].ToString();

	       return tmp;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
