using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TC_ATTACHMENT")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TcAttachMentEntity
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
        /// 描述
        /// </summary>
        [Column("DESCRIPTION")]
        [DataMember]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        [Column("NAME")]
        [DataMember]
        public string NAME { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Column("PATH")]
        [DataMember]
        public string PATH { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        [Column("REAL_NAME")]
        [DataMember]
        public string REAL_NAME { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        [Column("SUFFIXATION")]
        [DataMember]
        public string SUFFIXATION { get; set; }

        /// <summary>
        /// 上传方式
        /// </summary>
        [Column("UPLOAD_TYPE")]
        [DataMember]
        public string UPLOAD_TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DELETED")]
        [DataMember]
        public string DELETED { get; set; }
    }
}
