using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DOUBLE_RANDOM_ENTERPRISE")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class DoubleRandomEnterpriseEntity : BaseEntity
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        [Column("COMPANY_NAME")]
        [DataMember]
        public string COMPANY_NAME { get; set; }

        /// <summary>
        /// 社会统一信用代码
        /// </summary>
        [Column("ORGANIZATION_CODE")]
        [DataMember]
        public string ORGANIZATION_CODE { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [Column("LEGAL_REPRESENTATIVE")]
        [DataMember]
        public string LEGAL_REPRESENTATIVE { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("PHONE")]
        [DataMember]
        public string PHONE { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [Column("REGISTERED_ADDRESS")]
        [DataMember]
        public string REGISTERED_ADDRESS { get; set; }

        /// <summary>
        /// 生产经营地址
        /// </summary>
        [Column("PRODUCTION_ADDRESS")]
        [DataMember]
        public string PRODUCTION_ADDRESS { get; set; }

        /// <summary>
        /// 行业类别大类
        /// </summary>
        [Column("INDUSTRY_CATEGORYI")]
        [DataMember]
        public string INDUSTRY_CATEGORYI { get; set; }

        /// <summary>
        /// 行业类别大类名称
        /// </summary>
        [Column("INDUSTRY_CATEGORYI_NAME")]
        [DataMember]
        public string INDUSTRY_CATEGORYI_NAME { get; set; }

        /// <summary>
        /// 行业类别中类
        /// </summary>
        [Column("INDUSTRY_CATEGORYII")]
        [DataMember]
        public string INDUSTRY_CATEGORYII { get; set; }

        /// <summary>
        /// 行业类别中类名称
        /// </summary>
        [Column("INDUSTRY_CATEGORYII_Name")]
        [DataMember]
        public string INDUSTRY_CATEGORYII_NAME { get; set; }

        /// <summary>
        /// 行业类别小类
        /// </summary>
        [Column("INDUSTRY_CATEGORYIII")]
        [DataMember]
        public string INDUSTRY_CATEGORYIII { get; set; }

        /// <summary>
        /// 行业类别小类名称
        /// </summary>
        [Column("INDUSTRY_CATEGORYIII_NAME")]
        [DataMember]
        public string INDUSTRY_CATEGORYIII_NAME { get; set; }


    }
}
