//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationItemEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:23
//  功能描述：LegislationItem表实体
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
    /// 法律法规（适用案由）
    /// </summary>
    [Serializable]
    public class LegislationItemEntity : ModelImp.BaseModel<LegislationItemEntity>
    {
        public LegislationItemEntity()
        {
            TB_Name = TB_LegislationItem;
            Parm_Id = Parm_LegislationItem_Id;
            Parm_Version = Parm_LegislationItem_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LegislationItem_Insert;
            Sql_Update = Sql_LegislationItem_Update;
            Sql_Delete = Sql_LegislationItem_Delete;
        }
        #region Const of table LegislationItem
        /// <summary>
        /// Table LegislationItem
        /// </summary>
        public const string TB_LegislationItem = "LegislationItem";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LegislationItem_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LegislationItem_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LegislationItem_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndCaseAbstract
        /// </summary>
        public const string Parm_LegislationItem_EndCaseAbstract = "EndCaseAbstract";
        /// <summary>
        /// Parm EndExecute
        /// </summary>
        public const string Parm_LegislationItem_EndExecute = "EndExecute";
        /// <summary>
        /// Parm EndLawsuit
        /// </summary>
        public const string Parm_LegislationItem_EndLawsuit = "EndLawsuit";
        /// <summary>
        /// Parm EndOpinion
        /// </summary>
        public const string Parm_LegislationItem_EndOpinion = "EndOpinion";
        /// <summary>
        /// Parm EndPunishments
        /// </summary>
        public const string Parm_LegislationItem_EndPunishments = "EndPunishments";
        /// <summary>
        /// Parm HaCaseAbstract
        /// </summary>
        public const string Parm_LegislationItem_HaCaseAbstract = "HaCaseAbstract";
        /// <summary>
        /// Parm HaOpinion
        /// </summary>
        public const string Parm_LegislationItem_HaOpinion = "HaOpinion";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LegislationItem_Id = "Id";
        /// <summary>
        /// Parm ItemName
        /// </summary>
        public const string Parm_LegislationItem_ItemName = "ItemName";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_LegislationItem_ItemNo = "ItemNo";
        /// <summary>
        /// Parm LegislationId
        /// </summary>
        public const string Parm_LegislationItem_LegislationId = "LegislationId";
        /// <summary>
        /// Parm Num
        /// </summary>
        public const string Parm_LegislationItem_Num = "Num";
        /// <summary>
        /// Parm OrderNo
        /// </summary>
        public const string Parm_LegislationItem_OrderNo = "OrderNo";
        /// <summary>
        /// Parm PunishMethod
        /// </summary>
        public const string Parm_LegislationItem_PunishMethod = "PunishMethod";
        /// <summary>
        /// Parm ReCaseAbstract
        /// </summary>
        public const string Parm_LegislationItem_ReCaseAbstract = "ReCaseAbstract";
        /// <summary>
        /// Parm Records
        /// </summary>
        public const string Parm_LegislationItem_Records = "Records";
        /// <summary>
        /// Parm ReHarm
        /// </summary>
        public const string Parm_LegislationItem_ReHarm = "ReHarm";
        /// <summary>
        /// Parm ReOpinion
        /// </summary>
        public const string Parm_LegislationItem_ReOpinion = "ReOpinion";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LegislationItem_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LegislationItem_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LegislationItem_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LegislationItem_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LegislationItem_Version = "Version";
        /// <summary>
        /// Insert Query Of LegislationItem
        /// </summary>
        public const string Sql_LegislationItem_Insert = "insert into LegislationItem(CreateBy,CreateOn,CreatorId,EndCaseAbstract,EndExecute,EndLawsuit,EndOpinion,EndPunishments,HaCaseAbstract,HaOpinion,ItemName,ItemNo,LegislationId,Num,OrderNo,PunishMethod,ReCaseAbstract,Records,ReHarm,ReOpinion,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@EndCaseAbstract,@EndExecute,@EndLawsuit,@EndOpinion,@EndPunishments,@HaCaseAbstract,@HaOpinion,@ItemName,@ItemNo,@LegislationId,@Num,@OrderNo,@PunishMethod,@ReCaseAbstract,@Records,@ReHarm,@ReOpinion,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LegislationItem
        /// </summary>
        public const string Sql_LegislationItem_Update = "update LegislationItem set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndCaseAbstract=@EndCaseAbstract,EndExecute=@EndExecute,EndLawsuit=@EndLawsuit,EndOpinion=@EndOpinion,EndPunishments=@EndPunishments,HaCaseAbstract=@HaCaseAbstract,HaOpinion=@HaOpinion,ItemName=@ItemName,ItemNo=@ItemNo,LegislationId=@LegislationId,Num=@Num,OrderNo=@OrderNo,PunishMethod=@PunishMethod,ReCaseAbstract=@ReCaseAbstract,Records=@Records,ReHarm=@ReHarm,ReOpinion=@ReOpinion,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LegislationItem_Delete = "update LegislationItem set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _legislationId = string.Empty;
        /// <summary>
        /// 对应Legislation 主键
        /// </summary>
        public string LegislationId
        {
            get { return _legislationId ?? string.Empty; }
            set { _legislationId = value; }
        }
        private string _num = string.Empty;
        /// <summary>
        /// 序号
        /// </summary>
        public string Num
        {
            get { return _num ?? string.Empty; }
            set { _num = value; }
        }
        private string _itemNo = string.Empty;
        /// <summary>
        /// 案由编号
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _itemName = string.Empty;
        /// <summary>
        /// 适用案由
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? string.Empty; }
            set { _itemName = value; }
        }
        private string _reCaseAbstract = string.Empty;
        /// <summary>
        /// nvarchar 立案案情摘要
        /// </summary>
        public string ReCaseAbstract
        {
            get { return _reCaseAbstract ?? string.Empty; }
            set { _reCaseAbstract = value; }
        }
        private string _reOpinion = string.Empty;
        /// <summary>
        /// nvarchar 立案审批承办人意见
        /// </summary>
        public string ReOpinion
        {
            get { return _reOpinion ?? string.Empty; }
            set { _reOpinion = value; }
        }
        private string _reHarm = string.Empty;
        /// <summary>
        /// nvarchar 立案审批危害或损失情况
        /// </summary>
        public string ReHarm
        {
            get { return _reHarm ?? string.Empty; }
            set { _reHarm = value; }
        }
        private string _haCaseAbstract = string.Empty;
        /// <summary>
        /// nvarchar 处理审批案情摘要
        /// </summary>
        public string HaCaseAbstract
        {
            get { return _haCaseAbstract ?? string.Empty; }
            set { _haCaseAbstract = value; }
        }
        private string _haOpinion = string.Empty;
        /// <summary>
        /// nvarchar 处理审批承办人意见
        /// </summary>
        public string HaOpinion
        {
            get { return _haOpinion ?? string.Empty; }
            set { _haOpinion = value; }
        }
        private string _endCaseAbstract = string.Empty;
        /// <summary>
        /// nvarchar 结案审批案情摘要及调查经过
        /// </summary>
        public string EndCaseAbstract
        {
            get { return _endCaseAbstract ?? string.Empty; }
            set { _endCaseAbstract = value; }
        }
        private string _endPunishments = string.Empty;
        /// <summary>
        /// nvarchar 结案审批处理或处罚情况
        /// </summary>
        public string EndPunishments
        {
            get { return _endPunishments ?? string.Empty; }
            set { _endPunishments = value; }
        }
        private string _endExecute = string.Empty;
        /// <summary>
        /// nvarchar 结案审批执行情况
        /// </summary>
        public string EndExecute
        {
            get { return _endExecute ?? string.Empty; }
            set { _endExecute = value; }
        }
        private string _endLawsuit = string.Empty;
        /// <summary>
        /// nvarchar 结案审批复议和诉讼情况
        /// </summary>
        public string EndLawsuit
        {
            get { return _endLawsuit ?? string.Empty; }
            set { _endLawsuit = value; }
        }
        private string _endOpinion = string.Empty;
        /// <summary>
        /// nvarchar 结案审批承办人意见
        /// </summary>
        public string EndOpinion
        {
            get { return _endOpinion ?? string.Empty; }
            set { _endOpinion = value; }
        }
        private string _punishMethod = string.Empty;
        /// <summary>
        /// nvarchar 处罚方法
        /// </summary>
        public string PunishMethod
        {
            get { return _punishMethod ?? string.Empty; }
            set { _punishMethod = value; }
        }
        private string _records = string.Empty;
        /// <summary>
        /// nvarchar 笔录情况
        /// </summary>
        public string Records
        {
            get { return _records ?? string.Empty; }
            set { _records = value; }
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
        public override LegislationItemEntity SetModelValueByDataRow(DataRow dr)
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
        public override LegislationItemEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LegislationItemEntity();
            if (fields.Contains(Parm_LegislationItem_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LegislationItem_Id].ToString();
            if (fields.Contains(Parm_LegislationItem_LegislationId) || fields.Contains("*"))
                tmp.LegislationId = dr[Parm_LegislationItem_LegislationId].ToString();
            if (fields.Contains(Parm_LegislationItem_Num) || fields.Contains("*"))
                tmp.Num = dr[Parm_LegislationItem_Num].ToString();
            if (fields.Contains(Parm_LegislationItem_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_LegislationItem_ItemNo].ToString();
            if (fields.Contains(Parm_LegislationItem_ItemName) || fields.Contains("*"))
                tmp.ItemName = dr[Parm_LegislationItem_ItemName].ToString();
            if (fields.Contains(Parm_LegislationItem_ReCaseAbstract) || fields.Contains("*"))
                tmp.ReCaseAbstract = dr[Parm_LegislationItem_ReCaseAbstract].ToString();
            if (fields.Contains(Parm_LegislationItem_ReOpinion) || fields.Contains("*"))
                tmp.ReOpinion = dr[Parm_LegislationItem_ReOpinion].ToString();
            if (fields.Contains(Parm_LegislationItem_ReHarm) || fields.Contains("*"))
                tmp.ReHarm = dr[Parm_LegislationItem_ReHarm].ToString();
            if (fields.Contains(Parm_LegislationItem_HaCaseAbstract) || fields.Contains("*"))
                tmp.HaCaseAbstract = dr[Parm_LegislationItem_HaCaseAbstract].ToString();
            if (fields.Contains(Parm_LegislationItem_HaOpinion) || fields.Contains("*"))
                tmp.HaOpinion = dr[Parm_LegislationItem_HaOpinion].ToString();
            if (fields.Contains(Parm_LegislationItem_EndCaseAbstract) || fields.Contains("*"))
                tmp.EndCaseAbstract = dr[Parm_LegislationItem_EndCaseAbstract].ToString();
            if (fields.Contains(Parm_LegislationItem_EndPunishments) || fields.Contains("*"))
                tmp.EndPunishments = dr[Parm_LegislationItem_EndPunishments].ToString();
            if (fields.Contains(Parm_LegislationItem_EndExecute) || fields.Contains("*"))
                tmp.EndExecute = dr[Parm_LegislationItem_EndExecute].ToString();
            if (fields.Contains(Parm_LegislationItem_EndLawsuit) || fields.Contains("*"))
                tmp.EndLawsuit = dr[Parm_LegislationItem_EndLawsuit].ToString();
            if (fields.Contains(Parm_LegislationItem_EndOpinion) || fields.Contains("*"))
                tmp.EndOpinion = dr[Parm_LegislationItem_EndOpinion].ToString();
            if (fields.Contains(Parm_LegislationItem_PunishMethod) || fields.Contains("*"))
                tmp.PunishMethod = dr[Parm_LegislationItem_PunishMethod].ToString();
            if (fields.Contains(Parm_LegislationItem_Records) || fields.Contains("*"))
                tmp.Records = dr[Parm_LegislationItem_Records].ToString();
            if (fields.Contains(Parm_LegislationItem_OrderNo) || fields.Contains("*"))
                tmp.OrderNo = int.Parse(dr[Parm_LegislationItem_OrderNo].ToString());
            if (fields.Contains(Parm_LegislationItem_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LegislationItem_RowStatus].ToString());
            if (fields.Contains(Parm_LegislationItem_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LegislationItem_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LegislationItem_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LegislationItem_CreatorId].ToString();
            if (fields.Contains(Parm_LegislationItem_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LegislationItem_CreateBy].ToString();
            if (fields.Contains(Parm_LegislationItem_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LegislationItem_CreateOn].ToString());
            if (fields.Contains(Parm_LegislationItem_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LegislationItem_UpdateId].ToString();
            if (fields.Contains(Parm_LegislationItem_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LegislationItem_UpdateBy].ToString();
            if (fields.Contains(Parm_LegislationItem_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LegislationItem_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="legislationitem">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LegislationItemEntity legislationitem, SqlParameter[] parms)
        {
            parms[0].Value = legislationitem.LegislationId;
            parms[1].Value = legislationitem.Num;
            parms[2].Value = legislationitem.ItemNo;
            parms[3].Value = legislationitem.ItemName;
            parms[4].Value = legislationitem.ReCaseAbstract;
            parms[5].Value = legislationitem.ReOpinion;
            parms[6].Value = legislationitem.ReHarm;
            parms[7].Value = legislationitem.HaCaseAbstract;
            parms[8].Value = legislationitem.HaOpinion;
            parms[9].Value = legislationitem.EndCaseAbstract;
            parms[10].Value = legislationitem.EndPunishments;
            parms[11].Value = legislationitem.EndExecute;
            parms[12].Value = legislationitem.EndLawsuit;
            parms[13].Value = legislationitem.EndOpinion;
            parms[14].Value = legislationitem.PunishMethod;
            parms[15].Value = legislationitem.Records;
            parms[16].Value = legislationitem.OrderNo;
            parms[17].Value = legislationitem.RowStatus;
            parms[18].Value = legislationitem.CreatorId;
            parms[19].Value = legislationitem.CreateBy;
            parms[20].Value = legislationitem.CreateOn;
            parms[21].Value = legislationitem.UpdateId;
            parms[22].Value = legislationitem.UpdateBy;
            parms[23].Value = legislationitem.UpdateOn;
            parms[24].Value = legislationitem.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LegislationItemEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationItem_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LegislationItem_LegislationId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationItem_Num, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationItem_ItemNo, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_LegislationItem_ItemName, SqlDbType.VarChar, 300),
					new SqlParameter(Parm_LegislationItem_ReCaseAbstract, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_LegislationItem_ReOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_ReHarm, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_HaCaseAbstract, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_HaOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_EndCaseAbstract, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_EndPunishments, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_EndExecute, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_EndLawsuit, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_EndOpinion, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_PunishMethod, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_LegislationItem_Records, SqlDbType.VarChar, 4000),
					new SqlParameter(Parm_LegislationItem_OrderNo, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationItem_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LegislationItem_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationItem_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationItem_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LegislationItem_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationItem_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LegislationItem_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LegislationItem_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LegislationItem_Insert, parms);
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

