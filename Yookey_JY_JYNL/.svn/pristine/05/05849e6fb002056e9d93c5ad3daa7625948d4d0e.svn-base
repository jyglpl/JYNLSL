using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.Certificate
{
    [TableName("PERSONAL_ENFORCE_MANAGE")]
    [PrimaryKey("PK_ID")]
    [ExplicitColumns]
    public class CertificateInfoEntity : BaseEntity
    {
        /// <summary>
        /// 用户ID	
        /// </summary>
        [Column("USER_ID")]
        [DataMember]
        public string USER_ID { get; set; }

        /// <summary>
        /// 证件类型	
        /// </summary>
        [Column("TARGET_PAPER_TYPE")]
        [DataMember]
        public string TARGET_PAPER_TYPE { get; set; }

        /// <summary>
        /// 证件号码	
        /// </summary>
        [Column("TARGET_PAPER_NUM")]
        [DataMember]
        public string TARGET_PAPER_NUM { get; set; }

        /// <summary>
        /// 登陆账号	
        /// </summary>
        [Column("ACCOUNT")]
        [DataMember]
        public string ACCOUNT { get; set; }

        /// <summary>
        /// 姓名	
        /// </summary>
        [Column("NAME")]
        [DataMember]
        public string NAME { get; set; }

        /// <summary>
        /// 性别	
        /// </summary>
        [Column("SEX")]
        [DataMember]
        public string SEX { get; set; }

        /// <summary>
        /// 手机	
        /// </summary>
        [Column("MOBILE")]
        [DataMember]
        public string MOBILE { get; set; }

        /// <summary>
        /// 电话	
        /// </summary>
        [Column("PHONE")]
        [DataMember]
        public string PHONE { get; set; }

        /// <summary>
        /// 邮箱	
        /// </summary>
        [Column("MAIL")]
        [DataMember]
        public string MAIL { get; set; }

        /// <summary>
        /// 所在公司	
        /// </summary>
        [Column("COMPANY")]
        [DataMember]
        public string COMPANY { get; set; }

        /// <summary>
        /// 所在部门	
        /// </summary>
        [Column("DEPTNAME")]
        [DataMember]
        public string DEPTNAME { get; set; }

        /// <summary>
        /// 角色	
        /// </summary>
        [Column("ROLE")]
        [DataMember]
        public string ROLE { get; set; }

        /// <summary>
        /// 领证时间	
        /// </summary>
        [Column("GETCARDTIME")]
        [DataMember]
        public string GETCARDTIME { get; set; }

        /// <summary>
        /// 换证时间	
        /// </summary>
        [Column("REPLACEMENTTIME")]
        [DataMember]
        public string REPLACEMENTTIME { get; set; }

        /// <summary>
        /// 说明	
        /// </summary>
        [Column("DESCRIPTION")]
        [DataMember]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 领证开始时间
        /// </summary>
        public string GetBegin { get; set; }

        /// <summary>
        /// 领证结束时间
        /// </summary>
        public string GetEnd { get; set; }

        /// <summary>
        /// 换证开始时间
        /// </summary>
        public string ReplaceBegin { get; set; }

        /// <summary>
        /// 换证结束时间
        /// </summary>
        public string ReplaceEnd { get; set; }
    }
}
