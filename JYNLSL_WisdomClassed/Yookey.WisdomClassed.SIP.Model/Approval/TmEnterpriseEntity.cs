using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TM_ENTERPRISE")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TmEnterpriseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("ID")]
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CREATE_TIME")]
        [DataMember]
        public string CREATE_TIME { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [Column("CREATOR_ID")]
        [DataMember]
        public string CREATOR_ID { get; set; }

        /// <summary>
        /// 修改者ID
        /// </summary>
        [Column("MODIFY_ID")]
        [DataMember]
        public string MODIFY_ID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("MODIFY_TIME")]
        [DataMember]
        public string MODIFY_TIME { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Column("VERSION")]
        [DataMember]
        public string VERSION { get; set; }

        /// <summary>
        /// 社会统一信用代码
        /// </summary>
        [Column("UNIQUE_CREDIT_CODE")]
        [DataMember]
        public string UNIQUE_CREDIT_CODE { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Column("ENTERPRISE_NAME")]
        [DataMember]
        public string ENTERPRISE_NAME { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        [Column("LEGAL_PERSON")]
        [DataMember]
        public string LEGAL_PERSON { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [Column("ENTERPRISE_ADDRESS")]
        [DataMember]
        public string ENTERPRISE_ADDRESS { get; set; }

        /// <summary>
        /// 行政区划
        /// </summary>
        [Column("ADMINISTRATIVE_AREA")]
        [DataMember]
        public string ADMINISTRATIVE_AREA { get; set; }

        /// <summary>
        /// 企业联系人
        /// </summary>
        [Column("ENTERPRISE_LINKMAN")]
        [DataMember]
        public string ENTERPRISE_LINKMAN { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [Column("ENTERPRISE_LINKMAN_MOBILE")]
        [DataMember]
        public string ENTERPRISE_LINKMAN_MOBILE { get; set; }

        /// <summary>
        /// 企业状态
        /// </summary>
        [Column("ENTERPRISE_STATUS")]
        [DataMember]
        public string ENTERPRISE_STATUS { get; set; }

        /// <summary>
        /// 企业信息来源
        /// </summary>
        [Column("ENTERPRISE_SOURCE")]
        [DataMember]
        public string ENTERPRISE_SOURCE { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        [Column("APPLY_TIME")]
        [DataMember]
        public string APPLY_TIME { get; set; }

        /// <summary>
        /// 新增日期    
        /// </summary>
        [Column("ADD_TIME")]
        [DataMember]
        public string ADD_TIME { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("MEMO")]
        [DataMember]
        public string MEMO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DELETED")]
        [DataMember]
        public string DELETED { get; set; }
    }
}
