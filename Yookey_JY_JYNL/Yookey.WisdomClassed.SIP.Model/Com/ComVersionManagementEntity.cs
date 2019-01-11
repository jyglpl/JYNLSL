using PetaPoco;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    [TableName("ComVersionManagement")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class ComVersionManagementEntity : BaseEntity
    {
        /// <summary>
        /// 更新名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 版本序列号：系统自动获取上个版本累加1
        /// </summary>
        [Column("VersionNo")]
        public int VersionNo { get; set; }

        /// <summary>
        /// 文件版本号
        /// </summary>
        [Column("FileVersion")]
        public string FileVersion { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [Column("FileUrl")]
        public string FileUrl { get; set; }

        /// <summary>
        /// 更新内容
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// APP类型：1IOS 2Android
        /// </summary>
        [Column("MobileType")]
        public int MobileType { get; set; }
    }
}