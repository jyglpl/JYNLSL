using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.Attendance
{
    [TableName("Attendance")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class AttendanceEntity
    {
        /// <summary>
        /// 自增字段
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 所属单位Id
        /// </summary>
        [Column("CompanyId")]
        [DataMember]
        public string CompanyId { get; set; }

        /// <summary>
        /// 所属单位名称
        /// </summary>
        [Column("CompanyName")]
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// 所属部门Id
        /// </summary>
        [Column("DepartmentId")]
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        [Column("DepartmentName")]
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("UserId")]
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("UserName")]
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        [Column("ClockTime")]
        [DataMember]
        public DateTime? ClockTime { get; set; }

        /// <summary>
        /// 打卡地点
        /// </summary>
        [Column("ClockPlace")]
        [DataMember]
        public string ClockPlace { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Column("Longitude")]
        [DataMember]
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [Column("Latitude")]
        [DataMember]
        public string Latitude { get; set; }
    }
}
