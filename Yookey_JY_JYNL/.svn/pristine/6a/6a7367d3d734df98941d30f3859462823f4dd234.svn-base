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
    public class OnlineClassProgressEntity
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
        /// 最后一次学习时间（yyyy-MM-dd hh:mm:ss）
        /// </summary>
        [Column("LastStudyTime")]
        [DataMember]
        public DateTime LastStudyTime { get; set; }

        /// <summary>
        /// 最后一次学习视频、音频的秒数
        /// </summary>
        [Column("LastStudySec")]
        [DataMember]
        public string LastStudySec { get; set; }

        /// <summary>
        /// 学习的进度（最大值100）
        /// </summary>
        [Column("Progress")]
        [DataMember]
        public int Progress { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [Column("FinishTime")]
        [DataMember]
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 累计学习时长（单位秒）
        /// </summary>
        [Column("TotalTime")]
        [DataMember]
        public string TotalTime { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        [Column("Integral")]
        [DataMember]
        public Double Integral { get; set; }

        /// <summary>
        /// 学习总时长
        /// </summary>
        [Column("SumTime")]
        [DataMember]
        public int SumTime { get; set; }

    }
}
