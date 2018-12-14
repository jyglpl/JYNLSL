//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AppConst.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03
//  功能描述：系统常量
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

namespace Yookey.WisdomClassed.SIP.Common
{
    public class AppConst
    {
        public const string DecimalFormat = "#########0.00";
        public const string DecimalFormatLong = "#########0.000";
        public const string DecimalFormatWithGroup = "#,###,###,##0.00";
        public const string DecimalFormatWithCurrency = "￥#########0.00";

        /// <summary>
        /// DateFormat = "yyyy-MM-dd"
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd";
        /// <summary>
        /// DateFormatLong = "yyyy-MM-dd HH:mm:ss"
        /// </summary>
        public const string DateFormatLong = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 用户姓名Cookie
        /// </summary>
        public const string LoginUserNameCookieName = "WisdomClassedAccountName";

        /// <summary>
        /// 用户密码Cookie
        /// </summary>
        public const string LoginUserCookiePwd = "WisdomClassedAccountPwd";

        /// <summary>
        /// 用户主题风格Cookie
        /// </summary>
        public const string Uitheme = "UItheme";

        /// <summary>
        /// 加密 Key
        /// </summary>
        public const string EncryptKey = "YookeySZ";

        /// <summary>
        ///一般案件内部编号
        /// </summary>
        public const string NumPunishCase = "00300001";

        /// <summary>
        /// 简易案件决定书编号
        /// </summary>
        public const string NumSimpleDecision = "00300002";

        /// <summary>
        /// 排班生成流水号
        /// </summary>
        public const string NumFlight = "00300003";

        /// <summary>
        /// 暂扣流水号
        /// </summary>
        public const string NumTempZq = "00300004";

        /// <summary>
        /// 先行登记流水号
        /// </summary>
        public const string NumTempXx = "00300005";


        /// <summary>
        /// 违停流水号
        /// </summary>
        public const string NumWt = "00300006";

        /// <summary>
        /// 许可户外广告
        /// </summary>
        public const string XkGg = "00300007";

        /// <summary>
        /// 许可临时占道
        /// </summary>
        public const string XkZd = "00300008";

        /// <summary>
        /// 许可道路开挖
        /// </summary>
        public const string XkKw = "00300009";

        /// <summary>
        /// 查封
        /// </summary>
        public const string NumSealUp = "00300010";


        /// <summary>
        /// 国土一般案件内部编号
        /// </summary>
        public const string NumPunishCaseLand = "00300012";


        #region 量化积分项

        /// <summary>
        /// 一般案件
        /// </summary>
        public const string UpLoadPunishCase = "一般案件";

        /// <summary>
        /// 简易案件
        /// </summary>
        public const string UpLoadSimpleCase = "简易案件";

        /// <summary>
        /// 违法停车
        /// </summary>
        public const string UpLoadCheckCar = "违法停车";

        /// <summary>
        /// 流动摊贩
        /// </summary>
        public const string UpLoadStall = "流动摊贩";

        /// <summary>
        /// 事部件上报
        /// </summary>
        public const string UpLoadDsfxc = "事部件上报";

        /// <summary>
        /// 事部件处置
        /// </summary>
        public const string HandleDsfxc = "事部件处置";

        /// <summary>
        /// 案件预审
        /// </summary>
        public const string CaseFistCheck = "案件预审";

        /// <summary>
        /// 案件受理
        /// </summary>
        public const string CaseHandle = "案件受理";

        /// <summary>
        /// 立案审批
        /// </summary>
        public const string CaseFiled = "立案审批";

        /// <summary>
        /// 处理审批
        /// </summary>
        public const string CaseDealWith = "处理审批";

        /// <summary>
        /// 出具告知书
        /// </summary>
        public const string CaseInform = "出具告知书";

        /// <summary>
        /// 出具决定书
        /// </summary>
        public const string CaseDecision = "出具决定书";

        /// <summary>
        /// 结案审批
        /// </summary>
        public const string CaseEnd = "结案审批";

        /// <summary>
        /// 案件归档
        /// </summary>
        public const string CaseArchive = "案件归档";

        /// <summary>
        /// 调查询问地址（城管大厦）
        /// </summary>
        public const string SurveyAddress = "苏州工业园区南施街233号";

        /// <summary>
        /// 国土监察调查询问地址
        /// </summary>
        public const string LandSurveyAddress = "苏州工业园区现代大厦6楼询问室二";

        #endregion


        #region 违法建设拆除结算

        //封墙单价
        public const int WailOnPrice = 164;

        //人工单价
        public const int ManpowerOnPrice = 300;

        //拆除单价
        public const int DismantleOnPrice = 79;

        //拆窗单价
        public const int SecurityWindowOnPrice = 80;

        //垃圾车单价
        public const int GarbageCarOnPrice = 275;



        #endregion

        /// <summary>
        /// 局长室部门ID
        /// </summary>
        public const string DirectorDeptId = "98c88f4f-6250-492b-bae1-8c792a7734dd";

        /// <summary>
        /// 常规图片后缀
        /// </summary>
        public const string PictureExt = "*.jpg;*.jpeg;*.gif;*.png;";


        #region 一般案件类型（条线）

        /// <summary>
        /// 城市管理
        /// </summary>
        public const string CaseTypeCityManagement = "00950001";

        /// <summary>
        /// 国土监查
        /// </summary>
        public const string CaseTypeLand = "00950002";

        #endregion
    }
}
