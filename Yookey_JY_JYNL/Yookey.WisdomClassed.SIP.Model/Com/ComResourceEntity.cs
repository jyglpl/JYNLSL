//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComResourceEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:43
//  功能描述：ComResource表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.ModelImp;
//using PetaPoco;
//using System.Runtime.Serialization;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 基础数据
    /// </summary>
    [Serializable]
    public class ComResourceEntity : BaseModel<ComResourceEntity>
    {
        public ComResourceEntity()
        {
            TB_Name = TB_ComResource;
            Parm_Id = Parm_ComResource_Id;
            Parm_Version = Parm_ComResource_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComResource_Insert;
            Sql_Update = Sql_ComResource_Update;
            Sql_Delete = Sql_ComResource_Delete;
        }



        #region Const of table ComResource
        /// <summary>
        /// Table ComResource
        /// </summary>
        public const string TB_ComResource = "ComResource";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComResource_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComResource_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComResource_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComResource_Id = "Id";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_ComResource_OrderNo = "OrderNo";
        /// <summary>
        /// Parm ParentId
        /// </summary>
        public const string Parm_ComResource_ParentId = "ParentId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComResource_RowStatus = "RowStatus";
        /// <summary>
        /// Parm RsKey
        /// </summary>
        public const string Parm_ComResource_RsKey = "RsKey";
        /// <summary>
        /// Parm RsRemark
        /// </summary>
        public const string Parm_ComResource_RsRemark = "RsRemark";
        /// <summary>
        /// Parm RsUseflg
        /// </summary>
        public const string Parm_ComResource_RsUseflg = "RsUseflg";
        /// <summary>
        /// Parm RsValue
        /// </summary>
        public const string Parm_ComResource_RsValue = "RsValue";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComResource_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComResource_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComResource_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComResource_Version = "Version";
        /// <summary>
        /// Insert Query Of ComResource
        /// </summary>
        public const string Sql_ComResource_Insert = "insert into ComResource(CreateBy,CreateOn,CreatorId,OrderNo,ParentId,RowStatus,RsKey,RsRemark,RsUseflg,RsValue,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@OrderNo,@ParentId,@RowStatus,@RsKey,@RsRemark,@RsUseflg,@RsValue,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComResource
        /// </summary>
        public const string Sql_ComResource_Update = "update ComResource set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,OrderNo=@OrderNo,ParentId=@ParentId,RowStatus=@RowStatus,RsKey=@RsKey,RsRemark=@RsRemark,RsUseflg=@RsUseflg,RsValue=@RsValue,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComResource_Delete = "update ComResource set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _parentId = string.Empty;
        /// <summary>
        /// 父编号
        /// </summary>
        public string ParentId
        {
            get { return _parentId ?? string.Empty; }
            set { _parentId = value; }
        }
        private string _rsKey = string.Empty;
        
        public string RsKey
        {
            get { return _rsKey ?? string.Empty; }
            set { _rsKey = value; }
        }
        private string _rsValue = string.Empty;
        /// <summary>
        /// 值
        /// </summary>
        public string RsValue
        {
            get { return _rsValue ?? string.Empty; }
            set { _rsValue = value; }
        }
        private string _rsUseflg = string.Empty;
        /// <summary>
        /// 是否启用
        /// </summary>
        public string RsUseflg
        {
            get { return _rsUseflg ?? string.Empty; }
            set { _rsUseflg = value; }
        }
        private string _rsRemark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string RsRemark
        {
            get { return _rsRemark ?? string.Empty; }
            set { _rsRemark = value; }
        }
        private int _orderNo;
        /// <summary>
        /// 排序编号
        /// </summary>
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComResourceEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComResourceEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComResourceEntity();
            if (dr.Table.Columns.Contains(Parm_ComResource_Id))
                tmp.Id = dr[Parm_ComResource_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_ParentId))
                tmp.ParentId = dr[Parm_ComResource_ParentId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_RsKey))
                tmp.RsKey = dr[Parm_ComResource_RsKey].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_RsValue))
                tmp.RsValue = dr[Parm_ComResource_RsValue].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_RsUseflg))
                tmp.RsUseflg = dr[Parm_ComResource_RsUseflg].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_RsRemark))
                tmp.RsRemark = dr[Parm_ComResource_RsRemark].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_OrderNo))
                tmp.OrderNo = int.Parse(dr[Parm_ComResource_OrderNo].ToString());
            if (dr.Table.Columns.Contains(Parm_ComResource_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_ComResource_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_ComResource_Version))
            {
                var bts = (byte[])(dr[Parm_ComResource_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_ComResource_CreatorId))
                tmp.CreatorId = dr[Parm_ComResource_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_CreateBy))
                tmp.CreateBy = dr[Parm_ComResource_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComResource_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_ComResource_UpdateId))
                tmp.UpdateId = dr[Parm_ComResource_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_UpdateBy))
                tmp.UpdateBy = dr[Parm_ComResource_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_ComResource_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComResource_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comresource">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComResourceEntity comresource, SqlParameter[] parms)
        {
            parms[0].Value = comresource.ParentId;
            parms[1].Value = comresource.RsKey;
            parms[2].Value = comresource.RsValue;
            parms[3].Value = comresource.RsUseflg;
            parms[4].Value = comresource.RsRemark;
            parms[5].Value = comresource.OrderNo;
            parms[6].Value = comresource.RowStatus;
            parms[7].Value = comresource.CreatorId;
            parms[8].Value = comresource.CreateBy;
            parms[9].Value = comresource.CreateOn;
            parms[10].Value = comresource.UpdateId;
            parms[11].Value = comresource.UpdateBy;
            parms[12].Value = comresource.UpdateOn;
            parms[13].Value = comresource.Id;
            return parms;
        }
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComResourceEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComResource_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComResource_ParentId, SqlDbType.VarChar, 32),
					new SqlParameter(Parm_ComResource_RsKey, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_ComResource_RsValue, SqlDbType.VarChar, 100),
					new SqlParameter(Parm_ComResource_RsUseflg, SqlDbType.Char, 1),
					new SqlParameter(Parm_ComResource_RsRemark, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_ComResource_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComResource_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComResource_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComResource_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComResource_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComResource_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComResource_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComResource_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComResource_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComResource_Insert, parms);
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
