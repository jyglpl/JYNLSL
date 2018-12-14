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
    /// 电子台账文件上传实体
    /// </summary>
    [TableName("GridManagementFileInfo")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class GridManagementFileInfoEntity : BaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [Column("GMFileName")]
        [DataMember]
        public string GmFileName { get; set; }

        /// <summary>
        /// 文件描述
        /// </summary>
        [Column("GMFileDescribe")]
        [DataMember]
        public string GmFileDescribe { get; set; }

        /// <summary>
        /// 是否可下载默认为true ，1：可  0;不可
        /// </summary>
        [Column("FileDown")]
        [DataMember]
        public int FileDown { get; set; }

        /// <summary>
        /// 是否可删除默认为true ，1：可  0;不可
        /// </summary>
        [Column("FileDel")]
        [DataMember]
        public int FileDel { get; set; }

        /// <summary>
        /// 文件存放相对地址
        /// </summary>
        [Column("FileURL")]
        [DataMember]
        public string FileUrl { get; set; }


        /// <summary>
        /// 转换后文件存放相对地址
        /// </summary>
        [Column("ConvertFileURL")]
        [DataMember]
        public string ConvertFileUrl { get; set; }

        /// <summary>
        /// 组织结构ID
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
        /// 网格菜单ID
        /// </summary>
        [Column("GMId")]
        [DataMember]
        public string GmId { get; set; }


        #region 辅助字段

        /// <summary>
        /// 单位名称
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion
    }
}
