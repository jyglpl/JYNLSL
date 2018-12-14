//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="PunishmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2017/11/30 13:27:36
//  功能描述：Punishment表实体
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
    /// 执法公示数据
    /// </summary>
    [Serializable]
    public class PunishmentEntity : ModelImp.BaseModel<PunishmentEntity>
    {
        public PunishmentEntity()
        {
            TB_Name = TB_Punishment;
            Parm_Id = Parm_Punishment_Id;
            Parm_Version = Parm_Punishment_Version;
            Parm_All_Base = Parm_All;
            //Sql_Insert = Sql_Punishment_Insert;
            //Sql_Update = Sql_Punishment_Update;
            //Sql_Delete = Sql_Punishment_Delete;
        }
        #region Const of table Punishment
        /// <summary>
        /// Table Punishment
        /// </summary>
        public const string TB_Punishment = "Punishment";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BZ
        /// </summary>
        public const string Parm_Punishment_BZ = "BZ";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Punishment_Id = "Id";
        /// <summary>
        /// Parm CASEINFOID
        /// </summary>
        public const string Parm_Punishment_CASEINFOID = "CASEINFOID";
        /// <summary>
        /// Parm CASEINFONO
        /// </summary>
        public const string Parm_Punishment_CASEINFONO = "CASEINFONO";
        /// <summary>
        /// Parm CF_AJMC
        /// </summary>
        public const string Parm_Punishment_CF_AJMC = "CF_AJMC";
        /// <summary>
        /// Parm CF_BM
        /// </summary>
        public const string Parm_Punishment_CF_BM = "CF_BM";
        /// <summary>
        /// Parm CF_CFLB1
        /// </summary>
        public const string Parm_Punishment_CF_CFLB1 = "CF_CFLB1";
        /// <summary>
        /// Parm CF_CFLB2
        /// </summary>
        public const string Parm_Punishment_CF_CFLB2 = "CF_CFLB2";
        /// <summary>
        /// Parm CF_FR
        /// </summary>
        public const string Parm_Punishment_CF_FR = "CF_FR";
        /// <summary>
        /// Parm CF_GSJZQ
        /// </summary>
        public const string Parm_Punishment_CF_GSJZQ = "CF_GSJZQ";
        /// <summary>
        /// Parm CF_JDRQ
        /// </summary>
        public const string Parm_Punishment_CF_JDRQ = "CF_JDRQ";
        /// <summary>
        /// Parm CF_JG
        /// </summary>
        public const string Parm_Punishment_CF_JG = "CF_JG";
        /// <summary>
        /// Parm CF_SXYZCD
        /// </summary>
        public const string Parm_Punishment_CF_SXYZCD = "CF_SXYZCD";
        /// <summary>
        /// Parm CF_SY
        /// </summary>
        public const string Parm_Punishment_CF_SY = "CF_SY";
        /// <summary>
        /// Parm CF_SYFW
        /// </summary>
        public const string Parm_Punishment_CF_SYFW = "CF_SYFW";
        /// <summary>
        /// Parm CF_WSH
        /// </summary>
        public const string Parm_Punishment_CF_WSH = "CF_WSH";
        /// <summary>
        /// Parm CF_XDR_GSDJ
        /// </summary>
        public const string Parm_Punishment_CF_XDR_GSDJ = "CF_XDR_GSDJ";
        /// <summary>
        /// Parm CF_XDR_MC
        /// </summary>
        public const string Parm_Punishment_CF_XDR_MC = "CF_XDR_MC";
        /// <summary>
        /// Parm CF_XDR_SFZ
        /// </summary>
        public const string Parm_Punishment_CF_XDR_SFZ = "CF_XDR_SFZ";
        /// <summary>
        /// Parm CF_XDR_SHXYM
        /// </summary>
        public const string Parm_Punishment_CF_XDR_SHXYM = "CF_XDR_SHXYM";
        /// <summary>
        /// Parm CF_XDR_SWDJ
        /// </summary>
        public const string Parm_Punishment_CF_XDR_SWDJ = "CF_XDR_SWDJ";
        /// <summary>
        /// Parm CF_XDR_ZDM
        /// </summary>
        public const string Parm_Punishment_CF_XDR_ZDM = "CF_XDR_ZDM";
        /// <summary>
        /// Parm CF_XZJG
        /// </summary>
        public const string Parm_Punishment_CF_XZJG = "CF_XZJG";
        /// <summary>
        /// Parm CF_YJ
        /// </summary>
        public const string Parm_Punishment_CF_YJ = "CF_YJ";
        /// <summary>
        /// Parm CF_ZT
        /// </summary>
        public const string Parm_Punishment_CF_ZT = "CF_ZT";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Punishment_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Punishment_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Punishment_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DFBM
        /// </summary>
        public const string Parm_Punishment_DFBM = "DFBM";
        /// <summary>
        /// Parm IsPush
        /// </summary>
        public const string Parm_Punishment_IsPush = "IsPush";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Punishment_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SJC
        /// </summary>
        public const string Parm_Punishment_SJC = "SJC";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Punishment_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Punishment_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Punishment_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Punishment_Version = "Version";
        /// <summary>
        /// Parm WhetherPublic
        /// </summary>
        public const string Parm_Punishment_WhetherPublic = "WhetherPublic";
        /// <summary>
        /// Parm CF_ZYSX
        /// </summary>
        public const string Parm_Punishment_CF_ZYSX = "CF_ZYSX";
        /// <summary>
        /// Parm INFORMATION_FURNISH_IS_NAME
        /// </summary>
        public const string Parm_Punishment_INFORMATION_FURNISH_IS_NAME = "INFORMATION_FURNISH_IS_NAME";
        /// <summary>
        /// Parm CF_JE
        /// </summary>
        public const string Parm_Punishment_CF_JE = "CF_JE";
        /// <summary>
        /// Parm CONFISCATE_MONEY
        /// </summary>
        public const string Parm_Punishment_CONFISCATE_MONEY = "CONFISCATE_MONEY";
        /// <summary>
        /// Parm CF_SXXWYXQ
        /// </summary>
        public const string Parm_Punishment_CF_SXXWYXQ = "CF_SXXWYXQ";
        /// <summary>
        /// Parm CardType
        /// </summary>
        public const string Parm_Punishment_CardType = "CardType";
        /// <summary>
        /// Parm FRCard
        /// </summary>
        public const string Parm_Punishment_FRCard = "FRCard";
        /// <summary>
        /// Parm CF_Date
        /// </summary>
        public const string Parm_Punishment_CF_Date = "CF_Date";
        /// <summary>
        /// Insert Query Of Punishment
        /// </summary>
        public const string Sql_Punishment_Insert = "insert into Punishment(BZ,CASEINFOID,CASEINFONO,CF_AJMC,CF_BM,CF_CFLB1,CF_CFLB2,CF_FR,CF_GSJZQ,CF_JDRQ,CF_JG,CF_SXYZCD,CF_SY,CF_SYFW,CF_WSH,CF_XDR_GSDJ,CF_XDR_MC,CF_XDR_SFZ,CF_XDR_SHXYM,CF_XDR_SWDJ,CF_XDR_ZDM,CF_XZJG,CF_YJ,CF_ZT,CreateBy,CreateOn,CreatorId,DFBM,IsPush,RowStatus,SJC,UpdateBy,UpdateId,UpdateOn,WhetherPublic,Id) values(@BZ,@CASEINFOID,@CASEINFONO,@CF_AJMC,@CF_BM,@CF_CFLB1,@CF_CFLB2,@CF_FR,@CF_GSJZQ,@CF_JDRQ,@CF_JG,@CF_SXYZCD,@CF_SY,@CF_SYFW,@CF_WSH,@CF_XDR_GSDJ,@CF_XDR_MC,@CF_XDR_SFZ,@CF_XDR_SHXYM,@CF_XDR_SWDJ,@CF_XDR_ZDM,@CF_XZJG,@CF_YJ,@CF_ZT,@CreateBy,@CreateOn,@CreatorId,@DFBM,@IsPush,@RowStatus,@SJC,@UpdateBy,@UpdateId,@UpdateOn,@WhetherPublic,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Punishment
        /// </summary>
        public const string Sql_Punishment_Update = "update Punishment set BZ=@BZ,CASEINFOID=@CASEINFOID,CASEINFONO=@CASEINFONO,CF_AJMC=@CF_AJMC,CF_BM=@CF_BM,CF_CFLB1=@CF_CFLB1,CF_CFLB2=@CF_CFLB2,CF_FR=@CF_FR,CF_GSJZQ=@CF_GSJZQ,CF_JDRQ=@CF_JDRQ,CF_JG=@CF_JG,CF_SXYZCD=@CF_SXYZCD,CF_SY=@CF_SY,CF_SYFW=@CF_SYFW,CF_WSH=@CF_WSH,CF_XDR_GSDJ=@CF_XDR_GSDJ,CF_XDR_MC=@CF_XDR_MC,CF_XDR_SFZ=@CF_XDR_SFZ,CF_XDR_SHXYM=@CF_XDR_SHXYM,CF_XDR_SWDJ=@CF_XDR_SWDJ,CF_XDR_ZDM=@CF_XDR_ZDM,CF_XZJG=@CF_XZJG,CF_YJ=@CF_YJ,CF_ZT=@CF_ZT,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DFBM=@DFBM,IsPush=@IsPush,RowStatus=@RowStatus,SJC=@SJC,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WhetherPublic=@WhetherPublic where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Punishment_Delete = "update Punishment set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _cASEINFOID = string.Empty;
        /// <summary>
        /// 案件主键ID
        /// </summary>
        public string CASEINFOID
        {
            get { return _cASEINFOID ?? string.Empty; }
            set { _cASEINFOID = value; }
        }
        private string _cASEINFONO = string.Empty;
        /// <summary>
        /// 案件编号
        /// </summary>
        public string CASEINFONO
        {
            get { return _cASEINFONO ?? string.Empty; }
            set { _cASEINFONO = value; }
        }
        private string _cF_WSH = string.Empty;
        /// <summary>
        /// 行政处罚决定书文号
        /// </summary>
        public string CF_WSH
        {
            get { return _cF_WSH ?? string.Empty; }
            set { _cF_WSH = value; }
        }
        private string _cF_AJMC = string.Empty;
        /// <summary>
        /// 案件名称
        /// </summary>
        public string CF_AJMC
        {
            get { return _cF_AJMC ?? string.Empty; }
            set { _cF_AJMC = value; }
        }
        private string _cF_BM = string.Empty;
        /// <summary>
        /// 行政处罚编码
        /// </summary>
        public string CF_BM
        {
            get { return _cF_BM ?? string.Empty; }
            set { _cF_BM = value; }
        }
        private string _cF_CFLB1 = string.Empty;
        /// <summary>
        /// 处罚类别1
        /// </summary>
        public string CF_CFLB1
        {
            get { return _cF_CFLB1 ?? string.Empty; }
            set { _cF_CFLB1 = value; }
        }
        private string _cF_CFLB2 = string.Empty;
        /// <summary>
        /// 处罚类别2
        /// </summary>
        public string CF_CFLB2
        {
            get { return _cF_CFLB2 ?? string.Empty; }
            set { _cF_CFLB2 = value; }
        }
        private string _cF_SY = string.Empty;
        /// <summary>
        /// 处罚事由
        /// </summary>
        public string CF_SY
        {
            get { return _cF_SY ?? string.Empty; }
            set { _cF_SY = value; }
        }
        private string _cF_YJ = string.Empty;
        /// <summary>
        /// 处罚依据
        /// </summary>
        public string CF_YJ
        {
            get { return _cF_YJ ?? string.Empty; }
            set { _cF_YJ = value; }
        }
        private string _cF_XDR_MC = string.Empty;
        /// <summary>
        /// 行政相对人名称
        /// </summary>
        public string CF_XDR_MC
        {
            get { return _cF_XDR_MC ?? string.Empty; }
            set { _cF_XDR_MC = value; }
        }
        private string _cF_XDR_SHXYM = string.Empty;
        /// <summary>
        /// 行政相对人代码_1 (统一社会信用代码)
        /// </summary>
        public string CF_XDR_SHXYM
        {
            get { return _cF_XDR_SHXYM ?? string.Empty; }
            set { _cF_XDR_SHXYM = value; }
        }
        private string _cF_XDR_ZDM = string.Empty;
        /// <summary>
        /// 行政相对人代码_2 (组织机构代码)
        /// </summary>
        public string CF_XDR_ZDM
        {
            get { return _cF_XDR_ZDM ?? string.Empty; }
            set { _cF_XDR_ZDM = value; }
        }
        private string _cF_XDR_GSDJ = string.Empty;
        /// <summary>
        /// CF_XDR_GSDJ
        /// </summary>
        public string CF_XDR_GSDJ
        {
            get { return _cF_XDR_GSDJ ?? string.Empty; }
            set { _cF_XDR_GSDJ = value; }
        }
        private string _cF_XDR_SWDJ = string.Empty;
        /// <summary>
        /// 行政相对人代码_4 (税务登记号)
        /// </summary>
        public string CF_XDR_SWDJ
        {
            get { return _cF_XDR_SWDJ ?? string.Empty; }
            set { _cF_XDR_SWDJ = value; }
        }
        private string _cF_XDR_SFZ = string.Empty;
        /// <summary>
        /// 行政相对人代码_5 (居民身份证号)
        /// </summary>
        public string CF_XDR_SFZ
        {
            get { return _cF_XDR_SFZ ?? string.Empty; }
            set { _cF_XDR_SFZ = value; }
        }
        private string _cF_FR = string.Empty;
        /// <summary>
        /// 法定代表人姓名
        /// </summary>
        public string CF_FR
        {
            get { return _cF_FR ?? string.Empty; }
            set { _cF_FR = value; }
        }
        private string _cF_JG = string.Empty;
        /// <summary>
        /// 处罚结果
        /// </summary>
        public string CF_JG
        {
            get { return _cF_JG ?? string.Empty; }
            set { _cF_JG = value; }
        }
        private DateTime _cF_JDRQ = MinDate;
        /// <summary>
        /// 处罚决定日期 格式为:YYYY/MM/DD
        /// </summary>
        public DateTime CF_JDRQ
        {
            get { return _cF_JDRQ; }
            set { _cF_JDRQ = value; }
        }
        private string _cF_XZJG = string.Empty;
        /// <summary>
        /// 处罚机关
        /// </summary>
        public string CF_XZJG
        {
            get { return _cF_XZJG ?? string.Empty; }
            set { _cF_XZJG = value; }
        }
        private string _cF_ZT = string.Empty;
        /// <summary>
        /// 当前状态 0=正常（或空白）；1=撤销；2=异议；3=其他（备注说明）
        /// </summary>
        public string CF_ZT
        {
            get { return _cF_ZT ?? string.Empty; }
            set { _cF_ZT = value; }
        }
        private string _dFBM = string.Empty;
        /// <summary>
        /// 地方编码
        /// </summary>
        public string DFBM
        {
            get { return _dFBM ?? string.Empty; }
            set { _dFBM = value; }
        }
        private DateTime _sJC = MinDate;
        /// <summary>
        /// 数据更新时间戳
        /// </summary>
        public DateTime SJC
        {
            get { return _sJC; }
            set { _sJC = value; }
        }
        private string _bZ = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string BZ
        {
            get { return _bZ ?? string.Empty; }
            set { _bZ = value; }
        }
        private string _cF_SYFW = string.Empty;
        /// <summary>
        /// 信息使用范围
        /// </summary>
        public string CF_SYFW
        {
            get { return _cF_SYFW ?? string.Empty; }
            set { _cF_SYFW = value; }
        }
        private string _cF_SXYZCD = string.Empty;
        /// <summary>
        /// 失信严重程度 0.未定；1.一般；2.较重；3.严重。
        /// </summary>
        public string CF_SXYZCD
        {
            get { return _cF_SXYZCD ?? string.Empty; }
            set { _cF_SXYZCD = value; }
        }
        private DateTime _cF_GSJZQ = MinDate;
        /// <summary>
        /// 公示截止期 格式为:YYYY/MM/DD
        /// </summary>
        public DateTime CF_GSJZQ
        {
            get { return _cF_GSJZQ; }
            set { _cF_GSJZQ = value; }
        }
        private int _whetherPublic;
        /// <summary>
        /// 是否公开（0否，1是）
        /// </summary>
        public int WhetherPublic
        {
            get { return _whetherPublic; }
            set { _whetherPublic = value; }
        }
        private int _isPush;
        /// <summary>
        /// 是否已推送（0否，1是）
        /// </summary>
        public int IsPush
        {
            get { return _isPush; }
            set { _isPush = value; }
        }
        /// <summary>
        /// 处罚日期
        /// </summary>
        private DateTime _cfdate;
        public DateTime CF_Date
        {
            get { return _cfdate; }
            set { _cfdate = value; }
        }
        /// <summary>
        /// 失信行为有效期
        /// </summary>
        private DateTime _cfsxxwyxq;
        public DateTime CF_SXXWYXQ
        {
            get { return _cfsxxwyxq; }
            set { _cfsxxwyxq = value; }
        }
        /// <summary>
        /// 没收金额
        /// </summary>
        private string _confiscatemoney;
        public string CONFISCATE_MONEY
        {
            get { return _confiscatemoney ?? string.Empty; }
            set { _confiscatemoney = value; }
        }
        /// <summary>
        /// 罚款金额
        /// </summary>
        private string _cfje;
        public string CF_JE
        {
            get { return _cfje ?? string.Empty; }
            set { _cfje = value; }
        }
        /// <summary>
        /// 信息提供部门全称
        /// </summary>
        private string _informationname;
        public string INFORMATION_FURNISH_IS_NAME
        {
            get { return _informationname ?? string.Empty; }
            set { _informationname = value; }
        }
        /// <summary>
        /// 主要失信事实
        /// </summary>
        private string _cfzysx;
        public string CF_ZYSX
        {
            get { return _cfzysx ?? string.Empty; }
            set { _cfzysx = value; }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        private string _cardtype;
        public string CardType
        {
            get { return _cardtype ?? string.Empty; }
            set { _cardtype = value; }
        }
        /// <summary>
        /// 法人证件号码
        /// </summary>
        private string _frcard;
        public string FRCard
        {
            get { return _frcard ?? string.Empty; }
            set { _frcard = value; }
        }
        private string _cfhm;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CF_HM
        {
            get { return _cfhm ?? string.Empty; }
            set { _cfhm = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override PunishmentEntity SetModelValueByDataRow(DataRow dr)
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
        public override PunishmentEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new PunishmentEntity();
            if (fields.Contains(Parm_Punishment_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Punishment_Id].ToString();
            if (fields.Contains(Parm_Punishment_CASEINFOID) || fields.Contains("*"))
                tmp.CASEINFOID = dr[Parm_Punishment_CASEINFOID].ToString();
            if (fields.Contains(Parm_Punishment_CASEINFONO) || fields.Contains("*"))
                tmp.CASEINFONO = dr[Parm_Punishment_CASEINFONO].ToString();
            if (fields.Contains(Parm_Punishment_CF_WSH) || fields.Contains("*"))
                tmp.CF_WSH = dr[Parm_Punishment_CF_WSH].ToString();
            if (fields.Contains(Parm_Punishment_CF_JE) || fields.Contains("*"))
                tmp.CF_JE = dr[Parm_Punishment_CF_JE].ToString();
            if (fields.Contains(Parm_Punishment_CONFISCATE_MONEY) || fields.Contains("*"))
                tmp.CONFISCATE_MONEY = dr[Parm_Punishment_CONFISCATE_MONEY].ToString();
            if (fields.Contains(Parm_Punishment_INFORMATION_FURNISH_IS_NAME) || fields.Contains("*"))
                tmp.INFORMATION_FURNISH_IS_NAME = dr[Parm_Punishment_INFORMATION_FURNISH_IS_NAME].ToString();
            if (fields.Contains(Parm_Punishment_CF_AJMC) || fields.Contains("*"))
                tmp.CF_AJMC = dr[Parm_Punishment_CF_AJMC].ToString();
            if (fields.Contains(Parm_Punishment_CF_BM) || fields.Contains("*"))
                tmp.CF_BM = dr[Parm_Punishment_CF_BM].ToString();
            if (fields.Contains(Parm_Punishment_CF_CFLB1) || fields.Contains("*"))
                tmp.CF_CFLB1 = dr[Parm_Punishment_CF_CFLB1].ToString();
            if (fields.Contains(Parm_Punishment_CF_CFLB2) || fields.Contains("*"))
                tmp.CF_CFLB2 = dr[Parm_Punishment_CF_CFLB2].ToString();
            if (fields.Contains(Parm_Punishment_CF_SY) || fields.Contains("*"))
                tmp.CF_SY = dr[Parm_Punishment_CF_SY].ToString();
            if (fields.Contains(Parm_Punishment_CF_YJ) || fields.Contains("*"))
                tmp.CF_YJ = dr[Parm_Punishment_CF_YJ].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_MC) || fields.Contains("*"))
                tmp.CF_XDR_MC = dr[Parm_Punishment_CF_XDR_MC].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_SHXYM) || fields.Contains("*"))
                tmp.CF_XDR_SHXYM = dr[Parm_Punishment_CF_XDR_SHXYM].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_ZDM) || fields.Contains("*"))
                tmp.CF_XDR_ZDM = dr[Parm_Punishment_CF_XDR_ZDM].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_GSDJ) || fields.Contains("*"))
                tmp.CF_XDR_GSDJ = dr[Parm_Punishment_CF_XDR_GSDJ].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_SWDJ) || fields.Contains("*"))
                tmp.CF_XDR_SWDJ = dr[Parm_Punishment_CF_XDR_SWDJ].ToString();
            if (fields.Contains(Parm_Punishment_CF_XDR_SFZ) || fields.Contains("*"))
                tmp.CF_XDR_SFZ = dr[Parm_Punishment_CF_XDR_SFZ].ToString();
            if (fields.Contains(Parm_Punishment_CF_FR) || fields.Contains("*"))
                tmp.CF_FR = dr[Parm_Punishment_CF_FR].ToString();
            if (fields.Contains(Parm_Punishment_CF_JG) || fields.Contains("*"))
                tmp.CF_JG = dr[Parm_Punishment_CF_JG].ToString();
            if (fields.Contains(Parm_Punishment_CF_JDRQ) || fields.Contains("*"))
                tmp.CF_JDRQ = DateTime.Parse(dr[Parm_Punishment_CF_JDRQ].ToString());
            if (fields.Contains(Parm_Punishment_CF_Date) || fields.Contains("*"))
                tmp.CF_Date = DateTime.Parse(dr[Parm_Punishment_CF_Date].ToString());
            if (fields.Contains(Parm_Punishment_CF_SXXWYXQ) || fields.Contains("*"))
                tmp.CF_SXXWYXQ = DateTime.Parse(dr[Parm_Punishment_CF_SXXWYXQ].ToString());
            if (fields.Contains(Parm_Punishment_CF_XZJG) || fields.Contains("*"))
                tmp.CF_XZJG = dr[Parm_Punishment_CF_XZJG].ToString();
            if (fields.Contains(Parm_Punishment_CF_ZT) || fields.Contains("*"))
                tmp.CF_ZT = dr[Parm_Punishment_CF_ZT].ToString();
            if (fields.Contains(Parm_Punishment_DFBM) || fields.Contains("*"))
                tmp.DFBM = dr[Parm_Punishment_DFBM].ToString();
            if (fields.Contains(Parm_Punishment_SJC) || fields.Contains("*"))
                tmp.SJC = DateTime.Parse(dr[Parm_Punishment_SJC].ToString());
            if (fields.Contains(Parm_Punishment_BZ) || fields.Contains("*"))
                tmp.BZ = dr[Parm_Punishment_BZ].ToString();
            if (fields.Contains(Parm_Punishment_CF_SYFW) || fields.Contains("*"))
                tmp.CF_SYFW = dr[Parm_Punishment_CF_SYFW].ToString();
            if (fields.Contains(Parm_Punishment_CF_SXYZCD) || fields.Contains("*"))
                tmp.CF_SXYZCD = dr[Parm_Punishment_CF_SXYZCD].ToString();
            if (fields.Contains(Parm_Punishment_CF_GSJZQ) || fields.Contains("*"))
                tmp.CF_GSJZQ = DateTime.Parse(dr[Parm_Punishment_CF_GSJZQ].ToString());
            if (fields.Contains(Parm_Punishment_WhetherPublic) || fields.Contains("*"))
                tmp.WhetherPublic = int.Parse(dr[Parm_Punishment_WhetherPublic].ToString());
            if (fields.Contains(Parm_Punishment_IsPush) || fields.Contains("*"))
                tmp.IsPush = int.Parse(dr[Parm_Punishment_IsPush].ToString());
            if (fields.Contains(Parm_Punishment_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Punishment_RowStatus].ToString()); ;
            if (fields.Contains(Parm_Punishment_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Punishment_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Punishment_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Punishment_CreatorId].ToString();
            if (fields.Contains(Parm_Punishment_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Punishment_CreateBy].ToString();
            if (fields.Contains(Parm_Punishment_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Punishment_CreateOn].ToString());
            if (fields.Contains(Parm_Punishment_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Punishment_UpdateId].ToString();
            if (fields.Contains(Parm_Punishment_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Punishment_UpdateBy].ToString();
            if (fields.Contains(Parm_Punishment_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Punishment_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="punishment">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(PunishmentEntity punishment, SqlParameter[] parms)
        {
            parms[0].Value = punishment.CASEINFOID;
            parms[1].Value = punishment.CASEINFONO;
            parms[2].Value = punishment.CF_WSH;
            parms[3].Value = punishment.CF_AJMC;
            parms[4].Value = punishment.CF_BM;
            parms[5].Value = punishment.CF_CFLB1;
            parms[6].Value = punishment.CF_CFLB2;
            parms[7].Value = punishment.CF_SY;
            parms[8].Value = punishment.CF_YJ;
            parms[9].Value = punishment.CF_XDR_MC;
            parms[10].Value = punishment.CF_XDR_SHXYM;
            parms[11].Value = punishment.CF_XDR_ZDM;
            parms[12].Value = punishment.CF_XDR_GSDJ;
            parms[13].Value = punishment.CF_XDR_SWDJ;
            parms[14].Value = punishment.CF_XDR_SFZ;
            parms[15].Value = punishment.CF_FR;
            parms[16].Value = punishment.CF_JG;
            parms[17].Value = punishment.CF_JDRQ;
            parms[18].Value = punishment.CF_XZJG;
            parms[19].Value = punishment.CF_ZT;
            parms[20].Value = punishment.DFBM;
            parms[21].Value = punishment.SJC;
            parms[22].Value = punishment.BZ;
            parms[23].Value = punishment.CF_SYFW;
            parms[24].Value = punishment.CF_SXYZCD;
            parms[25].Value = punishment.CF_GSJZQ;
            parms[26].Value = punishment.WhetherPublic;
            parms[27].Value = punishment.IsPush;
            parms[28].Value = punishment.RowStatus;
            parms[29].Value = punishment.CreatorId;
            parms[30].Value = punishment.CreateBy;
            parms[31].Value = punishment.CreateOn;
            parms[32].Value = punishment.UpdateId;
            parms[33].Value = punishment.UpdateBy;
            parms[34].Value = punishment.UpdateOn;
            parms[35].Value = punishment.Id;
            parms[36].Value = punishment.CF_JE;
            parms[37].Value = punishment.CONFISCATE_MONEY;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(PunishmentEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Punishment_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Punishment_CASEINFOID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_CASEINFONO, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_CF_WSH, SqlDbType.NVarChar, 128),
					new SqlParameter(Parm_Punishment_CF_AJMC, SqlDbType.NVarChar, 256),
					new SqlParameter(Parm_Punishment_CF_BM, SqlDbType.NVarChar, 40),
					new SqlParameter(Parm_Punishment_CF_CFLB1, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_Punishment_CF_CFLB2, SqlDbType.NVarChar, 36),
					new SqlParameter(Parm_Punishment_CF_SY, SqlDbType.NVarChar, 2048),
					new SqlParameter(Parm_Punishment_CF_YJ, SqlDbType.NVarChar, 2048),
					new SqlParameter(Parm_Punishment_CF_XDR_MC, SqlDbType.NVarChar, 128),
					new SqlParameter(Parm_Punishment_CF_XDR_SHXYM, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_XDR_ZDM, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_XDR_GSDJ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_XDR_SWDJ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_XDR_SFZ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_FR, SqlDbType.NVarChar, 256),
					new SqlParameter(Parm_Punishment_CF_JG, SqlDbType.NVarChar, 2048),
					new SqlParameter(Parm_Punishment_CF_JDRQ, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Punishment_CF_XZJG, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_Punishment_CF_ZT, SqlDbType.NVarChar, 1),
					new SqlParameter(Parm_Punishment_DFBM, SqlDbType.NVarChar, 6),
					new SqlParameter(Parm_Punishment_SJC, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Punishment_BZ, SqlDbType.NVarChar, 4000),
					new SqlParameter(Parm_Punishment_CF_SYFW, SqlDbType.NVarChar, 1),
					new SqlParameter(Parm_Punishment_CF_SXYZCD, SqlDbType.NVarChar, 1),
					new SqlParameter(Parm_Punishment_CF_GSJZQ, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Punishment_WhetherPublic, SqlDbType.Int, 10),
					new SqlParameter(Parm_Punishment_IsPush, SqlDbType.Int, 10),
					new SqlParameter(Parm_Punishment_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Punishment_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Punishment_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Punishment_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Punishment_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Punishment_Insert, parms);
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

