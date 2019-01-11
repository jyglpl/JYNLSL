using System.ComponentModel;

namespace Yookey.WisdomClassed.SIP.Enumerate
{
    /// <summary>
    /// 状态分类
    /// </summary>
    public enum CaseStateType
    {
        /// <summary>
        /// 预审
        /// </summary>
        [Description("预审")]
        FirstTrial = 0,

        /// <summary>
        /// 待立案
        /// </summary>
        [Description("待立案")]
        Untreated = 1,

        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        InHand = 2,

        /// <summary>
        /// 待结案
        /// </summary>
        [Description("待结案")]
        StayClose = 3,

        /// <summary>
        /// 已结案
        /// </summary>
        [Description("已结案")]
        CloseJugee = 4,

        /// <summary>
        /// 已归档
        /// </summary>
        [Description("已归档")]
        Archived = 5,

        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 6
    }




    /// <summary>
    /// 查询类型
    /// </summary>
    public enum CaseQueryType
    {
        /// <summary>
        /// 请选择查询条件
        /// </summary>
        [Description("请选择查询条件")]
        PleaseQuery = 0,

        /// <summary>
        /// 案件编号
        /// </summary>
        [Description("案件编号")]
        CaseInfoNo = 1,

        /// <summary>
        /// 通知书编号
        /// </summary>
        [Description("通知书编号")]
        NoticeNo = 2,

        /// <summary>
        /// 当事人名称
        /// </summary>
        [Description("当事人名称")]
        TargetName = 3
    }

    /// <summary>
    /// 暂扣状态
    /// </summary>
    public enum TempDetainSate
    {
        /// <summary>
        /// 待入库0
        /// </summary>
        [Description("待入库")]
        ToInStorage = 0,


        /// <summary>
        /// 已入库1
        /// </summary>
        [Description("已入库")]
        InStorage = 1,

        /// <summary>
        /// 教育处理2
        /// </summary>
        [Description("教育处理")]
        HasReturned = 2,

        /// <summary>
        /// 移交其它部门3
        /// </summary>
        [Description("移交其它部门")]
        TransferDept = 3,
        /// <summary>
        /// 转入处罚4
        /// </summary>
        [Description("转入处罚")]
        ToPenaltyCase = 4,

        /// <summary>
        /// 处罚处理5
        /// </summary>
        [Description("处罚处理")]
        Punish = 5,
        /// <summary>
        /// 已发还6
        /// </summary>
        [Description("已发还")]
         ReturnTo = 6,



        /// <summary>
        /// 腐烂无价
        /// </summary>
        [Description("腐烂、无价")]
        DecayPriceless = 88,



    }

    /// <summary>
    /// 路面考核状态
    /// </summary>
    public enum AssessmentSate
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        Pending = 0,

        /// <summary>
        /// 处理中(指派)
        /// </summary>
        [Description("处理中")]
        Processing = 1,

        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Processed = 2,

        /// <summary>
        /// 已核查
        /// </summary>
        [Description("已核查")]
        Check = 3,
    }

    /// <summary>
    /// 队伍管理考核状态
    /// </summary>
    public enum TeamManagementSate
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        Pending = 0,

        /// <summary>
        /// 处理中(指派)
        /// </summary>
        [Description("处理中")]
        Processing = 1,

        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Processed = 2,

        /// <summary>
        /// 已核查
        /// </summary>
        [Description("已核查")]
        Check = 3,
    }
}
