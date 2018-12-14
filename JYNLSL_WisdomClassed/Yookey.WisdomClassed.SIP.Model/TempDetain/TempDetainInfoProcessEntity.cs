//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfo_ProcessEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/13 17:13:45
//  功能描述：TempDetainInfo_Process表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TempDetain
{
    /// <summary>
    /// 暂扣流程
    /// </summary>
    [Serializable]
    public class TempDetainInfoProcessEntity : ModelImp.BaseModel<TempDetainInfoProcessEntity>
    {
        public TempDetainInfoProcessEntity()
        {
            TB_Name = TB_TempDetainInfo_Process;
            Parm_Id = Parm_TempDetainInfo_Process_Id;
            Parm_Version = Parm_TempDetainInfo_Process_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TempDetainInfo_Process_Insert;
            Sql_Update = Sql_TempDetainInfo_Process_Update;
            Sql_Delete = Sql_TempDetainInfo_Process_Delete;
        }
        #region Const of table TempDetainInfo_Process
        /// <summary>
        /// Table TempDetainInfo_Process
        /// </summary>
        public const string TB_TempDetainInfo_Process = "TempDetainInfo_Process";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm After
        /// </summary>
        public const string Parm_TempDetainInfo_Process_After = "After";
        /// <summary>
        /// Parm Before
        /// </summary>
        public const string Parm_TempDetainInfo_Process_Before = "Before";
        /// <summary>
        /// Parm CaseTypeName
        /// </summary>
        public const string Parm_TempDetainInfo_Process_CaseTypeName = "CaseTypeName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TempDetainInfo_Process_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TempDetainInfo_Process_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TempDetainInfo_Process_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TempDetainInfo_Process_Id = "Id";
        /// <summary>
        /// Parm Idea
        /// </summary>
        public const string Parm_TempDetainInfo_Process_Idea = "Idea";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TempDetainInfo_Process_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TempDetainInfoId
        /// </summary>
        public const string Parm_TempDetainInfo_Process_TempDetainInfoId = "TempDetainInfoId";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TempDetainInfo_Process_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TempDetainInfo_Process_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TempDetainInfo_Process_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_TempDetainInfo_Process_UserId = "UserId";
        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_TempDetainInfo_Process_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainInfo_Process_Version = "Version";
        /// <summary>
        /// Insert Query Of TempDetainInfo_Process
        /// </summary>
        public const string Sql_TempDetainInfo_Process_Insert = "insert into TempDetainInfo_Process(After,Before,CaseTypeName,CreateBy,CreateOn,CreatorId,Idea,RowStatus,TempDetainInfoId,UpdateBy,UpdateId,UpdateOn,UserId,UserName,Id) values(@After,@Before,@CaseTypeName,@CreateBy,@CreateOn,@CreatorId,@Idea,@RowStatus,@TempDetainInfoId,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TempDetainInfo_Process
        /// </summary>
        public const string Sql_TempDetainInfo_Process_Update = "update TempDetainInfo_Process set After=@After,Before=@Before,CaseTypeName=@CaseTypeName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Idea=@Idea,RowStatus=@RowStatus,TempDetainInfoId=@TempDetainInfoId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserName=@UserName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TempDetainInfo_Process_Delete = "update TempDetainInfo_Process set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _tempDetainInfoId = string.Empty;
        /// <summary>
        /// 案件Id
        /// </summary>
        public string TempDetainInfoId
        {
            get { return _tempDetainInfoId ?? string.Empty; }
            set { _tempDetainInfoId = value; }
        }
        private string _caseTypeName = string.Empty;
        /// <summary>
        /// 案件类型名称
        /// </summary>
        public string CaseTypeName
        {
            get { return _caseTypeName ?? string.Empty; }
            set { _caseTypeName = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 处理人编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _userName = string.Empty;
        /// <summary>
        /// 处理人姓名
        /// </summary>
        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set { _userName = value; }
        }
        private string _before = string.Empty;
        /// <summary>
        /// 处理前状态
        /// </summary>
        public string Before
        {
            get { return _before ?? string.Empty; }
            set { _before = value; }
        }
        private string _after = string.Empty;
        /// <summary>
        /// 处理后状态
        /// </summary>
        public string After
        {
            get { return _after ?? string.Empty; }
            set { _after = value; }
        }
        private string _idea = string.Empty;
        /// <summary>
        /// 处理意见
        /// </summary>
        public string Idea
        {
            get { return _idea ?? string.Empty; }
            set { _idea = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override TempDetainInfoProcessEntity SetModelValueByDataRow(DataRow dr)
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
        public override TempDetainInfoProcessEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainInfoProcessEntity();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_Id) )
                tmp.Id = dr[Parm_TempDetainInfo_Process_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_TempDetainInfoId) )
                tmp.TempDetainInfoId = dr[Parm_TempDetainInfo_Process_TempDetainInfoId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_CaseTypeName) )
                tmp.CaseTypeName = dr[Parm_TempDetainInfo_Process_CaseTypeName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_UserId) )
                tmp.UserId = dr[Parm_TempDetainInfo_Process_UserId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_UserName) )
                tmp.UserName = dr[Parm_TempDetainInfo_Process_UserName].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_Before) )
                tmp.Before = dr[Parm_TempDetainInfo_Process_Before].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_After) )
                tmp.After = dr[Parm_TempDetainInfo_Process_After].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_Idea) )
                tmp.Idea = dr[Parm_TempDetainInfo_Process_Idea].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_RowStatus) )
                tmp.RowStatus = int.Parse(dr[Parm_TempDetainInfo_Process_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_Version) )
            {
                var bts = (byte[])(dr[Parm_TempDetainInfo_Process_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_CreatorId) )
                tmp.CreatorId = dr[Parm_TempDetainInfo_Process_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_CreateBy) )
                tmp.CreateBy = dr[Parm_TempDetainInfo_Process_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_CreateOn) )
                tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainInfo_Process_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_UpdateId) )
                tmp.UpdateId = dr[Parm_TempDetainInfo_Process_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_UpdateBy) )
                tmp.UpdateBy = dr[Parm_TempDetainInfo_Process_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_TempDetainInfo_Process_UpdateOn) )
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainInfo_Process_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetaininfo_process">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainInfoProcessEntity tempdetaininfo_process, SqlParameter[] parms)
        {
            parms[0].Value = tempdetaininfo_process.TempDetainInfoId;
            parms[1].Value = tempdetaininfo_process.CaseTypeName;
            parms[2].Value = tempdetaininfo_process.UserId;
            parms[3].Value = tempdetaininfo_process.UserName;
            parms[4].Value = tempdetaininfo_process.Before;
            parms[5].Value = tempdetaininfo_process.After;
            parms[6].Value = tempdetaininfo_process.Idea;
            parms[7].Value = tempdetaininfo_process.RowStatus;
            parms[8].Value = tempdetaininfo_process.CreatorId;
            parms[9].Value = tempdetaininfo_process.CreateBy;
            parms[10].Value = tempdetaininfo_process.CreateOn;
            parms[11].Value = tempdetaininfo_process.UpdateId;
            parms[12].Value = tempdetaininfo_process.UpdateBy;
            parms[13].Value = tempdetaininfo_process.UpdateOn;
            parms[14].Value = tempdetaininfo_process.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainInfoProcessEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Process_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_TempDetainInfo_Process_TempDetainInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_CaseTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_UserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_Before, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_After, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_Idea, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_TempDetainInfo_Process_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainInfo_Process_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainInfo_Process_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainInfo_Process_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TempDetainInfo_Process_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainInfo_Process_Insert, parms);
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

