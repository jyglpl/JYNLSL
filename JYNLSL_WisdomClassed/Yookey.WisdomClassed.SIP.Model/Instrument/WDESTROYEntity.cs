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
    public class WDESTROYEntity : ModelImp.BaseModel<WDESTROYEntity>
    {
        public WDESTROYEntity()
        {
            TB_Name = TB_WDESTROY;
            Parm_Id = Parm_WDESTROY_Id;
            Parm_Version = Parm_WDESTROY_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WDESTROY_Insert;
            Sql_Update = Sql_WDESTROY_Update;
            Sql_Delete = Sql_WDESTROY_Delete;
        }
        #region Const of table WDESTROY
        /// <summary>
        /// Table WDESTROY
        /// </summary>
        public const string TB_WDESTROY = "WDESTROY";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WDESTROY_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WDESTROY_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WDESTROY_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WDESTROY_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DESTROYBY
        /// </summary>
        public const string Parm_WDESTROY_DESTROYBY = "DESTROYBY";
        /// <summary>
        /// Parm DESTROYDATE
        /// </summary>
        public const string Parm_WDESTROY_DESTROYDATE = "DESTROYDATE";
        /// <summary>
        /// Parm ENDNO
        /// </summary>
        public const string Parm_WDESTROY_ENDNO = "ENDNO";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WDESTROY_Id = "Id";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WDESTROY_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WDESTROY_RowStatus = "RowStatus";
        /// <summary>
        /// Parm STARTNO
        /// </summary>
        public const string Parm_WDESTROY_STARTNO = "STARTNO";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WDESTROY_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WDESTROY_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WDESTROY_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WDESTROY_Version = "Version";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WDESTROY_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WDESTROY
        /// </summary>
        public const string Sql_WDESTROY_Insert = "insert into WDESTROY(AUTOID,CreateBy,CreateOn,CreatorId,DESTROYBY,DESTROYDATE,ENDNO,RECORDID,RowStatus,STARTNO,UpdateBy,UpdateId,UpdateOn,WSTYPE) values(@AUTOID,@CreateBy,@CreateOn,@CreatorId,@DESTROYBY,@DESTROYDATE,@ENDNO,@RECORDID,@RowStatus,@STARTNO,@UpdateBy,@UpdateId,@UpdateOn,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WDESTROY
        /// </summary>
        public const string Sql_WDESTROY_Update = "update WDESTROY set AUTOID=@AUTOID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DESTROYBY=@DESTROYBY,DESTROYDATE=@DESTROYDATE,ENDNO=@ENDNO,RECORDID=@RECORDID,RowStatus=@RowStatus,STARTNO=@STARTNO,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WDESTROY_Delete = "update WDESTROY set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _rECORDID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RECORDID
        {
            get { return _rECORDID ?? string.Empty; }
            set { _rECORDID = value; }
        }
        private string _sTARTNO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string STARTNO
        {
            get { return _sTARTNO ?? string.Empty; }
            set { _sTARTNO = value; }
        }
        private string _eNDNO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ENDNO
        {
            get { return _eNDNO ?? string.Empty; }
            set { _eNDNO = value; }
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
        private DateTime _dESTROYDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DESTROYDATE
        {
            get { return _dESTROYDATE; }
            set { _dESTROYDATE = value; }
        }
        private string _dESTROYBY = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DESTROYBY
        {
            get { return _dESTROYBY ?? string.Empty; }
            set { _dESTROYBY = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WDESTROYEntity SetModelValueByDataRow(DataRow dr)
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
        public override WDESTROYEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WDESTROYEntity();
            if (fields.Contains(Parm_WDESTROY_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WDESTROY_Id].ToString();
            if (fields.Contains(Parm_WDESTROY_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WDESTROY_AUTOID].ToString();
            if (fields.Contains(Parm_WDESTROY_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WDESTROY_RECORDID].ToString();
            if (fields.Contains(Parm_WDESTROY_STARTNO) || fields.Contains("*"))
                tmp.STARTNO = dr[Parm_WDESTROY_STARTNO].ToString();
            if (fields.Contains(Parm_WDESTROY_ENDNO) || fields.Contains("*"))
                tmp.ENDNO = dr[Parm_WDESTROY_ENDNO].ToString();
            if (fields.Contains(Parm_WDESTROY_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WDESTROY_WSTYPE].ToString();
            if (fields.Contains(Parm_WDESTROY_DESTROYDATE) || fields.Contains("*"))
                tmp.DESTROYDATE = DateTime.Parse(dr[Parm_WDESTROY_DESTROYDATE].ToString());
            if (fields.Contains(Parm_WDESTROY_DESTROYBY) || fields.Contains("*"))
                tmp.DESTROYBY = dr[Parm_WDESTROY_DESTROYBY].ToString();
            if (fields.Contains(Parm_WDESTROY_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WDESTROY_RowStatus].ToString());
            if (fields.Contains(Parm_WDESTROY_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WDESTROY_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WDESTROY_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WDESTROY_CreatorId].ToString();
            if (fields.Contains(Parm_WDESTROY_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WDESTROY_CreateBy].ToString();
            if (fields.Contains(Parm_WDESTROY_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WDESTROY_CreateOn].ToString());
            if (fields.Contains(Parm_WDESTROY_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WDESTROY_UpdateId].ToString();
            if (fields.Contains(Parm_WDESTROY_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WDESTROY_UpdateBy].ToString();
            if (fields.Contains(Parm_WDESTROY_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WDESTROY_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wdestroy">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WDESTROYEntity wdestroy, SqlParameter[] parms)
        {
            parms[0].Value = wdestroy.AUTOID;
            parms[1].Value = wdestroy.RECORDID;
            parms[2].Value = wdestroy.STARTNO;
            parms[3].Value = wdestroy.ENDNO;
            parms[4].Value = wdestroy.WSTYPE;
            parms[5].Value = wdestroy.DESTROYDATE;
            parms[6].Value = wdestroy.DESTROYBY;
            parms[7].Value = wdestroy.RowStatus;
            parms[8].Value = wdestroy.CreatorId;
            parms[9].Value = wdestroy.CreateBy;
            parms[10].Value = wdestroy.CreateOn;
            parms[11].Value = wdestroy.UpdateId;
            parms[12].Value = wdestroy.UpdateBy;
            parms[13].Value = wdestroy.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WDESTROYEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WDESTROY_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WDESTROY_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDESTROY_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WDESTROY_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_STARTNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WDESTROY_ENDNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WDESTROY_WSTYPE, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_DESTROYDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WDESTROY_DESTROYBY, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WDESTROY_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WDESTROY_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WDESTROY_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDESTROY_Insert, parms);
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