//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComPrintTemplateEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 15:06:05
//  功能描述：ComPrintTemplate表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 文书打印模板
    /// </summary>
    [Serializable]
    public class ComPrintTemplateEntity : ModelImp.BaseModel<ComPrintTemplateEntity>
    {
       	public ComPrintTemplateEntity()
		{
			TB_Name = TB_ComPrintTemplate;
			Parm_Id = Parm_ComPrintTemplate_Id;
			Parm_Version = Parm_ComPrintTemplate_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_ComPrintTemplate_Insert;
			Sql_Update = Sql_ComPrintTemplate_Update;
			Sql_Delete = Sql_ComPrintTemplate_Delete;
		}
       	#region Const of table ComPrintTemplate
		/// <summary>
		/// Table ComPrintTemplate
		/// </summary>
		public const string TB_ComPrintTemplate = "ComPrintTemplate";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_ComPrintTemplate_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_ComPrintTemplate_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_ComPrintTemplate_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_ComPrintTemplate_Id = "Id";
		/// <summary>
		/// Parm ProceduceName
		/// </summary>
		public const string Parm_ComPrintTemplate_ProceduceName = "ProceduceName";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_ComPrintTemplate_RowStatus = "RowStatus";
		/// <summary>
		/// Parm TemplateAddr
		/// </summary>
		public const string Parm_ComPrintTemplate_TemplateAddr = "TemplateAddr";
		/// <summary>
		/// Parm TemplateName
		/// </summary>
		public const string Parm_ComPrintTemplate_TemplateName = "TemplateName";
		/// <summary>
		/// Parm TemplateType
		/// </summary>
		public const string Parm_ComPrintTemplate_TemplateType = "TemplateType";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_ComPrintTemplate_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_ComPrintTemplate_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_ComPrintTemplate_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_ComPrintTemplate_Version = "Version";
		/// <summary>
		/// Insert Query Of ComPrintTemplate
		/// </summary>
		public const string Sql_ComPrintTemplate_Insert = "insert into ComPrintTemplate(CreateBy,CreateOn,CreatorId,ProceduceName,RowStatus,TemplateAddr,TemplateName,TemplateType,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@ProceduceName,@RowStatus,@TemplateAddr,@TemplateName,@TemplateType,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
		/// <summary>
		/// Update Query Of ComPrintTemplate
		/// </summary>
		public const string Sql_ComPrintTemplate_Update = "update ComPrintTemplate set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ProceduceName=@ProceduceName,RowStatus=@RowStatus,TemplateAddr=@TemplateAddr,TemplateName=@TemplateName,TemplateType=@TemplateType,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_ComPrintTemplate_Delete = "update ComPrintTemplate set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _templateName = string.Empty;
		/// <summary>
		/// 模板名称
		/// </summary>
		public string TemplateName
		{
			get{return _templateName ?? string.Empty;}
			set{_templateName = value;}
		}
		private int _templateType;
		/// <summary>
		/// 模板类型（1：word,2：fastreport）
		/// </summary>
		public int TemplateType
		{
			get{return _templateType;}
			set{_templateType = value;}
		}
		private string _templateAddr = string.Empty;
		/// <summary>
		/// 模板存储路径
		/// </summary>
		public string TemplateAddr
		{
			get{return _templateAddr ?? string.Empty;}
			set{_templateAddr = value;}
		}
		private string _proceduceName = string.Empty;
		/// <summary>
		/// 执行存储过程名称
		/// </summary>
		public string ProceduceName
		{
			get{return _proceduceName ?? string.Empty;}
			set{_proceduceName = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override ComPrintTemplateEntity SetModelValueByDataRow(DataRow dr)
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
		public override ComPrintTemplateEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComPrintTemplateEntity();
          			if (fields.Contains(Parm_ComPrintTemplate_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComPrintTemplate_Id].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_TemplateName) || fields.Contains("*"))
				tmp.TemplateName = dr[Parm_ComPrintTemplate_TemplateName].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_TemplateType) || fields.Contains("*"))
				tmp.TemplateType = int.Parse(dr[Parm_ComPrintTemplate_TemplateType].ToString());
			if (fields.Contains(Parm_ComPrintTemplate_TemplateAddr) || fields.Contains("*"))
				tmp.TemplateAddr = dr[Parm_ComPrintTemplate_TemplateAddr].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_ProceduceName) || fields.Contains("*"))
				tmp.ProceduceName = dr[Parm_ComPrintTemplate_ProceduceName].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComPrintTemplate_RowStatus].ToString());
			if (fields.Contains(Parm_ComPrintTemplate_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComPrintTemplate_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComPrintTemplate_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComPrintTemplate_CreatorId].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComPrintTemplate_CreateBy].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComPrintTemplate_CreateOn].ToString());
			if (fields.Contains(Parm_ComPrintTemplate_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComPrintTemplate_UpdateId].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComPrintTemplate_UpdateBy].ToString();
			if (fields.Contains(Parm_ComPrintTemplate_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComPrintTemplate_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comprinttemplate">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComPrintTemplateEntity comprinttemplate, SqlParameter[] parms)
		{
            				parms[0].Value = comprinttemplate.TemplateName;
				parms[1].Value = comprinttemplate.TemplateType;
				parms[2].Value = comprinttemplate.TemplateAddr;
				parms[3].Value = comprinttemplate.ProceduceName;
				parms[4].Value = comprinttemplate.RowStatus;
				parms[5].Value = comprinttemplate.CreatorId;
				parms[6].Value = comprinttemplate.CreateBy;
				parms[7].Value = comprinttemplate.CreateOn;
				parms[8].Value = comprinttemplate.UpdateId;
				parms[9].Value = comprinttemplate.UpdateBy;
				parms[10].Value = comprinttemplate.UpdateOn;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComPrintTemplateEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComPrintTemplate_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComPrintTemplate_Version, model.Version);
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComPrintTemplate_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComPrintTemplate_TemplateName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComPrintTemplate_TemplateType, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComPrintTemplate_TemplateAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComPrintTemplate_ProceduceName, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_ComPrintTemplate_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComPrintTemplate_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComPrintTemplate_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComPrintTemplate_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComPrintTemplate_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComPrintTemplate_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComPrintTemplate_UpdateOn, SqlDbType.DateTime, 23)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComPrintTemplate_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
