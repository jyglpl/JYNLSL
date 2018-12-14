//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_SIMPLE_NUMBEREntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/13 10:53:50
//  功能描述：INF_SIMPLE_NUMBER表实体
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
    /// 简易案件处罚决定书编号
    /// </summary>
    [Serializable]
    public class InfSimpleNumberEntity : ModelImp.BaseModel<InfSimpleNumberEntity>
    {
        public InfSimpleNumberEntity()
        {
            TB_Name = TB_INF_SIMPLE_NUMBER;
            Parm_Id = Parm_INF_SIMPLE_NUMBER_Id;
            Parm_Version = Parm_INF_SIMPLE_NUMBER_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_INF_SIMPLE_NUMBER_Insert;
            Sql_Update = Sql_INF_SIMPLE_NUMBER_Update;
            Sql_Delete = Sql_INF_SIMPLE_NUMBER_Delete;
        }
        #region Const of table INF_SIMPLE_NUMBER
        /// <summary>
        /// Table INF_SIMPLE_NUMBER
        /// </summary>
        public const string TB_INF_SIMPLE_NUMBER = "INF_SIMPLE_NUMBER";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_Id = "Id";
        /// <summary>
        /// Parm Num
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_Num = "Num";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_INF_SIMPLE_NUMBER_Version = "Version";
        /// <summary>
        /// Insert Query Of INF_SIMPLE_NUMBER
        /// </summary>
        public const string Sql_INF_SIMPLE_NUMBER_Insert = "insert into INF_SIMPLE_NUMBER(CreateBy,CreateOn,CreatorId,Num,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@Num,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of INF_SIMPLE_NUMBER
        /// </summary>
        public const string Sql_INF_SIMPLE_NUMBER_Update = "update INF_SIMPLE_NUMBER set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Num=@Num,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_INF_SIMPLE_NUMBER_Delete = "update INF_SIMPLE_NUMBER set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _num = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Num
        {
            get { return _num ?? string.Empty; }
            set { _num = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override InfSimpleNumberEntity SetModelValueByDataRow(DataRow dr)
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
        public override InfSimpleNumberEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new InfSimpleNumberEntity();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_INF_SIMPLE_NUMBER_Id].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_Num) || fields.Contains("*"))
                tmp.Num = dr[Parm_INF_SIMPLE_NUMBER_Num].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_INF_SIMPLE_NUMBER_RowStatus].ToString());
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_INF_SIMPLE_NUMBER_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_INF_SIMPLE_NUMBER_CreatorId].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_INF_SIMPLE_NUMBER_CreateBy].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_INF_SIMPLE_NUMBER_CreateOn].ToString());
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_INF_SIMPLE_NUMBER_UpdateId].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_INF_SIMPLE_NUMBER_UpdateBy].ToString();
            if (fields.Contains(Parm_INF_SIMPLE_NUMBER_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_INF_SIMPLE_NUMBER_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="inf_simple_number">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(InfSimpleNumberEntity inf_simple_number, SqlParameter[] parms)
        {
            parms[0].Value = inf_simple_number.Num;
            parms[1].Value = inf_simple_number.RowStatus;
            parms[2].Value = inf_simple_number.CreatorId;
            parms[3].Value = inf_simple_number.CreateBy;
            parms[4].Value = inf_simple_number.CreateOn;
            parms[5].Value = inf_simple_number.UpdateId;
            parms[6].Value = inf_simple_number.UpdateBy;
            parms[7].Value = inf_simple_number.UpdateOn;
            parms[8].Value = inf_simple_number.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(InfSimpleNumberEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_SIMPLE_NUMBER_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_INF_SIMPLE_NUMBER_Num, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_INF_SIMPLE_NUMBER_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_INF_SIMPLE_NUMBER_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_INF_SIMPLE_NUMBER_Insert, parms);
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

