using System;

namespace Yookey.WisdomClassed.SIP.Common.Config
{
    /// <summary>
    /// 基本设置描述类, 加[Serializable]标记为可序列化
    /// </summary>
    [Serializable]
    public class GeneralConfigInfo : IConfigInfo
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }
        /// <summary>
        /// 附件存储路径
        /// </summary>
        public string FileSaveAddr { get; set; }

        /// <summary>
        /// 附件预览地址
        /// </summary>
        public string FileViewLink { get; set; }

        /// <summary>
        /// 文书材料
        /// </summary>
        public string FileWritViewLink { get; set; }

        /// <summary>
        /// 附件外网预览地址
        /// </summary>
        public string FileViewOutNetLink { get; set; }

        /// <summary>
        /// 文件下载地址
        /// </summary>
        public string FileUpLoad { get; set; }

        /// <summary>
        /// 文件下载物理路径
        /// </summary>
        public string FilePathLoad { get; set; }

        /// <summary>
        /// 密码加密地址
        /// </summary>
        public string PasswordDecode { get; set; }

        /// <summary>
        /// 执法处案件受理室ID
        /// </summary>
        public string AcceptCenterId { get; set; }

        /// <summary>
        /// 市容处部门Id
        /// </summary>
        public string SrcDeptId { get; set; }

        /// <summary>
        /// 承办人一
        /// </summary>
        public string UdPersonalFirst { get; set; }

        /// <summary>
        /// 承办人二
        /// </summary>
        public string UdPersonalSecond { get; set; }

        /// <summary>
        /// 分管副局长
        /// </summary>
        public string DeputyDirector { get; set; }

        /// <summary>
        /// 主管局长
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// 需要过滤的案由编号
        /// </summary>
        public string KickItemNo { get; set; }

        /// <summary>
        /// 经纬度坐标转换
        /// </summary>
        public string CoordinateConvert { get; set; }

        /// <summary>
        /// 内网IP
        /// </summary>
        public string Intranet { get; set; }

        /// <summary>
        /// 外网IP
        /// </summary>
        public string OutNet { get; set; }

        /// <summary>
        /// 是否启用短信
        /// </summary>
        public int IsEnableNote { get; set; }

        /// <summary>
        /// 法律法规版本号
        /// </summary>
        public int LegislationVersion { get; set; }

        /// <summary>
        /// 市容处
        /// </summary>
        public string SrPersonal { get; set; }

        /// <summary>
        /// 执法处人员二
        /// </summary>
        public string ZfcPersonalSecond { get; set; }

        /// <summary>
        /// 结案日期在处罚后N开
        /// </summary>
        public int FinishMonth { get; set; }

        /// <summary>
        /// 图片存储服务链接地址
        /// </summary>
        public string FileSaveServiceLink { get; set; }

        /// <summary>
        /// 图片存储服务器预览地址
        /// </summary>
        public string FileSaveServiceViewLink { get; set; }

        #region 违章停车移交公安图片生成参数

        public string SBCode { get; set; }
        public string WFXW { get; set; }
        public string FXJG { get; set; }
        public string ZQMJ { get; set; }
        public string GLDJ { get; set; }
        public string SCValue { get; set; }
        public string BZValue { get; set; }
        public string TZSBH { get; set; }
        public string CJFS { get; set; }
        public string SBYH { get; set; }
        public string Total { get; set; }
        public string SN { get; set; }
        public string Remark { get; set; }
        public string Ver { get; set; }
        public string Pwh { get; set; }
        public int DayNum { get; set; }
        public int DayYJ { get; set; }

        #endregion

        /// <summary>
        /// 电子台账上传附件外网访问路径
        /// </summary>
        public string LedgerFileViewOutNetLink { get; set; }

        /// <summary>
        /// 电子台账上传文件访问路径
        /// </summary>
        public string LedgerFileViewLink { get; set; }

        /// <summary>
        /// 电子台账服务存储链接地址
        /// </summary>
        public string LedgerFileServiceLink { get; set; }
    }
}
