//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DISCUSSEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2018/11/02 14:09:57
//  功能描述：INF_PUNISH_DISCUSS表实体
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
    /// 案审、集体讨论
    /// </summary>
    [Serializable]
    public class InfPunishDiscussEntity : ModelImp.BaseModel<InfPunishDiscussEntity>
    {
        public InfPunishDiscussEntity()
        {
            TB_Name = TB_INF_PUNISH_DISCUSS;
            Parm_Id = Parm_INF_PUNISH_DISCUSS_Id;
            Parm_Version = Parm_INF_PUNISH_DISCUSS_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_PUNISH_DISCUSS_Insert;
            Sql_Update = Sql_INF_PUNISH_DISCUSS_Update;
            Sql_Delete = Sql_INF_PUNISH_DISCUSS_Delete;
        }
        #region Const of table INF_PUNISH_DISCUSS
        /// <summary>
        /// Table INF_PUNISH_DISCUSS
        /// </summary>
        public const string TB_INF_PUNISH_DISCUSS = "INF_PUNISH_DISCUSS";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CaseInfoId
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_CaseInfoId = "CaseInfoId";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DiscussType
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_DiscussType = "DiscussType";
        /// <summary>
        /// Parm EndTime
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_EndTime = "EndTime";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_Id = "Id";
        /// <summary>
        /// Parm MemberList
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_MemberList = "MemberList";
        /// <summary>
        /// Parm MemberName
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_MemberName = "MemberName";
        /// <summary>
        /// Parm MessageInfo
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_MessageInfo = "MessageInfo";
        /// <summary>
        /// Parm ReceivePhone
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_ReceivePhone = "ReceivePhone";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartTime
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_StartTime = "StartTime";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_PUNISH_DISCUSS_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_PUNISH_DISCUSS
        /// </summary>
        public const string Sql_INF_PUNISH_DISCUSS_Insert = "insert into INF_PUNISH_DISCUSS(CaseInfoId,CreateBy,CreateOn,CreatorId,DiscussType,EndTime,MemberList,MemberName,MessageInfo,ReceivePhone,RowStatus,StartTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CaseInfoId,@CreateBy,@CreateOn,@CreatorId,@DiscussType,@EndTime,@MemberList,@MemberName,@MessageInfo,@ReceivePhone,@RowStatus,@StartTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_PUNISH_DISCUSS
        /// </summary>
        public const string Sql_INF_PUNISH_DISCUSS_Update = "update INF_PUNISH_DISCUSS set CaseInfoId=@CaseInfoId,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DiscussType=@DiscussType,EndTime=@EndTime,MemberList=@MemberList,MemberName=@MemberName,MessageInfo=@MessageInfo,ReceivePhone=@ReceivePhone,RowStatus=@RowStatus,StartTime=@StartTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_PUNISH_DISCUSS_Delete = "update INF_PUNISH_DISCUSS set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _caseInfoId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CaseInfoId
        {
            get { return _caseInfoId ?? string.Empty; }
            set { _caseInfoId = value; }
        }
        private string _memberList = string.Empty;
        /// <summary>
        /// 与会人员列表
        /// </summary>
        public string MemberList
        {
            get { return _memberList ?? string.Empty; }
            set { _memberList = value; }
        }
        private string _memberName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MemberName
        {
            get { return _memberName ?? string.Empty; }
            set { _memberName = value; }
        }
        private string _receivePhone = string.Empty;
        /// <summary>
        /// 接收电话
        /// </summary>
        public string ReceivePhone
        {
            get { return _receivePhone ?? string.Empty; }
            set { _receivePhone = value; }
        }
        private string _messageInfo = string.Empty;
        /// <summary>
        /// 短信内容
        /// </summary>
        public string MessageInfo
        {
            get { return _messageInfo ?? string.Empty; }
            set { _messageInfo = value; }
        }
        private string _startTime = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string StartTime
        {
            get { return _startTime ?? string.Empty; }
            set { _startTime = value; }
        }
        private string _endTime = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string EndTime
        {
            get { return _endTime ?? string.Empty; }
            set { _endTime = value; }
        }
        private int _discussType;
        /// <summary>
        /// 0  案审会讨论 1  集体讨论
        /// </summary>
        public int DiscussType
        {
            get { return _discussType; }
            set { _discussType = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfPunishDiscussEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfPunishDiscussEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfPunishDiscussEntity();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_PUNISH_DISCUSS_Id].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_CaseInfoId) || fields.Contains("*"))
                tmp.CaseInfoId = dr[Parm_INF_PUNISH_DISCUSS_CaseInfoId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_MemberList) || fields.Contains("*"))
                tmp.MemberList = dr[Parm_INF_PUNISH_DISCUSS_MemberList].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_MemberName) || fields.Contains("*"))
                tmp.MemberName = dr[Parm_INF_PUNISH_DISCUSS_MemberName].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_ReceivePhone) || fields.Contains("*"))
                tmp.ReceivePhone = dr[Parm_INF_PUNISH_DISCUSS_ReceivePhone].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_MessageInfo) || fields.Contains("*"))
                tmp.MessageInfo = dr[Parm_INF_PUNISH_DISCUSS_MessageInfo].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_StartTime) || fields.Contains("*"))
                tmp.StartTime = dr[Parm_INF_PUNISH_DISCUSS_StartTime].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_EndTime) || fields.Contains("*"))
                tmp.EndTime = dr[Parm_INF_PUNISH_DISCUSS_EndTime].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_DiscussType) || fields.Contains("*"))
                tmp.DiscussType = int.Parse(dr[Parm_INF_PUNISH_DISCUSS_DiscussType].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_PUNISH_DISCUSS_RowStatus].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_PUNISH_DISCUSS_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_PUNISH_DISCUSS_CreatorId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_PUNISH_DISCUSS_CreateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DISCUSS_CreateOn].ToString());
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_PUNISH_DISCUSS_UpdateId].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_PUNISH_DISCUSS_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_PUNISH_DISCUSS_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_PUNISH_DISCUSS_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_punish_discuss">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfPunishDiscussEntity inf_punish_discuss, SqlParameter[] parms)
        {
            parms[0].Value = inf_punish_discuss.CaseInfoId;
            parms[1].Value = inf_punish_discuss.MemberList;
            parms[2].Value = inf_punish_discuss.MemberName;
            parms[3].Value = inf_punish_discuss.ReceivePhone;
            parms[4].Value = inf_punish_discuss.MessageInfo;
            parms[5].Value = inf_punish_discuss.StartTime;
            parms[6].Value = inf_punish_discuss.EndTime;
            parms[7].Value = inf_punish_discuss.DiscussType;
            parms[8].Value = inf_punish_discuss.RowStatus;
            parms[9].Value = inf_punish_discuss.CreatorId;
            parms[10].Value = inf_punish_discuss.CreateBy;
            parms[11].Value = inf_punish_discuss.CreateOn;
            parms[12].Value = inf_punish_discuss.UpdateId;
            parms[13].Value = inf_punish_discuss.UpdateBy;
            parms[14].Value = inf_punish_discuss.UpdateOn;
            parms[15].Value = inf_punish_discuss.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfPunishDiscussEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DISCUSS_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_PUNISH_DISCUSS_CaseInfoId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_MemberList, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_MemberName, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_ReceivePhone, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_MessageInfo, SqlDbType.NVarChar, -1),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_StartTime, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_EndTime, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_DiscussType, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_PUNISH_DISCUSS_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_PUNISH_DISCUSS_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_PUNISH_DISCUSS_Insert, parms);
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

