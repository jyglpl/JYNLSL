using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Instrument
{  /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WLYRECORDEntity : ModelImp.BaseModel<WLYRECORDEntity>
    {
        public WLYRECORDEntity()
        {
            TB_Name = TB_WLYRECORD;
            Parm_Id = Parm_WLYRECORD_Id;
            Parm_Version = Parm_WLYRECORD_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WLYRECORD_Insert;
            Sql_Update = Sql_WLYRECORD_Update;
            Sql_Delete = Sql_WLYRECORD_Delete;
        }
        #region Const of table WLYRECORD
        /// <summary>
        /// Table WLYRECORD
        /// </summary>
        public const string TB_WLYRECORD = "WLYRECORD";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CREATEBY
        /// </summary>
        public const string Parm_WLYRECORD_CREATEBY = "CREATEBY";
        /// <summary>
        /// Parm CREATEDATE
        /// </summary>
        public const string Parm_WLYRECORD_CREATEDATE = "CREATEDATE";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WLYRECORD_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WLYRECORD_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WLYRECORD_DEPTID = "DEPTID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WLYRECORD_Id = "Id";
        /// <summary>
        /// Parm LYPID
        /// </summary>
        public const string Parm_WLYRECORD_LYPID = "LYPID";
        /// <summary>
        /// Parm REMARK
        /// </summary>
        public const string Parm_WLYRECORD_REMARK = "REMARK";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WLYRECORD_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WLYRECORD_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WLYRECORD_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WLYRECORD_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WLYRECORD_Version = "Version";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_WLYRECORD_WSTATE = "WSTATE";
        /// <summary>
        /// Insert Query Of WLYRECORD
        /// </summary>
        public const string Sql_WLYRECORD_Insert = "insert into WLYRECORD(CREATEBY,CREATEDATE,CreateOn,CreatorId,DEPTID,LYPID,REMARK,RowStatus,UpdateBy,UpdateId,UpdateOn,WSTATE) values(@CREATEBY,@CREATEDATE,@CreateOn,@CreatorId,@DEPTID,@LYPID,@REMARK,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@WSTATE);select @@identity;";
        /// <summary>
        /// Update Query Of WLYRECORD
        /// </summary>
        public const string Sql_WLYRECORD_Update = "update WLYRECORD set CREATEBY=@CREATEBY,CREATEDATE=@CREATEDATE,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,LYPID=@LYPID,REMARK=@REMARK,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WSTATE=@WSTATE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WLYRECORD_Delete = "update WLYRECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _lYPID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LYPID
        {
            get { return _lYPID ?? string.Empty; }
            set { _lYPID = value; }
        }
        private string _dEPTID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DEPTID
        {
            get { return _dEPTID ?? string.Empty; }
            set { _dEPTID = value; }
        }
        private int _wSTATE;
        /// <summary>
        /// 
        /// </summary>
        public int WSTATE
        {
            get { return _wSTATE; }
            set { _wSTATE = value; }
        }
        private string _rEMARK = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string REMARK
        {
            get { return _rEMARK ?? string.Empty; }
            set { _rEMARK = value; }
        }
        private string _cREATEBY = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CREATEBY
        {
            get { return _cREATEBY ?? string.Empty; }
            set { _cREATEBY = value; }
        }
        private DateTime _cREATEDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATEDATE
        {
            get { return _cREATEDATE; }
            set { _cREATEDATE = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WLYRECORDEntity SetModelValueByDataRow(DataRow dr)
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
        public override WLYRECORDEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WLYRECORDEntity();
            if (fields.Contains(Parm_WLYRECORD_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WLYRECORD_Id].ToString();
            if (fields.Contains(Parm_WLYRECORD_LYPID) || fields.Contains("*"))
                tmp.LYPID = dr[Parm_WLYRECORD_LYPID].ToString();
            if (fields.Contains(Parm_WLYRECORD_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WLYRECORD_DEPTID].ToString();
            if (fields.Contains(Parm_WLYRECORD_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_WLYRECORD_WSTATE].ToString());
            if (fields.Contains(Parm_WLYRECORD_REMARK) || fields.Contains("*"))
                tmp.REMARK = dr[Parm_WLYRECORD_REMARK].ToString();
            if (fields.Contains(Parm_WLYRECORD_CREATEBY) || fields.Contains("*"))
                tmp.CREATEBY = dr[Parm_WLYRECORD_CREATEBY].ToString();
            if (fields.Contains(Parm_WLYRECORD_CREATEDATE) || fields.Contains("*"))
                tmp.CREATEDATE = DateTime.Parse(dr[Parm_WLYRECORD_CREATEDATE].ToString());
            if (fields.Contains(Parm_WLYRECORD_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WLYRECORD_RowStatus].ToString());
            if (fields.Contains(Parm_WLYRECORD_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WLYRECORD_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WLYRECORD_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WLYRECORD_CreatorId].ToString();
            if (fields.Contains(Parm_WLYRECORD_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WLYRECORD_CreateOn].ToString());
            if (fields.Contains(Parm_WLYRECORD_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WLYRECORD_UpdateId].ToString();
            if (fields.Contains(Parm_WLYRECORD_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WLYRECORD_UpdateBy].ToString();
            if (fields.Contains(Parm_WLYRECORD_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WLYRECORD_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wlyrecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WLYRECORDEntity wlyrecord, SqlParameter[] parms)
        {
            parms[0].Value = wlyrecord.LYPID;
            parms[1].Value = wlyrecord.DEPTID;
            parms[2].Value = wlyrecord.WSTATE;
            parms[3].Value = wlyrecord.REMARK;
            parms[4].Value = wlyrecord.CREATEBY;
            parms[5].Value = wlyrecord.CREATEDATE;
            parms[6].Value = wlyrecord.RowStatus;
            parms[7].Value = wlyrecord.CreatorId;
            parms[8].Value = wlyrecord.CreateOn;
            parms[9].Value = wlyrecord.UpdateId;
            parms[10].Value = wlyrecord.UpdateBy;
            parms[11].Value = wlyrecord.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WLYRECORDEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WLYRECORD_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WLYRECORD_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WLYRECORD_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WLYRECORD_LYPID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYRECORD_DEPTID, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WLYRECORD_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WLYRECORD_REMARK, SqlDbType.NVarChar, 400),
					new SqlParameter(Parm_WLYRECORD_CREATEBY, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYRECORD_CREATEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WLYRECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WLYRECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYRECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WLYRECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYRECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYRECORD_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WLYRECORD_Insert, parms);
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
