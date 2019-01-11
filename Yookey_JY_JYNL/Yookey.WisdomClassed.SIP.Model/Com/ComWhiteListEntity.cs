using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ComWhiteListEntity : ModelImp.BaseModel<ComWhiteListEntity>
    {
        public ComWhiteListEntity()
        {
            TB_Name = TB_ComWhiteList;
            Parm_Id = Parm_ComWhiteList_Id;
            Parm_Version = Parm_ComWhiteList_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComWhiteList_Insert;
            Sql_Update = Sql_ComWhiteList_Update;
            Sql_Delete = Sql_ComWhiteList_Delete;
        }
        #region Const of table ComWhiteList
        /// <summary>
        /// Table ComWhiteList
        /// </summary>
        public const string TB_ComWhiteList = "ComWhiteList";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComWhiteList_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComWhiteList_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComWhiteList_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComWhiteList_Id = "Id";
        /// <summary>
        /// Parm PlateNumber
        /// </summary>
        public const string Parm_ComWhiteList_PlateNumber = "PlateNumber";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComWhiteList_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComWhiteList_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComWhiteList_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComWhiteList_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComWhiteList_Version = "Version";
        /// <summary>
        /// Insert Query Of ComWhiteList
        /// </summary>
        public const string Sql_ComWhiteList_Insert = "insert into ComWhiteList(CreateBy,CreateOn,CreatorId,PlateNumber,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@PlateNumber,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComWhiteList
        /// </summary>
        public const string Sql_ComWhiteList_Update = "update ComWhiteList set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,PlateNumber=@PlateNumber,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComWhiteList_Delete = "update ComWhiteList set RowStatus=0 where Id=@Id;select @@rowcount;";
        #endregion

        #region Properties
        private string _plateNumber = string.Empty;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNumber
        {
            get { return _plateNumber ?? string.Empty; }
            set { _plateNumber = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComWhiteListEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComWhiteListEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComWhiteListEntity();
            if (fields.Contains(Parm_ComWhiteList_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComWhiteList_Id].ToString();
            if (fields.Contains(Parm_ComWhiteList_PlateNumber) || fields.Contains("*"))
                tmp.PlateNumber = dr[Parm_ComWhiteList_PlateNumber].ToString();
            if (fields.Contains(Parm_ComWhiteList_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComWhiteList_RowStatus].ToString());
            if (fields.Contains(Parm_ComWhiteList_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComWhiteList_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComWhiteList_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComWhiteList_CreatorId].ToString();
            if (fields.Contains(Parm_ComWhiteList_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComWhiteList_CreateBy].ToString();
            if (fields.Contains(Parm_ComWhiteList_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComWhiteList_CreateOn].ToString());
            if (fields.Contains(Parm_ComWhiteList_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComWhiteList_UpdateId].ToString();
            if (fields.Contains(Parm_ComWhiteList_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComWhiteList_UpdateBy].ToString();
            if (fields.Contains(Parm_ComWhiteList_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComWhiteList_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comwhitelist">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComWhiteListEntity comwhitelist, SqlParameter[] parms)
        {
            parms[0].Value = comwhitelist.PlateNumber;
            parms[1].Value = comwhitelist.RowStatus;
            parms[2].Value = comwhitelist.CreatorId;
            parms[3].Value = comwhitelist.CreateBy;
            parms[4].Value = comwhitelist.CreateOn;
            parms[5].Value = comwhitelist.UpdateId;
            parms[6].Value = comwhitelist.UpdateBy;
            parms[7].Value = comwhitelist.UpdateOn;
            parms[8].Value = comwhitelist.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComWhiteListEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComWhiteList_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComWhiteList_PlateNumber, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComWhiteList_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComWhiteList_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComWhiteList_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComWhiteList_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComWhiteList_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComWhiteList_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComWhiteList_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComWhiteList_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComWhiteList_Insert, parms);
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
