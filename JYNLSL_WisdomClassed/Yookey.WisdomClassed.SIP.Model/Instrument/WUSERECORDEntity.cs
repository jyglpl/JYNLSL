using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Instrument
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WUSERECORDEntity : ModelImp.BaseModel<WUSERECORDEntity>
    {
        public WUSERECORDEntity()
        {
            TB_Name = TB_WUSERECORD;
            Parm_Id = Parm_WUSERECORD_Id;
            Parm_Version = Parm_WUSERECORD_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WUSERECORD_Insert;
            Sql_Update = Sql_WUSERECORD_Update;
            Sql_Delete = Sql_WUSERECORD_Delete;
        }
        #region Const of table WUSERECORD
        /// <summary>
        /// Table WUSERECORD
        /// </summary>
        public const string TB_WUSERECORD = "WUSERECORD";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CREATEBY
        /// </summary>
        public const string Parm_WUSERECORD_CREATEBY = "CREATEBY";
        /// <summary>
        /// Parm CREATEDATE
        /// </summary>
        public const string Parm_WUSERECORD_CREATEDATE = "CREATEDATE";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WUSERECORD_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WUSERECORD_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WUSERECORD_DEPTID = "DEPTID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WUSERECORD_Id = "Id";
        /// <summary>
        /// Parm ISDELETE
        /// </summary>
        public const string Parm_WUSERECORD_ISDELETE = "ISDELETE";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WUSERECORD_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WUSERECORD_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WUSERECORD_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WUSERECORD_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm USEID
        /// </summary>
        public const string Parm_WUSERECORD_USEID = "USEID";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WUSERECORD_Version = "Version";
        /// <summary>
        /// Parm WSNO
        /// </summary>
        public const string Parm_WUSERECORD_WSNO = "WSNO";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WUSERECORD_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WUSERECORD
        /// </summary>
        public const string Sql_WUSERECORD_Insert = "insert into WUSERECORD(CREATEBY,CREATEDATE,CreateOn,CreatorId,DEPTID,ISDELETE,RowStatus,UpdateBy,UpdateId,UpdateOn,USEID,WSNO,WSTYPE) values(@CREATEBY,@CREATEDATE,@CreateOn,@CreatorId,@DEPTID,@ISDELETE,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@USEID,@WSNO,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WUSERECORD
        /// </summary>
        public const string Sql_WUSERECORD_Update = "update WUSERECORD set CREATEBY=@CREATEBY,CREATEDATE=@CREATEDATE,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,ISDELETE=@ISDELETE,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,USEID=@USEID,WSNO=@WSNO,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WUSERECORD_Delete = "update WUSERECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _uSEID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string USEID
        {
            get { return _uSEID ?? string.Empty; }
            set { _uSEID = value; }
        }
        private string _wSTYPE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WSTYPE
        {
            get { return _wSTYPE ?? string.Empty; }
            set { _wSTYPE = value; }
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
        private string _wSNO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WSNO
        {
            get { return _wSNO ?? string.Empty; }
            set { _wSNO = value; }
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
        private int _iSDELETE;
        /// <summary>
        /// 
        /// </summary>
        public int ISDELETE
        {
            get { return _iSDELETE; }
            set { _iSDELETE = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WUSERECORDEntity SetModelValueByDataRow(DataRow dr)
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
        public override WUSERECORDEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WUSERECORDEntity();
            if (fields.Contains(Parm_WUSERECORD_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WUSERECORD_Id].ToString();
            if (fields.Contains(Parm_WUSERECORD_USEID) || fields.Contains("*"))
                tmp.USEID = dr[Parm_WUSERECORD_USEID].ToString();
            if (fields.Contains(Parm_WUSERECORD_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WUSERECORD_WSTYPE].ToString();
            if (fields.Contains(Parm_WUSERECORD_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WUSERECORD_DEPTID].ToString();
            if (fields.Contains(Parm_WUSERECORD_WSNO) || fields.Contains("*"))
                tmp.WSNO = dr[Parm_WUSERECORD_WSNO].ToString();
            if (fields.Contains(Parm_WUSERECORD_CREATEBY) || fields.Contains("*"))
                tmp.CREATEBY = dr[Parm_WUSERECORD_CREATEBY].ToString();
            if (fields.Contains(Parm_WUSERECORD_CREATEDATE) || fields.Contains("*"))
                tmp.CREATEDATE = DateTime.Parse(dr[Parm_WUSERECORD_CREATEDATE].ToString());
            if (fields.Contains(Parm_WUSERECORD_ISDELETE) || fields.Contains("*"))
                tmp.ISDELETE = int.Parse(dr[Parm_WUSERECORD_ISDELETE].ToString());
            if (fields.Contains(Parm_WUSERECORD_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WUSERECORD_RowStatus].ToString());
            if (fields.Contains(Parm_WUSERECORD_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WUSERECORD_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WUSERECORD_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WUSERECORD_CreatorId].ToString();
            if (fields.Contains(Parm_WUSERECORD_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WUSERECORD_CreateOn].ToString());
            if (fields.Contains(Parm_WUSERECORD_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WUSERECORD_UpdateId].ToString();
            if (fields.Contains(Parm_WUSERECORD_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WUSERECORD_UpdateBy].ToString();
            if (fields.Contains(Parm_WUSERECORD_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WUSERECORD_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wuserecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WUSERECORDEntity wuserecord, SqlParameter[] parms)
        {
            parms[0].Value = wuserecord.USEID;
            parms[1].Value = wuserecord.WSTYPE;
            parms[2].Value = wuserecord.DEPTID;
            parms[3].Value = wuserecord.WSNO;
            parms[4].Value = wuserecord.CREATEBY;
            parms[5].Value = wuserecord.CREATEDATE;
            parms[6].Value = wuserecord.ISDELETE;
            parms[7].Value = wuserecord.RowStatus;
            parms[8].Value = wuserecord.CreatorId;
            parms[9].Value = wuserecord.CreateOn;
            parms[10].Value = wuserecord.UpdateId;
            parms[11].Value = wuserecord.UpdateBy;
            parms[12].Value = wuserecord.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WUSERECORDEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WUSERECORD_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WUSERECORD_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WUSERECORD_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WUSERECORD_USEID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WUSERECORD_DEPTID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_WSNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WUSERECORD_CREATEBY, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_CREATEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WUSERECORD_ISDELETE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WUSERECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WUSERECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WUSERECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUSERECORD_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WUSERECORD_Insert, parms);
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
