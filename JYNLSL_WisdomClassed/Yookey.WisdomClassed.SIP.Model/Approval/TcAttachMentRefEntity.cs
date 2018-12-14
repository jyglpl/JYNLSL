using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TC_ATTACHMENT_REF")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TcAttachMentRefEntity
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
        /// 创建人ID
        /// </summary>
        [Column("CREATOR_ID")]
        [DataMember]
        public string CREATOR_ID { get; set; }

        /// <summary>
        /// 修改人ID
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
        /// 乐观锁
        /// </summary>
        [Column("VERSION")]
        [DataMember]
        public string VERSION { get; set; }

        /// <summary>
        /// 附件id
        /// </summary>
        [Column("ATTACHMENT_ID")]
        [DataMember]
        public string ATTACHMENT_ID { get; set; }

        /// <summary>
        /// 标识符
        /// </summary>
        [Column("FLAG")]
        [DataMember]
        public string FLAG { get; set; }

        /// <summary>
        /// 关联记录id
        /// </summary>
        [Column("REF_RECORD_ID")]
        [DataMember]
        public string REF_RECORD_ID { get; set; }

        /// <summary>
        /// 关联表id
        /// </summary>
        [Column("REF_TABLE_ID")]
        [DataMember]
        public string REF_TABLE_ID { get; set; }

        /// <summary>
        /// 关联类型
        /// </summary>
        [Column("REF_TYPE")]
        [DataMember]
        public string REF_TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DELETED")]
        [DataMember]
        public string DELETED { get; set; }
    }
}
