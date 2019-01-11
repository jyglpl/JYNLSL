using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DoubleRandomObjLog")]//随机记录
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class DoubleRandomObjLogEntity
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
        /// 批次编号
        /// </summary>
        [Column("ParentId")]
        [DataMember]
        public string ParentId { get; set; }

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
        /// 对象编号
        /// </summary>
        [Column("ObjId")]
        [DataMember]
        public string ObjId { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        [Column("ObjName")]
        [DataMember]
        public string ObjName { get; set; }

        /// <summary>
        /// 检查人编号
        /// </summary>
        [Column("InspectorIds")]
        [DataMember]
        public string InspectorIds { get; set; }

        /// <summary>
        /// 检查人
        /// </summary>
        [Column("InspectorNames")]
        [DataMember]
        public string InspectorNames { get; set; }

        ///// <summary>
        ///// 完成人
        ///// </summary>
        //[Column("FinishBy")]
        //[DataMember]
        //public string FinishBy { get; set; }

        ///// <summary>
        ///// 完成人姓名
        ///// </summary>
        //[Column("FinishPerson")]
        //[DataMember]
        //public string FinishPerson { get; set; }

        ///// <summary>
        ///// 完成时间
        ///// </summary>
        //[Column("FinishTime")]
        //[DataMember]
        //public string FinishTime { get; set; }

        ///// <summary>
        ///// 备注
        ///// </summary>
        //[Column("Remark")]
        //[DataMember]
        //public string Remark { get; set; }


        /// <summary>
        /// 是否已派发(0为未派发，1为已派发)
        /// </summary>
        [Column("IsDispatch")]
        [DataMember]
        public int IsDispatch { get; set; }

        /// <summary>
        /// 完成人
        /// </summary>
        [Column("FinishBy")]
        [DataMember]
        public string FinishBy { get; set; }

        /// <summary>
        /// 完成人姓名
        /// </summary>
        [Column("FinishPerson")]
        [DataMember]
        public string FinishPerson { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [Column("FinishTime")]
        [DataMember]
        public string FinishTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [DataMember]
        public string Remark { get; set; }


        #region 辅助字段

        public string TeamName { get; set; }

        public string TypeName { get; set; } 
        #endregion

    }
}
