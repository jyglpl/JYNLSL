//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:24
//  功能描述：Legislation表实体
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
    /// 法律法规（违法行为）
    /// </summary>
    [Serializable]
    public class LegislationEntity : ModelImp.BaseModel<LegislationEntity>
    {
        public LegislationEntity()
        {
            TB_Name = TB_Legislation;
            Parm_Id = Parm_Legislation_Id;
            Parm_Version = Parm_Legislation_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Legislation_Insert;
            Sql_Update = Sql_Legislation_Update;
            Sql_Delete = Sql_Legislation_Delete;
        }
        #region Const of table Legislation
        /// <summary>
        /// Table Legislation
        /// </summary>
        public const string TB_Legislation = "Legislation";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ClassName
        /// </summary>
        public const string Parm_Legislation_ClassName = "ClassName";
        /// <summary>
        /// Parm ClassNo
        /// </summary>
        public const string Parm_Legislation_ClassNo = "ClassNo";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Legislation_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Legislation_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Legislation_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Legislation_Id = "Id";
        /// <summary>
        /// Parm ItemAct
        /// </summary>
        public const string Parm_Legislation_ItemAct = "ItemAct";
        /// <summary>
        /// Parm ItemCode
        /// </summary>
        public const string Parm_Legislation_ItemCode = "ItemCode";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_Legislation_ItemNo = "ItemNo";
        /// <summary>
        /// Parm ItemType
        /// </summary>
        public const string Parm_Legislation_ItemType = "ItemType";
        /// <summary>
        /// Parm Num
        /// </summary>
        public const string Parm_Legislation_Num = "Num";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_Legislation_OrderNo = "OrderNo";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Legislation_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Legislation_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Legislation_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Legislation_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Legislation_Version = "Version";
        /// <summary>
        /// Insert Query Of Legislation
        /// </summary>
        public const string Sql_Legislation_Insert = "insert into Legislation(ClassName,ClassNo,CreateBy,CreateOn,CreatorId,ItemAct,ItemCode,ItemNo,ItemType,Num,OrderNo,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@ClassName,@ClassNo,@CreateBy,@CreateOn,@CreatorId,@ItemAct,@ItemCode,@ItemNo,@ItemType,@Num,@OrderNo,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Legislation
        /// </summary>
        public const string Sql_Legislation_Update = "update Legislation set ClassName=@ClassName,ClassNo=@ClassNo,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,ItemAct=@ItemAct,ItemCode=@ItemCode,ItemNo=@ItemNo,ItemType=@ItemType,Num=@Num,OrderNo=@OrderNo,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Legislation_Delete = "update Legislation set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _num = string.Empty;
        /// <summary>
        /// varchar 序号
        /// </summary>
        public string Num
        {
            get { return _num ?? string.Empty; }
            set { _num = value; }
        }
        private string _itemCode = string.Empty;
        /// <summary>
        /// varchar 权力编码
        /// </summary>
        public string ItemCode
        {
            get { return _itemCode ?? string.Empty; }
            set { _itemCode = value; }
        }
        private string _itemType = string.Empty;
        /// <summary>
        /// nvarchar 权力类型
        /// </summary>
        public string ItemType
        {
            get { return _itemType ?? string.Empty; }
            set { _itemType = value; }
        }
        private string _itemNo = string.Empty;
        /// <summary>
        /// varchar 案由编号
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _itemAct = string.Empty;
        /// <summary>
        /// nvarchar 违法行为
        /// </summary>
        public string ItemAct
        {
            get { return _itemAct ?? string.Empty; }
            set { _itemAct = value; }
        }
        private string _classNo = string.Empty;
        /// <summary>
        /// nvarchar 所属类型（大类）
        /// </summary>
        public string ClassNo
        {
            get { return _classNo ?? string.Empty; }
            set { _classNo = value; }
        }
        private string _className = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ClassName
        {
            get { return _className ?? string.Empty; }
            set { _className = value; }
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

        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWords { get; set; }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LegislationEntity SetModelValueByDataRow(DataRow dr)
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
        public override LegislationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LegislationEntity();
            if (fields.Contains(Parm_Legislation_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Legislation_Id].ToString();
            if (fields.Contains(Parm_Legislation_Num) || fields.Contains("*"))
                tmp.Num = dr[Parm_Legislation_Num].ToString();
            if (fields.Contains(Parm_Legislation_ItemCode) || fields.Contains("*"))
                tmp.ItemCode = dr[Parm_Legislation_ItemCode].ToString();
            if (fields.Contains(Parm_Legislation_ItemType) || fields.Contains("*"))
                tmp.ItemType = dr[Parm_Legislation_ItemType].ToString();
            if (fields.Contains(Parm_Legislation_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_Legislation_ItemNo].ToString();
            if (fields.Contains(Parm_Legislation_ItemAct) || fields.Contains("*"))
                tmp.ItemAct = dr[Parm_Legislation_ItemAct].ToString();
            if (fields.Contains(Parm_Legislation_ClassNo) || fields.Contains("*"))
                tmp.ClassNo = dr[Parm_Legislation_ClassNo].ToString();
            if (fields.Contains(Parm_Legislation_ClassName) || fields.Contains("*"))
                tmp.ClassName = dr[Parm_Legislation_ClassName].ToString();
            if (fields.Contains(Parm_Legislation_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_Legislation_OrderNo].ToString());
            if (fields.Contains(Parm_Legislation_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Legislation_RowStatus].ToString());
            if (fields.Contains(Parm_Legislation_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Legislation_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Legislation_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Legislation_CreatorId].ToString();
            if (fields.Contains(Parm_Legislation_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Legislation_CreateBy].ToString();
            if (fields.Contains(Parm_Legislation_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Legislation_CreateOn].ToString());
            if (fields.Contains(Parm_Legislation_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Legislation_UpdateId].ToString();
            if (fields.Contains(Parm_Legislation_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Legislation_UpdateBy].ToString();
            if (fields.Contains(Parm_Legislation_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Legislation_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="legislation">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LegislationEntity legislation, SqlParameter[] parms)
        {
            parms[0].Value = legislation.Num;
            parms[1].Value = legislation.ItemCode;
            parms[2].Value = legislation.ItemType;
            parms[3].Value = legislation.ItemNo;
            parms[4].Value = legislation.ItemAct;
            parms[5].Value = legislation.ClassNo;
            parms[6].Value = legislation.ClassName;
            parms[7].Value = legislation.OrderNo;
            parms[8].Value = legislation.RowStatus;
            parms[9].Value = legislation.CreatorId;
            parms[10].Value = legislation.CreateBy;
            parms[11].Value = legislation.CreateOn;
            parms[12].Value = legislation.UpdateId;
            parms[13].Value = legislation.UpdateBy;
            parms[14].Value = legislation.UpdateOn;
            parms[15].Value = legislation.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LegislationEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Legislation_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Legislation_Num, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_Legislation_ItemCode, SqlDbType.VarChar, 20),
					new SqlParameter(Parm_Legislation_ItemType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Legislation_ItemNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_Legislation_ItemAct, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_Legislation_ClassNo, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Legislation_ClassName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Legislation_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_Legislation_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Legislation_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Legislation_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Legislation_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Legislation_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Legislation_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Legislation_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Legislation_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Legislation_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }


    /// <summary>
    /// 法律法规详情
    /// </summary>
    [Serializable]
    public class PunishDetailEntity
    {
        public PunishDetailEntity(LegislationEntity legislation,
            List<LegislationItemEntity> legislationItems, List<LegislationRuleEntity> legislationRules)
        {
            Legislation = legislation;
            LegislationItems = legislationItems;
            LegislationRules = legislationRules;
        }

        /// <summary>
        /// 违法行为
        /// </summary>
        public LegislationEntity Legislation
        {
            get;
            set;
        }

        /// <summary>
        /// 法律法规
        /// </summary>
        public List<LegislationRuleEntity> LegislationRules
        {
            get;
            set;
        }

        /// <summary>
        /// 适用案由
        /// </summary>
        public List<LegislationItemEntity> LegislationItems
        {
            get;
            set;
        }

    }
}

