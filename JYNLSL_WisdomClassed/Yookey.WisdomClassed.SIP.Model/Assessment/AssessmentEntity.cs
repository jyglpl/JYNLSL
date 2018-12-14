//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AssessmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/14 15:04:12
//  功能描述：Assessment表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Assessment
{
    /// <summary>
    /// 路面考核
    /// </summary>
    [Serializable]
    public class AssessmentEntity : ModelImp.BaseModel<AssessmentEntity>
    {
        public AssessmentEntity()
        {
            TB_Name = TB_Assessment;
            Parm_Id = Parm_Assessment_Id;
            Parm_Version = Parm_Assessment_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Assessment_Insert;
            Sql_Update = Sql_Assessment_Update;
            Sql_Delete = Sql_Assessment_Delete;
        }
        #region Const of table Assessment
        /// <summary>
        /// Table Assessment
        /// </summary>
        public const string TB_Assessment = "Assessment";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AssessmentAddress
        /// </summary>
        public const string Parm_Assessment_AssessmentAddress = "AssessmentAddress";
        /// <summary>
        /// Parm AssessmentTime
        /// </summary>
        public const string Parm_Assessment_AssessmentTime = "AssessmentTime";
        /// <summary>
        /// Parm ClassName
        /// </summary>
        public const string Parm_Assessment_ClassName = "ClassName";
        /// <summary>
        /// Parm ClassNo
        /// </summary>
        public const string Parm_Assessment_ClassNo = "ClassNo";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_Assessment_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_Assessment_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Assessment_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Assessment_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Assessment_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_Assessment_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm DepartmentName
        /// </summary>
        public const string Parm_Assessment_DepartmentName = "DepartmentName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Assessment_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_Assessment_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Assessment_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_Assessment_Status = "Status";

        /// <summary>
        /// Parm AssignUserId
        /// </summary>
        public const string Parm_Assessment_AssignUserId = "AssignUserId";
        /// <summary>
        /// Parm AssignUserName
        /// </summary>
        public const string Parm_Assessment_AssignUserName = "AssignUserName";
        /// <summary>
        /// Parm HandlingTime
        /// </summary>
        public const string Parm_Assessment_HandlingTime = "HandlingTime";

        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Assessment_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Assessment_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Assessment_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Assessment_Version = "Version";
        /// <summary>
        /// Insert Query Of Assessment
        /// </summary>
        public const string Sql_Assessment_Insert = "insert into Assessment(AssessmentAddress,AssessmentTime,ClassName,ClassNo,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DepartmentId,DepartmentName,Remark,RowStatus,Status,UpdateBy,UpdateId,UpdateOn,AssignUserId,AssignUserName,HandlingTime,Id) values(@AssessmentAddress,@AssessmentTime,@ClassName,@ClassNo,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@DepartmentName,@Remark,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn,@AssignUserId,@AssignUserName,@HandlingTime,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Assessment
        /// </summary>
        public const string Sql_Assessment_Update = "update Assessment set AssessmentAddress=@AssessmentAddress,AssessmentTime=@AssessmentTime,ClassName=@ClassName,ClassNo=@ClassNo,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,Remark=@Remark,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,AssignUserId=@AssignUserId,AssignUserName=@AssignUserName,HandlingTime=@HandlingTime where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Assessment_Delete = "update Assessment set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _companyId = string.Empty;
        /// <summary>
        /// 单位ID
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _companyName = string.Empty;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyName ?? string.Empty; }
            set { _companyName = value; }
        }
        private string _departmentId = string.Empty;
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _departmentName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName ?? string.Empty; }
            set { _departmentName = value; }
        }
        private string _classNo = string.Empty;
        /// <summary>
        /// 八大类ID
        /// </summary>
        public string ClassNo
        {
            get { return _classNo ?? string.Empty; }
            set { _classNo = value; }
        }
        private string _className = string.Empty;
        /// <summary>
        /// 八大类名称
        /// </summary>
        public string ClassName
        {
            get { return _className ?? string.Empty; }
            set { _className = value; }
        }
        private DateTime _assessmentTime = MinDate;
        /// <summary>
        /// 考核时间
        /// </summary>
        public DateTime AssessmentTime
        {
            get { return _assessmentTime; }
            set { _assessmentTime = value; }
        }
        private string _assessmentAddress = string.Empty;
        /// <summary>
        /// 考核地点
        /// </summary>
        public string AssessmentAddress
        {
            get { return _assessmentAddress ?? string.Empty; }
            set { _assessmentAddress = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 信息描述
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private int _status;
        /// <summary>
        /// 状态：0:待处理,1:处理中,2:已处理,3:已核查
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }


        private string _assignUserId;
        /// <summary>
        /// 指派人员
        /// </summary>
        public string AssignUserId
        {
            get { return _assignUserId; }
            set { _assignUserId = value; }
        }

        private string _assignUserName;
        /// <summary>
        /// 指派人员姓名
        /// </summary>
        public string AssignUserName
        {
            get { return _assignUserName; }
            set { _assignUserName = value; }
        }

        private DateTime _handlingTime = MinDate;
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime HandlingTime
        {
            get { return _handlingTime; }
            set { _handlingTime = value; }
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
        public override AssessmentEntity SetModelValueByDataRow(DataRow dr)
        {
            IList<string> fields = new List<string> { "*" };
            return SetModelValueByDataRow(dr, fields);
        }

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public override AssessmentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AssessmentEntity();
            if (dr.Table.Columns.Contains(Parm_Assessment_Id))
                tmp.Id = dr[Parm_Assessment_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_CompanyId))
                tmp.CompanyId = dr[Parm_Assessment_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_CompanyName))
                tmp.CompanyName = dr[Parm_Assessment_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_DepartmentId))
                tmp.DepartmentId = dr[Parm_Assessment_DepartmentId].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_DepartmentName))
                tmp.DepartmentName = dr[Parm_Assessment_DepartmentName].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_ClassNo))
                tmp.ClassNo = dr[Parm_Assessment_ClassNo].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_ClassName))
                tmp.ClassName = dr[Parm_Assessment_ClassName].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_AssessmentTime))
                tmp.AssessmentTime = DateTime.Parse(dr[Parm_Assessment_AssessmentTime].ToString());
            if (dr.Table.Columns.Contains(Parm_Assessment_AssessmentAddress))
                tmp.AssessmentAddress = dr[Parm_Assessment_AssessmentAddress].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_Remark))
                tmp.Remark = dr[Parm_Assessment_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_Status))
                tmp.Status = int.Parse(dr[Parm_Assessment_Status].ToString());
            if (dr.Table.Columns.Contains(Parm_Assessment_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_Assessment_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_Assessment_Version))
            {
                var bts = (byte[])(dr[Parm_Assessment_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_Assessment_CreatorId))
                tmp.CreatorId = dr[Parm_Assessment_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_CreateBy))
                tmp.CreateBy = dr[Parm_Assessment_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Assessment_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_Assessment_UpdateId))
                tmp.UpdateId = dr[Parm_Assessment_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_UpdateBy))
                tmp.UpdateBy = dr[Parm_Assessment_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Assessment_UpdateOn].ToString());

            if (dr.Table.Columns.Contains(Parm_Assessment_AssignUserId))
                tmp.AssignUserId = dr[Parm_Assessment_AssignUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_AssignUserName))
                tmp.AssignUserName = dr[Parm_Assessment_AssignUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_Assessment_HandlingTime))
                tmp.HandlingTime = DateTime.Parse(dr[Parm_Assessment_HandlingTime].ToString());
            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="assessment">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AssessmentEntity assessment, SqlParameter[] parms)
        {
            parms[0].Value = assessment.CompanyId;
            parms[1].Value = assessment.CompanyName;
            parms[2].Value = assessment.DepartmentId;
            parms[3].Value = assessment.DepartmentName;
            parms[4].Value = assessment.ClassNo;
            parms[5].Value = assessment.ClassName;
            parms[6].Value = assessment.AssessmentTime;
            parms[7].Value = assessment.AssessmentAddress;
            parms[8].Value = assessment.Remark;
            parms[9].Value = assessment.Status;
            parms[10].Value = assessment.RowStatus;
            parms[11].Value = assessment.CreatorId;
            parms[12].Value = assessment.CreateBy;
            parms[13].Value = assessment.CreateOn;
            parms[14].Value = assessment.UpdateId;
            parms[15].Value = assessment.UpdateBy;
            parms[16].Value = assessment.UpdateOn;
            parms[17].Value = assessment.AssignUserId;
            parms[18].Value = assessment.AssignUserName;
            parms[19].Value = assessment.HandlingTime;
            parms[20].Value = assessment.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AssessmentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Assessment_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Assessment_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_DepartmentName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_ClassNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_ClassName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_AssessmentTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Assessment_AssessmentAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Assessment_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Assessment_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_Assessment_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Assessment_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Assessment_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Assessment_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Assessment_AssignUserId, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_Assessment_AssignUserName, SqlDbType.NVarChar, 200),
                    new SqlParameter(Parm_Assessment_HandlingTime, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Assessment_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Assessment_Insert, parms);
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

