using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.DocumentManagement
{
    [TableName("DOCUMNET_DISPATCH_INFO")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class DocumentOfficialEntity : BaseEntity
    {
        /// <summary>
        /// 来文单位
        /// </summary>
        [Column("LWDW")]
        [DataMember]
        public string LWDW { get; set; }

        /// <summary>
        /// 下发开始时间
        /// </summary>
        [Column("LSSUED_STARTIME")]
        [DataMember]
        public string LSSUED_STARTIME { get; set; }

        /// <summary>
        /// 下发结束时间
        /// </summary>
        [Column("LSSUED_ENDTIME")]
        [DataMember]
        public string LSSUED_ENDTIME { get; set; }

        /// <summary>
        /// 文号
        /// </summary>
        [Column("WH")]
        [DataMember]
        public string WH { get; set; }

        /// <summary>
        /// 起草人
        /// </summary>
        [Column("QCR")]
        [DataMember]
        public string QCR { get; set; }


        /// <summary>
        /// 部门负责人
        /// </summary>
        [Column("BMFZR")]
        [DataMember]
        public string BMFZR { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        [Column("DOCUMENT_TITLE")]
        [DataMember]
        public string DOCUMENT_TITLE { get; set; }

        /// <summary>
        /// 份数
        /// </summary>
        [Column("Volume")]
        [DataMember]
        public string Volume { get; set; }

        /// <summary>
        /// 抄送单位
        /// </summary>
        [Column("DISPATCH_CSDW")]
        [DataMember]
        public string DISPATCH_CSDW { get; set; }

        /// <summary>
        /// 判断页面是新增还是详情修改
        /// </summary>
        [Column("IsInitial")]
        [DataMember]
        public string IsInitial { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        [Column("IsPublic")]
        [DataMember]
        public string IsPublic { get; set; }

        /// <summary>
        /// 分管领导签发
        /// </summary>
        [Column("DISPATCH_FGLD")]
        [DataMember]
        public string DISPATCH_FGLD { get; set; }

        /// <summary>
        /// 领导签发
        /// </summary>
        [Column("DISPATCH_LDQF")]
        [DataMember]
        public string DISPATCH_LDQF { get; set; }

        /// <summary>
        /// 发文状态
        /// </summary>
        [Column("DISPATCH_STATE")]
        [DataMember]
        public int DISPATCH_STATE { get; set; }
    }
}
