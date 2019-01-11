using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.DoubleRandom
{
    [TableName("DoubleRandomSpotChecks")]//随机批次
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class DoubleRandomSpotChecksEntity
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
        /// 抽查数量
        /// </summary>
        [Column("CheckNo")]
        [DataMember]
        public int CheckNo { get; set; }

        /// <summary>
        /// 抽查组数
        /// </summary>
        [Column("CheckGroup")]
        [DataMember]
        public int CheckGroup { get; set; }

         /// <summary>
        /// 抽查人员数
        /// </summary>
        [Column("CheckPersonNum")]
        [DataMember]
        public int CheckPersonNum { get; set; }

         /// <summary>
        /// 抽查对象数
        /// </summary>
        [Column("ObjNo")]
        [DataMember]
        public int ObjNo { get; set; }

        /// <summary>
        /// 双随机类型（1为双随机抽查，0为双随机督查）
        /// </summary>
        [Column("RandomType")]
        [DataMember]
        public string RandomType { get; set; }


        /// <summary>
        /// 是否派发
        /// </summary>
        [Column("IsDispatch")]
        [DataMember]
        public int IsDispatch { get; set; }

    }
}
