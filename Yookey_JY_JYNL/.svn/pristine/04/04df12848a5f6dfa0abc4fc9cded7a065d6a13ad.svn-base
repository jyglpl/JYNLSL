//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicensePulicityEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监企业调查表
//  作    者：叶念
//  创建日期：2018-05-29 11:51:50
//  功能描述：LicensePulicity表实体
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
    public class LicensePulicityEntity : ModelImp.BaseModel<LicensePulicityEntity>
    {
        public LicensePulicityEntity()
        {
            TB_Name = TB_LicensePulicity;
            Parm_Id = Parm_LicensePulicity_Id;
            Parm_Version = Parm_LicensePulicity_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_LicensePulicity_Insert;
            Sql_Update = Sql_LicensePulicity_Update;
            Sql_Delete = Sql_LicensePulicity_Delete;
        }
        #region Const of table LicensePulicity
        /// <summary>
        /// Table LicensePulicity
        /// </summary>
        public const string TB_LicensePulicity = "LicensePulicity";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm BZ
        /// </summary>
        public const string Parm_LicensePulicity_BZ = "BZ";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_LicensePulicity_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_LicensePulicity_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_LicensePulicity_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DFBM
        /// </summary>
        public const string Parm_LicensePulicity_DFBM = "DFBM";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_LicensePulicity_Id = "Id";
        /// <summary>
        /// Parm IsPush
        /// </summary>
        public const string Parm_LicensePulicity_IsPush = "IsPush";
        /// <summary>
        /// Parm LicenseId
        /// </summary>
        public const string Parm_LicensePulicity_LicenseId = "LicenseId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_LicensePulicity_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SJC
        /// </summary>
        public const string Parm_LicensePulicity_SJC = "SJC";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_LicensePulicity_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_LicensePulicity_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_LicensePulicity_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_LicensePulicity_Version = "Version";
        /// <summary>
        /// Parm WhetherPublic
        /// </summary>
        public const string Parm_LicensePulicity_WhetherPublic = "WhetherPublic";
        /// <summary>
        /// Parm XK_BM
        /// </summary>
        public const string Parm_LicensePulicity_XK_BM = "XK_BM";
        /// <summary>
        /// Parm XK_FJ
        /// </summary>
        public const string Parm_LicensePulicity_XK_FJ = "XK_FJ";
        /// <summary>
        /// Parm XK_FR
        /// </summary>
        public const string Parm_LicensePulicity_XK_FR = "XK_FR";
        /// <summary>
        /// Parm XK_JDRQ
        /// </summary>
        public const string Parm_LicensePulicity_XK_JDRQ = "XK_JDRQ";
        /// <summary>
        /// Parm XK_JZQ
        /// </summary>
        public const string Parm_LicensePulicity_XK_JZQ = "XK_JZQ";
        /// <summary>
        /// Parm XK_NR
        /// </summary>
        public const string Parm_LicensePulicity_XK_NR = "XK_NR";
        /// <summary>
        /// Parm XK_SPLB
        /// </summary>
        public const string Parm_LicensePulicity_XK_SPLB = "XK_SPLB";
        /// <summary>
        /// Parm XK_SYFW
        /// </summary>
        public const string Parm_LicensePulicity_XK_SYFW = "XK_SYFW";
        /// <summary>
        /// Parm XK_WSH
        /// </summary>
        public const string Parm_LicensePulicity_XK_WSH = "XK_WSH";
        /// <summary>
        /// Parm XK_XDR
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR = "XK_XDR";
        /// <summary>
        /// Parm XK_XDR_GSDJ
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR_GSDJ = "XK_XDR_GSDJ";
        /// <summary>
        /// Parm XK_XDR_SFZ
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR_SFZ = "XK_XDR_SFZ";
        /// <summary>
        /// Parm XK_XDR_SHXYM
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR_SHXYM = "XK_XDR_SHXYM";
        /// <summary>
        /// Parm XK_XDR_SWDJ
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR_SWDJ = "XK_XDR_SWDJ";
        /// <summary>
        /// Parm XK_XDR_ZDM
        /// </summary>
        public const string Parm_LicensePulicity_XK_XDR_ZDM = "XK_XDR_ZDM";
        /// <summary>
        /// Parm XK_XMMC
        /// </summary>
        public const string Parm_LicensePulicity_XK_XMMC = "XK_XMMC";
        /// <summary>
        /// Parm XK_XZJG
        /// </summary>
        public const string Parm_LicensePulicity_XK_XZJG = "XK_XZJG";
        /// <summary>
        /// Parm XK_ZT
        /// </summary>
        public const string Parm_LicensePulicity_XK_ZT = "XK_ZT";
        /// <summary>
        /// Insert Query Of LicensePulicity
        /// </summary>
        public const string Sql_LicensePulicity_Insert = "insert into LicensePulicity(BZ,CreateBy,CreateOn,CreatorId,DFBM,IsPush,LicenseId,RowStatus,SJC,UpdateBy,UpdateId,UpdateOn,WhetherPublic,XK_BM,XK_FJ,XK_FR,XK_JDRQ,XK_JZQ,XK_NR,XK_SPLB,XK_SYFW,XK_WSH,XK_XDR,XK_XDR_GSDJ,XK_XDR_SFZ,XK_XDR_SHXYM,XK_XDR_SWDJ,XK_XDR_ZDM,XK_XMMC,XK_XZJG,XK_ZT,Id) values(@BZ,@CreateBy,@CreateOn,@CreatorId,@DFBM,@IsPush,@LicenseId,@RowStatus,@SJC,@UpdateBy,@UpdateId,@UpdateOn,@WhetherPublic,@XK_BM,@XK_FJ,@XK_FR,@XK_JDRQ,@XK_JZQ,@XK_NR,@XK_SPLB,@XK_SYFW,@XK_WSH,@XK_XDR,@XK_XDR_GSDJ,@XK_XDR_SFZ,@XK_XDR_SHXYM,@XK_XDR_SWDJ,@XK_XDR_ZDM,@XK_XMMC,@XK_XZJG,@XK_ZT,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of LicensePulicity
        /// </summary>
        public const string Sql_LicensePulicity_Update = "update LicensePulicity set BZ=@BZ,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DFBM=@DFBM,IsPush=@IsPush,LicenseId=@LicenseId,RowStatus=@RowStatus,SJC=@SJC,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,WhetherPublic=@WhetherPublic,XK_BM=@XK_BM,XK_FJ=@XK_FJ,XK_FR=@XK_FR,XK_JDRQ=@XK_JDRQ,XK_JZQ=@XK_JZQ,XK_NR=@XK_NR,XK_SPLB=@XK_SPLB,XK_SYFW=@XK_SYFW,XK_WSH=@XK_WSH,XK_XDR=@XK_XDR,XK_XDR_GSDJ=@XK_XDR_GSDJ,XK_XDR_SFZ=@XK_XDR_SFZ,XK_XDR_SHXYM=@XK_XDR_SHXYM,XK_XDR_SWDJ=@XK_XDR_SWDJ,XK_XDR_ZDM=@XK_XDR_ZDM,XK_XMMC=@XK_XMMC,XK_XZJG=@XK_XZJG,XK_ZT=@XK_ZT where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_LicensePulicity_Delete = "update LicensePulicity set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _licenseId = string.Empty;
        /// <summary>
        /// 关联案件编号
        /// </summary>
        public string LicenseId
        {
            get { return _licenseId ?? string.Empty; }
            set { _licenseId = value; }
        }
        private string _xK_WSH = string.Empty;
        /// <summary>
        /// 行政许可决定书文号
        /// </summary>
        public string XK_WSH
        {
            get { return _xK_WSH ?? string.Empty; }
            set { _xK_WSH = value; }
        }
        private string _xK_XMMC = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string XK_XMMC
        {
            get { return _xK_XMMC ?? string.Empty; }
            set { _xK_XMMC = value; }
        }
        private string _xK_BM = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_BM
        {
            get { return _xK_BM ?? string.Empty; }
            set { _xK_BM = value; }
        }
        private string _xK_SPLB = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_SPLB
        {
            get { return _xK_SPLB ?? string.Empty; }
            set { _xK_SPLB = value; }
        }
        private string _xK_NR = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_NR
        {
            get { return _xK_NR ?? string.Empty; }
            set { _xK_NR = value; }
        }
        private string _xK_FJ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_FJ
        {
            get { return _xK_FJ ?? string.Empty; }
            set { _xK_FJ = value; }
        }
        private string _xK_XDR = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR
        {
            get { return _xK_XDR ?? string.Empty; }
            set { _xK_XDR = value; }
        }
        private string _xK_XDR_SHXYM = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR_SHXYM
        {
            get { return _xK_XDR_SHXYM ?? string.Empty; }
            set { _xK_XDR_SHXYM = value; }
        }
        private string _xK_XDR_ZDM = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR_ZDM
        {
            get { return _xK_XDR_ZDM ?? string.Empty; }
            set { _xK_XDR_ZDM = value; }
        }
        private string _xK_XDR_GSDJ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR_GSDJ
        {
            get { return _xK_XDR_GSDJ ?? string.Empty; }
            set { _xK_XDR_GSDJ = value; }
        }
        private string _xK_XDR_SWDJ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR_SWDJ
        {
            get { return _xK_XDR_SWDJ ?? string.Empty; }
            set { _xK_XDR_SWDJ = value; }
        }
        private string _xK_XDR_SFZ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XDR_SFZ
        {
            get { return _xK_XDR_SFZ ?? string.Empty; }
            set { _xK_XDR_SFZ = value; }
        }
        private string _xK_FR = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_FR
        {
            get { return _xK_FR ?? string.Empty; }
            set { _xK_FR = value; }
        }
        private DateTime _xK_JDRQ = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime XK_JDRQ
        {
            get { return _xK_JDRQ; }
            set { _xK_JDRQ = value; }
        }
        private DateTime _xK_JZQ = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime XK_JZQ
        {
            get { return _xK_JZQ; }
            set { _xK_JZQ = value; }
        }
        private string _xK_XZJG = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_XZJG
        {
            get { return _xK_XZJG ?? string.Empty; }
            set { _xK_XZJG = value; }
        }
        private string _xK_ZT = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_ZT
        {
            get { return _xK_ZT ?? string.Empty; }
            set { _xK_ZT = value; }
        }
        private string _dFBM = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DFBM
        {
            get { return _dFBM ?? string.Empty; }
            set { _dFBM = value; }
        }
        private DateTime _sJC = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SJC
        {
            get { return _sJC; }
            set { _sJC = value; }
        }
        private string _bZ = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string BZ
        {
            get { return _bZ ?? string.Empty; }
            set { _bZ = value; }
        }
        private string _xK_SYFW = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string XK_SYFW
        {
            get { return _xK_SYFW ?? string.Empty; }
            set { _xK_SYFW = value; }
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override LicensePulicityEntity SetModelValueByDataRow(DataRow dr)
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
        public override LicensePulicityEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new LicensePulicityEntity();
            if (fields.Contains(Parm_LicensePulicity_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_LicensePulicity_Id].ToString();
            if (fields.Contains(Parm_LicensePulicity_LicenseId) || fields.Contains("*"))
                tmp.LicenseId = dr[Parm_LicensePulicity_LicenseId].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_WSH) || fields.Contains("*"))
                tmp.XK_WSH = dr[Parm_LicensePulicity_XK_WSH].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XMMC) || fields.Contains("*"))
                tmp.XK_XMMC = dr[Parm_LicensePulicity_XK_XMMC].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_BM) || fields.Contains("*"))
                tmp.XK_BM = dr[Parm_LicensePulicity_XK_BM].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_SPLB) || fields.Contains("*"))
                tmp.XK_SPLB = dr[Parm_LicensePulicity_XK_SPLB].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_NR) || fields.Contains("*"))
                tmp.XK_NR = dr[Parm_LicensePulicity_XK_NR].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_FJ) || fields.Contains("*"))
                tmp.XK_FJ = dr[Parm_LicensePulicity_XK_FJ].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR) || fields.Contains("*"))
                tmp.XK_XDR = dr[Parm_LicensePulicity_XK_XDR].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR_SHXYM) || fields.Contains("*"))
                tmp.XK_XDR_SHXYM = dr[Parm_LicensePulicity_XK_XDR_SHXYM].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR_ZDM) || fields.Contains("*"))
                tmp.XK_XDR_ZDM = dr[Parm_LicensePulicity_XK_XDR_ZDM].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR_GSDJ) || fields.Contains("*"))
                tmp.XK_XDR_GSDJ = dr[Parm_LicensePulicity_XK_XDR_GSDJ].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR_SWDJ) || fields.Contains("*"))
                tmp.XK_XDR_SWDJ = dr[Parm_LicensePulicity_XK_XDR_SWDJ].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_XDR_SFZ) || fields.Contains("*"))
                tmp.XK_XDR_SFZ = dr[Parm_LicensePulicity_XK_XDR_SFZ].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_FR) || fields.Contains("*"))
                tmp.XK_FR = dr[Parm_LicensePulicity_XK_FR].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_JDRQ) || fields.Contains("*"))
                tmp.XK_JDRQ = DateTime.Parse(dr[Parm_LicensePulicity_XK_JDRQ].ToString());
            if (fields.Contains(Parm_LicensePulicity_XK_JZQ) || fields.Contains("*"))
                tmp.XK_JZQ = DateTime.Parse(dr[Parm_LicensePulicity_XK_JZQ].ToString());
            if (fields.Contains(Parm_LicensePulicity_XK_XZJG) || fields.Contains("*"))
                tmp.XK_XZJG = dr[Parm_LicensePulicity_XK_XZJG].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_ZT) || fields.Contains("*"))
                tmp.XK_ZT = dr[Parm_LicensePulicity_XK_ZT].ToString();
            if (fields.Contains(Parm_LicensePulicity_DFBM) || fields.Contains("*"))
                tmp.DFBM = dr[Parm_LicensePulicity_DFBM].ToString();
            if (fields.Contains(Parm_LicensePulicity_SJC) || fields.Contains("*"))
                tmp.SJC = DateTime.Parse(dr[Parm_LicensePulicity_SJC].ToString());
            if (fields.Contains(Parm_LicensePulicity_BZ) || fields.Contains("*"))
                tmp.BZ = dr[Parm_LicensePulicity_BZ].ToString();
            if (fields.Contains(Parm_LicensePulicity_XK_SYFW) || fields.Contains("*"))
                tmp.XK_SYFW = dr[Parm_LicensePulicity_XK_SYFW].ToString();
            if (fields.Contains(Parm_LicensePulicity_WhetherPublic) || fields.Contains("*"))
                tmp.WhetherPublic = int.Parse(dr[Parm_LicensePulicity_WhetherPublic].ToString());
            if (fields.Contains(Parm_LicensePulicity_IsPush) || fields.Contains("*"))
                tmp.IsPush = int.Parse(dr[Parm_LicensePulicity_IsPush].ToString());
            if (fields.Contains(Parm_LicensePulicity_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_LicensePulicity_RowStatus].ToString());
            if (fields.Contains(Parm_LicensePulicity_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_LicensePulicity_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_LicensePulicity_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_LicensePulicity_CreatorId].ToString();
            if (fields.Contains(Parm_LicensePulicity_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_LicensePulicity_CreateBy].ToString();
            if (fields.Contains(Parm_LicensePulicity_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_LicensePulicity_CreateOn].ToString());
            if (fields.Contains(Parm_LicensePulicity_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_LicensePulicity_UpdateId].ToString();
            if (fields.Contains(Parm_LicensePulicity_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_LicensePulicity_UpdateBy].ToString();
            if (fields.Contains(Parm_LicensePulicity_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_LicensePulicity_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="licensepulicity">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(LicensePulicityEntity licensepulicity, SqlParameter[] parms)
        {
            parms[0].Value = licensepulicity.LicenseId;
            parms[1].Value = licensepulicity.XK_WSH;
            parms[2].Value = licensepulicity.XK_XMMC;
            parms[3].Value = licensepulicity.XK_BM;
            parms[4].Value = licensepulicity.XK_SPLB;
            parms[5].Value = licensepulicity.XK_NR;
            parms[6].Value = licensepulicity.XK_FJ;
            parms[7].Value = licensepulicity.XK_XDR;
            parms[8].Value = licensepulicity.XK_XDR_SHXYM;
            parms[9].Value = licensepulicity.XK_XDR_ZDM;
            parms[10].Value = licensepulicity.XK_XDR_GSDJ;
            parms[11].Value = licensepulicity.XK_XDR_SWDJ;
            parms[12].Value = licensepulicity.XK_XDR_SFZ;
            parms[13].Value = licensepulicity.XK_FR;
            parms[14].Value = licensepulicity.XK_JDRQ;
            parms[15].Value = licensepulicity.XK_JZQ;
            parms[16].Value = licensepulicity.XK_XZJG;
            parms[17].Value = licensepulicity.XK_ZT;
            parms[18].Value = licensepulicity.DFBM;
            parms[19].Value = licensepulicity.SJC;
            parms[20].Value = licensepulicity.BZ;
            parms[21].Value = licensepulicity.XK_SYFW;
            parms[22].Value = licensepulicity.WhetherPublic;
            parms[23].Value = licensepulicity.IsPush;
            parms[24].Value = licensepulicity.RowStatus;
            parms[25].Value = licensepulicity.CreatorId;
            parms[26].Value = licensepulicity.CreateBy;
            parms[27].Value = licensepulicity.CreateOn;
            parms[28].Value = licensepulicity.UpdateId;
            parms[29].Value = licensepulicity.UpdateBy;
            parms[30].Value = licensepulicity.UpdateOn;
            parms[31].Value = licensepulicity.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(LicensePulicityEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicensePulicity_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_LicensePulicity_LicenseId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePulicity_XK_WSH, SqlDbType.NVarChar, 128),
					new SqlParameter(Parm_LicensePulicity_XK_XMMC, SqlDbType.NVarChar, 256),
					new SqlParameter(Parm_LicensePulicity_XK_BM, SqlDbType.NVarChar, 40),
					new SqlParameter(Parm_LicensePulicity_XK_SPLB, SqlDbType.NVarChar, 16),
					new SqlParameter(Parm_LicensePulicity_XK_NR, SqlDbType.NVarChar, 2048),
					new SqlParameter(Parm_LicensePulicity_XK_FJ, SqlDbType.NVarChar, 500),
					new SqlParameter(Parm_LicensePulicity_XK_XDR, SqlDbType.NVarChar, 256),
					new SqlParameter(Parm_LicensePulicity_XK_XDR_SHXYM, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_XDR_ZDM, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_XDR_GSDJ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_XDR_SWDJ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_XDR_SFZ, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_FR, SqlDbType.NVarChar, 256),
					new SqlParameter(Parm_LicensePulicity_XK_JDRQ, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicensePulicity_XK_JZQ, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicensePulicity_XK_XZJG, SqlDbType.NVarChar, 64),
					new SqlParameter(Parm_LicensePulicity_XK_ZT, SqlDbType.NVarChar, 1),
					new SqlParameter(Parm_LicensePulicity_DFBM, SqlDbType.NVarChar, 6),
					new SqlParameter(Parm_LicensePulicity_SJC, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicensePulicity_BZ, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_LicensePulicity_XK_SYFW, SqlDbType.NVarChar, 1),
					new SqlParameter(Parm_LicensePulicity_WhetherPublic, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicensePulicity_IsPush, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicensePulicity_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_LicensePulicity_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePulicity_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePulicity_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_LicensePulicity_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePulicity_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_LicensePulicity_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_LicensePulicity_Id, SqlDbType.NVarChar, 50)
				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_LicensePulicity_Insert, parms);
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

