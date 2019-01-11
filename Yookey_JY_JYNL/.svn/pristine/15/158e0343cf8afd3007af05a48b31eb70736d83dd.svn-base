using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DoubleRandomObj")]//随机对象
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class DoubleRandomObjEntity
    {
        /// <summary>
        /// 自增字段
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }

        private int _rowStatus = 1;
        /// <summary>
        /// 行状态(0:删除 1:正常)
        /// </summary>
        [Column("RowStatus")]
        [DataMember]
        public int RowStatus
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [Column("CreatorId")]
        public string CreatorId { get; set; }

        private string _createby = string.Empty;
        /// <summary>
        /// 记录创建人
        /// </summary>
        [Column("CreateBy")]
        [DataMember]
        public string CreateBy
        {
            get { return _createby ?? string.Empty; }
            set { _createby = value; }
        }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [Column("CreateOn")]
        [DataMember]
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 更新人Id
        /// </summary>
        [Column("UpdateId")]
        public string UpdateId { get; set; }

        private string _updateby = string.Empty;
        /// <summary>
        /// 记录修改人
        /// </summary>
        [Column("UpdateBy")]
        [DataMember]
        public string UpdateBy
        {
            get { return _updateby ?? string.Empty; }
            set { _updateby = value; }
        }

        /// <summary>
        /// 记录修改时间
        /// </summary>
        [Column("UpdateOn")]
        [DataMember]
        public DateTime UpdateOn { get; set; }
        
        /// <summary>
        /// 所属大队编号
        /// </summary>
        [Column("TeamId")]
        [DataMember]
        public string TeamId { get; set; }

        /// <summary>
        /// 类型编号
        /// </summary>
        [Column("TypeId")]
        [DataMember]
        public string TypeId { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        [Column("ObjName")]
        [DataMember]
        public string ObjName { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [Column("Position")]
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// 开发商
        /// </summary>
        [Column("Developer")]
        [DataMember]
        public string Developer { get; set; }

        /// <summary>
        /// 物业管理公司
        /// </summary>
        [Column("Property")]
        [DataMember]
        public string Property { get; set; }

        /// <summary>
        /// 物业负责人
        /// </summary>
        [Column("PropertyFZR")]
        [DataMember]
        public string PropertyFZR { get; set; }

        /// <summary>
        /// 负责人电话
        /// </summary>
        [Column("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        [Column("RandomNo")]
        [DataMember]
        public int RandomNo { get; set; }

        
        /// <summary>
        /// 所属大队名称
        /// </summary>
        [DataMember]
        public string TeamName { get; set; }
    }
}
