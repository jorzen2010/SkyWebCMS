using System;
using System.Configuration;

namespace Dal
{
    public static class ConfigManager
    {
        readonly static bool _Error;

        static Configuration _AppConfig;

        static ConfigManager()
        {
            string dllPath = string.Format(
                "{0}\\{1}.dll", AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "SkyWebCMS.Config");

            try
            {
                _AppConfig = ConfigurationManager.OpenExeConfiguration(dllPath);
            }
            catch (ConfigurationErrorsException)
            {
                _Error = true;
            }
        }

        public static KeyValueConfigurationCollection AppSettings
        {
            get
            {
                if (_Error) return null;
                return _AppConfig.AppSettings.Settings;
            }
        }

        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                if (_Error) return null;
                return _AppConfig.ConnectionStrings.ConnectionStrings;
            }
        }
    }
}