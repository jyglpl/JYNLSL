//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainGoodsEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 14:35:49
//  功能描述：TempDetainGoods表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.TempDetain
{
    /// <summary>
    /// 暂扣物品信息
    /// </summary>
    [Serializable]
    public class TempDetainGoodsEntity : ModelImp.BaseModel<TempDetainGoodsEntity>
    {
        public TempDetainGoodsEntity()
        {
            TB_Name = TB_TempDetainGoods;
            Parm_Id = Parm_TempDetainGoods_Id;
            Parm_Version = Parm_TempDetainGoods_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TempDetainGoods_Insert;
            Sql_Update = Sql_TempDetainGoods_Update;
            Sql_Delete = Sql_TempDetainGoods_Delete;
        }
        /// <summary>
        /// 构造函数
        /// 创建人：周庆
        /// 创建日期：2015年5月7日
        /// </summary>
        /// <param name="reader"></param>
        public TempDetainGoodsEntity(SqlDataReader reader)
        {

            Id = reader["Id"].ToString();
            TempId = reader["TempId"].ToString();
            ClassI = reader["ClassI"].ToString();
            ClassII = reader["ClassII"].ToString();
            GoodsNo = reader["GoodsNo"].ToString();
            GoodsName = reader["GoodsName"].ToString();
            GoodsCount = Convert.ToInt32(reader["GoodsCount"]);
            GoodsUnit = reader["GoodsUnit"].ToString();
            GoodsUnitName = reader["GoodsUnitName"].ToString();
            Specification = reader["Specification"].ToString();
            Remark = reader["Remark"].ToString();
            TransferDeptName = reader["TransferDeptName"].ToString();
            State = Convert.ToInt32(reader["State"]);
            RowStatus = Convert.ToInt32(reader["RowStatus"]);
            CreatorId = reader["CreatorId"].ToString();
            CreateBy = reader["CreateBy"].ToString();
            CreateOn = Convert.ToDateTime(reader["CreateOn"]);
            UpdateId = reader["UpdateId"].ToString();
            UpdateBy = reader["UpdateBy"].ToString();
            UpdateOn = Convert.ToDateTime(reader["UpdateOn"]);
        }

        #region Const of table TempDetainGoods
        /// <summary>
        /// Table TempDetainGoods
        /// </summary>
        public const string TB_TempDetainGoods = "TempDetainGoods";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ClassI
        /// </summary>
        public const string Parm_TempDetainGoods_ClassI = "ClassI";
        /// <summary>
        /// Parm ClassII
        /// </summary>
        public const string Parm_TempDetainGoods_ClassII = "ClassII";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TempDetainGoods_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TempDetainGoods_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TempDetainGoods_CreatorId = "CreatorId";
        /// <summary>
        /// Parm GoodsCount
        /// </summary>
        public const string Parm_TempDetainGoods_GoodsCount = "GoodsCount";
        /// <summary>
        /// Parm GoodsName
        /// </summary>
        public const string Parm_TempDetainGoods_GoodsName = "GoodsName";
        /// <summary>
        /// Parm GoodsNo
        /// </summary>
        public const string Parm_TempDetainGoods_GoodsNo = "GoodsNo";
        /// <summary>
        /// Parm GoodsUnit
        /// </summary>
        public const string Parm_TempDetainGoods_GoodsUnit = "GoodsUnit";
        /// <summary>
        /// Parm GoodsUnitName
        /// </summary>
        public const string Parm_TempDetainGoods_GoodsUnitName = "GoodsUnitName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TempDetainGoods_Id = "Id";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_TempDetainGoods_Remark = "Remark";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TempDetainGoods_RowStatus = "RowStatus";
        /// <summary>
        /// Parm Specification
        /// </summary>
        public const string Parm_TempDetainGoods_Specification = "Specification";
        /// <summary>
        /// Parm State
        /// </summary>
        public const string Parm_TempDetainGoods_State = "State";
        /// <summary>
        /// Parm TransferDeptName
        /// </summary>
        public const string Parm_TempDetainGoods_TransferDeptName = "TransferDeptName";
        /// <summary>
        /// Parm TempId
        /// </summary>
        public const string Parm_TempDetainGoods_TempId = "TempId";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TempDetainGoods_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TempDetainGoods_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TempDetainGoods_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainGoods_Version = "Version";
        /// <summary>
        /// Insert Query Of TempDetainGoods
        /// </summary>
        public const string Sql_TempDetainGoods_Insert = "insert into TempDetainGoods(ClassI,ClassII,CreateBy,CreateOn,CreatorId,GoodsCount,GoodsName,GoodsNo,GoodsUnit,GoodsUnitName,Remark,RowStatus,Specification,State,TempId,UpdateBy,UpdateId,UpdateOn,TransferDeptName,Id) values(@ClassI,@ClassII,@CreateBy,@CreateOn,@CreatorId,@GoodsCount,@GoodsName,@GoodsNo,@GoodsUnit,@GoodsUnitName,@Remark,@RowStatus,@Specification,@State,@TempId,@UpdateBy,@UpdateId,@UpdateOn,@TransferDeptName,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TempDetainGoods
        /// </summary>
        public const string Sql_TempDetainGoods_Update = "update TempDetainGoods set ClassI=@ClassI,ClassII=@ClassII,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,GoodsCount=@GoodsCount,GoodsName=@GoodsName,GoodsNo=@GoodsNo,GoodsUnit=@GoodsUnit,GoodsUnitName=@GoodsUnitName,Remark=@Remark,RowStatus=@RowStatus,Specification=@Specification,State=@State,TempId=@TempId,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,TransferDeptName=@TransferDeptName where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TempDetainGoods_Delete = "update TempDetainGoods set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _tempId = string.Empty;
        /// <summary>
        /// 外键编号
        /// </summary>
        public string TempId
        {
            get { return _tempId ?? string.Empty; }
            set { _tempId = value; }
        }
        private string _classI = string.Empty;
        /// <summary>
        /// 大类
        /// </summary>
        public string ClassI
        {
            get { return _classI ?? string.Empty; }
            set { _classI = value; }
        }
        private string _classII = string.Empty;
        /// <summary>
        /// 小类
        /// </summary>
        public string ClassII
        {
            get { return _classII ?? string.Empty; }
            set { _classII = value; }
        }
        private string _goodsNo = string.Empty;
        /// <summary>
        /// 物品编号
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo ?? string.Empty; }
            set { _goodsNo = value; }
        }
        private string _goodsName = string.Empty;
        /// <summary>
        /// 物品名称
        /// </summary>
        public string GoodsName
        {
            get { return _goodsName ?? string.Empty; }
            set { _goodsName = value; }
        }
        private int _goodsCount;
        /// <summary>
        /// 物品数量 
        /// </summary>
        public int GoodsCount
        {
            get { return _goodsCount; }
            set { _goodsCount = value; }
        }
        private string _goodsUnit = string.Empty;
        /// <summary>
        /// 计量单位编号
        /// </summary>
        public string GoodsUnit
        {
            get { return _goodsUnit ?? string.Empty; }
            set { _goodsUnit = value; }
        }
        private string _goodsUnitName = string.Empty;
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string GoodsUnitName
        {
            get { return _goodsUnitName ?? string.Empty; }
            set { _goodsUnitName = value; }
        }
        private string _specification = string.Empty;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specification
        {
            get { return _specification ?? string.Empty; }
            set { _specification = value; }
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
        private int _state;
        /// <summary>
        /// 状态 
        /// </summary>
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _transferDeptName = string.Empty;
        /// <summary>
        /// 移交部门名称
        /// </summary>
        public string TransferDeptName
        {
            get { return _transferDeptName ?? string.Empty; }
            set { _transferDeptName = value; }
        }

        /// <summary>
        /// 暂扣物品大类名称
        /// </summary>
        public string ClassIName { get; set; }

        /// <summary>
        /// 分类物品暂扣总数
        /// </summary>
        public int TotalCount { get; set; }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override TempDetainGoodsEntity SetModelValueByDataRow(DataRow dr)
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
        public override TempDetainGoodsEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainGoodsEntity();
            if (fields.Contains(Parm_TempDetainGoods_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_TempDetainGoods_Id].ToString();
            if (fields.Contains(Parm_TempDetainGoods_TempId) || fields.Contains("*"))
                tmp.TempId = dr[Parm_TempDetainGoods_TempId].ToString();
            if (fields.Contains(Parm_TempDetainGoods_ClassI) || fields.Contains("*"))
                tmp.ClassI = dr[Parm_TempDetainGoods_ClassI].ToString();
            if (fields.Contains(Parm_TempDetainGoods_ClassII) || fields.Contains("*"))
                tmp.ClassII = dr[Parm_TempDetainGoods_ClassII].ToString();
            if (fields.Contains(Parm_TempDetainGoods_GoodsNo) || fields.Contains("*"))
                tmp.GoodsNo = dr[Parm_TempDetainGoods_GoodsNo].ToString();
            if (fields.Contains(Parm_TempDetainGoods_GoodsName) || fields.Contains("*"))
                tmp.GoodsName = dr[Parm_TempDetainGoods_GoodsName].ToString();
            if (fields.Contains(Parm_TempDetainGoods_GoodsCount) || fields.Contains("*"))
                tmp.GoodsCount = int.Parse(dr[Parm_TempDetainGoods_GoodsCount].ToString());
            if (fields.Contains(Parm_TempDetainGoods_GoodsUnit) || fields.Contains("*"))
                tmp.GoodsUnit = dr[Parm_TempDetainGoods_GoodsUnit].ToString();
            if (fields.Contains(Parm_TempDetainGoods_GoodsUnitName) || fields.Contains("*"))
                tmp.GoodsUnitName = dr[Parm_TempDetainGoods_GoodsUnitName].ToString();
            if (fields.Contains(Parm_TempDetainGoods_Specification) || fields.Contains("*"))
                tmp.Specification = dr[Parm_TempDetainGoods_Specification].ToString();
            if (fields.Contains(Parm_TempDetainGoods_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_TempDetainGoods_Remark].ToString();
            if (fields.Contains(Parm_TempDetainGoods_State) || fields.Contains("*"))
                tmp.State = int.Parse(dr[Parm_TempDetainGoods_State].ToString());
            if (fields.Contains(Parm_TempDetainGoods_TransferDeptName) || fields.Contains("*"))
                tmp.TransferDeptName = dr[Parm_TempDetainGoods_TransferDeptName].ToString();
            if (fields.Contains(Parm_TempDetainGoods_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_TempDetainGoods_RowStatus].ToString());
            if (fields.Contains(Parm_TempDetainGoods_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_TempDetainGoods_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_TempDetainGoods_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_TempDetainGoods_CreatorId].ToString();
            if (fields.Contains(Parm_TempDetainGoods_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_TempDetainGoods_CreateBy].ToString();
            if (fields.Contains(Parm_TempDetainGoods_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainGoods_CreateOn].ToString());
            if (fields.Contains(Parm_TempDetainGoods_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_TempDetainGoods_UpdateId].ToString();
            if (fields.Contains(Parm_TempDetainGoods_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_TempDetainGoods_UpdateBy].ToString();
            if (fields.Contains(Parm_TempDetainGoods_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainGoods_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetaingoods">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainGoodsEntity tempdetaingoods, SqlParameter[] parms)
        {
            parms[0].Value = tempdetaingoods.TempId;
            parms[1].Value = tempdetaingoods.ClassI;
            parms[2].Value = tempdetaingoods.ClassII;
            parms[3].Value = tempdetaingoods.GoodsNo;
            parms[4].Value = tempdetaingoods.GoodsName;
            parms[5].Value = tempdetaingoods.GoodsCount;
            parms[6].Value = tempdetaingoods.GoodsUnit;
            parms[7].Value = tempdetaingoods.GoodsUnitName;
            parms[8].Value = tempdetaingoods.Specification;
            parms[9].Value = tempdetaingoods.Remark;
            parms[10].Value = tempdetaingoods.State;
            parms[11].Value = tempdetaingoods.RowStatus;
            parms[12].Value = tempdetaingoods.CreatorId;
            parms[13].Value = tempdetaingoods.CreateBy;
            parms[14].Value = tempdetaingoods.CreateOn;
            parms[15].Value = tempdetaingoods.UpdateId;
            parms[16].Value = tempdetaingoods.UpdateBy;
            parms[17].Value = tempdetaingoods.UpdateOn;
            parms[18].Value = tempdetaingoods.TransferDeptName;
            parms[19].Value = tempdetaingoods.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainGoodsEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainGoods_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_TempDetainGoods_TempId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_ClassI, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_ClassII, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_GoodsNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_GoodsName, SqlDbType.NChar, 10),
					new SqlParameter(Parm_TempDetainGoods_GoodsCount, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainGoods_GoodsUnit, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_GoodsUnitName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_Specification, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_Remark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_State, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainGoods_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainGoods_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainGoods_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainGoods_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TempDetainGoods_TransferDeptName, SqlDbType.NVarChar, 200),
                    new SqlParameter(Parm_TempDetainGoods_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainGoods_Insert, parms);
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

