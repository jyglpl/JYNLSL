using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Model.LawManger
{
    /// <summary>
    /// 法律法规表
    /// add by lpl
    /// 2019-1-9
    /// </summary>
    [TableName("LawManger")]//权利事项
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class LawMangerEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        [Column("ParentId")]
        [DataMember]
        public string ParentId { get; set; }
        /// <summary>
        /// 分类名/文档名
        /// </summary>
        [Column("Name")]
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 文档内容
        /// </summary>
        [Column("ContentText")]
        [DataMember]
        public string ContentText { get; set; }
        /// <summary>
        /// 行状态 1：正常，0：删除
        /// </summary>
        [Column("Rowsatus")]
        [DataMember]
        public int? Rowsatus { get; set; }
    }
}
