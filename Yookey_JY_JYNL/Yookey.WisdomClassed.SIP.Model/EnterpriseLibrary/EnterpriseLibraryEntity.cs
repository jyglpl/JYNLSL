using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetaPoco;

namespace Yookey.WisdomClassed.SIP.Model.EnterpriseLibrary
{
    /// <summary>
    /// add by lpl
    /// 2019-1-10
    /// 经营单位表
    /// </summary>
    [TableName("dbo.EnterpriseLibrary")]
    [PrimaryKey("Id", AutoIncrement = false)]
    [ExplicitColumns]
    public class EnterpriseLibraryEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 监管对象类型
        /// </summary>
        [Column("CompanyType")]
        [DataMember]
        public string CompanyType { get; set; }
        /// <summary>
        /// 监管对象性质
        /// </summary>
        [Column("CompanyNature")]
        [DataMember]
        public string CompanyNature { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        [Column("CompanyNum")]
        [DataMember]
        public string CompanyNum { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [Column("CompanyName")]
        [DataMember]
        public string CompanyName { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Column("CompanyCardNum")]
        [DataMember]
        public string CompanyCardNum { get; set; }
        /// <summary>
        /// 许可证
        /// </summary>
        [Column("CompanyPermitNum")]
        [DataMember]
        public string CompanyPermitNum { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        [Column("CompanyStreet")]
        [DataMember]
        public string CompanyStreet { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Column("CompanyAddress")]
        [DataMember]
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 法人/负责人姓名
        /// </summary>
        [Column("CompanyLegalPerson")]
        [DataMember]
        public string CompanyLegalPerson { get; set; }
        /// <summary>
        /// 法人电话
        /// </summary>
        [Column("LegalPersonPhone")]
        [DataMember]
        public string LegalPersonPhone { get; set; }
        /// <summary>
        /// 办公电话
        /// </summary>
        [Column("Phone")]
        [DataMember]
        public string Phone { get; set; }
        /// <summary>
        /// 企业联系人
        /// </summary>
        [Column("CompanyContacts")]
        [DataMember]
        public string CompanyContacts { get; set; }
        /// <summary>
        /// 是否重点监管
        /// </summary>
        [Column("IsImportant")]
        [DataMember]
        public string IsImportant { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        [Column("ProductType")]
        [DataMember]
        public string ProductType { get; set; }
        /// <summary>
        /// 企业规模
        /// </summary>
        [Column("CompanySize")]
        [DataMember]
        public string CompanySize { get; set; }
        /// <summary>
        /// 行状态：0：删除，1：正常
        /// </summary>
        [Column("Rowstatus")]
        [DataMember]
        public int? Rowstatus { get; set; }
    }
}
