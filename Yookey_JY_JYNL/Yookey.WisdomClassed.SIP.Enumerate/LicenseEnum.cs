using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Enumerate
{
    /// <summary>
    /// 状态分类
    /// </summary>
    public enum LicenseStateType
    {
        /// <summary>
        /// 待受理
        /// </summary>
        [Description("待受理")]
        Admissible = 0,

        /// <summary>
        /// 待踏勘
        /// </summary>
        [Description("待踏勘")]
        ToVisit = 1,

        /// <summary>
        /// 待审核
        /// </summary>
        [Description("审核中")]
        ToBeAudited = 2,

        /// <summary>
        /// 待办结
        /// </summary>
        [Description("待办结")]
        ToBeDone = -1,

        /// <summary>
        /// 已办结
        /// </summary>
        [Description("已办结")]
        HaveDone = 3,

        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 10
    }


    /// <summary>
    /// 查询类型
    /// </summary>
    public enum LicenseQueryType
    {
        /// <summary>
        /// 请选择查询条件
        /// </summary>
        [Description("请选择查询条件")]
        PleaseQuery = 0,

        /// <summary>
        /// 办件编号
        /// </summary>
        [Description("办件编号")]
        CaseInfoNo = 1,

        /// <summary>
        /// 申请人
        /// </summary>
        [Description("申请人")]
        TargetName = 2,

        /// <summary>
        /// 当事人名称
        /// </summary>
        [Description("设置地址")]
        Address = 3
    }

    /// <summary>
    /// 附件类型
    /// </summary>
    public enum LicenseAttachType
    {
        /// <summary>
        /// 案件材料目录附件
        /// </summary>
        [Description("案件材料目录附件")]
        Material=0,

        /// <summary>
        /// 现场检查附件
        /// </summary>
        [Description("现场检查附件")]
        CheckSpec=1
    }

    /// <summary>
    /// 现场检查里面的照片类型
    /// </summary>
    public enum LicenseCheckSpecType
    {
         /// <summary>
        /// 现场勘验附件
        /// </summary>
        [Description("现场勘验")]
        Prospect=0,

        /// <summary>
        /// 现场检查附件
        /// </summary>
        [Description("现场检查")]
        Check=1
    }
}
