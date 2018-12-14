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
    public class WZDSTORAGEEntity : ModelImp.BaseModel<WZDSTORAGEEntity>
    {
        public WZDSTORAGEEntity()
        {
            TB_Name = TB_WZDSTORAGE;
            Parm_Id = Parm_WZDSTORAGE_Id;
            Parm_Version = Parm_WZDSTORAGE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WZDSTORAGE_Insert;
            Sql_Update = Sql_WZDSTORAGE_Update;
            Sql_Delete = Sql_WZDSTORAGE_Delete;
        }
        #region Const of table WZDSTORAGE
        /// <summary>
        /// Table WZDSTORAGE
        /// </summary>
        public const string TB_WZDSTORAGE = "WZDSTORAGE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WZDSTORAGE_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WZDSTORAGE_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WZDSTORAGE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WZDSTORAGE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WZDSTORAGE_DEPTID = "DEPTID";
        /// <summary>
        /// Parm DESID
        /// </summary>
        public const string Parm_WZDSTORAGE_DESID = "DESID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WZDSTORAGE_Id = "Id";
        /// <summary>
        /// Parm INVALID
        /// </summary>
        public const string Parm_WZDSTORAGE_INVALID = "INVALID";
        /// <summary>
        /// Parm ISDESTROY
        /// </summary>
        public const string Parm_WZDSTORAGE_ISDESTROY = "ISDESTROY";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WZDSTORAGE_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WZDSTORAGE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WZDSTORAGE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WZDSTORAGE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WZDSTORAGE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm USEID
        /// </summary>
        public const string Parm_WZDSTORAGE_USEID = "USEID";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WZDSTORAGE_Version = "Version";
        /// <summary>
        /// Parm WSNO
        /// </summary>
        public const string Parm_WZDSTORAGE_WSNO = "WSNO";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_WZDSTORAGE_WSTATE = "WSTATE";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WZDSTORAGE_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WZDSTORAGE
        /// </summary>
        public const string Sql_WZDSTORAGE_Insert = "insert into WZDSTORAGE(AUTOID,CreateBy,CreateOn,CreatorId,DEPTID,DESID,INVALID,ISDESTROY,RECORDID,RowStatus,UpdateBy,UpdateId,UpdateOn,USEID,WSNO,WSTATE,WSTYPE) values(@AUTOID,@CreateBy,@CreateOn,@CreatorId,@DEPTID,@DESID,@INVALID,@ISDESTROY,@RECORDID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@USEID,@WSNO,@WSTATE,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WZDSTORAGE
        /// </summary>
        public const string Sql_WZDSTORAGE_Update = "update WZDSTORAGE set AUTOID=@AUTOID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,DESID=@DESID,INVALID=@INVALID,ISDESTROY=@ISDESTROY,RECORDID=@RECORDID,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,USEID=@USEID,WSNO=@WSNO,WSTATE=@WSTATE,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WZDSTORAGE_Delete = "update WZDSTORAGE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        public override WZDSTORAGEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WZDSTORAGEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WZDSTORAGEEntity();
            if (fields.Contains(Parm_WZDSTORAGE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WZDSTORAGE_Id].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WZDSTORAGE_AUTOID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WZDSTORAGE_WSTYPE].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WZDSTORAGE_RECORDID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_INVALID) || fields.Contains("*"))
                tmp.INVALID = dr[Parm_WZDSTORAGE_INVALID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_DESID) || fields.Contains("*"))
                tmp.DESID = dr[Parm_WZDSTORAGE_DESID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_USEID) || fields.Contains("*"))
                tmp.USEID = dr[Parm_WZDSTORAGE_USEID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WZDSTORAGE_DEPTID].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_WSNO) || fields.Contains("*"))
                tmp.WSNO = dr[Parm_WZDSTORAGE_WSNO].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_WZDSTORAGE_WSTATE].ToString());
            if (fields.Contains(Parm_WZDSTORAGE_ISDESTROY) || fields.Contains("*"))
                tmp.ISDESTROY = int.Parse(dr[Parm_WZDSTORAGE_ISDESTROY].ToString());
            if (fields.Contains(Parm_WZDSTORAGE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WZDSTORAGE_RowStatus].ToString());
            if (fields.Contains(Parm_WZDSTORAGE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WZDSTORAGE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WZDSTORAGE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WZDSTORAGE_CreatorId].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WZDSTORAGE_CreateBy].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WZDSTORAGE_CreateOn].ToString());
            if (fields.Contains(Parm_WZDSTORAGE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WZDSTORAGE_UpdateId].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WZDSTORAGE_UpdateBy].ToString();
            if (fields.Contains(Parm_WZDSTORAGE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WZDSTORAGE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wzdstorage">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WZDSTORAGEEntity wzdstorage, SqlParameter[] parms)
        {
            parms[0].Value = wzdstorage.AUTOID;
            parms[1].Value = wzdstorage.WSTYPE;
            parms[2].Value = wzdstorage.RECORDID;
            parms[3].Value = wzdstorage.INVALID;
            parms[4].Value = wzdstorage.DESID;
            parms[5].Value = wzdstorage.USEID;
            parms[6].Value = wzdstorage.DEPTID;
            parms[7].Value = wzdstorage.WSNO;
            parms[8].Value = wzdstorage.WSTATE;
            parms[9].Value = wzdstorage.ISDESTROY;
            parms[10].Value = wzdstorage.RowStatus;
            parms[11].Value = wzdstorage.CreatorId;
            parms[12].Value = wzdstorage.CreateBy;
            parms[13].Value = wzdstorage.CreateOn;
            parms[14].Value = wzdstorage.UpdateId;
            parms[15].Value = wzdstorage.UpdateBy;
            parms[16].Value = wzdstorage.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WZDSTORAGEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WZDSTORAGE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WZDSTORAGE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WZDSTORAGE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WZDSTORAGE_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WZDSTORAGE_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_INVALID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_DESID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_USEID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_DEPTID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_WSNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WZDSTORAGE_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WZDSTORAGE_ISDESTROY, SqlDbType.Int, 10),
					new SqlParameter(Parm_WZDSTORAGE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WZDSTORAGE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WZDSTORAGE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WZDSTORAGE_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WZDSTORAGE_Insert, parms);
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
