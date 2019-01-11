using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.IllegalConstruction
{
    [TableName("ILLEGAL_CASE_ATTACH")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class IllegalCaseAttachEntity : BaseEntity
    {
        /// <summary>
        /// 关联编号
        /// </summary>
        [Column("GL_RESOURCE_ID")]
        [DataMember]
        public string GL_RESOURCE_ID { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        [Column("FILE_NAME")]
        [DataMember]
        public string FILE_NAME { get; set; }

        /// <summary>
        /// 重命名后名称
        /// </summary>
        [Column("FILE_RENAME")]
        [DataMember]
        public string FILE_RENAME { get; set; }

        /// <summary>
        /// 附件状态
        /// </summary>
        [Column("FILE_STATE")]
        [DataMember]
        public string FILE_STATE { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        [Column("ENCLOSURE_SIZE")]
        [DataMember]
        public string ENCLOSURE_SIZE { get; set; }

        /// <summary>
        /// 附件保存路径
        /// </summary>
        [Column("FILE_ADDRESS")]
        [DataMember]
        public string FILE_ADDRESS { get; set; }

        /// <summary>
        /// 证据日期
        /// </summary>
        [Column("EVIDENCE_DATE")]
        [DataMember]
        public DateTime? EVIDENCE_DATE { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        [Column("ENCLOSURE_TYPE")]
        [DataMember]
        public string ENCLOSURE_TYPE { get; set; }

        /// <summary>
        /// 附件类型名称
        /// </summary>
        [Column("FILE_TYPE_NAME")]
        [DataMember]
        public string FILE_TYPE_NAME { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("REMARK")]
        [DataMember]
        public string REMARK { get; set; }
    }
}
