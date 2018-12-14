//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CommonEnum.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03
//  功能描述：请一定在此描述类用途
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.ComponentModel;

namespace Yookey.WisdomClassed.SIP.Enumerate
{

    /// <summary>
    /// 用户登录返回状态
    /// </summary>
    public enum UserLoginStatus
    {
        /// <summary>
        /// 登陆账户不存在
        /// </summary>
        [Description("登陆账户不存在")]
        NotUser = -1,

        /// <summary>
        /// 登陆账户被系统锁定
        /// </summary>
        [Description("登陆账户被系统锁定")]
        UserLocked = 2,

        /// <summary>
        /// 无效
        /// </summary>
        [Description("登陆密码错误")]
        PasswordError = 4,

        /// <summary>
        /// 登陆验证成功
        /// </summary>
        [Description("登陆验证成功")]
        Sucess = 3,

        /// <summary>
        /// 登录异常
        /// </summary>
        [Description("登录异常")]
        Error = 0,

        /// <summary>
        /// 离开
        /// </summary>
        [Description("离开")]
        Leave = 5,

        /// <summary>
        /// 登录账户暂时被锁定
        /// </summary>
        [Description("登录账户暂时被锁定")]
        TemporaryLocked = 6
    }


    /// <summary>
    /// 行状态
    /// </summary>
    public enum RowStatus
    {
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 0,

        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Normal = 1,

        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 2
    }

    /// <summary>
    /// 附件用途
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 用户头像
        /// </summary>
        [Description("用户头像")]
        UserAvatar = 0,

        /// <summary>
        /// 文章图片
        /// </summary>
        [Description("文章图片")]
        ArticlePic = 1,

        /// <summary>
        /// 产品图片
        /// </summary>
        [Description("产品图片")]
        ProductPic = 2,

        /// <summary>
        /// 产品介绍图
        /// </summary>
        [Description("产品介绍图")]
        ProductDescPic = 3,
    }



    /// <summary>
    /// 消息类型
    /// </summary>
    public enum WorkListType
    {
        /// <summary>
        /// 未处理
        /// </summary>
        [Description("未处理")]
        Pending = 0,

        /// <summary>
        /// 已阅读
        /// </summary>
        [Description("已阅读")]
        Read = 1,

        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Processed = 2,

        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")]
        Delete = 3,
    }

    /// <summary>
    /// 公告通知类型
    /// </summary>
    public enum NoticeType
    {
        /// <summary>
        /// 一般通知
        /// </summary>
        [Description("一般通知")]
        Ordinary = 1,

        /// <summary>
        /// 紧急通知
        /// </summary>
        [Description("紧急通知")]
        Urgency = 0,

    }

    /// <summary>
    /// 公告通知置顶方式
    /// </summary>
    public enum NoticeTop
    {
        /// <summary>
        /// 紧急通知
        /// </summary>
        [Description("置顶")]
        Yes = 1,

        /// <summary>
        /// 一般通知
        /// </summary>
        [Description("不置顶")]
        No = 0
    }

    /// <summary>
    /// 操作状态
    /// </summary>
    public enum OperationState
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failure = 0,

        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Error = -1
    }
}
