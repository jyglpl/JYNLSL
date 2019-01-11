using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.OnlineClass
{
    [TableName("OnlineClassProgress")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class OnlineClassRecordEntity
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
        /// 课件编号
        /// </summary>
        [Column("CourseId")]
        [DataMember]
        public string CourseId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Column("UserId")]
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// 学习开始时间
        /// </summary>
        [Column("StartTime")]
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 学习结束时间
        /// </summary>
        [Column("EndTime")]
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 本次学习时长（单位秒）
        /// </summary>
        [Column("StudyTime")]
        [DataMember]
        public string StudyTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Ip")]
        [DataMember]
        public string Ip { get; set; }
       
    }
}
