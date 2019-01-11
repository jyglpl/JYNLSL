using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 公告通知表接收表
    /// </summary>
    [Serializable]
    public class ComNoticeReceiveEntity : ModelImp.BaseModel<ComNoticeReceiveEntity>
    {
        public ComNoticeReceiveEntity()
        {
            TB_Name = TB_ComNoticeReceive;
            Parm_Id = Parm_ComNoticeReceive_Id;
            Parm_Version = Parm_ComNoticeReceive_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComNoticeReceive_Insert;
            Sql_Update = Sql_ComNoticeReceive_Update;
            Sql_Delete = Sql_ComNoticeReceive_Delete;
        }
        #region Const of table ComNoticeReceive
        /// <summary>
        /// Table ComNoticeReceive
        /// </summary>
        public const string TB_ComNoticeReceive = "ComNoticeReceive";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComNoticeReceive_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComNoticeReceive_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComNoticeReceive_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComNoticeReceive_Id = "Id";
        /// <summary>
        /// Parm IsRead
        /// </summary>
        public const string Parm_ComNoticeReceive_IsRead = "IsRead";
        /// <summary>
        /// Parm LastReadTime
        /// </summary>
        public const string Parm_ComNoticeReceive_LastReadTime = "LastReadTime";
        /// <summary>
        /// Parm NoticeId
        /// </summary>
        public const string Parm_ComNoticeReceive_NoticeId = "NoticeId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComNoticeReceive_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComNoticeReceive_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComNoticeReceive_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComNoticeReceive_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_ComNoticeReceive_UserId = "UserId";
        /// <summary>
        /// Parm UserNameq
        /// </summary>
        public const string Parm_ComNoticeReceive_UserNameq = "UserNameq";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComNoticeReceive_Version = "Version";
        /// <summary>
        /// Insert Query Of ComNoticeReceive
        /// </summary>
        public const string Sql_ComNoticeReceive_Insert = "insert into ComNoticeReceive(CreateBy,CreateOn,CreatorId,IsRead,LastReadTime,NoticeId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId,UserNameq,Id) values(@CreateBy,@CreateOn,@CreatorId,@IsRead,@LastReadTime,@NoticeId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@UserNameq,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComNoticeReceive
        /// </summary>
        public const string Sql_ComNoticeReceive_Update = "update ComNoticeReceive set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,IsRead=@IsRead,LastReadTime=@LastReadTime,NoticeId=@NoticeId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,UserNameq=@UserNameq where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComNoticeReceive_Delete = "update ComNoticeReceive set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _noticeId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string NoticeId
        {
            get { return _noticeId ?? string.Empty; }
            set { _noticeId = value; }
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
        private string _userNameq = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserNameq
        {
            get { return _userNameq ?? string.Empty; }
            set { _userNameq = value; }
        }
        private int _isRead;
        /// <summary>
        /// 
        /// </summary>
        public int IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }
        private DateTime _lastReadTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastReadTime
        {
            get { return _lastReadTime; }
            set { _lastReadTime = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComNoticeReceiveEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComNoticeReceiveEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComNoticeReceiveEntity();
            if (fields.Contains(Parm_ComNoticeReceive_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComNoticeReceive_Id].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_NoticeId) || fields.Contains("*"))
                tmp.NoticeId = dr[Parm_ComNoticeReceive_NoticeId].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_ComNoticeReceive_UserId].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_UserNameq) || fields.Contains("*"))
                tmp.UserNameq = dr[Parm_ComNoticeReceive_UserNameq].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_IsRead) || fields.Contains("*"))
                tmp.IsRead = int.Parse(dr[Parm_ComNoticeReceive_IsRead].ToString());
            if (fields.Contains(Parm_ComNoticeReceive_LastReadTime) || fields.Contains("*"))
                tmp.LastReadTime = DateTime.Parse(dr[Parm_ComNoticeReceive_LastReadTime].ToString());
            if (fields.Contains(Parm_ComNoticeReceive_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComNoticeReceive_RowStatus].ToString());
            if (fields.Contains(Parm_ComNoticeReceive_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComNoticeReceive_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComNoticeReceive_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComNoticeReceive_CreatorId].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComNoticeReceive_CreateBy].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComNoticeReceive_CreateOn].ToString());
            if (fields.Contains(Parm_ComNoticeReceive_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComNoticeReceive_UpdateId].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComNoticeReceive_UpdateBy].ToString();
            if (fields.Contains(Parm_ComNoticeReceive_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComNoticeReceive_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comnoticereceive">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComNoticeReceiveEntity comnoticereceive, SqlParameter[] parms)
        {
            parms[0].Value = comnoticereceive.NoticeId;
            parms[1].Value = comnoticereceive.UserId;
            parms[2].Value = comnoticereceive.UserNameq;
            parms[3].Value = comnoticereceive.IsRead;
            parms[4].Value = comnoticereceive.LastReadTime;
            parms[5].Value = comnoticereceive.RowStatus;
            parms[6].Value = comnoticereceive.CreatorId;
            parms[7].Value = comnoticereceive.CreateBy;
            parms[8].Value = comnoticereceive.CreateOn;
            parms[9].Value = comnoticereceive.UpdateId;
            parms[10].Value = comnoticereceive.UpdateBy;
            parms[11].Value = comnoticereceive.UpdateOn;
            parms[12].Value = comnoticereceive.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComNoticeReceiveEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNoticeReceive_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComNoticeReceive_NoticeId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_UserNameq, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_IsRead, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNoticeReceive_LastReadTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNoticeReceive_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNoticeReceive_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNoticeReceive_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeReceive_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComNoticeReceive_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNoticeReceive_Insert, parms);
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

