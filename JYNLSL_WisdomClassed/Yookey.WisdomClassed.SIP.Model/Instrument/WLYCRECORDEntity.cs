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
    public class WLYCRECORDEntity : ModelImp.BaseModel<WLYCRECORDEntity>
    {
        public WLYCRECORDEntity()
        {
            TB_Name = TB_WLYCRECORD;
            Parm_Id = Parm_WLYCRECORD_Id;
            Parm_Version = Parm_WLYCRECORD_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WLYCRECORD_Insert;
            Sql_Update = Sql_WLYCRECORD_Update;
            Sql_Delete = Sql_WLYCRECORD_Delete;
        }
        #region Const of table WLYCRECORD
        /// <summary>
        /// Table WLYCRECORD
        /// </summary>
        public const string TB_WLYCRECORD = "WLYCRECORD";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WLYCRECORD_AUTOID = "AUTOID";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_WLYCRECORD_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WLYCRECORD_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WLYCRECORD_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WLYCRECORD_DEPTID = "DEPTID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WLYCRECORD_Id = "Id";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WLYCRECORD_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WLYCRECORD_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WLYCRECORD_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WLYCRECORD_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WLYCRECORD_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WLYCRECORD_Version = "Version";
        /// <summary>
        /// Parm WCOUNT
        /// </summary>
        public const string Parm_WLYCRECORD_WCOUNT = "WCOUNT";
        /// <summary>
        /// Parm WCREATEDATE
        /// </summary>
        public const string Parm_WLYCRECORD_WCREATEDATE = "WCREATEDATE";
        /// <summary>
        /// Parm WENDNO
        /// </summary>
        public const string Parm_WLYCRECORD_WENDNO = "WENDNO";
        /// <summary>
        /// Parm WSTARTNO
        /// </summary>
        public const string Parm_WLYCRECORD_WSTARTNO = "WSTARTNO";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WLYCRECORD_WSTYPE = "WSTYPE";
        /// <summary>
        /// Parm WUSER
        /// </summary>
        public const string Parm_WLYCRECORD_WUSER = "WUSER";
        /// <summary>
        /// Insert Query Of WLYCRECORD
        /// </summary>
        public const string Sql_WLYCRECORD_Insert = "insert into WLYCRECORD(AUTOID,CreateBy,CreateOn,CreatorId,DEPTID,RECORDID,RowStatus,UpdateBy,UpdateId,UpdateOn,WCOUNT,WCREATEDATE,WENDNO,WSTARTNO,WSTYPE,WUSER) values(@AUTOID,@CreateBy,@CreateOn,@CreatorId,@DEPTID,@RECORDID,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@WCOUNT,@WCREATEDATE,@WENDNO,@WSTARTNO,@WSTYPE,@WUSER);select @@identity;";
        /// <summary>
        /// Update Query Of WLYCRECORD
        /// </summary>
        public const string Sql_WLYCRECORD_Update = "update WLYCRECORD set AUTOID=@AUTOID,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,RECORDID=@RECORDID,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WCOUNT=@WCOUNT,WCREATEDATE=@WCREATEDATE,WENDNO=@WENDNO,WSTARTNO=@WSTARTNO,WSTYPE=@WSTYPE,WUSER=@WUSER where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WLYCRECORD_Delete = "update WLYCRECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _wUSER = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WUSER
        {
            get { return _wUSER ?? string.Empty; }
            set { _wUSER = value; }
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WLYCRECORDEntity SetModelValueByDataRow(DataRow dr)
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
        public override WLYCRECORDEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WLYCRECORDEntity();
            if (fields.Contains(Parm_WLYCRECORD_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WLYCRECORD_Id].ToString();
            if (fields.Contains(Parm_WLYCRECORD_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WLYCRECORD_AUTOID].ToString();
            if (fields.Contains(Parm_WLYCRECORD_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WLYCRECORD_RECORDID].ToString();
            if (fields.Contains(Parm_WLYCRECORD_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WLYCRECORD_WSTYPE].ToString();
            if (fields.Contains(Parm_WLYCRECORD_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WLYCRECORD_DEPTID].ToString();
            if (fields.Contains(Parm_WLYCRECORD_WCOUNT) || fields.Contains("*"))
                tmp.WCOUNT = int.Parse(dr[Parm_WLYCRECORD_WCOUNT].ToString());
            if (fields.Contains(Parm_WLYCRECORD_WSTARTNO) || fields.Contains("*"))
                tmp.WSTARTNO = dr[Parm_WLYCRECORD_WSTARTNO].ToString();
            if (fields.Contains(Parm_WLYCRECORD_WENDNO) || fields.Contains("*"))
                tmp.WENDNO = dr[Parm_WLYCRECORD_WENDNO].ToString();
            if (fields.Contains(Parm_WLYCRECORD_WUSER) || fields.Contains("*"))
                tmp.WUSER = dr[Parm_WLYCRECORD_WUSER].ToString();
            if (fields.Contains(Parm_WLYCRECORD_WCREATEDATE) || fields.Contains("*"))
                tmp.WCREATEDATE = DateTime.Parse(dr[Parm_WLYCRECORD_WCREATEDATE].ToString());
            if (fields.Contains(Parm_WLYCRECORD_RowStatus) || fields.Contains("*"))
                tmp.RowStatus =int.Parse( dr[Parm_WLYCRECORD_RowStatus].ToString());
            if (fields.Contains(Parm_WLYCRECORD_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WLYCRECORD_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WLYCRECORD_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WLYCRECORD_CreatorId].ToString();
            if (fields.Contains(Parm_WLYCRECORD_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_WLYCRECORD_CreateBy].ToString();
            if (fields.Contains(Parm_WLYCRECORD_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WLYCRECORD_CreateOn].ToString());
            if (fields.Contains(Parm_WLYCRECORD_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WLYCRECORD_UpdateId].ToString();
            if (fields.Contains(Parm_WLYCRECORD_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WLYCRECORD_UpdateBy].ToString();
            if (fields.Contains(Parm_WLYCRECORD_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WLYCRECORD_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wlycrecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WLYCRECORDEntity wlycrecord, SqlParameter[] parms)
        {
            parms[0].Value = wlycrecord.AUTOID;
            parms[1].Value = wlycrecord.RECORDID;
            parms[2].Value = wlycrecord.WSTYPE;
            parms[3].Value = wlycrecord.DEPTID;
            parms[4].Value = wlycrecord.WCOUNT;
            parms[5].Value = wlycrecord.WSTARTNO;
            parms[6].Value = wlycrecord.WENDNO;
            parms[7].Value = wlycrecord.WUSER;
            parms[8].Value = wlycrecord.WCREATEDATE;
            parms[9].Value = wlycrecord.RowStatus;
            parms[10].Value = wlycrecord.CreatorId;
            parms[11].Value = wlycrecord.CreateBy;
            parms[12].Value = wlycrecord.CreateOn;
            parms[13].Value = wlycrecord.UpdateId;
            parms[14].Value = wlycrecord.UpdateBy;
            parms[15].Value = wlycrecord.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WLYCRECORDEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WLYCRECORD_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WLYCRECORD_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WLYCRECORD_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WLYCRECORD_AUTOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WLYCRECORD_DEPTID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_WCOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_WLYCRECORD_WSTARTNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WLYCRECORD_WENDNO, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WLYCRECORD_WUSER, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_WCREATEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WLYCRECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WLYCRECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WLYCRECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WLYCRECORD_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WLYCRECORD_Insert, parms);
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
       
 