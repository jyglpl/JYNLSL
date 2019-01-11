using System;
using System.IO;
using System.Web;

namespace Yookey.WisdomClassed.SIP.Common.Config
{
    /// <summary>
    /// �������ù�����
    /// </summary>
    class GeneralConfigFileManager : DefaultConfigFileManager
    {
        private static GeneralConfigInfo m_configinfo;


        /// <summary>
        /// �ļ��޸�ʱ��
        /// </summary>
        private static DateTime m_fileoldchange;


        /// <summary>
        /// ��ʼ���ļ��޸�ʱ��Ͷ���ʵ��
        /// </summary>
        static GeneralConfigFileManager()
        {
            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);

            try
            {
                m_configinfo = (GeneralConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(GeneralConfigInfo));
            }
            catch
            {
                if (File.Exists(ConfigFilePath))
                {
                    ReviseConfig();
                    m_configinfo = (GeneralConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(GeneralConfigInfo));
                }
            }
        }

        /// <summary>
        /// �˺�����Ϊ������Ҫ
        /// </summary>
        private static void ReviseConfig()
        {
            
        }

        /// <summary>
        /// ��ǰ�������ʵ��
        /// </summary>
        public new static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set { m_configinfo = (GeneralConfigInfo)value; }
        }

        /// <summary>
        /// �����ļ�����·��
        /// </summary>
        public static string filename = null;


        /// <summary>
        /// ��ȡ�����ļ�����·��
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        string path = context.Server.MapPath("~/");
                        filename = path + "/config/general.config";
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/general.config");
                    }
                }

                return filename;
            }

        }

        /// <summary>
        /// ����������ʵ��
        /// </summary>
        /// <returns></returns>
        public static GeneralConfigInfo LoadConfig()
        {

            try
            {
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, true);
            }
            catch
            {
                ReviseConfig();
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, true);
            }
            return ConfigInfo as GeneralConfigInfo;
        }

        /// <summary>
        /// ����������ʵ��
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}
