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
        /// 
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("Title")]
        [DataMember]
        public string Title { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("Publisher")]
        [DataMember]
        public string Publisher { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("ReleaseTime")]
        [DataMember]
        public DateTime? ReleaseTime { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("AplayState")]
        [DataMember]
        public string AplayState { get; set; }



        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [Column("Version")]
        [DataMember]
        public byte[] Version { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("CreatorId")]
        [DataMember]
        public string CreatorId { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("CreateBy")]
        [DataMember]
        public string CreateBy { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("CreateOn")]
        [DataMember]
        public DateTime? CreateOn { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("UpdateId")]
        [DataMember]
        public string UpdateId { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("UpdateBy")]
        [DataMember]
        public string UpdateBy { get; set; }





        /// <summary>
        /// 
        /// </summary>
        [Column("UpdateOn")]
        [DataMember]
        public DateTime? UpdateOn { get; set; }


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
