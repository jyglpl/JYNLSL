using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Model.Power
{
    /// <summary>
    /// add by lpl
    /// 2019-1-3
    /// 权利事项表
    /// </summary>
    [TableName("PowerItem")]//权利事项
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class PowerItemEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("Id")]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Item")]
        public string Item { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("CFZL")]
        public string CFZL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("CFYJ")]
        public string CFYJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("CFYJYW")]
        public string CFYJYW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("WFFG")]
        public string WFFG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("WFFGYW")]
        public string WFFGYW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("LX")]
        public string LX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("RowStatus")]
        public int? RowStatus { get; set; }
    }
}
