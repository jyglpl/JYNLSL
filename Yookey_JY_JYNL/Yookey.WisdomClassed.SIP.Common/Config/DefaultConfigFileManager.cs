using System;

namespace Yookey.WisdomClassed.SIP.Common.Config
{
    /// <summary>
    /// �ļ����ù������
    /// </summary>
    public class DefaultConfigFileManager
    {
        /// <summary>
        /// �ļ�����·������
        /// </summary>
        private static string m_configfilepath;

        /// <summary>
        /// ��ʱ���ö������
        /// </summary>
        private static IConfigInfo m_configinfo = null;

        /// <summary>
        /// ������
        /// </summary>
        private static object m_lockHelper = new object();


        /// <summary>
        /// �ļ�����·��
        /// </summary>
        public static string ConfigFilePath
        {
            get { return m_configfilepath; }
            set { m_configfilepath = value; }
        }


        /// <summary>
        /// ��ʱ���ö���
        /// </summary>
        public static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set { m_configinfo = value; }
        }

        /// <summary>
        /// ����(�����л�)ָ���������͵����ö���
        /// </summary>
        /// <param name="fileoldchange">�ļ�����ʱ��</param>
        /// <param name="configFilePath">�����ļ�����·��</param>
        /// <param name="configinfo">��Ӧ�ı��� ע:�ò�����Ҫ��������m_configinfo���� �� ��ȡ����.GetType()</param>
        /// <returns></returns>
        protected static IConfigInfo LoadConfig(ref DateTime fileoldchange, string configFilePath, IConfigInfo configinfo)
        {
            return LoadConfig(ref fileoldchange, configFilePath, configinfo, true);
        }


        /// <summary>
        /// ����(�����л�)ָ���������͵����ö���
        /// </summary>
        /// <param name="fileoldchange">�ļ�����ʱ��</param>
        /// <param name="configFilePath">�����ļ�����·��(�����ļ���)</param>
        /// <param name="configinfo">��Ӧ�ı��� ע:�ò�����Ҫ��������m_configinfo���� �� ��ȡ����.GetType()</param>
        /// <param name="checkTime">�Ƿ��鲢���´��ݽ�����"�ļ�����ʱ��"����</param>
        /// <returns></returns>
        protected static IConfigInfo LoadConfig(ref DateTime fileoldchange, string configFilePath, IConfigInfo configinfo, bool checkTime)
        {
            lock (m_lockHelper)
            {
                m_configfilepath = configFilePath;
                m_configinfo = configinfo;

                if (checkTime)
                {
                    DateTime m_filenewchange = System.IO.File.GetLastWriteTime(configFilePath);

                    //������������config�ļ������仯ʱ���config���¸�ֵ
                    if (fileoldchange != m_filenewchange)
                    {
                        fileoldchange = m_filenewchange;
                        m_configinfo = DeserializeInfo(configFilePath, configinfo.GetType());
                    }
                }
                else
                    m_configinfo = DeserializeInfo(configFilePath, configinfo.GetType());

                return m_configinfo;
            }
        }


        /// <summary>
        /// �����л�ָ������
        /// </summary>
        /// <param name="configfilepath">config �ļ���·��</param>
        /// <param name="configtype">��Ӧ������</param>
        /// <returns></returns>
        public static IConfigInfo DeserializeInfo(string configfilepath, Type configtype)
        {
            return (IConfigInfo)SerializationHelper.Load(configtype, configfilepath);
        }

        /// <summary>
        /// ��������ʵ��(�鷽����̳�)
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveConfig()
        {
            return true;
        }

        /// <summary>
        /// ����(���л�)ָ��·���µ������ļ�
        /// </summary>
        /// <param name="configFilePath">ָ���������ļ����ڵ�·��(�����ļ���)</param>
        /// <param name="configinfo">������(���л�)�Ķ���</param>
        /// <returns></returns>
        public bool SaveConfig(string configFilePath, IConfigInfo configinfo)
        {
            return SerializationHelper.Save(configinfo, configFilePath);
        }
    }
}
