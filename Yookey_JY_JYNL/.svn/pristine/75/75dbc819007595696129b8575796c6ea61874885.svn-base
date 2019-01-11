using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.OnlineClass
{
    [TableName("OnlineClassCourse")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class OnlineClassCourseEntity 
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
        /// 标题
        /// </summary>
        [Column("Title")]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 公告通知内容
        /// </summary>
        [Column("Contents")]
        [DataMember]
        public string Contents { get; set; }


        /// <summary>
        /// 课程简介
        /// </summary>
        [Column("Describle")]
        [DataMember]
        public string Describle { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Column("LinkUrl")]
        [DataMember]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 课程封面（关联附件表）
        /// </summary>
        [Column("Cover")]
        [DataMember]
        public string Cover { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        [Column("Score")]
        [DataMember]
        public Double Score { get; set; }

        /// <summary>
        /// 课程类型（视频、音频、图文、下载）
        /// </summary>
        [Column("CourseType")]
        [DataMember]
        public int CourseType { get; set; }

        /// <summary>
        /// 课程分类
        /// </summary>
        [Column("CategoryId")]
        [DataMember]
        public string CategoryId { get; set; }

        /// <summary>
        /// 学习时长（分钟）
        /// </summary>
        [Column("Duration")]
        [DataMember]
        public int Duration { get; set; }

        /// <summary>
        /// 学习开始时间
        /// </summary>
        [Column("StartTime")]
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 学习截止时间
        /// </summary>
        [Column("EndTime")]
        [DataMember]
        public DateTime EndTime { get; set; }



        /// <summary>
        /// 接收对象
        /// </summary>
        public string Receives { get; set; }

        /// <summary>
        /// 上传附件
        /// </summary>
        public string Files { get; set; }

    }
}