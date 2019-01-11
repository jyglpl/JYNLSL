using PetaPoco;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    /// <summary>
    /// 公共字段
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class BaseEntity : EntityBase
    {
        public static DateTime MinDate = Convert.ToDateTime("1900-01-01");

        /// <summary>
        /// 自增字段
        /// </summary>
        [Column("ID")]
        [DataMember]
        public string ID { get; set; }

        private int _rowStatus = 1;
        /// <summary>
        /// 行状态(0:删除 1:正常)
        /// </summary>
        [Column("ROWSTATUS")]
        [DataMember]
        [XmlIgnore]
        public int ROWSTATUS
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [Column("CREATOR_ID")]
        [XmlIgnore]
        public string CREATOR_ID { get; set; }

        private string _createby = string.Empty;
        /// <summary>
        /// 记录创建人
        /// </summary>
        [Column("CREATE_BY")]
        [DataMember]
        [XmlIgnore]
        public string CREATE_BY
        {
            get { return _createby ?? string.Empty; }
            set { _createby = value; }
        }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [Column("CREATE_ON")]
        [DataMember]
        [XmlIgnore]
        public DateTime CREATE_ON { get; set; }

        /// <summary>
        /// 更新人Id
        /// </summary>
        [Column("UPDATE_ID")]
        [XmlIgnore]
        public string UPDATE_ID { get; set; }

        private string _updateby = string.Empty;
        /// <summary>
        /// 记录修改人
        /// </summary>
        [Column("UPDATE_BY")]
        [DataMember]
        [XmlIgnore]
        public string UPDATE_BY
        {
            get { return _updateby ?? string.Empty; }
            set { _updateby = value; }
        }

        /// <summary>
        /// 记录修改时间
        /// </summary>
        [Column("UPDATE_ON")]
        [DataMember]
        [XmlIgnore]
        public DateTime UPDATE_ON { get; set; }

        private Page _page;
        /// <summary>
        /// 分页实体
        /// </summary>
        public Page page
        {
            get { return _page ?? new Page { PageSize = 10, CurrentPage = 1 }; }
            set { _page = value; }
        }
    }
}
