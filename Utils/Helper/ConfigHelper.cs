using System.Configuration;

namespace Utils
{
   public  class ConfigHelper
    {
        #region   基础参数
        private static System.Configuration.Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #endregion

        /// <summary>
        /// 添加键和对应值
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="value">键的值</param>
        /// <returns>返回结果（true:表示成功）</returns>
        public  static bool AddAppSetting(string key, string value) {
            if (string.IsNullOrEmpty(key)) return false;

            _config.AppSettings.Settings.Remove(key);
            _config.AppSettings.Settings.Add(key, value);
            _config.Save();

            return true;
        }

        /// <summary>
        /// 删除键和对应的值
        /// </summary>
        /// <param name="key">键的名称</param>
        /// <returns>返回结果（true:表示成功）</returns>
        public static bool DelAppSetting(string key) {
            if (string.IsNullOrEmpty(key)) return false;

            _config.AppSettings.Settings.Remove(key);
            _config.Save();
            return true;
        }

        /// <summary>
        /// 获取到键对应的值
        /// </summary>
        /// <param name="key">键名称</param>
        /// <returns>返回键对应的值</returns>
        public static string GetAppSetting(string key) {
            return _config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// 修改键和对应的值
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="value">键的值</param>
        /// <returns>返回结果（true:表示成功）</returns>
        public static bool UpdateAppSetting(string key, string value) {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return false;

            _config.AppSettings.Settings.Remove(key);
            _config.AppSettings.Settings.Add(key, value);

            _config.Save();

            return true;
        }


        /// <summary>
        /// 获取到AppSettings下的所有配置信息
        /// </summary>
        /// <returns>返回App.config下的appSettings下的所有配置信息</returns>
        public static KeyValueConfigurationCollection GetAllAppSettings() {
            return _config.AppSettings.Settings;

        }

        /// <summary>
        /// 获取ConnectionStrings下的键对应的连接字符串
        /// </summary>
        /// <param name="key">键名称</param>
        /// <returns>连接字符串</returns>
        public static string GetConnString(string key) {
            if (_config!=null) {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            else {
                return null;
            }
        }

    }//Class_end

}