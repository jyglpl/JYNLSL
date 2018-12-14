using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Enumerate
{
    /// <summary>
    /// 是否阅卷
    /// </summary>
    public enum ExamReadType
    {
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        ReadDisable = 0,

        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        ReadEnable = 1,
    }

    /// <summary>
    /// 允许立即得分
    /// </summary>
    public enum ExamScoreType
    {
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        GetScore = 0,

        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        GetNotScore = 1,
    }
    /// <summary>
    /// 试题类型
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// ---请选择---
        /// </summary>
        [Description("---请选择---")]
        Type = 0,

        /// <summary>
        /// 单选题
        /// </summary>
        [Description("单选题")]
        TypeDan = 00290001,

        /// <summary>
        /// 多选题
        /// </summary>
        [Description("多选题")]
        TypeDuo = 00290002,

        /// <summary>
        /// 判断题
        /// </summary>
        [Description("判断题")]
        TypePan = 00290003,

        /// <summary>
        /// 分析题
        /// </summary>
        [Description("分析题")]
        TypeFen = 00290004,

        /// <summary>
        /// 作文题
        /// </summary>
        [Description("作文题")]
        TypeZuo = 00290005,

        /// <summary>
        /// 论述题
        /// </summary>
        [Description("论述题")]
        TypeLun = 00290006,

        /// <summary>
        /// 填空题
        /// </summary>
        [Description("填空题")]
        TypeTian = 00290007,

        /// <summary>
        /// 简答题
        /// </summary>
        [Description("简答题")]
        TypeJian = 00290008,
    }

    /// <summary>
    /// 难易度
    /// </summary>
    public enum Difficulty
    {
        /// <summary>
        /// ---请选择---
        /// </summary>
        [Description("---请选择---")]
        DifficultyLevel = 0,

        /// <summary>
        /// 难
        /// </summary>
        [Description("难")]
        Difficult = 001,

        /// <summary>
        /// 较难
        /// </summary>
        [Description("较难")]
        Harder = 002,

        /// <summary>
        /// 中等
        /// </summary>
        [Description("中等")]
        Medium = 003,

        /// <summary>
        /// 较易
        /// </summary>
        [Description("较易")]
        MoreEasily = 004,

        /// <summary>
        /// 容易
        /// </summary>
        [Description("容易")]
        Easy = 005,
    }

    /// <summary>
    /// 选项
    /// </summary>
    public enum Options
    {
        /// <summary>
        /// A
        /// </summary>
        [Description("A")]
        OptionA = 0,

        /// <summary>
        /// B
        /// </summary>
        [Description("B")]
        OptionB = 1,

        /// <summary>
        /// C
        /// </summary>
        [Description("C")]
        OptionC = 2,

        /// <summary>
        /// D
        /// </summary>
        [Description("D")]
        OptionD = 3,

        /// <summary>
        /// E
        /// </summary>
        [Description("")]
        OptionE = 4,

        /// <summary>
        /// F
        /// </summary>
        [Description("")]
        OptionF = 5,

        /// <summary>
        /// G
        /// </summary>
        [Description("")]
        OptionG = 6,

        /// <summary>
        /// H
        /// </summary>
        [Description("")]
        OptionH = 7,
    }

    /// <summary>
    /// 奖惩
    /// </summary>
    public enum IsReward
    {
        /// <summary>
        /// 扣分
        /// </summary>
        [Description("扣分")]
        Punishment = 0,

        /// <summary>
        /// 加分
        /// </summary>
        [Description("加分")]
        Reward = 1,

        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 3,
    }}
