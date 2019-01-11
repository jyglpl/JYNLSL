using System;

namespace Yookey.WisdomClassed.SIP.Common.Config
{
    /// <summary>
    /// ��������������, ��[Serializable]���Ϊ�����л�
    /// </summary>
    [Serializable]
    public class GeneralConfigInfo : IConfigInfo
    {
        /// <summary>
        /// ϵͳ����
        /// </summary>
        public string SystemName { get; set; }
        /// <summary>
        /// �����洢·��
        /// </summary>
        public string FileSaveAddr { get; set; }

        /// <summary>
        /// ����Ԥ����ַ
        /// </summary>
        public string FileViewLink { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string FileWritViewLink { get; set; }

        /// <summary>
        /// ��������Ԥ����ַ
        /// </summary>
        public string FileViewOutNetLink { get; set; }

        /// <summary>
        /// �ļ����ص�ַ
        /// </summary>
        public string FileUpLoad { get; set; }

        /// <summary>
        /// �ļ���������·��
        /// </summary>
        public string FilePathLoad { get; set; }

        /// <summary>
        /// ������ܵ�ַ
        /// </summary>
        public string PasswordDecode { get; set; }

        /// <summary>
        /// ִ��������������ID
        /// </summary>
        public string AcceptCenterId { get; set; }

        /// <summary>
        /// ���ݴ�����Id
        /// </summary>
        public string SrcDeptId { get; set; }

        /// <summary>
        /// �а���һ
        /// </summary>
        public string UdPersonalFirst { get; set; }

        /// <summary>
        /// �а��˶�
        /// </summary>
        public string UdPersonalSecond { get; set; }

        /// <summary>
        /// �ֹܸ��ֳ�
        /// </summary>
        public string DeputyDirector { get; set; }

        /// <summary>
        /// ���ֳܾ�
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// ��Ҫ���˵İ��ɱ��
        /// </summary>
        public string KickItemNo { get; set; }

        /// <summary>
        /// ��γ������ת��
        /// </summary>
        public string CoordinateConvert { get; set; }

        /// <summary>
        /// ����IP
        /// </summary>
        public string Intranet { get; set; }

        /// <summary>
        /// ����IP
        /// </summary>
        public string OutNet { get; set; }

        /// <summary>
        /// �Ƿ����ö���
        /// </summary>
        public int IsEnableNote { get; set; }

        /// <summary>
        /// ���ɷ���汾��
        /// </summary>
        public int LegislationVersion { get; set; }

        /// <summary>
        /// ���ݴ�
        /// </summary>
        public string SrPersonal { get; set; }

        /// <summary>
        /// ִ������Ա��
        /// </summary>
        public string ZfcPersonalSecond { get; set; }

        /// <summary>
        /// �᰸�����ڴ�����N��
        /// </summary>
        public int FinishMonth { get; set; }

        /// <summary>
        /// ͼƬ�洢�������ӵ�ַ
        /// </summary>
        public string FileSaveServiceLink { get; set; }

        /// <summary>
        /// ͼƬ�洢������Ԥ����ַ
        /// </summary>
        public string FileSaveServiceViewLink { get; set; }

        #region Υ��ͣ���ƽ�����ͼƬ���ɲ���

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
        /// ����̨���ϴ�������������·��
        /// </summary>
        public string LedgerFileViewOutNetLink { get; set; }

        /// <summary>
        /// ����̨���ϴ��ļ�����·��
        /// </summary>
        public string LedgerFileViewLink { get; set; }

        /// <summary>
        /// ����̨�˷���洢���ӵ�ַ
        /// </summary>
        public string LedgerFileServiceLink { get; set; }
    }
}
