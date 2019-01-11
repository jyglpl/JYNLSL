//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateUseEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/18 15:05:07
//  功能描述：Base_CertificateUse表实体
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
    /// 使用管理
    /// </summary>
    [Serializable]
    public class BaseCertificateUseEntity : ModelImp.BaseModel<BaseCertificateUseEntity>
    {
       	public BaseCertificateUseEntity()
		{
			TB_Name = TB_Base_CertificateUse;
			Parm_Id = Parm_Base_CertificateUse_Id;
			Parm_Version = Parm_Base_CertificateUse_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_Base_CertificateUse_Insert;
			Sql_Update = Sql_Base_CertificateUse_Update;
			Sql_Delete = Sql_Base_CertificateUse_Delete;
		}
       	#region Const of table Base_CertificateUse
		/// <summary>
		/// Table Base_CertificateUse
		/// </summary>
		public const string TB_Base_CertificateUse = "Base_CertificateUse";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_Base_CertificateUse_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_Base_CertificateUse_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_Base_CertificateUse_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_Base_CertificateUse_Id = "Id";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_Base_CertificateUse_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_Base_CertificateUse_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_Base_CertificateUse_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_Base_CertificateUse_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm UseDesc
		/// </summary>
		public const string Parm_Base_CertificateUse_UseDesc = "UseDesc";
		/// <summary>
		/// Parm UserId
		/// </summary>
		public const string Parm_Base_CertificateUse_UserId = "UserId";
		/// <summary>
		/// Parm UseType
		/// </summary>
		public const string Parm_Base_CertificateUse_UseType = "UseType";
        /// <summary>
        /// Parm UseOn
        /// </summary>
        public const string Parm_Base_CertificateUse_UseOn = "UseOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_Base_CertificateUse_Version = "Version";
		/// <summary>
		/// Insert Query Of Base_CertificateUse
		/// </summary>
		public const string Sql_Base_CertificateUse_Insert = "insert into Base_CertificateUse(CreateBy,CreateOn,CreatorId,RowStatus,UpdateBy,UpdateId,UpdateOn,UseDesc,UserId,UseType,UseOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UseDesc,@UserId,@UseType,@UseOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of Base_CertificateUse
		/// </summary>
		public const string Sql_Base_CertificateUse_Update = "update Base_CertificateUse set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UseDesc=@UseDesc,UserId=@UserId,UseType=@UseType where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_Base_CertificateUse_Delete = "update Base_CertificateUse set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _userId = string.Empty;
		/// <summary>
		/// 用户编号
		/// </summary>
		public string UserId
		{
			get{return _userId ?? string.Empty;}
			set{_userId = value;}
		}
		private string _UseType = string.Empty;
		/// <summary>
		/// 使用类型
		/// </summary>
		public string UseType
		{
			get{return _UseType ?? string.Empty;}
			set{_UseType = value;}
		}
		private string _UseDesc = string.Empty;
		/// <summary>
		/// 使用描述
		/// </summary>
		public string UseDesc
		{
			get{return _UseDesc ?? string.Empty;}
			set{_UseDesc = value;}
		}
        /// <summary>
        /// 使用日期
        /// </summary>
        /// 
        private DateTime _useOn;
        public DateTime UseOn
        {
            get { return _useOn; }
            set { _useOn = value; }
        }
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override BaseCertificateUseEntity SetModelValueByDataRow(DataRow dr)
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
		public override BaseCertificateUseEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new BaseCertificateUseEntity();
          			if (fields.Contains(Parm_Base_CertificateUse_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_Base_CertificateUse_Id].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_UserId) || fields.Contains("*"))
				tmp.UserId = dr[Parm_Base_CertificateUse_UserId].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_UseType) || fields.Contains("*"))
				tmp.UseType = dr[Parm_Base_CertificateUse_UseType].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_UseDesc) || fields.Contains("*"))
				tmp.UseDesc = dr[Parm_Base_CertificateUse_UseDesc].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_Base_CertificateUse_RowStatus].ToString());
			if (fields.Contains(Parm_Base_CertificateUse_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_Base_CertificateUse_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_Base_CertificateUse_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_Base_CertificateUse_CreatorId].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_Base_CertificateUse_CreateBy].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_Base_CertificateUse_CreateOn].ToString());
			if (fields.Contains(Parm_Base_CertificateUse_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_Base_CertificateUse_UpdateId].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_Base_CertificateUse_UpdateBy].ToString();
			if (fields.Contains(Parm_Base_CertificateUse_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_Base_CertificateUse_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="base_certificateuse">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(BaseCertificateUseEntity base_certificateuse, SqlParameter[] parms)
		{
            				parms[0].Value = base_certificateuse.UserId;
				parms[1].Value = base_certificateuse.UseType;
				parms[2].Value = base_certificateuse.UseDesc;
                parms[3].Value = base_certificateuse.UseOn;
				parms[4].Value = base_certificateuse.RowStatus;
				parms[5].Value = base_certificateuse.CreatorId;
				parms[6].Value = base_certificateuse.CreateBy;
				parms[7].Value = base_certificateuse.CreateOn;
				parms[8].Value = base_certificateuse.UpdateId;
				parms[9].Value = base_certificateuse.UpdateBy;
				parms[10].Value = base_certificateuse.UpdateOn;
                parms[11].Value = base_certificateuse.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(BaseCertificateUseEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Base_CertificateUse_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_Base_CertificateUse_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_UseType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_UseDesc, SqlDbType.NVarChar, 200),
                    new SqlParameter(Parm_Base_CertificateUse_UseOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Base_CertificateUse_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Base_CertificateUse_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Base_CertificateUse_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Base_CertificateUse_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Base_CertificateUse_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Base_CertificateUse_Insert, parms);
				}
				return parms;
	    	}
            catch (Exception e)
            {
               	throw new Exception("获取查询参数时出错！", e);
            }
        }
    }
     /// <summary>
    /// 排班报表
    /// </summary>
    public class CertificateReport
    {
        /// <summary>
        /// 执法证数
        /// </summary>
        public int  ZFCounts { set; get; }
        /// <summary>
        /// 监督证数
        /// </summary>
        public int  JDCounts { set; get; }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
