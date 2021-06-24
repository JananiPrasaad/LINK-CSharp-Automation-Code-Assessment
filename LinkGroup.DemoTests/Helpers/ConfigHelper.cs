using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LinkGroup.DemoTests.Helpers
{
    public class ConfigHelper
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configKey"></param>
        /// <returns></returns>
        public static string GetConfigValue(string configKey)
        {
            string configValue = string.Empty;
            if (ConfigurationManager.AppSettings[configKey] != null)
            {
                configValue = ConfigurationManager.AppSettings[configKey].ToString();
            }
            return configValue;
        }
        #endregion

        #region Private Methods
        #endregion

    }
}
