using System.Configuration;
using Yookey.WisdomClassed.SIP.Common.Config;


namespace Yookey.WisdomClassed.SIP.Common
{
    public static class AppConfig
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public static string SystemName
        {
            get { return GeneralConfigs.GetConfig().SystemName; }
        }

        /// <summary>
        /// 天气预报接口
        /// </summary>
        public static string WearthService
        {
            get { return ConfigurationManager.AppSettings["WearthService"]; }
        }

        /// <summary>
        /// 网上课程附件打开地址
        /// </summary>
        public static string OnlineClassFileUrl
        {
            get { return ConfigurationManager.AppSettings["OnlineClassFileUrl"]; }
        }

        /// <summary>
        /// 网上课程附件存储地址
        /// </summary>
        public static string OnlineClassFileSave
        {
            get { return ConfigurationManager.AppSettings["OnlineClassFileSave"]; }
        }       

        /// <summary>
        /// 附件存储路径
        /// </summary>
        public static string FileSaveAddr
        {
            get { return GeneralConfigs.GetConfig().FileSaveAddr; }
        }

        /// <summary>
        /// 附件预览路径
        /// </summary>
        public static string FileViewLink
        {
            get { return GeneralConfigs.GetConfig().FileViewLink; }
        }

        /// <summary>
        /// 文书材料附件预览路径
        /// </summary>
        public static string FileWritViewLink
        {
            get { return GeneralConfigs.GetConfig().FileWritViewLink; }
        }

        /// <summary>
        /// 附件外网预览路径
        /// </summary>
        public static string FileViewOutNetLink
        {
            get { return GeneralConfigs.GetConfig().FileViewOutNetLink; }
        }

        /// <summary>
        /// 密码加密地址
        /// </summary>
        public static string PasswordDecode
        {
            get { return GeneralConfigs.GetConfig().PasswordDecode; }
        }

        /// <summary>
        /// 执法处案件受理室用户ID
        /// </summary>
        public static string AcceptCenterId
        {
            get { return GeneralConfigs.GetConfig().AcceptCenterId; }
        }

        /// <summary>
        /// 市容处部门ID
        /// </summary>
        public static string SrcDeptId
        {
            get { return GeneralConfigs.GetConfig().SrcDeptId; }
        }

        /// <summary>
        /// 承办人一
        /// </summary>
        public static string UdPersonalFirst
        {
            get { return GeneralConfigs.GetConfig().UdPersonalFirst; }
        }

        /// <summary>
        /// 承办人二
        /// </summary>
        public static string UdPersonalSecond
        {
            get { return GeneralConfigs.GetConfig().UdPersonalSecond; }
        }

        /// <summary>
        /// 分管副局长
        /// </summary>
        public static string DeputyDirector
        {
            get { return GeneralConfigs.GetConfig().DeputyDirector; }
        }

        /// <summary>
        /// 主管局长
        /// </summary>
        public static string Director
        {
            get { return GeneralConfigs.GetConfig().Director; }
        }

        /// <summary>
        /// 需要过滤的案由编号
        /// </summary>
        public static string KickItemNo
        {
            get { return GeneralConfigs.GetConfig().KickItemNo; }
        }

        /// <summary>
        /// 经伟度坐标转换
        /// </summary>
        public static string CoordinateConvert
        {
            get { return GeneralConfigs.GetConfig().CoordinateConvert.Replace("*", "&"); }
        }

        /// <summary>
        /// 内网IP
        /// </summary>
        public static string Intranet
        {
            get { return GeneralConfigs.GetConfig().Intranet; }
        }

        /// <summary>
        /// 外网IP
        /// </summary>
        public static string OutNet
        {
            get { return GeneralConfigs.GetConfig().OutNet; }
        }

        /// <summary>
        /// 是否启用短信
        /// </summary>
        public static bool IsEnableNote
        {
            get
            {
                var isEnable = GeneralConfigs.GetConfig().IsEnableNote;
                return isEnable == 1 ? true : false;
            }
        }

