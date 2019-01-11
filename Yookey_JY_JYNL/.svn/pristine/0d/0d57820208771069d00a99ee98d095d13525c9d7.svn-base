using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Instrument
{  /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class W_TYPETABLEEntity : ModelImp.BaseModel<W_TYPETABLEEntity>
    {
        public W_TYPETABLEEntity()
        {
            TB_Name = TB_W_TYPETABLE;
            Parm_Id = Parm_W_TYPETABLE_Id;
            Parm_Version = Parm_W_TYPETABLE_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_W_TYPETABLE_Insert;
            Sql_Update = Sql_W_TYPETABLE_Update;
            Sql_Delete = Sql_W_TYPETABLE_Delete;
        }
        #region Const of table W_TYPETABLE
        /// <summary>
        /// Table W_TYPETABLE
        /// </summary>
        public const string TB_W_TYPETABLE = "W_TYPETABLE";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CHECKCOUNT
        /// </summary>
        public const string Parm_W_TYPETABLE_CHECKCOUNT = "CHECKCOUNT";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_W_TYPETABLE_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_W_TYPETABLE_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_W_TYPETABLE_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_W_TYPETABLE_Id = "Id";
        /// <summary>
        /// Parm ISPDA
        /// </summary>
        public const string Parm_W_TYPETABLE_ISPDA = "ISPDA";

        /// <summary>
        /// WSNumber
        /// </summary>
        public const string Parm_W_TYPETABLE_WSNumber = "WSNumber";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_W_TYPETABLE_RowStatus = "RowStatus";
        /// <summary>
        /// Parm RSVALUE
        /// </summary>
        public const string Parm_W_TYPETABLE_RSVALUE = "RSVALUE";
        /// <summary>
        /// Parm SELETETABLE
        /// </summary>
        public const string Parm_W_TYPETABLE_SELETETABLE = "SELETETABLE";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_W_TYPETABLE_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_W_TYPETABLE_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_W_TYPETABLE_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_W_TYPETABLE_Version = "Version";
        /// <summary>
        /// Parm WCOUNT
        /// </summary>
        public const string Parm_W_TYPETABLE_WCOUNT = "WCOUNT";
        /// <summary>
        /// Parm WRSCODE
        /// </summary>
        public const string Parm_W_TYPETABLE_WRSCODE = "WRSCODE";
        /// <summary>
        /// Parm WRSKEY
        /// </summary>
        public const string Parm_W_TYPETABLE_WRSKEY = "WRSKEY";
        /// <summary>
        /// Parm WSAFECOUNT
        /// </summary>
        public const string Parm_W_TYPETABLE_WSAFECOUNT = "WSAFECOUNT";
        /// <summary>
        /// Parm WSTATE
        /// </summary>
        public const string Parm_W_TYPETABLE_WSTATE = "WSTATE";
        /// <summary>
        /// Insert Query Of W_TYPETABLE
        /// </summary>
        public const string Sql_W_TYPETABLE_Insert = "insert into W_TYPETABLE(CHECKCOUNT,CreateBy,CreateOn,CreatorId,ISPDA,WSNumber,RowStatus,RSVALUE,SELETETABLE,UpdateBy,UpdateId,UpdateOn,WCOUNT,WRSCODE,WRSKEY,WSAFECOUNT,WSTATE,id) values(@CHECKCOUNT,@CreateBy,@CreateOn,@CreatorId,@ISPDA,@WSNumber,@RowStatus,@RSVALUE,@SELETETABLE,@UpdateBy,@UpdateId,@UpdateOn,@WCOUNT,@WRSCODE,@WRSKEY,@WSAFECOUNT,@WSTATE,@id);select @@identity;";
        /// <summary>
        /// Update Query Of W_TYPETABLE
        /// </summary>
        public const string Sql_W_TYPETABLE_Update = "update W_TYPETABLE set CHECKCOUNT=@CHECKCOUNT,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ISPDA=@ISPDA,WSNumber=@WSNumber,RowStatus=@RowStatus,RSVALUE=@RSVALUE,SELETETABLE=@SELETETABLE,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WCOUNT=@WCOUNT,WRSCODE=@WRSCODE,WRSKEY=@WRSKEY,WSAFECOUNT=@WSAFECOUNT,WSTATE=@WSTATE where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_W_TYPETABLE_Delete = "update W_TYPETABLE set RowStatus=0 where Id=@Id ;select @@rowcount;";
        #endregion

        #region Properties
        private string _wRSCODE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WRSCODE
        {
            get { return _wRSCODE ?? string.Empty; }
            set { _wRSCODE = value; }
        }
        private string _wRSKEY = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WRSKEY
        {
            get { return _wRSKEY ?? string.Empty; }
            set { _wRSKEY = value; }
        }
        private string _rSVALUE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string RSVALUE
        {
            get { return _rSVALUE ?? string.Empty; }
            set { _rSVALUE = value; }
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
        private int _wSAFECOUNT;
        /// <summary>
        /// 
        /// </summary>
        public int WSAFECOUNT
        {
            get { return _wSAFECOUNT; }
            set { _wSAFECOUNT = value; }
        }
        private int _cHECKCOUNT;
        /// <summary>
        /// 
        /// </summary>
        public int CHECKCOUNT
        {
            get { return _cHECKCOUNT; }
            set { _cHECKCOUNT = value; }
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
        private string _sELETETABLE = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SELETETABLE
        {
            get { return _sELETETABLE ?? string.Empty; }
            set { _sELETETABLE = value; }
        }
        private int _iSPDA;
        /// <summary>
        /// 
        /// </summary>
        public int ISPDA
        {
            get { return _iSPDA; }
            set { _iSPDA = value; }
        }

        private string _wSNumber;
        /// <summary>
        /// 
        /// </summary>
        public string WSNumber
        {
            get { return _wSNumber; }
            set { _wSNumber = value; }
        }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override W_TYPETABLEEntity SetModelValueByDataRow(DataRow dr)
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
        public override W_TYPETABLEEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new W_TYPETABLEEntity();
            if (fields.Contains(Parm_W_TYPETABLE_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_W_TYPETABLE_Id].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_WRSCODE) || fields.Contains("*"))
                tmp.WRSCODE = dr[Parm_W_TYPETABLE_WRSCODE].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_WRSKEY) || fields.Contains("*"))
                tmp.WRSKEY = dr[Parm_W_TYPETABLE_WRSKEY].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_RSVALUE) || fields.Contains("*"))
                tmp.RSVALUE = dr[Parm_W_TYPETABLE_RSVALUE].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_WCOUNT) || fields.Contains("*"))
                tmp.WCOUNT = int.Parse(dr[Parm_W_TYPETABLE_WCOUNT].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_WSAFECOUNT) || fields.Contains("*"))
                tmp.WSAFECOUNT = int.Parse(dr[Parm_W_TYPETABLE_WSAFECOUNT].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_CHECKCOUNT) || fields.Contains("*"))
                tmp.CHECKCOUNT = int.Parse(dr[Parm_W_TYPETABLE_CHECKCOUNT].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_WSTATE) || fields.Contains("*"))
                tmp.WSTATE = int.Parse(dr[Parm_W_TYPETABLE_WSTATE].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_SELETETABLE) || fields.Contains("*"))
                tmp.SELETETABLE = dr[Parm_W_TYPETABLE_SELETETABLE].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_ISPDA) || fields.Contains("*"))
                tmp.ISPDA = int.Parse(dr[Parm_W_TYPETABLE_ISPDA].ToString());

            if (fields.Contains(Parm_W_TYPETABLE_WSNumber) || fields.Contains("*"))
                tmp.WSNumber = dr[Parm_W_TYPETABLE_WSNumber].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_W_TYPETABLE_RowStatus].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_W_TYPETABLE_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_W_TYPETABLE_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_W_TYPETABLE_CreatorId].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_W_TYPETABLE_CreateBy].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_W_TYPETABLE_CreateOn].ToString());
            if (fields.Contains(Parm_W_TYPETABLE_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_W_TYPETABLE_UpdateId].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_W_TYPETABLE_UpdateBy].ToString();
            if (fields.Contains(Parm_W_TYPETABLE_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_W_TYPETABLE_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="w_typetable">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(W_TYPETABLEEntity w_typetable, SqlParameter[] parms)
        {
            parms[0].Value = w_typetable.WRSCODE;
            parms[1].Value = w_typetable.WRSKEY;
            parms[2].Value = w_typetable.RSVALUE;
            parms[3].Value = w_typetable.WCOUNT;
            parms[4].Value = w_typetable.WSAFECOUNT;
            parms[5].Value = w_typetable.CHECKCOUNT;
            parms[6].Value = w_typetable.WSTATE;
            parms[7].Value = w_typetable.SELETETABLE;
            parms[8].Value = w_typetable.ISPDA;
            parms[9].Value = w_typetable.WSNumber;
            parms[10].Value = w_typetable.RowStatus;
            parms[11].Value = w_typetable.CreatorId;
            parms[12].Value = w_typetable.CreateBy;
            parms[13].Value = w_typetable.CreateOn;
            parms[14].Value = w_typetable.UpdateId;
            parms[15].Value = w_typetable.UpdateBy;
            parms[16].Value = w_typetable.UpdateOn;
            parms[17].Value = w_typetable.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(W_TYPETABLEEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
            return parsAll;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_W_TYPETABLE_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_W_TYPETABLE_WRSCODE, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_W_TYPETABLE_WRSKEY, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_RSVALUE, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_WCOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_W_TYPETABLE_WSAFECOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_W_TYPETABLE_CHECKCOUNT, SqlDbType.Int, 10),
					new SqlParameter(Parm_W_TYPETABLE_WSTATE, SqlDbType.Int, 10),
					new SqlParameter(Parm_W_TYPETABLE_SELETETABLE, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_ISPDA, SqlDbType.Int, 10),
                    new SqlParameter(Parm_W_TYPETABLE_WSNumber, SqlDbType.NVarChar, 500), 
					new SqlParameter(Parm_W_TYPETABLE_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_W_TYPETABLE_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_W_TYPETABLE_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_W_TYPETABLE_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_W_TYPETABLE_Id,  SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_W_TYPETABLE_Insert, parms);
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