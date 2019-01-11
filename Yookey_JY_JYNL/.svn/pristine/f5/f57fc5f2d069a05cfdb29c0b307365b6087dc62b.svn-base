//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightAlterationEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/13 14:31:45
//  功能描述：FlightAlteration表实体
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
    /// 调班
    /// </summary>
    [Serializable]
    public class FlightAlterationEntity : ModelImp.BaseModel<FlightAlterationEntity>
    {
        public FlightAlterationEntity()
        {
            TB_Name = TB_FlightAlteration;
            Parm_Id = Parm_FlightAlteration_Id;
            Parm_Version = Parm_FlightAlteration_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FlightAlteration_Insert;
            Sql_Update = Sql_FlightAlteration_Update;
            Sql_Delete = Sql_FlightAlteration_Delete;
        }
        #region Const of table FlightAlteration
        /// <summary>
        /// Table FlightAlteration
        /// </summary>
        public const string TB_FlightAlteration = "FlightAlteration";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AferUserId
        /// </summary>
        public const string Parm_FlightAlteration_AferUserId = "AferUserId";
        /// <summary>
        /// Parm AfterDate
        /// </summary>
        public const string Parm_FlightAlteration_AfterDate = "AfterDate";
        /// <summary>
        /// Parm AfterClassesId
        /// </summary>
        public const string Parm_FlightAlteration_AfterClassesId = "AfterClassesId";
        /// <summary>
        /// Parm AfterClassesName
        /// </summary>
        public const string Parm_FlightAlteration_AfterClassesName = "AfterClassesName";
        /// <summary>
        /// <summary>
        /// Parm AfterUserName
        /// </summary>
        public const string Parm_FlightAlteration_AfterUserName = "AfterUserName";
        /// <summary>
        /// Parm BeforeDate
        /// </summary>
        public const string Parm_FlightAlteration_BeforeDate = "BeforeDate";
        /// <summary>
        /// Parm BeforeClassesId
        /// </summary>
        public const string Parm_FlightAlteration_BeforeClassesId = "BeforeClassesId";
        /// <summary>
        /// Parm BeforeClassesName
        /// </summary>
        public const string Parm_FlightAlteration_BeforeClassesName = "BeforeClassesName";
        /// <summary>
        /// Parm BeforeUserId
        /// </summary>
        public const string Parm_FlightAlteration_BeforeUserId = "BeforeUserId";
        /// <summary>
        /// Parm BeforeUserName
        /// </summary>
        public const string Parm_FlightAlteration_BeforeUserName = "BeforeUserName";
        /// <summary>
        /// Parm CompanyId
        /// </summary>
        public const string Parm_FlightAlteration_CompanyId = "CompanyId";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_FlightAlteration_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FlightAlteration_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FlightAlteration_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FlightAlteration_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DeptId
        /// </summary>
        public const string Parm_FlightAlteration_DeptId = "DeptId";
        /// <summary>
        /// Parm DeptName
        /// </summary>
        public const string Parm_FlightAlteration_DeptName = "DeptName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FlightAlteration_Id = "Id";
        /// <summary>
        /// Parm Reason
        /// </summary>
        public const string Parm_FlightAlteration_Reason = "Reason";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_FlightAlteration_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FlightAlteration_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_FlightAlteration_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FlightAlteration_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FlightAlteration_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FlightAlteration_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FlightAlteration_Version = "Version";
        /// <summary>
        /// Insert Query Of FlightAlteration
        /// </summary>
        public const string Sql_FlightAlteration_Insert = "insert into FlightAlteration(AferUserId,AfterDate,AfterClassesId,AfterClassesName,AfterUserName,BeforeDate,BeforeClassesId,BeforeClassesName,BeforeUserId,BeforeUserName,CompanyId,CompanyName,CreateBy,CreateOn,CreatorId,DeptId,DeptName,Reason,Remark,RowStatus,Status,UpdateBy,UpdateId,UpdateOn,Id) values(@AferUserId,@AfterDate,@AfterClassesId,@AfterClassesName,@AfterUserName,@BeforeDate,@BeforeClassesId,@BeforeClassesName,@BeforeUserId,@BeforeUserName,@CompanyId,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@DeptId,@DeptName,@Reason,@Remark,@RowStatus,@Status,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FlightAlteration
        /// </summary>
        public const string Sql_FlightAlteration_Update = "update FlightAlteration set AferUserId=@AferUserId,AfterDate=@AfterDate,AfterClassesId=@AfterClassesId,AfterClassesName=@AfterClassesName,AfterUserName=@AfterUserName,BeforeDate=@BeforeDate,BeforeClassesId=@BeforeClassesId,BeforeClassesName=@BeforeClassesName,BeforeUserId=@BeforeUserId,BeforeUserName=@BeforeUserName,CompanyId=@CompanyId,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DeptId=@DeptId,DeptName=@DeptName,Reason=@Reason,Remark=@Remark,RowStatus=@RowStatus,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FlightAlteration_Delete = "update FlightAlteration set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _deptId = string.Empty;
        /// <summary>
        /// 部门编号
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
        private string _beforeUserId = string.Empty;
        /// <summary>
        /// 调班前人员编号
        /// </summary>
        public string BeforeUserId
        {
            get { return _beforeUserId ?? string.Empty; }
            set { _beforeUserId = value; }
        }
        private string _beforeUserName = string.Empty;
        /// <summary>
        /// 调班前人员名称
        /// </summary>
        public string BeforeUserName
        {
            get { return _beforeUserName ?? string.Empty; }
            set { _beforeUserName = value; }
        }
        private string _aferUserId = string.Empty;
        /// <summary>
        /// 调班后人员编号
        /// </summary>
        public string AferUserId
        {
            get { return _aferUserId ?? string.Empty; }
            set { _aferUserId = value; }
        }
        private string _afterUserName = string.Empty;
        /// <summary>
        /// 调班后人员姓名
        /// </summary>
        public string AfterUserName
        {
            get { return _afterUserName ?? string.Empty; }
            set { _afterUserName = value; }
        }
        private DateTime _beforeDate = MinDate;
        /// <summary>
        /// 调班前时间
        /// </summary>
        public DateTime BeforeDate
        {
            get { return _beforeDate; }
            set { _beforeDate = value; }
        }
        private string _beforeClassesId;
        /// <summary>
        /// 
        /// </summary>
        public string BeforeClassesId
        {
            get { return _beforeClassesId; }
            set { _beforeClassesId = value; }
        }

        private string _beforeClassesName;
        /// <summary>
        /// 
        /// </summary>
        public string BeforeClassesName
        {
            get { return _beforeClassesName; }
            set { _beforeClassesName = value; }
        }

        private DateTime _afterDate = MinDate;
        /// <summary>
        /// 调班后时间
        /// </summary>
        public DateTime AfterDate
        {
            get { return _afterDate; }
            set { _afterDate = value; }
        }

        private string _afterClassesId;
        /// <summary>
        /// 
        /// </summary>
        public string AfterClassesId
        {
            get { return _afterClassesId; }
            set { _afterClassesId = value; }
        }

        private string _afterClassesName;
        /// <summary>
        /// 
        /// </summary>
        public string AfterClassesName
        {
            get { return _afterClassesName; }
            set { _afterClassesName = value; }

        }
        private string _reason = string.Empty;
        /// <summary>
        /// 调班原因
        /// </summary>
        public string Reason
        {
            get { return _reason ?? string.Empty; }
            set { _reason = value; }
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
        /// 状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        #region 扩展属性

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string Keywords { get; set; }

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
        public override FlightAlterationEntity SetModelValueByDataRow(DataRow dr)
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
        public override FlightAlterationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FlightAlterationEntity();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_Id))
                tmp.Id = dr[Parm_FlightAlteration_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_CompanyId))
                tmp.CompanyId = dr[Parm_FlightAlteration_CompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_CompanyName))
                tmp.CompanyName = dr[Parm_FlightAlteration_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_DeptId))
                tmp.DeptId = dr[Parm_FlightAlteration_DeptId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_DeptName))
                tmp.DeptName = dr[Parm_FlightAlteration_DeptName].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_BeforeUserId))
                tmp.BeforeUserId = dr[Parm_FlightAlteration_BeforeUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_BeforeUserName))
                tmp.BeforeUserName = dr[Parm_FlightAlteration_BeforeUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_AferUserId))
                tmp.AferUserId = dr[Parm_FlightAlteration_AferUserId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_AfterUserName))
                tmp.AfterUserName = dr[Parm_FlightAlteration_AfterUserName].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_BeforeDate))
                tmp.BeforeDate = DateTime.Parse(dr[Parm_FlightAlteration_BeforeDate].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_BeforeClassesId))
                tmp.BeforeClassesId = dr[Parm_FlightAlteration_BeforeClassesId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_BeforeClassesName))
                tmp.BeforeClassesName = dr[Parm_FlightAlteration_BeforeClassesName].ToString();

            if (dr.Table.Columns.Contains(Parm_FlightAlteration_AfterDate))
                tmp.AfterDate = DateTime.Parse(dr[Parm_FlightAlteration_AfterDate].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_AfterClassesId))
                tmp.AfterClassesId = dr[Parm_FlightAlteration_AfterClassesId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_AfterClassesName))
                tmp.AfterClassesName = dr[Parm_FlightAlteration_AfterClassesName].ToString();

            if (dr.Table.Columns.Contains(Parm_FlightAlteration_Reason))
                tmp.Reason = dr[Parm_FlightAlteration_Reason].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_Remark))
                tmp.Remark = dr[Parm_FlightAlteration_Remark].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_Status))
                tmp.Status = int.Parse(dr[Parm_FlightAlteration_Status].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_FlightAlteration_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_Version))
            {
                var bts = (byte[])(dr[Parm_FlightAlteration_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_CreatorId))
                tmp.CreatorId = dr[Parm_FlightAlteration_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_CreateBy))
                tmp.CreateBy = dr[Parm_FlightAlteration_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FlightAlteration_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_UpdateId))
                tmp.UpdateId = dr[Parm_FlightAlteration_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_UpdateBy))
                tmp.UpdateBy = dr[Parm_FlightAlteration_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_FlightAlteration_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FlightAlteration_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="flightalteration">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FlightAlterationEntity flightalteration, SqlParameter[] parms)
        {
            parms[0].Value = flightalteration.CompanyId;
            parms[1].Value = flightalteration.CompanyName;
            parms[2].Value = flightalteration.DeptId;
            parms[3].Value = flightalteration.DeptName;
            parms[4].Value = flightalteration.BeforeUserId;
            parms[5].Value = flightalteration.BeforeUserName;
            parms[6].Value = flightalteration.AferUserId;
            parms[7].Value = flightalteration.AfterUserName;
            parms[8].Value = flightalteration.BeforeDate;
            parms[9].Value = flightalteration.BeforeClassesId;
            parms[10].Value = flightalteration.BeforeClassesName;
            parms[11].Value = flightalteration.AfterDate;
            parms[12].Value = flightalteration.AfterClassesId;
            parms[13].Value = flightalteration.AfterClassesName;
            parms[14].Value = flightalteration.Reason;
            parms[15].Value = flightalteration.Remark;
            parms[16].Value = flightalteration.Status;
            parms[17].Value = flightalteration.RowStatus;
            parms[18].Value = flightalteration.CreatorId;
            parms[19].Value = flightalteration.CreateBy;
            parms[20].Value = flightalteration.CreateOn;
            parms[21].Value = flightalteration.UpdateId;
            parms[22].Value = flightalteration.UpdateBy;
            parms[23].Value = flightalteration.UpdateOn;
            parms[24].Value = flightalteration.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FlightAlterationEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightAlteration_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_FlightAlteration_CompanyId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_CompanyName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_DeptId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_DeptName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_BeforeUserId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_BeforeUserName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_AferUserId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_AfterUserName, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_BeforeDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightAlteration_BeforeClassesId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_BeforeClassesName, SqlDbType.NVarChar, 50),

                            new SqlParameter(Parm_FlightAlteration_AfterDate, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightAlteration_AfterClassesId, SqlDbType.NVarChar, 50),
                             new SqlParameter(Parm_FlightAlteration_AfterClassesName, SqlDbType.NVarChar, 50),

                            new SqlParameter(Parm_FlightAlteration_Reason, SqlDbType.NVarChar, 500),
                            new SqlParameter(Parm_FlightAlteration_Remark, SqlDbType.NVarChar, 500),
                            new SqlParameter(Parm_FlightAlteration_Status, SqlDbType.Int, 10),
                            new SqlParameter(Parm_FlightAlteration_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_FlightAlteration_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightAlteration_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_FlightAlteration_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_FlightAlteration_Id, SqlDbType.NVarChar, 50)

                        };

                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FlightAlteration_Insert, parms);
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

