//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightMonitorEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:46
//  功能描述：FlightMonitor表实体
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
    /// 排班值班表
    /// </summary>
    [Serializable]
    public class FlightMonitorEntity : ModelImp.BaseModel<FlightMonitorEntity>
    {
        public FlightMonitorEntity()
        {
            TB_Name = TB_FlightMonitor;
            Parm_Id = Parm_FlightMonitor_Id;
            Parm_Version = Parm_FlightMonitor_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FlightMonitor_Insert;
            Sql_Update = Sql_FlightMonitor_Update;
            Sql_Delete = Sql_FlightMonitor_Delete;
        }
        #region Const of table FlightMonitor
        /// <summary>
        /// Table FlightMonitor
        /// </summary>
        public const string TB_FlightMonitor = "FlightMonitor";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ChiefMonitor
        /// </summary>
        public const string Parm_FlightMonitor_ChiefMonitor = "ChiefMonitor";
        /// <summary>
        /// Parm ChiefMonitorName
        /// </summary>
        public const string Parm_FlightMonitor_ChiefMonitorName = "ChiefMonitorName";
        /// <summary>
        /// Parm ChiefWatch
        /// </summary>
        public const string Parm_FlightMonitor_ChiefWatch = "ChiefWatch";
        /// <summary>
        /// Parm ChiefWatchName
        /// </summary>
        public const string Parm_FlightMonitor_ChiefWatchName = "ChiefWatchName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FlightMonitor_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FlightMonitor_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FlightMonitor_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptIdI
        /// </summary>
        public const string Parm_FlightMonitor_DeptIdI = "DeptIdI";
        /// <summary>
        /// Parm DeptIdII
        /// </summary>
        public const string Parm_FlightMonitor_DeptIdII = "DeptIdII";
        /// <summary>
        /// Parm DeptIdIII
        /// </summary>
        public const string Parm_FlightMonitor_DeptIdIII = "DeptIdIII";
        /// <summary>
        /// Parm DeputyMonitor
        /// </summary>
        public const string Parm_FlightMonitor_DeputyMonitor = "DeputyMonitor";
        /// <summary>
        /// Parm DeputyMonitorName
        /// </summary>
        public const string Parm_FlightMonitor_DeputyMonitorName = "DeputyMonitorName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FlightMonitor_Id = "Id";
        /// <summary>
        /// Parm OndutyDate
        /// </summary>
        public const string Parm_FlightMonitor_OndutyDate = "OndutyDate";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FlightMonitor_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FlightMonitor_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FlightMonitor_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FlightMonitor_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FlightMonitor_Version = "Version";
        /// <summary>
        /// Insert Query Of FlightMonitor
        /// </summary>
        public const string Sql_FlightMonitor_Insert = "insert into FlightMonitor(ChiefMonitor,ChiefMonitorName,ChiefWatch,ChiefWatchName,CreateBy,CreateOn,CreatorId,DeptIdI,DeptIdII,DeptIdIII,DeputyMonitor,DeputyMonitorName,OndutyDate,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@ChiefMonitor,@ChiefMonitorName,@ChiefWatch,@ChiefWatchName,@CreateBy,@CreateOn,@CreatorId,@DeptIdI,@DeptIdII,@DeptIdIII,@DeputyMonitor,@DeputyMonitorName,@OndutyDate,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FlightMonitor
        /// </summary>
        public const string Sql_FlightMonitor_Update = "update FlightMonitor set ChiefMonitor=@ChiefMonitor,ChiefMonitorName=@ChiefMonitorName,ChiefWatch=@ChiefWatch,ChiefWatchName=@ChiefWatchName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptIdI=@DeptIdI,DeptIdII=@DeptIdII,DeptIdIII=@DeptIdIII,DeputyMonitor=@DeputyMonitor,DeputyMonitorName=@DeputyMonitorName,OndutyDate=@OndutyDate,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FlightMonitor_Delete = "update FlightMonitor set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _chiefWatch = string.Empty;
        /// <summary>
        /// 总值班长
        /// </summary>
        public string ChiefWatch
        {
            get { return _chiefWatch ?? string.Empty; }
            set { _chiefWatch = value; }
        }
        private string _chiefWatchName = string.Empty;
        /// <summary>
        /// 总值班长姓名
        /// </summary>
        public string ChiefWatchName
        {
            get { return _chiefWatchName ?? string.Empty; }
            set { _chiefWatchName = value; }
        }
        private string _chiefMonitor = string.Empty;
        /// <summary>
        /// 正值班长
        /// </summary>
        public string ChiefMonitor
        {
            get { return _chiefMonitor ?? string.Empty; }
            set { _chiefMonitor = value; }
        }
        private string _chiefMonitorName = string.Empty;
        /// <summary>
        /// 正值班长姓名
        /// </summary>
        public string ChiefMonitorName
        {
            get { return _chiefMonitorName ?? string.Empty; }
            set { _chiefMonitorName = value; }
        }
        private string _deputyMonitor = string.Empty;
        /// <summary>
        /// 副值班长
        /// </summary>
        public string DeputyMonitor
        {
            get { return _deputyMonitor ?? string.Empty; }
            set { _deputyMonitor = value; }
        }
        private string _deputyMonitorName = string.Empty;
        /// <summary>
        /// 副值班长姓名
        /// </summary>
        public string DeputyMonitorName
        {
            get { return _deputyMonitorName ?? string.Empty; }
            set { _deputyMonitorName = value; }
        }
        private DateTime _ondutyDate = MinDate;
        /// <summary>
        /// 值班日期
        /// </summary>
        public DateTime OndutyDate
        {
            get { return _ondutyDate; }
            set { _ondutyDate = value; }
        }
        private string _deptIdI = string.Empty;
        /// <summary>
        /// 总值班部门
        /// </summary>
        public string DeptIdI
        {
            get { return _deptIdI ?? string.Empty; }
            set { _deptIdI = value; }
        }
        private string _deptIdII = string.Empty;
        /// <summary>
        /// 正值班所属部门
        /// </summary>
        public string DeptIdII
        {
            get { return _deptIdII ?? string.Empty; }
            set { _deptIdII = value; }
        }
        private string _deptIdIII = string.Empty;
        /// <summary>
        /// 副值班所属部门
        /// </summary>
        public string DeptIdIII
        {
            get { return _deptIdIII ?? string.Empty; }
            set { _deptIdIII = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FlightMonitorEntity SetModelValueByDataRow(DataRow dr)
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
        public override FlightMonitorEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightMonitorEntity();
            if (fields.Contains(Parm_FlightMonitor_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FlightMonitor_Id].ToString();
            if (fields.Contains(Parm_FlightMonitor_ChiefWatch) || fields.Contains("*"))
                tmp.ChiefWatch = dr[Parm_FlightMonitor_ChiefWatch].ToString();
            if (fields.Contains(Parm_FlightMonitor_ChiefWatchName) || fields.Contains("*"))
                tmp.ChiefWatchName = dr[Parm_FlightMonitor_ChiefWatchName].ToString();
            if (fields.Contains(Parm_FlightMonitor_ChiefMonitor) || fields.Contains("*"))
                tmp.ChiefMonitor = dr[Parm_FlightMonitor_ChiefMonitor].ToString();
            if (fields.Contains(Parm_FlightMonitor_ChiefMonitorName) || fields.Contains("*"))
                tmp.ChiefMonitorName = dr[Parm_FlightMonitor_ChiefMonitorName].ToString();
            if (fields.Contains(Parm_FlightMonitor_DeputyMonitor) || fields.Contains("*"))
                tmp.DeputyMonitor = dr[Parm_FlightMonitor_DeputyMonitor].ToString();
            if (fields.Contains(Parm_FlightMonitor_DeputyMonitorName) || fields.Contains("*"))
                tmp.DeputyMonitorName = dr[Parm_FlightMonitor_DeputyMonitorName].ToString();
            if (fields.Contains(Parm_FlightMonitor_OndutyDate) || fields.Contains("*"))
                tmp.OndutyDate = DateTime.Parse(dr[Parm_FlightMonitor_OndutyDate].ToString());
            if (fields.Contains(Parm_FlightMonitor_DeptIdI) || fields.Contains("*"))
                tmp.DeptIdI = dr[Parm_FlightMonitor_DeptIdI].ToString();
            if (fields.Contains(Parm_FlightMonitor_DeptIdII) || fields.Contains("*"))
                tmp.DeptIdII = dr[Parm_FlightMonitor_DeptIdII].ToString();
            if (fields.Contains(Parm_FlightMonitor_DeptIdIII) || fields.Contains("*"))
                tmp.DeptIdIII = dr[Parm_FlightMonitor_DeptIdIII].ToString();
            if (fields.Contains(Parm_FlightMonitor_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FlightMonitor_RowStatus].ToString());
            if (fields.Contains(Parm_FlightMonitor_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FlightMonitor_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FlightMonitor_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FlightMonitor_CreatorId].ToString();
            if (fields.Contains(Parm_FlightMonitor_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FlightMonitor_CreateBy].ToString();
            if (fields.Contains(Parm_FlightMonitor_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FlightMonitor_CreateOn].ToString());
            if (fields.Contains(Parm_FlightMonitor_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FlightMonitor_UpdateId].ToString();
            if (fields.Contains(Parm_FlightMonitor_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FlightMonitor_UpdateBy].ToString();
            if (fields.Contains(Parm_FlightMonitor_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightMonitor_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightmonitor">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FlightMonitorEntity flightmonitor, SqlParameter[] parms)
        {
            parms[0].Value = flightmonitor.ChiefWatch;
            parms[1].Value = flightmonitor.ChiefWatchName;
            parms[2].Value = flightmonitor.ChiefMonitor;
            parms[3].Value = flightmonitor.ChiefMonitorName;
            parms[4].Value = flightmonitor.DeputyMonitor;
            parms[5].Value = flightmonitor.DeputyMonitorName;
            parms[6].Value = flightmonitor.OndutyDate;
            parms[7].Value = flightmonitor.DeptIdI;
            parms[8].Value = flightmonitor.DeptIdII;
            parms[9].Value = flightmonitor.DeptIdIII;
            parms[10].Value = flightmonitor.RowStatus;
            parms[11].Value = flightmonitor.CreatorId;
            parms[12].Value = flightmonitor.CreateBy;
            parms[13].Value = flightmonitor.CreateOn;
            parms[14].Value = flightmonitor.UpdateId;
            parms[15].Value = flightmonitor.UpdateBy;
            parms[16].Value = flightmonitor.UpdateOn;
            parms[17].Value = flightmonitor.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FlightMonitorEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightMonitor_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FlightMonitor_ChiefWatch, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_ChiefWatchName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_ChiefMonitor, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_ChiefMonitorName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_DeputyMonitor, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_DeputyMonitorName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_OndutyDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightMonitor_DeptIdI, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_DeptIdII, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_DeptIdIII, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightMonitor_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightMonitor_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightMonitor_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FlightMonitor_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightMonitor_Insert, parms);
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

