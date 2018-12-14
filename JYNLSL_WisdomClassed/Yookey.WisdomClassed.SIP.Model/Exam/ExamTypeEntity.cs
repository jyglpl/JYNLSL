using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    [TableName("TitleTotal")]
    [PrimaryKey("SubJectId")]
    [ExplicitColumns]
    public class ExamTypeEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectId")]
        [DataMember]
        public string SubJectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectName")]
        [DataMember]
        public string SubJectName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectRadio")]
        [DataMember]
        public string SubJectRadio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectDuo")]
        [DataMember]
        public string SubJectDuo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectPan")]
        [DataMember]
        public string SubJectPan { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubjectIsStart")]
        [DataMember]
        public string SubjectIsStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CreateBy")]
        [DataMember]
        public string CreateBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CreateDate")]
        [DataMember]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("QuetionID")]
        [DataMember]
        public string QuetionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("IsDeleted")]
        [DataMember]
        public string IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("OrgID")]
        [DataMember]
        public string OrgID { get; set; }
    }
}
