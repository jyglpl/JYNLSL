using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.IllegalConstruction
{
    [TableName("ILLEGAL_CASEINFO")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class IllegalCaseInfoEntity : BaseEntity
    {
        /// <summary>
        /// 案件编号	
        /// </summary>
        [Column("CASE_INFO_NO")]
        [DataMember]
        public string CASE_INFO_NO { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        [Column("COMPANY_ID")]
        [DataMember]
        public string COMPANY_ID { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [Column("COMPANY_NAME")]
        [DataMember]
        public string COMPANY_NAME { get; set; }

        /// <summary>
        /// 执法中队主键
        /// </summary>
        [Column("DEPT_KEY_ID")]
        [DataMember]
        public string DEPT_KEY_ID { get; set; }

        /// <summary>
        /// 执法中队名称
        /// </summary>
        [Column("ZF_DEPT_NAME")]
        [DataMember]
        public string ZF_DEPT_NAME { get; set; }

        /// <summary>
        /// 承办人主键
        /// </summary>
        [Column("HANDLE_ID")]
        [DataMember]
        public string HANDLE_ID { get; set; }

        /// <summary>
        /// 承办人名称
        /// </summary>
        [Column("HANDLE_NAME")]
        [DataMember]
        public string HANDLE_NAME { get; set; }

        /// <summary>
        /// 案件登记来源 1-新增案件 2-同步服务案件
        /// </summary>
        [Column("CASE_REGISTRATION_SOURCE")]
        [DataMember]
        public string CASE_REGISTRATION_SOURCE { get; set; }

        /// <summary>
        /// 案件来源主键
        /// </summary>
        [Column("CASE_SOURCES")]
        [DataMember]
        public string CASE_SOURCES { get; set; }

        /// <summary>
        /// 案件来源名称
        /// </summary>
        [Column("RE_SOURCE_NAME")]
        [DataMember]
        public string RE_SOURCE_NAME { get; set; }

        /// <summary>
        /// 详细地址	
        /// </summary>
        [Column("DETAIL_ADDRESS")]
        [DataMember]
        public string DETAIL_ADDRESS { get; set; }

        /// <summary>
        /// 案发日期
        /// </summary>
        [Column("CASE_DATE")]
        [DataMember]
        public string CASE_DATE { get; set; }

        /// <summary>
        /// 案情摘要
        /// </summary>
        [Column("CASE_FACT")]
        [DataMember]
        public string CASE_FACT { get; set; }

        /// <summary>
        /// 案件状态
        /// </summary>
        [Column("CASE_STATUS")]
        [DataMember]
        public string CASE_STATUS { get; set; }

        /// <summary>
        /// 举报人姓名
        /// </summary>
        [Column("REPORT_NAME")]
        [DataMember]
        public string REPORT_NAME { get; set; }

        /// <summary>
        /// 举报-发现日期
        /// </summary>
        [Column("REPORT_CASE_DATE")]
        [DataMember]
        public string REPORT_CASE_DATE { get; set; }

        /// <summary>
        /// 举报人联系电话
        /// </summary>
        [Column("REPORT_PHONE")]
        [DataMember]
        public string REPORT_PHONE { get; set; }

        /// <summary>
        /// 规划认定移交-移交日期
        /// </summary>
        [Column("PLAN_CUTOFF_DATE")]
        [DataMember]
        public string PLAN_CUTOFF_DATE { get; set; }

        /// <summary>
        /// 规划认定移交-文件编号
        /// </summary>
        [Column("PLAN_FILE_NUMBER")]
        [DataMember]
        public string PLAN_FILE_NUMBER { get; set; }

        /// <summary>
        /// 规划认定移交截至日期
        /// </summary>
        [Column("PLAN_END_DATE")]
        [DataMember]
        public string PLAN_END_DATE { get; set; }

        /// <summary>
        /// 是否规划认定（0：未认定 1：已认定）
        /// </summary>
        [Column("ISPLAN")]
        [DataMember]
        public string ISPLAN { get; set; }

        /// <summary>
        /// 是否进入行政处罚（0：组织拆除 1：进入行政处罚流程）
        /// </summary>
        [Column("ISPUNISH")]
        [DataMember]
        public string ISPUNISH { get; set; }

        /// <summary>
        /// 是否直接结案（0：是违建 1：非违建直接结案）
        /// </summary>
        [Column("ISEND")]
        [DataMember]
        public string ISEND { get; set; }

        /// <summary>
        /// 预警
        /// </summary>
        [Column("OTHER_REMARK")]
        [DataMember]
        public string OTHER_REMARK { get; set; }

        /// <summary>
        /// 立案审批日期
        /// </summary>
        [Column("LASPDATE")]
        [DataMember]
        public string LASPDATE { get; set; }

        /// <summary>
        /// 处罚决定日期
        /// </summary>
        [Column("CFJDDATE")]
        [DataMember]
        public string CFJDDATE { get; set; }
    }
}
