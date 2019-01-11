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
    public class WSTOCKCRECORDEntity : ModelImp.BaseModel<WSTOCKCRECORDEntity>
    {
        public WSTOCKCRECORDEntity()
        {
            TB_Name = TB_WSTOCKCRECORD;
            Parm_Id = Parm_WSTOCKCRECORD_Id;
            Parm_Version = Parm_WSTOCKCRECORD_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WSTOCKCRECORD_Insert;
            Sql_Update = Sql_WSTOCKCRECORD_Update;
            Sql_Delete = Sql_WSTOCKCRECORD_Delete;
        }
        #region Const of table WSTOCKCRECORD
        /// <summary>
        /// Table WSTOCKCRECORD
        /// </summary>
        public const string TB_WSTOCKCRECORD = "WSTOCKCRECORD";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BCOUNT
        /// </summary>
        public const string Parm_WSTOCKCRECORD_BCOUNT = "BCOUNT";
        /// <summary>
        /// Parm CHILDID
        /// </summary>
        public const string Parm_WSTOCKCRECORD_CHILDID = "CHILDID";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WSTOCKCRECORD_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WSTOCKCRECORD_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WSTOCKCRECORD_Id = "Id";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WSTOCKCRECORD_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WSTOCKCRECORD_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WSTOCKCRECORD_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WSTOCKCRECORD_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WSTOCKCRECORD_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WSTOCKCRECORD_Version = "Version";
        /// <summary>
        /// Parm WCOUNT
        /// </summary>
        public const string Parm_WSTOCKCRECORD_WCOUNT = "WCOUNT";
        /// <summary>
        /// Parm WENDNO
        /// </summary>
        public const string Parm_WSTOCKCRECORD_WENDNO = "WENDNO";
        /// <summary>
        /// Parm WSTARTNO
        /// </summary>
        public const string Parm_WSTOCKCRECORD_WSTARTNO = "WSTARTNO";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WSTOCKCRECORD_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WSTOCKCRECORD
        /// </summary>
        public const string Sql_WSTOCKCRECORD_Insert = "insert into WSTOCKCRECORD(BCOUNT,CHILDID,CreateOn,CreatorId,RECORDID,RowStatus,UpdateBy,UpdateId,UpdateOn,WCOUNT,WENDNO,WSTARTNO,WSTYPE) values(@BCOUNT,@CHILDID,@CreateOn,@CreatorId,@RECORDID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@WCOUNT,@WENDNO,@WSTARTNO,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WSTOCKCRECORD
        /// </summary>
        public const string Sql_WSTOCKCRECORD_Update = "update WSTOCKCRECORD set BCOUNT=@BCOUNT,CHILDID=@CHILDID,CreateOn=@CreateOn,CreatorId=@CreatorId,RECORDID=@RECORDID,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WCOUNT=@WCOUNT,WENDNO=@WENDNO,WSTARTNO=@WSTARTNO,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WSTOCKCRECORD_Delete = "update WSTOCKCRECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _cHILDID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CHILDID
        {
            get { return _cHILDID ?? string.Empty; }
            set { _cHILDID = value; }
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
        private string _wSTYPE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WSTYPE
        {
            get { return _wSTYPE ?? string.Empty; }
            set { _wSTYPE = value; }
        }
        private int _bCOUNT;
        /// <summary>
        /// 
        /// </summary>
        public int BCOUNT
        {
            get { return _bCOUNT; }
            set { _bCOUNT = value; }
        }
        private int _wCOUNT;
        /// <summary>
        /// 
        /// </summary>
        public int WCOUNT
        {
            get { return _wCOUNT; }
            set { _wCOUNT = value; }
        }
        private string _wSTARTNO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WSTARTNO
        {
            get { return _wSTARTNO ?? string.Empty; }
            set { _wSTARTNO = value; }
        }
        private string _wENDNO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WENDNO
        {
            get { return _wENDNO ?? string.Empty; }
            set { _wENDNO = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WSTOCKCRECORDEntity SetModelValueByDataRow(DataRow dr)
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
        public override WSTOCKCRECORDEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WSTOCKCRECORDEntity();
            if (fields.Contains(Parm_WSTOCKCRECORD_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WSTOCKCRECORD_Id].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_CHILDID) || fields.Contains("*"))
                tmp.CHILDID = dr[Parm_WSTOCKCRECORD_CHILDID].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WSTOCKCRECORD_RECORDID].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WSTOCKCRECORD_WSTYPE].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_BCOUNT) || fields.Contains("*"))
                tmp.BCOUNT = int.Parse(dr[Parm_WSTOCKCRECORD_BCOUNT].ToString());
            if (fields.Contains(Parm_WSTOCKCRECORD_WCOUNT) || fields.Contains("*"))
                tmp.WCOUNT = int.Parse(dr[Parm_WSTOCKCRECORD_WCOUNT].ToString());
            if (fields.Contains(Parm_WSTOCKCRECORD_WSTARTNO) || fields.Contains("*"))
                tmp.WSTARTNO = dr[Parm_WSTOCKCRECORD_WSTARTNO].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_WENDNO) || fields.Contains("*"))
                tmp.WENDNO = dr[Parm_WSTOCKCRECORD_WENDNO].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WSTOCKCRECORD_RowStatus].ToString());
            if (fields.Contains(Parm_WSTOCKCRECORD_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WSTOCKCRECORD_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WSTOCKCRECORD_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WSTOCKCRECORD_CreatorId].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WSTOCKCRECORD_CreateOn].ToString());
            if (fields.Contains(Parm_WSTOCKCRECORD_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WSTOCKCRECORD_UpdateId].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WSTOCKCRECORD_UpdateBy].ToString();
            if (fields.Contains(Parm_WSTOCKCRECORD_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WSTOCKCRECORD_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wstockcrecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WSTOCKCRECORDEntity wstockcrecord, SqlParameter[] parms)
        {
            parms[0].Value = wstockcrecord.CHILDID;
            parms[1].Value = wstockcrecord.RECORDID;
            parms[2].Value = wstockcrecord.WSTYPE;
            parms[3].Value = wstockcrecord.BCOUNT;
            parms[4].Value = wstockcrecord.WCOUNT;
            parms[5].Value = wstockcrecord.WSTARTNO;
            parms[6].Value = wstockcrecord.WENDNO;
            parms[7].Value = wstockcrecord.RowStatus;
            parms[8].Value = wstockcrecord.CreatorId;
            parms[9].Value = wstockcrecord.CreateOn;
            parms[10].Value = wstockcrecord.UpdateId;
            parms[11].Value = wstockcrecord.UpdateBy;
            parms[12].Value = wstockcrecord.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WSTOCKCRECORDEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WSTOCKCRECORD_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WSTOCKCRECORD_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKCRECORD_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WSTOCKCRECORD_CHILDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKCRECORD_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKCRECORD_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WSTOCKCRECORD_BCOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKCRECORD_WCOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKCRECORD_WSTARTNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WSTOCKCRECORD_WENDNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WSTOCKCRECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKCRECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKCRECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WSTOCKCRECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKCRECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKCRECORD_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKCRECORD_Insert, parms);
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
