using Microsoft.Win32;
using System.Runtime.Versioning;

namespace CenterChangesManager.BLL.Global
{
    public static class clsGlobal
    {
        public static clsUser? CurrentUser;

        [SupportedOSPlatform("windows")]
        public static bool SaveLoginInfo(string username, string password)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CenterChangesManager"))
            {
                try
                {
                    key.SetValue("username", username);
                    //  key.SetValue("password", password);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        [SupportedOSPlatform("windows")]
        public static bool LoadLoginInfo(ref string username, string password)
        {
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CenterChangesManager"))
            {
                if (key != null)
                {
                    username = key.GetValue("username") as string ?? string.Empty;
                    //   password = key.GetValue("password") as string ?? string.Empty;
                    return true;
                }
                else
                {
                    username = string.Empty;
                    password = string.Empty;
                    return false;
                }
            }
        }

    }
}
