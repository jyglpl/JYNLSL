using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DOUBLE_RANDOM_CONSTRUCTION_SITE")]
    [PrimaryKey("PK_ID")]
    [ExplicitColumns]
    public class DoubleRandomConstructionSiteEntity
    {
        /// <summary>
        /// 工地名称
        /// </summary>
        [Column("GD_NAME")]
        [DataMember]
        public string GD_NAME { get; set; }

        /// <summary>
        /// 工地所属区域
        /// </summary>
        [Column("AREAID")]
        [DataMember]
        public string AREAID { get; set; }

        /// <summary>
        /// 工地所属区域名称
        /// </summary>
        [Column("AREAID_Name")]
        [DataMember]
        public string AREAID_Name { get; set; }

        /// <summary>
        /// 工地地址
        /// </summary>
        [Column("BUILDING_ADDRESS")]
        [DataMember]
        public string BUILDING_ADDRESS { get; set; }

        /// <summary>
        /// 建设方
        /// </summary>
        [Column("SUPPLIER")]
        [DataMember]
        public string SUPPLIER { get; set; }

        /// <summary>
        /// 建设方负责人
        /// </summary>
        [Column("PRINCIPAL")]
        [DataMember]
        public string PRINCIPAL { get; set; }

        /// <summary>
        /// 建设方负责人联系电话
        /// </summary>
        [Column("PRINCIPALTEL")]
        [DataMember]
        public string PRINCIPALTEL { get; set; }

        /// <summary>
        /// 施工方
        /// </summary>
        [Column("CONSTRUCTION")]
        [DataMember]
        public string CONSTRUCTION { get; set; }

        /// <summary>
        /// 施工方负责人
        /// </summary>
        [Column("CONSTRUCTPRINCIPAL")]
        [DataMember]
        public string CONSTRUCTPRINCIPAL { get; set; }

        /// <summary>
        /// 施工方负责人联系电话
        /// </summary>
        [Column("CONSTRUCTPRINCIPALTEL")]
        [DataMember]
        public string CONSTRUCTPRINCIPALTEL { get; set; }

        /// <summary>
        /// 监管部门ID
        /// </summary>
        [Column("ZG_DEPT_ID")]
        [DataMember]
        public string ZG_DEPT_ID { get; set; }

        /// <summary>
        /// 监管部门名称
        /// </summary>
        [Column("ZG_DEPT_Name")]
        [DataMember]
        public string ZG_DEPT_Name { get; set; }
    }
}
