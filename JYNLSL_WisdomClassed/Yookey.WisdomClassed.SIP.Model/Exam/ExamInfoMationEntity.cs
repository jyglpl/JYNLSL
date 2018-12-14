using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    [TableName("ExamInfomation")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class ExamInfoMationEntity
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
        [Column("Tid")]
        [DataMember]
        public string Tid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Uid")]
        [DataMember]
        public string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Time")]
        [DataMember]
        public DateTime Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Source")]
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("OId")]
        [DataMember]
        public string OId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("IsPiYue")]
        [DataMember]
        public string IsPiYue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("IsShenPi")]
        [DataMember]
        public string IsShenPi { get; set; }

        /// <summary>
        /// 试卷名称
        /// </summary>
        [Column("ExamTitle")]
        [DataMember]
        public string ExamTitle { get; set; }

        /// <summary>
        /// 试卷总分
        /// </summary>
        [Column("ExamScore")]
        [DataMember]
        public string ExamScore { get; set; }

        /// <summary>
        /// 科目最高分
        /// </summary>
        public double TopScore { get; set; }

        /// <summary>
        /// 考试次数
        /// </summary>
        public int ExamNo { get; set; }
    }
}
