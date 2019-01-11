//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="EmployeeWageEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/16 11:16:41
//  功能描述：EmployeeWage表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Hr
{
    /// <summary>
    /// 薪资
    /// </summary>
    [Serializable]
    public class EmployeeWageEntity : ModelImp.BaseModel<EmployeeWageEntity>
    {
        public EmployeeWageEntity()
        {
            TB_Name = TB_EmployeeWage;
            Parm_Id = Parm_EmployeeWage_Id;
            Parm_Version = Parm_EmployeeWage_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_EmployeeWage_Insert;
            Sql_Update = Sql_EmployeeWage_Update;
            Sql_Delete = Sql_EmployeeWage_Delete;
        }
        #region Const of table EmployeeWage
        /// <summary>
        /// Table EmployeeWage
        /// </summary>
        public const string TB_EmployeeWage = "EmployeeWage";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm AddressBT
        /// </summary>
        public const string Parm_EmployeeWage_AddressBT = "AddressBT";
        /// <summary>
        /// Parm BaseJT
        /// </summary>
        public const string Parm_EmployeeWage_BaseJT = "BaseJT";
        /// <summary>
        /// Parm BuckleUp
        /// </summary>
        public const string Parm_EmployeeWage_BuckleUp = "BuckleUp";
        /// <summary>
        /// Parm ColligateBT
        /// </summary>
        public const string Parm_EmployeeWage_ColligateBT = "ColligateBT";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_EmployeeWage_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_EmployeeWage_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_EmployeeWage_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DutyWage
        /// </summary>
        public const string Parm_EmployeeWage_DutyWage = "DutyWage";
        /// <summary>
        /// Parm HouseWage
        /// </summary>
        public const string Parm_EmployeeWage_HouseWage = "HouseWage";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_EmployeeWage_Id = "Id";
        /// <summary>
        /// Parm LevelWage
        /// </summary>
        public const string Parm_EmployeeWage_LevelWage = "LevelWage";
        /// <summary>
        /// Parm MedicalInsurance
        /// </summary>
        public const string Parm_EmployeeWage_MedicalInsurance = "MedicalInsurance";
        /// <summary>
        /// Parm EndowmentInsurance
        /// </summary>
        public const string Parm_EmployeeWage_EndowmentInsurance = "EndowmentInsurance";
        /// <summary>
        /// Parm MissEatToll
        /// </summary>
        public const string Parm_EmployeeWage_MissEatToll = "MissEatToll";
        /// <summary>
        /// Parm OvertimeToll
        /// </summary>
        public const string Parm_EmployeeWage_OvertimeToll = "OvertimeToll";
        /// <summary>
        /// Parm PersonTax
        /// </summary>
        public const string Parm_EmployeeWage_PersonTax = "PersonTax";
        /// <summary>
        /// Parm PostJT
        /// </summary>
        public const string Parm_EmployeeWage_PostJT = "PostJT";
        /// <summary>
        /// Parm ReissueWage
        /// </summary>
        public const string Parm_EmployeeWage_ReissueWage = "ReissueWage";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_EmployeeWage_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SendWageTime
        /// </summary>
        public const string Parm_EmployeeWage_SendWageTime = "SendWageTime";
        /// <summary>
        /// Parm SpecialJT
        /// </summary>
        public const string Parm_EmployeeWage_SpecialJT = "SpecialJT";
        /// <summary>
        /// Parm TelephoneBT
        /// </summary>
        public const string Parm_EmployeeWage_TelephoneBT = "TelephoneBT";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_EmployeeWage_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_EmployeeWage_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_EmployeeWage_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_EmployeeWage_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_EmployeeWage_Version = "Version";
        /// <summary>
        /// Parm WageTime
        /// </summary>
        public const string Parm_EmployeeWage_WageTime = "WageTime";
        /// <summary>
        /// Insert Query Of EmployeeWage
        /// </summary>
        public const string Sql_EmployeeWage_Insert = "insert into EmployeeWage(AddressBT,BaseJT,BuckleUp,ColligateBT,CreateBy,CreateOn,CreatorId,DutyWage,HouseWage,LevelWage,MedicalInsurance,EndowmentInsurance,MissEatToll,OvertimeToll,PersonTax,PostJT,ReissueWage,RowStatus,SendWageTime,SpecialJT,TelephoneBT,UpdateBy,UpdateId,UpdateOn,UserId,WageTime,Id) values(@AddressBT,@BaseJT,@BuckleUp,@ColligateBT,@CreateBy,@CreateOn,@CreatorId,@DutyWage,@HouseWage,@LevelWage,@MedicalInsurance,@EndowmentInsurance,@MissEatToll,@OvertimeToll,@PersonTax,@PostJT,@ReissueWage,@RowStatus,@SendWageTime,@SpecialJT,@TelephoneBT,@UpdateBy,@UpdateId,@UpdateOn,@UserId,@WageTime,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of EmployeeWage
        /// </summary>
        public const string Sql_EmployeeWage_Update = "update EmployeeWage set AddressBT=@AddressBT,BaseJT=@BaseJT,BuckleUp=@BuckleUp,ColligateBT=@ColligateBT,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DutyWage=@DutyWage,HouseWage=@HouseWage,LevelWage=@LevelWage,MedicalInsurance=@MedicalInsurance,EndowmentInsurance=@EndowmentInsurance,MissEatToll=@MissEatToll,OvertimeToll=@OvertimeToll,PersonTax=@PersonTax,PostJT=@PostJT,ReissueWage=@ReissueWage,RowStatus=@RowStatus,SendWageTime=@SendWageTime,SpecialJT=@SpecialJT,TelephoneBT=@TelephoneBT,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId,WageTime=@WageTime where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_EmployeeWage_Delete = "update EmployeeWage set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _userId = string.Empty;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        private Double _dutyWage;
        /// <summary>
        /// 职务工资
        /// </summary>
        public Double DutyWage
        {
            get { return _dutyWage; }
            set { _dutyWage = value; }
        }
        private Double _levelWage;
        /// <summary>
        /// 级别工资
        /// </summary>
        public Double LevelWage
        {
            get { return _levelWage; }
            set { _levelWage = value; }
        }
        private Double _colligateBT;
        /// <summary>
        /// 综合工资
        /// </summary>
        public Double ColligateBT
        {
            get { return _colligateBT; }
            set { _colligateBT = value; }
        }
        private Double _postJT;
        /// <summary>
        /// 岗位津贴
        /// </summary>
        public Double PostJT
        {
            get { return _postJT; }
            set { _postJT = value; }
        }
        private Double _baseJT;
        /// <summary>
        /// 基础津贴
        /// </summary>
        public Double BaseJT
        {
            get { return _baseJT; }
            set { _baseJT = value; }
        }
        private Double _addressBT;
        /// <summary>
        /// 地方补贴
        /// </summary>
        public Double AddressBT
        {
            get { return _addressBT; }
            set { _addressBT = value; }
        }
        private Double _specialJT;
        /// <summary>
        /// 特岗津贴
        /// </summary>
        public Double SpecialJT
        {
            get { return _specialJT; }
            set { _specialJT = value; }
        }
        private Double _telephoneBT;
        /// <summary>
        /// 联系费补贴
        /// </summary>
        public Double TelephoneBT
        {
            get { return _telephoneBT; }
            set { _telephoneBT = value; }
        }
        private Double _overtimeToll;
        /// <summary>
        /// 加班费
        /// </summary>
        public Double OvertimeToll
        {
            get { return _overtimeToll; }
            set { _overtimeToll = value; }
        }
        private Double _missEatToll;
        /// <summary>
        /// 误餐费
        /// </summary>
        public Double MissEatToll
        {
            get { return _missEatToll; }
            set { _missEatToll = value; }
        }
        private Double _reissueWage;
        /// <summary>
        /// 补发工资
        /// </summary>
        public Double ReissueWage
        {
            get { return _reissueWage; }
            set { _reissueWage = value; }
        }
        private Double _personTax;
        /// <summary>
        /// 个税
        /// </summary>
        public Double PersonTax
        {
            get { return _personTax; }
            set { _personTax = value; }
        }
        private Double _houseWage;
        /// <summary>
        /// 公积金
        /// </summary>
        public Double HouseWage
        {
            get { return _houseWage; }
            set { _houseWage = value; }
        }
        private Double _medicalInsurance;
        /// <summary>
        /// 医疗保险
        /// </summary>
        public Double MedicalInsurance
        {
            get { return _medicalInsurance; }
            set { _medicalInsurance = value; }
        }
        private Double _endowmentInsurance;
        /// <summary>
        /// 养老保险
        /// </summary>
        public Double EndowmentInsurance
        {
            get { return _endowmentInsurance; }
            set { _endowmentInsurance = value; }
        }

        private Double _buckleUp;
        /// <summary>
        /// 补扣
        /// </summary>
        public Double BuckleUp
        {
            get { return _buckleUp; }
            set { _buckleUp = value; }
        }
        private DateTime _wageTime = MinDate;
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime WageTime
        {
            get { return _wageTime; }
            set { _wageTime = value; }
        }
        private DateTime _sendWageTime = MinDate;
        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime SendWageTime
        {
            get { return _sendWageTime; }
            set { _sendWageTime = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override EmployeeWageEntity SetModelValueByDataRow(DataRow dr)
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
        public override EmployeeWageEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new EmployeeWageEntity();
            if (fields.Contains(Parm_EmployeeWage_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_EmployeeWage_Id].ToString();
            if (fields.Contains(Parm_EmployeeWage_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_EmployeeWage_UserId].ToString();
            if (fields.Contains(Parm_EmployeeWage_DutyWage) || fields.Contains("*"))
                tmp.DutyWage = Double.Parse(dr[Parm_EmployeeWage_DutyWage].ToString());
            if (fields.Contains(Parm_EmployeeWage_LevelWage) || fields.Contains("*"))
                tmp.LevelWage = Double.Parse(dr[Parm_EmployeeWage_LevelWage].ToString());
            if (fields.Contains(Parm_EmployeeWage_ColligateBT) || fields.Contains("*"))
                tmp.ColligateBT = Double.Parse(dr[Parm_EmployeeWage_ColligateBT].ToString());
            if (fields.Contains(Parm_EmployeeWage_PostJT) || fields.Contains("*"))
                tmp.PostJT = Double.Parse(dr[Parm_EmployeeWage_PostJT].ToString());
            if (fields.Contains(Parm_EmployeeWage_BaseJT) || fields.Contains("*"))
                tmp.BaseJT = Double.Parse(dr[Parm_EmployeeWage_BaseJT].ToString());
            if (fields.Contains(Parm_EmployeeWage_AddressBT) || fields.Contains("*"))
                tmp.AddressBT = Double.Parse(dr[Parm_EmployeeWage_AddressBT].ToString());
            if (fields.Contains(Parm_EmployeeWage_SpecialJT) || fields.Contains("*"))
                tmp.SpecialJT = Double.Parse(dr[Parm_EmployeeWage_SpecialJT].ToString());
            if (fields.Contains(Parm_EmployeeWage_TelephoneBT) || fields.Contains("*"))
                tmp.TelephoneBT = Double.Parse(dr[Parm_EmployeeWage_TelephoneBT].ToString());
            if (fields.Contains(Parm_EmployeeWage_OvertimeToll) || fields.Contains("*"))
                tmp.OvertimeToll = Double.Parse(dr[Parm_EmployeeWage_OvertimeToll].ToString());
            if (fields.Contains(Parm_EmployeeWage_MissEatToll) || fields.Contains("*"))
                tmp.MissEatToll = Double.Parse(dr[Parm_EmployeeWage_MissEatToll].ToString());
            if (fields.Contains(Parm_EmployeeWage_ReissueWage) || fields.Contains("*"))
                tmp.ReissueWage = Double.Parse(dr[Parm_EmployeeWage_ReissueWage].ToString());
            if (fields.Contains(Parm_EmployeeWage_PersonTax) || fields.Contains("*"))
                tmp.PersonTax = Double.Parse(dr[Parm_EmployeeWage_PersonTax].ToString());
            if (fields.Contains(Parm_EmployeeWage_HouseWage) || fields.Contains("*"))
                tmp.HouseWage = Double.Parse(dr[Parm_EmployeeWage_HouseWage].ToString());
            if (fields.Contains(Parm_EmployeeWage_MedicalInsurance) || fields.Contains("*"))
                tmp.MedicalInsurance = Double.Parse(dr[Parm_EmployeeWage_MedicalInsurance].ToString());
            if (fields.Contains(Parm_EmployeeWage_EndowmentInsurance) || fields.Contains("*"))
                tmp.EndowmentInsurance = Double.Parse(dr[Parm_EmployeeWage_EndowmentInsurance].ToString());
            if (fields.Contains(Parm_EmployeeWage_BuckleUp) || fields.Contains("*"))
                tmp.BuckleUp = Double.Parse(dr[Parm_EmployeeWage_BuckleUp].ToString());
            if (fields.Contains(Parm_EmployeeWage_WageTime) || fields.Contains("*"))
                tmp.WageTime = DateTime.Parse(dr[Parm_EmployeeWage_WageTime].ToString());
            if (fields.Contains(Parm_EmployeeWage_SendWageTime) || fields.Contains("*"))
                tmp.SendWageTime = DateTime.Parse(dr[Parm_EmployeeWage_SendWageTime].ToString());
            if (fields.Contains(Parm_EmployeeWage_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_EmployeeWage_RowStatus].ToString());
            if (fields.Contains(Parm_EmployeeWage_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_EmployeeWage_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_EmployeeWage_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_EmployeeWage_CreatorId].ToString();
            if (fields.Contains(Parm_EmployeeWage_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_EmployeeWage_CreateBy].ToString();
            if (fields.Contains(Parm_EmployeeWage_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_EmployeeWage_CreateOn].ToString());
            if (fields.Contains(Parm_EmployeeWage_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_EmployeeWage_UpdateId].ToString();
            if (fields.Contains(Parm_EmployeeWage_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_EmployeeWage_UpdateBy].ToString();
            if (fields.Contains(Parm_EmployeeWage_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_EmployeeWage_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="employeewage">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(EmployeeWageEntity employeewage, SqlParameter[] parms)
        {
            parms[0].Value = employeewage.UserId;
            parms[1].Value = employeewage.DutyWage;
            parms[2].Value = employeewage.LevelWage;
            parms[3].Value = employeewage.ColligateBT;
            parms[4].Value = employeewage.PostJT;
            parms[5].Value = employeewage.BaseJT;
            parms[6].Value = employeewage.AddressBT;
            parms[7].Value = employeewage.SpecialJT;
            parms[8].Value = employeewage.TelephoneBT;
            parms[9].Value = employeewage.OvertimeToll;
            parms[10].Value = employeewage.MissEatToll;
            parms[11].Value = employeewage.ReissueWage;
            parms[12].Value = employeewage.PersonTax;
            parms[13].Value = employeewage.HouseWage;
            parms[14].Value = employeewage.MedicalInsurance;
            parms[15].Value = employeewage.EndowmentInsurance;
            parms[16].Value = employeewage.BuckleUp;
            parms[17].Value = employeewage.WageTime;
            parms[18].Value = employeewage.SendWageTime;
            parms[19].Value = employeewage.RowStatus;
            parms[20].Value = employeewage.CreatorId;
            parms[21].Value = employeewage.CreateBy;
            parms[22].Value = employeewage.CreateOn;
            parms[23].Value = employeewage.UpdateId;
            parms[24].Value = employeewage.UpdateBy;
            parms[25].Value = employeewage.UpdateOn;
            parms[26].Value = employeewage.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(EmployeeWageEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_EmployeeWage_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_EmployeeWage_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_EmployeeWage_DutyWage, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_LevelWage, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_ColligateBT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_PostJT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_BaseJT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_AddressBT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_SpecialJT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_TelephoneBT, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_OvertimeToll, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_MissEatToll, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_ReissueWage, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_PersonTax, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_HouseWage, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_MedicalInsurance, SqlDbType.Float, 53),
                    new SqlParameter(Parm_EmployeeWage_EndowmentInsurance, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_BuckleUp, SqlDbType.Float, 53),
					new SqlParameter(Parm_EmployeeWage_WageTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_EmployeeWage_SendWageTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_EmployeeWage_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_EmployeeWage_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_EmployeeWage_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_EmployeeWage_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_EmployeeWage_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_EmployeeWage_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_EmployeeWage_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_EmployeeWage_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_EmployeeWage_Insert, parms);
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
    /// 工资实体详细
    /// </summary>
    [Serializable]
    public class EmployeeWageDetailEntity
    {
        public EmployeeWageDetailEntity()
        {
          
        }
        /// <summary>
        /// 主键
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public object UserName { get; set; }
        /// <summary>
        /// 职务工资
        /// </summary>
        public object DutyWage { get; set; }

        /// <summary>
        /// 级别工资
        /// </summary>
        public object LevelWage { get; set; }

        /// <summary>
        /// 综合工资
        /// </summary>
        public object ColligateBT { get; set; }

        /// <summary>
        /// 岗位津贴
        /// </summary>
        public object PostJT { get; set; }

        /// <summary>
        /// 基础津贴
        /// </summary>
        public object BaseJT { get; set; }

        /// <summary>
        /// 地方补贴
        /// </summary>
        public object AddressBT { get; set; }

        /// <summary>
        /// 特岗津贴
        /// </summary>
        public object SpecialJT { get; set; }

        /// <summary>
        /// 临时性补贴
        /// </summary>
        public object TelephoneBT { get; set; }

        /// <summary>
        /// 加班费
        /// </summary>
        public object OvertimeToll { get; set; }

        /// <summary>
        /// 误餐费
        /// </summary>
        public object MissEatToll { get; set; }

        /// <summary>
        /// 补发工资
        /// </summary>
        public object ReissueWage { get; set; }

        /// <summary>
        /// 个税
        /// </summary>
        public object PersonTax { get; set; }

        /// <summary>
        /// 公积金
        /// </summary>
        public object HouseWage { get; set; }

        /// <summary>
        /// 医疗保险
        /// </summary>
        public object MedicalInsurance { get; set; }

        /// <summary>
        /// 养老保险
        /// </summary>
        public object EndowmentInsurance { get; set; }

        /// <summary>
        /// 补扣
        /// </summary>
        public object BuckleUp { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public object SmallTotal { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public object LittleTotal { get; set; }

        /// <summary>
        /// 实际得到的工资
        /// </summary>
        public object ZTotal { get; set; }

        /// <summary>
        /// 合计
        /// </summary>
        public object Total { get; set; }

    }

    /// <summary>
    /// Excel列名
    /// </summary>
    [Serializable]
    public class WageExcelColumName
    {
        private string _colName=string.Empty;

        public string ColUserName { get { return "姓名"; }  }
        public string ColDutyWage { get {  return "职务工资"; }  }
        public string ColLevelWage { get {  return "级别工资"; }  }
        public string ColColligateBT { get {  return "综合工资"; }  }
        public string ColPostJT { get { return "岗位津贴"; } }
        public string ColBaseJT { get {  return "基础津贴"; }  }
        public string ColAddressBT { get {  return "地方补贴"; }  }
        public string ColSmallTotal { get {  return "小计"; }  }
        public string ColSpecialJT { get {  return "特岗津贴"; }  }
        public string ColTelephoneBT { get { return "临时性补贴"; } }
        public string ColOvertimeToll { get {  return "加班费"; }  }
        public string ColMissEatToll { get { return "误餐费"; }  }
        public string ColReissueWage { get { return "补发工资"; }  }
        public string ColTotal { get {  return "合计"; }  }
        public string ColPersonTax { get {  return "个税"; }  }
        public string ColHouseWage { get {  return "公积金"; } }
        public string ColMedicalInsurance { get {  return "医疗保险"; } }
        public string ColEndowmentInsurance { get { return "养老保险"; } }
        public string ColBuckleUp { get {  return "补扣"; }}
        public string ColLittleTotal { get {  return "小计"; } }
        public string ColZTotal { get { return "实得工资"; } }

        #region
        /// <summary>
        /// 获取表列中文名称
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        public string GetName(string colName)
        {
            switch (colName)
            {
                case "UserName":
                    return ColUserName;
                case "DutyWage":
                    return ColDutyWage;
                case "LevelWage":
                    return ColLevelWage;
                case "ColligateBT":
                    return ColColligateBT;
                case "PostJT":
                    return ColPostJT;
                case "BaseJT":
                    return ColBaseJT;
                case "AddressBT":
                    return ColAddressBT;
                case "SmallTotal":
                    return ColSmallTotal;
                case "SpecialJT":
                    return ColSpecialJT;
                case "TelephoneBT":
                    return ColTelephoneBT;
                case "OvertimeToll":
                    return ColOvertimeToll;
                case "MissEatToll":
                    return ColMissEatToll;
                case "ReissueWage":
                    return ColReissueWage;
                case "Total":
                    return ColTotal;
                case "PersonTax":
                    return ColPersonTax;
                case "HouseWage":
                    return ColHouseWage;
                case "MedicalInsurance":
                    return ColMedicalInsurance;
                case "EndowmentInsurance":
                    return ColEndowmentInsurance;
                case "BuckleUp":
                    return ColBuckleUp;
                case "LittleTotal":
                    return ColLittleTotal;
                case "ZTotal":
                    return ColZTotal;                  
            }
            return null;
        }
        #endregion

        /// <summary>
        /// 获取表列英文名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetColName(string name)
        {
            switch (name)
            {
                case "姓名":
                    return "UserName";
                case "职务工资":
                    return "DutyWage";
                case "级别工资":
                    return "LevelWage";
                case "综合补贴":
                    return "ColligateBT";
                case "岗位津贴":
                    return "PostJT";
                case "基础津贴":
                    return "BaseJT";
                case "地方补贴":
                    return "AddressBT";
                case "小计":
                    return "SmallTotal";
                case "特岗津贴":
                    return "SpecialJT";
                case "临时性补贴":
                    return "TelephoneBT";
                case "加班费":
                    return "OvertimeToll";
                case "误餐费":
                    return "MissEatToll";
                case "补发工资":
                    return "ReissueWage";
                case "合计":
                    return "Total";
                case "个税":
                    return "PersonTax";
                case "公积金":
                    return "HouseWage";
                case "医疗保险":
                    return "MedicalInsurance";
                case "养老保险":
                    return "EndowmentInsurance";
                case "补扣":
                    return "BuckleUp";
            }
            return null;
        }
    }
}

