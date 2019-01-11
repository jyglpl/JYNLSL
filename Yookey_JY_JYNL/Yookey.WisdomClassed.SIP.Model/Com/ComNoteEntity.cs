//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComNoteEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/9 10:53:32
//  功能描述：ComNote表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Yookey;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ComNoteEntity : ModelImp.BaseModel<ComNoteEntity>
    {
        public ComNoteEntity()
        {
            TB_Name = TB_ComNote;
            Parm_Id = Parm_ComNote_Id;
            Parm_Version = Parm_ComNote_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComNote_Insert;
            Sql_Update = Sql_ComNote_Update;
            Sql_Delete = Sql_ComNote_Delete;
        }
        #region Const of table ComNote
        /// <summary>
        /// Table ComNote
        /// </summary>
        public const string TB_ComNote = "ComNote";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComNote_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComNote_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComNote_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComNote_Id = "Id";
        /// <summary>
        /// Parm ResourcesId
        /// </summary>
        public const string Parm_ComNote_ResourcesId = "ResourcesId";
        /// <summary>
        /// Parm MistakeInfo
        /// </summary>
        public const string Parm_ComNote_MistakeInfo = "MistakeInfo";
        /// <summary>
        /// Parm ReceivePhone
        /// </summary>
        public const string Parm_ComNote_ReceivePhone = "ReceivePhone";
        /// <summary>
        /// Parm ReceiveTime
        /// </summary>
        public const string Parm_ComNote_ReceiveTime = "ReceiveTime";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_ComNote_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComNote_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SendDate
        /// </summary>
        public const string Parm_ComNote_SendDate = "SendDate";
        /// <summary>
        /// Parm Status
        /// </summary>
        public const string Parm_ComNote_Status = "Status";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComNote_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComNote_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComNote_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComNote_Version = "Version";
        /// <summary>
        /// Insert Query Of ComNote
        /// </summary>
        public const string Sql_ComNote_Insert = "insert into ComNote(CreateBy,CreateOn,CreatorId,MistakeInfo,ReceivePhone,ReceiveTime,Remark,RowStatus,SendDate,Status,UpdateBy,UpdateId,UpdateOn,ResourcesId,Id) values(@CreateBy,@CreateOn,@CreatorId,@MistakeInfo,@ReceivePhone,@ReceiveTime,@Remark,@RowStatus,@SendDate,@Status,@UpdateBy,@UpdateId,@UpdateOn,@ResourcesId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComNote
        /// </summary>
        public const string Sql_ComNote_Update = "update ComNote set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,MistakeInfo=@MistakeInfo,ReceivePhone=@ReceivePhone,ReceiveTime=@ReceiveTime,Remark=@Remark,RowStatus=@RowStatus,SendDate=@SendDate,Status=@Status,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,ResourcesId=@ResourcesId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComNote_Delete = "update ComNote set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _receivePhone = string.Empty;
        /// <summary>
        /// 接收手机号码
        /// </summary>
        public string ReceivePhone
        {
            get { return _receivePhone ?? string.Empty; }
            set { _receivePhone = value; }
        }
        private string _mistakeInfo = string.Empty;
        /// <summary>
        /// 发送短信内容
        /// </summary>
        public string MistakeInfo
        {
            get { return _mistakeInfo ?? string.Empty; }
            set { _mistakeInfo = value; }
        }
        private DateTime _receiveTime = MinDate;
        /// <summary>
        /// 需要发送短信时间
        /// </summary>
        public DateTime ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
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
        private DateTime _sendDate = MinDate;
        /// <summary>
        /// 实际发送时间
        /// </summary>
        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注，用于记录错误内容
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }

        private string _resourcesId = string.Empty;
        /// <summary>
        /// 发送消息编号
        /// </summary>
        public string ResourcesId
        {
            get { return _resourcesId; }
            set { _resourcesId = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComNoteEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComNoteEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComNoteEntity();
            if (fields.Contains(Parm_ComNote_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComNote_Id].ToString();
            if (fields.Contains(Parm_ComNote_Id) || fields.Contains("*"))
                tmp.ResourcesId = dr[Parm_ComNote_ResourcesId].ToString();
            if (fields.Contains(Parm_ComNote_ReceivePhone) || fields.Contains("*"))
                tmp.ReceivePhone = dr[Parm_ComNote_ReceivePhone].ToString();
            if (fields.Contains(Parm_ComNote_MistakeInfo) || fields.Contains("*"))
                tmp.MistakeInfo = dr[Parm_ComNote_MistakeInfo].ToString();
            if (fields.Contains(Parm_ComNote_ReceiveTime) || fields.Contains("*"))
                tmp.ReceiveTime = DateTime.Parse(dr[Parm_ComNote_ReceiveTime].ToString());
            if (fields.Contains(Parm_ComNote_Status) || fields.Contains("*"))
                tmp.Status = int.Parse(dr[Parm_ComNote_Status].ToString());
            if (fields.Contains(Parm_ComNote_SendDate) || fields.Contains("*"))
                tmp.SendDate = DateTime.Parse(dr[Parm_ComNote_SendDate].ToString());
            if (fields.Contains(Parm_ComNote_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_ComNote_Remark].ToString();
            if (fields.Contains(Parm_ComNote_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComNote_RowStatus].ToString());
            if (fields.Contains(Parm_ComNote_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComNote_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComNote_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComNote_CreatorId].ToString();
            if (fields.Contains(Parm_ComNote_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComNote_CreateBy].ToString();
            if (fields.Contains(Parm_ComNote_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComNote_CreateOn].ToString());
            if (fields.Contains(Parm_ComNote_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComNote_UpdateId].ToString();
            if (fields.Contains(Parm_ComNote_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComNote_UpdateBy].ToString();
            if (fields.Contains(Parm_ComNote_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComNote_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comnote">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComNoteEntity comnote, SqlParameter[] parms)
        {
            parms[0].Value = comnote.ReceivePhone;
            parms[1].Value = comnote.MistakeInfo;
            parms[2].Value = comnote.ReceiveTime;
            parms[3].Value = comnote.Status;
            parms[4].Value = comnote.SendDate;
            parms[5].Value = comnote.Remark;
            parms[6].Value = comnote.RowStatus;
            parms[7].Value = comnote.CreatorId;
            parms[8].Value = comnote.CreateBy;
            parms[9].Value = comnote.CreateOn;
            parms[10].Value = comnote.UpdateId;
            parms[11].Value = comnote.UpdateBy;
            parms[12].Value = comnote.UpdateOn;
            parms[13].Value = comnote.ResourcesId;
            parms[14].Value = comnote.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComNoteEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNote_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComNote_ReceivePhone, SqlDbType.VarChar, 11),
					new SqlParameter(Parm_ComNote_MistakeInfo, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComNote_ReceiveTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNote_Status, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNote_SendDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNote_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComNote_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNote_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNote_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNote_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNote_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNote_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNote_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComNote_ResourcesId, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_ComNote_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNote_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }

    //短信消息查询实体
    [Serializable]
    public class ComNoteContentEntity
    {
        //主键
        public string Id { get; set; }

        //手机号码和名称信息
        public string ReceivePhone { get; set; }

        //内容信息
        public string MistakeInfo { get; set; }

        //发送时间设置
        public DateTime ReceiveTime { get; set; }

        //发送人
        public string SendPerson { get; set; }

        //DataTable转化List
        public ComNoteContentEntity ConvertList(DataRow row)
        {
            return new ComNoteContentEntity
            {
                Id = row["Id"].ToString(),
                ReceivePhone = row["ReceivePhone"].ToString(),
                MistakeInfo = row["MistakeInfo"].ToString(),
                ReceiveTime=Convert.ToDateTime(row["ReceiveTime"]),
                SendPerson=row["SendPerson"].ToString()
            };
        }

    }

    //树实体
    [Serializable]
    public class Node 
    {
        //节点ID
        public string id { get; set; }

        //父节点ID
        public string pId { get; set; }

        //节点名称
        public string name { get; set; }
        
        //DataTable转化List
        public Node ConvertList(DataRow row)
        { 
          return  new Node{
                id=row["id"].ToString(),
                pId = row["pId"].ToString(),
                name = row["name"].ToString()
            };
        }
    }
}

