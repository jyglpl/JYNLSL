//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 16:39:59
//  功能描述：AttendanceReport表实体
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
    public class AttendanceReportEntity : ModelImp.BaseModel<AttendanceReportEntity>
    {
        public AttendanceReportEntity()
        {
            TB_Name = TB_AttendanceReport;
            Parm_Id = Parm_AttendanceReport_Id;
            Parm_Version = Parm_AttendanceReport_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_AttendanceReport_Insert;
            Sql_Update = Sql_AttendanceReport_Update;
            Sql_Delete = Sql_AttendanceReport_Delete;
        }
        #region Const of table AttendanceReport
        /// <summary>
        /// Table AttendanceReport
        /// </summary>
        public const string TB_AttendanceReport = "AttendanceReport";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_AttendanceReport_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_AttendanceReport_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_AttendanceReport_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_AttendanceReport_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_AttendanceReport_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_AttendanceReport_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm DepartmentName
        /// </summary>
        public const string Parm_AttendanceReport_DepartmentName = "DepartmentName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_AttendanceReport_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_AttendanceReport_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_AttendanceReport_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SMonth
        /// </summary>
        public const string Parm_AttendanceReport_SMonth = "SMonth";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_AttendanceReport_State = "State";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_AttendanceReport_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_AttendanceReport_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_AttendanceReport_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_AttendanceReport_Version = "Version";
        /// <summary>
        /// Insert Query Of AttendanceReport
        /// </summary>
        public const string Sql_AttendanceReport_Insert = "insert into AttendanceReport(CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DepartmentId,DepartmentName,Remark,RowStatus,SMonth,State,UpdateBy,UpdateId,UpdateOn,Id) values(@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@DepartmentName,@Remark,@RowStatus,@SMonth,@State,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of AttendanceReport
        /// </summary>
        public const string Sql_AttendanceReport_Update = "update AttendanceReport set CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,Remark=@Remark,RowStatus=@RowStatus,SMonth=@SMonth,State=@State,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_AttendanceReport_Delete = "update AttendanceReport set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
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
        private string _departmentId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _departmentName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName ?? string.Empty; }
            set { _departmentName = value; }
        }
        private DateTime _sMonth = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SMonth
        {
            get { return _sMonth; }
            set { _sMonth = value; }
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
        private int _state;
        /// <summary>
        /// 审批状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 审批状态
        /// </summary>
        public string StateDsc { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override AttendanceReportEntity SetModelValueByDataRow(DataRow dr)
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
        public override AttendanceReportEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AttendanceReportEntity();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_Id))
                tmp.Id = dr[Parm_AttendanceReport_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_CompanyId))
                tmp.CompanyId = dr[Parm_AttendanceReport_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_CompanyName))
                tmp.CompanyName = dr[Parm_AttendanceReport_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_DepartmentId))
                tmp.DepartmentId = dr[Parm_AttendanceReport_DepartmentId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_DepartmentName))
                tmp.DepartmentName = dr[Parm_AttendanceReport_DepartmentName].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_SMonth))
                tmp.SMonth = DateTime.Parse(dr[Parm_AttendanceReport_SMonth].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_Remark))
                tmp.Remark = dr[Parm_AttendanceReport_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_State))
                tmp.State = int.Parse(dr[Parm_AttendanceReport_State].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_AttendanceReport_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_Version))
            {
                var bts = (byte[])(dr[Parm_AttendanceReport_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_CreatorId))
                tmp.CreatorId = dr[Parm_AttendanceReport_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_CreateBy))
                tmp.CreateBy = dr[Parm_AttendanceReport_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_AttendanceReport_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_UpdateId))
                tmp.UpdateId = dr[Parm_AttendanceReport_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_UpdateBy))
                tmp.UpdateBy = dr[Parm_AttendanceReport_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_AttendanceReport_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_AttendanceReport_UpdateOn].ToString());
            if (dr.Table.Columns.Contains("StateDsc"))
                tmp.StateDsc = dr["StateDsc"].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="attendancereport">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AttendanceReportEntity attendancereport, SqlParameter[] parms)
        {
            parms[0].Value = attendancereport.CompanyId;
            parms[1].Value = attendancereport.CompanyName;
            parms[2].Value = attendancereport.DepartmentId;
            parms[3].Value = attendancereport.DepartmentName;
            parms[4].Value = attendancereport.SMonth;
            parms[5].Value = attendancereport.Remark;
            parms[6].Value = attendancereport.State;
            parms[7].Value = attendancereport.RowStatus;
            parms[8].Value = attendancereport.CreatorId;
            parms[9].Value = attendancereport.CreateBy;
            parms[10].Value = attendancereport.CreateOn;
            parms[11].Value = attendancereport.UpdateId;
            parms[12].Value = attendancereport.UpdateBy;
            parms[13].Value = attendancereport.UpdateOn;
            parms[14].Value = attendancereport.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AttendanceReportEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceReport_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_AttendanceReport_CompanyId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_CompanyName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_DepartmentId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_DepartmentName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_SMonth, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceReport_Remark, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_State, SqlDbType.Int, 10),
                            new SqlParameter(Parm_AttendanceReport_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_AttendanceReport_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceReport_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_AttendanceReport_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_AttendanceReport_Id, SqlDbType.NVarChar, 50)

                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_AttendanceReport_Insert, parms);
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

