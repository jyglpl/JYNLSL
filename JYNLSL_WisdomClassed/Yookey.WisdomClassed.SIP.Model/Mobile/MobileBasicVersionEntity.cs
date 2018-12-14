using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Mobile
{
    [Serializable]
    public class MobileBasicVersionEntity : ModelImp.BaseModel<MobileBasicVersionEntity>
    {
        public MobileBasicVersionEntity()
        {
            TB_Name = TB_Mobile_BasicVersion;
            Parm_Id = Parm_Mobile_BasicVersion_Id;
            Parm_Version = Parm_Mobile_BasicVersion_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Mobile_BasicVersion_Insert;
            Sql_Update = Sql_Mobile_BasicVersion_Update;
            Sql_Delete = Sql_Mobile_BasicVersion_Delete;
        }
        #region Const of table Mobile_BasicVersion
        /// <summary>
        /// Table Mobile_BasicVersion
        /// </summary>
        public const string TB_Mobile_BasicVersion = "Mobile_BasicVersion";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Mobile_BasicVersion_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Mobile_BasicVersion_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreateSql
        /// </summary>
        public const string Parm_Mobile_BasicVersion_CreateSql = "CreateSql";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Mobile_BasicVersion_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Mobile_BasicVersion_Id = "Id";
        /// <summary>
        /// Parm InsertSql
        /// </summary>
        public const string Parm_Mobile_BasicVersion_InsertSql = "InsertSql";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Mobile_BasicVersion_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Mobile_BasicVersion_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Mobile_BasicVersion_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Mobile_BasicVersion_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Mobile_BasicVersion_Version = "Version";
        /// <summary>
        /// Parm VersionNum
        /// </summary>
        public const string Parm_Mobile_BasicVersion_VersionNum = "VersionNum";
        /// <summary>
        /// Insert Query Of Mobile_BasicVersion
        /// </summary>
        public const string Sql_Mobile_BasicVersion_Insert = "insert into Mobile_BasicVersion(CreateBy,CreateOn,CreateSql,CreatorId,InsertSql,RowStatus,UpdateBy,UpdateId,UpdateOn,VersionNum) values(@CreateBy,@CreateOn,@CreateSql,@CreatorId,@InsertSql,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@VersionNum);select @@identity;";
        /// <summary>
        /// Update Query Of Mobile_BasicVersion
        /// </summary>
        public const string Sql_Mobile_BasicVersion_Update = "update Mobile_BasicVersion set CreateBy=@CreateBy,CreateOn=@CreateOn,CreateSql=@CreateSql,CreatorId=@CreatorId,InsertSql=@InsertSql,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,VersionNum=@VersionNum where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Mobile_BasicVersion_Delete = "update Mobile_BasicVersion set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private int _versionNum;
        /// <summary>
        /// 
        /// </summary>
        public int VersionNum
        {
            get { return _versionNum; }
            set { _versionNum = value; }
        }
        private string _createSql = string.Empty;
        /// <summary>
        /// 创建新表
        /// </summary>
        public string CreateSql
        {
            get { return _createSql ?? string.Empty; }
            set { _createSql = value; }
        }
        private string _insertSql = string.Empty;
        /// <summary>
        /// 配置表中新增语句
        /// </summary>
        public string InsertSql
        {
            get { return _insertSql ?? string.Empty; }
            set { _insertSql = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override MobileBasicVersionEntity SetModelValueByDataRow(DataRow dr)
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
        public override MobileBasicVersionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new MobileBasicVersionEntity();
            if (fields.Contains(Parm_Mobile_BasicVersion_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Mobile_BasicVersion_Id].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_VersionNum) || fields.Contains("*"))
                tmp.VersionNum = int.Parse(dr[Parm_Mobile_BasicVersion_VersionNum].ToString());
            if (fields.Contains(Parm_Mobile_BasicVersion_CreateSql) || fields.Contains("*"))
                tmp.CreateSql = dr[Parm_Mobile_BasicVersion_CreateSql].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_InsertSql) || fields.Contains("*"))
                tmp.InsertSql = dr[Parm_Mobile_BasicVersion_InsertSql].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Mobile_BasicVersion_RowStatus].ToString());
            if (fields.Contains(Parm_Mobile_BasicVersion_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Mobile_BasicVersion_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Mobile_BasicVersion_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Mobile_BasicVersion_CreatorId].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Mobile_BasicVersion_CreateBy].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Mobile_BasicVersion_CreateOn].ToString());
            if (fields.Contains(Parm_Mobile_BasicVersion_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Mobile_BasicVersion_UpdateId].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Mobile_BasicVersion_UpdateBy].ToString();
            if (fields.Contains(Parm_Mobile_BasicVersion_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Mobile_BasicVersion_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="mobile_basicversion">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(MobileBasicVersionEntity mobile_basicversion, SqlParameter[] parms)
        {
            parms[0].Value = mobile_basicversion.VersionNum;
            parms[1].Value = mobile_basicversion.CreateSql;
            parms[2].Value = mobile_basicversion.InsertSql;
            parms[3].Value = mobile_basicversion.RowStatus;
            parms[4].Value = mobile_basicversion.CreatorId;
            parms[5].Value = mobile_basicversion.CreateBy;
            parms[6].Value = mobile_basicversion.CreateOn;
            parms[7].Value = mobile_basicversion.UpdateId;
            parms[8].Value = mobile_basicversion.UpdateBy;
            parms[9].Value = mobile_basicversion.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(MobileBasicVersionEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_Mobile_BasicVersion_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_Mobile_BasicVersion_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_BasicVersion_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Mobile_BasicVersion_VersionNum, SqlDbType.Int, 10),
					new SqlParameter(Parm_Mobile_BasicVersion_CreateSql, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_Mobile_BasicVersion_InsertSql, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_Mobile_BasicVersion_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Mobile_BasicVersion_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_BasicVersion_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_BasicVersion_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Mobile_BasicVersion_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_BasicVersion_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_BasicVersion_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_BasicVersion_Insert, parms);
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

