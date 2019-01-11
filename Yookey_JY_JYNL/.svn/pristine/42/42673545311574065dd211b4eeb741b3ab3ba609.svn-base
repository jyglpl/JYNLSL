//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CASE_COLLECTEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/25 10:12:25
//  功能描述：INF_CASE_COLLECT表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Case
{
    /// <summary>
    /// 其他类案件汇总
    /// </summary>
    [Serializable]
    public class InfCaseCollectEntity : ModelImp.BaseModel<InfCaseCollectEntity>
    {
        public enum CaseType
        {

            /// <summary>
            /// 现场纠处
            /// </summary>
            SitePunishment = 1,
            /// <summary>
            /// 违章建筑
            /// </summary>
            Structures,
            /// <summary>
            /// 户外广告
            /// </summary>
            OutdoorAd
        }

        public InfCaseCollectEntity()
        {
            TB_Name = TB_INF_CASE_COLLECT;
            Parm_Id = Parm_INF_CASE_COLLECT_Id;
            Parm_Version = Parm_INF_CASE_COLLECT_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_CASE_COLLECT_Insert;
            Sql_Update = Sql_INF_CASE_COLLECT_Update;
            Sql_Delete = Sql_INF_CASE_COLLECT_Delete;
        }
        /// <summary>
        /// 构造函数
        /// 创建人：周庆
        /// 创建日期：2015年5月26日
        /// </summary>
        /// <param name="reader"></param>
        public InfCaseCollectEntity(SqlDataReader reader):this()
        {
            Id = reader["Id"].ToString();
            DeptId = reader["DeptId"].ToString();
            ClassesNo = reader["ClassesNo"].ToString();
            TypeNo = Convert.ToInt32(reader["TypeNo"]);
            Number = Convert.ToInt32(reader["Number"]);
            Area = Convert.ToDecimal(reader["Area"]);
            ReportingPeriod = Convert.ToDateTime(reader["ReportingPeriod"]);
            RowStatus = Convert.ToInt32(reader["RowStatus"]);
            CreatorId = reader["CreatorId"].ToString();
            CreateBy = reader["CreateBy"].ToString();
            CreateOn = Convert.ToDateTime(reader["CreateOn"]);
            UpdateId = reader["UpdateId"].ToString();
            UpdateBy = reader["UpdateBy"].ToString();
            UpdateOn = Convert.ToDateTime(reader["UpdateOn"]);
        }
        #region Const of table INF_CASE_COLLECT
        /// <summary>
        /// Table INF_CASE_COLLECT
        /// </summary>
        public const string TB_INF_CASE_COLLECT = "INF_CASE_COLLECT";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Area
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_Area = "Area";
        /// <summary>
        /// Parm ClassesNo
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_ClassesNo = "ClassesNo";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_DeptId = "DeptId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_Id = "Id";
        /// <summary>
        /// Parm Number
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_Number = "Number";
        /// <summary>
        /// Parm ReportingPeriod
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_ReportingPeriod = "ReportingPeriod";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TypeNo
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_TypeNo = "TypeNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_CASE_COLLECT_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_CASE_COLLECT
        /// </summary>
        public const string Sql_INF_CASE_COLLECT_Insert = "insert into INF_CASE_COLLECT(Area,ClassesNo,CreateBy,CreateOn,CreatorId,DeptId,Number,ReportingPeriod,RowStatus,TypeNo,UpdateBy,UpdateId,UpdateOn,Id) values(@Area,@ClassesNo,@CreateBy,@CreateOn,@CreatorId,@DeptId,@Number,@ReportingPeriod,@RowStatus,@TypeNo,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_CASE_COLLECT
        /// </summary>
        public const string Sql_INF_CASE_COLLECT_Update = "update INF_CASE_COLLECT set Area=@Area,ClassesNo=@ClassesNo,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,Number=@Number,ReportingPeriod=@ReportingPeriod,RowStatus=@RowStatus,TypeNo=@TypeNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_CASE_COLLECT_Delete = "update INF_CASE_COLLECT set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _classesNo = string.Empty;
        /// <summary>
        /// 所属类型
        /// </summary>
        public string ClassesNo
        {
            get { return _classesNo ?? string.Empty; }
            set { _classesNo = value; }
        }
        private int _typeNo;
        /// <summary>
        /// 1：现场纠处，2：拆除违章建筑，3：拆除户外广告
        /// </summary>
        public int TypeNo
        {
            get { return _typeNo; }
            set { _typeNo = value; }
        }
        private int _number;
        /// <summary>
        /// 数量
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        private decimal _area;
        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area
        {
            get { return _area; }
            set { _area = value; }
        }
        private DateTime _reportingPeriod = MinDate;
        /// <summary>
        /// 所属月份
        /// </summary>
        public DateTime ReportingPeriod
        {
            get { return _reportingPeriod; }
            set { _reportingPeriod = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfCaseCollectEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfCaseCollectEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfCaseCollectEntity();
            if (fields.Contains(Parm_INF_CASE_COLLECT_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_CASE_COLLECT_Id].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_DeptId) || fields.Contains("*"))
                tmp.DeptId = dr[Parm_INF_CASE_COLLECT_DeptId].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_ClassesNo) || fields.Contains("*"))
                tmp.ClassesNo = dr[Parm_INF_CASE_COLLECT_ClassesNo].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_TypeNo) || fields.Contains("*"))
                tmp.TypeNo = int.Parse(dr[Parm_INF_CASE_COLLECT_TypeNo].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_Number) || fields.Contains("*"))
                tmp.Number = int.Parse(dr[Parm_INF_CASE_COLLECT_Number].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_Area) || fields.Contains("*"))
                tmp.Area = decimal.Parse(dr[Parm_INF_CASE_COLLECT_Area].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_ReportingPeriod) || fields.Contains("*"))
                tmp.ReportingPeriod = DateTime.Parse(dr[Parm_INF_CASE_COLLECT_ReportingPeriod].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_CASE_COLLECT_RowStatus].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_CASE_COLLECT_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_CASE_COLLECT_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_CASE_COLLECT_CreatorId].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_CASE_COLLECT_CreateBy].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_CASE_COLLECT_CreateOn].ToString());
            if (fields.Contains(Parm_INF_CASE_COLLECT_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_CASE_COLLECT_UpdateId].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_CASE_COLLECT_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_CASE_COLLECT_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_CASE_COLLECT_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_case_collect">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfCaseCollectEntity inf_case_collect, SqlParameter[] parms)
        {
            parms[0].Value = inf_case_collect.DeptId;
            parms[1].Value = inf_case_collect.ClassesNo;
            parms[2].Value = inf_case_collect.TypeNo;
            parms[3].Value = inf_case_collect.Number;
            parms[4].Value = inf_case_collect.Area;
            parms[5].Value = inf_case_collect.ReportingPeriod;
            parms[6].Value = inf_case_collect.RowStatus;
            parms[7].Value = inf_case_collect.CreatorId;
            parms[8].Value = inf_case_collect.CreateBy;
            parms[9].Value = inf_case_collect.CreateOn;
            parms[10].Value = inf_case_collect.UpdateId;
            parms[11].Value = inf_case_collect.UpdateBy;
            parms[12].Value = inf_case_collect.UpdateOn;
            parms[13].Value = inf_case_collect.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfCaseCollectEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CASE_COLLECT_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_CASE_COLLECT_DeptId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_ClassesNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_TypeNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CASE_COLLECT_Number, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CASE_COLLECT_Area, SqlDbType.Decimal, 18),
					new SqlParameter(Parm_INF_CASE_COLLECT_ReportingPeriod, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CASE_COLLECT_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_CASE_COLLECT_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_CASE_COLLECT_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_UpdateBy, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_INF_CASE_COLLECT_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_CASE_COLLECT_Id, SqlDbType.VarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_CASE_COLLECT_Insert, parms);
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

