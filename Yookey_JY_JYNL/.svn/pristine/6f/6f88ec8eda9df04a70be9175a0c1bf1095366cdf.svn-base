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
    public class WSTOCKRECORDEntity : ModelImp.BaseModel<WSTOCKRECORDEntity>
    {
        public WSTOCKRECORDEntity()
        {
            TB_Name = TB_WSTOCKRECORD;
            Parm_Id = Parm_WSTOCKRECORD_Id;
            Parm_Version = Parm_WSTOCKRECORD_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WSTOCKRECORD_Insert;
            Sql_Update = Sql_WSTOCKRECORD_Update;
            Sql_Delete = Sql_WSTOCKRECORD_Delete;
        }
        #region Const of table WSTOCKRECORD
        /// <summary>
        /// Table WSTOCKRECORD
        /// </summary>
        public const string TB_WSTOCKRECORD = "WSTOCKRECORD";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CREATEBY
        /// </summary>
        public const string Parm_WSTOCKRECORD_CREATEBY = "CREATEBY";
        /// <summary>
        /// Parm CREATEDATE
        /// </summary>
        public const string Parm_WSTOCKRECORD_CREATEDATE = "CREATEDATE";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WSTOCKRECORD_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WSTOCKRECORD_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DEPTID
        /// </summary>
        public const string Parm_WSTOCKRECORD_DEPTID = "DEPTID";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WSTOCKRECORD_Id = "Id";
        /// <summary>
        /// Parm ISUNIT
        /// </summary>
        public const string Parm_WSTOCKRECORD_ISUNIT = "ISUNIT";
        /// <summary>
        /// Parm RECORDID
        /// </summary>
        public const string Parm_WSTOCKRECORD_RECORDID = "RECORDID";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WSTOCKRECORD_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TITLE
        /// </summary>
        public const string Parm_WSTOCKRECORD_TITLE = "TITLE";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WSTOCKRECORD_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WSTOCKRECORD_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WSTOCKRECORD_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WSTOCKRECORD_Version = "Version";
        /// <summary>
        /// Insert Query Of WSTOCKRECORD
        /// </summary>
        public const string Sql_WSTOCKRECORD_Insert = "insert into WSTOCKRECORD(CREATEBY,CREATEDATE,CreateOn,CreatorId,DEPTID,ISUNIT,RECORDID,RowStatus,TITLE,UpdateBy,UpdateId,UpdateOn) values(@CREATEBY,@CREATEDATE,@CreateOn,@CreatorId,@DEPTID,@ISUNIT,@RECORDID,@RowStatus,@TITLE,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
        /// <summary>
        /// Update Query Of WSTOCKRECORD
        /// </summary>
        public const string Sql_WSTOCKRECORD_Update = "update WSTOCKRECORD set CREATEBY=@CREATEBY,CREATEDATE=@CREATEDATE,CreateOn=@CreateOn,CreatorId=@CreatorId,DEPTID=@DEPTID,ISUNIT=@ISUNIT,RECORDID=@RECORDID,RowStatus=@RowStatus,TITLE=@TITLE,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WSTOCKRECORD_Delete = "update WSTOCKRECORD set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _rECORDID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RECORDID
        {
            get { return _rECORDID ?? string.Empty; }
            set { _rECORDID = value; }
        }
        private string _tITLE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string TITLE
        {
            get { return _tITLE ?? string.Empty; }
            set { _tITLE = value; }
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
        private int _iSUNIT;
        /// <summary>
        /// 
        /// </summary>
        public int ISUNIT
        {
            get { return _iSUNIT; }
            set { _iSUNIT = value; }
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
        public override WSTOCKRECORDEntity SetModelValueByDataRow(DataRow dr)
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
        public override WSTOCKRECORDEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WSTOCKRECORDEntity();
            if (fields.Contains(Parm_WSTOCKRECORD_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WSTOCKRECORD_Id].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_RECORDID) || fields.Contains("*"))
                tmp.RECORDID = dr[Parm_WSTOCKRECORD_RECORDID].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_TITLE) || fields.Contains("*"))
                tmp.TITLE = dr[Parm_WSTOCKRECORD_TITLE].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_DEPTID) || fields.Contains("*"))
                tmp.DEPTID = dr[Parm_WSTOCKRECORD_DEPTID].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_ISUNIT) || fields.Contains("*"))
                tmp.ISUNIT = int.Parse(dr[Parm_WSTOCKRECORD_ISUNIT].ToString());
            if (fields.Contains(Parm_WSTOCKRECORD_CREATEBY) || fields.Contains("*"))
                tmp.CREATEBY = dr[Parm_WSTOCKRECORD_CREATEBY].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_CREATEDATE) || fields.Contains("*"))
                tmp.CREATEDATE = DateTime.Parse(dr[Parm_WSTOCKRECORD_CREATEDATE].ToString());
            if (fields.Contains(Parm_WSTOCKRECORD_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WSTOCKRECORD_RowStatus].ToString());
            if (fields.Contains(Parm_WSTOCKRECORD_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WSTOCKRECORD_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WSTOCKRECORD_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WSTOCKRECORD_CreatorId].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WSTOCKRECORD_CreateOn].ToString());
            if (fields.Contains(Parm_WSTOCKRECORD_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WSTOCKRECORD_UpdateId].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WSTOCKRECORD_UpdateBy].ToString();
            if (fields.Contains(Parm_WSTOCKRECORD_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WSTOCKRECORD_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wstockrecord">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WSTOCKRECORDEntity wstockrecord, SqlParameter[] parms)
        {
            parms[0].Value = wstockrecord.RECORDID;
            parms[1].Value = wstockrecord.TITLE;
            parms[2].Value = wstockrecord.DEPTID;
            parms[3].Value = wstockrecord.ISUNIT;
            parms[4].Value = wstockrecord.CREATEBY;
            parms[5].Value = wstockrecord.CREATEDATE;
            parms[6].Value = wstockrecord.RowStatus;
            parms[7].Value = wstockrecord.CreatorId;
            parms[8].Value = wstockrecord.CreateOn;
            parms[9].Value = wstockrecord.UpdateId;
            parms[10].Value = wstockrecord.UpdateBy;
            parms[11].Value = wstockrecord.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WSTOCKRECORDEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WSTOCKRECORD_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WSTOCKRECORD_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKRECORD_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WSTOCKRECORD_RECORDID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKRECORD_TITLE, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_WSTOCKRECORD_DEPTID, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_WSTOCKRECORD_ISUNIT, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKRECORD_CREATEBY, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WSTOCKRECORD_CREATEDATE, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WSTOCKRECORD_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKRECORD_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKRECORD_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WSTOCKRECORD_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKRECORD_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKRECORD_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKRECORD_Insert, parms);
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
