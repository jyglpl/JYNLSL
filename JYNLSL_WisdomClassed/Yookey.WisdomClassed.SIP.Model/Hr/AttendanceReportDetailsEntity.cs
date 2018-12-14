//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportDetailsEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 16:34:11
//  功能描述：AttendanceReportDetails表实体
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
    public class AttendanceReportDetailsEntity : ModelImp.BaseModel<AttendanceReportDetailsEntity>
    {
        public AttendanceReportDetailsEntity()
        {
            TB_Name = TB_AttendanceReportDetails;
            Parm_Id = Parm_AttendanceReportDetails_Id;
            Parm_Version = Parm_AttendanceReportDetails_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_AttendanceReportDetails_Insert;
            Sql_Update = Sql_AttendanceReportDetails_Update;
            Sql_Delete = Sql_AttendanceReportDetails_Delete;
        }
        #region Const of table AttendanceReportDetails
        /// <summary>
        /// Table AttendanceReportDetails
        /// </summary>
        public const string TB_AttendanceReportDetails = "AttendanceReportDetails";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AttendType
        /// </summary>
        public const string Parm_AttendanceReportDetails_AttendType = "AttendType";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_AttendanceReportDetails_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_AttendanceReportDetails_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_AttendanceReportDetails_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndTime
        /// </summary>
        public const string Parm_AttendanceReportDetails_EndTime = "EndTime";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_AttendanceReportDetails_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_AttendanceReportDetails_Remark = "Remark";
        /// <summary>
        /// Parm ReportId
        /// </summary>
        public const string Parm_AttendanceReportDetails_ReportId = "ReportId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_AttendanceReportDetails_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartTime
        /// </summary>
        public const string Parm_AttendanceReportDetails_StartTime = "StartTime";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_AttendanceReportDetails_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_AttendanceReportDetails_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_AttendanceReportDetails_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_AttendanceReportDetails_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_AttendanceReportDetails_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_AttendanceReportDetails_Version = "Version";

        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_AttendanceReportDetails_OrderNo = "OrderNo";

        /// <summary>
        /// Insert Query Of AttendanceReportDetails
        /// </summary>
        public const string Sql_AttendanceReportDetails_Insert = "insert into AttendanceReportDetails(AttendType,CreateBy,CreateOn,CreatorId,EndTime,Remark,ReportId,RowStatus,StartTime,UpdateBy,UpdateId,UpdateOn,UserId,UserName,OrderNo,Id) values(@AttendType,@CreateBy,@CreateOn,@CreatorId,@EndTime,@Remark,@ReportId,@RowStatus,@StartTime,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@OrderNo,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of AttendanceReportDetails
        /// </summary>
        public const string Sql_AttendanceReportDetails_Update = "update AttendanceReportDetails set AttendType=@AttendType,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndTime=@EndTime,Remark=@Remark,ReportId=@ReportId,RowStatus=@RowStatus,StartTime=@StartTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName,OrderNo=@OrderNo where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_AttendanceReportDetails_Delete = "update AttendanceReportDetails set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _reportId = string.Empty;
        /// <summary>
        /// 外键ID
        /// </summary>
        public string ReportId
        {
            get { return _reportId ?? string.Empty; }
            set { _reportId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _userName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        private string _attendType = string.Empty;
        /// <summary>
        /// 考勤类型
        /// </summary>
        public string AttendType
        {
            get { return _attendType ?? string.Empty; }
            set { _attendType = value; }
        }
        private DateTime _startTime = MinDate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime _endTime = MinDate;
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }

        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderNo { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override AttendanceReportDetailsEntity SetModelValueByDataRow(DataRow dr)
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
        public override AttendanceReportDetailsEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AttendanceReportDetailsEntity();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_Id))
                tmp.Id = dr[Parm_AttendanceReportDetails_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_ReportId))
                tmp.ReportId = dr[Parm_AttendanceReportDetails_ReportId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_UserId))
                tmp.UserId = dr[Parm_AttendanceReportDetails_UserId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_UserName))
                tmp.UserName = dr[Parm_AttendanceReportDetails_UserName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_AttendType))
                tmp.AttendType = dr[Parm_AttendanceReportDetails_AttendType].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_StartTime))
                tmp.StartTime = DateTime.Parse(dr[Parm_AttendanceReportDetails_StartTime].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_EndTime))
                tmp.EndTime = DateTime.Parse(dr[Parm_AttendanceReportDetails_EndTime].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_Remark))
                tmp.Remark = dr[Parm_AttendanceReportDetails_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_AttendanceReportDetails_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_Version))
            {
                var bts = (byte[])(dr[Parm_AttendanceReportDetails_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_CreatorId))
                tmp.CreatorId = dr[Parm_AttendanceReportDetails_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_CreateBy))
                tmp.CreateBy = dr[Parm_AttendanceReportDetails_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_AttendanceReportDetails_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_UpdateId))
                tmp.UpdateId = dr[Parm_AttendanceReportDetails_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_UpdateBy))
                tmp.UpdateBy = dr[Parm_AttendanceReportDetails_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_AttendanceReportDetails_UpdateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReportDetails_OrderNo))
                tmp.OrderNo = int.Parse(dr[Parm_AttendanceReportDetails_OrderNo].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="attendancereportdetails">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AttendanceReportDetailsEntity attendancereportdetails, SqlParameter[] parms)
        {
            parms[0].Value = attendancereportdetails.ReportId;
            parms[1].Value = attendancereportdetails.UserId;
            parms[2].Value = attendancereportdetails.UserName;
            parms[3].Value = attendancereportdetails.AttendType;
            parms[4].Value = attendancereportdetails.StartTime;
            parms[5].Value = attendancereportdetails.EndTime;
            parms[6].Value = attendancereportdetails.Remark;
            parms[7].Value = attendancereportdetails.RowStatus;
            parms[8].Value = attendancereportdetails.CreatorId;
            parms[9].Value = attendancereportdetails.CreateBy;
            parms[10].Value = attendancereportdetails.CreateOn;
            parms[11].Value = attendancereportdetails.UpdateId;
            parms[12].Value = attendancereportdetails.UpdateBy;
            parms[13].Value = attendancereportdetails.UpdateOn;
            parms[14].Value = attendancereportdetails.OrderNo;
            parms[15].Value = attendancereportdetails.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AttendanceReportDetailsEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceReportDetails_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_AttendanceReportDetails_ReportId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_AttendType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_StartTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_AttendanceReportDetails_EndTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_AttendanceReportDetails_Remark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_AttendanceReportDetails_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_AttendanceReportDetails_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_AttendanceReportDetails_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_AttendanceReportDetails_OrderNo, SqlDbType.Int, 10),
                    new SqlParameter(Parm_AttendanceReportDetails_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceReportDetails_Insert, parms);
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

