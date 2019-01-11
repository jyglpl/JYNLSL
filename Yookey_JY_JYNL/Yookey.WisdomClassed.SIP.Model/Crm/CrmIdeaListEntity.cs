//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIdeaListEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 14:27:35
//  功能描述：CrmIdeaList表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CrmIdeaListEntity : ModelImp.BaseModel<CrmIdeaListEntity>
    {
        public CrmIdeaListEntity()
        {
            TB_Name = TB_CrmIdeaList;
            Parm_Id = Parm_CrmIdeaList_Id;
            Parm_Version = Parm_CrmIdeaList_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmIdeaList_Insert;
            Sql_Update = Sql_CrmIdeaList_Update;
            Sql_Delete = Sql_CrmIdeaList_Delete;
        }
        #region Const of table CrmIdeaList
        /// <summary>
        /// Table CrmIdeaList
        /// </summary>
        public const string TB_CrmIdeaList = "CrmIdeaList";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmIdeaList_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmIdeaList_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmIdeaList_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Duty
        /// </summary>
        public const string Parm_CrmIdeaList_Duty = "Duty";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmIdeaList_Id = "Id";
        /// <summary>
        /// Parm Idea
        /// </summary>
        public const string Parm_CrmIdeaList_Idea = "Idea";
        /// <summary>
        /// Parm LeveL
        /// </summary>
        public const string Parm_CrmIdeaList_LeveL = "LeveL";
        /// <summary>
        /// Parm ProcessID
        /// </summary>
        public const string Parm_CrmIdeaList_ProcessID = "ProcessID";
        /// <summary>
        /// Parm ProcessInstanceID
        /// </summary>
        public const string Parm_CrmIdeaList_ProcessInstanceID = "ProcessInstanceID";
        /// <summary>
        /// Parm ResourceID
        /// </summary>
        public const string Parm_CrmIdeaList_ResourceID = "ResourceID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmIdeaList_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Type
        /// </summary>
        public const string Parm_CrmIdeaList_Type = "Type";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmIdeaList_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmIdeaList_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmIdeaList_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_CrmIdeaList_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmIdeaList_Version = "Version";
        /// <summary>
        /// Parm WorkList
        /// </summary>
        public const string Parm_CrmIdeaList_WorkList = "WorkList";

        /// <summary>
        /// Parm UserName
        /// </summary>
        public const string Parm_CrmIdeaList_UserName = "UserName";

        /// <summary>
        /// Insert Query Of CrmIdeaList
        /// </summary>
        public const string Sql_CrmIdeaList_Insert = "insert into CrmIdeaList(CreateBy,CreateOn,CreatorId,Duty,Idea,LeveL,ProcessID,ProcessInstanceID,ResourceID,RowStatus,Type,UpdateBy,UpdateId,UpdateOn,UserId,WorkList) values(@CreateBy,@CreateOn,@CreatorId,@Duty,@Idea,@LeveL,@ProcessID,@ProcessInstanceID,@ResourceID,@RowStatus,@Type,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@WorkList);select @@identity;";
        /// <summary>
        /// Update Query Of CrmIdeaList
        /// </summary>
        public const string Sql_CrmIdeaList_Update = "update CrmIdeaList set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Duty=@Duty,Idea=@Idea,LeveL=@LeveL,ProcessID=@ProcessID,ProcessInstanceID=@ProcessInstanceID,ResourceID=@ResourceID,RowStatus=@RowStatus,Type=@Type,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,WorkList=@WorkList where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmIdeaList_Delete = "update CrmIdeaList set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _resourceID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ResourceID
        {
            get { return _resourceID ?? string.Empty; }
            set { _resourceID = value; }
        }
        private string _type = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get { return _type ?? string.Empty; }
            set { _type = value; }
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
        private string _idea = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Idea
        {
            get { return _idea ?? string.Empty; }
            set { _idea = value; }
        }
        private string _processID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ProcessID
        {
            get { return _processID ?? string.Empty; }
            set { _processID = value; }
        }
        private string _processInstanceID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ProcessInstanceID
        {
            get { return _processInstanceID ?? string.Empty; }
            set { _processInstanceID = value; }
        }
        private string _workList = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WorkList
        {
            get { return _workList ?? string.Empty; }
            set { _workList = value; }
        }
        private string _leveL;
        /// <summary>
        /// 
        /// </summary>
        public string LeveL
        {
            get { return _leveL; }
            set { _leveL = value; }
        }
        private string _duty = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Duty
        {
            get { return _duty ?? string.Empty; }
            set { _duty = value; }
        }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string UserName { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmIdeaListEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmIdeaListEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmIdeaListEntity();
            if (fields.Contains(Parm_CrmIdeaList_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmIdeaList_Id].ToString();
            if (fields.Contains(Parm_CrmIdeaList_ResourceID) || fields.Contains("*"))
                tmp.ResourceID = dr[Parm_CrmIdeaList_ResourceID].ToString();
            if (fields.Contains(Parm_CrmIdeaList_Type) || fields.Contains("*"))
                tmp.Type = dr[Parm_CrmIdeaList_Type].ToString();
            if (fields.Contains(Parm_CrmIdeaList_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_CrmIdeaList_UserId].ToString();
            if (fields.Contains(Parm_CrmIdeaList_Idea) || fields.Contains("*"))
                tmp.Idea = dr[Parm_CrmIdeaList_Idea].ToString();
            if (fields.Contains(Parm_CrmIdeaList_ProcessID) || fields.Contains("*"))
                tmp.ProcessID = dr[Parm_CrmIdeaList_ProcessID].ToString();
            if (fields.Contains(Parm_CrmIdeaList_ProcessInstanceID) || fields.Contains("*"))
                tmp.ProcessInstanceID = dr[Parm_CrmIdeaList_ProcessInstanceID].ToString();
            if (fields.Contains(Parm_CrmIdeaList_WorkList) || fields.Contains("*"))
                tmp.WorkList = dr[Parm_CrmIdeaList_WorkList].ToString();
            if (fields.Contains(Parm_CrmIdeaList_LeveL) || fields.Contains("*"))
                tmp.LeveL = dr[Parm_CrmIdeaList_LeveL].ToString();
            if (fields.Contains(Parm_CrmIdeaList_Duty) || fields.Contains("*"))
                tmp.Duty = dr[Parm_CrmIdeaList_Duty].ToString();
            if (fields.Contains(Parm_CrmIdeaList_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmIdeaList_RowStatus].ToString());
            if (fields.Contains(Parm_CrmIdeaList_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_CrmIdeaList_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_CrmIdeaList_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmIdeaList_CreatorId].ToString();
            if (fields.Contains(Parm_CrmIdeaList_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmIdeaList_CreateBy].ToString();
            if (fields.Contains(Parm_CrmIdeaList_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmIdeaList_CreateOn].ToString());
            if (fields.Contains(Parm_CrmIdeaList_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmIdeaList_UpdateId].ToString();
            if (fields.Contains(Parm_CrmIdeaList_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmIdeaList_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmIdeaList_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmIdeaList_UpdateOn].ToString());
            if (fields.Contains(Parm_CrmIdeaList_UserName) || fields.Contains("*"))
                tmp.UserName = dr[Parm_CrmIdeaList_UserName].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmidealist">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmIdeaListEntity crmidealist, SqlParameter[] parms)
        {
            parms[0].Value = crmidealist.ResourceID;
            parms[1].Value = crmidealist.Type;
            parms[2].Value = crmidealist.UserId;
            parms[3].Value = crmidealist.Idea;
            parms[4].Value = crmidealist.ProcessID;
            parms[5].Value = crmidealist.ProcessInstanceID;
            parms[6].Value = crmidealist.WorkList;
            parms[7].Value = crmidealist.LeveL;
            parms[8].Value = crmidealist.Duty;
            parms[9].Value = crmidealist.RowStatus;
            parms[10].Value = crmidealist.CreatorId;
            parms[11].Value = crmidealist.CreateBy;
            parms[12].Value = crmidealist.CreateOn;
            parms[13].Value = crmidealist.UpdateId;
            parms[14].Value = crmidealist.UpdateBy;
            parms[15].Value = crmidealist.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmIdeaListEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_CrmIdeaList_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_CrmIdeaList_Version, model.Version);
            return parms;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmIdeaList_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmIdeaList_ResourceID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_Type, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_Idea, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmIdeaList_ProcessID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_ProcessInstanceID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_WorkList, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_LeveL, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIdeaList_Duty, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmIdeaList_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmIdeaList_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmIdeaList_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmIdeaList_Insert, parms);
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

