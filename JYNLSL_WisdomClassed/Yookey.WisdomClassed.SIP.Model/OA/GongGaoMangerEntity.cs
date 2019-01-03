using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Model.OA
{
    /// <summary>
    /// add by lpl
    /// 2018-12-25
    /// 苏州吴中
    /// </summary>
    [TableName("GongWenManger")]//公文管理表
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class GongGaoMangerEntity
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }





        /// <summary>
        /// 公文标题
        /// </summary>
        [Column("Title")]
        [DataMember]
        public string Title { get; set; }





        /// <summary>
        /// 公文类型
        /// </summary>
        [Column("Leixing")]
        [DataMember]
        public string Leixing { get; set; }





        /// <summary>
        /// 发文单位
        /// </summary>
        [Column("DanWei")]
        [DataMember]
        public string DanWei { get; set; }





        /// <summary>
        /// 完成时限
        /// </summary>
        [Column("WCData")]
        [DataMember]
        public DateTime? WCData { get; set; }





        /// <summary>
        /// 文件编号
        /// </summary>
        [Column("WJNo")]
        [DataMember]
        public string WJNo { get; set; }





        /// <summary>
        /// 附件地址
        /// </summary>
        [Column("FilePath")]
        [DataMember]
        public string FilePath { get; set; }





        /// <summary>
        /// 审批状态
        /// </summary>
        [Column("SPZT")]
        [DataMember]
        public string SPZT { get; set; }





        /// <summary>
        /// 当前办理人
        /// </summary>
        [Column("DQBLR")]
        [DataMember]
        public string DQBLR { get; set; }





        /// <summary>
        /// 登记时间
        /// </summary>
        [Column("DJTime")]
        [DataMember]
        public DateTime? DJTime { get; set; }





        /// <summary>
        /// 处理状态
        /// </summary>
        [Column("CLState")]
        [DataMember]
        public string CLState { get; set; }





        /// <summary>
        /// 创建人
        /// </summary>
        [Column("Admin")]
        [DataMember]
        public string Admin { get; set; }


        /// </summary>
        /// 公告内容
        [Column("Remark")]
        public string Remark { get; set; }
        /// <summary>


        /// <summary>
        /// 删除行，正常：1，删除：0
        /// </summary>
        [Column("RowStatus")]
        [DataMember]
        public int? RowStatus { get; set; }





        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("CreatorId")]
        [DataMember]
        public string CreatorId { get; set; }





        /// <summary>
        /// 创建人
        /// </summary>
        [Column("CreateBy")]
        [DataMember]
        public string CreateBy { get; set; }





        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateOn")]
        [DataMember]
        public DateTime? CreateOn { get; set; }





        /// <summary>
        /// 更新人Id
        /// </summary>
        [Column("UpdateId")]
        [DataMember]
        public string UpdateId { get; set; }





        /// <summary>
        /// 更新人
        /// </summary>
        [Column("UpdateBy")]
        [DataMember]
        public string UpdateBy { get; set; }





        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("UpdateOn")]
        [DataMember]
        public DateTime? UpdateOn { get; set; }
    }
}
