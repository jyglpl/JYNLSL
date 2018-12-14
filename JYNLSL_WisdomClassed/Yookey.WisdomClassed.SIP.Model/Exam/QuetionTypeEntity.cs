using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    [TableName("QuetionDataType")]
    [PrimaryKey("QuetionID")]
    [ExplicitColumns]
    public class QuetionTypeEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("QuetionID")]
        [DataMember]
        public string QuetionID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("QuetionName")]
        [DataMember]
        public string QuetionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Sort")]
        [DataMember]
        public string Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }
}
