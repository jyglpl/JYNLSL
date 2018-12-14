//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ActivityEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/9/21 14:58:05
//  功能描述：Activity表实体
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
    /// 许可-活动
    /// </summary>
    [Serializable]
    public class ActivityEntity : ModelImp.BaseModel<ActivityEntity>
    {
        public ActivityEntity()
        {
            TB_Name = TB_Activity;
            Parm_Id = Parm_Activity_Id;
            Parm_Version = Parm_Activity_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Activity_Insert;
            Sql_Update = Sql_Activity_Update;
            Sql_Delete = Sql_Activity_Delete;
        }
        #region Const of table Activity
        /// <summary>
        /// Table Activity
        /// </summary>
        public const string TB_Activity = "Activity";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm ActivityName
        /// </summary>
        public const string Parm_Activity_ActivityName = "ActivityName";
        /// <summary>
        /// Parm ActivityNo
        /// </summary>
        public const string Parm_Activity_ActivityNo = "ActivityNo";
        /// <summary>
        /// Parm BatchNum
        /// </summary>
        public const string Parm_Activity_BatchNum = "BatchNum";
        /// <summary>
        /// Parm CompanyName
        /// </summary>
        public const string Parm_Activity_CompanyName = "CompanyName";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Activity_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Activity_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Activity_CreatorId = "CreatorId";
        /// <summary>
        /// Parm EndDate
        /// </summary>
        public const string Parm_Activity_EndDate = "EndDate";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Activity_Id = "Id";
        /// <summary>
        /// Parm INTERNAL_NO
        /// </summary>
        public const string Parm_Activity_INTERNAL_NO = "INTERNAL_NO";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Activity_RowStatus = "RowStatus";
        /// <summary>
        /// Parm StartDate
        /// </summary>
        public const string Parm_Activity_StartDate = "StartDate";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Activity_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Activity_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Activity_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm VenueAdress
        /// </summary>
        public const string Parm_Activity_VenueAdress = "VenueAdress";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Activity_Version = "Version";
        /// <summary>
        /// Insert Query Of Activity
        /// </summary>
        public const string Sql_Activity_Insert = "insert into Activity(ActivityName,ActivityNo,BatchNum,CompanyName,CreateBy,CreateOn,CreatorId,EndDate,INTERNAL_NO,RowStatus,StartDate,UpdateBy,UpdateId,UpdateOn,VenueAdress,Id) values(@ActivityName,@ActivityNo,@BatchNum,@CompanyName,@CreateBy,@CreateOn,@CreatorId,@EndDate,@INTERNAL_NO,@RowStatus,@StartDate,@UpdateBy,@UpdateId,@UpdateOn,@VenueAdress,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Activity
        /// </summary>
        public const string Sql_Activity_Update = "update Activity set ActivityName=@ActivityName,ActivityNo=@ActivityNo,BatchNum=@BatchNum,CompanyName=@CompanyName,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,EndDate=@EndDate,INTERNAL_NO=@INTERNAL_NO,RowStatus=@RowStatus,StartDate=@StartDate,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,VenueAdress=@VenueAdress where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Activity_Delete = "update Activity set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _activityNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ActivityNo
        {
            get { return _activityNo ?? string.Empty; }
            set { _activityNo = value; }
        }
        private string _iNTERNAL_NO = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string INTERNAL_NO
        {
            get { return _iNTERNAL_NO ?? string.Empty; }
            set { _iNTERNAL_NO = value; }
        }
        private string _companyName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            get { return _companyName ?? string.Empty; }
            set { _companyName = value; }
        }
        private string _venueAdress = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string VenueAdress
        {
            get { return _venueAdress ?? string.Empty; }
            set { _venueAdress = value; }
        }
        private string _activityName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ActivityName
        {
            get { return _activityName ?? string.Empty; }
            set { _activityName = value; }
        }
        private DateTime _startDate = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        private DateTime _endDate = MinDate;
        /// <summary>
        /// 
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
        public override ActivityEntity SetModelValueByDataRow(DataRow dr)
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
        public override ActivityEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ActivityEntity();
            if (fields.Contains(Parm_Activity_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Activity_Id].ToString();
            if (fields.Contains(Parm_Activity_BatchNum) || fields.Contains("*"))
                tmp.BatchNum = dr[Parm_Activity_BatchNum].ToString();
            if (fields.Contains(Parm_Activity_ActivityNo) || fields.Contains("*"))
                tmp.ActivityNo = dr[Parm_Activity_ActivityNo].ToString();
            if (fields.Contains(Parm_Activity_INTERNAL_NO) || fields.Contains("*"))
                tmp.INTERNAL_NO = dr[Parm_Activity_INTERNAL_NO].ToString();
            if (fields.Contains(Parm_Activity_CompanyName) || fields.Contains("*"))
                tmp.CompanyName = dr[Parm_Activity_CompanyName].ToString();
            if (fields.Contains(Parm_Activity_VenueAdress) || fields.Contains("*"))
                tmp.VenueAdress = dr[Parm_Activity_VenueAdress].ToString();
            if (fields.Contains(Parm_Activity_ActivityName) || fields.Contains("*"))
                tmp.ActivityName = dr[Parm_Activity_ActivityName].ToString();
            if (fields.Contains(Parm_Activity_StartDate) || fields.Contains("*"))
                tmp.StartDate = DateTime.Parse(dr[Parm_Activity_StartDate].ToString());
            if (fields.Contains(Parm_Activity_EndDate) || fields.Contains("*"))
                tmp.EndDate = DateTime.Parse(dr[Parm_Activity_EndDate].ToString());
            if (fields.Contains(Parm_Activity_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Activity_RowStatus].ToString());
            if (fields.Contains(Parm_Activity_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Activity_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Activity_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Activity_CreatorId].ToString();
            if (fields.Contains(Parm_Activity_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Activity_CreateBy].ToString();
            if (fields.Contains(Parm_Activity_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Activity_CreateOn].ToString());
            if (fields.Contains(Parm_Activity_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Activity_UpdateId].ToString();
            if (fields.Contains(Parm_Activity_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Activity_UpdateBy].ToString();
            if (fields.Contains(Parm_Activity_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Activity_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="activity">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ActivityEntity activity, SqlParameter[] parms)
        {
            parms[0].Value = activity.BatchNum;
            parms[1].Value = activity.ActivityNo;
            parms[2].Value = activity.INTERNAL_NO;
            parms[3].Value = activity.CompanyName;
            parms[4].Value = activity.VenueAdress;
            parms[5].Value = activity.ActivityName;
            parms[6].Value = activity.StartDate;
            parms[7].Value = activity.EndDate;
            parms[8].Value = activity.RowStatus;
            parms[9].Value = activity.CreatorId;
            parms[10].Value = activity.CreateBy;
            parms[11].Value = activity.CreateOn;
            parms[12].Value = activity.UpdateId;
            parms[13].Value = activity.UpdateBy;
            parms[14].Value = activity.UpdateOn;
            parms[15].Value = activity.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ActivityEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Activity_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Activity_BatchNum, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Activity_ActivityNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_INTERNAL_NO, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_CompanyName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_VenueAdress, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_ActivityName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_StartDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Activity_EndDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Activity_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Activity_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Activity_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Activity_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Activity_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Activity_Insert, parms);
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

