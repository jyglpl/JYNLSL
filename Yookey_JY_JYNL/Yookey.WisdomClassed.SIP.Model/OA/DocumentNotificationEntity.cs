using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.OA
{
    [TableName("DocumentNotification")]//公告通知
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public partial class DocumentNotificationEntity 
    {



        /// <summary>
        /// Id
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }





        /// <summary>
        /// 标题
        /// </summary>
        [Column("Title")]
        [DataMember]
        public string Title { get; set; }





        /// <summary>
        /// 发布人
        /// </summary>
        [Column("Publisher")]
        [DataMember]
        public string Publisher { get; set; }





        /// <summary>
        /// 发布时间
        /// </summary>
        [Column("ReleaseTime")]
        [DataMember]
        public DateTime? ReleaseTime { get; set; }





        /// <summary>
        /// 接受状态
        /// </summary>
        [Column("AplayState")]
        [DataMember]
        public string AplayState { get; set; }



        /// <summary>
        /// 通告类型
        /// </summary>
        [Column("Category")]
        [DataMember]
        public string Category { get; set; }


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








        /// <summary>
        /// 内容
        /// </summary>
        [Column("GGContent")]
        [DataMember]
        public string GGContent { get; set; }





        /// <summary>
        /// 接受人
        /// </summary>
        [Column("Sendname")]
        [DataMember]
        public string Sendname { get; set; }





        /// <summary>
        /// 附件地址
        /// </summary>
        [Column("FilePath")]
        [DataMember]
        public string FilePath { get; set; }





        /// <summary>
        /// 是否置顶
        /// </summary>
        [Column("Iszd")]
        [DataMember]
        public string Iszd { get; set; }


        /// <summary>
        /// 接受数量
        /// </summary>
        [Column("JieShouCount")]
        [DataMember]
        public int? JieShouCount { get; set; }





        /// <summary>
        /// 接受人总数
        /// </summary>
        [Column("JieShouAllCount")]
        [DataMember]
        public int? JieShouAllCount { get; set; }


        private Page _page;
        /// <summary>
        /// 分页实体
        /// </summary>
        public Page page
        {
            get { return _page ?? new Page { PageSize = 10, CurrentPage = 1 }; }
            set { _page = value; }
        }
    }
}
