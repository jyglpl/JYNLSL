namespace Yookey.WisdomClassed.SIP.Common.Config
{
    public interface IConfigInfo
    {
    }
    public class BaseConfig
    {
        public static void InitConfig()
        {
            GeneralConfigs.GetConfig();
        }
    }
}
