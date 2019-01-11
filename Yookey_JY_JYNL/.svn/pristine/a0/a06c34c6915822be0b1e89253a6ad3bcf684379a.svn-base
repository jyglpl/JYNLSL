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
    public class WBRIGADEEntity : ModelImp.BaseModel<WBRIGADEEntity>
    {
        public WBRIGADEEntity()
        {
            TB_Name = TB_WBRIGADE;
            Parm_Id = Parm_WBRIGADE_Id;
            Parm_Version = Parm_WBRIGADE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WBRIGADE_Insert;
            Sql_Update = Sql_WBRIGADE_Update;
            Sql_Delete = Sql_WBRIGADE_Delete;
        }
        #region Const of table WBRIGADE
        /// <summary>
        /// Table WBRIGADE
        /// </summary>
        public const string TB_WBRIGADE = "WBRIGADE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WBRIGADE_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WBRIGADE_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WBRIGADE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WBRIGADE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WBRIGADE_Id = "Id";
        /// <summary>
        /// Parm ISDESTROY
        /// </summary>
        public const string Parm_WBRIGADE_ISDESTROY = "ISDESTROY";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WBRIGADE_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WBRIGADE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WBRIGADE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WBRIGADE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WBRIGADE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm USEDATE
        /// </summary>
        public const string Parm_WBRIGADE_USEDATE = "USEDATE";
        /// <summary>
        /// Parm USERS
        /// </summary>
        public const string Parm_WBRIGADE_USERS = "USERS";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WBRIGADE_Version = "Version";
        /// <summary>
        /// Parm WCREATEDATE
        /// </summary>
        public const string Parm_WBRIGADE_WCREATEDATE = "WCREATEDATE";
        /// <summary>
        /// Parm WSNO
        /// </summary>
        public const string Parm_WBRIGADE_WSNO = "WSNO";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_WBRIGADE_WSTATE = "WSTATE";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WBRIGADE_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WBRIGADE
        /// </summary>
        public const string Sql_WBRIGADE_Insert = "insert into WBRIGADE(AUTOID,CreateBy,CreateOn,CreatorId,Id,ISDESTROY,RECORDID,RowStatus,UpdateBy,UpdateId,UpdateOn,USEDATE,USERS,WCREATEDATE,WSNO,WSTATE,WSTYPE) values(@AUTOID,@CreateBy,@CreateOn,@CreatorId,@Id,@ISDESTROY,@RECORDID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@USEDATE,@USERS,@WCREATEDATE,@WSNO,@WSTATE,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WBRIGADE
        /// </summary>
        public const string Sql_WBRIGADE_Update = "update WBRIGADE set AUTOID=@AUTOID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Id=@Id,ISDESTROY=@ISDESTROY,RECORDID=@RECORDID,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,USEDATE=@USEDATE,USERS=@USERS,WCREATEDATE=@WCREATEDATE,WSNO=@WSNO,WSTATE=@WSTATE,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WBRIGADE_Delete = "update WBRIGADE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _uSERS = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string USERS
        {
            get { return _uSERS ?? string.Empty; }
            set { _uSERS = value; }
        }
        private DateTime _uSEDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime USEDATE
        {
            get { return _uSEDATE; }
            set { _uSEDATE = value; }
        }
        private DateTime _wCREATEDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime WCREATEDATE
        {
            get { return _wCREATEDATE; }
            set { _wCREATEDATE = value; }
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
        public override WBRIGADEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WBRIGADEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WBRIGADEEntity();
            if (fields.Contains(Parm_WBRIGADE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WBRIGADE_Id].ToString();
            if (fields.Contains(Parm_WBRIGADE_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WBRIGADE_AUTOID].ToString();
            if (fields.Contains(Parm_WBRIGADE_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WBRIGADE_WSTYPE].ToString();
            if (fields.Contains(Parm_WBRIGADE_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WBRIGADE_RECORDID].ToString();
            if (fields.Contains(Parm_WBRIGADE_WSNO) || fields.Contains("*"))
                tmp.WSNO = dr[Parm_WBRIGADE_WSNO].ToString();
            if (fields.Contains(Parm_WBRIGADE_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_WBRIGADE_WSTATE].ToString());
            if (fields.Contains(Parm_WBRIGADE_USERS) || fields.Contains("*"))
                tmp.USERS = dr[Parm_WBRIGADE_USERS].ToString();
            if (fields.Contains(Parm_WBRIGADE_USEDATE) || fields.Contains("*"))
                tmp.USEDATE = DateTime.Parse(dr[Parm_WBRIGADE_USEDATE].ToString());
            if (fields.Contains(Parm_WBRIGADE_WCREATEDATE) || fields.Contains("*"))
                tmp.WCREATEDATE = DateTime.Parse(dr[Parm_WBRIGADE_WCREATEDATE].ToString());
            if (fields.Contains(Parm_WBRIGADE_ISDESTROY) || fields.Contains("*"))
                tmp.ISDESTROY = int.Parse(dr[Parm_WBRIGADE_ISDESTROY].ToString());
            if (fields.Contains(Parm_WBRIGADE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WBRIGADE_RowStatus].ToString());
            if (fields.Contains(Parm_WBRIGADE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WBRIGADE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WBRIGADE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WBRIGADE_CreatorId].ToString();
            if (fields.Contains(Parm_WBRIGADE_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WBRIGADE_CreateBy].ToString();
            if (fields.Contains(Parm_WBRIGADE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WBRIGADE_CreateOn].ToString());
            if (fields.Contains(Parm_WBRIGADE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WBRIGADE_UpdateId].ToString();
            if (fields.Contains(Parm_WBRIGADE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WBRIGADE_UpdateBy].ToString();
            if (fields.Contains(Parm_WBRIGADE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WBRIGADE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wbrigade">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WBRIGADEEntity wbrigade, SqlParameter[] parms)
        {
            parms[0].Value = wbrigade.Id;
            parms[1].Value = wbrigade.AUTOID;
            parms[2].Value = wbrigade.WSTYPE;
            parms[3].Value = wbrigade.RECORDID;
            parms[4].Value = wbrigade.WSNO;
            parms[5].Value = wbrigade.WSTATE;
            parms[6].Value = wbrigade.USERS;
            parms[7].Value = wbrigade.USEDATE;
            parms[8].Value = wbrigade.WCREATEDATE;
            parms[9].Value = wbrigade.ISDESTROY;
            parms[10].Value = wbrigade.RowStatus;
            parms[11].Value = wbrigade.CreatorId;
            parms[12].Value = wbrigade.CreateBy;
            parms[13].Value = wbrigade.CreateOn;
            parms[14].Value = wbrigade.UpdateId;
            parms[15].Value = wbrigade.UpdateBy;
            parms[16].Value = wbrigade.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WBRIGADEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WBRIGADE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WBRIGADE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WBRIGADE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WBRIGADE_Id, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WBRIGADE_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_WSNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WBRIGADE_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_WBRIGADE_USERS, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_USEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WBRIGADE_WCREATEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WBRIGADE_ISDESTROY, SqlDbType.Int, 10),
					new SqlParameter(Parm_WBRIGADE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WBRIGADE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WBRIGADE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WBRIGADE_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WBRIGADE_Insert, parms);
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