using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.DocumentManagement
{
    [TableName("DOCUMENT_INCOMING_INFO")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class DocumentIncomingEntity : BaseEntity
    {

        /// <summary>
        /// 收文单位
        /// </summary>
        [Column("INCOMING_UNIT")]
        [DataMember]
        public string INCOMING_UNIT { get; set; }
        /// <summary>
        /// 内容摘要
        /// </summary>
        [Column("DOCUMENT_CONTENT")]
        [DataMember]
        public string DOCUMENT_CONTENT { get; set; }
        /// <summary>
        /// 收文时间
        /// </summary>
        [Column("INCOMING_DATE")]
        [DataMember]
        public string INCOMING_DATE { get; set; }
        /// <summary>
        /// 限定回复时间
        /// </summary>
        [Column("QUALIFIED_DATE")]
        [DataMember]
        public string QUALIFIED_DATE { get; set; }
        /// <summary>
        /// 公文号
        /// </summary>
        [Column("DOCUMENT_HAO")]
        [DataMember]
        public string DOCUMENT_HAO { get; set; }
        /// <summary>
        /// 承办人
        /// </summary>
        [Column("CBR")]
        [DataMember]
        public string CBR { get; set; }
        /// <summary>
        /// 文件主题
        /// </summary>
        [Column("DOCUMENT_THEME")]
        [DataMember]
        public string DOCUMENT_THEME { get; set; }
        /// <summary>
        /// 来源路径
        /// </summary>
        [Column("SOURCE_PATH")]
        [DataMember]
        public string SOURCE_PATH { get; set; }
        /// <summary>
        /// 是否已阅
        /// </summary>
        [Column("WHETHER_READ")]
        [DataMember]
        public string WHETHER_READ { get; set; }
        /// <summary>
        /// 收文状态
        /// </summary>
        [Column("INCOMING_STATE")]
        [DataMember]
        public string INCOMING_STATE { get; set; }
        /// <summary>
        /// 拟办意见
        /// </summary>
        [Column("INCOMING_NBYJ")]
        [DataMember]
        public string INCOMING_NBYJ { get; set; }
        /// <summary>
        /// 领导批示
        /// </summary>
        [Column("INCOMING_PS")]
        [DataMember]
        public string INCOMING_PS { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        [Column("CLJG")]
        [DataMember]
        public string CLJG { get; set; }

        /// <summary>
        /// 判断页面是新增还是详情修改
        /// </summary>
        [Column("IsInitial")]
        [DataMember]
        public string IsInitial { get; set; }
    }
}
