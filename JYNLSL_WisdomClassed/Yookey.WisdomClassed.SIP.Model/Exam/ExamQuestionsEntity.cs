using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    [TableName("ExamQuestions")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class ExamQuestionsEntity
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
        [Column("Sid")]
        [DataMember]
        public string Sid { get; set; }
    }
}
