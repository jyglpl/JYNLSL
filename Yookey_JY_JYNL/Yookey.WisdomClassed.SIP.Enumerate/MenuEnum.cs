using System.ComponentModel;

namespace Yookey.WisdomClassed.SIP.Enumerate
{
    /// <summary>
    /// 菜单级别
    /// </summary>
    public enum MenuLevel
    {
        /// <summary>
        /// 一级菜单
        /// </summary>
        [Description("一级菜单")]
        First = 1,

        /// <summary>
        /// 二级菜单
        /// </summary>
        [Description("二级菜单")]
        Second = 2,

        /// <summary>
        /// 三级菜单
        /// </summary>
        [Description("三级菜单")]
        Third = 3,

        /// <summary>
        /// 四级菜单
        /// </summary>
        [Description("四级菜单")]
        Fourth = 4
    }

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu = 1,

        /// <summary>
        /// 功能
        /// </summary>
        [Description("功能")]
        Action = 0
    }

    /// <summary>
    /// 功能类型
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Insert = 1,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Update = 2,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 3,

        /// <summary>
        /// 查询
        /// </summary>
        [Description("查询")]
        Select = 4
    }


    /// <summary>
    /// 菜单打开方式
    /// </summary>
    public enum OpenType
    {
        /// <summary>
        /// 新标签
        /// </summary>
        [Description("新标签")]
        Insert = 1,

        /// <summary>
        /// 弹出
        /// </summary>
        [Description("弹出")]
        Update = 2,

        /// <summary>
        /// 内嵌
        /// </summary>
        [Description("内嵌")]
        Delete = 3
    }

    public enum Source
    {
        /// <summary>
        /// 请选择
        /// </summary>
        [Description("请选择")]
        Zero = 0,

        /// <summary>
        /// 执法业务处理
        /// </summary>
        [Description("执法业务处理")]
        One = 1,

        /// <summary>
        /// 执法日常处理
        /// </summary>
        [Description("执法日常处理")]
        Two = 2,

        /// <summary>
        /// 执法日常办公
        /// </summary>
        [Description("执法日常办公")]
        Three = 3
    }
}
