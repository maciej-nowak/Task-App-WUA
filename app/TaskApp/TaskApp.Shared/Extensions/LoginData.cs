using System;

namespace TaskApp.Extensions
{
    public static class LoginData
    {

        public static void SaveLogin(String login)
        {
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localSettings = applicationData.LocalSettings;
            localSettings.Values["login"] = login;
        }

        public static String ReadLogin()
        {
            String value = "";
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localSettings = applicationData.LocalSettings;
            if (localSettings.Values["login"] != null)
            {
                value = localSettings.Values["login"].ToString();
            }
            return value;
        }
    }
}

