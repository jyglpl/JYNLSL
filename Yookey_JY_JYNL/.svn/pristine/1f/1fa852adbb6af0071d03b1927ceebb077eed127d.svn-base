//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmMessageWorkEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 17:41:23
//  功能描述：CrmMessageWork表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 消息表
    /// </summary>
    [Serializable]
    public class CrmMessageWorkEntity : ModelImp.BaseModel<CrmMessageWorkEntity>
    {
        public CrmMessageWorkEntity()
        {
            TB_Name = TB_CrmMessageWork;
            Parm_Id = Parm_CrmMessageWork_Id;
            Parm_Version = Parm_CrmMessageWork_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmMessageWork_Insert;
            Sql_Update = Sql_CrmMessageWork_Update;
            Sql_Delete = Sql_CrmMessageWork_Delete;
        }
        #region Const of table CrmMessageWork
        /// <summary>
        /// Table CrmMessageWork
        /// </summary>
        public const string TB_CrmMessageWork = "CrmMessageWork";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ActionerID
        /// </summary>
        public const string Parm_CrmMessageWork_ActionerID = "ActionerID";
        /// <summary>
        /// Parm ActivityInstanceID
        /// </summary>
        public const string Parm_CrmMessageWork_ActivityInstanceID = "ActivityInstanceID";
        /// <summary>
        /// Parm ContentTypeID
        /// </summary>
        public const string Parm_CrmMessageWork_ContentTypeID = "ContentTypeID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmMessageWork_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmMessageWork_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmMessageWork_CreatorId = "CreatorId";
        /// <summary>
        /// Parm ExecuteDate
        /// </summary>
        public const string Parm_CrmMessageWork_ExecuteDate = "ExecuteDate";
        /// <summary>
        /// Parm FormAddress
        /// </summary>
        public const string Parm_CrmMessageWork_FormAddress = "FormAddress";
        /// <summary>
        /// Parm FormData
        /// </summary>
        public const string Parm_CrmMessageWork_FormData = "FormData";
        /// <summary>
        /// Parm FormID
        /// </summary>
        public const string Parm_CrmMessageWork_FormID = "FormID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmMessageWork_Id = "Id";
        /// <summary>
        /// Parm IsReply
        /// </summary>
        public const string Parm_CrmMessageWork_IsReply = "IsReply";
        /// <summary>
        /// Parm Note
        /// </summary>
        public const string Parm_CrmMessageWork_Note = "Note";
        /// <summary>
        /// Parm ProcessInstanceID
        /// </summary>
        public const string Parm_CrmMessageWork_ProcessInstanceID = "ProcessInstanceID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmMessageWork_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SendActivityID
        /// </summary>
        public const string Parm_CrmMessageWork_SendActivityID = "SendActivityID";
        /// <summary>
        /// Parm SenderID
        /// </summary>
        public const string Parm_CrmMessageWork_SenderID = "SenderID";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        public const string Parm_CrmMessageWork_StartDate = "StartDate";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_CrmMessageWork_State = "State";
        /// <summary>
        /// Parm Titles
        /// </summary>
        public const string Parm_CrmMessageWork_Titles = "Titles";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmMessageWork_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmMessageWork_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmMessageWork_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmMessageWork_Version = "Version";

        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComMessageWork_UserName = "UserName";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComMessageWork_RsKey = "RsKey";

        public const string Parm_ComMessageWork_Isread = "Isread";

        public const string Parm_ComMessageWork_AutoID = "AutoID";

        public const string Parm_ComMessageWork_CompanyId = "CompanyId";
        /// <summary>
        /// Insert Query Of CrmMessageWork
        /// </summary>
        public const string Sql_CrmMessageWork_Insert = "insert into CrmMessageWork(ActionerID,ActivityInstanceID,ContentTypeID,CreateBy,CreateOn,CreatorId,ExecuteDate,FormAddress,FormData,FormID,IsReply,Note,ProcessInstanceID,RowStatus,SendActivityID,SenderID,StartDate,State,Titles,UpdateBy,UpdateId,UpdateOn,Id) values(@ActionerID,@ActivityInstanceID,@ContentTypeID,@CreateBy,@CreateOn,@CreatorId,@ExecuteDate,@FormAddress,@FormData,@FormID,@IsReply,@Note,@ProcessInstanceID,@RowStatus,@SendActivityID,@SenderID,@StartDate,@State,@Titles,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of CrmMessageWork
        /// </summary>
        public const string Sql_CrmMessageWork_Update = "update CrmMessageWork set ActionerID=@ActionerID,ActivityInstanceID=@ActivityInstanceID,ContentTypeID=@ContentTypeID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ExecuteDate=@ExecuteDate,FormAddress=@FormAddress,FormData=@FormData,FormID=@FormID,IsReply=@IsReply,Note=@Note,ProcessInstanceID=@ProcessInstanceID,RowStatus=@RowStatus,SendActivityID=@SendActivityID,SenderID=@SenderID,StartDate=@StartDate,State=@State,Titles=@Titles,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmMessageWork_Delete = "update CrmMessageWork set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _titles = string.Empty;
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Titles
        {
            get { return _titles ?? string.Empty; }
            set { _titles = value; }
        }
        private string _processInstanceID = string.Empty;
        /// <summary>
        /// 业务编号
        /// </summary>
        public string ProcessInstanceID
        {
            get { return _processInstanceID ?? string.Empty; }
            set { _processInstanceID = value; }
        }
        private string _sendActivityID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SendActivityID
        {
            get { return _sendActivityID ?? string.Empty; }
            set { _sendActivityID = value; }
        }
        private string _activityInstanceID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ActivityInstanceID
        {
            get { return _activityInstanceID ?? string.Empty; }
            set { _activityInstanceID = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 消息发送时间
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private string _senderID = string.Empty;
        /// <summary>
        /// 发送人编号
        /// </summary>
        public string SenderID
        {
            get { return _senderID ?? string.Empty; }
            set { _senderID = value; }
        }
        private DateTime _executeDate = MinDate;
        /// <summary>
        /// 消息处理后时间
        /// </summary>
        public DateTime ExecuteDate
        {
            get { return _executeDate; }
            set { _executeDate = value; }
        }
        private string _actionerID = string.Empty;
        /// <summary>
        /// 接收人编号
        /// </summary>
        public string ActionerID
        {
            get { return _actionerID ?? string.Empty; }
            set { _actionerID = value; }
        }
        private string _formID = string.Empty;
        /// <summary>
        /// 表单编号
        /// </summary>
        public string FormID
        {
            get { return _formID ?? string.Empty; }
            set { _formID = value; }
        }
        private string _formData;
        /// <summary>
        /// 表单内容
        /// </summary>
        public string FormData
        {
            get { return _formData; }
            set { _formData = value; }
        }
        private string _formAddress = string.Empty;
        /// <summary>
        /// 获取数据页面地址
        /// </summary>
        public string FormAddress
        {
            get { return _formAddress ?? string.Empty; }
            set { _formAddress = value; }
        }
        private string _contentTypeID = string.Empty;
        /// <summary>
        /// 表单内容所属的类型
        /// </summary>
        public string ContentTypeID
        {
            get { return _contentTypeID ?? string.Empty; }
            set { _contentTypeID = value; }
        }
        private int _isReply;
        /// <summary>
        /// 消息是否需要处理（0:不处理/1:处理）
        /// </summary>
        public int IsReply
        {
            get { return _isReply; }
            set { _isReply = value; }
        }
        private int _state;
        /// <summary>
        /// 0:未读/1:已读/2:已处理
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _note = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get { return _note ?? string.Empty; }
            set { _note = value; }
        }

        private string _userName;
        /// <summary>
        /// 发送人
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _rsKey;
        /// <summary>
        /// 消息类型
        /// </summary>
        public string RsKey
        {
            get { return _rsKey; }
            set { _rsKey = value; }
        }

        private int _isread;

        //本地已阅读缓存
        public int Isread
        {
            get { return _isread; }
            set { _isread = value; }
        }

        //手动生成编号
        private int _autoID;

        public int AutoID
        {
            get { return _autoID; }
            set { _autoID = value; }
        }

        /// <summary>
        /// 消息所属片区编号
        /// </summary>
        private string _CompanyId;

        public string CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }

        private WfProcessInstanceEntity processInstance = new WfProcessInstanceEntity();
        public WfProcessInstanceEntity ProcessInstance
        {
            get { return processInstance; }
            set { processInstance = value; }
        }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmMessageWorkEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmMessageWorkEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmMessageWorkEntity();
            if (fields.Contains(Parm_CrmMessageWork_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_CrmMessageWork_Id].ToString();
            if (fields.Contains(Parm_CrmMessageWork_Titles) || fields.Contains("*"))
                tmp.Titles = dr[Parm_CrmMessageWork_Titles].ToString();
            if (fields.Contains(Parm_CrmMessageWork_ProcessInstanceID) || fields.Contains("*"))
                tmp.ProcessInstanceID = dr[Parm_CrmMessageWork_ProcessInstanceID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_SendActivityID) || fields.Contains("*"))
                tmp.SendActivityID = dr[Parm_CrmMessageWork_SendActivityID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_ActivityInstanceID) || fields.Contains("*"))
                tmp.ActivityInstanceID = dr[Parm_CrmMessageWork_ActivityInstanceID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_StartDate) || fields.Contains("*"))
                tmp.StartDate = DateTime.Parse(dr[Parm_CrmMessageWork_StartDate].ToString());
            if (fields.Contains(Parm_CrmMessageWork_SenderID) || fields.Contains("*"))
                tmp.SenderID = dr[Parm_CrmMessageWork_SenderID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_ExecuteDate) || fields.Contains("*"))
                tmp.ExecuteDate = DateTime.Parse(dr[Parm_CrmMessageWork_ExecuteDate].ToString());
            if (fields.Contains(Parm_CrmMessageWork_ActionerID) || fields.Contains("*"))
                tmp.ActionerID = dr[Parm_CrmMessageWork_ActionerID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_FormID) || fields.Contains("*"))
                tmp.FormID = dr[Parm_CrmMessageWork_FormID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_FormData) || fields.Contains("*"))
                tmp.FormData = dr[Parm_CrmMessageWork_FormData].ToString();
            if (fields.Contains(Parm_CrmMessageWork_FormAddress) || fields.Contains("*"))
                tmp.FormAddress = dr[Parm_CrmMessageWork_FormAddress].ToString();
            if (fields.Contains(Parm_CrmMessageWork_ContentTypeID) || fields.Contains("*"))
                tmp.ContentTypeID = dr[Parm_CrmMessageWork_ContentTypeID].ToString();
            if (fields.Contains(Parm_CrmMessageWork_IsReply) || fields.Contains("*"))
                tmp.IsReply = int.Parse(dr[Parm_CrmMessageWork_IsReply].ToString());
            if (fields.Contains(Parm_CrmMessageWork_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_CrmMessageWork_State].ToString());
            if (fields.Contains(Parm_CrmMessageWork_Note) || fields.Contains("*"))
                tmp.Note = dr[Parm_CrmMessageWork_Note].ToString();
            if (fields.Contains(Parm_CrmMessageWork_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_CrmMessageWork_RowStatus].ToString());
            if (fields.Contains(Parm_CrmMessageWork_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_CrmMessageWork_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_CrmMessageWork_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_CrmMessageWork_CreatorId].ToString();
            if (fields.Contains(Parm_CrmMessageWork_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_CrmMessageWork_CreateBy].ToString();
            if (fields.Contains(Parm_CrmMessageWork_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmMessageWork_CreateOn].ToString());
            if (fields.Contains(Parm_CrmMessageWork_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_CrmMessageWork_UpdateId].ToString();
            if (fields.Contains(Parm_CrmMessageWork_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_CrmMessageWork_UpdateBy].ToString();
            if (fields.Contains(Parm_CrmMessageWork_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmMessageWork_UpdateOn].ToString());
            if ((fields.Contains(Parm_ComMessageWork_UserName) || fields.Contains("*")) && dr.Table.Columns.Contains(Parm_ComMessageWork_UserName))
                tmp.UserName = dr[Parm_ComMessageWork_UserName].ToString();
            if ((fields.Contains(Parm_ComMessageWork_RsKey) || fields.Contains("*")) && dr.Table.Columns.Contains(Parm_ComMessageWork_RsKey))
                tmp.RsKey = dr[Parm_ComMessageWork_RsKey].ToString();


            if ((fields.Contains(Parm_ComMessageWork_Isread) || fields.Contains("*")) && dr.Table.Columns.Contains(Parm_ComMessageWork_Isread))
                tmp.Isread =Convert.ToInt32(dr[Parm_ComMessageWork_Isread].ToString());

            if ((fields.Contains(Parm_ComMessageWork_AutoID) || fields.Contains("*")) && dr.Table.Columns.Contains(Parm_ComMessageWork_AutoID))
                tmp.AutoID =Convert.ToInt32(dr[Parm_ComMessageWork_AutoID].ToString());

            if ((fields.Contains(Parm_ComMessageWork_CompanyId) || fields.Contains("*")) && dr.Table.Columns.Contains(Parm_ComMessageWork_CompanyId))
                tmp.CompanyId = dr[Parm_ComMessageWork_CompanyId].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmmessagework">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmMessageWorkEntity crmmessagework, SqlParameter[] parms)
        {
            parms[0].Value = crmmessagework.Titles;
            parms[1].Value = crmmessagework.ProcessInstanceID;
            parms[2].Value = crmmessagework.SendActivityID;
            parms[3].Value = crmmessagework.ActivityInstanceID;
            parms[4].Value = crmmessagework.StartDate;
            parms[5].Value = crmmessagework.SenderID;
            parms[6].Value = crmmessagework.ExecuteDate;
            parms[7].Value = crmmessagework.ActionerID;
            parms[8].Value = crmmessagework.FormID;
            parms[9].Value = crmmessagework.FormData;
            parms[10].Value = crmmessagework.FormAddress;
            parms[11].Value = crmmessagework.ContentTypeID;
            parms[12].Value = crmmessagework.IsReply;
            parms[13].Value = crmmessagework.State;
            parms[14].Value = crmmessagework.Note;
            parms[15].Value = crmmessagework.RowStatus;
            parms[16].Value = crmmessagework.CreatorId;
            parms[17].Value = crmmessagework.CreateBy;
            parms[18].Value = crmmessagework.CreateOn;
            parms[19].Value = crmmessagework.UpdateId;
            parms[20].Value = crmmessagework.UpdateBy;
            parms[21].Value = crmmessagework.UpdateOn;
            parms[22].Value = crmmessagework.Id;


            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmMessageWorkEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);

            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
            //parms[parms.Length - 2] = new SqlParameter(Parm_CrmMessageWork_Id, model.Id);
            //parms[parms.Length - 1] = new SqlParameter(Parm_CrmMessageWork_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmMessageWork_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmMessageWork_Titles, SqlDbType.NVarChar, 400),
					new SqlParameter(Parm_CrmMessageWork_ProcessInstanceID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_SendActivityID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_ActivityInstanceID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmMessageWork_SenderID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_ExecuteDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmMessageWork_ActionerID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_FormID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_FormData, SqlDbType.Xml, -1),
					new SqlParameter(Parm_CrmMessageWork_FormAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_CrmMessageWork_ContentTypeID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_IsReply, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmMessageWork_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmMessageWork_Note, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_CrmMessageWork_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmMessageWork_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmMessageWork_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmMessageWork_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_CrmMessageWork_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmMessageWork_Insert, parms);
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
    /// 获取流程节点处理时间差的参数对象
    /// </summary>
    public class HandTimeSearch
    {
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }
        /// <summary>
        /// 开始节名称
        /// </summary>
        public string BeginActivity { get; set; }
        /// <summary>
        /// 结束节点名称
        /// </summary>
        public string EndActivity { get; set; }
        /// <summary>
        /// 相差天数
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// 是大于多少天还是在多少天之内
        /// </summary>
        public bool IsMore { get; set; }
        /// <summary>
        /// 查询时间范围开始
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 查询时间范围结束
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 案件类别编号
        /// </summary>
        public string ItemCode { get; set; }
    }

    /// <summary>
    /// 按片区返回节点数量信息
    /// </summary>
    public class HandTimeArea
    {
        /// <summary>
        /// 片区编号
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 片区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 案件数量
        /// </summary>
        public int CaseCount { get; set; }
    }

    public class HandTimeAreaTotal
    {
        /// <summary>
        /// 受理办件总数
        /// </summary>
        public int AcceptanceCountTotal { get; set; }

        /// <summary>
        /// 按期办理总数
        /// </summary>
        public int HandleScheduleTota { get; set; }

        /// <summary>
        /// 超期办理总数
        /// </summary>
        public int HandExceedTotal { get; set; }

        /// <summary>
        /// 完成验收总数
        /// </summary>
        public int CheckedCountTotal { get; set; }

        /// <summary>
        /// 按时验收总数
        /// </summary>
        public int CheckScheduleTotal { get; set; }

        /// <summary>
        /// 超期验收总数
        /// </summary>
        public int CheckExceedTotal { get; set; }

    }
}

