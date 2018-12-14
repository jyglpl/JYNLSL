using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Hr
{
    /// <summary>
    /// 加班登记
    /// </summary>
    [Serializable]
    public class WorkOvertimeEntity : ModelImp.BaseModel<WorkOvertimeEntity>
    {
        public WorkOvertimeEntity()
        {
            TB_Name = TB_WorkOvertime;
            Parm_Id = Parm_WorkOvertime_Id;
            Parm_Version = Parm_WorkOvertime_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WorkOvertime_Insert;
            Sql_Update = Sql_WorkOvertime_Update;
            Sql_Delete = Sql_WorkOvertime_Delete;
        }
        #region Const of table WorkOvertime
        /// <summary>
        /// Table WorkOvertime
        /// </summary>
        public const string TB_WorkOvertime = "WorkOvertime";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BeginTime
        /// </summary>
        public const string Parm_WorkOvertime_BeginTime = "BeginTime";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_WorkOvertime_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_WorkOvertime_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WorkOvertime_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WorkOvertime_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WorkOvertime_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_WorkOvertime_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_WorkOvertime_DeptName = "DeptName";
        /// <summary>
        /// Parm EndTime
        /// </summary>
        public const string Parm_WorkOvertime_EndTime = "EndTime";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WorkOvertime_Id = "Id";
        /// <summary>
        /// Parm OvertimeDays
        /// </summary>
        public const string Parm_WorkOvertime_Overtime = "Overtime";
        /// <summary>
        /// Parm OvertimeReason
        /// </summary>
        public const string Parm_WorkOvertime_OvertimeReason = "OvertimeReason";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_WorkOvertime_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WorkOvertime_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_WorkOvertime_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WorkOvertime_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WorkOvertime_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WorkOvertime_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_WorkOvertime_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_WorkOvertime_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WorkOvertime_Version = "Version";
        /// <summary>
        /// Insert Query Of WorkOvertime
        /// </summary>
        public const string Sql_WorkOvertime_Insert = "insert into WorkOvertime(BeginTime,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DeptId,DeptName,EndTime,Overtime,OvertimeReason,Remark,RowStatus,Status,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Id) values(@BeginTime,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DeptId,@DeptName,@EndTime,@Overtime,@OvertimeReason,@Remark,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of WorkOvertime
        /// </summary>
        public const string Sql_WorkOvertime_Update = "update WorkOvertime set BeginTime=@BeginTime,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,DeptName=@DeptName,EndTime=@EndTime,Overtime=@Overtime,OvertimeReason=@OvertimeReason,Remark=@Remark,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WorkOvertime_Delete = "update WorkOvertime set RowStatus=0 where Id=@Id;select @@rowcount;";
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
        private string _overtimeReason = string.Empty;
        /// <summary>
        /// 加班原因
        /// </summary>
        public string OvertimeReason
        {
            get { return _overtimeReason ?? string.Empty; }
            set { _overtimeReason = value; }
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
        private double _overtime;
        /// <summary>
        /// 加班天数
        /// </summary>
        public double Overtime
        {
            get { return _overtime; }
            set { _overtime = value; }
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
        public override WorkOvertimeEntity SetModelValueByDataRow(DataRow dr)
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
        public override WorkOvertimeEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WorkOvertimeEntity();
            if (fields.Contains(Parm_WorkOvertime_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WorkOvertime_Id].ToString();
            if (fields.Contains(Parm_WorkOvertime_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_WorkOvertime_UserId].ToString();
            if (fields.Contains(Parm_WorkOvertime_UserName) || fields.Contains("*"))
                tmp.UserName = dr[Parm_WorkOvertime_UserName].ToString();
            if (fields.Contains(Parm_WorkOvertime_OvertimeReason) || fields.Contains("*"))
                tmp.OvertimeReason = dr[Parm_WorkOvertime_OvertimeReason].ToString();
            if (fields.Contains(Parm_WorkOvertime_CompanyId) || fields.Contains("*"))
                tmp.CompanyId = dr[Parm_WorkOvertime_CompanyId].ToString();
            if (fields.Contains(Parm_WorkOvertime_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_WorkOvertime_CompanyName].ToString();
            if (fields.Contains(Parm_WorkOvertime_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_WorkOvertime_DeptId].ToString();
            if (fields.Contains(Parm_WorkOvertime_DeptName) || fields.Contains("*"))
                tmp.DeptName = dr[Parm_WorkOvertime_DeptName].ToString();
            if (fields.Contains(Parm_WorkOvertime_BeginTime) || fields.Contains("*"))
                tmp.BeginTime = DateTime.Parse(dr[Parm_WorkOvertime_BeginTime].ToString());
            if (fields.Contains(Parm_WorkOvertime_EndTime) || fields.Contains("*"))
                tmp.EndTime = DateTime.Parse(dr[Parm_WorkOvertime_EndTime].ToString());
            if (fields.Contains(Parm_WorkOvertime_Overtime) || fields.Contains("*"))
                tmp.Overtime = Double.Parse(dr[Parm_WorkOvertime_Overtime].ToString());
            if (fields.Contains(Parm_WorkOvertime_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_WorkOvertime_Remark].ToString();
            if (fields.Contains(Parm_WorkOvertime_Status) || fields.Contains("*"))
                tmp.Status = int.Parse(dr[Parm_WorkOvertime_Status].ToString());
            if (fields.Contains(Parm_WorkOvertime_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WorkOvertime_RowStatus].ToString());
            if (fields.Contains(Parm_WorkOvertime_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WorkOvertime_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WorkOvertime_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WorkOvertime_CreatorId].ToString();
            if (fields.Contains(Parm_WorkOvertime_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WorkOvertime_CreateBy].ToString();
            if (fields.Contains(Parm_WorkOvertime_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WorkOvertime_CreateOn].ToString());
            if (fields.Contains(Parm_WorkOvertime_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WorkOvertime_UpdateId].ToString();
            if (fields.Contains(Parm_WorkOvertime_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WorkOvertime_UpdateBy].ToString();
            if (fields.Contains(Parm_WorkOvertime_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WorkOvertime_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="workovertime">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WorkOvertimeEntity workovertime, SqlParameter[] parms)
        {
            parms[0].Value = workovertime.UserId;
            parms[1].Value = workovertime.UserName;
            parms[2].Value = workovertime.OvertimeReason;
            parms[3].Value = workovertime.CompanyId;
            parms[4].Value = workovertime.CompanyName;
            parms[5].Value = workovertime.DeptId;
            parms[6].Value = workovertime.DeptName;
            parms[7].Value = workovertime.BeginTime;
            parms[8].Value = workovertime.EndTime;
            parms[9].Value = workovertime.Overtime;
            parms[10].Value = workovertime.Remark;
            parms[11].Value = workovertime.Status;
            parms[12].Value = workovertime.RowStatus;
            parms[13].Value = workovertime.CreatorId;
            parms[14].Value = workovertime.CreateBy;
            parms[15].Value = workovertime.CreateOn;
            parms[16].Value = workovertime.UpdateId;
            parms[17].Value = workovertime.UpdateBy;
            parms[18].Value = workovertime.UpdateOn;
            parms[19].Value = workovertime.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WorkOvertimeEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WorkOvertime_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WorkOvertime_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_OvertimeReason, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_WorkOvertime_CompanyId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_DeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_DeptName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_BeginTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WorkOvertime_EndTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WorkOvertime_Overtime, SqlDbType.Float, 53),
					new SqlParameter(Parm_WorkOvertime_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_WorkOvertime_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_WorkOvertime_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WorkOvertime_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WorkOvertime_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WorkOvertime_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_WorkOvertime_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WorkOvertime_Insert, parms);
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
