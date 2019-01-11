using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Yookey.WisdomClassed.SIP.Model.FingerPrint
{
    /// <summary>
    /// 指纹
    /// </summary>
    [Serializable]
    public class FingerPrintEntity : ModelImp.BaseModel<FingerPrintEntity>
    {
        public FingerPrintEntity()
        {
            TB_Name = TB_FingerPrint;
            Parm_Id = Parm_FingerPrint_Id;
            Parm_Version = Parm_FingerPrint_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_FingerPrint_Insert;
            Sql_Update = Sql_FingerPrint_Update;
            Sql_Delete = Sql_FingerPrint_Delete;
        }
        #region Const of table FingerPrint
        /// <summary>
        /// Table FingerPrint
        /// </summary>
        public const string TB_FingerPrint = "FingerPrint";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_FingerPrint_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_FingerPrint_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_FingerPrint_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_FingerPrint_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_FingerPrint_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SerialNumber
        /// </summary>
        public const string Parm_FingerPrint_SerialNumber = "SerialNumber";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_FingerPrint_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_FingerPrint_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_FingerPrint_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_FingerPrint_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_FingerPrint_Version = "Version";
        /// <summary>
        /// Insert Query Of FingerPrint
        /// </summary>
        public const string Sql_FingerPrint_Insert = "insert into FingerPrint(CreateBy,CreateOn,CreatorId,RowStatus,SerialNumber,UpdateBy,UpdateId,UpdateOn,UserId,Id) values(@CreateBy,@CreateOn,@CreatorId,@RowStatus,@SerialNumber,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of FingerPrint
        /// </summary>
        public const string Sql_FingerPrint_Update = "update FingerPrint set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RowStatus=@RowStatus,SerialNumber=@SerialNumber,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_FingerPrint_Delete = "update FingerPrint set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _userId = string.Empty;
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private string _serialNumber = string.Empty;
        /// <summary>
        /// 手机序列号
        /// </summary>
        public string SerialNumber
        {
            get { return _serialNumber ?? string.Empty; }
            set { _serialNumber = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override FingerPrintEntity SetModelValueByDataRow(DataRow dr)
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
        public override FingerPrintEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new FingerPrintEntity();
            if (fields.Contains(Parm_FingerPrint_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_FingerPrint_Id].ToString();
            if (fields.Contains(Parm_FingerPrint_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_FingerPrint_UserId].ToString();
            if (fields.Contains(Parm_FingerPrint_SerialNumber) || fields.Contains("*"))
                tmp.SerialNumber = dr[Parm_FingerPrint_SerialNumber].ToString();
            if (fields.Contains(Parm_FingerPrint_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_FingerPrint_RowStatus].ToString());
            if (fields.Contains(Parm_FingerPrint_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_FingerPrint_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_FingerPrint_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_FingerPrint_CreatorId].ToString();
            if (fields.Contains(Parm_FingerPrint_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_FingerPrint_CreateBy].ToString();
            if (fields.Contains(Parm_FingerPrint_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_FingerPrint_CreateOn].ToString());
            if (fields.Contains(Parm_FingerPrint_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_FingerPrint_UpdateId].ToString();
            if (fields.Contains(Parm_FingerPrint_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_FingerPrint_UpdateBy].ToString();
            if (fields.Contains(Parm_FingerPrint_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_FingerPrint_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="fingerprint">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(FingerPrintEntity fingerprint, SqlParameter[] parms)
        {
            parms[0].Value = fingerprint.UserId;
            parms[1].Value = fingerprint.SerialNumber;
            parms[2].Value = fingerprint.RowStatus;
            parms[3].Value = fingerprint.CreatorId;
            parms[4].Value = fingerprint.CreateBy;
            parms[5].Value = fingerprint.CreateOn;
            parms[6].Value = fingerprint.UpdateId;
            parms[7].Value = fingerprint.UpdateBy;
            parms[8].Value = fingerprint.UpdateOn;
            parms[9].Value = fingerprint.Id;
            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(FingerPrintEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_FingerPrint_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_FingerPrint_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FingerPrint_SerialNumber, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_FingerPrint_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_FingerPrint_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FingerPrint_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FingerPrint_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_FingerPrint_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FingerPrint_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_FingerPrint_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_FingerPrint_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_FingerPrint_Insert, parms);
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
