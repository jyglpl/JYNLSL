using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Evidence
{
    [TableName("INF_PUNISH_ATTACH_PROOF")]
    [PrimaryKey("SYS_ID")]
    [ExplicitColumns]
    public class ProofAttachEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("SYS_ID")]
        [DataMember]
        public string SYS_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ATTACHID")]
        [DataMember]
        public string ATTACHID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("RESOURCEID")]
        [DataMember]
        public string RESOURCEID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CLASSNO")]
        [DataMember]
        public string CLASSNO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("REMARK")]
        [DataMember]
        public string REMARK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILENAME")]
        [DataMember]
        public string FILENAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILETYPE")]
        [DataMember]
        public string FILETYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILELENGTH")]
        [DataMember]
        public string FILELENGTH { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ISUPFISNISH")]
        [DataMember]
        public string ISUPFISNISH { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILEADDRESS")]
        [DataMember]
        public string FILEADDRESS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILETHUMBNAIL")]
        [DataMember]
        public string FILETHUMBNAIL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DEVICENO")]
        [DataMember]
        public string DEVICENO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("USERID")]
        [DataMember]
        public string USERID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DATASOURCE")]
        [DataMember]
        public string DATASOURCE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CREATEDATE")]
        [DataMember]
        public string CREATEDATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ISTEMPORARYDEL")]
        [DataMember]
        public string ISTEMPORARYDEL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ISPERMANENTDEL")]
        [DataMember]
        public string ISPERMANENTDEL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FILERENAME")]
        [DataMember]
        public string FILERENAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ADDRESS")]
        [DataMember]
        public string ADDRESS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CUSERID")]
        [DataMember]
        public string CUSERID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CTIME")]
        [DataMember]
        public string CTIME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SelectType")]
        [DataMember]
        public string SelectType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FIRSTCATEGORYID")]
        [DataMember]
        public string FIRSTCATEGORYID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("FIRSTCATEGORYNAME")]
        [DataMember]
        public string FIRSTCATEGORYNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SECONDCATEGORYID")]
        [DataMember]
        public string SECONDCATEGORYID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("SECONDCATEGORYNAME")]
        [DataMember]
        public string SECONDCATEGORYNAME { get; set; }


        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        //public int pageindex { get; set; }

        /// <summary>
        /// 分页个数
        /// </summary>
        //public int pagesize { get; set; }
    }
}
