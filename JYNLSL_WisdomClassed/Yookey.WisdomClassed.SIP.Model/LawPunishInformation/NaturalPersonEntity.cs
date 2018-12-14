using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.LawPunishInformation
{
    [TableName("PunishmentNp")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class NaturalPersonEntity : BaseEntity
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
        /// 姓名
        /// </summary>
        [Column("NaturalName")]
        [DataMember]
        public string NaturalName { get; set; }


        /// <summary>
        /// 证件类型
        /// </summary>
        [Column("IdCardType")]
        [DataMember]
        public string IdCardType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Column("IdCard")]
        [DataMember]
        public string IdCard { get; set; }

        /// <summary>
        /// 违法行为名称
        /// </summary>
        [Column("IllegalName")]
        [DataMember]
        public string IllegalName { get; set; }

        /// <summary>
        /// 处罚文书编号或处罚决定案号
        /// </summary>
        [Column("DocumentNumber")]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 处罚依据
        /// </summary>
        [Column("PunishmentBasis")]
        [DataMember]
        public string PunishmentBasis { get; set; }

        /// <summary>
        /// 处罚结果
        /// </summary>
        [Column("PunishmentResults")]
        [DataMember]
        public string PunishmentResults { get; set; }

        /// <summary>
        /// 处罚金额
        /// </summary>
        [Column("FineMoney")]
        [DataMember]
        public string FineMoney { get; set; }

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
        /// 处罚机关名称
        /// </summary>
        [Column("OtherName")]
        [DataMember]
        public string OtherName { get; set; }

        /// <summary>
        /// 处罚决定日期
        /// </summary>
        [Column("DecidedTime")]
        [DataMember]
        public DateTime DecidedTime { get; set; }

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
        /// 主要失信事实
        /// </summary>
        [Column("MainDishonest")]
        [DataMember]
        public string MainDishonest { get; set; }

        /// <summary>
        /// 公示截止日期
        /// </summary>
        [Column("PublicDeadline")]
        [DataMember]
        public DateTime PublicDeadline { get; set; }

        /// <summary>
        /// 是否公示（1公示2不公示）
        /// </summary>
        [Column("IsPush")]
        [DataMember]
        public int IsPush { get; set; }
    }
}
