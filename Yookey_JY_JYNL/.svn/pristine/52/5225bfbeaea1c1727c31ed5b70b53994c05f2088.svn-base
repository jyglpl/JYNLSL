using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    public class ComArticleEntity : ModelImp.BaseModel<ComArticleEntity>
    {
        public ComArticleEntity()
        {
            TB_Name = TB_ComArticle;
            Parm_Id = Parm_ComArticle_Id;
            Parm_Version = Parm_ComArticle_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComArticle_Insert;
            Sql_Update = Sql_ComArticle_Update;
            Sql_Delete = Sql_ComArticle_Delete;
        }
        #region Const of table ComArticle
        /// <summary>
        /// Table ComArticle
        /// </summary>
        public const string TB_ComArticle = "ComArticle";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Astatus
        /// </summary>
        public const string Parm_ComArticle_Astatus = "Astatus";
        /// <summary>
        /// Parm Contents
        /// </summary>
        public const string Parm_ComArticle_Contents = "Contents";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComArticle_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComArticle_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComArticle_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndTimie
        /// </summary>
        public const string Parm_ComArticle_EndTimie = "EndTimie";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComArticle_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComArticle_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartTime
        /// </summary>
        public const string Parm_ComArticle_StartTime = "StartTime";
        /// <summary>
        /// Parm Title
        /// </summary>
        public const string Parm_ComArticle_Title = "Title";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComArticle_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComArticle_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComArticle_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComArticle_Version = "Version";
        /// <summary>
        /// Insert Query Of ComArticle
        /// </summary>
        public const string Sql_ComArticle_Insert = "insert into ComArticle(Astatus,Contents,CreateBy,CreateOn,CreatorId,EndTimie,RowStatus,StartTime,Title,UpdateBy,UpdateId,UpdateOn) values(@Astatus,@Contents,@CreateBy,@CreateOn,@CreatorId,@EndTimie,@RowStatus,@StartTime,@Title,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
        /// <summary>
        /// Update Query Of ComArticle
        /// </summary>
        public const string Sql_ComArticle_Update = "update ComArticle set Astatus=@Astatus,Contents=@Contents,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndTimie=@EndTimie,RowStatus=@RowStatus,StartTime=@StartTime,Title=@Title,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComArticle_Delete = "update ComArticle set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _astatus = string.Empty;
        /// <summary>
        /// 文章类型
        /// </summary>
        public string Astatus
        {
            get { return _astatus ?? string.Empty; }
            set { _astatus = value; }
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComArticleEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComArticleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComArticleEntity();
            if (fields.Contains(Parm_ComArticle_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComArticle_Id].ToString();
            if (fields.Contains(Parm_ComArticle_Title) || fields.Contains("*"))
                tmp.Title = dr[Parm_ComArticle_Title].ToString();
            if (fields.Contains(Parm_ComArticle_Contents) || fields.Contains("*"))
                tmp.Contents = dr[Parm_ComArticle_Contents].ToString();
            if (fields.Contains(Parm_ComArticle_Astatus) || fields.Contains("*"))
                tmp.Astatus = dr[Parm_ComArticle_Astatus].ToString();
            if (fields.Contains(Parm_ComArticle_StartTime) || fields.Contains("*"))
                tmp.StartTime = DateTime.Parse(dr[Parm_ComArticle_StartTime].ToString());
            if (fields.Contains(Parm_ComArticle_EndTimie) || fields.Contains("*"))
                tmp.EndTimie = DateTime.Parse(dr[Parm_ComArticle_EndTimie].ToString());
            if (fields.Contains(Parm_ComArticle_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComArticle_RowStatus].ToString());
            if (fields.Contains(Parm_ComArticle_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComArticle_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComArticle_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComArticle_CreatorId].ToString();
            if (fields.Contains(Parm_ComArticle_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComArticle_CreateBy].ToString();
            if (fields.Contains(Parm_ComArticle_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComArticle_CreateOn].ToString());
            if (fields.Contains(Parm_ComArticle_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComArticle_UpdateId].ToString();
            if (fields.Contains(Parm_ComArticle_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComArticle_UpdateBy].ToString();
            if (fields.Contains(Parm_ComArticle_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComArticle_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comarticle">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComArticleEntity comarticle, SqlParameter[] parms)
        {
            parms[0].Value = comarticle.Title;
            parms[1].Value = comarticle.Contents;
            parms[2].Value = comarticle.Astatus;
            parms[3].Value = comarticle.StartTime;
            parms[4].Value = comarticle.EndTimie;
            parms[5].Value = comarticle.RowStatus;
            parms[6].Value = comarticle.CreatorId;
            parms[7].Value = comarticle.CreateBy;
            parms[8].Value = comarticle.CreateOn;
            parms[9].Value = comarticle.UpdateId;
            parms[10].Value = comarticle.UpdateBy;
            parms[11].Value = comarticle.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComArticleEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_ComArticle_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_ComArticle_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComArticle_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComArticle_Title, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComArticle_Contents, SqlDbType.Text, 2147483647),
					new SqlParameter(Parm_ComArticle_Astatus, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComArticle_StartTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComArticle_EndTimie, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComArticle_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComArticle_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComArticle_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComArticle_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComArticle_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComArticle_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComArticle_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComArticle_Insert, parms);
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