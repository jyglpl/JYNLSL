//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AdvertisingEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/9/21 14:58:06
//  功能描述：Advertising表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Consent
{
    /// <summary>
    /// 许可-广告
    /// </summary>
    [Serializable]
    public class AdvertisingEntity : ModelImp.BaseModel<AdvertisingEntity>
    {
        public AdvertisingEntity()
        {
            TB_Name = TB_Advertising;
            Parm_Id = Parm_Advertising_Id;
            Parm_Version = Parm_Advertising_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Advertising_Insert;
            Sql_Update = Sql_Advertising_Update;
            Sql_Delete = Sql_Advertising_Delete;
        }

        #region Const of table Advertising
        /// <summary>
        /// Table Advertising
        /// </summary>
        private const string TB_Advertising = "Advertising";
        private const string Parm_All = "*";
        /// <summary>
        /// Parm Address
        /// </summary>
        private const string Parm_Advertising_Address = "Address";
        /// <summary>
        /// Parm AdvertisContents
        /// </summary>
        private const string Parm_Advertising_AdvertisContents = "AdvertisContents";
        /// <summary>
        /// Parm AdvertisNo
        /// </summary>
        private const string Parm_Advertising_AdvertisNo = "AdvertisNo";
        /// <summary>
        /// Parm BatchNum
        /// </summary>
        private const string Parm_Advertising_BatchNum = "BatchNum";
        /// <summary>
        /// Parm CategoryQuantity
        /// </summary>
        private const string Parm_Advertising_CategoryQuantity = "CategoryQuantity";

        /// <summary>
        /// Parm OwnerCompanyId
        /// </summary>
        private const string Parm_Advertising_OwnerCompanyId = "OwnerCompanyId";

        /// <summary>
        /// Parm OwnerCompanyId
        /// </summary>
        private const string Parm_Advertising_OwnerCompanyName = "OwnerCompanyName";

        /// <summary>
        /// Parm CompanyName
        /// </summary>
        private const string Parm_Advertising_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        private const string Parm_Advertising_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        private const string Parm_Advertising_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        private const string Parm_Advertising_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        private const string Parm_Advertising_EndDate = "EndDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        private const string Parm_Advertising_Id = "Id";
        /// <summary>
        /// Parm INTERNAL_NO
        /// </summary>
        private const string Parm_Advertising_INTERNAL_NO = "INTERNAL_NO";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        private const string Parm_Advertising_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        private const string Parm_Advertising_StartDate = "StartDate";
        /// <summary>
        /// Parm TypeNo
        /// </summary>
        private const string Parm_Advertising_TypeNo = "TypeNo";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        private const string Parm_Advertising_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        private const string Parm_Advertising_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        private const string Parm_Advertising_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        private const string Parm_Advertising_Version = "Version";
        /// <summary>
        /// Insert Query Of Advertising
        /// </summary>
        private const string Sql_Advertising_Insert = "insert into Advertising(Address,AdvertisContents,AdvertisNo,BatchNum,CategoryQuantity,OwnerCompanyId,OwnerCompanyName,CompanyName,CreateBy,CreateOn,CreatorId,EndDate,INTERNAL_NO,RowStatus,StartDate,TypeNo,UpdateBy,UpdateId,UpdateOn,Id) values(@Address,@AdvertisContents,@AdvertisNo,@BatchNum,@CategoryQuantity,@OwnerCompanyId,@OwnerCompanyName,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@EndDate,@INTERNAL_NO,@RowStatus,@StartDate,@TypeNo,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Advertising
        /// </summary>
        private const string Sql_Advertising_Update = "update Advertising set Address=@Address,AdvertisContents=@AdvertisContents,AdvertisNo=@AdvertisNo,BatchNum=@BatchNum,CategoryQuantity=@CategoryQuantity,OwnerCompanyId=@OwnerCompanyId,OwnerCompanyName=@OwnerCompanyName,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndDate=@EndDate,INTERNAL_NO=@INTERNAL_NO,RowStatus=@RowStatus,StartDate=@StartDate,TypeNo=@TypeNo,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        private const string Sql_Advertising_Delete = "update Advertising set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _batchNum = string.Empty;
        /// <summary>
        /// 档案编号
        /// </summary>
        public string BatchNum
        {
            get { return _batchNum ?? string.Empty; }
            set { _batchNum = value; }
        }
        private string _advertisNo = string.Empty;
        /// <summary>
        /// 许可证编号
        /// </summary>
        public string AdvertisNo
        {
            get { return _advertisNo ?? string.Empty; }
            set { _advertisNo = value; }
        }
        private string _iNTERNAL_NO = string.Empty;
        /// <summary>
        /// 内部编号
        /// </summary>
        public string INTERNAL_NO
        {
            get { return _iNTERNAL_NO ?? string.Empty; }
            set { _iNTERNAL_NO = value; }
        }
        private string _typeNo = string.Empty;
        /// <summary>
        /// 类别
        /// </summary>
        public string TypeNo
        {
            get { return _typeNo ?? string.Empty; }
            set { _typeNo = value; }
        }
        /// <summary>
        /// 所属单位ID
        /// </summary>
        public string OwnerCompanyId { get; set; }

        /// <summary>
        /// 所属单位名称
        /// </summary>
        public string OwnerCompanyName { get; set; }

        private string _companyName = string.Empty;
        /// <summary>
        /// 申请单位名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyName ?? string.Empty; }
            set { _companyName = value; }
        }
        private string _address = string.Empty;
        /// <summary>
        /// 设置地址
        /// </summary>
        public string Address
        {
            get { return _address ?? string.Empty; }
            set { _address = value; }
        }
        private string _advertisContents = string.Empty;
        /// <summary>
        /// 广告内容
        /// </summary>
        public string AdvertisContents
        {
            get { return _advertisContents ?? string.Empty; }
            set { _advertisContents = value; }
        }
        private string _categoryQuantity = string.Empty;
        /// <summary>
        /// 广告类别和数量
        /// </summary>
        public string CategoryQuantity
        {
            get { return _categoryQuantity ?? string.Empty; }
            set { _categoryQuantity = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 设置时间 开始
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private DateTime _endDate = MinDate;
        /// <summary>
        /// 设置时间 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /// <summary>
        /// 附件信息
        /// </summary>
        public string Attachment { get; set; }

        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override AdvertisingEntity SetModelValueByDataRow(DataRow dr)
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
        public override AdvertisingEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new AdvertisingEntity();
            if (dr.Table.Columns.Contains(Parm_Advertising_Id))
                tmp.Id = dr[Parm_Advertising_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_BatchNum))
                tmp.BatchNum = dr[Parm_Advertising_BatchNum].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_AdvertisNo))
                tmp.AdvertisNo = dr[Parm_Advertising_AdvertisNo].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_INTERNAL_NO))
                tmp.INTERNAL_NO = dr[Parm_Advertising_INTERNAL_NO].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_TypeNo))
                tmp.TypeNo = dr[Parm_Advertising_TypeNo].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_OwnerCompanyId))
                tmp.OwnerCompanyId = dr[Parm_Advertising_OwnerCompanyId].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_OwnerCompanyName))
                tmp.OwnerCompanyName = dr[Parm_Advertising_OwnerCompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_CompanyName))
                tmp.CompanyName = dr[Parm_Advertising_CompanyName].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_Address))
                tmp.Address = dr[Parm_Advertising_Address].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_AdvertisContents))
                tmp.AdvertisContents = dr[Parm_Advertising_AdvertisContents].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_CategoryQuantity))
                tmp.CategoryQuantity = dr[Parm_Advertising_CategoryQuantity].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_StartDate))
                tmp.StartDate = DateTime.Parse(dr[Parm_Advertising_StartDate].ToString());
            if (dr.Table.Columns.Contains(Parm_Advertising_EndDate))
                tmp.EndDate = DateTime.Parse(dr[Parm_Advertising_EndDate].ToString());
            if (dr.Table.Columns.Contains(Parm_Advertising_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_Advertising_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_Advertising_Version))
            {
                var bts = (byte[])(dr[Parm_Advertising_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_Advertising_CreatorId))
                tmp.CreatorId = dr[Parm_Advertising_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_CreateBy))
                tmp.CreateBy = dr[Parm_Advertising_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Advertising_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_Advertising_UpdateId))
                tmp.UpdateId = dr[Parm_Advertising_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_UpdateBy))
                tmp.UpdateBy = dr[Parm_Advertising_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_Advertising_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Advertising_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="advertising">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(AdvertisingEntity advertising, SqlParameter[] parms)
        {
            parms[0].Value = advertising.BatchNum;
            parms[1].Value = advertising.AdvertisNo;
            parms[2].Value = advertising.INTERNAL_NO;
            parms[3].Value = advertising.TypeNo;
            parms[4].Value = advertising.OwnerCompanyId;
            parms[5].Value = advertising.OwnerCompanyName;
            parms[6].Value = advertising.CompanyName;
            parms[7].Value = advertising.Address;
            parms[8].Value = advertising.AdvertisContents;
            parms[9].Value = advertising.CategoryQuantity;
            parms[10].Value = advertising.StartDate;
            parms[11].Value = advertising.EndDate;
            parms[12].Value = advertising.RowStatus;
            parms[13].Value = advertising.CreatorId;
            parms[14].Value = advertising.CreateBy;
            parms[15].Value = advertising.CreateOn;
            parms[16].Value = advertising.UpdateId;
            parms[17].Value = advertising.UpdateBy;
            parms[18].Value = advertising.UpdateOn;
            parms[19].Value = advertising.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(AdvertisingEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Advertising_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Advertising_BatchNum, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Advertising_AdvertisNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_INTERNAL_NO, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_TypeNo, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_Advertising_OwnerCompanyId, SqlDbType.NVarChar, 50),
                    new SqlParameter(Parm_Advertising_OwnerCompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_Address, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_AdvertisContents, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_CategoryQuantity, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Advertising_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Advertising_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Advertising_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Advertising_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Advertising_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Advertising_Id, SqlDbType.NVarChar, 50),
                    

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Advertising_Insert, parms);
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


