//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationRuleEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/1 18:56:11
//  功能描述：LegislationRule表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Case
{
    /// <summary>
    /// 法律法规（处罚标准）
    /// </summary>
    [Serializable]
    public class LegislationRuleEntity : ModelImp.BaseModel<LegislationRuleEntity>
    {
        public LegislationRuleEntity()
        {
            TB_Name = TB_LegislationRule;
            Parm_Id = Parm_LegislationRule_Id;
            Parm_Version = Parm_LegislationRule_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LegislationRule_Insert;
            Sql_Update = Sql_LegislationRule_Update;
            Sql_Delete = Sql_LegislationRule_Delete;
        }
        #region Const of table LegislationRule
        /// <summary>
        /// Table LegislationRule
        /// </summary>
        public const string TB_LegislationRule = "LegislationRule";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LegislationRule_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LegislationRule_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LegislationRule_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LegislationRule_Id = "Id";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_LegislationRule_ItemNo = "ItemNo";
        /// <summary>
        /// Parm LegislationId
        /// </summary>
        public const string Parm_LegislationRule_LegislationId = "LegislationId";
        /// <summary>
        /// Parm Measurement
        /// </summary>
        public const string Parm_LegislationRule_Measurement = "Measurement";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_LegislationRule_OrderNo = "OrderNo";
        /// <summary>
        /// Parm PunishContent
        /// </summary>
        public const string Parm_LegislationRule_PunishContent = "PunishContent";
        /// <summary>
        /// Parm PunishDesc
        /// </summary>
        public const string Parm_LegislationRule_PunishDesc = "PunishDesc";
        /// <summary>
        /// Parm PunishMax
        /// </summary>
        public const string Parm_LegislationRule_PunishMax = "PunishMax";
        /// <summary>
        /// Parm PunishMin
        /// </summary>
        public const string Parm_LegislationRule_PunishMin = "PunishMin";
        /// <summary>
        /// Parm PunishType
        /// </summary>
        public const string Parm_LegislationRule_PunishType = "PunishType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LegislationRule_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LegislationRule_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LegislationRule_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LegislationRule_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LegislationRule_Version = "Version";
        /// <summary>
        /// Insert Query Of LegislationRule
        /// </summary>
        public const string Sql_LegislationRule_Insert = "insert into LegislationRule(CreateBy,CreateOn,CreatorId,ItemNo,LegislationId,Measurement,OrderNo,PunishContent,PunishDesc,PunishMax,PunishMin,PunishType,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@ItemNo,@LegislationId,@Measurement,@OrderNo,@PunishContent,@PunishDesc,@PunishMax,@PunishMin,@PunishType,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LegislationRule
        /// </summary>
        public const string Sql_LegislationRule_Update = "update LegislationRule set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ItemNo=@ItemNo,LegislationId=@LegislationId,Measurement=@Measurement,OrderNo=@OrderNo,PunishContent=@PunishContent,PunishDesc=@PunishDesc,PunishMax=@PunishMax,PunishMin=@PunishMin,PunishType=@PunishType,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LegislationRule_Delete = "update LegislationRule set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _itemNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _legislationId = string.Empty;
        /// <summary>
        /// nvarchar 主表编号
        /// </summary>
        public string LegislationId
        {
            get { return _legislationId ?? string.Empty; }
            set { _legislationId = value; }
        }
        private string _punishContent = string.Empty;
        /// <summary>
        /// nvarchar 处罚内容
        /// </summary>
        public string PunishContent
        {
            get { return _punishContent ?? string.Empty; }
            set { _punishContent = value; }
        }
        private string _punishDesc = string.Empty;
        /// <summary>
        /// 处罚内容描述
        /// </summary>
        public string PunishDesc
        {
            get { return _punishDesc ?? string.Empty; }
            set { _punishDesc = value; }
        }
        private string _punishType = string.Empty;
        /// <summary>
        /// nvarchar 处罚种类
        /// </summary>
        public string PunishType
        {
            get { return _punishType ?? string.Empty; }
            set { _punishType = value; }
        }
        private string _measurement = string.Empty;
        /// <summary>
        /// nvarchar 处罚计量单位
        /// </summary>
        public string Measurement
        {
            get { return _measurement ?? string.Empty; }
            set { _measurement = value; }
        }
        private int _punishMax;
        /// <summary>
        /// int 处罚标准上限
        /// </summary>
        public int PunishMax
        {
            get { return _punishMax; }
            set { _punishMax = value; }
        }
        private int _punishMin;
        /// <summary>
        /// int 处罚标准下限
        /// </summary>
        public int PunishMin
        {
            get { return _punishMin; }
            set { _punishMin = value; }
        }
        private int _orderNo;
        /// <summary>
        /// int 排序编号
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
        public override LegislationRuleEntity SetModelValueByDataRow(DataRow dr)
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
        public override LegislationRuleEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LegislationRuleEntity();
            if (fields.Contains(Parm_LegislationRule_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LegislationRule_Id].ToString();
            if (fields.Contains(Parm_LegislationRule_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_LegislationRule_ItemNo].ToString();
            if (fields.Contains(Parm_LegislationRule_LegislationId) || fields.Contains("*"))
                tmp.LegislationId = dr[Parm_LegislationRule_LegislationId].ToString();
            if (fields.Contains(Parm_LegislationRule_PunishContent) || fields.Contains("*"))
                tmp.PunishContent = dr[Parm_LegislationRule_PunishContent].ToString();
            if (fields.Contains(Parm_LegislationRule_PunishDesc) || fields.Contains("*"))
                tmp.PunishDesc = dr[Parm_LegislationRule_PunishDesc].ToString();
            if (fields.Contains(Parm_LegislationRule_PunishType) || fields.Contains("*"))
                tmp.PunishType = dr[Parm_LegislationRule_PunishType].ToString();
            if (fields.Contains(Parm_LegislationRule_Measurement) || fields.Contains("*"))
                tmp.Measurement = dr[Parm_LegislationRule_Measurement].ToString();
            if (fields.Contains(Parm_LegislationRule_PunishMax) || fields.Contains("*"))
                tmp.PunishMax = int.Parse(dr[Parm_LegislationRule_PunishMax].ToString());
            if (fields.Contains(Parm_LegislationRule_PunishMin) || fields.Contains("*"))
                tmp.PunishMin = int.Parse(dr[Parm_LegislationRule_PunishMin].ToString());
            if (fields.Contains(Parm_LegislationRule_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_LegislationRule_OrderNo].ToString());
            if (fields.Contains(Parm_LegislationRule_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LegislationRule_RowStatus].ToString());
            if (fields.Contains(Parm_LegislationRule_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LegislationRule_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LegislationRule_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LegislationRule_CreatorId].ToString();
            if (fields.Contains(Parm_LegislationRule_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LegislationRule_CreateBy].ToString();
            if (fields.Contains(Parm_LegislationRule_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LegislationRule_CreateOn].ToString());
            if (fields.Contains(Parm_LegislationRule_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LegislationRule_UpdateId].ToString();
            if (fields.Contains(Parm_LegislationRule_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LegislationRule_UpdateBy].ToString();
            if (fields.Contains(Parm_LegislationRule_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LegislationRule_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="legislationrule">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LegislationRuleEntity legislationrule, SqlParameter[] parms)
        {
            parms[0].Value = legislationrule.ItemNo;
            parms[1].Value = legislationrule.LegislationId;
            parms[2].Value = legislationrule.PunishContent;
            parms[3].Value = legislationrule.PunishDesc;
            parms[4].Value = legislationrule.PunishType;
            parms[5].Value = legislationrule.Measurement;
            parms[6].Value = legislationrule.PunishMax;
            parms[7].Value = legislationrule.PunishMin;
            parms[8].Value = legislationrule.OrderNo;
            parms[9].Value = legislationrule.RowStatus;
            parms[10].Value = legislationrule.CreatorId;
            parms[11].Value = legislationrule.CreateBy;
            parms[12].Value = legislationrule.CreateOn;
            parms[13].Value = legislationrule.UpdateId;
            parms[14].Value = legislationrule.UpdateBy;
            parms[15].Value = legislationrule.UpdateOn;
            parms[16].Value = legislationrule.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LegislationRuleEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationRule_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LegislationRule_ItemNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_LegislationId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_PunishContent, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_LegislationRule_PunishDesc, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_LegislationRule_PunishType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_LegislationRule_Measurement, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_LegislationRule_PunishMax, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationRule_PunishMin, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationRule_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationRule_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationRule_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LegislationRule_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationRule_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LegislationRule_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationRule_Insert, parms);
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

