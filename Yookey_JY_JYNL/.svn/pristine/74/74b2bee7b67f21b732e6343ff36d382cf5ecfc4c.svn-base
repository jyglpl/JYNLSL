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
    public class WDESTROYBYDATEEntity : ModelImp.BaseModel<WDESTROYBYDATEEntity>
    {
        public WDESTROYBYDATEEntity()
        {
            TB_Name = TB_WDESTROYBYDATE;
            Parm_Id = Parm_WDESTROYBYDATE_Id;
            Parm_Version = Parm_WDESTROYBYDATE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WDESTROYBYDATE_Insert;
            Sql_Update = Sql_WDESTROYBYDATE_Update;
            Sql_Delete = Sql_WDESTROYBYDATE_Delete;
        }
        #region Const of table WDESTROYBYDATE
        /// <summary>
        /// Table WDESTROYBYDATE
        /// </summary>
        public const string TB_WDESTROYBYDATE = "WDESTROYBYDATE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AUTOID
        /// </summary>
        public const string Parm_WDESTROYBYDATE_AUTOID = "AUTOID";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WDESTROYBYDATE_Version = "Version";
        

            /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WDESTROYBYDATE_Id = "Id";
        /// <summary>
        /// Parm WCREATEBY
        /// </summary>
        public const string Parm_WDESTROYBYDATE_WCREATEBY = "WCREATEBY";
        /// <summary>
        /// Parm WCREATEDATE
        /// </summary>
        public const string Parm_WDESTROYBYDATE_WCREATEDATE = "WCREATEDATE";
        /// <summary>
        /// Parm WDESID
        /// </summary>
        public const string Parm_WDESTROYBYDATE_WDESID = "WDESID";
        /// <summary>
        /// Parm WENDDATE
        /// </summary>
        public const string Parm_WDESTROYBYDATE_WENDDATE = "WENDDATE";
        /// <summary>
        /// Parm WSTARTDATE
        /// </summary>
        public const string Parm_WDESTROYBYDATE_WSTARTDATE = "WSTARTDATE";
        /// <summary>
        /// Insert Query Of WDESTROYBYDATE
        /// </summary>
        public const string Sql_WDESTROYBYDATE_Insert = "insert into WDESTROYBYDATE(AUTOID,WCREATEBY,WCREATEDATE,WDESID,WENDDATE,WSTARTDATE) values(@AUTOID,@WCREATEBY,@WCREATEDATE,@WDESID,@WENDDATE,@WSTARTDATE);select @@identity;";
        /// <summary>
        /// Update Query Of WDESTROYBYDATE
        /// </summary>
        public const string Sql_WDESTROYBYDATE_Update = "update WDESTROYBYDATE set AUTOID=@AUTOID,WCREATEBY=@WCREATEBY,WCREATEDATE=@WCREATEDATE,WDESID=@WDESID,WENDDATE=@WENDDATE,WSTARTDATE=@WSTARTDATE where AUTOID=@AUTOID;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WDESTROYBYDATE_Delete = "update WDESTROYBYDATE set RowStatus=0 where AUTOID=@AUTOID;select @@rowcount;";
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
        private DateTime _wSTARTDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime WSTARTDATE
        {
            get { return _wSTARTDATE; }
            set { _wSTARTDATE = value; }
        }
        private DateTime _wENDDATE = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime WENDDATE
        {
            get { return _wENDDATE; }
            set { _wENDDATE = value; }
        }
        private string _wCREATEBY = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WCREATEBY
        {
            get { return _wCREATEBY ?? string.Empty; }
            set { _wCREATEBY = value; }
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
        private string _wDESID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WDESID
        {
            get { return _wDESID ?? string.Empty; }
            set { _wDESID = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WDESTROYBYDATEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WDESTROYBYDATEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WDESTROYBYDATEEntity();
            if (fields.Contains(Parm_WDESTROYBYDATE_AUTOID) || fields.Contains("*"))
                tmp.AUTOID = dr[Parm_WDESTROYBYDATE_AUTOID].ToString();
            if (fields.Contains(Parm_WDESTROYBYDATE_WSTARTDATE) || fields.Contains("*"))
                tmp.WSTARTDATE = DateTime.Parse(dr[Parm_WDESTROYBYDATE_WSTARTDATE].ToString());
            if (fields.Contains(Parm_WDESTROYBYDATE_WENDDATE) || fields.Contains("*"))
                tmp.WENDDATE = DateTime.Parse(dr[Parm_WDESTROYBYDATE_WENDDATE].ToString());
            if (fields.Contains(Parm_WDESTROYBYDATE_WCREATEBY) || fields.Contains("*"))
                tmp.WCREATEBY = dr[Parm_WDESTROYBYDATE_WCREATEBY].ToString();
            if (fields.Contains(Parm_WDESTROYBYDATE_WCREATEDATE) || fields.Contains("*"))
                tmp.WCREATEDATE = DateTime.Parse(dr[Parm_WDESTROYBYDATE_WCREATEDATE].ToString());
            if (fields.Contains(Parm_WDESTROYBYDATE_WDESID) || fields.Contains("*"))
                tmp.WDESID = dr[Parm_WDESTROYBYDATE_WDESID].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wdestroybydate">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WDESTROYBYDATEEntity wdestroybydate, SqlParameter[] parms)
        {
            parms[0].Value = wdestroybydate.AUTOID;
            parms[1].Value = wdestroybydate.WSTARTDATE;
            parms[2].Value = wdestroybydate.WENDDATE;
            parms[3].Value = wdestroybydate.WCREATEBY;
            parms[4].Value = wdestroybydate.WCREATEDATE;
            parms[5].Value = wdestroybydate.WDESID;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WDESTROYBYDATEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WDESTROYBYDATE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WDESTROYBYDATE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDESTROYBYDATE_Insert);
                if (parms == null)
                {
                    parms = new[]{
														new SqlParameter(Parm_WDESTROYBYDATE_AUTOID, SqlDbType.NVarChar, 50),
						new SqlParameter(Parm_WDESTROYBYDATE_WSTARTDATE, SqlDbType.DateTime, 23),
						new SqlParameter(Parm_WDESTROYBYDATE_WENDDATE, SqlDbType.DateTime, 23),
						new SqlParameter(Parm_WDESTROYBYDATE_WCREATEBY, SqlDbType.NVarChar, 50),
						new SqlParameter(Parm_WDESTROYBYDATE_WCREATEDATE, SqlDbType.DateTime, 23),
						new SqlParameter(Parm_WDESTROYBYDATE_WDESID, SqlDbType.NVarChar, 50)

					};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WDESTROYBYDATE_Insert, parms);
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
																																																																																																																																																																																																																																																																																																																																																																												

