//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainNumEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/5 15:14:47
//  功能描述：TempDetainNum表实体
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
    /// 
    /// </summary>
    [Serializable]
    public class TempDetainNumEntity : ModelImp.BaseModel<TempDetainNumEntity>
    {
        public TempDetainNumEntity()
        {
            TB_Name = TB_TempDetainNum;
            Parm_Id = Parm_TempDetainNum_Id;
            Parm_Version = Parm_TempDetainNum_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_TempDetainNum_Insert;
            Sql_Update = Sql_TempDetainNum_Update;
            Sql_Delete = Sql_TempDetainNum_Delete;
        }
        #region Const of table TempDetainNum
        /// <summary>
        /// Table TempDetainNum
        /// </summary>
        public const string TB_TempDetainNum = "TempDetainNum";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_TempDetainNum_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_TempDetainNum_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_TempDetainNum_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_TempDetainNum_Id = "Id";
        /// <summary>
        /// Parm Num
        /// </summary>
        public const string Parm_TempDetainNum_Num = "Num";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_TempDetainNum_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_TempDetainNum_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_TempDetainNum_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_TempDetainNum_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_TempDetainNum_Version = "Version";
        /// <summary>
        /// Insert Query Of TempDetainNum
        /// </summary>
        public const string Sql_TempDetainNum_Insert = "insert into TempDetainNum(CreateBy,CreateOn,CreatorId,Num,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@Num,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of TempDetainNum
        /// </summary>
        public const string Sql_TempDetainNum_Update = "update TempDetainNum set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Num=@Num,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_TempDetainNum_Delete = "update TempDetainNum set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        public override TempDetainNumEntity SetModelValueByDataRow(DataRow dr)
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
        public override TempDetainNumEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new TempDetainNumEntity();
            if (fields.Contains(Parm_TempDetainNum_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_TempDetainNum_Id].ToString();
            if (fields.Contains(Parm_TempDetainNum_Num) || fields.Contains("*"))
                tmp.Num = dr[Parm_TempDetainNum_Num].ToString();
            if (fields.Contains(Parm_TempDetainNum_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_TempDetainNum_RowStatus].ToString());
            if (fields.Contains(Parm_TempDetainNum_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_TempDetainNum_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_TempDetainNum_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_TempDetainNum_CreatorId].ToString();
            if (fields.Contains(Parm_TempDetainNum_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_TempDetainNum_CreateBy].ToString();
            if (fields.Contains(Parm_TempDetainNum_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_TempDetainNum_CreateOn].ToString());
            if (fields.Contains(Parm_TempDetainNum_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_TempDetainNum_UpdateId].ToString();
            if (fields.Contains(Parm_TempDetainNum_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_TempDetainNum_UpdateBy].ToString();
            if (fields.Contains(Parm_TempDetainNum_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_TempDetainNum_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="tempdetainnum">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(TempDetainNumEntity tempdetainnum, SqlParameter[] parms)
        {
            parms[0].Value = tempdetainnum.Num;
            parms[1].Value = tempdetainnum.RowStatus;
            parms[2].Value = tempdetainnum.CreatorId;
            parms[3].Value = tempdetainnum.CreateBy;
            parms[4].Value = tempdetainnum.CreateOn;
            parms[5].Value = tempdetainnum.UpdateId;
            parms[6].Value = tempdetainnum.UpdateBy;
            parms[7].Value = tempdetainnum.UpdateOn;
            parms[8].Value = tempdetainnum.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(TempDetainNumEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainNum_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_TempDetainNum_Num, SqlDbType.NVarChar, 20),
					new SqlParameter(Parm_TempDetainNum_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_TempDetainNum_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainNum_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainNum_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_TempDetainNum_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainNum_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_TempDetainNum_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_TempDetainNum_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_TempDetainNum_Insert, parms);
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

