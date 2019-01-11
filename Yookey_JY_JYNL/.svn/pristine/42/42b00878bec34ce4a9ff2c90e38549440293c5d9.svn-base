using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.ShowVideo
{
    /// <summary>
    /// 视频演示
    /// </summary>
    [Serializable]
    public class ShowVideoEntity : ModelImp.BaseModel<ShowVideoEntity>
    {
        public ShowVideoEntity()
        {
            TB_Name = TB_ShowVideo;
            Parm_Id = Parm_ShowVideo_Id;
            Parm_Version = Parm_ShowVideo_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ShowVideo_Insert;
            Sql_Update = Sql_ShowVideo_Update;
            Sql_Delete = Sql_ShowVideo_Delete;
        }
        #region Const of table ShowVideo
        /// <summary>
        /// Table ShowVideo
        /// </summary>
        public const string TB_ShowVideo = "ShowVideo";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ShowVideo_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ShowVideo_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ShowVideo_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ShowVideo_Id = "Id";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_ShowVideo_OrderNo = "OrderNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ShowVideo_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Title
        /// </summary>
        public const string Parm_ShowVideo_Title = "Title";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ShowVideo_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ShowVideo_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ShowVideo_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UrL
        /// </summary>
        public const string Parm_ShowVideo_UrL = "UrL";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ShowVideo_Version = "Version";
        /// <summary>
        /// Insert Query Of ShowVideo
        /// </summary>
        public const string Sql_ShowVideo_Insert = "insert into ShowVideo(CreateBy,CreateOn,CreatorId,OrderNo,RowStatus,Title,UpdateBy,UpdateId,UpdateOn,UrL,Id) values(@CreateBy,@CreateOn,@CreatorId,@OrderNo,@RowStatus,@Title,@UpdateBy,@UpdateId,@UpdateOn,@UrL,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ShowVideo
        /// </summary>
        public const string Sql_ShowVideo_Update = "update ShowVideo set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OrderNo=@OrderNo,RowStatus=@RowStatus,Title=@Title,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UrL=@UrL where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ShowVideo_Delete = "update ShowVideo set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _urL = string.Empty;
        /// <summary>
        /// 路径
        /// </summary>
        public string UrL
        {
            get { return _urL ?? string.Empty; }
            set { _urL = value; }
        }
        private string _title = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string Title
        {
            get { return _title ?? string.Empty; }
            set { _title = value; }
        }
        private int _orderNo;
        /// <summary>
        /// 
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
        public override ShowVideoEntity SetModelValueByDataRow(DataRow dr)
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
        public override ShowVideoEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ShowVideoEntity();
            if (fields.Contains(Parm_ShowVideo_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ShowVideo_Id].ToString();
            if (fields.Contains(Parm_ShowVideo_UrL) || fields.Contains("*"))
                tmp.UrL = dr[Parm_ShowVideo_UrL].ToString();
            if (fields.Contains(Parm_ShowVideo_Title) || fields.Contains("*"))
                tmp.Title = dr[Parm_ShowVideo_Title].ToString();
            if (fields.Contains(Parm_ShowVideo_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_ShowVideo_OrderNo].ToString());
            if (fields.Contains(Parm_ShowVideo_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ShowVideo_RowStatus].ToString());
            if (fields.Contains(Parm_ShowVideo_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ShowVideo_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ShowVideo_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ShowVideo_CreatorId].ToString();
            if (fields.Contains(Parm_ShowVideo_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ShowVideo_CreateBy].ToString();
            if (fields.Contains(Parm_ShowVideo_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ShowVideo_CreateOn].ToString());
            if (fields.Contains(Parm_ShowVideo_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ShowVideo_UpdateId].ToString();
            if (fields.Contains(Parm_ShowVideo_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ShowVideo_UpdateBy].ToString();
            if (fields.Contains(Parm_ShowVideo_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ShowVideo_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="showvideo">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ShowVideoEntity showvideo, SqlParameter[] parms)
        {
            parms[0].Value = showvideo.UrL;
            parms[1].Value = showvideo.Title;
            parms[2].Value = showvideo.OrderNo;
            parms[3].Value = showvideo.RowStatus;
            parms[4].Value = showvideo.CreatorId;
            parms[5].Value = showvideo.CreateBy;
            parms[6].Value = showvideo.CreateOn;
            parms[7].Value = showvideo.UpdateId;
            parms[8].Value = showvideo.UpdateBy;
            parms[9].Value = showvideo.UpdateOn;
            parms[10].Value = showvideo.Id;

            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ShowVideoEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ShowVideo_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ShowVideo_UrL, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_ShowVideo_Title, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_ShowVideo_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_ShowVideo_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ShowVideo_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ShowVideo_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ShowVideo_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ShowVideo_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ShowVideo_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ShowVideo_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ShowVideo_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ShowVideo_Insert, parms);
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
