//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementStandardEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:35
//  功能描述：TeamManagementStandard表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TeamManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class TeamManagementStandardEntity : ModelImp.BaseModel<TeamManagementStandardEntity>
    {
        public TeamManagementStandardEntity()
        {
            TB_Name = TB_TeamManagementStandard;
            Parm_Id = Parm_TeamManagementStandard_Id;
            Parm_Version = Parm_TeamManagementStandard_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TeamManagementStandard_Insert;
            Sql_Update = Sql_TeamManagementStandard_Update;
            Sql_Delete = Sql_TeamManagementStandard_Delete;
        }
        #region Const of table TeamManagementStandard
        /// <summary>
        /// Table TeamManagementStandard
        /// </summary>
        public const string TB_TeamManagementStandard = "TeamManagementStandard";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ClassTypeId
        /// </summary>
        public const string Parm_TeamManagementStandard_ClassTypeId = "ClassTypeId";
        /// <summary>
        /// Parm ClassTypeIdName
        /// </summary>
        public const string Parm_TeamManagementStandard_ClassTypeIdName = "ClassTypeIdName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TeamManagementStandard_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TeamManagementStandard_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TeamManagementStandard_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TeamManagementStandard_Id = "Id";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_TeamManagementStandard_OrderNo = "OrderNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TeamManagementStandard_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StandardContent
        /// </summary>
        public const string Parm_TeamManagementStandard_StandardContent = "StandardContent";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TeamManagementStandard_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TeamManagementStandard_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TeamManagementStandard_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TeamManagementStandard_Version = "Version";
        /// <summary>
        /// Insert Query Of TeamManagementStandard
        /// </summary>
        public const string Sql_TeamManagementStandard_Insert = "insert into TeamManagementStandard(ClassTypeId,ClassTypeIdName,CreateBy,CreateOn,CreatorId,OrderNo,RowStatus,StandardContent,UpdateBy,UpdateId,UpdateOn,Id) values(@ClassTypeId,@ClassTypeIdName,@CreateBy,@CreateOn,@CreatorId,@OrderNo,@RowStatus,@StandardContent,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TeamManagementStandard
        /// </summary>
        public const string Sql_TeamManagementStandard_Update = "update TeamManagementStandard set ClassTypeId=@ClassTypeId,ClassTypeIdName=@ClassTypeIdName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OrderNo=@OrderNo,RowStatus=@RowStatus,StandardContent=@StandardContent,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TeamManagementStandard_Delete = "update TeamManagementStandard set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _classTypeId = string.Empty;
        /// <summary>
        /// 考核评分内容Id
        /// </summary>
        public string ClassTypeId
        {
            get { return _classTypeId ?? string.Empty; }
            set { _classTypeId = value; }
        }
        private string _classTypeIdName = string.Empty;
        /// <summary>
        /// 评分内容
        /// </summary>
        public string ClassTypeIdName
        {
            get { return _classTypeIdName ?? string.Empty; }
            set { _classTypeIdName = value; }
        }
        private string _standardContent = string.Empty;
        /// <summary>
        /// 考评标准
        /// </summary>
        public string StandardContent
        {
            get { return _standardContent ?? string.Empty; }
            set { _standardContent = value; }
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
        public override TeamManagementStandardEntity SetModelValueByDataRow(DataRow dr)
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
        public override TeamManagementStandardEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TeamManagementStandardEntity();
            if (fields.Contains(Parm_TeamManagementStandard_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_TeamManagementStandard_Id].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_ClassTypeId) || fields.Contains("*"))
                tmp.ClassTypeId = dr[Parm_TeamManagementStandard_ClassTypeId].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_ClassTypeIdName) || fields.Contains("*"))
                tmp.ClassTypeIdName = dr[Parm_TeamManagementStandard_ClassTypeIdName].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_StandardContent) || fields.Contains("*"))
                tmp.StandardContent = dr[Parm_TeamManagementStandard_StandardContent].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_TeamManagementStandard_OrderNo].ToString());
            if (fields.Contains(Parm_TeamManagementStandard_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_TeamManagementStandard_RowStatus].ToString());
            if (fields.Contains(Parm_TeamManagementStandard_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_TeamManagementStandard_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_TeamManagementStandard_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_TeamManagementStandard_CreatorId].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_TeamManagementStandard_CreateBy].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TeamManagementStandard_CreateOn].ToString());
            if (fields.Contains(Parm_TeamManagementStandard_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_TeamManagementStandard_UpdateId].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_TeamManagementStandard_UpdateBy].ToString();
            if (fields.Contains(Parm_TeamManagementStandard_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TeamManagementStandard_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="teammanagementstandard">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TeamManagementStandardEntity teammanagementstandard, SqlParameter[] parms)
        {
            parms[0].Value = teammanagementstandard.ClassTypeId;
            parms[1].Value = teammanagementstandard.ClassTypeIdName;
            parms[2].Value = teammanagementstandard.StandardContent;
            parms[3].Value = teammanagementstandard.OrderNo;
            parms[4].Value = teammanagementstandard.RowStatus;
            parms[5].Value = teammanagementstandard.CreatorId;
            parms[6].Value = teammanagementstandard.CreateBy;
            parms[7].Value = teammanagementstandard.CreateOn;
            parms[8].Value = teammanagementstandard.UpdateId;
            parms[9].Value = teammanagementstandard.UpdateBy;
            parms[10].Value = teammanagementstandard.UpdateOn;
            parms[11].Value = teammanagementstandard.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TeamManagementStandardEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementStandard_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_TeamManagementStandard_ClassTypeId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TeamManagementStandard_ClassTypeIdName, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_TeamManagementStandard_StandardContent, SqlDbType.VarChar, 200),
                            new SqlParameter(Parm_TeamManagementStandard_OrderNo, SqlDbType.Int, 10),
                            new SqlParameter(Parm_TeamManagementStandard_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_TeamManagementStandard_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TeamManagementStandard_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TeamManagementStandard_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_TeamManagementStandard_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TeamManagementStandard_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_TeamManagementStandard_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_TeamManagementStandard_Id, SqlDbType.NVarChar, 50)

                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TeamManagementStandard_Insert, parms);
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

