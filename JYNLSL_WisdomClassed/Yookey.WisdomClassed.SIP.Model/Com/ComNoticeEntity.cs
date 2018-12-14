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
    /// 公告通知表
    /// </summary>
    [Serializable]
    public class ComNoticeEntity : ModelImp.BaseModel<ComNoticeEntity>
    {
        public ComNoticeEntity()
        {
            TB_Name = TB_ComNotice;
            Parm_Id = Parm_ComNotice_Id;
            Parm_Version = Parm_ComNotice_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComNotice_Insert;
            Sql_Update = Sql_ComNotice_Update;
            Sql_Delete = Sql_ComNotice_Delete;
        }
        #region Const of table ComNotice
        /// <summary>
        /// Table ComNotice
        /// </summary>
        public const string TB_ComNotice = "ComNotice";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Astatus
        /// </summary>
        public const string Parm_ComNotice_Astatus = "Astatus";
        /// <summary>
        /// Parm AType
        /// </summary>
        public const string Parm_ComNotice_AType = "AType";
        /// <summary>
        /// Parm Contents
        /// </summary>
        public const string Parm_ComNotice_Contents = "Contents";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComNotice_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComNotice_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComNotice_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndTimie
        /// </summary>
        public const string Parm_ComNotice_EndTimie = "EndTimie";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComNotice_Id = "Id";
        /// <summary>
        /// Parm IsTop
        /// </summary>
        public const string Parm_ComNotice_IsTop = "IsTop";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComNotice_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartTime
        /// </summary>
        public const string Parm_ComNotice_StartTime = "StartTime";
        /// <summary>
        /// Parm Title
        /// </summary>
        public const string Parm_ComNotice_Title = "Title";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComNotice_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComNotice_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComNotice_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComNotice_Version = "Version";
        /// <summary>
        /// Insert Query Of ComNotice
        /// </summary>
        public const string Sql_ComNotice_Insert = "insert into ComNotice(Astatus,AType,Contents,CreateBy,CreateOn,CreatorId,EndTimie,IsTop,RowStatus,StartTime,Title,UpdateBy,UpdateId,UpdateOn,Id) values(@Astatus,@AType,@Contents,@CreateBy,@CreateOn,@CreatorId,@EndTimie,@IsTop,@RowStatus,@StartTime,@Title,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComNotice
        /// </summary>
        public const string Sql_ComNotice_Update = "update ComNotice set Astatus=@Astatus,AType=@AType,Contents=@Contents,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndTimie=@EndTimie,IsTop=@IsTop,RowStatus=@RowStatus,StartTime=@StartTime,Title=@Title,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComNotice_Delete = "update ComNotice set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion
        #region Properties
        private string _title = string.Empty;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title ?? string.Empty; }
            set { _title = value; }
        }
        private string _contents = string.Empty;
        /// <summary>
        /// 公告通知内容
        /// </summary>
        public string Contents
        {
            get { return _contents ?? string.Empty; }
            set { _contents = value; }
        }
        private int _astatus;
        /// <summary>
        /// 通知类型（1：紧急，0：一般）
        /// </summary>
        public int Astatus
        {
            get { return _astatus; }
            set { _astatus = value; }
        }
        private int _isTop;
        /// <summary>
        /// 是否置顶（1：是，0：否）
        /// </summary>
        public int IsTop
        {
            get { return _isTop; }
            set { _isTop = value; }
        }
        private int _aType;
        /// <summary>
        /// 通知类型（1：统一身份认证系统、2：网上课程）
        /// </summary>
        public int AType
        {
            get { return _aType; }
            set { _aType = value; }
        }
        private DateTime _startTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime _endTimie = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTimie
        {
            get { return _endTimie; }
            set { _endTimie = value; }
        }

        /// <summary>
        /// 接收人（只有Id）
        /// </summary>
        public string Actioners { get; set; }

        /// <summary>
        /// 接收人（姓名+电话）
        /// </summary>
        public string ActionerNames { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComNoticeEntity SetModelValueByDataRow(DataRow dr)
      	{
            IList<string> fields = new List<string> {"*"};
   	    	return SetModelValueByDataRow(dr,fields);
        }

		/// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
		public override ComNoticeEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComNoticeEntity();
          			if (fields.Contains(Parm_ComNotice_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_ComNotice_Id].ToString();
			if (fields.Contains(Parm_ComNotice_Title) || fields.Contains("*"))
				tmp.Title = dr[Parm_ComNotice_Title].ToString();
			if (fields.Contains(Parm_ComNotice_Contents) || fields.Contains("*"))
				tmp.Contents = dr[Parm_ComNotice_Contents].ToString();
			if (fields.Contains(Parm_ComNotice_Astatus) || fields.Contains("*"))
				tmp.Astatus = int.Parse(dr[Parm_ComNotice_Astatus].ToString());
			if (fields.Contains(Parm_ComNotice_IsTop) || fields.Contains("*"))
				tmp.IsTop = int.Parse(dr[Parm_ComNotice_IsTop].ToString());
			if (fields.Contains(Parm_ComNotice_AType) || fields.Contains("*"))
				tmp.AType = int.Parse(dr[Parm_ComNotice_AType].ToString());
			if (fields.Contains(Parm_ComNotice_StartTime) || fields.Contains("*"))
				tmp.StartTime = DateTime.Parse(dr[Parm_ComNotice_StartTime].ToString());
			if (fields.Contains(Parm_ComNotice_EndTimie) || fields.Contains("*"))
				tmp.EndTimie = DateTime.Parse(dr[Parm_ComNotice_EndTimie].ToString());
			if (fields.Contains(Parm_ComNotice_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_ComNotice_RowStatus].ToString());
			if (fields.Contains(Parm_ComNotice_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_ComNotice_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_ComNotice_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_ComNotice_CreatorId].ToString();
			if (fields.Contains(Parm_ComNotice_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_ComNotice_CreateBy].ToString();
			if (fields.Contains(Parm_ComNotice_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_ComNotice_CreateOn].ToString());
			if (fields.Contains(Parm_ComNotice_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_ComNotice_UpdateId].ToString();
			if (fields.Contains(Parm_ComNotice_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_ComNotice_UpdateBy].ToString();
			if (fields.Contains(Parm_ComNotice_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_ComNotice_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comnotice">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(ComNoticeEntity comnotice, SqlParameter[] parms)
		{
            				parms[0].Value = comnotice.Title;
				parms[1].Value = comnotice.Contents;
				parms[2].Value = comnotice.Astatus;
				parms[3].Value = comnotice.IsTop;
				parms[4].Value = comnotice.AType;
				parms[5].Value = comnotice.StartTime;
				parms[6].Value = comnotice.EndTimie;
				parms[7].Value = comnotice.RowStatus;
				parms[8].Value = comnotice.CreatorId;
				parms[9].Value = comnotice.CreateBy;
				parms[10].Value = comnotice.CreateOn;
				parms[11].Value = comnotice.UpdateId;
				parms[12].Value = comnotice.UpdateBy;
				parms[13].Value = comnotice.UpdateOn;
                parms[14].Value = comnotice.Id;

             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(ComNoticeEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNotice_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_ComNotice_Title, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComNotice_Contents, SqlDbType.Text, 2147483647),
					new SqlParameter(Parm_ComNotice_Astatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNotice_IsTop, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNotice_AType, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNotice_StartTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNotice_EndTimie, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNotice_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNotice_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNotice_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNotice_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNotice_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNotice_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNotice_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComNotice_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNotice_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                    
