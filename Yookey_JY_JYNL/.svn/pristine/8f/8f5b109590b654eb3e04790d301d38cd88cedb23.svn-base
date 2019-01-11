//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceLeaveEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/13 13:28:41
//  功能描述：AttendanceLeave表实体
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
    /// 请假登记
    /// </summary>
    [Serializable]
    public class AttendanceLeaveEntity : ModelImp.BaseModel<AttendanceLeaveEntity>
    {
        public AttendanceLeaveEntity()
        {
            TB_Name = TB_AttendanceLeave;
            Parm_Id = Parm_AttendanceLeave_Id;
            Parm_Version = Parm_AttendanceLeave_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_AttendanceLeave_Insert;
            Sql_Update = Sql_AttendanceLeave_Update;
            Sql_Delete = Sql_AttendanceLeave_Delete;
        }
        #region Const of table AttendanceLeave
        /// <summary>
        /// Table AttendanceLeave
        /// </summary>
        public const string TB_AttendanceLeave = "AttendanceLeave";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BeginTime
        /// </summary>
        public const string Parm_AttendanceLeave_BeginTime = "BeginTime";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_AttendanceLeave_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_AttendanceLeave_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_AttendanceLeave_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_AttendanceLeave_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_AttendanceLeave_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_AttendanceLeave_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_AttendanceLeave_DeptName = "DeptName";
        /// <summary>
        /// Parm EndTime
        /// </summary>
        public const string Parm_AttendanceLeave_EndTime = "EndTime";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_AttendanceLeave_Id = "Id";
        /// <summary>
        /// Parm LeaveReason
        /// </summary>
        public const string Parm_AttendanceLeave_LeaveReason = "LeaveReason";
        /// <summary>
        /// Parm LeaveTime
        /// </summary>
        public const string Parm_AttendanceLeave_LeaveTime = "LeaveTime";
        /// <summary>
        /// Parm LeaveType
        /// </summary>
        public const string Parm_AttendanceLeave_LeaveType = "LeaveType";
        /// <summary>
        /// Parm LeaveTypeName
        /// </summary>
        public const string Parm_AttendanceLeave_LeaveTypeName = "LeaveTypeName";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_AttendanceLeave_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_AttendanceLeave_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_AttendanceLeave_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_AttendanceLeave_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_AttendanceLeave_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_AttendanceLeave_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_AttendanceLeave_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_AttendanceLeave_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_AttendanceLeave_Version = "Version";
        /// <summary>
        /// Insert Query Of AttendanceLeave
        /// </summary>
        public const string Sql_AttendanceLeave_Insert = "insert into AttendanceLeave(BeginTime,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DeptId,DeptName,EndTime,LeaveReason,LeaveTime,LeaveType,LeaveTypeName,Remark,RowStatus,Status,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Id) values(@BeginTime,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DeptId,@DeptName,@EndTime,@LeaveReason,@LeaveTime,@LeaveType,@LeaveTypeName,@Remark,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of AttendanceLeave
        /// </summary>
        public const string Sql_AttendanceLeave_Update = "update AttendanceLeave set BeginTime=@BeginTime,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,DeptName=@DeptName,EndTime=@EndTime,LeaveReason=@LeaveReason,LeaveTime=@LeaveTime,LeaveType=@LeaveType,LeaveTypeName=@LeaveTypeName,Remark=@Remark,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_AttendanceLeave_Delete = "update AttendanceLeave set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _userId = string.Empty;
        /// <summary>
        /// 请假人ID
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _userName = string.Empty;
        /// <summary>
        /// 请假人姓名
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        private string _leaveType = string.Empty;
        /// <summary>
        /// 请假类型
        /// </summary>
        public string LeaveType
        {
            get { return _leaveType ?? string.Empty; }
            set { _leaveType = value; }
        }
        private string _leaveTypeName = string.Empty;
        /// <summary>
        /// 请假类型名称
        /// </summary>
        public string LeaveTypeName
        {
            get { return _leaveTypeName ?? string.Empty; }
            set { _leaveTypeName = value; }
        }
        private string _leaveReason = string.Empty;
        /// <summary>
        /// 请假原因
        /// </summary>
        public string LeaveReason
        {
            get { return _leaveReason ?? string.Empty; }
            set { _leaveReason = value; }
        }
        private string _companyId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyId
        {
            get { return _companyId ?? string.Empty; }
            set { _companyId = value; }
        }
        private string _companyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            get { return _companyName ?? string.Empty; }
            set { _companyName = value; }
        }
        private string _deptId = string.Empty;
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DeptId
        {
            get { return _deptId ?? string.Empty; }
            set { _deptId = value; }
        }
        private string _deptName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName
        {
            get { return _deptName ?? string.Empty; }
            set { _deptName = value; }
        }
        private DateTime _beginTime = MinDate;
        /// <summary>
        /// 请假开始时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }
        private DateTime _endTime = MinDate;
        /// <summary>
        /// 请假截止时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private Double _leaveTime;
        /// <summary>
        /// 请假天数
        /// </summary>
        public Double LeaveTime
        {
            get { return _leaveTime; }
            set { _leaveTime = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private int _status;
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion


        #region 辅助属性

        /// <summary>
        /// 附件材料
        /// </summary>
        public string Attachment { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override AttendanceLeaveEntity SetModelValueByDataRow(DataRow dr)
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
        public override AttendanceLeaveEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AttendanceLeaveEntity();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_Id) )
                tmp.Id = dr[Parm_AttendanceLeave_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_UserId) )
                tmp.UserId = dr[Parm_AttendanceLeave_UserId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_UserName) )
                tmp.UserName = dr[Parm_AttendanceLeave_UserName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_LeaveType) )
                tmp.LeaveType = dr[Parm_AttendanceLeave_LeaveType].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_LeaveTypeName) )
                tmp.LeaveTypeName = dr[Parm_AttendanceLeave_LeaveTypeName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_LeaveReason) )
                tmp.LeaveReason = dr[Parm_AttendanceLeave_LeaveReason].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_CompanyId) )
                tmp.CompanyId = dr[Parm_AttendanceLeave_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_CompanyName) )
                tmp.CompanyName = dr[Parm_AttendanceLeave_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_DeptId) )
                tmp.DeptId = dr[Parm_AttendanceLeave_DeptId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_DeptName) )
                tmp.DeptName = dr[Parm_AttendanceLeave_DeptName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_BeginTime) )
                tmp.BeginTime = DateTime.Parse(dr[Parm_AttendanceLeave_BeginTime].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_EndTime) )
                tmp.EndTime = DateTime.Parse(dr[Parm_AttendanceLeave_EndTime].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_LeaveTime) )
                tmp.LeaveTime = Double.Parse(dr[Parm_AttendanceLeave_LeaveTime].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_Remark) )
                tmp.Remark = dr[Parm_AttendanceLeave_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_Status) )
                tmp.Status = int.Parse(dr[Parm_AttendanceLeave_Status].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_RowStatus) )
                tmp.RowStatus = int.Parse(dr[Parm_AttendanceLeave_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_Version) )
            {
                var bts = (byte[])(dr[Parm_AttendanceLeave_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_CreatorId) )
                tmp.CreatorId = dr[Parm_AttendanceLeave_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_CreateBy) )
                tmp.CreateBy = dr[Parm_AttendanceLeave_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_CreateOn) )
                tmp.CreateOn = DateTime.Parse(dr[Parm_AttendanceLeave_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_UpdateId) )
                tmp.UpdateId = dr[Parm_AttendanceLeave_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_UpdateBy) )
                tmp.UpdateBy = dr[Parm_AttendanceLeave_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceLeave_UpdateOn) )
                tmp.UpdateOn = DateTime.Parse(dr[Parm_AttendanceLeave_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="attendanceleave">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AttendanceLeaveEntity attendanceleave, SqlParameter[] parms)
        {
            parms[0].Value = attendanceleave.UserId;
            parms[1].Value = attendanceleave.UserName;
            parms[2].Value = attendanceleave.LeaveType;
            parms[3].Value = attendanceleave.LeaveTypeName;
            parms[4].Value = attendanceleave.LeaveReason;
            parms[5].Value = attendanceleave.CompanyId;
            parms[6].Value = attendanceleave.CompanyName;
            parms[7].Value = attendanceleave.DeptId;
            parms[8].Value = attendanceleave.DeptName;
            parms[9].Value = attendanceleave.BeginTime;
            parms[10].Value = attendanceleave.EndTime;
            parms[11].Value = attendanceleave.LeaveTime;
            parms[12].Value = attendanceleave.Remark;
            parms[13].Value = attendanceleave.Status;
            parms[14].Value = attendanceleave.RowStatus;
            parms[15].Value = attendanceleave.CreatorId;
            parms[16].Value = attendanceleave.CreateBy;
            parms[17].Value = attendanceleave.CreateOn;
            parms[18].Value = attendanceleave.UpdateId;
            parms[19].Value = attendanceleave.UpdateBy;
            parms[20].Value = attendanceleave.UpdateOn;
            parms[21].Value = attendanceleave.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AttendanceLeaveEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceLeave_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_AttendanceLeave_UserId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_UserName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_LeaveType, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_LeaveTypeName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_LeaveReason, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_AttendanceLeave_CompanyId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_CompanyName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_DeptId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_DeptName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_BeginTime, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceLeave_EndTime, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceLeave_LeaveTime, SqlDbType.Float, 53),
                            new SqlParameter(Parm_AttendanceLeave_Remark, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_AttendanceLeave_Status, SqlDbType.Int, 10),
                            new SqlParameter(Parm_AttendanceLeave_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_AttendanceLeave_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceLeave_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceLeave_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceLeave_Id, SqlDbType.NVarChar, 50)
                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceLeave_Insert, parms);
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

