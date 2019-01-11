//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightClassesOfDeptmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/10 14:05:24
//  功能描述：FlightClassesOfDeptment表实体
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
    /// 班次与部门对应
    /// </summary>
    [Serializable]
    public class FlightClassesOfDeptmentEntity : ModelImp.BaseModel<FlightClassesOfDeptmentEntity>
    {
        public FlightClassesOfDeptmentEntity()
        {
            TB_Name = TB_FlightClassesOfDeptment;
            Parm_Id = Parm_FlightClassesOfDeptment_Id;
            Parm_Version = Parm_FlightClassesOfDeptment_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FlightClassesOfDeptment_Insert;
            Sql_Update = Sql_FlightClassesOfDeptment_Update;
            Sql_Delete = Sql_FlightClassesOfDeptment_Delete;
        }
        #region Const of table FlightClassesOfDeptment
        /// <summary>
        /// Table FlightClassesOfDeptment
        /// </summary>
        public const string TB_FlightClassesOfDeptment = "FlightClassesOfDeptment";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ClassesId
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_ClassesId = "ClassesId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_DeptId = "DeptId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TimePeriodEnd
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_TimePeriodEnd = "TimePeriodEnd";
        /// <summary>
        /// Parm TimePeriodState
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_TimePeriodState = "TimePeriodState";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_Version = "Version";

        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_FlightClassesOfDeptment_OrderNo = "OrderNo";

        /// <summary>
        /// Insert Query Of FlightClassesOfDeptment
        /// </summary>
        public const string Sql_FlightClassesOfDeptment_Insert = "insert into FlightClassesOfDeptment(ClassesId,CreateBy,CreateOn,CreatorId,DeptId,RowStatus,TimePeriodEnd,TimePeriodState,UpdateBy,UpdateId,UpdateOn,OrderNo,Id) values(@ClassesId,@CreateBy,@CreateOn,@CreatorId,@DeptId,@RowStatus,@TimePeriodEnd,@TimePeriodState,@UpdateBy,@UpdateId,@UpdateOn,@OrderNo,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FlightClassesOfDeptment
        /// </summary>
        public const string Sql_FlightClassesOfDeptment_Update = "update FlightClassesOfDeptment set ClassesId=@ClassesId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,RowStatus=@RowStatus,TimePeriodEnd=@TimePeriodEnd,TimePeriodState=@TimePeriodState,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,OrderNo=@OrderNo where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FlightClassesOfDeptment_Delete = "update FlightClassesOfDeptment set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _deptId = string.Empty;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId
        {
            get { return _deptId ?? string.Empty; }
            set { _deptId = value; }
        }
        private string _classesId = string.Empty;
        /// <summary>
        /// 班次编号
        /// </summary>
        public string ClassesId
        {
            get { return _classesId ?? string.Empty; }
            set { _classesId = value; }
        }
        private string _timePeriodState = string.Empty;
        /// <summary>
        /// 时间段
        /// </summary>
        public string TimePeriodState
        {
            get { return _timePeriodState ?? string.Empty; }
            set { _timePeriodState = value; }
        }
        private string _timePeriodEnd = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string TimePeriodEnd
        {
            get { return _timePeriodEnd ?? string.Empty; }
            set { _timePeriodEnd = value; }
        }

        public int OrderNo { get; set; }


        public string DepteName { get; set; }
        public string ClassesName { get; set; }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FlightClassesOfDeptmentEntity SetModelValueByDataRow(DataRow dr)
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
        public override FlightClassesOfDeptmentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightClassesOfDeptmentEntity();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_Id))
                tmp.Id = dr[Parm_FlightClassesOfDeptment_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_DeptId))
                tmp.DeptId = dr[Parm_FlightClassesOfDeptment_DeptId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_ClassesId))
                tmp.ClassesId = dr[Parm_FlightClassesOfDeptment_ClassesId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_TimePeriodState))
                tmp.TimePeriodState = dr[Parm_FlightClassesOfDeptment_TimePeriodState].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_TimePeriodEnd))
                tmp.TimePeriodEnd = dr[Parm_FlightClassesOfDeptment_TimePeriodEnd].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_FlightClassesOfDeptment_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_Version))
            {
                var bts = (byte[])(dr[Parm_FlightClassesOfDeptment_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_CreatorId))
                tmp.CreatorId = dr[Parm_FlightClassesOfDeptment_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_CreateBy))
                tmp.CreateBy = dr[Parm_FlightClassesOfDeptment_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FlightClassesOfDeptment_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_UpdateId))
                tmp.UpdateId = dr[Parm_FlightClassesOfDeptment_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_UpdateBy))
                tmp.UpdateBy = dr[Parm_FlightClassesOfDeptment_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightClassesOfDeptment_UpdateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightClassesOfDeptment_OrderNo))
                tmp.OrderNo = int.Parse(dr[Parm_FlightClassesOfDeptment_OrderNo].ToString());


            if (dr.Table.Columns.Contains("DepteName"))
                tmp.DepteName = dr["DepteName"].ToString();

            if (dr.Table.Columns.Contains("ClassesName"))
                tmp.ClassesName = dr["ClassesName"].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightclassesofdeptment">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FlightClassesOfDeptmentEntity flightclassesofdeptment, SqlParameter[] parms)
        {
            parms[0].Value = flightclassesofdeptment.DeptId;
            parms[1].Value = flightclassesofdeptment.ClassesId;
            parms[2].Value = flightclassesofdeptment.TimePeriodState;
            parms[3].Value = flightclassesofdeptment.TimePeriodEnd;
            parms[4].Value = flightclassesofdeptment.RowStatus;
            parms[5].Value = flightclassesofdeptment.CreatorId;
            parms[6].Value = flightclassesofdeptment.CreateBy;
            parms[7].Value = flightclassesofdeptment.CreateOn;
            parms[8].Value = flightclassesofdeptment.UpdateId;
            parms[9].Value = flightclassesofdeptment.UpdateBy;
            parms[10].Value = flightclassesofdeptment.UpdateOn;
            parms[11].Value = flightclassesofdeptment.OrderNo;
            parms[12].Value = flightclassesofdeptment.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FlightClassesOfDeptmentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite,
                                                                          Sql_FlightClassesOfDeptment_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_FlightClassesOfDeptment_DeptId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_ClassesId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_TimePeriodState, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_TimePeriodEnd, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_FlightClassesOfDeptment_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightClassesOfDeptment_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightClassesOfDeptment_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightClassesOfDeptment_OrderNo, SqlDbType.Int, 10),
                            new SqlParameter(Parm_FlightClassesOfDeptment_Id, SqlDbType.NVarChar, 50)

                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite,
                                                              Sql_FlightClassesOfDeptment_Insert, parms);
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

