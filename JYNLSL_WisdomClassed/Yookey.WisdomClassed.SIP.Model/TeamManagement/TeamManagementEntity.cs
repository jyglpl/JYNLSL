//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagement表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TeamManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TeamManagementEntity : ModelImp.BaseModel<TeamManagementEntity>
    {
       	public TeamManagementEntity()
		{
			TB_Name = TB_TeamManagement;
			Parm_Id = Parm_TeamManagement_Id;
			Parm_Version = Parm_TeamManagement_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_TeamManagement_Insert;
			Sql_Update = Sql_TeamManagement_Update;
			Sql_Delete = Sql_TeamManagement_Delete;
		}
       	#region Const of table TeamManagement
		/// <summary>
		/// Table TeamManagement
		/// </summary>
		public const string TB_TeamManagement = "TeamManagement";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm AssessmentAddress
		/// </summary>
		public const string Parm_TeamManagement_AssessmentAddress = "AssessmentAddress";
		/// <summary>
		/// Parm AssessmentTime
		/// </summary>
		public const string Parm_TeamManagement_AssessmentTime = "AssessmentTime";
		/// <summary>
		/// Parm AssignUserId
		/// </summary>
		public const string Parm_TeamManagement_AssignUserId = "AssignUserId";
		/// <summary>
		/// Parm AssignUserName
		/// </summary>
		public const string Parm_TeamManagement_AssignUserName = "AssignUserName";
		/// <summary>
		/// Parm ClassName
		/// </summary>
		public const string Parm_TeamManagement_ClassName = "ClassName";
		/// <summary>
		/// Parm ClassNo
		/// </summary>
		public const string Parm_TeamManagement_ClassNo = "ClassNo";
		/// <summary>
		/// Parm CompanyId
		/// </summary>
		public const string Parm_TeamManagement_CompanyId = "CompanyId";
		/// <summary>
		/// Parm CompanyName
		/// </summary>
		public const string Parm_TeamManagement_CompanyName = "CompanyName";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_TeamManagement_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_TeamManagement_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_TeamManagement_CreatorId = "CreatorId";
		/// <summary>
		/// Parm DepartmentId
		/// </summary>
		public const string Parm_TeamManagement_DepartmentId = "DepartmentId";
		/// <summary>
		/// Parm DepartmentName
		/// </summary>
		public const string Parm_TeamManagement_DepartmentName = "DepartmentName";
		/// <summary>
		/// Parm HandlingTime
		/// </summary>
		public const string Parm_TeamManagement_HandlingTime = "HandlingTime";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_TeamManagement_Id = "Id";
		/// <summary>
		/// Parm Remark
		/// </summary>
		public const string Parm_TeamManagement_Remark = "Remark";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_TeamManagement_RowStatus = "RowStatus";
		/// <summary>
		/// Parm StandardId
		/// </summary>
		public const string Parm_TeamManagement_StandardId = "StandardId";
		/// <summary>
		/// Parm StandardName
		/// </summary>
		public const string Parm_TeamManagement_StandardName = "StandardName";
		/// <summary>
		/// Parm Status
		/// </summary>
		public const string Parm_TeamManagement_Status = "Status";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_TeamManagement_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_TeamManagement_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_TeamManagement_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_TeamManagement_Version = "Version";
		/// <summary>
		/// Insert Query Of TeamManagement
		/// </summary>
		public const string Sql_TeamManagement_Insert = "insert into TeamManagement(AssessmentAddress,AssessmentTime,AssignUserId,AssignUserName,ClassName,ClassNo,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DepartmentId,DepartmentName,HandlingTime,Remark,RowStatus,StandardId,StandardName,Status,UpdateBy,UpdateId,UpdateOn,Id) values(@AssessmentAddress,@AssessmentTime,@AssignUserId,@AssignUserName,@ClassName,@ClassNo,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@DepartmentName,@HandlingTime,@Remark,@RowStatus,@StandardId,@StandardName,@Status,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of TeamManagement
		/// </summary>
		public const string Sql_TeamManagement_Update = "update TeamManagement set AssessmentAddress=@AssessmentAddress,AssessmentTime=@AssessmentTime,AssignUserId=@AssignUserId,AssignUserName=@AssignUserName,ClassName=@ClassName,ClassNo=@ClassNo,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,HandlingTime=@HandlingTime,Remark=@Remark,RowStatus=@RowStatus,StandardId=@StandardId,StandardName=@StandardName,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_TeamManagement_Delete = "update TeamManagement set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private string _companyId = string.Empty;
		/// <summary>
		/// 单位ID
		/// </summary>
		public string CompanyId
		{
			get{return _companyId ?? string.Empty;}
			set{_companyId = value;}
		}
		private string _companyName = string.Empty;
		/// <summary>
		/// 单位名称
		/// </summary>
		public string CompanyName
		{
			get{return _companyName ?? string.Empty;}
			set{_companyName = value;}
		}
		private string _departmentId = string.Empty;
		/// <summary>
		/// 部门ID
		/// </summary>
		public string DepartmentId
		{
			get{return _departmentId ?? string.Empty;}
			set{_departmentId = value;}
		}
		private string _departmentName = string.Empty;
		/// <summary>
		/// 部门名称
		/// </summary>
		public string DepartmentName
		{
			get{return _departmentName ?? string.Empty;}
			set{_departmentName = value;}
		}
		private string _classNo = string.Empty;
		/// <summary>
		///  队伍管理大类ID
		/// </summary>
		public string ClassNo
		{
			get{return _classNo ?? string.Empty;}
			set{_classNo = value;}
		}
		private string _className = string.Empty;
		/// <summary>
		/// 队伍管理大类名称
		/// </summary>
		public string ClassName
		{
			get{return _className ?? string.Empty;}
			set{_className = value;}
		}
		private string _standardId = string.Empty;
		/// <summary>
		/// 考核内容Id
		/// </summary>
		public string StandardId
		{
			get{return _standardId ?? string.Empty;}
			set{_standardId = value;}
		}
		private string _standardName = string.Empty;
		/// <summary>
		/// 考核内容
		/// </summary>
		public string StandardName
		{
			get{return _standardName ?? string.Empty;}
			set{_standardName = value;}
		}
		private DateTime _assessmentTime = MinDate;
		/// <summary>
		/// 考核时间
		/// </summary>
		public DateTime AssessmentTime
		{
			get{return _assessmentTime;}
			set{_assessmentTime = value;}
		}
		private string _assessmentAddress = string.Empty;
		/// <summary>
		/// 考核地点
		/// </summary>
		public string AssessmentAddress
		{
			get{return _assessmentAddress ?? string.Empty;}
			set{_assessmentAddress = value;}
		}
		private string _assignUserId = string.Empty;
		/// <summary>
		/// 指派人员
		/// </summary>
		public string AssignUserId
		{
			get{return _assignUserId ?? string.Empty;}
			set{_assignUserId = value;}
		}
		private string _assignUserName = string.Empty;
		/// <summary>
		/// 指派人员姓名
		/// </summary>
		public string AssignUserName
		{
			get{return _assignUserName ?? string.Empty;}
			set{_assignUserName = value;}
		}
		private DateTime _handlingTime = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime HandlingTime
		{
			get{return _handlingTime;}
			set{_handlingTime = value;}
		}
		private string _remark = string.Empty;
		/// <summary>
		/// 信息描述
		/// </summary>
		public string Remark
		{
			get{return _remark ?? string.Empty;}
			set{_remark = value;}
		}
		private int _status;
		/// <summary>
		/// 状态：0:待处理,1:处理中,2:已处理,3:已核查
		/// </summary>
		public int Status
		{
			get{return _status;}
			set{_status = value;}
		}
		#endregion

        #region 手动添加
        public string STime { get; set; }
        public string ETime { get; set; }
        public string HandlingIdea { get; set; }
        #endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override TeamManagementEntity SetModelValueByDataRow(DataRow dr)
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
		public override TeamManagementEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TeamManagementEntity();
          			if (fields.Contains(Parm_TeamManagement_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_TeamManagement_Id].ToString();
			if (fields.Contains(Parm_TeamManagement_CompanyId) || fields.Contains("*"))
				tmp.CompanyId = dr[Parm_TeamManagement_CompanyId].ToString();
			if (fields.Contains(Parm_TeamManagement_CompanyName) || fields.Contains("*"))
				tmp.CompanyName = dr[Parm_TeamManagement_CompanyName].ToString();
			if (fields.Contains(Parm_TeamManagement_DepartmentId) || fields.Contains("*"))
				tmp.DepartmentId = dr[Parm_TeamManagement_DepartmentId].ToString();
			if (fields.Contains(Parm_TeamManagement_DepartmentName) || fields.Contains("*"))
				tmp.DepartmentName = dr[Parm_TeamManagement_DepartmentName].ToString();
			if (fields.Contains(Parm_TeamManagement_ClassNo) || fields.Contains("*"))
				tmp.ClassNo = dr[Parm_TeamManagement_ClassNo].ToString();
			if (fields.Contains(Parm_TeamManagement_ClassName) || fields.Contains("*"))
				tmp.ClassName = dr[Parm_TeamManagement_ClassName].ToString();
			if (fields.Contains(Parm_TeamManagement_StandardId) || fields.Contains("*"))
				tmp.StandardId = dr[Parm_TeamManagement_StandardId].ToString();
			if (fields.Contains(Parm_TeamManagement_StandardName) || fields.Contains("*"))
				tmp.StandardName = dr[Parm_TeamManagement_StandardName].ToString();
			if (fields.Contains(Parm_TeamManagement_AssessmentTime) || fields.Contains("*"))
				tmp.AssessmentTime = DateTime.Parse(dr[Parm_TeamManagement_AssessmentTime].ToString());
			if (fields.Contains(Parm_TeamManagement_AssessmentAddress) || fields.Contains("*"))
				tmp.AssessmentAddress = dr[Parm_TeamManagement_AssessmentAddress].ToString();
			if (fields.Contains(Parm_TeamManagement_AssignUserId) || fields.Contains("*"))
				tmp.AssignUserId = dr[Parm_TeamManagement_AssignUserId].ToString();
			if (fields.Contains(Parm_TeamManagement_AssignUserName) || fields.Contains("*"))
				tmp.AssignUserName = dr[Parm_TeamManagement_AssignUserName].ToString();
			if (fields.Contains(Parm_TeamManagement_HandlingTime) || fields.Contains("*"))
				tmp.HandlingTime = DateTime.Parse(dr[Parm_TeamManagement_HandlingTime].ToString());
			if (fields.Contains(Parm_TeamManagement_Remark) || fields.Contains("*"))
				tmp.Remark = dr[Parm_TeamManagement_Remark].ToString();
			if (fields.Contains(Parm_TeamManagement_Status) || fields.Contains("*"))
				tmp.Status = int.Parse(dr[Parm_TeamManagement_Status].ToString());
			if (fields.Contains(Parm_TeamManagement_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_TeamManagement_RowStatus].ToString());
			if (fields.Contains(Parm_TeamManagement_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_TeamManagement_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_TeamManagement_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_TeamManagement_CreatorId].ToString();
			if (fields.Contains(Parm_TeamManagement_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_TeamManagement_CreateBy].ToString();
			if (fields.Contains(Parm_TeamManagement_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_TeamManagement_CreateOn].ToString());
			if (fields.Contains(Parm_TeamManagement_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_TeamManagement_UpdateId].ToString();
			if (fields.Contains(Parm_TeamManagement_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_TeamManagement_UpdateBy].ToString();
			if (fields.Contains(Parm_TeamManagement_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_TeamManagement_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="teammanagement">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(TeamManagementEntity teammanagement, SqlParameter[] parms)
		{
            				parms[0].Value = teammanagement.CompanyId;
				parms[1].Value = teammanagement.CompanyName;
				parms[2].Value = teammanagement.DepartmentId;
				parms[3].Value = teammanagement.DepartmentName;
				parms[4].Value = teammanagement.ClassNo;
				parms[5].Value = teammanagement.ClassName;
				parms[6].Value = teammanagement.StandardId;
				parms[7].Value = teammanagement.StandardName;
				parms[8].Value = teammanagement.AssessmentTime;
				parms[9].Value = teammanagement.AssessmentAddress;
				parms[10].Value = teammanagement.AssignUserId;
				parms[11].Value = teammanagement.AssignUserName;
				parms[12].Value = teammanagement.HandlingTime;
				parms[13].Value = teammanagement.Remark;
				parms[14].Value = teammanagement.Status;
				parms[15].Value = teammanagement.RowStatus;
				parms[16].Value = teammanagement.CreatorId;
				parms[17].Value = teammanagement.CreateBy;
				parms[18].Value = teammanagement.CreateOn;
				parms[19].Value = teammanagement.UpdateId;
				parms[20].Value = teammanagement.UpdateBy;
				parms[21].Value = teammanagement.UpdateOn;
                parms[22].Value = teammanagement.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(TeamManagementEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagement_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_TeamManagement_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_DepartmentName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_ClassName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_StandardId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_StandardName, SqlDbType.NVarChar, 2000),
					new SqlParameter(Parm_TeamManagement_AssessmentTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagement_AssessmentAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagement_AssignUserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_AssignUserName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagement_HandlingTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagement_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TeamManagement_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagement_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TeamManagement_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TeamManagement_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TeamManagement_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TeamManagement_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagement_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
