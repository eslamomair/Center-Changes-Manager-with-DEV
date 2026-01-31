using CenterChangesManager.Common;
using CenterChangesManager.DAL;
namespace CenterChangesManager.BLL
{
    public class clsUser
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode { get; private set; } = enMode.AddNew;

        public clsUsers UserData { get; set; }

        // منشئ للمستخدم الجديد
        public clsUser()
        {
            this.UserData = new clsUsers { UserID = -1 };
            this.Mode = enMode.AddNew;
        }

        // منشئ خاص لتحميل بيانات موجودة
        private clsUser(clsUsers user)
        {
            this.UserData = user;
            this.Mode = enMode.Update;
        }

        // البحث
        public static async Task<clsUser> FindAsync(int userID)
        {
            var user = await clsUserData.GetUserByIDAsync(userID);
            return (user != null) ? new clsUser(user) : null;
        }

        // تسجيل الدخول
        public static async Task<clsUser> LoginAsync(string username, string password)
        {
            var user = await clsUserData.GetUserByUsernameAndPasswordAsync(username, password);
            if (user != null && user.IsActive)
                return new clsUser(user);
            return null;
        }

        // التحقق من الاسم
        public static async Task<bool> IsUserNameUsedAsync(string userName)
        {
            return await clsUserData.IsUserExistAsync(userName);
        }

        // الحفظ الذكي
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await IsUserNameUsedAsync(this.UserData.UserName))
                        throw new Exception("اسم المستخدم مكرر في النظام.");

                    this.UserData.UserID = await clsUserData.AddNewUserAsync(this.UserData);
                    if (this.UserData.UserID != -1)
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await clsUserData.UpdateUserAsync(this.UserData);
            }
            return false;
        }

        public static async Task<bool> DeleteAsync(int userID)
        {
            return await clsUserData.DeleteUserAsync(userID);
        }

        public static async Task<IEnumerable<clsUser>> GetAllUsersAsync()
        {
            var DataList = await clsUserData.GetAllUsersAsync();

            return


            DataList.Select(user => new clsUser(user)).ToList();
        }

        public static async Task<bool> IsAnyUserExistsAsync()
        {
            return await clsUserData.IsAnyUserExists();
        }
    }
}