namespace CenterChangesManager.BLL.Global
{
    public class clsPermissions
    {
        [Flags]
        public enum enPermissions
        {
            None = 0,
            AddVariable = 1 << 0,          // 1
            EditVariable = 1 << 1,         // 2
            DeleteVariable = 1 << 2,       // 4
            ViewReports = 1 << 3,         // 8
            ExportData = 1 << 4,          // 16
            DeleteAttachments = 1 << 5,   // 32
            ManageUsers = 1 << 6,         // 64
            EditPermissions = 1 << 7,    // 128
            DeleteUser = 1 << 8,         // 256
            All = AddVariable | EditVariable | DeleteVariable | ViewReports
        | ExportData | DeleteAttachments | ManageUsers | EditPermissions | DeleteUser// المدير العام
        }



        public static bool CheckAccess(enPermissions userPermission, enPermissions requiredPermission)
        {
            return (userPermission & requiredPermission) == requiredPermission;
        }

        // تحويل الرقم القادم من DB مع فلترة آمنة
        public static enPermissions ConvertFromInt(int permissionsValue)
        {
            return (enPermissions)permissionsValue & enPermissions.All;
        }

        // التحقق باستخدام المستخدم الحالي
        public static bool CheckAccess(enPermissions RequiredPermission)
        {
            return CheckAccess(
                ConvertFromInt(clsGlobal.CurrentUser.UserData.Permession),
                RequiredPermission
            );
        }

    }
}
