using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Model.OA
{
    [TableName("DocNotfPerson")]//公告通知
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class DocNotfPersonEntity
    {



        /// <summary>
        /// 用户姓名
        /// </summary>
        [Column("Name")]
        [DataMember]
        public string Name { get; set; }





        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("Pid")]
        [DataMember]
        public string Pid { get; set; }





        /// <summary>
        /// 附件地址
        /// </summary>
        [Column("FilePath")]
        [DataMember]
        public string FilePath { get; set; }





        /// <summary>
        /// 是否阅读
        /// </summary>
        [Column("IsJS")]
        [DataMember]
        public string IsJS { get; set; }

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
        /// 公告Id
        /// </summary>
        /// 
        [Column("ContentId")]
        [DataMember]
        public string ContentId { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        [Column("Title")]
        public string Title { get; set; }





        /// <summary>
        /// 通告类型
        /// </summary>
        [Column("Category")]
        public string Category { get; set; }





        /// <summary>
        /// 发布人
        /// </summary>
        [Column("Publisher")]
        public string Publisher { get; set; }


        /// <summary>
        /// 发布时间
        /// </summary>
        [Column("ReleaseTime")]
        public DateTime? ReleaseTime { get; set; }

    }
}
