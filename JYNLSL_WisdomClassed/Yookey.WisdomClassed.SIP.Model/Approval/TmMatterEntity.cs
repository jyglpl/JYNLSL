using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Approval
{
    [TableName("TM_MATTER")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class TmMatterEntity
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
        /// 创建者ID
        /// </summary>
        [Column("CREATOR_ID")]
        [DataMember]
        public string CREATOR_ID { get; set; }

        /// <summary>
        /// 修改者ID
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
        /// 版本号
        /// </summary>
        [Column("VERSION")]
        [DataMember]
        public string VERSION { get; set; }

        /// <summary>
        /// 事项说明URL
        /// </summary>
        [Column("MATTER_URL")]
        [DataMember]
        public string MATTER_URL { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        [Column("SEQUENCE")]
        [DataMember]
        public string SEQUENCE { get; set; }

        /// <summary>
        /// 权利编号
        /// </summary>
        [Column("POWER_NO")]
        [DataMember]
        public string POWER_NO { get; set; }

        /// <summary>
        /// 事项名称
        /// </summary>
        [Column("MATTER_NAME")]
        [DataMember]
        public string MATTER_NAME { get; set; }

        /// <summary>
        /// 事项名称简称
        /// </summary>
        [Column("MATTER_SIMPLE_NAME")]
        [DataMember]
        public string MATTER_SIMPLE_NAME { get; set; }

        /// <summary>
        /// 权利类型
        /// </summary>
        [Column("POWER_TYPE")]
        [DataMember]
        public string POWER_TYPE { get; set; }

        /// <summary>
        /// 履职处室
        /// </summary>
        [Column("DEAL_DEPT")]
        [DataMember]
        public string DEAL_DEPT { get; set; }

        /// <summary>
        /// 办结时限
        /// </summary>
        [Column("TIME_LIMIT")]
        [DataMember]
        public string TIME_LIMIT { get; set; }

        /// <summary>
        /// 编号前缀
        /// </summary>
        [Column("NO_PREFIX")]
        [DataMember]
        public string NO_PREFIX { get; set; }

        /// <summary>
        /// 编号年月日
        /// </summary>
        [Column("NO_YMD_INDEX")]
        [DataMember]
        public string NO_YMD_INDEX { get; set; }

        /// <summary>
        /// 编号序号码
        /// </summary>
        [Column("NO_INDEX")]
        [DataMember]
        public string NO_INDEX { get; set; }
    }
}
