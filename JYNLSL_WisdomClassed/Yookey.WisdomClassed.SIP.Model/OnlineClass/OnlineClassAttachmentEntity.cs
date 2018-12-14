﻿using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.OnlineClass
{
    [TableName("OnlineClassAttachment")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class OnlineClassAttachmentEntity
    {
        /// <summary>
        /// 自增字段
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }

        //private int _rowStatus = 1;
        ///// <summary>
        ///// 行状态(0:删除 1:正常)
        ///// </summary>
        //[Column("RowStatus")]
        //[DataMember]
        //public int RowStatus
        //{
        //    get { return _rowStatus; }
        //    set { _rowStatus = value; }
        //}

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

        private Page _page;
        /// <summary>
        /// 分页实体
        /// </summary>
        public Page page
        {
            get { return _page ?? new Page { PageSize = 10, CurrentPage = 1 }; }
            set { _page = value; }
        }

        /// <summary>
        /// 外键数据源编号
        /// </summary>
        [Column("ResourceId")]
        [DataMember]
        public string ResourceId { get; set; }
        
        /// <summary>
        /// 附件名称
        /// </summary>
        [Column("FileName")]
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// 附件重命名后的名称
        /// </summary>
        [Column("FileReName")]
        [DataMember]
        public string FileReName { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        [Column("FileSize")]
        [DataMember]
        public string FileSize { get; set; }

        /// <summary>
        /// 是否已上传完成
        /// </summary>
        [Column("IsCompleted")]
        [DataMember]
        public int IsCompleted { get; set; }

        /// <summary>
        /// 附件上传保存的路径（相对路径）
        /// </summary>
        [Column("FileAddress")]
        [DataMember]
        public string FileAddress { get; set; }

    }
}

