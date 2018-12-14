namespace Yookey.WisdomClassed.SIP.Common.Config
{
    /// <summary>
    /// ����������
    /// </summary>
    public class GeneralConfigs
    {
        private static object lockHelper = new object();

        //private static System.Timers.Timer generalConfigTimer = new System.Timers.Timer(1 * 1000);

        private static GeneralConfigInfo m_configinfo;

        /// <summary>
        /// ��̬���캯����ʼ����Ӧʵ���Ͷ�ʱ��
        /// </summary>
        static GeneralConfigs()
        {
            m_configinfo = GeneralConfigFileManager.LoadConfig();

            //generalConfigTimer.AutoReset = true;
            //generalConfigTimer.Enabled = true;
            //generalConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            //generalConfigTimer.Start();
        }

        //private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    ResetConfig();
        //}

        /// <summary>
        /// ����������ʵ��
        /// </summary>
        public static void ResetConfig()
        {
            m_configinfo = GeneralConfigFileManager.LoadConfig();
        }

        public static GeneralConfigInfo GetConfig()
        {
            return GeneralConfigFileManager.LoadConfig();
        }

        /// <summary>
        /// ����������ʵ��
        /// </summary>
        /// <param name="generalconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(GeneralConfigInfo generalconfiginfo)
        {
            GeneralConfigFileManager gcf = new GeneralConfigFileManager();
            GeneralConfigFileManager.ConfigInfo = generalconfiginfo;
            return gcf.SaveConfig();
        }



        #region Helper

        /// <summary>
        /// ���л�������ϢΪXML
        /// </summary>
        /// <param name="configinfo">������Ϣ</param>
        /// <param name="configFilePath">�����ļ�����·��</param>
        public static GeneralConfigInfo Serialiaze(GeneralConfigInfo configinfo, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(configinfo, configFilePath);
            }
            return configinfo;
        }


        public static GeneralConfigInfo Deserialize(string configFilePath)
        {
            return (GeneralConfigInfo)SerializationHelper.Load(typeof(GeneralConfigInfo), configFilePath);
        }

        #endregion
    }
}
