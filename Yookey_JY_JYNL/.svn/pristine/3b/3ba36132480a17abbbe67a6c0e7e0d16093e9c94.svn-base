//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicensePointPositionEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-13 17:14:02
//  功能描述：LicensePointPosition表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.License
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LicensePointPositionEntity : ModelImp.BaseModel<LicensePointPositionEntity>
    {
        public LicensePointPositionEntity()
        {
            TB_Name = TB_LicensePointPosition;
            Parm_Id = Parm_LicensePointPosition_Id;
            Parm_Version = Parm_LicensePointPosition_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicensePointPosition_Insert;
            Sql_Update = Sql_LicensePointPosition_Update;
            Sql_Delete = Sql_LicensePointPosition_Delete;
        }
        #region Const of table LicensePointPosition
        /// <summary>
        /// Table LicensePointPosition
        /// </summary>
        public const string TB_LicensePointPosition = "LicensePointPosition";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BaiduLat
        /// </summary>
        public const string Parm_LicensePointPosition_BaiduLat = "BaiduLat";
        /// <summary>
        /// Parm BaiduLng
        /// </summary>
        public const string Parm_LicensePointPosition_BaiduLng = "BaiduLng";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicensePointPosition_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicensePointPosition_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicensePointPosition_CreatorId = "CreatorId";
        /// <summary>
        /// Parm GPSLat
        /// </summary>
        public const string Parm_LicensePointPosition_GPSLat = "GPSLat";
        /// <summary>
        /// Parm GPSLng
        /// </summary>
        public const string Parm_LicensePointPosition_GPSLng = "GPSLng";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicensePointPosition_Id = "Id";
        /// <summary>
        /// Parm LicenseId
        /// </summary>
        public const string Parm_LicensePointPosition_LicenseId = "LicenseId";
        /// <summary>
        /// Parm PointType
        /// </summary>
        public const string Parm_LicensePointPosition_PointType = "PointType";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicensePointPosition_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicensePointPosition_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicensePointPosition_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicensePointPosition_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicensePointPosition_Version = "Version";
        /// <summary>
        /// Insert Query Of LicensePointPosition
        /// </summary>
        public const string Sql_LicensePointPosition_Insert = "insert into LicensePointPosition(BaiduLat,BaiduLng,CreateBy,CreateOn,CreatorId,GPSLat,GPSLng,LicenseId,PointType,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@BaiduLat,@BaiduLng,@CreateBy,@CreateOn,@CreatorId,@GPSLat,@GPSLng,@LicenseId,@PointType,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicensePointPosition
        /// </summary>
        public const string Sql_LicensePointPosition_Update = "update LicensePointPosition set BaiduLat=@BaiduLat,BaiduLng=@BaiduLng,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,GPSLat=@GPSLat,GPSLng=@GPSLng,LicenseId=@LicenseId,PointType=@PointType,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicensePointPosition_Delete = "update LicensePointPosition set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private decimal _gPSLat;
        /// <summary>
        /// GPS经度
        /// </summary>
        public decimal GPSLat
        {
            get { return _gPSLat; }
            set { _gPSLat = value; }
        }
        private decimal _gPSLng;
        /// <summary>
        /// GPS纬度
        /// </summary>
        public decimal GPSLng
        {
            get { return _gPSLng; }
            set { _gPSLng = value; }
        }
        private decimal _baiduLat;
        /// <summary>
        /// 百度经度
        /// </summary>
        public decimal BaiduLat
        {
            get { return _baiduLat; }
            set { _baiduLat = value; }
        }
        private decimal _baiduLng;
        /// <summary>
        /// 百度纬度
        /// </summary>
        public decimal BaiduLng
        {
            get { return _baiduLng; }
            set { _baiduLng = value; }
        }
        private string _licenseId = string.Empty;
        /// <summary>
        /// 许可ID
        /// </summary>
        public string LicenseId
        {
            get { return _licenseId ?? string.Empty; }
            set { _licenseId = value; }
        }
        private string _pointType = string.Empty;
        /// <summary>
        /// 打点类型(0070)
        /// </summary>
        public string PointType
        {
            get { return _pointType ?? string.Empty; }
            set { _pointType = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicensePointPositionEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicensePointPositionEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicensePointPositionEntity();
            if (fields.Contains(Parm_LicensePointPosition_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicensePointPosition_Id].ToString();
            if (fields.Contains(Parm_LicensePointPosition_GPSLat) || fields.Contains("*"))
                tmp.GPSLat = decimal.Parse(dr[Parm_LicensePointPosition_GPSLat].ToString());
            if (fields.Contains(Parm_LicensePointPosition_GPSLng) || fields.Contains("*"))
                tmp.GPSLng = decimal.Parse(dr[Parm_LicensePointPosition_GPSLng].ToString());
            if (fields.Contains(Parm_LicensePointPosition_BaiduLat) || fields.Contains("*"))
                tmp.BaiduLat = decimal.Parse(dr[Parm_LicensePointPosition_BaiduLat].ToString());
            if (fields.Contains(Parm_LicensePointPosition_BaiduLng) || fields.Contains("*"))
                tmp.BaiduLng = decimal.Parse(dr[Parm_LicensePointPosition_BaiduLng].ToString());
            if (fields.Contains(Parm_LicensePointPosition_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicensePointPosition_RowStatus].ToString());
            if (fields.Contains(Parm_LicensePointPosition_LicenseId) || fields.Contains("*"))
                tmp.LicenseId = dr[Parm_LicensePointPosition_LicenseId].ToString();
            if (fields.Contains(Parm_LicensePointPosition_PointType) || fields.Contains("*"))
                tmp.PointType = dr[Parm_LicensePointPosition_PointType].ToString();
            if (fields.Contains(Parm_LicensePointPosition_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicensePointPosition_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicensePointPosition_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicensePointPosition_CreatorId].ToString();
            if (fields.Contains(Parm_LicensePointPosition_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicensePointPosition_CreateBy].ToString();
            if (fields.Contains(Parm_LicensePointPosition_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicensePointPosition_CreateOn].ToString());
            if (fields.Contains(Parm_LicensePointPosition_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicensePointPosition_UpdateId].ToString();
            if (fields.Contains(Parm_LicensePointPosition_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicensePointPosition_UpdateBy].ToString();
            if (fields.Contains(Parm_LicensePointPosition_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicensePointPosition_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensepointposition">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicensePointPositionEntity licensepointposition, SqlParameter[] parms)
        {
            parms[0].Value = licensepointposition.GPSLat;
            parms[1].Value = licensepointposition.GPSLng;
            parms[2].Value = licensepointposition.BaiduLat;
            parms[3].Value = licensepointposition.BaiduLng;
            parms[4].Value = licensepointposition.RowStatus;
            parms[5].Value = licensepointposition.LicenseId;
            parms[6].Value = licensepointposition.PointType;
            parms[7].Value = licensepointposition.CreatorId;
            parms[8].Value = licensepointposition.CreateBy;
            parms[9].Value = licensepointposition.CreateOn;
            parms[10].Value = licensepointposition.UpdateId;
            parms[11].Value = licensepointposition.UpdateBy;
            parms[12].Value = licensepointposition.UpdateOn;
            parms[13].Value = licensepointposition.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicensePointPositionEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicensePointPosition_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicensePointPosition_GPSLat, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicensePointPosition_GPSLng, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicensePointPosition_BaiduLat, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicensePointPosition_BaiduLng, SqlDbType.Decimal, 10),
					new SqlParameter(Parm_LicensePointPosition_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicensePointPosition_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_PointType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicensePointPosition_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePointPosition_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicensePointPosition_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicensePointPosition_Insert, parms);
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

