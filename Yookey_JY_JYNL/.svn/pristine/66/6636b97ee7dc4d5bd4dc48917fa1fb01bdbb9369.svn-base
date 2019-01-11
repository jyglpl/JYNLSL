//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightLochusAppearEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:46
//  功能描述：FlightLochusAppear表实体
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
    /// 排班主表
    /// </summary>
    [Serializable]
    public class FlightLochusAppearEntity : ModelImp.BaseModel<FlightLochusAppearEntity>
    {
        public FlightLochusAppearEntity()
        {
            TB_Name = TB_FlightLochusAppear;
            Parm_Id = Parm_FlightLochusAppear_Id;
            Parm_Version = Parm_FlightLochusAppear_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FlightLochusAppear_Insert;
            Sql_Update = Sql_FlightLochusAppear_Update;
            Sql_Delete = Sql_FlightLochusAppear_Delete;
        }
        #region Const of table FlightLochusAppear
        /// <summary>
        /// Table FlightLochusAppear
        /// </summary>
        public const string TB_FlightLochusAppear = "FlightLochusAppear";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AppearId
        /// </summary>
        public const string Parm_FlightLochusAppear_AppearId = "AppearId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FlightLochusAppear_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FlightLochusAppear_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FlightLochusAppear_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_FlightLochusAppear_DeptId = "DeptId";
        /// <summary>
        /// Parm FlightDate
        /// </summary>
        public const string Parm_FlightLochusAppear_FlightDate = "FlightDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FlightLochusAppear_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FlightLochusAppear_RowStatus = "RowStatus";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_FlightLochusAppear_State = "State";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FlightLochusAppear_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FlightLochusAppear_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FlightLochusAppear_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FlightLochusAppear_Version = "Version";
        /// <summary>
        /// Insert Query Of FlightLochusAppear
        /// </summary>
        public const string Sql_FlightLochusAppear_Insert = "insert into FlightLochusAppear(AppearId,CreateBy,CreateOn,CreatorId,DeptId,FlightDate,RowStatus,State,UpdateBy,UpdateId,UpdateOn,Id) values(@AppearId,@CreateBy,@CreateOn,@CreatorId,@DeptId,@FlightDate,@RowStatus,@State,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FlightLochusAppear
        /// </summary>
        public const string Sql_FlightLochusAppear_Update = "update FlightLochusAppear set AppearId=@AppearId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,FlightDate=@FlightDate,RowStatus=@RowStatus,State=@State,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FlightLochusAppear_Delete = "update FlightLochusAppear set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _appearId = string.Empty;
        /// <summary>
        /// 排班编号
        /// </summary>
        public string AppearId
        {
            get { return _appearId ?? string.Empty; }
            set { _appearId = value; }
        }
        private string _deptId = string.Empty;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId
        {
            get { return _deptId ?? string.Empty; }
            set { _deptId = value; }
        }
        private string _flightDate = string.Empty;
        /// <summary>
        /// 排班日期，精确到年月日
        /// </summary>
        public string FlightDate
        {
            get { return _flightDate ?? string.Empty; }
            set { _flightDate = value; }
        }
        private int _state;
        /// <summary>
        /// 状态
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FlightLochusAppearEntity SetModelValueByDataRow(DataRow dr)
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
        public override FlightLochusAppearEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightLochusAppearEntity();
            if (fields.Contains(Parm_FlightLochusAppear_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FlightLochusAppear_Id].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_AppearId) || fields.Contains("*"))
                tmp.AppearId = dr[Parm_FlightLochusAppear_AppearId].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_FlightLochusAppear_DeptId].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_FlightDate) || fields.Contains("*"))
                tmp.FlightDate = dr[Parm_FlightLochusAppear_FlightDate].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_FlightLochusAppear_State].ToString());
            if (fields.Contains(Parm_FlightLochusAppear_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FlightLochusAppear_RowStatus].ToString());
            if (fields.Contains(Parm_FlightLochusAppear_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FlightLochusAppear_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FlightLochusAppear_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FlightLochusAppear_CreatorId].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FlightLochusAppear_CreateBy].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FlightLochusAppear_CreateOn].ToString());
            if (fields.Contains(Parm_FlightLochusAppear_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FlightLochusAppear_UpdateId].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FlightLochusAppear_UpdateBy].ToString();
            if (fields.Contains(Parm_FlightLochusAppear_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightLochusAppear_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightlochusappear">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FlightLochusAppearEntity flightlochusappear, SqlParameter[] parms)
        {
            parms[0].Value = flightlochusappear.AppearId;
            parms[1].Value = flightlochusappear.DeptId;
            parms[2].Value = flightlochusappear.FlightDate;
            parms[3].Value = flightlochusappear.State;
            parms[4].Value = flightlochusappear.RowStatus;
            parms[5].Value = flightlochusappear.CreatorId;
            parms[6].Value = flightlochusappear.CreateBy;
            parms[7].Value = flightlochusappear.CreateOn;
            parms[8].Value = flightlochusappear.UpdateId;
            parms[9].Value = flightlochusappear.UpdateBy;
            parms[10].Value = flightlochusappear.UpdateOn;
            parms[11].Value = flightlochusappear.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FlightLochusAppearEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightLochusAppear_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FlightLochusAppear_AppearId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_DeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_FlightDate, SqlDbType.NVarChar, 15),
					new SqlParameter(Parm_FlightLochusAppear_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightLochusAppear_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightLochusAppear_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightLochusAppear_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightLochusAppear_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FlightLochusAppear_Id, SqlDbType.NVarChar, 50)
                    };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightLochusAppear_Insert, parms);
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
    /// 排班信息
    /// </summary>
    public class FlightMaster
    {
        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime Date { set; get; }

        /// <summary>
        /// 排班星期
        /// </summary>
        public string Week { set; get; }

        /// <summary>
        /// 详细集合
        /// </summary>
        public List<FlightDetails> FlightDetailses { get; set; }
    }

    /// <summary>
    /// 排班详情
    /// </summary>
    public class FlightDetails
    {
        /// <summary>
        /// 班次ID
        /// </summary>
        public string ClassesId { set; get; }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string ClassesName { set; get; }

        /// <summary>
        /// 工作时间段
        /// </summary>
        public string TimeInterval { set; get; }

        /// <summary>
        /// 人员集合
        /// </summary>
        public string UserNames { get; set; }
    }


    /// <summary>
    /// 排班报表
    /// </summary>
    public class FlightReport
    {
        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime Date { set; get; }

        /// <summary>
        /// 排班星期
        /// </summary>
        public string Week { set; get; }

        ///// <summary>
        ///// 总值班
        ///// </summary>
        //public string ChiefWatch { set; get; }

        ///// <summary>
        ///// 正值班长
        ///// </summary>
        //public string ChiefMonitor { get; set; }

        ///// <summary>
        ///// 副值班长
        ///// </summary>
        //public string DepudyMonitor { get; set; }

        /// <summary>
        /// 排班详情
        /// </summary>
        //public List<FlightReportDetails> FlightReportDetails { get; set; }

        public List<Dictionary<string,string>> FlightReportDetails { get; set; }

        public string DeptId { get; set; }

        public string DeptName { get; set; }

        public string[] ColFileName
        {
            get
            {
                return new string[]{
                "日期","星期","部门","早班","中班","夜班","日班","休息"
            };
            }
        }
    }

    /// <summary>
    /// 排班报表详情
    /// </summary>
    [Serializable]
    public class FlightReportDetails
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 早班
        /// </summary>
        public string ForeShift { get; set; }

        /// <summary>
        /// 中班
        /// </summary>
        public string MiddleShift { get; set; }

        /// <summary>
        /// 晚班
        /// </summary>
        public string NightShift { get; set; }

        /// <summary>
        /// 白班
        /// </summary>
        public string DayShift { get; set; }

        /// <summary>
        /// 休息
        /// </summary>
        public string Rest { get; set; }
    }

    /// <summary>
    /// 排班导入模板
    /// </summary>
    [Serializable]
    public class FlightExcelEntity
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 早班
        /// </summary>
        public string ForeShift { get; set; }

        /// <summary>
        /// 中班
        /// </summary>
        public string MiddleShift { get; set; }

        /// <summary>
        /// 晚班
        /// </summary>
        public string NightShift { get; set; }

        /// <summary>
        /// 白班
        /// </summary>
        public string DayShift { get; set; }

        /// <summary>
        /// 休息
        /// </summary>
        public string Rest { get; set; }

        /// <summary>
        /// 所有班次
        /// </summary>
        public string[] Shifts
        {
            get
            {
                return new string[] { "DayShift", "ForeShift", "MiddleShift", "NightShift", "Rest" };
            }
        }

        /// <summary>
        /// 总值班、正值班长、副值班长
        /// </summary>
        public string[] Dutys
        {
            get
            {
                return new string[] { "watch", "monitor","depudy" };
            }
        }

        /// <summary>
        /// 获取表列英文名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetColName(string name)
        {

            switch (name)
            {
                case "日期":
                    return "Date";
                case "日班":
                    return "DayShift";
                case "早班":
                    return "ForeShift";
                case "中班":
                    return "MiddleShift";
                case "夜班":
                    return "NightShift";
                case "休息":
                    return "Rest";
                case "总值班":
                    return "watch";
                case "正值班长":
                    return "monitor";
                case"副值班长":
                    return "depudy";
            }
            return null;
        }

        /// <summary>
        /// 获取表列英文名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetName(string name)
        {
            switch (name)
            {
                case "DayShift":
                    return "日班";
                case "ForeShift":
                    return "早班";
                case "MiddleShift":
                    return "中班";
                case "NightShift":
                    return "夜班";
                case "Rest":
                    return "休息";
            }
            return null;
        }
    }
}

