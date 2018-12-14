using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TM_MATTER_APPLY_CERTIFICATE")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TmMatterApplyCertificate
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CREATE_TIME")]
        [DataMember]
        public string CREATE_TIME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CREATOR_ID")]
        [DataMember]
        public string CREATOR_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("MODIFY_ID")]
        [DataMember]
        public string MODIFY_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("MODIFY_TIME")]
        [DataMember]
        public string MODIFY_TIME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("VERSION")]
        [DataMember]
        public string VERSION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ENTERPRISE_ID")]
        [DataMember]
        public string ENTERPRISE_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_TYPE")]
        [DataMember]
        public string CERT_TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_NO")]
        [DataMember]
        public string CERT_NO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_MEMO")]
        [DataMember]
        public string CERT_MEMO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_TIME")]
        [DataMember]
        public string CERT_TIME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_CYCLE_START")]
        [DataMember]
        public string CERT_CYCLE_START { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CERT_CYCLE_END")]
        [DataMember]
        public string CERT_CYCLE_END { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DELETED")]
        [DataMember]
        public string DELETED { get; set; }

    }
}
