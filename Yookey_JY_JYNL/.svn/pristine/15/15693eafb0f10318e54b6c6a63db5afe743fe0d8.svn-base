using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.GridManagement
{
    [TableName("GridManagementFileScoreInfo")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class GridManagementFileScoreInfoEntity : BaseEntity
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        [Column("GMId")]
        [DataMember]
        public string GmId { get; set; }

        /// <summary>
        /// 文件ID
        /// </summary>
        [Column("GMFileInfoId")]
        [DataMember]
        public string GmFileInfoId { get; set; }

        /// <summary>
        /// 扣分值
        /// </summary>
        [Column("FileScore")]
        [DataMember]
        public int FileScore { get; set; }

        /// <summary>
        /// 扣分时间
        /// </summary>
        [Column("FileScoreTime")]
        [DataMember]
        public DateTime FileScoreTime { get; set; }

        /// <summary>
        /// 扣分备注
        /// </summary>
        [Column("FileScoreRemark")]
        [DataMember]
        public string FileScoreRemark { get; set; }

        /// <summary>
        /// 所属单位ID
        /// </summary>
        [Column("CompanyId")]
        [DataMember]
        public string CompanyId { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        [Column("DeptId")]
        [DataMember]
        public string DeptId { get; set; }

        /// <summary>
        /// 评分所属年份
        /// </summary>
        [Column("GradeYear")]
        [DataMember]
        public int GradeYear { get; set; }

        /// <summary>
        /// 评分所属季度
        /// </summary>
        [Column("GradeQuarter")]
        [DataMember]
        public int GradeQuarter { get; set; }
    }
}
