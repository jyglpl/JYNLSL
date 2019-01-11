//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightOfEmpEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/17 17:04:46
//  功能描述：FlightOfEmp表实体
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
    /// 排班人员对应表
    /// </summary>
    [Serializable]
    public class FlightOfEmpEntity : ModelImp.BaseModel<FlightOfEmpEntity>
    {
        public FlightOfEmpEntity()
        {
            TB_Name = TB_FlightOfEmp;
            Parm_Id = Parm_FlightOfEmp_Id;
            Parm_Version = Parm_FlightOfEmp_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FlightOfEmp_Insert;
            Sql_Update = Sql_FlightOfEmp_Update;
            Sql_Delete = Sql_FlightOfEmp_Delete;
        }
        #region Const of table FlightOfEmp
        /// <summary>
        /// Table FlightOfEmp
        /// </summary>
        public const string TB_FlightOfEmp = "FlightOfEmp";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FlightOfEmp_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FlightOfEmp_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FlightOfEmp_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FlightOfEmp_Id = "Id";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_FlightOfEmp_OrderNo = "OrderNo";
        /// <summary>
        /// Parm ParticularId
        /// </summary>
        public const string Parm_FlightOfEmp_ParticularId = "ParticularId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FlightOfEmp_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FlightOfEmp_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FlightOfEmp_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FlightOfEmp_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_FlightOfEmp_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FlightOfEmp_Version = "Version";
        /// <summary>
        /// Insert Query Of FlightOfEmp
        /// </summary>
        public const string Sql_FlightOfEmp_Insert = "insert into FlightOfEmp(CreateBy,CreateOn,CreatorId,OrderNo,ParticularId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,Id) values(@CreateBy,@CreateOn,@CreatorId,@OrderNo,@ParticularId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FlightOfEmp
        /// </summary>
        public const string Sql_FlightOfEmp_Update = "update FlightOfEmp set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OrderNo=@OrderNo,ParticularId=@ParticularId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FlightOfEmp_Delete = "update FlightOfEmp set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _particularId = string.Empty;
        /// <summary>
        /// 对应明细表ID
        /// </summary>
        public string ParticularId
        {
            get { return _particularId ?? string.Empty; }
            set { _particularId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 人员编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private int _orderNo;
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FlightOfEmpEntity SetModelValueByDataRow(DataRow dr)
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
        public override FlightOfEmpEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightOfEmpEntity();
            if (fields.Contains(Parm_FlightOfEmp_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FlightOfEmp_Id].ToString();
            if (fields.Contains(Parm_FlightOfEmp_ParticularId) || fields.Contains("*"))
                tmp.ParticularId = dr[Parm_FlightOfEmp_ParticularId].ToString();
            if (fields.Contains(Parm_FlightOfEmp_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_FlightOfEmp_UserId].ToString();
            if (fields.Contains(Parm_FlightOfEmp_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_FlightOfEmp_OrderNo].ToString());
            if (fields.Contains(Parm_FlightOfEmp_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FlightOfEmp_RowStatus].ToString());
            if (fields.Contains(Parm_FlightOfEmp_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FlightOfEmp_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FlightOfEmp_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FlightOfEmp_CreatorId].ToString();
            if (fields.Contains(Parm_FlightOfEmp_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FlightOfEmp_CreateBy].ToString();
            if (fields.Contains(Parm_FlightOfEmp_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FlightOfEmp_CreateOn].ToString());
            if (fields.Contains(Parm_FlightOfEmp_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FlightOfEmp_UpdateId].ToString();
            if (fields.Contains(Parm_FlightOfEmp_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FlightOfEmp_UpdateBy].ToString();
            if (fields.Contains(Parm_FlightOfEmp_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightOfEmp_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightofemp">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FlightOfEmpEntity flightofemp, SqlParameter[] parms)
        {
            parms[0].Value = flightofemp.ParticularId;
            parms[1].Value = flightofemp.UserId;
            parms[2].Value = flightofemp.OrderNo;
            parms[3].Value = flightofemp.RowStatus;
            parms[4].Value = flightofemp.CreatorId;
            parms[5].Value = flightofemp.CreateBy;
            parms[6].Value = flightofemp.CreateOn;
            parms[7].Value = flightofemp.UpdateId;
            parms[8].Value = flightofemp.UpdateBy;
            parms[9].Value = flightofemp.UpdateOn;
            parms[10].Value = flightofemp.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FlightOfEmpEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightOfEmp_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FlightOfEmp_ParticularId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightOfEmp_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FlightOfEmp_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FlightOfEmp_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FlightOfEmp_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FlightOfEmp_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightOfEmp_Insert, parms);
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

