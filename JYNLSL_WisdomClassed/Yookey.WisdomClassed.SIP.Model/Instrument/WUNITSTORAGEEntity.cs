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
    public class WUNITSTORAGEEntity : ModelImp.BaseModel<WUNITSTORAGEEntity>
    {
        public WUNITSTORAGEEntity()
        {
            TB_Name = TB_WUNITSTORAGE;
            Parm_Id = Parm_WUNITSTORAGE_Id;
            Parm_Version = Parm_WUNITSTORAGE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WUNITSTORAGE_Insert;
            Sql_Update = Sql_WUNITSTORAGE_Update;
            Sql_Delete = Sql_WUNITSTORAGE_Delete;
        }
        #region Const of table WUNITSTORAGE
        /// <summary>
        /// Table WUNITSTORAGE
        /// </summary>
        public const string TB_WUNITSTORAGE = "WUNITSTORAGE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WUNITSTORAGE_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WUNITSTORAGE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WUNITSTORAGE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DESID
        /// </summary>
        public const string Parm_WUNITSTORAGE_DESID = "DESID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WUNITSTORAGE_Id = "Id";
        /// <summary>
        /// Parm INVALID
        /// </summary>
        public const string Parm_WUNITSTORAGE_INVALID = "INVALID";
        /// <summary>
        /// Parm ISDESTROY
        /// </summary>
        public const string Parm_WUNITSTORAGE_ISDESTROY = "ISDESTROY";
        /// <summary>
        /// Parm LYPID
        /// </summary>
        public const string Parm_WUNITSTORAGE_LYPID = "LYPID";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WUNITSTORAGE_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WUNITSTORAGE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UNIT
        /// </summary>
        public const string Parm_WUNITSTORAGE_UNIT = "UNIT";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WUNITSTORAGE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WUNITSTORAGE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WUNITSTORAGE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WUNITSTORAGE_Version = "Version";
        /// <summary>
        /// Parm WSNO
        /// </summary>
        public const string Parm_WUNITSTORAGE_WSNO = "WSNO";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_WUNITSTORAGE_WSTATE = "WSTATE";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WUNITSTORAGE_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WUNITSTORAGE
        /// </summary>
        public const string Sql_WUNITSTORAGE_Insert = "insert into WUNITSTORAGE(AUTOID,CreateOn,CreatorId,DESID,Id,INVALID,ISDESTROY,LYPID,RECORDID,RowStatus,UNIT,UpdateBy,UpdateId,UpdateOn,WSNO,WSTATE,WSTYPE) values(@AUTOID,@CreateOn,@CreatorId,@DESID,@Id,@INVALID,@ISDESTROY,@LYPID,@RECORDID,@RowStatus,@UNIT,@UpdateBy,@UpdateId,@UpdateOn,@WSNO,@WSTATE,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WUNITSTORAGE
        /// </summary>
        public const string Sql_WUNITSTORAGE_Update = "update WUNITSTORAGE set AUTOID=@AUTOID,CreateOn=@CreateOn,CreatorId=@CreatorId,DESID=@DESID,Id=@Id,INVALID=@INVALID,ISDESTROY=@ISDESTROY,LYPID=@LYPID,RECORDID=@RECORDID,RowStatus=@RowStatus,UNIT=@UNIT,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WSNO=@WSNO,WSTATE=@WSTATE,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WUNITSTORAGE_Delete = "update WUNITSTORAGE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _lYPID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LYPID
        {
            get { return _lYPID ?? string.Empty; }
            set { _lYPID = value; }
        }
        private string _uNIT = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UNIT
        {
            get { return _uNIT ?? string.Empty; }
            set { _uNIT = value; }
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
        public override WUNITSTORAGEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WUNITSTORAGEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WUNITSTORAGEEntity();
            if (fields.Contains(Parm_WUNITSTORAGE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WUNITSTORAGE_Id].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WUNITSTORAGE_AUTOID].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WUNITSTORAGE_WSTYPE].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WUNITSTORAGE_RECORDID].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_INVALID) || fields.Contains("*"))
                tmp.INVALID = dr[Parm_WUNITSTORAGE_INVALID].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_DESID) || fields.Contains("*"))
                tmp.DESID = dr[Parm_WUNITSTORAGE_DESID].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_LYPID) || fields.Contains("*"))
                tmp.LYPID = dr[Parm_WUNITSTORAGE_LYPID].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_UNIT) || fields.Contains("*"))
                tmp.UNIT = dr[Parm_WUNITSTORAGE_UNIT].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_WSNO) || fields.Contains("*"))
                tmp.WSNO = dr[Parm_WUNITSTORAGE_WSNO].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_WUNITSTORAGE_WSTATE].ToString());
            if (fields.Contains(Parm_WUNITSTORAGE_ISDESTROY) || fields.Contains("*"))
                tmp.ISDESTROY = int.Parse(dr[Parm_WUNITSTORAGE_ISDESTROY].ToString());
            if (fields.Contains(Parm_WUNITSTORAGE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WUNITSTORAGE_RowStatus].ToString());
            if (fields.Contains(Parm_WUNITSTORAGE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WUNITSTORAGE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WUNITSTORAGE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WUNITSTORAGE_CreatorId].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WUNITSTORAGE_CreateOn].ToString());
            if (fields.Contains(Parm_WUNITSTORAGE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WUNITSTORAGE_UpdateId].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WUNITSTORAGE_UpdateBy].ToString();
            if (fields.Contains(Parm_WUNITSTORAGE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn =  DateTime.Parse(dr[Parm_WUNITSTORAGE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wunitstorage">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WUNITSTORAGEEntity wunitstorage, SqlParameter[] parms)
        {
            parms[0].Value = wunitstorage.Id;
            parms[1].Value = wunitstorage.AUTOID;
            parms[2].Value = wunitstorage.WSTYPE;
            parms[3].Value = wunitstorage.RECORDID;
            parms[4].Value = wunitstorage.INVALID;
            parms[5].Value = wunitstorage.DESID;
            parms[6].Value = wunitstorage.LYPID;
            parms[7].Value = wunitstorage.UNIT;
            parms[8].Value = wunitstorage.WSNO;
            parms[9].Value = wunitstorage.WSTATE;
            parms[10].Value = wunitstorage.ISDESTROY;
            parms[11].Value = wunitstorage.RowStatus;
            parms[12].Value = wunitstorage.CreatorId;
            parms[13].Value = wunitstorage.CreateOn;
            parms[14].Value = wunitstorage.UpdateId;
            parms[15].Value = wunitstorage.UpdateBy;
            parms[16].Value = wunitstorage.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WUNITSTORAGEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WUNITSTORAGE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WUNITSTORAGE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WUNITSTORAGE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WUNITSTORAGE_Id, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WUNITSTORAGE_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_INVALID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_DESID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_LYPID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_UNIT, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_WSNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WUNITSTORAGE_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WUNITSTORAGE_ISDESTROY, SqlDbType.Int, 10),
					new SqlParameter(Parm_WUNITSTORAGE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WUNITSTORAGE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WUNITSTORAGE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WUNITSTORAGE_UpdateOn, SqlDbType.DateTime, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WUNITSTORAGE_Insert, parms);
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
