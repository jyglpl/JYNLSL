using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.GridManagement
{
    /// <summary>
    /// 电子台账文件夹设置实体
    /// </summary>
    [TableName("GridManagementInfo")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class GridManagementInfoEntity : BaseEntity
    {
        /// <summary>
        /// 父主键
        /// </summary>
        [Column("ParentId")]
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// 网格编号
        /// </summary>
        [Column("GMCode")]
        [DataMember]
        public string GmCode { get; set; }

        /// <summary>
        /// 网格名称
        /// </summary>
        [Column("GMName")]
        [DataMember]
        public string GmName { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        [Column("SortCode")]
        [DataMember]
        public int SortCode { get; set; }

        /// <summary>
        /// 是否公共使用，1：通用  0：不通用
        /// </summary>
        [Column("CommanUseStatus")]
        [DataMember]
        public int CommanUseStatus { get; set; }

        /// <summary>
        /// 组织结构ID	通用的ID为0
        /// </summary>
        [Column("CompanyId")]
        [DataMember]
        public string CompanyId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Column("DeptId")]
        [DataMember]
        public string DeptId { get; set; }

        /// <summary>
        /// 文件类型，1：区局  0：大/中队
        /// </summary>
        [Column("GMType")]
        [DataMember]
        public int GMType { get; set; }

        #region 辅助字段

        /// <summary>
        /// 子集数量
        /// </summary>
        public int ChildCount { get; set; }

        #endregion
    }
}
