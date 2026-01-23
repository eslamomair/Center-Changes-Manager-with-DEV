namespace CenterChangesManager.BLL.Global
{
    public class clsPermissions
    {
        [Flags]
        public enum enPermissions
        {
            None = 0,
            AddVariable = 1,          // 1
            EditVariable = 2,         // 2
            DeleteVariable = 4,       // 4
            ViewReports = 8,          // 8
            ExportData = 16,          // 16
            DeleteAttachments = 32,   // 32
            ManageUsers = 64,         // 64
            EditPermissions = 128,    // 128
            DeleteUser = 256,         // 256
            All = -1                  // المدير العام
        }

        //public static bool ApplyMainMenuPermissions()
        //{
        //    if (!CheckAccess(ConvertFromInt(clsGlobal.CurrentUser.UserData.Permession), enPermissions.ExportData))
        //    {
        //        return false;
        //    }
        //    if (!CheckAccess(ConvertFromInt(clsGlobal.CurrentUser.UserData.Permession), enPermissions.AddNewChange))
        //    {
        //        return false;
        //    }
        //    if (!CheckAccess(ConvertFromInt(clsGlobal.CurrentUser.UserData.Permession), enPermissions.UpdateChange))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public static bool CheckAccess(enPermissions userPermission, enPermissions requiredPermission)
        {
            if (userPermission == enPermissions.All)
            {
                return true;
            }

            if ((requiredPermission & userPermission) == requiredPermission)
                return true;
            return false;
        }

        public static enPermissions ConvertFromInt(int permissionsValue)
        {
            return (enPermissions)permissionsValue;
        }


        public static bool ChekAccess(enPermissions RequiredPermission)
        {
            if (CheckAccess(ConvertFromInt(clsGlobal.CurrentUser.UserData.Permession), RequiredPermission))
            {

                return true;
            }
            return false;
        }

    }
}
