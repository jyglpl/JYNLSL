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
    public enum ScoreType
    {
        /// <summary>
        /// 请选择查询条件
        /// </summary>
        [Description("全部")]
        PleaseQuery = 0,

        /// <summary>
        /// 分值类型
        /// </summary>
        [Description("减分")]
        Deduction = -1,

        /// <summary>
        /// 加分
        /// </summary>
        [Description("加分")]
        AwardedMarks = 1
    }
}
