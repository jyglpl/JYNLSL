using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DOUBLE_RANDOM_ROAD")]
    [PrimaryKey("PK_ID")]
    [ExplicitColumns]
    public class DoubleRandomRoadEntity : BaseEntity
    {
        /// <summary>
        /// 路段名称
        /// </summary>
        [Column("ROAD_NAME")]
        public string ROAD_NAME { get; set; }

        /// <summary>
        /// 路段描述
        /// </summary>
        [Column("LD_REMARK")]
        public string LD_REMARK { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        [Column("SS_DEPT_ID")]
        public string SS_DEPT_ID { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        [Column("SS_DEPT_NAME")]
        public string SS_DEPT_NAME { get; set; }

        /// <summary>
        /// 责任人ID
        /// </summary>
        [Column("ZRR_ID")]
        public string ZRR_ID { get; set; }

        /// <summary>
        /// 责任人姓名
        /// </summary>
        [Column("ZZR_NAME")]
        public string ZZR_NAME { get; set; }

    }
}