        /// <summary>
        /// 法律法规版本号
        /// </summary>
        public static int LegislationVersion
        {
            get { return GeneralConfigs.GetConfig().LegislationVersion; }
        }

        /// <summary>
        /// 市容处
        /// </summary>
        public static string SrPersonal
        {
            get { return GeneralConfigs.GetConfig().SrPersonal; }
        }

        /// <summary>
        /// 执法处人员二
        /// </summary>
        public static string ZfcPersonalSecond
        {
            get { return GeneralConfigs.GetConfig().ZfcPersonalSecond; }
        }

        /// <summary>
        /// 结案日期在处罚后N月
        /// </summary>
        public static int FinishMonth
        {
            get { return GeneralConfigs.GetConfig().FinishMonth; }
        }

        /// <summary>
        /// 图片存储服务链接地址
        /// </summary>
        public static string FileSaveServiceLink
        {
            get { return GeneralConfigs.GetConfig().FileSaveServiceLink; }
        }

        /// <summary>
        /// 图片存储服务器预览地址
        /// </summary>
        public static string FileSaveServiceViewLink
        {
            get { return GeneralConfigs.GetConfig().FileSaveServiceViewLink; }
        }

        #region 违章停车移交公安图片生成参数

        public static string SBCode { get { return GeneralConfigs.GetConfig().SBCode; } }
        public static string WFXW { get { return GeneralConfigs.GetConfig().WFXW; } }
        public static string FXJG { get { return GeneralConfigs.GetConfig().FXJG; } }
        public static string ZQMJ { get { return GeneralConfigs.GetConfig().ZQMJ; } }
        public static string GLDJ { get { return GeneralConfigs.GetConfig().GLDJ; } }
        public static string SCValue { get { return GeneralConfigs.GetConfig().SCValue; } }
        public static string BZValue { get { return GeneralConfigs.GetConfig().BZValue; } }
        public static string TZSBH { get { return GeneralConfigs.GetConfig().TZSBH; } }
        public static string CJFS { get { return GeneralConfigs.GetConfig().CJFS; } }
        public static string SBYH { get { return GeneralConfigs.GetConfig().SBYH; } }
        public static string Total { get { return GeneralConfigs.GetConfig().Total; } }
        public static string SN { get { return GeneralConfigs.GetConfig().SN; } }
        public static string Remark { get { return GeneralConfigs.GetConfig().Remark; } }
        public static string Ver { get { return GeneralConfigs.GetConfig().Ver; } }
        public static string Pwh { get { return GeneralConfigs.GetConfig().Pwh; } }
        public static int DayNum { get { return GeneralConfigs.GetConfig().DayNum; } }
        public static int DayYJ { get { return GeneralConfigs.GetConfig().DayYJ; } }

        #endregion

        /// <summary>
        /// 电子台账上传附件外网访问路径
        /// </summary>
        public static string LedgerFileViewOutNetLink
        {
            get { return GeneralConfigs.GetConfig().LedgerFileViewOutNetLink; }
        }

        /// <summary>
        /// 电子台账上传文件访问路径
        /// </summary>
        public static string LedgerFileViewLink
        {
            get { return GeneralConfigs.GetConfig().LedgerFileViewLink; }
        }

        /// <summary>
        /// 电子台账上传服务
        /// </summary>
        public static string LedgerFileServiceLink
        {

            get { return GeneralConfigs.GetConfig().LedgerFileServiceLink; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public static string ErrroLogAddress
        {
            get { return ConfigurationManager.AppSettings["ErrorLog"]; }
        }
        public static string UpDate
        {
            get { return ConfigurationManager.AppSettings["UpDate"]; }
        }
        public static string UpTime
        {
            get { return ConfigurationManager.AppSettings["UpTime"]; }
        }
        public static string TimerInterval
        {
            get { return ConfigurationManager.AppSettings["TimerInterval"]; }
        }

        public static string Path
        {
            get { return ConfigurationManager.AppSettings["path"]; }
        }
    }
}
