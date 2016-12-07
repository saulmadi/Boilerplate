using System;
using System.Configuration;

namespace Common
{
    public static class Configuration
    {
        public static string DataBase
        {
            get
            {
                const string database = "DataBase";
                var cs = ExtractConfiguration(database);


                return cs;
            }
        }

        private static string ExtractConfiguration(string appKey)
        {
            var configurationValue = ConfigurationManager.AppSettings[appKey] ??
                                     Environment.GetEnvironmentVariable(appKey);

            if (configurationValue != null) return configurationValue;

            throw new Exception(string.Format("The key {0} wasn't found in the app configuration", appKey));
        }
    }
}