using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    [TableName("QuetionTitleThemeInfo")]
    [PrimaryKey("QTTID")]
    [ExplicitColumns]
    public class QuetionTitleEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("QTTID")]
        [DataMember]
        public string QTTID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("QuetionID")]
        [DataMember]
        public string QuetionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SubJectId")]
        [DataMember]
        public string SubJectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("TItemId")]
        [DataMember]
        public string TItemId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }
}
