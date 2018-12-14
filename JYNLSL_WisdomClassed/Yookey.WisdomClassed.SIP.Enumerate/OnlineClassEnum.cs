using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Enumerate
{
    /// <summary>
    /// 课件类型
    /// </summary>
    public enum CourseType
    {
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video = 1,

        /// <summary>
        /// 音频
        /// </summary>
        [Description("音频")]
        Voice = 2,

        /// <summary>
        /// 图文
        /// </summary>
        [Description("图文")]
        Political = 3,

        /// <summary>
        /// 下载
        /// </summary>
        [Description("下载")]
        Down = 4
    }


    /// <summary>
    /// 查询类型
    /// </summary>
    public enum CourseQueryType
    {
        /// <summary>
        /// 选修的课程
        /// </summary>
        [Description("选修的课程")]
        Electives = 1,

        /// <summary>
        /// 必修的课程
        /// </summary>
        [Description("必修的课程")]
        Required = 2,

        /// <summary>
        /// 已完成的课程
        /// </summary>
        [Description("已完成的课程")]
        Finish = 3
    }
}
