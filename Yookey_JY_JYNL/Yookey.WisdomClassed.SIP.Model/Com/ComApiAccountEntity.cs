using PetaPoco;
using Yookey.WisdomClassed.SIP.Model.Base;
namespace Yookey.WisdomClassed.SIP.Model.Com
{
    [TableName("COMAPIACCOUNT")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class ComApiAccountEntity : BaseEntity
    {
        /// <summary>
        /// 帐号名称
        /// </summary>
        [Column("ACCOUNTNAME")]
        public string ACCOUNTNAME { get; set; }

        /// <summary>
        /// 接口帐号
        /// </summary>
        [Column("ACCOUNTID")]
        public string ACCOUNTID { get; set; }

        /// <summary>
        /// 接口密码
        /// </summary>
        [Column("PASSWORD")]
        public string PASSWORD { get; set; }

        /// <summary>
        /// 加密令牌
        /// </summary>
        [Column("DESTOKEN")]
        public string DESTOKEN { get; set; }

        /// <summary>
        /// -
        /// </summary>
        [Column("REMARK")]
        public string REMARK { get; set; }
    }
}