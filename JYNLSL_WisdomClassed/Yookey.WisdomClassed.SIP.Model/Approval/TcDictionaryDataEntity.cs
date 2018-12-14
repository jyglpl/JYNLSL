using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TC_DICTIONARY_DATA")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TcDictionaryDataEntity
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
        /// 代码
        /// </summary>
        [Column("CODE")]
        [DataMember]
        public string CODE { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("SEQUENCE")]
        [DataMember]
        public string SEQUENCE { get; set; }

        /// <summary>
        /// 字典类别代码
        /// </summary>
        [Column("TYPE_CODE")]
        [DataMember]
        public string TYPE_CODE { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Column("VALUE")]
        [DataMember]
        public string VALUE { get; set; }
    }
}
