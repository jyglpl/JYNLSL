using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.SealUp
{
    /// <summary>
    /// 查封物品信息
    /// </summary>
    [Serializable]
    public class SealUpGoodsEntity : ModelImp.BaseModel<SealUpGoodsEntity>
    {
        public SealUpGoodsEntity()
        {
            TB_Name = TB_SealUpGoods;
            Parm_Id = Parm_SealUpGoods_Id;
            Parm_Version = Parm_SealUpGoods_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_SealUpGoods_Insert;
            Sql_Update = Sql_SealUpGoods_Update;
            Sql_Delete = Sql_SealUpGoods_Delete;
        }
        #region Const of table SealUpGoods
        /// <summary>
        /// Table SealUpGoods
        /// </summary>
        public const string TB_SealUpGoods = "SealUpGoods";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Area
        /// </summary>
        public const string Parm_SealUpGoods_Area = "Area";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_SealUpGoods_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_SealUpGoods_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_SealUpGoods_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Direction
        /// </summary>
        public const string Parm_SealUpGoods_Direction = "Direction";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_SealUpGoods_Id = "Id";
        /// <summary>
        /// Parm Location
        /// </summary>
        public const string Parm_SealUpGoods_Location = "Location";
        /// <summary>
        /// Parm MaterialId
        /// </summary>
        public const string Parm_SealUpGoods_MaterialId = "MaterialId";
        /// <summary>
        /// Parm MaterialName
        /// </summary>
        public const string Parm_SealUpGoods_MaterialName = "MaterialName";
        /// <summary>
        /// Parm Name
        /// </summary>
        public const string Parm_SealUpGoods_Name = "Name";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_SealUpGoods_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_SealUpGoods_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SealUpId
        /// </summary>
        public const string Parm_SealUpGoods_SealUpId = "SealUpId";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_SealUpGoods_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_SealUpGoods_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_SealUpGoods_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_SealUpGoods_Version = "Version";
        /// <summary>
        /// Insert Query Of SealUpGoods
        /// </summary>
        public const string Sql_SealUpGoods_Insert = "insert into SealUpGoods(Area,CreateBy,CreateOn,CreatorId,Direction,Location,MaterialId,MaterialName,Name,Remark,RowStatus,SealUpId,UpdateBy,UpdateId,UpdateOn,Id) values(@Area,@CreateBy,@CreateOn,@CreatorId,@Direction,@Location,@MaterialId,@MaterialName,@Name,@Remark,@RowStatus,@SealUpId,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of SealUpGoods
        /// </summary>
        public const string Sql_SealUpGoods_Update = "update SealUpGoods set Area=@Area,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Direction=@Direction,Location=@Location,MaterialId=@MaterialId,MaterialName=@MaterialName,Name=@Name,Remark=@Remark,RowStatus=@RowStatus,SealUpId=@SealUpId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_SealUpGoods_Delete = "update SealUpGoods set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _sealUpId = string.Empty;
        /// <summary>
        /// 外键编号
        /// </summary>
        public string SealUpId
        {
            get { return _sealUpId ?? string.Empty; }
            set { _sealUpId = value; }
        }
        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name ?? string.Empty; }
            set { _name = value; }
        }
        private string _location = string.Empty;
        /// <summary>
        /// 位置
        /// </summary>
        public string Location
        {
            get { return _location ?? string.Empty; }
            set { _location = value; }
        }
        private string _direction = string.Empty;
        /// <summary>
        /// 方向
        /// </summary>
        public string Direction
        {
            get { return _direction ?? string.Empty; }
            set { _direction = value; }
        }
        private string _area = string.Empty;
        /// <summary>
        /// 面积
        /// </summary>
        public string Area
        {
            get { return _area ?? string.Empty; }
            set { _area = value; }
        }
        private string _materialId = string.Empty;
        /// <summary>
        /// 材质编号
        /// </summary>
        public string MaterialId
        {
            get { return _materialId ?? string.Empty; }
            set { _materialId = value; }
        }
        private string _materialName = string.Empty;
        /// <summary>
        /// 材质名称
        /// </summary>
        public string MaterialName
        {
            get { return _materialName ?? string.Empty; }
            set { _materialName = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注描述
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override SealUpGoodsEntity SetModelValueByDataRow(DataRow dr)
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
        public override SealUpGoodsEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new SealUpGoodsEntity();
            if (fields.Contains(Parm_SealUpGoods_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_SealUpGoods_Id].ToString();
            if (fields.Contains(Parm_SealUpGoods_SealUpId) || fields.Contains("*"))
                tmp.SealUpId = dr[Parm_SealUpGoods_SealUpId].ToString();
            if (fields.Contains(Parm_SealUpGoods_Name) || fields.Contains("*"))
                tmp.Name = dr[Parm_SealUpGoods_Name].ToString();
            if (fields.Contains(Parm_SealUpGoods_Location) || fields.Contains("*"))
                tmp.Location = dr[Parm_SealUpGoods_Location].ToString();
            if (fields.Contains(Parm_SealUpGoods_Direction) || fields.Contains("*"))
                tmp.Direction = dr[Parm_SealUpGoods_Direction].ToString();
            if (fields.Contains(Parm_SealUpGoods_Area) || fields.Contains("*"))
                tmp.Area = dr[Parm_SealUpGoods_Area].ToString();
            if (fields.Contains(Parm_SealUpGoods_MaterialId) || fields.Contains("*"))
                tmp.MaterialId = dr[Parm_SealUpGoods_MaterialId].ToString();
            if (fields.Contains(Parm_SealUpGoods_MaterialName) || fields.Contains("*"))
                tmp.MaterialName = dr[Parm_SealUpGoods_MaterialName].ToString();
            if (fields.Contains(Parm_SealUpGoods_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_SealUpGoods_Remark].ToString();
            if (fields.Contains(Parm_SealUpGoods_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_SealUpGoods_RowStatus].ToString());
            if (fields.Contains(Parm_SealUpGoods_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_SealUpGoods_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_SealUpGoods_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_SealUpGoods_CreatorId].ToString();
            if (fields.Contains(Parm_SealUpGoods_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_SealUpGoods_CreateBy].ToString();
            if (fields.Contains(Parm_SealUpGoods_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_SealUpGoods_CreateOn].ToString());
            if (fields.Contains(Parm_SealUpGoods_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_SealUpGoods_UpdateId].ToString();
            if (fields.Contains(Parm_SealUpGoods_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_SealUpGoods_UpdateBy].ToString();
            if (fields.Contains(Parm_SealUpGoods_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_SealUpGoods_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="sealupgoods">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(SealUpGoodsEntity sealupgoods, SqlParameter[] parms)
        {
            parms[0].Value = sealupgoods.SealUpId;
            parms[1].Value = sealupgoods.Name;
            parms[2].Value = sealupgoods.Location;
            parms[3].Value = sealupgoods.Direction;
            parms[4].Value = sealupgoods.Area;
            parms[5].Value = sealupgoods.MaterialId;
            parms[6].Value = sealupgoods.MaterialName;
            parms[7].Value = sealupgoods.Remark;
            parms[8].Value = sealupgoods.RowStatus;
            parms[9].Value = sealupgoods.CreatorId;
            parms[10].Value = sealupgoods.CreateBy;
            parms[11].Value = sealupgoods.CreateOn;
            parms[12].Value = sealupgoods.UpdateId;
            parms[13].Value = sealupgoods.UpdateBy;
            parms[14].Value = sealupgoods.UpdateOn;
            parms[15].Value = sealupgoods.Id;

            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(SealUpGoodsEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUpGoods_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_SealUpGoods_SealUpId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_Name, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_Location, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_Direction, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_Area, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_MaterialId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_MaterialName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_Remark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUpGoods_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SealUpGoods_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpGoods_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_SealUpGoods_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUpGoods_Insert, parms);
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
