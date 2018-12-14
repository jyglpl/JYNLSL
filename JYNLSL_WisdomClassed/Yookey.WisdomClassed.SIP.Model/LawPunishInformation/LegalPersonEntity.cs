using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;


namespace Yookey.WisdomClassed.SIP.Model.LawPunishInformation
{
    [TableName("PunishmentLw")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class LegalPersonEntity : BaseEntity
    {
        /// <summary>
        /// 案件主键ID
        /// </summary>
        [Column("CASE_MAIN_ID")]
        [DataMember]
        public string CASE_MAIN_ID { get; set; }

        /// <summary>
        /// 案件编号
        /// </summary>
        [Column("CASE_INFO_NO")]
        [DataMember]
        public string CASE_INFO_NO { get; set; }

        /// <summary>
        /// 工商注册号
        /// </summary>
        [Column("RegistraNumber")]
        [DataMember]
        public string RegistraNumber { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Column("OrganizationCode")]
        [DataMember]
        public string OrganizationCode { get; set; }

        /// <summary>
        /// 处罚名称
        /// </summary>
        [Column("PunishmentName")]
        [DataMember]
        public string PunishmentName { get; set; }

        /// <summary>
        /// 行政处罚编码
        /// </summary>
        [Column("PunishmentCod")]
        [DataMember]
        public string PunishmentCod { get; set; }

        /// <summary>
        /// 处罚决定文书号
        /// </summary>
        [Column("DocumentNumber")]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 处罚类别1
        /// </summary>
        [Column("CategoryOne")]
        [DataMember]
        public int CategoryOne { get; set; }

        /// <summary>
        /// 处罚类别2
        /// </summary>
        [Column("CategoryTwo")]
        [DataMember]
        public int CategoryTwo { get; set; }

        /// <summary>
        /// 罚款金额
        /// </summary>
        [Column("FineMoney")]
        [DataMember]
        public string FineMoney { get; set; }

        /// <summary>
        /// 没收金额
        /// </summary>
        [Column("ConfiscateMoney")]
        [DataMember]
        public string ConfiscateMoney { get; set; }

        /// <summary>
        /// 处罚事由
        /// </summary>
        [Column("PunishmentReason")]
        [DataMember]
        public string PunishmentReason { get; set; }

        /// <summary>
        /// 处罚依据
        /// </summary>
        [Column("PunishmentBasis")]
        [DataMember]
        public string PunishmentBasis { get; set; }

        /// <summary>
        /// 处罚结论
        /// </summary>
        [Column("PunishmentVerdict")]
        [DataMember]
        public string PunishmentVerdict { get; set; }

        /// <summary>
        /// 失信严重程度
        /// </summary>
        [Column("DishonestSeverity")]
        [DataMember]
        public int DishonestSeverity { get; set; }

        /// <summary>
        /// 失信行为有效期
        /// </summary>
        [Column("DishonestValidity")]
        [DataMember]
        public DateTime DishonestValidity { get; set; }

        /// <summary>
        /// 处罚决定机关名称
        /// </summary>
        [Column("DecidedName")]
        [DataMember]
        public string DecidedName { get; set; }

        /// <summary>
        /// 处罚决定日期
        /// </summary>
        [Column("DecidedTime")]
        [DataMember]
        public DateTime DecidedTime { get; set; }

        /// <summary>
        /// 法定代表人姓名
        /// </summary>
        [Column("LegalName")]
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// 法定代表人证件类型
        /// </summary>
        [Column("LegalCardType")]
        [DataMember]
        public string LegalCardType { get; set; }

        /// <summary>
        /// 法定代表人证件号
        /// </summary>
        [Column("LegalCard")]
        [DataMember]
        public string LegalCard { get; set; }

        /// <summary>
        /// 处罚截止期
        /// </summary>
        [Column("PunishmentDeadline")]
        [DataMember]
        public DateTime PunishmentDeadline { get; set; }

        /// <summary>
        /// 执行情况
        /// </summary>
        [Column("Implementation")]
        [DataMember]
        public string Implementation { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [Column("State")]
        [DataMember]
        public int State { get; set; }

        /// <summary>
        /// 信息使用范围
        /// </summary>
        [Column("Scope")]
        [DataMember]
        public int Scope { get; set; }

        /// <summary>
        /// 公示截止日期
        /// </summary>
        [Column("PublicDeadline")]
        [DataMember]
        public DateTime PublicDeadline { get; set; }

        /// <summary>
        /// 信息提供部门全称
        /// </summary>
        [Column("InformationName")]
        [DataMember]
        public string InformationName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Note")]
        [DataMember]
        public string Note { get; set; }

        /// <summary>
        /// 是否公示（1公示2不公示）
        /// </summary>
        [Column("IsPush")]
        [DataMember]
        public int IsPush { get; set; }
    }
}
