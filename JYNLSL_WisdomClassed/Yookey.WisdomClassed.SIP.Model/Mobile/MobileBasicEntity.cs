using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Mobile
{
    /// <summary>
    /// 基础信息配置表
    /// </summary>
    [Serializable]
    public class MobileBasicEntity : ModelImp.BaseModel<MobileBasicEntity>
    {
        public MobileBasicEntity()
        {
            TB_Name = TB_Mobile_Basic;
            Parm_Id = Parm_Mobile_Basic_Id;
            Parm_Version = Parm_Mobile_Basic_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Mobile_Basic_Insert;
            Sql_Update = Sql_Mobile_Basic_Update;
            Sql_Delete = Sql_Mobile_Basic_Delete;
        }
        #region Const of table Mobile_Basic
        /// <summary>
        /// Table Mobile_Basic
        /// </summary>
        public const string TB_Mobile_Basic = "Mobile_Basic";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BasicName
        /// </summary>
        public const string Parm_Mobile_Basic_BasicName = "BasicName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Mobile_Basic_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Mobile_Basic_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Mobile_Basic_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Mobile_Basic_Id = "Id";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Mobile_Basic_RowStatus = "RowStatus";
        /// <summary>
        /// Parm TableName
        /// </summary>
        public const string Parm_Mobile_Basic_TableName = "TableName";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Mobile_Basic_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Mobile_Basic_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Mobile_Basic_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Mobile_Basic_Version = "Version";
        /// <summary>
        /// Parm VersionNum
        /// </summary>
        public const string Parm_Mobile_Basic_VersionNum = "VersionNum";
        /// <summary>
        /// Insert Query Of Mobile_Basic
        /// </summary>
        public const string Sql_Mobile_Basic_Insert = "insert into Mobile_Basic(BasicName,CreateBy,CreateOn,CreatorId,RowStatus,TableName,UpdateBy,UpdateId,UpdateOn,VersionNum) values(@BasicName,@CreateBy,@CreateOn,@CreatorId,@RowStatus,@TableName,@UpdateBy,@UpdateId,@UpdateOn,@VersionNum);select @@identity;";
        /// <summary>
        /// Update Query Of Mobile_Basic
        /// </summary>
        public const string Sql_Mobile_Basic_Update = "update Mobile_Basic set BasicName=@BasicName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,RowStatus=@RowStatus,TableName=@TableName,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,VersionNum=@VersionNum where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Mobile_Basic_Delete = "update Mobile_Basic set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _basicName = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string BasicName
        {
            get { return _basicName ?? string.Empty; }
            set { _basicName = value; }
        }
        private string _tableName = string.Empty;
        /// <summary>
        /// 对应表名称
        /// </summary>
        public string TableName
        {
            get { return _tableName ?? string.Empty; }
            set { _tableName = value; }
        }
        private int _versionNum;
        /// <summary>
        /// 对应版本号
        /// </summary>
        public int VersionNum
        {
            get { return _versionNum; }
            set { _versionNum = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override MobileBasicEntity SetModelValueByDataRow(DataRow dr)
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
        public override MobileBasicEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new MobileBasicEntity();
            if (fields.Contains(Parm_Mobile_Basic_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Mobile_Basic_Id].ToString();
            if (fields.Contains(Parm_Mobile_Basic_BasicName) || fields.Contains("*"))
                tmp.BasicName = dr[Parm_Mobile_Basic_BasicName].ToString();
            if (fields.Contains(Parm_Mobile_Basic_TableName) || fields.Contains("*"))
                tmp.TableName = dr[Parm_Mobile_Basic_TableName].ToString();
            if (fields.Contains(Parm_Mobile_Basic_VersionNum) || fields.Contains("*"))
                tmp.VersionNum = int.Parse(dr[Parm_Mobile_Basic_VersionNum].ToString());
            if (fields.Contains(Parm_Mobile_Basic_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Mobile_Basic_RowStatus].ToString());
            if (fields.Contains(Parm_Mobile_Basic_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Mobile_Basic_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Mobile_Basic_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Mobile_Basic_CreatorId].ToString();
            if (fields.Contains(Parm_Mobile_Basic_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Mobile_Basic_CreateBy].ToString();
            if (fields.Contains(Parm_Mobile_Basic_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Mobile_Basic_CreateOn].ToString());
            if (fields.Contains(Parm_Mobile_Basic_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Mobile_Basic_UpdateId].ToString();
            if (fields.Contains(Parm_Mobile_Basic_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Mobile_Basic_UpdateBy].ToString();
            if (fields.Contains(Parm_Mobile_Basic_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Mobile_Basic_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="mobile_basic">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(MobileBasicEntity mobile_basic, SqlParameter[] parms)
        {
            parms[0].Value = mobile_basic.BasicName;
            parms[1].Value = mobile_basic.TableName;
            parms[2].Value = mobile_basic.VersionNum;
            parms[3].Value = mobile_basic.RowStatus;
            parms[4].Value = mobile_basic.CreatorId;
            parms[5].Value = mobile_basic.CreateBy;
            parms[6].Value = mobile_basic.CreateOn;
            parms[7].Value = mobile_basic.UpdateId;
            parms[8].Value = mobile_basic.UpdateBy;
            parms[9].Value = mobile_basic.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(MobileBasicEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_Mobile_Basic_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_Mobile_Basic_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_Basic_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Mobile_Basic_BasicName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_TableName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_VersionNum, SqlDbType.Int, 10),
					new SqlParameter(Parm_Mobile_Basic_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Mobile_Basic_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Mobile_Basic_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_Basic_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_Basic_Insert, parms);
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

