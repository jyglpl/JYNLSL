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
    public class WDEPTSTORAGEEntity : ModelImp.BaseModel<WDEPTSTORAGEEntity>
    {
        public WDEPTSTORAGEEntity()
        {
            TB_Name = TB_WDEPTSTORAGE;
            Parm_Id = Parm_WDEPTSTORAGE_Id;
            Parm_Version = Parm_WDEPTSTORAGE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WDEPTSTORAGE_Insert;
            Sql_Update = Sql_WDEPTSTORAGE_Update;
            Sql_Delete = Sql_WDEPTSTORAGE_Delete;
        }
        #region Const of table WDEPTSTORAGE
        /// <summary>
        /// Table WDEPTSTORAGE
        /// </summary>
        public const string TB_WDEPTSTORAGE = "WDEPTSTORAGE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WDEPTSTORAGE_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WDEPTSTORAGE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WDEPTSTORAGE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_DEPTID = "DEPTID";
        /// <summary>
        /// Parm DESID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_DESID = "DESID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WDEPTSTORAGE_Id = "Id";
        /// <summary>
        /// Parm INVALID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_INVALID = "INVALID";
        /// <summary>
        /// Parm ISDESTROY
        /// </summary>
        public const string Parm_WDEPTSTORAGE_ISDESTROY = "ISDESTROY";
        /// <summary>
        /// Parm LYPID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_LYPID = "LYPID";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WDEPTSTORAGE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WDEPTSTORAGE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WDEPTSTORAGE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WDEPTSTORAGE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm USEID
        /// </summary>
        public const string Parm_WDEPTSTORAGE_USEID = "USEID";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WDEPTSTORAGE_Version = "Version";
        /// <summary>
        /// Parm WSNO
        /// </summary>
        public const string Parm_WDEPTSTORAGE_WSNO = "WSNO";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_WDEPTSTORAGE_WSTATE = "WSTATE";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WDEPTSTORAGE_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WDEPTSTORAGE
        /// </summary>
        public const string Sql_WDEPTSTORAGE_Insert = "insert into WDEPTSTORAGE(AUTOID,CreateBy,CreateOn,CreatorId,DEPTID,DESID,INVALID,ISDESTROY,LYPID,RECORDID,RowStatus,UpdateBy,UpdateId,UpdateOn,USEID,WSNO,WSTATE,WSTYPE) values(@AUTOID,@CreateBy,@CreateOn,@CreatorId,@DEPTID,@DESID,@INVALID,@ISDESTROY,@LYPID,@RECORDID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@USEID,@WSNO,@WSTATE,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WDEPTSTORAGE
        /// </summary>
        public const string Sql_WDEPTSTORAGE_Update = "update WDEPTSTORAGE set AUTOID=@AUTOID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,DESID=@DESID,INVALID=@INVALID,ISDESTROY=@ISDESTROY,LYPID=@LYPID,RECORDID=@RECORDID,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,USEID=@USEID,WSNO=@WSNO,WSTATE=@WSTATE,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WDEPTSTORAGE_Delete = "update WDEPTSTORAGE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _aUTOID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AUTOID
        {
            get { return _aUTOID ?? string.Empty; }
            set { _aUTOID = value; }
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
        private string _rECORDID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RECORDID
        {
            get { return _rECORDID ?? string.Empty; }
            set { _rECORDID = value; }
        }
        private string _iNVALID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string INVALID
        {
            get { return _iNVALID ?? string.Empty; }
            set { _iNVALID = value; }
        }
        private string _dESID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DESID
        {
            get { return _dESID ?? string.Empty; }
            set { _dESID = value; }
        }
        private string _uSEID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string USEID
        {
            get { return _uSEID ?? string.Empty; }
            set { _uSEID = value; }
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
        private string _lYPID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LYPID
        {
            get { return _lYPID ?? string.Empty; }
            set { _lYPID = value; }
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
        private int _iSDESTROY;
        /// <summary>
        /// 
        /// </summary>
        public int ISDESTROY
        {
            get { return _iSDESTROY; }
            set { _iSDESTROY = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WDEPTSTORAGEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WDEPTSTORAGEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WDEPTSTORAGEEntity();
            if (fields.Contains(Parm_WDEPTSTORAGE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WDEPTSTORAGE_Id].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WDEPTSTORAGE_AUTOID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WDEPTSTORAGE_WSTYPE].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WDEPTSTORAGE_RECORDID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_INVALID) || fields.Contains("*"))
                tmp.INVALID = dr[Parm_WDEPTSTORAGE_INVALID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_DESID) || fields.Contains("*"))
                tmp.DESID = dr[Parm_WDEPTSTORAGE_DESID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_USEID) || fields.Contains("*"))
                tmp.USEID = dr[Parm_WDEPTSTORAGE_USEID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WDEPTSTORAGE_DEPTID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_WSNO) || fields.Contains("*"))
                tmp.WSNO = dr[Parm_WDEPTSTORAGE_WSNO].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_LYPID) || fields.Contains("*"))
                tmp.LYPID = dr[Parm_WDEPTSTORAGE_LYPID].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_WDEPTSTORAGE_WSTATE].ToString());
            if (fields.Contains(Parm_WDEPTSTORAGE_ISDESTROY) || fields.Contains("*"))
                tmp.ISDESTROY = int.Parse(dr[Parm_WDEPTSTORAGE_ISDESTROY].ToString());
            if (fields.Contains(Parm_WDEPTSTORAGE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WDEPTSTORAGE_RowStatus].ToString());
            if (fields.Contains(Parm_WDEPTSTORAGE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WDEPTSTORAGE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WDEPTSTORAGE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WDEPTSTORAGE_CreatorId].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WDEPTSTORAGE_CreateBy].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WDEPTSTORAGE_CreateOn].ToString());
            if (fields.Contains(Parm_WDEPTSTORAGE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WDEPTSTORAGE_UpdateId].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WDEPTSTORAGE_UpdateBy].ToString();
            if (fields.Contains(Parm_WDEPTSTORAGE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WDEPTSTORAGE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wdeptstorage">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WDEPTSTORAGEEntity wdeptstorage, SqlParameter[] parms)
        {
            parms[0].Value = wdeptstorage.AUTOID;
            parms[1].Value = wdeptstorage.WSTYPE;
            parms[2].Value = wdeptstorage.RECORDID;
            parms[3].Value = wdeptstorage.INVALID;
            parms[4].Value = wdeptstorage.DESID;
            parms[5].Value = wdeptstorage.USEID;
            parms[6].Value = wdeptstorage.DEPTID;
            parms[7].Value = wdeptstorage.WSNO;
            parms[8].Value = wdeptstorage.LYPID;
            parms[9].Value = wdeptstorage.WSTATE;
            parms[10].Value = wdeptstorage.ISDESTROY;
            parms[11].Value = wdeptstorage.RowStatus;
            parms[12].Value = wdeptstorage.CreatorId;
            parms[13].Value = wdeptstorage.CreateBy;
            parms[14].Value = wdeptstorage.CreateOn;
            parms[15].Value = wdeptstorage.UpdateId;
            parms[16].Value = wdeptstorage.UpdateBy;
            parms[17].Value = wdeptstorage.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WDEPTSTORAGEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WDEPTSTORAGE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WDEPTSTORAGE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDEPTSTORAGE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WDEPTSTORAGE_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WDEPTSTORAGE_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_INVALID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_DESID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_USEID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_DEPTID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_WSNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WDEPTSTORAGE_LYPID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WDEPTSTORAGE_ISDESTROY, SqlDbType.Int, 10),
					new SqlParameter(Parm_WDEPTSTORAGE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WDEPTSTORAGE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WDEPTSTORAGE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDEPTSTORAGE_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDEPTSTORAGE_Insert, parms);
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
