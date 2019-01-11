using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Evidence
{
    [TableName("INF_PUNISH_ATTACH_CASE")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class ProofAttachCaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("ID")]
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 案件ID
        /// </summary>
        [Column("CASEID")]
        [DataMember]
        public string CaseId { get; set; }

        /// <summary>
        /// 视频ID
        /// </summary>
        [Column("PROOFATTACHID")]
        [DataMember]
        public string ProofAttachId { get; set; }

        /// <summary>
        /// 页面
        /// </summary>
        [Column("PENALTYCASE")]
        [DataMember]
        public string PenaltyCase { get; set; }

        /// <summary>
        /// 一般案件、简易案件
        /// </summary>
        [Column("PENALTY")]
        [DataMember]
        public string Penalty { get; set; }
    }
}
