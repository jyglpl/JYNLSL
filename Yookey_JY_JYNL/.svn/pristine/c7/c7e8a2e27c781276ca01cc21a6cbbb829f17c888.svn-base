using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.Certificate
{
    [TableName("ENFORCE_ATTACH")]
    [PrimaryKey("PK_ID")]
    [ExplicitColumns]
    public class CertificateAttachEntity : BaseEntity
    {
        /// <summary>
        /// 用户ID	
        /// </summary>
        [Column("USER_ID")]
        [DataMember]
        public string USER_ID { get; set; }

        /// <summary>
        /// 附件名称	
        /// </summary>
        [Column("FILE_NAME")]
        [DataMember]
        public string FILE_NAME { get; set; }

        /// <summary>
        /// 附件保存路径	
        /// </summary>
        [Column("FILE_ADDRESS")]
        [DataMember]
        public string FILE_ADDRESS { get; set; }
    }
}
