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
    public class WSTOCKTABLEEntity : ModelImp.BaseModel<WSTOCKTABLEEntity>
    {
        public WSTOCKTABLEEntity()
        {
            TB_Name = TB_WSTOCKTABLE;
            Parm_Id = Parm_WSTOCKTABLE_Id;
            Parm_Version = Parm_WSTOCKTABLE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_WSTOCKTABLE_Insert;
            Sql_Update = Sql_WSTOCKTABLE_Update;
            Sql_Delete = Sql_WSTOCKTABLE_Delete;
        }
        #region Const of table WSTOCKTABLE
        /// <summary>
        /// Table WSTOCKTABLE
        /// </summary>
        public const string TB_WSTOCKTABLE = "WSTOCKTABLE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_WSTOCKTABLE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_WSTOCKTABLE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm CURRENTSTOCK
        /// </summary>
        public const string Parm_WSTOCKTABLE_CURRENTSTOCK = "CURRENTSTOCK";
        /// <summary>
        /// Parm FIRSTSTOCK
        /// </summary>
        public const string Parm_WSTOCKTABLE_FIRSTSTOCK = "FIRSTSTOCK";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_WSTOCKTABLE_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_WSTOCKTABLE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm STOCKID
        /// </summary>
        public const string Parm_WSTOCKTABLE_STOCKID = "STOCKID";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_WSTOCKTABLE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_WSTOCKTABLE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_WSTOCKTABLE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_WSTOCKTABLE_Version = "Version";
        /// <summary>
        /// Parm WSTYPE
        /// </summary>
        public const string Parm_WSTOCKTABLE_WSTYPE = "WSTYPE";
        /// <summary>
        /// Insert Query Of WSTOCKTABLE
        /// </summary>
        public const string Sql_WSTOCKTABLE_Insert = "insert into WSTOCKTABLE(CreateOn,CreatorId,CURRENTSTOCK,FIRSTSTOCK,Id,RowStatus,STOCKID,UpdateBy,UpdateId,UpdateOn,WSTYPE) values(@CreateOn,@CreatorId,@CURRENTSTOCK,@FIRSTSTOCK,@Id,@RowStatus,@STOCKID,@UpdateBy,@UpdateId,@UpdateOn,@WSTYPE);select @@identity;";
        /// <summary>
        /// Update Query Of WSTOCKTABLE
        /// </summary>
        public const string Sql_WSTOCKTABLE_Update = "update WSTOCKTABLE set CreateOn=@CreateOn,CreatorId=@CreatorId,CURRENTSTOCK=@CURRENTSTOCK,FIRSTSTOCK=@FIRSTSTOCK,Id=@Id,RowStatus=@RowStatus,STOCKID=@STOCKID,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WSTYPE=@WSTYPE where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_WSTOCKTABLE_Delete = "update WSTOCKTABLE set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _sTOCKID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string STOCKID
        {
            get { return _sTOCKID ?? string.Empty; }
            set { _sTOCKID = value; }
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
        private int _fIRSTSTOCK;
        /// <summary>
        /// 
        /// </summary>
        public int FIRSTSTOCK
        {
            get { return _fIRSTSTOCK; }
            set { _fIRSTSTOCK = value; }
        }
        private int _cURRENTSTOCK;
        /// <summary>
        /// 
        /// </summary>
        public int CURRENTSTOCK
        {
            get { return _cURRENTSTOCK; }
            set { _cURRENTSTOCK = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override WSTOCKTABLEEntity SetModelValueByDataRow(DataRow dr)
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
        public override WSTOCKTABLEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new WSTOCKTABLEEntity();
            if (fields.Contains(Parm_WSTOCKTABLE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_WSTOCKTABLE_Id].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_STOCKID) || fields.Contains("*"))
                tmp.STOCKID = dr[Parm_WSTOCKTABLE_STOCKID].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_WSTYPE) || fields.Contains("*"))
                tmp.WSTYPE = dr[Parm_WSTOCKTABLE_WSTYPE].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_FIRSTSTOCK) || fields.Contains("*"))
                tmp.FIRSTSTOCK = int.Parse(dr[Parm_WSTOCKTABLE_FIRSTSTOCK].ToString());
            if (fields.Contains(Parm_WSTOCKTABLE_CURRENTSTOCK) || fields.Contains("*"))
                tmp.CURRENTSTOCK = int.Parse(dr[Parm_WSTOCKTABLE_CURRENTSTOCK].ToString());
            if (fields.Contains(Parm_WSTOCKTABLE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_WSTOCKTABLE_RowStatus].ToString());
            if (fields.Contains(Parm_WSTOCKTABLE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_WSTOCKTABLE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_WSTOCKTABLE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_WSTOCKTABLE_CreatorId].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_WSTOCKTABLE_CreateOn].ToString());
            if (fields.Contains(Parm_WSTOCKTABLE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_WSTOCKTABLE_UpdateId].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_WSTOCKTABLE_UpdateBy].ToString();
            if (fields.Contains(Parm_WSTOCKTABLE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_WSTOCKTABLE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="wstocktable">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(WSTOCKTABLEEntity wstocktable, SqlParameter[] parms)
        {
            parms[0].Value = wstocktable.Id;
            parms[1].Value = wstocktable.STOCKID;
            parms[2].Value = wstocktable.WSTYPE;
            parms[3].Value = wstocktable.FIRSTSTOCK;
            parms[4].Value = wstocktable.CURRENTSTOCK;
            parms[5].Value = wstocktable.RowStatus;
            parms[6].Value = wstocktable.CreatorId;
            parms[7].Value = wstocktable.CreateOn;
            parms[8].Value = wstocktable.UpdateId;
            parms[9].Value = wstocktable.UpdateBy;
            parms[10].Value = wstocktable.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(WSTOCKTABLEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_WSTOCKTABLE_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_WSTOCKTABLE_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKTABLE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_WSTOCKTABLE_Id, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKTABLE_STOCKID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKTABLE_WSTYPE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_WSTOCKTABLE_FIRSTSTOCK, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKTABLE_CURRENTSTOCK, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKTABLE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_WSTOCKTABLE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKTABLE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_WSTOCKTABLE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKTABLE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_WSTOCKTABLE_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_WSTOCKTABLE_Insert, parms);
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