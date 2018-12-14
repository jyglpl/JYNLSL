using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.IllegalConstruction
{
    [TableName("ILLEGAL_REMOVE")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class IllegalCaseRemoveEntity : BaseEntity
    {
        /// <summary>
        /// 案件编号	
        /// </summary>
        [Column("CASE_INFO_NO")]
        [DataMember]
        public string CASE_INFO_NO { get; set; }

        /// <summary>
        /// 拆除日期
        /// </summary>
        [Column("REMOVE_FINISH_DATE")]
        [DataMember]
        public string REMOVE_FINISH_DATE { get; set; }

        /// <summary>
        /// 清运垃圾（吨）
        /// </summary>
        [Column("KEEP_GARBAGE")]
        [DataMember]
        public string KEEP_GARBAGE { get; set; }

        /// <summary>
        /// 拆除数
        /// </summary>
        [Column("REMOVE_COUNT")]
        [DataMember]
        public string REMOVE_COUNT { get; set; }

        /// <summary>
        /// 拆除面积
        /// </summary>
        [Column("REMOVE_AREA")]
        [DataMember]
        public string REMOVE_AREA { get; set; }

        /// <summary>
        /// 拆除方式Id
        /// </summary>
        [Column("REMOVAL_METHOD_ID")]
        [DataMember]
        public string REMOVAL_METHOD_ID { get; set; }

        /// <summary>
        /// 拆除方式名称
        /// </summary>
        [Column("REMOVAL_METHOD_NAME")]
        [DataMember]
        public string REMOVAL_METHOD_NAME { get; set; }

        /// <summary>
        /// 全过程索引编号
        /// </summary>
        [Column("REMOVE_NO")]
        [DataMember]
        public string REMOVE_NO { get; set; }

        /// <summary>
        /// 拆除情况描述
        /// </summary>
        [Column("REMOVE_DESCRIPTION")]
        [DataMember]
        public string REMOVE_DESCRIPTION { get; set; }
    }
}
