//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="OldMonthReportTotalEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2017/5/31 13:55:16
//  功能描述：OldMonthReportTotal表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Education
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OldMonthReportTotalEntity : ModelImp.BaseModel<OldMonthReportTotalEntity>
    {
       	public OldMonthReportTotalEntity()
		{
			TB_Name = TB_OldMonthReportTotal;
			Parm_Id = Parm_OldMonthReportTotal_Id;
			Parm_Version = Parm_OldMonthReportTotal_Version;
			Parm_All_Base = Parm_All;
			Sql_Insert = Sql_OldMonthReportTotal_Insert;
			Sql_Update = Sql_OldMonthReportTotal_Update;
			Sql_Delete = Sql_OldMonthReportTotal_Delete;
		}
       	#region Const of table OldMonthReportTotal
		/// <summary>
		/// Table OldMonthReportTotal
		/// </summary>
		public const string TB_OldMonthReportTotal = "OldMonthReportTotal";
		public const string Parm_All = "*";
		/// <summary>
		/// Parm Case_00090001
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090001 = "Case_00090001";
		/// <summary>
		/// Parm Case_00090001_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090001_Money = "Case_00090001_Money";
		/// <summary>
		/// Parm Case_00090002
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090002 = "Case_00090002";
		/// <summary>
		/// Parm Case_00090002_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090002_Money = "Case_00090002_Money";
		/// <summary>
		/// Parm Case_00090003
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090003 = "Case_00090003";
		/// <summary>
		/// Parm Case_00090003_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090003_Money = "Case_00090003_Money";
		/// <summary>
		/// Parm Case_00090004
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090004 = "Case_00090004";
		/// <summary>
		/// Parm Case_00090004_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090004_Money = "Case_00090004_Money";
		/// <summary>
		/// Parm Case_00090005
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090005 = "Case_00090005";
		/// <summary>
		/// Parm Case_00090005_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090005_Money = "Case_00090005_Money";
		/// <summary>
		/// Parm Case_00090006
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090006 = "Case_00090006";
		/// <summary>
		/// Parm Case_00090006_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090006_Money = "Case_00090006_Money";
		/// <summary>
		/// Parm Case_00090007
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090007 = "Case_00090007";
		/// <summary>
		/// Parm Case_00090007_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090007_Money = "Case_00090007_Money";
		/// <summary>
		/// Parm Case_00090008
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090008 = "Case_00090008";
		/// <summary>
		/// Parm Case_00090008_Money
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_00090008_Money = "Case_00090008_Money";
		/// <summary>
		/// Parm Case_Punish
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_Punish = "Case_Punish";
		/// <summary>
		/// Parm Case_PunishMoney
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_PunishMoney = "Case_PunishMoney";
		/// <summary>
		/// Parm Case_Simple
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_Simple = "Case_Simple";
		/// <summary>
		/// Parm Case_SimpleMoney
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_SimpleMoney = "Case_SimpleMoney";
		/// <summary>
		/// Parm Case_TotalCount
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_TotalCount = "Case_TotalCount";
		/// <summary>
		/// Parm Case_TotalMoney
		/// </summary>
		public const string Parm_OldMonthReportTotal_Case_TotalMoney = "Case_TotalMoney";
		/// <summary>
		/// Parm CreateBy
		/// </summary>
		public const string Parm_OldMonthReportTotal_CreateBy = "CreateBy";
		/// <summary>
		/// Parm CreateOn
		/// </summary>
		public const string Parm_OldMonthReportTotal_CreateOn = "CreateOn";
		/// <summary>
		/// Parm CreatorId
		/// </summary>
		public const string Parm_OldMonthReportTotal_CreatorId = "CreatorId";
		/// <summary>
		/// Parm Ed_00090001
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090001 = "Ed_00090001";
		/// <summary>
		/// Parm Ed_00090002
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090002 = "Ed_00090002";
		/// <summary>
		/// Parm Ed_00090003
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090003 = "Ed_00090003";
		/// <summary>
		/// Parm Ed_00090004
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090004 = "Ed_00090004";
		/// <summary>
		/// Parm Ed_00090005
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090005 = "Ed_00090005";
		/// <summary>
		/// Parm Ed_00090006
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090006 = "Ed_00090006";
		/// <summary>
		/// Parm Ed_00090007
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090007 = "Ed_00090007";
		/// <summary>
		/// Parm Ed_00090008
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_00090008 = "Ed_00090008";
		/// <summary>
		/// Parm Ed_TotalCount
		/// </summary>
		public const string Parm_OldMonthReportTotal_Ed_TotalCount = "Ed_TotalCount";
		/// <summary>
		/// Parm Id
		/// </summary>
		public const string Parm_OldMonthReportTotal_Id = "Id";
		/// <summary>
		/// Parm ReportDate
		/// </summary>
		public const string Parm_OldMonthReportTotal_ReportDate = "ReportDate";
		/// <summary>
		/// Parm RowStatus
		/// </summary>
		public const string Parm_OldMonthReportTotal_RowStatus = "RowStatus";
		/// <summary>
		/// Parm UpdateBy
		/// </summary>
		public const string Parm_OldMonthReportTotal_UpdateBy = "UpdateBy";
		/// <summary>
		/// Parm UpdateId
		/// </summary>
		public const string Parm_OldMonthReportTotal_UpdateId = "UpdateId";
		/// <summary>
		/// Parm UpdateOn
		/// </summary>
		public const string Parm_OldMonthReportTotal_UpdateOn = "UpdateOn";
		/// <summary>
		/// Parm Version
		/// </summary>
		public const string Parm_OldMonthReportTotal_Version = "Version";
		/// <summary>
		/// Insert Query Of OldMonthReportTotal
		/// </summary>
		public const string Sql_OldMonthReportTotal_Insert = "insert into OldMonthReportTotal(Case_00090001,Case_00090001_Money,Case_00090002,Case_00090002_Money,Case_00090003,Case_00090003_Money,Case_00090004,Case_00090004_Money,Case_00090005,Case_00090005_Money,Case_00090006,Case_00090006_Money,Case_00090007,Case_00090007_Money,Case_00090008,Case_00090008_Money,Case_Punish,Case_PunishMoney,Case_Simple,Case_SimpleMoney,Case_TotalCount,Case_TotalMoney,CreateBy,CreateOn,CreatorId,Ed_00090001,Ed_00090002,Ed_00090003,Ed_00090004,Ed_00090005,Ed_00090006,Ed_00090007,Ed_00090008,Ed_TotalCount,ReportDate,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@Case_00090001,@Case_00090001_Money,@Case_00090002,@Case_00090002_Money,@Case_00090003,@Case_00090003_Money,@Case_00090004,@Case_00090004_Money,@Case_00090005,@Case_00090005_Money,@Case_00090006,@Case_00090006_Money,@Case_00090007,@Case_00090007_Money,@Case_00090008,@Case_00090008_Money,@Case_Punish,@Case_PunishMoney,@Case_Simple,@Case_SimpleMoney,@Case_TotalCount,@Case_TotalMoney,@CreateBy,@CreateOn,@CreatorId,@Ed_00090001,@Ed_00090002,@Ed_00090003,@Ed_00090004,@Ed_00090005,@Ed_00090006,@Ed_00090007,@Ed_00090008,@Ed_TotalCount,@ReportDate,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
		/// <summary>
		/// Update Query Of OldMonthReportTotal
		/// </summary>
		public const string Sql_OldMonthReportTotal_Update = "update OldMonthReportTotal set Case_00090001=@Case_00090001,Case_00090001_Money=@Case_00090001_Money,Case_00090002=@Case_00090002,Case_00090002_Money=@Case_00090002_Money,Case_00090003=@Case_00090003,Case_00090003_Money=@Case_00090003_Money,Case_00090004=@Case_00090004,Case_00090004_Money=@Case_00090004_Money,Case_00090005=@Case_00090005,Case_00090005_Money=@Case_00090005_Money,Case_00090006=@Case_00090006,Case_00090006_Money=@Case_00090006_Money,Case_00090007=@Case_00090007,Case_00090007_Money=@Case_00090007_Money,Case_00090008=@Case_00090008,Case_00090008_Money=@Case_00090008_Money,Case_Punish=@Case_Punish,Case_PunishMoney=@Case_PunishMoney,Case_Simple=@Case_Simple,Case_SimpleMoney=@Case_SimpleMoney,Case_TotalCount=@Case_TotalCount,Case_TotalMoney=@Case_TotalMoney,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Ed_00090001=@Ed_00090001,Ed_00090002=@Ed_00090002,Ed_00090003=@Ed_00090003,Ed_00090004=@Ed_00090004,Ed_00090005=@Ed_00090005,Ed_00090006=@Ed_00090006,Ed_00090007=@Ed_00090007,Ed_00090008=@Ed_00090008,Ed_TotalCount=@Ed_TotalCount,ReportDate=@ReportDate,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
		/// <summary>
		/// Set RowStatus=0
		/// </summary>
		public const string Sql_OldMonthReportTotal_Delete = "update OldMonthReportTotal set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
		#endregion

       	#region Properties
		private DateTime _reportDate = MinDate;
		/// <summary>
		/// 
		/// </summary>
		public DateTime ReportDate
		{
			get{return _reportDate;}
			set{_reportDate = value;}
		}
		private int _ed_00090001;
		/// <summary>
		/// 教育纠处-市容
		/// </summary>
		public int Ed_00090001
		{
			get{return _ed_00090001;}
			set{_ed_00090001 = value;}
		}
		private int _ed_00090002;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090002
		{
			get{return _ed_00090002;}
			set{_ed_00090002 = value;}
		}
		private int _ed_00090003;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090003
		{
			get{return _ed_00090003;}
			set{_ed_00090003 = value;}
		}
		private int _ed_00090004;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090004
		{
			get{return _ed_00090004;}
			set{_ed_00090004 = value;}
		}
		private int _ed_00090005;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090005
		{
			get{return _ed_00090005;}
			set{_ed_00090005 = value;}
		}
		private int _ed_00090006;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090006
		{
			get{return _ed_00090006;}
			set{_ed_00090006 = value;}
		}
		private int _ed_00090007;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090007
		{
			get{return _ed_00090007;}
			set{_ed_00090007 = value;}
		}
		private int _ed_00090008;
		/// <summary>
		/// 
		/// </summary>
		public int Ed_00090008
		{
			get{return _ed_00090008;}
			set{_ed_00090008 = value;}
		}
		private int _ed_TotalCount;
		/// <summary>
		/// 教育纠处-小计
		/// </summary>
		public int Ed_TotalCount
		{
			get{return _ed_TotalCount;}
			set{_ed_TotalCount = value;}
		}
		private int _case_00090001;
		/// <summary>
		/// 违章查处-市容
		/// </summary>
		public int Case_00090001
		{
			get{return _case_00090001;}
			set{_case_00090001 = value;}
		}
		private int _case_00090002;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090002
		{
			get{return _case_00090002;}
			set{_case_00090002 = value;}
		}
		private int _case_00090003;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090003
		{
			get{return _case_00090003;}
			set{_case_00090003 = value;}
		}
		private int _case_00090004;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090004
		{
			get{return _case_00090004;}
			set{_case_00090004 = value;}
		}
		private int _case_00090005;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090005
		{
			get{return _case_00090005;}
			set{_case_00090005 = value;}
		}
		private int _case_00090006;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090006
		{
			get{return _case_00090006;}
			set{_case_00090006 = value;}
		}
		private int _case_00090007;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090007
		{
			get{return _case_00090007;}
			set{_case_00090007 = value;}
		}
		private int _case_00090008;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090008
		{
			get{return _case_00090008;}
			set{_case_00090008 = value;}
		}
		private int _case_TotalCount;
		/// <summary>
		/// 违章查处-小计
		/// </summary>
		public int Case_TotalCount
		{
			get{return _case_TotalCount;}
			set{_case_TotalCount = value;}
		}
		private int _case_00090001_Money;
		/// <summary>
		/// 结案罚款金额-市容
		/// </summary>
		public int Case_00090001_Money
		{
			get{return _case_00090001_Money;}
			set{_case_00090001_Money = value;}
		}
		private int _case_00090002_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090002_Money
		{
			get{return _case_00090002_Money;}
			set{_case_00090002_Money = value;}
		}
		private int _case_00090003_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090003_Money
		{
			get{return _case_00090003_Money;}
			set{_case_00090003_Money = value;}
		}
		private int _case_00090004_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090004_Money
		{
			get{return _case_00090004_Money;}
			set{_case_00090004_Money = value;}
		}
		private int _case_00090005_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090005_Money
		{
			get{return _case_00090005_Money;}
			set{_case_00090005_Money = value;}
		}
		private int _case_00090006_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090006_Money
		{
			get{return _case_00090006_Money;}
			set{_case_00090006_Money = value;}
		}
		private int _case_00090007_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090007_Money
		{
			get{return _case_00090007_Money;}
			set{_case_00090007_Money = value;}
		}
		private int _case_00090008_Money;
		/// <summary>
		/// 
		/// </summary>
		public int Case_00090008_Money
		{
			get{return _case_00090008_Money;}
			set{_case_00090008_Money = value;}
		}
		private int _case_TotalMoney;
		/// <summary>
		/// 结案-总金额
		/// </summary>
		public int Case_TotalMoney
		{
			get{return _case_TotalMoney;}
			set{_case_TotalMoney = value;}
		}
		private int _case_Punish;
		/// <summary>
		/// 结案一般起数
		/// </summary>
		public int Case_Punish
		{
			get{return _case_Punish;}
			set{_case_Punish = value;}
		}
		private int _case_PunishMoney;
		/// <summary>
		/// 结案一般金额
		/// </summary>
		public int Case_PunishMoney
		{
			get{return _case_PunishMoney;}
			set{_case_PunishMoney = value;}
		}
		private int _case_Simple;
		/// <summary>
		/// 结案简易数
		/// </summary>
		public int Case_Simple
		{
			get{return _case_Simple;}
			set{_case_Simple = value;}
		}
		private int _case_SimpleMoney;
		/// <summary>
		/// 结案简易金额
		/// </summary>
		public int Case_SimpleMoney
		{
			get{return _case_SimpleMoney;}
			set{_case_SimpleMoney = value;}
		}
		#endregion
	
		/// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
		public override OldMonthReportTotalEntity SetModelValueByDataRow(DataRow dr)
      	{
            IList<string> fields = new List<string> {"*"};
   	    	return SetModelValueByDataRow(dr,fields);
        }

		/// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
		public override OldMonthReportTotalEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new OldMonthReportTotalEntity();
          			if (fields.Contains(Parm_OldMonthReportTotal_Id) || fields.Contains("*"))
				tmp.Id = dr[Parm_OldMonthReportTotal_Id].ToString();
			if (fields.Contains(Parm_OldMonthReportTotal_ReportDate) || fields.Contains("*"))
				tmp.ReportDate = DateTime.Parse(dr[Parm_OldMonthReportTotal_ReportDate].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090001) || fields.Contains("*"))
				tmp.Ed_00090001 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090001].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090002) || fields.Contains("*"))
				tmp.Ed_00090002 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090002].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090003) || fields.Contains("*"))
				tmp.Ed_00090003 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090003].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090004) || fields.Contains("*"))
				tmp.Ed_00090004 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090004].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090005) || fields.Contains("*"))
				tmp.Ed_00090005 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090005].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090006) || fields.Contains("*"))
				tmp.Ed_00090006 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090006].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090007) || fields.Contains("*"))
				tmp.Ed_00090007 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090007].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_00090008) || fields.Contains("*"))
				tmp.Ed_00090008 = int.Parse(dr[Parm_OldMonthReportTotal_Ed_00090008].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Ed_TotalCount) || fields.Contains("*"))
				tmp.Ed_TotalCount = int.Parse(dr[Parm_OldMonthReportTotal_Ed_TotalCount].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090001) || fields.Contains("*"))
				tmp.Case_00090001 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090001].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090002) || fields.Contains("*"))
				tmp.Case_00090002 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090002].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090003) || fields.Contains("*"))
				tmp.Case_00090003 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090003].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090004) || fields.Contains("*"))
				tmp.Case_00090004 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090004].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090005) || fields.Contains("*"))
				tmp.Case_00090005 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090005].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090006) || fields.Contains("*"))
				tmp.Case_00090006 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090006].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090007) || fields.Contains("*"))
				tmp.Case_00090007 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090007].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090008) || fields.Contains("*"))
				tmp.Case_00090008 = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090008].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_TotalCount) || fields.Contains("*"))
				tmp.Case_TotalCount = int.Parse(dr[Parm_OldMonthReportTotal_Case_TotalCount].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090001_Money) || fields.Contains("*"))
				tmp.Case_00090001_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090001_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090002_Money) || fields.Contains("*"))
				tmp.Case_00090002_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090002_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090003_Money) || fields.Contains("*"))
				tmp.Case_00090003_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090003_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090004_Money) || fields.Contains("*"))
				tmp.Case_00090004_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090004_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090005_Money) || fields.Contains("*"))
				tmp.Case_00090005_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090005_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090006_Money) || fields.Contains("*"))
				tmp.Case_00090006_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090006_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090007_Money) || fields.Contains("*"))
				tmp.Case_00090007_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090007_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_00090008_Money) || fields.Contains("*"))
				tmp.Case_00090008_Money = int.Parse(dr[Parm_OldMonthReportTotal_Case_00090008_Money].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_TotalMoney) || fields.Contains("*"))
				tmp.Case_TotalMoney = int.Parse(dr[Parm_OldMonthReportTotal_Case_TotalMoney].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_Punish) || fields.Contains("*"))
				tmp.Case_Punish = int.Parse(dr[Parm_OldMonthReportTotal_Case_Punish].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_PunishMoney) || fields.Contains("*"))
				tmp.Case_PunishMoney = int.Parse(dr[Parm_OldMonthReportTotal_Case_PunishMoney].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_Simple) || fields.Contains("*"))
				tmp.Case_Simple = int.Parse(dr[Parm_OldMonthReportTotal_Case_Simple].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Case_SimpleMoney) || fields.Contains("*"))
				tmp.Case_SimpleMoney = int.Parse(dr[Parm_OldMonthReportTotal_Case_SimpleMoney].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_RowStatus) || fields.Contains("*"))
				tmp.RowStatus = int.Parse(dr[Parm_OldMonthReportTotal_RowStatus].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_Version) || fields.Contains("*"))
			{
				var bts = (byte[])(dr[Parm_OldMonthReportTotal_Version]);
				Array.Reverse(bts);
				tmp.Version = BitConverter.ToInt64(bts, 0);
			}
			if (fields.Contains(Parm_OldMonthReportTotal_CreatorId) || fields.Contains("*"))
				tmp.CreatorId = dr[Parm_OldMonthReportTotal_CreatorId].ToString();
			if (fields.Contains(Parm_OldMonthReportTotal_CreateBy) || fields.Contains("*"))
				tmp.CreateBy = dr[Parm_OldMonthReportTotal_CreateBy].ToString();
			if (fields.Contains(Parm_OldMonthReportTotal_CreateOn) || fields.Contains("*"))
				tmp.CreateOn = DateTime.Parse(dr[Parm_OldMonthReportTotal_CreateOn].ToString());
			if (fields.Contains(Parm_OldMonthReportTotal_UpdateId) || fields.Contains("*"))
				tmp.UpdateId = dr[Parm_OldMonthReportTotal_UpdateId].ToString();
			if (fields.Contains(Parm_OldMonthReportTotal_UpdateBy) || fields.Contains("*"))
				tmp.UpdateBy = dr[Parm_OldMonthReportTotal_UpdateBy].ToString();
			if (fields.Contains(Parm_OldMonthReportTotal_UpdateOn) || fields.Contains("*"))
				tmp.UpdateOn = DateTime.Parse(dr[Parm_OldMonthReportTotal_UpdateOn].ToString());

	       return tmp;
        }

		/// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="oldmonthreporttotal">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForAdd(OldMonthReportTotalEntity oldmonthreporttotal, SqlParameter[] parms)
		{
            				parms[0].Value = oldmonthreporttotal.ReportDate;
				parms[1].Value = oldmonthreporttotal.Ed_00090001;
				parms[2].Value = oldmonthreporttotal.Ed_00090002;
				parms[3].Value = oldmonthreporttotal.Ed_00090003;
				parms[4].Value = oldmonthreporttotal.Ed_00090004;
				parms[5].Value = oldmonthreporttotal.Ed_00090005;
				parms[6].Value = oldmonthreporttotal.Ed_00090006;
				parms[7].Value = oldmonthreporttotal.Ed_00090007;
				parms[8].Value = oldmonthreporttotal.Ed_00090008;
				parms[9].Value = oldmonthreporttotal.Ed_TotalCount;
				parms[10].Value = oldmonthreporttotal.Case_00090001;
				parms[11].Value = oldmonthreporttotal.Case_00090002;
				parms[12].Value = oldmonthreporttotal.Case_00090003;
				parms[13].Value = oldmonthreporttotal.Case_00090004;
				parms[14].Value = oldmonthreporttotal.Case_00090005;
				parms[15].Value = oldmonthreporttotal.Case_00090006;
				parms[16].Value = oldmonthreporttotal.Case_00090007;
				parms[17].Value = oldmonthreporttotal.Case_00090008;
				parms[18].Value = oldmonthreporttotal.Case_TotalCount;
				parms[19].Value = oldmonthreporttotal.Case_00090001_Money;
				parms[20].Value = oldmonthreporttotal.Case_00090002_Money;
				parms[21].Value = oldmonthreporttotal.Case_00090003_Money;
				parms[22].Value = oldmonthreporttotal.Case_00090004_Money;
				parms[23].Value = oldmonthreporttotal.Case_00090005_Money;
				parms[24].Value = oldmonthreporttotal.Case_00090006_Money;
				parms[25].Value = oldmonthreporttotal.Case_00090007_Money;
				parms[26].Value = oldmonthreporttotal.Case_00090008_Money;
				parms[27].Value = oldmonthreporttotal.Case_TotalMoney;
				parms[28].Value = oldmonthreporttotal.Case_Punish;
				parms[29].Value = oldmonthreporttotal.Case_PunishMoney;
				parms[30].Value = oldmonthreporttotal.Case_Simple;
				parms[31].Value = oldmonthreporttotal.Case_SimpleMoney;
				parms[32].Value = oldmonthreporttotal.RowStatus;
				parms[33].Value = oldmonthreporttotal.CreatorId;
				parms[34].Value = oldmonthreporttotal.CreateBy;
				parms[35].Value = oldmonthreporttotal.CreateOn;
				parms[36].Value = oldmonthreporttotal.UpdateId;
				parms[37].Value = oldmonthreporttotal.UpdateBy;
				parms[38].Value = oldmonthreporttotal.UpdateOn;
                parms[39].Value = oldmonthreporttotal.Id;
             return parms;
        }

		/// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
		public override SqlParameter[] SetParmsValueByModelForUpdate(OldMonthReportTotalEntity model, SqlParameter[] parms)
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
				var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_OldMonthReportTotal_Insert);
				if (parms == null)
				{
					parms = new []{
	                 								new SqlParameter(Parm_OldMonthReportTotal_ReportDate, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090001, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090002, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090003, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090004, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090005, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090006, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090007, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_00090008, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Ed_TotalCount, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090001, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090002, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090003, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090004, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090005, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090006, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090007, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090008, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_TotalCount, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090001_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090002_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090003_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090004_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090005_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090006_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090007_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_00090008_Money, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_TotalMoney, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_Punish, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_PunishMoney, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_Simple, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_Case_SimpleMoney, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_OldMonthReportTotal_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_OldMonthReportTotal_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_OldMonthReportTotal_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_OldMonthReportTotal_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_OldMonthReportTotal_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_OldMonthReportTotal_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_OldMonthReportTotal_Id,SqlDbType.NVarChar, 50)

				};
					SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_OldMonthReportTotal_Insert, parms);
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
